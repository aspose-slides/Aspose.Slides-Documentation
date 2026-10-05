---
title: Administrar OLE en presentaciones usando Python
linktitle: Administrar OLE
type: docs
weight: 40
url: /es/python-net/manage-ole/
keywords:
- objeto OLE
- Vinculación e incrustación de objetos
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
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en PowerPoint y archivos OpenDocument con Aspose.Slides para Python mediante .NET. Incruste, actualice y exporte contenido OLE sin problemas."
---
## **Introducción**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se enlacen o incrusten en otra.

{{% /alert %}}

Por ejemplo, un gráfico creado en Microsoft Excel y colocado en una diapositiva de PowerPoint es un objeto OLE.

- Un objeto OLE puede aparecer como un icono. Al hacer doble clic en el icono se abre el objeto en su aplicación asociada (p. ej., Excel) o se le solicita que elija una aplicación para abrirlo o editarlo.
- Un objeto OLE puede mostrar su contenido (por ejemplo, un gráfico). En este caso, PowerPoint activa el objeto incrustado, carga la interfaz del gráfico y permite editar los datos del gráfico dentro de PowerPoint.

Aspose.Slides for Python le permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Añadir objetos OLE a diapositivas**

Si ya ha creado un gráfico en Microsoft Excel y desea incrustarlo en una diapositiva como un marco de objeto OLE mediante Aspose.Slides for Python, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva por su índice.
1. Lea el archivo de Excel en una matriz de bytes.
1. Añada un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a la diapositiva, proporcionando la matriz de bytes y otros detalles del objeto OLE.
1. Guarde la presentación modificada como archivo PPTX.

En el ejemplo siguiente, un gráfico de un archivo Excel se incrusta en una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Nota:** El constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) recibe la extensión del archivo del objeto incrustable como su segundo parámetro. PowerPoint usa esta extensión para identificar el tipo de archivo y seleccionar la aplicación adecuada para abrir el objeto OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Preparar los datos para el objeto OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Añadir un marco de objeto OLE a la diapositiva.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Añadir objetos OLE vinculados**

Aspose.Slides for Python le permite añadir un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) que enlaza a un archivo en lugar de incrustar sus datos.

El siguiente ejemplo en Python muestra cómo añadir un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) vinculado a un archivo Excel en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Añadir un marco de objeto OLE con un archivo Excel vinculado.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a él de la siguiente manera:

1. Cargue la presentación que contiene el objeto OLE incrustado creando una instancia de la clase Presentation.
1. Obtenga una referencia a la diapositiva por su índice.
1. Acceda a la forma OleObjectFrame.
1. Una vez que tenga el marco del objeto OLE, realice las operaciones requeridas sobre él.

El ejemplo a continuación accede al marco del objeto OLE —un gráfico Excel incrustado— y recupera sus datos de archivo. En este ejemplo, utilizamos un PPTX que tiene una única forma en la primera diapositiva.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Obtener los datos del archivo incrustado.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Obtener la extensión del archivo incrustado.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Acceder a propiedades de objetos OLE vinculados**

Aspose.Slides le permite acceder a las propiedades de un marco de objeto OLE vinculado.

El siguiente ejemplo en Python verifica si un objeto OLE está vinculado y, de ser así, recupera la ruta del archivo vinculado:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Comprobar si el objeto OLE está vinculado.
        if ole_frame.is_object_link:
            # Imprimir la ruta completa del archivo vinculado.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Imprimir la ruta relativa del archivo vinculado, si está presente.
            # Sólo las presentaciones .ppt pueden contener una ruta relativa.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Cambiar datos de objeto OLE**

{{% alert color="info" title="Note" %}}

En esta sección, el ejemplo de código a continuación utiliza [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a él y modificar sus datos de la siguiente manera:

1. Cargue la presentación creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la diapositiva de destino por su índice.
1. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Una vez que tenga el marco del objeto OLE, realice las operaciones requeridas sobre él.
1. Cree un objeto `Workbook` y lea los datos OLE.
1. Abra la `Worksheet` deseada y edite los datos.
1. Guarde el `Workbook` actualizado en un flujo.
1. Reemplace los datos del objeto OLE usando ese flujo.

En el ejemplo siguiente, se accede a un marco de objeto OLE (un gráfico Excel incrustado) y se modifican sus datos de archivo para actualizar el gráfico. La muestra usa un PPTX creado previamente que contiene una única forma en la primera diapositiva.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Leer los datos del objeto OLE como un objeto Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modificar los datos del libro de trabajo.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Cambiar los datos del objeto del marco OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Incrustar archivos en diapositivas**

Además de los gráficos Excel, Aspose.Slides for Python le permite incrustar otros tipos de archivo en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en un objeto insertado, se abre automáticamente en la aplicación asociada, o se le solicita que elija un programa apropiado.

Este código Python muestra cómo incrustar archivos HTML y ZIP en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar sustituir objetos OLE antiguos por otros nuevos o cambiar un objeto OLE no compatible por uno compatible. Aspose.Slides for Python le permite establecer el tipo de archivo de un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión de archivo.

Este código Python muestra cómo establecer el tipo de archivo del objeto OLE incrustado a `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Cambiar el tipo de archivo a ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer imágenes de icono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa basada en un icono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos en la vista previa, puede establecer la imagen del icono y el título mediante Aspose.Slides for Python.

Este código Python muestra cómo establecer la imagen del icono y el título para un objeto incrustado:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Añadir una imagen a los recursos de la presentación.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Establecer un título y la imagen para la vista previa del OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Evitar que los marcos de objetos OLE se redimensionen y reposicionen**

Después de añadir un objeto OLE vinculado a una diapositiva, PowerPoint puede solicitarle que actualice los enlaces al abrir la presentación. Seleccionar «Update Links» puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza la vista previa con los datos del objeto vinculado. Para evitar que PowerPoint le solicite actualizar los datos del objeto, establezca la propiedad `update_automatic` de la clase [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) en `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer archivos incrustados**

Aspose.Slides for Python le permite extraer archivos incrustados en diapositivas como objetos OLE de la siguiente forma:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contenga los objetos OLE que desea extraer.
1. Recorra todas las formas de la presentación y localice las formas OLEObjectFrame.
1. Recupere los datos del archivo incrustado de cada [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) y escríbalos en disco.

El siguiente código Python muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **Preguntas frecuentes**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imágenes?**

Lo que se muestra en la diapositiva se renderiza: el icono/imagen de sustitución (vista previa). El contenido OLE «en vivo» no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para asegurar la apariencia esperada en el PDF exportado.

Para conservar también el archivo incrustado como adjunto PDF, establezca [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) en `True`. Esta opción está desactivada por defecto. Vea un ejemplo e instrucciones para comprobar el adjunto en [Preserve Embedded OLE Files as PDF Attachments](/slides/es/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/python-net/applying-protection-to-presentation/). No es cifrado, pero impide eficazmente ediciones y movimientos accidentales.

**¿Por qué un objeto Excel vinculado «salta» o cambia de tamaño al abrir la presentación?**

PowerPoint puede refrescar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Working Solution for Worksheet Resizing](/slides/es/python-net/working-solution-for-worksheet-resizing/): ajuste el marco al rango, o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.

**¿Se conservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?**

En PPTX, la información de «ruta relativa» no está disponible, solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas fiables/URI accesibles o la incrustación.