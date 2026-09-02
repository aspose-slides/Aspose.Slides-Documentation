---
title: Migracja do nowego silnika Python-to-.NET w wersji 26.8
linktitle: Migracja do nowego silnika
type: docs
weight: 290
url: /pl/python-net/migrate-to-new-engine/
keywords:
- nowy silnik
- migracja
- aspose.pydrawing
- podstawowe elementy rysowania
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Przenieś swój kod Python do nowego silnika Aspose.Slides w wersji 26.8: przenieś podstawowe elementy rysowania do aspose.slides i automatycznie napraw importy."
---
## **Wprowadzenie**

Wersja 26.8 zastępuje silnik łączący Pythona z .NET. Podstawowe elementy rysowania zostały przeniesione do modułu `aspose.slides`.

Przejdź od razu do [Mam błąd](#i-have-an-error), jeśli po aktualizacji wystąpią problemy.

### **Podstawowe elementy rysowania przeniesione do aspose.slides**

Przeniesiono siedem typów. Zachowują one swoje nazwy, argumenty i zachowanie:

|Typ|Przed 26.8|26.8 i później|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/pl/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/pl/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/pl/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/color/)|

Te siedem typów stanowiło całą pozostałą zawartość `aspose.pydrawing`. Po przekierowaniu ich nie musisz już nigdzie w kodzie odwoływać się do `aspose.pydrawing`; wszystkie jego importy mogą zostać usunięte. To także ułatwia weryfikację – zobacz [Zweryfikuj migrację](#verify-the-migration).

**Kod starszy:**

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

**Wersja 26.8:**

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

Forma importu `from` zmienia się w ten sam sposób:

```python
# Stary kod
from aspose.pydrawing import Color, Point

# Wersja 26.8
from aspose.slides import Color, Point
```

## **Napraw błąd importu**

Znajdź traceback w pierwszej kolumnie.

|Błąd|Przyczyna|Rozwiązanie|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|Pakiet jest w wersji 26.8, a kod nadal wskazuje na stary moduł|[Zaktualizuj swój kod](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Ta sama przyczyna, forma importu `from`|[Zaktualizuj swój kod](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Moduł i wszystkie jego siedem typów zostały przeniesione do `aspose.slides`|[Zaktualizuj swój kod](#update-your-code), a następnie usuń import `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Kod został zmigrowany, ale zainstalowany pakiet jest wersją 26.7 lub starszą|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Wartość utworzona z `aspose.pydrawing` została przekazana do nowego API|Utwórz wartość również z `aspose.slides`|

## **Zaktualizuj swój kod**

Ponieważ `aspose.pydrawing` nie zawiera nic oprócz siedmiu przeniesionych typów, migracja polega jedynie na zmianie nazwy modułu. Wszystkie formy importu są obsługiwane przez tę jedną zmianę, włącznie z aliasami:

```python
# Stary kod
import aspose.pydrawing as drawing
color = drawing.Color.red

# Wersja 26.8 - alias nadal działa
import aspose.slides as drawing
color = drawing.Color.red
```

Jest to poprawne w dowolnym zakresie, w tym wewnątrz ciała funkcji, ponieważ alias pozostaje związany dokładnie tam, gdzie był wcześniej. Jedyną wadą jest myląca nazwa, więc rozważ wyraźne zaznaczenie intencji:

```python
import aspose.slides as slides
color = slides.Color.red
```

Wybierz podejście, które odpowiada rozmiarowi Twojej bazy kodu.

### **Zastąp ręcznie**

Dla kilku plików wyszukaj `aspose.pydrawing` i zamień go na `aspose.slides`, a następnie usuń niepotrzebne importy.

### **Zastąp za pomocą polecenia powłoki**

Jest to zamiana zwykłego tekstu, więc wpływa także na wystąpienia w ciągach znaków i komentarzach. Oba polecenia zapisują kopię `.bak` każdego zmienianego pliku.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

W macOS użyj `sed -i ''` zamiast `sed -i.bak` lub zainstaluj GNU sed jako `gsed`.

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

Aby cofnąć zmiany w Linux lub macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Aby cofnąć zmiany w Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Zastąp skryptem Python**

Ta sama zmiana nazwy, przenośna między Linux, macOS i Windows. Skrypt przyjmuje ścieżkę jako argument i wyświetla podgląd zmian, chyba że podano `--write`. Dodaj `--backup`, aby zachować kopię `.bak` każdego zmienionego pliku. Zapisz go pod dowolną nazwą – komunikat użycia pobiera nazwę w czasie uruchomienia.

```python
"""Zmień nazwę aspose.pydrawing na aspose.slides. Zastąpienie zwykłym tekstem.

    python <this script> src/                     # podgląd
    python <this script> src/ --write             # zastosuj
    python <this script> src/ --write --backup    # zastosuj, zachowując kopie .bak
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

Przykładowe uruchomienie wygląda tak:

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

Ścieżka może być katalogiem, który jest przeszukiwany rekurencyjnie, lub pojedynczym plikiem `.py`.

### **Zastąp skryptem opartym na AST**

Zalecane dla większych baz kodu. Skrypt wykonuje tę samą zmianę nazwy, ale najpierw parsuje każdy plik, dzięki czemu nie modyfikuje wystąpień w ciągach, komentarzach ani docstringach.

Ponieważ zmienia nazwę modułu w miejscu i pozostawia aliasy, wszystkie formy importu są obsługiwane bez specjalnych przypadków: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, wieloliniowe importy w nawiasach, importy wewnątrz funkcji oraz przekazywanie modułu jako wartości. Akceptuje te same flagi `--write` i `--backup`.

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
        # Nazwa modułu jest zmieniana w miejscu, więc każdy alias pozostaje związany tak jak wcześniej.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Każde wyrażenie odnoszące się do modułu, w tym surowe `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # od końca do początku zachowuje poprawność offsetów
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

Oba skrypty są idempotentne: ponowne uruchomienie ich na już zmigrowanym kodzie nie wprowadza zmian.

## **Zweryfikuj migrację**

Wyszukiwanie tekstowe pokazuje, czy coś pozostało:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Jest to szybkie, ale dopasowuje także wystąpienia w ciągach i komentarzach, więc czysty kod może nadal generować wyniki. Aby uzyskać ostateczną odpowiedź, użyj poniższego sprawdzenia. Raportuje jedynie rzeczywiste odwołania w kodzie i kończy działanie z niezerowym kodem wyjścia, jeśli coś pozostanie, co umożliwia użycie go jako bramki w procesie budowania.

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

Uruchom go przed i po migracji:

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

Na koniec uruchom test weryfikacyjny, który wykorzystuje przeniesione typy:

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

## **Zalecana kolejność migracji**

1. **Zapisz punkt odniesienia.** Uruchom testy na bieżącej wersji i zachowaj referencyjne renderingi. To pozwala później odróżnić błędy migracji od różnic w renderowaniu.
2. **Podgląd migracji.** Uruchom jeden ze skryptów bez `--write` i przejrzyj listę plików, które miałby zmienić.
3. **Zastosuj i zweryfikuj.** Uruchom z `--write --backup`, a następnie skrypt weryfikacyjny i test weryfikacyjny.
4. **Porównaj renderingi z tolerancją.** Przejście na kompilację .NET 6 może wprowadzić małe różnice w tekście i efektach. Użyj porównania opartego na progach zamiast porównania bajt po bajcie.
5. **Usuń kopie zapasowe.** Gdy wynik zostanie potwierdzony, usuń pliki `.bak`: `find . -name '*.py.bak' -delete` w Linux i macOS lub `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` w Windows.

## **Obsługa obu wersji w jednej bazie kodu**

Jeśli musisz uruchamiać kod przeciwko wersjom 26.7 i 26.8 z tego samego źródła:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 i później
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 i wcześniejsze
```

## **Co się nie zmieniło**

- Nazwy, argumenty i zachowanie przeniesionych podstawowych elementów.
- Reszta interfejsu API `aspose.slides`.
- Licencjonowanie i sposób stosowania pliku licencji.
- Formaty plików oraz zachowanie przy zapisywaniu i wczytywaniu.
- Wymagania systemowe na Windows i macOS.
- Brak osobnej instalacji .NET – środowisko uruchomieniowe nadal jest w pakiecie.