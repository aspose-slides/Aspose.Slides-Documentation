---
title: تحويل PowerPoint إلى HTML
linktitle: تحويل PowerPoint إلى HTML
type: docs
weight: 30
url: /php-java/convert-powerpoint-to-html/
keywords: "PHP PowerPoint إلى HTML، تحويل عرض PowerPoint، PPTX، PPT، PPT إلى HTML، PPTX إلى HTML، PowerPoint إلى HTML، حفظ PowerPoint كـ HTML، حفظ PPT كـ HTML، حفظ PPTX كـ HTML، Java، Aspose.Slides، تصدير HTML"
description: "تحويل PowerPoint HTML : حفظ PPTX أو PPT كـ HTML . حفظ الشرائح كـ HTML "
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق HTML باستخدام PHP. تغطي المواضيع التالية.

- تحويل PowerPoint إلى HTML
- تحويل PPT إلى HTML
- تحويل PPTX إلى HTML
- تحويل ODP إلى HTML
- تحويل شريحة PowerPoint إلى HTML

## **Java PowerPoint إلى HTML**

للحصول على كود مثال Java لتحويل PowerPoint إلى HTML، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى HTML](#convert-powerpoint-to-html). يمكن للكود تحميل عدد من الصيغ مثل PPT وPPTX وODP في كائن العرض وحفظه بتنسيق HTML.

## **حول تحويل PowerPoint إلى HTML**
باستخدام [**Aspose.Slides لـ PHP عبر Java**](https://products.aspose.com/slides/php-java/)، يمكن للتطبيقات والمطورين تحويل عرض PowerPoint إلى HTML: **PPTX إلى HTML** أو **PPT إلى HTML**.

**Aspose.Slides** يوفر العديد من الخيارات (معظمها من [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) class) التي تحدد عملية تحويل PowerPoint إلى HTML:

* تحويل عرض PowerPoint كامل إلى HTML.
* تحويل شريحة معينة في عرض PowerPoint إلى HTML.
* تحويل وسائط العرض (صور، فيديوهات، إلخ) إلى HTML.
* تحويل عرض PowerPoint إلى HTML متجاوب. 
* تحويل عرض PowerPoint إلى HTML مع ملاحظات المتحدث متضمنة أو مستبعدة. 
* تحويل عرض PowerPoint إلى HTML مع تعليقات متضمنة أو مستبعدة. 
* تحويل عرض PowerPoint إلى HTML مع خطوط أصلية أو مضمنة. 
* تحويل عرض PowerPoint إلى HTML أثناء استخدام نمط CSS الجديد. 

{{% alert color="primary" %}} 

باستخدام واجهته البرمجية الخاصة، طورت Aspose محولات مجانية [للعرض إلى HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT إلى HTML](https://products.aspose.app/slides/conversion/ppt-to-html)، [PPTX إلى HTML](https://products.aspose.app/slides/conversion/pptx-to-html)، [ODP إلى HTML](https://products.aspose.app/slides/conversion/odp-to-html)، إلخ. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

قد ترغب في الاطلاع على محولات أخرى [مجانية من Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}} 

بجانب عمليات التحويل الموضحة هنا، تدعم Aspose.Slides أيضًا هذه العمليات التحويلية التي تتعلق بتنسيق HTML: 

* [HTML إلى صورة](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **تحويل PowerPoint إلى HTML**
باستخدام Aspose.Slides، يمكنك تحويل عرض PowerPoint كامل إلى HTML بهذه الطريقة:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. استخدام [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method لحفظ الكائن كملف HTML.

يعرض هذا الكود كيفية تحويل PowerPoint إلى HTML:

```php
// إنشاء كائن Presentation يمثل ملف عرض
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # حفظ العرض كـ HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحويل PowerPoint إلى HTML متجاوب**
توفر Aspose.Slides الخاصة بـ [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) class التي تتيح لك إنشاء ملفات HTML متجاوبة. يظهر لك هذا الكود كيفية تحويل عرض PowerPoint إلى HTML متجاوب:

```php
// إنشاء كائن Presentation يمثل ملف عرض
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # حفظ العرض كـ HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى HTML مع الملاحظات**
يعرض لك هذا الكود كيفية تحويل PowerPoint إلى HTML مع الملاحظات:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # حفظ صفحات الملاحظات
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى HTML مع الخطوط الأصلية**

توفر Aspose.Slides [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) class التي تسمح لك بتضمين جميع الخطوط في العرض أثناء تحويله إلى HTML.

لمنع تضمين خطوط معينة، يمكنك تمرير مصفوفة من أسماء الخطوط إلى مُنشئ معلمة من [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) class. الخطوط الشائعة، مثل Calibri أو Arial، عندما تُستخدم في عرض، لا تحتاج إلى تضمينها لأن معظم الأنظمة تحتوي بالفعل على مثل هذه الخطوط. عند تضمين تلك الخطوط، يصبح المستند الناتج HTML كبيرًا دون داعٍ.

تدعم [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) class الوراثة وتوفر [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) method، والتي تهدف إلى أن يتم تجاوزها.

```php
  $pres = new Presentation("input.pptx");
  try {
    # استبعاد خطوط العرض الافتراضية
    $fontNameExcludeList = array("Calibri", "Arial" );
    $embedFontsController = new EmbedAllFontsHtmlController($fontNameExcludeList);
    $htmlOptionsEmbed = new HtmlOptions();
    $htmlOptionsEmbed->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($embedFontsController));
    $pres->save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, $htmlOptionsEmbed);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى HTML مع صور عالية الجودة**

بشكل افتراضي، عند تحويل PowerPoint إلى HTML، يقوم Aspose.Slides بإخراج HTML صغير مع صور بدقة 72 DPI وتم حذف المناطق المقطوعة. للحصول على ملفات HTML بصور عالية الجودة، عليك تعيين خاصية `PicturesCompression` (من `HtmlOptions` class) إلى 96 (أي، `PicturesCompression.Dpi96`) أو أعلى [القيم](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression).

يعرض هذا الكود PHP كيفية تحويل عرض PowerPoint إلى HTML مع الحصول على صور عالية الجودة بدقة 150 DPI (أي `PicturesCompression.Dpi150`):

```php
  $pres = new Presentation("InputDoc.pptx");
  try {
    $htmlOpts = new HtmlOptions();
    $htmlOpts->setPicturesCompression(PicturesCompression::Dpi150);
    $pres->save("OutputDoc-dpi150.html", SaveFormat::Html, $htmlOpts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يعرض هذا الكود كيفية إخراج HTML مع صور بدقة كاملة:

```php
  $pres = new Presentation("InputDoc.pptx");
  try {
    $htmlOpts = new HtmlOptions();
    $htmlOpts->setDeletePicturesCroppedAreas(false);
    $pres->save("Outputdoc-noCrop.html", SaveFormat::Html, $htmlOpts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل شريحة إلى HTML**
لتحويل شريحة معينة في PowerPoint إلى HTML، عليك إنشاء مثيل من نفس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class (المستخدمة لتحويل عروض تقديمية كاملة إلى HTML) ثم استخدم [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method لحفظ الملف كـ HTML. يمكن استخدام [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) class لتحديد خيارات تحويل إضافية:

يعرض هذا الكود PHP كيفية تحويل شريحة في عرض PowerPoint إلى HTML:

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;


class CustomFormattingController
{
    function writeDocumentStart($generator, $presentation) { }

    function writeDocumentEnd($generator, $presentation) { }

    function writeSlideStart($generator, $slide)
	{
        $generator->addHtml(sprintf(self::SlideHeader, $generator->getSlideIndex() + 1));
    }

    function writeSlideEnd($generator, $slide)
	{
        $generator->addHtml(self::SlideFooter);
    }

    function writeShapeStart($generator, $shape) { }

    function writeShapeEnd($generator, $shape) { }

    const SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    const SlideFooter = "</div>";
}
  $pres = new Presentation("Individual-Slide.pptx");
  try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
	$formattingController= java_closure(new CustomFormattingController(), null, java("com.aspose.slides.IHtmlFormattingController"));
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($formattingController));
    # حفظ الملف
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حفظ ملفات CSS والصور عند تصديرها إلى HTML**
باستخدام ملفات أنماط CSS الجديدة، يمكنك بسهولة تغيير نمط ملف HTML الناتج من عملية تحويل PowerPoint إلى HTML. 

يعرض كود PHP في هذا المثال كيفية استخدام طرق قابلة للتجاوز لإنشاء مستند HTML مخصص مع رابط إلى ملف CSS:

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # قالب رأس مخصص
    const Header = "<!DOCTYPE html>\n" .
            "<html>\n" .
            "<head>\n" .
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" .
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" .
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" .
            "</head>";

    public $m_cssFileName;

    public function __construct($cssFileName)
    {
        parent::__construct();
		$this->m_cssFileName = $cssFileName;
	}

    public function writeDocumentStart($generator, $presentation)
    {
        $generator->addHtml(sprintf(self::Header, $m_cssFileName));
        $this->writeAllFonts($generator, $presentation);
    }

    public function writeAllFonts($generator, $presentation)
    {
        $generator->addHtml("<!-- خطوط مضمنة -->");
        parent::writeAllFonts($generator, $presentation);
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $options = new HtmlOptions();
    $options->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter(new CustomHeaderAndFontsController("styles.css")));
    $pres->save("pres.html", SaveFormat::Html, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ربط جميع الخطوط عند تحويل العرض إلى HTML**

إذا كنت لا ترغب في تضمين الخطوط (لتجنب زيادة حجم الـ HTML الناتج)، يمكنك ربط جميع الخطوط من خلال تنفيذ إصدارك الخاص من `LinkAllFontsHtmlController`. 

يعرض هذا الكود PHP كيفية تحويل PowerPoint إلى HTML بينما يرتبط بكل الخطوط ويستبعد "Calibri" و "Arial" (حيث أنها موجودة بالفعل في النظام):

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private $m_basePath;

    public function __construct($fontNameExcludeList, $basePath)
    {
        parent::__construct($fontNameExcludeList);
        $this->m_basePath = $basePath;
    }

    function writeFont
    (
            $generator,
            $originalFont,
            $substitutedFont,
            $fontStyle,
            $fontWeight,
            $fontData)
    {
        try {
            $fontName = java_is_null($substitutedFont) ? $originalFont->getFontName() : $substitutedFont->getFontName();
            $path = $fontName . ".woff"; // قد تحتاج إلى بعض تعقيم المسارات
			$fstr = new Java("java.io.FileOutputStream", $this->m_basePath . $path);
			$Array = new java_class("java.lang.reflect.Array");
			try {
				$fstr->write($fontData, 0, $Array->getLength($fontData));
			} finally {
				$fstr->close();
			}

            $generator->addHtml("<style>");
            $generator->addHtml("@font-face { ");
            $generator->addHtml("font-family: '" . $fontName . "'; ");
            $generator->addHtml("src: url('" . $path . "')");

            $generator->addHtml(" }");
            $generator->addHtml("</style>");
        } catch (JavaException $ex) {
        }
    }
}
    $pres = new Presentation("pres.pptx");
  try {
    # استبعاد الخطوط الافتراضية
	$fontNameExcludeList = array("Calibri", "Arial");
    $linkcont = new LinkAllFontsHtmlController($fontNameExcludeList, "C:/Windows/Fonts/");
    $htmlOptionsEmbed = new HtmlOptions();
    $htmlOptionsEmbed->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($linkcont));
    $pres->save("pres.html", SaveFormat::Html, $htmlOptionsEmbed);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل PowerPoint إلى HTML متجاوب**
يعرض هذا الكود PHP كيفية تحويل عرض PowerPoint إلى HTML متجاوب:

```php
  $pres = new Presentation("SomePresentation.pptx");
  try {
    $saveOptions = new HtmlOptions();
    $saveOptions->setSvgResponsiveLayout(true);
    $pres->save("SomePresentation-out.html", SaveFormat::Html, $saveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تصدير ملفات الوسائط إلى HTML**
باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك تصدير ملفات الوسائط بهذه الطريقة:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع إلى الشريحة.
1. إضافة فيديو إلى الشريحة.
1. كتابة العرض كملف HTML.

يعرض هذا الكود PHP كيفية إضافة فيديو إلى العرض ثم حفظه كـ HTML:

```php
// تحميل عرض
  $pres = new Presentation();
  try {
    $path = "./out/";
    $fileName = "ExportMediaFiles_out.html";
    $baseUri = "http://www.example.com/";
    $file = new Java("java.io.File", "my_video.avi");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $videoData = $Array->newInstance($Byte, $Array->getLength($file));
    try {
        $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
        $dis->readFully($videoData);
    } finally {
        if (!java_is_null($dis)) $dis->close();
    }
    $video = $pres->getVideos()->addVideo($videoData);
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $controller = new VideoPlayerHtmlController($path, $fileName, $baseUri);
    # تعيين خيارات HTML
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # حفظ الملف
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```