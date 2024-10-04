---
title: Gestionar OLE
type: docs
weight: 40
url: /python-net/manage-ole/
keywords: "Agregar OLE, Agregar objeto, Incorporar objeto Object Linking & Embedding, Marco de objeto OLE, Incorporar OLE, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar objeto OLE a la presentación de PowerPoint en Python"
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación a través de enlaces o incrustaciones.

{{% /alert %}}

Considere un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando se hace doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le pide que seleccione una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenidos reales—por ejemplo, el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y se pueden modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para Python a través de .NET](https://products.aspose.com/slides/python-net) permite insertar Objetos OLE en las diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Agregar Marcos de Objetos OLE a las Diapositivas**
Suponiendo que ya creó un gráfico en Microsoft Excel y desea incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para Python a través de .NET, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva a través de su índice.
1. Abra el archivo de Excel que contiene el objeto gráfico de Excel y guárdelo en `MemoryStream`.
1. Agregue el Marco de Objeto OLE a la diapositiva que contiene el arreglo de bytes y otra información sobre el objeto OLE.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico desde un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) utilizando Aspose.Slides para Python a través de .NET.  
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) toma una extensión de objeto incrustable como segundo parámetro. Esta extensión permite que PowerPoint interprete correctamente el tipo de archivo y elija la aplicación adecuada para abrir este objeto OLE.

```py 
import aspose.slides as slides

# Instancia la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Carga un archivo de excel en un stream
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Crea un objeto de datos para incrustar
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Agrega una forma de Marco de Objeto Ole
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Escribe el archivo PPTX en disco
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Acceder a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puede encontrar o acceder a ese objeto fácilmente de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtenga la referencia de la diapositiva utilizando su índice.

1. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Este fue el Marco de Objeto OLE deseado al que se accedió.

1. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación en él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva)—y luego se escriben los datos del archivo a un archivo de Excel:

```py 
import aspose.slides as slides

# Carga el PPTX a un objeto de presentación
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Convierte la forma a OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # Lee el objeto OLE y lo escribe en disco
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Obtiene los datos del archivo incrustado
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Obtiene la extensión del archivo incrustado
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Crea una ruta para guardar el archivo extraído
        extractedPath = "excelFromOLE_out" + fileExtention

        # Guarda los datos extraídos
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Cambiar los Datos del Objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto con Aspose.Slides para Python a través de .NET y modificar sus datos de esta manera:

1. Abra la presentación deseada con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtenga la referencia de la diapositiva a través de su índice.

1. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   En nuestro ejemplo, utilizamos el PPTX creado anteriormente, que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Este fue el Marco de Objeto OLE deseado al que se accedió.

1. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación en él.

1. Cree el objeto Workbook y acceda a los Datos OLE.

1. Acceda a la Hoja de trabajo deseada y enmiende los datos.

1. Guarde el Workbook actualizado en flujos.

1. Cambie los datos del objeto OLE desde los datos de flujo.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego se modifican sus datos de archivo para cambiar los datos del gráfico.

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## Incrustar Otros Tipos de Archivos en Diapositivas

Además de los gráficos de Excel, Aspose.Slides para Python a través de .NET permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa relevante, o se redirige al usuario a seleccionar un programa apropiado para abrir el objeto.

Este código de Python le muestra cómo incrustar HTML y ZIP en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## Establecer Tipos de Archivos para Objetos Incrustados

Al trabajar en presentaciones, es posible que necesite reemplazar objetos OLE antiguos por otros nuevos. O puede necesitar reemplazar un objeto OLE no compatible por uno compatible.

Aspose.Slides para Python a través de .NET permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puede cambiar los datos del marco OLE o su extensión.

Este código de Python le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("La extensión de datos incrustados actual es:" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Establecer Imágenes de Iconos y Títulos para Objetos Incrustados

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE.

Si desea utilizar una imagen y texto específicos como elementos en la vista previa, puede establecer la imagen del ícono y el título utilizando Aspose.Slides para Python a través de .NET.

Este código de Python le muestra cómo establecer la imagen del ícono y el título para un objeto incrustado:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "Mi título"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## Extraer Archivos Incrustados

Aspose.Slides para Python a través de .NET le permite extraer los archivos incrustados en las diapositivas como objetos OLE de esta manera:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contenga el objeto OLE que pretende extraer.
2. Recorra todas las formas en la presentación y acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
3. Acceda a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbalo en disco.

Este código de Python le muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```