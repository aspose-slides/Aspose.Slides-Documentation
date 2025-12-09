---
title: تنسيق نص العرض التقديمي في .NET
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/net/text-formatting/
keywords:
- تسليط الضوء على النص
- تعبير نمطي
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
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---

## **نظرة عامة**

تُقدم هذه المقالة كيفية إدارة وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. ستتعلم كيفية تطبيق ميزات تنسيق النص مثل اختيار الخط، الحجم، اللون، التظليل، لون الخلفية، التباعد، والمحاذاة. بالإضافة إلى ذلك، تغطي العمل مع إطارات النص، الفقرات، التنسيق، وخيارات التخطيط المتقدمة مثل الدوران المخصص وسلوكيات الملاءمة التلقائية.

سواءً كنت تُنشئ العروض تقديميًا برمجيًا أو تُخصّص المحتوى الموجود، ستساعدك هذه الأمثلة على إنشاء تخطيطات نصية واضحة ومظهرها احترافي تعزز شرائحك وتحسّن قابلية القراءة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، والذي يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:
![نص العينة](sample_text.png)

## **تسليط الضوء على النص**

تتيح لك طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) تظليل جزء من النص بلون خلفية بناءً على عينة نص مطابقة.

لاستخدام هذه الطريقة، اتبع الخطوات التالية:
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) باستخدام ملف إدخال (PPT، PPTX، ODP، إلخ).
2. الوصول إلى الشريحة المطلوبة باستخدام مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. الوصول إلى الشكل المستهدف من مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) وتحويله إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. تظليل النص المطلوب باستخدام طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) عبر تزويده بنص العينة واللون.
5. حفظ العرض التقديمي بالصيغة المطلوبة (مثل PPT، PPTX، ODP).

مثال الشيفرة أدناه يسلط الضوء على جميع occurrences الأحرف **"try"** والكلمة الكاملة **"to"**.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // احصل على الشكل الأول من الشريحة الأولى.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // ظلل كلمة "try" في الشكل.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // ظلل كلمة "to" في الشكل.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![النص المبرز](highlighted_text.png)

{{% alert color="primary" %}} 
توفر Aspose محرر PowerPoint عبر الإنترنت بسيط ومجاني.
{{% /alert %}} 

## **تسليط الضوء على النص باستخدام التعبيرات النمطية**

يتيح لك Aspose.Slides for .NET البحث وتظليل أجزاء محددة من النص في شرائح PowerPoint باستخدام التعبيرات النمطية. هذه الميزة مفيدة خاصة عندما تحتاج إلى إبراز الكلمات المفتاحية أو الأنماط أو المحتوى القائم على البيانات بشكل ديناميكي. تتيح طريقة [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) تظليل أجزاء من النص بلون خلفية باستخدام تعبير نمطي.

مثال الشيفرة أدناه يسلط الضوء على جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // تمييز جميع الكلمات التي تتكون من سبعة أحرف أو أكثر.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![النص المبرز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

يوفر Aspose.Slides for .NET القدرة على تطبيق ألوان الخلفية على فقرات كاملة أو أجزاء نصية فردية في شرائح PowerPoint. هذه الوظيفة مفيدة عندما تريد تظليل كلمات أو عبارات محددة، جذب الانتباه إلى الرسائل الأساسية، أو تحسين الجاذبية البصرية لعروضك.

مثال الشيفرة التالي يوضح كيفية تعيين لون الخلفية لل**فقرة كاملة**:
```cs
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

مثال الشيفرة أدناه يوضح كيفية تعيين لون الخلفية لـ**أجزاء النص ذات الخط الغامق**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // تعيين لون التظليل للجزء النصي.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![الأجزاء النصية الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

محاذاة النص هي جانب أساسي من تنسيق الشرائح يؤثر على كل من قابلية القراءة والجاذبية البصرية. في Aspose.Slides for .NET، يمكنك التحكم بدقة في محاذاة الفقرات داخل إطارات النص، مما يضمن تقديم محتواك بشكل متسق—سواء كان متمركزًا، محاذيًا لليسار، لليمين، أو مبررًا. يوضح هذا القسم كيفية تطبيق وتخصيص محاذاة النص في عروض PowerPoint الخاصة بك.

مثال الشيفرة التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:
```cs
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

## **تعيين شفافية النص**

ضبط شفافية النص يتيح لك إنشاء تأثيرات بصرية خفيفة وتحسين جمالية الشرائح. يوفر Aspose.Slides for .NET القدرة على تعيين مستوى شفافية الفقرات وأجزاء النص، مما يسهل دمج النص مع الخلفيات أو إبراز عناصر معينة. يوضح هذا القسم كيفية تطبيق إعدادات الشفافية على النص في عروضك.

