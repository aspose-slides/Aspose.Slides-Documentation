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
- هندسه شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشه منحنی
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های پاورپوینت با Aspose.Slides برای پایتون از طریق جاوا: مسیرهای هندسی، گوشه‌های منحنی، شکل‌های ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه شکل‌های ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایشی و مسیرهای هندسی سفارشی کنید. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) کار کنید تا شکل‌های موجود را اصلاح کنید، عملیات پایه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید، و هندسه به‌روزرسانی شده را به شکل اعمال کنید.

همچنین نحوه ایجاد شکل‌های سفارشی و ترکیبی، ساخت شکل‌ها با گوشه‌های منحنی، تعیین اینکه آیا هندسه یک شکل بسته است، بررسی عناصر شکل، و تبدیل قالب‌های متنی Java AWT به مسیرهای هندسی را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنا را در یک نقطه تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما اجازه می‌دهد خطوط مرزی یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایه برای یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

در هنگام ویرایش شکل‌های PowerPoint، این مفاهیم را در ذهن داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل شده توسط بخش‌ها تشکیل شده است.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود دارند:
  * در یک نقطه گوشه‌ای، بخش‌های مجاور می‌توانند در زاویه‌ای به‌هم بپیوندند.
  * در یک نقطه صاف، دو دسته کنترل هم‌راستا و به‌صورت مساوی از نقطه لنگر فاصله دارند.
  * در یک نقطه مستقیم، دو دسته کنترل هم‌راستا هستند ولی می‌توانند فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌های آن‌ها خطوط مرزی شکل را تغییر می‌دهد.

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) نمونه مسیر هندسی شی [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای بازیابی [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) از نمونه [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)، می‌توانید از روش [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این روش‌ها استفاده کنید: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) برای شکل‌های دارای مسیر تک و [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) برای شکل‌های دارای مسیرهای متعدد.
* برای افزودن بخش‌ها، می‌توانید از روش‌های تحت [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از روش‌های [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) و [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از روش [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسه شکل، می‌توانید یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) را از طریق [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) بخوانید و بخش‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بازپخش کنید.

## **عملیات ویرایشی ساده**

از روش‌های زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌هایی که یک ایندکس می‌پذیرند، بخش را در موقعیت صفر مبنای آن در آرایه بخش‌های مسیر وارد می‌کنند.

| عملیات | متد |
| --- | --- |
| اضافه یا درج یک خط مستقیم. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| اضافه یا درج یک منحنی Bézier مکعب با دو نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| اضافه یا درج یک منحنی Bézier درجه دوم با یک نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| اضافه یک قوس بیضوی با ابعاد و زاویه‌های مشخص شده به درجه. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| بستن شکل جاری با وصل کردن نقطه انتهایی به نقطه شروع. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| تنظیم نقطه شروع یک شکل. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| حذف یک بخش در ایندکس صفر مبنا. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **اضافه کردن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطه جدید در مرکز آن، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از بالای شکل قرار دارند. ایندکس‌های بخش ۱ و ۴ آن‌ها را بر روی لبه‌های بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

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

این مثال مرز شکل قلبی را با حذف بخش در ایندکس صفر مبنا ۲ با استفاده از [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) مرز شکل را به‌روز می‌کند.

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

این مثال یک ستاره پنج‌نوک با استفاده از [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) می‌سازد. شعاع‌های متناوب بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ نقطه نوک‌ها و فرو رفتگی‌ها را تعریف می‌کنند؛ گام ۷۲ درجه، پنج نوک را به‌صورت مساوی فضا می‌دهد. مسیر با [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) بسته می‌شود و با استفاده از [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) بر روی یک شکل مستطیلی اعمال می‌شود و مرز آن را جایگزین می‌کند.

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

این مثال دو [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بسته برای یک‌سوم بالایی و یک‌سوم پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل ترکیبی واحد با یک فاصله در یک‌سوم میانی ایجاد می‌کند.

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

این مثال بخش‌های مستقیم را با [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) ترکیب می‌کند تا شکلی با گوشه‌های منحنی به سمت داخل بسازد. هر اندازه گوشه عرض و ارتفاع قوس را به‌واحد نقاط تعیین می‌کند و چرخش ‑90 درجه یک چهارم بیضی ضدساعتی ترسیم می‌کند. مسیر نهایی با [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **تشخیص اینکه آیا هندسه یک شکل بسته است**

کد کمکی زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته به پایان می‌رسد یا نه. این کد [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) را می‌خواند و دستور نهایی [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) را با [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیر غیرخالی وجود ندارد، `False` برمی‌گرداند. این بررسی تنها دستور نهایی هر مسیر را چک می‌کند؛ تمام زیرشکل‌های داخل مسیر بررسی نمی‌شوند. مثال برای یک مستطیل `True` چاپ می‌کند.

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

## **بازرسی دستورات مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اولین شکل در اسلاید اول دارای لبه‌ی بالایی مستقیم، یک منحنی Bézier مکعب و لبه‌ی بسته مستقیم است. با استفاده از [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) مسیرهای شکل را بخوانید و با [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) بخش‌های هر مسیر را به ترتیب رسم دریافت کنید. برای هر بخش، [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) دستور را شناسایی می‌کند و نحوه تفسیر مقادیر برگشتی توسط [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) را تعیین می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

مختصات‌ها به‌صورت محلی نسبت به شکل گزارش می‌شوند، با (0, 0) در گوشه‌ی بالا‑چپ آن، x به سمت راست و y به سمت پایین افزایشی دارد. بخش بسته بدون مختصات اضافه به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **استخراج و بازرسی عناصر شکل**

از [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) برای بررسی یک شکل موجود به‌صورت عناصری که شامل نقاط مسیر و انواع نقاط هستند، استفاده کنید. هر عنصر برگشتی را به [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) با `jpype.JObject` تبدیل کنید تا آرایه‌های نقاط و انواع را از طریق روش‌های [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) و [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) دریافت کنید. این نمایش برای تحلیل مرز یا ارسال هندسه به ابزارهای رسم سفارشی مفید است.

مثال فایل input.pptx را باز می‌کند، اولین شکل هندسی را مستقیماً در اسلاید اول می‌یابد و بخش‌های مسیر آن را چاپ می‌کند. برای مشاهدهٔ خروجی‌های هر دو نوع، از ارائه‌ای با شکل دارای بخش‌های مستقیم و منحنی استفاده کنید. این روش داخل گروه‌ها جستجو نمی‌کند.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

آرایه‌ها بر حسب ایندکس مطابقت دارند: `points[i]` یک نقطه و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier مکعب از نقطه انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطه کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت یکجا مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین پرچم دارند. برای شناسایی نوع بخش با `0x07` ماسک کنید و برای تشخیص زیرمسیر بسته `0x80` را جداگانه تست کنید. برای مثال `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. جاوا این پرچم‌ها را در بایت‌های علامت‌دار ذخیره می‌کند؛ ماسک کردن مقادیر بیتی اصلی را حفظ می‌کند. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیلات.** نقاط بر حسب نقاط (1/72 اینچ) اندازه‌گیری می‌شوند، X به سمت راست و Y به سمت پایین افزایشی دارد. برای یک شکل بدون گروه، مختصات استخراج‌شده پیشاپیش موقعیت برگردانده‌شده توسط [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) و [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) و عرض و ارتفاع فعلی آن را شامل می‌شود. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازه `120 × 80` دارای مرزهای `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید؛ برای به‌دست آوردن مختصات نسبت به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش شکل که توسط [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) برگردانده می‌شود یا وارونه‌های افقی و عمودی را اعمال نمی‌کنند. برای بازتولید مرز نمایش داده‌شده، این تبدیلات را حول مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین تبدیل مختصات گروه و تبدیلات را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه/مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب کودک منعکس شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روز نمی‌کند. زمانی که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد، این روش را انتخاب کنید. وقتی به دستورات هندسی در سیستم مختصات محلی شکل یا نیاز به ویرایش هندسه دارید، از [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) یا [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) اعمال کنید.

## **تبدیل یک Java AWT Shape به GeometryPath**

این مثال یک قالب مستطیلی را با متن تبدیل‌شده به هندسه ترکیب می‌کند. روش [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) برای قاب، پرکردن را غیرفعال می‌سازد. یک [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) قالب متن را در یک [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ایجاد می‌کند. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) آن حرکت، خط، درجه دوم، مکعب و بخش‌های بستن را فراهم می‌کند که مثال آن‌ها را بر روی یک [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) بازپخش می‌کند.

متن از قلم Arial به اندازه ۴۰ نقطه استفاده می‌کند. قالب به‌صورت افقی ۲۰ نقطه جابجا شده و بالای بصری آن ۱۰ نقطه زیر لبه بالای شکل قرار گرفته است. مسیر متن پر می‌شود، در حالی که مستطیل اولیه به‌صورت قالب باقی می‌ماند. اعمال هر دو مسیر با [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) یک شکل واحد شامل مستطیل و متن تولید می‌کند.

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

## **سؤالات متداول**

**پس از جایگزینی هندسه، پرکردن و مرزبندی چه اتفاقی می‌افتد؟**

سبک با شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پرکردن و مرز به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را همراه با هندسهٔ آن به‌درستی چرخاند؟**

از روش [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) شکل استفاده کنید؛ هندسه به دلیل بسته بودن به سیستم مختصات خود شکل، همراه با آن می‌چرخد.

**آیا می‌توان یک شکل سفارشی را به تصویر تبدیل کرد تا نتیجه «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/python-java/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/python-java/create-shape-thumbnails/) را به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌سازد.