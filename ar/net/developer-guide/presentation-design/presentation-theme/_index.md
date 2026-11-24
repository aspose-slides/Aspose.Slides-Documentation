---
title: إدارة سمات العروض التقديمية في .NET
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/net/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- سمة خارجية
- THMX
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
description: "تحكم في سمات العروض التقديمية في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والخطوط والتأثيرات. تشير الكائنات الواعية بالسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر خاصية [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة على مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/)، ويمكن للتخطيط تجاوز سمة الماستر الموروثة عبر [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)، ويمكن للشرائح الفردية القيام بالمثل. عمليًا، يتم حل السمة الفعالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

الأقسام أدناه تُظهر أكثر سير عمل شائع للسمة: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

الكائن [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) يعرض [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/)، و[FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) الخاصة بالسمة. فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يتفاوت.

المثال التالي يقرأ خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية، والملء، والخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماستر، لا تفترض أن كل شريحة لها نفس السمة الفعالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعالة الموضح لاحقًا في هذه المقالة عندما تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

الملء، الخطوط، والنصوص الواعية بالسمة يمكن أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا يتم تغييرها بواسطة تحديث لون السمة.

المثال الشامل التالي ينشئ شكلًا يستخدم `Accent4`، يغير لون السمة لـ `Accent4` إلى الأحمر، يحفظ العرض، يعيده فتحه، ويطبع لون الملء الفعال:

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

لأن المستطيل ما زال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على ذلك الملء.

### **استخدام الألوان من لوحة الألوان الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون السمة بتطبيق عمليات تحويل اللون. يتيح Aspose.Slides هذه التحويلات عبر [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الأفتح والأغمق المولدة من لوحة الألوان الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات قائمة على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يعرض [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي سمة الخطوط على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تعرض خصائص [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي للنص المعقّد (Minor Complex Script Font)
* `+mj-cs` - خط العنوان للنص المعقّد (Major Complex Script Font)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وخطًا أساسيًا يستخدم خط السمة اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتبدل تلقائيًا عندما تتغير سمة الخطوط.

