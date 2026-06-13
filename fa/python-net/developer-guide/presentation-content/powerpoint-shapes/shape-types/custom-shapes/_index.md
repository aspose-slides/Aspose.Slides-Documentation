---
title: سفارشی‌سازی اشکال در ارائه‌ها با پایتون
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/python-net/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسه شکل
- مسیر هندسی
- نقاط مسیر
- ویرایش نقاط
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشه منحنی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مقدمه**

یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **Edit Points** می‌توانید:

* گوشهٔ مربع را به داخل یا خارج حرکت دهید،
* انحنای یک گوشه یا نقطه را تنظیم کنید،
* نقاط جدیدی به مربع اضافه کنید،
* نقاط آن را دستکاری کنید.

می‌توانید این عملیات را بر روی هر شکلی اعمال کنید. با **Edit Points** می‌توانید یک شکل را اصلاح کنید یا از یک شکل موجود شکل جدیدی ایجاد کنید.

## **نکات ویرایش شکل**

!["دستور \"Edit Points\""](custom_shape_0.png)

قبل از شروع ویرایش اشکال PowerPoint با استفاده از **Edit Points**، این نکات دربارهٔ اشکال را در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند **بسته** یا **باز** باشد.
* یک شکل بسته نقطهٔ شروع یا پایان ندارد؛ یک شکل باز دارای ابتدا و انتها است.
* هر شکل حداقل دو نقطهٔ لنگر دارد که توسط قطعات خطی به هم متصل هستند.
* یک قطعه می‌تواند مستقیم یا منحنی باشد؛ نقاط لنگر طبیعت قطعه را تعیین می‌کنند.
* نقاط لنگر می‌توانند **گوشه‌ای**، **ملانمایی** یا **مستقیم** باشند:
  * یک نقطهٔ **گوشه‌ای** جایی است که دو قطعهٔ مستقیم در یک زاویه به هم می‌رسند.
  * یک نقطهٔ **ملانمایی** دارای دو دستهٔ هم‌خط است و قطعات پیوست، یک منحنی نرم را تشکیل می‌دهند. در این حالت، هر دو دسته از نقطهٔ لنگر فاصلهٔ مساوی دارند.
  * یک نقطهٔ **مستقیم** نیز دو دستهٔ هم‌خط دارد و قطعات پیوست یک منحنی نرم را می‌سازند. در این حالت، دسته‌ها نیازی به داشتن فاصلهٔ مساوی از نقطهٔ لنگر ندارند.
* با جابه‌جایی یا ویرایش نقاط لنگر (و بدین ترتیب تغییر زوایای قطعات)، می‌توانید ظاهر شکل را تغییر دهید.

برای ویرایش اشکال PowerPoint، Aspose.Slides کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) مسیر هندسی یک شیء [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) از یک نمونهٔ [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/)، از متد [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/get_geometry_paths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) یک شکل، از [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/set_geometry_path/) برای *اشکال جامد* و از [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/set_geometry_paths/) برای *اشکال ترکیبی* استفاده کنید.
* برای افزودن قطعات، از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) استفاده کنید.
* از ویژگی‌های [GeometryPath.stroke](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/stroke/) و [GeometryPath.fill_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/fill_mode/) برای کنترل ظاهر مسیر هندسی استفاده کنید.
* از ویژگی [GeometryPath.path_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/path_data/) برای به‌دست آوردن مسیر هندسی یک شکل به عنوان آرایه‌ای از قطعات مسیر استفاده کنید.

## **عملیات ساده ویرایش**

روش‌های زیر برای عملیات ساده ویرایش استفاده می‌شوند.

**افزودن خط** به انتهای مسیر:
```py
line_to(point)
line_to(x, y)
```

**افزودن خط** در موقعیت مشخصی از مسیر:
```py    
line_to(point, index)
line_to(x, y, index)
```

**افزودن منحنی Bezier مکعبی** به انتهای مسیر:
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**افزودن منحنی Bezier مکعبی** در موقعیت مشخصی از مسیر:
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**افزودن منحنی Bezier درجه دو** به انتهای مسیر:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**افزودن منحنی Bezier درجه دو** در موقعیت مشخصی از مسیر:
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**افزودن یک قوس** به مسیر:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**بستن شکل فعلی** در مسیر:
```py
close_figure()
```

**تنظیم موقعیت نقطهٔ بعدی**:
```py
move_to(point)
move_to(x, y)
```

**حذف قطعهٔ مسیر** در اندیس مشخصی:
```py
remove_at(index)
```

## **افزودن نقاط سفارشی به اشکال**

