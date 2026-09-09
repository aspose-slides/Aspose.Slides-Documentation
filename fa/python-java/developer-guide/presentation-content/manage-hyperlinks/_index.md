---
title: مدیریت پیوندهای ارائه در Python از طریق Java
linktitle: مدیریت پیوند
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
- پیوند ویدیو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "به‌راحتی پیوندها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java مدیریت کنید—در عرض چند دقیقه تعامل و جریان کاری را بهبود ببخشید."
---
## **مقدمه**

یک پیوند یک ارجاع به یک شیء، داده یا مکان است. پیوندهای رایج در ارائه‌های PowerPoint شامل موارد زیر هستند:

* پیوندها به وب‌سایت‌ها در متن، اشکال یا رسانه‌ها
* پیوندها به اسلایدها

Aspose.Slides برای Python از طریق Java به شما امکان انجام بسیاری از کارها مرتبط با پیوندها در ارائه‌ها را می‌دهد. 

{{% alert color="info" title="نکته" %}} 

ممکن است بخواهید ویرایشگر رایگان آنلاین پاورپوینت Aspose را بررسی کنید. [ویرایشگر رایگان آنلاین پاورپوینت.](https://products.aspose.app/slides/fa/editor)

{{% /alert %}} 

## **افزودن پیوندهای URL**

### **افزودن پیوندهای URL به متن**

این کد Python نشان می‌دهد چگونه یک پیوند وب‌سایت به متن اضافه کنید:

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

### **افزودن پیوندهای URL به اشکال یا چارچوب‌ها**

این مثال کد در Python از طریق Java نشان می‌دهد چگونه یک پیوند وب‌سایت به یک شکل اضافه کنید:

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

### **افزودن پیوندهای URL به رسانه‌ها**

Aspose.Slides به شما امکان می‌دهد پیوندها را به تصاویر، فایل‌های صوتی و ویدئویی اضافه کنید. 

این مثال کد نشان می‌دهد چگونه به یک **تصویر** پیوند اضافه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # افزودن تصویر به ارائه
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # ایجاد قاب تصویر در اسلاید 1 بر پایه تصویر قبلا اضافه شده
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این مثال کد نشان می‌دهد چگونه به یک **فایل صوتی** پیوند اضافه کنید:

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

این مثال کد نشان می‌دهد چگونه به یک **ویدئو** پیوند اضافه کنید:

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

{{% alert color="success" title="نکته" %}} 

ممکن است بخواهید *[مدیریت OLE](/slides/fa/python-java/manage-ole/)* را ببینید.

{{% /alert %}}

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

از آنجا که پیوندها به شما اجازه می‌دهند ارجاعاتی به اشیاء یا مکان‌ها اضافه کنید، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید. 

این مثال کد نشان می‌دهد چگونه فهرست مطالبی با پیوندها ایجاد کنید:

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

## **قالب‌بندی پیوندها**

### **رنگ**

با ویژگی [Hyperlink.setColorSource](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setColorSource) در کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/) می‌توانید رنگ پیوندها را تنظیم کنید و همچنین اطلاعات رنگ را از پیوندها دریافت کنید. این ویژگی برای نخستین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این خصوصیت در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این مثال کد عملیاتی را نشان می‌دهد که در آن پیوندهای با رنگ‌های مختلف به یک اسلاید اضافه می‌شوند:

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

## **حذف پیوندها از ارائه‌ها**

### **حذف پیوندها از متن**

این کد Python نشان می‌دهد چگونه پیوند را از متن یک اسلاید ارائه حذف کنید:

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

### **حذف پیوندها از اشکال یا چارچوب‌ها**

این کد Python نشان می‌دهد چگونه پیوند را از یک شکل در یک اسلاید ارائه حذف کنید:

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

## **پیوند قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/) قابل تغییر است. با این کلاس می‌توانید مقادیر خصوصیات زیر را تغییر دهید:

- [setTargetFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

این قطعه کد نشان می‌دهد چگونه یک پیوند به اسلاید اضافه کنید و پس از آن توضیح ابزار (tooltip) آن را ویرایش کنید:

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

    # تغییر tooltip پیوندی که قبلاً اضافه شده است
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **خواص پشتیبانی‌شده در HyperlinkQueries**

می‌توانید از [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/) برای یک ارائه، اسلاید یا متن که پیوند در آن تعریف شده است، دسترسی داشته باشید. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getHyperlinkQueries)

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/) این متدها و خواص را پشتیبانی می‌کند: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **سوالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروه‌بندی از اسلایدها هستند؛ ناوبری به‌صورت فنی به یک اسلاید خاص هدف می‌گیرد. برای «ناوبری به یک بخش» معمولاً به اولین اسلاید آن بخش پیوند می‌زنید.

**آیا می‌توانم پیوند را به عناصر اسلاید اصلی (master) وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی از پیوندها پشتیبانی می‌کنند. چنین پیوندهایی در اسلایدهای فرزند ظاهر می‌شوند و در زمان نمایش اسلاید قابل کلیک هستند.

**آیا پیوندها هنگام خروجی گرفتن به PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/python-java/convert-powerpoint-to-html/)، بله—پیوندها عموماً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/python-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/python-java/convert-powerpoint-to-video/)، قابلیت کلیک کردن منتقل نمی‌شود زیرا این فرمت‌ها (فریم‌های رستر/ویدئو) از پیوندها پشتیبانی نمی‌کنند.