# Code samples

Every new or changed sample must be self-contained and compilable: include imports/usings and label
the code fence. Validate it according to [validation.md](validation.md). Where runtime validation is
required, verify the behavior described by the article and reopen generated output when applicable.

Do not use `throw` statements in documentation samples. Handle missing objects, unexpected types,
and unavailable data with conditional branches and non-throwing diagnostic output.

In prose, link each mentioned public API class, interface, method, property, and enumeration directly
to the platform API Reference member page when one exists. Verify the target.

## Shared style

- Keep each statement on one physical line. Simplify long statements with meaningful intermediate values.
- Do not create a local only to split a clear property, member-access, indexer, or getter chain.
- Extract values used more than once, runtime casts, side effects, difficult chains, and semantically
  important intermediate results.
- Evaluate non-trivial I/O, loading, parsing, conversion, factory, or lookup calls before passing their
  results to another method. Apply the same rule to semantically meaningful nested construction.
- Clear property/getter/indexer chains may remain in conditions and arguments.
- Do not extract a one-use interpolated string unless part of it needs clarification.
- When a disposable object is created before a `try` block, dispose it directly in `finally` without
  a null check. Keep a null guard only when construction occurs inside `try` and may fail before assignment.

## Java and Android via Java

- Put import declarations at the beginning of every code block and reference imported types by their
  short names. Do not use fully qualified class names in sample bodies.

## PHP via Java

- Put `use` imports at the beginning of every code block and reference imported types by their short
  names. Do not use fully qualified class names in sample bodies.
- In prose, FAQ text, and link labels, separate a PHP class from its method with `::`, as in
  `Presentation::save`; never write a class-qualified PHP method as `Presentation.save`.

## C#

- Use modern using declarations such as `using var presentation = new Presentation();`.
- Use `var` where the type is inferred; retain explicit types where C# requires them.

## C++

- Prefer owner indexed accessors such as `presentation->get_Slide(0)` and `slide->get_Shape(0)` over
  fetching a collection solely to call `idx_get(0)`. Use collections for iteration, counting,
  mutation, or when no direct accessor exists.
- Assign `ExplicitCast<T>(value)` and other runtime casts to a well-named local before member access.
