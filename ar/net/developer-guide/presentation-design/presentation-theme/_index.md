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
- سمة خارجية
- THMX
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للـ .NET لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **مقدمة**

تعرف سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والحدود والتأثيرات. الكائنات المتوافقة مع السمة تشير إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة أن يُحدّث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر الخاصية [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات سمة على مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/masterthememanager/overridetheme/)، ويمكن للتخطيط تجاوز سمة الماستر الموروثة عبر [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/overridetheme/)، ويمكن للشريحة الفردية القيام بالمثل. عملياً، يتم حل السمة الفعالة لشريحة ما عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل شائع للسمة: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر الكائن [MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/) مخطط السمة [ColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/fontscheme/)، و[FormatScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/mastertheme/formatscheme/). يُعد فحص هذه المجموعات قبل تعديلها مفيداً خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط يمكن أن يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويُبلغ عن عدد أنماط الخلفية، والملء، والحد، وتأثيرات السمة المخزنة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعالة الموضح لاحقاً في هذه المقالة عندما يكون هناك تجاوزات لتخطيط أو شريحة.

## **تغيير ألوان السمة**

يمكن للملء، والحد، والنص المتوافق مع السمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/). عندما تغيّر المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/)، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمي مع القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغيّر بتحديث لون السمة.

المثال التالي من الطرف إلى الطرف ينشئ شكلاً يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون الملء الفعلي:

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

