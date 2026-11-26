---
title: سفارشی‌سازی اشکال ارائه در پایتون
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
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشه منحنی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق .NET: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایشی و مسیرهای هندسی سفارشی کرد. این مقاله نشان می‌دهد که چگونه می‌توان با [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) کار کرد تا اشکال موجود را تغییر دهید، عملیات اولیه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسه به‌روز شده را به یک شکل اعمال کنید.

همچنین نشان می‌دهد که چگونه می‌توان اشکال سفارشی و ترکیبی ایجاد کرد، اشکالی با گوشه‌های منحنی ساخت، تعیین کرد آیا هندسه یک شکل بسته است یا خیر، و عناصر شکل را برای تجزیه و تحلیل کانتور استخراج کرد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

در PowerPoint می‌توانید از **Edit Points** برای تغییر یک مربع استفاده کنید:

* یک گوشه را به داخل یا بیرون حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد محدوده‌ی یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایه‌ای برای یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر (anchor) که توسط قسمت‌ها (segments) به هم متصل شده‌اند، تشکیل می‌شود.
* یک قسمت می‌تواند صاف یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود داشته باشند:
  * در نقطه‌ی گوشه‌ای، قسمت‌های مجاور می‌توانند با زاویه‌ای به یکدیگر برسند.
  * در نقطه‌ی صاف، دو دسته‌ی کنترل هم‌راستا و به‌صورت مساوی از نقطه لنگر فاصله دارند.
  * در نقطه‌ی مستقیم، دو دسته‌ی کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌های آن‌ها محدوده‌ی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای بازیابی [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) از نمونهٔ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) می‌توانید از متد [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را استفاده کنید: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) برای اشکالی که یک مسیر دارند و [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) برای اشکالی که مسیرهای متعدد دارند.
