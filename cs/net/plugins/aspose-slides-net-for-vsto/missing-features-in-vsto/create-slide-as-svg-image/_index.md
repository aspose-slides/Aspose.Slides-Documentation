---
title: Vytvořit snímek jako SVG obrázek
type: docs
weight: 70
url: /cs/net/create-slide-as-svg-image/
---
Pro vygenerování obrázku SVG z libovolného požadovaného snímku pomocí Aspose.Slides.Pptx pro .NET postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation.
- Získejte odkaz na požadovaný snímek pomocí jeho ID nebo indexu.
- Načtěte obrázek SVG do paměťového proudu.
- Uložte paměťový proud do souboru.

## **Příklad**

```

 //Vytvořte instanci třídy Presentation, která představuje soubor prezentace

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Přístup k druhému snímku

   ISlide sld = pres.Slides[1];

   //Vytvořte objekt paměťového proudu

   MemoryStream SvgStream = new MemoryStream();

   //Vygenerujte SVG obrázek snímku a uložte jej do paměťového proudu

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Uložte paměťový proud do souboru

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

   }

SvgStream.Close();

``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)

## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Pro více informací navštivte [Renderování snímků prezentace jako SVG obrázky v .NET](/slides/cs/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}