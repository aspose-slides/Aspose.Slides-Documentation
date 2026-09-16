---
title: مدیریت هایپرلینک‌های ارائه در Python از طریق Java
linktitle: مدیریت هایپرلینک‌ها
type: docs
weight: 20
url: /fa/python-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن هایپرلینک
- ایجاد هایپرلینک
- قالب‌بندی هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- هایپرلینک متن
- هایپرلینک اسلاید
- هایپرلینک شکل
- هایپرلینک تصویر
- هایپرلینک ویدئو
- هایپرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "هایپرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java اضافه، قالب‌بندی، به‌روزرسانی و حذف کنید، با مثال‌های Python."
---
## **مقدمه**

یک هایپرلینک محتواهای ارائه را به یک وب‌سایت یا مکانی درون ارائه متصل می‌کند. در PowerPoint، هایپرلینک‌ها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از طریق متن، شکل یا چارچوب رسانه‌ای.
* پیمایش به اسلاید دیگر، برای مثال از فهرست مطالب.

Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد این لینک‌ها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، خصوصیاتشان را به‌روزرسانی کنید و حذف نمایید. مثال‌های زیر نشان می‌دهند چگونه با هایپرلینک‌های موجود در عناصر منفرد کار کنید و چگونه به هایپرلینک‌ها در سطح ارائه، اسلاید یا فریم متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
شما می‌توانید ارائه‌ها را با [ویراستگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) نیز ویرایش کنید.
{{% /alert %}} 

## **افزودن هایپرلینک URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا چارچوب رسانه‌ای اختصاص دهید. عنصری که به آن هایپرلینک اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: یک بخش متن فقط متن انتخاب شده را لینک می‌کند، در حالی که یک شکل یا چارچوب، شیء اسلاید را لینک می‌کند.

### **افزودن هایپرلینک URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#setHyperlinkClick) بخش متن پاس دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن هایپرلینک URL به اشکال و چارچوب‌های رسانه‌ای**

برای قابل کلیک کردن یک شکل یا چارچوب، متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setHyperlinkClick) آن را فراخوانی کنید. هایپرلینک به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

رویکرد مشابه برای چارچوب‌های تصویر، صدا و ویدیو نیز صادق است: هایپرلینک را به چارچوب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTooltip) را صدا بزنید.

مثال زیر یک مستطیل را قابل کلیک می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

هایپرلینک‌های داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی بپرند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setColorSource) از کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/) تعیین می‌کند آیا یک هایپرلینک رنگ هایپرلینک ارائه یا قالب‌بندی بخش متن را استفاده می‌کند. برای اعمال رنگ متن دلخواه، مقدار [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو هایپرلینک متنی را به همان اسلاید اضافه می‌کند. اولین آن با پر شدن متن قرمز، و دومین آن رنگ پیش‌فرض هایپرلینک را حفظ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **صدا**

یک هایپرلینک می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که در حال پخش است متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [Hyperlink.setSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setSound) صدای مرتبط با هایپرلینک را تعیین می‌کند.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) کنترل می‌کند آیا فعال‌سازی هایپرلینک صدا را متوقف می‌کند یا نه.

#### **افزودن صدای هایپرلینک**

مثال زیر فایل `sampleaudio.wav` را بارگیری می‌کند و آن را به دکمه‌ای در اسلاید اول مرتبط می‌سازد. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌نویسد. یک شکل دوم در همان اسلاید با کلیک کردن صدا را متوقف می‌کند، بدون انجام عملیات ناوبری.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **استخراج صدای هایپرلینک**

مثال زیر ارائه‌ای را که در بالا ایجاد شد باز می‌کند و صدای هایپرلینک اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getSound) و [getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audio/#getBinaryData) در حافظه می‌خواند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Tooltip و تنظیمات تعامل**

پس از اختصاص یک هایپرلینک به متن یا شکل می‌توانید متدهای زیر را صدا بزنید:

- [setTooltip](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTooltip) متنی را تنظیم می‌کند که بیننده می‌تواند به عنوان راهنمای لینک نمایش دهد.
- [setTargetFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTargetFrame) فریم هدف را درون یک frameset HTML والد مشخص می‌کند، اگر کاربرد داشته باشد.
- [setHistory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHistory) کنترل می‌کند آیا فعال‌سازی لینک مقصد را به فهرست هایپرلینک‌های مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHighlightClick) تعیین می‌کند آیا هایپرلینک هنگام کلیک برجسته شود یا خیر.

## **حذف هایپرلینک‌ها از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) برای جمع‌آوری مخازن هایپرلینک، از جمله لینک‌های بخش‌های متنی، قبل از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل mouse‑over نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده یک‌بار حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت موجودی کامل هایپرلینک‌ها**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) مخازن هایپرلینک را برمی‌گرداند، مانند اشیاء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) و [PortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/)، نه یک لیست ساده از رشته‌های URL. هم متدهای [getHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getHyperlinkMouseOver) را برای هر مخزن بررسی کنید. آن‌ها مستقل هستند: یک مخزن می‌تواند هر دو عمل را در بر داشته باشد، بنابراین یک گزارش کامل می‌تواند حداکثر دو ردیف برای هر مخزن داشته باشد.

