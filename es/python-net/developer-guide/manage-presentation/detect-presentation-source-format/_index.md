---
title: Determinar el formato original de la presentación en Python
linktitle: Formato de origen
type: docs
weight: 35
url: /es/python-net/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Leer el formato original de una presentación cargada en Python con Aspose.Slides para Python mediante .NET, comparar APIs de detección y manejar archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, lea la propiedad de solo lectura [Presentation.source_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/source_format/) para determinar su formato original. Úsela cuando el procesamiento posterior dependa del formato con el que se cargó la instancia actual.

El formato de origen es diferente del [SaveFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación utilizando [Presentation.source_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/source_format/), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Reconocer los valores admitidos**

La enumeración [SourceFormat] distingue los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `PPT` | `.ppt` | Presentación PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Presentación Office Open XML |
| `PPTM` | `.pptm` | Presentación Office Open XML con macros |
| `PPS` | `.pps` | Presentación de diapositivas PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Presentación de diapositivas Office Open XML |
| `PPSM` | `.ppsm` | Presentación de diapositivas Office Open XML con macros |
| `POT` | `.pot` | Plantilla PowerPoint 97–2003 |
| `POTX` | `.potx` | Plantilla Office Open XML |
| `POTM` | `.potm` | Plantilla Office Open XML con macros |
| `ODP` | `.odp` | Presentación OpenDocument |
| `OTP` | `.otp` | Plantilla de presentación OpenDocument |
| `FODP` | `.fodp` | Presentación ODF XML plano |
| `XML` | `.xml` | Presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o una matriz de bytes cargada. El constructor [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) recibe solo el flujo.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS y POT utilizan el mismo formato binario subyacente. Al cargar por ruta de archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede reportarse como `SourceFormat.PPT`; el ejemplo de PPS anterior informa `PPT`.

Si su aplicación debe conservar la distinción, conserve el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de cargar**

Utilice [PresentationFactory.get_presentation_info] y [PresentationInfo.load_format] cuando necesite inspeccionar un archivo antes de cargar su modelo de objeto de presentación completo. Utilice [Presentation.source_format] cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` y muestra `PPTX` para ambas comprobaciones. En producción, elija la API adecuada para su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección sólo para obtener su formato de origen.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Los resultados tienen tipos de enumeración diferentes: [LoadFormat] y [SourceFormat]. No los compare convirtiendo sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. En la comprobación de guardar y volver a abrir descrita a continuación, PowerPoint XML se informó como `LoadFormat.UNKNOWN` antes de cargar y como `SourceFormat.XML` después de cargar.

## **Mantener separados los formatos de origen y de salida**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Muestra `PPTX` tanto antes como después de guardar la instancia original. Sólo la nueva instancia cargada desde la salida ODP informa `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Una presentación creada desde cero con `slides.Presentation()` informa `SourceFormat.PPTX`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Registre si su aplicación creó o cargó la instancia por separado si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asocia cada valor de [SourceFormat] actualmente admitido a una extensión convencional, sin analizar el nombre de archivo de entrada. La alternativa evita asignar silenciosamente una extensión a un valor no reconocido.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Esta asignación no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para guardar realmente, seleccione un [SaveFormat] explícitamente, o use la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y volviendo a abrir**

Este ejemplo autónomo crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Vuelve a abrir cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, la carga por ruta informa `PPS`, mientras que la carga de los mismos bytes sin nombre de archivo informa `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

La misma comprobación con todos los formatos enumerados anteriormente produjo estos resultados para presentaciones generadas con extensiones coincidentes:

| Formato guardado | SourceFormat a partir de una ruta de archivo | SourceFormat a partir de un flujo sin nombre |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectivamente | Igual que la ruta de archivo |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectivamente | Igual que la ruta de archivo |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectivamente | Igual que la ruta de archivo |
| ODP, OTP | `ODP`, `OTP` respectivamente | Igual que la ruta de archivo |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

En estas comprobaciones, la única normalización del formato de origen fue PPS/POT a `PPT` para flujos sin nombre. La tabla describe la identificación de formatos, no la preservación de cada característica de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `PPTX`. Una instancia cargada desde el archivo ODP guardado informa `ODP`.

**¿Puede un flujo siempre distinguir una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Mantenga el nombre de archivo o los metadatos de subtipo por separado cuando se requiera esa distinción.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation.source_format]. Utilice [PresentationFactory.get_presentation_info] para la inspección antes de cargar.