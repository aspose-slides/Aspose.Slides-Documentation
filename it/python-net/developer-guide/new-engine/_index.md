---
title: Migra al nuovo motore Python-to-.NET nella versione 26.8
linktitle: Migra al nuovo motore
type: docs
weight: 290
url: /it/python-net/migrate-to-new-engine/
keywords:
- nuovo motore
- migrazione
- aspose.pydrawing
- primitive di disegno
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Sposta il tuo codice Python sul nuovo motore Aspose.Slides nella versione 26.8: sposta le primitive di disegno su aspose.slides e correggi automaticamente le importazioni."
---
## **Introduzione**

La versione 26.8 sostituisce il motore che collega Python a .NET. Le primitive di disegno sono state spostate nel modulo `aspose.slides`.

Vai direttamente a [Ho un errore](#i-have-an-error) se hai problemi dopo l'aggiornamento.

### **Primitive di Disegno Spostate su aspose.slides**

Sono stati spostati sette tipi. Mantengono i loro nomi, argomenti e comportamento:

|Tipo|Prima della 26.8|26.8 e successive|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/it/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/it/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/it/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/it/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/it/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/it/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/it/python-net/aspose.slides/color/)|

Questi sette tipi costituivano l'intero contenuto rimanente di `aspose.pydrawing`. Una volta reindirizzati, nulla nel tuo codice deve più fare riferimento a `aspose.pydrawing` e ogni importazione di esso può essere rimossa. Questo rende anche più semplice verificare il risultato – vedi [Verifica la migrazione](#verify-the-migration).

**Codice legacy:**

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

**Versione 26.8:**

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

La forma di importazione `from` cambia allo stesso modo:

```python
# Codice legacy
from aspose.pydrawing import Color, Point

# Versione 26.8
from aspose.slides import Color, Point
```

## **Correggi un errore di importazione**

Trova il tuo traceback nella prima colonna.

|Errore|Causa|Correzione|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (o `Point`, `Rectangle` e così via)|Il pacchetto è 26.8, il codice punta ancora al vecchio modulo|[Aggiorna il tuo codice](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|La stessa causa, forma di importazione `from`|[Aggiorna il tuo codice](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Il modulo e tutti e sette i suoi tipi sono stati spostati in `aspose.slides`|[Aggiorna il tuo codice](#update-your-code), poi elimina l'import `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Il codice è stato migrato, ma il pacchetto installato è 26.7 o precedente|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Un valore creato da `aspose.pydrawing` viene passato alla nuova API|Crea anche il valore da `aspose.slides`|

## **Aggiorna il tuo codice**

Poiché `aspose.pydrawing` non contiene altro oltre i sette tipi spostati, la migrazione è una rinomina del modulo. Ogni forma di importazione è coperta da questa singola rinomina, inclusi gli alias:

```python
# Codice legacy
import aspose.pydrawing as drawing
color = drawing.Color.red

# Versione 26.8 - l'alias continua a funzionare
import aspose.slides as drawing
color = drawing.Color.red
```

Questo è valido in qualsiasi ambito, incluso all'interno del corpo di una funzione, perché l'alias rimane legato esattamente dove era legato prima. L'unico inconveniente è un nome fuorviante, quindi considera di rendere esplicita l'intenzione:

```python
import aspose.slides as slides
color = slides.Color.red
```

Scegli l'approccio che corrisponde alla dimensione del tuo code base.

### **Sostituisci manualmente**

Per pochi file, cerca `aspose.pydrawing` e sostituiscilo con `aspose.slides`, poi rimuovi ogni importazione non più necessaria.

### **Sostituisci con un comando shell**

Si tratta di una sostituzione di testo puro, quindi influisce anche sulle occorrenze all'interno di stringhe e commenti. Entrambi i comandi scrivono una copia `.bak` di ogni file modificato.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Su macOS, usa `sed -i ''` invece di `sed -i.bak`, o installa GNU sed come `gsed`.

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

Per ripristinare su Linux o macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Per ripristinare su Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Sostituisci con uno script Python**

La stessa rinomina, portabile su Linux, macOS e Windows. Lo script accetta il percorso come argomento e mostra in anteprima le modifiche a meno che non venga passato `--write`. Aggiungi `--backup` per mantenere una copia `.bak` di ogni file modificato. Salvalo con qualsiasi nome – il messaggio di utilizzo rileva il nome a runtime.

```python
"""Rinominare aspose.pydrawing in aspose.slides. Sostituzione di testo semplice.

    python <this script> src/                     # anteprima
    python <this script> src/ --write             # applica
    python <this script> src/ --write --backup    # applica, mantenendo le copie .bak
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

Un tipico esecuzione appare così:

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

Il percorso può essere una directory, percorsa ricorsivamente, oppure un singolo file `.py`.

### **Sostituisci con uno script basato su AST**

Consigliato per code base più grandi. Questo script esegue la stessa rinomina, ma prima analizza ogni file, così non tocca le occorrenze all'interno di stringhe, commenti o docstring.

Poiché rinomina il modulo in loco e lascia intatti gli alias, ogni forma di importazione è gestita senza casi speciali: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, importazioni multi‑linea tra parentesi, importazioni dentro funzioni e il modulo passato come valore. Accetta le stesse opzioni `--write` e `--backup`.

Entrambi gli script sono idempotenti: eseguirli nuovamente sul codice migrato non apporta modifiche.

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
        # Il nome del modulo è rinominato in loco, quindi ogni alias rimane legato come prima.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Qualsiasi espressione che fa riferimento al modulo, inclusa la forma `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # elaborando dal fondo all'inizio gli offset rimangono validi
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

## **Verifica la migrazione**

Una ricerca testuale mostra se qualcosa è rimasto:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Questo è rapido, ma corrisponde anche all'interno di stringhe e commenti, perciò del codice pulito possono ancora comparire risultati. Per una risposta definitiva, usa il controllo sotto. Riporta solo riferimenti al codice reale ed esce con uno stato diverso da zero se ne restano, rendendolo utilizzabile come gate di build.

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

Eseguilo prima e dopo la migrazione:

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

Infine, esegui un test smoke che utilizza i tipi spostati:

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

## **Ordine di migrazione consigliato**

1. **Salva una baseline.** Esegui i tuoi test sulla versione corrente e conserva i rendering di riferimento. Questo ti consente di separare gli errori di migrazione dalle differenze di rendering in seguito.  
2. **Anteprima della migrazione.** Esegui uno degli script senza `--write` e rivedi l'elenco dei file che verrebbero modificati.  
3. **Applica e verifica.** Esegui con `--write --backup`, poi lo script di verifica e il test smoke.  
4. **Confronta i rendering con una tolleranza.** Il passaggio alla build .NET 6 può produrre piccole differenze in testo ed effetti. Usa un confronto basato su una soglia anziché un controllo byte per byte.  
5. **Rimuovi i backup.** Una volta confermato il risultato, elimina i file `.bak`: `find . -name '*.py.bak' -delete` su Linux e macOS, o `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` su Windows.

## **Supporta entrambe le versioni in un unico code base**

Se devi eseguire sia la 26.7 sia la 26.8 dallo stesso sorgente:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 e successive
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 e precedenti
```

## **Cosa non è cambiato**

- Nomi, argomenti e comportamento delle primitive spostate.  
- Il resto dell'API `aspose.slides`.  
- Licenze e modalità di applicazione del file di licenza.  
- Formati di file e comportamento di salvataggio e caricamento.  
- Requisiti di sistema su Windows e macOS.  
- L'assenza di un'installazione .NET separata – il runtime è ancora incluso.