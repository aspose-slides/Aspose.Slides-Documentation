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
- افزودن پیوند
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق .NET ایجاد، ویرایش و کلون کردن جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را بهبود می‌بخشد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای اضافه کردن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Python کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را ارائه می‌دهد که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را فراهم می‌کند. اما همه شکل‌ها توانایی نگهداری متن را ندارند.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
بنابراین، هنگام کار با شکلی که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که آن شکل به وسیلهٔ کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) تبدیل شده است. تنها در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/)، که یک ویژگی تحت [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) است، کار کنید. بخش [Update Text](/slides/fa/python-net/manage-textbox/#update-text) را در این صفحه ببینید.
{{% /alert %}}

## **ایجاد جعبه‌های متن در اسلایدها**

برای ایجاد یک جعبه متن در یک اسلاید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. به اولین اسلاید ارجاع بگیرید.  
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با `ShapeType.RECTANGLE` در موقعیت مورد نظر روی اسلاید اضافه کنید.  
4. متن را در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل تنظیم کنید.  
5. ارائه را به عنوان یک فایل PPTX ذخیره کنید.

مثال زیر پایتون این مراحل را پیاده‌سازی می‌کند:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید در ارائه.
    slide = presentation.slides[0]

    # افزودن AutoShape از نوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # ذخیرهٔ ارائه روی دیسک.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی اینکه آیا یک شکل جعبه متن است یا نه**

Aspose.Slides ویژگی [is_text_box](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/is_text_box/) را در کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) فراهم می‌کند که به شما امکان تعیین اینکه آیا یک شکل جعبه متن است یا نه را می‌دهد.

![جعبه متن و شکل](istextbox.png)

این مثال پایتون نشان می‌دهد که چگونه بررسی کنید آیا یک شکل به عنوان جعبه متن ایجاد شده است یا نه:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

توجه داشته باشید که اگر یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را با استفاده از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) اضافه کنید، ویژگی `is_text_box` شکل مقدار `False` را برمی‌گرداند. اما پس از افزودن متن—چه با متد `add_text_frame` و چه با تنظیم ویژگی `text`—`is_text_box` مقدار `True` را برمی‌گرداند.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box نادرست است
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box صحیح است

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box نادرست است
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box صحیح است

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box نادرست است
    shape3.add_text_frame("")
    # shape3.is_text_box نادرست است

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box نادرست است
    shape4.text_frame.text = ""
    # shape4.is_text_box نادرست است
```

## **افزودن ستون‌ها به جعبه‌های متن**

Aspose.Slides ویژگی‌های [column_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_count/) و [column_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_spacing/) را در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) فراهم می‌کند تا به جعبه‌های متن ستون اضافه کنید. می‌توانید تعداد ستون‌ها را مشخص کرده و فاصله (به نقطه) بین ستون‌ها را تنظیم کنید.

کد پایتون زیر این عملیات را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# دریافت اولین اسلاید در ارائه.
	slide = presentation.slides[0]

	# افزودن AutoShape از نوع RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# افزودن TextFrame به مستطیل.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# دریافت قالب متن TextFrame.
	format = shape.text_frame.text_frame_format

	# تعیین تعداد ستون‌ها در TextFrame.
	format.column_count = 3

	# تعیین فاصله بین ستون‌ها.
	format.column_spacing = 10

	# ذخیرهٔ ارائه.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی متن**

Aspose.Slides به شما امکان می‌دهد متن را در یک جعبه متن واحد یا در کل ارائه به‌روزرسانی کنید.

مثال پایتون زیر نشان می‌دهد چگونه تمام متن‌ها در یک ارائه به‌روزرسانی شوند:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # ذخیرهٔ ارائهٔ اصلاح شده.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن جعبه‌های متن با پیوندهای فراگیر**

می‌توانید یک پیوند را در یک جعبه متن وارد کنید. وقتی جعبه متن کلیک شود، پیوند باز می‌شود.

برای افزودن جعبه متنی که حاوی پیوند باشد، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. به اولین اسلاید ارجاع بگیرید.  
3. یک [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) با `ShapeType.RECTANGLE` در موقعیت مورد نظر روی اسلاید اضافه کنید.  
4. متن را در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) شکل تنظیم کنید.  
5. به یک ارجاع به [HyperlinkManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/) دریافت کنید.  
6. از ویژگی `hyperlink_manager` برای تنظیم یک پیوند کلیک خارجی استفاده کنید.  
7. ارائه را به عنوان یک فایل PPTX ذخیره کنید.

این مثال پایتون نشان می‌دهد چگونه یک جعبه متن با پیوند به یک اسلاید اضافه شود:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation.
with slides.Presentation() as presentation:

    # دریافت اولین اسلاید در ارائه.
    slide = presentation.slides[0]

    # افزودن AutoShape از نوع RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # افزودن متن به چارچوب.
    text_portion.text = "Aspose.Slides"

    # تنظیم پیوند برای متن بخش.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # ذخیرهٔ ارائه به عنوان فایل PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**تفاوت جعبه متن و نگهدارنده متن هنگام کار با اسلایدهای مستر چیست؟**

یک [placeholder](/slides/fa/python-net/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل در یک اسلاید خاص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متن به‌صورت انبوه در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را به AutoShapeهایی که دارای فریم متن هستند محدود کنید و اشیاء توکار (مانند [charts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/)) را با پیمایش جداگانهٔ مجموعه‌هایشان یا صرف‌نظر کردن از آن نوع اشیاء حذف کنید.