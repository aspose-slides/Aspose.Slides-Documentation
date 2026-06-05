---
title: Convertir presentaciones de PowerPoint a HTML en Node.js
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML en Node.js. Utilice Aspose.Slides para Node.js a través de Java para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y contenido multimedia."
---
## **Visión general**

Aspose.Slides for Node.js via Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y realizar una llamada `save` con [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, las fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, responsivo o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de imagen y los datos de imágenes recortadas.
- Incorporar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML produce un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es cómodo para compartir un único archivo, pero puede aumentar el tamaño de salida. Para publicación web, considere recursos externos, reducir la DPI de las imágenes y sólo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Este ejemplo escribe un único archivo HTML. El objeto Presentation se elimina en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Utilizar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes comunes incluyen:

- `SlidesLayoutOptions`: agrega notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: modifica cómo se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla la DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos de imágenes recortadas.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran las opciones más habituales por separado para que pueda combinar solo las que su flujo de trabajo necesite.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `Presentation.save` que acepta números de diapositiva usa posiciones basadas en 1. El bucle siguiente guarda cada diapositiva en un archivo HTML independiente.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Utilice este patrón cuando un sitio web o una aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) y pásela a cada llamada `save`.

## **Crear HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/responsivehtmlcontroller/) ofrece salida HTML responsiva mediante [HtmlFormatter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para un diseño responsivo basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Incluir notas del orador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.setSlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos de forma predeterminada a menos que se elijan sus posiciones.

Suponga que la presentación original contiene notas del orador:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la misma.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

El HTML exportado incluye el área de notas:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si solo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, configure ambas propiedades.

## **Controlar la calidad de imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

{{c61ceb5a-1250