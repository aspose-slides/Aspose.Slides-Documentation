# Code sample validation

For every platform, validate every code fence added or modified in the current diff. Each must pass
compilation against the real Aspose.Slides library. Where compilation is inapplicable, execute each
example against the real library and require it to complete without errors. Syntax parsing, import
checks, reflection, and method-signature checks do not replace compilation or required execution.
Do not skip API calls or replace them with mocks.

For .NET, also execute the examples, verify the relevant object state, and reopen saved files to
verify the result described in the article. For other platforms, separate object-state, saved-output,
or visual checks are not required unless explicitly requested.

Use the existing `tools/<platform>/snippet-check/` checker and read its `README.md` when present.
README files describe how to invoke the tools; they do not replace the validation requirements above.
If it cannot select individual fences, supply temporary inputs containing only the changed fences:
Python files for Python launchers, or Markdown for checkers that accept Markdown.
Use the article directly only when all its fences changed. Keep temporary inputs inside the checker
and remove them afterward. Do not alter articles for validation, create ad hoc projects, or install
another product copy; reuse existing dependencies and runtimes.

## Platform checks

Read only the applicable platform instructions:

- .NET: [validation-net.md](validation-net.md).
- Android via Java: [validation-androidjava.md](validation-androidjava.md).
- Node.js via Java: [validation-nodejs-java.md](validation-nodejs-java.md).
- Python via Java: compilation is inapplicable; execute the examples through JPype using
  `tools/python-java/snippet-check/run.cmd`.
- Python via .NET: compilation is inapplicable; execute the examples using
  `tools/python-net/snippet-check/run.cmd` and its supported commands. Use the supplied Python 3
  runtime, not `python` from `PATH`.
- All other platforms: apply the compilation-or-execution requirement above using the existing
  platform checker and runtime.

For .NET, Java, C++, Android via Java, and Node.js via Java, use this command with the repository
platform folder name and the input selected above; Node.js additionally requires `-Docker`:

```powershell
powershell -ExecutionPolicy Bypass -File tools\<platform>\snippet-check\check-snippets.ps1 -Article <validation-input>
```

## Reporting

For each article, report `compilation: passed`, `compilation: failed`, or `compilation: not applicable`.
For `not applicable`, also report `execution against the real library: passed / failed / not run`.
Report the number of examples that passed the required compilation or execution out of the total
requiring validation. Failed or unrun required checks are unresolved issues; do not present the
article as complete. If no code fence changed, report `code unchanged`.

Only .NET requires the additional behavioral report defined in its reference. For other platforms,
report compilation or the required execution results only.
