---
title: مدیریت پیوندهای ارائه در Python via Java
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/python-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java اضافه، قالب‌بندی، به‌روزرسانی و حذف کنید، با استفاده از مثال‌های Python."
---
## **مقدمه**

یک پیوند (hyperlink) محتویات ارائه را به یک وب‌سایت یا یک مکان در داخل ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک قاب رسانه‌ای.
* رفتن به اسلاید دیگری، برای مثال، از فهرست مطالب.

Aspose.Slides for Python via Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدا آنها را کنترل کنید، ویژگی‌هایشان را به‌روز کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با پیوندها روی عناصر جداگانه کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا قاب متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
شما همچنین می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که به آن پیوند را اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن به متن انتخاب‌شده پیوند می‌دهد، در حالی که یک شکل یا قاب به شیء اسلاید پیوند می‌دهد.

برای ارائه‌هایی که شامل پیوندهای نسبی هستند، به [مدیریت پایه پیوند](/slides/fa/python-java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایهٔ سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای پیوند متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) بخش متن پاس بدهید، همان‌طور که در زیر نشان داده شده است. فقط آن قسمت از متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

متد [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) را روی مستطیل صدا کنید تا تمام ناحیه آن قابل کلیک شود. از [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) استفاده کنید تا هنگام رفتن نشانگر ماوس به مستطیل، راهنمایی درباره مقصد به خوانندگان نشان داده شود. هر دو متد برای قاب‌های تصویر، صدا و ویدئو نیز اعمال می‌شوند.

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

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی بروید. مثال زیر از [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) برای پیوند متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندها**

می‌توانید رنگ متن پیوندشده را تغییر دهید، هنگام فعال‌سازی پیوند توسط خواننده صدا را پخش یا متوقف کنید، و نکته راهنمایی (tooltip) را که هنگام hover ظاهر می‌شود تنظیم کنید.

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) از کلاس [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) تعیین می‌کند که آیا پیوند از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) باعث می‌شود لینک اول از پر کردن قرمز بخش متن استفاده کند. لینک دوم رنگ پیوند ارائه را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که در حال پخش است را متوقف کند. برای پیکربندی این رفتارها از متدهای زیر استفاده کنید:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) صدا مرتبط با پیوند را مشخص می‌کند.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) کنترل می‌کند که آیا فعال‌سازی پیوند صدا قبلی را متوقف می‌کند یا نه.

#### **افزودن صدای پیوند**

دکمه در اسلاید اول از [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) استفاده می‌کند تا هنگام کلیک خواننده برای پیشروی، صدا از `sampleaudio.wav` پخش شود. در اسلاید دوم، دکمهٔ جداگانه‌ای از [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) استفاده می‌کند تا پخش را متوقف کند و خواننده را در همان اسلاید نگه دارد.

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

#### **استخراج صدای پیوند**

مثال زیر ارائهٔ ساخته‌شده در بالا را باز می‌کند و صداهای پیوند اولین شکل را از طریق [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) و [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) به حافظه می‌خواند.

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

### **تنظیمات نکته راهنمایی و تعامل**

پس از اختصاص یک پیوند به متن یا یک شکل، می‌توانید متدهای زیر از کلاس [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) متنی را تنظیم می‌کند که بیننده می‌تواند به عنوان راهنمایی برای پیوند نمایش دهد.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) قاب هدف را درون یک فریم‌ست HTML والد، در صورت امکان، مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) کنترل می‌کند که آیا فعال‌سازی پیوند مقصد آن را به فهرست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) کنترل می‌کند که آیا پیوند هنگام کلیک برجسته شود یا نه.

## **حذف پیوندها از ارائه‌ها**

از [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) برای جمع‌آوری محفظه‌های پیوند، از جمله پیوندهای بخش متن، قبل از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) را فراخوانی کنید؛ حذف عمل کلیک، معادل mouse‑over آن را حذف نمی‌کند.

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

برای حذف بدون قید، [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) هر دو نوع فعال‌سازی را در محدودهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش ارث‌ها، طرح‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی پیوندها قبل از جایگزینی متن SmartArt**

