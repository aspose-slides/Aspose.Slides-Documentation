---
title: سمة العرض
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords: "السمة, سمة PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides لـ .NET"
description: "سمة عرض PowerPoint في C# أو .NET"
---

يحدد سمة العرض خصائص عناصر التصميم. عند اختيار سمة عرض، فإنك في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من ألوان، [خطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط خلفية](/slides/ar/net/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للسمة. للسماح لك باختيار لون سمة جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

هذا الكود C# يوضح كيفية تغيير لون التمييز لسمة:
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


يمكنك تحديد القيمة الفعالة للون الناتج بالطريقة التالية:
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (لون [A=255, R=128, G=100, B=162])
```


لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعين له لون التمييز (من العملية الأولية). ثم نغير اللون في السمة:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


يتم تطبيق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين تلك الألوان واستخلاصها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

هذا الكود C# يوضح عملية الحصول على ألوان لوحة إضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تمييز 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // تمييز 4، أفتح 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // تمييز 4، أفتح 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // تمييز 4، أفتح 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // تمييز 4، أغمق 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // تمييز 4، أغمق 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسما وتطبيقات أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني صغیر)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني كبیر)
* **+mn-ea** - خط الجسم الآسيوي الشرقي (خط شرق آسيوي صغیر)
* **+mj-ea** - خط الجسم الآسيوي الشرقي (خط شرق آسيوي كبیر)

هذا الكود C# يوضح كيفية تعيين الخط اللاتيني لعنصر سمة:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


هذا الكود C# يوضح كيفية تغيير خط سمة العرض:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/). 
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مسبقة التعريف، لكن يتم حفظ 3 فقط من تلك الخلفيات في عرض تقديمي قياسي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C# لمعرفة عدد الخلفيات المعرّفة مسبقًا في العرض:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) من فئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

هذا الكود C# يوضح كيفية تعيين الخلفية لعرض تقديمي:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/net/presentation-background/). 
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج هذه المصفوفات في 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو الناتج عندما تُطبّق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)، [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)، [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) من فئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) يمكنك تغيير العناصر في السمة (بشكل أكثر مرونة من الخيارات في PowerPoint).

هذا الكود C# يوضح كيفية تغيير تأثير سمة عن طريق تعديل أجزاء من العناصر:
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


التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، وغيرها:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير السمة الأساسية؟**

نعم. تدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على السمة الأساسية دون تعديل (من خلال [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

استخدم [استنساخ الشرائح](/slides/ar/net/clone-slides/) مع السمة الأساسية إلى العرض المستهدف. هذا يحافظ على السمة الأصلية، التخطيطات، والسمة المرتبطة بحيث يظل المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع وراثات وتجاوزات السمة؟**

استخدم واجهات برمجة التطبيقات للـ["Effective" views](/slides/ar/net/shape-effective-properties/) للسمة/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية التي تم حلها بعد تطبيق السمة الأساسية وأي تجاوزات محلية.