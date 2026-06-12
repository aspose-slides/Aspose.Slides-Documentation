---
title: Dia maken als SVG-afbeelding
type: docs
weight: 70
url: /nl/net/create-slide-as-svg-image/
---
Om een SVG-afbeelding te genereren van een gewenste dia met Aspose.Slides.Pptx voor .NET, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation-klasse.
- Haal de referentie van de gewenste dia op via de ID of index.
- Verkrijg de SVG-afbeelding in een memorystroom.
- Sla de memorystroom op naar een bestand.
## **Voorbeeld**

```

 //Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Toegang tot de tweede dia

   ISlide sld = pres.Slides[1];

   //Maak een MemoryStream-object aan

   MemoryStream SvgStream = new MemoryStream();

   //Genereer een SVG-afbeelding van de dia en sla deze op in de memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Sla de memory stream op naar een bestand

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
## **Voorbeeld downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Dia's van presentaties renderen als SVG-afbeeldingen in .NET](/slides/nl/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}