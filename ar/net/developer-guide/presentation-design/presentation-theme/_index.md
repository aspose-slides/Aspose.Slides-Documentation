---
title: إدارة أنماط العرض التقديمي في .NET
linktitle: نمط العرض التقديمي
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض التقديمي
- نمط الشريحة
- تعيين النمط
- تغيير النمط
- إدارة النمط
- لون النمط
- لوحة ألوان إضافية
- خط النمط
- نمط النمط
- تأثير النمط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحكم في أنماط العرض التقديمي في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
يحدد نمط العرض خصائص عناصر التصميم. عند اختيارك لنمط عرض، فإنك في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، يتألف النمط من ألوان، [الخطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/net/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون النمط**

يستخدم نمط PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على النمط. لتتمكن من اختيار لون نمط جديد، يوفر Aspose.Slides قيمًا ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/).

يعرض هذا الكود C# طريقة تغيير لون التمييز (accent) للنمط:

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

لتوضيح عملية تغيير اللون أكثر، ننشئ عنصرًا آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغيّر اللون في النمط:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون النمط من لوحة ألوان إضافية**

عند تطبيق تحولات الإضاءة على اللون الرئيسي للنمط (1)، تتشكل ألوان من لوحة الألوان الإضافية (2). يمكنك بعد ذلك تعيين تلك الألوان النمطية والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1** - ألوان النمط الرئيسة  
**2** - ألوان من لوحة الألوان الإضافية.

يعرض هذا الكود C# عملية الحصول على ألوان لوحة الألوان الإضافية من اللون الرئيسي للنمط ثم استخدامها في الأشكال:

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

### **ربط `SchemeColor` بألوان `IColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان النمط التالية: `Background1`, `Background2`, `Text1`, و `Text2`.

مع ذلك، تُعيد `Presentation.MasterTheme.ColorScheme` كائنًا من نوع [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، الذي يعرض الألوان المقابلة كالتالي: `Dark1`, `Dark2`, `Light1`, و `Light2`.

الفرق هنا فقط في التسمية. هذه القيم تشير إلى نفس مواضع ألوان النمط والتطابق ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و `Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان النمط.

يأتي هذا الاختلاف في التسمية من مصطلحات Microsoft Office. استخدمت إصدارات Office القديمة `Dark 1`، `Light 1`، `Dark 2`، و `Light 2`، بينما تعرض إصدارات الواجهة الحديثة نفس المواضع كـ `Text 1`، `Background 1`، `Text 2`، و `Background 2`.

## **تغيير خط النمط**

لتمكينك من اختيار الخطوط للنمط وغيرها من الأغراض، يستخدم Aspose.Slides هذه المعرفات الخاصة (المشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - الخط الأساسي اللاتيني (Minor Latin Font)
* **+mj-lt** - الخط الرئيسي للعنوان اللاتيني (Major Latin Font)
* **+mn-ea** - الخط الأساسي للآسيوي الشرقي (Minor East Asian Font)
* **+mj-ea** - الخط الرئيسي للآسيوي الشرقي (Major East Asian Font)

يعرض هذا الكود C# طريقة تعيين الخط اللاتيني لعنصر النمط:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

يعرض هذا الكود C# طريقة تغيير خط نمط العرض:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في مشاهدة [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية النمط**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية محددة مسبقًا، ولكن يتم حفظ 3 فقط من تلك الخلفيات الـ12 في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظك لعرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C# لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/) يمكنك إضافة أو الوصول إلى نمط الخلفية في نمط PowerPoint. 
{{% /alert %}}

يعرض هذا الكود C# طريقة ضبط الخلفية للعرض التقديمي:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في مشاهدة [خلفية PowerPoint](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تغيير تأثير النمط**

عادةً ما يحتوي نمط PowerPoint على 3 قيم لكل مجموعة أنماط. تُدمج تلك المجموعات في هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles)) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme) يمكنك تغيير عناصر النمط (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

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

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير القالب الرئيسي؟**

نعم. يدعم Aspose.Slides تجاوزات النمط على مستوى الشريحة، بحيث يمكنك تطبيق نمط محلي على تلك الشريحة فقط مع الحفاظ على النمط الرئيسي دون تغيير (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض تقديمي إلى آخر؟**

قم بـ[استنساخ الشرائح](/slides/ar/net/clone-slides/) مع القالب الخاص بها إلى العرض الهدف. هذا يحافظ على القالب الأصلي، التخطيطات، والنمط المرتبط بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**

استخدم "العروض الفعّالة" في واجهة برمجة التطبيقات ["effective" views](/slides/ar/net/shape-effective-properties/) للنمط/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية المحلولة بعد تطبيق القالب الرئيسي وأي تجاوزات محلية.