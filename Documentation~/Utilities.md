# Utilities

### `[ReadOnly]` Attribute
You can add this attribute to any serialized field _(For non-custom structs)_ and it will prevent the value from being edited
while keeping it visible, useful for debugger, or allowing designers to see what is happening.

![readonly attribute](Images/readonly.PNG)
```csharp
[SerializeField, ReadOnly, Min(0)]
private float speed;
private float _current;

[ReadOnly]
public int test;
```

## Animators
### Ping Pong
> _**NOTE** `Rotation` & `Position` target World Space_ 

![example](Images/pingpong_example.gif)

This animator will Ping-Pong the follow transform values if enabled:
- Position
- Rotation
- Scale

Set the speed _( > 0)_ & the animator curve. This will target the Transform that it's attached to and will run automatically.
### Simple Spin
### Texture Scroller
### Transform Animator
