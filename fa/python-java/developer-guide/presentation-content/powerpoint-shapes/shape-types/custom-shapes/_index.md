---
title: سفارشی‌سازی اشکال ارائه در پایتون از طریق جاوا
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/python-java/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسهٔ شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشهٔ منحنی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق جاوا: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) کار کنیم تا اشکال موجود را تغییر داده، عملیات‌های پایهٔ ویرایش مسیر را انجام داده، نقاط را اضافه یا حذف کنیم و هندسهٔ به‌روزشده را به شکل اعمال کنیم.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است، بررسی عناصر شکل و تبدیل خطوط مرزبندی متن جاوا AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید از **Edit Points** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به داخل یا بیرون حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد حاشیهٔ شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایهٔ شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint این مفاهیم را در ذهن داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل‌شده توسط بخش‌ها تشکیل می‌شود.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به عنوان نقاط گوشه‌ای، مستقیم یا صاف وجود دارند:
  * در یک نقطهٔ گوشه‌ای، بخش‌های مجاور می‌توانند با زاویه‌ای ملاقات کنند.
  * در یک نقطهٔ صاف، دو دستهٔ کنترل هم‌راسته‌اند و از نقطهٔ لنگر فاصلهٔ برابر دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راسته‌اند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌های آن‌ها، حاشیهٔ شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای بازیابی [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)، می‌توانید از متد [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را به کار ببرید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) برای اشکالی که مسیر واحد دارند و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) برای اشکالی که مسیرهای چندگانه دارند.
