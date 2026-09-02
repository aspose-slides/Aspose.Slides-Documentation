---
title: ย้ายไปยังเอนจิ้น Python-to-.NET ใหม่ในเวอร์ชัน 26.8
linktitle: ย้ายไปยังเอนจิ้นใหม่
type: docs
weight: 290
url: /th/python-net/migrate-to-new-engine/
keywords:
- เอนจิ้นใหม่
- การย้าย
- aspose.pydrawing
- primitive การวาด
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "ย้ายโค้ด Python ของคุณไปยังเอนจิ้น Aspose.Slides ใหม่ในเวอร์ชัน 26.8: ย้าย primitive การวาดไปยัง aspose.slides และแก้ไขการนำเข้าโดยอัตโนมัติ."
---
## **บทนำ**

เวอร์ชัน 26.8 แทนที่เอ็นจิินที่เชื่อมต่อ Python กับ .NET. primitive การวาดถูกย้ายไปยังโมดูล `aspose.slides`.

ข้ามไปที่ [ฉันมีข้อผิดพลาด](#i-have-an-error) หากคุณมีปัญหา หลังการอัพเกรด.

### **Primitive การวาดที่ย้ายไปยัง aspose.slides**

มีการย้ายชนิดทั้งหมดเจ็ดชนิด. ชนิดเหล่านี้เก็บชื่อ, อาร์กิวเมนต์, และพฤติกรรมไว้เหมือนเดิม:

|ประเภท|ก่อน 26.8|26.8 และหลัง|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/th/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/th/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/th/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/th/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/th/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/th/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/th/python-net/aspose.slides/color/)|

