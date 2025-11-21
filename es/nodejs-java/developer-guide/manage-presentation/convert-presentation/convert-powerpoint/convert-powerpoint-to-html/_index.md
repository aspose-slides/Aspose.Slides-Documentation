---
title: Convertir PowerPoint a HTML en JavaScript
linktitle: Convertir Powerpoint a HTML
type: docs
weight: 30
url: /es/nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint a HTML, Convertir presentación de PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, Java, Aspose.Slides, exportación HTML"
description: "Convertir PowerPoint a HTML en JavaScript. Guardar PPTX o PPT como HTML en JavaScript. Guardar diapositivas como HTML en JavaScript"
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint al formato HTML usando JavaScript. Cubre los siguientes temas.

- Convertir PowerPoint a HTML en JavaScript
- Convertir PPT a HTML en JavaScript
- Convertir PPTX a HTML en JavaScript
- Convertir ODP a HTML en JavaScript
- Convertir diapositiva de PowerPoint a HTML en JavaScript

## **Java PowerPoint a HTML**

Para obtener código de muestra en JavaScript que convierta PowerPoint a HTML, consulte la sección a continuación, es decir, [Convert PowerPoint to HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**

Usando [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**.

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación completa de PowerPoint a HTML.
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.
* Convertir los medios de la presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo.
* Convertir una presentación de PowerPoint a HTML con notas del presentador incluidas o excluidas.
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos.
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas.
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS.

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló convertidores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Es posible que desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que implican el formato HTML:

* [HTML a imagen](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}

## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Utilizar el método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) para guardar el objeto como un archivo HTML.

Este código le muestra cómo convertir un PowerPoint a HTML en JavaScript:
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // Guardar la presentación en HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a HTML responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) que permite generar archivos HTML responsivos. Este código le muestra cómo convertir una presentación de PowerPoint a HTML responsivo en JavaScript:
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // Guardando la presentación en HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a HTML con notas**
Este código le muestra cómo convertir un PowerPoint a HTML con notas en JavaScript:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Guardando páginas de notas
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a HTML con fuentes originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) que permite incrustar todas las fuentes de una presentación al convertirla a HTML.

Para evitar que se incrusten ciertas fuentes, puede pasar una matriz de nombres de fuente a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController). Fuentes populares, como Calibri o Arial, cuando se usan en una presentación, no necesitan ser incrustadas porque la mayoría de los sistemas ya las contienen. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) soporta herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) , que está destinado a sobrescribirse.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // excluir fuentes predeterminadas de la presentación
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir PowerPoint a HTML con imágenes de alta calidad**

Por defecto, cuando convierte PowerPoint a HTML, Aspose.Slides genera HTML pequeño con imágenes a 72 DPI y áreas recortadas eliminadas. Para obtener archivos HTML con imágenes de mayor calidad, debe pasar `96` al método `setPicturesCompression` de la clase `HtmlOptions` (es decir, `PicturesCompression.Dpi96`) o valores más altos [values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

Este código JavaScript le muestra cómo convertir una presentación de PowerPoint a HTML obteniendo imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression.Dpi150`):
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Este código en JavaScript le muestra cómo generar HTML con imágenes de calidad completa:
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convertir diapositiva a HTML**
Para convertir una diapositiva específica de un PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) (utilizada para convertir presentaciones completas a HTML) y luego usar el método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) puede usarse para especificar opciones de conversión adicionales:

```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // Guardando archivo
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Guardar CSS e Imágenes al exportar a HTML**
Usando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML.

El código JavaScript en este ejemplo le muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Deberá implementar CustomHeaderAndFontsController en Java, compilarlo y añadirlo a la ubicación del módulo \aspose.slides.via.java\lib\.
Este código Java le muestra cómo se implementa `CustomHeaderAndFontsController`:
```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Plantilla de encabezado personalizada
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **Vincular todas las fuentes al convertir la presentación a HTML**

Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede vincular todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`.

Este código JavaScript le muestra cómo convertir un PowerPoint a HTML vinculando todas las fuentes y excluyendo "Calibri" y "Arial" (ya que ya existen en el sistema):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Excluir fuentes predeterminadas de la presentación
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Deberá implementar LinkAllFontsHtmlController en Java, compilarlo y añadirlo a la ubicación del módulo \aspose.slides.via.java\lib\.
Este código Java le muestra cómo se implementa `LinkAllFontsHtmlController`:
```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // es posible que sea necesario sanitizar la ruta
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```


## **Convertir PowerPoint a HTML responsivo**
Este código JavaScript le muestra cómo convertir una presentación de PowerPoint a HTML responsivo:
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exportar archivos multimedia a HTML**
Usando Aspose.Slides for Node.js via Java, puede exportar archivos multimedia de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. Obtener una referencia a la diapositiva.
3. Agregar un video a la diapositiva.
4. Escribir la presentación como un archivo HTML.

Este código JavaScript le muestra cómo agregar un video a la presentación y luego guardarla como HTML:
```javascript
// Cargando una presentación
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // Configurando opciones HTML
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // Guardando el archivo
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Cuál es el rendimiento de Aspose.Slides al convertir múltiples presentaciones a HTML?**

El rendimiento depende del tamaño y la complejidad de las presentaciones. Aspose.Slides es altamente eficiente y escalable para operaciones por lotes. Para obtener un rendimiento óptimo al convertir muchas presentaciones, se recomienda usar multihilo o procesamiento paralelo siempre que sea posible.

**¿Aspose.Slides admite la exportación de hipervínculos a HTML?**

Sí, Aspose.Slides admite completamente la exportación de hipervínculos incrustados a HTML. Cuando convierte presentaciones al formato HTML, los hipervínculos se conservan automáticamente y siguen siendo clicables.

**¿Existe algún límite en el número de diapositivas al convertir presentaciones a HTML?**

No hay límite en el número de diapositivas al usar Aspose.Slides. Puede convertir presentaciones de cualquier tamaño. Sin embargo, para presentaciones que contengan un número muy grande de diapositivas, el rendimiento puede depender de los recursos disponibles en su servidor o sistema.