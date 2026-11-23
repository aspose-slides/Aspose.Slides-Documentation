---
title: تنسيق نص العرض التقديمي في .NET
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/net/text-formatting/
keywords:
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

هذا المقال يوضح كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. يغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

ما لم يذكر غير ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو صندوق نص، والفقرة الأولى تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاء غليظة تستخدم التنسيق الفعّال، بما في ذلك تنسيق الغليظة الموروث:

![نص عينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير نمطي وتظليلها، راجع [Search and Replace Text](/slides/ar/net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التمييز الافتراضي للفقرة، أو استخدم [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) لأجزاء النص الفردية.

المثال التالي يعيّن تمييز رمادي فاتح كافتراضي للفقرة الأولى. ألوان التمييز الصريحة على الأجزاء الفردية تتفوق على هذا الافتراضي:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ضبط لون التمييز للفقرة بالكامل.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

الكود أدناه يوضح كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط الغليظ**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تعيين لون التمييز لجزء النص.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذاة إلى اليسار، إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ضبط محاذاة الفقرة إلى الوسط.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) لمحاذاة عمودية لأجزاء النص ذات أحجام خطوط مختلفة داخل سطر. ينطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر من سطورها.

المثال التالي يخلق أربعة صناديق نص مسماة على شريحة واحدة. كل فقرة تحتوي على نفس النص بحجم 18 و36 و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، يعطل الملاءمة التلقائية واللف، ويحافظ على إطارات النص كبيرة بما يكفي لسطر واحد.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

النتيجة:

![مقارنة محاذاة Baseline وTop وCenter وBottom مع أحجام خطوط مختلطة](font_alignment.png)

محاذاة الخط تعتمد على مقاييس الخط، لذلك قد لا تتطابق حواف الحروف الفردية تماماً. يتضمن المثال حرفاً كبيراً وحرفاً هابطاً لتوضيح الفرق بين محاذاة القاعدة والسفلي. تتأثر النتيجة بتوافر الخطوط والاستبدال، الأحرف المستخدمة، واختلاف أحجام الخطوط. أبعاد الإطار، الهوامش، تباعد الأسطر، اللف، والملاءمة التلقائية تؤثر أيضاً على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)، الذي يتحكم في محاذاة الفقرة الأفقية، و[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)، الذي يحدد موضع كتلة النص عمودياً داخل الشكل. تنسيق الفوقية والسطحية عبر [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) يغير موضع الأجزاء الفردية نسبياً إلى القاعدة بدلاً من تعيين محاذاة الخط لأسطر الفقرة.

## **تعيين الشفافية للنص**

تتحكم شفافية النص عبر مكوّن ألفا للون المعين إلى [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

الكود أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين تعبئة سوداء شبه شفافة للنص.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغليظ**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تعيين شفافية جزء النص.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) لتكبير أو تقليص التباعد بين الأحرف في صندوق نص. تضيف الأمثلة 3 نقاط تباعد؛ القيم السالبة تقرّب النص.

الكود C# التالي يوضح كيفية تكبير تباعد الأحرف في **الفقرة بأكملها**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود أدناه يوضح كيفية تكبير تباعد الأحرف في **أجزاء النص ذات الخط الغليظ**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
        portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل Kerning للخطوط المحددة**

في بعض الحالات قد يبدو النص المصدّر بواسطة Aspose.Slides أكثر ضيقاً قليلاً من النص نفسه في PowerPoint. يحدث ذلك لأن PowerPoint قد يتجاهل بيانات kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة وتم تفعيل kerning في إعدادات PowerPoint.

لتقريب المخرجات المصدّرة من عرض PowerPoint في مثل هذه الحالات، يمكنك تعطيل kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويضع حدًا بقدره 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطّل kerning للأجزاء المطابقة التي يقل حجم خطها عن 100 نقطة:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

بالنسبة للنص المطابق تحت الحد، يمنع هذا الإعداد kerning ويمكن أن يساعد في محاذاة مخرجات Aspose.Slides مع عرض PowerPoint البصري للخطوط المتأثرة بهذا السلوك المحدد لـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

المثال التالي يعين الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع غليظ، مائل، وتسطير منقط. التنسيق الصريح على الأجزاء الفردية يتفوق على هذه القيم الافتراضية.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين خصائص الخط للفقرة.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

المثال التالي يطبق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال غليظًا:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // تعيين خصائص الخط لجزء النص.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **التحكم في تطبيع ارتفاع النص**

استخدم [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) عند إعادة إنتاج طباعة القالب أو فحص اختلافات ارتفاع الأحرف. في PowerPoint، يؤدي تمكين التطبيع إلى تمديد أو ضغط الأحرف عمودياً لتمنحها ارتفاعاً ظاهرياً موحداً داخل جزء النص. لا يضمن ذلك تساوي ارتفاع النص عبر خطوط مختلفة.