* برای افزودن بخش‌ها، می‌توانید از متدهای زیرمجموعهٔ [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از متدهای [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)، می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از متد [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) را به عنوان آرایه‌ای از بخش‌های مسیر بازیابی کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی هندسهٔ شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن بخوانید و بخش‌ها را روی یک [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات سادهٔ ویرایش**

از روش‌های زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌هایی که اندیس می‌پذیرند، یک بخش را در موقعیت صفر‑پایه‌ای در آرایهٔ بخش‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| افزودن یا درج منحنی Bézier درجهٔ سه با دو نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| افزودن یا درج منحنی Bézier درجهٔ دو با یک نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| افزودن قوس بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| بستن شکل جاری با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در اندیس صفر‑پایه‌ای. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **اضافه کردن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن، ۱۰۰ پوینت از سمت چپ و ۵۰ پوینت از بالا قرار دارند. اندیس‌های بخش ۱ و ۴ آن‌ها را روی لبه‌های بالا و پایین قرار می‌دهند و آن لبه‌ها را به داخل می‌کشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال مرزبندی شکل قلبی را با حذف بخش در اندیس صفر‑پایه‌ای ۲ توسط [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) مرزبندی شکل را به‌روز می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال با استفاده از [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) یک ستارهٔ پنج‌پره با رادیس‌های بیرونی و درونی به ترتیب ۱۰۰ و ۵۰ پوینت می‌سازد؛ گام ۷۲ درجه فواصل پنج پر نوک را مساوی می‌کند. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) به یک شکل مستطیلی اعمال می‌شود و مرزبندی آن را جایگزین می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بسته برای یک‑سوم بالا و یک‑سوم پایین یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد با یک فضای خالی در یک‑سوم میانی می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های داخل‌منحنی ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب پوینت تعیین می‌کند و گرداندن ‑۹۰ درجه یک ربع بیضی ساعت‌گرد را می‌کشد. مسیر کامل با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه با فرمت PPTX ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

این کمک‌کننده بررسی می‌کند آیا هر مسیر هندسی غیرخالی با یک بخش بسته خاتمه می‌یابد. با خواندن [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) و مقایسهٔ دستور نهایی بخش [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) با [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) آن را تعیین می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشند `False` برمی‌گرداند. این بررسی فقط دستور نهایی هر مسیر را مقایسه می‌کند؛ تمام زیرشکل‌های داخل مسیر را بررسی نمی‌کند. مثال برای یک مستطیل `True` چاپ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **استخراج و بررسی عناصر شکل**

از [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) برای بررسی یک شکل موجود به عنوان عناصری حاوی نقاط مسیر و انواع نقطه استفاده کنید. هر عنصر بازگشت‌شده را با `jpype.JObject` به [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های نقطه و نوع را از طریق متدهای [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) دریافت کنید. این نمایش برای تحلیل مرزبندی یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل `input.pptx` را باز می‌کند، اولین شکل هندسی را مستقیماً بر روی اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای دیدن خروجی هر دو نوع خط مستقیم و منحنی، از ارائه‌ای حاوی شکلی با این دو نوع بخش استفاده کنید. این روش داخل گروه‌ها جستجو نمی‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # نوع بخش را نگه‌دارید، بدون پرچم‌ها.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # مصرف هر دو نقطه کنترل و نقطه انتهایی.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

آرایه‌ها بر اساس اندیس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier درجهٔ سه از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی نوع‑`3` متوالی استفاده می‌کند: دو نقطهٔ کنترل سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت یکجا مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها هستند. با ماسک `0x07` می‌توانید نوع بخش را شناسایی کنید و با تست جداگانهٔ `0x80` یک زیرمسیر بسته را تشخیص دهید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که بسته می‌شود. جاوا این پرچم‌ها را به‌صورت بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک کردن مقادیر بیتی اصلی را حفظ می‌کند. مقایسهٔ مقدار خام تنها با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل جداگانه، مختصات استخراج‌شده پیشاپیش شامل موقعیتی است که توسط [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) برگردانده می‌شود و عرض و ارتفاع فعلی آن را بازتاب می‌دهد. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای حدود مرزبندی `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید؛ برای دریافت مختصات نسبی به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقطه‌های استخراج‌شده چرخش شکل که توسط [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) برگردانده می‌شود یا وارونگی افقی و عمودی را اعمال نمی‌کنند. برای بازتولید مرزبندی نمایشی، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین باید نگاشتی از مختصات گروه و تبدیل‌های آن را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا تبدیل ترجمه یا مقیاس را دوبار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده‌اند.

**بررسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرزبندی را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. زمانی از این روش استفاده کنید که برنامهٔ تجزیه یا رسم شما به آرایه‌های نقطه/نوع نیاز دارد. وقتی به دستورات هندسی در سیستم مختصات محلی شکل یا ویرایش هندسهٔ آن نیاز دارید، از [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک java.awt.Shape به GeometryPath**

این مثال مرزبندی مستطیلی را با متنی ترکیب می‌کند که به هندسه تبدیل شده است. متد [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) مرزبندی را غیرفعال می‌کند. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) خطوط مرزی متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، منحنی درجهٔ دو، منحنی درجهٔ سه و بخش‌های بسته را فراهم می‌کند که مثال آن‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بازپخش می‌کند.

متن با قلم Arial 40‑پوینتی رسم می‌شود. مرزبندی 20 پوینت به صورت افقی جابجا شده و بالای بصری آن 10 پوینت زیر لبهٔ بالایی شکل قرار می‌گیرد. مسیر متن پر می‌شود، در حالی که مستطیل اصلی به‌صورت مرزبندی باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد حاوی مستطیل و متن تولید می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # دریافت مسیر هندسی شکل.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # ایجاد مسیر گرافیکی جدید با متن.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # تبدیل مسیر گرافیکی به مسیر هندسی.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # اعمال مسیر متن همراه با مسیر هندسی اصلی.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **سؤال و جواب**

**پس از جایگزینی هندسه، پرکردن و مرزبندی چه می‌شود؟**

سبک با شکل می‌ماند؛ تنها مرزبندی تغییر می‌کند. پرکردن و مرزبندی به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را همزمان با هندسهٔ آن به‌درستی چرخش دهم؟**

از متد [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خودش متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. منطقهٔ [slide](/slides/fa/python-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/python-java/create-shape-thumbnails/) را به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.