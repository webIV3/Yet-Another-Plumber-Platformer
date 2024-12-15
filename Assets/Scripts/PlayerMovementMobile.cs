using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementMobile : MonoBehaviour
{
	private Rigidbody2D rb;
	private BoxCollider2D coll;
	private SpriteRenderer sprite;
	private Animator anim;

	[SerializeField] private LayerMask jumpableGround;

	private float dirX = 0f;
	[SerializeField] private float moveSpeed = 7f;
	[SerializeField] private float jumpForce = 12f;

	private enum MovementState { idle, running, jumping, falling } //estados para la animacion

	[SerializeField] private AudioSource jumpSoundEffect;
	[SerializeField] private AudioSource brBreak;

	// Use this for initialization
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update() //Movimiento horizontal y salto
	{
		dirX = CrossPlatformInputManager.GetAxis("Horizontal");
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

		if (CrossPlatformInputManager.GetButtonDown("Jump") && IsGrounded())
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				jumpSoundEffect.Play();
			}
		
		UpdateAnimationState();
	}

	private void UpdateAnimationState()  //Condiciones para estado de animacion
	{
		MovementState state;
	
		if (dirX > 0f)
		{
			state = MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			state = MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		if (rb.velocity.y > .1f)
		{
			state = MovementState.jumping;
		}
		else if (rb.velocity.y < -.1f)
		{
			state = MovementState.falling;
		}

		anim.SetInteger("state", (int)state);

	}

	private bool IsGrounded() //Para que luigi no salte infinitamente
	{
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}

	void OnCollisionEnter2D(Collision2D collision) //Si toca un bloque ?, hace toda la funcion que hace el bloque ?
	{
		if (collision.gameObject.CompareTag("QuestionBlock") && collision.gameObject.GetComponent<BlockHit>())
		{
			collision.gameObject.GetComponent<BlockHit>().QuestionBlockBounce();
		}
		if (collision.gameObject.CompareTag("Brick")) //unica solución que se me ocurrio para que haya un sonido al romper un bloque
		{
			brBreak.Play();
		}
	}
}
