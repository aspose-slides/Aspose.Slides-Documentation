---
title: Convertir PowerPoint a HTML en C++
linktitle: Convertir PowerPoint a HTML
type: docs
weight: 30
url: /es/cpp/convert-powerpoint-to-html/
keywords: "C++ PowerPoint a HTML, Convertir presentación de PowerPoint, PPTX, PPT, PPT a HTML, PPTX a HTML, PowerPoint a HTML, Guardar PowerPoint como HTML, Guardar PPT como HTML, Guardar PPTX como HTML, C++, CPP, Aspose.Slides, exportación a HTML"
description: "Convertir PowerPoint a HTML en C++. Guardar PPTX o PPT como HTML en C++. Guardar diapositivas como HTML en C++"
---

## **Resumen**

Este artículo explica cómo convertir una presentación de PowerPoint en formato HTML utilizando C++. Cubre los siguientes temas.

- [Convertir PowerPoint a HTML en C++](#convertir-powerpoint-a-html)
- [Convertir PPT a HTML en C++](#convertir-powerpoint-a-html)
- [Convertir PPTX a HTML en C++](#convertir-powerpoint-a-html)
- [Convertir ODP a HTML en C++](#convertir-powerpoint-a-html)
- [Convertir diapositiva de PowerPoint a HTML en C++](#convertir-diapositiva-a-html)

## **C++ PowerPoint a HTML**

Para obtener código de ejemplo en C++ para convertir PowerPoint a HTML, consulte la sección siguiente: [Convertir PowerPoint a HTML](#convertir-powerpoint-a-html). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**
Usando [**Aspose.Slides para C++**](https://products.aspose.com/slides/cpp/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** proporciona muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación de PowerPoint completa a HTML.
* Convertir una diapositiva específica en una presentación de PowerPoint a HTML.
* Convertir medios de presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo. 
* Convertir una presentación de PowerPoint a HTML con notas del orador incluidas o excluidas. 
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos. 
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas. 
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló convertidores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Puede querer revisar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión que involucran el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Usando Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
   * Cargue **.ppt** en la clase _Presentation_ para **Convertir PPT a HTML en C++**
   * Cargue **.pptx** en la clase _Presentation_ para **Convertir PPTX a HTML en C++**
   * Cargue **.odp** en la clase _Presentation_ para **Convertir ODP a HTML en C++**
3. Use el método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) para guardar el objeto como un archivo HTML.

Este código muestra cómo convertir un PowerPoint a HTML en C++:

```cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Guardando la presentación en HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```

## **Convertir PowerPoint a HTML responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) que permite generar archivos HTML responsivos. Este código muestra cómo convertir una presentación de PowerPoint a HTML responsivo en C++:

```cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Guardando la presentación en HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```

## **Convertir PowerPoint a HTML con notas**
Este código muestra cómo convertir un PowerPoint a HTML con notas en C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Guardando páginas de notas
pres->Save(u"Output.html", SaveFormat::Html, opt);
```

## **Convertir PowerPoint a HTML con fuentes originales**
Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) que permite incrustar todas las fuentes en una presentación al convertir la presentación a HTML.

Para evitar que ciertas fuentes se incrusten, puede pasar un arreglo de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). Las fuentes populares, como Calibri o Arial, cuando se usan en una presentación, no tienen que ser incrustadas porque la mayoría de los sistemas ya contienen esas fuentes. Cuando esas fuentes están incrustadas, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) admite la herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), que está destinado a ser sobreescrito. 

```cpp
auto pres = System::MakeObject<Presentation>(u"input.pptx");

// excluir fuentes predeterminadas de la presentación
auto fontNameExcludeList = System::MakeArray<System::String>({ u"Calibri", u"Arial" });

auto embedFontsController = System::MakeObject<EmbedAllFontsHtmlController>(fontNameExcludeList);

auto htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(embedFontsController));

pres->Save(u"input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, htmlOptionsEmbed);
```

## **Convertir PowerPoint a HTML con imágenes de alta calidad**
Por defecto, cuando convierte PowerPoint a HTML, Aspose.Slides produce HTML pequeño con imágenes a 72 DPI y áreas recortadas eliminadas. Para obtener archivos HTML con imágenes de mayor calidad, debe establecer la propiedad `PicturesCompression` (de la clase `HtmlOptions`) a 96 (es decir, `PicturesCompression::Dpi96`) o valores [más altos](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

Este código en C++ muestra cómo convertir una presentación de PowerPoint a HTML mientras se obtienen imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression::Dpi150`):

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```

Este código en C++ muestra cómo generar HTML con imágenes de calidad completa:

```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```

## **Convertir diapositiva a HTML**
Para convertir una diapositiva específica en PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (usada para convertir presentaciones completas a HTML) y luego usar el método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) se puede usar para especificar opciones de conversión adicionales:

Este código en C++ muestra cómo convertir una diapositiva en una presentación de PowerPoint a HTML:

``` cpp
class CustomFormattingController : public IHtmlFormattingController
{
public:
    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteDocumentEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override{}
    void WriteSlideStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(String::Format(SlideHeader, generator->get_SlideIndex() + 1));
    }
    void WriteSlideEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<ISlide> slide) override
    {
        generator->AddHtml(SlideFooter);
    }
    void WriteShapeStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}
    void WriteShapeEnd(SharedPtr<IHtmlGenerator> generator, SharedPtr<IShape> shape) override{}

private:
    static const String SlideHeader;
    static const String SlideFooter;
};

const String CustomFormattingController::SlideHeader = u"<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
const String CustomFormattingController::SlideFooter = u"</div>";
```

``` cpp
void Run()
{
    String dataDir = GetDataPath();
    
    auto presentation = System::MakeObject<Presentation>(dataDir + u"Individual-Slide.pptx");

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>());
    auto htmlOptions = System::MakeObject<HtmlOptions>();
    htmlOptions->set_HtmlFormatter(formatter);

    // Guardando archivo              
    for (int32_t i = 0; i < presentation->get_Slides()->get_Count(); i++)
    {
        presentation->Save(dataDir + u"Individual Slide" + (i + 1) + u"_out.html", 
            MakeArray<int32_t>({ i + 1 }), SaveFormat::Html, htmlOptions);
    }
}
```

## **Guardar CSS e Imágenes al exportar a HTML**
Utilizando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código en C++ en este ejemplo muestra cómo utilizar métodos sobreescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:

``` cpp
class CustomHeaderAndFontsController : public EmbedAllFontsHtmlController
{
public:
    CustomHeaderAndFontsController(String cssFileName)
        : m_cssFileName(cssFileName)
    {
    }

    void WriteDocumentStart(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(System::String::Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    void WriteAllFonts(SharedPtr<IHtmlGenerator> generator, SharedPtr<IPresentation> presentation) override
    {
        generator->AddHtml(u"<!-- Fonts incrustadas -->");
        EmbedAllFontsHtmlController::WriteAllFonts(generator, presentation);
    }

private:
    static const String Header;
    String m_cssFileName;
};

const String CustomHeaderAndFontsController::Header = String(u"<!DOCTYPE html>\n") + 
u"<html>\n" + u"<head>\n" + 
u"<meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\">\n" + 
u"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" + 
u"<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" + u"</head>";
```

``` cpp
void Run()
{
    // La ruta al directorio de documentos.
    System::String dataDir = GetDataPath();

    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    auto htmlController = System::MakeObject<CustomHeaderAndFontsController>(u"styles.css");
    auto options = System::MakeObject<HtmlOptions>();
    options->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(htmlController));
    pres->Save(u"pres.html", SaveFormat::Html, options);
}
```

## **Enlazar todas las fuentes al convertir la presentación a HTML**
Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede enlazar todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código en C++ muestra cómo convertir un PowerPoint a HTML mientras se enlazan todas las fuentes y se excluyen "Calibri" y "Arial" (ya que ya existen en el sistema): 

```cpp
class LinkAllFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkAllFontsHtmlController(ArrayPtr<String> fontNameExcludeList, String basePath)
        :   EmbedAllFontsHtmlController(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    void WriteFont(SharedPtr<IHtmlGenerator> generator, SharedPtr<IFontData> originalFont, SharedPtr<IFontData> substitutedFont,
        String fontStyle, String fontWeight, ArrayPtr<uint8_t> fontData)
    {
        String fontName = substitutedFont == nullptr ? originalFont->get_FontName() : substitutedFont->get_FontName();
        String path = String::Format(u"{0}.woff", fontName); // puede ser necesario algún saneamiento de ruta
        IO::File::WriteAllBytes(IO::Path::Combine(m_basePath, path), fontData);

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face { ");
        generator->AddHtml(String::Format(u"font-family: '{0}'; ", fontName));
        generator->AddHtml(String::Format(u"src: url('{0}')", path));

        generator->AddHtml(u" }");
        generator->AddHtml(u"</style>");
    }

private:
    String m_basePath;
};
```

``` cpp
void Run()
{
    auto pres = System::MakeObject<Presentation>(u"pres.pptx");

    // excluir fuentes predeterminadas de la presentación
    auto fontNameExcludeList = System::MakeArray<String>({ u"Calibri", u"Arial" });
    
    auto linkcont = System::MakeObject<LinkAllFontsHtmlController>(fontNameExcludeList, u"C://Windows//Fonts//");

    System::SharedPtr<HtmlOptions> htmlOptionsEmbed = System::MakeObject<HtmlOptions>();
    htmlOptionsEmbed->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(linkcont));
    
    pres->Save(u"pres.html", SaveFormat::Html, htmlOptionsEmbed);
}
```

## **Convertir PowerPoint a HTML responsivo**
Este código en C++ muestra cómo convertir una presentación de PowerPoint a HTML responsivo:

```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```


## **Exportar archivos multimedia a HTML**
Utilizando Aspose.Slides para C++, puede exportar archivos multimedia de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenga una referencia a la diapositiva.
1. Agregue un video a la diapositiva.
1. Escriba la presentación como un archivo HTML.

Este código en C++ muestra cómo agregar un video a la presentación y luego guardarlo como HTML: 

```cpp
 // Carga una presentación
auto pres = System::MakeObject<Presentation>();

const System::String path = u"C:/out/";
const System::String fileName = u"ExportMediaFiles_out.html";
const System::String baseUri = u"http://www.example.com/";

auto fileStream = System::MakeObject<IO::FileStream>(u"my_video.avi", IO::FileMode::Open, IO::FileAccess::Read);

auto video = pres->get_Videos()->AddVideo(fileStream, Aspose::Slides::LoadingStreamBehavior::ReadStreamAndRelease);

auto slide = pres->get_Slides()->idx_get(0);
slide->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(path, fileName, baseUri);

// Establece las opciones HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Guarda el archivo
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```