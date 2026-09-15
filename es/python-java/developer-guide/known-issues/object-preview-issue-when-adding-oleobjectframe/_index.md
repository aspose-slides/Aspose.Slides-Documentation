---
title: Problema de vista previa del objeto al agregar OleObjectFrame
linktitle: Problema de objeto OLE
type: docs
weight: 10
url: /es/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides para Python a través de Java y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---
## **Introducción**

Cuando usas Aspose.Slides for Python via Java para añadir un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y no es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Administrar OLE](/slides/es/python-java/manage-ole/).

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse.

Por ejemplo, si añades un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, vea el artículo "Administrar OLE") y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![mensaje de objeto OLE](OLE_object_message.png)

Para confirmar que tu objeto OLE se añadió a la diapositiva, haz doble clic en el mensaje "EMBEDDED OLE OBJECT", o haz clic con el botón derecho y selecciona **Objeto > Editar**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint abre entonces el objeto OLE incrustado.

![datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Cuando hagas clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE.

![vista previa del objeto OLE](OLE_object_preview.png)

Guarda tu presentación para conservar la imagen de vista previa actualizada del objeto OLE. Cuando vuelvas a abrir la presentación, ya no verás el mensaje "EMBEDDED OLE OBJECT".

## **Otra solución**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes sustituir el mensaje por la imagen de vista previa que prefieras. El siguiente código muestra el proceso:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Añadir una imagen a los recursos de la presentación.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Establecer un título y la imagen para la vista previa del objeto OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La diapositiva que contiene el [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) cambia entonces a esto:

![Nueva imagen de objeto OLE](OLE_object_new_image.png)

## **Preguntas frecuentes**

**¿Por qué aparece el mensaje "EMBEDDED OLE OBJECT"?**

El mensaje indica que el objeto OLE ha cambiado y que su imagen de vista previa necesita actualizarse. Este comportamiento es intencional.

**¿Cómo puedo actualizar la vista previa en PowerPoint?**

Haz doble clic en el mensaje o selecciona **Objeto > Editar** para abrir el objeto OLE incrustado. Haz clic en el objeto OLE para actualizar la vista previa y luego guarda la presentación.

**¿Puedo sustituir el mensaje sin abrir la presentación en PowerPoint?**

Sí. Puedes asignar una imagen de vista previa preferida al objeto OLE, como se muestra en el ejemplo de código anterior.