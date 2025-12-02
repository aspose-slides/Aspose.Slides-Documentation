---
title: Problema de vista previa del objeto al agregar OleObjectFrame
linktitle: Problema de objeto OLE
type: docs
weight: 10
url: /es/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto cambiado
- vista previa del objeto
- presentación
- PowerPoint
- Python
- Aspose.Slides
description: "Descubra por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides para Python y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides para Python mediante .NET, cuando agregas [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva, se muestra un mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulta [Manage OLE](/slides/es/python-net/manage-ole/).

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarte que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse.

Por ejemplo, si agregas un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulta el artículo "Manage OLE") y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![OLE object message](OLE_object_message.png)

Si deseas verificar y confirmar que tu objeto OLE se agregó a la diapositiva, debes hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puedes hacer clic derecho sobre él y seleccionar la opción **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![OLE object data](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haces clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se reemplaza por la imagen real del objeto OLE.

![OLE object preview](OLE_object_preview.png)

Ahora, puede que desees guardar tu presentación para asegurarte de que la imagen del objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, cuando la abras de nuevo, NO verás el mensaje "EMBEDDED OLE OBJECT".

## **Otras soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una imagen**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes reemplazar el mensaje con la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso:
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

![New OLE object image](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puedes crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abras presentaciones en el programa.