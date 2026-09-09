---
title: مدیریت متن فوقانی و زیرنویس در ارائه‌ها با استفاده از Python از طریق Java
linktitle: فوقانی و زیرنویس
type: docs
weight: 80
url: /fa/python-java/superscript-and-subscript/
keywords:
- فوقانی
- زیرنویس
- افزودن فوقانی
- افزودن زیرنویس
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "در Aspose.Slides برای Python از طریق Java بر فراوانی فوقانی و زیرنویس مسلط شوید و ارائه‌های خود را با قالب‌بندی حرفه‌ای متن برای حداکثر تاثیر ارتقا دهید."
---
## **نمای کلی**

Aspose.Slides ویژگی‌هایی برای ادغام متن فوقانی و زیرنویس در ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) شما فراهم می‌کند. چه بخواهید فرمول‌های شیمیایی، معادلات ریاضی را برجسته کنید یا محتوا را با پاورقی‌ها حاشیه‌نویسی کنید، این گزینه‌های قالب‌بندی تخصصی به حفظ وضوح و دقت کمک می‌کنند. در این مقاله، نحوه اعمال بدون درزی سبک‌های فوقانی و زیرنویس را یاد می‌گیرید و اطمینان حاصل می‌کنید که در هر اسلاید نتایج حرفه‌ای به‌دست می‌آید.

## **مدیریت متن فوقانی و زیرنویس**

می‌توانید متن فوقانی و زیرنویس را به هر بخشی از یک پاراگراف اضافه کنید. برای اعمال این قالب‌بندی در یک چارچوب متن Aspose.Slides، از متد [setEscapement](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#setEscapement) کلاس [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) استفاده کنید.

مقدار escapement از -100٪ (زیرنویس) تا 100٪ (فوقانی) متغیر است. برای مثال:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- اسلاید را با استفاده از ایندکس آن دریافت کنید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) از نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapetype/#Rectangle) به اسلاید اضافه کنید.
- به [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) دسترسی پیدا کنید.
- پاراگراف‌های موجود را پاک کنید.
- یک پاراگراف برای نگه داشتن متن فوقانی ایجاد کنید و آن را به [مجموعه پاراگراف‌ها](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParagraphs) چارچوب متن اضافه کنید.
- یک Portion ایجاد کنید.
- از [setEscapement](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#setEscapement) استفاده کنید تا مقدار بین 0 تا 100 را برای فوقانی تنظیم کنید (0 به معنای عدم وجود فوقانی است).
- متن [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) را تنظیم کنید و آن را به مجموعه بخش‌های پاراگراف اضافه کنید.
- یک پاراگراف برای نگه داشتن متن زیرنویس ایجاد کنید و آن را به [مجموعه پاراگراف‌ها](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParagraphs) چارچوب متن اضافه کنید.
- یک Portion ایجاد کنید.
- از [setEscapement](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#setEscapement) استفاده کنید تا مقدار بین -100 تا 0 را برای زیرنویس تنظیم کنید (0 به معنای عدم وجود زیرنویس است).
- متن [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) را تنظیم کنید و آن را به مجموعه بخش‌های پاراگراف اضافه کنید.
- ارائه را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر این مراحل را پیاده‌سازی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpure.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# یک ارائه ایجاد کنید.
presentation = Presentation()
try:
    # اسلاید را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک جعبه متن ایجاد کنید.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # یک پاراگراف برای متن فوقانی ایجاد کنید.
    superscript_paragraph = Paragraph()

    # یک بخش با متن عادی ایجاد کنید.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # یک بخش با متن فوقانی ایجاد کنید.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # یک پاراگراف برای متن زیرنویس ایجاد کنید.
    subscript_paragraph = Paragraph()

    # یک بخش با متن عادی ایجاد کنید.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # یک بخش با متن زیرنویس ایجاد کنید.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # پاراگراف‌ها را به جعبه متن اضافه کنید.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا فوقانی و زیرنویس هنگام خروجی گرفتن به PDF یا فرمت‌های دیگر حفظ می‌شوند؟**

بله، Aspose.Slides به‌درستی قالب‌بندی فوقانی و زیرنویس را هنگام خروجی گرفتن ارائه‌ها به PDF، PPT/PPTX، تصاویر و سایر فرمت‌های پشتیبانی‌شده حفظ می‌کند. این قالب‌بندی تخصصی در تمام فایل‌های خروجی دست نخورده باقی می‌ماند.

**آیا می‌توان فوقانی و زیرنویس را با سایر سبک‌های قالب‌بندی مانند بولد یا ایتالیک ترکیب کرد؟**

بله، Aspose.Slides به شما امکان می‌دهد تا انواع مختلف سبک‌های متنی را در یک Portion ترکیب کنید. می‌توانید بولد، ایتالیک، زیرخط و به‌صورت همزمان فوقانی یا زیرنویس را با تنظیم ویژگی‌های مربوطه در [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) فعال کنید.

**آیا قالب‌بندی فوقانی و زیرنویس برای متن داخل جدول‌ها، نمودارها یا SmartArt کار می‌کند؟**

بله، Aspose.Slides قالب‌بندی را در اکثر اشیاء، از جمله جدول‌ها و عناصر نمودارها، پشتیبانی می‌کند. هنگام کار با SmartArt، باید به عناصر مناسب (مانند [SmartArtNode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/)) و کانتینرهای متنی آن‌ها دسترسی پیدا کنید و سپس ویژگی‌های [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/) را به‌صورت مشابه تنظیم کنید.