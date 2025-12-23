---
title: Convertir des présentations PowerPoint en HTML avec PHP
linktitle: PowerPoint en HTML
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en HTML
- présentation en HTML
- diapositive en HTML
- PPT en HTML
- PPTX en HTML
- enregistrer PowerPoint en HTML
- enregistrer présentation en HTML
- enregistrer diapositive en HTML
- enregistrer PPT en HTML
- enregistrer PPTX en HTML
- exporter PPT en HTML
- exporter PPTX en HTML
- PHP
- Aspose.Slides
description: "Convertir des présentations PowerPoint en HTML réactif avec PHP. Conservez la mise en page, les liens et les images grâce au guide de conversion Aspose.Slides pour des résultats rapides et impeccables."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format HTML en utilisant PHP. Il couvre les sujets suivants.

- Convertir PowerPoint en HTML
- Convertir PPT en HTML
- Convertir PPTX en HTML
- Convertir ODP en HTML
- Convertir une diapositive PowerPoint en HTML

## **PowerPoint en HTML avec PHP**

Pour le code d'exemple Java permettant de convertir PowerPoint en HTML, veuillez consulter la section ci-dessous, c’est-a-dire [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Le code peut charger plusieurs formats tels que PPT, PPTX et ODP dans l'objet Presentation et l'enregistrer au format HTML.

## **A propos de la conversion PowerPoint en HTML**

En utilisant [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), les applications et les développeurs peuvent convertir une présentation PowerPoint en HTML : **PPTX en HTML** ou **PPT en HTML**.

**Aspose.Slides** fournit de nombreuses options (principalement de la classe [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)) qui définissent le processus de conversion PowerPoint en HTML :

* Convertir une présentation PowerPoint entière en HTML.
* Convertir une diapositive spécifique d'une présentation PowerPoint en HTML.
* Convertir les médias de la présentation (images, videos, etc.) en HTML.
* Convertir une présentation PowerPoint en HTML reactif.
* Convertir une présentation PowerPoint en HTML avec ou sans notes du presentateur.
* Convertir une présentation PowerPoint en HTML avec ou sans commentaires.
* Convertir une présentation PowerPoint en HTML avec les polices originales ou incorporees.
* Convertir une présentation PowerPoint en HTML en utilisant le nouveau style CSS.

{{% alert color="primary" %}} 

