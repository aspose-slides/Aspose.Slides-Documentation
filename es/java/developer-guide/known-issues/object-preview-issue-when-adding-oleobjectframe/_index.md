---
title: Problema de vista previa del objeto al agregar OleObjectFrame
linktitle: Problema de objeto OLE
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
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides para Java y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides para Java, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Administrar OLE](/slides/es/java/manage-ole/). 

## **Explicación y Solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse. 

Por ejemplo, si añade un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulte el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si desea verificar y confirmar que su objeto OLE se añadió a la diapositiva, debe hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puede hacer clic con el botón derecho sobre él y seleccionar la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se reemplaza por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede que desee guardar su presentación para asegurar que la imagen del objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, al abrirla nuevamente, NO verá el mensaje "EMBEDDED OLE OBJECT". 

## **Otras Soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una imagen**

Si no desea eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:
```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Agregar una imagen a los recursos de la presentación.
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


La diapositiva que contiene `OleObjectFrame` entonces cambia a esto:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abra presentaciones en el programa.