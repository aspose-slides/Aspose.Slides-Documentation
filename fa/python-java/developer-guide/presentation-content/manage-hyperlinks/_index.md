---
title: مدیریت هایپرلینک‌های ارائه در Python از طریق Java
linktitle: مدیریت هایپرلینک
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
description: "به راحتی هایپرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java مدیریت کنید—تعامل و جریان کار را در عرض چند دقیقه بهبود دهید."
---
## **معرفی**

یک هایپرلینک، اشاره‌ای به یک شیء یا داده یا مکانی در چیزی است. این‌ها هایپرلینک‌های رایج در ارائه‌های PowerPoint هستند:

* لینک‌ها به وب‌سایت‌ها داخل متن‌ها، اشکال یا رسانه‌ها
* لینک‌ها به اسلایدها

Aspose.Slides برای Python از طریق Java به شما امکان انجام بسیاری از کارها مرتبط با هایپرلینک‌ها در ارائه‌ها را می‌دهد.

{{% alert color="info" title="Note" %}} 
ممکن است بخواهید Aspose ساده را ببینید، [ویرایشگر آنلاین رایگان PowerPoint.](https://products.aspose.app/slides/fa/editor)
{{% /alert %}} 

## **افزودن هایپرلینک‌های URL**

### **افزودن هایپرلینک‌های URL به متن**

این کد Python نحوه افزودن یک هایپرلینک وب‌سایت به متن را نشان می‌دهد:

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
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن هایپرلینک‌های URL به اشکال یا فریم‌ها**

این نمونه کد در Python از طریق Java نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک شکل اضافه کنید:

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
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **افزودن هایپرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن هایپرلینک‌ها به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد.

این نمونه کد نشان می‌دهد چگونه یک هایپرلینک به یک **تصویر** اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # تصویر را به ارائه اضافه می‌کند
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # قاب تصویر را در اسلاید ۱ بر پایه تصویر اضافه شده قبلی ایجاد می‌کند
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این نمونه کد نشان می‌دهد چگونه یک هایپرلینک به یک **فایل صوتی** اضافه کنید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این نمونه کد نشان می‌دهد چگونه یک هایپرلینک به یک **ویدئو** اضافه کنید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 
ممکن است بخواهید ببینید *[مدیریت OLE](/slides/fa/python-java/manage-ole/)*.
{{% /alert %}}

## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که هایپرلینک‌ها به شما امکان اضافه کردن ارجاع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید.

این نمونه کد نشان می‌دهد چگونه یک فهرست مطالب با هایپرلینک‌ها ایجاد کنید:

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

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

با استفاده از ویژگی [Hyperlink.setColorSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setColorSource) در کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/)، می‌توانید رنگ‌های هایپرلینک‌ها را تنظیم کنید و همچنین اطلاعات رنگ را از هایپرلینک‌ها دریافت کنید. این ویژگی اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی بر روی نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این نمونه کد عملیاتی را نشان می‌دهد که در آن‌هایپرلینک‌های با رنگ‌های مختلف به همان اسلاید اضافه شده‌اند:

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
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف هایپرلینک‌ها از ارائه‌ها**

### **حذف هایپرلینک‌ها از متن**

این کد Python نحوه حذف هایپرلینک از یک متن در اسلاید ارائه را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **حذف هایپرلینک‌ها از اشکال یا فریم‌ها**

این کد Python نحوه حذف هایپرلینک از یک شکل در اسلاید ارائه را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **هایپرلینک قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این ویژگی‌ها را تغییر دهید:

- [setTargetFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

این تکه کد نشان می‌دهد چگونه یک هایپرلینک به یک اسلاید اضافه کنید و بعداً توضیح ابزار (tooltip) آن را ویرایش کنید:

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
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # تغییر راهنمای ابزار (tooltip) هایپرلینکی که قبلاً اضافه شده است
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ویژگی‌های پشتیبانی‌شده در HyperlinkQueries**

می‌توانید از [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/) از یک ارائه، اسلاید یا متن که هایپرلینک در آن تعریف شده است، دسترسی پیدا کنید.

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getHyperlinkQueries)

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/) این متدها و ویژگی‌ها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **پرسش‌های رایج**

**چگونه می‌توانم ناوبری داخلی نه تنها به یک اسلاید، بلکه به «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروه‌بندی‌ای از اسلایدها هستند؛ ناوبری به‌صورت فنی به یک اسلاید خاص هدف می‌گیرد. برای «ناوبری به یک بخش» معمولاً به اولین اسلاید آن بخش لینک می‌دهید.

**آیا می‌توانم یک هایپرلینک را به عناصر اسلاید مستر وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و لِی‌اوت از هایپرلینک‌ها پشتیبانی می‌کنند. چنین لینک‌هایی در اسلایدهای فرزند ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

**آیا هایپرلینک‌ها هنگام خروجی گرفتن به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-java/convert-powerpoint-to-html/) بله—به‌طور کلی لینک‌ها حفظ می‌شوند. هنگام خروجی گرفتن به [تصاویر](/slides/fa/python-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/python-java/convert-powerpoint-to-video/)، قابلیت کلیک شدن منتقل نمی‌شود زیرا این فرمت‌ها (فریم‌های رستر/ویدئوی) از هایپرلینک پشتیبانی نمی‌کنند.