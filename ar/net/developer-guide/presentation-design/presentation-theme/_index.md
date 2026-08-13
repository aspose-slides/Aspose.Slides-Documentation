---
title: إدارة سمات العرض التقديمي في .NET
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
description: "تحكم في سمات العرض التقديمي في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **مقدمة**

تعرف سمة العرض خصائص عناصر التصميم. عند اختيارك لسمة العرض، فأنت في الأساس تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من الألوان، [الخطوط](/slides/ar/net/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/net/presentation-background/)، والتأثيرات.

![مكونات-السمة](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة للسمة. لتتمكن من اختيار لون سمة جديد، توفر Aspose.Slides القيم تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/).

يكشف هذا الكود C# كيفية تغيير لون التركيز لسمة:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (لون [A=255, R=128, G=100, B=162])
}
```

للتوضيح الإضافي لعملية تغيير اللون، نقوم بإنشاء عنصر آخر ونُعيّن له لون التركيز (من العملية الأولية). ثم نغيّر اللون في السمة:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

يُطبق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على اللون الرئيسي للسمة (1)، تتشكل ألوان من لوحة الألوان الإضافية (2). يمكنك بعد ذلك تعيين هذه الألوان السمة والحصول عليها.

![ألوان-لوحة-الألوان-الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية  
**2** - ألوان من لوحة الألوان الإضافية.

يوضح هذا الكود C# عملية يتم فيها الحصول على ألوان لوحة الألوان الإضافية من اللون الرئيسي للسمة ثم استخدامها في الأشكال:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // التمييز 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // التمييز 4، أفتح 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // التمييز 4، أفتح 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // التمييز 4، أفتح 40%
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

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية:

`Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، تُرجع `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، التي تعرض الألوان المقابلة كـ:

`Dark1`، `Dark2`، `Light1`، و`Light2`.

الاختلاف هنا فقط في التسمية. هذه القيم تشير إلى نفس خانات ألوان السمة والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا توجد تحويلات ديناميكية بين `Text`/`Background` و `Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسميات يأتي من مصطلحات Microsoft Office. كانت الإصدارات القديمة من Office تستخدم `Dark 1` و`Light 1` و`Dark 2` و`Light 2`, بينما تُظهر الإصدارات الحديثة من الواجهة نفس الخانات كـ `Text 1` و`Background 1` و`Text 2` و`Background 2`.

## **تغيير خط السمة**

لتمكينك من اختيار الخطوط للسمة وتطبيقات أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني فرعي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط الجسم الآسيوي الشرقي (خط آسيوي شرقي فرعي)
* **+mj-ea** - خط الجسم الآسيوي الشرقي (خط آسيوي شرقي رئيسي)

يعرض هذا الكود C# كيفية تعيين الخط اللاتيني لعناصر السمة:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

يعرض هذا الكود C# كيفية تغيير خط سمة العرض:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُحددة مسبقًا لكن يتم حفظ 3 فقط من تلك الخلفيات في عرض تقديمي نمطي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C# لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/) يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

يعرض هذا الكود C# كيفية تعيين الخلفية لعرض تقديمي:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. الفهرس يبدأ من 1.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج تلك المصفوفات في 3 تأثيرات: خفيف، متوسط، ومكثف. على سبيل المثال، هذه النتيجة عندما تُطبق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles)) من الفئة [FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme) يمكنك تغيير عناصر السمة (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

يعرض هذا الكود C# كيفية تغيير تأثير السمة عن طريق تعديل أجزاء من العناصر:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **الأسئلة الشائعة**

### هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الرئيس؟

نعم. تدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، لذلك يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على سمة الرئيس غير متغيرة (من خلال [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/)).

### ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟

قم بـ[استنساخ الشرائح](/slides/ar/net/clone-slides/) مع الرئيس الخاص بها إلى العرض الهدف. هذا يحافظ على الرئيس الأصلي، التخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

### كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟

استخدم واجهات ["الفعّال"](/slides/ar/net/shape-effective-properties/) للموضوع/اللون/الخط/التأثير في API. تُعيد هذه القيم الخصائص النهائية التي تم حلها بعد تطبيق الرئيس وأي تجاوزات محلية.