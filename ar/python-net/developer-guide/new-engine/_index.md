---
title: الترقية إلى محرك Python إلى .NET الجديد في الإصدار 26.8
linktitle: الترقية إلى المحرك الجديد
type: docs
weight: 290
url: /ar/python-net/migrate-to-new-engine/
keywords:
- محرك جديد
- ترحيل
- aspose.pydrawing
- بدائيات الرسم
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "انقل شيفرة Python الخاصة بك إلى محرك Aspose.Slides الجديد في الإصدار 26.8: انقل بدائيات الرسم إلى aspose.slides، وقم بإصلاح الاستيرادات تلقائيًا."
---
## **مقدمة**

الإصدار 26.8 يحل محل المحرك الذي يربط Python بـ .NET. انتقلت بدائيات الرسم إلى وحدة `aspose.slides`.

انتقل مباشرة إلى [I Have an Error](#i-have-an-error) إذا واجهت مشاكل بعد الترقية.

### **بدائيات الرسم نُقلت إلى aspose.slides**

تم نقل سبعة أنواع. تحتفظ بأسمائها، ومعاملاتها، وسلوكها:

|النوع|قبل 26.8|26.8 وما بعد|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/ar/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/ar/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/ar/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/color/)|

كانت هذه الأنواع السبعة هي المحتوى المتبقي الكامل لـ `aspose.pydrawing`. بعد إعادة توجيهها، لا يحتاج أي جزء من الشيفرة إلى الإشارة إلى `aspose.pydrawing` على الإطلاق، ويمكن حذف جميع الاستيرادات الخاصة بها. هذا يجعل التحقق من النتيجة سهلًا – راجع [Verify the Migration](#verify-the-migration).

**شيفرة قديمة:**

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

**الإصدار 26.8:**

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

شكل الاستيراد `from` يتغير بنفس الطريقة:

```python
# كود قديم
from aspose.pydrawing import Color, Point

# الإصدار 26.8
from aspose.slides import Color, Point
```

## **إصلاح خطأ الاستيراد**

ابحث عن تتبع الأخطاء في العمود الأول.

|الخطأ|السبب|الحل|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (أو `Point`، `Rectangle`، وما إلى ذلك)|الحزمة هي 26.8، ولا يزال الكود يشير إلى الوحدة القديمة|[Update your code](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|نفس السبب، شكل الاستيراد `from`|[Update your code](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|الوحدة وجميع الأنواع السبعة نُقلت إلى `aspose.slides`|[Update your code](#update-your-code)، ثم احذف استيراد `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|تم ترحيل الكود، لكن الحزمة المثبتة هي 26.7 أو أقدم|`pip install --upgrade aspose.slides`|
|`TypeError` على لون أو نقطة أو حجم|قيمة تم إنشاؤها من `aspose.pydrawing` تم تمريرها إلى الـ API الجديد|إنشاء القيمة من `aspose.slides` أيضًا|

## **تحديث الشيفرة الخاصة بك**

نظرًا لأن `aspose.pydrawing` لا يحتوي على أي محتوى بخلاف الأنواع السبعة المنقولة، فإن الترقيّة هي مجرد إعادة تسمية الوحدة. جميع صيغ الاستيراد مغطاة بهذه إعادة التسمية الوحيدة، بما في ذلك الأقسام المستعارة:

```python
# كود قديم
import aspose.pydrawing as drawing
color = drawing.Color.red

# الإصدار 26.8 - يظل الاسم المستعار يعمل
import aspose.slides as drawing
color = drawing.Color.red
```

هذا صالح في أي نطاق، بما في ذلك داخل جسم الدالة، لأن القسم المستعار يظل مرتبطًا تمامًا حيث كان مرتبطًا قبل ذلك. العيب الوحيد هو الاسم المضلٍّ، لذا فكر في جعل النية صريحة:

```python
import aspose.slides as slides
color = slides.Color.red
```

اختر النهج الذي يتناسب مع حجم قاعدة الشيفرة الخاصة بك.

### **الاستبدال يدويًا**

لعدد قليل من الملفات، ابحث عن `aspose.pydrawing` واستبدله بـ `aspose.slides`، ثم احذف أي استيراد لم يعد مطلوبًا.

### **الاستبدال بأمر سطر الأوامر**

هذا استبدال نصي عادي، لذا سيؤثر أيضًا على الظهور داخل السلاسل التعليقات. كلا الأمرين يكتبان نسخة `.bak` من كل ملف يتم تغييره.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

على macOS، استخدم `sed -i ''` بدلاً من `sed -i.bak`، أو ثبّت GNU sed كـ `gsed`.

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

للعودة إلى الحالة السابقة على Linux أو macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

للعودة إلى الحالة السابقة على Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **الاستبدال باستخدام برنامج Python**

نفس عملية إعادة التسمية، ويمكن تشغيلها على Linux و macOS و Windows. يأخذ البرنامج المسار كمعامل ويعرض التغييرات مسبقًا ما لم يتم تمرير `--write`. أضف `--backup` للاحتفاظ بنسخة `.bak` من كل ملف تم تغييره. احفظه بأي اسم – سيتم التعرف على الاسم تلقائيًا عند التنفيذ.

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

تشغيل نموذجي يبدو هكذا:

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

يمكن أن يكون المسار دليلًا يُستكشف بصورة متكررة، أو ملف `.py` واحد.

### **الاستبدال باستخدام برنامج قائم على AST**

مُوصى به لقاعدة شيفرة أكبر. يقوم هذا البرنامج بنفس عملية إعادة التسمية، لكنه يحلّل كل ملف أولًا، وبالتالي لا يلمس الظهور داخل السلاسل أو التعليقات أو السلاسل التوثيقية.

نظرًا لأنه يعيد تسمية الوحدة في مكانها ويترك الأقسام المستعارة كما هي، يتم معالجة جميع صيغ الاستيراد دون حالات استثنائية: `import aspose.pydrawing`، `import aspose.pydrawing as X`، `from aspose.pydrawing import Color`، `from aspose.pydrawing import Color as C`، الاستيرادات المتعددة الأسطر داخل أقواس، الاستيرادات داخل الدوال، وتمرير الوحدة كقيمة. يقبل نفس العلامات `--write` و`--backup`.

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
        # استيراد aspose.pydrawing [كـ X]  /  من aspose.pydrawing استيراد ...
        # يتم إعادة تسمية اسم الوحدة في مكانها، لذا يبقى أي اسم مستعار مرتبط كما كان.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # أي تعبير يشير إلى الوحدة، بما في ذلك `fn(aspose.pydrawing)` الصريح.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # المعالجة من الخلف إلى الأمام تحافظ على صحة الإزاحات
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

كلا البرنامجين متعادلان: تشغيلهما مرة أخرى على الشيفرة المُهجرة لا يغيّر شيئًا.

## **التحقق من الترقيّة**

بحث نصي يُظهر ما إذا كان هناك أي بقايا:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

هذا سريع، لكنه يطابق أيضًا داخل السلاسل والتعليقات، لذا قد تُظهر الشيفرة النظيفة نتائج. للحصول على إجابة حاسمة، استخدم الفحص أدناه. يُظهر فقط مراجع الشيفرة الفعلية ويخرج بحالة غير صفرية إذا بقي أي شيء، ما يجعله قابلًا للاستخدام كقوة بناء.

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

شغّله قبل وبعد الترقيّة:

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

أخيرًا، نفّذ اختبارًا سريعًا يركّز على الأنواع المنقولة:

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

## **ترتيب الترقيّة الموصى به**

1. **احفظ نسخة أساسية.** نفّذ اختباراتك على الإصدار الحالي واحتفظ بالنتائج المرجعية. هذا يسمح لك بفصل أخطاء الترقيّة عن اختلافات العرض لاحقًا.  
2. **معاينة الترقيّة.** شغّل أحد البرامج بدون `--write` وراجع قائمة الملفات التي سيُغيّرها.  
3. **التطبيق والتحقق.** شغّل مع `--write --backup`، ثم تشغيل برنامج التحقق واختبار الفحص السريع.  
4. **قارن النتائج بحد tolerancе.** الانتقال إلى بناء .NET 6 قد ينتج عنه اختلافات طفيفة في النصوص والتأثيرات. استخدم مقارنة تعتمد على العتبة بدلًا من فحص بايت-بايت.  
5. **أزل النسخ الاحتياطية.** بمجرد تأكيد النتيجة، احذف ملفات `.bak`: `find . -name '*.py.bak' -delete` على Linux و macOS، أو `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` على Windows.

## **دعم كلا الإصدارين في قاعدة شيفرة واحدة**

إذا احتجت إلى تشغيل الشيفرة ضد 26.7 و 26.8 من المصدر نفسه:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 وما بعده
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 وما قبله
```

## **ما لم يتغير**

- أسماء، ومعاملات، وسلوك البدائيات المنقولة.  
- باقي سطح API لـ `aspose.slides`.  
- الترخيص وطريقة تطبيق ملف الترخيص.  
- صيغ الملفات وسلوك الحفظ والتحميل.  
- متطلبات النظام على Windows و macOS.  
- عدم وجود تثبيت .NET منفصل – لا يزال وقت التشغيل مُضمّنًا.