هنگامی که یک پاراگراف را در یک گرهٔ SmartArt موجود جایگزین می‌کنید، پاک‌سازی بخش‌های متن آن می‌تواند پیوند قدیمی را فعال بگذارد. پاراگراف را از طریق [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame) دریافت کنید. پیش از پاک کردن بخش‌ها، بر روی فریم متن شکل گره‌ای که پاراگراف را نمایش می‌دهد، [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) را فراخوانی کنید، سپس [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) را بر روی شیء بازگردانده‌شده صدا بزنید. این کار هر پیوندی را در آن فریم حذف می‌کند، از جمله پیوندهای موجود در سایر پاراگراف‌ها.

این مثال فرض می‌کند که سومین شکل در اسلاید اول فایل `SmartArtHyperlink.pptx` یک گرافیک SmartArt است. این مثال اولین پاراگراف گرهٔ چهارم را جایگزین می‌کند. در این ارائه، اولین شکل گره آن پاراگراف را نمایش می‌دهد.

پس از افزودن هر دو بخش، مثال قالب‌بندی مؤثر آنها را با [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) می‌خواند. در آن قالب‌بندی، `getHyperlinkClick` پیوند جدید را برای بخش اول و `None` را برای بخش دوم برمی‌گرداند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # هیچ
finally:
    presentation.dispose()