در اینجا یاد می‌گیرید چگونه یک شکل آزاد را با افزودن دنباله‌ای دلخواه از نقاط تعریف کنید. با مشخص کردن نقاط به ترتیب و انواع قطعات (مستقیم یا منحنی) و در صورت نیاز بستن مسیر، می‌توانید گرافیک‌های سفارشی دقیق—چندضلعی‌ها، آیکون‌ها، حاشیه‌نویسی‌ها یا لوگوها—را مستقیم بر روی اسلایدها رسم کنید.

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/) ایجاد کنید و نوع آن را به [ShapeType.RECTANGLE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapetype/) تنظیم کنید.
2. یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) را از شکل دریافت کنید.
3. یک نقطهٔ جدید بین دو نقطهٔ بالایی مسیر وارد کنید.
4. یک نقطهٔ جدید بین دو نقطهٔ پایینی مسیر وارد کنید.
5. مسیر به‌روز شده را به شکل اعمال کنید.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![نقاط سفارشی](custom_shape_1.png)

## **حذف نقاط از اشکال**

گاهی یک شکل سفارشی شامل نقاط غیرضروری است که هندسهٔ آن را پیچیده می‌کند یا روی رندر تأثیر می‌گذارد. این بخش نشان می‌دهد چگونه نقاط خاصی را از مسیر یک شکل حذف کنید تا خطوط بیرونی را ساده‌سازی کنید و نتایج دقیق‌تری به دست آورید.

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/) ایجاد کنید و نوع آن را به [ShapeType.HEART](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapetype/) تنظیم کنید.
2. یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) را از شکل دریافت کنید.
3. یک قطعه را از مسیر حذف کنید.
4. مسیر به‌روز شده را به شکل اعمال کنید.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![نقاط حذف شده](custom_shape_2.png)

## **ایجاد اشکال سفارشی**

شکل‌های برداری سفارشی را با تعریف یک [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) و ترکیب آن از خطوط، قوس‌ها و منحنی‌های Bézier بسازید. این بخش نشان می‌دهد چگونه از صفر یک هندسهٔ سفارشی ایجاد کنید و شکل حاصل را به اسلاید اضافه کنید.

1. نقاط شکل را محاسبه کنید.
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) ایجاد کنید.
3. مسیر را با نقاط پر کنید.
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/) ایجاد کنید.
5. مسیر را به شکل اعمال کنید.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![شکل سفارشی](custom_shape_3.png)

## **ایجاد اشکال سفارشی ترکیبی**

ایجاد یک شکل سفارشی ترکیبی به شما امکان می‌دهد چندین مسیر هندسی را در یک شکل قابل استفاده ترکیب کنید. این مسیرها را تعریف و ترکیب کنید تا جلوه‌های بصری پیچیده‌ای بسازید که فراتر از مجموعهٔ استاندارد اشکال هستند.

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/) ایجاد کنید.
2. نمونهٔ اول کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) را ایجاد کنید.
3. نمونهٔ دوم کلاس [GeometryPath](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometrypath/) را ایجاد کنید.
4. هر دو مسیر را به شکل اعمال کنید.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![شکل ترکیبی](custom_shape_4.png)

## **ایجاد اشکال سفارشی با گوشه‌های منحنی**

این بخش نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی نرم با استفاده از مسیر هندسی رسم کنید. قطعات مستقیم و قوس‌های دایره‌ای را ترکیب کنید تا پیرامون شکل را تشکیل دهید و شکل نهایی را به اسلاید اضافه کنید.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![گوشه‌های منحنی](custom_shape_6.png)

## **تشخیص بسته بودن هندسهٔ یک شکل**

یک شکل بسته به عنوان شکلی تعریف می‌شود که تمام اضلاع آن به هم متصل هستند و مرز یکپارچه‌ای بدون فاصله تشکیل می‌دهند. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک نمای سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی کنید آیا هندسهٔ یک شکل بسته است یا نه:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **سوالات متداول**

**بعد از جایگزینی هندسه، پرکننده و حاشیه چه می‌شود؟**  
سبک همچنان به شکل باقی می‌ماند؛ فقط خطوط مرزی تغییر می‌کند. پرکننده و حاشیه به‌طور خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌درستی به همراه هندسه‌اش بچرخانم؟**  
از ویژگی [rotation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/geometryshape/rotation/) شکل استفاده کنید؛ هندسه به‌همراه شکل می‌چرخد زیرا به سیستم مختصات خود شکل وابسته است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه «قفل» شود؟**  
بله. ناحیهٔ مورد نیاز را از [slide](/slides/fa/python-net/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/python-net/create-shape-thumbnails/) به قالب رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.