يمكن لمجموعات الخطوط الرئيسية والثانوية أيضًا أن تحتوي على خرائط خطوط لأنظمة كتابة فردية، مثل السيريليكية، العربية، اليابانية، الجورجية، والثعاني. لفحص، إضافة، استبدال، أو إزالة هذه الخرائط، راجع [Script-Specific Theme Fonts](/slides/ar/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العروض، راجع [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

### **حل مراجع خطوط السمة**

عند فحص النص، قد يحتوي [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) على مرجع سمة مثل `+mn-lt` بدلًا من اسم عائلة الخط. استدعِ [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) مع [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) المناسب لحل ذلك المرجع. تحدد البادئات `+mj` و`+mn` مجموعات الخطوط الرئيسة والثانوية؛ تحدد اللاحقات `-lt`، `-ea`، و`-cs` الخطوط اللاتينية، الآسيوية الشرقية، والنص المعقّد على التوالي.

احصل على السمة الفعالة عبر [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) على الكائن الذي تنطبق سمة عليه النص المفحوص. للنص العادي على شريحة، استخدم `slide.CreateThemeEffective()` لتشمل السمة الموروثة لتلك الشريحة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر بحد ذاته، استخدم سمةه الفعالة. لا تفترض أن سمة أول ماستر تنطبق على كل الشرائح.

المثال التالي ينشئ جزء نص يمرجع صراحةً الخط اللاتيني الثانوي. يهيئ مخطط خطوط الشريحة عبر [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) ويضبط عائلتي الخطوط اللاتينية الرئيسة والثانوية إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

الناتج هو `+mn-lt -> Calibri` متبوعًا بـ `Verdana -> Verdana`. يظل المرجع المخزن دون تغيير، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا استخدم الجزء `+mj-lt`، فسيتم حله إلى `Arial` في هذه السمة.

يُحدد حل مرجع السمة عائلة الخط التي حددتها السمة. لا يتحقق من توفّر الخط ولا يحدد ملف الخط المستخدم نهائيًا بعد الاستبدال أو اللجوء إلى بدائل الحروف أثناء العرض. راجع [Font Selection Sequence](/slides/ar/net/font-selection-sequence/) و[Font Substitution](/slides/ar/net/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق سمة**

تحل سير العمل أدناه مشكلات مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. حدد الماستر من تجميع [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) الذي يطبق [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ ماستر شريحة جديد بناءً على الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد مسبقًا على الماستر المحدد.
1. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) المُنشأ حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر، يحفظ العرض، ويعيد فتح النتيجة:

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

قد تتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) أو أحد الفئات الفرعية المتعلقة بالتنسيق. تحقق من صحة المسارات التي يقدمها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بالماسترات والسيمات الحالية. تُحل ألوان، خطوط، ملء، خطوط، خلفيات، وتأثيرات واعية بالسمة مقابل السمة الخارجية. قد تبقى الألوان، الخطوط، الملء، وتنسيقات الصيغة الصريحة غير متغيّرة. يمكن لتجاوزات المستوى التخطيطي وتجاوزات المستوى الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. لضمان عرض وتصدير ثابتين، ثبت الخطوط المطلوبة، وفّرها من خلال [مصادر الخطوط المخصصة](/slides/ar/net/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/net/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد ماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) و[ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء ينشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهما ويطبق سمة خارجية مختلفة على كل مجموعة:

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

النداء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والنداء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. ينقل هذا الماستر وتخطيطاته والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضل عندما يجب أن تبدو الشريحة المصدرية كما هي في الوجهة. مجرد استنساخ المحتوى إلى ماستر هدف غير مرتبط قد يغيّر ألوان، خطوط، خلفيات، وتأثيرات مدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على الماستر والتخطيط الحاليين، ابدأ تجاوزًا على مستوى الشريحة من سمة المصدر. تنسخ الطرق [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

يُغيّر ذلك السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استعمال نفس طرق التهيئة عبر مدير سمة التخطيط [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة على مستوى العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج مجموعة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة تغييرات السمة العالمية لاحقًا أكثر صعوبة في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزن ملء خلفيات السمة في [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مما هو مخزن فعليًا في هذا التجميع لأن الواجهة يمكنها دمج ملء السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجميع المخزن و[Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) الحالي. يستخدم `StyleIndex` القيمة `0` لعدم وجود ملء سمة؛ القيم الموجبة هي مراجع أنماط خلفية السمة. هذا مختلف عن فهرسة التجميع .NET مباشرةً، حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يبلغ عن عدد ملء الخلفية المتاحة، يعيّن مرجع خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على مدخل السمة المشار إليه من قبل الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، فقد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لاTreat `StyleIndex` كفهرس تجميع يبدأ من الصفر. تجنب أيضًا ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على تجميعات منفصلة لـ[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/)، و[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). غالبًا ما تحتوي سمات Office على ثلاثة مداخل نمط رئيسية تمثل بصريًا تنسيق دقيق، متوسط، ومكثف، لكن ينبغي على الشيفرة فحص كل تجميع بدلاً من افتراض عدد ثابت.

![تأثيرات سمة دقيقة، متوسطة، ومكثفة مطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في C#، يكون فهرس التجميع صفريًا: `[0]` هو النمط الأول المخزن و`[2]` هو الثالث. فهارس مراجع النمط للشكل مفهوم منفصل، يتم عرضه عبر [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مداخل الأنماط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط ملء، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح أول خط سمة سمةً باللون الأحمر، ويصبح ثالث ملء سمةً أخضرًا غامقًا صلبًا، ويكتسب ثالث تأثير سمةً ظلًا خارجيًا بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على أي فترات نمط يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الخط، الملء، وإعدادات الظل](presentation-design_11.png)

## **اختيار أنماط ملء وخط سمة لشكل**

يمكن للشكل اختيار ملءه وحدوده بشكل مستقل عبر [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) و[LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). لكل من الخاصيتين، الفهرس `1` يختار أول مدخل في التجميع السمة المقابل (`FillStyles[0]` أو `LineStyles[0]`)، والفهرس `2` يختار المدخل الثاني.

المثال التالي يهيء نمطي ملء (ذهب وأزرق سماوي) ونمطي خط (أزرق داكن بـ6 pt وأحمر داكن بـ12 pt) في السمة الافتراضية لعرض جديد. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| الأنماط الأولية | تغيير الحد الأيمن | تحرير أول ملء سمة |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية مع حدود رقيقة زرقاء داكنة متطابقة](theme-style-initial.png) | ![المستطيل الأزرق السماوي الآن له حد سميك أحمر داكن](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا الحدين دون تغيير](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر حدود المستطيل الأيمن فقط. تعديل أول ملء سمة يحدّث كل شكل يستخدمه. هنا، يتحول المستطيل الأيسر إلى اللون الأخضر فقط.

على شكل موجود، يمكن للون ملء محلي، لون خط، أو عرض خط أن يتجاوز ذلك الجزء من نمط السمة. إذا لم يطرأ أي تأثير مرئي عند تغيير فهرس النمط، فافحص [التنسيق المباشر](/slides/ar/net/shape-formatting/) للشكل.

## **تحديد ما إذا كان ملء صلب فعال يستخدم لون سمة**

يمكن أن يُخزّن الملء مباشرةً على كائن أو يُورث من فقرة، أو تخطيط، أو ماستر، أو نمط سمة، أو مستوى تنسيق آخر. استدعِ [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) لحل تلك السلسلة إلى [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولًا تحقق من [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). فقط عندما تكون `FillType.Solid` يجب قراءة خصائص الملء الصلب.

لملء صلب، تُرجع [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) القيمة النهائية RGB بعد الوراثة، وإطلاع السمة، وتطبيق تحويلات اللون. تُرجع [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) الفتحة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن الملء الصلب الفعّال ليس مبنيًا على لون مخطط. في سير عمل حيث تكون الملء إما ألوان سمة أو ألوان RGB مباشرة، تحدد هذه القيمة ملء RGB مباشر.

لا تستخدم قيمة [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) المحلية وحدها لتصنيف ملء. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط محدد محليًا، لذا تكون قيمته المحلية `NotDefined`، بينما يرث ملءه الفعّال لون سمة ويحل إلى `Text1` أو `Accent6`. بالمقابل، يخبرك `SolidFillSchemeColor` أي فتحة سمة منطقية أنتجت اللون الفعّال، لكنه لا يخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر من تسلسل التنسيق.

المثال التالي يحمل عرضًا، يدقق كل ملء أشكال وملء أجزاء النص، يطبع كل قيمة RGB نهائية واللون المخطط المرتبط، ويُعلِّم الملء الصلب الذي لن يتتبع تغييرات ألوان السمة:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

الفَرع `NotDefined` يقدم قائمة تدقيق للملء الصلب الذي لن يستجيب لتغييرات فتحات ألوان السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيم RGB المبلغ عنها تظهر المظهر الحالي، بينما يوضح قيمة المخطط ما إذا كان ذلك المظهر مرتبطًا بالسمة.

كائنات الصيغة الفعّالة هي لقطات. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق موروث، استدعِ `GetEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعالة**

تُظهر كائنات السمة الخام ما هو معرف على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). للخلفية، استخدم [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/)، وللملء استخدم [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ السمة الفعالة، الخلفية، وملء الشكل الأول من شريحة:

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

استخدم البيانات الفعالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق سمة خارجية على كل الشرائح في العرض؟**

لا. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) يعيد تعيين فقط الشرائح التي تعتمد على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسيماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) للشريحة وابدأ سمة تجاوزها. يظل التغيير محليًا لتلك الشريحة؛ تواصل الشرائح الأخرى وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). هذا يحافظ على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) لسمة شريحة أو تخطيط والطُرق المقابلة للبيانات الفعالة لكائنات الصيغة مثل [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) و[FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). تُعيد هذه الـ API القيم المحلولة بعد تطبيق الوراثة والتجاوزات.