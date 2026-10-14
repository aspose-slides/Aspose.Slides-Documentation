---
title: قالب‌بندی اشکال PowerPoint در پایتون
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌کش
- خط شکل طرح‌کش
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندرینگ شکل سیاه‑سفید
- رندرینگ شکل خاکستری
- چرخاندن شکل
- افکت برش سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در پایتون با استفاده از Aspose.Slides—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

در PowerPoint می‌توانید شکل‌ها را به اسلایدها اضافه کنید. از آنجا که شکل‌ها از خطوط تشکیل شده‌اند، می‌توانید آنها را با تغییر یا اعمال افکت‌ها بر روی حاشیه‌هایشان قالب‌بندی کنید. علاوه بر این، می‌توانید شکل‌ها را با تنظیماتی که کنترل می‌کند داخلی آنها چگونه پر شود، قالب‌بندی کنید.

![قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای Python کلاس‌ها و ویژگی‌هایی فراهم می‌کند که به شما امکان می‌دهند شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل تعیین کنید. مراحل زیر این فرایند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [سبک خط](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [سبک خط شکسته](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) شکل را تنظیم کنید.
1. رنگ خط شکل را تنظیم کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک AutoShape از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # حذف پر کردن از شکل مستطیل تا فقط خطوط آن قابل مشاهده باشند.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # اعمال قالب‌بندی به خطوط مستطیل.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # تنظیم رنگ خط مستطیل.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # ذخیره فایل PPTX به دیسک.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های طرح‌کش به خطوط شکل**

یک افکت طرح‌کش باعث می‌شود خط یک شکل شبیه به کشیده شده توسط دست ظاهر شود. برای دسترسی به تنظیمات خط از [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) استفاده کنید، برای دسترسی به تنظیمات طرح‌کش از [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) استفاده کنید، و برای انتخاب یک مقدار از شمارش‌نامه [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) از [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک افکت [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) اعمال شود، مقدار اختصاص یافته به‌صورت صریح خوانده شود و با استفاده از [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) افکت حذف شود:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # دسترسی به قالب‌بندی خط شکل و قالب‌بندی طرح‌کش آن.
    sketch_format = shape.line_format.sketch_format

    # اعمال یک افکت طرح‌کش.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # خواندن افکت طرح‌کش اختصاص داده‌شده مستقیم به شکل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # حذف افکت طرح‌کش.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

مقداری که `SketchFormat.sketch_type` برمی‌گرداند نمایانگر تنظیمی است که مستقیماً به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برسد، از [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) استفاده کنید، به ویژگی `sketch_format` شیء بازگردانده شده دسترسی پیدا کنید و مقدار ویژگی `sketch_type` آن را بخوانید. مقدار مؤثر نشان‌دهنده قالب‌بندی‌ای است که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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

در اینجا سه گزینه نوع اتصال آورده شده است:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در یک زاویه (مانند گوشه یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زاویه‌های تیز رسم می‌کنید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا دیده می‌شود) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شده‌اند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

	# دریافت اولین اسلاید.
	slide = presentation.slides[0]

	# سه AutoShape از نوع Rectangle اضافه کنید.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# رنگ پر کردن هر شکل مستطیل را تنظیم کنید.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# عرض خط را تنظیم کنید.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# رنگ خط هر مستطیل را تنظیم کنید.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# سبک اتصال را تنظیم کنید.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# متن را به هر مستطیل اضافه کنید.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# فایل PPTX را بر روی دیسک ذخیره کنید.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را به یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را به‌طوری اعمال کنید که یکی به‌ تدریج به دیگری محو شود.

در اینجا نحوه اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) شکل را به `GRADIENT` تنظیم کنید.
1. دو رنگ دلخواه خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعه `gradient_stops` که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع Ellipse اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # قالب‌بندی گرادیان را بر روی بیضی اعمال کنید.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # جهت گرادیان را تنظیم کنید.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # دو نقطه توقف گرادیان اضافه کنید.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادرشده متفاوت از همان‌طور که در PowerPoint نشان داده می‌شود باشد، به [انتخاب یک سبک رندرینگ گرادیان](/slides/fa/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر پر کردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک طراحی دو رنگی—مانند نقاط، خط‌خط‌ها، کراس‌هچ‌ها یا شطرنجی‌ها—به یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی از پیش تعریف شده ارائه می‌دهد که می‌توانید برای شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را ارتقا دهید. حتی پس از انتخاب یک الگوی پیش‌فرض، می‌توانید رنگ‌های دقیق مورد استفاده را مشخص کنید.

در اینجا نحوه اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) شکل را به `PATTERN` تنظیم کنید.
1. یک سبک الگو از گزینه‌های از پیش تعریف شده انتخاب کنید.
1. [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) الگو را تنظیم کنید.
1. [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) الگو را تنظیم کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # نوع پر کردن را به Pattern تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # سبک الگو را تنظیم کنید.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # رنگ پس‌زمینه و پیش‌زمینه الگو را تنظیم کنید.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طور مؤثری تصویر را به‌عنوان پس‌زمینه شکل استفاده کنید.

در اینجا نحوه استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) شکل را به `PICTURE` تنظیم کنید.
1. حالت پر کردن تصویر را به `TILE` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به ویژگی `picture.image` از `picture_fill_format` شکل اختصاص دهید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

