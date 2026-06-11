---
title: Anpassa bubbeldiagram i presentationer i .NET
linktitle: Bubbeldiagram
type: docs
url: /sv/net/bubble-chart/
keywords:
- bubbeldiagram
- bubbelförstorlek
- storleksskalning
- storleksrepresentation
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för .NET för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Denna artikel visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbelformer via egenskapen `BubbleSizeScale` och styrning av hur bubbelförstoringsvärden representeras via egenskapen `BubbleSizeRepresentation`.

Exemplen visar hur man skapar ett bubbeldiagram, justerar dess storleksskalning och byter bubbelförstoringsrepresentation till att använda bredd. Artikeln innehåller också ett kort Vanliga frågor-avsnitt som klargör stöd för diagramtypen “Bubble with 3-D”, noterar att praktiska diagramgränser beror på prestanda och målversionen av PowerPoint, samt förklarar att export bevarar diagrammets utseende via Aspose.Slides rendering‑motor.

## **Skalning av bubbeldiagrammets storlek**
Aspose.Slides för .NET erbjuder stöd för skalning av bubbeldiagrammens storlek. I Aspose.Slides för .NET har egenskaperna **IChartSeries.BubbleSizeScale** och **IChartSeriesGroup.BubbleSizeScale** lagts till. Nedan visas ett exempel.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Representera data som bubbeldiagramstorlekar**
Egendomen **BubbleSizeRepresentation** har lagts till i IChartSeries-, IChartSeriesGroup‑gränssnitten och relaterade klasser. **BubbleSizeRepresentation** anger hur bubbelförstoringsvärdena representeras i bubbeldiagrammet. Möjliga värden är **BubbleSizeRepresentationType.Area** och **BubbleSizeRepresentationType.Width**. På motsvarande sätt har enum‑typen **BubbleSizeRepresentationType** lagts till för att specificera de möjliga sätten att representera data som bubbeldiagramstorlekar. Nedanstående kodexempel visas.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Stöds ett “bubbeldiagram med 3‑D‑effekt”, och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, “Bubble with 3‑D”. Den applicerar 3‑D‑stil på bubblorna men lägger inte till en extra axel; data förblir X‑Y‑S (storlek). Typen är tillgänglig i enum‑värdet [chart type](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/).

**Finns det någon gräns för antal serier och datapunkter i ett bubbeldiagram?**

Det finns ingen strikt gräns på API‑nivå; begränsningarna bestäms av prestanda och målversionen av PowerPoint. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödjda format bevarar diagrammets utseende; rendering utförs av Aspose.Slides‑motorn. För raster‑/vektormatier gäller allmänna regler för diagramgrafikrendering (upplösning, kantutjämning), så välj en tillräcklig DPI för utskrift.