---
title: Convertir presentaciones de PowerPoint a HTML en Java
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML en Java. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Visión general**

Aspose.Slides for Java puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y llamar a `save` con [SaveFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, adaptable o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de la imagen y los datos recortados de la imagen.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML genera un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es conveniente para compartir un solo archivo, pero puede aumentar el tamaño del resultado. Para la publicación web, considere recursos externos, reducir el DPI de las imágenes y solo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Este ejemplo escribe un archivo HTML. El objeto Presentation se elimina en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes comunes incluyen:

- `SlidesLayoutOptions`: añade notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla el DPI de la imagen y el tamaño del resultado.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos recortados de la imagen.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando se requiera.

Las secciones siguientes muestran por separado las opciones más comunes para que pueda combinar solo las que su flujo de trabajo necesite.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `Presentation.save` que acepta números de diapositiva utiliza posiciones de diapositiva basadas en 1. El bucle siguiente guarda cada diapositiva en un archivo HTML separado.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Utilice este patrón cuando un sitio web o aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una instancia de [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/) y pásela a cada llamada `save`.

## **Crear HTML adaptable**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/java/com.aspose.slides/responsivehtmlcontroller/) proporciona salida HTML adaptable mediante [HtmlFormatter](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para un diseño adaptable basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Incluir notas del orador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.setSlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación origen contiene notas del orador:

![Diapositiva con notas del orador en PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador debajo de la diapositiva.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

La salida HTML incluye el área de notas:

![Salida HTML con la diapositiva y notas del orador](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si solo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño del resultado. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/java/com.aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Conserve los datos recortados solo cuando los usuarios necesiten recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Agregar CSS**

Para un estilo sencillo, pase una cadena CSS a `HtmlFormatter.createDocumentFormatter`. Esto modifica el documento HTML circundante mientras Aspose.Slides continúa renderizando el contenido de la diapositiva.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Para un encabezado de documento personalizado, un archivo CSS enlazado o un marcado personalizado alrededor de diapositivas y formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/es/java/com.aspose.slides/ihtmlformattingcontroller/) y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/java/com.aspose.slides/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño del resultado.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Excluya fuentes solo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Enlazar archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de fuentes en archivos WOFF separados y añadir reglas `@font-face` al HTML. El asistente a continuación extiende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/java/com.aspose.slides/embedallfontshtmlcontroller/) y sobrescribe `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

En este ejemplo, los archivos de fuentes se guardan en `html-output/fonts`, y el HTML los referencia con URLs como `fonts/BrandFont-normal-400.woff`. Si el archivo HTML y las fuentes se despliegan en otra ubicación, elija `fontUrlPrefix` de modo que coincida con la ruta URL desplegada.

## **Guardar recursos externamente**

El HTML autocontenido es fácil de mover, pero los recursos Base64 incrustados pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/es/java/com.aspose.slides/ilinkembedcontroller/) y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/).

Cuando externaliza recursos, elija dos rutas deliberadamente:

- La ruta de salida del sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o vídeo generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos.

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/java/com.aspose.slides/videoplayerhtmlcontroller/) exporta archivos de vídeo y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto usado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para una vista previa local, puede crear una URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden causar que los archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de las imágenes, fuentes, efectos, gráficos y medios incrustados. Valores DPI más altos de `PicturesCompression`, fuentes incrustadas, salida SVG y áreas recortadas de imágenes retenidas pueden mejorar la fidelidad pero normalmente aumentan el tamaño del resultado.

Para una conversión por lotes:

- Elimine rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
- Utilice directorios de salida separados para trabajos distintos.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca el DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación origen, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) entre hilos. Procese archivos diferentes con instancias de presentación separadas, flujos separados y directorios de salida separados. Consulte la guía de [multithreading](/slides/es/java/multithreading/) para más detalles.

**¿Es seguro usar un objeto Presentation en varios hilos?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) debe cargarse, modificarse, guardarse y eliminarse en un solo hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas recortadas de imágenes retenidas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando un resultado más pequeño sea más importante que la máxima fidelidad.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para vista previa local, puede derivarla del directorio de salida con `mediaDirectory.toUri().toString()`. Para despliegue, use la URL absoluta del directorio multimedia publicado. El `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación del recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides` a `true` en [HtmlOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/) cuando las diapositivas ocultas deban exportarse.