بیایید بگوییم فایلی به‌نام "lotus.png" داریم که تصویر زیر را دارد:

![عکس لوتوس](lotus.png)

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # نوع پر کردن را به Picture تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # حالت پر کردن تصویر را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # یک تصویر بارگذاری کنید و به منابع ارائه اضافه کنید.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # تصویر را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی‌کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی کردن را سفارشی کنید، می‌توانید از ویژگی‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): حالت پر کردن تصویر—یا `TILE` یا `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): تراز کاشی‌ها در داخل شکل.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو وارونه شود.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): تنظیم جابجایی افقی کاشی (به پوینت) از مبدأ شکل.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): تنظیم جابجایی عمودی کاشی (به پوینت) از مبدأ شکل.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): تعریف مقیاس افقی کاشی به‌عنوان درصد.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): تعریف مقیاس عمودی کاشی به‌عنوان درصد.

کد زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    first_slide = presentation.slides[0]

    # یک AutoShape مستطیل اضافه کنید.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # تصویر را به شکل اختصاص دهید.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری را پیکربندی کنید.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ ثابت**

در PowerPoint، پر کردن با رنگ ثابت یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن با رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) شکل را به `SOLID` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # نوع پر کردن را به Solid تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # رنگ پر کردن را تنظیم کنید.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگامی که یک رنگ ثابت، گرادیان، تصویر یا پر کردن بافت را به شکل‌ها اعمال می‌کنید، می‌توانید سطح شفافیتی را نیز تنظیم کنید تا میزان مات بودن پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل شفاف‌تر شود و پس‌زمینه یا اشیاء زیرین به‌جزئی قابل دیدن باشند.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ استفاده‌شده برای پر کردن تنظیم کنید. در اینجا نحوه انجام این کار آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن را به `SOLID` تنظیم کنید.
1. از `Color.from_argb` برای تعریف رنگی با شفافیت (مكوّن `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]
    
    # یک AutoShape مستطیل ثابت اضافه کنید.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # یک AutoShape مستطیل شفاف بر روی شکل ثابت اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

Aspose.Slides به شما امکان می‌دهد شکل‌ها را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی `rotation` شکل را به زاویه دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # شکل را 5 درجه بچرخانید.
    shape.rotation = 5

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **اضافه کردن افکت‌های برش سه‌بعدی**

Aspose.Slides به شما اجازه می‌دهد افکت‌های برش سه‌بعدی را به شکل‌ها اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) آنها.

برای اضافه کردن افکت‌های برش سه‌بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) شکل را تنظیم کنید تا تنظیمات برش را تعریف کنید.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # یک شکل به اسلاید اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # ارائه را به‌عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت برش ۳بعدی](3D-bevel-effect.png)

## **اضافه کردن افکت‌های چرخش سه‌بعدی**

Aspose.Slides به شما اجازه می‌دهد افکت‌های چرخش سه‌بعدی را به شکل‌ها اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) آنها.

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک ارجاع به اسلایدی بر حسب ایندکس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) و [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) شکل را تنظیم کنید تا چرخش سه‌بعدی تعریف شود.
1. ارائه را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # ارائه را به‌عنوان فایل PPTX ذخیره کنید.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت چرخش ۳بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑سفید برای شکل‌ها**

خاصیت [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) مشخص می‌کند که یک شکل به‌تنهایی هنگام نمایش یا پردازش ارائه در حالت سیاه‑سفید چگونه رندر شود. این ویژگی به‌تنهایی حالت سیاه‑سفید را فعال نمی‌کند و در حالت رنگی عادی، پر کردن، خط یا قالب‌بندی دیگر شکل را تغییر نمی‌دهد.

یک مقدار از شمارش‌نامه [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) را برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `AUTOMATIC` به برنامه رندر اجازه می‌دهد تبدیل را انتخاب کند، `GRAY` و `LIGHT_GRAY` از رنگ خاکستری استفاده می‌کنند، `BLACK_WHITE` فقط سیاه و سفید، `BLACK` و `WHITE` یک رنگ ثابت، `COLOR` رنگ عادی را حفظ می‌کند و `HIDDEN` شکل را در حالت سیاه‑سفید حذف می‌کند. `NOT_DEFINED` به این معناست که هیچ حالت سطح‌شکل اختصاص داده نشده است.

کد زیر یک شکل رنگی ایجاد می‌کند و آن را طوری تنظیم می‌کند که در حالت نمایش سیاه‑سفید به‌صورت خاکستری ظاهر شود:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # در حالت رنگی پر کردن نارنجی را حفظ کنید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

در حالت رنگ عادی، مستطیل پر شدن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `GRAY` از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا دیگر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام شکل‌های دارای جای‌نگهدارنده را در [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض برگردانید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # بازنشانی هر شکلی در اسلاید که یک جای‌نگهدارنده در چیدمان دارد.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**آیا قالب‌بندی شکل بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

فقط به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

هر ویژگی کلیدی قالب‌بندی شکل‌ها—پر کردن، خط و تنظیمات افکت—را با هم مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک‌های آنها را یکسان درنظر بگیرید و به‌صورت منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت بعدی سبک‌ها را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد کنم؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آنها را در هر جایی که لازم است دوباره اعمال کنید.