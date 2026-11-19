---
title: إدارة الروابط التشعبية للعرض التقديمي في .NET
linktitle: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/net/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي للنص
- رابط تشعبي للشريحة
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة، تنسيق، تحديث، وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET، مع أمثلة بلغة C#."
---
## **المقدمة**

يُربط الارتباط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، يُستَخدم الارتباط التشعبي عادةً لهدفين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

Aspose.Slides for .NET يتيح لك إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية العمل مع الروابط التشعبية على عناصر فردية وكيفية الوصول إلى الروابط على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}

يمكنك أيضًا تحرير العروض التقديمية باستخدام [المحرر المجاني عبر الإنترنت لبرنامج Aspose PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الارتباط التشعبي يحدد منطقة النقر: جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

لعروض تحتوي على روابط تشعبية نسبية، راجع [إدارة أساس الارتباط التشعبي](/slides/ar/net/presentation-properties/#manage-the-hyperlink-base) للقراءة أو التغيير أو مسح الأساس على مستوى المستند.

### **إضافة روابط URL إلى النص**

لربط نص بموقع ويب، عيّن [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) لجزء النص، كما هو موضح أدناه. يصبح ذلك الجزء فقط من النص قابلاً للنقر.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

عيّن URL إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) للمستطيل لجعل مساحته بالكامل قابلة للنقر. تُظهر خاصية [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) تلميحًا للقراء حول الوجهة عند تمرير الماوس فوق المستطيل. نفس الخصائص تنطبق على إطارات الصورة والصوت والفيديو.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

تُتيح الروابط التشعبية الداخلية للقراء القفز من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) لربط النص “Page 2” في الشريحة الأولى بالشريحة الثانية.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **تنسيق الروابط التشعبية**

يمكنك تغيير لون النص المربوط، تشغيل أو إيقاف صوت عندما يُفعّل القارئ الرابط، وتعيين تلميح الأدوات الذي يظهر عند المرور.

### **اللون**

تحدِّد خاصية [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) لكائن [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي للعرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) واضبط لون ملء الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

في هذا المثال، يجعل تعيين [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) على الرابط الأول يظهر نصه باللون الأحمر. الرابط الثاني يحتفظ بلون الارتباط التشعبي للعرض.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **الصوت**

يمكن للارتباط التشعبي تشغيل صوت عند تنشيطه أو إيقاف صوت يُشغَل بالفعل. استخدم الخصائص التالية لتكوين هذه السلوكيات:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) يحدد الصوت المرتبط بالارتباط التشعبي.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) يتحكم فيما إذا كان تنشيط الارتباط التشعبي يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

يستخدم الزر في الشريحة الأولى خاصية [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) لتشغيل صوت من ملف WAV عند النقر للتقدم. في الشريحة الثانية، يستخدم زر منفصل خاصية [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) لإيقاف التشغيل وإبقاء القارئ على تلك الشريحة.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **استخراج صوت الارتباط التشعبي**

يفتح المثال التالي العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر خاصية [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) و[BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **إعدادات تلميحات الأدوات والتفاعل**

يمكنك تحديث الخصائص التالية لكائن [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) يحدد النص الذي يمكن للمُشاهِد عرضه كتلميح للارتباط.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML أصلية، إذا كان ذلك مناسبًا.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) يتحكم فيما إذا كان تنشيط الرابط يضيف وجهته إلى قائمة الروابط التي تمت مشاهدتها.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) يتحكم فيما إذا كان يُبرز الارتباط التشعبي عند النقر.

## **إزالة الروابط التشعبية من العروض التقديمية**

استخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع حاويات الروابط، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) أو [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)؛ إزالة فعل النقر لا يزيل ما يعادله من فعل مرور الماوس.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

لإزالة غير مشروطة، [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) يزيل كلا نوعي التنشيط في النطاق المحدد في استدعاء واحد. للحصول على تنظيف انتقائي وتغطية للماستر، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **مسح الروابط التشعبية قبل استبدال نص SmartArt**

عند استبدال فقرة في عقدة SmartArt موجودة، قد يترك مسح أجزاء النص رابطًا تشعبيًا قديمًا فعالًا. استرجع الفقرة عبر [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). قبل مسح أجزائها، استدعِ [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) عبر كائن [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) على إطار النص لشكل العقدة الذي يعرض الفقرة. يزيل هذا كل الارتباطات في ذلك الإطار، بما في ذلك الروابط في فقراته الأخرى.

يفترض المثال أن الشكل الثالث في الشريحة الأولى هو رسم SmartArt. يستبدل الفقرة الأولى من العقدة الرابعة. في هذا العرض، يعرض الشكل الأول للعقدة تلك الفقرة.

بعد إضافة كلا الجزأين، يقرأ المثال تنسيقهما الفعّال عبر [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). تُعيد الخاصية الفعّالة [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) الرابط التشعبي الجديد للجزء الأول و`null` للثاني.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **إنشاء جرد كامل للروابط التشعبية**

