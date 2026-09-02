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
description: "إدارة سمات العروض التقديمية في Aspose.Slides لـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع علامة تجارية متسقة."
---
## **مقدمة**

يعرف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات المدركة للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات في آنٍ واحد.

في Aspose.Slides، تتوفر سمة المستوى العرض من خلال الخاصية [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/masterthememanager/overridetheme/)، ويمكن للتخطيط تجاوز سمة الموروثة عبر [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)، ويمكن للشرائح الفردية القيام بنفس الشيء. عمليًا، يتم حل السمة الفعالة للشرائح من خلال سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل السمة شيوعًا: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر الكائن [MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/) سمة العرض الخاصة بـ[ColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/fontscheme/)، و[FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/formatscheme/). يكون فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

يعرض المثال التالي خصائص السمة الرئيسية ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعالة الموضح لاحقًا في هذه المقالة عندما تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص المدركة للسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/). عندما تقوم بتغيير الإدخال المقابل في سمة [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمة تُعيد حلها بناءً على القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

يعرض المثال التالي من البداية إلى النهاية إنشاء شكل يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يفتحه مرة أخرى، ويطبع لون التعبئة الفعلي:

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

نظرًا لأن المستطيل لا يزال مرتبطًا بـ`Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخرج PowerPoint تنوعات أفتح وأغمق من لون السمة عن طريق تطبيق تحويلات اللون. يتيح Aspose.Slides هذه التحويلات من خلال [ColorTransformOperation](https://reference.aspose.com/slides/ar/net/aspose.slides/colortransformoperation/).

![الألوان الأساسية للسمة والألوان الأفتح والأغمق التي تم إنشاؤها من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.

**2** - تنوعات أفتح وأغمق مُنتجة من ألوان السمة الرئيسية.

يعرض المثال التالي إنشاء ستة مستطيلات تعتمد على `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه التنوعات مبنية على لون السمة. إذا تغير `Accent4` لاحقًا، يتم إعادة حساب الألوان المحوّلة من القيمة الجديدة لـ`Accent4`.

### **تعيين قيم `SchemeColor` إلى فتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يعرّف [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/) نفس فتحات السمة كـ`Dark1`، `Light1`، `Dark2`، و`Light2`. التعيين ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا يتم تحويلها ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

يحتوي نظام خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر خصائص [FontScheme.Major](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (خط لاتيني ثانوي)
* `+mj-lt` - خط العنوان لاتيني (خط لاتيني رئيسي)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (خط شرق آسيوي ثانوي)
* `+mj-ea` - خط العنوان شرق آسيوي (خط شرق آسيوي رئيسي)

يعرض المثال التالي إنشاء عنوان يستخدم خط السمة اللاتيني الرئيسي وسطر نص أساسي يستخدم خط السمة اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف السمة لن يتبدل تلقائيًا عندما يتغير نظام خطوط السمة.

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملان شائعان، وكل منهما يحل مشكلة مختلفة.

### **الاحتفاظ بسمة المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض المستهدف باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة باستخدام [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاتّه والسمة المرتبطة معه معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات التي تقودها السمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة المستهدفة البقاء على الماستر والتخطيط الحاليين، ابدأ بتجاوز مستوى الشريحة من السمة المصدر. تنسخ الطرق [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initformatschemefrom/) المكوّنات الثلاث الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من قبل الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

يُطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيطات واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. يؤدي وجود عدد كبير من التجاوزات على مستوى الشريحة إلى صعوبة التنبؤ بتغييرات السمة العامة لاحقًا.

## **تحديث أنماط خلفية السمة**

يُخزن ملء خلفية السمة في [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مما هو مخزن فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج ملء السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة العرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.StyleIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/background/styleindex/) الحالي. يستخدم `StyleIndex` القيمة `0` عندما لا يكون هناك ملء سمة؛ والقيم الموجبة تشير إلى مراجع أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة ‎.NET‎ مباشرةً حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

يعرض المثال التالي عدد ملء الخلفية المتاح، يعيّن مرجع خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على مدخل السمة الذي يشير إليه الماستر وعلى أي تجاوزات خلفية في التخطيط أو مستوى الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تعديل خلفية الماستر تلك الشريحة. استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعامل `StyleIndex` كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
لمزيد من تنسيق الخلفية المباشر والوراثة، راجع [Presentation Background](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

تحتوي مجموعة تنسيق السمة على مجموعات منفصلة من [FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles/)، و[EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles/). غالبًا ما تحتوي سمات Office النموذجية على ثلاث مدخلات أساسية تتطابق بصريًا مع التنسيقات الخفيفة، المتوسطة، والشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C#، يكون فهرس المجموعة يبدأ من الصفر: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. فهارس مراجع النمط للشكل مفهوم منفصل، يُظهره [IShapeStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

يفحص المثال التالي وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يُفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط سمة أحمر، ويصبح ثالث نمط تعبئة سمة أخضر غابي صلب، ويحصل النمط الثالث للتأثير على ظل خارجي بمسافة 10 نقاط. لا يزال المظهر البصري الدقيق يعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعالة**

تخبرك كائنات السمة الخام بما تم تعريفه على مستوى معين. تُظهر القيم الفعالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). للخلفية، استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/)، وللتعبئة استخدم [FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/).

يعرض المثال التالي السمة الفعالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعالة لتشخيص الرسم، التحقق، والمقارنات. إذا فحصت فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/) الخاص بالشريحة وقم بتهيئة سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة السمات القائمة.

**ما هو الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستخدم [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) لاستنساخ الماستر، ثم [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) لاستنساخ الشريحة مع ذلك الماستر. هذا يبقي الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) لسمة الشريحة أو التخطيط، واستخدم الطرق المقابلة للبيانات الفعالة لكائنات التنسيق مثل [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) و[FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم التي تم حلها بعد تطبيق الوراثة والتجاوزات.