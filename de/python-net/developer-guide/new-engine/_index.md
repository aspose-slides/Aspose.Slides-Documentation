---
title: Migration zur neuen Python-zu-.NET-Engine in Version 26.8
linktitle: Migration zur neuen Engine
type: docs
weight: 290
url: /de/python-net/migrate-to-new-engine/
keywords:
- neue Engine
- Migration
- aspose.pydrawing
- Zeichenprimitive
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Verschieben Sie Ihren Python-Code zur neuen Aspose.Slides-Engine in Version 26.8: verlegen Sie Zeichenprimitive nach aspose.slides und korrigieren Sie Importe automatisch."
---
## **Einführung**

Version 26.8 ersetzt die Engine, die Python mit .NET verbindet. Die Zeichenprimitive wurden in das Modul `aspose.slides` verschoben.

Springen Sie direkt zu [Ich habe einen Fehler](#i-have-an-error), wenn Sie nach dem Upgrade Probleme haben.

### **Zeichenprimitive nach aspose.slides verschoben**

|Typ|Vor 26.8|26.8 und später|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/de/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/de/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/de/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/de/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/de/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/de/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/de/python-net/aspose.slides/color/)|

Diese sieben Typen stellten den gesamten verbleibenden Inhalt von `aspose.pydrawing` dar. Sobald Sie sie umgeleitet haben, muss Ihr Code überhaupt nicht mehr auf `aspose.pydrawing` verweisen, und jeder Import davon kann entfernt werden. Das erleichtert auch die Überprüfung – siehe [Migration überprüfen](#verify-the-migration).

**Legacy-Code:**

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

Die `from`-Import-Form ändert sich auf dieselbe Weise:

```python
# Legacy-Code
from aspose.pydrawing import Color, Point

# Version 26.8
from aspose.slides import Color, Point
```

## **Importfehler beheben**

Suchen Sie die Traceback-Ausgabe in der ersten Spalte.

|Fehler|Ursache|Lösung|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|Das Paket ist 26.8, der Code verweist noch auf das alte Modul|[Aktualisieren Sie Ihren Code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Dasselbe Problem, `from`-Import-Form|[Aktualisieren Sie Ihren Code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Das Modul und alle sieben seiner Typen wurden in `aspose.slides` verschoben|[Aktualisieren Sie Ihren Code](#update-your-code), dann löschen Sie den `aspose.pydrawing`-Import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Der Code wurde migriert, aber das installierte Paket ist 26.7 oder älter|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Ein Wert, der aus `aspose.pydrawing` erstellt wurde, wird an die neue API übergeben|Erstellen Sie den Wert ebenfalls aus `aspose.slides`|

## **Ihren Code aktualisieren**

Da `aspose.pydrawing` keinen anderen Inhalt als die sieben verschobenen Typen hat, besteht die Migration ausschließlich aus einer Umbenennung des Moduls. Jede Import-Form wird durch diese eine Umbenennung abgedeckt, einschließlich Aliasen:

```python
# Legacy-Code
import aspose.pydrawing as drawing
color = drawing.Color.red

# Version 26.8 - der Alias funktioniert weiterhin
import aspose.slides as drawing
color = drawing.Color.red
```

Dies ist in jedem Gültigkeitsbereich gültig, auch innerhalb einer Funktionsdefinition, da das Alias genau dort gebunden bleibt, wo es vorher gebunden war. Der einzige Nachteil ist ein irreführender Name, daher sollten Sie die Absicht explizit machen:

```python
import aspose.slides as slides
color = slides.Color.red
```

Wählen Sie den Ansatz, der zur Größe Ihres Codebestands passt.

### **Manuell ersetzen**

Für einige Dateien suchen Sie nach `aspose.pydrawing` und ersetzen es durch `aspose.slides`, anschließend entfernen Sie alle nicht mehr benötigten Importe.

### **Mit einem Shell-Befehl ersetzen**

Dies ist ein einfacher Textaustausch, daher werden auch Vorkommen in Zeichenketten und Kommentaren geändert. Beide Befehle schreiben eine `.bak`‑Kopie jeder geänderten Datei.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Unter macOS verwenden Sie `sed -i ''` anstelle von `sed -i.bak` oder installieren GNU sed als `gsed`.

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

Um unter Linux oder macOS zurückzurollen:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Um unter Windows zurückzurollen:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Mit einem Python‑Skript ersetzen**

Die gleiche Umbenennung, portabel für Linux, macOS und Windows. Das Skript nimmt den Pfad als Argument und zeigt die Änderungen an, sofern nicht `--write` angegeben wird. Fügen Sie `--backup` hinzu, um eine `.bak`‑Kopie jeder geänderten Datei zu behalten. Speichern Sie es unter einem beliebigen Namen – die Hilfemeldung ermittelt den Namen zur Laufzeit.

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

Ein typischer Durchlauf sieht so aus:

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

Der Pfad kann ein Verzeichnis sein, das rekursiv durchsucht wird, oder eine einzelne `.py`‑Datei.

### **Mit einem AST‑basierten Skript ersetzen**

Empfohlen für größere Codebasen. Dieses Skript führt die gleiche Umbenennung durch, parsed jedoch zunächst jede Datei, sodass Vorkommen in Zeichenketten, Kommentaren oder Docstrings nie verändert werden.

Da es das Modul an Ort und Stelle umbenennt und Aliase unverändert lässt, wird jede Import-Form ohne Sonderfälle behandelt: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, mehrzeilige, geklammerte Importe, Importe innerhalb von Funktionen und das Modul, das als Wert übergeben wird. Es akzeptiert dieselben Flags `--write` und `--backup`.

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
        # Der Modulname wird an Ort und Stelle umbenannt, sodass jedes Alias wie zuvor gebunden bleibt.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Jeder Ausdruck, der auf das Modul verweist, einschließlich eines nackten `fn(aspose.pydrawing)`.
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

Beide Skripte sind idempotent: Ein erneutes Ausführen auf migriertem Code ändert nichts.

## **Migration überprüfen**

Eine Textsuche zeigt, ob noch etwas übrig ist:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Dies ist schnell, trifft jedoch auch in Zeichenketten und Kommentaren zu, sodass sauberer Code immer noch Treffer erzeugen kann. Für eine eindeutige Antwort benutzen Sie die nachstehende Prüfung. Sie meldet nur echte Code-Referenzen und beendet sich mit einem von Null verschiedenen Status, falls noch welche vorhanden sind, was sie als Build‑Gate nutzbar macht.

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

Führen Sie es vor und nach der Migration aus:

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

Abschließend führen Sie einen Smoke‑Test aus, der die verschobenen Typen verwendet:

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

## **Empfohlene Migrationsreihenfolge**

1. **Erstellen Sie eine Ausgangsbasis.** Führen Sie Ihre Tests mit der aktuellen Version aus und behalten Sie Referenz‑Renderings. So können Sie Migrationsfehler später von Render‑Unterschieden trennen.
2. **Vorschau der Migration.** Führen Sie eines der Skripte ohne `--write` aus und prüfen Sie die Liste der zu ändernden Dateien.
3. **Anwenden und überprüfen.** Führen Sie es mit `--write --backup` aus, danach das Verifizierungs‑Skript und den Smoke‑Test.
4. **Renderings mit Toleranz vergleichen.** Der Umstieg auf das .NET‑6‑Build kann kleine Unterschiede in Text und Effekten erzeugen. Verwenden Sie einen Schwellenwert‑basierten Vergleich statt eines byte‑für‑byte‑Checks.
5. **Backups entfernen.** Sobald das Ergebnis bestätigt ist, löschen Sie die `.bak`‑Dateien: `find . -name '*.py.bak' -delete` unter Linux und macOS oder `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` unter Windows.

## **Unterstützung beider Versionen in einem Code‑Bestand**

Falls Sie sowohl gegen 26.7 als auch 26.8 aus derselben Quelle laufen lassen müssen:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 und später
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 und früher
```

## **Was sich nicht geändert hat**

- Namen, Argumente und Verhalten der verschobenen Primitive.
- Der Rest der `aspose.slides`‑API‑Oberfläche.
- Lizenzierung und wie die Lizenzdatei angewendet wird.
- Dateiformate sowie das Speicher‑ und Ladeverhalten.
- Systemanforderungen unter Windows und macOS.
- Das Fehlen einer separaten .NET‑Installation – die Laufzeit ist weiterhin gebündelt.