مثال الشيفرة أدناه يوضح كيفية تطبيق الشفافية على **الفقرة كاملة**:
```cs
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

مثال الشيفرة التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:
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
            // تعيين شفافية الجزء النصي.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![الأجزاء النصية الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

يتيح لك Aspose.Slides تعيين التباعد بين الحروف في مربع نص. هذا يسمح لك بضبط الكثافة البصرية لسطر أو كتلة نصية عن طريق توسيع أو تقليل المسافة بين الأحرف.

الكود C# التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

مثال الشيفرة أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![تباعد الأحرف في الأجزاء النصية](character_spacing_in_text_portions.png)

## **إدارة خصائص خط النص**

يوفر Aspose.Slides for .NET القدرة على ضبط إعدادات الخط بدقة على مستوى الفقرة أو لأجزاء النص الفردية، مما يضمن الاتساق البصري وتلبية متطلبات تصميم العرض التقديمي. يمكنك تعريف أنماط الخط، الأحجام، وغيرها من خيارات التنسيق لجميع الفقرات، مما يمنحك تحكمًا أكبر في مظهر النص. يوضح هذا القسم كيفية إدارة خصائص الخط لفقرات النص في شريحة.

الكود التالي يحدد الخط ونمط النص للفقرة بأكملها: يطبق حجم الخط، الغامق، المائل، التسطير النقطي، وخط Times New Roman على جميع الأجزاء في الفقرة.
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

مثال الشيفرة أدناه يطبق خصائص مماثلة على **أجزاء النص ذات الخط الغامق**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // تعيين خصائص الخط للجزء النصي.
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
![خصائص الخط للأجزاء النصية](font_properties_for_text_portions.png)

## **تعيين دوران النص**

يمكن أن يعزز تدوير النص تخطيط الشرائح ويساعد على إبراز محتوى معين. باستخدام Aspose.Slides for .NET، يمكنك بسهولة تطبيق دوران على النص داخل الأشكال، وضبط الزاوية لتتناسب مع التصميم. يوضح هذا القسم كيفية تعيين والتحكم في دوران النص لتحقيق التأثير البصري المطلوب.

الكود التالي يعيّن اتجاه النص في الشكل إلى `Vertical270`، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:
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

تعيين زاوية دوران مخصصة لـ`TextFrame` يتيح لك وضع النص بزوايا دقيقة، مما يمكّن من تصاميم شرائح أكثر إبداعًا ومرونة. يوفر Aspose.Slides for .NET تحكمًا كاملاً في دوران إطارات النص، مما يسهل محاذاة النص مع عناصر الشريحة الأخرى. يوجهك هذا القسم خلال تطبيق زاوية دوران محددة على `TextFrame`.

مثال الشيفرة أدناه يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:
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

يوفر Aspose.Slides الخصائص `SpaceAfter` و`SpaceBefore` و`SpaceWithin` ضمن فئة [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/)، مما يتيح لك إدارة تباعد الأسطر للفقرة. تُستخدم هذه الخصائص كما يلي:
* استخدام قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدام قيمة سالبة لتحديد تباعد السطر بالنقاط.

مثال الكود التالي يوضح كيفية تحديد تباعد الأسطر داخل الفقرة:
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
![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

خاصية AutoFitType تحدد سلوك النص عندما يتجاوز حدود الحاوية. يتيح لك Aspose.Slides for .NET التحكم فيما إذا كان النص يجب أن يتقلص ليناسب، يتجاوز، أو يغير حجم الشكل تلقائيًا. يوضح هذا القسم كيفية تعيين `AutofitType` لـ`TextFrame` لإدارة تخطيط النص بفعالية داخل الأشكال.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **تعيين المرفق لإطارات النص**

يُحدد التثبيت كيف يتم وضع النص داخل الشكل رأسيًا. باستخدام Aspose.Slides for .NET، يمكنك تعيين نوع التثبيت لـ`TextFrame` لمحاذاة النص إلى أعلى، وسط، أو أسفل الشكل. يوضح هذا القسم كيفية تعديل إعدادات التثبيت لتحقيق المحاذاة الرأسية المطلوبة لمحتوى النص.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **تعيين تبويب النص**

يساعد التبويب على تنظيم النص في تخطيطات منظمة بإضافة مسافات متسقة بين عناصر المحتوى. يدعم Aspose.Slides for .NET تعيين نقاط تبويب مخصصة داخل فقرات النص، مما يتيح تحكمًا دقيقًا في موضع النص. يوضح هذا القسم كيفية تكوين تبويب النص لتحسين المحاذاة والتنسيق.
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
![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية `LanguageId` لفئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)، والتي تتيح لك تعيين لغة التدقيق لمستند PowerPoint. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد النحوية في PowerPoint.

مثال الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء نصي:
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

تحديد اللغة الافتراضية للنص يضمن صحة تدقيق الإملاء، وتقطيع الكلمات، وسلوك التحويل النص إلى كلام في PowerPoint. يتيح لك Aspose.Slides for .NET تعيين اللغة على مستوى الجزء النصي أو الفقرة. يوضح هذا القسم كيفية تعريف اللغة الافتراضية لنص العرض التقديمي الخاص بك.
```cs
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

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في عرض تقديمي مرة واحدة، يمكنك استخدام خاصية `DefaultTextStyle` لواجهة [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) وتحديد التنسيق المفضل لديك.
```cs
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


## **استخراج النص مع تأثير الأحرف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرداد مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. للتعامل مع ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)—إذا أظهر `All`، قم ببساطة بتحويل السلسلة المرجعة إلى أحرف كبيرة حتى يتطابق الناتج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا مربع النص التالي على الشريحة الأولى من ملف sample2.pptx.
![تأثير الأحرف الكبيرة](all_caps_effect.png)

مثال الشيفرة أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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

لتعديل النص في جدول داخل شريحة، يجب عليك استخدام كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). يمكنك التكرار عبر جميع خلايا الجدول وتغيير النص في كل خلية عن طريق الوصول إلى خصائص `TextFrame` و`ParagraphFormat` الخاصة بها داخل كل خلية.

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم الخاصية `FillFormat` في [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). قم بتعيين `FillFormat` إلى `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للمتدرج، إلى جانب خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير المتدرج على النص.