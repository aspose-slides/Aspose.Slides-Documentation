---
title: مدیریت جعبه‌های متن در ارائه‌ها با پایتون
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/python-net/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند ابرمتنی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **معرفی**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا اشکال وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Python کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را فراهم می‌کند که به شما امکان می‌دهد یک شکل حاوی متن اضافه کنید.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را ارائه می‌دهد. اما همه اشکال نمی‌توانند متن داشته باشند.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
به همین دلیل، وقتی با شکیه‌ای سر و کار دارید که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید تأیید کنید که آن شکیه از طریق کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) تبدیل شده است. تنها پس از آن می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) کار کنید که یک ویژگی زیر [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) است. بخش [Update Text](/slides/fa/python-net/manage-textbox/#update-text) در این صفحه را ببینید.
{{% /alert %}}

## **ایجاد جعبه‌های متن در اسلایدها**

برای ایجاد یک جعبه متن در یک اسلاید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید اول ارجاع بگیرید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با `ShapeType.RECTANGLE` در موقعیت دلخواه روی اسلاید اضافه کنید.
4. متن را در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل تنظیم کنید.
5. ارائه را به صورت فایل PPTX ذخیره کنید.

مثال زیر در Python این مراحل را اجرا می‌کند:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # اسلاید اول ارائه را دریافت کنید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع RECTANGLE اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی اینکه آیا یک شکل جعبه متن است یا نه**

Aspose.Slides ویژگی [is_text_box](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/is_text_box/) را در کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) فراهم می‌کند که به شما اجازه می‌دهد تعیین کنید آیا یک شکل جعبه متن است یا خیر.

![Text box and shape](istextbox.png)

این مثال پایتون نشان می‌دهد چگونه بررسی کنید که آیا یک شکل به عنوان جعبه متن ایجاد شده است:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

توجه داشته باشید که اگر یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را با استفاده از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) اضافه کنید، ویژگی `is_text_box` شکل مقدار `False` برمی‌گرداند. اما پس از افزودن متن—چه با متد `add_text_frame` و چه با تنظیم ویژگی `text`—`is_text_box` مقدار `True` می‌دهد.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box غلط است
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box درست است

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box غلط است
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box درست است

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box غلط است
    shape3.add_text_frame("")
    # shape3.is_text_box غلط است

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box غلط است
    shape4.text_frame.text = ""
    # shape4.is_text_box غلط است
```

## **یافتن شکلی که TextFrame را مالک است**

در کدهای عمومی پردازش متن، ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) دریافت کنید بدون اینکه قبلاً بدانید کدام شیء ارائه آن را شامل می‌شود. از ویژگی [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) استفاده کنید تا به شکل مالک بازگردید.

برای یک TextFrame که به یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) یا شکل دیگری حاوی متن تعلق دارد، [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) تنظیم شده و [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) مقدار `None` دارد. هر دو ویژگی فقط برای ناوبری خواندنی هستند، بنابراین خواندن آن‌ها مالکیت را تغییر نمی‌دهد. همیشه قبل از دسترسی به شکل، مقدار برگشتی را برای `None` بررسی کنید.

برای مثال کامل که مالکیت شکل و سلول جدول را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به جعبه‌های متن**

Aspose.Slides ویژگی‌های [column_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_count/) و [column_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_spacing/) را در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) ارائه می‌دهد تا ستون‌ها به جعبه‌های متن اضافه شوند. می‌توانید تعداد ستون‌ها را مشخص کنید و فاصله (بر حسب نقطه) بین ستون‌ها را تنظیم کنید.

کد پایتون زیر این عملیات را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# دریافت اولین اسلاید در ارائه.
	slide = presentation.slides[0]

	# یک AutoShape از نوع RECTANGLE اضافه کنید.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# یک TextFrame به مستطیل اضافه کنید.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# دریافت قالب متن TextFrame.
	format = shape.text_frame.text_frame_format

	# تعداد ستون‌ها در TextFrame را مشخص کنید.
	format.column_count = 3

	# فاصله بین ستون‌ها را مشخص کنید.
	format.column_spacing = 10

	# ذخیرهٔ ارائه.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی متن**

Aspose.Slides به شما امکان می‌دهد متن را در یک جعبه متن منفرد یا در سراسر یک ارائه به‌روزرسانی کنید.

مثال زیر در پایتون نشان می‌دهد چگونه تمام متن‌ها را در یک ارائه به‌روزرسانی کنید:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # ذخیرهٔ ارائه تغییر یافته.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن جعبه‌های متن با پیوندهای ابرمتنی**

می‌توانید یک پیوند را در جعبه متن وارد کنید. وقتی جعبه متن کلیک شود، پیوند باز می‌شود.

برای افزودن جعبه متنی که شامل پیوند ابرمتنی است، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید اول ارجاع بگیرید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با `ShapeType.RECTANGLE` در موقعیت دلخواه روی اسلاید اضافه کنید.
4. متن را در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل تنظیم کنید.
5. به [HyperlinkManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/) ارجاع بگیرید.
6. از ویژگی `hyperlink_manager` برای تنظیم یک پیوند کلیک خارجی استفاده کنید.
7. ارائه را به صورت فایل PPTX ذخیره کنید.

این مثال پایتون نحوه افزودن جعبه متن با پیوند ابرمتنی به یک اسلاید را نشان می‌دهد:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # اولین اسلاید در ارائه را دریافت کنید.
    slide = presentation.slides[0]

    # یک AutoShape از نوع RECTANGLE اضافه کنید.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # متن را به فریم اضافه کنید.
    text_portion.text = "Aspose.Slides"

    # یک پیوند ابرمتنی برای متن بخش تنظیم کنید.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**فرق بین جعبه متن و جای‌دار متن (placeholder) هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/python-net/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل در یک اسلاید خاص است و هنگام تغییر طرح‌بندی تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متن به صورت دسته‌ای در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جدول‌ها و SmartArt دست بزنم؟**

تکرار خود را به auto‑shapesهایی که فریم متن دارند محدود کنید و اشیاء توکار (مانند [charts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/)) را با عبور از مجموعه‌هایشان به‌صورت جداگانه یا صرف‌نظر کردن از آن انواع اشیاء، حذف کنید.