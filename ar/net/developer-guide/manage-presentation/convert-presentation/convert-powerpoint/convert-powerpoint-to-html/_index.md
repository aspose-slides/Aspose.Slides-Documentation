---
title: تحويل عروض PowerPoint إلى HTML في .NET
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- العرض إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- .NET
- C#
- Aspose.Slides
description: تحويل عروض PowerPoint إلى HTML متجاوب في .NET. احفظ التخطيط والروابط والصور باستخدام دليل التحويل الخاص بـ Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء.
---

## **نظرة عامة**

حسّن سير عملك عن طريق تحويل عروض PowerPoint وOpenDocument إلى HTML باستخدام Aspose.Slides for .NET. يقدم هذا الدليل إرشادات مفصلة، وأمثلة شفرة قوية، وأساليب مختبرة لضمان عملية تحويل موثوقة وفعّالة مُحسّنة للعرض على الويب.

توفر Aspose.Slides العديد من الخيارات—معظمها من الفئة [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)—التي تحدد عملية التحويل من تنسيق PowerPoint (أو OpenDocument) إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (صور، فيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML مستجيب.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.

## **تحويل عرض تقديمي إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint أو OpenDocument كامل إلى HTML كما يلي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف HTML.

تُظهر هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML بلغة C#:
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (مثل PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // حفظ العرض التقديمي كـ HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **تحويل عرض تقديمي إلى HTML مستجيب**

توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) التي تمكّنك من إنشاء ملفات HTML مستجيبة. تُظهر هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML مستجيب بلغة C#:
```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // حفظ العرض التقديمي كـ HTML.
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل عرض تقديمي إلى HTML مع ملاحظات المتحدث**

عند تحويل عرض PowerPoint أو OpenDocument إلى HTML مع ملاحظات المتحدث، من الضروري التقاط جوهر المستند الأصلي بالكامل. تضمن هذه العملية تمثيل العناصر البصرية للشرائح بدقة، مع الحفاظ على ملاحظات المتحدث المرفقة، مما يضيف محتوى غنيًا بسياق إضافي ورؤى معمقة.

لنفترض أن لدينا عرض PowerPoint يحتوي على الشريحة التالية:

![A presentation slide with speaker notes](slide_with_notes.png)

تُظهر هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث بلغة C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // ضبط الخيارات لملاحظات المتحدث.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // ضبط الخيارات لوثيقة HTML الناتجة.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // حفظ العرض التقديمي كـ HTML مع ملاحظات المتحدث.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


النتيجة:

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **تحويل عرض تقديمي إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) مع معاملات. الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمج لأنها موجودة مسبقًا في أغلب الأنظمة. دمجها سيزيد حجم ملف HTML الناتج دون فائدة.

تدعم الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) الوراثة وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) التي يُقصد أن يتم تجاوزها.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // استبعاد خطوط العرض الافتراضية.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل عرض تقديمي إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عند تحويل عرض PowerPoint إلى HTML، تُنتج Aspose.Slides ملف HTML صغير بصور بدقة 72 DPI وتزيل المناطق المقطوعة. للحصول على ملفات HTML بصور ذات جودة أعلى، يجب تعيين الخاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression.Dpi96`) أو قيمة أعلى، كما هو موضح في [هذا المرجع](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

تُظهر شفرة C# التالية كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        PicturesCompression = PicturesCompression.Dpi150
    };

    presentation.Save("output_dpi_150.html", SaveFormat.Html, htmlOptions);
}
```


تُظهر شفرة C# التالية كيفية تحويل عرض PowerPoint إلى HTML دون حذف المناطق المقطوعة:
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        DeletePicturesCroppedAreas = false
    };

    presentation.Save("output_no_crop.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل شريحة عرض إلى HTML**

لتحويل شريحة معينة في عرض PowerPoint إلى HTML، تحتاج إلى إنشاء مثال من نفس الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الملف كملف HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) لتحديد خيارات تحويل إضافية.

تُظهر شفرة C# التالية كيفية تحويل شريحة مع ملاحظات المتحدث في عرض PowerPoint إلى HTML:
```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("sample.pptx"))
    {
        NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        HtmlOptions htmlOptions = new HtmlOptions
        {
            SlidesLayoutOptions = notesOptions,
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController())
        };

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i + 1;

            // احفظ الشريحة إلى ملف HTML.
            string fileName = $"output_slide_{slideIndex}.html";
            presentation.Save(fileName, new[] { slideIndex }, SaveFormat.Html, htmlOptions);
        }
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **حفظ CSS والصور عند التصدير إلى HTML**

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل مظهر ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML.

تُظهر شفرة C# في هذا المثال كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص يتضمن رابطًا إلى ملف CSS:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");

	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	presentation.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
	// قالب رأس مخصص.
	const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";

    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```


## **ربط جميع الخطوط عند تحويل عرض تقديمي إلى HTML**

إذا كنت لا تريد دمج الخطوط (لتجنب زيادة حجم ملف HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة خاصة بك من `LinkAllFontsHtmlController`.

تُظهر شفرة C# التالية كيفية تحويل عرض PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و"Arial" (لأنهما مثبتان بالفعل على النظام):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // استبعاد خطوط العرض الافتراضية.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


تُظهر شفرة C# التالية كيفية تنفيذ `LinkAllFontsHtmlController`:
```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; // قد يلزم تنقية للمسار.

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```


## **تحويل عرض تقديمي يحتوي على صور SVG إلى HTML مستجيب**

تُظهر شفرة C# التالية كيفية تحويل عرض PowerPoint إلى HTML مستجيب:
```c#
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    HtmlOptions saveOptions = new HtmlOptions
    {
        SvgResponsiveLayout = true
    };

    presentation.Save("SvgResponsiveLayout-out.html", SaveFormat.Html, saveOptions);
}
```


## **تصدير ملفات الوسائط إلى HTML**

باستخدام Aspose.Slides for .NET، يمكنك تصدير ملفات الوسائط كالتالي:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

تُظهر شفرة C# التالية كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML: 
```c#
// إنشاء عرض تقديمي جديد.
using (Presentation presentation = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = presentation.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = presentation.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // تعيين خيارات HTML.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // حفظ العرض التقديمي كملف HTML.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

طوّرت Aspose محولات مجانية من [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

تصفح المحولات المجانية الأخرى من Aspose عبر الرابط التالي: [free converters from Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

إلى جانب عمليات التحويل الموضحة هنا، تدعم Aspose.Slides أيضًا عمليات التحويل التالية التي تتضمن تنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو أداء Aspose.Slides عند تحويل عروض تقديمية متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعّال للغاية وقابل للتوسع للعمليات الدفعة. لتحقيق أفضل أداء عند تحويل عدد كبير من العروض، يوصى باستخدام المعالجة المتعددة الخيوط أو المعالجة المتوازية كلما أمكن.

**هل تدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، تدعم Aspose.Slides تصدير الروابط التشعبية المضمّنة إلى HTML بالكامل. عند تحويل العروض إلى صيغة HTML، تُحفظ الروابط التشعبية تلقائيًا وتظل قابلة للنقر.

**هل هناك حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة على الخادم أو النظام الخاص بك.