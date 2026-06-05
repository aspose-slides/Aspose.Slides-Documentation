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
description: "Convertir presentaciones de PowerPoint a HTML en PHP. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Visión general**

Aspose.Slides for PHP via Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentación](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y realizar una llamada a `save` con [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos enlazados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar toda la presentación o diapositivas seleccionadas.
- Generar HTML de diseño fijo, responsivo o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de las imágenes y los datos de las áreas recortadas.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML produce un documento HTML autocontenible donde la mayoría de los recursos están incrustados. Esto es cómodo para compartir un solo archivo, pero puede aumentar el tamaño de salida. Para publicación web, considere recursos externos, reducir la DPI de las imágenes y sólo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentación](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Este ejemplo escribe un único archivo HTML. El objeto de presentación se elimina en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Las opciones más comunes incluyen:

- `SlidesLayoutOptions`: añade notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: modifica la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla la DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos de imágenes recortadas.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran las opciones más habituales por separado para que pueda combinar sólo aquellas que necesita en su flujo de trabajo.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `save` que acepta números de diapositiva usa posiciones basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML independiente.

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

Utilice este patrón cuando un sitio web o una aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmloptions/) y pásela a cada llamada `save`.

## **Crear HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/php-java/aspose.slides/responsivehtmlcontroller/) proporciona salida HTML responsiva mediante [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

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

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.SlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos de forma predeterminada a menos que elija sus posiciones.

Supongamos que la presentación fuente contiene notas del orador:

![Diapositiva con notas del orador en PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la misma.

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

![Salida HTML con la diapositiva y notas del orador](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si sólo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de la imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturescompression/) cuando necesite una mayor calidad de imagen.

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

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del contenido exportado. Conserve los datos recortados sólo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

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

Para un estilo sencillo, pase una cadena CSS a [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/) mediante `createDocumentFormatter`. Esto modifica el documento HTML circundante mientras Aspose.Slides continúa renderizando el contenido de la diapositiva.

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

Para un encabezado de documento personalizado, un archivo CSS enlazado o un marcado personalizado alrededor de diapositivas y formas, utilice un controlador de formato personalizado y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/php-java/aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste las fuentes en