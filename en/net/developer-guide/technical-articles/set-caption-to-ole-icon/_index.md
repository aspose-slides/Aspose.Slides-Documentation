---
title: Set Caption to OLE Icon
type: docs
weight: 160
url: /net/set-caption-to-ole-icon/
---

A new property **SubstitutePictureTitle** has been added to **IOleObjectFrame** interface and **OleObjectFrame** class. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // Add Ole objects
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Add image object
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // Set caption to OLE icon
    oof.SubstitutePictureTitle = "Caption example";
}
```


