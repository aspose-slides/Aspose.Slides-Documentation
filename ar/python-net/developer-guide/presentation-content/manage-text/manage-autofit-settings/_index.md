---
title: إدارة إعدادات التكيف التلقائي
type: docs
weight: 30
url: /ar/python-net/manage-autofit-settings/
keywords: "صندوق نص, تكيف تلقائي, عرض PowerPoint, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "قم بتعيين إعدادات التكيف التلقائي لصندوق النص في PowerPoint باستخدام بايثون"
---

افتراضيًا، عند إضافة صندوق نص، تستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لصندوق النص—حيث يقوم بتغيير حجم صندوق النص تلقائيًا لضمان تناسب النص دائمًا داخله.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في صندوق النص أطول أو أكبر، يقوم PowerPoint بتكبير صندوق النص تلقائيًا—زيادة ارتفاعه—ليسع المزيد من النص.
* عندما يصبح النص في صندوق النص أقصر أو أصغر، يقوم PowerPoint بتقليل حجم صندوق النص تلقائيًا—خفض ارتفاعه—لإزالة المساحة الزائدة.

في PowerPoint، هذه هي المعلمات أو الخيارات الأربعة المهمة التي تتحكم في سلوك التكيف التلقائي لصندوق النص:

* **لا تقوم بالتكيف التلقائي**
* **قم بتقليص النص عند التجاوز**
* **تغيير حجم الشكل ليتناسب مع النص**
* **لف النص داخل الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

يوفر Aspose.Slides لبايثون عبر .NET خيارات مشابهة—بعض الخصائص ضمن فئة [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—التي تتيح لك التحكم في سلوك التكيف التلقائي لصناديق النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يناسب النص في صندوقه دائمًا بعد إجراء تغييرات على النص، عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (من فئة [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) إلى `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

يوضح لك هذا الكود في بايثون كيفية تحديد أنه يجب أن يتناسب النص دائمًا مع صندوقه في عرض PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

إذا أصبح النص أطول أو أكبر، فسيتم تغيير حجم صندوق النص تلقائيًا (زيادة في الارتفاع) لضمان تناسب كل النص داخله. إذا أصبح النص أقصر، يحدث العكس.

## **لا تقوم بالتكيف التلقائي**

إذا كنت تريد لصندوق النص أو الشكل الاحتفاظ بأبعاده بغض النظر عن التغييرات التي تم إجراؤها على النص المحتوي، عليك استخدام خيار **لا تقوم بالتكيف التلقائي**. لتحديد هذا الإعداد، قم بتعيين خاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (من فئة [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) إلى `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

يوضح لك هذا الكود في بايثون كيفية تحديد أنه يجب على صندوق النص الاحتفاظ بأبعاده دائمًا في عرض PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه، سيتجاوز.

## **تقليص النص عند التجاوز**

إذا أصبح النص طويلًا جدًا بالنسبة لصندوقه، من خلال خيار **تقليص النص عند التجاوز**، يمكنك تحديد أن حجم النص وتباعده يجب أن يتم تقليلهما ليتناسبا مع صندوقه. لتحديد هذا الإعداد، قم بتعيين خاصية [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (من فئة [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) إلى `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

يوضح لك هذا الكود في بايثون كيفية تحديد أنه يجب تقليص النص عند التجاوز في عرض PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="معلومات" color="info" %}}

عند استخدام خيار **تقليص النص عند التجاوز**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه.

{{% /alert %}}

## **لف النص**

إذا كنت تريد أن يتم لف النص داخل شكل ما عندما يتجاوز النص حدود الشكل (فقط العرض)، عليك استخدام معلمة **لف النص داخل الشكل**. لتحديد هذا الإعداد، يجب عليك تعيين خاصية [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) إلى `1`.

يوضح لك هذا الكود في بايثون كيفية استخدام إعداد لف النص في عرض PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملحوظة" color="warning" %}} 

إذا قمت بتعيين خاصية `wrap_text` إلى `0` لشكل ما، فعندما يصبح النص داخل الشكل أطول من عرض الشكل، يتم تمديد النص خارج حدود الشكل على سطر واحد.

{{% /alert %}}