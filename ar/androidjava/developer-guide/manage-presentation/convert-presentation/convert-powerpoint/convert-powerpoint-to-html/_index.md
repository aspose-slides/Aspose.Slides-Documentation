---
title: تحويل عروض PowerPoint إلى HTML على Android
linktitle: PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-html/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- حفظ PowerPoint كـ HTML
- حفظ العرض التقديمي كـ HTML
- حفظ الشريحة كـ HTML
- حفظ PPT كـ HTML
- حفظ PPTX كـ HTML
- تصدير PPT إلى HTML
- تصدير PPTX إلى HTML
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى HTML متجاوب في Java. الحفاظ على التخطيط والروابط والصور باستخدام Aspose.Slides لنظام Android دليل التحويل للحصول على نتائج سريعة خالية من الأخطاء."
---

## **نظرة عامة**

هذه المقالة تشرح كيفية تحويل عرض تقديمي PowerPoint إلى تنسيق HTML باستخدام Java. تغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML في Java
- تحويل PPT إلى HTML في Java
- تحويل PPTX إلى HTML في Java
- تحويل ODP إلى HTML في Java
- تحويل شريحة PowerPoint إلى HTML في Java

## **PowerPoint إلى HTML على Android**

للحصول على عينة كود Java لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [Convert PowerPoint to HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من التنسيقات مثل PPT و PPTX و ODP في كائن Presentation وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**

باستخدام [**Aspose.Slides for Android عبر Java**](https://products.aspose.com/slides/androidjava/)، يمكن للتطبيقات والمطورين تحويل عرض تقديمي PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

توفر Aspose.Slides العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) ) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض تقديمي PowerPoint كامل إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع تضمين ملاحظات المتحدث أو استثناؤها. 
* تحويل عرض PowerPoint إلى HTML مع تضمين التعليقات أو استثناؤها. 
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة. 
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام واجهة برمجة التطبيقات الخاصة بها، طورت Aspose محولات مجانية من [العرض التقديمي إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على [محولات مجانية أخرى من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل الموضحة هنا، يدعم Aspose.Slides أيضًا عمليات التحويل التالية المتعلقة بتنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض تقديمي PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. استخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) لحفظ الكائن كملف HTML.

هذا الكود يظهر لك كيفية تحويل PowerPoint إلى HTML في Java:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // حفظ العرض بتنسيق HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى HTML متجاوب**
توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) التي تسمح بإنشاء ملفات HTML متجاوبة. يُظهر هذا الكود كيفية تحويل عرض PowerPoint إلى HTML متجاوب في Java:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // حفظ العرض بتنسيق HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحويل PowerPoint إلى HTML مع الملاحظات**
يُظهر هذا الكود كيفية تحويل PowerPoint إلى HTML مع الملاحظات في Java:
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

توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج بعض الخطوط، يمكنك تمرير مصفوفة من أسماء الخطوط إلى منشئ مُعاملات الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). الخطوط الشائعة مثل Calibri أو Arial، عند استخدامها في عرض، لا تحتاج إلى دمجها لأن معظم الأنظمة تتضمن هذه الخطوط مسبقًا. عندما تُدمج هذه الخطوط، يصبح مستند HTML الناتج كبيرًا دون ضرورة.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) الوراثة وتوفر الطريقة [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) التي يُقصد أن يتم تجاوزها.
```java
Presentation pres = new Presentation("input.pptx");
try {
    // استبعاد خطوط العرض التقديمي الافتراضية
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

بشكل افتراضي، عند تحويل PowerPoint إلى HTML، تُنتج Aspose.Slides ملفات HTML صغيرة مع صور بدقة 72 DPI وتُحذف المناطق المقتطعة. للحصول على ملفات HTML بصور ذات جودة أعلى، عليك تعيين خاصية `PicturesCompression` (من فئة `HtmlOptions`) إلى 96 (أي `PicturesCompression.Dpi96`) أو قيم أعلى [values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression).

يُظهر هذا كود Java كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):
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


يُظهر هذا الكود في Java كيفية إخراج HTML بصور ذات جودة كاملة:
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
لتحويل شريحة محددة في PowerPoint إلى HTML، عليك إنشاء كائن من نفس فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (المستخدمة لتحويل العروض الكاملة إلى HTML) ثم استخدام طريقة [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) لتحديد خيارات تحويل إضافية:

هذا كود Java يوضح كيفية تحويل شريحة في عرض PowerPoint إلى HTML:
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


## **حفظ CSS والصور عند التصدير إلى HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML.

يُظهر كود Java في هذا المثال كيفية استخدام طرق قابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:
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
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **ربط جميع الخطوط عند تحويل عرض تقديمي إلى HTML**

إذا كنت لا تريد دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط عن طريق تنفيذ نسخة خاصة بك من `LinkAllFontsHtmlController`.

هذا كود Java يوضح كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و "Arial" (لأنهما موجودان بالفعل في النظام): 
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // استبعاد خطوط العرض التقديمية الافتراضية
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


هذا كود Java يوضح كيفية تنفيذ `LinkAllFontsHtmlController`:
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
            String path = fontName + ".woff"; // قد يلزم تنظيف بعض المسار
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
هذا كود Java يوضح كيفية تحويل عرض PowerPoint إلى HTML متجاوب:
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
باستخدام Aspose.Slides for Android عبر Java، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع إلى الشريحة.
3. إضافة فيديو إلى الشريحة.
4. حفظ العرض كملف HTML.

هذا كود Java يوضح كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:
```java
// تحميل عرض تقديمي
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


## **FAQ**

**ما هو الأداء الخاص بـ Aspose.Slides عند تحويل عروض تقديمية متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعّال للغاية وقابل للتوسع للعمليات الدفعية. للحصول على أفضل أداء عند تحويل عدد كبير من العروض، يُنصح باستخدام تعدد الخيوط أو المعالجة المتوازية كلما كان ذلك ممكنًا.

**هل تدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، تدعم Aspose.Slides تصدير الروابط التشعبية المدمجة إلى HTML. عند تحويل العروض إلى تنسيق HTML، يتم الحفاظ على الروابط تلقائيًا وتظل قابلة للنقر.

**هل هناك أي حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة على الخادم أو النظام الخاص بك.