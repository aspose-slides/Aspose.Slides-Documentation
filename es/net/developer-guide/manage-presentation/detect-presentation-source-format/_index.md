---
title: Determinar el formato original de la presentación en .NET
linktitle: Formato de origen
type: docs
weight: 35
url: /es/net/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en C# con Aspose.Slides para .NET, compare las APIs de detección y maneje archivos, flujos y formatos heredados."
---
## **Resumen**

Después de cargar una presentación, lea la propiedad de solo lectura [Presentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/) para determinar su formato original. La propiedad también está disponible a través de [IPresentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/sourceformat/). Utilícela cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Reconocer los valores compatibles**

La enumeración [SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/sourceformat/) diferencia los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentación Office Open XML |
| `Pptm` | `.pptm` | Presentación Office Open XML con macros |
| `Pps` | `.pps` | Presentación de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Presentación de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | Presentación de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | Plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | Plantilla Office Open XML |
| `Potm` | `.potm` | Plantilla Office Open XML con macros |
| `Odp` | `.odp` | Presentación OpenDocument |
| `Otp` | `.otp` | Plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | Presentación ODF XML plano |
| `Xml` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o una matriz de bytes cargada. El constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) recibe solo el flujo.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS y POT utilizan el mismo formato binario subyacente. Cuando se carga por ruta de archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado PPS y POT puede reportarse como `SourceFormat.Ppt`; el ejemplo PPS anterior informa `Ppt`.

Si su aplicación debe conservar la distinción, mantenga el nombre de archivo original o los metadatos de subtipo por separado. La extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de cargar**

Utilice [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) y [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/loadformat/) cuando necesite inspeccionar un archivo antes de cargar su modelo de objetos de presentación completo. Utilice [Presentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` y muestra `Pptx` en ambas comprobaciones. En producción, elija la API adecuada para su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección únicamente para obtener su formato de origen.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Los resultados tienen tipos de enumeración diferentes: [LoadFormat](https://reference.aspose.com/slides/es/net/aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/sourceformat/). No los compare convirtiendo sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. En la comprobación de guardar y volver a abrir descrita a continuación, PowerPoint XML se informó como `LoadFormat.Unknown` antes de cargar y como `SourceFormat.Xml` después de cargar.

## **Mantener separados los formatos de origen y de salida**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Muestra `Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde la salida ODP informa `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Una presentación creada desde cero con `new Presentation()` informa `SourceFormat.Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Controle por separado si su aplicación creó o cargó la instancia si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asocia cada valor actualmente compatible de [SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/sourceformat/) a una extensión convencional, sin analizar el nombre de archivo de entrada. El valor predeterminado evita asignar silenciosamente una extensión a un valor no reconocido.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Este mapeo no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para guardar realmente, seleccione explícitamente un [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/) o utilice la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/net/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y volviendo a abrir**

Este ejemplo autocontenido crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Vuelve a abrir cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, cargar por ruta informa `Pps`, mientras que cargar los mismos bytes sin nombre de archivo informa `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

La misma comprobación con todos los formatos listados arriba produjo los siguientes resultados para presentaciones generadas con extensiones coincidentes:

| Formato guardado | SourceFormat desde una ruta de archivo | SourceFormat desde un flujo sin nombre |
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

En estas comprobaciones, la única normalización del formato de origen fue PPS/POT a `Ppt` para flujos sin nombre. La tabla describe la identificación de formatos, no la conservación de cada característica de presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Un flujo siempre puede distinguir una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando se requiera esa distinción.

**¿Qué API debería usar si la presentación ya está cargada?**

Lea [Presentation.SourceFormat](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sourceformat/). Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) para inspección antes de cargar.