* برای اضافه کردن قسمت‌ها، می‌توانید از متدهای موجود تحت [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از ویژگی‌های [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) می‌توانید ظاهر مسیر هندسی را تنظیم کنید.
* با استفاده از ویژگی [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از قسمت‌های مسیر بازیابی کنید.

## **عملیات ساده ویرایش**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرندهٔ شاخص، یک قسمت را در موقعیت صفر‑پایهٔ آرایهٔ قسمت‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| افزودن یا درج یک منحنی Bézier به‌صورت مکعبی با دو نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| افزودن یا درج یک منحنی Bézier درجهٔ دوم با یک نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| افزودن یک قوس بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| بستن شکل فعلی با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| حذف یک قسمت در شاخص صفر‑پایه. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به شکل مستطیلی با استفاده از [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) اعمال می‌نماید. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن قرار دارند، ۱۰۰ پیکسل از سمت چپ و ۵۰ پیکسل از بالای شکل. اندیس‌های قسمت ۱ و ۴ آنها را بر لبهٔ بالایی و پایینی می‌گذارند و این لبه‌ها را به سمت داخل می‌کشند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال طرح بیرونی شکل قلبی را با حذف قسمت در شاخص صفر‑پایهٔ ۲ با [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) کانتور شکل را به‌روز می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج گوشه‌ای را با استفاده از [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی متناوب ۱۰۰ و ۵۰ پیکسل، نکات و صدورهای داخلی را تعریف می‌کند؛ گام ۷۲ درجه، پنج نوک را به‌طور مساوی فاصله می‌دهد. مسیر با [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) بسته می‌شود و با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) بر روی یک شکل مستطیلی اعمال می‌شود و قالب آن را جایگزین می‌کند.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) بسته برای یک‑سوم بالا و یک‑سوم پایین یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) یک شکل ترکیبی واحد با یک شکاف در یک‑سوم میانی ایجاد می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال قسمت‌های مستقیم را با [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) ترکیب می‌کند تا شکل با گوشه‌های منحنی به سمت داخل ساخته شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را به نقطه تعیین می‌کند و سوئپ -۹۰ درجه یک ربع بیضی خلاف ساعت‌گرد رسم می‌کند. مسیر کامل با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

کد کمکی زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته پایان می‌یابد یا نه. این کد [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) را می‌خواند و دستور نهایی [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) را با [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیر خالی باشد، مقدار false برمی‌گرداند. این بررسی فقط دستور نهایی هر مسیر را چک می‌کند؛ به تمام زیرشکله‌های داخل مسیر نگاه نمی‌کند. مثال `True` را برای یک مستطیل چاپ می‌کند.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **بازرسی دستورات مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشهٔ کاری خود قرار دهید. اولین شکل در اولین اسلاید دارای لبهٔ بالایی مستقیم، یک منحنی Bézier مکعبی و یک لبهٔ بستهٔ مستقیم است. از [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) برای خواندن مسیرهای آن استفاده کنید. برای هر مسیر، [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) بخش‌ها را به ترتیب رسم فهرست می‌کند. هر بخش [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) تعیین می‌کند که چگونه باید [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) آن تفسیر شود.

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

شکل در نقطهٔ (200, 100) پیکسل بر روی اسلاید قرار دارد. مختصات گزارش‌شده به‌صورت محلی نسبت به شکل است. گوشهٔ بالایی‑چپ آن (0, 0) است، محور X به سمت راست و محور Y به سمت پایین افزایش می‌یابد. بخش بسته بدون مختصات اضافه به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **استخراج و بازبینی عناصر شکل**

از [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) برای بازبینی یک شکل موجود به‌عنوان عناصری که شامل نقاط مسیر و انواع نقاط هستند، استفاده کنید. هر [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) بازگردانده‌شده آرایه‌های [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) و [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) خود را نمایان می‌کند. این نمایش برای تجزیه و تحلیل کانتور یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌نماید. برای مشاهده خروجی‌های هردو نوع (خطی و منحنی) از یک ارائه‌ای که شامل شکل با قسمت‌های مستقیم و منحنی است استفاده کنید. این روش داخل گروه‌ها را جستجو نمی‌کند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
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

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

آرایه‌ها بر اساس اندیس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند و نوع `1` خطی را از نقطهٔ قبل به نقطهٔ فعلی می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت یکجا مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌کند.

انواع نقطه همچنین پرچم‌هایی دارند. با ماسک `0x07` می‌توانید نوع بخش را شناسایی کنید و با تست جداگانهٔ `0x80` می‌توانید زیرمسیر بسته را تشخیص دهید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) نقطهٔ انتهایی Bézier است که بسته می‌شود. مقایسهٔ مقدار خالص فقط با `1` یا `3` این موارد را نادیده می‌گیرد. پرچم‌های دیگر مانند خط‌چین (`0x10`) و علامت (`0x20`) نوع پایهٔ بخش را تغییری نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب پیکسل (1/72 اینچ) اندازه‌گیری می‌شوند و X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیرگروه‌بندی‌شده، مختصات استخراج‌شده در موقعیت `[x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)` و `[y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)` آن گنجانده شده و عرض و ارتفاع فعلی را منعکس می‌کند. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با ابعاد `120 × 80` محدودهٔ کانتور `(100, 200)`–`(220, 280)` دارد. موقعیت shape را دوبار اضافه نکنید؛ برای به‌دست آوردن مختصات نسبی به قاب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش `[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)` یا وارونگی افقی/عمودی شکل را اعمال نمی‌کنند. برای بازتولید کانتور نمایش‌داده‌شده، این تبدیل‌ها را دور مرکز شکل اعمال کنید. برای اشکال گروه‌بندی‌شده، همچنین باید نگاشت مختصات گروه و تبدیلات آن را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی مختصات اسلاید رندر شده هستند یا ترجمه/مقیاس را دوبار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده باشد.

**بازرسی در برابر ویرایش.** آرایه‌های استخراج‌شده توصیف‌کنندهٔ کانتور هستند؛ تغییر آن‌ها شکل اصلی را بروز نمی‌کند. این روش زمانی مناسب است که کد تجزیه و تحلیل یا رسم شما به آرایه‌های نقطه/نوع نیاز دارد. زمانی که به دستورات هندسی در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسهٔ آن را ویرایش کنید، از [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) یا [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) اعمال کنید.

## **سوالات متداول**

**بعد از جایگزینی هندسه، پر کردن و حاشیهٔ شکل چه می‌شود؟**

سبک با شکل باقی می‌ماند؛ فقط کانتور تغییر می‌کند. پر کردن و حاشیه به‌صورت خودکار روی هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را به‌درستی همراه با هندسه‌اش چرخاند؟**

از ویژگی `[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)` شکل استفاده کنید؛ هندسه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ مورد نیاز را از اسلاید `[slide](/slides/fa/python-net/convert-powerpoint-to-png/)` یا خود شکل `[shape](/slides/fa/python-net/create-shape-thumbnails/)` به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.