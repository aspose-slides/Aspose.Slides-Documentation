---
title: "حسّن عروضك التقديمية باستخدام AutoFit في بايثون"
linktitle: "إعدادات AutoFit"
type: docs
weight: 30
url: /ar/python-java/manage-autofit-settings/
keywords:
- "مربع نص"
- "AutoFit"
- "عدم AutoFit"
- "ملاءمة النص"
- "تصغير النص"
- "لف النص"
- "تغيير حجم الشكل"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Java"
- "Aspose.Slides"
description: "تعرّف على كيفية إدارة إعدادات AutoFit في Aspose.Slides للبايثون عبر جافا لتحسين عرض النص في عروض PowerPoint وOpenDocument وتعزيز قابلية قراءة المحتوى."
---
## **المقدمة**

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fit text** لمربع النص—فهو يقوم تلقائيًا بتغيير حجم مربع النص لضمان أن النص يظل دائمًا يتناسب معه.

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص — زيادة ارتفاعه — للسماح له باحتواء المزيد من النص.
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص — تقليل ارتفاعه — لإزالة المساحة الزائدة.

في PowerPoint، هذه هي الأربعة معلمات أو خيارات المهمة التي تتحكم في سلوك الـ AutoFit لمربع النص:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![خيارات الضبط التلقائي في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for Python via Java خيارات مماثلة—بعض الخصائص ضمن فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)—تتيح لك التحكم في سلوك الـ autofit لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص دائمًا داخل المربع بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fit text**. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#Shape).

![إعداد دائم التناسب في PowerPoint](alwaysfit-setting-powerpoint.png)

يعرض هذا الكود Python كيفية تحديد أن النص يجب أن يتناسب دائمًا داخل صندله في عرض PowerPoint:

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

إذا أصبح النص أطول أو أكبر، سيُعاد ضبط حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن جميع النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس.

## **عدم Autofit**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [None](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#None).

![إعداد عدم Autofit في PowerPoint](donotautofit-setting-powerpoint.png)

يعرض هذا الكود Python كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عندما يصبح النص أطول من الصندوق، يخرج خارج الصندوق.

## **تقليص النص عند الفائض**

إذا أصبح النص أطول من الصندوق، يمكنك استخدام خيار **Shrink text on overflow** لتحديد أن حجم النص والمسافات يجب أن تُقلص لتناسب الصندوق. لتحديد هذا الإعداد، استخدم طريقة [setAutofitType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setAutofitType) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [Normal](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textautofittype/#Normal).

![إعداد تقليل النص عند الفائض في PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

يعرض هذا الكود Python كيفية تحديد أن النص يجب أن يُقلص عند الفائض في عرض PowerPoint:

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

{{% alert title="Note" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من الصندوق.
{{% /alert %}}

## **التفاف النص**

إذا كنت تريد أن يلتف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، عليك استخدام طريقة [setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/)) مع [NullableBool.True_](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#True).

يعرض هذا الكود Python كيفية استخدام إعداد التفاف النص في عرض PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
إذا استخدمت طريقة [setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) مع [NullableBool.False](https://reference.aspose.com/slides/ar/python-java/aspose.slides/nullablebool/#False) لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارج حدود الشكل على سطر واحد.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تؤثر الهوامش الداخلية لإطار النص على الـ AutoFit؟**

نعم. الهوامش الداخلية (Padding) تقلل من المساحة المتاحة للنص، لذا يبدأ الـ AutoFit بالعمل مبكرًا—يقلص الخط أو يغير حجم الشكل أسرع. تحقق من الهوامش و اضبطها قبل تعديل الـ AutoFit.

**كيف يتفاعل الـ AutoFit مع فواصل السطر اليدوية والمرنة؟**

الفواصل القسرية تبقى في مكانها، ويتكيف الـ AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من حدة تقليص النص بواسطة الـ AutoFit.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج الـ AutoFit؟**

نعم. استبدال خط بمعايير مختلفة يغير عرض/ارتفاع النص، مما قد يغير حجم الخط النهائي وتفاف السطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.