เจ็ดชนิดนี้เป็นเนื้อหาที่เหลือทั้งหมดของ `aspose.pydrawing`. หลังจากที่คุณได้ชี้ใหม่แล้ว, โค้ดของคุณไม่จำเป็นต้องอ้างอิง `aspose.pydrawing` อีกเลย, และการนำเข้าทั้งหมดของมันสามารถลบได้. สิ่งนี้ทำให้การตรวจสอบผลลัพธ์ง่ายขึ้น - ดู [ตรวจสอบการย้าย](#verify-the-migration).

**โค้ดเก่า:**

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

**เวอร์ชัน 26.8:**

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

รูปแบบการนำเข้า `from` มีการเปลี่ยนแปลงในลักษณะเดียวกัน:

```python
# โค้ดเก่า
from aspose.pydrawing import Color, Point

# เวอร์ชัน 26.8
from aspose.slides import Color, Point
```

## **แก้ไขข้อผิดพลาดการนำเข้า**

ค้นหา traceback ของคุณในคอลัมน์แรก.

|ข้อผิดพลาด|สาเหตุ|การแก้ไข|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|แพคเกจเป็น 26.8, โค้ดยังชี้ไปที่โมดูลเก่า|[อัปเดตโค้ดของคุณ](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|สาเหตุเดียวกัน, รูปแบบการนำเข้า `from`|[อัปเดตโค้ดของคุณ](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|โมดูลและชนิดทั้งเจ็ดได้ย้ายไปยัง `aspose.slides`|[อัปเดตโค้ดของคุณ](#update-your-code), แล้วลบการนำเข้า `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|โค้ดได้ทำการย้ายแล้ว, แต่แพคเกจที่ติดตั้งคือ 26.7 หรือเก่ากว่า|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|ค่าที่สร้างจาก `aspose.pydrawing` ถูกส่งไปยัง API ใหม่|สร้างค่าโดยใช้ `aspose.slides` ด้วยเช่นกัน|

## **อัปเดตโค้ดของคุณ**

เนื่องจาก `aspose.pydrawing` ไม่มีเนื้อหาอื่นนอกจากชนิดเจ็ดที่ย้าย, การย้ายคือการเปลี่ยนชื่อของโมดูล. รูปแบบการนำเข้าทั้งหมดจะครอบคลุมด้วยการเปลี่ยนชื่อนี้, รวมถึง alias:

```python
# โค้ดเก่า
import aspose.pydrawing as drawing
color = drawing.Color.red

# เวอร์ชัน 26.8 - alias ยังคงทำงาน
import aspose.slides as drawing
color = drawing.Color.red
```

สิ่งนี้ใช้ได้ในทุกสโคป, รวมถึงภายในบอดี้ของฟังก์ชัน, เพราะ alias ยังคงผูกไว้ในตำแหน่งเดิม. ข้อจำกัดเดียวคือชื่อที่อาจทำให้เข้าใจผิด, ดังนั้นพิจารณาให้เจตนาเป็นลักษณะชัดเจน:

```python
import aspose.slides as slides
color = slides.Color.red
```

เลือกวิธีที่ตรงกับขนาดของฐานโค้ดของคุณ.

### **แทนที่ด้วยตนเอง**

สำหรับไฟล์ไม่กี่ไฟล์, ค้นหา `aspose.pydrawing` และแทนที่ด้วย `aspose.slides`, แล้วลบการนำเข้าที่ไม่จำเป็นอีกต่อไป.

### **แทนที่ด้วยคำสั่ง Shell**

นี่เป็นการแทนที่แบบข้อความธรรมดา, ดังนั้นจึงส่งผลต่อการปรากฏในสตริงและคอมเมนต์ด้วย. ทั้งสองคำสั่งจะเขียนไฟล์สำเนา `.bak` ของทุกไฟล์ที่เปลี่ยนแปลง.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

บน macOS, ใช้ `sed -i ''` แทน `sed -i.bak`, หรือทำการติดตั้ง GNU sed เป็น `gsed`.

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

เพื่อกู้คืนบน Linux หรือ macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

เพื่อกู้คืนบน Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **แทนที่ด้วยสคริปต์ Python**

การเปลี่ยนชื่อเดียวกัน, พกพาได้บน Linux, macOS, และ Windows. สคริปต์รับพาธเป็นอาร์กิวเมนต์และแสดงตัวอย่างการเปลี่ยนแปลงหากไม่ได้ส่ง `--write`. เพิ่ม `--backup` เพื่อเก็บสำเนา `.bak` ของทุกไฟล์ที่เปลี่ยน. บันทึกเป็นชื่อใดก็ได้ - ข้อความการใช้งานจะดึงชื่อขึ้นมาขณะรัน.

```python
"""เปลี่ยนชื่อ aspose.pydrawing เป็น aspose.slides การแทนที่เป็นข้อความธรรมดา.

    python <this script> src/                     # แสดงตัวอย่าง
    python <this script> src/ --write             # ใช้งาน
    python <this script> src/ --write --backup    # ใช้งาน, เก็บสำเนา .bak
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

การเรียกใช้งานทั่วไปมีลักษณะดังนี้:

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

พาธสามารถเป็นไดเรกทอรีที่สแกนแบบรีเคอร์ซีฟ, หรือไฟล์ `.py` เพียงไฟล์เดียว.

### **แทนที่ด้วยสคริปต์ที่ใช้ AST**

แนะนำสำหรับฐานโค้ดที่ใหญ่กว่า. สคริปต์นี้ทำการเปลี่ยนชื่อเดียวกัน, แต่จะพาร์เซไฟล์แต่ละไฟล์ก่อน, ดังนั้นจะไม่แตะต้องการปรากฏในสตริง, คอมเมนต์, หรือ docstring.

เพราะสคริปต์เปลี่ยนชื่อโมดูลในที่และปล่อย alias ไว้, รูปแบบการนำเข้าทุกแบบจะถูกจัดการโดยไม่มีกรณีพิเศษ: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, การนำเข้าแบบหลายบรรทัดในวงเล็บ, การนำเข้าในฟังก์ชัน, และการส่งโมดูลเป็นค่า. รองรับ флаг `--write` และ `--backup` เหมือนเดิม.

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
        # นำเข้า aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # ชื่อโมดูลถูกเปลี่ยนชื่อในที่, ดังนั้น alias ใดก็ยังคงผูกอยู่เหมือนเดิม
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # นิพจน์ใดๆ ที่อ้างอิงโมดูล, รวมถึง `fn(aspose.pydrawing)` อย่างเดียว
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # การทำจากหลังไปหน้า ทำให้ตำแหน่งออฟเซ็ตยังคงถูกต้อง
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

สคริปต์ทั้งสองเป็น idempotent: การรันซ้ำบนโค้ดที่ย้ายแล้วจะไม่เปลี่ยนแปลงอะไรเลย.

## **ตรวจสอบการย้าย**

การค้นหาข้อความจะแสดงว่ามีอะไรเหลืออยู่หรือไม่:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

การตรวจสอบนี้รวดเร็ว, แต่ก็จะจับคู่ในสตริงและคอมเมนต์ด้วย, ดังนั้นโค้ดที่สะอาดอาจยังพบผลลัพธ์. เพื่อคำตอบที่ชัดเจน, ใช้การตรวจสอบด้านล่าง. มันรายงานเฉพาะการอ้างอิงโค้ดจริงและออกด้วยสถานะไม่เป็นศูนย์หากเหลืออะไร, ทำให้ใช้เป็นเกตการสร้างได้.

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

รันก่อนและหลังการย้าย:

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

สุดท้าย, รันการทดสอบ smoke ที่เรียกใช้ชนิดที่ย้าย:

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

## **ลำดับการย้ายที่แนะนำ**

1. **บันทึกฐานข้อมูล.** รันการทดสอบของคุณบนเวอร์ชันปัจจุบันและเก็บผลการเรนเดอร์อ้างอิง. สิ่งนี้ทำให้คุณแยกข้อผิดพลาดการย้ายจากความแตกต่างของการเรนเดอร์ในภายหลัง.
2. **ชมภาพรวมการย้าย.** รันสคริปต์ใดสคริปต์หนึ่งโดยไม่ใช้ `--write` และตรวจสอบรายการไฟล์ที่มันจะเปลี่ยน.
3. **นำไปใช้และตรวจสอบ.** รันด้วย `--write --backup`, จากนั้นสคริปต์ตรวจสอบและการทดสอบ smoke.
4. **เปรียบเทียบการเรนเดอร์ด้วยทอลแรนซ์.** การย้ายไปยัง .NET 6 อาจทำให้เกิดความแตกต่างเล็กน้อยในข้อความและเอฟเฟกต์. ใช้วิธีเปรียบเทียบแบบเกณฑ์แทนการตรวจสอบไบต์ต่อไบต์.
5. **ลบไฟล์สำรอง.** เมื่อผลลัพธ์ได้รับการยืนยัน, ลบไฟล์ `.bak`: `find . -name '*.py.bak' -delete` บน Linux และ macOS, หรือ `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` บน Windows.

## **สนับสนุนทั้งสองเวอร์ชันในฐานโค้ดเดียว**

หากคุณต้องการรันกับ 26.7 และ 26.8 จากแหล่งเดียวกัน:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 และต่อไป
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 และก่อนหน้า
```

## **สิ่งที่ไม่เปลี่ยนแปลง**

- ชื่อ, อาร์กิวเมนต์, และพฤติกรรมของ primitive ที่ย้าย
- ส่วนที่เหลือของ API `aspose.slides`
- การให้ลิขสิทธิ์และวิธีการใช้ไฟล์ลิขสิทธิ์
- รูปแบบไฟล์และพฤติกรรมการบันทึกและโหลด
- ความต้องการของระบบบน Windows และ macOS
- การไม่มีการติดตั้ง .NET แยกต่างหาก - runtime ยังคงถูกรวมไว้