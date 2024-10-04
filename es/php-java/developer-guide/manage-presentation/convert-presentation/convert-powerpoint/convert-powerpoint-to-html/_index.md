---
title: Convertir PowerPoint a HTML
linktitle: Convertir PowerPoint a HTML
type: docs
weight: 30
url: /php-java/convert-powerpoint-to-html/
keywords: "PHP PowerPoint a HTML, Convertir presentación PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, Java, Aspose.Slides, exportación HTML"
description: "Convertir PowerPoint HTML: Guardar PPTX o PPT como HTML. Guardar diapositivas como HTML."
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato HTML usando PHP. Cubre los siguientes temas.

- Convertir PowerPoint a HTML
- Convertir PPT a HTML
- Convertir PPTX a HTML
- Convertir ODP a HTML
- Convertir diapositiva de PowerPoint a HTML

## **Java PowerPoint a HTML**

Para el código de muestra de Java para convertir PowerPoint a HTML, consulte la sección a continuación es decir, [Convertir PowerPoint a HTML](#convertir-powerpoint-a-html). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentación y guardarlo en formato HTML.

## **Sobre la conversión de PowerPoint a HTML**
Usando [**Aspose.Slides para PHP a través de Java**](https://products.aspose.com/slides/php-java/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**.

**Aspose.Slides** ofrece muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación de PowerPoint completa a HTML.
* Convertir una diapositiva específica en una presentación de PowerPoint a HTML.
* Convertir medios de presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del orador incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML mientras se usa el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló convertidores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Es posible que desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que implican el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}

## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación de PowerPoint completa a HTML de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Usar el método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para guardar el objeto como un archivo HTML.

Este código le muestra cómo convertir un PowerPoint a HTML:

```php
// Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # Guardar la presentación en HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint a HTML responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) que le permite generar archivos HTML responsivos. Este código le muestra cómo convertir una presentación de PowerPoint a HTML responsivo:

```php
// Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Guardar la presentación en HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint a HTML con notas**
Este código le muestra cómo convertir un PowerPoint a HTML con notas:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Guardar páginas de notas
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint a HTML con fuentes originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) que le permite incrustar todas las fuentes en una presentación mientras convierte la presentación a HTML.

Para evitar que ciertas fuentes sean incrustadas, puede pasar un array de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController). Las fuentes populares, como Calibri o Arial, cuando se utilizan en una presentación, no es necesario que sean incrustadas porque la mayoría de los sistemas ya contienen tales fuentes. Cuando se incrustan esas fuentes, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) admite herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) que está destinado a ser sobrescrito.

```php
  $pres = new Presentation("input.pptx");
  try {
    # excluir fuentes predeterminadas de presentación
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

## **Convertir PowerPoint a HTML con imágenes de alta calidad**

Por defecto, cuando convierte PowerPoint a HTML, Aspose.Slides genera HTML pequeño con imágenes a 72 DPI y áreas recortadas eliminadas. Para obtener archivos HTML con imágenes de mayor calidad, debe configurar la propiedad `PicturesCompression` (de la clase `HtmlOptions`) a 96 (es decir, `PicturesCompression.Dpi96`) o valores [más altos](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression).

Este código PHP le muestra cómo convertir una presentación de PowerPoint a HTML mientras obtiene imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression.Dpi150`):

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

Este código le muestra cómo generar HTML con imágenes de calidad completa:

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

## **Convertir diapositiva a HTML**
Para convertir una diapositiva específica en un PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) (usada para convertir presentaciones completas a HTML) y luego usar el método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) puede ser utilizada para especificar opciones de conversión adicionales:

Este código PHP le muestra cómo convertir una diapositiva en una presentación de PowerPoint a HTML:

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
    # Guardando el archivo
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Guardar CSS e imágenes al exportar a HTML**
Usando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código PHP en este ejemplo le muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Plantilla de encabezado personalizada
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
        $generator->addHtml("<!-- Fuentes incrustadas -->");
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

## **Vincular todas las fuentes al convertir la presentación a HTML**

Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede vincular todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código PHP le muestra cómo convertir un PowerPoint a HTML mientras vincula todas las fuentes y excluye "Calibri" y "Arial" (ya que ya existen en el sistema):

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
            $path = $fontName . ".woff"; // puede necesitar sanitización de ruta
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
    # Excluir fuentes predeterminadas de presentación
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

## **Convertir PowerPoint a HTML responsivo**
Este código PHP le muestra cómo convertir una presentación de PowerPoint a HTML responsivo:

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

## **Exportar archivos multimedia a HTML**
Usando Aspose.Slides para PHP a través de Java, puede exportar archivos multimedia de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtener una referencia a la diapositiva.
1. Agregar un video a la diapositiva.
1. Escribir la presentación como un archivo HTML.

Este código PHP le muestra cómo agregar un video a la presentación y luego guardarlo como HTML:

```php
// Cargando una presentación
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
    # Configuración de opciones HTML
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # Guardar el archivo
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```