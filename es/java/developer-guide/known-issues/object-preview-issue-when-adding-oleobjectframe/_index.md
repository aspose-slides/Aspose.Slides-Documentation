---
title: Marcador de posición de vista previa del objeto al añadir OleObjectFrame
linktitle: Marcador de vista previa de OLE
type: docs
weight: 10
url: /es/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- marcador de posición de vista previa
- por diseño
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Por qué un objeto OLE añadido con Aspose.Slides for Java muestra un marcador de posición EMBEDDED OLE OBJECT hasta que su vista previa se actualiza, y cómo establecer tu propia imagen de vista previa."
---
## **Introducción**

Usando Aspose.Slides for Java, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/oleobjectframe/) a una diapositiva, se muestra un mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NOT un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Administrar OLE](/slides/es/java/manage-ole/).

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse.

Por ejemplo, si añades un gráfico de Microsoft Excel como [OleObjectFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, vea el artículo "Administrar OLE") y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si deseas comprobar y confirmar que tu objeto OLE se añadió a la diapositiva, debes hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puedes hacer clic con el botón derecho sobre él y seleccionar la opción **Objeto > Editar**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haces clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" es reemplazado por la imagen real del objeto OLE.

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que quieras guardar tu presentación para asegurar que la imagen del objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, al volver a abrirla no verás el mensaje "EMBEDDED OLE OBJECT".

## **Otra solución**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes sustituir el mensaje por la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso. Asumen que la primera forma en la primera diapositiva de *embeddedOLE.pptx* es el marco del objeto OLE y que *myImage.png* contiene la imagen a mostrar, y guardan el resultado como *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Añadir una imagen a los recursos de la presentación.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Establecer la imagen para la vista previa del objeto OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La diapositiva que contiene el `OleObjectFrame` cambia a esto:

![Nueva imagen de objeto OLE](OLE_object_new_image.png)