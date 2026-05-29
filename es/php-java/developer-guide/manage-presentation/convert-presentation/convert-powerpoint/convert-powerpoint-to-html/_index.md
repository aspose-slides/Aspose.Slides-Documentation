---
title: Convertir presentaciones de PowerPoint a HTML en PHP
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/php-java/convert-powerpoint-to-html/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- guardar PowerPoint como HTML
- guardar presentación como HTML
- guardar diapositiva como HTML
- guardar PPT como HTML
- guardar PPTX como HTML
- exportar PPT a HTML
- exportar PPTX a HTML
- PHP
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML en PHP. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y contenidos multimedia."
---
## **Visión general**

Aspose.Slides for PHP via Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y una llamada `save` con [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, responsivo o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de la imagen y los datos recortados de la imagen.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML produce un documento HTML autónomo donde la mayoría de los recursos están incrustados. Esto resulta cómodo para compartir un solo archivo, pero puede aumentar el tamaño de salida. Para la publicación web, considere utilizar recursos externos, reducir la DPI de las imágenes y sólo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Este ejemplo escribe un archivo HTML. El objeto Presentation se elimina en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Las opciones comunes incluyen:

- `SlidesLayoutOptions`: agrega notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla la DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos recortados de la imagen.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran por separado las opciones más comunes para que pueda combinar únicamente las que necesita su flujo de trabajo.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `save` que acepta números de diapositiva utiliza posiciones basadas en 1. El bucle siguiente guarda cada diapositiva en un archivo HTML separado.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Utilice este patrón cuando un sitio web o aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) y pásela a cada llamada `save`.

## **Crear HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/php-java/aspose.slides/responsivehtmlcontroller/) proporciona salida HTML responsiva a través de [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Para un diseño responsivo basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Incluir notas del orador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.SlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación original contiene notas del orador:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la diapositiva.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

El HTML exportado incluye el área de notas:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si sólo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de la imagen y las áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Mantenga los datos recortados solo cuando los usuarios necesiten recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Añadir CSS**

Para un estilo sencillo, pase una cadena CSS a [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/) a través de `createDocumentFormatter`. Esto cambia el documento HTML circundante mientras Aspose.Slides continúa renderizando el contenido de la diapositiva.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Para un encabezado de documento personalizado, un archivo CSS enlazado o marcado personalizado alrededor de diapositivas y formas, utilice un controlador de formato personalizado y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste las fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/php-java/aspose.slides/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño de salida.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Excluya fuentes solo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Vincular archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de fuentes en archivos WOFF separados y añadir reglas `@font-face` al HTML. En PHP a través de Java, este escenario suele implementarse con una pequeña clase auxiliar Java que extiende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/php-java/aspose.slides/embedallfontshtmlcontroller/), escribe los bytes de la fuente en un directorio de salida y inyecta reglas `@font-face` en el HTML generado. Compile esa clase auxiliar, añádala al classpath del PHP Java Bridge y, a continuación, instánciela desde PHP con `new Java(...)`.

Al crear dicho asistente, elija deliberadamente dos rutas:

- La ruta de salida del sistema de archivos, donde se escriben los archivos de fuentes generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos de fuentes.

## **Guardar recursos externamente**

El HTML autónomo es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, proporcione un controlador de enlace/incrustación personalizado al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/).

Al externalizar recursos, elija deliberadamente dos rutas:

- La ruta de salida del sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o vídeo generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos.

Mantenga estas rutas coherentes con su distribución de implementación para que el HTML generado pueda cargar sus recursos externos después de moverlo a un servidor web o a otro directorio.

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/php-java/aspose.slides/videoplayerhtmlcontroller/) exporta archivos de vídeo y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio de salida utilizado por el HTML generado y los archivos multimedia.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto utilizado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html`, `path` debe apuntar a `html-output`, y `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para vista previa local, puede construir una URI `file:///` a partir del directorio de salida. Para una aplicación desplegada, utilice la URL absoluta del directorio de salida publicado.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden hacer que los archivos de distintas conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de las imágenes, las fuentes, los efectos, los diagramas y los medios incrustados. Valores más altos de DPI en `PicturesCompression`, fuentes incrustadas, salida SVG y áreas de imagen recortadas retenidas pueden mejorar la fidelidad pero normalmente aumentan el tamaño de salida.

Para la conversión por lotes:

- Libere rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
- Utilice directorios de salida separados para trabajos distintos.
- Evite incrustar fuentes comunes a menos que la fidelidad lo exija.
- Reduzca la DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación origen, el HTML generado y los recursos externos juntos hasta que las rutas de implementación sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) entre hilos. Procese archivos diferentes con instancias de presentación separadas, flujos separados y directorios de salida distintos.

**¿Es seguro utilizar el objeto Presentation en varios hilos?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) debe cargarse, modificarse, guardarse y liberarse en un solo hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación por defecto puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas de imagen recortadas retenidas también aumentan el tamaño. Utilice recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando un tamaño más pequeño sea más importante que la fidelidad máxima.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para vista previa local, puede derivarla del directorio de salida con una URI de archivo Java. Para implementación, use la URL absoluta del directorio de medios publicado. El `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación del recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides` en `true` en [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) cuando las diapositivas ocultas deban exportarse.