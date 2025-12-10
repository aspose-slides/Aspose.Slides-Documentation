---
title: تحسين عروضك التقديمية باستخدام AutoFit في .NET
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/net/manage-autofit-settings/
keywords:
- مربع نص
- الملاءمة التلقائية
- عدم الملاءمة التلقائية
- ملاءمة النص
- تصغير النص
- لف النص
- تغيير حجم الشكل
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides
description: "تعرّف على كيفية إدارة إعدادات AutoFit في Aspose.Slides لـ .NET لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

## **نظرة عامة**

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** للمربع النصي—فهو يغير حجم المربع تلقائيًا لضمان احتواء النص بداخله دائمًا.

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص في المربع النصي أطول أو أكبر، يقوم PowerPoint تلقائيًا بتكبير المربع—بزيادة ارتفاعه—للسماح بوجود نص أكثر.
* عندما يصبح النص في المربع النصي أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل المربع—بخفض ارتفاعه—لإزالة المساحة الزائدة.

في PowerPoint، هناك أربع معلمات أو خيارات مهمة تتحكم في سلوك الملاءمة التلقائية لمربع النص:

* **عدم الملاءمة التلقائية**
* **تصغير النص عند الفائض**
* **تغيير حجم الشكل ليتناسب مع النص**
* **لف النص داخل الشكل**

![خيارات الملاءمة التلقائية في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for .NET خيارات مماثلة—خصائص ضمن فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—تتيح لك التحكم في سلوك الملاءمة التلقائية لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت تريد أن يتناسب النص داخل الصندوق دائمًا مع الصندوق بعد أي تعديل للنص، عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، اضبط خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Shape`.

![تغيير حجم الشكل ليتناسب مع النص](alwaysfit-setting-powerpoint.png)

هذا الكود C# يوضح كيفية تحديد أن النص يجب أن يتناسب دائمًا مع الصندوق في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيُعاد تحجيم مربع النص تلقائيًا (زيادة الارتفاع) لضمان احتواء جميع النص. إذا أصبح النص أقصر، يحدث العكس.

## **عدم الملاءمة التلقائية**

إذا كنت تريد أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص الموجود فيه، عليك استخدام خيار **عدم الملاءمة التلقائية**. لتحديد هذا الإعداد، اضبط خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

هذا الكود C# يوضح كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص أطول من الصندوق، يفيض خارج الصندوق.

## **تصغير النص عند الفائض**

إذا أصبح النص أطول من الصندوق، يمكنك عبر خيار **تصغير النص عند الفائض** تحديد أن حجم النص والمسافات يجب أن تقل لتتناسب مع الصندوق. لتحديد هذا الإعداد، اضبط خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

هذا الكود C# يوضح كيفية تحديد أن النص يجب أن يُصغر عند الفائض في عرض PowerPoint:
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
عند استخدام خيار **تصغير النص عند الفائض**، يُطبق الإعداد فقط عندما يصبح النص أطول من الصندوق.
{{% /alert %}}

## **لف النص**

إذا كنت تريد أن يُلف النص داخل الشكل عندما يتجاوز النص حد الشكل (العرض فقط)، عليك استخدام معلمة **لف النص داخل الشكل**. لتحديد هذا الإعداد، اضبط خاصية `WrapText` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `NullableBool.True`.

هذا الكود C# يوضح كيفية استخدام إعداد لف النص في عرض PowerPoint:
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
إذا ضبطت خاصية `WrapText` إلى `NullableBool.False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارج حدود الشكل سطرًا واحدًا.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تؤثر الهوامش الداخلية لإطار النص على الملاءمة التلقائية؟**

نعم. الهوامش الداخلية (Padding) تقلل المساحة المتاحة للنص، لذا ستبدأ الملاءمة التلقائية في العمل مبكرًا—إما بتقليل حجم الخط أو بتغيير حجم الشكل. تحقق من الهوامش واضبطها قبل تعديل الملاءمة التلقائية.

**كيف تتفاعل الملاءمة التلقائية مع الفواصل اليدوية والناعمة؟**

تبقى الفواصل القسرية في موضعها، وتتكيف الملاءمة التلقائية مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية غالبًا ما يقلل من شدة تصغير النص عبر الملاءمة التلقائية.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج الملاءمة التلقائية؟**

نعم. استبدال الخط بخط لديه قياسات مختلفة يغير عرض/ارتفاع النص، مما قد يغير حجم الخط النهائي ولف الأسطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.