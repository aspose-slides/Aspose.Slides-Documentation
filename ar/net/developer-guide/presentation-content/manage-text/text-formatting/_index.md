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
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. خصص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، التدوير، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مسافات التاب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى تحتوي على النص المعروض أدناه. كل من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاءً بالخط العريض تستخدم التنسيق الفعال، بما في ذلك تنسيق الخط العريض الموروث:

![نص تجريبي](sample_text.png)

للعثور على النص الحرفي أو مطابقة التعبير النمطي وتظليله، راجع [بحث واستبدال النص](/slides/ar/net/search-and-replace-text/).

## **ضبط لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التظليل الافتراضي للفقرة، أو استخدم [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) لأجزاء النص الفردية.

المثال التالي يضبط تظليلًا بالرمادي الفاتح كقيمة افتراضية للفقرة الأولى. ألوان التظليل الصريحة على الأجزاء الفردية لها أولوية أعلى من هذا الإعداد الافتراضي:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين لون التظليل للفقرة بأكملها.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![فقرة رمادية](gray_paragraph.png)

المثال البرمجي أدناه يوضح كيفية ضبط لون خلفية **أجزاء النص ذات الخط العريض**:

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
        // تعيين لون التظليل لجزء النص.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) لتحديد محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة وسطية، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين محاذاة الفقرة إلى الوسط.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) لمحاذاة أجزاء النص ذات أحجام الخط المختلفة عموديًا داخل سطر. ينطبق هذا الإعداد على الفقرة بأكملها ويُتحكم في المحاذاة داخل كل سطر منها.

المثال التالي يُنشئ أربع مربعات نص مُسمّى على شريحة واحدة. كل فقرة تحتوي على نفس النص بحجم 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم Arial، ويعطل الملاءمة التلقائية واللف، ويحافظ على إطارات النص كبيرة بما يكفي لسطر واحد.

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

![مقارنة بين محاذاة Baseline، Top، Center، وBottom مع أحجام خطوط مختلطة](font_alignment.png)

محاذاة الخط تعتمد على مقاييس الخط، لذا فإن حواف الأحرف الفردية قد لا تتطابق تمامًا. يتضمن المثال حرفًا كبيرًا وحرفًا أسفليًا لتوضيح الفرق بين محاذاة القاعدة والمحاذاة السفلية. تتأثر النتيجة بتوافر الخطوط والاستبدال، الأحرف المستخدمة، واختلاف أحجام الخطوط. كذلك تؤثر أبعاد الإطار، الهوامش، تباعد السطر، اللف، والملاءمة التلقائية على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)، الذي يتحكم في المحاذاة الأفقية للفقرة، وعن [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)، الذي يحدد موضع كتلة النص عموديًا داخل الشكل. تنسيق الفوقية والتحتي عبر [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) يَحْوِّل الأجزاء الفردية بالنسبة للقاعدة بدلاً من ضبط محاذاة الخط للسطور.

## **ضبط الشفافية للنص**

تُتحكم شفافية النص من خلال مكوّن ألفا للون المعيّن إلى [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا في نظام ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال البرمجي أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

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

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

## **ضبط تباعد الأحرف للنص**

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) لتوسيع أو تقليص التباعد بين الأحرف في مربع نص. تضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تقلل التباعد.

الكود C# التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال البرمجي أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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
        // ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
        portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التقرّب للخطوط المحددة**

في بعض الحالات، قد يبدو النص المُنتج بواسطة Aspose.Slides أكثر ضيقًا قليلاً مقارنةً بالنص نفسه في PowerPoint. يحدث هذا لأن PowerPoint قد يتجاهل بيانات التقرّب لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات تقرّب صالحة وكان التقرّب مفعَّلًا في إعدادات PowerPoint.

لجعل الناتج أقرب إلى PowerPoint في هذه الحالات، يمكنك تعطيل التقرّب لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال وجود "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما فيها الخطوط الموروثة، ويضبط حدًا قدره 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل التقرّب للأجزاء التي يكون حجم خطها أقل من 100 نقطة:

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

بالنسبة للنص المتطابق تحت الحد، يمنع هذا الإعداد التقرّب وقد يساعد على توافق عرض Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن ضبط خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. التنسيق الصريح على الأجزاء الفردية له أولوية أعلى من هذه القيم الافتراضية:

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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال عريضًا:

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

