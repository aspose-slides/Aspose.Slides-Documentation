---
title: Guardar presentaciones en Python mediante Java
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/python-java/save-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Guarde presentaciones PowerPoint y OpenDocument en archivos o flujos en Python mediante Java con Aspose.Slides, y configure la salida PPTX y el informe del progreso."
---
## **Visión general**

Después de crear una presentación o [abrir una existente](/slides/es/python-java/open-presentation/), use el método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para escribir el resultado. Aspose.Slides for Python via Java puede guardar una presentación en un archivo o flujo en formatos PowerPoint, OpenDocument, PDF y otros. Las siguientes secciones cubren las operaciones de guardado estándar y las opciones disponibles para la salida PPTX.

## **Guardar presentaciones en archivos**

Para guardar una presentación en un archivo, pase la ruta de salida y un valor [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save). El valor de formato determina el tipo de archivo que Aspose.Slides crea.

El siguiente ejemplo crea una presentación y la guarda como un archivo PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Añadir o modificar el contenido de la presentación aquí.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Guardar presentaciones en su formato original**

En una aplicación de procesamiento por lotes, el formato de entrada puede no ser conocido de antemano. Después de cargar un archivo, lea su formato original mediante el método [Presentation.getSourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSourceFormat). Pase el valor [SourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/sourceformat/) resultante a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/#toSaveFormat) para obtener el valor [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) correspondiente, y luego use [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para escribir la presentación modificada.

El siguiente ejemplo completo procesa cada archivo en un directorio de entrada, actualiza su título y lo guarda en un directorio de salida en el formato desde el que se cargó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideutil/#toSaveFormat) asigna PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP y PowerPoint XML a sus formatos de guardado de presentación correspondientes. Solo asigna formatos de origen de presentación; no está pensado para seleccionar formatos de exportación como PDF, HTML, TIFF o imágenes. Pasar un valor [SourceFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/sourceformat/) no compatible o inválido produce una [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Los archivos legados PPT, PPS y POT utilizan el mismo contenedor binario. Cuando una presentación de este tipo se carga desde un flujo sin extensión de archivo, un archivo PPS o POT puede identificarse como PPT. Si es necesario conservar estos subtipos heredados, mantenga el nombre de archivo original o los metadatos de formato por separado y úselos al elegir el nombre y formato del archivo de salida.

## **Guardar presentaciones en flujos**

Para escribir una presentación sin depender de una ruta de archivo final, pase un flujo de escritura y un valor [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) al método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save). Este enfoque es útil cuando la salida debe devolverse desde un servicio web, almacenarse en una base de datos o procesarse en memoria.

El siguiente ejemplo guarda una nueva presentación en un flujo de archivo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Guardar presentaciones con un tipo de vista predefinido**

Puede especificar la vista en la que PowerPoint abre inicialmente una presentación guardada. Utilice el método [ViewProperties.setLastView](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewproperties/#setLastView) con un valor [ViewType](https://reference.aspose.com/slides/es/python-java/aspose.slides/viewtype/) antes de guardar.

El siguiente ejemplo configura la vista Slide Master como vista inicial:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Guardar presentaciones en el formato estricto Office Open XML**

Para crear un archivo PPTX que cumpla con el perfil Strict de Office Open XML, cree una instancia de [PptxOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxoptions/) y utilice su método [setConformance](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxoptions/#setConformance) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Luego pase las opciones al método [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo ZIP estándar limita el tamaño comprimido y descomprimido de cada entrada, el tamaño total del archivo y el número de entradas. Como un archivo PPTX es un archivo ZIP, una presentación muy grande puede superar esos límites. Las extensiones ZIP64 aumentan los límites de tamaño y de número de entradas aplicables.

Utilice el método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxoptions/#setZip64Mode) para controlar si Aspose.Slides escribe extensiones ZIP64:
- [IfNecessary](https://reference.aspose.com/slides/es/python-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo cuando la presentación supera los límites estándar de ZIP. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/python-java/aspose.slides/zip64mode/#Never) deshabilita las extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/es/python-java/aspose.slides/zip64mode/#Always) siempre escribe extensiones ZIP64.

El siguiente ejemplo siempre habilita las extensiones ZIP64 para la presentación de salida:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PpptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Si se usa [Zip64Mode.Never](https://reference.aspose.com/slides/es/python-java/aspose.slides/zip64mode/#Never) y la presentación no puede ajustarse a los límites estándar de ZIP, la operación de guardado lanza una [PptxException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Para la salida PPTX, puede equilibrar la velocidad de guardado con el tamaño del archivo usando el método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxoptions/#setCompressionLevel). La clase [CompressionLevel](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/) ofrece los siguientes valores:
- [None](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#None) almacena datos sin compresión.
- [Level1](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level1) proporciona la compresión más rápida y la salida comprimida más grande.
- [Level2](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level2) hasta [Level5](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level5) favorecen progresivamente una salida más pequeña sobre la velocidad de guardado.
- [Level6](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level6) equilibra la velocidad de guardado y el tamaño del archivo. Este es el nivel predeterminado.
- [Level7](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level7) y [Level8](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level8) favorecen aún más una salida más pequeña sobre la velocidad de guardado.
- [Level9](https://reference.aspose.com/slides/es/python-java/aspose.slides/compressionlevel/#Level9) ofrece la compresión más fuerte y requiere el mayor tiempo de procesamiento.

El siguiente ejemplo guarda una presentación sin compresión:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

El siguiente ejemplo usa el nivel máximo de compresión:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Guardar presentaciones sin actualizar la miniatura**

Al guardar una presentación como PPTX, el método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla la miniatura del documento:
- `True` regenera la miniatura durante la operación de guardado. Este es el valor predeterminado.
- `False` conserva la miniatura existente. Si la presentación no tiene miniatura, Aspose.Slides no genera una.

El siguiente ejemplo guarda una presentación sin actualizar su miniatura:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Desactivar la actualización de la miniatura puede reducir el tiempo necesario para guardar un archivo PPTX.
{{% /alert %}}

## **Informar del progreso del guardado como porcentaje**

Para supervisar una operación de guardado, registre un controlador de progreso de Python mediante `jpype.JProxy` y páselo al método [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides entonces llama al método `reporting` del controlador con valores de progreso durante la exportación.

El siguiente ejemplo informa del progreso de una exportación a PDF en la consola:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) gratuito construido con la API Aspose.Slides. Guarda diapositivas seleccionadas de una presentación como archivos PPT o PPTX separados.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite guardado incremental o “guardado rápido”?**

No. Cada operación de guardado escribe un archivo de salida completo en lugar de actualizar solo las partes modificadas.

**¿Pueden varios hilos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) [no es segura para subprocesos](/slides/es/python-java/multithreading/). Acceda y guarde cada instancia solo desde un hilo a la vez.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar una presentación?**

[Hyperlinks](/slides/es/python-java/manage-hyperlinks/) permanecen en la presentación. Aspose.Slides no copia los archivos vinculados externamente, por lo que la presentación guardada debe seguir pudiendo acceder a sus ubicaciones.

**¿Puedo guardar metadatos del documento como autor, título, empresa y fecha de creación?**

Sí. Configure las [propiedades del documento](/slides/es/python-java/presentation-properties/) apropiadas antes de guardar, y Aspose.Slides las escribe en el archivo de salida.