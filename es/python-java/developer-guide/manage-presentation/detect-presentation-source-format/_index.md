---
title: Determinar el formato original de la presentación en Python vía Java
linktitle: Formato de origen
type: docs
weight: 35
url: /es/python-java/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Leer el formato original de una presentación cargada en Python mediante Java con Aspose.Slides para Python mediante Java, comparar las APIs de detección y gestionar archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, llame al método [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSourceFormat) para determinar su formato original. Úselo cuando el procesamiento posterior dependa del formato desde el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no cambia el formato de origen de la instancia existente.

Los ejemplos requieren Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible. Cada ejemplo inicia la JVM si no está ya en ejecución.

## **Leer el formato de origen de un archivo**

Este ejemplo requiere un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSourceFormat), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Reconocer los valores compatibles**

La clase [SourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/sourceformat/) define constantes enteras que distinguen los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentación Office Open XML |
| `Pptm` | `.pptm` | presentación Office Open XML con macros |
| `Pps` | `.pps` | presentación de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | presentación de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | presentación de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | plantilla Office Open XML |
| `Potm` | `.potm` | plantilla Office Open XML con macros |
| `Odp` | `.odp` | presentación OpenDocument |
| `Otp` | `.otp` | plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | presentación OpenDocument XML plano |
| `Xml` | `.xml` | presentación PowerPoint XML |

## **Leer el formato de origen de un flujo**

Este ejemplo requiere un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o una matriz de bytes cargada. El constructor [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) recibe solo el flujo. Python lee los bytes del archivo, y JPype los convierte a una matriz de bytes Java para el flujo de memoria Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS y POT usan el mismo formato binario subyacente. Cuando se carga mediante la ruta del archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede informarse como `SourceFormat.Ppt`; el ejemplo de PPS anterior muestra el valor entero de `SourceFormat.Ppt`.

Si su aplicación debe preservar la distinción, conserve el nombre de archivo original o los metadatos de subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debe ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la detección antes y después de la carga**

Utilice [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) y [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#getLoadFormat) cuando necesite inspeccionar un archivo antes de cargar su modelo de objeto de presentación completo. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSourceFormat) cuando la instancia ya exista.

Este ejemplo requiere `sample.pptx` e imprime los valores enteros de `LoadFormat.Pptx` y `SourceFormat.Pptx`, respectivamente. En producción, elija la API adecuada para su etapa de procesamiento; una presentación ya cargada no necesita una segunda inspección solo para obtener su formato de origen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Los resultados usan constantes de diferentes clases: [LoadFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/sourceformat/). No compare sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede informarse como `LoadFormat.Unknown` antes de la carga y como `SourceFormat.Xml` después de la carga.

## **Mantener los formatos de origen y salida por separado**

Este ejemplo requiere `sample.pptx` y escribe `converted.odp`. Imprime el valor entero de `SourceFormat.Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde la salida ODP informa `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Una presentación creada desde cero con `Presentation()` informa `SourceFormat.Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Realice un seguimiento de si su aplicación creó o cargó la instancia por separado si esa distinción es importante.

## **Mapear un formato de origen a una extensión**

El siguiente ejemplo requiere `sample.pptx`. Asocia cada valor actualmente compatible de [SourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/sourceformat/) a una extensión convencional, sin analizar el nombre de archivo de entrada. El valor de reserva evita asignar silenciosamente una extensión a un valor no reconocido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Este mapeo no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para guardar realmente, seleccione explícitamente un [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) o use la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos guardando y reabriendo**

Este ejemplo autónomo crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Vuelve a abrir cada salida tanto por ruta como mediante un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, cargar por ruta informa `Pps`, mientras que cargar los mismos bytes sin un nombre de archivo informa `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes. Los nombres denotan constantes; los ejemplos en Python imprimen sus valores enteros:

| Formato guardado | SourceFormat a partir de una ruta de archivo | SourceFormat a partir de un flujo sin nombre |
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

El contenido PPS/POT se identifica como `Ppt` para flujos sin nombre. La tabla describe la identificación del formato, no la preservación de todas las características de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Puede un flujo distinguir siempre una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Conserve el nombre de archivo o los metadatos de subtipo por separado cuando se requiera esa distinción.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSourceFormat). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspección antes de la carga.