استخدم [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) عند إعادة إنتاج تخطيط القوالب أو دراسة اختلافات ارتفاع الأحرف. في PowerPoint، تمكين التطبيع يمدد أو يضغط الأحرف عموديًا لتمنحها ارتفاعًا مرئيًا موحدًا داخل جزء النص. لا يضمن ذلك تعادلاً في ارتفاع النص بين الخطوط المختلفة.

اضبط الخاصية إلى [NullableBool.True أو False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) لتمكين أو تعطيل التطبيع صراحة. يبقى `NullableBool.NotDefined` دون ضبط محلي، بحيث يرث الجزء قيمتها، مثلاً من [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) للفقرة. لا يعني ذلك `False`. استخدم [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) واقرأ [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) للحصول على القيمة المنطقية النهائية.

المثال التفاعلي التالي يتطلب تثبيت **Arial**. يُنشئ كتلتين من النص تحتوي كل منهما على الأحرف الكبيرة، الأحرف الصغيرة، الأحرف الأسفلية، والحروف المشكَّلة بحجم 54 نقطة. تُفعَّل التطبيع افتراضيًا في كلتا الفقرتين. الجزء العلوي يُعطل التطبيع صراحةً؛ الجزء السفلي يرثه. أحجام الإطارات، الهوامش، وتباعد الفقرات متماثلة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على المقارنة ثابتة. يطبع المثال `False: False` و`NotDefined: True`، ثم يُحفظ الملف "text_height_normalization.pptx".

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

تم تصدير المقارنة أدناه من العرض المحفوظ. الصف العلوي به تطبيع معطَّل (`False`); الصف السفلي يرث الإعداد المفعَّل (`NotDefined` → `True`). احرص على تثبيت Arial لإعادة إنتاج هذا الشكل.

![نص Arial بحجم 54 نقطة مع إيقاف التطبيع أعلاه وتفعيل التطبيع الموروث أدناه](text_height_normalization.png)

التطبيع يغيّر ارتفاع الأحرف دون تعديل قيمة [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) في الفقرة في تباعد الأسطر، بينما يتحكم [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) لإطار النص في كيفية تعديل النص أو حاويته لملاءمة المساحة. هذه الإعدادات تخدم أغراضًا مختلفة وقد تؤثر على التخطيط العام بصورة مستقلة. لمزيد من المعلومات حول تنسيق الفقرات والوراثة، راجع [إدارة الفقرات](/slides/ar/net/manage-paragraph/).

## **تطبيق وإزالة الخط المشطوب**

استخدم [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) على جزء النص لعرض تصحيحات أو إلغاء مصطلحات أو أسعار سابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType.Single أو Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) لسطر واحد أو سطرين عبر النص.

