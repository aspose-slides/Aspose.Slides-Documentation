---
title: Vykreslit snímek jako miniaturu do JPEG pomocí uživatelsky definovaných hodnot
type: docs
weight: 70
url: /cs/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Jak vygenerovat miniaturu libovolného požadovaného snímku pomocí Aspose.Slides pro .NET:

1. Vytvořte instanci třídy **Presentation**.
1. Získejte referenci na libovolný požadovaný snímek pomocí jeho ID nebo indexu.
1. Získejte faktory měřítka X a Y na základě uživatelem definovaných rozměrů X a Y.
1. Získejte obrázek miniatury referencovaného snímku v určeném měřítku.
1. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation(srcFileName))
{
    //Přístup k prvnímu snímku
    ISlide sld = pres.Slides[0];

    //Uživatelem definovaný rozměr
    int desiredX = 1200;
    int desiredY = 800;

    //Získání měřítka hodnoty  X a Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Vytvořte obraz v plném měřítku
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Uložte obraz na disk ve formátu JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)