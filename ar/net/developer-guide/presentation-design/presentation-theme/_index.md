---
title: ثيم العرض
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords: "ثيم، ثيم باوربوينت، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "ثيم عرض باوربوينت في C# أو .NET"
---

تحدد ثيم العرض خصائص عناصر التصميم. عند اختيار ثيم عرض، فإنك تختار في الأساس مجموعة معينة من العناصر المرئية وخصائصها.

في باوربوينت، يتكون الثيم من الألوان، [الخطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/net/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون الثيم**

يستخدم ثيم باوربوينت مجموعة معينة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على الثيم. للسماح لك باختيار لون جديد للثيم، يوفر Aspose.Slides قيمًا تحت [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) التعداد.

يوضح هذا الكود بلغة C# كيفية تغيير لون التمييز لثيم:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

يمكنك تحديد القيمة الفعالة للون الناتج بهذه الطريقة:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

لإظهار عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونخصص له لون التمييز (من العملية الأولية). ثم نغير اللون في الثيم:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون الثيم من لوحة إضافية**

عندما تطبق تحويلات السطوع على لون الثيم الرئيسي(1)، تتشكل الألوان من اللوحة الإضافية(2). يمكنك حينها تعيين هذه الألوان للثيم والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان الثيم الرئيسية

**2** - ألوان من اللوحة الإضافية.

يوضح هذا الكود بلغة C# عملية يتم فيها الحصول على ألوان اللوحة الإضافية من لون الثيم الرئيسي ثم استخدامها في الأشكال:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4، أفتح 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4، أفتح 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4، أفتح 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4، أغمق 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4، أغمق 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **تغيير خط الثيم**

للسماح لك باختيار الخطوط للثيمات وأغراض أخرى، يستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في باوربوينت):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط الجسم شرق آسيوي (خط شرق آسيوي ثانوي)
* **+mj-ea** - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

يوضح هذا الكود بلغة C# كيفية تعيين الخط اللاتيني لعنصر الثيم:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("تنسيق نص الثيم");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

يوضح هذا الكود بلغة C# كيفية تغيير خط ثيم العرض:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطلاع على [خطوط باوربوينت](/slides/ar/net/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية الثيم**

بشكل افتراضي، يوفر تطبيق باوربوينت 12 خلفية مسبقة التعريف ولكن يتم حفظ فقط 3 من تلك الخلفيات الـ 12 في العرض التقديمي النموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق باوربوينت، يمكنك تشغيل هذا الكود بلغة C# لمعرفة عدد الخلفيات المسبقة في العرض التقديمي:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"عدد أنماط ملء الخلفية للثيم هو {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) من فئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) يمكنك إضافة أو الوصول إلى نمط الخلفية في ثيم باوربوينت. 

{{% /alert %}}

يوضح هذا الكود بلغة C# كيفية تعيين الخلفية لعرض تقديمي:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**دليل الفهرس**: 0 يستخدم لعدم الملء. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في الاطلاع على [خلفية باوربوينت](/slides/ar/net/presentation-background/).

{{% /alert %}}

## **تغيير تأثير الثيم**

عادةً ما يحتوي ثيم باوربوينت على 3 قيم لكل مصفوفة نمط. يتم دمج تلك المصفوفات في هذه 3 تأثيرات: خفيفة، معتدلة، وشديدة. على سبيل المثال، هذه هي النتيجة عندما يتم تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)، [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)، [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) من فئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) يمكنك تغيير العناصر في ثيم (بمرونة أكبر حتى من الخيارات في باوربوينت).

يوضح هذا الكود بلغة C# كيفية تغيير تأثير الثيم عن طريق تعديل أجزاء من العناصر:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)