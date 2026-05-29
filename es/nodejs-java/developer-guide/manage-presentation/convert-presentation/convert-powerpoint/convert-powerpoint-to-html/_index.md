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
description: "Convertir presentaciones de PowerPoint a HTML en Node.js. Utilice Aspose.Slides para Node.js mediante Java para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Visión general**

Aspose.Slides para Node.js mediante Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y una llamada `save` con [SaveFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, receptivo o basado en SVG.
- Incluir notas del presentador y comentarios.
- Controlar la calidad de la imagen y los datos de imagen recortados.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML genera un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es conveniente para compartir un solo archivo, pero puede aumentar el tamaño del resultado. Para la publicación web, considere recursos externos, reducir DPI de la imagen y sólo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

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

Este ejemplo escribe un archivo HTML. El objeto Presentation se elimina en el bloque `finally`, lo que libera los manejadores de archivos y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes comunes incluyen:

- `SlidesLayoutOptions`: añade notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla el DPI de la imagen y el tamaño del resultado.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos de imagen recortados.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las siguientes secciones muestran las opciones más comunes por separado para que pueda combinar sólo las que su flujo de trabajo necesita.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `Presentation.save` que acepta números de diapositiva utiliza posiciones basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

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

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/responsivehtmlcontroller/) proporciona salida HTML responsiva a través de [HtmlFormatter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

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

## **Incluir notas del presentador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.setSlidesLayoutOptions` para incluir notas del presentador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación origen contiene notas del presentador:

![Diapositiva con notas del presentador en PowerPoint](slide_with_notes.png)

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

El siguiente código exporta el contenido de la diapositiva con notas del presentador debajo de la misma.

El HTML exportado incluye el área de notas:

![Salida HTML con la diapositiva y notas del presentador](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si sólo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de la imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño del resultado. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Conserve los datos recortados sólo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Añadir CSS**

Para un estilo simple, pase una cadena CSS a `HtmlFormatter.createDocumentFormatter`. Esto modifica el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para un encabezado de documento personalizado, un archivo CSS enlazado o un marcado personalizado alrededor de diapositivas y formas, use [HtmlFormatter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmlformatter/) con un controlador de formato.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Incrustar mejora la fidelidad visual pero aumenta el tamaño del resultado.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Excluya fuentes sólo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Vincular archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de las fuentes en archivos WOFF separados y añadir reglas `@font-face` al HTML. En Node.js mediante Java, este escenario suele implementarse con una pequeña clase auxiliar Java que extiende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), escribe los bytes de la fuente en un directorio de salida y inyecta reglas `@font-face` en el HTML generado. Compile esa ayuda, añádala al classpath del módulo Node.js y luego instánciela desde JavaScript con `java.newInstanceSync`.

Al crear dicha ayuda, elija dos rutas deliberadamente:

- La ruta de salida del sistema de archivos, donde se escriben los archivos de fuentes generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos de fuentes.

## **Guardar recursos externamente**

El HTML autocontenido es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos externos de imagen, fuente, audio o video, use un controlador de exportación que escriba los recursos en un directorio elegido y genere URLs visibles para el navegador. Mantenga la ruta del sistema de archivos y la ruta URL alineadas con el diseño de su despliegue.

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exporta archivos de video y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto usado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para una vista previa local, puede crear una URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden hacer que los archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de la imagen, fuentes, efectos, gráficos y medios incrustados. Valores de DPI de `PicturesCompression` más altos, fuentes incrustadas, salida SVG y áreas recortadas de imagen conservadas pueden mejorar la fidelidad pero normalmente aumentan el tamaño del resultado.

Para conversión por lotes:

- Elimine rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
- Utilice directorios de salida separados para trabajos separados.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca el DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación origen, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y permanecen clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una única instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) entre los workers. Procese diferentes archivos con instancias de presentación separadas, flujos separados y directorios de salida separados. Consulte la [multithreading guidance](/slides/es/nodejs-java/multithreading/) para obtener detalles.

**¿Es seguro para subprocesos el objeto Presentation?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) debe cargarse, modificarse, guardarse y eliminarse en un solo worker. Para trabajo en paralelo, cree una instancia independiente por worker o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación por defecto puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas de imagen recortadas conservadas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando un archivo más pequeño sea más importante que la máxima fidelidad.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para una vista previa local, puede derivarla del directorio de salida con una URI `file:///`. Para el despliegue, use la URL absoluta del directorio multimedia publicado. La `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación del recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides` a `true` en [HtmlOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/) cuando sea necesario exportar diapositivas ocultas.