---
title: تحسين عروضك التقديمية باستخدام AutoFit في بايثون
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/python-java/manage-autofit-settings/
keywords:
- مربع نص
- autofit
- عدم autofit
- ملاءمة النص
- تقليص النص
- تغليف النص
- تحجيم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- جافا
- Aspose.Slides
description: "تعلم كيفية إدارة إعدادات AutoFit في Aspose.Slides لبايثون عبر جافا لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---
## **المقدمة**

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** لمربع النص—ويُعيد تحجيم مربع النص تلقائيًا لضمان أن النص يظل دائمًا يتناسب معه.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتوسيع مربع النص—يزيد ارتفاعه—للسماح له بحمل المزيد من النص.  
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص—ينقص ارتفاعه—لإزالة المساحة الزائدة.

في PowerPoint، هناك 4 معلمات أو خيارات مهمة تتحكم في سلوك الملاءمة التلقائية (autofit) لمربع النص:

* **عدم الملاءمة التلقائية**
* **تقليص النص عند الفائض**
* **تحجيم الشكل لتناسب النص**
* **تغليف النص داخل الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر مكتبة Aspose.Slides for Python عبر Java خيارات مماثلة—بعض الخصائص ضمن فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)—تتيح لك التحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية.

## **تحجيم الشكل لتناسب النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا مع الصندوق بعد إجراء أي تغييرات على النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يظهر هذا المثال البرمجي بلغة Python كيفية تحديد أن النص يجب أن يتناسب دائمًا مع صندوقه في عرض تقديمي PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا أصبح النص أطول أو أكبر، سيتم تعديل حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن جميع النصوص تتناسب معه. إذا أصبح النص أقصر، يحدث العكس.

## **عدم الملاءمة التلقائية**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تُجرى على النص الموجود داخله، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [None](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يظهر هذا المثال البرمجي بلغة Python كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض تقديمي PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عندما يصبح النص أطول من صندوقه، يفيض خارج الصندوق.

## **تقليص النص عند الفائض**

إذا أصبح النص أطول من صندوقه، يمكنك من خلال خيار **Shrink text on overflow** تحديد أن حجم النص والمسافات يجب تقليصهما لتناسب الصندوق. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [Normal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يظهر هذا المثال البرمجي بلغة Python كيفية تحديد أن النص يجب أن يُقلص عند الفائض في عرض تقديمي PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="ملاحظة" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من صندوقه.
{{% /alert %}}

## **تغليف النص**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حد عرض الشكل فقط، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، يجب استخدام طريقة [setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [NullableBool.True](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#True).

يظهر هذا المثال البرمجي بلغة Python كيفية استخدام إعداد تغليف النص في عرض تقديمي PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="تحذير" color="warning" %}} 
إذا استخدمت طريقة [setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) مع [NullableBool.False](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#False) لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، سيستمر النص في التمدد خارج حدود الشكل على سطر واحد.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تؤثر الهوامش الداخلية لإطار النص على الملاءمة التلقائية؟**

نعم. الهوامش الداخلية (Padding) تقلل من المنطقة المتاحة للنص، لذا سيبدأ سلوك الملاءمة التلقائية في العمل مبكرًا—إما بتقليص الخط أو تعديل حجم الشكل. تحقق من الهوامش واضبطها قبل تعديل إعدادات الملاءمة التلقائية.

**كيف يتفاعل الملاءمة التلقائية مع الفواصل اليدوية وفواصل السطر الناعمة؟**

تبقى الفواصل القسرية في مكانها، وتتكيف الملاءمة التلقائية مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من مدى تقليص النص الذي تحتاجه الملاءمة التلقائية.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج الملاءمة التلقائية؟**

نعم. استبدال الخط بآخر له مقاييس مختلفة يؤثر على عرض/ارتفاع النص، مما قد يغيّر حجم الخط النهائي وتغليف السطر. بعد أي تغيير أو استبدال للخط، قم بإعادة فحص الشرائح.