---
title: Convertir PowerPoint a HTML en C# .NET
linktitle: Convertir PowerPoint a HTML
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
keywords: "C# PowerPoint a HTML, C# PPT a HTML, C# ODP a HTML, C# Slide a HTML, Convertir presentación de PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, C#, Csharp, .NET, Aspose.Slides, exportación a HTML"
description: "Convertir PowerPoint a HTML: Guardar PPTX o PPT como HTML. Guardar diapositivas como HTML"
---

## **Descripción general**

Este artículo explica cómo convertir una presentación de PowerPoint en formato HTML utilizando C#. Cubre los siguientes temas.

- [Convertir PowerPoint a HTML en C#](#convertir-powerpoint-a-html)
- [Convertir PPT a HTML en C#](#convertir-powerpoint-a-html)
- [Convertir PPTX a HTML en C#](#convertir-powerpoint-a-html)
- [Convertir ODP a HTML en C#](#convertir-powerpoint-a-html)
- [Convertir diapositiva de PowerPoint a HTML en C#](#convertir-diapositiva-a-html)

## **C# PowerPoint a HTML**

Para ver un código de ejemplo en C# para convertir PowerPoint a HTML, consulte la sección a continuación, es decir, [Convertir PowerPoint a HTML](#convertir-powerpoint-a-html). El código puede cargar varios formatos como PPT, PPTX y ODP en un objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**
Utilizando [**Aspose.Slides para .NET**](https://products.aspose.com/slides/net/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación de PowerPoint completa a HTML.
* Convertir una diapositiva específica en una presentación de PowerPoint a HTML.
* Convertir medios de presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del orador incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML mientras se utiliza el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Utilizando su propia API, Aspose desarrolló conversores gratuitos [de presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Es posible que desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que involucran el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Utilizando Aspose.Slides, puede convertir toda una presentación de PowerPoint a HTML de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Utilizar el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el objeto como un archivo HTML.

Este código muestra cómo convertir un PowerPoint a HTML en C#:

```c#
// Instancia un objeto de presentación que representa un archivo de presentación, por ejemplo, PPT, PPTX, ODP, etc.
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Guarda la presentación como HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **Convertir PowerPoint a HTML responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) que le permite generar archivos HTML responsivos. Este código muestra cómo convertir una presentación de PowerPoint a HTML responsivo en C#:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Guarda la presentación como HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **Convertir PowerPoint a HTML con notas**
Este código muestra cómo convertir un PowerPoint a HTML con notas en C#:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Guarda páginas de notas
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **Convertir PowerPoint a HTML con fuentes originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) que le permite incrustar todas las fuentes en una presentación mientras convierte la presentación a HTML.

Para evitar que ciertas fuentes se incrusten, puede pasar una matriz de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Las fuentes populares, como Calibri o Arial, cuando se utilizan en una presentación, no tienen que ser incrustadas porque la mayoría de los sistemas ya contienen tales fuentes. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) admite la herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont), que está destinado a ser sobrescrito. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // Excluye fuentes predeterminadas de la presentación
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **Convertir PowerPoint a HTML con imágenes de alta calidad**

Por defecto, cuando convierte PowerPoint a HTML, Aspose.Slides genera un HTML pequeño con imágenes a 72 DPI y áreas recortadas eliminadas. Para obtener archivos HTML con imágenes de mayor calidad, debe establecer la propiedad `PicturesCompression` (de la clase `HtmlOptions`) en 96 (es decir, `PicturesCompression.Dpi96`) o valores [más altos](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Este código C# muestra cómo convertir una presentación de PowerPoint a HTML mientras se obtienen imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression.Dpi150`):

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

Este código en C# muestra cómo generar HTML con imágenes de calidad completa:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **Convertir diapositiva a HTML**
Para convertir una diapositiva específica en un PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (usada para convertir presentaciones completas a HTML) y luego usar el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) se puede utilizar para especificar opciones de conversión adicionales:

Este código C# muestra cómo convertir una diapositiva en una presentación de PowerPoint a HTML:

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Guarda el archivo              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **Guardar CSS e imágenes al exportar a HTML**
Utilizando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código C# en este ejemplo muestra cómo utilizar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Plantilla de encabezado personalizada
    const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";


    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- Fuentes incrustadas -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **Vincular todas las fuentes al convertir la presentación a HTML**

Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede vincular todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código C# muestra cómo convertir un PowerPoint a HTML vinculando todas las fuentes y excluyendo "Calibri" y "Arial" (ya que ya existen en el sistema): 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    //Excluye fuentes predeterminadas de la presentación
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

Este código C# muestra cómo se implementa `LinkAllFontsHtmlController`:

```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; //Puede ser necesario sanitizar la ruta

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

## **Convertir PowerPoint a HTML responsivo**
Este código C# muestra cómo convertir una presentación de PowerPoint a HTML responsivo:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Exportar archivos multimedia a HTML**
Utilizando Aspose.Slides para .NET, puede exportar archivos multimedia de esta manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtener una referencia a la diapositiva.
1. Agregar un video a la diapositiva.
1. Escribir la presentación como un archivo HTML.

Este código C# muestra cómo agregar un video a la presentación y luego guardarlo como HTML: 

```c#
// Carga una presentación
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Establece opciones HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Guarda el archivo
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```