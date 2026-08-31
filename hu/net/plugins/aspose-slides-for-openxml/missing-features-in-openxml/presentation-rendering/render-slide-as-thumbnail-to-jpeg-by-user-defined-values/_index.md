---
title: Felhasználó által meghatározott értékek alapján a dia miniatűr JPEG-be renderelése
type: docs
weight: 70
url: /hu/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
A kívánt dia miniatűrjének előállításához az Aspose.Slides for .NET használatával:

1. Hozzon létre egy példányt a **Presentation** osztályból.
1. Szerezze meg a kívánt dia hivatkozását az ID vagy index használatával.
1. Szerezze meg az X és Y nagyítási tényezőket a felhasználó által meghatározott X és Y méretek alapján.
1. Szerezze meg a hivatkozott dia miniatűr képét a megadott méretarányban.
1. Mentse el a miniatűr képet a kívánt képformátumban.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Példányosítsa a Presentation osztályt, amely a bemutató fájlt képviseli
using (Presentation pres = new Presentation(srcFileName))
{
    //Az első diát érje el
    ISlide sld = pres.Slides[0];

    //Felhasználó által meghatározott méret
    int desiredX = 1200;
    int desiredY = 800;

    //Az X és Y méretezett értékeinek lekérése
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Hozzon létre egy teljes méretű képet
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Mentse a képet a lemezre JPEG formátumban
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Mintakód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)