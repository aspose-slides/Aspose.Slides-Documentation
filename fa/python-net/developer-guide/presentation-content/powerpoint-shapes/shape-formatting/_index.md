---
title: قالب‌بندی اشکال پاورپوینت در پایتون
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ جامد
- شفافیت شکل
- چرخاندن شکل
- افکت برج 3بعدی
- افکت چرخش 3بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "بیاموزید چگونه اشکال پاورپوینت را در پایتون با استفاده از Aspose.Slides قالب‌بندی کنید—پر کردن، خط و سبک‌های افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط ساخته شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها به حاشیه‌های آنها فرمت‌دهی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که نحوه پر شدن داخل آنها را کنترل می‌کند، اشکال را فرمت‌دهی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides for Python کلاس‌ها و ویژگی‌هایی را فراهم می‌کند که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint فرمت‌دهی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید برای یک شکل سبک خط سفارشی تعیین کنید. مراحل زیر روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. [style خط](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [dash style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linedashstyle/) شکل را تنظیم کنید.
1. رنگ خط برای شکل را تعیین کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را قالب‌بندی کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

#    یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    #    اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    #    یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    #    رنگ پر برای شکل مستطیل را تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    #    قالب‌بندی خطوط مستطیل را اعمال کنید.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    #    رنگ خط مستطیل را تنظیم کنید.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    #    فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خط‌های قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکچ به خطوط شکل**

یک افکت اسکچ ظاهر خط شکل را به‌صورت دستی‌کشیده نشان می‌دهد. از [Shape.line_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/line_format/) برای دسترسی به تنظیمات خط، [LineFormat.sketch_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lineformat/sketch_format/) برای دسترسی به تنظیمات اسکچ، و [SketchFormat.sketch_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sketchformat/sketch_type/) برای انتخاب مقداری از شمارش [LineSketchType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/) استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه افکت [LineSketchType.CURVED](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاصی را بخوانید و با [LineSketchType.NONE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linesketchtype/) افکت را حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # دسترسی به قالب خط شکل و قالب اسکچ آن.
    sketch_format = shape.line_format.sketch_format

    # اعمال افکت اسکچ.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # خواندن افکت اسکچ اختصاص داده شده مستقیم به شکل.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # حذف افکت اسکچ.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

مقداری که `SketchFormat.sketch_type` برمی‌گرداند، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [LineFormat.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lineformat/get_effective/) استفاده کنید، به ویژگی `sketch_format` شیء بازگشتی دسترسی پیدا کنید و مقدار `sketch_type` آن را بخوانید. مقدار مؤثر نشان‌دهنده قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود:

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

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

به‌صورت پیش‌فرض، وقتی PowerPoint دو خط را با زاویه‌ای (مثلاً در گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکلی با زوایای تیز می‌کشید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد پایتون زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا مشاهده می‌شود) با تنظیمات اتصال Miter، Bevel و Round ساخته شدند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

	# دریافت اولین اسلاید.
	slide = presentation.slides[0]

	# افزودن سه شکل خودکار از نوع Rectangle.
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

	# تنظیم رنگ خط برای هر مستطیل.
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

در PowerPoint، پر کردن گرادیان گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیبی مداوم از رنگ‌ها را بر یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `GRADIENT` تنظیم کنید.
1. دو رنگ مطلوب خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعهٔ `gradient_stops` که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/gradientformat/) در دسترس است، اضافه کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک افکت پر کردن گرادیان را به یک بیضی اعمال کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک شکل خودکار از نوع Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # اعمال قالب‌بندی گرادیان به الیپس.
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

