---
title: Vykreslit snímek jako miniaturu do JPEG
type: docs
weight: 60
url: /cs/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** se používá k vytváření prezentačních souborů obsahujících snímky. Tyto snímky lze zobrazit otevřením prezentačních souborů v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit snímky jako obrázky ve svém oblíbeném prohlížeči obrázků. V takových případech vám Aspose.Slides for .NET pomůže generovat miniatury snímků.

Pro vygenerování miniatury libovolného požadovaného snímku pomocí Aspose.Slides for .NET:

1. Vytvořte instanci třídy **Presentation**.
1. Získejte odkaz na libovolný požadovaný snímek pomocí jeho ID nebo indexu.
1. Získáte obrázek miniatury odkazovaného snímku v určeném měřítku.
1. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Vytvořte instanci třídy Presentation, která představuje prezentační soubor
using (Presentation pres = new Presentation(srcFileName))
{
    //Přístup k prvnímu snímku
    ISlide sld = pres.Slides[0];

    //Vytvořte obraz v plném měřítku
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Uložte obrázek na disk ve formátu JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)