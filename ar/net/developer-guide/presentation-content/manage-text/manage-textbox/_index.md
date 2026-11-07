---
title: "إدارة صناديق النص في العروض التقديمية في .NET"
linktitle: "إدارة صندوق النص"
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
description: "إنشاء وتحديد وتنسيق وتحديث صناديق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET."
---
## **المقدمة**

في Aspose.Slides for .NET، يتم تخزين نص الشريحة في إطارات نصية تنتمي إلى الأشكال. تمثل الواجهة [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) الشكل الأكثر شيوعًا الذي يحمل نصًا وتكشف نصه عبر الخاصية [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="ملاحظة" %}}

كل شكل تلقائي ينفذ [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، لكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نص. عند معالجة عرض تقديمي موجود، تحقق من أن الشكل ينفذ `IAutoShape` قبل الوصول إلى نصه.

{{% /alert %}}

## **إنشاء صندوق نص على شريحة**

لإنشاء صندوق نص، أضف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطار نصه، واحفظ العرض التقديمي. المثال التالي ينشئ صندوق نص مستطيل:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

الإحداثيات والأبعاد التي تم تمريرها إلى [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) تُقاس بالنقاط. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) يُهيئ إطار النص بالنص المقدم.

## **التحقق من شكل صندوق النص**

استخدم خاصية [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) لتحديد ما إذا كان الشكل التلقائي يُعامل كصندوق نص. هذا مفيد عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![صندوق نص وشكل](istextbox.png)

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

لا يُعتبر الشكل التلقائي المضاف حديثًا صندوق نص حتى يحتوي على نص غير فارغ. يمكنك توفير ذلك النص عبر [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) أو [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). إضافة أو تعيين سلسلة فارغة يترك `IsTextBox` مضبوطة على `false`:

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

النداءان الأوليان يطبعان `True`؛ الأخيران يطبعان `False`.

## **العثور على الشكل الذي يمتلك إطار نص**

قد يتلقى كود معالجة النص العام كائنًا من نوع [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم الخاصية للقراءة فقط [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) للعودة إلى الشكل المالكة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

بالنسبة لإطار نص مملوك لشكل تلقائي أو شكل آخر يحمل نصًا، يحتوي `ParentShape` على المالك وتكون [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) `null`. تحقق من القيمة المرجعة قبل الوصول إليها. لتحديد كل من مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، انظر [Search and Replace Text](/slides/ar/net/search-and-replace-text/).

## **الحصول على مستطيل نص الشكل**

بدءًا من Aspose.Slides for .NET 26.11، تُعيد الدالة [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) مساحة النص المحددة بواسطة هندسة الشكل الأب. إحداثياتها وأبعادها بالنقاط،相 بالنسبة إلى الزاوية اليسرى العليا لذلك الشكل. على سبيل المثال، تكون للمقوس مستطيل نص أصغر من حدودها الخارجية.

هذا المستطيل يصف الشكل، وليس الأحرف المُرسَمة. تغيير النص أو هوامش إطار النص لا يجعله قياسًا للنص المحتل. استخدم [paragraph bounds](/slides/ar/net/paragraph-bounds/) أو [portion bounds](/slides/ar/net/portion-bounds/) لقياسات النص المُرسَم.

بعد [installing Aspose.Slides for .NET](/slides/ar/net/installation/) 26.11 أو أحدث، شغِّل هذا المثال لرسم مستطيل نص الهندسة باللون الأحمر. الأشكال غير مُدوَّرة وغير مُجمَّعة، لذا إضافة موضع X/Y يكفي لوضع التراكب على الشريحة.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

بالنسبة للأشكال ذات 200 × 100 نقطة أعلاه، يُعيد المستطيل `(0, 0, 200, 100)`؛ ويُعيد المقوس تقريبًا `(29.289, 14.645, 141.421, 70.711)`. الطريقة تقرأ أيضاً مستطيل النص المعلن لهندسة مخصصة. لا تُطبّق دوران مساحة الشريحة أو تحويلات المجموعة؛ احسب هذه التحويلات منفصلًا عند تموضع التراكب. قد يلقي إطار نص بدون شكل هندسي، مثل إطار نص خلية جدول، استثناء `InvalidOperationException`.

## **إضافة أعمدة إلى صندوق النص**

خاصية [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) تقسم إطار النص إلى أعمدة، بينما خاصية [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) تُحدد الفجوة بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) ويمكن تعديلهما عبر إطار النص في صندوق نص موجود. يعاد تدفق النص بين الأعمدة داخل نفس الشكل؛ ولا يتواصل إلى شكل آخر.

المثال التالي ينشئ صندوق نص بثلاثة أعمدة مع 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرأ الإعدادات المخزنة من ملف الإخراج:

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

استخدم الدالة [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) لاسترجاع النص المعين لكل عمود بصري في إطار نص موجود. تُعيد الدالة سلسلة واحدة لكل عمود، بترتيب القراءة حسب الأعمدة. ينتج إطار نص بعمود واحد مصفوفة بعنصر واحد، والعمود الفارغ يُمثَّل بسلسلة فارغة. تحتوي السلاسل على نص عادي فقط؛ لا يُحافظ على تنسيق المستوى الجزئي.

هذا مفيد عندما تحتاج إلى:
- استخراج النص مع الحفاظ على ترتيب القراءة حسب الأعمدة.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل أو حقل قاعدة بيانات أو وجهة أخرى.
- فحص كيفية إعادة توزيع النص بعد تغيير [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/)، [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/)، الخط، أو حجم إطار النص.

تُبلغ الطريقة النص الموزَّع داخل [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) الحالي؛ ولا تُعيد تدفق النص تلقائيًا بين أشكال أو صناديق نص منفصلة. قد يعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرأ عدد الأعمدة المكوَّن، ويكتب نص كل عمود إلى ملف منفصل. تُهمل الأشكال التي لا توفر إطار نص.

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

لتحديث النص في جميع أنحاء العرض التقديمي، قم بالتكرار عبر الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرّر أجزاء نصها. العمل على مستوى الجزء يتيح لك تغيير كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لكلمة `years` بـ `months` في نص الشكل التلقائي ويجعل كل جزء متأثر غامقًا:

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

هذا الاستعراض يُحدّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمَّعة يتطلب استعراض مجموعات تلك الكائنات الخاصة.

## **إضافة صندوق نص مع ارتباط تشعبي**

يمكن تعيين ارتباط تشعبي إلى جزء نص معين، بحيث يكون فقط ذلك النص هو الرابط القابل للنقر. استخدم [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) لربط الجزء بعنوان URL خارجي.

المثال التالي يُنشئ نصًا مرتبطًا ويحفظه إلى عرض تقديمي:

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

**ما الفرق بين صندوق النص وعناصر النائب النصي على شريحة رئيسية أو تخطيطية؟**

يمكن لعناصر [placeholder](/slides/ar/net/manage-placeholder/) أن تورث موقعها وتنسيقها من [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) أو [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). صندوق النص العادي هو شكل مستقل على الشريحة التي تم إنشاؤه فيها ولا يكتسب سلوك العنصر النائب عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

قصر الاستعراض على الأشكال التي تنفذ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)، كما هو موضح في مثال تحديث النص. تخزن المخططات والجداول وSmartArt النص في نماذج كائناتها الخاصة، لذا لا يتم تعديلها بهذه الحلقة.