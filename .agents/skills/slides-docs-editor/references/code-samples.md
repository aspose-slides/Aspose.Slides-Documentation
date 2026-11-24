# Code samples

Make each sample self-contained. Include the declarations its language requires to use the APIs shown
and label the code fence with the language.

Handle missing objects, unexpected types, and unavailable data with conditional branches and
diagnostic messages. Avoid explicitly raising exceptions in documentation samples.

In prose, link each mentioned public API class, interface, method, property, and enumeration directly
to the platform API Reference member page when one exists. Verify the target.

Omit trailing parentheses from method names in prose and link labels.

## Explain the examples

Every code example must have enough surrounding prose to explain its purpose, the important
settings or decisions, and the expected result. State required input files and assumptions about
their contents when relevant. Explain non-obvious values, units, indices, or API interactions so
readers can adapt the example rather than merely copy it.

Do not leave examples with only a generic introduction such as "The following code shows how to..."
or a list of API names. Scale the explanation to the example's complexity; avoid line-by-line
paraphrases, repeated setup descriptions, and filler added solely to increase length.

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
  results to another method. Extract a nested constructor call into a named variable when the value is reused
  or the name clarifies its role. Keep simple, single-use values inline when their purpose is clear
  from the surrounding call.
- Clear property/getter/indexer chains may remain in conditions and arguments.
- Do not extract a one-use interpolated string unless part of it needs clarification.

## Platform rules

Read only the applicable style/API reference:

- Java or Android via Java: [java](platform-java.md).
- Python via .NET: [python-net](platform-python-net.md).
- Python via Java: [python-java](platform-python-java.md).
- PHP via Java: [php-java](platform-php-java.md).
- Node.js via Java or .NET: [nodejs](platform-nodejs.md).
- C#: [net](platform-net.md).
- C++: [cpp](platform-cpp.md).
