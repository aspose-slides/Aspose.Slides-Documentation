# Code samples

Every sample must be self-contained and valid for its platform: include imports/usings and label the
code fence.

Do not use `throw` statements in documentation samples. Handle missing objects, unexpected types,
and unavailable data with conditional branches and non-throwing diagnostic output.

In prose, link each mentioned public API class, interface, method, property, and enumeration directly
to the platform API Reference member page when one exists. Verify the target.

When mentioning a method in prose, omit trailing parentheses from its name, including in link labels:
write `Fonts::GetScriptFont`, not `Fonts::GetScriptFont()`.

## Shared style

- Use clear, descriptive variable names instead of abbreviations, such as `presentation` instead of
  `pres` and `paragraph` instead of `para`. When several objects have the same type, name them by
  purpose rather than numbering them. Follow the platform's naming conventions. Short loop indices
  such as `i` and `j` are acceptable.
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

## Platform rules

Read only the applicable style/API reference:

- Java or Android via Java: [java](platform-java.md).
- Python via Java: [python-java](platform-python-java.md).
- PHP via Java: [php-java](platform-php-java.md).
- C#: [net](platform-net.md).
- C++: [cpp](platform-cpp.md).
