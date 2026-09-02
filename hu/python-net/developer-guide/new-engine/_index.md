---
title: Az új Python-to-.NET motorra való migráció a 26.8-as verzióban
linktitle: Átállás az új motorra
type: docs
weight: 290
url: /hu/python-net/migrate-to-new-engine/
keywords:
- új motor
- migráció
- aspose.pydrawing
- rajzolási primitívek
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Helyezze át a Python kódját az új Aspose.Slides motorra a 26.8-as verzióban: a rajzolási primitíveket költöztesse át az aspose.slides-ba, és javítsa automatikusan az importokat."
---
## **Bevezetés**

A 26.8-as verzió lecseréli a Python és a .NET összekapcsolásáért felelős motort. A rajzolási primitívek az `aspose.slides` modulba kerültek.

Ugrás közvetlenül a [Hiba történt](#i-have-an-error) részre, ha a frissítés után problémák merülnek fel.

### **A rajzolási primitívek áthelyezve az aspose.slides modulba**

Hét típus került áthelyezésre. Megőrzik neveiket, argumentumaikat és viselkedésüket:

|Típus|26.8 előtti|26.8 és később|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/hu/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/hu/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/color/)|

Ezek a hét típus alkották a `aspose.pydrawing` teljes maradék tartalmát. Miután átirányítottad őket, a kódban már nincs szükség a `aspose.pydrawing` hivatkozásra, és minden importja eltávolítható. Ezáltal az eredmény könnyen ellenőrizhető – lásd a [Migráció ellenőrzése](#verify-the-migration) részt.

**Régi kód:**

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

**26.8-as verzió:**

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

Az `from` import szintaxisa is ugyanígy változik:

```python
# Régi kód
from aspose.pydrawing import Color, Point

# 26.8-as verzió
from aspose.slides import Color, Point
```

## **Import hiba javítása**

Keresd a traceback-et az első oszlopban.

|Hiba|Ok|Javítás|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (vagy `Point`, `Rectangle`, stb.)|A csomag 26.8-as, a kód még a régi modulra mutat|[Frissítsd a kódot](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Ugyanaz az ok, `from` import szintaxisa|[Frissítsd a kódot](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|A modul és a hét típusa áthelyezésre került az `aspose.slides` modulba|[Frissítsd a kódot](#update-your-code), majd töröld az `aspose.pydrawing` importot|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|A kód migrálva van, de a telepített csomag 26.7 vagy régebbi|`pip install --upgrade aspose.slides`|
|`TypeError` a szín, pont vagy méret argumentumnál|Egy `aspose.pydrawing`-ból létrehozott érték kerül átadásra az új API-nak|Hozd létre az értéket `aspose.slides`-ból is|

## **Kód frissítése**

Mivel a `aspose.pydrawing` tartalma csak a hét áthelyezett típust tartalmazza, a migráció csupán a modul átnevezése. Minden import forma lefedésre kerül ezzel az egyetlen átnevezéssel, beleértve az aliasokat is:

```python
# Régi kód
import aspose.pydrawing as drawing
color = drawing.Color.red

# 26.8-as verzió - az alias továbbra is működik
import aspose.slides as drawing
color = drawing.Color.red
```

Ez bármely hatókörben érvényes, beleértve a függvénytesteken belül is, mert az alias pontosan ott marad, ahol korábban is volt. Egyetlen hátránya a félrevezető név, ezért érdemes a szándékot egyértelművé tenni:

```python
import aspose.slides as slides
color = slides.Color.red
```

Válaszd azt a megközelítést, amely a kódod méretének megfelel.

### **Kézi cserélés**

Néhány fájlnál keresd meg a `aspose.pydrawing`-t, cseréld le `aspose.slides`-ra, majd távolítsd el a már nem szükséges importot.

### **Cserélés parancssorral**

Ez egyszerű szöveges csere, ezért a karakterláncokban és megjegyzésekben is módosítja a megjelenéseket. Mindkét parancs `.bak` másolatot készít az összes módosított fájlról.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

macOS alatt használd a `sed -i ''`-t a `sed -i.bak` helyett, vagy telepíts GNU sed-et `gsed` néven.

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

A visszagörgetés Linux vagy macOS esetén:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

A visszagörgetés Windows esetén:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Cserélés Python szkripttel**

Ugyanaz az átnevezés, hordozható Linux, macOS és Windows rendszereken. A szkript a útvonalat paraméterként kapja, és a változtatásokat csak akkor hajtja végre, ha a `--write` kapcsolót megadod. A `--backup` kapcsolóval `.bak` másolatot készíthetsz minden módosított fájlról. Mentsd el tetszőleges néven – a használati üzenet a futás időpontjában veszi fel a nevet.

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

Egy tipikus futás így néz ki:

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

Az útvonal lehet könyvtár, amelyet rekurzívan bejár, vagy egyetlen `.py` fájl.

### **Cserélés AST-alapú szkripttel**

Ajánlott nagyobb kódbázisok esetén. A szkript ugyanazt az átnevezést végzi, de előbb elemzi a fájlt, így soha nem érint karakterláncokat, megjegyzéseket vagy docstringeket.

Mivel a modul nevét helyben átnevezi, az aliasokat érintetlenül hagyja, ezért minden import forma kezelhető speciális esetek nélkül: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, több soros zárójelezett importok, függvényeken belüli importok, valamint a modul értékként történő átadása. Elfogadja ugyanazt a `--write` és `--backup` kapcsolót.

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
        # importálás aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # A modul neve helyben kerül átnevezésre, így minden alias a korábbihoz hasonlóan megmarad.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Bármely kifejezés, amely a modulra hivatkozik, beleértve a `fn(aspose.pydrawing)` egyszerű hívást is.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # visszafelé haladva a pozíciók érvényesek maradnak
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

Mindkét szkript idempotens: újbóli futtatásuk migrált kódban nem változtat semmit.

## **Migráció ellenőrzése**

Egy szöveges keresés megmutatja, maradt‑e még bármi:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Ez gyors, de a karakterláncokban és megjegyzésekben is találatot ad, így tiszta kód is adhat találatot. A végleges válaszhoz használd az alábbi ellenőrzést. Csak a tényleges kódhivatkozásokat jelzi, és ha marad valamelyik, nem‑nulla kilépési kóddal tér vissza, ami építési kapuként használható.

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

Futtasd a migráció előtt és után:

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

Végül hajts végre egy füsttesztet, amely a áthelyezett típusokat használja:

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

## **Ajánlott migrációs sorrend**

1. **Készíts biztonsági mentést.** Futassa a teszteket a jelenlegi verzión, és őrizd meg a referencia rendereléseket. Ez segít a migrációs hibákat a renderelésbeli különbségektől elkülöníteni.
2. **Nézd át a migrációt.** Futtass egy szkriptet `--write` nélkül, és ellenőrizd a módosítandó fájlok listáját.
3. **Alkalmazd és ellenőrizd.** Futtasd `--write --backup` kapcsolókkal, majd a ellenőrző szkriptet és a füsttesztet.
4. **Hasonlítsd össze a rendereléseket toleranciával.** A .NET 6-ra való áttérés apró eltéréseket okozhat szövegben és effektusokban. Használj küszöbérték‑alapú összehasonlítást a bitek‑közti ellenőrzés helyett.
5. **Töröld a mentéseket.** Miután az eredmény megerősítést nyert, távolítsd el a `.bak` fájlokat: `find . -name '*.py.bak' -delete` Linux és macOS esetén, vagy `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` Windows alatt.

## **Mindkét verzió támogatása egy kódbázisban**

Ha ugyanazból a forrásból kell mind a 26.7, mind a 26.8 verzióval futtatni:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 és újabb
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 és korábbi
```

## **Mi nem változott**

- A áthelyezett primitívek nevei, argumentumai és viselkedése.
- Az `aspose.slides` API többi része.
- Licencelés és a licencfájl alkalmazása.
- Fájlformátumok és a mentés/ betöltés viselkedése.
- Rendszerkövetelmények Windowson és macOS-en.
- A külön .NET telepítés hiánya – a runtime továbbra is be van csomagolva.