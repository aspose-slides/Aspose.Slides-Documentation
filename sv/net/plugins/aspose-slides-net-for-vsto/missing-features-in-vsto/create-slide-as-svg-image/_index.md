---
title: Skapa bild som SVG-bild
type: docs
weight: 70
url: /sv/net/create-slide-as-svg-image/
---
För att generera en SVG-bild från vilken önskad bild som helst med Aspose.Slides.Pptx för .NET, följ stegen nedan:

- Skapa en instans av Presentation-klassen.
- Hämta referensen till den önskade bilden genom att använda dess ID eller index.
- Hämta SVG-bilden i en minnesström.
- Spara minnesströmmen till en fil.
## **Exempel**

```

 //Instansiera en Presentation-klass som representerar presentationsfilen

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
   //Åtkomst till den andra bilden
   ISlide sld = pres.Slides[1];
   //Skapa ett minnesström-objekt
   MemoryStream SvgStream = new MemoryStream();
   //Generera en SVG-bild av bilden och spara i minnesström
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //Spara minnesström till fil
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
}
SvgStream.Close();
``` 
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

För mer information, besök [Rendera presentationsbilder som SVG-bilder i .NET](/slides/sv/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}