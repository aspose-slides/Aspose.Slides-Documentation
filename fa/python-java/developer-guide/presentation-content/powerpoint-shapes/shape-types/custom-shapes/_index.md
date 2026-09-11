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
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشهٔ منحنی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق جاوا: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **نمای کلی**

این مقاله نحوهٔ سفارشی‌سازی اشکال ارائه در Aspose.Slides را از طریق ویرایش هندسهٔ شکل با استفاده از نقاط ویرایشی و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) کار کنید تا اشکال موجود را تغییر داده، عملیات پایه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسهٔ به‌روز شده را دوباره به شکل اعمال کنید.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است یا خیر، و تبدیل بین [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) و [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) برای سناریوهای سفارشی‌سازی هندسهٔ بیشتر را نشان می‌دهد.

## **تغییر شکل با استفاده از نقاط ویرایشی**

یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **نقاط ویرایشی** می‌توانید

* گوشهٔ مربع را به سمت داخل یا خارج حرکت دهید
* انحنای یک گوشه یا نقطه را مشخص کنید
* نقاط جدیدی به مربع اضافه کنید
* نقاط روی مربع را دستکاری کنید و غیره.

به‌طور اساسی می‌توانید این کارها را روی هر شکلی انجام دهید. با نقاط ویرایشی می‌توانید شکل را تغییر دهید یا از یک شکل موجود یک شکل جدید بسازید.

## **نکات ویرایشی شکل**

![overview_image](custom_shape_0.png)

قبل از اینکه شروع به ویرایش اشکال PowerPoint از طریق نقاط ویرایشی کنید، ممکن است به نکات زیر دربارهٔ اشکال توجه کنید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* وقتی یک شکل بسته است، نقطهٔ شروع یا پایان ندارد. وقتی یک شکل باز است، دارای نقطهٔ آغاز و پایان است.
* تمام اشکال حداقل شامل ۲ نقطهٔ لنگر هستند که توسط خطوط به یکدیگر متصل می‌شوند.
* یک خط می‌تواند مستقیم یا منحنی باشد. نقاط لنگر طبیعت خط را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقطهٔ گوشه، نقطهٔ مستقیم یا نقطهٔ صاف وجود داشته باشند:
  * نقطهٔ گوشه نقطه‌ای است که دو خط مستقیم با زاویه‌ای به هم می‌پیوندند.
  * نقطهٔ صاف نقطه‌ای است که دو دستهٔ کنترل (handle) در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت صاف به هم وصل می‌شوند. در این حالت تمام دسته‌ها فاصلهٔ مساوی از نقطهٔ لنگر دارند.
  * نقطهٔ مستقیم نقطه‌ای است که دو دستهٔ کنترل در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت صاف به هم وصل می‌شوند. در این حالت دسته‌ها نیازی به فاصلهٔ مساوی از نقطهٔ لنگر ندارند.
* با جابه‌جا یا ویرایش نقاط لنگر (که زاویهٔ خطوط را تغییر می‌دهد) می‌توانید ظاهر شکل را تغییر دهید.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) می‌توانید از متد [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را به‌کار ببرید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/#setGeometryPath) برای *شکل‌های جامد* و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/#setGeometryPaths) برای *شکل‌های ترکیبی*.
* برای افزودن بخش‌ها می‌توانید از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از متدهای [GeometryPath.setStroke](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/#setFillMode) می‌توانید ظاهر مسیر هندسی را تعیین کنید.
* با استفاده از متد [GeometryPath.getPathData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر بازیابی کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسهٔ شکل، می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) را به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) تبدیل کنید.
* از متدهای [geometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapeutil/) و [graphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapeutil/) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapeutil/)) برای تبدیل دو‑طرفهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) به [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) استفاده کنید.

## **عملیات ویرایشی ساده**

امضاهای زیر عملیات پایهٔ ویرایش را نشان می‌دهند:

