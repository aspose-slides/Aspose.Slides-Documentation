---
title: Generování náhledu ze snímku s uživatelsky definovanými rozměry
type: docs
weight: 100
url: /cs/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Chcete-li vygenerovat náhled libovolného požadovaného snímku pomocí Aspose.Slides pro .NET:

- Vytvořte instanci třídy Presentation.
- Získejte odkaz na požadovaný snímek pomocí jeho ID nebo indexu.
- Zjistěte měřítka X a Y na základě uživatelem definovaných rozměrů X a Y.
- Získejte obrázek náhledu referencovaného snímku v určeném měřítku.
- Uložte obrázek náhledu v libovolném požadovaném formátu obrázku.
## **Příklad**
```cs
//Instancujte třídu Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Přístup k prvnímu snímku
    ISlide sld = pres.Slides[0];

    //Uživatelsky definovaný rozměr
    int desiredX = 1200;
    int desiredY = 800;

    //Získání škálovaných hodnot X a Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Vytvořte obrázek v plném měřítku
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Uložte obrázek na disk ve formátu JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Pro více informací navštivte [Převést snímek](/slides/cs/net/convert-slide/).
{{% /alert %}}