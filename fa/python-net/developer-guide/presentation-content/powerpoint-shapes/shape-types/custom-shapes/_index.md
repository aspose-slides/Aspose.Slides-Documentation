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

این مقاله نحوهٔ سفارشی‌سازی اشکال ارائه در Aspose.Slides را از طریق ویرایش هندسهٔ شکل با استفاده از نقاط ویرایشی و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) برای تغییر اشکال موجود کار کنید، عملیات پایهٔ ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسهٔ به‌روز شده را به یک شکل اعمال کنید.

همچنین نحوهٔ ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسهٔ یک شکل بسته است یا خیر، و استخراج عناصر شکل برای تحلیل قالب را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

در PowerPoint می‌توانید از **نقاط ویرایشی** برای تغییر یک مربع استفاده کنید:

* حرکت یک گوشه به سمت داخل یا خارج.
* تنظیم انحنا در یک نقطه.
* افزودن نقاط جدید.

ویرایش نقاط به شما امکان می‌دهد خط مرزی یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایه‌ای برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل به‌وسیلهٔ بخش‌ها تشکیل می‌شود.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دستگیره‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود دارند:
  * در یک نقطه گوشه‌ای، بخش‌های مجاور می‌توانند در یک زاویه به هم بپیوندند.
  * در یک نقطه صاف، دو دستگیرهٔ کنترل هم‌راستا هستند و فاصلهٔ برابر از نقطهٔ لنگر دارند.
  * در یک نقطه مستقیم، دو دستگیرهٔ کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* حرکت نقاط لنگر یا تنظیم دستگیره‌های آنها، خط مرزی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) مسیر هندسی شیء [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) از یک نمونهٔ [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)، می‌توانید از متد [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) برای اشکالی که تنها یک مسیر دارند و [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) برای اشکالی که چند مسیر دارند.
* برای اضافه کردن بخش‌ها، می‌توانید از متدهای موجود در [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) استفاده کنید.
* با استفاده از ویژگی‌های [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) و [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/)، می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از ویژگی [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)، می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.

## **عملیات ساده ویرایشی**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرندهٔ یک شاخص، یک بخش را در آن موقعیت صفر‑پایه‌ای در آرایهٔ بخش‌های مسیر وارد می‌کند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| افزودن یا درج یک منحنی Bézier مکعبی با دو نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| افزودن یا درج یک منحنی Bézier درجهٔ دوم با یک نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| افزودن یک قوس بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| بستن شکل فعلی با اتصال نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| حذف یک بخش در ایندکس صفر‑پایه‌ای. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **اضافه کردن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) وارد می‌کند و مسیر ویرایش‌شده را با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) اعمال می‌نماید. مختصات‌ها به‌صورت محلی به شکل هستند: هر دو نقطهٔ جدید در مرکز آن قرار دارند، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از سمت بالا. ایندکس‌های بخش ۱ و ۴ آنها را بر روی لبهٔ بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

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

این مثال خط مرزی یک شکل قلبی را با حذف بخش در ایندکس صفر‑پایه‌ای ۲ با استفاده از [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) تغییر می‌دهد. اعمال مسیر ویرایش‌شده با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) شکل را به‌روز می‌کند.

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

این مثال یک ستارهٔ پنج‌پرایه را با استفاده از [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) می‌سازد. شعاع‌های خارجی و داخلی به ترتیب ۱۰۰ و ۵۰ نقطه به‌صورت متناوب تعریف می‌شوند؛ گام ۷۲ درجه، پنج سر را به‌صورت مساوی فواصل می‌کند. مسیر با [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) بسته می‌شود و با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) به یک شکل مستطیلی اعمال می‌گردد، به‌طوری‌که خط مرزی آن جایگزین می‌شود.

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

