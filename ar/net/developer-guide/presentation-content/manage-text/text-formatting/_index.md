---
title: تنسيق نص العرض التقديمي في .NET
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/net/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملائمة التلقائية
- تثبيت إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تكوين وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. وتغطي تمييز النص، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملائمة التلقائية، تثبيت النص، مواضع الفواصل، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص مثال](sample_text.png)

## **تمييز النص**

استخدم طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlighttext/) عندما تحتاج إلى تمييز النص الذي يطابق عينة معينة داخل إطار نص. تُطبق الطريقة لونًا مميزًا على أجزاء النص المطابقة ويمكن استخدامها مع [TextSearchOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/textsearchoptions/) للتحكم في كيفية إجراء البحث، على سبيل المثال لمطابقة الكلمات الكاملة فقط.

الكود أدناه يميز جميع تداخلات الأحرف **"try"** ثم يميز كلمة **"to"** الكاملة فقط.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // الحصول على الشكل الأول من الشريحة الأولى.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // تمييز الكلمة "try" في الشكل.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // تمييز الكلمة "to" في الشكل.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![النص المميز](highlighted_text.png)

## **تمييز النص باستخدام التعابير النمطية**

طريقة [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/highlightregex/) تميز النصوص التي يتم العثور عليها عبر تعبير نمطي. في .NET، تُعرَّف هذه الواجهة على [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).

الكود أدناه يميز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // تمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![النص المميز باستخدام التعابير النمطية](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التمييز الافتراضي لفقرة، أو استخدم [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/highlightcolor/) لأجزاء النص الفردية.

الكود التالي يوضح كيفية تعيين لون الخلفية **لكامل الفقرة**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين لون التمييز للفقرة بأكملها.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

الكود أدناه يوضح كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذاة إلى اليسار، إلى اليمين، مبررة، وما إلى ذلك.

الكود التالي يوضح كيفية محاذاة الفقرة إلى **المركز**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين محاذاة الفقرة إلى المركز.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة المُحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تُتحكم شفافية النص من خلال العنصر ألفا للون المعيّن إلى [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بصيغة ARGB على مقياس 0–255، وليس نسبة شفافية.

الكود التالي يوضح كيفية تطبيق الشفافية على **كامل الفقرة**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين لون التعبئة للنص إلى اللون الشفاف.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

الكود التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

```cs
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

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/spacing/) لتوسيع أو تقليل التباعد بين الأحرف في مربع النص.

الكود C# التالي يوضح كيفية توسيع تباعد الأحرف في **كامل الفقرة**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
            portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التقريب (Kerning) لبعض الخطوط**

في بعض الحالات، قد يبدو النص الذي تُخرجه Aspose.Slides أكثر ضيقًا قليلاً مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التقريب لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات تقريب صالحة وكان التقريب مفعَّلًا في إعدادات PowerPoint.

لجعل النتيجة المُصدَّرة أقرب إلى ما في PowerPoint في هذه الحالات، يمكنك تعطيل التقريب لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```cs
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

هذه الإعدادات تمنع تطبيق التقريب على أجزاء النص المطابقة ويمكن أن تساعد في توافق عرض Aspose.Slides مع المخرجات المرئية في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على أجزاء منفردة عبر [IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/).

الكود التالي يضبط الخط ونمط النص لكامل الفقرة: يطبق حجم الخط، العريض، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

```cs
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

الكود التالي يطبق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

```cs
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

استخدم [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/textverticaltype/) لتعيين توجيه نص مسبق داخل الشكل.

الكود التالي يضبط توجيه النص داخل الشكل إلى `Vertical270`، وهو ما يدور النص **90 درجة عكس عقارب الساعة**:

```cs
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

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/rotationangle/) لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).

الكود التالي يدير إطار النص بزاوية 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

```cs
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

توفر Aspose.Slides الخصائص [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستعمل هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد السطر داخل الفقرة:

```cs
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

## **تعيين نوع الملائمة التلقائية لإطارات النص**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/autofittype/) يحدد كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص ينكمش، يتجاوز، أو يعيد تحجيم الشكل تلقائيًا.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **تعيين تثبيت إطارات النص**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/anchoringtype/) يحدد كيفية تواؤم النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **تعيين جدولة علامات التبويب للنص**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/tabs/) لتكوين مواضع علامات التبويب في الفقرة.

```cs
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

![علامات التبويب للفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IPortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/languageid/)، والتي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والنحو في PowerPoint.

الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء نص:

```cs
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

    // تعيين معرف لغة التدقيق.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/) لتحديد اللغة الافتراضية للنص الذي يتم إنشاؤه أثناء تحميل أو إنشاء عرض تقديمي.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // إضافة شكل مستطيل جديد يحتوي على نص.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // فحص لغة الجزء الأول.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/defaulttextstyle/).

الكود التالي يوضح كيفية تعيين خط عريض بحجم 14 نقطة كنمط نص افتراضي لكل النص عبر الشرائح في عرض تقديمي جديد.

```cs
using (var presentation = new Presentation())
{
    // احصل على تنسيق الفقرة من المستوى الأعلى.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **استخراج النص مع تأثير الحروف الكبيرة الكاملة**

في PowerPoint، تطبيق تأثير **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابة النص أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/net/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا مربع النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الحروف الكبيرة الكاملة](all_caps_effect.png)

الكود التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```cs
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

**كيف يمكن تعديل النص في جدول داخل شريحة؟**

لتعديل النص في جدول داخل شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/). استعرض الخلايا وقم بتحديث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/textframe/) وتنسيق الفقرة عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكن تطبيق لون متدرج للنص في شريحة PowerPoint؟**

لتطبيق لون متدرج للنص، استخدم [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/fillformat/). اضبط [IFillFormat.FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformat/filltype/) على [FillType.Gradient](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) وملّف خيارات التدرج، الاتجاه، والشفافية.