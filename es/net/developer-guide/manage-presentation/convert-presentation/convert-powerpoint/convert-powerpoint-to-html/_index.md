---
title: Convertir presentaciones de PowerPoint a HTML en .NET
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML responsivo en .NET. Preservar el diseño, los enlaces y las imágenes con la guía de conversión de Aspose.Slides para obtener resultados rápidos y sin errores."
---

## **Visión general**

Mejore su flujo de trabajo convirtiendo presentaciones de PowerPoint y OpenDocument a HTML con Aspose.Slides para .NET. Esta guía ofrece instrucciones detalladas, ejemplos de código robustos y métodos probados para garantizar un proceso de conversión fiable y eficiente, optimizado para la visualización web.

Aspose.Slides ofrece muchas opciones —principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)— que definen el proceso de conversión de formato PowerPoint (o OpenDocument) a HTML:

* Convertir una presentación completa de PowerPoint a HTML.  
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.  
* Convertir los medios de la presentación (imágenes, videos, etc.) a HTML.  
* Convertir una presentación de PowerPoint a HTML responsivo.  
* Convertir una presentación de PowerPoint a HTML con notas del orador incluidas o excluidas.  
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos.  
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas.  
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS.  

## **Convertir una presentación a HTML**

Con Aspose.Slides, puede convertir una presentación completa de PowerPoint o OpenDocument a HTML de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Utilizar el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el objeto como un archivo HTML.  

Este código muestra cómo convertir una presentación de PowerPoint a HTML en C#:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación (p.ej., PPT, PPTX, ODP, etc.).
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Guardar la presentación como HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **Convertir una presentación a HTML responsivo**

Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) que permite generar archivos HTML responsivos. Este código demuestra cómo convertir una presentación de PowerPoint a HTML responsivo en C#:
```c#
// Instanciar la clase Presentation que representa un archivo de presentación.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();

    HtmlOptions htmlOptions = new HtmlOptions 
    { 
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
    };

    // Guardar la presentación como HTML.
    presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir una presentación a HTML con notas del orador**

Al convertir una presentación de PowerPoint o OpenDocument a HTML con notas del orador, es esencial capturar la esencia completa del documento original. Este proceso garantiza que no solo se representen con precisión los elementos visuales de las diapositivas, sino que también se conserven las notas del orador, enriqueciendo el contenido con contexto e información adicional.

Supongamos que tenemos una presentación de PowerPoint con la siguiente diapositiva:

![A presentation slide with speaker notes](slide_with_notes.png)

Este código muestra cómo convertir una presentación de PowerPoint a HTML con notas del orador en C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Establecer opciones para las notas del orador.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Establecer opciones para el documento HTML de salida.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // Guardar la presentación como HTML con notas del orador.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


El resultado:

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **Convertir una presentación a HTML con fuentes originales**

Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) que permite incrustar todas las fuentes de una presentación al convertirla a HTML.

Para evitar que ciertas fuentes se incrusten, puede pasar una matriz de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Fuentes populares, como Calibri o Arial, no necesitan incrustarse porque la mayoría de los sistemas ya las incluyen. Incrustarlas aumentaría innecesariamente el tamaño del documento HTML resultante.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) admite herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont), que está destinado a ser sobrescrito.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Excluir las fuentes predeterminadas de la presentación.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir una presentación a HTML con imágenes de alta calidad**

Por defecto, al convertir una presentación de PowerPoint a HTML, Aspose.Slides genera un archivo HTML pequeño con imágenes a 72 DPI y elimina las áreas recortadas. Para obtener archivos HTML con imágenes de mayor calidad, debe establecer la propiedad `PicturesCompression` (de la clase `HtmlOptions`) en 96 (es decir, `PicturesCompression.Dpi96`) o un valor superior, como se detalla en [esta referencia](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Este código C# muestra cómo convertir una presentación de PowerPoint a HTML obteniendo imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression.Dpi150`):
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        PicturesCompression = PicturesCompression.Dpi150
    };

    presentation.Save("output_dpi_150.html", SaveFormat.Html, htmlOptions);
}
```


Este código C# muestra cómo convertir una presentación de PowerPoint a HTML sin eliminar áreas recortadas:
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        DeletePicturesCroppedAreas = false
    };

    presentation.Save("output_no_crop.html", SaveFormat.Html, htmlOptions);
}
```


