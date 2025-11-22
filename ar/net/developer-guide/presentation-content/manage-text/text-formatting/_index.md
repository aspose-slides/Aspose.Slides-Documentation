---
title: تنسيق نص PowerPoint في C#
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
- خاصية الضبط التلقائي
- مرساة إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C#
- Aspose.Slides
description: "تعلم كيفية تنسيق وتطبيق نمط النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. قم بتخصيص الخطوط والألوان والمحاذاة والمزيد باستخدام أمثلة كود قوية بلغة C#."
---

## **نظرة عامة**

تقدم هذه المقالة كيفية إدارة وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. ستتعلم كيفية تطبيق ميزات تنسيق النص مثل اختيار الخط، الحجم، اللون، التظليل، لون الخلفية، التباعد، والمحاذاة. بالإضافة إلى ذلك، تغطي العمل مع إطارات النص، الفقرات، التنسيق، وخيارات التخطيط المتقدمة مثل الدوران المخصص وسلوكيات الضبط التلقائي.

سواء كنت تقوم بإنشاء العروض برمجيًا أو تخصيص المحتوى الموجود، ستساعدك هذه الأمثلة على إنشاء تخطيطات نصية واضحة ومظهر احترافي تعزز شرائحك وتحسن قابلية القراءة.

في الأمثلة أدناه، سنستخدم ملفًا باسم "sample.pptx" يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:
![نص عينة](sample_text.png)

## **تسليط الضوء على النص**

تتيح لك طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) تمييز جزء من النص بلون خلفية بناءً على عينة نص مطابقة.

لاستخدام هذه الطريقة، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) باستخدام ملف إدخال (PPT، PPTX، ODP، إلخ).
2. الوصول إلى الشريحة المطلوبة باستخدام مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. الوصول إلى الشكل المستهدف من مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) وتحويله إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. تمييز النص المطلوب باستخدام طريقة [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) من خلال تقديم النص النموذجي واللون.
5. حفظ العرض بالتنسيق المطلوب (مثل PPT، PPTX، ODP).

المثال البرمجي أدناه يبرز جميع حالات الأحرف **"try"** والكلمة الكاملة **"to"**.
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
![النص المظلل](highlighted_text.png)