```

## **ایجاد یک فهرست کامل پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) محفظه‌های پیوند را باز می‌گرداند، مانند اشیای [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) و [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)، نه یک لیست ساده از رشته‌های URL. هر دو متد [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) را روی هر محفظه بررسی کنید. این‌ها مستقل هستند: همان محفظه می‌تواند هر دو عمل را نمایش دهد، بنابراین یک گزارش کامل به حداکثر دو سطر برای هر محفظه نیاز دارد.

### **پرس و جو در محدوده‌های ارائه، اسلاید و قاب‑متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) از طریق متدهای [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) و [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) در دسترس است. هر محدوده از همان پرس و جوها پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) محفظه‌هایی را که دارای عمل کلیک هستند برمی‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) محفظه‌هایی را که دارای عمل mouse‑over هستند برمی‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) محفظه‌هایی را که هر یک یا هر دو عمل را دارند برمی‌گرداند.

این مثال عمل کلیک و mouse‑over را به یک شکل و متن آن اختصاص می‌دهد و یک عمل ماکرو را به دکمه‌ای جداگانه می‌دهد. تعداد محفظه‌های برگردانده‌شده توسط [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) را با شمارش‌ها برای هر نوع فعال‌سازی مقایسه می‌کند. یک پرس و جو بر روی قاب‑متن فقط پیوندهای موجود در متن را می‌شمارد. اعمال خود شکل دربرگیرنده در پرس و جوهای اسلاید و ارائه ظاهر می‌شود.

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

برای این مثال، پرس و جوهای ارائه و اسلاید به ترتیب سه محفظهٔ کلیک، دو محفظهٔ mouse‑over و سه محفظه با هر یک از اعمال را گزارش می‌کنند. پرس و جوی قاب‑متن یک محفظه در هر دسته را گزارش می‌دهد.

### **دسته‌بندی اعمال و مقصدها**

از [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| مقدارها | معنی برای بررسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری پیش‌فرض اسلایدشو، در زمینهٔ اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش فعلی یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائهٔ دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل ناشناخته‌ای که نیاز به بررسی دارد. |

مقصدهای خارجی را از طریق [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) و مقصدهای داخلی خاص را از طریق [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide) بخوانید. اعمال داخلی و دستورات پیش‌فرض ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنی نیست که محفظه بی‌عمل است. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) را هنگامی که با URL نرمال‌شده متفاوت است، حفظ کنید، و نکته راهنمایی بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) را در صورت موجود بودن گنجانید.

### **گزارش، پاک‌سازی و تأیید پیوندها**

این مثال ارائهٔ مثال قبلی را باز می‌کند و به ازای هر عمل یک رکورد JSON می‌نویسد. از [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) برای جمع‌آوری محفظه‌ها در اسلایدهای معمولی، مسترها، طرح‌ها و یادداشت‌ها استفاده می‌کند، از جمله مسترهای یادداشت و جزوات در صورت حضور. برای شمارش هر محفظه یک بار از برابری ارجاع استفاده می‌کند، سیاست توضیح داده‌شده در زیر را اعمال می‌کند و ارائهٔ ذخیره‌شده را دوباره باز می‌کند تا هر دو عمل کلیک و mouse‑over را بررسی کند.

گزارش، ایندکس اسلایدی مبتنی بر یک (یک‌پایه) و [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) را در صورت موجود بودن ثبت می‌کند. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) اسلاید مالک را برای محفظه‌های پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌ها و یادداشت‌ها ایندکس اسلاید معمولی ندارند و با محدودهٔ خود شناسایی می‌شوند. محفظه‌های شکل و محفظه‌های قالب‌بندی بخش متن به‌طور جداگانه برچسب‌گذاری می‌شوند؛ انواع دیگر محفظه نام نوع زمان اجرا خود را حفظ می‌کنند. به هر محفظه یک شناسهٔ محلی گزارش اختصاص داده می‌شود تا دو عمل آن همبستگی داشته باشند. گزارش انواع عمل‌ها را به‌عنوان ثابت‌های عددی تعریف‌شده توسط شمارشگر Java ذخیره می‌کند.

این سیاست کاربردی به‌صورت عمدی محدود است و فقط URLهای HTTPS مطلق و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌های URL را رد می‌کند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. فقط داشتن HTTPS کافی نیست تا اعتماد ایجاد کند: لیست‌های مجاز میزبان و سایر بررسی‌ها را برای برنامهٔ خود اضافه کنید. هم URLهای خارجی اصلی و هم نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرا کردن اعمال حسابرسی می‌کند.

برای اصلاح، مدیر پیوندهای محفظه یعنی [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) از [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) پشتیبانی می‌کند. در اینجا، کلیک‌های خارجی ممنوع با یک صفحهٔ لندینگ HTTPS ثابت جایگزین می‌شوند؛ کلیک‌ها و mouse‑overهای ممنوع دیگر به‌صورت مستقل حذف می‌شوند. مقدار `replace_external_clicks` را به `False` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. قبل از استقرار، یک صفحهٔ جایگزین متعلق به برنامه انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بازبینی PDF محتاطانه استفاده می‌کند: اعمال mouse‑over و هر چیزی غیر از یک لینک خارجی یا پرش اسلاید خاص را به‌عنوان ممکن است پشتیبانی‌نشده علامت‌گذاری می‌کند. این یک نکتهٔ بازبینی است، نه تست قابلیت یا ضمانتی که لینک‌های بدون علامت‌گذاری در صادرات حفظ خواهند شد. صادرات‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-java/convert-powerpoint-to-html/) ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های صادرات و نمایشگر. [images](/slides/fa/python-java/convert-powerpoint-to-png/) و [video](/slides/fa/python-java/convert-powerpoint-to-video/) رستری نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها، هر عمل را علامت‌گذاری کنید.

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

با ورودی ایجاد‌شده در بالا، گزارش شامل پنج ردیف عمل است. لینک mouse‑over فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی حاوی یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را اجرا می‌کند. یک محفظه با کلیک مجاز و mouse‑over ممنوع، عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) است که هر دو نوع فعال‌سازی را در سراسر محدودهٔ انتخاب‌شده بدون در نظر گرفتن سیاست حذف می‌کند. تأیید در اینجا فقط اعمال پیوندها را بررسی می‌کند؛ پروژه‌های VBA تعبیه‌شده، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و یک فایل PDF یا HTML صادرات‌شده را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اسلاید اول آن پیوند دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید جداگانه هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اسلاید اول آن بخش پیوند دهید.

**آیا می‌توانم پیوندی را به عناصر اسلاید مستر وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و طرح از پیوند پشتیبانی می‌کنند. پیوندهای این عناصر در حین نمایش اسلایدها بر روی اسلایدهایی که از مستر یا طرح مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

صادرات‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستری و ویدئو نمی‌توانند. به ملاحظات صادرات در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.