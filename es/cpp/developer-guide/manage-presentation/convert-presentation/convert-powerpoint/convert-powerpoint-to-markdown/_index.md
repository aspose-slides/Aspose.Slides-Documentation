---
title: Convertir presentaciones PowerPoint a Markdown en C++
linktitle: PowerPoint a Markdown
type: docs
weight: 140
url: /es/cpp/convert-powerpoint-to-markdown/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a MD
- presentación a MD
- diapositiva a MD
- PPT a MD
- PPTX a MD
- guardar PowerPoint como Markdown
- guardar presentación como Markdown
- guardar diapositiva como Markdown
- guardar PPT como MD
- guardar PPTX como MD
- exportar PPT a MD
- exportar PPTX a MD
- exportación de imágenes Markdown
- enlaces de imágenes CDN
- PowerPoint
- presentación
- Markdown
- C++
- Aspose.Slides
description: "Convertir presentaciones PPT y PPTX a Markdown en C++ y controlar dónde se guardan y referencian las imágenes exportadas en bitmap, metarchivo y SVG."
---
## **Visión general**

Aspose.Slides for C++ puede convertir presentaciones PPT y PPTX a Markdown para documentación, sitios estáticos, migración de contenido y flujos de trabajo de control de versiones. Puede elegir un sabor de Markdown, controlar cómo se renderiza el contenido de las diapositivas y decidir dónde se almacenan las imágenes exportadas y cómo el Markdown generado las referencia.

De forma predeterminada, la exportación a Markdown utiliza salida solo de texto. Para exportar contenido visual, establezca el método [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) con el valor `Sequential` o `Visual` del enumerado [MarkdownExportType](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownexporttype/). `Sequential` representa los elementos de la diapositiva por separado y en orden, mientras que `Visual` mantiene los elementos agrupados juntos para preservar su relación visual. El valor `TextOnly` no genera recursos de imagen, por lo que los eventos de guardado de imágenes no se invocan en ese modo.

## **Convertir una presentación a Markdown**

Cargue el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y luego llame al método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) con el valor `Md` del enumerado [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/).

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Seleccionar un sabor de Markdown**

El método [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) controla la especificación de Markdown utilizada para la salida. El enumerado [Flavor](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/flavor/) incluye CommonMark, GitHub Flavored Markdown y otras variantes admitidas.

El siguiente ejemplo exporta una presentación como CommonMark:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Exportar imágenes usando el comportamiento predeterminado de guardado local**

La clase [MarkdownSaveOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/) proporciona dos métodos para configurar las imágenes guardadas localmente:

- [set_BasePath](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) especifica el directorio base para el documento Markdown y sus recursos.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) especifica el subdirectorio de imágenes. Su valor predeterminado es `Images`.

El siguiente ejemplo representa contenido visual, escribe imágenes en `output/assets` y crea referencias de imagen relativas en el documento Markdown:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Este comportamiento también sirve como alternativa cuando un controlador personalizado de guardado de imágenes devuelve `false`.

## **Personalizar el guardado de imágenes y los enlaces Markdown**

Utilice el evento `MarkdownSaveOptions::ImageSaving` para recursos de mapa de bits y metarchivo no SVG emitidos durante la exportación a Markdown. Su delegado [MarkdownImageSavingHandler](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) recibe el objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/), su [ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/) y el enlace Markdown generado como parámetro `System::String&`. Guarde o cargue la imagen con el formato proporcionado y reemplace `link` con la referencia que debe aparecer en la salida Markdown.

Los recursos emitidos en formato SVG se manejan por separado. Suscríbase al evento `MarkdownSaveOptions::SvgImageSaving`, cuyo delegado [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) recibe un objeto [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) y el parámetro `System::String& link`. Un SVG no tiene argumento `ImageFormat`; escriba o cargue sus datos XML mediante el método [ISvgImage::get_SvgData](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/get_svgdata/). Dependiendo del modo de exportación y del agrupamiento visual, un SVG en la presentación fuente puede rasterizarse o combinarse con otro contenido; el recurso resultante que no sea SVG se pasa entonces a `ImageSaving`. Suscríbase a ambos eventos cuando cada recurso visual exportado requiera procesamiento personalizado.

El valor de retorno del controlador determina quién procesa la imagen:

- Devuelva `true` después de que el controlador haya guardado, subido, transformado o procesado la imagen de alguna manera y haya asignado un valor válido a `link`. Aspose.Slides escribe ese valor en el documento Markdown y no realiza su guardado local predeterminado.
- Devuelva `false` para que Aspose.Slides guarde la imagen localmente y genere su enlace según [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) y [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Un controlador que devuelve `true` asume la responsabilidad de la imagen. Si devuelve `true` sin asignar un enlace válido y no vacío, la exportación falla con una `InvalidOperationException`.
{{% /alert %}}

### **Guardar imágenes en un directorio de origen CDN y usar URLs externas**

El siguiente ejemplo trata `cdn-origin/presentations/quarterly-report` como un directorio de origen CDN montado o sincronizado. Cada controlador extrae el nombre de archivo generado, guarda la imagen en ese directorio personalizado y reemplaza la referencia local generada por una URL pública de CDN. El propio ejemplo no realiza ninguna carga de red: la URL solo se vuelve válida después de que el directorio se monte como origen CDN o sus archivos se publiquen en el CDN. Para almacenamiento de objetos, reemplace la escritura en el sistema de archivos por la operación de carga del SDK de almacenamiento y asigne `link` solo después de que la carga se complete correctamente.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

El controlador de bitmap devuelve deliberadamente `false` para imágenes menores de 128 × 128 píxeles, por lo que Aspose.Slides guarda esas imágenes en `output/fallback-images` usando el comportamiento predeterminado. Los recursos de bitmap y metarchivo más grandes, así como los recursos SVG, son manejados por el código personalizado. Por ejemplo, una referencia local generada como `fallback-images/image1.png` pasa a `https://cdn.example.com/presentations/quarterly-report/image1.png`. Los controladores usan rutas del sistema operativo solo al escribir archivos; los enlaces escritos en Markdown utilizan barras diagonales (`/`) y nombres de archivo escapados en URL. Aplique la misma regla al crear enlaces relativos: use `/`, no el separador de directorios específico de la plataforma.

## **Preguntas frecuentes**

**¿Puede un controlador procesar tanto imágenes rasterizadas como imágenes SVG?**

No. Utilice `MarkdownSaveOptions::ImageSaving` para los recursos de mapa de bits y metarchivo emitidos y `MarkdownSaveOptions::SvgImageSaving` para los recursos emitidos como SVG. El primero proporciona un objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) y un [ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/); el segundo proporciona un objeto [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) cuyos datos SVG pueden leerse con [ISvgImage::get_SvgData](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/get_svgdata/). Un SVG fuente que se rasteriza durante la exportación se procesa mediante `ImageSaving`.

**¿Qué ocurre cuando un controlador de guardado de imágenes devuelve `false`?**

Aspose.Slides utiliza su comportamiento predeterminado de guardado local. La ubicación de la imagen y la referencia generada se controlan mediante [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) y [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/).

**¿Puede un controlador proporcionar una URL sin guardar la imagen localmente?**

Sí. El controlador puede subir la imagen al almacenamiento de objetos o pasarla a otro servicio, asignar la URL resultante a `link` y devolver `true`. El controlador debe completar el procesamiento por sí mismo; devolver `true` impide el guardado local predeterminado.

**¿Por qué la exportación a Markdown lanza una `InvalidOperationException` desde un controlador?**

Esta excepción se produce cuando el controlador devuelve `true` pero no proporciona un enlace válido. Asigne la ruta relativa o la URL externa que debe escribirse en Markdown antes de devolver `true`.

**¿Qué separador de rutas deben usar los enlaces de imágenes?**

Utilice barras diagonales (`/`) en los enlaces Markdown y en las URL. Use `Path::Combine` solo para rutas del sistema de archivos y luego construya o normalice la referencia Markdown por separado.

**¿Se conservan los hipervínculos durante la exportación a Markdown?**

Sí. Los [hipervínculos](/slides/es/cpp/manage-hyperlinks/) de texto se conservan como enlaces Markdown estándar. Las [transiciones](/slides/es/cpp/slide-transition/) y [animaciones](/slides/es/cpp/powerpoint-animation/) de diapositivas no se convierten.

**¿Pueden las presentaciones convertirse a Markdown en paralelo?**

Puede procesar diferentes archivos de presentación en paralelo, pero no comparta la misma instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) entre hilos. Siga las [directrices de multihilo](/slides/es/cpp/multithreading/) y utilice una instancia separada para cada archivo.