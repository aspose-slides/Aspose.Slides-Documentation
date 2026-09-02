---
title: إدارة سمات العروض التقديمية في .NET
linktitle: نمط العرض
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords:
- نمط PowerPoint
- نمط العرض التقديمي
- نمط الشريحة
- تعيين نمط
- تغيير نمط
- إدارة النمط
- نمط خارجي
- THMX
- لون النمط
- لوحة إضافية
- خط النمط
- نمط التصميم
- مؤثر النمط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع حفظ الهوية البصرية المتناسقة."
---
## **المقدمة**

يحدد نمط العرض التقديمي مجموعة منسقة من الألوان والخطوط وأنماط الخلفيات والتعبئات والخطوط والمؤثرات. تُشير الكائنات المدركة للنمط إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، بحيث يمكن لتغيير النمط أن يُحدّث العديد من الكائنات مرة واحدة.

في Aspose.Slides، يتوفر نمط العرض على مستوى العرض من خلال الخاصية [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/). يمكن للعرض أيضاً أن يحتوي على تعديلات للنمط على مستويات أدنى. يمكن للماستر أن يتجاوز نمط العرض عبر [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/masterthememanager/overridetheme/)، ويمكن لتصميم التخطيط أن يتجاوز النمط الموروث عبر [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)، ويمكن للشريحة الفردية أن تفعل ذلك كذلك. عملياً، يتم حل النمط الفعّال لشريحة ما من خلال سلسلة الوراثة هذه: نمط العرض، تعديل الماستر، تعديل التخطيط، وتعديل الشريحة.

![مكونات النمط: الألوان، الخطوط، أنماط الخلفية، والمؤثرات](theme-constituents.png)

الأقسام أدناه توضح أكثر سير عمل شائع للنمط: فحص النمط، تغيير الألوان والخطوط، نسخ أو تطبيق نمط، تحديث أنماط الخلفية والمؤثرات، وقراءة القيم الفعّالة بعد حل الوراثة والتعديلات.

## **فحص النمط**

الكائن [MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/) يُظهر [ColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/fontscheme/)، و[FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/formatscheme/). فحص هذه المجموعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات النمط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للنمط ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والمؤثرات المخزنة في النمط:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس النمط الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل النمط‑الفعّال الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تعديلات على التخطيط أو الشريحة.

## **تغيير ألوان النمط**

يمكن للتعبئات، الخطوط، والنصوص المدركة للنمط أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/). عندما تُغيّر المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، تُطبق جميع الكائنات التي لا تزال تشير إلى ذلك اللون على القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتأثر بتحديث لون النمط.

المثال الشامل التالي ينشئ شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في النمط إلى الأحمر، يحفظ العرض، يعيده مرة أخرى، ويطبع لون التعبئة الفعّال:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير النمط. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات المستقبلية على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

‏PowerPoint يُشتق المتغيّرات الفاتحة والداكنة من لون النمط بتطبيق تحويلات لونية. Aspose.Slides يُظهر هذه التحويلات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/net/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للنمط والألوان الفاتحة والداكنة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان النمط الرئيسية.  
**2** - المتغيّرات الفاتحة والداكنة المنتجة من ألوان النمط الرئيسية.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبّق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

تظل هذه المتغيّرات مستندة إلى لون النمط. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يقدّم [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/) نفس الفتحات كنصوص `Dark1`، `Light1`، `Dark2`، و`Light2`. الترابط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات النمط؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط النمط**

يتضمن مخطط خطوط النمط مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص العادي. الخاصيتان [FontScheme.Major](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/minor/) تُظهران هاتين المجموعتين.

يمكن استخدام مُعرّفات خطوط النمط المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص العادي لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط النص العادي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط النمط اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط النمط اللاتيني الفرعي. ثم يغيّر خطوط النمط ويحفظ النتيجة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

