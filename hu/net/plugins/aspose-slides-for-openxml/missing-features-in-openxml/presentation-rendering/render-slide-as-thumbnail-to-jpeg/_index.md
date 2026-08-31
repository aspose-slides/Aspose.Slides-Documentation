---
title: Dia renderelése bélyegképként JPEG-re
type: docs
weight: 60
url: /hu/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** arra szolgál, hogy prezentációs fájlokat hozzon létre, amelyek diákból állnak. Ezek a diák megtekinthetők a prezentációs fájlok Microsoft PowerPoint‑tal való megnyitásával. De néha a fejlesztőknek szükségük lehet a diák képként való megtekintésére a kedvenc képmegjelenítőjükkel. Ilyen esetekben az Aspose.Slides for .NET segít előállítani a diák bélyegképeit.

Ahhoz, hogy a kívánt dia bélyegképét előállítsa az Aspose.Slides for .NET használatával:

1. Hozzon létre egy példányt a **Presentation** osztályból.
2. Szerezze meg a kívánt dia hivatkozását az azonosítója vagy indexe alapján.
3. Szerezze be a hivatkozott dia bélyegképét egy megadott méretezésben.
4. Mentse el a bélyegképet a kívánt képformátumban.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
using (Presentation pres = new Presentation(srcFileName))
{
    //Az első diához hozzáférés
    ISlide sld = pres.Slides[0];

    //Teljes méretű kép létrehozása
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Kép mentése lemezre JPEG formátumban
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Mintakód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)