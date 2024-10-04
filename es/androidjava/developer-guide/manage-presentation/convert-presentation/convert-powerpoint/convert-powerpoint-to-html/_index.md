---
title: Convertir PowerPoint a HTML en Java
linktitle: Convertir PowerPoint a HTML
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint a HTML, Convertir presentación de PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, Java, Aspose.Slides, exportación a HTML"
description: "Convertir PowerPoint a HTML en Java: Guardar PPTX o PPT como HTML en Java. Guardar diapositivas como HTML en Java"
---

## **Descripción General**

Este artículo explica cómo convertir una presentación de PowerPoint en formato HTML usando Java. Cubre los siguientes temas.

- Convertir PowerPoint a HTML en Java
- Convertir PPT a HTML en Java
- Convertir PPTX a HTML en Java
- Convertir ODP a HTML en Java
- Convertir diapositiva de PowerPoint a HTML en Java

## **Java PowerPoint a HTML**

Para ver el código de ejemplo en Java para convertir PowerPoint a HTML, consulte la sección a continuación es decir, [Convertir PowerPoint a HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en un objeto presentación y guardarlo en formato HTML.

## **Acerca de la Conversión de PowerPoint a HTML**
Usando [**Aspose.Slides para Android a través de Java**](https://products.aspose.com/slides/androidjava/), las aplicaciones y desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**.

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación completa de PowerPoint a HTML.
* Convertir una diapositiva específica en una presentación de PowerPoint a HTML.
* Convertir medios de presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del orador incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML mientras se utiliza el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló convertidores gratuitos [de presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Quizás desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que involucran el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}

## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Usar el método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para guardar el objeto como un archivo HTML.

Este código le muestra cómo convertir un PowerPoint a HTML en Java:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Guardar la presentación en HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a HTML Responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) que le permite generar archivos HTML responsivos. Este código le muestra cómo convertir una presentación de PowerPoint a HTML responsivo en Java:

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Guardar la presentación en HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a HTML con Notas**
Este código le muestra cómo convertir un PowerPoint a HTML con notas en Java:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Guardar páginas de notas
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a HTML con Fuentes Originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) que le permite incrustar todas las fuentes en una presentación al convertir la presentación a HTML.

Para evitar que se incrusten ciertas fuentes, puede pasar un arreglo de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). Fuentes populares, como Calibri o Arial, cuando se utilizan en una presentación, no tienen que ser incrustadas porque la mayoría de los sistemas ya contienen tales fuentes. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) soporta herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) que está destinado a ser sobrescrito.

```java
Presentation pres = new Presentation("input.pptx");
try {
    // excluir fuentes de presentación predeterminadas
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a HTML con Imágenes de Alta Calidad**

Por defecto, cuando convierte PowerPoint a HTML, Aspose.Slides genera HTML pequeño con imágenes a 72 DPI y elimina áreas recortadas. Para obtener archivos HTML con imágenes de mayor calidad, debe configurar la propiedad `PicturesCompression` (de la clase `HtmlOptions`) en 96 (es decir, `PicturesCompression.Dpi96`) o en [valores](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression) superiores.

Este código Java le muestra cómo convertir una presentación de PowerPoint a HTML mientras obtiene imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression.Dpi150`):

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

Este código en Java le muestra cómo generar HTML con imágenes de calidad completa:

```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir Diapositiva a HTML**
Para convertir una diapositiva específica en un PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (utilizada para convertir presentaciones completas a HTML) y luego usar el método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) se puede utilizar para especificar opciones de conversión adicionales:

Este código Java le muestra cómo convertir una diapositiva en una presentación de PowerPoint a HTML:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Guardar archivo
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Diapositiva Individual" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```

## **Guardar CSS e Imágenes al Exportar a HTML**
Usando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código Java en este ejemplo le muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Plantilla de encabezado personalizado
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
        generator.addHtml("<!-- Fuentes incrustadas -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Vincular Todas las Fuentes al Convertir Presentación a HTML**

Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede vincular todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código Java le muestra cómo convertir un PowerPoint a HTML mientras vincula todas las fuentes y excluye "Calibri" y "Arial" (ya que ya existen en el sistema): 

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //Excluir fuentes de presentación predeterminadas
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```

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
            String path = fontName + ".woff"; // puede ser necesaria alguna sanitización de ruta
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

## **Convertir PowerPoint a HTML Responsivo**
Este código Java le muestra cómo convertir una presentación de PowerPoint a HTML responsivo:

```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exportar Archivos Multimedia a HTML**
Usando Aspose.Slides para Android a través de Java, puede exportar archivos multimedia de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener una referencia a la diapositiva.
1. Agregar un video a la diapositiva.
1. Escribir la presentación como un archivo HTML.

Este código Java le muestra cómo agregar un video a la presentación y luego guardarlo como HTML: 

```java
// Cargando una presentación
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Configurando opciones HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // Guardando el archivo
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```