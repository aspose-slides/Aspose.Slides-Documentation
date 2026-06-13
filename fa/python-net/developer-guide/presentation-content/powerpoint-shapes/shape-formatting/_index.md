---
title: قالب‌بندی اشکال PowerPoint در Python
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/python-net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- قالب‌بندی نوع اتصال
- پرکردن شیب‌دار
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ جامد
- شفافیت شکل
- چرخاندن شکل
- اثر لبه سه‌بعدی
- اثر چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در Python با استفاده از Aspose.Slides قالب‌بندی کنید—پرکردن، خط و سبک‌های اثر را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال اثرات بر حاشیه آن‌ها، قالب‌بندی کنید. علاوه بر این، می‌توانید با تعیین تنظیماتی که کنترل می‌کنند داخل اشکال چگونه پر شود، قالب‌بندی کنید.

![قالب‌بندی‌شکل‑در‑PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python کلاس‌ها و خصوصیاتیکه اجازه می‌دهند با استفاده از همان گزینه‌های موجود در PowerPoint اشکال را قالب‌بندی کنید، فراهم می‌کند.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روش را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. قالب‌خط [line style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. قالب‌خط دَش [dash style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/linedashstyle/) شکل را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را قالب‌بندی کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند ایجاد کنید.
with slides.Presentation() as presentation:

    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # رنگ پر کننده برای شکل مستطیل را تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # قالب‌بندی خطوط مستطیل را اعمال کنید.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # رنگ خط مستطیل را تنظیم کنید.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![خطوط‌قالب‌بندی‌شده‑در‑ارائه](formatted-lines.png)

## **قالب‌بندی انواع اتصال**

سه گزینهٔ نوع اتصال وجود دارد:

* گرد
* قاطع
* شیاردار

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در زاویه‌ای (مانند گوشهٔ یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زوایای تیزی رسم می‌کنید، ممکن است گزینهٔ **Miter** را ترجیح دهید.

![نوع‌اتصال‑در‑ارائه](join-style-powerpoint.png)

کد پایتون زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا دیده می‌شود) با تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

	# اولین اسلاید را دریافت کنید.
	slide = presentation.slides[0]

	# سه شکل خودکار از نوع Rectangle اضافه کنید.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# رنگ پر کردن برای هر شکل مستطیل را تنظیم کنید.
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

	# رنگ خط برای هر مستطیل را تنظیم کنید.
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

	# فایل PPTX را روی دیسک ذخیره کنید.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **پر کردن شیب‌دار**

در PowerPoint، پر کردن شیب‌دار یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد ترکیبی پیوسته از رنگ‌ها را روی یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را به‌طوری که یکی به‌تدریج به دیگری محو شود، اعمال کنید.

در ادامه نحوهٔ اعمال پر کردن شیب‌دار به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `GRADIENT` تنظیم کنید.
1. دو رنگ مطلوب خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `add` مجموعه `gradient_stops` که توسط کلاس [GradientFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/gradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Ellipse اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # قالب‌بندی گرادیان را به بیضی اعمال کنید.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # جهت گرادیان را تنظیم کنید.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # دو نقطه توقف گرادیان اضافه کنید.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![بیضی‌با‌پر‌کردن‌شیب‌دار](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد طرحی دو رنگی—مانند نقطه‌ها، خط‌راها، خط‌چوب‌ها یا الگوهای شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینهٔ الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک پیش‌تعریف‌شدهٔ الگو را فراهم می‌کند که می‌توانید به شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگو پیش‌تعریف‌شده، می‌توانید رنگ‌های دقیق موردنظر را مشخص کنید.

نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PATTERN` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. ویژگی [back_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/back_color/) الگو را تنظیم کنید.
1. ویژگی [fore_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides/patternformat/fore_color/) الگو را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # نوع پر کردن را به Pattern تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # سبک الگو را تنظیم کنید.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # رنگ پس‌زمینه و پیش‌زمینهٔ الگو را تنظیم کنید.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![مستطیل‌با‌پر‌کردن‌الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینهٔ قالب‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل درج کنید—به‌طور مؤثر تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده کنید.

نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `PICTURE` تنظیم کنید.
1. حالت پر کردن تصویر را به `TILE` (یا حالت دلخواه دیگر) تنظیم کنید.
1. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. این تصویر را به خصوصیت `picture.image` قالب‌پرکردن تصویر (`picture_fill_format`) شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد پایتون زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # نوع پر کردن را به Picture تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # حالت پر کردن تصویر را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # یک تصویر بارگذاری کنید و آن را به منابع ارائه اضافه کنید.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # تصویر را تنظیم کنید.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل‌با‌پر‌کردن‌تصویر](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر کاشی‑شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌بندی را سفارشی کنید، می‌توانید از خصوصیات زیر کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/) استفاده کنید:

- [picture_fill_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/picture_fill_mode/): حالت پر کردن تصویر—`TILE` یا `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_alignment/): تراز کاشی‌ها در داخل شکل.
- [tile_flip](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_flip/): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [tile_offset_x](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_offset_x/): جابجایی افقی کاشی (به پوینت) از مبدأ شکل.
- [tile_offset_y](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_offset_y/): جابجایی عمودی کاشی (به پوینت) از مبدأ شکل.
- [tile_scale_x](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_scale_x/): مقیاس افقی کاشی به‌صورت درصد.
- [tile_scale_y](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillformat/tile_scale_y/): مقیاس عمودی کاشی به‌صورت درصد.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‑شده اضافه کرده و گزینه‌های کاشی را پیکربندی کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اولین اسلاید را دریافت کنید.
    first_slide = presentation.slides[0]

    # یک شکل خودکار مستطیل اضافه کنید.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # نوع پر کردن شکل را به Picture تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # تصویر را بارگذاری کنید و به منابع ارائه اضافه کنید.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # تصویر را به شکل اختصاص دهید.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # حالت پر کردن تصویر و ویژگی‌های کاشی‌بندی را پیکربندی کنید.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![گزینه‌های‌کاشی](tile-options.png)

## **پر کردن رنگ جامد**

در PowerPoint، پر کردن رنگ جامد یک گزینهٔ قالب‌بندی است که شکل را با یک رنگ یکنواخت پر می‌کند. این رنگ پس‌زمینهٔ ساده بدون هیچ شیب، بافت یا الگویی اعمال می‌شود.

برای اعمال پر کردن رنگ جامد به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) شکل را به `SOLID` تنظیم کنید.
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.
1. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک مستطیل را در اسلاید PowerPoint با پر کردن رنگ جامد قالب‌بندی کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # نوع پر کردن را به Solid تنظیم کنید.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # رنگ پر کردن را تنظیم کنید.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل‌با‌پر‌کردن‌رنگ‑جامد](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، زمانی که پر کردن رنگ جامد، شیب‌دار، تصویر یا بافت را به اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان قابلیت مشاهدهٔ پر کردن را کنترل کنید. مقدار شفافیت بالاتر شکل را بیشتر شفاف می‌کند و پس‌زمینه یا اشیای زیرین را قابل مشاهده می‌سازد.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفای رنگ مورد استفاده برای پر کردن تنظیم کنید. روش کار به‌صورت زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی پر کردن را به `SOLID` تنظیم کنید.
1. از `Color.from_argb` برای تعریف رنگی با شفافیت (مقدار `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک رنگ پر کردن شفاف به یک مستطیل اعمال کنید:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]
    
    # یک شکل خودکار مستطیل صلب اضافه کنید.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # یک شکل خودکار مستطیل شفاف بر روی شکل صلب اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![شکل‌شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام قرار دادن عناصر بصری با نیازهای خاص تراز یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. ویژگی `rotation` شکل را به زاویهٔ مطلوب تنظیم کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه یک شکل را به‌طور ۵ درجه بچرخانید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد ایجاد کنید.
with slides.Presentation() as presentation:

    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع Rectangle اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # شکل را به میزان 5 درجه بچرخانید.
    shape.rotation = 5

    # فایل PPTX را روی دیسک ذخیره کنید.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

نتیجه:

![چرخش‌شکل](shape-rotation.png)

## **افزودن اثر لبهٔ سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد اثرات لبهٔ سه‌بعدی را به اشکال اعمال کنید با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/).

برای افزودن اثر لبهٔ سه‌بعدی به یک شکل، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات لبه پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه اثر لبهٔ سه‌بعدی را به یک شکل اعمال کنید:

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

![اثر‑لبه‑سه‌بعدی](3D-bevel-effect.png)

## **افزودن اثر چرخش سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد اثرات چرخش سه‌بعدی را به اشکال اعمال کنید با پیکربندی خصوصیات [ThreeDFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/threedformat/).

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را بر اساس اندیس آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را به اسلاید اضافه کنید.
1. خصوصیات [camera_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/camera/camera_type/) و [light_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/lightrig/light_type/) شکل را برای تعریف چرخش سه‌بعدی تنظیم کنید.
1. ارائه را ذخیره کنید.

کد پایتون زیر نشان می‌دهد چگونه اثر چرخش سه‌بعدی را به یک شکل اعمال کنید:

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

![اثر‑چرخش‑سه‌بعدی](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی**

کد پایتون زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکال دارای نگهدارنده‌ها را در [LayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) به تنظیمات پیش‌فرض برگردانید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # هر شکلی را روی اسلاید که یک نگهدارنده در طرح‌بندی دارد ریست کنید.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا قالب‌بندی اشکال بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌طور جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضای فایل را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، اثرات و شیب‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافه‌ای ندارند.

**چگونه می‌توانم اشکالی را در اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا آنها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—تنظیمات پر کردن، خط و اثرات—را مقایسه کنید. اگر تمام مقادیر متناظر مطابقت داشت، سبک‌ها را یکسان در نظر بگیرید و آن اشکال را به‌صورت منطقی گروه‌بندی کنید که مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را cloning کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است اعمال کنید.