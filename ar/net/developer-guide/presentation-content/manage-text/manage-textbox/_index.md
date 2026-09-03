---
title: إدارة صناديق النص في العروض التقديمية باستخدام .NET
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/net/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتحديد وتنسيق وتحديث صناديق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET."
---
## **المقدمة**

في Aspose.Slides for .NET، يتم تخزين نص الشريحة في إطارات النص التي تنتمي إلى الأشكال. تمثل الواجهة [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) الشكل الأكثر شيوعًا الذي يحمل النص وتكشف عن نصه عبر الخاصية [IAutoShape.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="ملاحظة" %}}
كل شكل تلقائي ينفذ [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، ولكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نص. عند معالجة عرض تقديمي موجود، تحقق من أن الشكل ينفذ `IAutoShape` قبل الوصول إلى نصه.
{{% /alert %}}

## **إنشاء مربع نص على الشريحة**

لإنشاء مربع نص، قم بإضافة شكل تلقائي إلى شريحة، أضف نصًا إلى إطار النص الخاص به، واحفظ العرض التقديمي. المثال التالي ينشئ مربع نص مستطيل:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

الإحداثيات والأبعاد الممرَّرة إلى [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addautoshape/) تُقاس بالنقاط. تقوم [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/addtextframe/) بتهيئة إطار النص بالنص المزوَّد.

## **التحقق من كون الشكل مربع نص**

استخدم الخاصية [AutoShape.IsTextBox](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/istextbox/) لتحديد ما إذا كان الشكل التلقائي يُعامل كمربع نص. هذا مفيد عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![مربع نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في عرض تقديمي:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

لا يُعتبر الشكل التلقائي المضاف حديثًا مربع نص حتى يحتوي على نص غير فارغ. يمكنك توفير ذلك النص عبر [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/addtextframe/) أو [ITextFrame.Text](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/text/). إضافة أو تعيين سلسلة فارغة يترك `IsTextBox` مضبوطًا على `false`:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

الاستدعاءان الأولان يطبعان `True`؛ والاستدعاءان الأخيران يطبعان `False`.

## **إيجاد الشكل الذي يمتلك إطار نص**

قد يتلقى كود معالجة النص العامة كائنًا من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم الخاصية للقراءة فقط [ITextFrame.ParentShape](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentshape/) للعودة إلى [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) المالك.

لإطار نص مملوك لشكل تلقائي أو شكل آخر يحمل نصًا، يحتوي `ParentShape` على المالك وتكون [ITextFrame.ParentCell](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/parentcell/) `null`. تحقق من القيمة المرجعة قبل الوصول إليها. لتحديد كل من مالكي الشكل وخلية الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/net/search-and-replace-text/).

## **إضافة أعمدة إلى مربع النص**

خاصية [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/columncount/) تقسم إطار النص إلى أعمدة، بينما [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/columnspacing/) تحدد الفجوة بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى [ITextFrameFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/) ويمكن تغييرهما عبر إطار النص لمربع نص موجود. يعيد تدفق النص بين الأعمدة داخل الشكل نفسه؛ لا يستمر في شكل آخر.

المثال التالي ينشئ مربع نص ثلاثي الأعمدة مع 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرأ الإعدادات المخزنة مرة أخرى من ملف الإخراج:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **استخراج النص من الأعمدة الفردية**

استخدم [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/ar/net/aspose.slides/textframe/splittextbycolumns/) لاسترجاع النص المخصص لكل عمود مرئي في إطار نص موجود. تُرجع الطريقة سلسلة واحدة لكل عمود، بترتيب القراءة القائم على الأعمدة. ينتج إطار نص عمود واحد مصفوفة ذات عنصر واحد، والعمود الفارغ يُمثَّل بسلسلة فارغة. السلاسل تحتوي على نص عادي فقط؛ لا يتم الحفاظ على تنسيق المستويات الجزئية.

هذا مفيد عندما تحتاج إلى:
- استخراج النص مع الحفاظ على ترتيب القراءة القائم على الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل، أو حقل قاعدة بيانات، أو وجهة أخرى.
- فحص كيفية إعادة توزيع النص بعد تغيير [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/columncount/)، [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframeformat/columnspacing/)، الخط، أو حجم إطار النص.

الطريقة تُبلغ عن النص الموزع داخل [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) الحالي؛ لا تقوم تلقائيًا بتدفق النص بين أشكال أو مربعات نص منفصلة. قد يعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرض تقديمي، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرأ عدد الأعمدة المُكوَّن، ويكتب النص من كل عمود إلى ملف منفصل. تُهمل الأشكال التي لا توفّر إطار نص.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **تحديث النص**

لتحديث النص في جميع أنحاء عرض تقديمي، كرّر عبر الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرّر أجزاء نصها. العمل على مستوى الجزء يتيح لك تغيير كلًا من النص وتنسيق الأحرف.

المثال التالي يستبدل كل تواجد لكلمة `years` بـ `months` في نص الشكل التلقائي ويجعل كل جزء متأثر غامقًا:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

هذا التجول يحدّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة يتطلب التجول في مجموعات تلك الكائنات الخاصة.

## **إضافة مربع نص مع ارتباط تشعبي**

يمكن تعيين ارتباط تشعبي إلى جزء نصي محدد، بحيث يكون ذلك النص فقط هو القابل للنقر. استخدم [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) لربط الجزء بعنوان URL خارجي.

المثال التالي ينشئ نصًا مرتبطًا ويحفظه إلى عرض تقديمي:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **الأسئلة الشائعة**

**ما هو الفرق بين مربع النص وعلامة النص النائبة على الشريحة الرئيسية أو شريحة التخطيط؟**

يمكن لـ [placeholder](/slides/ar/net/manage-placeholder/) أن يرث موقعه وتنسيقه من [master slide](https://reference.aspose.com/slides/ar/net/aspose.slides/masterslide/) أو [layout slide](https://reference.aspose.com/slides/ar/net/aspose.slides/layoutslide/). مربع النص العادي هو شكل مستقل على الشريحة التي تم إنشاؤه فيها ولا يكتسب سلوك العنصر النائب عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

حدد التجول إلى الأشكال التي تنفّذ [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/)، كما هو موضح في مثال تحديث النص. المخططات والجداول وSmartArt تخزن النص في نماذج كائناتها الخاصة، لذا لا يتم تعديلها بهذه الحلقة.