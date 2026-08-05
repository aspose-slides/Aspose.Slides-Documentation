---
title: Problema de vista previa del objeto al añadir OleObjectFrame
linktitle: Problema de objeto OLE
type: docs
weight: 10
url: /es/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al añadir OleObjectFrame en Aspose.Slides para Node.js y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---
## **Introducción**

Al usar Aspose.Slides para Java, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/oleobjectframe/) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva resultante. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulta [Administrar OLE](/slides/es/nodejs-java/manage-ole/).

## **Explicación y Solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarte que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse. 

Por ejemplo, si añades un gráfico de Microsoft Excel como [OleObjectFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulta el artículo "Administrar OLE") y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![Mensaje del objeto OLE](OLE_object_message.png)

Si deseas comprobar y confirmar que tu objeto OLE se ha añadido a la diapositiva, debes hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puedes hacer clic con el botón derecho sobre él y seguir la opción **Objeto > Editar**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint abre entonces el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Cuando haces clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que quieras guardar tu presentación para asegurarte de que la imagen del Objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, cuando la vuelvas a abrir, NO verás el mensaje "EMBEDDED OLE OBJECT". 

## **Otras Soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" por una imagen**

Si no deseas eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puedes reemplazar el mensaje por la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Añadir una imagen a los recursos de la presentación.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Establecer un título y la imagen para la vista previa del objeto OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puedes crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abras presentaciones en el programa.