En utilisant son propre API, Aspose a developpe des convertisseurs gratuits [presentation en HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) : [PPT en HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX en HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP en HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vous pouvez egalement consulter d'autres [convertisseurs gratuits d'Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

En plus des processus de conversion décrits ici, Aspose.Slides prend également en charge les operations de conversion suivantes impliquant le format HTML : 

* [HTML en image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint en HTML**
En utilisant Aspose.Slides, vous pouvez convertir une presentation PowerPoint entière en HTML de cette maniere :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
2. Utilisez la [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode pour enregistrer l'objet en tant que fichier HTML.

Ce code montre comment convertir un PowerPoint en HTML :
```php
// Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # Enregistrement de la présentation en HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Convertir PowerPoint en HTML réactif**
Aspose.Slides fourni la classe [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) qui vous permet de generer des fichiers HTML reactifs. Ce code montre comment convertir une presentation PowerPoint en HTML reactif :
```php
// Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Enregistrement de la présentation en HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir PowerPoint en HTML avec notes**
Ce code montre comment convertir un PowerPoint en HTML avec les notes :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Enregistrement des pages de notes
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Convertir PowerPoint en HTML avec polices originales**

Aspose.Slides fourni la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) qui vous permet d'incorporer toutes les polices d'une presentation lors de la conversion en HTML.

Pour eviter l'incorporation de certaines polices, vous pouvez transmettre un tableau de noms de polices a un constructeur parametre de la classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController). Les polices populaires, telles que Calibri ou Arial, lorsqu'utilisees dans une presentation, n'ont pas besoin d'etre incorporees car la plupart des systemes les contiennent deja. Lorsque ces polices sont incorporees, le document HTML resultant devient inutilement volumineux.

La classe [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) supporte l'héritage et fournit la méthode [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) qui est destinée a être surchargée.
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


## **Convertir PowerPoint en HTML avec images haute qualite**

Par défaut, lors de la conversion de PowerPoint en HTML, Aspose.Slides genere un HTML avec des images a 72 DPI et supprime les zones recadrees. Pour obtenir des fichiers HTML avec des images de meilleure qualite, vous devez definir la propriete `PicturesCompression` (de la classe `HtmlOptions`) sur 96 (c'est-a-dire `PicturesCompression.Dpi96`) ou des [valeurs](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression).

Ce code PHP montre comment convertir une presentation PowerPoint en HTML tout en obtenant des images haute qualite a 150 DPI (c'est-a-dire `PicturesCompression.Dpi150`) :
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


Ce code montre comment produire du HTML avec des images en pleine qualite :
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
Pour convertir une diapositive specifique d'un PowerPoint en HTML, vous devez instancier la meme [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe (utilisee pour convertir des presentations entieres en HTML) puis utiliser la [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode pour enregistrer le fichier au format HTML. La classe [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) peut etre utilisee pour specifier des options de conversion supplementaires :

Ce code PHP montre comment convertir une diapositive d'une presentation PowerPoint en HTML :
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
    # Enregistrement du fichier
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Enregistrer le CSS et les images lors de l'exportation en HTML**
En utilisant les nouveaux fichiers de style CSS, vous pouvez facilement modifier le style du fichier HTML resultnant du processus de conversion PowerPoint en HTML. 

Le code PHP de cet exemple montre comment utiliser des methodes surchargables pour creer un document HTML personnalise avec un lien vers un fichier CSS :
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Modèle d'en-tête personnalisé
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


## **Lier toutes les polices lors de la conversion d'une presentation en HTML**

Si vous ne souhaitez pas incorporer les polices (pour eviter d'augmenter la taille du HTML resultant), vous pouvez lier toutes les polices en implementant votre propre version `LinkAllFontsHtmlController`. 

Ce code PHP montre comment convertir un PowerPoint en HTML tout en liant toutes les polices et en excluant "Calibri" et "Arial" (puisqu'elles existent deja dans le systeme) :
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
            $path = $fontName . ".woff"; // une certaine désinfection du chemin peut être nécessaire
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


## **Convertir PowerPoint en HTML réactif**
Ce code PHP montre comment convertir une presentation PowerPoint en HTML réactif :
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


## **Exporter les fichiers multimédia en HTML**
En utilisant Aspose.Slides for PHP via Java, vous pouvez exporter des fichiers multimédia de cette maniere :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.
2. Obtenez une référence à la diapositive.
3. Ajoutez une video à la diapositive.
4. Enregistrez la presentation sous forme de fichier HTML.

Ce code PHP montre comment ajouter une video a la presentation puis l'enregistrer en HTML :
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
    # Définition des options HTML
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # Enregistrement du fichier
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quelle est la performance d'Aspose.Slides lors de la conversion de plusieurs presentations en HTML?**

La performance dépend de la taille et de la complexite des presentations. Aspose.Slides est tres efficace et scalable pour les operations en lot. Pour obtenir des performances optimales lors de la conversion d'un grand nombre de presentations, il est recommande d'utiliser le multithreading ou le traitement parallel chaque fois que possible.

**Aspose.Slides prend-il en charge l'exportation des hyperliens vers HTML?**

Oui, Aspose.Slides prend pleinement en charge l'exportation des hyperliens incorporees vers HTML. Lorsque vous convertissez des presentations au format HTML, les hyperliens sont preserves automatiquement et restent cliquables.

**Existe-t-il une limite au nombre de diapositives lors de la conversion de presentations en HTML?**

Il n'existe aucune limite au nombre de diapositives lorsque vous utilisez Aspose.Slides. Vous pouvez convertir des presentations de toute taille. Cependant, pour des presentations contenant un nombre tres eleve de diapositives, la performance peut dépendre des ressources disponibles sur votre serveur ou systeme.