---
title: Administrar OLE
type: docs
weight: 40
url: /es/python-net/manage-ole/
keywords:
- agregar OLE
- insertar OLE
- agregar un objeto
- insertar un objeto
- insertar un archivo
- objeto vinculado
- Vinculación e Inserción de Objetos
- objeto OLE
- PowerPoint 
- presentación
- Python
- Aspose.Slides para Python a través de .NET
description: Agregar objetos OLE a presentaciones de PowerPoint en Python
---

{{% alert title="Info" color="info" %}}

OLE (Vinculación e Inserción de Objetos) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación a través de vínculos o incrustaciones.

{{% /alert %}}

Considera un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando haces doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se te pide que selecciones una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenidos reales, por ejemplo, el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, la interfaz del gráfico se carga y puedes modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para Python a través de .NET](https://products.aspose.com/slides/python-net) te permite insertar objetos OLE en las diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Agregando Marcos de Objetos OLE a Diapositivas**
Suponiendo que ya has creado un gráfico en Microsoft Excel y deseas incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE utilizando Aspose.Slides para Python a través de .NET, puedes hacerlo de la siguiente manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Abre el archivo de Excel que contiene el objeto gráfico de Excel y guárdalo en `MemoryStream`.
1. Agrega el Marco de Objeto OLE a la diapositiva que contiene el arreglo de bytes y otra información sobre el objeto OLE.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado un gráfico de un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) utilizando Aspose.Slides para Python a través de .NET.  
**Nota** que el constructor de [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) toma una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

```py 
import aspose.slides as slides

# Instancia la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Carga un archivo de excel al flujo
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Crea un objeto de datos para incrustar
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Agrega un marco de objeto Ole
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Escribe el archivo PPTX en disco
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Accediendo a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puedes encontrar o acceder a ese objeto fácilmente de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtén la referencia de la diapositiva utilizando su índice.

1. Accede a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   En nuestro ejemplo, utilizamos el PPTX previamente creado que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Este era el Marco de Objeto OLE deseado al que acceder.

1. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación sobre él.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se escriben en un archivo de Excel:

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

## **Cambiando los Datos del Objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puedes acceder fácilmente a ese objeto con Aspose.Slides para Python a través de .NET y modificar sus datos de esta manera:

1. Abre la presentación deseada con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtén la referencia de la diapositiva a través de su índice.

1. Accede a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   En nuestro ejemplo, utilizamos el PPTX previamente creado, que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto a un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Este era el Marco de Objeto OLE deseado al que acceder.

1. Una vez que se accede al Marco de Objeto OLE, puedes realizar cualquier operación sobre él.

1. Crea el objeto Workbook y accede a los Datos OLE.

1. Accede a la Hoja de Cálculo deseada y modifica los datos.

1. Guarda el Workbook actualizado en flujos.

1. Cambia los datos del objeto OLE desde los datos de flujo.

En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto gráfico de Excel incrustado en una diapositiva) y luego sus datos de archivo se modifican para cambiar los datos del gráfico.

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## Incrustando Otros Tipos de Archivos en Diapositivas

Además de gráficos de Excel, Aspose.Slides para Python a través de .NET permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puedes insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa relevante, o se dirige al usuario a seleccionar un programa apropiado para abrir el objeto.

Este código python te muestra cómo incrustar HTML y ZIP en una diapositiva:

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

## Estableciendo Tipos de Archivo para Objetos Incrustados

Al trabajar en presentaciones, es posible que necesites reemplazar objetos OLE antiguos por nuevos. O puede que necesites reemplazar un objeto OLE no soportado por uno soportado.

Aspose.Slides para Python a través de .NET te permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puedes cambiar los datos del marco OLE o su extensión.

Este código python te muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

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

## Estableciendo Imágenes y Títulos de Íconos para Objetos Incrustados

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE.

Si deseas utilizar una imagen y un texto específicos como elementos en la vista previa, puedes establecer la imagen de ícono y el título utilizando Aspose.Slides para Python a través de .NET.

Este código de Python te muestra cómo establecer la imagen de ícono y el título para un objeto incrustado:

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

## **Prevenir que un Marco de Objeto OLE sea Redimensionado y Reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, cuando abres la presentación en PowerPoint, es posible que veas un mensaje pidiéndote que actualices los enlaces. Hacer clic en el botón "Actualizar Enlaces" puede cambiar el tamaño y la posición del marco de objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, establece la propiedad `update_automatic` de la clase [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a `False`:

```py
oleObjectFrame.update_automatic = False
```

## Extrayendo Archivos Incrustados

Aspose.Slides para Python a través de .NET te permite extraer los archivos incrustados en las diapositivas como objetos OLE de esta manera:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) que contenga el objeto OLE que deseas extraer.
2. Recorre todas las formas en la presentación y accede a la forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
3. Accede a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbelo en disco.

Este código python te muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:

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