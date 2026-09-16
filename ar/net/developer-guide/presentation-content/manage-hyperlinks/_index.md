---
title: إدارة ارتباطات العرض التقديمي في .NET
linktitle: إدارة الارتباطات التشعبية
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
- ارتباط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أضف، صمم، حدّث، وأزل الارتباطات التشعبية في عروض PowerPoint وعروض OpenDocument باستخدام Aspose.Slides for .NET، مع أمثلة C#."
---
## **مقدمة**

يُربط الارتباط التشعبي محتوى العرض بموقع ويب أو موقع داخل العرض نفسه. في PowerPoint، يُستخدم الارتباط التشعبي عادةً لغرضين:

* فتح موقع ويب من نص أو شكل أو إطار وسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح Aspose.Slides for .NET إضافة هذه الروابط، التحكم في مظهرها وصوتها، تحديث خصائصها، وإزالتها. تُظهر الأمثلة أدناه كيفية التعامل مع الارتباطات التشعبية على العناصر الفردية وكيفية الوصول إلى الارتباطات على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="ملاحظة" %}}

يمكنك أيضًا تعديل العروض باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/ar/editor).

{{% /alert %}} 

## **إضافة ارتباطات تشعبية إلى عناوين URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُعين إليه الارتباط التشعبي يحدد منطقة النقر: جزء النص يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

### **إضافة ارتباطات URL إلى النص**

لربط نص بموقع ويب، عيّن [Hyperlink](https://reference.aspose.com/slides/ar/net/aspose.slides/hyperlink/) إلى الخاصية [HyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/portionformat/hyperlinkclick/) لجزء النص، كما هو موضح أدناه. يصبح ذلك الجزء فقط من النص قابلاً للنقر.

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

لجعل شكل أو إطار قابلاً للنقر، اضبط خاصية [HyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/hyperlinkclick/) الخاصة به. الارتباط التشعبي ينتمي إلى الكائن نفسه وليس إلى جزء نص داخل الكائن.

ينطبق نفس النهج على إطارات الصور والصوت والفيديو: عيّن الارتباط التشعبي إلى الإطار واضبط خاصية [Tooltip](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/tooltip/) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلاً للنقر:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **استخدام الارتباطات لإنشاء جدول محتويات**

تسمح الارتباطات الداخلية للقارئ بالانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

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

تحدد الخاصية [ColorSource](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/colorsource/) لـ [IHyperlink](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/) ما إذا كان الارتباط التشعبي يستخدم لون الارتباط التشعبي للعرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/hyperlinkcolorsource/) واضبط لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

المثال التالي يضيف ارتباطين نصيين إلى نفس الشريحة. الأول يستخدم تعبئة نصية حمراء، بينما الثاني يحتفظ باللون الافتراضي للارتباط التشعبي.

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

يمكن للارتباط التشعبي تشغيل صوت عند تفعيله أو إيقاف صوت يُشغل بالفعل. استخدم الخصائص التالية لتكوين هذه السلوكيات:

- [IHyperlink.Sound](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/sound/) يحدد الصوت المرتبط بالارتباط التشعبي.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/stopsoundonclick/) يتحكم فيما إذا كان تفعيل الارتباط التشعبي يُوقف الصوت السابق.

#### **إضافة صوت للارتباط التشعبي**

المثال التالي يحمل `sampleaudio.wav` ويربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يُوقف الصوت السابق عند النقر، دون تنفيذ عملية انتقاليّة.

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

المثال التالي يفتح العرض الذي تم إنشاؤه أعلاه ويقرأ صوت الارتباط التشعبي للشكل الأول إلى الذاكرة عبر [Sound](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/sound/) و [BinaryData](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudio/binarydata/).

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

### **إعدادات التلميح والتفاعل**

يمكنك تحديث الخصائص التالية لـ [IHyperlink](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/) بعد تعيين ارتباط تشعبي إلى نص أو شكل:

