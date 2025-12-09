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
description: "تحويل عروض PowerPoint إلى HTML استجابي في .NET. الحفاظ على التخطيط والروابط والصور باستخدام دليل التحويل الخاص بـ Aspose.Slides للحصول على نتائج سريعة وخالية من الأخطاء."
---

## **نظرة عامة**

قم بتحسين سير العمل الخاص بك عن طريق تحويل عروض PowerPoint وOpenDocument إلى HTML باستخدام Aspose.Slides للـ .NET. يقدم هذا الدليل تعليمات مفصلة، أمثلة شفرة قوية، وطُرُق مُختبرة لضمان عملية تحويل موثوقة وفعّالة مُحسّنة للعرض على الويب.

توفر Aspose.Slides العديد من الخيارات — معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) — التي تُحدِّد عملية التحويل من تنسيق PowerPoint (أو OpenDocument) إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML استجابي.
* تحويل عرض PowerPoint إلى HTML مع تضمين ملاحظات المتحدث أو استبعادها.
* تحويل عرض PowerPoint إلى HTML مع تضمين التعليقات أو استبعادها.
* تحويل عرض PowerPoint إلى HTML باستخدام الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.

## **تحويل عرض تقديمي إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint أو OpenDocument كامل إلى HTML كما يلي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف HTML.

يوضح هذا الشيفرة كيفية تحويل عرض PowerPoint إلى HTML بلغة C#:
```c#
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي (مثل PPT, PPTX, ODP, إلخ).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // حفظ العرض التقديمي كملف HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **تحويل عرض تقديمي إلى HTML استجابي**

توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) التي تتيح لك إنشاء ملفات HTML استجابية. يوضح هذا الشيفرة كيفية تحويل عرض PowerPoint إلى HTML استجابي بلغة C#:
```c#
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
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

عند تحويل عرض PowerPoint أو OpenDocument إلى HTML مع ملاحظات المتحدث، من الضروري التقاط جوهر المستند الأصلي بالكامل. تضمن هذه العملية أن العناصر البصرية للشرائح ممثلة بدقة، بالإضافة إلى الحفاظ على ملاحظات المتحدث المصاحبة، مما يضيف سياقًا إضافيًا ورؤى قيّمة.

لنفترض أن لدينا عرض PowerPoint يحتوي على الشريحة التالية:

![شريحة عرض مع ملاحظات المتحدث](slide_with_notes.png)

يظهر هذا الشيفرة كيفية تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث بلغة C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // تعيين الخيارات لملاحظات المتحدث.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // تعيين الخيارات لوثيقة HTML الناتجة.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // حفظ العرض التقديمي كـ HTML مع ملاحظات المتحدث.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


النتيجة:

![ملف HTML يحتوي على الشريحة وملاحظات المتحدث](HTML_with_notes.png)

## **تحويل عرض تقديمي إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ مُعَلَّم للـ [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمج لأنها متوفرة بالفعل على معظم الأنظمة. دمجها سيزيد حجم ملف HTML الناتج دون ضرورة.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) الوراثة وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) التي من المفترض أن تُعاد تعريفها.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // استبعاد خطوط العرض التقديمي الافتراضية.
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

بشكل افتراضي، عندما تقوم بتحويل عرض PowerPoint إلى HTML، تُنتج Aspose.Slides ملف HTML صغير مع صور بدقة 72 DPI وتزيل المناطق المقصوصة. للحصول على ملفات HTML بصور ذات جودة أعلى، يجب تعيين خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression.Dpi96`) أو قيمة أعلى، كما هو موضح في [هذا المرجع](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

يوضح هذا الشيفرة بلغة C# كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):
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


يعرض هذا الشيفرة بلغة C# كيفية تحويل عرض PowerPoint إلى HTML دون حذف المناطق المقصوصة:
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


## **تحويل شريحة من عرض تقديمي إلى HTML**

لتحويل شريحة معينة في عرض PowerPoint إلى HTML، تحتاج إلى إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) لتحديد خيارات تحويل إضافية.

يوضح هذا الشيفرة بلغة C# كيفية تحويل شريحة مع ملاحظات المتحدث في عرض PowerPoint إلى HTML:
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

            // حفظ الشريحة في ملف HTML.
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


## **حفظ ملفات CSS والصور عند تصدير إلى HTML**

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل مظهر ملف HTML الناتج من عملية التحويل من PowerPoint إلى HTML.

يُظهر الشيفرة C# في هذا المثال كيفية استخدام طرق قابلة لإعادة التعريف لإنشاء مستند HTML مخصص يتضمن رابطًا إلى ملف CSS:
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

إذا لم ترغب في دمج الخطوط (لتجنب زيادة حجم ملف HTML الناتج)، يمكنك ربط جميع الخطوط بتنفيذ نسخة خاصة بك من `LinkAllFontsHtmlController`.

يُظهر هذا الشيفرة بلغة C# كيفية تحويل عرض PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و"Arial" (لأنهما مثبتان بالفعل على النظام):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	// استبعاد خطوط العرض التقديمي الافتراضية.
	string[] fontNameExcludeList = { "Calibri", "Arial" };

	LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

	HtmlOptions htmlOptionsEmbed = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
	};

	presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


يعرض هذا الشيفرة بللغة C# كيف تم تنفيذ `LinkAllFontsHtmlController`:
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
            string path = fontName + ".woff"; // قد تحتاج إلى تنقية المسار.

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


## **تحويل عرض تقديمي يحتوي على صور SVG إلى HTML استجابي**

يُظهر هذا الشيفرة بلغة C# كيفية تحويل عرض PowerPoint إلى HTML استجابي:
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

باستخدام Aspose.Slides للـ .NET، يمكنك تصدير ملفات الوسائط كالتالي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع للشفرة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

يُظهر هذا الشيفرة بلغة C# كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:
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

    // تحديد خيارات HTML.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // حفظ العرض التقديمي كملف HTML.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

قامت Aspose بتطوير محولات مجانية من [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

اطّلع على المحولات المجانية الأخرى من Aspose:
https://products.aspose.app/slides/conversion

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل الموضحة هنا، تدعم Aspose.Slides أيضًا عمليات تحويل أخرى تتضمن تنسيق HTML:

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**ما هو أداء Aspose.Slides عند تحويل عروض تقديمية متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعّالة وعالية القابلية للتوسع لعمليات الدُفعات. لتحقيق أداء مثالي عند تحويل عدد كبير من العروض، يُنصح باستخدام البرمجة المتعددة الخيوط أو المعالجة المتوازية كلما كان ذلك ممكنًا.

**هل تدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، تدعم Aspose.Slides تصدير الروابط التشعبية المضمنة إلى HTML بالكامل. عند تحويل العروض إلى تنسيق HTML، يتم الحفاظ على الروابط التشعبية تلقائيًا وتظل قابلة للنقر.

**هل هناك حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة على الخادم أو النظام الخاص بك.