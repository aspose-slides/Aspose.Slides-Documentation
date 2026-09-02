---
title: Migrasi ke Mesin Python-ke-.NET Baru di Versi 26.8
linktitle: Migrasi ke Mesin Baru
type: docs
weight: 290
url: /id/python-net/migrate-to-new-engine/
keywords:
- mesin baru
- migrasi
- aspose.pydrawing
- primitif gambar
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Pindahkan kode Python Anda ke mesin Aspose.Slides baru pada versi 26.8: alihkan primitif gambar ke aspose.slides, dan perbaiki impor secara otomatis."
---
## **Introduction**

Versi 26.8 menggantikan mesin yang menghubungkan Python ke .NET. Primitif gambar dipindahkan ke modul `aspose.slides`.

Langsung lompat ke [I Have an Error](#i-have-an-error) jika Anda mengalami masalah setelah upgrade.

### **Drawing Primitives Moved to aspose.slides**

Tujuh tipe dipindahkan. Mereka mempertahankan nama, argumen, dan perilakunya:

|Tipe|Sebelum 26.8|26.8 dan Selanjutnya|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/id/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/id/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/id/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/id/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/id/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/id/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/id/python-net/aspose.slides/color/)|

Ketujuh tipe ini adalah seluruh isi yang tersisa dari `aspose.pydrawing`. Setelah Anda mengarahkan ulang mereka, tidak ada lagi kode yang perlu merujuk ke `aspose.pydrawing`, dan setiap impor dapat dihapus. Hal ini juga memudahkan pemeriksaan hasil — lihat [Verify the Migration](#verify-the-migration).

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

Bentuk impor `from` berubah dengan cara yang sama:

```python
# Kode lama
from aspose.pydrawing import Color, Point

# Versi 26.8
from aspose.slides import Color, Point
```

## **Fix an Import Error**

Temukan traceback Anda di kolom pertama.

|Kesalahan|Penyebab|Perbaikan|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (atau `Point`, `Rectangle`, dan sebagainya)|Paketnya 26.8, kode masih menunjuk ke modul lama|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Penyebab yang sama, bentuk impor `from`|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Modul dan ketujuh tipenya dipindahkan ke `aspose.slides`|[Update your code](#update-your-code), lalu hapus impor `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Kode telah dimigrasikan, tetapi paket yang terpasang masih versi 26.7 atau lebih lama|`pip install --upgrade aspose.slides`|
|`TypeError` pada argumen warna, titik, atau ukuran|Nilai yang dibuat dari `aspose.pydrawing` diteruskan ke API baru|Buat nilai tersebut dari `aspose.slides` juga|

## **Update Your Code**

Karena `aspose.pydrawing` tidak memiliki konten selain ketujuh tipe yang dipindahkan, migrasi hanyalah penggantian nama modul. Setiap bentuk impor tercakup oleh pergantian nama tunggal ini, termasuk alias:

```python
# Kode lama
import aspose.pydrawing as drawing
color = drawing.Color.red

# Versi 26.8 - alias tetap berfungsi
import aspose.slides as drawing
color = drawing.Color.red
```

Ini valid dalam ruang lingkup apa pun, termasuk di dalam tubuh fungsi, karena alias tetap terikat persis di tempat sebelumnya. Satu-satunya kelemahan adalah nama yang menyesatkan, jadi pertimbangkan untuk membuat maksudnya lebih eksplisit:

```python
import aspose.slides as slides
color = slides.Color.red
```

Pilih pendekatan yang sesuai dengan ukuran basis kode Anda.

### **Replace Manually**

Untuk beberapa file, cari `aspose.pydrawing` dan gantikan dengan `aspose.slides`, lalu hapus impor yang tidak lagi diperlukan.

### **Replace with a Shell Command**

Ini adalah penggantian teks biasa, sehingga juga memengaruhi kemunculan di dalam string dan komentar. Kedua perintah menulis salinan `.bak` dari setiap file yang diubah.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Di macOS, gunakan `sed -i ''` alih-alih `sed -i.bak`, atau instal GNU sed sebagai `gsed`.

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

Untuk mengembalikan perubahan di Linux atau macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Untuk mengembalikan perubahan di Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Replace with a Python Script**

Penggantian yang sama, dapat dipindahkan lintas Linux, macOS, dan Windows. Skrip menerima jalur sebagai argumen dan menampilkan pratinjau perubahan kecuali `--write` diberikan. Tambahkan `--backup` untuk menyimpan salinan `.bak` setiap file yang diubah. Simpan dengan nama apa pun — pesan penggunaan akan mengambil nama saat dijalankan.

```python
"""Ganti nama aspose.pydrawing menjadi aspose.slides. Penggantian teks biasa.

    python <this script> src/                     # pratinjau
    python <this script> src/ --write             # terapkan
    python <this script> src/ --write --backup    # terapkan, menyimpan salinan .bak
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

Contoh jalankan tipikal:

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

Jalur dapat berupa direktori, yang akan dijelajahi secara rekursif, atau satu file `.py` tunggal.

### **Replace with an AST-Based Script**

Disarankan untuk basis kode yang lebih besar. Skrip ini melakukan penggantian yang sama, tetapi mem-parsing tiap file terlebih dahulu, sehingga tidak menyentuh kemunculan di dalam string, komentar, atau docstring.

Karena ia mengganti modul di tempat dan membiarkan alias tidak berubah, setiap bentuk impor ditangani tanpa kasus khusus: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, impor berparentesis multi‑baris, impor di dalam fungsi, dan modul yang diteruskan sebagai nilai. Skrip menerima flag `--write` dan `--backup` yang sama.

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
        # impor aspose.pydrawing [sebagai X]  /  dari aspose.pydrawing import ...
        # Nama modul diganti di tempat, sehingga setiap alias tetap terikat seperti sebelumnya.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Setiap ekspresi yang merujuk ke modul, termasuk yang langsung seperti `fn(aspose.pydrawing)`.
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

Kedua skrip bersifat idempotent: menjalankannya lagi pada kode yang sudah dimigrasi tidak mengubah apa‑apa.

## **Verify the Migration**

Pencarian teks menunjukkan apakah masih ada yang tersisa:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Ini cepat, namun juga mencocokkan di dalam string dan komentar, sehingga kode bersih masih dapat menghasilkan temuan. Untuk jawaban yang pasti, gunakan pemeriksaan di bawah. Ia hanya melaporkan referensi kode nyata dan keluar dengan status non‑zero bila ada yang masih tersisa, sehingga dapat dipakai sebagai gate build.

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

Jalankan sebelum dan sesudah migrasi:

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

Akhirnya, jalankan tes smoke yang menguji tipe yang dipindahkan:

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

## **Recommended Migration Order**

1. **Save a baseline.** Jalankan tes Anda pada versi saat ini dan simpan render referensi. Ini memungkinkan Anda memisahkan kesalahan migrasi dari perbedaan rendering nantinya.  
2. **Preview the migration.** Jalankan salah satu skrip tanpa `--write` dan tinjau daftar file yang akan diubah.  
3. **Apply and verify.** Jalankan dengan `--write --backup`, kemudian skrip verifikasi dan tes smoke.  
4. **Compare renders with a tolerance.** Perpindahan ke build .NET 6 dapat menghasilkan perbedaan kecil pada teks dan efek. Gunakan perbandingan berbasis ambang, bukan pemeriksaan byte‑per‑byte.  
5. **Remove the backups.** Setelah hasil dikonfirmasi, hapus file `.bak`: `find . -name '*.py.bak' -delete` pada Linux dan macOS, atau `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` pada Windows.

## **Support Both Versions in One Code Base**

Jika Anda perlu menjalankan kode terhadap 26.7 dan 26.8 dari sumber yang sama:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 dan selanjutnya
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 dan sebelumnya
```

## **What Did Not Change**

- Nama, argumen, dan perilaku primitif yang dipindahkan.  
- Sisa permukaan API `aspose.slides`.  
- Lisensi dan cara file lisensi diterapkan.  
- Format file serta perilaku penyimpanan dan pemuatan.  
- Persyaratan sistem pada Windows dan macOS.  
- Tidak adanya instalasi .NET terpisah – runtime masih dibundel.