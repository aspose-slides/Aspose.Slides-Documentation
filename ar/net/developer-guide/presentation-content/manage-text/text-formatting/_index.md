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
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. تشمل ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، إيقاف التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم "sample.pptx"، يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص عيّني](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير عادي وتظليلها، راجع [بحث واستبدال النص](/slides/ar/net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/highlightcolor/) لأجزاء النص الفردية.

يظهر المثال البرمجي التالي كيفية تعيين لون الخلفية **لكامل الفقرة**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // تعيين لون التظليل للفقرة بالكامل.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

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

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون محاذاة مركزية، إلى اليسار، إلى اليمين، مبررة، وما إلى ذلك.

يظهر المثال البرمجي التالي كيفية محاذاة الفقرة إلى **المركز**:

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

![الفقرة المحاذية](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم الشفافية في النص من خلال مكوّن ألفا للون المخصص إلى [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **كل الفقرة**:

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

يظهر المثال البرمجي التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/spacing/) لتوسيع أو تضييق التباعد بين الأحرف في مربع النص.

يظهر الكود C# التالي كيفية توسيع تباعد الأحرف في **كل الفقرة**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ملاحظة: استخدم القيم السلبية لتقليل تباعد الأحرف.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يظهر مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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
            // ملاحظة: استخدم القيم السلبية لتقليل تباعد الأحرف.
            portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **إيقاف التقويس للخطوط المحددة**

في بعض الحالات، قد يظهر النص المصدّر بواسطة Aspose.Slides أكثر إحكامًا قليلاً من النص نفسه المعروض في PowerPoint. يحدث هذا لأن PowerPoint قد يتجاهل بيانات التقويس لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تقويس صالحة وتكون التقويس مفعلة في إعدادات PowerPoint.

لجعل الناتج المصدّر أقرب إلى ما في PowerPoint في هذه الحالات، يمكنك إيقاف التقويس لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

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

هذا الإعداد يمنع تطبيق التقويس على أجزاء النص المطابقة ويمكن أن يساعد في توافق عرض Aspose.Slides مع النتيجة البصرية لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/).

يظهر الكود التالي تعيين الخط وأسلوب النص للفقرة بالكامل: يطبق حجم الخط، العريض، المائل، تسطير منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

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

يظهر مثال الشيفرة أدناه تطبيق خصائص مماثلة على **أجزاء النص ذات الخط العريض**:

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

استخدم [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/textverticaltype/) لتحديد اتجاه نص مسبق التعريف داخل الشكل.

يظهر المثال البرمجي التالي تعيين اتجاه النص داخل الشكل إلى `Vertical270`، مما يدور النص **90 درجة عكس اتجاه العقارب**:

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

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/rotationangle/) لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).

يدور مثال الشيفرة أدناه إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

توفر Aspose.Slides الخاصيتين [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سلبية لتحديد تباعد السطر بالنقاط.

يظهر المثال البرمجي التالي كيفية تحديد تباعد السطر داخل الفقرة:

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

يحدد [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/autofittype/) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يتقلص، يتجاوز، أو يعيد تحجيم الشكل تلقائيًا.

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

لحساب عدد الأسطر بعد التفصيل التلقائي ورؤية كيف يتغير عرض النص أو الشكل، راجع [عدد الأسطر المصدّرة](/slides/ar/net/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين تثبيت إطارات النص**

يحدد [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/anchoringtype/) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل.

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

## **تعيين تبويب النص**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/tabs/) لتكوين إيقافات التبويب في الفقرة.

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

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/)، التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد النحوية في PowerPoint.

يظهر المثال البرمجي التالي كيفية تعيين لغة التدقيق لجزء النص:

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

    // تعيين معرف لغة التدقيق.
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

    // فحص لغة الجزء الأول.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/defaulttextstyle/).

يظهر المثال البرمجي التالي كيفية تعيين خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // الحصول على تنسيق الفقرة على المستوى الأعلى.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **استخراج النص مع تأثير الأحرف الكبيرة كلها**

في PowerPoint، يجعل تطبيق تأثير الخط **All Caps** النص يظهر بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/net/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا مربع النص التالي على الشريحة الأولى من ملف sample2.pptx.

![تأثير الأحرف الكبيرة كلها](all_caps_effect.png)

يظهر مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/). تكرّر عبر الخلايا وحدث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/textframe/) وتنسيق الفقرة عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). اضبط [IFillFormat.FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) وقم بتكوين نقاط التدرج والاتجاه والشفافية.