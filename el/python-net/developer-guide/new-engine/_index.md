---
title: Μετάβαση στη Νέα Μηχανή Python-προς-.NET στην Έκδοση 26.8
linktitle: Μετάβαση στη Νέα Μηχανή
type: docs
weight: 290
url: /el/python-net/migrate-to-new-engine/
keywords:
- νέα μηχανή
- μετανάστευση
- aspose.pydrawing
- primitive σχεδίασης
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Μετακινήστε τον κώδικά σας Python στη νέα μηχανή Aspose.Slides στην έκδοση 26.8: μεταφέρετε τα primitives σχεδίασης στο aspose.slides και διορθώστε αυτόματα τις εισαγωγές."
---
## **Εισαγωγή**

Η έκδοση 26.8 αντικαθιστά τη μηχανή που συνδέει την Python με το .NET. Τα primitive σχεδίασης μετακινήθηκαν στο module `aspose.slides`.

Jump straight to [Έχω Σφάλμα](#i-have-an-error) if you have an issues after upgrade.

### **Primitive Σχεδίασης Μεταφέρθηκαν στο aspose.slides**

Μεταφέρθηκαν επτά τύποι. Διατηρούν τα ονόματά τους, τα ορίσματα και τη συμπεριφορά τους:

|Τύπος|Πριν 26.8|26.8 και Μετά|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/el/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/el/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/el/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/el/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/el/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/el/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/el/python-net/aspose.slides/color/)|

