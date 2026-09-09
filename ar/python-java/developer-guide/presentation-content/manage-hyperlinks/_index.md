---
title: إدارة ارتباطات العرض التقديمي في Python عبر Java
linktitle: إدارة الارتباط التشعبي
type: docs
weight: 20
url: /ar/python-java/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي للنص
- ارتباط تشعبي للشرائح
- ارتباط تشعبي للشكل
- ارتباط تشعبي للصورة
- ارتباط تشعبي للفيديو
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة الارتباطات التشعبية بسهولة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـPython عبر Java—عزز التفاعل وسير العمل في دقائق."
---
## **المقدمة**

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو موقع. تشمل الروابط التشعبية الشائعة في عروض PowerPoint:

* روابط إلى مواقع ويب في النص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for Python via Java يتيح لك تنفيذ العديد من المهام المتعلقة بالارتباطات التشعبية في العروض التقديمية. 

{{% alert color="info" title="ملاحظة" %}} 

قد ترغب في تجربة محرّر PowerPoint **المجاني** على الإنترنت من Aspose: [محرّر PowerPoint المجاني على الويب.](https://products.aspose.app/slides/ar/editor)

{{% /alert %}} 

## **إضافة ارتباطات URL**

### **إضافة ارتباطات URL إلى النص**

هذا الكود في Python يوضح كيفية إضافة ارتباط ويب إلى النص:

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

### **إضافة ارتباطات URL إلى الأشكال أو الإطارات**

هذا المثال في Python عبر Java يوضح كيفية إضافة ارتباط ويب إلى شكل:

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

### **إضافة ارتباطات URL إلى الوسائط**

Aspose.Slides يتيح لك إضافة ارتباطات إلى الصور، ملفات الصوت، وملفات الفيديو. 

هذا المثال يوضح كيفية إضافة ارتباط إلى **صورة**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # يضيف صورة إلى العرض التقديمي
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # ينشئ إطار صورة على الشريحة 1 استنادًا إلى الصورة المضافة مسبقًا
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذا المثال يوضح كيفية إضافة ارتباط إلى **ملف صوت**:

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

هذا المثال يوضح كيفية إضافة ارتباط إلى **فيديو**:

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

{{% alert color="success" title="نصيحة" %}} 

قد ترغب في الاطلاع على *[إدارة OLE](/slides/ar/python-java/manage-ole/)*.

{{% /alert %}}

## **استخدام الارتباطات لإنشاء جدول محتويات**

نظرًا لأن الارتباطات تسمح بإضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء جدول محتويات. 

هذا المثال يوضح كيفية إنشاء جدول محتويات مع ارتباطات تشعبية:

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

## **تنسيق الارتباطات**

### **اللون**

باستخدام خاصية [Hyperlink.setColorSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setColorSource) في فئة [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) يمكنك تعيين لون للارتباطات التشعبية والحصول على معلومات اللون منها. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

هذا المثال يُظهر عملية إضافة ارتباطات بألوان مختلفة إلى نفس الشريحة:

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

## **إزالة الارتباطات من العروض**

### **إزالة الارتباطات من النص**

هذا الكود في Python يوضح كيفية إزالة الارتباط من نص على شريحة عرض:

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

### **إزالة الارتباطات من الأشكال أو الإطارات**

هذا الكود في Python يوضح كيفية إزالة الارتباط من شكل على شريحة عرض:

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

## **الارتباط القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/) قابلة للتعديل. باستخدام هذه الفئة يمكنك تغيير القيم للخصائص التالية:

- [setTargetFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

المقتطف التالي يوضح كيفية إضافة ارتباط إلى شريحة وتعديل تلميحه لاحقًا:

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

    # يغيّر تلميح الارتباط التشعبي الذي تم إضافته بالفعل
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الخصائص المدعومة في HyperlinkQueries**

يمكنك الوصول إلى [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/) من عرض تقديمي أو شريحة أو نص تم تعريف الارتباط التشعبي له. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getHyperlinkQueries)

فئة [HyperlinkQueries](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/) تدعم هذه الطرق والخصائص: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **الأسئلة المتكررة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى في قسم؟**

الأقسام في PowerPoint هي مجموعات من الشرائح؛ التنقل يستهدف تقنيًا شريحة محددة. للـ"انتقال إلى قسم"، عادةً ما تقوم بالربط إلى الشريحة الأولى لهذا القسم.

**هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة وتخطيطاتها الارتباطات التشعبية. تظهر هذه الروابط على الشرائح الفرعية وتكون قابلة للنقر أثناء عرض الشرائح.

**هل سيتم الحفاظ على الارتباطات عند التحويل إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/) و [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، نعم — عادةً ما تُحفظ الروابط. عند التحويل إلى [صور](/slides/ar/python-java/convert-powerpoint-to-png/) و [فيديو](/slides/ar/python-java/convert-powerpoint-to-video/)، لن تُنقل القابلية للنقر بسبب طبيعة هذه الصيغ (الإطارات النقطية/الفيديو لا تدعم الارتباطات).