در PowerPoint، پر کردن الگو گزینهٔ قالب‌بندی است که به شما امکان می‌دهد یک طرح دو‌رنگ—مانند نقطه‌ها، خط‌های راه راه، کراس‌هچ‌ها یا شطرنجی‌ها—را بر یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی از پیش تعریف‌شده را فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی از پیش تعریف‌شده، می‌توانید رنگ‌های دقیق موردنظر را نیز مشخص کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PATTERN` تنظیم کنید.
1. یک سبک الگو از گزینه‌های از پیش تعریف‌شده انتخاب کنید.
1. مقدار [back_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/back_color/) الگو را تنظیم کنید.
1. مقدار [fore_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/fore_color/) الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه پر کردن الگو را به یک مستطیل اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک شکل خودکار از نوع Rectangle.
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

در PowerPoint، پر کردن تصویر گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل درج کنید — به‌طوری که تصویر به‌عنوان پس‌زمینهٔ شکل عمل کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PICTURE` تنظیم کنید.
1. حالت پر کردن تصویر را به `TILE` (یا حالت موردنظر دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به ویژگی `picture.image` قالب `picture_fill_format` شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

فرض کنیم فایلی به نام «lotus.png» با تصویر زیر داشته باشیم:

![عکس لوتوس](lotus.png)

کد پایتون زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک شکل خودکار از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # تنظیم نوع پر کردن به Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تنظیم حالت پر کردن تصویر.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # بارگیری یک تصویر و افزودن آن به منابع ارائه.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # تنظیم تصویر.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌شدن را سفارشی کنید، می‌توانید از ویژگی‌های زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/picture_fill_mode/): حالت پر کردن تصویر را تنظیم می‌کند — `TILE` یا `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_alignment/): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [tile_flip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_flip/): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو برگردانده شود.
- [tile_offset_x](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_offset_x/): افست افقی کاشی (به‌پونیک) نسبت به مبدأ شکل را تنظیم می‌کند.
- [tile_offset_y](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_offset_y/): افست عمودی کاشی (به‌پونیک) نسبت به مبدأ شکل را تنظیم می‌کند.
- [tile_scale_x](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_scale_x/): مقیاس افقی کاشی به‌صورت درصد تعیین می‌شود.
- [tile_scale_y](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_scale_y/): مقیاس عمودی کاشی به‌صورت درصد تعیین می‌شود.

کد نمونهٔ زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اسلاید اول.
    first_slide = presentation.slides[0]

    # افزودن یک شکل خودکار مستطیل.
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

    # ذخیرهٔ فایل PPTX بر روی دیسک.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ جامد**

در PowerPoint، پر کردن رنگ جامد گزینهٔ قالب‌بندی است که یک شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن رنگ جامد به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `SOLID` تنظیم کنید.
1. رنگ پر‌کنندهٔ موردنظر خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه پر کردن رنگ جامد را به یک مستطیل در اسلاید پاورپوینت اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

#    یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    #    دریافت اولین اسلاید.
    slide = presentation.slides[0]

    #    یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    #    نوع پر کردن را به Solid تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.SOLID

    #    رنگ پر را تنظیم کنید.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    #    فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل با پر کردن رنگ جامد](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، هنگام اعمال رنگ جامد، گرادیان، تصویر یا بافت به اشکال، می‌توانید سطح شفافیتی را تنظیم کنید تا میزان تیرگی پر کردن را کنترل کنید. مقدار شفافیت بالاتر شکل را شفاف‌تر می‌کند و پس‌زمینه یا اشیاء زیرین را تا حدی قابل مشاهده می‌سازد.

Aspose.Slides به شما اجازه می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تغییر دهید. این‌گونه می‌توانید انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. نوع پر کردن را به `SOLID` تنظیم کنید.
1. از `Color.from_argb` برای تعریف رنگی با شفافیت (مؤلفهٔ `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف به یک مستطیل اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]
    
    # افزودن یک شکل خودکار مستطیل جامد.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # افزودن یک شکل خودکار مستطیل شفاف بر روی شکل جامد.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌دهی عناصر بصری با نیازهای خاص هم‌راستایی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی `rotation` شکل را به زاویهٔ موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک شکل را به میزان 5 درجه بچرخانید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک شکل خودکار از نوع Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # چرخاندن شکل به میزان 5 درجه.
    shape.rotation = 5

    # ذخیره فایل PPTX بر روی دیسک.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برج 3بعدی**

Aspose.Slides به شما اجازه می‌دهد افکت‌های برج 3بعدی را به اشکال اعمال کنید با تنظیم ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/).

برای افزودن افکت‌های برج 3بعدی به یک شکل، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات برج را تعریف کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه افکت‌های برج 3بعدی را به یک شکل اعمال کنید:

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

    # ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت برج 3بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3بعدی**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3بعدی را به اشکال اعمال کنید با تنظیم ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/).

برای اعمال چرخش 3بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [camera_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/camera/camera_type/) و [light_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lightrig/light_type/) شکل را تنظیم کنید تا چرخش 3بعدی تعریف شود.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه افکت‌های چرخش 3بعدی را به یک شکل اعمال کنید:

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

    # ارائه را به عنوان فایل PPTX ذخیره کنید.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![افکت چرخش 3بعدی](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد پایتون زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال با جای‌گیرها را در [LayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض بازگردانید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # هر شکل در اسلاید را که دارای جای‌گیر در طرح‌بندی است بازنشانی کنید.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صورت حداقلی. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافه‌ای ایجاد نمی‌کنند.

**چگونه می‌توانم اشکالی را که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل — تنظیمات پر، خط و افکت — را با یکدیگر مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشته باشند، سبک آنها را یکسان در نظر بگیرید و منطقی این اشکال را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در ادامه ساده می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر از آن استفاده کنم؟**

بله. اشکال نمونه با سبک‌های موردنظر را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آنها را در هرجا که لازم باشد اعمال کنید.