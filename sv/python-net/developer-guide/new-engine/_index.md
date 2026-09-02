---
title: Migrera till den nya Python-till-.NET-motorn i version 26.8
linktitle: Migrera till den nya motorn
type: docs
weight: 290
url: /sv/python-net/migrate-to-new-engine/
keywords:
- ny motor
- migrering
- aspose.pydrawing
- ritprimitiver
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Flytta din Python-kod till den nya Aspose.Slides-motorn i version 26.8: flytta ritprimitiver till aspose.slides och åtgärda importerna automatiskt."
---
## **Introduktion**

Version 26.8 ersätter motorn som kopplar Python till .NET. Rita‑primitiverna har flyttats till `aspose.slides`‑modulen.

Hoppa direkt till [Jag har ett fel](#i-have-an-error) om du får problem efter uppgraderingen.

### **Ritprimitiver flyttade till aspose.slides**

Sju typer har flyttats. De behåller sina namn, argument och beteende:

|Typ|Före 26.8|26.8 och senare|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/sv/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/sv/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/sv/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/color/)|

Dessa sju typer utgjorde hela återstående innehållet i `aspose.pydrawing`. När du har ompekat dem behöver ingen kod längre referera till `aspose.pydrawing`, och alla importeringar av den kan tas bort. Det gör också resultatet lätt att kontrollera – se [Verifiera migreringen](#verify-the-migration).

**Gammal kod:**

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

`from`‑importformen ändras på samma sätt:

```python
# Gammal kod
from aspose.pydrawing import Color, Point

# Version 26.8
from aspose.slides import Color, Point
```

## **Åtgärda ett importfel**

Hitta din stackspårning i den första kolumnen.

|Fel|Orsak|Åtgärd|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (eller `Point`, `Rectangle` o.s.v.)|Paketet är 26.8, men koden pekar fortfarande på den gamla modulen|[Uppdatera koden](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Samma orsak, `from`‑importform|[Uppdatera koden](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Modulen och alla dess sju typer har flyttats till `aspose.slides`|[Uppdatera koden](#update-your-code), ta sedan bort `aspose.pydrawing`‑importen|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Koden var migrerad, men det installerade paketet är 26.7 eller äldre|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Ett värde skapat från `aspose.pydrawing` skickas till det nya API:t|Skapa värdet också från `aspose.slides`|

## **Uppdatera din kod**

Eftersom `aspose.pydrawing` inte har något innehåll förutom de sju flyttade typerna, är migreringen ett namnbyte av modulen. Varje importform hanteras av detta enkla namnbyte, inklusive alias:

```python
# Gammal kod
import aspose.pydrawing as drawing
color = drawing.Color.red

# Version 26.8 - aliaset fungerar fortfarande
import aspose.slides as drawing
color = drawing.Color.red
```

Detta är giltigt i alla scoper, inklusive i en funktionskropp, eftersom aliaset förblir bundet exakt där det var bundet tidigare. Den enda nackdelen är ett missvisande namn, så överväg att göra avsikten explicit:

```python
import aspose.slides as slides
color = slides.Color.red
```

Välj den metod som passar storleken på din kodbas.

### **Ersätt manuellt**

För några filer, sök efter `aspose.pydrawing` och ersätt med `aspose.slides`, ta sedan bort eventuell import som inte längre behövs.

### **Ersätt med ett skal‑kommando**

Detta är en raktextersättning, så den påverkar även förekomster i strängar och kommentarer. Båda kommandona skriver en `.bak`‑kopia av varje fil de ändrar.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

På macOS, använd `sed -i ''` istället för `sed -i.bak`, eller installera GNU sed som `gsed`.

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

För att återgå på Linux eller macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

För att återgå på Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Ersätt med ett Python‑skript**

Samma namnbyte, portabelt över Linux, macOS och Windows. Skriptet tar sökvägen som argument och visar en förhandsgranskning av ändringarna om inte `--write` anges. Lägg till `--backup` för att behålla en `.bak`‑kopia av varje ändrad fil. Spara det under valfritt namn – användningsmeddelandet hämtar namnet vid körning.

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

Ett typiskt körning ser ut så här:

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

Vägen kan vara en katalog, som genomsöks rekursivt, eller en enskild `.py`‑fil.

### **Ersätt med ett AST‑baserat skript**

Rekommenderas för större kodbaser. Detta skript utför samma namnbyte, men parsar först varje fil, så att det aldrig rör förekomster i strängar, kommentarer eller docstrings.

Eftersom det byter namn på modulen på plats och låter alias vara kvar, hanteras varje importform utan specialfall: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, flerradiga parenteserade importer, importer inuti funktioner och modulen som värde. Det accepterar samma `--write`‑ och `--backup`‑flaggor.

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
        # importera aspose.pydrawing [som X]  /  från aspose.pydrawing import ...
        # Modulnamnet byts namn på plats, så att alla alias förblir bundna som tidigare.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Alla uttryck som refererar till modulen, inklusive rena `fn(aspose.pydrawing)`.
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

Båda skripten är idempotenta: att köra dem igen på migrerad kod ändrar ingenting.

## **Verifiera migreringen**

En textsökning visar om något återstår:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Detta är snabbt, men det matchar även i strängar och kommentarer, så ren kod kan ändå ge träffar. För ett definitivt svar, använd kontrollen nedan. Den rapporterar bara riktiga kodreferenser och avslutar med en icke‑noll status om något finns kvar, vilket gör den användbar som bygggrind.

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

Kör den före och efter migreringen:

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

Slutligen, kör ett röktest som använder de flyttade typerna:

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

## **Rekommenderad migrationsordning**

1. **Spara en baslinje.** Kör dina tester på den aktuella versionen och behåll referensrenderingar. Detta låter dig separera migrationsfel från renderingsskillnader senare.
2. **Förhandsgranska migreringen.** Kör ett av skripten utan `--write` och granska listan över filer som skulle ändras.
3. **Tillämpa och verifiera.** Kör med `--write --backup`, sedan verifieringsskriptet och röktestet.
4. **Jämför renderingar med en tolerans.** Övergången till .NET 6‑byggnaden kan ge små skillnader i text och effekter. Använd en tröskelbaserad jämförelse snarare än en exakt byte‑för‑byte‑kontroll.
5. **Ta bort säkerhetskopiorna.** När resultatet är bekräftat, ta bort `.bak`‑filerna: `find . -name '*.py.bak' -delete` på Linux och macOS, eller `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` på Windows.

## **Stöd båda versionerna i en kodbas**

Om du behöver köra mot 26.7 och 26.8 från samma källa:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 och senare
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 och tidigare
```

## **Vad som inte ändrades**

- Namn, argument och beteende för de flyttade primitiva typerna.
- Resten av `aspose.slides`‑API‑ytan.
- Licensiering och hur licensfilen appliceras.
- Filformat samt spar‑ och läsbeteende.
- Systemkrav på Windows och macOS.
- Avsaknaden av en separat .NET‑installation – körningsmiljön är fortfarande inbäddad.