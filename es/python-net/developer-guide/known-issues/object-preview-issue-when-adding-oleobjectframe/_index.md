---
title: Problema de Vista Previa del Objeto al Añadir OleObjectFrame
linktitle: Problema de Objeto OLE
type: docs
weight: 10
url: /es/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- presentación
- PowerPoint
- Python
- Aspose.Slides
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al añadir OleObjectFrame en Aspose.Slides para Python y cómo corregir los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides for Python a través de .NET, cuando agrega [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva, se muestra el mensaje **EMBEDDED OLE OBJECT** en la diapositiva resultante. Este mensaje es intencional y **NO** es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Manage OLE](/slides/es/python-net/manage-ole/). 

## **Explicación y solución**

Aspose.Slides muestra el mensaje **EMBEDDED OLE OBJECT** para notificarle que el objeto OLE ha sido modificado y la imagen de vista previa debe actualizarse. 

Por ejemplo, si agrega un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulte el artículo “Manage OLE”) y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si desea comprobar y confirmar que su objeto OLE se añadió a la diapositiva, debe hacer doble clic en el mensaje **EMBEDDED OLE OBJECT**, o bien hacer clic con el botón derecho y seleccionar la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint abre entonces el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede seguir mostrando el mensaje **EMBEDDED OLE OBJECT**. Cuando haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje **EMBEDDED OLE OBJECT** se reemplaza por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, es posible que desee guardar su presentación para asegurarse de que la imagen del objeto OLE se actualice correctamente. De este modo, después de guardar la presentación, al abrirla nuevamente no verá el mensaje **EMBEDDED OLE OBJECT**. 

## **Otras soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una imagen**

Si no desea eliminar el mensaje **EMBEDDED OLE OBJECT** abriendo la presentación en PowerPoint y luego guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Agregar una imagen a los recursos de la presentación.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Establecer un título y la imagen para la vista previa del objeto OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


La diapositiva que contiene el `OleObjectFrame` entonces cambia a lo siguiente:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abra presentaciones en el programa.