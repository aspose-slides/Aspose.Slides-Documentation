---
title: تحويل PowerPoint إلى HTML في Java
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint إلى HTML, تحويل عرض PowerPoint, PPTX, PPT, PPT إلى HTML, PPTX إلى HTML, PowerPoint إلى HTML, حفظ PowerPoint كـ HTML, حفظ PPT كـ HTML, حفظ PPTX كـ HTML, Java, Aspose.Slides, تصدير HTML"
description: "تحويل PowerPoint HTML في Java: حفظ PPTX أو PPT كـ HTML في Java. حفظ الشرائح كـ HTML في Java"
---

## **نظرة عامة**

تتناول هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام Java. تغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML في Java
- تحويل PPT إلى HTML في Java
- تحويل PPTX إلى HTML في Java
- تحويل ODP إلى HTML في Java
- تحويل شريحة PowerPoint إلى HTML في Java

## **Java PowerPoint إلى HTML**

للحصول على مثال لشفرة Java لتحويل PowerPoint إلى HTML، يرجى مراجعة القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للشفرة تحميل عدد من التنسيقات مثل PPT و PPTX و ODP في كائن العرض وحفظه في تنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides لـ Android عبر Java**](https://products.aspose.com/slides/androidjava/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (صور، فيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث مشمولة أو مستبعدة. 
* تحويل عرض PowerPoint إلى HTML مع التعليقات مشمولة أو مستبعدة. 
* تحويل عرض PowerPoint إلى HTML مع خطوط أصلية أو مضمنة. 
* تحويل عرض PowerPoint إلى HTML أثناء استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام واجهته البرمجية الخاصة، طورت Aspose محولات مجانية [للعرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في التحقق من المحولات الأخرى [المجانية من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب عمليات التحويل الموصوفة هنا، تدعم Aspose.Slides أيضًا هذه العمليات التحويلية المتعلقة بتنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. استخدم أسلوب [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) لحفظ الكائن كملف HTML.

تعرض هذه الشفرة كيفية تحويل PowerPoint إلى HTML في Java:

```java
// إنشاء كائن Presentation يمثل ملف عرض
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // حفظ العرض إلى HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى HTML متجاوب**
توفر Aspose.Slides فئة [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) التي تتيح لك إنشاء ملفات HTML متجاوبة. تعرض هذه الشفرة كيفية تحويل عرض PowerPoint إلى HTML متجاوب في Java:

```java
// إنشاء كائن Presentation يمثل ملف عرض
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // حفظ العرض إلى HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**
تعرض هذه الشفرة كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Java:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // حفظ صفحات الملاحظات
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) التي تتيح لك تضمين جميع الخطوط في العرض أثناء تحويل العرض إلى HTML.

لتجنب تضمين بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى منشئ معلمات من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). الخطوط الشائعة، مثل Calibri أو Arial، عند استخدامها في عرض، لا تحتاج إلى تضمينها لأن معظم الأنظمة تحتوي بالفعل على هذه الخطوط. عندما يتم تضمين هذه الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) الوراثة وتوفر أسلوب [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) الذي يهدف إلى أن يتم تجاوزه.

```java
Presentation pres = new Presentation("input.pptx");
try {
    // استبعاد الخطوط الافتراضية للعرض
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عند تحويل PowerPoint إلى HTML، تقوم Aspose.Slides بإخراج HTML صغير مع صور بدقة 72 DPI والمناطق المقصوصة المحذوفة. للحصول على ملفات HTML مع صور عالية الجودة، يجب عليك تعيين خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression.Dpi96`) أو قيم أعلى [قيم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression).

تعرض هذه الشفرة في Java كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

توضح هذه الشفرة في Java كيفية إخراج HTML مع صور كاملة الجودة:

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل شريحة إلى HTML**
لتحويل شريحة معينة في PowerPoint إلى HTML، يجب عليك إنشاء مثيل من نفس فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (التي تستخدم لتحويل العروض الكاملة إلى HTML) ثم استخدام أسلوب [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) لتحديد خيارات التحويل الإضافية:

توضح هذه الشفرة في Java كيفية تحويل شريحة في عرض PowerPoint إلى HTML:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // حفظ الملف
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```


## **حفظ CSS والصور عند تصدير إلى HTML**
باستخدام ملفات أنماط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML. 

توضح هذه الشفرة في Java مثالًا عن كيفية استخدام الأساليب القابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // قالب رأس مخصص
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName) 
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation) 
    {
        generator.addHtml("<!-- الخطوط المدمجة -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا ترغب في تضمين الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط من خلال تنفيذ نسختك الخاصة من `LinkAllFontsHtmlController`.

توضح هذه الشفرة في Java كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستبعاد "Calibri" و "Arial" (لأنها موجودة بالفعل في النظام): 

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // استبعاد الخطوط الافتراضية للعرض
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```

توضح هذه الشفرة في Java كيفية تنفيذ `LinkAllFontsHtmlController`:

```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // قد تحتاج إلى تطهير المسار
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```

## **تحويل PowerPoint إلى HTML متجاوب**
توضح هذه الشفرة في Java كيفية تحويل عرض PowerPoint إلى HTML متجاوب:

```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تصدير ملفات الوسائط إلى HTML**
باستخدام Aspose.Slides لـ Android عبر Java، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. احصل على مرجع إلى الشريحة.
1. أضف فيديو إلى الشريحة.
1. اكتب العرض كملف HTML.

توضح هذه الشفرة في Java كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML: 

```java
// تحميل عرض
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // تعيين خيارات HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // حفظ الملف
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```