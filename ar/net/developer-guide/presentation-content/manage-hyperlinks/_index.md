---
title: إدارة ارتباطات العرض التقديمي في .NET
linktitle: إدارة الارتباطات
type: docs
weight: 20
url: /ar/net/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة ارتباط تشعبي
- إنشاء ارتباط تشعبي
- تنسيق ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- ارتباط تشعبي نصي
- ارتباط تشعبي شريحة
- ارتباط تشعبي شكل
- ارتباط تشعبي صورة
- ارتباط تشعبي فيديو
- ارتباط تشعبي قابل للتغيير
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة، تنسيق، تحديث، وإزالة الارتباطات التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET، مع أمثلة C#."
---
## **مقدمة**

يوفر الارتباط التشعّبي اتصالًا بين محتوى العرض التقديمي وموقع ويب أو موقع داخل العرض التقديمي. في PowerPoint، عادةً ما يخدم الارتباطات التشعبية غرضين:
* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

Aspose.Slides for .NET يتيح لك إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. توضح الأمثلة أدناه كيفية العمل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **إضافة ارتباطات URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعيّن إليه الارتباط التشعّبي يحدد المنطقة القابلة للنقر: جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

للعروض التقديمية التي تحتوي على ارتباطات تشعبية نسبية، انظر [إدارة قاعدة الارتباط التشعّبي](/slides/ar/net/presentation-properties/#manage-the-hyperlink-base) للقراءة أو التغيير أو مسح القاعدة على مستوى المستند.

### **إضافة ارتباطات URL إلى النص**

لربط النص بموقع ويب، عيّن [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) إلى خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) لجزء النص، كما هو موضح أدناه. يصبح ذلك الجزء فقط من النص قابلًا للنقر.

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

### **إضافة ارتباطات URL إلى الأشكال وإطارات الوسائط**

لجعل شكل أو إطار قابل للنقر، اضبط خاصية [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) الخاصة به. الارتباط التشعّبي يخص الكائن نفسه وليس جزء نص داخل ذلك الكائن.

ينطبق النهج نفسه على إطارات الصورة والصوت والفيديو: عيّن الارتباط التشعّبي إلى الإطار واضبط [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) للارتباط إذا لزم الأمر.

المثال التالي يجعل المستطيل قابلًا للنقر:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **استخدام الارتباطات التشعبية لإنشاء جدول محتويات**

تمكن الارتباطات التشعبية الداخلية القرّاء من الانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

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

## **تنسيق الارتباطات التشعبية**

### **اللون**

تحدد خاصية [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) لـ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) ما إذا كان الارتباط التشعّبي يستخدم لون الارتباط التشعّبي للعرض التقديمي أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

المثال التالي يضيف ارتباطي نص إلى نفس الشريحة. الأول يستخدم تعبئة نصية حمراء، بينما الثاني يحتفظ باللون الافتراضي للارتباط التشعّبي.

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

يمكن للارتباط التشعّبي تشغيل صوت عند تفعيله أو إيقاف صوت يُشغل بالفعل. استخدم الخصائص التالية لتكوين هذه السلوكيات:
- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) يحدد الصوت المرتبط بالارتباط التشعّبي.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) يتحكم فيما إذا كان تفعيل الارتباط التشعّبي يوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعّبي**

المثال التالي يحمل الملف `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

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

#### **استخراج صوت الارتباط التشعّبي**

المثال التالي يفتح العرض التقديمي المُنشئ أعلاه ويقرأ صوت الارتباط التشعّبي للشكل الأول إلى الذاكرة عبر [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) و[BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **تلميح الأدلة وإعدادات التفاعل**

يمكنك تحديث الخصائص التالية لـ [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) بعد تعيين ارتباط تشعّبي إلى نص أو شكل:
- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) يحدد النص الذي يمكن للمُشاهد عرضه كتلميح للارتباط.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML أمًّا كانت، إذا كان ذلك مناسبًا.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) يتحكم فيما إذا كان تنشيط الارتباط يضيف وجهته إلى قائمة الارتباطات المشاهدة.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) يتحكم فيما إذا كان الارتباط يُبرز عند النقر.

## **إزالة الارتباطات التشعبية من العروض التقديمية**

استخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لجمع حاويات الارتباطات التشعبية، بما في ذلك روابط أجزاء النص، قبل تعديلها. المثال التالي يزيل كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) أو [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); إزالة إجراء النقر لا يزيل نظيره عند مرور الفأرة.

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

للإزالة غير المشروطة، [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) يزيل كلا نوعي التنشيط في النطاق المحدد في استدعاء واحد. لتنظيف انتقائي وتغطية الماسترز، التخطيطات، والملاحظات، انظر [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض تقديمي، قم بجرد الإجراءات التفاعلية بالإضافة إلى روابط الويب الخاصة به. تُعيد [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) و[HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

قد يؤدي فحص الارتباطات التشعبية على مستوى الشكل فقط إلى فقدان الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المسترجعة لتتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **استعلام عن نطاقات العرض التقديمي، الشريحة، وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) متوفرة عبر [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/)، [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/)، و[ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). كل نطاق يدعم نفس الاستعلامات:
- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) تُعيد الحاويات التي لها إجراء نقر.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) تُعيد الحاويات التي لها إجراء مرور الفأرة.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) تُعيد الحاويات التي لها أحد الإجراءين أو كليهما.

المثال التالي يُنشئ الملف `hyperlink-audit-input.pptx` مع رابط نقر خارجي، رابط مرور الفأرة لملف، تنقل شريحة داخلي، رابط مرور الفأرة لنص، وإجراء ماكرو. لا ينفّذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها على كل نطاق؛ الأعداد تصف الحاويات، لا مجموعات الإجراءات. نطاق إطار النص لا يتضمن روابط الشكل المحيط.

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

في هذا المثال، تقارير استعلامات العرض التقديمي والشريحة كل منها تشير إلى ثلاث حاويات نقر، حاويتين مرور الفأرة، وثلاث حاويات ذات أي إجراء. تقرير إطار النص يُظهر حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) لتفسير الإجراء قبل تفسير وجهته. قيم [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) تغطي أكثر من تنقل الويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعّبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسَّر في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ مراجعة منفصلة عن عناوين URL الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) والوجهات الداخلية المحددة من [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على عنوان URL خارجي؛ عنوان URL الفارغ لا يعني أن الحاوية لا تملك إجراء. احتفظ بـ [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) عندما يختلف عن عنوان URL المُعَدل، وضمّن [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) عندما يكون متاحًا.

### **التقرير، التنظيف، والتحقق من الارتباطات التشعبية**

المثال التالي على .NET 6+ يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`، يطبّق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يعيد فتحه للتحقق من كلا نوعي التنشيط مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم مساواة المرجع لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لجرد شامل على مستوى الحزمة، يستعلم صراحةً عن الماسترز، التخطيطات، الملاحظات، والماستر للملاحظات وتوزيع الأوراق عند وجودها.