العنوان يتبع الخط الرئيسي والنص العادي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلًا من مُعرّف النمط لن يتغيّر تلقائيًا عند تغيير مخطط خطوط النمط.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والفرعية أيضًا على تعيينات خطوط للأنظمة الكتابية الفردية، مثل السريليانية والعربية واليابانية والجورجية والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط النمط حسب النص البرمجي](/slides/ar/net/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض التقديمي، انظر [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق نمط**

تُحلّ سير العمل أدناه مشكلات مختلفة متعلقة بالنمط.

### **تطبيق نمط خارجي على الشرائح التابعة للماستر**

استخدم [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف نمط PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. حدد الماستر من مجموعة [Presentation.Masters](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/masters/) التي تنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف النمط إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة استنادًا إلى الماستر المحدد.
1. تُطبق النمط الخارجي على الماستر الجديد.
1. تُعيد تعيين الماستر الجديد لجميع الشرائح التي كانت تعتمد على الماستر المحدد سابقًا.
1. تُعيد الكائن [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يُطبق نمطًا خارجيًا على الشرائح التي تعتمد على الماستر الأول، يحفظ العرض، ويعيد فتح النتيجة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

قد يتسبب نمط غير صالح أو معطوب أو غير مدعوم في حدوث [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/) أو أحد الفئات الفرعية المتعلقة بالتنسيق. تحقق من صحة المسارات التي يُدخلها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق النمط بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها ونماذجها الحالية. تُحلّ الألوان والخطوط والتعبئات والخطوط الخلفية والمؤثرات المدركة للنمط وفقًا للنمط الخارجي. قد تظل الألوان والخطوط والتعبئات المعيّنة مباشرة دون تغيير. يمكن أن تتفوّق تعديلات المستوى التخطيطي أو المستوى الشريحة على القيم الموروثة من الماستر الجديد.

قد يشير النمط إلى خطوط غير متوفرة في بيئة التشغيل. لضمان عرض وتصدير متسق، ثبّت الخطوط المطلوبة، أو وفّرها عبر [مصادر خطوط مخصصة](/slides/ar/net/custom-font/)، أو ضبط [بدائل الخطوط](/slides/ar/net/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: الطريقة تقبل مسار ملف `.thmx` ولا تتطلب إنشاء تعديلات على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق أنماط خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصله من شريحة تمثيلية عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/) و[ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي نمط لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويُطبق نمطًا خارجيًا مختلفًا على كل مجموعة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

الاستدعاء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على نمط المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر مع الحفاظ على التصميم الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. هذا يُنقل الماستر وتخطيطاته والنمط المرتبط به معًا.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية كما هي في الوجهة. مجرد استنسخ المحتوى على ماستر هدف غير مرتبط قد يُغيّر الألوان والخطوط والخلفيات والمؤثرات المدفوعة بالنمط.

### **تطبيق قيم النمط على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، ابدأ بتعديل محلي على مستوى الشريحة من النمط المصدر. تُنسخ طرق [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للنمط إلى التعديل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

يُغيّر هذا النمط المستخدم لتلك الشريحة دون تعديل النمط الموروث للشرائح الأخرى. لإزالة التعديل المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تعديل نمط على تخطيط**

تعديل على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لديها تعديل خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

استخدم نمطًا على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في التصميم الأساسي ذاته، واستخدم تعديل تخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تعديل شريحة فقط للحالات الاستثنائية الحقيقية. التعديلات الزائدة على مستوى الشريحة تجعل تغييرات النمط العامة في المستقبل أصعب في التنبؤ.

## **تحديث أنماط خلفية النمط**

تُخزن تعبئات خلفية النمط في [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات النمط مع ألوان النمط ومراجع الأنماط الأخرى.

![معرض أنماط الخلفية في PowerPoint لنمط عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.StyleIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/background/styleindex/) الحالي. يستخدم `StyleIndex` القيمة `0` لعدم وجود تعبئة نمطية؛ القيم الموجبة تُشير إلى مراجع أنماط خلفية النمط. هذا يختلف عن فهرسة مجموعة .NET نفسها، حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية نمطي إلى الماستر الأول، ويحفظ العرض:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

النتيجة الظاهرة تعتمد على مدخل النمط المُشير إليه من قبل الماستر وأي تعديلات خلفية على مستوى التخطيط أو الشريحة. إذا كانت الشريحة تستخدم خلفية خاصة بها، قد لا يغيّر تعديل خلفية الماستر فقط تلك الشريحة. استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تعامل `StyleIndex` كفهرس مجموعة يبدأ من الصفر. وتجنب أيضًا ترميز رقم نمط من ملف واحد والافتراض أن له نفس المظهر في ملف آخر؛ تعريفات نمط العرض خاصة بالعرض نفسه.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [خلفية العرض](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تحديث مؤثرات النمط**

يحتوي مخطط تنسيق النمط على مجموعات منفصلة من [FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles/)، و[EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles/). غالبًا ما تحتوي أنماط Office على ثلاثة مدخلات رئيسية تُطابق بصريًا تنسيقات دقيقة، متوسطة، ومكثفة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![مؤثرات النمط الدقيقة، المتوسطة، والمكثفة المطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C#، يكون فهرس المجموعة بصفر: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، يُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapestyle/). تعديل نمط النمط يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات الأنماط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط مؤثر، ويحفظ النتيجة:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط النمط أحمر، ويصبح ثالث نمط تعبئة النمط أخضر غامق صلب، ويضيف الثالث ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز النمط.

![أنماط مؤثرات النمط بعد تغيير خط وتعبئة وإعدادات الظل](presentation-design_11.png)

## **قراءة قيم النمط الفعّالة**

تُظهر كائنات النمط الأولية ما هو معرف على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتعديلات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). للخلفية، استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/)، وللتعبئة استخدم [FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ النمط الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/)، قد تفوت تعديلًا على مستوى ماستر أو تخطيط أو شريحة أو شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق نمط خارجي على كل شريحة في العرض؟**

لا. تقوم [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) بإعادة تعيين الشرائح التي تعتمد فقط على الماستر المختار. الشرائح التي تستخدم ماسترات أخرى تحتفظ بأنماطها الحالية.

**هل يمكنني تطبيق نمط على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/) الخاص بالشريحة وابدأ تعديل النمط المحلي. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة أنماطها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل نمط من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة ثم استنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/). يضمن ذلك الحفاظ على الماستر والتخطيطات والنمط معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتعديلات؟**

استخدم [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) لنمط شريحة أو تخطيط، واستخدم الطرق الفعّالة المقابلة لكائنات التنسيق مثل [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) و[FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم التي تم حلها بعد تطبيق الوراثة والتعديلات.