فقط اسکن کردن هایپرلینک‌های سطح شکل می‌تواند لینک‌های موجود در بخش‌های متنی را از دست بدهد. به جای آن حوزه مناسب را پرس‌وجو کنید و مخازن بازگردانده‌شده را نگه دارید تا بعداً بتوانید اعمال آن‌ها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجو در حوزه‌های Presentation, Slide و Text‑Frame**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/) از طریق [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getHyperlinkQueries) و [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getHyperlinkQueries) در دسترس است. هر حوزه همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) مخازنی را با عمل کلیک بر می‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) مخازنی را با عمل mouse‑over بر می‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) مخازنی را که هر کدام یا هر دو عمل را دارند، بر می‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک mouse‑over فایل، ناوبری داخلی اسلاید، یک لینک mouse‑over متنی و یک عمل ماکرو است. هیچ‌یک از این اعمال اجرا نمی‌شوند. همان سه پرس‌وجو در هر حوزه کار می‌کند؛ شمارش‌ها مخازن را نه تعداد اعمال نشان می‌دهند. حوزه text‑frame لینک‌های خود شکل دربرگیرنده را مستثنی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه مخزن کلیک، دو مخزن mouse‑over و سه مخزن با هر یک از اعمال را گزارش می‌کنند. پرس‌وجوی text‑frame در هر دسته یک مخزن گزارش می‌دهد.

### **دسته‌بندی اعمال و مقصدها**

برای تفسیر یک عمل قبل از تفسیر مقصد، از متد [Hyperlink.getActionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getActionType) استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب شامل موارد زیر می‌شوند:

| مقادیر | معنی برای بازرسی |
| --- | --- |
| `Hyperlink` | هایپرلینک خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌ساخته اسلایدشو، در زمینهٔ اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | اجرای برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائهٔ دیگر؛ از URLهای وب جدا بررسی کنید. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری یا عمل ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از [getExternalUrl](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getExternalUrl) و مقاصد داخلی خاص را از [getTargetSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getTargetSlide) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنا نیست که مخزن هیچ عملی ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) را در صورتی که متفاوت از URL نرمال‌شده باشد حفظ کنید و tooltipی که توسط [getTooltip](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#getTooltip) برگردانده می‌شود را اگر موجود است، اضافه کنید.

### **گزارش، پاک‌سازی و اعتبارسنجی هایپرلینک‌ها**

مثال Python زیر یک ارائه موجود (فایلی که در بالا ایجاد شد) می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را مجدداً بررسی کند. قبل از تغییر مخازن را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوباره یک مخزن، از برابری ارجاعی استفاده می‌کند. پرس‌وجوهای ارائه اسلایدهای معمولی را شامل می‌شود؛ برای فهرست‌گیری در سطح بسته، به‌طور صریح مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و برگه‌ها را نیز پرس‌وجو می‌کند.

گزارش، اندیس اسلاید (یک‌پایه) و [getSlideId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideId) را در صورت موجود بودن ذخیره می‌کند. متد [getSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getSlide) اسلاید مالک را برای مخازن پشتیبانی‌شده فراهم می‌آورد. مسترها، لایه‌ها و یادداشت‌ها اندیس اسلاید عادی ندارند و با دامنهٔ خود شناخته می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع مخزن نام نوع زمان اجرا خود را حفظ می‌کنند. هر مخزن یک شناسه محلی در گزارش دریافت می‌کند تا دو عمل آن بتوانند همبستگی پیدا کنند. نوع عمل به صورت عدد صحیح ثابت تعریف‌شده توسط شمارشگر Java ذخیره می‌شود.

این سیاست محدود کننده به‌صورت صریح فقط URLهای HTTPS مطلق و اهداف اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اقدامات فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. تنها HTTPS تضمین اعتمادی نیست: لیست سفید میزبان‌ها و بررسی‌های دیگر را متناسب با کاربرد خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال بازرسی می‌کند.

برای اصلاح، مخزن از [getHyperlinkManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getHyperlinkManager) متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه لندینگ ثابت HTTPS جایگزین می‌شوند؛ دیگر کلیک‌ها و اعمال mouse‑over ممنوع به‌صورت مستقل حذف می‌شوند. مقدار `replace_external_clicks` را به `False` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. پیش از استقرار، صفحه جایگزین متعلق به برنامه خود را انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بازبینی PDF محافظه‌کار استفاده می‌کند: اعمال mouse‑over و هر چیزی جز لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالا پشتیبانی‌نشده پرچم‌گذاری می‌کند. این یک اشارهٔ بازبینی است، نه آزمون قابلیت یا ضمانت این‌که لینک‌های بدون پرچم در خروجی باقی می‌مانند. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است بسته به عمل، گزینه‌های خروجی و مرورگر، هایپرلینک را حفظ کنند. تصاویر raster و ویدیو نمی‌توانند هایپرلینک تعاملی را حفظ کنند؛ برای این خروجی‌ها هر عمل را پرچم‌گذاری کنید.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

با ورودی ایجادشده در بالا، گزارش شامل پنج ردیف عمل می‌شود. لینک mouse‑over فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. اعتبارسنجی صفر عمل ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع، شاخهٔ جایگزینی را نیز اجرا می‌کند. مخزنی که یک کلیک مجاز و یک mouse‑over ممنوع دارد، عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [removeAllHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) است که هر دو نوع فعال‌سازی را در دامنه انتخاب‌شده بدون در نظر گرفتن سیاست حذف می‌کند. اعتبارسنجی در اینجا فقط اعمال هایپرلینک را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیاء OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل PDF یا HTML خروجی را نیز اعتبارسنجی نمی‌کند.

## **سؤالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک بدهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک هایپرلینک داخلی به یک اسلاید تک هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم هایپرلینک را به عناصر مستر اسلاید وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لایه‌ها از هایپرلینک پشتیبانی می‌کنند. لینک‌های موجود بر این عناصر در حین نمایش اسلاید بر اسلایدهایی که از مستر یا لایه مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا هایپرلینک‌ها هنگام خروجی به PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است هایپرلینک‌ها را حفظ کنند؛ تصاویر raster و ویدئو نمی‌توانند. برای جزئیات بیشتر به ملاحظات خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.