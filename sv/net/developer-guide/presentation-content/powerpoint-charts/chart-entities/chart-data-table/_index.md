---
title: Anpassa diagramdatatabeller i presentationer i .NET
linktitle: Datatabell
type: docs
url: /sv/net/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Anpassa diagramdatatabeller i .NET för PPT och PPTX med Aspose.Slides för att öka effektiviteten och attraktionskraften i presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ange teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

Den innehåller också korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram som laddas från befintliga presentationer eller mallar samt identifiera diagram där datatabellen är aktiverad.

## **Ange teckensnittsegenskaper för en diagramdatatabell**
Aspose.Slides för .NET erbjuder stöd för att ändra färg på kategorier i en serie.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassobjekt.
1. Lägg till ett diagram på sliden.
1. Ställ in diagrammets datatabell.
1. Ställ in teckenhöjd.
1. Spara den ändrade presentationen.

Nedanstående exempel ges.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [förklaringsnycklar](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/datatable/showlegendkey/), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av sliden, så den exporterade [PDF](/slides/sv/net/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/net/convert-powerpoint-to-html/)/[bild](/slides/sv/net/convert-powerpoint-to-png/) inkluderar diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För varje diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [visas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/hasdatatable/) med diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagram egenskap som indikerar om datatabellen [visas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/hasdatatable/) och iterera genom slidsen för att identifiera de diagram där den är aktiverad.