- [Tooltip](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/tooltip/) يضبط النص الذي يمكن للمشاهد عرضه كتلميح للارتباط.
- [TargetFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/targetframe/) يحدد إطار الهدف داخل مجموعة إطارات HTML، إذا كان ذلك مناسبًا.
- [History](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/history/) يتحكم فيما إذا كان تفعيل الارتباط يضيف هدفه إلى قائمة الارتباطات التي تمت مشاهدتها.
- [HighlightClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/highlightclick/) يتحكم فيما إذا كان الارتباط يُبرز عند النقر.

## **إزالة الارتباطات التشعبية من العروض**

استخدم [GetAnyHyperlinks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) لتجميع حاويات الارتباطات، بما في ذلك روابط أجزاء النص، قبل تعديلها. المثال التالي يزيل كلا نوعي التفعيل من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [RemoveHyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) أو [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)؛ إزالة إجراء النقر لا تُزيل نظيره عند المرور بالفأرة.

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

للإزالة غير المشروطة، [RemoveAllHyperlinks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) يزيل كلا نوعي التفعيل في النطاق المحدد في استدعاء واحد. للتنظيف الانتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **بناء جرد كامل للارتباطات التشعبية**

قبل توزيع عرض، اجمع جردًا لإجراءات التفاعل بالإضافة إلى روابط الويب. [GetAnyHyperlinks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) يُعيد كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطّحة من سلاسل URL. افحص كل من [HyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) و [HyperlinkMouseOver](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تُظهر كلا الإجراءين، لذا يحتاج التقرير الكامل إلى صفين كحد أقصى لكل حاوية.

المسح على مستوى الأشكال فقط قد يفوّت الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلاً من ذلك، واحفظ الحاويات التي تم إرجاعها لتتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **استعلام عن نطاقات العرض، الشريحة، وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/) متاحة عبر [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/hyperlinkqueries/)، [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/hyperlinkqueries/)، و [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/hyperlinkqueries/). كل نطاق يدعم نفس الاستعلامات:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) يُرجع الحاويات التي لها إجراء نقرة.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) يُرجع الحاويات التي لها إجراء مرور بالفأرة.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) يُرجع الحاويات التي لديها أي من الإجراءين أو كليهما.

المثال التالي ينشئ `hyperlink-audit-input.pptx` مع رابط نقر خارجي، رابط مرور بالفأرة إلى ملف، تنقل داخلي بين الشرائح، رابط مرور بالفأرة للنص، وإجراء ماكرو. لا يتم تنفيذ أي من هذه الإجراءات. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تُشير إلى الحاويات، وليس إلى إجمالي الإجراءات. نطاق إطار النص يستثني روابط الشكل المحيط به.

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

في هذا المثال، تُظهر استعلامات العرض والشريحة ثلاث حاويات نقرة، حاويتين مرور بالفأرة، وثلاث حاويات ذات أي إجراء. استعلام إطار النص يُظهر حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [IHyperlink.ActionType](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/actiontype/) لتفسير الإجراء قبل تفسير الوجهة. قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/net/aspose.slides/hyperlinkactiontype/) تغطي أكثر من تنقل ويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | ارتباط تشعبي خارجي؛ افحص عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يُفسَّر في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض آخر؛ راجع منفصلًا عن عناوين URL للويب. |
| `StartStopMedia` | تشغيل أو إيقاف تشغيل الوسائط. |
| `NoAction`, `Unknown` | لا إجراء تنقل، أو إجراء غير معروف يتطلب مراجعة. |

اقرئ الوجهات الخارجية من [ExternalUrl](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/externalurl/) والوجهات الداخلية المحددة من [TargetSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/targetslide/). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على عنوان URL خارجي؛ عنوان URL الفارغ لا يعني أن الحاوية لا تمتلك إجراءً. احفظ [ExternalUrlOriginal](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/externalurloriginal/) عندما يختلف عن عنوان URL المُطبع، وضمّن [Tooltip](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlink/tooltip/) عندما يتوفر.

### **التقارير، التنظيف، والتحقق من الارتباطات**

