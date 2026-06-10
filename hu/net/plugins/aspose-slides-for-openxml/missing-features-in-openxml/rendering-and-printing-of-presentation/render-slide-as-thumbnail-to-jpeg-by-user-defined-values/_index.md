---
title: Dia renderelése bélyegképként JPEG-be felhasználó által meghatározott értékekkel
type: docs
weight: 70
url: /hu/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Az Aspose.Slides for .NET használatával egy tetszőleges diának a bélyegképének előállításához:

1. Hozzon létre egy példányt a **Presentation** osztályból.
1. Szerezze be a kívánt dia hivatkozását az azonosítója vagy indexe alapján.
1. Szerezze meg az X és Y méretezési tényezőket a felhasználó által megadott X és Y méretek alapján.
1. Kapja meg a hivatkozott dia bélyegképét a megadott méretarányban.
1. Mentse el a bélyegképet egy kívánt képformátumban.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Példányosítsa a Presentation osztályt, amely a bemutató fájlt képviseli
using (Presentation pres = new Presentation(srcFileName))
{
    //Hozzáférés az első diát
    ISlide sld = pres.Slides[0];

    //Felhasználó által meghatározott méret
    int desiredX = 1200;
    int desiredY = 800;

    //Az X és Y méretezett értékének lekérése
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Teljes méretű kép létrehozása
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Kép mentése lemezen JPEG formátumban
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)