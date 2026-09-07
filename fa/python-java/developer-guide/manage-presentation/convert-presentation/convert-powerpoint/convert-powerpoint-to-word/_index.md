---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در پایتون از طریق جاوا
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/python-java/convert-powerpoint-to-word/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به Word
- ارائه به Word
- PPT به Word
- PPTX به Word
- ODP به Word
- PowerPoint به DOCX
- PPT به DOCX
- PPTX به DOCX
- PowerPoint به DOC
- ذخیره PPT به صورت DOCX
- ذخیره PPTX به صورت DOCX
- صادر کردن PPT به DOCX
- صادر کردن PPTX به DOCX
- پایتون
- جاوا
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به Word در پایتون از طریق جاوا با Aspose.Slides و Aspose.Words، ترکیب تصاویر اسلاید با متن قابل ویرایش."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان ارائه‌های PowerPoint و OpenDocument را به اسناد Word تبدیل کرد با استفاده از Aspose.Slides برای Python از طریق Java همراه با Aspose.Words برای Java. Aspose.Slides هر اسلاید را رندر می‌کند و متن آن را می‌خواند، در حالی که Aspose.Words سند Word را از طریق JPype ایجاد می‌نماید. نیاز به Microsoft Office نیست.

سند حاصل شامل یک تصویر اسلاید به‌علاوه متن قابل ویرایش استخراج‌شده از اشکال خودکار سطح‑بالایی آن اسلاید است. تصویر ظاهر بصری اسلاید را حفظ می‌کند؛ شکل‌ها، نمودارها و جدول‌های جداگانه به اشیای قابل ویرایش Word تبدیل نمی‌شوند. متن استخراج شده قالب‌بندی یا موقعیت متن اصلی را نگه نمی‌دارد.

## **تبدیل PowerPoint به Word**

1. [Aspose.Slides for Python via Java](/slides/fa/python-java/installation/) و یک محیط اجرای Java سازگار را نصب کنید.
2. [Aspose.Words for Java](https://releases.aspose.com/words/java/) را دانلود کنید. فایل JAR اصلی آن را در یک پوشه `lib` در کنار اسکریپت خود قرار داده و نام آن را به `aspose-words.jar` تغییر دهید، یا مسیر را در مثال برای مطابقت با فایل دانلودی خود تنظیم کنید.
3. پرزنتیشن ورودی، `sample.pptx` را در پوشهٔ کاری قرار دهید. مسیر `lib/aspose-words.jar` نیز نسبت به همان پوشه است.
4. کد Python زیر را اجرا کنید تا `output.docx` ایجاد شود.

این مثال منبع را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری می‌کند و اسلایدها را با [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) رندر می‌نماید. از [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) در Aspose.Words برای درج تصاویر و متن در سند Word استفاده می‌کند.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # تصویر اسلاید را بر عرض ناحیه متن تنظیم کنید و نسبت عرض‑به‑ارتفاع آن را حفظ کنید.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # متن ساده را از اشکال خودکار سطح بالایی اضافه کنید، شامل جعبه‌های متن.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

هر اسلاید در صفحهٔ جدیدی آغاز می‌شود. متن استخراج‌شدهٔ طولانی یا تصاویر اسلایدی که به‌طور غیرعادی بلند هستند ممکن است به صفحات اضافه نیاز داشته باشند. کد فقط بین اسلایدها شکست صفحه اضافه می‌کند و ارائه و تصاویر رندر شده را در بلوک‌های `finally` آزاد می‌سازد. JVM برای تبدیل‌های بعدی در همان فرآیند Python در دسترس می‌ماند.

## **سؤالات متداول**

**کدام کتابخانه‌ها مورد نیاز هستند؟**

از Aspose.Slides برای Python از طریق Java، JPype، یک محیط اجرای Java سازگار و Aspose.Words برای Java استفاده کنید. هر دو کتابخانه Aspose در همان JVM اجرا می‌شوند. Aspose.Slides ارائه را مدیریت می‌کند؛ Aspose.Words سند Word را می‌نویسد.

**آیا می‌توانم فایل‌های PPT و ODP را علاوه بر PPTX تبدیل کنم؟**

بله. `sample.pptx` را با یک فایل PPT یا ODP جایگزین کنید. برای فرمت‌های ورودی ارائه به [Supported File Formats](/slides/fa/python-java/supported-file-formats/) مراجعه کنید.

**آیا تمام محتوای اسلاید در Word قابل ویرایش است؟**

خیر. هر اسلاید به‌صورت تصویر ثابت درج می‌شود و متن سادهٔ استخراج‌شده از اشکال خودکار سطح‑بالایی زیر آن اضافه می‌شود. متن داخل گروه‌ها، جدول‌ها، SmartArt و نمودارها، همچنین یادداشت‌های گوینده، توسط این مثال استخراج نمی‌شود. انیمیشن‌ها و انتقال‌ها در سند Word بازسازی نمی‌شوند.

**آیا می‌توانم به‌جای DOCX به‌صورت DOC ذخیره کنم؟**

بله. نام فایل خروجی را به `output.doc` تغییر دهید. Aspose.Words قالب خروجی را بر اساس پسوند نام فایل هنگام استفاده از این روش ذخیره‌سازی انتخاب می‌کند.