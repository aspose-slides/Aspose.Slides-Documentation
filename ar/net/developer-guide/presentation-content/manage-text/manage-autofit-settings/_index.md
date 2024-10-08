---
title: إدارة إعدادات التعديل التلقائي
type: docs
weight: 30
url: /ar/net/manage-autofit-settings/
keywords: "مربع النص، تعديل تلقائي، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تعيين إعدادات التعديل التلقائي لمربع النص في PowerPoint باستخدام C# أو .NET"
---

بشكل افتراضي، عند إضافة مربع نص، يستخدم Microsoft PowerPoint إعداد **تغيير حجم الشكل ليتناسب مع النص** لمربع النص—إذ يقوم بتغيير حجم مربع النص تلقائيًا لضمان تناسق النص داخله.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* عندما يصبح النص في مربع النص أطول أو أكبر، يقوم PowerPoint بتكبير مربع النص تلقائيًا—يزيد من ارتفاعه—ليتمكن من استيعاب المزيد من النص.
* عندما يصبح النص في مربع النص أقصر أو أصغر، يقوم PowerPoint بتقليل مربع النص تلقائيًا—يقلل من ارتفاعه—لإزالة المساحة الزائدة.

في PowerPoint، هذه هي 4 معلمات أو خيارات مهمة تتحكم في سلوك التعديل التلقائي لمربع النص:

* **لا تعدل تلقائيًا**
* **تصغير النص عند التدفق الزائد**
* **تغيير حجم الشكل ليتناسب مع النص**
* **لف النص في الشكل.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

توفر Aspose.Slides لـ .NET خيارات مماثلة—بعض الخصائص تحت فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—التي تسمح لك بالتحكم في سلوك التعديل التلقائي لمربعات النص في العروض التقديمية.

## **تغيير حجم الشكل ليتناسب مع النص**

إذا كنت ترغب في أن يتناسب النص في مربع مع ذلك المربع بعد إجراء تغييرات على النص، يجب عليك استخدام خيار **تغيير حجم الشكل ليتناسب مع النص**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) إلى `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

هذا الكود C# يظهر لك كيفية تحديد أن النص يجب أن يتناسب دائمًا مع مربع النص في عرض PowerPoint:

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

إذا أصبح النص أطول أو أكبر، سيتم تغيير حجم مربع النص تلقائيًا (زيادة في الارتفاع) لضمان تناسق جميع النصوص بداخله. إذا أصبح النص أقصر، يحدث العكس.

## **لا تعدل تلقائيًا**

إذا كنت ترغب في أن يحتفظ مربع النص أو الشكل بأبعاده بغض النظر عن التغييرات التي تطرأ على النص المحتوى، يجب عليك استخدام خيار **لا تعدل تلقائيًا**. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) إلى `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

هذا الكود C# يظهر لك كيفية تحديد أن مربع النص يجب أن يحتفظ دائمًا بأبعاده في عرض PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

عندما يصبح النص طويلًا جدًا مقارنة بمربعه، فإنه يتجاوز الحدود.

## **تصغير النص عند التدفق الزائد**

إذا أصبح النص طويلًا جدًا بالنسبة لمربعه، من خلال خيار **تصغير النص عند التدفق الزائد**، يمكنك تحديد أن حجم النص ومسافاته يجب تقليلها ليتناسب مع مربعه. لتحديد هذا الإعداد، قم بتعيين خاصية [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) إلى `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

هذا الكود C# يظهر لك كيفية تحديد أن النص يجب أن يتم تصغيره عند التدفق الزائد في عرض PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="معلومات" color="info" %}}

عند استخدام خيار **تصغير النص عند التدفق الزائد**، يتم تطبيق الإعداد فقط عندما يصبح النص طويلًا جدًا لمربعه. 

{{% /alert %}}

## **لف النص**

إذا كنت ترغب في لف النص داخل شكل عندما يتجاوز النص حدود الشكل (العرض فقط)، يجب عليك استخدام خيار **لف النص في الشكل**. لتحديد هذا الإعداد، يجب عليك تعيين خاصية [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) (من فئة [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) إلى `true`.

هذا الكود C# يظهر لك كيفية استخدام إعداد لف النص في عرض PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ملاحظة" color="warning" %}} 

إذا قمت بتعيين خاصية `WrapText` إلى `False` لشكل، عندما يصبح النص داخل الشكل أطول من عرض الشكل، يتجاوز النص حدود الشكل على طول سطر واحد. 

{{% /alert %}}