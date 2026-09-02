---
title: قالب‌بندی اشکال پاورپوینت در پایتون
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط اسکیچ شکل
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برجستگی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Python با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت بر خطوط مرزی آن‌ها را قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای Python کلاس‌ها و ویژگی‌هایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید سبک خط سفارشی برای یک شکل تعریف کنید. مراحل زیر روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [line style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. ویژگی [dash style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linedashstyle/) شکل را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

کد Python زیر نحوه قالب‌بندی یک `AutoShape` مستطیل را نشان می‌دهد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Rectangle
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # حذف پرشکله از شکل مستطیل تا فقط خطوط آن قابل رؤیت باشد
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # اعمال قالب‌بندی به خطوط مستطیل
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # تعیین رنگ برای خط مستطیل
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # ذخیره فایل PPTX بر روی دیسک
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت اسکیچ بر خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط یک شکل شبیه به دست‌خط به نظر برسد. برای دسترسی به تنظیمات خط از [Shape.line_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/line_format/) استفاده کنید، برای دسترسی به تنظیمات اسکیچ از [LineFormat.sketch_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lineformat/sketch_format/) و برای انتخاب مقدار از enumeration [LineSketchType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/) از [SketchFormat.sketch_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sketchformat/sketch_type/) استفاده کنید.

کد Python زیر نحوه اعمال افکت [LineSketchType.CURVED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/)، خواندن مقدار به‌طور صریح تعیین‌شده و حذف افکت با [LineSketchType.NONE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/) را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # دسترسی به قالب‌بندی خط شکل و قالب‌بندی اسکیچ آن.
    sketch_format = shape.line_format.sketch_format

    # اعمال افکت اسکیچ.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # خواندن افکت اسکیچ اختصاص داده‌شده مستقیم به شکل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # حذف افکت اسکیچ.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

مقداری که توسط `SketchFormat.sketch_type` بازگردانده می‌شود، تنظیمی را نشان می‌دهد که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط قابل ارث‌بری از تم، اسلاید اصلی یا اسلاید چیدمان باشد، از [LineFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lineformat/get_effective/) استفاده کنید، به ویژگی `sketch_format` شیء بازگشتی دسترسی پیدا کنید و مقدار ویژگی `sketch_type` آن را بخوانید. مقدار مؤثر نشان‌دهنده قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه‌ی نوع اتصال وجود دارد:

* گرد
* شیاردار
* کانفی

به‌صورت پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشهٔ یک شکل) به هم می‌پیوندد، از تنظیم **Round** استفاده می‌کند. اما اگر شکلی با زاویه‌های تیز ترسیم می‌کنید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد Python زیر نحوهٔ ایجاد سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round را نشان می‌دهد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است.
with slides.Presentation() as presentation:

	# دریافت اولین اسلاید.
	slide = presentation.slides[0]

	# افزودن سه AutoShape از نوع Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# تنظیم رنگ پر برای هر شکل مستطیل.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# تنظیم عرض خط.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# تنظیم رنگ برای خط هر مستطیل.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# تنظیم سبک اتصال.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# افزودن متن به هر مستطیل.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# ذخیره فایل PPTX بر روی دیسک.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `GRADIENT` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعه `gradient_stops` که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # اعمال قالب‌بندی گرادیان به بیضی.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # تنظیم جهت گرادیان.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # افزودن دو نقطه توقف گرادیان.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینهٔ قالب‌بندی است که به شما امکان می‌دهد طرح دو‌رنگی—مانند نقاط، خطوط، خطوط متقاطع یا طرح شطرنجی—را بر روی شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگو پیش‌تعریف‌شده را فراهم می‌کند که می‌توانید بر روی اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PATTERN` تنظیم کنید.
1. یک سبک الگو را از میان گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. مقدار [back_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/back_color/) الگو را تنظیم کنید.
1. مقدار [fore_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/fore_color/) الگو را تنظیم کنید.
1. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تنظیم نوع پر کردن به Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # تنظیم سبک الگو.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد تصویری را داخل یک شکل قرار دهید—به‌طوری که تصویر به‌عنوان پس‌زمینهٔ شکل استفاده شود.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PICTURE` تنظیم کنید.
1. حالت پر کردن تصویر را به `TILE` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) از تصویر مورد نظر خود ایجاد کنید.
1. این تصویر را به ویژگی `picture.image` از `picture_fill_format` شکل اختصاص دهید.
1. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

![تصویر لوتوس](lotus.png)

کد Python زیر نحوهٔ پر کردن یک شکل با تصویر را نشان می‌دهد:

```python
import aspose.slides as slides

    # ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است.
    with slides.Presentation() as presentation:

        # دریافت اولین اسلاید.
        slide = presentation.slides[0]

        # افزودن یک AutoShape از نوع Rectangle.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

        # تنظیم نوع پر کردن به Picture.
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # تنظیم حالت پر کردن تصویر.
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

        # بارگذاری یک تصویر و افزودن آن به منابع ارائه.
        with slides.Images.from_file("lotus.png") as image:
            presentation_image = presentation.images.add_image(image)

        # تنظیم تصویر.
        shape.fill_format.picture_fill_format.picture.image = presentation_image

        # ذخیره فایل PPTX بر روی دیسک.
        presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی‌کردن تصویر به‌عنوان بافت**

اگر می‌خواهید تصویری کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌ها را سفارشی کنید، می‌توانید از ویژگی‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode]: حالت پر کردن تصویر را تنظیم می‌کند—`TILE` یا `STRETCH`.
- [tile_alignment]: هم‌ترازی کاشی‌ها درون شکل را مشخص می‌کند.
- [tile_flip]: تعیین می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [tile_offset_x]: افست افقی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [tile_offset_y]: افست عمودی کاشی (به نقطه) را از مبدأ شکل تنظیم می‌کند.
- [tile_scale_x]: مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [tile_scale_y]: مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```py
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    first_slide = presentation.slides[0]

    # افزودن یک AutoShape مستطیل.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # تنظیم نوع پر کردن شکل به Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # بارگذاری تصویر و افزودن آن به منابع ارائه.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # اختصاص تصویر به شکل.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ ثابت**

در PowerPoint، پر کردن رنگ ثابت یک گزینهٔ قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینهٔ ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `SOLID` تنظیم کنید.
1. رنگ پر کردن مورد نظر خود را به شکل اختصاص دهید.
1. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # تنظیم نوع پر کردن به Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # تنظیم رنگ پر کردن.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگامی که یک پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پر کردن کنترل شود. مقدار بالاتر شفافیت باعث می‌شود شکل بیشتر شفاف باشد و پس‌زمینه یا اشیای زیرین بخشی از آن را مشاهده کنند.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوه انجام آن آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی FillType را به `SOLID` تنظیم کنید.
1. از `Color.from_argb` برای تعریف یک رنگ با شفافیت استفاده کنید (جزء `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]
    
    # افزودن یک AutoShape مستطیل ثابت.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # افزودن یک AutoShape مستطیل شفاف بر روی شکل ثابت.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص ترازبندی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی `rotation` شکل را به زاویه دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # چرخاندن شکل به میزان 5 درجه.
    shape.rotation = 5

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجسته‌سازی 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی 3D را با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) شکل‌ها اعمال کنید.

برای افزودن افکت‌های برجسته‌سازی 3D به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # افزودن یک شکل به اسلاید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # تنظیم ویژگی‌های ThreeDFormat شکل.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # ذخیره ارائه به‌صورت فایل PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت برجستگی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) شکل‌ها اعمال کنید.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس آن، ارجاعی به اسلاید دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [camera_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/camera/camera_type/) و [light_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lightrig/light_type/) شکل را تنظیم کنید تا چرخش 3D تعریف شود.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

# ایجاد یک نمونه از کلاس Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # ذخیره ارائه به‌صورت فایل PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

ویژگی [Shape.black_white_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/black_white_mode/) مشخص می‌کند که یک شکل به‌صورت منفرد چگونه در حالت نمایش یا پردازش سیاه‑سفید رندر شود. این ویژگی به‌تنهایی حالت نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا دیگر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقداری از enumeration [BlackWhiteMode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/blackwhitemode/) برای انتخاب رفتار دلخواه استفاده کنید. به‌عنوان مثال، `AUTOMATIC` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `GRAY` و `LIGHT_GRAY` از رنگ خاکستری استفاده می‌کنند، `BLACK_WHITE` فقط سیاه و سفید، `BLACK` و `WHITE` یک رنگ واحد را اعمال می‌کنند، `COLOR` رنگ عادی را حفظ می‌کند و `HIDDEN` شکل را در حالت سیاه‑سفید حذف می‌کند. `NOT_DEFINED` به این معنی است که هیچ حالت سطح شکل‌ایی اختصاص نیافته است.

کد Python زیر یک شکل رنگی را ایجاد می‌کند و آن را در حالت نمایش سیاه‑سفید به‌صورت خاکستری نشان می‌دهد:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # پر کردن نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

در حالت رنگ عادی، مستطیل پرشدگی نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `GRAY` از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد یک اسلاید تمام‌رنگ را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد Python زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با جای‌گیرها در [LayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # بازنشانی هر شکل در اسلایدی که جای‌گیر در طرح‌بندی دارد.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا قالب‌بندی اشکال بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت حداقل. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پر، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر یکسان باشند، سبک آنها را یکسان در نظر بگیرید و منطقی آن اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آنها را در هر جایی که لازم باشد اعمال کنید.