---
title: Convertir presentaciones PowerPoint a HTML en Android
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Convertir presentaciones PowerPoint a HTML en Android. Utilice Aspose.Slides para Android a través de Java para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Visión general**

Aspose.Slides for Android a través de Java puede guardar presentaciones PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y realizar una llamada `save` con [SaveFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, responsivo o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de la imagen y los datos de imágenes recortadas.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación HTML produce un documento HTML autónomo donde la mayoría de los recursos están incrustados. Esto resulta cómodo para compartir un solo archivo, pero puede aumentar el tamaño de salida. Para publicación web, considere recursos externos, reducir el DPI de las imágenes y solo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y guárdala con [SaveFormat.Html](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Este ejemplo escribe un archivo HTML. El objeto de presentación se dispone en el bloque `finally`, lo que libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/) es la clase principal de configuración para la exportación HTML. Configuraciones comunes incluyen:

- `SlidesLayoutOptions`: agrega notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formateo a un controlador.
- `SlideImageFormat`: modifica cómo se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla el DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos de imágenes recortadas.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran las opciones más comunes por separado para que pueda combinar solo las que su flujo de trabajo necesite.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga `Presentation.save` que acepta números de diapositiva utiliza posiciones basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

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

Utilice este patrón cuando un sitio web o una aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/) y pásela a cada llamada `save`.

## **Crear HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/responsivehtmlcontroller/) proporciona salida HTML responsiva a través de [HtmlFormatter](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

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

Para un diseño responsivo basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

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

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/notescommentslayoutingoptions/) a través de `HtmlOptions.SlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación fuente contiene notas del orador:

![Diapositiva con notas del orador en PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del orador bajo la diapositiva.

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

El HTML exportado incluye el área de notas:

![Salida HTML con la diapositiva y notas del orador](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si solo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de la imagen y áreas recortadas**

La exportación HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/picturescompression/) cuando necesite mayor calidad de imagen.

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

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Conserve los datos recortados solo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

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

## **Añadir CSS**

Para un estilo sencillo, pase una cadena CSS a `HtmlFormatter.createDocumentFormatter`. Esto modifica el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

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

Para un encabezado de documento personalizado, un archivo CSS enlazado o un marcado personalizado alrededor de diapositivas y formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihtmlformattingcontroller/) y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmlformatter/) con `createCustomFormatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño de salida.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Excluya fuentes solo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes poco comunes, la incrustación suele ser más segura.

## **Vincular archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de fuentes en archivos WOFF separados y añadir reglas `@font-face` al HTML. El asistente a continuación amplía [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) y sobrescribe `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

En este ejemplo, los archivos de fuentes se guardan en `html-output/fonts`, y el HTML los referencia con URL como `fonts/BrandFont-normal-400.woff`. Si el archivo HTML y las fuentes se despliegan en otra ubicación, elija `fontUrlPrefix` de modo que coincida con la ruta URL publicada.

## **Guardar recursos externamente**

El HTML autónomo es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ilinkembedcontroller/) y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/).

Al externalizar recursos, elija dos rutas de forma deliberada:

- La ruta de salida del sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o vídeo generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos.

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exporta archivos de vídeo y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto usado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para vista previa local, puede crear una URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden hacer que archivos de distintas conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de imágenes, fuentes, efectos, gráficos y medios incrustados. Valores superiores de DPI en `PicturesCompression`, fuentes incrustadas, salida SVG y áreas de imagen recortadas retenidas pueden mejorar la fidelidad pero generalmente aumentan el tamaño de salida.

Para conversiones por lotes:

- Disponga rápidamente cada instancia de [Presentation].
- Use directorios de salida separados para trabajos distintos.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca el DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación fuente, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation] entre hilos. Procese diferentes archivos con instancias de presentación distintas, flujos separados y directorios de salida diferentes. Consulte la guía de [multithreading guidance](/slides/es/androidjava/multithreading/) para más detalles.

**¿Es thread‑safe un objeto Presentation?**

No. Una sola instancia de [Presentation] debe cargarse, modificarse, guardarse y disponerse en un único hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alto DPI, medios, contenido SVG y áreas de imagen recortadas retenidas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando sea más importante un archivo pequeño que la máxima fidelidad.

**¿Cómo debería elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para vista previa local, puede derivarla del directorio de salida con `mediaDirectory.toUri().toString()`. Para despliegue, use la URL absoluta del directorio multimedia publicado. La ruta del sistema de archivos `path` y la `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación de recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides` en `true` en [HtmlOptions] cuando sea necesario exportar diapositivas ocultas.