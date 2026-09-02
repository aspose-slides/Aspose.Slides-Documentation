---
title: "مهاجرت به موتور جدید Python‑to‑.NET در نسخه ۲۶.۸"
linktitle: "مهاجرت به موتور جدید"
type: docs
weight: 290
url: /fa/python-net/migrate-to-new-engine/
keywords:
- "موتور جدید"
- "مهاجرت"
- aspose.pydrawing
- "اجزای رسم"
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "کد Python خود را به موتور جدید Aspose.Slides در نسخه ۲۶.۸ منتقل کنید: اجزای رسم را به aspose.slides جابجا کنید و ایمپورت‌ها را به‌صورت خودکار اصلاح کنید."
---
## **معرفی**

نسخه ۲۶.۸ موتور متصل‌کنندهٔ پایتون به .NET را جایگزین می‌کند. اجزای رسم به ماژول `aspose.slides` منتقل شدند.

اگر پس از ارتقا مشکلی دارید، مستقیماً به [I Have an Error](#i-have-an-error) بروید.

### **اجزای رسم به aspose.slides منتقل شدند**

هفت نوع منتقل شدند. آن‌ها نام، آرگومان و رفتار خود را حفظ می‌کنند:

|نوع|قبل از ۲۶.۸|۲۶.۸ و بعد|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/fa/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/fa/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/fa/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/color/)|

