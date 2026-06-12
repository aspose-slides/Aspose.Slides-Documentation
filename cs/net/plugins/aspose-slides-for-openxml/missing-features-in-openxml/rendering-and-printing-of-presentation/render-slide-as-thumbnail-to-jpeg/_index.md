---
title: Vykreslit snímek jako miniaturu do JPEG
type: docs
weight: 60
url: /cs/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** se používá k vytváření souborů prezentací obsahujících snímky. Tyto snímky lze zobrazit otevřením souborů prezentace v Microsoft PowerPointu. Někdy však vývojáři potřebují zobrazit snímky jako obrázky pomocí svého oblíbeného prohlížeče obrázků. V takových případech vám Aspose.Slides for .NET pomůže generovat miniatury snímků.

Chcete-li vygenerovat miniaturu libovolného požadovaného snímku pomocí Aspose.Slides for .NET:

1. Vytvořte instanci třídy **Presentation**.
1. Získejte odkaz na libovolný požadovaný snímek pomocí jeho ID nebo indexu.
1. Získejte obrázek miniatury odkazovaného snímku v zadaném měřítku.
1. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instancujte třídu Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation(srcFileName))
{
    //Přístup k prvnímu snímku
    ISlide sld = pres.Slides[0];

    //Vytvořte obraz v plném měřítku
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Uložte obraz na disk ve formátu JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Stáhněte ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)