---
title: Establecer título para el ícono OLE
type: docs
weight: 160
url: /es/net/set-caption-to-ole-icon/
---

Se ha agregado una nueva propiedad **SubstitutePictureTitle** a la interfaz **IOleObjectFrame** y a la clase **OleObjectFrame**. Permite obtener, establecer o cambiar el título de un ícono OLE. El siguiente fragmento de código muestra un ejemplo de creación de un objeto de Excel y la configuración de su título.

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // Agregar objetos Ole
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Agregar objeto de imagen
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // Establecer título para el ícono OLE
    oof.SubstitutePictureTitle = "Ejemplo de título";
}
```