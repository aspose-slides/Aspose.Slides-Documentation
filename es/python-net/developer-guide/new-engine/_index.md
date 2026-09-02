---
title: Migrar al nuevo motor Python a .NET en la versión 26.8
linktitle: Migrar al nuevo motor
type: docs
weight: 290
url: /es/python-net/migrate-to-new-engine/
keywords:
- nuevo motor
- migración
- aspose.pydrawing
- primitivas de dibujo
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Transfiera su código Python al nuevo motor Aspose.Slides en la versión 26.8: traslade las primitivas de dibujo a aspose.slides y corrija automáticamente las importaciones."
---
## **Introducción**

La versión 26.8 reemplaza el motor que conecta Python con .NET. Los primitivas de dibujo se trasladaron al módulo `aspose.slides`.

Vaya directamente a [Tengo un error](#i-have-an-error) si tiene algún problema después de la actualización.

### **Primitivas de dibujo trasladadas a aspose.slides**

Siete tipos trasladados. Conservan sus nombres, argumentos y comportamiento:

|Tipo|Antes de 26.8|26.8 y posteriores|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/es/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/es/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/es/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/es/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/es/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/es/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/es/python-net/aspose.slides/color/)|

Estos siete tipos constituían todo el contenido restante de `aspose.pydrawing`. Una vez que los haya redirigido, su código ya no necesita hacer referencia a `aspose.pydrawing`, y todas sus importaciones pueden eliminarse. Eso también facilita la verificación del resultado: vea [Verificar la migración](#verify-the-migration).

**Código heredado:**

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

**Versión 26.8:**

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

La forma de importación `from` cambia de la misma manera:

```python
# Código heredado
from aspose.pydrawing import Color, Point

# Versión 26.8
from aspose.slides import Color, Point
```

## **Solucionar un error de importación**

Encuentre su rastreo en la primera columna.

|Error|Causa|Solución|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (o `Point`, `Rectangle`, etc.)|El paquete es 26.8, el código aún apunta al módulo antiguo|[Actualice su código](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|El mismo motivo, forma de importación `from`|[Actualice su código](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|El módulo y los siete tipos se trasladaron a `aspose.slides`|[Actualice su código](#update-your-code), luego elimine la importación `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|El código se migró, pero el paquete instalado es 26.7 o anterior|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Se pasa un valor creado a partir de `aspose.pydrawing` a la nueva API|Cree el valor también a partir de `aspose.slides`|

## **Actualice su código**

Como `aspose.pydrawing` no tiene contenido aparte de los siete tipos trasladados, la migración es simplemente un cambio de nombre del módulo. Cada forma de importación queda cubierta por ese único cambio, incluidos los alias:

```python
# Código heredado
import aspose.pydrawing as drawing
color = drawing.Color.red

# Versión 26.8 - el alias sigue funcionando
import aspose.slides as drawing
color = drawing.Color.red
```

Esto es válido en cualquier ámbito, incluido dentro del cuerpo de una función, porque el alias sigue vinculado exactamente donde estaba antes. La única desventaja es un nombre engañoso, por lo que considere hacer explícita la intención:

```python
import aspose.slides as slides
color = slides.Color.red
```

Elija el enfoque que se ajuste al tamaño de su base de código.

### **Reemplazar manualmente**

Para unos pocos archivos, busque `aspose.pydrawing` y reemplácelo por `aspose.slides`, luego elimine cualquier importación que ya no sea necesaria.

### **Reemplazar con un comando de shell**

Esto es un reemplazo de texto plano, por lo que también afecta a las apariciones dentro de cadenas y comentarios. Ambos comandos generan una copia `.bak` de cada archivo que modifican.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

En macOS, use `sed -i ''` en vez de `sed -i.bak`, o instale GNU sed como `gsed`.

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

Para revertir en Linux o macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Para revertir en Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Reemplazar con un script de Python**

El mismo cambio de nombre, portátil en Linux, macOS y Windows. El script recibe la ruta como argumento y muestra una vista previa de los cambios a menos que se pase `--write`. Añada `--backup` para conservar una copia `.bak` de cada archivo modificado. Guárdelo con cualquier nombre; el mensaje de uso detecta el nombre en tiempo de ejecución.

```python
"""Renombrar aspose.pydrawing a aspose.slides. Reemplazo de texto plano.

    python <this script> src/                     # vista previa
    python <this script> src/ --write             # aplicar
    python <this script> src/ --write --backup    # aplicar, manteniendo copias .bak
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

Una ejecución típica se ve así:

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

La ruta puede ser un directorio, que se recorre recursivamente, o un único archivo `.py`.

### **Reemplazar con un script basado en AST**

Recomendado para bases de código más grandes. Este script realiza el mismo cambio de nombre, pero analiza cada archivo primero, de modo que nunca toca apariciones dentro de cadenas, comentarios o docstrings.

Como renombra el módulo en el sitio y deja los alias intactos, cada forma de importación se gestiona sin casos especiales: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, importaciones multilínea entre paréntesis, importaciones dentro de funciones y el módulo pasado como valor. Acepta los mismos indicadores `--write` y `--backup`.

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
        # El nombre del módulo se renombra en el sitio, por lo que cualquier alias permanece vinculado como antes.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Cualquier expresión que haga referencia al módulo, incluida una llamada directa `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # de atrás hacia adelante mantiene válidas las posiciones
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

Ambos scripts son idempotentes: volver a ejecutarlos sobre código ya migrado no produce cambios.

## **Verificar la migración**

Una búsqueda de texto muestra si queda algo:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Esto es rápido, pero también coincide dentro de cadenas y comentarios, de modo que el código limpio puede seguir generando coincidencias. Para una respuesta definitiva, use la verificación a continuación. Sólo informa referencias reales al código y finaliza con un estado distinto de cero si quedan, lo que lo hace útil como puerta de compilación.

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

Ejecute la verificación antes y después de la migración:

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

Finalmente, ejecute una prueba rápida que ejercite los tipos trasladados:

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

## **Orden recomendado de migración**

1. **Guarde una referencia base.** Ejecute sus pruebas con la versión actual y conserve renderizados de referencia. Esto le permite separar errores de migración de diferencias de renderizado posteriores.
2. **Previsualice la migración.** Ejecute uno de los scripts sin `--write` y revise la lista de archivos que se modificarían.
3. **Aplique y verifique.** Ejecute con `--write --backup`, luego el script de verificación y la prueba rápida.
4. **Compare las representaciones con una tolerancia.** El paso a la compilación .NET 6 puede producir pequeñas diferencias en texto y efectos. Use una comparación basada en umbrales en lugar de una verificación byte a byte.
5. **Elimine las copias de seguridad.** Una vez confirmado el resultado, borre los archivos `.bak`: `find . -name '*.py.bak' -delete` en Linux y macOS, o `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` en Windows.

## **Compatibilidad con ambas versiones en una única base de código**

Si necesita ejecutar contra 26.7 y 26.8 desde la misma fuente:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 y posteriores
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 y anteriores
```

## **Qué no cambió**

- Nombres, argumentos y comportamiento de los primitivos trasladados.
- El resto de la superficie de la API de `aspose.slides`.
- Licencias y la forma en que se aplica el archivo de licencia.
- Formatos de archivo y el comportamiento de guardado y carga.
- Requisitos del sistema en Windows y macOS.
- La ausencia de una instalación .NET separada: el tiempo de ejecución sigue incluido.