{{% alert color="primary" %}} 
توفر Aspose [محرر PowerPoint مجاني عبر الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **تسليط الضوء على النص باستخدام التعابير النمطية**

تتيح لك Aspose.Slides لـ .NET البحث وتظليل أجزاء محددة من النص في شرائح PowerPoint باستخدام التعابير النمطية. تكون هذه الميزة مفيدة بشكل خاص عندما تحتاج إلى إبراز الكلمات المفتاحية أو الأنماط أو المحتوى المستند إلى البيانات بصورة ديناميكية. تسمح طريقة [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) لك بتظليل أجزاء من النص بلون خلفية باستخدام تعبير نمطي.

المثال البرمجي أدناه يبرز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // تمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


النتيجة:
![النص المظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

تمكنك Aspose.Slides لـ .NET من تطبيق ألوان خلفية على فقرات كاملة أو أجزاء نصية فردية في شرائح PowerPoint. هذه الوظيفة مفيدة عندما تريد تظليل كلمات أو عبارات محددة، أو جذب الانتباه إلى رسائل رئيسية، أو تحسين الجاذبية البصرية لعروضك التقديمية.

المثال البرمجي التالي يوضح كيفية تعيين لون الخلفية لل**فقرة بأكملها**:
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

المثال البرمجي أدناه يوضح كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط الغامق**:
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

تُعد محاذاة النص جانبًا أساسيًا في تنسيق الشرائح يؤثر على كل من قابلية القراءة والجاذبية البصرية. في Aspose.Slides لـ .NET، يمكنك التحكم بدقة في محاذاة الفقرات داخل إطارات النص، مما يضمن عرض المحتوى بصورة متسقة—سواءً كان مركزيًا، أو مَحاذً إلى اليسار، أو إلى اليمين، أو مبررًا. يوضح هذا القسم كيفية تطبيق وتخصيص محاذاة النص في عروض PowerPoint الخاصة بك.

المثال البرمجي التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:
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

## **تعيين الشفافية للنص**

يسمح ضبط شفافية النص بإنشاء تأثيرات بصرية دقيقة وتحسين جمالية الشرائح. توفر Aspose.Slides لـ .NET القدرة على تعيين مستوى شفافية الفقرات وأجزاء النص، مما يسهل دمج النص مع الخلفيات أو إبراز عناصر محددة. يوضح هذا القسم كيفية تطبيق إعدادات الشفافية على النص في عروضك.

المثال البرمجي أدناه يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:
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

المثال البرمجي التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:
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

تتيح لك Aspose.Slides ضبط التباعد بين الحروف في مربع النص. يتيح لك ذلك تعديل الكثافة البصرية لخط أو كتلة نصية عن طريق توسيع أو تضييق المسافة بين الأحرف.

الكود C# التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:
```cs
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

المثال البرمجي أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:
```cs
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

## **إدارة خصائص خط النص**

تتيح لك Aspose.Slides لـ .NET ضبط إعدادات الخط بدقة على مستوى الفقرة وعلى مستوى أجزاء النص الفردية، مما يضمن التناسق البصري وتلبية متطلبات تصميم العرض. يمكنك تحديد أنماط الخطوط، الأحجام، وخيارات التنسيق الأخرى لكافة الفقرات، مما يمنحك سيطرة أكبر على مظهر النص. يوضح هذا القسم كيفية إدارة خصائص الخط للنصوص الفقرية في الشريحة.

الكود التالي يحدد الخط ونمط النص للفقرة بأكملها: يطبق حجم الخط، غامق، مائل، تسطير منقط، وخط Times New Roman على جميع أجزاء الفقرة.
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

المثال البرمجي أدناه يطبق خصائص مشابهة على **أجزاء النص ذات الخط الغامق**:
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

يمكن أن يعزز تدوير النص تخطيط شرائحك ويساعد على إبراز محتوى معين. باستخدام Aspose.Slides لـ .NET، يمكنك بسهولة تطبيق دوران على النص داخل الأشكال، وضبط الزاوية لتتناسب مع تصميمك. يوضح هذا القسم كيفية تعيين والتحكم في دوران النص لتحقيق التأثير البصري المطلوب.

الكود التالي يضبط اتجاه النص في الشكل إلى `Vertical270`، مما يدير النص **90 درجة عكس اتجاه عقارب الساعة**:
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

يسمح تعيين زاوية دوران مخصصة لـ `TextFrame` بوضع النص بزايا دقيقة، مما يتيح تصاميم شرائح أكثر إبداعًا ومرونة. توفر Aspose.Slides لـ .NET تحكمًا كاملًا في دوران إطارات النص، مما يسهل محاذاة النص مع عناصر الشريحة الأخرى. يوضح هذا القسم كيفية تطبيق زاوية دوران محددة على `TextFrame`.

الكود التالي يدور إطار النص بزاوية 3 درجات باتجاه عقارب الساعة داخل الشكل:
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

## **ضبط تباعد الأسطر للفقرات**

توفر Aspose.Slides الخصائص `SpaceAfter` و `SpaceBefore` و `SpaceWithin` ضمن فئة [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/)، مما يتيح لك إدارة تباعد الأسطر لفقرة. تُستخدم هذه الخصائص كما يلي:

* استخدام قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدام قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد الأسطر داخل الفقرة:
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

## **تعيين نوع الضبط التلقائي لإطارات النص**

تحدد الخاصية AutoFitType كيفية تصرف النص عندما يتجاوز حدود الحاوية. تسمح لك Aspose.Slides لـ .NET بالتحكم فيما إذا كان النص يجب أن يتقلص ليتناسب، أو يتجاوز، أو يعيد تحجيم الشكل تلقائيًا. يوضح هذا القسم كيفية تعيين `AutofitType` لـ `TextFrame` لإدارة تخطيط النص بفعالية داخل الأشكال.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **تعيين مرساة إطارات النص**

تحدد المرساة كيفية وضع النص داخل الشكل رأسياً. باستخدام Aspose.Slides لـ .NET، يمكنك تعيين نوع المرساة لـ `TextFrame` لمحاذاة النص إلى أعلى، أو وسط، أو أسفل الشكل. يوضح هذا القسم كيفية تعديل إعدادات المرساة لتحقيق محاذاة رأسية مرغوبة لمحتوى النص.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **تعيين جدولة النص**

تساعد الجدولة على تنظيم النص في تخطيطات منظمة جيدًا عن طريق إضافة مسافات متسقة بين عناصر المحتوى. يدعم Aspose.Slides لـ .NET ضبط فواصل تبويب مخصصة داخل فقرات النص، مما يتيح تحكمًا دقيقًا في موضع النص. يوضح هذا القسم كيفية تكوين جدولة النص لتحسين المحاذاة والتنسيق.
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
![فواصل الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية `LanguageId` ضمن فئة [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)، والتي تسمح لك بتعيين لغة التدقيق لتوثيق PowerPoint. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء نصي:
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

يضمن تحديد اللغة الافتراضية للنص صحة تدقيق الإملاء، وتقطيع الكلمات، وسلوك تحويل النص إلى كلام في PowerPoint. تسمح لك Aspose.Slides لـ .NET بتعيين اللغة على مستوى جزء النص أو الفقرة. يوضح هذا القسم كيفية تعريف اللغة الافتراضية لنص العرض التقديمي الخاص بك.
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // إضافة شكل مستطيل جديد مع نص.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // التحقق من لغة الجزء الأول.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **تعيين نمط النص الافتراضي**

إذا كنت بحاجة إلى تطبيق نفس تنسيق النص الافتراضي على جميع عناصر النص في العرض مرة واحدة، يمكنك استخدام الخاصية `DefaultTextStyle` من واجهة [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) وتعريف التنسيق المفضل لديك.

الكود التالي يوضح كيفية تعيين خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.
```cs
using (var presentation = new Presentation())
{
    // الحصول على تنسيق الفقرة المستوى الأعلى.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **استخراج النص مع تأثير الحروف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو كان مكتوبًا أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمعالجة ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)— إذا كان يشير إلى `All`، قم ببساطة بتحويل السلسلة المسترجعة إلى أحرف كبيرة بحيث يتطابق الناتج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا مربع نص التالي على الشريحة الأولى من ملف sample2.pptx.
![تأثير الحروف الكبيرة](all_caps_effect.png)

المثال البرمجي أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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


الناتج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام كائن [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). يمكنك المرور على جميع الخلايا في الجدول وتغيير النص في كل خلية عبر الوصول إلى خصائص `TextFrame` و `ParagraphFormat` داخل كل خلية.

**كيف يمكن تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم الخاصية `FillFormat` في [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). اضبط `FillFormat` على `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للمتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير المتدرج على النص.