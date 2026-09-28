---
title: Marcador de posición de vista previa de objeto al añadir OleObjectFrame
linktitle: Marcador de vista previa OLE
type: docs
weight: 10
url: /es/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problema de vista previa
- marcador de posición de vista previa
- por diseño
- objeto incrustado
- archivo incrustado
- objeto modificado
- vista previa del objeto
- presentación
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Por qué un objeto OLE añadido con Aspose.Slides para .NET muestra un marcador de posición EMBEDDED OLE OBJECT hasta que se actualiza su vista previa, y cómo establecer su propia imagen de vista previa."
---
## **Introducción**

Al usar Aspose.Slides para .NET, cuando añade [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe/) a una diapositiva, se muestra el mensaje "EMBEDDED OLE OBJECT" en la diapositiva resultante. Este mensaje es intencional y NO es un error.

Para obtener más información sobre el trabajo con objetos OLE, consulte [Gestionar OLE](/slides/es/net/manage-ole/).

## **Explicación y Solución**

Aspose.Slides muestra el mensaje "EMBEDDED OLE OBJECT" para notificarle que el objeto OLE ha sido modificado y que la imagen de vista previa debe actualizarse.

Por ejemplo, si añade un gráfico de Microsoft Excel como [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe/) a una diapositiva (para más detalles, consulte el artículo "Manage OLE") y luego abre la presentación en Microsoft PowerPoint, verá esta imagen en la diapositiva:

![mensaje de objeto OLE](OLE_object_message.png)

Si desea comprobar y confirmar que su objeto OLE se ha añadido a la diapositiva, debe hacer doble clic en el mensaje "EMBEDDED OLE OBJECT", o puede hacer clic con el botón derecho y seleccionar la opción **Objeto > Editar**.

![Objeto OLE > Editar](OLE_object_edit.png)

PowerPoint abre entonces el objeto OLE incrustado.

![datos del objeto OLE](OLE_object_data.png)

La diapositiva puede conservar el mensaje "EMBEDDED OLE OBJECT". Una vez que haga clic en el objeto OLE, la vista previa de la diapositiva se actualiza y el mensaje "EMBEDDED OLE OBJECT" se sustituye por la imagen real del objeto OLE.

![vista previa del objeto OLE](OLE_object_preview.png)

Ahora, es posible que desee guardar su presentación para asegurarse de que la imagen del Objeto OLE se actualice correctamente. De esta forma, después de guardar la presentación, cuando la vuelva a abrir, NO verá el mensaje "EMBEDDED OLE OBJECT".

## **Otras Soluciones**

### **Solución 1: Reemplazar el mensaje "Embedded OLE Object" por una imagen**

Si no desea eliminar el mensaje "EMBEDDED OLE OBJECT" abriendo la presentación en PowerPoint y luego guardándola, puede reemplazar el mensaje con la imagen de vista previa que prefiera. Estas líneas de código demuestran el proceso:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

La diapositiva que contiene el `OleObjectFrame` entonces cambia a esto:

![Nueva imagen de objeto OLE](OLE_object_new_image.png)

### **Solución 2: Crear un complemento para PowerPoint**

También puede crear un complemento para Microsoft PowerPoint que actualice todos los objetos OLE al abrir presentaciones en el programa.