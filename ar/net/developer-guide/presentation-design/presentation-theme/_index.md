---
title: إدارة سمات العروض التقديمية في .NET
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
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
description: "إدارة سمات العروض التقديمية في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية موحدة."
---

تحدد سمة العرض خصائص عناصر التصميم. عند اختيار سمة عرض، فأنت في الأساس تختار مجموعة محددة من العناصر المرئية وخصائصها.

في PowerPoint، تتكون السمة من الألوان، [الخطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/net/presentation-background/)، والتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للسمة. لتحديد لون سمة جديد، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/).

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

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (اللون [A=255, R=128, G=100, B=162])
```


لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغيّر اللون في السمة:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


سيتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات السطوع على لون السمة الرئيسي (1)، تتشكل ألوان من لوحة الألوان الإضافية (2). يمكنك بعدها تعيين هذه الألوان السمة والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // التمييز 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // التمييز 4، أخف 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // التمييز 4، أخف 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // التمييز 4، أخف 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // التمييز 4، أغمق 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // التمييز 4، أغمق 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسمة وغيرها من الاستخدامات، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني فرعي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي فرعي)
* **+mj-ea** - خط النص الأساسي الآسيوي الشرقي (خط آسيوي شرقي فرعي)

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


يظهر لك هذا الكود C# كيفية تغيير خط سمة العرض:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية محددة مسبقًا ولكن يتم حفظ 3 فقط من هذه الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C# لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles] من فئة [FormatScheme]، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**دليل الفهرس**: يُستخدم 0 لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مجموعة أنماط. يتم دمج هذه المجموعات في 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles]، [LineStyles]، [EffectStyles]) من فئة [FormatScheme] يمكنك تغيير عناصر السمة (بمرونة أكبر من الخيارات في PowerPoint).

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

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الأساسي؟**

نعم. يدعم Aspose.Slides تجاوزات سمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الأساسي سليمة (من خلال [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

[Clone slides] مع الماستر إلى العرض المستهدف. هذا يحافظ على الماستر الأصلي، التخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعالة" بعد جميع الوراثة والتجاوزات؟**

استخدم "وجهات النظر الفعالة" في الـ API للسمة/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية بعد تطبيق الماستر وأي تجاوزات محلية.