## **Convertir una diapositiva de presentación a HTML**

Para convertir una diapositiva específica de una presentación de PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (utilizada para convertir presentaciones completas) y luego usar el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) puede usarse para especificar opciones de conversión adicionales.

Este código C# muestra cómo convertir una diapositiva con notas del orador en una presentación de PowerPoint a HTML:
```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("sample.pptx"))
    {
        NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        HtmlOptions htmlOptions = new HtmlOptions
        {
            SlidesLayoutOptions = notesOptions,
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController())
        };

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i + 1;

            // Guardar la diapositiva en un archivo HTML.
            string fileName = $"output_slide_{slideIndex}.html";
            presentation.Save(fileName, new[] { slideIndex }, SaveFormat.Html, htmlOptions);
        }
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

Con los nuevos archivos de estilo CSS, puede cambiar fácilmente la apariencia del archivo HTML generado a partir del proceso de conversión de PowerPoint a HTML.

El código C# en este ejemplo muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado que incluya un enlace a un archivo CSS:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");

	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	presentation.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Plantilla de encabezado personalizada.
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
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```


## **Vincular todas las fuentes al convertir una presentación a HTML**

Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede vincular todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`.

Este código C# muestra cómo convertir una presentación de PowerPoint a HTML vinculando todas las fuentes y excluyendo "Calibri" y "Arial" (ya que están instaladas en el sistema):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	// Excluir fuentes predeterminadas de la presentación.
	string[] fontNameExcludeList = { "Calibri", "Arial" };

	LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

	HtmlOptions htmlOptionsEmbed = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
	};

	presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
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
            string path = fontName + ".woff"; // Puede ser necesario sanitizar la ruta.

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


## **Convertir una presentación con imágenes SVG a HTML responsivo**

Este código C# muestra cómo convertir una presentación de PowerPoint a HTML responsivo:
```c#
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    HtmlOptions saveOptions = new HtmlOptions
    {
        SvgResponsiveLayout = true
    };

    presentation.Save("SvgResponsiveLayout-out.html", SaveFormat.Html, saveOptions);
}
```


## **Exportar archivos multimedia a HTML**

Con Aspose.Slides para .NET, puede exportar archivos multimedia de la siguiente manera:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtener una referencia a la diapositiva.  
1. Añadir un video a la diapositiva.  
1. Guardar la presentación como un archivo HTML.  

Este código C# muestra cómo añadir un video a la presentación y luego guardarla como HTML:
```c#
// Crear una nueva presentación.
using (Presentation presentation = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = presentation.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = presentation.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Establecer opciones HTML.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Guardar la presentación en un archivo HTML.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose desarrolló conversores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

¡Consulte otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion)! 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que involucran el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/net/conversion/html-to-image/)  
* [HTML a JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)  
* [HTML a XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)  
* [HTML a TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

**¿Cuál es el rendimiento de Aspose.Slides al convertir múltiples presentaciones a HTML?**

El rendimiento depende del tamaño y la complejidad de las presentaciones. Aspose.Slides es altamente eficiente y escalable para operaciones por lotes. Para lograr un rendimiento óptimo al convertir muchas presentaciones, se recomienda usar multihilo o procesamiento paralelo siempre que sea posible.

**¿Aspose.Slides admite la exportación de hipervínculos a HTML?**

Sí, Aspose.Slides admite completamente la exportación de hipervínculos incrustados a HTML. Cuando convierte presentaciones al formato HTML, los hipervínculos se conservan automáticamente y siguen siendo clicables.

**¿Existe algún límite en el número de diapositivas al convertir presentaciones a HTML?**

No hay límite en el número de diapositivas al usar Aspose.Slides. Puede convertir presentaciones de cualquier tamaño. Sin embargo, para presentaciones que contengan un número muy grande de diapositivas, el rendimiento puede depender de los recursos disponibles en su servidor o sistema.