---
title: PowerPoint-Präsentationen in HTML konvertieren mit PHP
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/php-java/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- PPT nach HTML exportieren
- PPTX nach HTML exportieren
- PHP
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML mit PHP konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden schnell und fehlerfrei erhalten."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit PHP in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint zu HTML konvertieren
- PPT zu HTML konvertieren
- PPTX zu HTML konvertieren
- ODP zu HTML konvertieren
- PowerPoint‑Folie zu HTML konvertieren

## **PowerPoint zu HTML in PHP**

Für Beispielcode in Java zur Konvertierung von PowerPoint zu HTML siehe bitte den Abschnitt unten, d. h. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Der Code kann zahlreiche Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und in das HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML-Konvertierung**

Mit [**Aspose.Slides für PHP via Java**](https://products.aspose.com/slides/php-java/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)), die den PowerPoint‑zu‑HTML-Konvertierungsprozess definieren:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Sprecher‑Notizen ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Kommentare ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei originale oder eingebettete Schriftarten verwendet werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren und dabei den neuen CSS‑Stil verwenden.

{{% alert color="primary" %}} 

Mit ihrer eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch folgende Konvertierungsoperationen im Zusammenhang mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine komplette PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie ein PowerPoint in HTML konvertieren :
```php
// Instanziiere ein Presentation‑Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    #    Speichere die Präsentation als HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **PowerPoint zu responsivem HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren :
```php
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Speichere die Präsentation als HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie ein PowerPoint in HTML mit Notizen konvertieren :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Speichern von Notizseiten
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint zu HTML mit Originalschriftarten konvertieren**

Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) zur Verfügung, mit der Sie alle Schriftarten einer Präsentation beim Konvertieren in HTML einbetten können.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen in einer Präsentation nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) bereit, die überschrieben werden soll.
```php
  $pres = new Presentation("input.pptx");
  try {
    # Standard-Präsentationsschriftarten ausschließen
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


## **PowerPoint zu HTML mit hochqualitativen Bildern konvertieren**

Standardmäßig erzeugt Aspose.Slides beim Konvertieren von PowerPoint zu HTML ein kompaktes HTML mit Bildern mit 72 DPI und entfernten Beschnittbereichen. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d. h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression) setzen.

Dieser PHP‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren und dabei hochqualitative Bilder mit 150 DPI erhalten (d. h. `PicturesCompression.Dpi150`):
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


Dieser Code zeigt, wie Sie HTML mit Bildern in voller Qualität ausgeben:
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


## **Eine Folie zu HTML konvertieren**
Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, müssen Sie dieselbe Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) instanziieren (die zum Konvertieren kompletter Präsentationen in HTML verwendet wird) und anschließend die Methode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) verwenden, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen festzulegen:

Dieser PHP‑Code zeigt, wie Sie eine Folie einer PowerPoint‑Präsentation in HTML konvertieren:
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


## **CSS und Bilder beim Exportieren nach HTML speichern**
Durch die Verwendung neuer CSS‑Stildateien können Sie das Aussehen der HTML‑Datei, die aus dem PowerPoint‑zu‑HTML-Konvertierungsprozess entsteht, einfach ändern.

Der PHP‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument mit einem Verweis auf eine CSS‑Datei zu erstellen:
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Benutzerdefinierte Kopfzeilenvorlage
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
        $generator->addHtml("<!-- Embedded fonts -->");
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


## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation zu HTML**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu erhöhen), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren.

Dieser PHP‑Code zeigt, wie Sie ein PowerPoint in HTML konvertieren, dabei alle Schriftarten verlinken und „Calibri“ sowie „Arial“ ausschließen (da sie bereits im System vorhanden sind):
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
            $path = $fontName . ".woff"; // einige Pfadbereinigungen können erforderlich sein
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
    # Standard‑Präsentationsschriftarten ausschließen
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


## **PowerPoint zu responsivem HTML konvertieren**
Dieser PHP‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren:
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


## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides für PHP via Java können Sie Mediendateien wie folgt exportieren:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie eine Referenz zur Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser PHP‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:
```php
// Lade eine Präsentation
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


## **FAQ**

**Wie ist die Performance von Aspose.Slides beim Konvertieren mehrerer Präsentationen zu HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist für Batch‑Operationen hoch effizient und skalierbar. Um bei der Konvertierung vieler Präsentationen optimale Performance zu erzielen, wird empfohlen, nach Möglichkeit Mehrfach‑Threading oder Parallelverarbeitung zu verwenden.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das Exportieren eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen in das HTML‑Format werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen zu HTML?**

Bei der Verwendung von Aspose.Slides gibt es keine Begrenzung der Folienzahl. Sie können Präsentationen beliebiger Größe konvertieren. Bei Präsentationen mit einer sehr großen Anzahl von Folien kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.