المثال التالي لـ .NET 6+ يقرأ عرضًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يفتحه مرة أخرى للتحقق من كلا نوعي التفعيل مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم المساواة المرجعية لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ لجرد شامل على مستوى الحزمة، يستعلم أيضًا عن الماسترز، التخطيطات، الملاحظات، وعن ماسترز الملاحظات والنشرات عندما تكون موجودة.

يسجل التقرير مؤشر شريحة يبدأ من 1 و [SlideId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/slideid/) عندما يتوفر. يُقدم [ISlideComponent.Slide](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecomponent/slide/) الشريحة المالكة للحاويات المدعومة. لا تملك الماسترز، التخطيطات، والملاحظات مؤشر شريحة عادي وتُحدد بنطاقها. تُصنَّف حاويات الشكل وحاويات تنسيق أجزاء النص بشكل منفصل؛ الأنواع الأخرى تبقى باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لربط إجراءهاين.

هذه السياسة المتحفظة تسمح فقط بروابط HTTPS مطلقة ووجهات شرائح داخلية صالحة. ترفض ماكروهات، برامج، إجراءات ملفات، إجراءات عرض الشرائح الأخرى، إجراءات غير معروفة، وأي مخطط URL آخر. هذه الرفضات هي قرارات سياسة، وليست حكمًا على أمان Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من عناوين URL الأصلية والمُطبع. يراجع المثال البيانات الوصفية دون اتباع الروابط أو تنفيذ الإجراءات.

للتصحيح، يدعم [HyperlinkManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) الخاص بالحاوية [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)، [RemoveHyperlinkClick](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)، و [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات والمرورات غير المسموح بها بشكل مستقل. اضبط `replaceExternalClicks` إلى `false` لإزالة جميع انتهاكات السياسة بدلاً من ذلك. اختر صفحة استبدال مملوكة للتطبيق قبل النشر.

علامة تصدير التقرير تستخدم سياسة مراجعة PDF متحفظة: علم إجراءات المرور بالفأرة وأي شيء غير الرابط الخارجي أو القفزة إلى شريحة معينة على أنه قد لا يكون مدعومًا. إنها تلميح مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير المؤشرة بعد التصدير. قد تحتفظ صادرات PDF وHTML المدعومة بالارتباطات، تبعًا للإجراء، خيارات التصدير، والمشاهد. لا يمكن لصور raster والفيديو الحفاظ على الارتباطات التفاعلية؛ علم كل إجراء عند التدقيق لهذه المخرجات.

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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمس صفوف إجراءات. يزيل رابط مرور الفأرة إلى ملف والماكرو النقر، بينما تبقى روابط HTTPS وتنقل الشرائح الداخلية. تطبع عملية التحقق صفر إجراءات محظورة. إدخال يحتوي على رابط نقر خارجي محظور يُظهر فرع الاستبدال. حاوية ذات نقرة مسموح بها ومرور بالفأرة محظور تحتفظ بنقرتها.

هذا التنظيف الانتقائي يختلف عن [RemoveAllHyperlinks](https://reference.aspose.com/slides/ar/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)، الذي يُزيل كلا نوعي التفعيل في النطاق المحدد بغض النظر عن السياسة. التحقق هنا يقتصر على إجراءات الارتباطات؛ لا يزيل مشاريع VBA المضمّنة، كائنات OLE، أو محتوى نشط آخر، ولا يتحقق من ملف PDF أو HTML المُصدّر.

## **الأسئلة المتكررة**

**كيف يمكنني الربط بقسم أو الشريحة الأولى منه؟**

تُجمع الشرائح في PowerPoint ضمن أقسام، لكنه لا يمكن للارتباط التشعبي الداخلي أن يستهدف قسمًا كاملاً؛ فهو يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي إلى عناصر ماستر الشريحة بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر ماستر الشريحة والتخطيط الارتباطات التشعبية. تكون الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل ستحافظ الارتباطات التشعبية عند تصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ صادرات PDF وHTML المدعومة بالارتباطات؛ لا يمكن للصور النقطية والفيديو الحفاظ على الارتباطات التفاعلية. راجع الاعتبارات في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).