---
title: تحويل عروض PowerPoint إلى HTML في C#
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-html/
keywords:
- PowerPoint إلى HTML
- العرض إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- تحويل عرض PowerPoint
- تحويل PowerPoint
- تحويل العرض
- تحويل HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير HTML
- C#
- .NET
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint وOpenDocument إلى HTML باستخدام Aspose.Slides for .NET. يقدم هذا الدليل إرشادات وعينات كود وأفضل الممارسات لتحويل الشرائح إلى تنسيق مناسب للويب."
---

## **نظرة عامة**

قم بتحسين سير عملك عن طريق تحويل عروض PowerPoint وOpenDocument إلى HTML باستخدام Aspose.Slides for .NET. يقدم هذا الدليل إرشادات مفصلة، أمثلة كود قوية، وطرق مختبرة لضمان عملية تحويل موثوقة وفعالة مُحسّنة للعرض على الويب.

يوفر Aspose.Slides العديد من الخيارات — معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) — التي تحدد عملية التحويل من تنسيق PowerPoint (أو OpenDocument) إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML باستخدام نمط CSS الجديد.

## **تحويل عرض تقديمي إلى HTML**

باستخدام Aspose.Slides، يمكنك تحويل عرض تقديمي كامل بصيغة PowerPoint أو OpenDocument إلى HTML كما يلي:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استخدام الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف HTML.

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى HTML بلغة C#:
```c#
// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي (مثال: PPT, PPTX, ODP, إلخ).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // حفظ العرض كملف HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **تحويل عرض تقديمي إلى HTML متجاوب**

يوفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) التي تمكنك من إنشاء ملفات HTML متجاوبة. هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى HTML متجاوب بلغة C#:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // حفظ العرض كملف HTML.
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **تحويل عرض تقديمي إلى HTML مع ملاحظات المتحدث**

عند تحويل عرض PowerPoint أو OpenDocument إلى HTML مع ملاحظات المتحدث، من الضروري الحفاظ على جوهر المستند الأصلي. يضمن هذا الإجراء تمثيل العناصر البصرية للشرائح بدقة مع حفظ ملاحظات المتحدث، مما يضيف سياقًا ورؤى إضافية للمحتوى.

لنفترض أن لدينا عرض PowerPoint يحتوي على الشريحة التالية:

![شريحة عرض مع ملاحظات المتحدث](slide_with_notes.png)

هذا الكود يوضح كيفية تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث بلغة C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // تعيين خيارات ملاحظات المتحدث.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // تعيين خيارات وثيقة HTML الناتجة.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // حفظ العرض كملف HTML مع ملاحظات المتحدث.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


النتيجة:

![وثيقة HTML مع الشريحة وملاحظات المتحدث](HTML_with_notes.png)

## **تحويل عرض تقديمي إلى HTML مع الخطوط الأصلية**

يوفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) التي تسمح بدمج جميع الخطوط في العرض أثناء التحويل إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشيء مَعَلمات للفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). الخطوط الشائعة مثل Calibri أو Arial لا تحتاج إلى دمج لأنها متواجدة بالفعل في معظم الأنظمة. دمجها سيزيد حجم ملف HTML الناتج دون فائدة.

الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) تدعم الوراثة وتوفر الطريقة [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) التي يُقصد تجاوزها.
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

افتراضيًا، عند تحويل عرض PowerPoint إلى HTML، ينتج Aspose.Slides ملف HTML صغير مع صور بدقة 72 DPI ويحذف المناطق المقصوصة. للحصول على ملفات HTML بصور ذات جودة أعلى، يجب ضبط الخاصية `PicturesCompression` (من فئة `HtmlOptions`) على 96 (أي `PicturesCompression.Dpi96`) أو قيمة أعلى، كما هو موضح في [هذا المرجع](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

هذا الكود بلغة C# يوضح كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):
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


هذا الكود بلغة C# يوضح كيفية تحويل عرض PowerPoint إلى HTML دون حذف المناطق المقصوصة:
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

لتحويل شريحة محددة في عرض PowerPoint إلى HTML، تحتاج إلى إنشاء مثال من نفس فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) المستخدمة لتحويل العروض بالكامل، ثم استخدام الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) لتحديد خيارات تحويل إضافية.

هذا الكود بلغة C# يوضح كيفية تحويل شريحة مع ملاحظات المتحدث في عرض PowerPoint إلى HTML:
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

            // حفظ الشريحة إلى ملف HTML.
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

باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تعديل مظهر ملف HTML الذي يتم إنشاؤه من عملية تحويل PowerPoint إلى HTML.

الكود بلغة C# في هذا المثال يوضح كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص يتضمن رابطًا إلى ملف CSS:
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

إذا كنت لا ترغب في دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط عن طريق تنفيذ نسخة مخصصة من `LinkAllFontsHtmlController`.

هذا الكود بلغة C# يوضح كيفية تحويل عرض PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و"Arial" (لأنهما مثبتان بالفعل على النظام):
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


هذا الكود بلغة C# يوضح كيفية تنفيذ `LinkAllFontsHtmlController`:
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
            string path = fontName + ".woff"; // قد يكون من الضروري تنظيف بعض المسارات.

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

هذا الكود بلغة C# يوضح كيفية تحويل عرض PowerPoint إلى HTML متجاوب:
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

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

هذا الكود بلغة C# يوضح كيفية إضافة فيديو إلى العرض ثم حفظه كملف HTML:
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

قامت Aspose بتطوير محولات مجانية لـ [عرض تقديمي إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، وغيرها.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

تحقق من المحولات المجانية الأخرى من Aspose:
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

إلى جانب عمليات التحويل الموضحة هنا، يدعم Aspose.Slides أيضًا عمليات التحويل التالية المتعلقة بتنسيق HTML:

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو أداء Aspose.Slides عند تحويل عروض تقديمية متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعال جدًا وقابل للتوسع لعمليات الدُفعات. لتحقيق أفضل أداء عند تحويل عدد كبير من العروض، يُنصح باستخدام تعدد الخيوط أو المعالجة المتوازية كلما أمكن.

**هل يدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، يدعم Aspose.Slides تصدير الروابط التشعبية المدمجة إلى HTML بالكامل. عند تحويل العروض إلى تنسيق HTML، يتم الحفاظ على الروابط تلقائيًا وتظل قابلة للنقر.

**هل هناك أي حد لعدد الشرائح عند تحويل العروض التقديمية إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة على الخادم أو النظام الخاص بك.