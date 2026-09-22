---
title: Determinar el formato original de la presentación en C++
linktitle: Formato de origen
type: docs
weight: 35
url: /es/cpp/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en C++ con Aspose.Slides para C++, compare las API de detección y maneje archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, llame a [Presentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sourceformat/) para determinar su formato original. El método también está disponible a través de [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_sourceformat/). Úselo cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sourceformat/), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Reconocer los valores admitidos**

La enumeración [SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/sourceformat/) distingue los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentación Office Open XML |
| `Pptm` | `.pptm` | Presentación Office Open XML con macros |
| `Pps` | `.pps` | Show de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Show de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | Show de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | Plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | Plantilla Office Open XML |
| `Potm` | `.potm` | Plantilla Office Open XML con macros |
| `Odp` | `.odp` | Presentación OpenDocument |
| `Otp` | `.otp` | Plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | Presentación ODF XML plano |
| `Xml` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria simula una entrada recibida sin nombre de archivo, como un valor de base de datos o un arreglo de bytes cargado. El constructor de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) recibe solo el flujo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS y POT usan el mismo formato binario subyacente. Cuando se carga por ruta de archivo, la extensión puede ayudar a distinguir un show de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede reportarse como `SourceFormat::Ppt`; el ejemplo de PPS anterior informa `Ppt`.

Si su aplicación debe preservar la distinción, conserve el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de cargar**

Utilice [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/getpresentationinfo/) y [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_loadformat/) cuando necesite inspeccionar un archivo antes de cargar su modelo de objeto de presentación completo. Utilice [Presentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sourceformat/) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` e imprime `Pptx` para ambas comprobaciones. En producción, elija la API adecuada a su fase de procesamiento; una presentación ya cargada no necesita una segunda inspección solo para obtener su formato de origen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Los resultados tienen diferentes tipos de enumeración: [LoadFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/sourceformat/). No los compare convirtiendo sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede reportarse como `LoadFormat::Unknown` antes de cargar y como `SourceFormat::Xml` después de cargar.

## **Mantener los formatos de origen y de salida separados**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Imprime `Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde la salida ODP informa `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Una presentación creada desde cero con `MakeObject<Presentation>()` informa `SourceFormat::Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no una evidencia de que se haya cargado un archivo PPTX. Controle por separado si su aplicación creó o cargó la instancia si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asocia cada valor actualmente admitido de [SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/sourceformat/) a una extensión convencional, sin analizar el nombre de archivo de entrada. El valor de reserva evita asignar silenciosamente una extensión a un valor no reconocido.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Este mapeo no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga desde un flujo. Para el guardado real, seleccione un [SaveFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) explícitamente, o use la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y reabriendo**

Este ejemplo autónomo crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Reabre cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, cargar por ruta informa `Pps`, mientras que cargar los mismos bytes sin nombre de archivo informa `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes:

| Formato guardado | SourceFormat desde ruta de archivo | SourceFormat desde flujo sin nombre |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual que la ruta de archivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual que la ruta de archivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual que la ruta de archivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual que la ruta de archivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

El contenido heredado PPS/POT se normaliza a `Ppt` para flujos sin nombre. La tabla describe la identificación del formato, no la preservación de todas las características de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Un flujo siempre puede distinguir una presentación heredada, un show de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando se requiera esa distinción.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation::get_SourceFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sourceformat/). Use [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/getpresentationinfo/) para inspección antes de cargar.