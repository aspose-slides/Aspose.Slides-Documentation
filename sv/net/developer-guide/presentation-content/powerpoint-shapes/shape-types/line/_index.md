---
title: Lägg till linjeformer i presentationer i .NET
linktitle: Linje
type: docs
weight: 50
url: /sv/net/line/
keywords:
- linje
- skapa linje
- lägga till linje
- enkel linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att manipulera linjeformatering i PowerPoint-presentationer med Aspose.Slides för .NET. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides låter dig lägga till linjeformer i PowerPoint-bilder programmässigt. Denna artikel visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska inställningar för linjeformatering såsom stil, tjocklek, streckmönster, pilspetsalternativ och fyllningsfärg.

## **Skapa en enkel linje**
För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av [AddAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/methods/addautoshape/index)-metoden som exponeras av Shapes-objektet.
- Skriv den modifierade presentationen som en PPTX-fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```c#
// Skapa en instans av PresentationEx-klassen som representerar PPTX-filen
using (Presentation pres = new Presentation())
{
    // Hämta den första bilden
    ISlide sld = pres.Slides[0];

    // Lägg till en autoshape av typen linje
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write PPTX-filen till disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Skapa en pilformad linje**
Aspose.Slides för .NET låter också utvecklare konfigurera vissa egenskaper hos linjen för att göra den mer attraktiv. Låt oss försöka konfigurera några egenskaper så att linjen ser ut som en pil. Följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av AddAutoShape-metoden som exponeras av Shapes-objektet.
- Ställ in Linjestilen till någon av de stilar som erbjuds av Aspose.Slides för .NET.
- Ställ in linjens bredd.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/net/aspose.slides/linedashstyle) för linjen till någon av de stilar som erbjuds av Aspose.Slides för .NET.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/net/aspose.slides/linearrowheadstyle) och längd för linjens startpunkt.
- Ställ in pilspetsstil och längd för linjens slutpunkt.
- Skriv den modifierade presentationen som en PPTX-fil.

```c#
// Instansiera PresentationEx-klassen som representerar PPTX-filen
using (Presentation pres = new Presentation())
{

    // Hämta den första bilden
    ISlide sld = pres.Slides[0];

    // Lägg till en autoshape av typen linje
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Tillämpa någon formatering på linjen
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Skriv PPTX-filen till disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en anslutning så att den "snäpper" till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/net/aspose.slides/shapetype/)) blir inte automatiskt en anslutning. För att den ska snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/net/aspose.slides/connector/)-typen och de [corresponding APIs](/slides/sv/net/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att avgöra de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/net/shape-effective-properties/) via [ILineFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/sv/net/aspose.slides/ilinefillformateffectivedata/)-gränssnitten—dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Shapes tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/autoshapelock/) som låter dig [disallow editing operations](/slides/sv/net/applying-protection-to-presentation/).