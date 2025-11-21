---
title: تحسين عروضك التقديمية باستخدام AutoFit في .NET
linktitle: إعدادات Autofit
type: docs
weight: 30
url: /ar/net/manage-autofit-settings/
keywords:
- مربع نص
- AutoFit
- عدم تعديل تلقائي
- ملاءمة النص
- تقليل النص
- لف النص
- تغيير حجم الشكل
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides
description: "تعرف على كيفية إدارة إعدادات AutoFit في Aspose.Slides لـ .NET لتحسين عرض النص في عروض PowerPoint وOpenDocument وتحسين قابلية قراءة المحتوى."
---

## **نظرة عامة**

إفتراضيًا، عندما تُضيف مربع نص، يستخدم Microsoft PowerPoint إعداد **Resize shape to fit text** لمربع النص—فهو يعيد ضبط حجم المربع تلقائيًا لضمان توافق النص معه دائمًا.

![مربع نص في PowerPoint](textbox-in-powerpoint.png)

* عندما يصبح النص داخل المربع أطول أو أكبر، يقوم PowerPoint تلقائيًا بزيادة ارتفاع المربع للسماح بوجود المزيد من النص.
* عندما يصبح النص داخل المربع أقصر أو أصغر، يقوم PowerPoint تلقائيًا بتقليل ارتفاع المربع لإزالة المساحة الزائدة.

في PowerPoint، هناك أربع معلمات أو خيارات مهمة تتحكم في سلوك Autofit لمربع النص:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![خيارات Autofit في PowerPoint](autofit-options-powerpoint.png)

توفر Aspose.Slides for .NET خيارات مماثلة—خصائص ضمن فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—تتيح لك التحكم في سلوك Autofit لمربعات النص في العروض التقديمية.

## **Resize Shape to Fit Text**

إذا أردت أن يناسب النص داخل الصندوق دائمًا ذلك الصندوق بعد إجراء تغييرات على النص، عليك استخدام خيار **Resize shape to fit text**. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Shape`.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

يظهر الكود التالي بلغة C# كيفية تحديد أن النص يجب أن يناسب الصندوق دائمًا في عرض PowerPoint:
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


إذا أصبح النص أطول أو أكبر، سيُعاد ضبط حجم مربع النص تلقائيًا (زيادة الارتفاع) لضمان احتواء كامل النص. وإذا أصبح النص أقصر، يحدث العكس.

## **Do Not Autofit**

إذا رغبت في أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص داخلها، عليك استخدام خيار **Do not Autofit**. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `None`.

!["Do not Autofit" setting in PowerPoint](donotautofit-setting-powerpoint.png)

يظهر الكود التالي بلغة C# كيفية تحديد أن مربع النص يجب أن يحتفظ بأبعاده دائمًا في عرض PowerPoint:
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


عندما يصبح النص طويلاً جدًا بالنسبة لصندوقه، يخرج النص خارجه.

## **Shrink Text on Overflow**

إذا أصبح النص طويلًا جدًا بالنسبة لصندوقه، يمكنك من خلال خيار **Shrink text on overflow** تحديد أن حجم النص والمسافات يجب تقليصهما ليتناسب مع الصندوق. لتحديد هذا الإعداد، عيّن خاصية `AutofitType` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `Normal`.

!["Shrink text on overflow" setting in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

يظهر الكود التالي بلغة C# كيفية تحديد أن النص يجب أن يُصغر عند الفائض في عرض PowerPoint:
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
عند استخدام خيار **Shrink text on overflow**، يُطبق الإعداد فقط عندما يصبح النص طويلًا جدًا بالنسبة لصندوقه.
{{% /alert %}}

## **Wrap Text**

إذا أردت أن يُلف النص داخل الشكل عندما يتجاوز النص حد عرض الشكل، عليك استخدام المعلمة **Wrap text in shape**. لتحديد هذا الإعداد، يجب تعيين خاصية `WrapText` من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) إلى `NullableBool.True`.

يظهر الكود التالي بلغة C# كيفية استخدام إعداد Wrap Text في عرض PowerPoint:
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
إذا عيّنت خاصية `WrapText` إلى `NullableBool.False` لشكل ما، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يمتد النص خارج حدود الشكل على سطر واحد.
{{% /alert %}}

## **FAQ**

**هل تؤثر الهوامش الداخلية لإطار النص على AutoFit؟**

نعم. تقليل الهوامش الداخلية (Padding) يقلل من المساحة المتاحة للنص، لذا سيبدأ AutoFit بالعمل مبكرًا—مُصغّرًا الخط أو مُعدلاً حجم الشكل أسرع. تحقق من الهوامش وضبطها قبل ضبط AutoFit.

**كيف يتفاعل AutoFit مع الفواصل اليدوية والناعمة؟**

تظل الفواصل القسرية في مكانها، ويتكيف AutoFit مع حجم الخط والمسافات حولها. إزالة الفواصل غير الضرورية يقلل من الحاجة إلى تقليص النص بشكل مفرط.

**هل يؤثر تغيير خط السمة أو استبدال الخط على نتائج AutoFit؟**

نعم. استبدال الخط بآخر له قياسات مختلفة يغيّر عرض/ارتفاع النص، مما قد يغير حجم الخط النهائي وتوزيع الأسطر. بعد أي تغيير أو استبدال للخط، أعد فحص الشرائح.