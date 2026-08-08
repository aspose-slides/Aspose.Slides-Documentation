---
title: Optimizar la gestión de imágenes en presentaciones usando C++
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/cpp/image/
keywords:
- añadir imagen
- añadir foto
- añadir mapa de bits
- reemplazar imagen
- reemplazar foto
- desde la web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- recursos SVG externos
- resolutor SVG
- imágenes SVG vinculadas
- fuentes SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Optimice la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para C++, mejorando el rendimiento y automatizando su flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente llamativas. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas desde archivos, internet u otras fuentes. De forma similar, Aspose.Slides permite añadir imágenes a las diapositivas de una presentación de varias maneras. 

{{% alert title="Consejo" color="primary" %}} 
Aspose ofrece conversores gratuitos: [JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt) que le permiten crear presentaciones rápidamente a partir de imágenes. 
{{% /alert %}} 

{{% alert title="Información" color="info" %}}
Si desea añadir una imagen como marco de foto—especialmente si planea redimensionarla, aplicar efectos o usar otras opciones de formato estándar—vea [Marco de imagen](/slides/es/cpp/picture-frame/). 
{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}
Puede convertir imágenes de un formato a otro. Consulte las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/cpp/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/cpp/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/cpp/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/cpp/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Añadir imágenes almacenadas localmente a diapositivas**

Puede añadir una o más imágenes almacenadas en su ordenador a una diapositiva de la presentación. El siguiente código de ejemplo en C++ muestra cómo añadir una imagen a una diapositiva:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Añadir imágenes de la web a diapositivas**

Si la imagen que desea añadir a una diapositiva no está almacenada en su ordenador, puede añadirla directamente desde la web. 

El siguiente código de ejemplo en C++ muestra cómo añadir una imagen desde la web a una diapositiva:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Añadir imágenes a los patrones de diapositivas**

Un patrón de diapositiva almacena y controla información como el tema y el diseño de las diapositivas que lo utilizan. Cuando añade una imagen a un patrón de diapositiva, la imagen aparece en todas las diapositivas basadas en ese patrón. 

El siguiente código de ejemplo en C++ muestra cómo añadir una imagen a un patrón de diapositiva:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Añadir imágenes como fondo de diapositiva**

