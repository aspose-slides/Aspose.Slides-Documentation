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
description: "Aprenda por qué aparece EMBEDDED OLE OBJECT al agregar OleObjectFrame en Aspose.Slides para .NET y cómo solucionar problemas de vista previa en presentaciones PPT, PPTX y ODP."
---

## **Introducción**

Al usar Aspose.Slides para .NET, cuando agrega un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva de salida. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Manage OLE](/slides/es/net/manage-ole/). 

## **Explicación y solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse. 

Por ejemplo, si agrega un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva (para más detalles, consulte el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![OLE object message](OLE_object_message.png)

Si desea verificar y confirmar que su objeto OLE se añadió a la diapositiva, debe hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puede hacer clic con el botón derecho sobre él y seleccionar la opción **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint entonces abre el objeto OLE incrustado.

![OLE object data](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se reemplaza por la imagen real del objeto OLE. 

![OLE object preview](OLE_object_preview.png)

Ahora, es posible que desee guardar su presentación para asegurarse de que la imagen del objeto OLE se actualice correctamente. De esta manera, después de guardar la presentación, al volver a abrirla, NO verá el mensaje "EMBEDDED OLE OBJECT". 

## **Otras soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" con una imagen**

Si no desea eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Agregar una imagen a los recursos de la presentación.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Establecer un título y la imagen para la vista previa del objeto OLE.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![New OLE object image](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE cuando abra presentaciones en el programa.