قبل توزيع عرض تقديمي، قم بجرد إجراءاته التفاعلية بالإضافة إلى روابطه على الويب. تُعيد [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)، ليست قائمة مسطحة من سلاسل URL. افحص كل من [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) و[HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تُظهر كلا الفعلين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

فحص الروابط على مستوى الشكل فقط قد يتغاضى عن الروابط المرتبطة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات التي تم إرجاعها لتتمكن لاحقًا من تحديث أو إزالة أفعالها.

### **استعلام عن نطاقات العرض، الشريحة، وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) متاحة عبر [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)، [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)، و[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). يدعم كل نطاق نفس الاستعلامات:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) يُرجع الحاويات التي لها فعل نقر.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) يُرجع الحاويات التي لها فعل مرور ماوس.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) يُرجع الحاويات التي لها أي من الفعلين أو كليهما.

يعطي هذا المثال أفعال النقر والمرور إلى شكل ونصه، وإجراء ماكرو إلى زر منفصل. يقارن الحاويات التي تُرجعها [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) مع عدد كل نوع من أفعال التنشيط. استعلام إطار النص يُحصي الروابط في النص فقط. تظهر أفعال الشكل نفسه في استعلامات الشريحة والعرض.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

في هذا المثال، تُظهر استعلامات العرض والشريحة كلٌ منها ثلاثة حاويات نقر، حاويتين مرور ماوس، وثلاث حاويات تحتوي على أي من الفعلين. يُظهر استعلام إطار النص حاوية واحدة في كل فئة.

### **تصنيف الأفعال والوجهات**

استخدم [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) لتفسير الفعل قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) ما هو أكثر من تنقل ويب:

| القيم | المعنى لتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسَّر في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ قدِّم مراجعة منفصلة عن روابط الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا عمل تنقل، أو فعل غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) والوجهات الداخلية المحددة من [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). قد لا تحتوي الأفعال الداخلية والأوامر المدمجة على URL خارجي؛ URL فارغ لا يعني أن الحاوية لا تحوي فعلًا. احفظ [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) عندما يختلف عن URL المُعَدل، واشمل [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) إذا كان متوفرًا.

### **تقرير، تنقية، والتحقق من الروابط التشعبية**

يفتح مثال .NET 6+ هذا العرض من المثال السابق ويكتب سجلًّا بصيغة JSON لكل فعل. يستخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع الحاويات على الشرائح العادية، الماسترز، التخطيطات، والملاحظات، بما في ذلك ماستر الملاحظات والنسخة المطبوعة عند وجودهما. يستخدم مساواة مرجعية لحساب كل حاوية مرة واحدة، يُطبق السياسة الموضحة أدناه، ثم يعيد فتح العرض المُحَفَظ للتحقق من كل من أفعال النقر ومرور الماوس.

يسجِّل التقرير فهرس شريحة يبدأ من 1 و[SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) عند توفره. يُوفر [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) الشريحة المالكة للحاويات المدعومة. لا تمتلك الماسترز، التخطيطات، والملاحظات فهرس شريحة عادي وتُعرَّف بنطاقها. تُوسَّم حاويات الأشكال وحاويات تنسيق أجزاء النص منفصلًا؛ تحتفظ الأنواع الأخرى باسم نوعها في وقت التنفيذ. يحصل كل حاوية على معرف محلي في التقرير لتُربط أفعالها معًا.

هذه السياسة التقييدية تسمح فقط بروابط HTTPS مطلقة ووجهات شرائح داخلية صالحة. تُرفض الماكروهات، البرامج، أفعال الملفات، أفعال عرض الشرائح الأخرى، الأفعال غير المعروفة، ومخططات URL الأخرى. هذه الرفضات قرارات سياسة، ليست حكمًا أمانًا من Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من URL الأصلي والـ URL المُعدَّل. يراجع المثال بيانات التعريف دون اتباع الروابط أو تنفيذ الأفعال.

للتصحيح، يدعم [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) الخاص بالحاوية [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)، و[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُحذف باقي الأفعال غير المسموح بها بشكل مستقل. عيّن `replaceExternalClicks` إلى `false` لإزالة جميع انتهاكات السياسة بدلاً من الاستبدال. اختر صفحة استبدال مملوكة لتطبيقك قبل النشر.

علامة تصدير التقرير تستخدم سياسة مراجعة PDF تحفظية: تُعلِّم أفعال مرور الماوس وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة محددة بأنه قد يكون غير مدعوم. إنها إشعار مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير المؤشرة عند التصدير. قد تحافظ عمليات تصدير [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/net/convert-powerpoint-to-html/) المدعومة على الروابط حسب الفعل، خيارات التصدير، والمشاهد. لا تستطيع [الصور](/slides/ar/net/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/net/convert-powerpoint-to-video/) حفظ الروابط التفاعلية؛ علِّم كل فعل عند التدقيق لتلك النواتج.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

مع المدخل المُنشأ أعلاه، يحتوي التقرير على خمسة صفوف أفعال. يُزال رابط مرور الماوس للملف والماكرو النقر، بينما تُبقى روابط HTTPS والتنقل الداخلي إلى الشرائح. تطبع عملية التحقق صفر أفعال محظورة. يُظهر مدخل يحتوي على رابط خارجي غير مسموح به فرع الاستبدال. حاوية ذات نقرة مسموح بها ومرور ماوس غير مسموح يُبقي فعل النقر.

هذا التنظيف الانتقائي يختلف عن [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)، الذي يُزيل كلا الفعلين في النطاق المحدد بغض النظر عن السياسة. التحقق هنا يركّز على أفعال الارتباط التشعبي فقط؛ لا يزيل مشروعات VBA المضمَّنة، كائنات OLE، أو محتوى نشط آخر، ولا يتحقق من صحة ملفات PDF أو HTML المُصدَّرة.

## **الأسئلة الشائعة**

**كيف يمكنني الربط إلى قسم أو أول شريحة له؟**

تُجمع الشرائح في PowerPoint ضمن أقسام، لكن الارتباط التشعبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي لعناصر شريحة الماستر لتعمل على جميع الشرائح؟**

نعم. تدعم عناصر شريحة الماستر والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشريحة التي تستخدم الماستر أو التخطيط المقابل.

**هل ستُحافظ الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تُحافظ عمليات تصدير PDF وHTML المدعومة على الروابط التشعبية؛ لا يمكن للصور النقطية والفيديو حفظ الروابط التفاعلية. راجع اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).