این هفت نوع تمام محتوای باقی‌ماندهٔ `aspose.pydrawing` بودند. پس از تغییر مسیر آن‌ها، دیگر هیچ بخشی از کد شما نیازی به ارجاع به `aspose.pydrawing` ندارد و تمام ایمپورت‌های آن می‌توانند حذف شوند. این همچنین اعتبارسنجی را آسان می‌کند - به [Verify the Migration](#verify-the-migration) نگاه کنید.

**کد قدیمی:**

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

**نسخه ۲۶.۸:**

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

نحو ایمپورت `from` به همان شکل تغییر می‌کند:

```python
# کد قدیمی
from aspose.pydrawing import Color, Point

# نسخه ۲۶.۸
from aspose.slides import Color, Point
```

## **رفع خطای ایمپورت**

ردیابی خطا (traceback) خود را در ستون اول پیدا کنید.

|خطا|دلیل|راه‌حل|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (یا `Point`، `Rectangle` و غیره)|پکیج ۲۶.۸ است، اما کد هنوز به ماژول قدیمی اشاره می‌کند|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|همین دلیل، نحو ایمپورت `from`|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|ماژول و همهٔ هفت نوع آن به `aspose.slides` منتقل شده‌اند|[Update your code](#update-your-code)، سپس ایمپورت `aspose.pydrawing` را حذف کنید|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|کد مهاجرت کرده است، اما پکیج نصب‌شده ۲۶.۷ یا قدیمی‌تر است|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|مقداری که از `aspose.pydrawing` ایجاد شده به API جدید پاس داده شده|مقدار را همچنین از `aspose.slides` ایجاد کنید|

## **به‌روزرسانی کد شما**

از آنجا که `aspose.pydrawing` جز محتوا به جز هفت نوع منتقل شده چیزی ندارد، مهاجرت صرفاً تغییر نام ماژول است. تمام اشکال ایمپورت توسط این تغییر نام تک‌گانه پوشش داده می‌شوند، از جمله مستعارها:

```python
# کد قدیمی
import aspose.pydrawing as drawing
color = drawing.Color.red

# نسخه ۲۶.۸ - مستعار کار می‌کند
import aspose.slides as drawing
color = drawing.Color.red
```

این در هر دامنه‌ای معتبر است، حتی داخل بدنه یک تابع، چون مستعار دقیقاً در همان جایی که قبلاً بایند شده باقی می‌ماند. تنها نکته منفی نام گمراه‌کننده است، بنابراین در نظر داشته باشید هدف را به طور واضح بیان کنید:

```python
import aspose.slides as slides
color = slides.Color.red
```

روشی را انتخاب کنید که متناسب با اندازهٔ پایه کد شما باشد.

### **جایگزینی دستی**

برای تعداد کمی فایل، به‌دنبال `aspose.pydrawing` بگردید و آن را با `aspose.slides` جایگزین کنید، سپس هر ایمپورت غیرضروری را حذف کنید.

### **جایگزینی با فرمان شل**

این یک جایگزینی متن ساده است، بنابراین موارد داخل رشته‌ها و نظرات نیز تحت تأثیر قرار می‌گیرد. هر دو فرمان یک نسخهٔ `.bak` از هر فایل تغییر یافته می‌نویسند.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

در macOS، به جای `sed -i.bak` از `sed -i ''` استفاده کنید یا GNU sed را به عنوان `gsed` نصب کنید.

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

برای بازگشت در Linux یا macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

برای بازگشت در Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **جایگزینی با اسکریپت پایتون**

همان تغییر نام، قابل حمل بر روی Linux، macOS و Windows. اسکریپت مسیر را به‌عنوان آرگومان می‌گیرد و تغییرات را پیش‌نمایش می‌کند مگر اینکه `--write` ارائه شود. برای حفظ یک نسخهٔ `.bak` از هر فایل تغییر یافته `--backup` را اضافه کنید. آن را تحت هر نامی ذخیره کنید؛ پیام استفاده نام را در زمان اجرا می‌گیرد.

```python
"""تغییر نام aspose.pydrawing به aspose.slides. جایگزینی متن ساده.

    python <this script> src/                     # پیش‌نمایش
    python <this script> src/ --write             # اعمال
    python <this script> src/ --write --backup    # اعمال، حفظ نسخه‌های .bak
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

یک اجرا معمولی به این شکل است:

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

مسیر می‌تواند یک پوشه باشد که به‌صورت بازگشتی پیمایش می‌شود یا یک فایل `.py` منفرد.

### **جایگزینی با اسکریپت مبتنی بر AST**

برای پایه‌های کد بزرگتر توصیه می‌شود. این اسکریپت همان تغییر نام را انجام می‌دهد، اما ابتدا هر فایل را پارس می‌کند، بنابراین هرگز موارد داخل رشته‌ها، نظرات یا docstringها را تحت تأثیر قرار نمی‌دهد.

از آنجا که ماژول را در‌جا تغییر نام می‌دهد و مستعارها را دست‌نخورده می‌گذارد، تمام اشکال ایمپورت بدون موارد خاص مدیریت می‌شوند: `import aspose.pydrawing`، `import aspose.pydrawing as X`، `from aspose.pydrawing import Color`، `from aspose.pydrawing import Color as C`، ایمپورت‌های چندخطی داخل پرانتز، ایمپورت‌ها داخل توابع و ماژول به‌عنوان مقدار عبور داده‌شده. همین پرچم‌های `--write` و `--backup` را می‌پذیرد.

```python
"""تغییر نام aspose.pydrawing به aspose.slides، عبور از رشته‌ها و نظرات.

    python <this script> src/                     # پیش‌نمایش
    python <this script> src/ --write             # اعمال
    python <this script> src/ --write --backup    # اعمال، حفظ نسخه‌های .bak
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
        # وارد کردن aspose.pydrawing [as X]  /  از aspose.pydrawing import ...
        # نام ماژول درجا تغییر نام می‌یابد، بنابراین هر مستعاری همان‌طور که قبلاً بایند شده باقی می‌ماند.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # هر عبارت خواستار ماژول، از جمله `fn(aspose.pydrawing)` ساده.
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

هر دو اسکریپت ایندومنت هستند: اجرای دوباره آن‌ها روی کد مهاجرت‌شده تغییری ایجاد نمی‌کند.

## **تأیید مهاجرت**

یک جستجوی متن نشان می‌دهد آیا چیزی باقی مانده است یا نه:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

این سریع است، اما در رشته‌ها و نظرات نیز مطابقت می‌کند، بنابراین حتی کد تمیز ممکن است نتایج بدهد. برای پاسخ قطعی، بررسی زیر را استفاده کنید. این فقط ارجاعات واقعی کد را گزارش می‌دهد و در صورتی که مواردی باقی بماند با وضعیت غیر صفر خارج می‌شود، که آن را برای گیت ساخت قابل استفاده می‌کند.

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

قبل و بعد از مهاجرت آن را اجرا کنید:

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

در نهایت، یک تست Smoke اجرا کنید که انواع منتقل‌شده را تست می‌کند:

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

## **ترتیب پیشنهادی مهاجرت**

1. **یک نقطهٔ پایه ذخیره کنید.** تست‌های خود را بر روی نسخهٔ فعلی اجرا کنید و رندرهای مرجع را نگه دارید. این به شما اجازه می‌دهد خطاهای مهاجرت را از اختلافات رندر بعداً جدا کنید.
2. **پیشنمایش مهاجرت.** یکی از اسکریپت‌ها را بدون `--write` اجرا کنید و لیست فایل‌هایی که تغییر می‌دهند را بررسی کنید.
3. **اعمال و تأیید.** با `--write --backup` اجرا کنید، سپس اسکریپت تأیید و تست Smoke را اجرا کنید.
4. **رندرها را با تحمل مقایسه کنید.** انتقال به ساخت .NET 6 ممکن است تفاوت‌های کوچکی در متن و اثرات ایجاد کند. به جای بررسی بایت به بایت، از مقایسه مبتنی بر آستانه استفاده کنید.
5. **پشتیبان‌ها را حذف کنید.** پس از تأیید نتیجه، فایل‌های `.bak` را حذف کنید: `find . -name '*.py.bak' -delete` در Linux و macOS، یا `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` در Windows.

## **پشتیبانی از هر دو نسخه در یک پایه کد**

اگر لازم است با نسخه‌های ۲۶.۷ و ۲۶.۸ از یک منبع اجرا کنید:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # ۲۶.۸ و بعدی
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # ۲۶.۷ و قبلی
```

## **آنچه تغییر نکرد**

- نام‌ها، آرگومان‌ها و رفتار اجزای منتقل‌شده.
- باقی‌ماندهٔ سطح API `aspose.slides`.
- مجوزها و نحوهٔ اعمال فایل لایسنس.
- قالب‌های فایل و رفتار ذخیره‌سازی و بارگذاری.
- نیازمندی‌های سیستم در Windows و macOS.
- عدم وجود نصب جداگانهٔ .NET - زمان اجرا همچنان بسته‌بندی شده است.