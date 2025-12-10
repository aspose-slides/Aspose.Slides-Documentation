---
title: إدارة سمات العروض التقديمية في .NET
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
- سمة الشريحة
- ضبط السمة
- تغيير السمة
- إدارة السمة
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---

يُعرّف موضوع العرض التقديمي خصائص عناصر التصميم. عند اختيارك لموضوع العرض التقديمي، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتضمن الموضوع ألوانًا، [الخطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/net/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

يستخدم موضوع PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للموضوع. لتحديد لون سمة جديد، توفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

هذا الكود C# يوضح كيفية تغيير لون التمييز للموضوع:
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (لون [A=255, R=128, G=100, B=162])
```


لتوضيح عملية تغيير اللون أكثر، نقوم بإنشاء عنصر آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغيّر اللون في الموضوع:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


يُطبَّق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة إضافية**

عند تطبيق تحولات اللمعان على اللون الرئيسي للموضوع (1)، تُشكَّل ألوان من اللوحة الإضافية (2). يمكنك بعد ذلك ضبط هذه الألوان وإحضارها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من اللوحة الإضافية.

هذا الكود C# يوضح كيفية الحصول على ألوان اللوحة الإضافية من اللون الرئيسي للموضوع ثم استخدامها في الأشكال:
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

لتمكينك من اختيار الخطوط للمواضيع وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي Latin (خط Latin الصغير)
* **+mj-lt** - خط العنوان Latin (خط Latin الرئيسي)
* **+mn-ea** - خط النص الأساسي East Asian (خط East Asian الصغير)
* **+mj-ea** - خط النص الأساسي East Asian (خط East Asian الصغير)

هذا الكود C# يوضح كيفية تعيين الخط Latin لعنصر في الموضوع:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


هذا الكود C# يوضح كيفية تغيير خط موضوع العرض التقديمي:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="نصيحة" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُعرَّفة مسبقًا ولكن فقط 3 منها تُحفظ في العرض التقديمي النموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C# لمعرفة عدد الخلفيات المُعرَّفة مسبقًا في العرض:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) من الفئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/)، يمكنك إضافة أو الوصول إلى نمط الخلفية في موضوع PowerPoint. 
{{% /alert %}}

هذا الكود C# يوضح كيفية ضبط الخلفية للعرض التقديمي:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما يحتوي موضوع PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج هذه المصفوفات في هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو الناتج عندما تُطبق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) من الفئة [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) يمكنك تغيير العناصر في الموضوع (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

هذا الكود C# يوضح كيفية تغيير تأثير السمة عن طريق تعديل أجزاء من العناصر:
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

## **الأسئلة المتكررة**

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الأساسي؟**

نعم. تدعم Aspose.Slides تجاوزات موضوع على مستوى الشريحة، بحيث يمكنك تطبيق موضوع محلي على تلك الشريحة فقط مع الحفاظ على موضوع الأساسي دون تغيير (من خلال [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل موضوع من عرض تقديمي إلى آخر؟**

[Clone slides](/slides/ar/net/clone-slides/) مع الماستر الخاص بها إلى العرض المستهدف. يحافظ ذلك على الماستر الأصلي، التخطيطات، والموضوع المرتبط لضمان بقاء المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع الوراثة والتجاوزات؟**

استخدم "العروض الفعّالة" في API عبر [\"effective\" views](/slides/ar/net/shape-effective-properties/) للموضوع/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحلّلة بعد تطبيق الماستر وأي تجاوزات محلية.