لأن المستطيل ما زال مرتبطاً بـ`Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك الملء.

### **استخدام ألوان من اللوحة الإضافية**

يستمد PowerPoint المتغيرات الفاتحة والداكنة من لون السمة بتطبيق تحولات اللون. تُظهر Aspose.Slides هذه التحولات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/net/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المُولَّدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.  
**2** - المتغيرات الفاتحة والداكنة المُنتجة من الألوان الرئيسية للسمة.

المثال التالي يُنشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحولات اللمعان على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات ما زالت مستندة إلى لون السمة. إذا تغير `Accent4` لاحقاً، تُعاد حساب الألوان المُحوَّلة من القيمة الجديدة لـ`Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/icolorscheme/) نفس فتحات السمة كـ`Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط السمة**

يتضمن مخطط خطوط السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر الخصائص [FontScheme.Major](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)

المثال التالي يُنشئ عنواناً يستخدم الخط اللاتيني الرئيسي وخطاً أساسياً يستخدم الخط اللاتيني الفرعي. ثم يُغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتغيّر تلقائياً عندما يتغيّر مخطط خطوط السمة.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والفرعية أيضاً على تعيينات خطوط لأنظمة كتابة فردية، مثل السيران، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/net/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحلّ سير العمل أدناه مشكلات مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation.Masters](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/masters/)، التي تُنفِّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ ماستر شريحة جديد استناداً إلى الماستر المختار.  
2. تُطبق السمة الخارجية على الماستر الجديد.  
3. تُعيّن الماستر الجديد إلى جميع الشرائح التي كانت تعتمد سابقاً على الماستر المختار.  
4. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/) المُنشأ حديثاً.

المثال التالي يُطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر، يحفظ العرض، ويعيد فتح النتيجة:

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

سمة غير صالحة أو ملف تالف أو غير مدعوم قد يسبب [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/) أو أحد فروعه المرتبطة بالتنسيق. تحقّق من المسارات التي يُدخلها المستخدم، عالج فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد نجاح تطبيق السمة.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المختار فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها وسماها الحالية. تُحلّ الألوان، الخطوط، الملء، الحدود، الخلفيات، والتأثيرات المتوافقة مع السمة وفق السمة الخارجية. قد تظل الألوان، الخطوط، الملء والتنسيق الصريح غير متغيّرة. يمكن أن تتفوّق تجاوزات مستوى التخطيط أو الشريحة على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. للحصول على عرض وتصدير ثابتين، ثبّت الخطوط المطلوبة، وزِّدها عبر [مصادر الخطوط المخصصة](/slides/ar/net/custom-font/)، أو ضبط [استبدال الخطوط](/slides/ar/net/font-substitution/).

هذا سير عمل على مستوى ماستر مباشرة: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى شريحة أو تخطيط يدوياً.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عندما لا تكون الماستر المعني معروفاً مسبقاً، احصل عليه من شريحة تمثيلية عبر [ISlide.LayoutSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/layoutslide/) و[ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ilayoutslide/masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماسترهما ويطبق سمة خارجية مختلفة على كل مجموعة:

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

النداء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والنداء الثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح التابعة لأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/)، ثم انسخ الشريحة باستخدام [ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) والماستر المنسوخ. سيحمل ذلك الماستر وتخطيطاته والسمة المرتبطة معه معاً.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر وجهة غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات التي تقودها السمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان لابد من بقاء الشريحة المستهدفة على الماستر والتخطيط الحاليين، ابدئ تجاوز سمة على مستوى الشريحة من السمة المصدر. تنسخ الطرق [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/initformatschemefrom/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

يغيّر ذلك السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن للشريحة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/layoutslidethememanager/) الخاص بالتخطيط:

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

استخدم سمة على مستوى ماستر أو عرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة التصميم الأساسي نفسه، واستخدم تجاوز التخطيط عندما يحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة التغييرات العامة للسمة لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزَّن ملء خلفيات السمة في [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مما هو مخزن فعلياً في هذه المجموعة لأن الواجهة يمكنها دمج الملء السمي مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة العرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.StyleIndex](https://reference.aspose.com/slides/ar/net/aspose.slides/background/styleindex/). يستخدم `StyleIndex` القيمة `0` لعدم وجود ملء سمي؛ القيم الموجبة تشير إلى مراجع أنماط خلفية سميّة. هذا مختلف عن فهرسة المجموعة في .NET حيث يعني `[0]` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يُبلغ عن عدد ملء الخلفية المتوفر، يعيّن مرجع خلفية سمي للماستر الأول، ويحفظ العرض:

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

تعتمد النتيجة المرئية على السمة التي يشير إليها الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعتَبر `StyleIndex` كفهرس مجموعة يبدأ من الصفر. وتجنّب أيضًا ترميز رقم نمط من ملف واحد والافتراض بأنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/net/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة من [FillStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/linestyles/)، و[EffectStyles](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/formatscheme/effectstyles/). غالباً ما تتضمن السمات المكتبية ثلاث مدخلات رئيسية تتطابق بصرياً مع تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C#، يكون فهرس المجموعة يبدأ من الصفر: `[0]` هو أول نمط مخزن و`[2]` هو الثالث. مؤشرات مراجع نمط الشكل هي مفهوم منفصل، يُظهرها [IShapeStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط الملء الثالث، يُفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح نمط الخط السمي الأول أحمر، ونمط الملء السمي الثالث يصبح أخضر غابي صلب، ونمط التأثير الثالث يحصل على ظل خارجي بمسافة 10 نقاط. لا يزال النتيجة البصرية الفعلية تعتمد على الفتحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الخط والملء وإعدادات الظل](presentation-design_11.png)

## **تحديد ما إذا كان الملء الصلب الفعّال يستخدم لون سمة**

يمكن أن يُخزن الملء مباشرةً على كائن أو يُورث من فقرة أو تخطيط أو ماستر أو نمط سمة أو مستوى تنسيق آخر. استدعِ [IFillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformat/geteffective/) لتحويل تلك السلسلة إلى كائن ثابت [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/). أولاً تحقق من [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/filltype/). فقط عندما يكون `FillType.Solid` ينبغي قراءة خصائص الملء الصلب.

بالنسبة للملء الصلب، تُعيد [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) القيمة النهائية للـRGB بعد الوراثة والبحث في السمة وتطبيق تحويلات اللون. تُعيد [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) الفتحة المنطقية في [SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/schemecolor/) التي أنشأت اللون، مثل `Text1` أو `Accent6`. قيمة `SchemeColor.NotDefined` تعني أن الملء الصلب الفعّال ليس مبنياً على لون مخطط. في سير عمل حيث تكون الملء إما ألوان سمة أو ألوان RGB مباشرة، تُحدِّد هذه القيمة ملء RGB مباشر.

لا تستخدم قيمة [IColorFormat.SchemeColor](https://reference.aspose.com/slides/ar/net/aspose.slides/icolorformat/schemecolor/) المحلية وحدها لتصنيف الملء. على سبيل المثال، قد لا يحتوي جزء نص على قيمة مخطط محلية، لذا تكون قيمته `NotDefined`، بينما يَورِث ملءه الفعّال لون سمة ويُحل إلى `Text1` أو `Accent6`. على العكس، تُظهر `SolidFillSchemeColor` الفتحة المنطقية التي أنتجت اللون الفعلي، لكنها لا تُظهر ما إذا كانت تلك الفتحة جاءت من الكائن أو الفقرة أو التخطيط أو الماستر أو مستوى آخر من التسلسل الهرمي للتنسيق.

المثال التالي يُحمِّل عرضاً، يراجع كل ملء شكل وملء جزء نص، يطبع كل قيمة RGB نهائية والقيمة المرتبطة بالمخطط، ويحدد الملء الصلب الذي لن يتتبع تغييرات ألوان السمة:

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

الفرع `NotDefined` يُقدِّم قائمة تدقيق للملء الصلب الذي لن يستجيب لتغيّر فتحات ألوان السمة. راجع تلك الكائنات عندما يتوجب على العرض اتباع لوحة ألوان علامة تجارية جديدة. لا يزال قيمة الـRGB المبلغة تُظهر المظهر الحالي، بينما تُوضح قيمة المخطط ما إذا كان هذا المظهر مرتبطاً بالسمة.

الكائنات الفعالة هي snapshots. بعد تغيير سمة العرض أو تجاوز سمة أو أي تنسيق مُورَّث، استدعِ `GetEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعّالة**

الكائنات السمية الخام تُظهر ما تم تعريفه على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). للخلفية، استخدم [Background.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/background/geteffective/)، وللملء استخدم [FillFormat.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، والملء الأول للشكل من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثّر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) يعين فقط الشرائح التي تعتمد على الماستر المختار. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسماها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة بدون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محلياً لتلك الشريحة؛ تستمر باقي الشرائح في وراثة سماها الحالية.

**ما هي الطريقة الأكثر أماناً لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، انسخ الماستر المصدر إلى الوجهة ثم انسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/). يحافظ ذلك على الماستر، التخطيطات، والسمة معاً.

**كيف يمكنني الاطّلاع على القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) لسمة شريحة أو تخطيط، والطُرُق الفعّالة المقابلة لكائنات التنسيق مثل [Background.GetEffective] و[FillFormat.GetEffective]. تُعيد هذه الواجهات القيم المُحلَّة بعد تطبيق الوراثة والتجاوزات.