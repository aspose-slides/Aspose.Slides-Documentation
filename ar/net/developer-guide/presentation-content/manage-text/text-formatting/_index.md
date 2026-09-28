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
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ .NET. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ .NET. وتشمل ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مواقع التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى تحتوي على النص المعروض أدناه. كلا من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاءً بالخط العريض تستخدم التنسيق الفعال، بما في ذلك تنسيق الخط العريض الموروث:

![نص عينة](sample_text.png)

للعثور على النص الحرفي أو مطابقة التعبيرات النمطية وتظليلهما، راجع [البحث واستبدال النص](/slides/ar/net/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/highlightcolor/) لأجزاء النص الفردية.

المثال التالي يحدد تظليل رمادي فاتح كافتراضي للفقرة الأولى. ألوان التظليل الصريحة على الأجزاء الفردية تتفوق على هذا الافتراضي:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين لون التظليل للفقرة بالكامل.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

النتيجة:
![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط الغامق**:
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
![الأجزاء النصية الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/alignment/) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة متمركزة، محاذاة لليسار، محاذاة لليمين، مبررة، وما إلى ذلك.

يعرض مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// تعيين محاذاة الفقرة إلى المركز.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```
النتيجة:
![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

يتم التحكم في شفافية النص عبر مكوّن ألفا للون المعيّن لـ[IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على مقياس 0–255، وليس نسبة شفافية.

يعرض مثال الشيفرة أدناه كيفية تطبيق الشفافية على **الفقرة بالكامل**:
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

يعرض مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:
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
![الأجزاء النصية الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/spacing/) لتوسيع أو تقليل التباعد بين الأحرف في مربع النص. تضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تُقلص النص.

يعرض كود C# التالي كيفية توسيع تباعد الأحرف في **الفقرة بالكامل**:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```
النتيجة:
![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يعرض مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:
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
        // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
        portion.PortionFormat.Spacing = 3;  // توسيع تباعد الأحرف.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```
النتيجة:
![تباعد الأحرف في الأجزاء النصية](character_spacing_in_text_portions.png)

### **إلغاء الترصيع لأحرف خطوط معينة**

في بعض الحالات، قد يبدو النص المُصدّر بواسطة Aspose.Slides أكثر إحكامًا قليلاً مقارنةً بالنص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الترصيع لبعض الخطوط، حتى عندما يحتوي الخط على معلومات ترصيع صالحة وتكون ميزة الترصيع مفعلة في إعدادات PowerPoint.

لجعل المخرجات المُصدّرة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك إلغاء ترصيع النص للأجزاء التي تستخدم الخط المتأثر. عيّن [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/kerningminimalsize/) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال الملف "presentation.pptx" مع مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويعيّن عتبة قدرها 100 نقطة للأجزاء التي تستخدم Roboto. هذا يلغي ترصيع الأجزاء المطابقة التي يكون حجم الخط فيها أقل من 100 نقطة:
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

بالنسبة للنص المتطابق الذي يكون أقل من العتبة، يمنع هذا الإعداد الترصيع وقد يساعد في مطابقة عرض Aspose.Slides مع النتيجة البصرية في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaultportionformat/) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض ومائل وتسطير منقّط. التنسيق الصريح على الأجزاء الفردية يتفوق على هذه الإعدادات الافتراضية.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// عيّن خصائص الخط للفقرة.
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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقّط على الأجزاء التي يكون تنسيقها الفعّال عريض:
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
        // عيّن خصائص الخط لجزء النص.
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

## **تعيين دوران النص**

استخدم [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/textverticaltype/) لتعيين اتجاه نص مسبق داخل الشكل.

يقوم مثال الشيفرة التالي بتعيين اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ar/net/aspose.slides/textverticaltype/)، الذي يدور النص **90 درجة عكس عقرب الساعة**:
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

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/rotationangle/) لتعيين زاوية دوران مخصصة لإطار نص [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/).

يرفع مثال الشيفرة التالي إطار النص بزاوية 3 درجات مع اتجاه عقرب الساعة داخل الشكل:
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

يوفر Aspose.Slides الخاصيات [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spaceafter/)، [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacebefore/)، و[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/spacewithin/) للتحكم في تباعد الفقرات. تُستخدم هذه الخاصيات كما يلي:
* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):
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

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل النص الضيقة والعروض التي تمزج بين النص اللاتيني والآسيوي الشرقي. الخصائص التالية تنتمي إلى [IParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/)، لذا تُطبق على الفقرة بأكملها:
- [LatinLineBreak](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/latinlinebreak/) يتحكم في قواعد كسر السطر اللاتيني. في النص المختلط، قد يؤدي تغييره إلى تغيير موضع تغليف النص الآسيوي الشرقي والرموز القريبة.
- [EastAsianLineBreak](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/eastasianlinebreak/) يتحكم في قواعد كسر السطر الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تُستبدل بـ [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/wraptext/)، الذي يفعّل الالتفاف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث الالتفاف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يفرض سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يعيّن كلا خاصيتي كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر قيمة الخاصية مع ترك الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial وSimSun بحجم 24 نقطة مع عرض إطار 160 نقطة وصفر هوامش أفقية لإطار النص. يتم تعيين [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/autofittype/) إلى [TextAutofitType.None](https://reference.aspose.com/slides/ar/net/aspose.slides/textautofittype/) بحيث يظل حجم النص وأبعاد الإطار ثابتين.
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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/hangingpunctuation/) يسمح للعلامات المسموح بها بالتمدد خارج الحافة اليمنى لسطر النص بدلًا من احتلال السطر التالي. ينطبق على الفقرة بأكملها ويختلف عن الإزاحة المتدلية.

