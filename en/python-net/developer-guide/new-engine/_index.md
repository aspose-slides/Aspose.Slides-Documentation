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
- Python
- Aspose.Slides
description: "Move your Python code to the new Aspose.Slides engine in version 26.8: relocate drawing primitives to aspose.slides, and fix imports automatically."
---

## **Introduction**

Version 26.8 replaces the engine that connects Python to .NET. The drawing primitives moved into the `aspose.slides` module.

Jump straight to [I Have an Error](#i-have-an-error) if you have an issues after upgrade.

### **Drawing Primitives Moved to aspose.slides**

Seven types moved. They keep their names, arguments, and behavior:

|Type|Before 26.8|26.8 and Later|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/python-net/aspose.slides/color/)|

These seven types were the entire remaining content of `aspose.pydrawing`. Once you have repointed them, nothing in your code needs to reference `aspose.pydrawing` at all, and every import of it can be removed. That also makes the result easy to check - see [Verify the Migration](#verify-the-migration).

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
|`TypeError` on a color, point, or size argument|A value created from `aspose.pydrawing` is passed to the new API|Create the value from `aspose.slides` as well|

## **Update Your Code**

Because `aspose.pydrawing` has no content other than the seven moved types, the migration is a rename of the module. Every import form is covered by that single rename, including aliases:

```python
# Legacy code
import aspose.pydrawing as drawing
color = drawing.Color.red

# Version 26.8 - the alias keeps working
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

```
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

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Replace with a Python Script**

The same rename, portable across Linux, macOS, and Windows. The script takes the path as an argument and previews the changes unless `--write` is passed. Add `--backup` to keep a `.bak` copy of every changed file. Save it under any name - the usage message picks the name up at run time.

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
2. **Preview the migration.** Run one of the scripts without `--write` and review the list of files it would change.
3. **Apply and verify.** Run with `--write --backup`, then the verification script and the smoke test.
4. **Compare renders with a tolerance.** The move to the .NET 6 build may produce small differences in text and effects. Use a threshold-based comparison rather than a byte-for-byte check.
5. **Remove the backups.** Once the result is confirmed, delete the `.bak` files: `find . -name '*.py.bak' -delete` on Linux and macOS, or `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` on Windows.

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
- The absence of a separate .NET installation - the runtime is still bundled.
