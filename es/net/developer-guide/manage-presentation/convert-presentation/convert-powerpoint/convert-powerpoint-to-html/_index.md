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
description: "Convierta presentaciones de PowerPoint a HTML en .NET. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y medios."
---
## **Resumen**

Aspose.Slides for .NET puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en una única carga de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y una llamada a [Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) con [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos enlazados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, adaptable o basado en SVG.
- Incluir notas del orador y comentarios.
- Controlar la calidad de imagen y los datos recortados de las imágenes.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML genera un documento HTML autónomo donde la mayoría de los recursos se incrustan. Esto es conveniente para compartir un único archivo, pero puede aumentar el tamaño de salida. Para la publicación web, considere recursos externos, reducir la DPI de las imágenes y solo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una presentación a HTML**

Para exportar una presentación a HTML, cárguela con [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y guárdela con [SaveFormat.Html](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Este ejemplo escribe un archivo HTML. El objeto de presentación se elimina mediante la declaración `using`, lo que libera los manejadores de archivos y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes más comunes incluyen:

- `SlidesLayoutOptions`: agrega notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla la DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos recortados de la imagen.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las siguientes secciones muestran por separado las opciones más comunes para que pueda combinar solo aquellas que su flujo de trabajo necesita.

## **Convertir diapositivas seleccionadas a HTML**

La sobrecarga [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) que acepta números de diapositiva utiliza posiciones de diapositiva basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Utilice este patrón cuando un sitio web o una aplicación necesite una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una instancia de [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/) y pásela a cada llamada `Save`.

## **Crear HTML adaptable**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/net/aspose.slides.export/responsivehtmlcontroller/) proporciona salida HTML adaptable mediante [HtmlFormatter](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Para un diseño adaptable basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Incluir notas del orador y comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/notescommentslayoutingoptions/) a través de `HtmlOptions.SlidesLayoutOptions` para incluir notas del orador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Suponga que la presentación fuente contiene notas del orador:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con notas del orador debajo de la diapositiva.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions.Right` o `CommentsPositions.Bottom`. Si solo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la calidad de imagen y áreas recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/net/aspose.slides.export/picturescompression/) cuando necesite mayor calidad de imagen.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse del resultado exportado. Conserve los datos recortados solo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Agregar CSS**

Para un estilo simple, pasa una cadena CSS a [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Esto cambia el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Para un encabezado de documento personalizado, un archivo CSS enlazado o un marcado personalizado alrededor de diapositivas y formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/es/net/aspose.slides.export/ihtmlformattingcontroller/) y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmlformatter/) con `CreateCustomFormatter`.

## **Incrustar fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste las fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/net/aspose.slides.export/embedallfontshtmlcontroller/). Incrustar mejora la fidelidad visual pero aumenta el tamaño de salida.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Excluya fuentes solo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Enlazar archivos de fuentes en lugar de incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de fuentes en archivos WOFF separados y añadir reglas `@font-face` al HTML. El asistente a continuación amplía [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/net/aspose.slides.export/embedallfontshtmlcontroller/) y sobrescribe `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```
```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

En este ejemplo, los archivos de fuentes se guardan en `html-output/fonts`, y el HTML los referencia con URL como `fonts/BrandFont-normal-400.woff`. Si el archivo HTML y las fuentes se despliegan en otra ubicación, elija `fontUrlPrefix` para que coincida con la ruta URL desplegada.

## **Guardar recursos externamente**

El HTML autónomo es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/es/net/aspose.slides.export/ilinkembedcontroller/) y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/htmloptions/).

Al externalizar recursos, elija dos rutas deliberadamente:

- La ruta de salida del sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o video generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos.

Para una implementación completa de enlace de imágenes, vea [Export Presentations to HTML with Externally Linked Images](/slides/es/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportar archivos multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/net/aspose.slides.export/videoplayerhtmlcontroller/) exporta video y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo de URI absoluto usado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para una vista previa local, puede crear una URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones servidoras. Las rutas de salida compartidas pueden provocar que los archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y gestión de recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de imágenes, fuentes, efectos, gráficos y medios incrustados. Valores DPI más altos de `PicturesCompression`, fuentes incrustadas, salida SVG y áreas de imagen recortadas conservadas pueden mejorar la fidelidad pero generalmente aumentan el tamaño de salida.

Para la conversión por lotes:

- Elimine rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
- Utilice directorios de salida separados para trabajos diferentes.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca la DPI de las imágenes cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación fuente, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **FAQ**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) entre hilos. Procese diferentes archivos con instancias de presentación independientes, flujos separados y directorios de salida diferentes. Consulte la [multithreading guidance](/slides/es/net/multithreading/) para obtener detalles.

**¿Es seguro usar un objeto Presentation en varios hilos?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) debe cargarse, modificarse, guardarse y eliminarse en un solo hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas recortadas de imágenes conservadas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando un tamaño de salida menor sea más importante que la máxima fidelidad.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para una vista previa local, puede derivarla del directorio de salida con `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Para el despliegue, use la URL absoluta del directorio de medios publicado. El `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación del recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides = true` en [HtmlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/htmloptions/) cuando sea necesario exportar diapositivas ocultas.