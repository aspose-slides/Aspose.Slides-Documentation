---
title: Gestionar OLE en presentaciones usando Python
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/python-java/manage-ole/
keywords:
- Objeto OLE
- Vinculación y incrustación de objetos
- añadir OLE
- incrustar OLE
- añadir objeto
- incrustar objeto
- añadir archivo
- incrustar archivo
- objeto enlazado
- archivo enlazado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en PowerPoint y archivos OpenDocument con Aspose.Slides para Python mediante Java. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" title="Nota" %}}
OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante enlaces o incrustación.
{{% /alert %}}

Considere un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un icono. En este caso, al hacer doble clic en el icono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides para Python mediante Java](https://products.aspose.com/slides/es/python-java/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya ha creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides para Python mediante Java, puede hacerlo de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Lea el archivo de Excel como una matriz de bytes.
4. Añada el [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) a la diapositiva con la matriz de bytes y otra información sobre el objeto OLE.
5. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo siguiente, añadimos un gráfico de un archivo de Excel a una diapositiva como un marco de objeto OLE usando Aspose.Slides para Python mediante Java. **Nota** que el constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleembeddeddatainfo/) toma una extensión de objeto incrustable como su segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Preparar los datos para el objeto OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Añadir el marco de objeto OLE a la diapositiva.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Agregar marcos de objetos OLE enlazados**

Aspose.Slides para Python mediante Java permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) con un enlace al archivo en lugar de datos incrustados.

Este código Python muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) con un archivo Excel enlazado a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir un marco de objeto OLE con un archivo Excel enlazado.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de la siguiente manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Acceda a la forma [OleObjectFrame]. En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego verificamos que el objeto era un [OleObjectFrame]. Este era el marco de objeto OLE deseado para acceder.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Obtener los datos del archivo incrustado.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Obtener la extensión del archivo incrustado.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Acceder a las propiedades del marco de objeto OLE enlazado**

Aspose.Slides permite acceder a las propiedades del marco de objeto OLE enlazado.

Este código Python muestra cómo comprobar si un objeto OLE está enlazado y luego obtener la ruta al archivo enlazado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Comprobar si el objeto OLE está enlazado.
        if ole_frame.isObjectLink():
            # Imprimir la ruta completa del archivo enlazado.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Imprimir la ruta relativa del archivo enlazado si está presente.
            # Sólo las presentaciones PPT pueden contener la ruta relativa.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Cambiar datos del objeto OLE**

{{% alert color="info" title="Nota" %}}
En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de la siguiente manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Acceda a la forma del marco de objeto OLE. En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego verificamos que el objeto era un [OleObjectFrame]. Este era el marco de objeto OLE deseado para acceder.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.
5. Cree un objeto [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) y acceda a los datos OLE.
6. Acceda a la [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) deseada y modifique los datos.
7. Guarde el [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) actualizado en un flujo.
8. Cambie los datos del objeto OLE a partir del flujo.

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Leer los datos del objeto OLE como un objeto Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modificar los datos del libro de trabajo.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Cambiar los datos del objeto del marco OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Incrustar otros tipos de archivo en diapositivas**

Además de los gráficos de Excel, Aspose.Slides para Python mediante Java permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando el usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le pide que seleccione un programa adecuado para abrirlo.

Este código Python muestra cómo incrustar HTML y ZIP en una diapositiva:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por otros nuevos o reemplazar un objeto OLE no compatible por uno compatible. Aspose.Slides para Python mediante Java permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código Python muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Cambiar el tipo de archivo a ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa constituida por una imagen de icono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos en la vista previa, puede establecer la imagen del icono y el título mediante Aspose.Slides para Python mediante Java.

Este código Python muestra cómo establecer la imagen del icono y el título para un objeto incrustado:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Añadir una imagen a los recursos de la presentación.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Establecer un título y la imagen para la vista previa del OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Evitar que un marco de objeto OLE sea redimensionado y recolocado**

Después de agregar un objeto OLE enlazado a una diapositiva de presentación, al abrir la presentación en PowerPoint, puede aparecer un mensaje solicitando actualizar los enlaces. Al hacer clic en el botón "Update Links" el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE enlazado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, establezca el método [setUpdateAutomatic](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) de la clase [OleObjectFrame] a `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extraer archivos incrustados**

Aspose.Slides para Python mediante Java permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que contenga los objetos OLE que desea extraer.
2. Recorra todas las formas de la presentación y acceda a las formas [OleObjectFrame].
3. Acceda a los datos de los archivos incrustados a partir de los marcos de objeto OLE y escríbalos en disco.

Este código Python muestra cómo extraer los archivos incrustados en una diapositiva como objetos OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?**

Lo que es visible en la diapositiva se renderiza: el icono/imagen sustituta (vista previa). El contenido OLE "en vivo" no se ejecuta durante la renderización. Si es necesario, establezca su propia imagen de vista previa para asegurar la apariencia esperada en el PDF exportado.

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no lo muevan/editen en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/python-java/applying-protection-to-presentation/). No se trata de encriptación, pero evita eficazmente ediciones y movimientos accidentales.

**¿Por qué un objeto Excel enlazado "salta" o cambia de tamaño al abrir la presentación?**

PowerPoint puede refrescar la vista previa del OLE enlazado. Para una apariencia estable, siga las prácticas de la [Solución funcional para redimensionar hojas de cálculo](/slides/es/python-java/working-solution-for-worksheet-resizing/): ajuste el marco al rango, o escale el rango a un marco fijo y establezca una imagen sustituta adecuada.

**¿Se conservarán las rutas relativas para objetos OLE enlazados en el formato PPTX?**

En PPTX, la información de "ruta relativa" no está disponible—solo la ruta completa. Las rutas relativas aparecen en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas fiables/URIs accesibles o la incrustación.