**افزودن یک خط** به انتهای مسیر:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**افزودن یک خط** به موقعیتی مشخص در مسیر:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**افزودن یک منحنی بزیهٔ مکعبی** به انتهای مسیر:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**افزودن یک منحنی بزیهٔ مکعبی** به موقعیتی مشخص در مسیر:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**افزودن یک منحنی بزیهٔ درجهٔ دو** به انتهای مسیر:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**افزودن یک منحنی بزیهٔ درجهٔ دو** به موقعیتی مشخص در مسیر:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**پیوست یک قوس مشخص** به مسیر:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**بستن شکل فعلی** مسیر:

- `geometry_path.closeFigure()`

**تنظیم موقعیت برای نقطهٔ بعدی**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**حذف بخش مسیر** در یک اندیس داده شده:

- `geometry_path.removeAt(index)`

## **افزودن نقاط سفارشی به یک شکل**
1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) ایجاد کنید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Rectangle) را تنظیم کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) را از شکل دریافت کنید.
3. نقطهٔ جدیدی بین دو نقطهٔ بالایی مسیر اضافه کنید.
4. نقطهٔ جدیدی بین دو نقطهٔ پایینی مسیر اضافه کنید.
5. مسیر را به شکل اعمال کنید.

این کد پایتون نشان می‌دهد چگونه نقاط سفارشی به یک شکل اضافه شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) ایجاد کنید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Heart) را تنظیم کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) را از شکل دریافت کنید.
3. بخش مسیر را حذف کنید.
4. مسیر را به شکل اعمال کنید.

این کد پایتون نشان می‌دهد چگونه نقاط از یک شکل حذف شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

1. نقاط شکل را محاسبه کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) ایجاد کنید.
3. مسیر را با نقاط پر کنید.
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) ایجاد کنید.
5. مسیر را به شکل اعمال کنید.

این کد پایتون نشان می‌دهد چگونه یک شکل سفارشی ایجاد شود:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) ایجاد کنید.
2. یک نمونهٔ اول از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) ایجاد کنید.
3. یک نمونهٔ دوم از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) ایجاد کنید.
4. مسیرها را به شکل اعمال کنید.

این کد پایتون نشان می‌دهد چگونه یک شکل ترکیبی سفارشی ساخته شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

این کد پایتون نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی (به سمت داخل) ایجاد شود:

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

یک شکل بسته به‌عنوان شکلی تعریف می‌شود که تمام سمت‌های آن به‌هم متصل باشند و یک مرز واحد بدون فاصله ایجاد کنند. چنین شکلی می‌تواند فرم هندسی ساده یا طرح سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی شود که آیا هندسهٔ یک شکل بسته است یا نه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **تبدیل GeometryPath به java.awt.Shape**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometryshape/) ایجاد کنید.
2. یک نمونه از کلاس [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ایجاد کنید.
3. نمونهٔ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) را با مرور [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن و بازپخش هر بخش بر روی مسیر، به نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-java/aspose.slides/geometrypath/) تبدیل کنید.
4. مسیرها را به شکل اعمال کنید.

این کد پایتون گام‌های فوق را برای تبدیل یک مسیر گرافیکی به مسیر هندسی پیاده‌سازی می‌کند:

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
    # یک شکل جدید ایجاد کنید.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # مسیر هندسی شکل را دریافت کنید.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # یک مسیر گرافیکی جدید با متن ایجاد کنید.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # مسیر گرافیکی را به مسیر هندسی تبدیل کنید.
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

    # مسیر متن را همراه با مسیر هندسی اصلی اعمال کنید.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **سوالات متداول**

**پس از جایگزینی هندسه، پرکننده و کناره چه اتفاقی می‌افتد؟**

سبک با شکل باقی می‌ماند؛ فقط contour تغییر می‌کند. پرکننده و کناره به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان شکل سفارشی را همراه با هندسه‌اش به‌درستی چرخاند؟**

از متد [setRotation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه به‌خاطر پیوند به سیستم مختصات خود شکل، همراه با آن می‌چرخد.

**آیا می‌توانم شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/python-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/python-java/create-shape-thumbnails/) مورد نیاز را به قالب رستری صادر کنید؛ این کار کار با هندسه‌های سنگین را ساده‌تر می‌سازد.