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
- objeto modificado
- vista previa del objeto
- presentación
- PowerPoint
- Python
- Aspose.Slides
description: "Aprende por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides para Python y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides for Python via .NET, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva, se muestra un mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Administrar OLE](/slides/es/python-net/manage-ole/). 

## **Explicación y Solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarte que el objeto OLE ha sido modificado y la imagen de vista previa debe actualizarse. 

Por ejemplo, si añades un gráfico de Microsoft Excel como [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulte el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![Mensaje del objeto OLE](OLE_object_message.png)

Si deseas comprobar y confirmar que tu objeto OLE se añadió a la diapositiva, debes hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puedes hacer clic derecho sobre él y acceder a la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que hagas clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que desees guardar tu presentación para asegurar que la imagen del Objeto OLE se actualice correctamente. De este modo, después de guardar la presentación, al volver a abrirla NO verás el mensaje "EMBEDDED OLE OBJECT". 

## **Otras Soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una Imagen**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes sustituir el mensaje por la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso:
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


La diapositiva que contiene el `OleObjectFrame` cambia a lo siguiente:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puedes crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE al abrir presentaciones en el programa.