Puede usar una imagen como fondo de una o varias diapositivas. Para obtener más información, consulte *[Establecer imágenes como fondos de diapositivas](/slides/es/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Añadir SVG a presentaciones**

El contenido SVG puede añadirse a una presentación utilizando la clase [SvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/svgimage/). El objeto [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) resultante puede entonces añadirse a la colección de imágenes de la presentación y usarse para crear un marco de imagen. 

El siguiente ejemplo en C++ importa una cadena SVG autocontenida. Todas las imágenes, estilos y demás recursos utilizados por este SVG se incrustan directamente en el contenido SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importar contenido SVG con recursos externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y canalizaciones web pueden referenciar recursos que se almacenan fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace a una imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente. 

Para importar dicho contenido SVG, cree una implementación de [IExternalResourceResolver](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/iexternalresourceresolver/) y pásela, junto con una URI base, al constructor `SvgImage` correspondiente. La URI base identifica la ubicación del documento SVG y se utiliza para resolver los enlaces relativos. 

La interfaz [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) proporciona acceso a información sobre el SVG importado:

- `get_SvgContent()` devuelve el marcado SVG como una cadena. 
- `get_SvgData()` devuelve el contenido SVG como una matriz de bytes. 
- `get_BaseUri()` devuelve la URI base utilizada para los enlaces relativos. 
- `get_ExternalResourceResolver()` devuelve el resolvedor asignado a la imagen SVG. 

### **Implementar un resolvedor de recursos externos**

El resolvedor tiene dos métodos:

- [ResolveUri](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelva una cadena nula cuando el enlace no pueda resolverse o no esté permitido. 
- [GetEntity](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) devuelve un flujo legible para una URI de recurso absoluta. Devuelva `nullptr` cuando el recurso esté ausente, bloqueado o no disponible. También puede devolverse un flujo de reserva cuando sea apropiado. 

El siguiente resolvedor carga recursos vinculados solo desde un directorio local permitido. Los recursos de red y las rutas fuera del directorio permitido se bloquean. Se devuelve una imagen de reserva opcional para los enlaces de imagen no resueltos.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Este resolvedor permite intencionalmente solo archivos locales.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Utilice una imagen de reserva solo para recursos de imagen. Devolver un flujo de imagen
        // para una fuente o hoja de estilo faltante no sería válido.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Resolver recursos vinculados durante la importación de SVG**

Suponga que `assets/diagram.svg` contiene una referencia relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

El siguiente ejemplo en C++ pasa la URI del archivo SVG como la URI base y proporciona un resolvedor personalizado. El resolvedor convierte el enlace de imagen relativo en una URI absoluta y devuelve un flujo que contiene el recurso vinculado mientras Aspose.Slides procesa el SVG.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// La URI base representa la ubicación del documento SVG.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La clase `SvgImage` también proporciona sobrecargas que aceptan datos SVG como una matriz de bytes o un flujo, junto con un resolvedor de recursos externos y una URI base.

{{% alert title="Importante" color="warning" %}}
El resolvedor de recursos hace que los recursos externos estén disponibles mientras Aspose.Slides procesa y renderiza el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él. 

Cuando se añade un `ISvgImage` a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de reserva. Un recurso vinculado puede aparecer en la imagen de reserva generada mientras un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Una aplicación que renderice la representación SVG nativa puede, por tanto, omitir el contenido vinculado cuando el recurso externo original no está disponible. 
{{% /alert %}}

### **Crear una imagen SVG portable**

Para crear una imagen SVG que no dependa de archivos externos, haga que el SVG sea autocontenido antes de crear el `SvgImage`. Por ejemplo, reemplace las URLs de imágenes vinculadas con URIs `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Después de que todos los recursos necesarios se incrusten en el contenido SVG, cree el `SvgImage`, añádalo a la colección de imágenes de la presentación e insértelo en un marco de imagen como se muestra en el ejemplo anterior. 

### **Gestionar recursos ausentes o bloqueados**

Devuelva una cadena nula desde `ResolveUri` cuando una URI de recurso sea inválida, prohibida o no pueda resolverse. Devuelva `nullptr` desde `GetEntity` cuando el recurso no pueda leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando sea posible. 

Puede devolverse un flujo de reserva para un recurso ausente, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelva un flujo de imagen solo para una imagen faltante, no para una fuente o una hoja de estilo. 

{{% alert title="Seguridad" color="warning" %}}
No resuelva rutas de archivo arbitrarias ni URLs de red sin restricciones a partir de archivos SVG no confiables. Restrinja los esquemas, directorios y hosts permitidos. Para recursos de red, aplique también tiempos de espera de conexión, límites de tamaño de respuesta y validación de contenido. 
{{% /alert %}}

## **Convertir SVG a un conjunto de formas**
Aspose.Slides puede convertir un SVG en un conjunto de formas, similar a la funcionalidad correspondiente en PowerPoint:

![Menú emergente de PowerPoint](img_01_01.png)

Esta funcionalidad la proporciona una sobrecarga del método [AddGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/) que acepta un objeto [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) como primer argumento. 

El siguiente código de ejemplo en C++ muestra cómo usar este método para convertir un archivo SVG en un conjunto de formas:

```cpp
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Nombre del archivo SVG de origen
auto svgFileName = System::String(u"sample.svg");

// Nombre del archivo de presentación de salida
auto outPptxPath = System::String(u"presentation.pptx");

// Crear una nueva presentación
auto presentation = System::MakeObject<Presentation>();

// Leer el contenido del archivo SVG
auto svgContent = File::ReadAllText(svgFileName);

// Crear un objeto SvgImage
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Obtener el tamaño de la diapositiva
auto slideSize = presentation->get_SlideSize()->get_Size();

// Convertir la imagen SVG a un grupo de formas y escalarla al tamaño de la diapositiva
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Guardar la presentación en formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Añadir imágenes como EMF a diapositivas**
Aspose.Slides for C++ permite generar imágenes EMF a partir de hojas de cálculo Excel con Aspose.Cells y añadirlas a las diapositivas de la presentación. 

El siguiente código de ejemplo en C++ muestra cómo hacerlo:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells para C++ debe iniciarse antes de usar cualquiera de sus tipos.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Renderizar la hoja de cálculo como EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells devuelve la página renderizada como un búfer, que Aspose.Slides añade como una imagen.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes usadas por formas de diapositiva. Esta sección describe varias formas de actualizar imágenes en la colección. Puede reemplazar una imagen usando datos binarios sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) o otra imagen que ya exista en la colección. 

1. Cargue el archivo de presentación que contiene imágenes utilizando la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). 
1. Cargue una nueva imagen desde un archivo en una matriz de bytes. 
1. Reemplace la imagen objetivo con la nueva imagen utilizando la matriz de bytes. 
1. En el segundo enfoque, cargue la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) y reemplace la imagen objetivo con ese objeto. 
1. En el tercer enfoque, reemplace la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación. 
1. Escriba la presentación modificada como un archivo PPTX. 

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// La primera forma.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// La segunda forma.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// La tercera forma.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Guardar la presentación en un archivo.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Información" color="info" %}}
Con el conversor gratuito [Text to GIF](https://products.aspose.app/slides/es/text-to-gif) de Aspose, puede animar texto fácilmente y crear GIFs a partir de texto. 
{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [imagen](/slides/es/cpp/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar. 

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloque el logotipo en la diapositiva maestra o en un diseño y reemplácelo en la colección de imágenes de la presentación; los cambios se propagarán a todos los elementos que usan ese recurso. 

**¿Se puede convertir un SVG insertado en formas editables?**

Sí. Puede convertir un SVG en un grupo de formas, después de lo cual las partes individuales se vuelven editables con las propiedades estándar de forma. 

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/cpp/presentation-background/) en la diapositiva maestra o en el diseño correspondiente—cualquier diapositiva que use esa maestra/diseño heredará el fondo. 

**¿Cómo evito que una presentación se vuelva demasiado grande debido a muchas imágenes?**

Reutilice un único recurso de imagen en lugar de duplicados, elija resoluciones razonables, aplique compresión al guardar y mantenga los gráficos repetidos en la maestra cuando corresponda.