المثال المستقل التالي يُفعّل علامات الترقيم المتدلية في إطار نص عرضه 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". باستخدام Arial بحجم 24 نقطة وصفر هوامش أفقية لإطار النص، يبقى النقطة النهائية بعد "sentence" وتتمدد خارج الحافة اليمنى للنص. عيّن الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تُحتل النقطة سطرًا منفصلًا. تم تمكين الالتفاف وتعطيل الملاءمة التلقائية للحفاظ على عرض ثابت.
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

ليس كل علامة ترقيم يمكن أن تتدلى. تُطبق [شروط الخط والتخطيط الموضحة أعلاه](#conditions-and-limitations) أيضًا على هذه المقارنة: قد يؤدي تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية إلى إزالة الاختلاف المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/autofittype/) يحدد سلوك النص عندما يتجاوز حدود الحاوية. استخدمه للتحكم فيما إذا كان النص يتقلص، يتجاوز، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يكوّن الشكل لإعادة حجمه ليتناسب مع النص ويحفظ النتيجة في "autofit_type.pptx".
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يؤثر تغيير عرض النص أو الشكل على النتيجة، راجع [Count Rendered Lines](/slides/ar/net/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين تثبيت إطارات النص**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/anchoringtype/) يحدد كيفية تموضع النص عموديًا داخل الشكل، على سبيل المثال في الأعلى أو الوسط أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **تعيين جدولة النص**

استخدم [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/defaulttabsize/) و[IParagraphFormat.Tabs](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraphformat/tabs/) لتكوين نقاط التبويب في فقرة. يحدد المثال التالي المسافة الافتراضية للتبويب إلى 100 نقطة ويضيف نقطة تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.
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
![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) التي تتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والنحو في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":
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

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا بالإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` لأول جزء نص.
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

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/defaulttextstyle/).

المثال التالي يعيّن خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات الافتراضية ما لم يتم تجاوزها بتنسيق أكثر تحديدًا.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// احصل على تنسيق الفقرة من المستوى الأعلى.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **استخراج النص مع تأثير الأحرف الكبيرة**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/net/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال ملف "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير الأحرف الكبيرة، كما هو موضح أدناه.
![تأثير الأحرف الكبيرة](all_caps_effect.png)

يوضح مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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
الناتج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكنني تعديل النص في جدول داخل شريحة؟**

لتعديل النص في جدول داخل شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/net/aspose.slides/itable/). قم بالتجول عبر الخلايا وحدث كل خلية عبر [ICell.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/icell/textframe/) وتنسيق الفقرات عبر [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/paragraphformat/).

**كيف يمكنني تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/fillformat/). عيّن [IFillFormat.FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/ifillformat/filltype/) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) وقم بتهيئة نقاط التدرج، الاتجاه، والشفافية.