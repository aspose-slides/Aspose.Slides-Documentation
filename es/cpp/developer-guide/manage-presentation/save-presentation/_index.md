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
- Formato Strict Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- C++
- Aspose.Slides
description: "Descubra cómo guardar presentaciones en C++ usando Aspose.Slides: exporte a PowerPoint u OpenDocument conservando diseños, fuentes y efectos."
---
## **Visión general**

[Abrir presentaciones en C++](/slides/es/cpp/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) contiene el contenido de una presentación. Tanto si está creando una presentación desde cero como si está modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para C++, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `Save` de la clase [Presentation]. Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Realice alguna operación aquí...

// Guarde la presentación en un archivo.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `Save` de la clase [Presentation]. Una presentación puede escribirse en varios tipos de flujos. En el ejemplo siguiente, creamos una nueva presentación y la guardamos en un flujo de archivo.

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

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Guardar la presentación en el flujo.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando se abre la presentación generada mediante la clase [ViewProperties]. Utilice el método [set_LastView] con un valor de la enumeración [ViewType].

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

Aspose.Slides le permite guardar una presentación en el formato estricto Office Open XML. Utilice la clase [PptxOptions] y establezca su propiedad de conformidad al guardar. Si establece `Conformance.Iso29500_2008_Strict`, el archivo de salida se guarda en el formato estricto Office Open XML.

El ejemplo siguiente crea una presentación y la guarda en el formato estricto Office Open XML.

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

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Guardar la presentación en el formato Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño descomprimido de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 elevan estos límites a 2^64.

El método [IPptxOptions::set_Zip64Mode] le permite elegir cuándo usar las extensiones del formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- `IfNecessary` utiliza las extensiones del formato ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- `Never` nunca utiliza las extensiones del formato ZIP64.
- `Always` siempre utiliza las extensiones del formato ZIP64.

El siguiente código muestra cómo guardar una presentación como archivo PPTX con las extensiones del formato ZIP64 habilitadas:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Al guardar con `Zip64Mode.Never`, se lanza una [PptxException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides proporciona el método [PptxOptions::set_CompressionLevel], que le permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- **None**: No se aplica compresión. Los archivos se almacenan tal cual.
- **Level1**: La compresión más rápida con la relación de compresión más baja.
- **Level2**: Compresión más rápida con una relación de compresión ligeramente mejor que **Level1**.
- **Level3**: Ofrece mejor compresión que **Level2** con un impacto moderado en el tiempo de procesamiento.
- **Level4**: Ofrece mejor compresión que **Level3**.
- **Level5**: Ofrece una compresión mejorada respecto a **Level4** con tiempo de procesamiento adicional.
- **Level6**: Compresión estándar que ofrece un buen equilibrio entre velocidad de procesamiento y tamaño del archivo. Este es el *nivel de compresión predeterminado*.
- **Level7**: Ofrece mejor compresión que **Level6** con procesamiento más lento.
- **Level8**: Ofrece mejor compresión que **Level7**.
- **Level9**: Compresión máxima. Produce el archivo de menor tamaño al costo del mayor tiempo de procesamiento.

El siguiente ejemplo muestra cómo guardar una presentación como archivo PPTX *sin compresión*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Guardar presentaciones sin actualizar la miniatura**

El método [PptxOptions::set_RefreshThumbnail] controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código siguiente, la presentación se guarda en PPTX sin actualizar su miniatura.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.
{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

La interfaz [IProgressCallback] se utiliza a través del método `set_ProgressCallback` expuesto por la interfaz [ISaveOptions] y la clase abstracta [SaveOptions]. Asigne una implementación de [IProgressCallback] con `set_ProgressCallback` para recibir actualizaciones del progreso de guardado como porcentaje.

Los fragmentos de código siguientes muestran cómo usar `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Utilice aquí el valor del porcentaje de progreso.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
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

// La clase de devolución de llamada de progreso definida arriba.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) que utiliza su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el “guardado rápido” (guardado incremental) para que solo se escriban los cambios?**

No. Guardar crea el archivo de destino completo cada vez; el “guardado rápido” incremental no está soportado.

**¿Es seguro en cuanto a hilos guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) [no es segura para hilos](/slides/es/cpp/multithreading/); guárdela desde un único hilo.

**¿Qué ocurre con los hipervínculos y los archivos enlazados externamente al guardar?**

[Los hipervínculos](/slides/es/cpp/manage-hyperlinks/) se conservan. Los archivos enlazados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/cpp/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.