لإزالة الخط المشطوب، عيّن `TextStrikethroughType.None`. هذا يُعطِّل التأثير صراحةً، حتى لو كان التنسيق المحيط يحدد خطًا مشطوبًا. على العكس، `TextStrikethroughType.NotDefined` يترك الإعداد المحلي غير معرف، ويسمح للجزء بوراثة التنسيق، مثلاً من الفقرة. ولا يضمن إزالة الخط المشطوب. استخدم [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال التفاعلي التالي يُنشئ ثلاث مقارنات أسعار. كل فقرة لها أجزاء منفصلة للملصق، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يُطبق ثم يُزيل الخط المشطوب؛ الصفوف الأخرى تحتفظ بخط مشطوب واحد أو مزدوج. تغيير هذه الخاصية يحافظ على النص وتنسيقه الآخر، بما في ذلك الخط العريض للسعر السابق.

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

// تطبيق الخط المشطوب، ثم إزالته صراحةً من السعر السابق الأول.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

النتيجة، من الأعلى إلى الأسفل: بدون خط مشطوب، بخط مشطوب واحد، وبخط مشطوب مزدوج.

![الأسعار السابقة بدون خط مشطوب، بخط مشطوب واحد، وبخط مشطوب مزدوج](strikethrough.png)

## **ضبط دوران النص**

استخدم [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) لتحديد اتجاه نص مسبق داخل شكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس عقارب الساعة**:

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

## **ضبط دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) لتحديد زاوية دوران مخصصة لإطار نصي عبر [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

المثال البرمجي أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

## **ضبط تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بنقاط.

المثال التالي يضبط التباعد داخل الفقرة الأولى إلى 200 % من ارتفاع السطر (تباعد مزدوج):

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

![تباعد السطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تمزج بين النص اللاتيني والآسيوي الشرقي. الخصائص التالية تنتمي إلى [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) يتحكم في قواعد كسر السطر للغة اللاتينية. في النص المختلط، قد يؤدي تغييره أيضًا إلى تعديل مواضع النص والحدود الشرقية الآسيوية وعلامات الترقيم المجاورة.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) يتحكم في قواعد كسر السطر للآسيوية الشرقية، بما فيها القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تستبدل [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)، الذي يُفعِّل اللف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف كسر سطر. كسر سطر صريح يُدخل سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال التفاعلي التالي يُنشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يضبط كلا خاصيتي كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غير قيمة الخاصية المعنية مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun، بعرض إطار 160 نقطة ولا هوامش أفقية لإطار النص. يتم ضبط [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) إلى [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) بحيث يبقى حجم النص وأبعاد الإطار ثابتين.

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

## **التحكم في علامات الترقيم المعلقة**

يتيح [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) للعلامات الترقيمية المؤهلة أن تمتد إلى ما وراء الحافة اليمنى لسطر النص بدلاً من احتلال السطر التالي. ينطبق هذا على الفقرة بأكملها وهو مختلف عن الإزاحة المعلقة.

المثال التفاعلي التالي يُفعِّل علامات الترقيم المعلقة في إطار نص عرضه 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". باستخدام Arial بحجم 24 نقطة ولا هوامش أفقية لإطار النص، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما وراء حافة النص اليمنى. اضبط الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تحتل النقطة سطرًا منفصلًا. يتم تمكين اللف وتعطيل الملاءمة التلقائية للحفاظ على عرض ثابت.

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

ليس كل علامة ترقيم يمكن أن تُعلق. تنطبق أيضًا [الظروف المتعلقة بالخط والتخطيط المذكورة أعلاه](#control-line-breaking): تغيير الخط، العرض المتاح، الهوامش، أو إعدادات الملاءمة التلقائية قد يزيل الفرق المرئي.

## **ضبط نوع الملاءمة التلقائية لإطارات النص**

يحدد [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) سلوك النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغر، يتجاوز، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يُعدِّل الشكل لإعادة تحجيمه ليتناسب مع النص ويحفظ النتيجة في "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

لحساب عدد الأسطر بعد اللف التلقائي ورؤية كيف يتغيّر عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/net/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يتجاوز الحاوية.

## **ضبط مرساة إطارات النص**

يُعرّف [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل. المثال التالي يضع مرساة النص في أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **ضبط تبويب النص**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) لتكوين مسافات التاب في الفقرة. المثال التالي يضبط الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف فاصلًا إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تاب.

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

![علامات التاب في الفقرة](paragraph_tabs.png)

## **ضبط لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)، التي تُتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الأخطاء الإملائية والنحوية في PowerPoint.

المثال التالي يتطلب وجود "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتوى الفقرة الأولى بـ "1。"، يضبط SimSun كخط لها، ويعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":

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

عند نسخ نص متعدد اللغات من قالب، احفظ كلًا من [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) و[IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). المثال التفاعلي التالي يُنشئ جزءًا مصدرًا باللغة الإنجليزية الأمريكية كلغته الأساسية والفرنسية كلغته البديلة، وينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

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
// إذا لم يكن للمصدر لغة بديلة، فإن null يمسح قيمة الوجهة.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل `null`، ويحافظ بيان النسخ نفسه على عدم وجوده دون إدخال قيمة افتراضية، حتى لو كان الوجهة يحتوي مسبقًا على لغة بديلة مُعيَّنة.

هذه المعرفات تُخزّن بيانات اللغة الوصفية. الحفاظ عليها لا يحدِّد القاموس الذي يختاره PowerPoint للتدقيق الإملائي أو النحوي.

## **ضبط اللغة الافتراضية**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) لتعريف اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا بلغة النص الافتراضية الإنجليزية الأمريكية، يضيف مربع نص، ويطبع `en-US` لأول جزء نصي فيه.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// أضف شكلاً مستطيلاً جديدًا مع نص.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// تحقق من لغة الجزء الأول.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **ضبط نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

المثال التالي يضبط خطًا عريضًا بحجم 14 نقطة كقيمة افتراضية للفقرات العليا في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص وراثة هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// احصل على تنسيق الفقرة من المستوى العلوي.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **استخراج النص مع تأثير الحروف الكبيرة كلها**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال وجود "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير All Caps](all_caps_effect.png)

المثال البرمجي أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

المخرجات:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). تَجول عبر الخلايا وقم بتحديث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) وتنسيق الفقرات عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكنني تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). اضبط [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) وُConfigure نقاط التدرج، الاتجاه، والشفافية.

ميزة ذات صلة: [تنسيق النص داخل الشرائح](/slides/ar/features/text-formatting/).