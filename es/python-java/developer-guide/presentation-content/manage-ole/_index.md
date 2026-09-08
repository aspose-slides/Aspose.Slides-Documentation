---
title: Gestionar OLE en presentaciones usando Python
linktitle: Gestionar OLE
type: docs
weight: 40
url: /es/python-java/manage-ole/
keywords:
- objeto OLE
- Vinculación y incrustación de objetos
- añadir OLE
- incrustar OLE
- añadir objeto
- incrustar objeto
- añadir archivo
- incrustar archivo
- objeto vinculado
- archivo vinculado
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
description: "Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides para Python a través de Java. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación mediante vinculación o incrustación.
{{% /alert %}}

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un ícono. En este caso, al hacer doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides para Python a través de Java](https://products.aspose.com/slides/es/python-java/) permite insertar Objetos OLE en diapositivas como marcos de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/)).

## **Agregar marcos de objeto OLE a diapositivas**

Suponiendo que ya ha creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE utilizando Aspose.Slides para Python a través de Java, puede hacerlo de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Lea el archivo de Excel como una matriz de bytes.
4. Agregue el [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.
5. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo siguiente, añadimos un gráfico de un archivo Excel a una diapositiva como un marco de objeto OLE utilizando Aspose.Slides para Python a través de Java. **Nota** que el constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleembeddeddatainfo/) recibe una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

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

    # Preparar datos para el objeto OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Añadir el marco del objeto OLE a la diapositiva.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Agregar marcos de objeto OLE vinculados**

Aspose.Slides para Python a través de Java le permite añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) sin incrustar datos, sino solo con un vínculo al archivo.

Este código Python le muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) con un archivo Excel vinculado a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añadir un marco de objeto OLE con un archivo Excel vinculado.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a marcos de objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtenga la referencia de la diapositiva usando su índice.
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/). En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego verificamos que el objeto fuera un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/). Este era el marco de objeto OLE deseado para ser accedido.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.

En el siguiente ejemplo, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo.

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
        # Obtener la extensión del archivo incrustado.
        # ...

finally:
    presentation.dispose()
```

### **Acceder a las propiedades del marco de objeto OLE vinculado**

Aspose.Slides le permite acceder a las propiedades del marco de objeto OLE vinculado.

Este código Python le muestra cómo comprobar si un objeto OLE está vinculado y luego obtener la ruta al archivo vinculado:

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

        # Comprobar si el objeto OLE está vinculado.
        if ole_frame.isObjectLink():
            # Imprimir la ruta completa al archivo vinculado.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Imprimir la ruta relativa al archivo vinculado si está presente.
            # Sólo las presentaciones PPT pueden contener la ruta relativa.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Cambiar los datos del objeto OLE**

{{% alert color="info" title="Note" %}}
En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) .
2. Obtenga la referencia de la diapositiva mediante su índice.
3. Acceda a la forma del marco de objeto OLE. En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego verificamos que el objeto fuera un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/). Este era el marco de objeto OLE deseado para ser accedido.
4. Una vez accedido al marco de objeto OLE, puede realizar cualquier operación sobre él.
5. Cree un objeto [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) y acceda a los datos OLE.
6. Acceda a la [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) deseada y modifique los datos.
7. Guarde el [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) actualizado en un flujo.
8. Cambie los datos del objeto OLE a partir del flujo.

En el siguiente ejemplo, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

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

Además de los gráficos de Excel, Aspose.Slides para Python a través de Java le permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita al usuario seleccionar un programa apropiado para abrirlo.

Este código Python le muestra cómo incrustar HTML y ZIP en una diapositiva:

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

Al trabajar con presentaciones, puede ser necesario reemplazar objetos OLE antiguos por unos nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides para Python a través de Java le permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código Python le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

## **Establecer imágenes de ícono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa que consiste en una imagen de ícono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea utilizar una imagen y texto específicos como elementos en la vista previa, puede establecer la imagen de ícono y el título mediante Aspose.Slides para Python a través de Java.

Este código Python le muestra cómo establecer la imagen de ícono y el título para un objeto incrustado:

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

## **Evitar que un marco de objeto OLE sea redimensionado y reubicado**

Después de añadir un objeto OLE vinculado a una diapositiva de la presentación, al abrir la presentación en PowerPoint puede aparecer un mensaje que le pide actualizar los vínculos. Al hacer clic en el botón "Update Links" el tamaño y la posición del marco de objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, establezca el método [setUpdateAutomatic](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) de la clase [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) a `False`:

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

Aspose.Slides para Python a través de Java le permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) que contenga los objetos OLE que desea extraer.
2. Recorra todas las formas de la presentación y acceda a las formas [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/).
3. Acceda a los datos de los archivos incrustados desde los marcos de objeto OLE y escríbalos en el disco.

Este código Python le muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:

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

## **FAQ**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imágenes?**

Lo que se muestra en la diapositiva se renderiza: el ícono/imagen de sustitución (vista previa). El contenido OLE "en vivo" no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia deseada en el PDF exportado.

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/python-java/applying-protection-to-presentation/). No es encriptación, pero impide eficazmente ediciones y movimientos accidentales.

**¿Por qué un objeto Excel vinculado "salta" o cambia de tamaño al abrir la presentación?**

PowerPoint puede refrescar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Solución funcional para el redimensionado de hojas de cálculo](/slides/es/python-java/working-solution-for-worksheet-resizing/): ajuste el marco al rango, o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.

**¿Se conservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?**

En PPTX, la información de "ruta relativa" no está disponible—solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas fiables/URIs accesibles o la incrustación.