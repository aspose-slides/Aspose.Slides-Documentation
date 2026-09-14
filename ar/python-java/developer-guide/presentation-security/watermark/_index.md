---
title: إضافة علامات مائية إلى العروض التقديمية باستخدام بايثون
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/python-java/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تغيير علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام بايثون لتحديد مسودة، معلومات سرية، حقوق طبع ونشر، وأكثر."
---
## **مقدمة**

**العلامة المائية** في العرض التقديمي هي ختم نصي أو صورة يُستخدم على شريحة واحدة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للدلالة على أن العرض هو مسودة (مثل علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثل علامة مائية "سري")، أو لتحديد الشركة المالكة (مثل علامة مائية "اسم الشركة")، أو لتحديد مؤلف العرض، وما إلى ذلك. تساعد العلامة المائية في منع انتهاك حقوق النشر من خلال الإشارة إلى أن العرض لا يجب نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ الملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/python-java/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام الفئة [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) يرث من الفئة [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، مما يتيح لك استخدام جميع إعدادات الشكل المرنة. وبما أن [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) ليس شكلاً وتُقيد إعداداته، فتم تغليفه في كائن [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم الـ Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى الـ Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو الشكل الأب للعلامة المائية) يتم توفير وظيفة قفل الشكل في Aspose.Slides. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يُقفل شكل العلامة المائية على الـ Slide Master، يُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك مستقبلاً، إذا رغبت في حذفها، العثور عليها بين أشكال الشريحة بالاسم.

يمكنك تصميم العلامة المائية بأي شكل؛ ومع ذلك، عادةً ما توجد ميزات شائعة في العلامات المائية، مثل المحاذاة المركزية، والدوران، والموضع الأمامي، وما إلى ذلك. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بالفئة [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/). هذا النوع لا يرث من الفئة [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، التي تحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك يتم تغليف كائن [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) داخل كائن [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/). لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [addTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#addTextFrame) كما هو موضح أدناه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [كيفية استخدام فئة TextFrame](/slides/ar/python-java/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى العرض التقديمي**

إذا رغبت في إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح مرة واحدة)، أضفها إلى الـ [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/). يبقى منطق الإضافة نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [addTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [كيفية استخدام Slide Master](/slides/ar/python-java/slide-master/)
{{% /alert %}}

### **ضبط شفافية شكل العلامة المائية**

افتراضيًا، يتم تنسيق الشكل المستطيل بألوان التعبئة والحد. تجعل السطور البرمجية التالية الشكل شفافًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **ضبط الخط للعلامة المائية النصية**

يمكنك تغيير خط العلامة المائية النصية كما هو موضح أدناه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **ضبط لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **توسيط العلامة المائية النصية**

يمكنك توسيط العلامة المائية على الشريحة، وذلك بتنفيذ ما يلي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

الصورة أدناه تُظهر النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى العرض التقديمي**

لإضافة علامة مائية صورة إلى شريحة من العرض، يمكنك القيام بما يلي:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **قفل العلامة المائية من التعديل**

إذا كان من الضروري منع تعديل العلامة المائية، استخدم طريقة [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#getAutoShapeLock) على الشكل. بهذه الخاصية يمكنك حماية الشكل من الاختيار، وإعادة التحجيم، وإعادة الوضع، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، والمزيد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # قفل شكل العلامة المائية لمنع التعديل.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **إحضار العلامة المائية إلى المقدمة**

في Aspose.Slides، يمكن ضبط ترتيب Z للأشكال عبر طريقة [ShapeCollection.reorder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#reorder). للقيام بذلك، عليك استدعاء هذه الطريقة من مجموعة أشكال الشريحة وتمرير مرجع الشكل ورقمه إلى الطريقة. بهذه الطريقة يمكن إحضار الشكل إلى المقدمة أو إرساله إلى الخلف. هذه الميزة مفيدة بشكل خاص إذا رغبت في وضع العلامة المائية أمام محتوى العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **ضبط دوران العلامة المائية**

إليك مثالًا برمجيًا يوضح كيفية ضبط دوران العلامة المائية لتكون موجهة بشكل مائل عبر الشريحة:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **تعيين اسم للعلامة المائية**

يتيح لك Aspose.Slides تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه لاحقًا لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، مرره إلى طريقة [Shape.setName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم طريقة [Shape.getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getName) للعثور عليه بين أشكال الشريحة. ثم مرر شكل العلامة المائية إلى طريقة [ShapeCollection.remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب علي استخدامها؟**

العلامة المائية هي طبقة نصية أو صورة تُطبق على الشرائح لتساعد في حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، يتيح لك Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التجول عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل شريحة على حدة.

**كيف يمكنني ضبط شفافية العلامة المائية؟**

يمكنك ضبط شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([getFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getFillFormat)) للشكل. يضمن ذلك أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

**هل يمكنني تخصيص الخط والنمط للعلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط وحجم ونمط ليناسب تصميم العرض ويحافظ على تناسق العلامة التجارية.

**كيف أغيّر موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع ودوران العلامة المائية برمجيًا عبر تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.