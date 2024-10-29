---
title: Convertir PowerPoint en HTML
linktitle: Convertir PowerPoint en HTML
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-html/
keywords: "PHP  PowerPoint en HTML, Convertir Présentation PowerPoint, PPTX, PPT, PPT en HTML, PPTX en HTML, PowerPoint en HTML, Enregistrer PowerPoint en HTML, Enregistrer PPT en HTML, Enregistrer PPTX en HTML, Java, Aspose.Slides, exportation HTML"
description: "Convertir PowerPoint en HTML : Enregistrer PPTX ou PPT en HTML. Enregistrer les diapositives en HTML"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant PHP. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML
- Convertir PPT en HTML
- Convertir PPTX en HTML
- Convertir ODP en HTML
- Convertir une diapositive PowerPoint en HTML

## **Java PowerPoint en HTML**

Pour le code exemple Java pour convertir PowerPoint en HTML, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PowerPoint en HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans un objet Présentation et l'enregistrer au format HTML.

## **À propos de la conversion PowerPoint en HTML**
En utilisant [**Aspose.Slides pour PHP via Java**](https://products.aspose.com/slides/php-java/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** fournit de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)) qui définissent le processus de conversion de PowerPoint en HTML :

* Convertir une présentation PowerPoint entière en HTML.
* Convertir une diapositive spécifique d'une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, vidéos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML responsive.
* Convertir une présentation PowerPoint en HTML avec des notes de conférencier incluses ou exclues.
* Convertir une présentation PowerPoint en HTML avec des commentaires inclus ou exclus.
* Convertir une présentation PowerPoint en HTML avec des polices originales ou intégrées.
* Convertir une présentation PowerPoint en HTML tout en utilisant le nouveau style CSS.

{{% alert color="primary" %}} 

En utilisant sa propre API, Aspose a développé des convertisseurs gratuits [présentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous voudrez peut-être consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge ces opérations de conversion impliquant le format HTML : 

* [HTML en image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
En utilisant Aspose.Slides, vous pouvez convertir une présentation PowerPoint entière en HTML de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Utilisez la méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer l'objet en tant que fichier HTML.

Ce code vous montre comment convertir un PowerPoint en HTML :

```php
// Instancier un objet Presentation représentant un fichier de présentation
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # Sauvegarde de la présentation en HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir PowerPoint en HTML responsive**
Aspose.Slides fournit la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) qui vous permet de générer des fichiers HTML responsives. Ce code vous montre comment convertir une présentation PowerPoint en HTML responsive :

```php
// Instancier un objet Presentation représentant un fichier de présentation
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Sauvegarde de la présentation en HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en HTML avec notes**
Ce code vous montre comment convertir un PowerPoint en HTML avec des notes :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Sauvegarde des pages de notes
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en HTML avec polices originales**

Aspose.Slides fournit la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) qui permet d'incorporer toutes les polices dans une présentation lors de la conversion de la présentation en HTML.

Pour empêcher certaines polices d'être incorporées, vous pouvez passer un tableau de noms de polices à un constructeur paramétré de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController). Les polices populaires, telles que Calibri ou Arial, lorsqu'elles sont utilisées dans une présentation, n'ont pas besoin d'être incorporées car la plupart des systèmes contiennent déjà de telles polices. Lorsque ces polices sont incorporées, le document HTML résultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) prend en charge l'héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) qui est destinée à être remplacée.

```php
  $pres = new Presentation("input.pptx");
  try {
    # exclure les polices de présentation par défaut
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

## **Convertir PowerPoint en HTML avec des images de haute qualité**

Par défaut, lorsque vous convertissez PowerPoint en HTML, Aspose.Slides produit un petit HTML avec des images à 72 DPI et des zones recadrées supprimées. Pour obtenir des fichiers HTML avec des images de haute qualité, vous devez définir la propriété `PicturesCompression` (de la classe `HtmlOptions`) sur 96 (c'est-à-dire `PicturesCompression.Dpi96`) ou des [valeurs supérieures](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression).

Ce code PHP vous montre comment convertir une présentation PowerPoint en HTML tout en obtenant des images de haute qualité à 150 DPI (c'est-à-dire `PicturesCompression.Dpi150`) :

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

Ce code vous montre comment produire un HTML avec des images de qualité complète :

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

## **Convertir une diapositive en HTML**
Pour convertir une diapositive spécifique d'un PowerPoint en HTML, vous devez instancier la même classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) (utilisée pour convertir des présentations entières en HTML) et ensuite utiliser la méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) peut être utilisée pour spécifier des options de conversion supplémentaires :

Ce code PHP vous montre comment convertir une diapositive dans une présentation PowerPoint en HTML :

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
    # Sauvegarder le fichier
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Diapositive Individuelle" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Enregistrer le CSS et les images lors de l'exportation en HTML**
En utilisant de nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML résultant du processus de conversion de PowerPoint en HTML. 

Le code PHP dans cet exemple vous montre comment utiliser des méthodes remplaçables pour créer un document HTML personnalisé avec un lien vers un fichier CSS :

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Modèle de l'en-tête personnalisé
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
        $generator->addHtml("<!-- Polices intégrées -->");
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

## **Lier toutes les polices lors de la conversion d'une présentation en HTML**

Si vous ne souhaitez pas incorporer les polices (pour éviter d'augmenter la taille du HTML résultant), vous pouvez lier toutes les polices en implémentant votre propre version de `LinkAllFontsHtmlController`. 

Ce code PHP vous montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent déjà dans le système) :

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
            $path = $fontName . ".woff"; // un certain assainissement de chemin peut être nécessaire
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
    # Exclure les polices de présentation par défaut
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

## **Convertir PowerPoint en HTML responsive**
Ce code PHP vous montre comment convertir une présentation PowerPoint en HTML responsive :

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


## **Exporter des fichiers multimédia en HTML**
En utilisant Aspose.Slides pour PHP via Java, vous pouvez exporter des fichiers multimédia de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence à la diapositive.
1. Ajoutez une vidéo à la diapositive.
1. Écrivez la présentation en tant que fichier HTML.

Ce code PHP vous montre comment ajouter une vidéo à la présentation et ensuite l'enregistrer en tant que HTML :

```php
// Chargement d'une présentation
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
    # Définir les options HTML
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # Sauvegarder le fichier
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```