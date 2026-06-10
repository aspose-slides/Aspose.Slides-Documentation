---
title: Diabélyegkép létrehozása JPEG formátumban
type: docs
weight: 90
url: /hu/net/generate-slide-thumbnail-as-jpeg/
---
Az Aspose.Slides for .NET használatával egy tetszőleges dia bélyegképének elkészítéséhez:

- Hozzon létre egy Presentation osztály példányt.
- Szerezze meg a kívánt dia hivatkozását azonosítója vagy indexe alapján.
- Kérje le a hivatkozott dia bélyegképét a megadott méretarányban.
- Mentse el a bélyegképet a kívánt képformátumban.
## **Példa**
```cs
//Példányosítsa a Presentation osztályt, amely a bemutató fájlt képviseli
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Hozzáférés az első diához
    ISlide sld = pres.Slides[0];

    //Teljes méretű kép létrehozása
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Mentse a képet lemezre JPEG formátumban
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Futó példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
További részletekért látogasson el a [Convert PPT and PPTX to JPG in .NET](/slides/hu/net/convert-powerpoint-to-jpg/) oldalra.
{{% /alert %}}