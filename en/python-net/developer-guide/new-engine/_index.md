---
title: Migrate to the New Python-to-.NET Engine in Version 26.8
linktitle: Migrate to the New Engine
type: docs
weight: 290
url: /python-net/migrate-to-new-engine/
keywords:
- new engine
- migration
- aspose.pydrawing
- drawing primitives
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- OpenSSL 3
- Python
- Aspose.Slides
description: "Move your Python code to the new Aspose.Slides engine in version 26.8: relocate drawing primitives to aspose.slides, meet the OpenSSL 3 requirement, and fix imports automatically."
---

## **Introduction**

Version 26.8 of Aspose.Slides for Python via .NET ships a **new connection engine** between the Python layer and the underlying .NET library. The engine changes how .NET types are projected into Python, which has two visible consequences for existing code:

- The drawing primitives previously exposed through `aspose.pydrawing` are now part of the `aspose.slides` module.
- The bundled runtime requires **OpenSSL 3**, so systems that provide only OpenSSL 1.1 are no longer supported.

Neither change affects the behavior of the API itself. `Color.red` means the same thing, `Point` takes the same arguments, and rendering options work as before. Only the module the types come from is different.

If you already have a traceback in front of you, go directly to [Fix an Import Error](#fix-an-import-error).

## **What Changed in Version 26.8**

|Layer|Before 26.8|26.8 and Later|
| :- | :- | :- |
|Python-to-.NET bridge|Previous interop engine|New connection engine|
|Underlying .NET product|Earlier target framework|.NET 6 build of Aspose.Slides for .NET|
|Bundled runtime|Earlier runtime|.NET 10 runtime|
|Cryptography backend|OpenSSL 1.1|OpenSSL 3|

Basing the Python package on the .NET 6 build aligns it with the current .NET product line: the same API surface, the same fixes, and the same rendering semantics. The .NET 10 runtime is bundled, so no separate .NET installation is required.

### **Drawing Primitives Moved to aspose.slides**

Seven types moved. They keep their names, arguments, and behavior:

|Type|Before 26.8|26.8 and Later|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/python-net/aspose.slides/size/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/python-net/aspose.slides/color/)|
|ColorF|`aspose.pydrawing.ColorF`|[aspose.slides.ColorF](https://reference.aspose.com/slides/python-net/aspose.slides/colorf/)|

These seven types were the entire remaining content of `aspose.pydrawing`. Once you have repointed them, nothing in your code needs to reference `aspose.pydrawing` at all, and every import of it can be removed. That also makes the result easy to check — see [Verify the Migration](#verify-the-migration).

**Legacy code:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**Version 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

The `from` import form changes the same way:

```python
# Legacy code
from aspose.pydrawing import Color, Point

# Version 26.8
from aspose.slides import Color, Point
```

## **Fix an Import Error**

Find your traceback in the first column.

|Error|Cause|Fix|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|The package is 26.8, the code still points at the old module|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|The same cause, `from` import form|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|The module and all seven of its types moved into `aspose.slides`|[Update your code](#update-your-code), then delete the `aspose.pydrawing` import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|The code was migrated, but the installed package is 26.7 or older|`pip install --upgrade aspose.slides`|
|`ImportError: libssl.so.3: cannot open shared object file`|The operating system provides OpenSSL 1.1 only|[Meet the OpenSSL 3 requirement](#meet-the-openssl-3-requirement)|
|`TypeError` on a color, point, or size argument|A value created from `aspose.pydrawing` is passed to the new API|Create the value from `aspose.slides` as well|
|`AttributeError` on `get_thumbnail`, `system_image`, or `render_to_graphics`|An earlier change: these members were removed with the Modern API|See [Enhance Image Processing with the Modern API](/slides/python-net/modern-api/)|

## **Meet the OpenSSL 3 Requirement**

Check this before migrating any code. An import error takes a minute to fix, while an unsupported base image blocks an entire build pipeline.

The bundled .NET 10 runtime links against OpenSSL 3. On a system that provides only OpenSSL 1.1, the package fails to load and no code change will help.

|Platform|Status|Note|
| :- | :- | :- |
|Ubuntu 22.04, 24.04|Supported|OpenSSL 3 out of the box|
|Debian 12 (bookworm)|Supported|OpenSSL 3|
|RHEL, Rocky, Alma 9 and later|Supported|OpenSSL 3|
|Amazon Linux 2023|Supported|OpenSSL 3|
|Ubuntu 20.04, Debian 11|Not supported|OpenSSL 1.1 — upgrade the operating system|
|CentOS 7, Amazon Linux 2|Not supported|OpenSSL 1.1 and an outdated glibc|
|Alpine (musl)|Verify separately|Depends on the musl runtime build|
|Windows 10 and later, Server 2016 and later|Supported|No changes required|
|macOS 12 and later|Supported|No changes required|

Verify the environment:

```bash
openssl version                                          # expect OpenSSL 3.x
ldconfig -p | grep -E 'libssl\.so\.3|libcrypto\.so\.3'   # expect two matches
```

For containers, update the base image:

|Old Image|New Image|
| :- | :- |
|`python:3.x-slim-bullseye`|`python:3.x-slim-bookworm`|
|`ubuntu:20.04`|`ubuntu:22.04`|
|`debian:11`|`debian:12`|
|`amazonlinux:2`|`amazonlinux:2023`|
|`centos:7`|`rockylinux:9`|

In GitHub Actions, replace `runs-on: ubuntu-20.04` with `ubuntu-22.04` or `ubuntu-latest`.

## **Update Your Code**

Because `aspose.pydrawing` has no content other than the seven moved types, the migration is a rename of the module. Every import form is covered by that single rename, including aliases:

```python
# Legacy code
import aspose.pydrawing as drawing
color = drawing.Color.red

# Version 26.8 — the alias keeps working
import aspose.slides as drawing
color = drawing.Color.red
```

This is valid in any scope, including inside a function body, because the alias remains bound exactly where it was bound before. The only drawback is a misleading name, so consider making the intent explicit:

```python
import aspose.slides as slides
color = slides.Color.red
```

Choose the approach that matches the size of your code base.

### **Replace Manually**

For a few files, search for `aspose.pydrawing` and replace it with `aspose.slides`, then remove any import that is no longer needed.

### **Replace with a Shell Command**

This is a plain text replacement, so it also affects occurrences inside strings and comments. Both commands write a `.bak` copy of every file they change.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

On macOS, use `sed -i ''` instead of `sed -i.bak`, or install GNU sed as `gsed`.

**Windows PowerShell:**

```powershell
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

To roll back on Linux or macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

To roll back on Windows:

```powershell
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Replace with a Python Script**

The same rename, portable across Linux, macOS, and Windows. The script takes the path as an argument and previews the changes unless `--write` is passed. Add `--backup` to keep a `.bak` copy of every changed file. Save it under any name — the usage message picks the name up at run time.

```python
"""Rename aspose.pydrawing to aspose.slides. Plain text replacement.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

A typical run looks like this:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

The path can be a directory, which is walked recursively, or a single `.py` file.

### **Replace with an AST-Based Script**

Recommended for larger code bases. This script performs the same rename, but parses each file first, so it never touches occurrences inside strings, comments, or docstrings.

Because it renames the module in place and leaves aliases alone, every import form is handled without special cases: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, multi-line parenthesized imports, imports inside functions, and the module passed as a value. It accepts the same `--write` and `--backup` flags.

```python
"""Rename aspose.pydrawing to aspose.slides, skipping strings and comments.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # import aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # The module name is renamed in place, so any alias stays bound as before.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Any expression referring to the module, including bare `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # back to front keeps offsets valid
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

Both scripts are idempotent: running them again on migrated code changes nothing.

## **Verify the Migration**

A text search shows whether anything is left:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

This is quick, but it also matches inside strings and comments, so clean code can still produce hits. For a definitive answer, use the check below. It reports only real code references and exits with a non-zero status if any remain, which makes it usable as a build gate.

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

Run it before and after the migration:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

Finally, run a smoke test that exercises the moved types:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **Recommended Migration Order**

1. **Save a baseline.** Run your tests on the current version and keep reference renders. This lets you separate migration errors from rendering differences later.
2. **Update the environment first.** Move to an OpenSSL 3 image and confirm that your current version still works there. Only then upgrade the package. Changing both at once makes failures hard to attribute.
3. **Preview the migration.** Run one of the scripts without `--write` and review the list of files it would change.
4. **Apply and verify.** Run with `--write --backup`, then the verification script and the smoke test.
5. **Compare renders with a tolerance.** The move to the .NET 6 build may produce small differences in text and effects. Use a threshold-based comparison rather than a byte-for-byte check.
6. **Remove the backups.** Once the result is confirmed, delete the `.bak` files: `find . -name '*.py.bak' -delete` on Linux and macOS, or `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` on Windows.

## **Support Both Versions in One Code Base**

If you need to run against 26.7 and 26.8 from the same source:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 and later
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 and earlier
```

## **What Did Not Change**

- Names, arguments, and behavior of the moved primitives.
- The rest of the `aspose.slides` API surface.
- Licensing and how the license file is applied.
- File formats and the saving and loading behavior.
- System requirements on Windows and macOS.
- The absence of a separate .NET installation — the runtime is still bundled.

# **FAQ**

### Why did the primitives move to `aspose.slides`?

The new engine projects .NET types into Python differently. Under the previous engine, the geometry and color types were surfaced through a separate `aspose.pydrawing` module; the new engine projects them into the main module. This completes the effort started with the [Modern API](/slides/python-net/modern-api/), which removed the remaining `aspose.pydrawing` dependencies from the public API.

### Do I have to uninstall `aspose.pydrawing`?

There is nothing to uninstall. It was never a separate product — it was a module that shipped alongside Aspose Python via .NET packages, not something you install or declare in `requirements.txt`. `pip install` cannot fix a `ModuleNotFoundError` for it; migrating the code is the fix.

### Are there other types in `aspose.pydrawing` that I need to handle?

No. The seven types listed above were its entire remaining content. Members that used `aspose.pydrawing.Image`, `Bitmap`, and `Graphics` were removed earlier with the [Modern API](/slides/python-net/modern-api/).

### Does this change how my presentations render?

The API is unchanged, but the underlying .NET 6 build may produce small pixel-level differences in text and effects. Compare renders with a tolerance rather than byte-for-byte.

### My build agent runs Ubuntu 20.04. Can I stay on it?

No. The bundled runtime requires OpenSSL 3, which Ubuntu 20.04 does not provide. Move to Ubuntu 22.04 or later.

### Can I test the upgrade before committing to it?

Install version 26.8 in a throwaway virtual environment on an OpenSSL 3 image, run the migration script in preview mode, and run your test suite there.

### The migration script renamed the module but my alias is now called `drawing`. Is that a problem?

No, the code is correct — the alias simply points at `aspose.slides`. Rename it if you want the code to read clearly.
