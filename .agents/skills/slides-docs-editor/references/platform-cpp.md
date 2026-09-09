# C++

- Prefer namespace imports after the include declarations and use short class and interface names in
  sample bodies. Keep a fully qualified name only when needed to resolve an ambiguity.
- Prefer `auto` for local variables initialized from an expression or simple literal, including
  loop counters and collection indexes. Retain an explicit type when its width or signedness is
  semantically important, when it controls overload resolution, or when type deduction would obscure
  the sample.
- Prefer owner indexed accessors such as `presentation->get_Slide(0)` and `slide->get_Shape(0)` over
  fetching a collection solely to call `idx_get(0)`. Use collections for iteration, counting,
  mutation, or when no direct accessor exists.
- Assign `ExplicitCast<T>(value)` and other runtime casts to a well-named local before member access.
