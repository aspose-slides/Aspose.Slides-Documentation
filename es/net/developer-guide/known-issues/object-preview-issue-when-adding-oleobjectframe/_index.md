---
title: Problema de vista previa del objeto al agregar OleObjectFrame
linktitle: Problema de objeto OLE
type: docs
weight: 10
url: /es/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- presentación
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides for .NET y cómo solucionar los problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides for .NET, cuando agrega un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Manage OLE](/slides/es/net/manage-ole/). 

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE se ha modificado y la imagen de vista previa debe actualizarse. 

Por ejemplo, si agrega un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva (para más detalles, vea el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si desea comprobar y confirmar que su objeto OLE se agregó a la diapositiva, debe hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puede hacer clic derecho sobre él y seleccionar la opción **Object > Edit**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, puede querer guardar su presentación para asegurarse de que la imagen del objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, cuando la abra nuevamente, NO verá el mensaje "EMBEDDED OLE OBJECT". 

## **Otras soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" por una imagen**

Si no desea eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![Nueva imagen del objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abra presentaciones en el programa.