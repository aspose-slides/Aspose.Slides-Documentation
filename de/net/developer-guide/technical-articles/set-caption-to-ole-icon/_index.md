---
title: Bildunterschrift für OLE-Icon festlegen
type: docs
weight: 160
url: /de/net/set-caption-to-ole-icon/
---

Eine neue Eigenschaft **SubstitutePictureTitle** wurde zum **IOleObjectFrame**-Interface und zur **OleObjectFrame**-Klasse hinzugefügt. Sie ermöglicht es, die Bildunterschrift eines OLE-Icons abzurufen, festzulegen oder zu ändern. Der folgende Codeausschnitt zeigt ein Beispiel zur Erstellung eines Excel-Objekts und zur Festlegung seiner Bildunterschrift.

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // Fügen Sie OLE-Objekte hinzu
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Fügen Sie das Bildobjekt hinzu
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // Bildunterschrift für OLE-Icon festlegen
    oof.SubstitutePictureTitle = "Beispielbildunterschrift";
}
```