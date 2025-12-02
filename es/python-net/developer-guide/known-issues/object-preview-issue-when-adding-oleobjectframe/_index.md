---
title: Problema de vista previa del objeto al añadir OleObjectFrame
linktitle: Problema de objeto OLE
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
description: "Aprenda por qué EMBEDDED OLE OBJECT aparece al agregar OleObjectFrame en Aspose.Slides para Python y cómo corregir problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides for Python a través de .NET, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva, se muestra un mensaje "EMBEDDED OLE OBJECT" en la diapositiva resultante. Este mensaje es intencional y NOT es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Manage OLE](/slides/es/python-net/manage-ole/).

## **Explicación y Solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse. 

Por ejemplo, si añade un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulte el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si desea comprobar y confirmar que su objeto OLE se añadió a la diapositiva, debe hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puede hacer clic derecho sobre él y pasar por la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que desee guardar su presentación para asegurarse de que la imagen del objeto OLE se actualice correctamente. De este modo, después de guardar la presentación, al abrirla de nuevo, NO verá el mensaje "EMBEDDED OLE OBJECT". 

## **Otras Soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una imagen**

Si no desea eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Añadir una imagen a los recursos de la presentación.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Establecer un título y la imagen para la vista previa del objeto OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abra presentaciones en el programa.