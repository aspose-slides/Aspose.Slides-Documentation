---
title: إدارة الروابط التشعبية للعرض التقديمي في Python عبر Java
linktitle: إدارة الرابط التشعبي
type: docs
weight: 20
url: /ar/python-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي نصي
- رابط تشعبي للشرائح
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة الروابط التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java—تعزيز التفاعل وسير العمل في دقائق."
---
## **المقدمة**

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان ما. هذه روابط تشعب شائعة في عروض PowerPoint:

* الروابط إلى مواقع الويب داخل النصوص أو الأشكال أو الوسائط
* الروابط إلى الشرائح

يتيح لك Aspose.Slides for Python عبر Java تنفيذ العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية. 

{{% alert color="info" title="Note" %}} 

ربما ترغب في تجربة Aspose البسيط، [محرر PowerPoint المجاني على الإنترنت.](https://products.aspose.app/slides/ar/editor)

{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النص**

يعرض لك هذا الكود بلغة Python كيفية إضافة رابط موقع ويب إلى نص:

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

### **إضافة روابط URL إلى الأشكال أو الإطارات**

يعرض لك هذا المثال البرمجي بلغة Python عبر Java كيفية إضافة رابط موقع ويب إلى شكل:

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

### **إضافة روابط URL إلى الوسائط**

يتيح لك Aspose.Slides إضافة روابط تشعبية إلى الصور وملفات الصوت والفيديو. 

يعرض لك هذا المثال البرمجي كيفية إضافة رابط تشعبي إلى **صورة**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # إضافة صورة إلى العرض التقديمي
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # إنشاء إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يعرض لك هذا المثال البرمجي كيفية إضافة رابط تشعبي إلى **ملف صوتي**:

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

يعرض لك هذا المثال البرمجي كيفية إضافة رابط تشعبي إلى **فيديو**:

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

ربما ترغب في مشاهدة *[إدارة OLE](/slides/ar/python-java/manage-ole/)*.

{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

نظرًا لأن الروابط التشعبية تسمح لك بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات.

يعرض لك هذا المثال البرمجي كيفية إنشاء جدول محتويات باستخدام الروابط التشعبية:

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

## **تنسيق الروابط التشعبية**

### **اللون**

باستخدام الخاصية [Hyperlink.setColorSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setColorSource) في الفئة [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/)، يمكنك تعيين لون الروابط التشعبية وكذلك الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذلك لا تُطبق التغييرات المتعلقة بهذه الخاصية على إصدارات PowerPoint القديمة.

يعرض لك هذا المثال البرمجي عملية تم فيها إضافة روابط تشعبية بألوان مختلفة إلى الشريحة نفسها:

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

## **إزالة الروابط التشعبية من العروض التقديمية**

### **إزالة الروابط التشعبية من النص**

يعرض لك هذا الكود بلغة Python كيفية إزالة الرابط التشعبي من نص في شريحة العرض التقديمي:

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

### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

يعرض لك هذا الكود بلغة Python كيفية إزالة الرابط التشعبي من شكل في شريحة العرض التقديمي: 

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

## **رابط تشعبي قابل للتغيير**

الفئة [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) قابلة للتغيير. باستخدام هذه الفئة، يمكنك تعديل قيم الخصائص التالية:

- [setTargetFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

يعرض لك مقتطف الشيفرة كيفية إضافة رابط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:

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

    # يغيّر تلميح الرابط التشعبي الذي تم إضافته بالفعل
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الخصائص المدعومة في HyperlinkQueries**

يمكنك الوصول إلى [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/) من عرض تقديمي أو شريحة أو نص تم تعريف الرابط التشعبي له. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getHyperlinkQueries)

تدعم الفئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/) هذه الطرق والخصائص: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **الأسئلة الشائعة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى من قسم؟**

الأقسام في PowerPoint هي تجميعات للشرائح؛ التقنية تستهدف شريحة محددة. لل«انتقال إلى قسم»، عادةً ما تقوم بالربط إلى شريحته الأولى.

**هل يمكنني إرفاق رابط تشعبي بعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والقوالب الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية ويمكن النقر عليها أثناء تشغيل العرض.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، نعم—عادةً ما تُحفظ الروابط. عند التصدير إلى [صور](/slides/ar/python-java/convert-powerpoint-to-png/) و[فيديو](/slides/ar/python-java/convert-powerpoint-to-video/)، لن تُحافظ على القابلية للنقر بسبب طبيعة هذه الصيغ (الإطارات النقطية/الفيديو لا تدعم الروابط التشعبية).