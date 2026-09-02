---
title: Migrujte na nový engine Python-to-.NET ve verzi 26.8
linktitle: Migrujte na nový engine
type: docs
weight: 290
url: /cs/python-net/migrate-to-new-engine/
keywords:
- nový engine
- migrace
- aspose.pydrawing
- kreslicí primitivy
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Přeneste svůj Python kód na nový engine Aspose.Slides ve verzi 26.8: přesuňte kreslicí primitivy do aspose.slides a automaticky opravte importy."
---
## **Úvod**

Version 26.8 replaces the engine that connects Python to .NET. The drawing primitives moved into the `aspose.slides` module.

Jump straight to [I Have an Error](#i-have-an-error) if you have an issues after upgrade.

### **Kreslicí primitivy přesunuty do aspose.slides**

Sedm typů bylo přesunuto. Zachovávají své názvy, argumenty i chování:

|Typ|Před 26.8|26.8 a novější|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/cs/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/cs/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/color/)|

These seven types were the entire remaining content of `aspose.pydrawing`. Once you have repointed them, nothing in your code needs to reference `aspose.pydrawing` at all, and every import of it can be removed. That also makes the result easy to check - see [Verify the Migration](#verify-the-migration).

**Kód starší verze:**

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

**Verze 26.8:**

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
# Zastaralý kód
from aspose.pydrawing import Color, Point

# Verze 26.8
from aspose.slides import Color, Point
```

## **Opravit importní chybu**

Najděte svou traceback v první sloupci.

|Chyba|Příčina|Oprava|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (nebo `Point`, `Rectangle` a podobně)|Balíček je verze 26.8, kód stále odkazuje na starý modul|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Stejná příčina, forma importu `from`|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Modul a všech sedm jeho typů byly přesunuty do `aspose.slides`|[Update your code](#update-your-code), pak odstraňte import `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Kód byl migrován, ale nainstalovaný balíček je verze 26.7 nebo starší|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Hodnota vytvořená z `aspose.pydrawing` je předána novému API|Vytvořte také hodnotu z `aspose.slides`|

## **Aktualizujte svůj kód**

Protože `aspose.pydrawing` neobsahuje nic jiného než těch sedm přesunutých typů, migrace je přejmenování modulu. Každá forma importu je tímto jedním přejmenováním pokryta, včetně aliasů:

```python
# Zastaralý kód
import aspose.pydrawing as drawing
color = drawing.Color.red

# Verze 26.8 - alias stále funguje
import aspose.slides as drawing
color = drawing.Color.red
```

Toto je platné v libovolném rozsahu, včetně těla funkce, protože alias zůstává svázán přesně tam, kde byl původně. Jedinou nevýhodou je zavádějící název, takže zvažte explicitní vyjádření záměru:

```python
import aspose.slides as slides
color = slides.Color.red
```

Zvolte přístup, který odpovídá rozsahu vašeho kódu.

### **Nahradit ručně**

Pro několik souborů vyhledejte `aspose.pydrawing` a nahraďte jej `aspose.slides`, poté odstraňte jakýkoli import, který již není potřeba.

### **Nahradit pomocí příkazu shellu**

Jedná se o prostou náhradu textu, takže postihne i výskyty v řetězcích a komentářích. Oba příkazy vytvoří `.bak` kopii každého změněného souboru.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Na macOS použijte `sed -i ''` místo `sed -i.bak`, nebo nainstalujte GNU sed jako `gsed`.

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

Pro vrácení změn na Linuxu nebo macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Pro vrácení změn na Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Nahradit pomocí Python skriptu**

Stejné přejmenování, přenositelné napříč Linuxem, macOS a Windows. Skript přijímá cestu jako argument a zobrazí změny, pokud není zadáno `--write`. Přidejte `--backup` pro zachování `.bak` kopie každého upraveného souboru. Uložte jej pod libovolným názvem – zpráva o použití automaticky zjistí název při spuštění.

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

Typický běh vypadá takto:

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

Cesta může být adresář, který se prochází rekurzivně, nebo jediný soubor `.py`.

### **Nahradit pomocí skriptu založeného na AST**

Doporučeno pro větší kódové základny. Tento skript provádí stejné přejmenování, ale nejprve parsuje každý soubor, takže se nedotýká výskytů v řetězcích, komentářích či docstringách.

Protože přejmenovává modul na místě a aliasy nechává, každá forma importu je ošetřena bez speciálních případů: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, víceliniové závorkové importy, importy uvnitř funkcí a modul předávaný jako hodnota. Přijímá stejné příznaky `--write` a `--backup`.

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
        # Název modulu je přejmenován na místě, takže jakýkoli alias zůstává svázán jako dříve.
        # Jakýkoli výraz odkazující na modul, včetně čistého `fn(aspose.pydrawing)`.
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

Oba skripty jsou idempotentní: jejich opětovné spuštění na migrovaném kódu nic nemění.

## **Ověřit migraci**

Textové hledání ukáže, zda něco zůstalo:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Je to rychlé, ale také zachytí výskyty v řetězcích a komentářích, takže čistý kód může stále generovat shody. Pro jednoznačnou odpověď použijte kontrolu níže. Zpráva obsahuje jen skutečné odkazy v kódu a pokud nějaké zůstaly, ukončí se s nenulovým stavem, což ji činí vhodnou jako bránu při sestavování.

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

Spusťte ji před a po migraci:

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

Nakonec spusťte kouřový test, který provede použitelnost přesunutých typů:

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

## **Doporučený pořadí migrace**

1. **Uložte výchozí stav.** Spusťte testy na aktuální verzi a uchovejte referenční výstupy. To vám umožní později oddělit chyby migrace od rozdílů v renderování.
2. **Náhled migrace.** Spusťte jeden ze skriptů bez `--write` a prohlédněte si seznam souborů, které by změnil.
3. **Aplikovat a ověřit.** Spusťte s `--write --backup`, poté ověřovací skript a kouřový test.
4. **Porovnejte rendery s tolerancí.** Přechod na .NET 6 build může způsobit malé rozdíly v textu a efektech. Použijte porovnání založené na prahu místo porovnání byte po bytu.
5. **Odstraňte zálohy.** Jakmile je výsledek potvrzen, smažte soubory `.bak`: `find . -name '*.py.bak' -delete` na Linuxu a macOS, nebo `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` na Windows.

## **Podporovat obě verze v jedné kódové základně**

Pokud potřebujete spouštět verze 26.7 a 26.8 ze stejného zdroje:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 a novější
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 a starší
```

## **Co se nezměnilo**

- Názvy, argumenty a chování přesunutých primitiv.
- Zbytek API `aspose.slides`.
- Licencování a způsob aplikace licenčního souboru.
- Formáty souborů a chování ukládání a načítání.
- Systémové požadavky na Windows a macOS.
- Absence samostatné instalace .NET – runtime je stále součástí balíčku.