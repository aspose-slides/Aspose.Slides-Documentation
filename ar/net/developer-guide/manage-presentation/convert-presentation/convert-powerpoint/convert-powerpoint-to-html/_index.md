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
description: "تحويل عروض PowerPoint إلى HTML متجاوب في .NET. الحفاظ على التخطيط والروابط والصور باستخدام دليل تحويل Aspose.Slides للحصول على نتائج سريعة وخالية من العيوب."
---

## **نظرة عامة**

حسّن سير العمل الخاص بك عن طريق تحويل عروض PowerPoint وOpenDocument إلى HTML باستخدام Aspose.Slides for .NET. يقدم هذا الدليل إرشادات تفصيلية، أمثلة شفرة قوية، وأساليب مجربة لضمان عملية تحويل موثوقة وفعّالة محسّنة للعرض على الويب.

توفر Aspose.Slides العديد من الخيارات—معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)—التي تحدد عملية التحويل من صيغة PowerPoint (أو OpenDocument) إلى HTML:

* تحويل عرض تقديمي كامل من PowerPoint إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو الخطوط المدمجة.
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.

## **تحويل عرض تقديمي إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض تقديمي كامل من PowerPoint أو OpenDocument إلى HTML كما يلي:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف HTML.

توضح هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML بـ C#:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي (مثل PPT، PPTX، ODP، إلخ).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // حفظ العرض التقديمي كملف HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **تحويل عرض تقديمي إلى HTML متجاوب**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) التي تمكّنك من إنشاء ملفات HTML متجاوبة. تُظهر هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML متجاوب بـ C#:
```c#
// إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // حفظ العرض التقديمي كملف HTML.
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل عرض تقديمي إلى HTML مع ملاحظات المتحدث**

عند تحويل عرض PowerPoint أو OpenDocument إلى HTML مع ملاحظات المتحدث، من الضروري التقاط جوهر المستند الأصلي بالكامل. يضمن هذا الإجراء أن العناصر البصرية للشرائح تُعرض بدقة، وأن ملاحظات المتحدث تُحافظ عليها، مما يضيف سياقًا ورؤى إضافية للمحتوى.

لنفرض أن لدينا عرض PowerPoint يحتوي على الشريحة التالية:

![A presentation slide with speaker notes](slide_with_notes.png)

توضح هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث بـ C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // تعيين خيارات ملاحظات المتحدث.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // تعيين خيارات مستند HTML الناتج.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // حفظ العرض التقديمي كملف HTML مع ملاحظات المتحدث.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


النتيجة:

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **تحويل عرض تقديمي إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) المتضمن معاملات. لا تحتاج إلى دمج خطوط شائعة مثل Calibri أو Arial لأن معظم الأنظمة تتضمنها مسبقًا. سيؤدي دمجها إلى زيادة حجم مستند HTML الناتج دون فائدة.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) الوراثة وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) التي من المقصود تجاوزها.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // استبعاد خطوط العرض التقديمية الافتراضية.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل عرض تقديمي إلى HTML مع صور ذات جودة عالية**

بشكل افتراضي، عند تحويل عرض PowerPoint إلى HTML، تُنتج Aspose.Slides ملف HTML صغير يحتوي على صور بدقة 72 DPI وتزيل المناطق المقصوصة. للحصول على ملفات HTML تحتوي على صور ذات جودة أعلى، يجب ضبط الخاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (`PicturesCompression.Dpi96`) أو قيمة أعلى، كما هو موضح في [this reference](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

توضح شفرة C# هذه كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (`PicturesCompression.Dpi150`):
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


توضح شفرة C# هذه كيفية تحويل عرض PowerPoint إلى HTML دون حذف المناطق المقصوصة:
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


## **تحويل شريحة عرض تقديمي إلى HTML**

لتحويل شريحة محددة في عرض PowerPoint إلى HTML، عليك إنشاء كائن من نفس فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) المستخدمة لتحويل العروض الكاملة إلى HTML، ثم استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) لتحديد خيارات تحويل إضافية.

توضح شفرة C# هذه كيفية تحويل شريحة مع ملاحظات المتحدث في عرض PowerPoint إلى HTML:
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


## **حفظ ملفات CSS والصور عند التصدير إلى HTML**

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل مظهر ملف HTML المُنتَج من عملية تحويل PowerPoint إلى HTML.

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
    // قالب الرأس المخصص.
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

إذا لم ترغب في دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`.

تُظهر شفرة C# هذه كيفية تحويل عرض PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و "Arial" (لأنهما مثبتان مسبقًا على النظام):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // استبعاد خطوط العرض التقديمية الافتراضية.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


تُظهر شفرة C# هذه كيفية تنفيذ `LinkAllFontsHtmlController`:
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
            string path = fontName + ".woff"; // قد تكون هناك حاجة إلى بعض تنظيف المسار.

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


## **تحويل عرض تقديمي يحتوي على صور SVG إلى HTML متجاوب**

تُظهر شفرة C# هذه كيفية تحويل عرض PowerPoint إلى HTML متجاوب:
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

باستخدام Aspose.Slides for .NET، يمكنك تصدير ملفات الوسائط كما يلي:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

تُظهر شفرة C# هذه كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:
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

    // حفظ العرض التقديمي إلى ملف HTML.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

قامت Aspose بتطوير محولات مجانية لتحويل [العروض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html)، وغيرها.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

تحقق من المحولات المجانية الأخرى من Aspose:
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل المذكورة هنا، تدعم Aspose.Slides أيضًا عمليات تحويل أخرى تتعلق بصيغة HTML:

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو أداء Aspose.Slides عند تحويل عدة عروض تقديمية إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعال للغاية وقابل للتوسع للعمليات الجماعية. لتحقيق الأداء الأمثل عند تحويل عدد كبير من العروض، يُنصح باستخدام تعدد الخيوط أو المعالجة المتوازية كلما أمكن.

**هل يدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، يدعم Aspose.Slides تصدير الروابط التشعبية المدمجة إلى HTML بالكامل. عند تحويل العروض إلى صيغة HTML، تُحافظ الروابط التشعبية تلقائيًا وتظل قابلة للنقر.

**هل هناك حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض من أي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتوفرة على الخادم أو النظام الخاص بك.