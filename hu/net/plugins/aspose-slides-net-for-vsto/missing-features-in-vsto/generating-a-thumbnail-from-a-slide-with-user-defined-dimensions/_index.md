---
title: Bélyegkép generálása diáról felhasználó által meghatározott méretekkel
type: docs
weight: 100
url: /hu/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
A kívánt diák bélyegképének előállításához az Aspose.Slides for .NET használatával:

- Hozzon létre egy példányt a Presentation osztályból.
- Szerezze be a kívánt dia hivatkozását az ID vagy index használatával.
- Szerezze meg az X és Y méretezési tényezőket a felhasználó által meghatározott X és Y méretek alapján.
- Szerezze meg a hivatkozott dia bélyegképét a megadott méretarányon.
- Mentse el a bélyegképet tetszőleges képformátumban.
## **Példa**
```cs
//A prezentációfájlt képviselő Presentation osztály példányosítása
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Az első dia elérése
    ISlide sld = pres.Slides[0];

    //Felhasználó által meghatározott méret
    int desiredX = 1200;
    int desiredY = 800;

    //X és Y méretezett értékének lekérése
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Teljes méretű kép létrehozása
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Kép mentése lemezre JPEG formátumban
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Futtatható példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
További részletekért látogassa meg a [Convert Slide](/slides/hu/net/convert-slide/).
{{% /alert %}}