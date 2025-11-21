---
title: تحويل PowerPoint إلى HTML باستخدام JavaScript
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-html/
keywords: "PowerPoint Java إلى HTML, تحويل عرض PowerPoint, PPTX, PPT, PPT إلى HTML, PPTX إلى HTML, PowerPoint إلى HTML, حفظ PowerPoint كـ HTML, حفظ PPT كـ HTML, حفظ PPTX كـ HTML, Java, Aspose.Slides, تصدير HTML"
description: "تحويل PowerPoint إلى HTML باستخدام JavaScript. حفظ PPTX أو PPT كـ HTML في JavaScript. حفظ الشرائح كـ HTML في JavaScript"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى صيغة HTML باستخدام JavaScript. تغطي المواضيع التالية:

- تحويل PowerPoint إلى HTML في JavaScript
- تحويل PPT إلى HTML في JavaScript
- تحويل PPTX إلى HTML في JavaScript
- تحويل ODP إلى HTML في JavaScript
- تحويل شريحة PowerPoint إلى HTML في JavaScript

## **PowerPoint إلى HTML في JavaScript**

للحصول على عينة كود JavaScript لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [Convert PowerPoint to HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation وحفظه بصيغة HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من فئة [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة محددة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (الصور، الفيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد ملاحظات المتحدث. 
* تحويل عرض PowerPoint إلى HTML مع تضمين أو استبعاد التعليقات. 
* تحويل عرض PowerPoint إلى HTML مع الخطوط الأصلية أو المدمجة. 
* تحويل عرض PowerPoint إلى HTML مع استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام API الخاص به، طوّرت Aspose محولات مجانية [من عرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على محولات مجانية أخرى من Aspose عبر هذا الرابط: [free converters from Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

بالإضافة إلى عمليات التحويل المذكورة هنا، يدعم Aspose.Slides عمليات التحويل التالية المتعلقة بصيغة HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}

## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. استخدم طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) لحفظ الكائن كملف HTML.

يظهر هذا الكود كيفية تحويل PowerPoint إلى HTML في JavaScript:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // حفظ العرض التقديمي إلى HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى HTML متجاوب**
توفر Aspose.Slides الفئة [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) التي تسمح بإنشاء ملفات HTML متجاوبة. يوضح هذا الكود كيفية تحويل عرض PowerPoint إلى HTML متجاوب في JavaScript:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // حفظ العرض التقديمي إلى HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى HTML مع ملاحظات**
يظهر هذا الكود كيفية تحويل PowerPoint إلى HTML مع الملاحظات في JavaScript:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // حفظ صفحات الملاحظات
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides الفئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) التي تسمح بدمج جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع دمج خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى المُنشئ المParameterized من فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController). الخطوط الشائعة، مثل Calibri أو Arial، عند استخدامها في العرض، لا يلزم دمجها لأن معظم الأنظمة تحتوي عليها مسبقًا. عندما يتم دمج تلك الخطوط، يصبح مستند HTML الناتج كبيرًا بشكل غير ضروري.

تدعم فئة [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) الميراث وتوفر طريقة [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) التي يُقصد تجاوزها.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // استبعاد خطوط العرض التقديمي الافتراضية
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عند تحويل PowerPoint إلى HTML، ينتج Aspose.Slides ملفات HTML صغيرة مع صور بدقة 72 DPI ومناطق مقصوصة محذوفة. للحصول على ملفات HTML بصور ذات جودة أعلى، عليك تمرير القيمة `96` إلى طريقة `setPicturesCompression` من فئة `HtmlOptions` (أي `PicturesCompression.Dpi96`) أو قيم أعلى كما هو موضح في [القيم المتاحة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

يُظهر هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


هذا الكود في JavaScript يُظهر كيفية إخراج HTML مع صور بجودة كاملة:
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحويل الشريحة إلى HTML**
لتحويل شريحة معينة في PowerPoint إلى HTML، عليك إنشاء مثيل من نفس الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) (المستخدمة لتحويل العروض الكلية إلى HTML) ثم استخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) لحفظ الملف كـ HTML. يمكن استخدام فئة [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) لتحديد خيارات تحويل إضافية:

يُظهر هذا الكود JavaScript كيفية تحويل شريحة في عرض PowerPoint إلى HTML:
```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // حفظ الملف
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **حفظ CSS والصور عند التصدير إلى HTML**
باستخدام ملفات نمط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج عن عملية تحويل PowerPoint إلى HTML.

يُظهر الكود JavaScript في هذا المثال كيفية استخدام طرق يمكن تجاوزها لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ستحتاج إلى تنفيذ `CustomHeaderAndFontsController` في Java، تجميعه، وإضافته إلى موقع الوحدة \aspose.slides.via.java\lib\.
يُظهر هذا الكود Java كيفية تنفيذ `CustomHeaderAndFontsController`:
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


## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا ترغب في دمج الخطوط (لتجنب زيادة حجم HTML الناتج)، يمكنك ربط جميع الخطوط عبر تنفيذ نسخة خاصة من `LinkAllFontsHtmlController`.

يُظهر هذا الكود JavaScript كيفية تحويل PowerPoint إلى HTML مع ربط جميع الخطوط واستثناء "Calibri" و "Arial" (لأنهما موجودتان بالفعل في النظام):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // استبعاد خطوط العرض التقديمي الافتراضية
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


ستحتاج إلى تنفيذ `LinkAllFontsHtmlController` في Java، تجميعه، وإضافته إلى موقع الوحدة \aspose.slides.via.java\lib\.
يُظهر هذا الكود Java كيفية تنفيذ `LinkAllFontsHtmlController`:
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
            String path = fontName + ".woff"; // قد يكون من الضروري تنقية المسار
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
يُظهر هذا الكود JavaScript كيفية تحويل عرض PowerPoint إلى HTML متجاوب:
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **استخراج ملفات الوسائط إلى HTML**
باستخدام Aspose.Slides for Node.js via Java، يمكنك استخراج ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

يُظهر هذا الكود JavaScript كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:
```javascript
// تحميل عرض تقديمي
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // تعيين خيارات HTML
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // حفظ الملف
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ما هو أداء Aspose.Slides عند تحويل عروض متعددة إلى HTML؟**

يعتمد الأداء على حجم وتعقيد العروض. Aspose.Slides فعال للغاية وقابل للتوسع للعمليات الدفعية. لتحقيق الأداء المثالي عند تحويل عدد كبير من العروض، يُنصح باستخدام المعالجة المتعددة الخيوط أو المعالجة المتوازية كلما كان ذلك ممكنًا.

**هل يدعم Aspose.Slides تصدير الروابط التشعبية إلى HTML؟**

نعم، يدعم Aspose.Slides بالكامل تصدير الروابط التشعبية المدمجة إلى HTML. عندما تقوم بتحويل العروض إلى صيغة HTML، تُحافظ الروابط التشعبية تلقائيًا وتظل قابلة للنقر.

**هل هناك حد لعدد الشرائح عند تحويل العروض إلى HTML؟**

لا يوجد حد لعدد الشرائح عند استخدام Aspose.Slides. يمكنك تحويل عروض بأي حجم. ومع ذلك، بالنسبة للعروض التي تحتوي على عدد كبير جدًا من الشرائح، قد يعتمد الأداء على الموارد المتاحة على الخادم أو النظام الخاص بك.