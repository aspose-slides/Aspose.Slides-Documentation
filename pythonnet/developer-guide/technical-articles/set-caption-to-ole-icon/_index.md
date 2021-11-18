---
title: Set Caption to OLE Icon
type: docs
weight: 160
url: /pythonnet/set-caption-to-ole-icon/
---

A new property **SubstitutePictureTitle** has been added to **IOleObjectFrame** interface and **OleObjectFrame** class. It allows to get, set or change the caption of an OLE icon. The code snippet below shows a sample of creating Excel object and setting its caption.

```py
using (Presentation pres = new Presentation())
{
    IPPImage image = null;
    ISlide slide = pres.Slides[0];

    // Add Ole objects
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.bin");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xls");
    
    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Add image object
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    using (MemoryStream ms = new MemoryStream(imgBuf))
    {
        image = pres.Images.AddImage(new Bitmap(ms));
    }
    oof.SubstitutePictureFormat.Picture.Image = image;

    // Set caption to OLE icon
    oof.SubstitutePictureTitle = "Caption example";
}
```


