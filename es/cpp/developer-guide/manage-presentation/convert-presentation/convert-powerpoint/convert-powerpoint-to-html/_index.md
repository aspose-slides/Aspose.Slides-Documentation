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
description: "Convertir presentaciones de PowerPoint a HTML responsivo en C++. Preservar el diseño, los enlaces y las imágenes con la guía de conversión de Aspose.Slides para resultados rápidos y sin errores."
---

## **Visión general**

Este artículo explica cómo convertir una presentación de PowerPoint al formato HTML usando C++. Cubre los siguientes temas.

- [Convertir PowerPoint a HTML en C++](#convert-powerpoint-to-html)
- [Convertir PPT a HTML en C++](#convert-powerpoint-to-html)
- [Convertir PPTX a HTML en C++](#convert-powerpoint-to-html)
- [Convertir ODP a HTML en C++](#convert-powerpoint-to-html)
- [Convertir diapositiva de PowerPoint a HTML en C++](#convert-slide-to-html)

## **PowerPoint a HTML en C++**

Para obtener código de ejemplo en C++ que convierta PowerPoint a HTML, consulte la sección a continuación, es decir, [Convertir PowerPoint a HTML](#convert-powerpoint-to-html). El código puede cargar varios formatos como PPT, PPTX y ODP en el objeto Presentation y guardarlo en formato HTML.

## **Acerca de la conversión de PowerPoint a HTML**

Con [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), las aplicaciones y los desarrolladores pueden convertir una presentación de PowerPoint a HTML: **PPTX a HTML** o **PPT a HTML**. 

**Aspose.Slides** ofrece muchas opciones (principalmente de la clase [**HtmlOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options)) que definen el proceso de conversión de PowerPoint a HTML:

* Convertir una presentación completa de PowerPoint a HTML.
* Convertir una diapositiva específica de una presentación de PowerPoint a HTML.
* Convertir los medios de la presentación (imágenes, videos, etc.) a HTML.
* Convertir una presentación de PowerPoint a HTML responsivo.
* Convertir una presentación de PowerPoint a HTML con notas del presentador incluidas o excluidas.
* Convertir una presentación de PowerPoint a HTML con comentarios incluidos o excluidos.
* Convertir una presentación de PowerPoint a HTML con fuentes originales o incrustadas.
* Convertir una presentación de PowerPoint a HTML utilizando el nuevo estilo CSS. 

{{% alert color="primary" %}} 

Usando su propia API, Aspose desarrolló conversores gratuitos de [presentación a HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT a HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX a HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP a HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Es posible que desee consultar otros [convertidores gratuitos de Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Además de los procesos de conversión descritos aquí, Aspose.Slides también admite estas operaciones de conversión relacionadas con el formato HTML: 

* [HTML a imagen](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}


## **Convertir PowerPoint a HTML**
Con Aspose.Slides, puede convertir una presentación completa de PowerPoint a HTML de esta manera:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
   * Cargue **.ppt** en la clase _Presentation_ para **Convertir PPT a HTML en C++**
   * Cargue **.pptx** en la clase _Presentation_ para **Convertir PPTX a HTML en C++**
   * Cargue **.odp** en la clase _Presentation_ para **Convertir ODP a HTML en C++**
3. Utilice el método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) para guardar el objeto como un archivo HTML.

Este código le muestra cómo convertir un PowerPoint a HTML en C++:
```cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");
    
auto htmlOpt = System::MakeObject<HtmlOptions>();
htmlOpt->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(u"", false));

// Guardar la presentación en HTML
presentation->Save(u"ConvertWholePresentationToHTML_out.html", SaveFormat::Html, htmlOpt);
```


## **Convertir PowerPoint a HTML responsivo**
Aspose.Slides proporciona la clase [ResponsiveHtmlController ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.responsive_html_controller) que permite generar archivos HTML responsivos. Este código le muestra cómo convertir una presentación de PowerPoint a HTML responsivo en C++:
```cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Convert_HTML.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));

// Guardar la presentación en HTML
presentation->Save(u"ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, htmlOptions);
```


## **Convertir PowerPoint a HTML con notas**
Este código le muestra cómo convertir un PowerPoint a HTML con notas en C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

auto opt = System::MakeObject<HtmlOptions>();

auto options = opt->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Guardando páginas de notas
pres->Save(u"Output.html", SaveFormat::Html, opt);
```


## **Convertir PowerPoint a HTML con fuentes originales**
Aspose.Slides proporciona la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) que permite incrustar todas las fuentes de una presentación al convertirla a HTML.

Para evitar que se incrusten ciertas fuentes, puede pasar una matriz de nombres de fuentes a un constructor parametrizado de la clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller). Las fuentes populares, como Calibri o Arial, cuando se utilizan en una presentación, no es necesario incrustarlas porque la mayoría de los sistemas ya las contienen. Cuando esas fuentes se incrustan, el documento HTML resultante se vuelve innecesariamente grande.

La clase [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller) admite herencia y proporciona el método [WriteFont](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.embed_all_fonts_html_controller#a1dfd1c26bb181c8581ec67d270ce0b77), que está destinado a ser sobrescrito. 
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
Por defecto, al convertir PowerPoint a HTML, Aspose.Slides genera HTML pequeño con imágenes a 72 DPI y elimina las áreas recortadas. Para obtener archivos HTML con imágenes de mayor calidad, debe establecer la propiedad `PicturesCompression` (de la clase `HtmlOptions`) a 96 (es decir, `PicturesCompression::Dpi96`) o valores superiores [values](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.export#adc51ca67b7e5c99f6fad75b02ebfd6d8).

Este código C++ le muestra cómo convertir una presentación de PowerPoint a HTML obteniendo imágenes de alta calidad a 150 DPI (es decir, `PicturesCompression::Dpi150`):
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_PicturesCompression(PicturesCompression::Dpi150);

pres->Save(u"OutputDoc-dpi150.html", SaveFormat::Html, htmlOpts);
```


Este código en C++ le muestra cómo generar HTML con imágenes de calidad completa:
```cpp
auto pres = System::MakeObject<Presentation>(u"InputDoc.pptx");

auto htmlOpts = System::MakeObject<HtmlOptions>();
htmlOpts->set_DeletePicturesCroppedAreas(false);

pres->Save(u"Outputdoc-noCrop.html", SaveFormat::Html, htmlOpts);
```


## **Convertir una diapositiva a HTML**
Para convertir una diapositiva específica de un PowerPoint a HTML, debe instanciar la misma clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) (utilizada para convertir presentaciones completas a HTML) y luego usar el método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a5c310c99c623922fc32e91a6d74f7020) para guardar el archivo como HTML. La clase [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) puede usarse para especificar opciones de conversión adicionales:

Este código C++ le muestra cómo convertir una diapositiva de una presentación de PowerPoint a HTML:
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

    auto formatter = HtmlFormatter::CreateCustomFormatter(MakeObject<CustomFormattingController>();
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


## **Guardar CSS e imágenes al exportar a HTML**
Usando nuevos archivos de estilo CSS, puede cambiar fácilmente el estilo del archivo HTML resultante del proceso de conversión de PowerPoint a HTML. 

El código C++ de este ejemplo le muestra cómo usar métodos sobrescribibles para crear un documento HTML personalizado con un enlace a un archivo CSS:
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
        generator->AddHtml(u"<!-- Embedded fonts -->");
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


## **Enlazar todas las fuentes al convertir una presentación a HTML**
Si no desea incrustar fuentes (para evitar aumentar el tamaño del HTML resultante), puede enlazar todas las fuentes implementando su propia versión de `LinkAllFontsHtmlController`. 

Este código C++ le muestra cómo convertir un PowerPoint a HTML enlazando todas las fuentes y excluyendo "Calibri" y "Arial" (ya que ya existen en el sistema): 
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
        String path = String::Format(u"{0}.woff", fontName); // puede ser necesario sanear la ruta
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
Este código C++ le muestra cómo convertir una presentación de PowerPoint a HTML responsivo:
```cpp
auto presentation = System::MakeObject<Presentation>(u"SomePresentation.pptx");
auto saveOptions = System::MakeObject<HtmlOptions>();
saveOptions->set_SvgResponsiveLayout(true);
presentation->Save(u"SomePresentation-out.html", SaveFormat::Html, saveOptions);
```



## **Exportar archivos multimedia a HTML**
Con Aspose.Slides for C++, puede exportar archivos multimedia de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga una referencia a la diapositiva.
3. Agregue un video a la diapositiva.
4. Escriba la presentación como un archivo HTML.

Este código C++ le muestra cómo agregar un video a la presentación y luego guardarla como HTML: 
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

// Establece opciones HTML
auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);

htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateCustomFormatter(controller));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(svgOptions));

// Guarda el archivo
pres->Save(IO::Path::Combine(path, fileName), SaveFormat::Html, htmlOptions);
```


## **FAQ**

**¿Cuál es el rendimiento de Aspose.Slides al convertir múltiples presentaciones a HTML?**

El rendimiento depende del tamaño y la complejidad de las presentaciones. Aspose.Slides es altamente eficiente y escalable para operaciones por lotes. Para lograr un rendimiento óptimo al convertir muchas presentaciones, se recomienda utilizar subprocesos múltiples o procesamiento paralelo siempre que sea posible.

**¿Aspose.Slides admite la exportación de hipervínculos a HTML?**

Sí, Aspose.Slides admite completamente la exportación de hipervínculos incrustados a HTML. Cuando convierte presentaciones al formato HTML, los hipervínculos se conservan automáticamente y siguen siendo clicables.

**¿Existe algún límite en la cantidad de diapositivas al convertir presentaciones a HTML?**

No hay límite en la cantidad de diapositivas al usar Aspose.Slides. Puede convertir presentaciones de cualquier tamaño. Sin embargo, para presentaciones que contengan un número muy grande de diapositivas, el rendimiento puede depender de los recursos disponibles en su servidor o sistema.