اضبط الخاصية إلى [NullableBool.True أو False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) لتمكين أو تعطيل التطبيع صراحة. `NullableBool.NotDefined` يترك الإعداد المحلي غير محدد بحيث يرث الجزء قيمته، مثالاً من [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) للفقرة. لا يعني ذلك `False`. استخدم [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) واقرأ [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) للحصول على القيمة البوليانية المحسوبة.

المثال التالي يتطلب تثبيت **Arial**. يخلق كتلتين نصيتين تحتويان على نفس الأحرف الكبيرة، الصغيرة، الأحرف الهابطة، والحروف ذات اللواحق عند 54 نقطة. تمكّن الفقرتان التطبيع افتراضياً. الجزء العلوي يعطل التطبيع صراحةً؛ الجزء السفلي يرثه. أبعاد الإطار، الهوامش، وتباعد الفقرات متطابقة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على مقارنة ثابتة. يطبع المثال `False: False` و`NotDefined: True`، ثم يحفظ "text_height_normalization.pptx".

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

المقارنة أدناه تم استخراجها من العرض المحفوظ. الصف العلوي لديه التطبيع معطل (`False`); الصف السفلي يرث الإعداد المفعّل (`NotDefined` → `True`). احرص على تثبيت Arial لتكرار هذه المظهر.

![نص Arial بحجم 54 نقطة مع التطبيع معطل أعلى وموروث مفعّل أسفل](text_height_normalization.png)

التطبيع يغيّر ارتفاع الأحرف دون تعديل قيمة [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) للفقرة في تباعد الأسطر، بينما يتحكم [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) لإطار النص في كيفية تعديل النص أو حاويته لتناسب. تخدم هذه الإعدادات أغراضاً مختلفة ويمكن أن تؤثر على التخطيط الكلي بصورة مستقلة. لمزيد من المعلومات حول تنسيق الفقرات والوراثة، راجع [Manage Paragraph](/slides/ar/net/manage-paragraph/).

## **تطبيق وإزالة الخط المشطوب**

استخدم [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) على جزء نص لعرض تصحيحات أو مصطلحات ملغاة أو أسعار سابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType.Single أو Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) لسطر أو سطرين عبر النص.

لإزالة الخط المشطوب، عيّن `TextStrikethroughType.None`. هذا يعطل التأثير صراحةً حتى لو كان التنسيق المحيط يحدد الخط المشطوب. بالمقابل، `TextStrikethroughType.NotDefined` يترك الإعداد المحلي غير معرف، مما يسمح للجزء بوراثة التنسيق، مثالاً من الفقرة. لا يضمن ذلك إزالة الخط المشطوب. استخدم [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال التالي يخلق ثلاثة مقارنات أسعار. لكل فقرة أجزاء منفصلة للعلامة، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يطبق ثم يزيل الخط المشطوب؛ الصفوف الأخرى تحتفظ بخط مشطوب واحد أو مزدوج. تغيير هذه الخاصية يحافظ على النص وتنسيقه الآخر، بما في ذلك غليظ السعر السابق.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// تطبيق خط مشطوب، ثم إزالته صراحةً من السعر السابق الأول.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

النتيجة، من الأعلى إلى الأسفل: بدون خط مشطوب، خط مشطوب واحد، وخط مشطوب مزدوج.

![الأسعار السابقة بدون خط مشطوب، بخط مشطوب واحد، وبخط مشطوب مزدوج](strikethrough.png)

## **تعيين دوران النص**

استخدام [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) لتعيين اتجاه نص مسبق داخل شكل.

المثال التالي يعيّن اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس عقارب الساعة**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

النتيجة:

![دوران النص](text_rotation.png)

## **عرض الأرقام جنباً إلى جنب في النص العمودي**

لإبقاء رقم مكوّن من رقمين معاً في تسمية يابانية عمودية، ضع كلا الرقمان في جزء نص واحد واضبط [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) على ذلك الجزء. يستخدم المثال [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) وخط MS Gothic بحجم 40 نقطة لكل من التسمية. يختلف فقط قيمة [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) المعينة للجزء الرقمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

في PowerPoint، تُظهر التسمية اليسرى (`True`) الأرقام في وضعية رأسية وجانبية بين 和 و 年. في التسمية اليمنى (`False`)، يتم تدوير الزوج 90 درجة باتجاه عقارب الساعة. الأحرف اليابانية المحيطة تظل رأسية في كلتا التسميتين.

![مقارنة PowerPoint لتسميات التاريخ العمودية بأرقام رأسية على اليسار وأرقام مائلة على اليمين.](vertical_date.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

الكود أدناه يدور إطار النص 3 درجات باتجاه عقارب الساعة داخل الشكل:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستعمل هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في تقطيع الأسطر**

قواعد تقطيع أسطر الفقرة مفيدة في كتل نصية ضيقة وعروض تمزج بين النص اللاتيني والنص الشرقي الآسيوي. تنتمي الخصائص التالية إلى [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)، لذا فهي تطبق على الفقرة بأكملها:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) يتحكم في قواعد تقطيع الأسطر للخط اللاتيني. في النص المختلط، قد يغيّر ذلك موضع النص الشرقي الآسيوي وعلامات الترقيم المجاورة.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) يتحكم في قواعد تقطيع الأسطر للخط الشرقي الآسيوي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)، الذي يفعّل اللف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف قطع سطر. إدخال صريح لسطر جديد يفرض سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال التالي يخلق كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يضبط كلا خاصيتي تقطيع الأسطر صراحةً ويحفظ "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة الخاصية مع إبقاء الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun، وعرض إطار 160 نقطة وهوامش أفقية صفرية. يُعيّن [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) إلى [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) لضمان بقاء حجم النص وأبعاد الإطار ثابتين.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **التحكم في علامات الترقيم المتدلية**

