---
title: Migreren naar de nieuwe Python-naar-.NET engine in versie 26.8
linktitle: Migreren naar de nieuwe engine
type: docs
weight: 290
url: /nl/python-net/migrate-to-new-engine/
keywords:
- nieuwe engine
- migratie
- aspose.pydrawing
- drawing primitives
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Verplaats je Python‑code naar de nieuwe Aspose.Slides engine in versie 26.8: verplaats tekenprimitieven naar aspose.slides en corrigeer imports automatisch."
---
## **Inleiding**

Versie 26.8 vervangt de engine die Python met .NET verbindt. De tekenprimitieven zijn verplaatst naar de `aspose.slides` module.

Spring direct naar [Ik heb een fout](#i-have-an-error) als je problemen hebt na de upgrade.

### **Tekenprimitieven verplaatst naar aspose.slides**

|Type|Voor 26.8|26.8 en later|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/nl/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/nl/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/color/)|

Deze zeven typen vormden de volledige resterende inhoud van `aspose.pydrawing`. Zodra je ze opnieuw hebt gepunt, hoeft er in je code niets meer naar `aspose.pydrawing` te verwijzen, en kan elke import ervan worden verwijderd. Dat maakt het resultaat ook gemakkelijk te controleren – zie [Verifieer de migratie](#verify-the-migration).

**Oude code:**

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

**Versie 26.8:**

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

De `from` importvorm verandert op dezelfde manier:

```python
# Oude code
from aspose.pydrawing import Color, Point

# Versie 26.8
from aspose.slides import Color, Point
```

## **Los een importfout op**

Zoek je traceback in de eerste kolom.

|Fout|Oorzaak|Oplossing|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (of `Point`, `Rectangle`, enz.)|De package is 26.8, de code wijst nog naar de oude module|[Werk je code bij](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Dezelfde oorzaak, `from` importvorm|[Werk je code bij](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|De module en alle zeven typen zijn verplaatst naar `aspose.slides`|[Werk je code bij](#update-your-code), verwijder daarna de `aspose.pydrawing` import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|De code is gemigreerd, maar het geïnstalleerde pakket is 26.7 of ouder|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Een waarde gemaakt vanuit `aspose.pydrawing` wordt doorgegeven aan de nieuwe API|Maak de waarde ook vanuit `aspose.slides`|

## **Werk je code bij**

Omdat `aspose.pydrawing` geen andere inhoud heeft dan de zeven verplaatste typen, is de migratie een hernoeming van de module. Elke importvorm wordt gedekt door die enkele hernoeming, inclusief aliassen:

```python
# Oude code
import aspose.pydrawing as drawing
color = drawing.Color.red

# Versie 26.8 - de alias blijft werken
import aspose.slides as drawing
color = drawing.Color.red
```

Dit is geldig in elke scope, ook binnen een functielichaam, omdat de alias exact blijft gebonden waar hij eerder gebonden was. Het enige nadeel is een misleidende naam, overweeg daarom de intentie expliciet te maken:

```python
import aspose.slides as slides
color = slides.Color.red
```

Kies de aanpak die past bij de omvang van je codebasis.

### **Handmatig vervangen**

Voor enkele bestanden, zoek naar `aspose.pydrawing` en vervang dit door `aspose.slides`, verwijder vervolgens elke import die niet meer nodig is.

### **Vervangen met een shell‑opdracht**

Dit is een platte tekstvervanging, dus het beïnvloedt ook voorkomens binnen strings en commentaren. Beide commando's schrijven een `.bak`‑kopie van elk bestand dat ze wijzigen.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Op macOS gebruik je `sed -i ''` in plaats van `sed -i.bak`, of installeer GNU sed als `gsed`.

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

Om terug te gaan op Linux of macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Om terug te gaan op Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Vervangen met een Python‑script**

Dezelfde hernoeming, draagbaar over Linux, macOS en Windows. Het script neemt het pad als argument en toont een voorbeeld van de wijzigingen tenzij `--write` wordt meegegeven. Voeg `--backup` toe om een `.bak`‑kopie van elk gewijzigd bestand te behouden. Sla het op onder een willekeurige naam – het gebruiksbericht haalt de naam tijdens runtime op.

```python
"""Hernoem aspose.pydrawing naar aspose.slides. Vervanging van platte tekst.

    python <this script> src/                     # voorbeeld
    python <this script> src/ --write             # toepassen
    python <this script> src/ --write --backup    # toepassen, .bak-kopieën behouden
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

Een typische uitvoering ziet er als volgt uit:

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

Het pad kan een map zijn, die recursief wordt doorlopen, of een enkel `.py`‑bestand.

### **Vervangen met een AST‑gebaseerd script**

Aanbevolen voor grotere codebases. Dit script voert dezelfde hernoeming uit, maar parseert eerst elk bestand, zodat het nooit voorkomens binnen strings, commentaren of docstrings aanraakt.

Omdat het de module ter plekke hernoemt en aliassen onaangeroerd laat, wordt elke importvorm afgehandeld zonder speciale gevallen: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, meerregelige haakjes‑imports, imports binnen functies, en de module als waarde doorgeven. Het accepteert dezelfde `--write`‑ en `--backup`‑vlaggen.

```python
"""Hernoem aspose.pydrawing naar aspose.slides, strings en commentaren overslaan.

    python <this script> src/                     # voorbeeld
    python <this script> src/ --write             # toepassen
    python <this script> src/ --write --backup    # toepassen, .bak-kopieën behouden
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
        # De modulenaam wordt ter plekke hernoemd, zodat elk alias behouden blijft zoals eerder.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Elke expressie die naar de module verwijst, inclusief een ruwe `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # van achteren naar voren behouden offsets geldig
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

Beide scripts zijn idempotent: ze opnieuw uitvoeren op gemigreerde code verandert niets.

## **Verifieer de migratie**

Een tekstzoekopdracht toont of er nog iets overblijft:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Dit is snel, maar het treft ook binnen strings en commentaren, zodat schone code nog steeds hits kan opleveren. Voor een definitief antwoord, gebruik de onderstaande controle. Deze rapporteert alleen echte code‑referenties en stopt met een niet‑nul status als er nog iets overblijft, waardoor hij bruikbaar is als build‑poort.

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

Voer het uit vóór en na de migratie:

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

Voer tenslotte een smoke‑test uit die de verplaatste typen test:

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

## **Aanbevolen migratievolgorde**

1. **Bewaar een basislijn.** Voer je tests uit op de huidige versie en bewaar referentie‑renders. Hiermee kun je migratiefouten scheiden van renderverschillen later.
2. **Bekijk een preview van de migratie.** Voer een van de scripts uit zonder `--write` en bekijk de lijst met bestanden die het zou wijzigen.
3. **Pas toe en verifieer.** Voer uit met `--write --backup`, vervolgens het verificatiescript en de smoke‑test.
4. **Vergelijk renders met een tolerantie.** De overgang naar de .NET 6‑build kan kleine verschillen in tekst en effecten veroorzaken. Gebruik een drempel‑gebaseerde vergelijking in plaats van een byte‑voor‑byte controle.
5. **Verwijder de back‑ups.** Zodra het resultaat bevestigd is, verwijder je de `.bak`‑bestanden: `find . -name '*.py.bak' -delete` op Linux en macOS, of `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` op Windows.

## **Ondersteun beide versies in één code‑basis**

Als je zowel 26.7 als 26.8 moet draaien vanuit dezelfde bron:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 en later
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 en eerder
```

## **Wat niet veranderde**

- Namen, argumenten en gedrag van de verplaatste primitieven.
- De rest van het `aspose.slides` API‑oppervlak.
- Licenties en hoe het licentiebestand wordt toegepast.
- Bestandsformaten en het opslaan‑ en laadgedrag.
- Systeemvereisten op Windows en macOS.
- Het ontbreken van een aparte .NET‑installatie – de runtime is nog steeds gebundeld.