این مثال دو شیء بستهٔ [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) برای یک‑سوم سوم بالایی و پایینینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) یک شکل ترکیبی واحد ایجاد می‌کند که در میانهٔ یک‑سوم سوم آن یک شکاف دارد.

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
    bottom_path.move_to(shape.height / 3 * 2, 0)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های مستقیم را با [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) ترکیب می‌کند تا شکلی با گوشه‌های درونی منحنی ساخته شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب نقطه تنظیم می‌کند و سوئیپ ‑۹۰ درجه یک چهارم بیضی ضدساعت را ترسیم می‌کند. مسیر تکمیل‌شده با [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **تشخیص اینکه آیا هندسه یک شکل بسته است یا خیر**

کمک‌کنندهٔ زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته پایان می‌یابد یا نه. این تابع [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) را می‌خواند و فرمان نهایی بخش [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) را با [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشد، مقدار false بر‑گردانده می‌شود. این بررسی فقط فرمان نهایی هر مسیر را در نظر می‌گیرد؛ زیرشکل‌های داخل مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `True` چاپ می‌کند.

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

## **استخراج و بازرسی عناصر شکل**

از [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) برای بازرسی یک شکل موجود به‌عنوان عناصری شامل نقاط مسیر و انواع نقطه استفاده کنید. هر [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) بازگردانده‌شده آرایه‌های [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) و [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) را در دسترس می‌گذارد. این نمایش برای تحلیل قالب یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین GeometryShape را مستقیماً بر روی اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌نماید. برای مشاهدهٔ خروجی هر دو نوع بخش (مستقیم و منحنی) از یک ارائه حاوی شکل با این دو نوع بخش استفاده کنید. جستجو در داخل گروه‌ها انجام نمی‌شود.

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
                point_type = types[i] & 0x07  # نگه داشتن نوع بخش، بدون پرچم‌ها.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # مصرف هر دو نقطه کنترل و نقطه انتهایی.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

آرایه‌ها با ایندکس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. مقدار `0` یک شکل را آغاز می‌کند و مقدار `1` خطی از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را همزمان مصرف می‌کند و نقطهٔ انتهایی را برای بسته بودن بررسی می‌نماید.

انواع نقطه همچنین پرچم‌هایی دارند. با ماسک `0x07` می‌توانید نوع بخش را شناسایی کنید و با تست جداگانهٔ `0x80` می‌توانید یک زیرمسیر بسته را تشخیص دهید. برای مثال `129` (`0x81`) یعنی نقطهٔ انتهایی خطی که زیرمسیر را می‌بندد، و `131` (`0x83`) یعنی نقطهٔ انتهایی Bézier که بسته می‌شود. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند dash (`0x10`) و marker (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیردسته‌بندی‌شده، مختصات استخراج‌شده قبلاً موقعیت `[x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)` و `[y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)` آن را شامل می‌شود و عرض و ارتفاع فعلی آن را نشان می‌دهد. به عنوان مثال، یک مستطیل بدون چرخش که در `(100, 200)` با اندازهٔ `120 × 80` قرار دارد، دارای مرزهای قالب `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسب به چارچوب غیرچرخان، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخش `[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)` یا وارونگی افقی/عمودی شکل را اعمال نمی‌کنند. برای بازتولید قالب نمایش‌داده‌شده، این تبدیلات را حول مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین تبدیل مختصات گروه و تبدیلات را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده تنها قالب را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را بروز نمی‌کند. وقتی تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد، از این روش استفاده کنید. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه، از [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) یا [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) اعمال کنید.

## **پرسش‌های متداول**

**پس از جایگزینی هندسه، پرکردن و خط‌کشی چه اتفاقی می‌افتد؟**

سبک با شکل باقی می‌ماند؛ فقط قالب تغییر می‌کند. پرکردن و خط‌کشی به‌طور خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌درستی همراه با هندسه‌اش بچرخانم؟**

از ویژگی `[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)` شکل استفاده کنید؛ هندسه به‌همراه شکل می‌چرخد زیرا به سیستم مختصات خود شکل وابسته است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/python-net/convert-powerpoint-to-png/) مورد نیاز یا خود [shape](/slides/fa/python-net/create-shape-thumbnails/) را به قالب raster صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.