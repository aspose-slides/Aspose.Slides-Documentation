---
title: Convertir presentaciones de PowerPoint a HTML en C++
linktitle: PowerPoint a HTML
type: docs
weight: 30
url: /es/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint a HTML en C++. Utilice Aspose.Slides para exportar archivos PPT y PPTX, diapositivas seleccionadas, notas, fuentes, imágenes, SVG y multimedia."
---
## **Resumen**

Aspose.Slides para C++ puede guardar presentaciones de PowerPoint como HTML sin Microsoft PowerPoint. La conversión básica consiste en cargar una única [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y realizar una llamada `Save` con [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/). Utilice [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/) cuando necesite controlar el diseño exportado, fuentes, imágenes, notas, comentarios, salida SVG o recursos vinculados.

Esta guía se centra en escenarios prácticos de exportación a HTML:

- Exportar una presentación completa o diapositivas seleccionadas.
- Generar HTML de diseño fijo, adaptable o basado en SVG.
- Incluir notas del presentador y comentarios.
- Controlar la calidad de imagen y los datos de imágenes recortadas.
- Incrustar fuentes o guardar los archivos de fuentes por separado.
- Elegir cómo se escriben y referencian los recursos externos y los archivos multimedia.

Por defecto, la exportación a HTML produce un documento HTML autocontenido donde la mayoría de los recursos están incrustados. Esto es cómodo para compartir un solo archivo, pero puede aumentar el tamaño de la salida. Para publicación web, considere recursos externos, reducir la DPI de las imágenes y sólo incrustar fuentes que no estén disponibles de forma fiable en el entorno de destino.

## **Convertir una Presentación a HTML**

Para exportar una presentación a HTML, cárgela con [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y guárdela con `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Este ejemplo escribe un archivo HTML. La llamada a `Dispose` libera los manejadores de archivo y los recursos de renderizado después de la exportación.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/) es la clase principal de configuración para la exportación a HTML. Los ajustes habituales incluyen:

- `SlidesLayoutOptions`: agrega notas, comentarios, folletos u otra información de diseño.
- `HtmlFormatter`: cambia la estructura del documento HTML o delega el formato a un controlador.
- `SlideImageFormat`: cambia la forma en que se representan las diapositivas, por ejemplo como SVG.
- `PicturesCompression`: controla la DPI de la imagen y el tamaño de salida.
- `DeletePicturesCroppedAreas`: conserva o elimina los datos de imágenes recortadas.
- `SvgResponsiveLayout`: hace que el contenido SVG exportado se adapte a su contenedor.
- `ShowHiddenSlides`: incluye diapositivas ocultas cuando sea necesario.

Las secciones siguientes muestran por separado las opciones más habituales para que pueda combinar sólo las que su flujo de trabajo necesite.

## **Convertir Diapositivas Seleccionadas a HTML**

La sobrecarga `Presentation::Save` que acepta números de diapositiva utiliza posiciones de diapositiva basadas en 1. El bucle a continuación guarda cada diapositiva en un archivo HTML separado.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Utilice este patrón cuando un sitio web o una aplicación necesiten una página HTML por diapositiva. Si cada diapositiva debe tener el mismo diseño, cree una única instancia de [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/) y pásela a cada llamada `Save`.

## **Crear HTML Adaptable**

[ResponsiveHtmlController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/responsivehtmlcontroller/) proporciona salida HTML adaptable mediante [HtmlFormatter](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmlformatter/). Úselo cuando la página exportada deba adaptarse mejor al ancho del navegador.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Para un diseño adaptable basado en SVG, establezca `SvgResponsiveLayout` en [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/). Esto es útil cuando el contenido de la diapositiva se exporta como marcado SVG escalable.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Incluir Notas del Presentador y Comentarios**

Utilice [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) a través de `HtmlOptions.SlidesLayoutOptions` para incluir notas del presentador o comentarios. Las notas y los comentarios están ocultos por defecto a menos que elija sus posiciones.

Supongamos que la presentación de origen contiene notas del presentador:

![Diapositiva con notas del presentador en PowerPoint](slide_with_notes.png)

El siguiente código exporta el contenido de la diapositiva con las notas del presentador bajo la diapositiva.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

El HTML exportado incluye el área de notas:

![Salida HTML con la diapositiva y notas del presentador](HTML_with_notes.png)

Para exportar comentarios, establezca `CommentsPosition`, por ejemplo a `CommentsPositions::Right` o `CommentsPositions::Bottom`. Si sólo necesita comentarios, omita `NotesPosition`. Si necesita tanto notas como comentarios, establezca ambas propiedades.

## **Controlar la Calidad de Imagen y Áreas Recortadas**

La exportación a HTML puede comprimir las imágenes de las diapositivas para reducir el tamaño de la salida. Establezca `PicturesCompression` a un valor de [PicturesCompression](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/picturescompression/) cuando necesite mayor calidad de imagen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Por defecto, las áreas recortadas de las imágenes pueden eliminarse de la salida exportada. conserve los datos recortados sólo cuando los usuarios deban poder recuperar o inspeccionar esas partes ocultas de la imagen. Mantenerlos puede aumentar el tamaño del HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Añadir CSS**

Para un estilo sencillo, pase una cadena CSS a `HtmlFormatter::CreateDocumentFormatter`. Esto cambia el documento HTML circundante mientras Aspose.Slides sigue renderizando el contenido de la diapositiva.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Para un encabezado de documento personalizado, un archivo CSS vinculado o marcado personalizado alrededor de diapositivas y formas, implemente [IHtmlFormattingController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ihtmlformattingcontroller/) y páselo a [HtmlFormatter](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmlformatter/) con `CreateCustomFormatter`.

## **Incrustar Fuentes**

Si el entorno de destino puede no tener instaladas las fuentes de la presentación, incruste fuentes en el HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedallfontshtmlcontroller/). La incrustación mejora la fidelidad visual pero aumenta el tamaño de la salida.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Excluya fuentes sólo cuando esté seguro de que los navegadores o sistemas de destino ya las proporcionan. Para fuentes de marca o fuentes menos comunes, la incrustación suele ser más segura.

## **Vincular Archivos de Fuente en Lugar de Incrustarlos**

Para reducir el tamaño del archivo HTML, puede escribir los datos de fuentes en archivos WOFF independientes y añadir reglas `@font-face` al HTML. El ayudante a continuación extiende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedallfontshtmlcontroller/) y sobrescribe `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

En este ejemplo, los archivos de fuente se guardan en `html-output/fonts`, y el HTML los referencia con URL como `fonts/BrandFont-normal-400.woff`. Si el archivo HTML y las fuentes se despliegan en otra ubicación, elija `fontUrlPrefix` de modo que coincida con la ruta URL desplegada.

## **Guardar Recursos Externamente**

El HTML autocontenido es fácil de mover, pero los recursos incrustados en Base64 pueden hacer que el archivo sea grande. Si su aplicación necesita archivos de imagen externos, implemente [ILinkEmbedController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/) y páselo al constructor de [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/).

Al externalizar recursos, elija dos rutas de forma deliberada:

- La ruta de salida en el sistema de archivos, donde su aplicación escribe imágenes, fuentes, audio o vídeo generados.
- La ruta URL, que es la que el navegador utiliza desde el documento HTML para cargar esos archivos.

## **Exportar Archivos Multimedia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exporta archivos de vídeo y audio y escribe HTML que puede reproducirlos en un navegador. Su constructor recibe:

- `path`: el directorio donde se escribirán los archivos multimedia generados.
- `fileName`: el nombre del archivo HTML que se está generando.
- `baseUri`: el prefijo URI absoluto utilizado en los enlaces HTML a los archivos multimedia.

Si el archivo HTML es `html-output/presentation.html` y los archivos multimedia se guardan en `html-output/media`, `path` debe apuntar al directorio multimedia en disco, mientras que `baseUri` debe apuntar al mismo directorio desde el punto de vista del navegador. Para vista previa local, puede crear un URI `file:///` a partir del directorio multimedia. Para una aplicación desplegada, use la URL absoluta del directorio multimedia publicado.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Utilice directorios de salida que sean únicos por trabajo de exportación, especialmente en aplicaciones de servidor. Las rutas de salida compartidas pueden provocar que archivos de diferentes conversiones se sobrescriban entre sí.

## **Rendimiento y Gestión de Recursos**

La conversión a HTML es una operación de renderizado, por lo que el tiempo de procesamiento y el uso de memoria dependen del número de diapositivas, la resolución de las imágenes, fuentes, efectos, gráficos y medios incrustados. Valores más altos de DPI en `PicturesCompression`, fuentes incrustadas, salida SVG y áreas de imagen recortadas retenidas pueden mejorar la fidelidad pero suelen aumentar el tamaño de la salida.

Para conversiones por lotes:

- Libere rápidamente cada instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
- Utilice directorios de salida separados para trabajos independientes.
- Evite incrustar fuentes comunes a menos que la fidelidad lo requiera.
- Reduzca la DPI de la imagen cuando el HTML sea para vista previa o miniaturas.
- Mantenga la presentación original, el HTML generado y los recursos externos juntos hasta que las rutas de despliegue sean definitivas.

## **Preguntas frecuentes**

**¿Se conservan los hipervínculos en la salida HTML?**

Sí. Los hipervínculos de la presentación se exportan a HTML y siguen siendo clicables cuando la URL de destino es válida.

**¿Puedo convertir presentaciones a HTML en paralelo?**

Sí, pero no comparta una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) entre hilos. Procese archivos diferentes con instancias de presentación separadas, flujos separados y directorios de salida separados. Consulte la [multithreading guidance](/slides/es/cpp/multithreading/) para obtener más detalles.

**¿Es seguro usar un objeto Presentation en varios hilos?**

No. Una única instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) debe cargarse, modificarse, guardarse y liberarse en un solo hilo. Para trabajo paralelo, cree una instancia independiente por hilo o proceso.

**¿Por qué el archivo HTML generado es grande?**

La exportación predeterminada puede incrustar recursos directamente en el HTML. Las fuentes incrustadas, imágenes de alta DPI, medios, contenido SVG y áreas de imagen recortadas retenidas también aumentan el tamaño. Use recursos externos, excluya fuentes comunes de la incrustación y reduzca `PicturesCompression` cuando una salida más pequeña sea más importante que la máxima fidelidad.

**¿Cómo debo elegir baseUri para la exportación de medios?**

Elija `baseUri` desde el punto de vista del navegador y páselo como una URI absoluta. Para vista previa local, puede derivarla del directorio de salida con `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Para despliegue, use la URL absoluta del directorio multimedia publicado. El `path` del sistema de archivos y el `baseUri` del navegador no tienen que ser la misma cadena, pero deben describir la misma ubicación de recurso.

**¿Puedo incluir diapositivas ocultas?**

Sí. Establezca `ShowHiddenSlides` en `true` en [HtmlOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/) cuando sea necesario exportar diapositivas ocultas.