---
title: تحسين عروضك التقديمية باستخدام AutoFit في C#
linktitle: إدارة إعدادات Autofit
type: docs
weight: 30
url: /ar/net/manage-autofit-settings/
keywords:
- مربع نص
- AutoFit
- عدم الضبط التلقائي
- ملاءمة النص
- تصغير النص
- التفاف النص
- تحجيم الشكل
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides
description: "تعلم كيفية إدارة إعدادات AutoFit في Aspose.Slides لـ .NET لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

## **نظرة عامة**

بشكل افتراضي، عندما تضيف مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fit text** لمربع النص—يقوم تلقائيًا بتغيير حجم مربع النص لضمان أن النص دائمًا يتناسب معه.

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير مربع النص—زيادة ارتفاعه—للسماح له بحمل المزيد من النص.
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل حجم مربع النص—خفض ارتفاعه— لإزالة المساحة الزائدة.

في PowerPoint، هذه هي المعايير أو الخيارات الأربعة المهمة التي تتحكم في سلوك الضبط التلقائي لمربع النص:

* **عدم الضبط التلقائي**
* **تصغير النص عند الفائض**
* **تحجيم الشكل ليتناسب مع النص**
* **التفاف النص داخل الشكل**

![خيارات الضبط التلقائي في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for .NET خيارات مشابهة—خصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—تتيح لك التحكم في سلوك الضبط التلقائي لمربعات النص في العروض التقديمية.

## **تحجيم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص دائمًا داخل الصندوق بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fit text**. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Shape`.

![تحجيم الشكل ليتناسب مع النص](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


إذا أصبح النص أطول أو أكبر، سيُعيد PowerPoint تعديل حجم مربع النص تلقائيًا (زيادة ارتفاعه) لضمان أن جميع النص يتناسب فيه. إذا أصبح النص أقصر، يحدث العكس.

## **عدم الضبط التلقائي**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الذي يحتويه، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


عند أن يصبح النص أطول من الصندوق، ينسكب خارج الصندوق.

## **تصغير النص عند الفائض**

إذا أصبح النص أطول من الصندوق، يمكنك عبر خيار **Shrink text on overflow** تحديد أن يتم تقليل حجم النص والمسافات لجعله يتناسب داخل الصندوق. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
عند استخدام خيار **Shrink text on overflow**، يتم تطبيق الإعداد فقط عندما يصبح النص أطول من الصندوق.
{{% /alert %}}

## **التفاف النص داخل الشكل**

إذا كنت تريد أن يُلتف النص داخل الشكل عندما يتجاوز النص حد الشكل (العرض فقط)، عليك استخدام معلمة **Wrap text in shape**. لتحديد هذا الإعداد، عليك تعيين خاصية `WrapText` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `NullableBool.True`.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 
إذا قمت بتعيين خاصية `WrapText` إلى `NullableBool.False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارج حدود الشكل في سطر واحد.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. تقليل الهوامش الداخلية (Padding) يقلل من المساحة المتاحة للنص، لذا سيتدخل AutoFit مبكرًا—إما بتصغير حجم الخط أو تغيير حجم الشكل أسرع. تحقق من الهوامش واضبطها قبل تعديل AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية والناعمة؟**

تظل الفواصل القسرية كما هي، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تقليص النص بواسطة AutoFit.

**هل يؤدي تغيير خط الثيم أو استبدال الخط إلى تأثير نتائج AutoFit؟**

نعم. استبدال الخط بآخر له مقاييس مختلفة يغير عرض/ارتفاع النص، مما قد يغيّر الحجم النهائي للخط وتوزيع الأسطر. بعد أي تغيير أو استبدال للخط، يجب مراجعة الشرائح مرة أخرى.