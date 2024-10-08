---
title: تحويل PowerPoint إلى HTML في C# .NET
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-html/
keywords: "C# PowerPoint إلى HTML، C# PPT إلى HTML، C# ODP إلى HTML، C# شريحة إلى HTML، تحويل عرض PowerPoint، PPTX، PPT، PPT إلى HTML، PPTX إلى HTML، PowerPoint إلى HTML، حفظ PowerPoint كـ HTML، حفظ PPT كـ HTML، حفظ PPTX كـ HTML، C#، Csharp، .NET، Aspose.Slides، تصدير HTML"
description: "تحويل PowerPoint إلى HTML: حفظ PPTX أو PPT كـ HTML. حفظ الشرائح كـ HTML"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام C#. تغطي الموضوعات التالية.

- [تحويل PowerPoint إلى HTML في C#](#convert-powerpoint-to-html)
- [تحويل PPT إلى HTML في C#](#convert-powerpoint-to-html)
- [تحويل PPTX إلى HTML في C#](#convert-powerpoint-to-html)
- [تحويل ODP إلى HTML في C#](#convert-powerpoint-to-html)
- [تحويل شريحة PowerPoint إلى HTML في C#](#convert-slide-to-html)

## **C# PowerPoint إلى HTML**

للحصول على رمز عينة C# لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للرمز تحميل عدد من التنسيقات مثل PPT و PPTX و ODP في كائن Presentation وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides لـ .NET**](https://products.aspose.com/slides/net/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**. 

توفر **Aspose.Slides** العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint بالكامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، مقاطع الفيديو، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث.
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات.
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة.
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد.

{{% alert color="primary" %}} 

باستخدام واجهتها البرمجية الخاصة، قامت Aspose بتطوير محولات [العرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) مجانية: [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على محولات [مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب عمليات التحويل الموصوفة هنا، تدعم Aspose.Slides أيضًا هذه العمليات التحويلية التي تتضمن تنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint بالكامل إلى HTML بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استخدم طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الكائن كملف HTML.

هذا الرمز يوضح لك كيفية تحويل PowerPoint إلى HTML في C#:

```c#
// ينشئ كائن عرض يمثل ملف عرض مثل PPT أو PPTX أو ODP إلخ.
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // يحفظ العرض إلى HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **تحويل PowerPoint إلى HTML متجاوب**
توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) التي تتيح لك إنشاء ملفات HTML متجاوبة. هذا الرمز يوضح لك كيفية تحويل عرض PowerPoint إلى HTML متجاوب في C#:

```c#
// ينشئ كائن Presentation يمثل ملف عرض
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // يحفظ العرض إلى HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**
هذا الرمز يوضح لك كيفية تحويل PowerPoint إلى HTML مع الملاحظات في C#:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // يحفظ صفحات الملاحظات
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) التي تتيح لك تضمين جميع الخطوط في العرض عند تحويل العرض إلى HTML.

لتجنب تضمين خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى المُنشئ المعلم من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). الخطوط الشائعة، مثل Calibri أو Arial، عند استخدامها في عرض، لا تحتاج إلى التضمين لأن معظم الأنظمة تحتوي بالفعل على هذه الخطوط. عندما يتم تضمين تلك الخطوط، يصبح المستند HTML الناتج كبيرًا بشكل غير ضروري.

فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) تدعم الوراثة وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) التي من المقرر أن يتم تجاوزها. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // يستبعد خطوط العرض الافتراضية
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عندما تقوم بتحويل PowerPoint إلى HTML، تقوم Aspose.Slides بإخراج HTML صغير مع صور بدقة 72 DPI ومناطق مقطوعة محذوفة. للحصول على ملفات HTML مع صور بجودة أعلى، يجب عليك ضبط خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي، `PicturesCompression.Dpi96`) أو أعلى [قيم](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

هذا الرمز C# يوضح لك كيفية تحويل عرض PowerPoint إلى HTML أثناء الحصول على صور عالية الجودة بدقة 150 DPI (أي. `PicturesCompression.Dpi150`):

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

هذا الرمز في C# يوضح لك كيفية إخراج HTML مع صور ذات جودة كاملة:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **تحويل شريحة إلى HTML**
لتحويل شريحة محددة في PowerPoint إلى HTML، يجب عليك إنشاء مثيل من نفس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الفئة (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) لتحديد خيارات تحويل إضافية:

هذا الشيفرة C# يوضح لك كيفية تحويل شريحة في عرض PowerPoint إلى HTML:

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // حفظ الملف              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
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
باستخدام ملفات أنماط CSS الجديدة، يمكنك تغيير نمط ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML بسهولة. 

الرمز C# في هذا المثال يوضح لك كيفية استخدام الطرق القابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // قالب رأس مخصص
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
        generator.AddHtml("<!-- الخطوط المدمجة -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **رابط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا تريد تضمين الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط من خلال تنفيذ نسختك الخاصة من `LinkAllFontsHtmlController`. 

هذا الرمز C# يوضح لك كيفية تحويل PowerPoint إلى HTML أثناء ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنها موجودة بالفعل في النظام): 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    //يستبعد خطوط العرض الافتراضية
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

هذا الرمز C# يوضح لك كيفية تنفيذ `LinkAllFontsHtmlController`:

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
            string path = fontName + ".woff"; // قد يحتاج بعض التنظيف للمسار

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

## **تحويل PowerPoint إلى HTML متجاوب**
هذا الرمز C# يوضح لك كيفية تحويل عرض PowerPoint إلى HTML متجاوب:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **تصدير ملفات الوسائط إلى HTML**
باستخدام Aspose.Slides لـ .NET، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. احصل على مرجع إلى الشريحة.
1. أضف فيديو إلى الشريحة.
1. اكتب العرض كملف HTML.

هذا الرمز C# يوضح لك كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML: 

```c#
// يحمل عرضًا
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // يضبط خيارات HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // يحفظ الملف
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```