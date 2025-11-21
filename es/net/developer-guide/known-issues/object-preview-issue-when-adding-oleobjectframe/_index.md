---
title: Problema de vista previa del objeto al agregar OleObjectFrame
linktitle: Problema con objeto OLE
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

Al usar Aspose.Slides para .NET, cuando añades [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva, se muestra el mensaje **"EMBEDDED OLE OBJECT"** en la diapositiva de salida. Este mensaje es intencional y **NO** es un error.

Para obtener más información sobre cómo trabajar con objetos OLE, consulte [Administrar OLE](/slides/es/net/manage-ole/). 

## **Explicación y solución**

Aspose.Slides muestra el mensaje **"EMBEDDED OLE OBJECT"** para notificar que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse. 

Por ejemplo, si añades un gráfico de Microsoft Excel como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a una diapositiva (para más detalles, consulta el artículo “Administrar OLE”) y luego abres la presentación en Microsoft PowerPoint, verás esta imagen en la diapositiva:

![Mensaje de objeto OLE](OLE_object_message.png)

Si deseas comprobar y confirmar que tu objeto OLE se añadió a la diapositiva, debes hacer doble clic en el mensaje **"EMBEDDED OLE OBJECT"**, o bien hacer clic con el botón derecho y seleccionar la opción **Objeto > Editar**.

![Objeto > Editar](OLE_object_edit.png)

PowerPoint abre entonces el objeto OLE incrustado.

![Datos del objeto OLE](OLE_object_data.png)

La diapositiva puede seguir mostrando el mensaje **"EMBEDDED OLE OBJECT"**. Cuando haces clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje se reemplaza por la imagen real del objeto OLE. 

![Vista previa del objeto OLE](OLE_object_preview.png)

Ahora, es posible que quieras guardar la presentación para asegurarte de que la imagen del objeto OLE se actualice correctamente. De este modo, después de guardar la presentación, al volver a abrirla **NO** verás el mensaje **"EMBEDDED OLE OBJECT"**. 

## **Otras soluciones**

### **Solución 1: Reemplazar el mensaje "EMBEDDED OLE OBJECT" con una imagen**

Si no deseas eliminar el mensaje **"EMBEDDED OLE OBJECT"** abriendo la presentación en PowerPoint y luego guardándola, puedes sustituir el mensaje por la imagen de vista previa que prefieras. Estas líneas de código demuestran el proceso:
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


La diapositiva que contiene el `OleObjectFrame` cambia a lo siguiente:

![Nueva imagen de objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puedes crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE al abrir presentaciones en el programa.