Αυτοί οι επτά τύποι ήταν το μοναδικό υπόλοιπο περιεχόμενο του `aspose.pydrawing`. Μόλις τα επαναπροσανατολίσετε, δεν χρειάζεται να αναφερθείτε καθόλου στο `aspose.pydrawing` στον κώδικά σας, και κάθε εισαγωγή του μπορεί να αφαιρεθεί. Αυτό επίσης καθιστά το αποτέλεσμα εύκολο στον έλεγχο – δείτε [Επαλήθευση της Μετανάστευσης](#verify-the-migration).

**Παραδοσιακός κώδικας:**

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

**Έκδοση 26.8:**

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

Η μορφή εισαγωγής `from` αλλάζει με τον ίδιο τρόπο:

```python
# Κώδικας κληρονομίας
from aspose.pydrawing import Color, Point

# Έκδοση 26.8
from aspose.slides import Color, Point
```

## **Διόρθωση Σφάλματος Εισαγωγής**

Βρείτε το traceback σας στην πρώτη στήλη.

|Σφάλμα|Αιτία|Διόρθωση|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|Το πακέτο είναι 26.8, ο κώδικας εξακολουθεί να δείχνει στο παλιό module|[Ενημέρωση του κώδικά σας](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Ίδια αιτία, μορφή εισαγωγής `from`|[Ενημέρωση του κώδικά σας](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Το module και όλοι οι επτά τύποι του μετακινήθηκαν στο `aspose.slides`|[Ενημέρωση του κώδικά σας](#update-your-code), μετά διαγράψτε την εισαγωγή `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Ο κώδικας είχε μεταφερθεί, αλλά το εγκατεστημένο πακέτο είναι 26.7 ή παλαιότερο|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Μια τιμή που δημιουργήθηκε από `aspose.pydrawing` περνά στο νέο API|Δημιουργήστε την τιμή επίσης από `aspose.slides`|

## **Ενημέρωση του Κώδικά σας**

Επειδή το `aspose.pydrawing` δεν έχει περιεχόμενο εκτός από τους επτά μεταφερμένους τύπους, η μετανάστευση είναι μια μετονομασία του module. Κάθε μορφή εισαγωγής καλύπτεται από αυτή τη μονή μετονομασία, συμπεριλαμβανομένων των ψευδωνύμων:

```python
# Κώδικας κληρονομίας
import aspose.pydrawing as drawing
color = drawing.Color.red

# Έκδοση 26.8 - το ψευδώνυμο παραμένει ενεργό
import aspose.slides as drawing
color = drawing.Color.red
```

Αυτό είναι έγκυρο σε οποιοδήποτε scope, συμπεριλαμβανομένου του σώματος μιας συνάρτησης, επειδή το ψευδώνυμο παραμένει δεσμευμένο ακριβώς όπου ήταν δεσμευμένο πριν. Το μόνο μειονέκτημα είναι ένα παραπλανητικό όνομα, οπότε σκεφτείτε να κάνετε το σκοπό σαφές:

```python
import aspose.slides as slides
color = slides.Color.red
```

Επιλέξτε την προσέγγιση που ταιριάζει στο μέγεθος του κώδικά σας.

### **Αντικατάσταση Χειροκίνητα**

Για μερικά αρχεία, ψάξτε για `aspose.pydrawing` και αντικαταστήστε το με `aspose.slides`, τότε αφαιρέστε οποιαδήποτε εισαγωγή δεν χρειάζεται πλέον.

### **Αντικατάσταση με Εντολή Shell**

Αυτή είναι μια αντικατάσταση κειμένου, επομένως επηρεάζει επίσης εμφανίσεις μέσα σε strings και σχόλια. Και οι δύο εντολές γράφουν ένα αντίγραφο `.bak` κάθε αρχείου που αλλάζουν.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Σε macOS, χρησιμοποιήστε `sed -i ''` αντί για `sed -i.bak`, ή εγκαταστήστε GNU sed ως `gsed`.

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

Για επαναφορά σε Linux ή macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Για επαναφορά σε Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Αντικατάσταση με Python Script**

Η ίδια μετονομασία, φορητή σε Linux, macOS και Windows. Το script παίρνει τη διαδρομή ως όρισμα και προεπισκοπεί τις αλλαγές εκτός αν δοθεί `--write`. Προσθέστε `--backup` για να κρατήσετε ένα αντίγραφο `.bak` κάθε τροποποιημένου αρχείου. Αποθηκεύστε το με οποιοδήποτε όνομα – το μήνυμα χρήσης παίρνει το όνομα κατά την εκτέλεση.

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

Μια τυπική εκτέλεση φαίνεται έτσι:

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

Η διαδρομή μπορεί να είναι φάκελος, που περιπλανιέται αναδρομικά, ή ένα μόνο αρχείο `.py`.

### **Αντικατάσταση με Script Βασισμένο σε AST**

Συνιστάται για μεγαλύτερα code bases. Αυτό το script εκτελεί την ίδια μετονομασία, αλλά αναλύει πρώτα το κάθε αρχείο, ώστε να μην αγγίζει εμφανίσεις μέσα σε strings, σχόλια ή docstrings.

Επειδή μετονομάζει το module επί τόπου και αφήνει τα ψευδώνυμα, κάθε μορφή εισαγωγής αντιμετωπίζεται χωρίς ειδικές περιπτώσεις: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, εισαγωγές πολλαπλών γραμμών με παρενθέσεις, εισαγωγές μέσα σε συναρτήσεις, και το module που περνιέται ως τιμή. Αποδέχεται τις ίδιες σημαίες `--write` και `--backup`.

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
        # εισαγωγή aspose.pydrawing [ως X]  /  από aspose.pydrawing import ...
        # Το όνομα του module μετονομάζεται επί τόπου, έτσι οποιοδήποτε ψευδώνυμο παραμένει δεσμευμένο όπως πριν.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Οποιαδήποτε έκφραση που αναφέρεται στο module, συμπεριλαμβανομένου του ακατέργαστου `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # η επεξεργασία από το τέλος προς την αρχή διατηρεί τις μετατοπίσεις έγκυρες
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

Και τα δύο scripts είναι idempotent: η επανεκτέλεσή τους σε κώδικα που έχει ήδη μεταφερθεί δεν κάνει καμία αλλαγή.

## **Επαλήθευση της Μετανάστευσης**

Μια αναζήτηση κειμένου δείχνει αν κάτι απομένει:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Αυτό είναι γρήγορο, αλλά επίσης ταιριάζει μέσα σε strings και σχόλια, οπότε καθαρός κώδικας μπορεί ακόμα να παράγει αποτελέσματα. Για οριστική απάντηση, χρησιμοποιήστε τον παρακάτω έλεγχο. Αναφέρει μόνο πραγματικές αναφορές κώδικα και εξέρχεται με μη μηδενική κατάσταση αν κάτι απομείνει, πράγμα που το κάνει χρήσιμο ως φάκελο κατασκευής.

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

Τρέξτε το πριν και μετά τη μετανάστευση:

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

Τέλος, τρέξτε ένα smoke test που δοκιμάζει τους μεταφερμένους τύπους:

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

## **Συνιστώμενη Σειρά Μεταναστεύσεων**

1. **Αποθήκευση βασικής γραμμής.** Εκτελέστε τις δοκιμές σας στην τρέχουσα έκδοση και κρατήστε αναφορικά renders. Αυτό σας επιτρέπει να διαχωρίσετε σφάλματα μετανάστευσης από διαφορές rendering αργότερα.
2. **Προεπισκόπηση της μετανάστευσης.** Εκτελέστε ένα από τα scripts χωρίς `--write` και ελέγξτε τη λίστα αρχείων που θα αλλάξει.
3. **Εφαρμογή και επαλήθευση.** Εκτελέστε με `--write --backup`, έπειτα το script επαλήθευσης και το smoke test.
4. **Σύγκριση renders με ανοχή.** Η μετάβαση στο .NET 6 build μπορεί να δημιουργήσει μικρές διαφορές σε κείμενο και εφέ. Χρησιμοποιήστε σύγκριση βάσει κατωφλίου αντί για byte‑by‑byte έλεγχο.
5. **Διαγραφή των αντιγράφων ασφαλείας.** Μόλις επιβεβαιώσετε το αποτέλεσμα, διαγράψτε τα αρχεία `.bak`: `find . -name '*.py.bak' -delete` σε Linux και macOS, ή `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` σε Windows.

## **Υποστήριξη Και των Δύο Εκδόσεων σε Ένα Code Base**

Εάν χρειάζεται να τρέξετε εναντίον 26.7 και 26.8 από την ίδια πηγή:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 και αργότερα
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 και παλαιότερα
```

## **Τι Δεν Άλλαξε**

- Ονόματα, ορίσματα και συμπεριφορά των μεταφερόμενων primitive.
- Το υπόλοιπο του API `aspose.slides`.
- Η άδεια χρήσης και ο τρόπος εφαρμογής του αρχείου άδειας.
- Οι μορφές αρχείων και η συμπεριφορά αποθήκευσης/φόρτωσης.
- Απαιτήσεις συστήματος σε Windows και macOS.
- Η απουσία ξεχωριστής εγκατάστασης .NET – το runtime εξακολουθεί να είναι ενσωματωμένο.