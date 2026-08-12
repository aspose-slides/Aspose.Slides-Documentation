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
- تثبيت إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تنسيق وتنسيق نصوص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، التدوير، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مسافات الجدولة، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

للعثور على النص الحرفي أو مطابقة التعبير النمطي وتظليله، راجع [بحث واستبدال النص](/slides/ar/net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التظليل الافتراضي للفقرة، أو استخدم [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/highlightcolor/) لأجزاء النص الفردية.

يعرض مثال الشيفرة التالي كيفية تعيين لون الخلفية لل**فقرة كاملة**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين لون التظليل للفقرة بأكملها.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص بخط غامق**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وما إلى ذلك.

يعرض مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين محاذاة الفقرة إلى الوسط.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تُتحكم شفافية النص عبر مكوّن ألفا للون المعيّن إلى [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

يعرض مثال الشيفرة أدناه كيفية تطبيق الشفافية على **فقرة كاملة**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين لون تعبئة النص إلى لون شفاف.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

يعرض مثال الشيفرة التالي كيفية تطبيق الشفافية **لأجزاء النص بخط غامق**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/spacing/) لتوسيع أو تقليص التباعد بين الأحرف في مربع النص.

يعرض الشيفرة C# التالية كيفية توسيع تباعد الأحرف في **الفقرة الكاملة**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يعرض مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص بخط غامق**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
            portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل Kerning للخطوط المحددة**

في بعض الحالات، قد يبدو النص المُعرَض بواسطة Aspose.Slides ضيقًا قليلاً مقارنة بنفس النص المعروض في PowerPoint. يمكن أن يحدث هذا لأن PowerPoint قد يتجاهل بيانات kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة ويتم تمكين kerning في إعدادات PowerPoint.

لجعل الإخراج المُعَرض أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل kerning لأجزاء النص التي تستخدم الخط المتأثر. قم بتعيين [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

يمنع هذا الإعداد تطبيق kerning على أجزاء النص المتطابقة ويمكن أن يساعد في توافق عرض Aspose.Slides مع النتيجة البصرية في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على أجزاء فردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/).

تحدد الشيفرة التالية الخط ونمط النص للفقرة بأكملها: فهي تطبق حجم الخط، الغامق، المائل، التسطير المنقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين خصائص الخط للفقرة.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

يوضح مثال الشيفرة أدناه تطبيق خصائص مماثلة **لأجزاء النص بخط غامق**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/textverticaltype/) لتعيين اتجاه نص محدد مسبقًا داخل شكل.

تحدد الشيفرة التالية اتجاه النص في الشكل إلى `Vertical270`، مما يدير النص **90 درجة عكس اتجاه عقارب الساعة**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/rotationangle/) لتعيين زاوية دوران مخصصة لإطار [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).

يدور مثال الشيفرة أدناه إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كالتالي:
* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

يعرض مثال الشيفرة التالي كيفية تحديد تباعد السطر داخل الفقرة:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد السطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/autofittype/) كيفية تصرف النص عندما يتجاوز حدود الحاوية الخاصة به. استخدمه للتحكم فيما إذا كان النص سيصغر، يفيض، أو يعيد حجم الشكل تلقائيًا.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **تعيين تثبيت إطارات النص**

يحدد [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/anchoringtype/) كيفية تموضع النص عموديًا داخل الشكل، على سبيل المثال في الأعلى، الوسط، أو الأسفل.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **تعيين جدولة النص**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/tabs/) لتكوين مواضع الجدولة في الفقرة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![جدولة الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/)، التي تتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

يعرض مثال الشيفرة التالي كيفية تعيين لغة التدقيق لجزء النص:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // تعيين معرّف لغة التدقيق.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // إضافة شكل مستطيل جديد مع نص.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // تحقق من لغة الجزء الأول.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق النص الافتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/defaulttextstyle/).

يعرض مثال الشيفرة التالي كيفية تعيين خط غامق افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // احصل على تنسيق الفقرة في المستوى الأعلى.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **استخراج النص بتأثير الأحرف الكبيرة كلها**

في PowerPoint، تطبيق تأثير الخط **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عندما تسترجع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/net/aspose.slides/textcaptype/) وحوِّل السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا مربع النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير All Caps](all_caps_effect.png)

يعرض مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

المخرجات:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/textframe/) وتنسيق الفقرة عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكن تطبيق تدرج اللون على النص في شريحة PowerPoint؟**

لتطبيق تدرج لوني على النص، استخدم [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). عيّن [IFillFormat.FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.