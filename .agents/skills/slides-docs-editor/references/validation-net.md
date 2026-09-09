# .NET validation

Use `tools/net/` to compile and run the applicable examples. Verify their relevant in-memory state;
reopen saved output and confirm the described objects, properties, content, and effects. If console
output is a described result of an example, capture it and verify that it matches the article's
description. For variable output, check the relevant values or format rather than requiring an
exact match of the entire output. Add only minimal temporary invocations or assertions to the
existing validator.

For each article with changed code, also report:

- `runtime behavior: passed — the examples perform the operations described in the article` only
  after every applicable example passes the state, saved-output, and applicable console-output checks.
- `runtime behavior: failed` if any applicable example fails or was not run; describe the unresolved
  issue. Compilation alone does not establish correct behavior.
