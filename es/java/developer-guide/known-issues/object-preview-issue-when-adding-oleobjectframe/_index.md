---
title: Problema de vista previa del objeto al añadir OleObjectFrame
linktitle: Problema del objeto OLE
type: docs
weight: 10
url: /es/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al añadir OleObjectFrame en Aspose.Slides para Java y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---
## **Introducción**

Al utilizar Aspose.Slides for Java, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/oleobjectframe/) a una diapositiva, se muestra un mensaje "EMBEDDED OLE OBJECT" en la diapositiva resultante. Este mensaje es intencional y NOT es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulta [Administrar OLE](/slides/es/java/manage-ole/).

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y la imagen de vista previa debe actualizarse.

Por ejemplo, si añades un gráfico de Microsoft Excel como un [OleObjectFrame] a una diapositiva (para más detalles, consulta el artículo "Administrar OLE") y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![Mensaje del objeto OLE](OLE_object_message.png)

Si deseas comprobar y confirmar que tu objeto OLE se ha añadido a la diapositiva, debes hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puedes hacer clic derecho sobre él y seleccionar la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede mantener el mensaje "EMBEDDED OLE OBJECT". Una vez que haces clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE.

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que quieras guardar tu presentación para asegurar que la imagen del Objeto OLE se actualice correctamente. De este modo, después de guardar la presentación, al volver a abrirla, NO verás el mensaje "EMBEDDED OLE OBJECT".

## **Otra solución**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes sustituir el mensaje por la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Añadir una imagen a los recursos de la presentación.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Establecer un título y la imagen para la vista previa del objeto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)