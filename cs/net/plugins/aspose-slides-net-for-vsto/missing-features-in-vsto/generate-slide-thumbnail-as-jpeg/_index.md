---
title: Vytvořit miniaturu snímku jako JPEG
type: docs
weight: 90
url: /cs/net/generate-slide-thumbnail-as-jpeg/
---
Pro vygenerování miniatury libovolného požadovaného snímku pomocí Aspose.Slides pro .NET:

- Vytvořte instanci třídy Presentation.
- Získejte referenci na libovolný požadovaný snímek pomocí jeho ID nebo indexu.
- Získejte obrázek miniatury odkazovaného snímku v zadaném měřítku.
- Uložte obrázek miniatury v libovolném požadovaném formátu obrazu.
## **Příklad**
```cs
//Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Přístup k prvnímu snímku
    ISlide sld = pres.Slides[0];

    //Vytvořte obrázek v plném měřítku
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Uložte obrázek na disk ve formátu JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pro více podrobností navštivte [Převod PPT a PPTX na JPG v .NET](/slides/cs/net/convert-powerpoint-to-jpg/).

{{% /alert %}}