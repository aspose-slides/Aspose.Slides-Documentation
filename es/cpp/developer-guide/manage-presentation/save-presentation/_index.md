---
title: Guardar presentaciones en C++
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/cpp/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- formato estricto Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- C++
- Aspose.Slides
description: "Guarde presentaciones de PowerPoint y OpenDocument en archivos o flujos en C++ con Aspose.Slides, y configure la salida PPTX y la generación de informes de progreso."
---
## **Descripción general**

Después de crear una presentación o [abrir una existente](/slides/es/cpp/open-presentation/), utilice el método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) para escribir el resultado. Aspose.Slides para C++ puede guardar una presentación en un archivo o flujo en PowerPoint, OpenDocument, PDF y otros formatos. Las siguientes secciones cubren las operaciones de guardado estándar y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) al método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/). El valor de formato determina el tipo de archivo que Aspose.Slides crea.

El siguiente ejemplo crea una presentación y la guarda como un archivo PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Agregar o modificar el contenido de la presentación aquí.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Guardar presentaciones en su formato original**

Para ejemplos de detección de archivos y flujos, el comportamiento de presentaciones recién creadas y la distinción entre formatos de origen y de salida, consulte [Determine the Original Presentation Format](/slides/es/cpp/detect-presentation-source-format/).

En una aplicación de procesamiento por lotes, es posible que el formato de entrada no se conozca de antemano. Después de cargar un archivo, lea su formato original con [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_sourceformat/). Pase el valor [SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/sourceformat/) resultante a [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/tosaveformat/) para obtener el valor [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) correspondiente y, a continuación, utilice [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato con el que se cargó:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/tosaveformat/) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus formatos de guardado de presentación correspondientes. Sólo asigna formatos de origen de la presentación; no está destinado a seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor [SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/sourceformat/) no compatible o no válido provoca una [ArgumentException](https://reference.aspose.com/slides/es/cpp/system/argumentexception/).

Los archivos heredados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, conserve el nombre de archivo original o los metadatos de formato por separado y utilícelos al elegir el nombre y formato del archivo de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un [Stream](https://reference.aspose.com/slides/es/cpp/system.io/stream/) grabable y un valor [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) al método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Llame a [ViewProperties::set_LastView](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewproperties/set_lastview/) con un valor [ViewType](https://reference.aspose.com/slides/es/cpp/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Maestro de diapositivas como vista inicial:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Para crear un archivo PPTX que cumpla con el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pptxoptions/) y llame a [PptxOptions::set_Conformance](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pptxoptions/set_conformance/) con `Conformance::Iso29500_2008_Strict`. A continuación, pase las opciones al método [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y sin comprimir de cada entrada, el tamaño total del archivo y el número de entradas. Dado que un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 aumentan los límites aplicables de tamaño y número de entradas.

Utilice [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) para controlar si Aspose.Slides escribe extensiones ZIP64:

- `IfNecessary` usa ZIP64 sólo cuando la presentación supera los límites estándar de ZIP. Este es el modo predeterminado.
- `Never` desactiva las extensiones ZIP64.
- `Always` siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Si `Zip64Mode` se establece en `Never` y la presentación no cabe dentro de los límites estándar de ZIP, la operación de guardado lanza una [PptxException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado con el tamaño del archivo llamando a [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). La enumeración [CompressionLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/compressionlevel/) proporciona los siguientes valores:

- `None` almacena los datos sin compresión.
- `Level1` ofrece la compresión más rápida y el mayor tamaño de salida comprimida.
- `Level2` a `Level5` favorecen progresivamente una salida más pequeña sobre la velocidad de guardado.
- `Level6` equilibra la velocidad de guardado y el tamaño del archivo. Este es el nivel predeterminado.
- `Level7` y `Level8` favorecen aún más una salida más pequeña sobre la velocidad de guardado.
- `Level9` ofrece la compresión más fuerte y requiere el mayor tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

El siguiente ejemplo usa el nivel máximo de compresión:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Guardar presentaciones sin actualizar la miniatura**

Al guardar una presentación como PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controla la miniatura del documento:

- `true` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `false` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

Para monitorizar una operación de guardado, implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprogresscallback/) y pase la implementación a [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides entonces llama a [IProgressCallback::Reporting](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprogresscallback/reporting/) con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación a PDF en la consola:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito creado con la API de Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX independientes.
{{% /alert %}}

## **FAQ**

**¿Aspose.Slides admite guardado incremental o “guardado rápido”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar sólo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/cpp/multithreading/). Acceda y guarde cada instancia sólo desde un hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar una presentación?**

[Hyperlinks](/slides/es/cpp/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar los metadatos del documento, como el autor, título, empresa y fecha de creación?**

Sí. Establezca las [propiedades del documento](/slides/es/cpp/presentation-properties/) apropiadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.