يسجل التقرير فهرس الشريحة (بدءًا من 1) و[SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) حيثما كان متاحًا. يوفر [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) الشريحة المالكة للحاويات المدعومة. لا تمتلك الماسترز، التخطيطات، والملاحظات فهرس شريحة عادي وتُحدد بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ الأنواع الأخرى تحتفظ باسم النوع في وقت التشغيل. يحصل كل حاوية على معرف تقرير محلي لتتم ربط إجراءاتها.

تسمح هذه السياسة التطبيقية المقيدة عمدًا فقط بعناوين URL مطلقة عبر HTTPS وعناوين شريحة داخلية صالحة. ترفض الماكرو، البرامج، إجراءات الملفات، إجراءات عرض الشرائح الأخرى، الإجراءات غير المعروفة، وبروتوكولات URL أخرى. هذه الرفضات هي قرارات سياسة، لا حكم أمان من Aspose.Slides. لا يضمن HTTPS وحده الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من عناوين URL الخارجية الأصلية والمعدلة. يراجع المثال البيانات الوصفية دون متابعة الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) الخاص بالحاوية [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)، و[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية المنقوصة بصفحة هبوط HTTPS ثابتة؛ تُزال الروابط والنقرات غير المسموح بها بشكل مستقل. اضبط `replaceExternalClicks` إلى `false` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة بديلة مملوكة للتطبيق قبل النشر.

علم تصدير التقرير يستخدم سياسة مراجعة PDF تحفظية: يعلّم إجراءات مرور الفأرة وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة محددة على أنه قد لا يكون مدعومًا. إنها إشارة مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير المعلّمة عند التصدير. قد تحافظ الصادرات المدعومة من [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/net/convert-powerpoint-to-html/) على الارتباطات، حسب الإجراء، خيارات التصدير، والمشاهد. لا يمكن للصور النقطية [images](/slides/ar/net/convert-powerpoint-to-png/) و[video](/slides/ar/net/convert-powerpoint-to-video/) الحفاظ على الارتباطات التفاعلية؛ علم كل إجراء عند التدقيق لتلك المخرجات.

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

مع الإدخال المُنشأ أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يُزال رابط مرور الفأرة للملف والماكرو النقر، بينما تظل الروابط HTTPS والتنقل الداخلي محفوظة. تُظهر عملية التحقق عدم وجود إجراءات محظورة. الإدخال الذي يحتوي على رابط نقر خارجي محظور أيضًا يجرّب فرع الاستبدال. الحاوية التي لديها نقر مسموح ومرور فأرة محظور تحتفظ بإجراء النقر.

هذا التنظيف الانتقائي يختلف عن [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)، الذي يزيل كلا نوعي التنشيط في جميع النطاقات المحددة بغض النظر عن السياسة. التحقق هنا يتحقق فقط من إجراءات الارتباط التشعّبي؛ لا يزيل مشاريع VBA المضمنة أو كائنات OLE أو محتوى نشط آخر، ولا يتحقق من صحة ملف PDF أو HTML المصدر.

## **الأسئلة المتكررة**

**كيف يمكنني ربط قسم أو شريحته الأولى؟**

تُجَمّع الأقسام في PowerPoint الشرائح، لكن الارتباط التشعّبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعّبي لعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسة (الماستر) والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل سيتم الاحتفاظ بالارتباطات التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ صادرات PDF وHTML المدعومة على الارتباطات التشعبية؛ لا يمكن للصور النقطية أو الفيديو حفظ الارتباطات التفاعلية. انظر اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).