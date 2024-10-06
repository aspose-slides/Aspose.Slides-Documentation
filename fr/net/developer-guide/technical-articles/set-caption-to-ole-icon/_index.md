---
title: Définir la légende de l'icône OLE
type: docs
weight: 160
url: /net/set-caption-to-ole-icon/
---

Une nouvelle propriété **SubstitutePictureTitle** a été ajoutée à l'interface **IOleObjectFrame** et à la classe **OleObjectFrame**. Elle permet d'obtenir, de définir ou de changer la légende d'une icône OLE. L'extrait de code ci-dessous montre un exemple de création d'un objet Excel et de définition de sa légende.

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // Ajouter des objets Ole
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Ajouter un objet image
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // Définir la légende de l'icône OLE
    oof.SubstitutePictureTitle = "Exemple de légende";
}
```