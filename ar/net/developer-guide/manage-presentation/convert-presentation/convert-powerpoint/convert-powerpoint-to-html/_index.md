---
title: تحويل عروض PowerPoint إلى HTML في .NET
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML في .NET. استخدم Aspose.Slides لتصدير ملفات PPT و PPTX، الشرائح المحددة، الملاحظات، الخطوط، الصور، SVG، والوسائط."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET حفظ عروض PowerPoint كملفات HTML دون الحاجة إلى Microsoft PowerPoint. التحويل الأساسي هو تحميل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحد واستدعاء [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/). استخدم [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) عندما تحتاج إلى التحكم في التخطيط المُصدَّر، الخطوط، الصور، الملاحظات، التعليقات، ناتج SVG، أو الموارد المرتبطة.

يركّز هذا الدليل على سيناريوهات عملية لتصدير HTML:

- تصدير عرض كامل أو شرائح مختارة.
- إنشاء HTML ثابت التخطيط، استجابة، أو قائم على SVG.
- تضمين ملاحظات المتحدث وتعليقات.
- التحكم في جودة الصورة وبيانات المناطق المقصوصة.
- تضمين الخطوط أو حفظ ملفات الخطوط بشكل منفصل.
- اختيار كيفية كتابة الموارد الخارجية وملفات الوسائط والإشارة إليها.

بشكل افتراضي، ينتج تصدير HTML مستند HTML ذاتي الاحتواء حيث تُضمّن معظم الموارد. هذا مريح لمشاركة ملف واحد، لكنه قد يزيد من حجم الإخراج. للنشر على الويب، ضع في اعتبارك الموارد الخارجية، خفض DPI الصورة، وتضمين الخطوط فقط عندما لا تكون متوفرة بشكل موثوق في البيئة المستهدفة.

## **تحويل عرض إلى HTML**

