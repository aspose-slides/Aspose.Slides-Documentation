---
title: PowerPoint in HTML konvertieren
linktitle: PowerPoint in HTML konvertieren
type: docs
weight: 30
url: /de/php-java/convert-powerpoint-to-html/
keywords: "PHP PowerPoint in HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, Java, Aspose.Slides, HTML-Export"
description: "PowerPoint HTML konvertieren: Speichern Sie PPTX oder PPT als HTML. Speichern Sie Folien als HTML."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie eine PowerPoint-Präsentation im HTML-Format mit PHP konvertieren. Er behandelt die folgenden Themen.

- PowerPoint in HTML konvertieren
- PPT in HTML konvertieren
- PPTX in HTML konvertieren
- ODP in HTML konvertieren
- PowerPoint-Folie in HTML konvertieren

## **Java PowerPoint in HTML**

Für Beispielcode zur Konvertierung von PowerPoint in HTML mit Java siehe den nachstehenden Abschnitt, d.h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann eine Vielzahl von Formaten wie PPT, PPTX und ODP im Präsentationsobjekt laden und in HTML-Format speichern.

## **Über die PowerPoint-zu-HTML-Konvertierung**
Mit [**Aspose.Slides für PHP über Java**](https://products.aspose.com/slides/php-java/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML konvertieren: **PPTX in HTML** oder **PPT in HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)-Klasse), die den Konvertierungsprozess von PowerPoint zu HTML definieren:

* Konvertieren Sie eine gesamte PowerPoint-Präsentation in HTML.
* Konvertieren Sie eine bestimmte Folie in einer PowerPoint-Präsentation in HTML.
* Konvertieren Sie Präsentationsmedien (Bilder, Videos usw.) in HTML.
* Konvertieren Sie eine PowerPoint-Präsentation in reaktionsfähiges HTML.
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit enthaltenen oder ausgeschlossenen Sprechernotizen.
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit enthaltenen oder ausgeschlossenen Kommentaren.
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit originalen oder eingebetteten Schriftarten.
* Konvertieren Sie eine PowerPoint-Präsentation in HTML und verwenden Sie den neuen CSS-Stil.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation in HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)-Konverter entwickelt: [PPT in HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX in HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP in HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten vielleicht auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) überprüfen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen im Zusammenhang mit dem HTML-Format: 

* [HTML in Bild](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf folgende Weise in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML konvertieren:

```php
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # Speichern der Präsentation als HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint in reaktionsfähiges HTML konvertieren**
Aspose.Slides bietet die [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController)-Klasse, die es Ihnen ermöglicht, reaktionsfähige HTML-Dateien zu erstellen. Dieser Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in reaktionsfähiges HTML konvertieren:

```php
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Speichern der Präsentation als HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint in HTML mit Notizen konvertieren**
Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML mit Notizen konvertieren:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Speichern der Notizenseiten
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint in HTML mit Originalschriftarten konvertieren**

Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)-Klasse, die es Ihnen ermöglicht, alle Schriftarten in einer Präsentation einzubetten, während die Präsentation in HTML konvertiert wird.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array von Schriftartnamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)-Klasse übergeben. Beliebte Schriftarten wie Calibri oder Arial, die in einer Präsentation verwendet werden, müssen nicht eingebettet werden, da die meisten Systeme solche Schriftarten bereits enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)-Klasse unterstützt Vererbung und bietet die [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)-Methode, die überschrieben werden soll.

```php
  $pres = new Presentation("input.pptx");
  try {
    # standardmäßige Präsentationsschriftarten ausschließen
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

## **PowerPoint in HTML mit Bildern von hoher Qualität konvertieren**

Standardmäßig gibt Aspose.Slides bei der Konvertierung von PowerPoint in HTML ein kleines HTML mit Bildern bei 72 DPI und gelöschten beschnittenen Bereichen aus. Um HTML-Dateien mit Bildern von höherer Qualität zu erhalten, müssen Sie die `PicturesCompression`-Eigenschaft (aus der `HtmlOptions`-Klasse) auf 96 (d.h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression) setzen.

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in HTML konvertieren und dabei Bilder von hoher Qualität bei 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:

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

Dieser Code zeigt Ihnen, wie Sie HTML mit Bildern in voller Qualität ausgeben:

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

## **Folie in HTML konvertieren**
Um eine bestimmte Folie in einer PowerPoint-Präsentation in HTML zu konvertieren, müssen Sie die gleiche [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse instanziieren (die verwendet wird, um gesamte Präsentationen in HTML zu konvertieren) und dann die [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)-Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)-Klasse kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser PHP-Code zeigt Ihnen, wie Sie eine Folie in einer PowerPoint-Präsentation in HTML konvertieren:

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
    # Datei speichern
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS-Stildateien können Sie den Stil der HTML-Datei, die aus dem Konvertierungsprozess von PowerPoint nach HTML resultiert, ganz einfach ändern.

Der PHP-Code in diesem Beispiel zeigt Ihnen, wie Sie überladbare Methoden verwenden, um ein benutzerdefiniertes HTML-Dokument mit einem Link zu einer CSS-Datei zu erstellen:

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Benutzerdefinierte Header-Vorlage
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
        $generator->addHtml("<!-- Eingebettete Schriftarten -->");
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

## **Alle Schriftarten beim Konvertieren der Präsentation in HTML verlinken**

Wenn Sie keine Schriftarten einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren. 

Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint in HTML konvertieren, während alle Schriftarten verlinkt und "Calibri" und "Arial" ausgeschlossen werden (da sie bereits im System vorhanden sind):

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
            $path = $fontName . ".woff"; // Möglicherweise ist eine Pfadsanierung erforderlich
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
    # Standardmäßige Präsentationsschriftarten ausschließen
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

## **PowerPoint in reaktionsfähiges HTML konvertieren**
Dieser PHP-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in reaktionsfähiges HTML konvertieren:

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


## **Medieninhalte in HTML exportieren**
Mit Aspose.Slides für PHP über Java können Sie Medieninhalte auf folgende Weise exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Fügen Sie ein Video zur Folie hinzu.
1. Schreiben Sie die Präsentation als HTML-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie ein Video zur Präsentation hinzufügen und es dann als HTML speichern:

```php
// Laden einer Präsentation
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
    # HTML-Optionen festlegen
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # Datei speichern
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```