يتيح [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) للعلامات الترقيمية المؤهلة أن تمتد إلى ما بعد حافة السطر الأيمن بدلًا من الانتقال إلى السطر التالي. ينطبق على الفقرة بأكملها ويختلف عن الهوامش المتدلية.

المثال التالي يُفعّل علامات الترقيم المتدلية في إطار نص عرضه 100 نقطة ويحفظ "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما بعد حافة النص اليمنى. اضبط الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تشغل النقطة سطرًا منفصلًا. تم تفعيل اللف وتعطيل الملاءمة التلقائية للحفاظ على عرض ثابت.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

ليس كل علامة ترقيم يمكن أن تتدلى. تنطبق [شروط الخط والتخطيط الموضحة أعلاه](#control-line-breaking) على هذه المقارنة أيضًا: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة قد يزيل الفرق المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص ينكمش، يتجاوز، أو يعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة تحجيمه ليتناسب مع النص ويحفظ النتيجة إلى "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

لحساب عدد الأسطر بعد اللف التلقائي ورؤية كيف يتغير عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/net/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين مرساة إطارات النص**

يحدد [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) كيفية تموضع النص عمودياً داخل الشكل، مثلاً في الأعلى أو الوسط أو الأسفل. المثال التالي يرسخ النص إلى أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **تعيين الجدولة النصية**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) لتكوين علامات التبويب في فقرة. المثال التالي يعيّن الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف علامة تبويب محاذية إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

النتيجة:

![علامات التبويب للفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)، التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والنحو في PowerPoint.

المثال التالي يتطلب "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。" ويعيّن SimSun كخط لها، ويحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// تعيين لغة التدقيق إلى الصينية المبسطة.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **نسخ بيانات اللغة الوصفية**

عند نسخ نص متعدد اللغات من قالب، احفظ كل من [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) و[IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). المثال التالي يخلق جزء مصدر بلغة الإنجليزية الأمريكية كلغة أساسية ولغة فرنسية كلغة بديلة، وينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
    // إذا لم يحتوي المصدر على لغة بديلة، فإن null يمسح قيمة الوجهة.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل `null`، ويحافظ بيان النسخ نفسه على عدم وجوده دون إدخال قيمة افتراضية، حتى لو كان الوجهة قد عيّن لغة بديلة مسبقاً.

هذه المعرفات تُخزن بيانات لغة وصفية. حفظها لا يحدد أي قاموس يختاره PowerPoint لتدقيق الإملاء أو النحو.

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يخلق عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف صندوق نص، ويطبع `en-US` للجزء النصي الأول.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// إضافة شكل مستطيل جديد مع نص.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// تحقق من لغة الجزء الأول.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

المثال التالي يعيّن خطًا غليظًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد، ويحفظه إلى "default_text_style.pptx". يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// احصل على تنسيق الفقرة في المستوى العلوي.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **استخراج النص مع تأثير الأحرف الكبيرة كلها**

في PowerPoint، يُظهر تطبيق تأثير الخط **All Caps** النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

المثال التالي يتطلب "sample2.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير All Caps](all_caps_effect.png)

الكود أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) وتنسيق الفقرة عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). اضبط [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) وكمّن نقاط التدرج، الاتجاه، والشفافية.

الميزة ذات الصلة: [Format text within slides](/slides/ar/features/text-formatting/).