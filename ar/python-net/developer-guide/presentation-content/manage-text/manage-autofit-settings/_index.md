---
title: حسّن عروضك التقديمية باستخدام الضبط التلقائي AutoFit في بايثون
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/python-net/manage-autofit-settings/
keywords:
- مربع نص
- الضبط التلقائي
- عدم الضبط التلقائي
- ملاءمة النص
- تقليل حجم النص
- تغليف النص
- تغيير حجم الشكل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة إعدادات AutoFit في Aspose.Slides لبايثون عبر .NET لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fix text** للمربع النصي—يقوم تلقائيًا بتغيير حجم المربع النصي لضمان أن النص دائمًا يتناسب معه. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتوسيع مربع النص—يزيد ارتفاعه—للسماح له بحمل نص أكبر. 
* عندما يصبح النص داخل مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل مربع النص—يقلل ارتفاعه—لإزالة المساحة الزائدة. 

في PowerPoint، هذه هي المعلمات أو الخيارات الأربعة المهمة التي تتحكم في سلوك الضبط التلقائي لمربع النص:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET يوفر خيارات مشابهة—بعض الخصائص تحت الفئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—التي تتيح لك التحكم في سلوك الضبط التلقائي لمربعات النص في العروض التقديمية. 

## **تغيير حجم الأشكال لتتناسب مع النص**

إذا كنت تريد أن يتناسب النص داخل المربع دائمًا مع ذلك المربع بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fix text**. لتحديد هذا الإعداد، اضبط الخاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) إلى `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


إذا أصبح النص أطول أو أكبر، سيتم تغيير حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان أن كل النص يتناسب معه. إذا أصبح النص أقصر، يحدث العكس. 

## **عدم الضبط التلقائي**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، اضبط الخاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) إلى `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


عندما يصبح النص طويلًا جدًا بالنسبة لمربعه، سيظهر خارج المربع. 

## **تقليل النص عند الفائض**

إذا أصبح النص طويلًا جدًا بالنسبة لمربعه، يمكنك من خلال خيار **Shrink text on overflow** تحديد أنه يجب تقليل حجم النص والمسافات لجعله يتناسب مع المربع. لتحديد هذا الإعداد، اضبط الخاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) إلى `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لمربعه. 
{{% /alert %}}

## **تغليف النص**

إذا كنت تريد أن يُلف النص داخل الشكل عندما يتجاوز النص حدود الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، عليك ضبط الخاصية [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) إلى `NullableBool.TRUE`. 

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
إذا ضبطت الخاصية `wrap_text` إلى `NullableBool.FALSE` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص خارج حدود الشكل على سطر واحد. 
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. الهوامش الداخلية (Padding) تقلل من المنطقة القابلة للاستخدام للنص، لذا سيبدأ AutoFit في العمل مبكرًا—إما بتقليص الخط أو تغيير حجم الشكل بشكل أسرع. تحقق من الهوامش واضبطها قبل تعديل AutoFit.

**كيف يتفاعل AutoFit مع فواصل الأسطر اليدوية والمرنة؟**

الفواصل القسرية تبقى في مكانها، ويتكيف AutoFit بحجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليل النص بواسطة AutoFit.

**هل يؤثر تغيير خط السمة أو تفعيل استبدال الخط على نتائج AutoFit؟**

نعم. استبدال الخط بخط له مقاييس مختلفة يغير عرض/ارتفاع النص، مما قد يغيّر الحجم النهائي للخط وتغليف الأسطر. بعد أي تعديل أو استبدال للخط، أعد فحص الشرائح.