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
description: "إدارة سمات العرض التقديمي في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع علامة تجارية متسقة."
---
## **المقدمة**

موضوع العرض التقديمي يعرّف مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. الكائنات التي تدعم الموضوع تشير إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير الموضوع تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، يتوفر موضوع العرض على مستوى العرض من خلال خاصية [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للموضوع في مستويات أدنى. يمكن للماستر تجاوز موضوع العرض عبر [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/masterthememanager/overridetheme/)، ويمكن للتخطيط تجاوز موضوعه الموروث عبر [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)، ويمكن للشفرة الفردية القيام بالمثل. عملياً، يتم حل الموضوع الفعّال للشفرة عبر سلسلة الوراثة هذه: موضوع العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

الأقسام أدناه تُظهر أكثر سير عمل شائع للموضوع: فحص موضوع، تغيير الألوان والخطوط، نسخ أو تطبيق موضوع، تحديث أنماط الخلفية والتأثير، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص موضوع**

الكائن [MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/) يُظهر [ColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/fontscheme/)، و[FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/formatscheme/). فحص هذه المجموعات قبل تعديلها مفيد خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للموضوع ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزّنة في الموضوع:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس الموضوع الفعّال. افحص الماستر المرتبط بالشفرة، واستخدم سير عمل الموضوع الفعّال الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات على مستوى التخطيط أو الشريحة.

## **تغيير ألوان الموضوع**

التعبئات، الخطوط، والنصوص التي تدعم الموضوع يمكن أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون حسب القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون الموضوع.

المثال التالي من البداية إلى النهاية ينشئ شكلاً يستخدم `Accent4`، يغيّر لون الموضوع `Accent4` إلى الأحمر، يحفظ العرض، يعيده للفتح، ويطبع لون التعبئة الفعّال:

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

لأن المستطيل لا يزال مرتبطاً بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير الموضوع. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

PowerPoint يولّد متباينات أفتح وأتمنى من لون الموضوع عبر تطبيق تحولات لونية. Aspose.Slides يكشف هذه التحولات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - ألوان الموضوع الرئيسية.

**2** - المتباينات الأفتح والأتمنى المُنتجة من ألوان الموضوع الرئيسية.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبّق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه المتباينات لا تزال تستند إلى لون الموضوع. إذا تغير `Accent4` لاحقاً، تُعاد حساب الألوان المتحوّلة من القيمة الجديدة لـ `Accent4`.

### **تعيين قيم `SchemeColor` إلى فتحات `IColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يوضح [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/) نفس فتحات الموضوع كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الت mapping ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات الموضوع؛ ليست قيماً تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط الموضوع**

مخطط خطوط الموضوع يحتوي على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. خصائص [FontScheme.Major](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/minor/) تُظهر تلك المجموعات.

معرفات خطوط الموضوع المتوافقة مع PowerPoint يمكن استخدامها في تنسيق النص:

* `+mn‑lt` - خط النص الأساسي Latin (Minor Latin Font)
* `+mj‑lt` - خط العنوان Latin (Major Latin Font)
* `+mn‑ea` - خط النص الأساسي East Asian (Minor East Asian Font)
* `+mj‑ea` - خط العنوان East Asian (Major East Asian Font)

المثال التالي ينشئ عنواناً يستخدم خط الموضوع Latin الرئيسي، وسطر نص أساسي يستخدم خط الموضوع Latin الفرعي. ثم يغيّر خطوط الموضوع ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف موضوع لن يتبدّل تلقائياً عندما يتغيّر مخطط خطوط الموضوع.

مجموعات الخطوط الرئيسية والفرعية يمكن أن تحتوي أيضاً على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثعنا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض التقديمي، راجع [PowerPoint Fonts](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق موضوع**

هناك سيران شائعان، وكل منهما يحلّ مشكلة مختلفة.

### **الحفاظ على موضوع المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر والحفاظ على التصميم الأصلي، استنسخ الماستر المصدر إلى العرض الهدف عبر [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة عبر [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. هذا يُحمل الماستر، تخطيطاته، والموضوع المرتبط معاً.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالموضوع.

### **تطبيق قيم الموضوع على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على الماستر والتخطيط الحاليين، ابتدئ تجاوزاً على مستوى الشريحة من موضوع المصدر. طرق [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initformatschemefrom/) تنسخ المكوّنات الثلاثة الرئيسية للموضوع إلى التجاوز.

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

هذا يغيّر الموضوع المستخدم لتلك الشريحة دون تغيير الموضوع الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز موضوع على تخطيط**

تجاوز على مستوى التخطيط يطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/layoutslidethememanager/):

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

استخدم موضوع على مستوى الماستر أو العرض التقديمي عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدام تجاوز تخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدام تجاوز شريحة فقط للاستثناءات الحقيقية. التجاوزات الزائدة على مستوى الشريحة تجعل تغييرات الموضوع العامة لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية الموضوع**

تُخزن تعبئات خلفية الموضوع في [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المادية المخزّنة في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات الموضوع مع ألوان الموضوع ومراجع أنماط أخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزّنة و[Background.StyleIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/background/styleindex/) الحالي. `StyleIndex` يستخدم `0` لعدم وجود تعبئة موضوع؛ القيم الموجبة هي مراجع لأنماط خلفية الموضوع. هذا مختلف عن فهرسة مجموعة .NET مباشرةً، حيث يعني `[0]` العنصر الأول المخزّن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية موضوع إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على مدخل الموضوع الذي يشيره الماستر وعلى أي تجاوزات خلفية في التخطيط أو مستوى الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعتَبِر `StyleIndex` كفهرس مجموعة يبدأ من صفر. كما تجنّب ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات أنماط الموضوع خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثتها، راجع [Presentation Background](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات الموضوع**

مخطط تنسيق الموضوع يحتوي على مجموعات منفصلة لـ [FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles/)، و[EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles/). غالباً ما تحتوي موضوعات Office على ثلاث مدخلات أساسية تمثّل بصرياً التنسيقات الخفيفة، المتوسطة، والقوية، لكن يجب على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C#، يكون فهرس المجموعة يبدأ من صفر: `[0]` هو أول نمط مخزّن و`[2]` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، يُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapestyle/). تعديل نمط موضوع يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال ذات التنسيق المباشر قد تظل غير متغيّرة.

المثال التالي يتحقّق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح أول خط موضوع أحمر، وثالث تعبئة موضوع يصبح أخضر غابة صلب، وثالث نمط تأثير يكتسب ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية النهائية ما زالت تعتمد على الفتحات التي يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز الموضوع.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **قراءة قيم الموضوع الفعّالة**

كائنات الموضوع الخام تُظهر ما هو معرف على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). للخلفية، استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/)، وللتعبئة استخدم [FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ الموضوع الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة للتشخيص، التحقق، والمقارنات. إذا فحصت فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/)، قد تفوتك أي تجاوز ماستر أو تخطيط أو شريحة أو شكل يُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/) للشفرة وابدأ تجاوزه للموضوع. التغيير يبقى محلياً لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة الموضوعات الحالية لها.

**ما هي الطريقة الأكثر أماناً لنقل موضوع من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهر المصدر، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/). هذا يُبقي الماستر، التخطيطات، والموضوع معاً.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) للموضوع على شريحة أو تخطيط، واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) و[FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم التي تم حلها بعد تطبيق الوراثة والتجاوزات.