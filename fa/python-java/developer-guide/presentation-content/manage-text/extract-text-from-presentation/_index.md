---
title: استخراج پیشرفته متن از ارائه‌ها در پایتون از طریق جاوا
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/python-java/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- بازیابی متن
- بازیابی متن از اسلاید
- بازیابی متن از ارائه
- بازیابی متن از پاورپوینت
- بازیابی متن از OpenDocument
- بازیابی متن از PPT
- بازیابی متن از PPTX
- بازیابی متن از ODP
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "به‌سرعت متن را از ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق جاوا استخراج کنید. راهنمای ساده گام‌به‌گام ما را دنبال کنید تا زمان صرفه‌جویی کنید."
---
## **مروری کلی**

استخراج متن از ارائه‌ها کاری رایج اما ضروری برای توسعه‌دهندگانی است که با محتوای اسلایدها کار می‌کنند. چه با فایل‌های Microsoft PowerPoint با فرمت PPT یا PPTX سر و کار داشته باشید و چه ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تحلیل، خودکارسازی، ایندکس‌گذاری یا مهاجرت محتوا بحرانی باشد.

این مقاله راهنمای جامع‌تری برای استخراج مؤثر متن از انواع فرمت‌های ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides برای Python via Java را ارائه می‌دهد. شما یاد می‌گیرید چگونه به‌صورت سیستماتیک بر روی عناصر ارائه پیمایش کنید تا متن مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides برای Python via Java کلاس [SlideUtil](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/) را فراهم می‌کند. این کلاس چندین متد استاتیک overload شده برای استخراج تمام متن از یک ارائه یا اسلاید ارائه می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#getAllTextBoxes) استفاده کنید. این متد شی‌ای از نوع [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) را به‌عنوان پارامتر می‌پذیرد. هنگام اجرا، متد تمام اسلاید را برای یافتن متن جستجو می‌کند و آرایه‌ای از اشیای نوع [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) را بر می‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از متد استاتیک [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/#getAllTextFrames) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideutil/) در دسترس است، استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. اول، شی‌ای از نوع [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) که نمایانگر یک ارائه PowerPoint یا OpenDocument است و از آن متن استخراج می‌شود.
2. دوم، مقدار `bool` که نشان می‌دهد آیا اسلایدهای مستر در هنگام اسکن متن از ارائه گنجانده شوند یا نه.

این متد آرایه‌ای از اشیای نوع [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) را بر می‌گرداند که شامل اطلاعات قالب‌بندی متن نیز می‌شود. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، از جمله اسلایدهای مستر، اسکن می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **استخراج متنی دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/) نیز متدهایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# متن را از یک فایل استخراج کنید.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# متن را از یک جریان استخراج کنید.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# متن را از یک جریان با استفاده از گزینه‌های بارگذاری استخراج کنید.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتایج استخراج متن را مشخص می‌کند و می‌تواند به مقادیر زیر تنظیم شود:

- [Unarranged](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – متن خام بدون توجه به موقعیت آن در اسلاید.
- [Arranged](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – متن به همان ترتیب که در اسلاید ظاهر می‌شود، سازماندهی می‌شود.

حالت Unarranged وقتی سرعت حیاتی است قابل استفاده است؛ این حالت سریع‌تر از حالت Arranged می‌باشد.

[PresentationText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationtext/) متن خام استخراج‌شده از ارائه را نشان می‌دهد. متد [getSlidesText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationtext/#getSlidesText) این کلاس آرایه‌ای از اشیای نوع `SlideText` را بر می‌گرداند. هر شیء متن اسلاید مربوطه را نمایندگی می‌کند. شیء نوع `SlideText` دارای متدهای زیر است:

- `getText` – متن داخل شکل‌های اسلاید.
- `getMasterText` – متن داخل شکل‌های اسلاید مستر مرتبط با این اسلاید.
- `getLayoutText` – متن داخل شکل‌های اسلاید لایه‌بندی مرتبط با این اسلاید.
- `getNotesText` – متن داخل شکل‌های اسلاید یادداشت‌ها مرتبط با این اسلاید.
- `getCommentsText` – متن داخل نظرات مرتبط با این اسلاید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **پرسش‌های متداول**

**سرعت پردازش Aspose.Slides برای ارائه‌های بزرگ هنگام استخراج متن چقدر است؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/python-java/open-presentation/) را پردازش کند، که آن را برای سناریوهای پردازش بلادرنگ یا انبوه مناسب می‌سازد.

**آیا Aspose.Slides می‌تواند متن را از جدول‌ها و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جدول‌ها و اشیای مرتبط با نمودارها استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای رایج ارائه‌ دسترسی و آنالیز داشته باشید.

**آیا برای استخراج متن از ارائه‌ها نیاز به مجوز خاص Aspose.Slides دارم؟**

می‌توانید با نسخه آزمایشی رایگان Aspose.Slides متن را استخراج کنید، هرچند این نسخه دارای [محدودیت‌های مشخص](/slides/fa/python-java/licensing/) است، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگ‌تر، خرید یک مجوز کامل توصیه می‌شود.