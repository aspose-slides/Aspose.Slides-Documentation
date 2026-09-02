---
title: Migrer vers le nouveau moteur Python-vers-.NET dans la version 26.8
linktitle: Migrer vers le nouveau moteur
type: docs
weight: 290
url: /fr/python-net/migrate-to-new-engine/
keywords:
- nouveau moteur
- migration
- aspose.pydrawing
- primitives de dessin
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Déplacez votre code Python vers le nouveau moteur Aspose.Slides dans la version 26.8 : relocalisez les primitives de dessin vers aspose.slides et corrigez automatiquement les importations."
---
## **Introduction**

La version 26.8 remplace le moteur qui relie Python à .NET. Les primitives de dessin ont été déplacées dans le module `aspose.slides`.

Jump straight to [I Have an Error](#i-have-an-error) if you have an issues after upgrade.

### **Primitives de dessin déplacées vers aspose.slides**

Sept types ont été déplacés. Ils conservent leurs noms, arguments et comportement :

|Type|Avant 26.8|26.8 et versions ultérieures|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/fr/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/fr/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/color/)|

Ces sept types constituaient l'intégralité du contenu restant de `aspose.pydrawing`. Une fois que vous les avez repointés, votre code n’a plus besoin de faire référence à `aspose.pydrawing`, et chaque importation peut être supprimée. Cela rend également le résultat facile à vérifier – voir [Verify the Migration](#verify-the-migration).

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

La forme d'import `from` change de la même manière:

```python
# Code hérité
from aspose.pydrawing import Color, Point

# Version 26.8
from aspose.slides import Color, Point
```

## **Corriger une erreur d'importation**

Trouvez votre trace d’erreur dans la première colonne.

|Erreur|Cause|Correction|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|Le package est en version 26.8, le code pointe toujours vers l'ancien module|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|La même cause, forme d'import `from`|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Le module et les sept types ont été déplacés dans `aspose.slides`|[Update your code](#update-your-code), then delete the `aspose.pydrawing` import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Le code a été migré, mais le package installé est en version 26.7 ou antérieure|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Une valeur créée à partir de `aspose.pydrawing` est transmise à la nouvelle API|Create the value from `aspose.slides` as well|

## **Mettez à jour votre code**

Comme `aspose.pydrawing` ne contient plus rien d’autre que les sept types déplacés, la migration consiste en un simple renommage du module. Chaque forme d'import est couverte par ce seul renommage, y compris les alias:

```python
# Code hérité
import aspose.pydrawing as drawing
color = drawing.Color.red

# Version 26.8 - l'alias reste fonctionnel
import aspose.slides as drawing
color = drawing.Color.red
```

Ceci est valable dans n'importe quel scope, y compris à l'intérieur du corps d'une fonction, car l'alias reste lié exactement où il l'était auparavant. Le seul inconvénient est un nom trompeur, il peut donc être judicieux de rendre l'intention explicite:

```python
import aspose.slides as slides
color = slides.Color.red
```

Choisissez l'approche qui correspond à la taille de votre base de code.

### **Remplacer manuellement**

Pour quelques fichiers, recherchez `aspose.pydrawing` et remplacez-le par `aspose.slides`, puis supprimez tout import qui n'est plus nécessaire.

### **Remplacer avec une commande shell**

Il s'agit d'un remplacement en texte brut, il affecte donc également les occurrences à l'intérieur des chaînes et des commentaires. Les deux commandes créent une copie `.bak` de chaque fichier modifié.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Sur macOS, utilisez `sed -i ''` au lieu de `sed -i.bak`, ou installez GNU sed sous le nom `gsed`.

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

### **Remplacer avec un script Python**

Le même renommage, portable sur Linux, macOS et Windows. Le script prend le chemin en argument et prévisualise les changements sauf si `--write` est fourni. Ajoutez `--backup` pour conserver une copie `.bak` de chaque fichier modifié. Enregistrez-le sous n'importe quel nom ; le message d’utilisation récupère le nom au moment de l'exécution.

```python
"""Renommer aspose.pydrawing en aspose.slides. Remplacement en texte brut.

    python <this script> src/                     # aperçu
    python <this script> src/ --write             # appliquer
    python <this script> src/ --write --backup    # appliquer, en conservant les copies .bak
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

Un exemple d'exécution ressemble à ceci :

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

Le chemin peut être un répertoire, parcouru récursivement, ou un fichier `.py` unique.

### **Remplacer avec un script basé sur l'AST**

Recommandé pour les bases de code plus importantes. Ce script effectue le même renommage, mais analyse chaque fichier d'abord, de sorte qu'il ne touche jamais les occurrences dans les chaînes, les commentaires ou les docstrings.

Comme il renomme le module en place et laisse les alias intacts, chaque forme d'import est gérée sans cas particuliers : `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, imports parenthésés sur plusieurs lignes, imports à l'intérieur de fonctions, et le module passé comme valeur. Il accepte les mêmes drapeaux `--write` et `--backup`.

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
        # importer aspose.pydrawing [as X] / depuis aspose.pydrawing import ...
        # Le nom du module est renommé sur place, donc tout alias reste lié comme avant.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Toute expression se référant au module, y compris une utilisation directe `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # le traitement de la fin vers le début préserve la validité des offsets
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

Les deux scripts sont idempotents : les exécuter à nouveau sur du code migré ne change rien.

## **Vérifier la migration**

Une recherche textuelle montre s'il reste quelque chose :

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

C’est rapide, mais cela correspond aussi aux occurrences dans les chaînes et les commentaires, de sorte qu'un code propre peut encore produire des résultats. Pour une réponse définitive, utilisez la vérification ci‑dessous. Elle ne signale que les vraies références de code et renvoie un statut non nul s’il en reste, ce qui la rend utilisable comme porte de build.

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

Exécutez‑la avant et après la migration :

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

Enfin, lancez un test de fumée qui exerce les types déplacés :

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

## **Ordre de migration recommandé**

1. **Save a baseline.** Run your tests on the current version and keep reference renders. This lets you separate migration errors from rendering differences later.
2. **Preview the migration.** Run one of the scripts without `--write` and review the list of files it would change.
3. **Apply and verify.** Run with `--write --backup`, then the verification script and the smoke test.
4. **Compare renders with a tolerance.** The move to the .NET 6 build may produce small differences in text and effects. Use a threshold‑based comparison rather than a byte‑for‑byte check.
5. **Remove the backups.** Once the result is confirmed, delete the `.bak` files: `find . -name '*.py.bak' -delete` on Linux and macOS, or `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` on Windows.

## **Prendre en charge les deux versions dans une même base de code**

If you need to run against 26.7 and 26.8 from the same source:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 et versions ultérieures
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 et versions antérieures
```

## **Ce qui n'a pas changé**

- Noms, arguments et comportement des primitives déplacées.
- Le reste de la surface d'API `aspose.slides`.
- Licence et mode d'application du fichier de licence.
- Formats de fichiers ainsi que le comportement de sauvegarde et de chargement.
- Exigences système sur Windows et macOS.
- L'absence d'une installation .NET séparée – le runtime est toujours fourni avec le package.