لتصدير عرض إلى HTML، قم بتحميله باستخدام [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحفظه باستخدام [SaveFormat.Html](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

هذا المثال يكتب ملف HTML واحد. يتم تحرير كائن العرض بواسطة عبارة `using`، التي تُحرّر مقابض الملفات وموارد التصيير بعد التصدير.

## **استخدام HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) هو الفئة الرئيسة لتكوين تصدير HTML. تشمل الإعدادات الشائعة:

- `SlidesLayoutOptions`: يضيف الملاحظات، التعليقات، النشرات، أو معلومات تخطيط أخرى.
- `HtmlFormatter`: يغيّر بنية مستند HTML أو يوكل التنسيق إلى متحكم.
- `SlideImageFormat`: يغيّر طريقة تمثيل الشرائح، على سبيل المثال كـ SVG.
- `PicturesCompression`: يتحكم في DPI الصورة وحجم الإخراج.
- `DeletePicturesCroppedAreas`: يحافظ على أو يزيل بيانات الصورة المقصوصة.
- `SvgResponsiveLayout`: يجعل محتوى SVG المُصدَّر يتكيف مع الحاوية الخاصة به.
- `ShowHiddenSlides`: يتضمن الشرائح المخفية عند الحاجة.

توضح الأقسام التالية أكثر الخيارات شيوعًا بشكل منفصل حتى تتمكن من دمج ما تحتاجه فقط في سير عملك.

## **تحويل الشرائح المحددة إلى HTML**

الوظيفة الزائدة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) التي تقبل أرقام الشرائح تستخدم مواضع الشرائح ذات الفهرسة من 1. الحلقة أدناه تحفظ كل شريحة في ملف HTML منفصل.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

استخدم هذا النمط عندما يحتاج موقع ويب أو تطبيق إلى صفحة HTML واحدة لكل شريحة. إذا كان يجب أن تكون كل شريحة ذات تخطيط موحد، أنشئ كائنًا واحدًا من [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) ومرره إلى كل استدعاء `Save`.

## **إنشاء HTML استجابة**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/responsivehtmlcontroller/) يوفر ناتج HTML استجابة عبر [HtmlFormatter](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmlformatter/). استخدمه عندما يجب أن يتكيف الصفحة المصدَّرة بشكل أفضل مع عرض المتصفح.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

للتخطيط المستجيب القائم على SVG، عيّن `SvgResponsiveLayout` على [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/). هذا مفيد عندما يُصدَّر محتوى الشريحة كعلامة SVG قابلة للتوسع.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **تضمين ملاحظات المتحدث والتعليقات**

استخدم [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) عبر `HtmlOptions.SlidesLayoutOptions` لتضمين ملاحظات المتحدث أو التعليقات. تكون الملاحظات والتعليقات مخفية افتراضيًا ما لم تحدد مواضعها.

افترض أن العرض المصدر يحتوي على ملاحظات المتحدث:

![شريحة مع ملاحظات المتحدث في PowerPoint](slide_with_notes.png)

الكود التالي يصدر محتوى الشريحة مع ملاحظات المتحدث أسفل الشريحة.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

الناتج HTML يتضمن منطقة الملاحظات:

![ناتج HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

لتصدير التعليقات، اضبط `CommentsPosition`، على سبيل المثال إلى `CommentsPositions.Right` أو `CommentsPositions.Bottom`. إذا احتجت فقط إلى التعليقات، احذف `NotesPosition`. إذا احتجت كلاً من الملاحظات والتعليقات، عيّن الخصيتين معًا.

## **التحكم في جودة الصورة والمناطق المقصوصة**

يمكن لتصدير HTML ضغط صور الشرائح لتقليل حجم الإخراج. عيّن `PicturesCompression` إلى قيمة من [PicturesCompression](https://reference.aspose.com/slides/ar/net/aspose.slides.export/picturescompression/) عندما تحتاج إلى جودة صورة أعلى.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

افتراضيًا، قد تُزال المناطق المقصوصة من الصور في الناتج المُصدَّر. احتفظ بالبيانات المقصوصة فقط عندما يلزم المستخدمون استعادة أو فحص تلك الأجزاء المخفية من الصورة. الاحتفاظ بها يمكن أن يزيد من حجم HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **إضافة CSS**

للتنسيق البسيط، مرّر سلسلة CSS إلى [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmlformatter/createdocumentformatter/). يغيّر هذا المستند HTML المحيط بينما يواصل Aspose.Slides تصيير محتوى الشريحة.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

لرأس مستند مخصص، ملف CSS مربوط، أو علامات مخصصة حول الشرائح والأشكال، نفّذ [IHtmlFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ihtmlformattingcontroller/) ومرره إلى [HtmlFormatter](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmlformatter/) باستخدام `CreateCustomFormatter`.

## **تضمين الخطوط**

إذا كان من المرجح أن البيئة المستهدفة لا تحتوي على خطوط العرض مثبتة، ضمّن الخطوط في HTML باستخدام [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/embedallfontshtmlcontroller/). يضيف التضمين تحسينًا في الدقة البصرية لكنه يزيد من حجم الإخراج.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

استبعد الخطوط فقط عندما تكون واثقًا من أن المتصفحات أو الأنظمة المستهدفة توفرها بالفعل. بالنسبة للخطوط العلامية أو الخطوط الأقل شيوعًا، يكون التضمين عادةً أكثر أمانًا.

## **ربط ملفات الخطوط بدلاً من تضمينها**

لتقليل حجم ملف HTML، يمكنك كتابة بيانات الخط إلى ملفات WOFF منفصلة وإضافة قواعد `@font-face` إلى HTML. المساعد أدناه يوسع [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/embedallfontshtmlcontroller/) ويعيد تعريف `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

في هذا المثال، تُحفظ ملفات الخط في `html-output/fonts`، ويشير HTML إليها بواسطة عناوين URL مثل `fonts/BrandFont-normal-400.woff`. إذا تم نشر ملف HTML والخطوط في موقع آخر، اختر `fontUrlPrefix` بحيث يتطابق مع مسار URL المنشور.

## **حفظ الموارد خارجياً**

HTML ذاتي الاحتواء سهل النقل، لكن الموارد المضمّنة بصيغة Base64 قد تجعل الملف كبيرًا. إذا كان تطبيقك يحتاج إلى ملفات صور خارجية، نفّذ [ILinkEmbedController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/) ومرره إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/htmloptions/).

عند جعل الموارد خارجية، اختر مسارين بوعي:

- مسار مخرج نظام الملفات، حيث يكتب تطبيقك الصور، الخطوط، الصوت أو الفيديو المولدة.
- مسار URL، وهو ما يستخدمه المتصفح من مستند HTML لتحميل تلك الملفات.

للحصول على تنفيذ كامل لربط الصور، راجع [تصدير العروض إلى HTML مع صور مرتبطة خارجيًا](/slides/ar/net/exporting-presentations-to-html-with-externally-linked-images/).

## **تصدير ملفات الوسائط**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/videoplayerhtmlcontroller/) يصدر ملفات الفيديو والصوت ويكتب HTML يمكن تشغيله في المتصفح. يأخذ مُنشئه:

- `path`: الدليل الذي سيتم كتابة ملفات الوسائط المولدة فيه.
- `fileName`: اسم ملف HTML الجاري إنشاؤه.
- `baseUri`: بادئة URI المطلقة المستخدمة في روابط HTML لملفات الوسائط.

إذا كان ملف HTML هو `html-output/presentation.html` وملفات الوسائط محفوظة في `html-output/media`، يجب أن يشير `path` إلى دليل الوسائط على القرص، بينما يجب أن يشير `baseUri` إلى نفس الدليل من منظور المتصفح. للمعاينة المحلية، يمكنك بناء URI من النوع `file:///` من دليل الوسائط. للتطبيق المنشور، استخدم URL المطلق لدليل الوسائط المنشور.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

استخدم دلائل مخرج فريدة لكل مهمة تصدير، خاصة في تطبيقات الخادم. قد تتسبب مسارات المخرج المشتركة في كتابة ملفات من تحويلات مختلفة فوق بعضها البعض.

## **الأداء وإدارة الموارد**

تحويل HTML عملية تصيير، لذا يعتمد زمن المعالجة واستخدام الذاكرة على عدد الشرائح، دقة الصور، الخطوط، التأثيرات، المخططات، والوسائط المضمنة. القيم الأعلى لـ `PicturesCompression` DPI، الخطوط المضمنة، ناتج SVG، والاحتفاظ بالمناطق المقصوصة للصور قد يحسن الدقة لكنه عادةً ما يزيد من حجم الإخراج.

لتحويل دفعي:

- تخلص من كل كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) فورًا.
- استخدم دلائل مخرج منفصلة للوظائف المختلفة.
- تجنّب تضمين الخطوط الشائعة إلا إذا تطلب الأمر ذلك لضمان الدقة.
- خفّض DPI الصورة عندما يكون HTML للمعاينة أو المصغرات.
- احتفظ بالعرض المصدر، HTML المولد، والموارد الخارجية معًا حتى تصبح مسارات النشر نهائية.

## **الأسئلة المتداولة**

**هل يتم الحفاظ على الروابط التشعبية في ناتج HTML؟**

نعم. تُصدَّر روابط العرض إلى HTML وتبقى قابلة للنقر عندما يكون عنوان URL الهدف صالحًا.

**هل يمكنني تحويل العروض إلى HTML بشكل متوازي؟**

نعم، ولكن لا تشارك كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحد بين الخيوط. عالج ملفات مختلفة باستخدام كائنات عرض مستقلة، وتيارات منفصلة، ومسارات مخرج منفصلة. راجع دليل [multithreading guidance](/slides/ar/net/multithreading/) للمزيد من التفاصيل.

**هل كائن Presentation آمن للاستخدام عبر الخيوط؟**

لا. يجب تحميل، تعديل، حفظ، وتحرير كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) على خيط واحد فقط. للعمل المتوازي، أنشئ نسخة مستقلة لكل خيط أو عملية.

**لماذا يكون ملف HTML المولد كبيرًا؟**

يمكن للتصدير الافتراضي تضمين الموارد مباشرة في HTML. الخطوط المضمنة، الصور DPI العالية، الوسائط، محتوى SVG، والاحتفاظ بالمناطق المقصوصة للصور تزيد جميعها من الحجم. استخدم موارد خارجية، استبعد الخطوط الشائعة من التضمين، وخفّض `PicturesCompression` عندما يكون حجم الإخراج الصغير أهم من أقصى دقة.

**كيف يجب أن أختار baseUri لتصدير الوسائط؟**

اختر `baseUri` من منظور المتصفح ومرره كـ URI مطلق. للمعاينة المحلية، يمكنك اشتقاقه من دليل المخرج باستخدام `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. للنشر، استخدم URL المطلق لدليل الوسائط المنشور. لا يلزم أن تكون سلسلة `path` على نظام الملفات هي نفس سلسلة `baseUri`، ولكن يجب أن تصف الموقع نفسه للموارد.

**هل يمكنني تضمين الشرائح المخفية؟**

نعم. عيّن `ShowHiddenSlides = true` على [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/) عندما يجب تصدير الشرائح المخفية.