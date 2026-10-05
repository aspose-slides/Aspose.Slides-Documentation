---
title: Convertir presentaciones a HTML5 en PHP
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/php-java/export-to-html5/
keywords:
- PowerPoint a HTML5
- OpenDocument a HTML5
- presentación a HTML5
- diapositiva a HTML5
- PPT a HTML5
- PPTX a HTML5
- ODP a HTML5
- guardar PPT como HTML5
- guardar PPTX como HTML5
- guardar ODP como HTML5
- exportar PPT a HTML5
- exportar PPTX a HTML5
- exportar ODP a HTML5
- PHP
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 adaptable con Aspose.Slides para PHP a través de Java. Conservar el formato, las animaciones y la interactividad."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 usando Aspose.Slides para PHP a través de Java. Cubre la exportación básica, el control de animaciones de formas y transiciones de diapositivas, y la disposición de comentarios. También compara la salida HTML5 con la salida basada en SVG de la exportación HTML estándar.

## **Exportar PowerPoint a HTML5**

El siguiente ejemplo carga una presentación desde el directorio de trabajo y la guarda en formato HTML5. Utiliza la configuración de exportación predeterminada; el siguiente ejemplo muestra cómo controlar la reproducción de animaciones de forma explícita. Reemplace la ruta de entrada con la ruta a su presentación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Además del documento HTML, la exportación escribe archivos CSS y JavaScript de soporte para el estilo de diapositivas, animaciones, efectos y navegación. Mantenga estos archivos junto al documento HTML al mover o publicar la salida. La página generada también carga jQuery y Anime.js desde CDNs públicos; sin ellos, la navegación de diapositivas y las animaciones no se ejecutan.
{{% /alert %}}

Para exportar sin reproducir animaciones de formas ni transiciones de diapositivas, pase `false` a [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) y [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) en [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Estas configuraciones son independientes, por lo que puede habilitar una mientras deshabilita la otra. El ejemplo exporta la presentación con ambos tipos de animación desactivados en la página generada.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Exportar PowerPoint a HTML**

La exportación HTML estándar utiliza un enfoque de renderizado diferente: el contenido de la diapositiva se representa mediante SVG dentro de una página HTML. El siguiente ejemplo convierte una presentación a un documento HTML usando este enfoque de renderizado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

El marcado simplificado a continuación ilustra la estructura de la página generada. El elemento SVG contiene el contenido de la diapositiva renderizado; el texto de marcador de posición representa ese contenido y no es la salida literal de la exportación.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
La exportación basada en SVG no expone las formas de PowerPoint como elementos HTML individuales. Utilice la exportación HTML5 cuando necesite las opciones de animación de formas y transición de diapositivas demostradas en este artículo.
{{% /alert %}}

## **Exportar PowerPoint a vista de diapositivas HTML5**

La exportación HTML5 genera una página para ver y navegar por las diapositivas de la presentación en un navegador. Este ejemplo habilita tanto [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) como [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) para que la vista de diapositivas exportada pueda reproducir los efectos de la presentación original.

Utilice una presentación que ya contenga animaciones de formas y transiciones de diapositivas para ver el efecto de estas configuraciones. Habilitarlas no agrega nuevos efectos a las diapositivas que no los tengan. Después de la exportación, abra el documento HTML5 generado en un navegador con sus archivos de soporte disponibles.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Puede incluir los comentarios de diapositiva existentes en la salida HTML5 para que los lectores vean la retroalimentación junto al contenido de la diapositiva. El ejemplo en esta sección espera que la presentación origen contenga comentarios, como se muestra a continuación. Exporta esos comentarios; no crea nuevos.

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Pasar un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) al método [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) de [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Use [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) para seleccionar `Right` de la enumeración [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) y colocar los comentarios a la derecha de cada diapositiva.

El siguiente ejemplo exporta la presentación a HTML5 con este diseño de comentarios. Una presentación sin comentarios no tendrá texto de comentario para mostrar.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)

## **Excluir hipervínculos JavaScript durante la exportación**

Suponga que `hyperlinks.pptx` contiene texto enlazado con un objetivo `javascript:alert('Hello')` y un enlace ordinario `https://example.com/`. Para excluir el hipervínculo JavaScript durante la exportación, pase `true` a [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). El valor predeterminado es `false`, por lo que estos enlaces no se filtran a menos que habilite la opción.

El siguiente ejemplo carga la presentación desde el directorio de trabajo y la exporta usando [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

El archivo exportado omite el hipervínculo JavaScript manteniendo su texto y el enlace HTTPS ordinario. La presentación original no se modifica.

Esta opción filtra los hipervínculos JavaScript; no elimina todos los scripts ni otro contenido activo, ni garantiza el cumplimiento de CSP. Por ejemplo, la salida HTML5 sigue incluyendo scripts para la navegación y animaciones de diapositivas.

## **Preguntas frecuentes**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducirán en HTML5?**

Sí, la exportación HTML5 proporciona opciones separadas para habilitar o deshabilitar las [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) y las [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**¿Se admiten los comentarios y dónde pueden situarse respecto a la diapositiva?**

Sí, los comentarios existentes pueden incluirse en la salida HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) a través de las [configuraciones de diseño](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) para notas y comentarios.

**¿Puedo omitir los enlaces que invocan JavaScript por razones de seguridad o CSP?**

Sí, la configuración [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) permite omitir los hipervínculos con llamadas a JavaScript durante el guardado. El valor predeterminado es `false`. Consulte [Excluir hipervínculos JavaScript durante la exportación](/slides/es/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) para un ejemplo de exportación HTML5 y el alcance del filtro. Esta configuración no elimina el JavaScript utilizado por el visor HTML5 para la navegación y las animaciones.