---
title: Dia renderelése bélyegképként JPEG formátumba
type: docs
weight: 60
url: /hu/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** a diát tartalmazó prezentációs fájlok létrehozására szolgál. Ezeket a diákot megtekinthetjük a prezentációs fájlok Microsoft PowerPoint‑tal történő megnyitásával. Néha azonban a fejlesztőknek szükségük lehet a diák képként történő megjelenítésére a kedvenc képnéző programjukban. Ilyen esetben az Aspose.Slides for .NET segít a diák bélyegképének előállításában.

Az Aspose.Slides for .NET használatával bármely kívánt dia bélyegképének előállításához:

1. Hozzon létre egy példányt a **Presentation** osztályból.
1. Szerezze be a kívánt dia hivatkozását az ID‑jének vagy indexének használatával.
1. Kérje le a hivatkozott dia bélyegképét a megadott méretezésben.
1. Mentse el a bélyegképet a kívánt képformátumban.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//A Presentation osztály példányosítása, amely a prezentációs fájlt képviseli
using (Presentation pres = new Presentation(srcFileName))
{
    //Az első dia elérése
    ISlide sld = pres.Slides[0];

    //Teljes méretű kép létrehozása
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Kép mentése lemezre JPEG formátumban
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)