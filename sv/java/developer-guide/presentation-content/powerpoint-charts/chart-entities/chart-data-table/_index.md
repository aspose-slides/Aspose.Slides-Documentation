---
title: Anpassa diagramdatatabeller i presentationer med Java
linktitle: Datatabell
type: docs
url: /sv/java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Anpassa diagramdatatabeller i Java för PPT och PPTX med Aspose.Slides för att öka effektiviteten och attraktiviteten i presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ställa in teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

Den innehåller också korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram som laddats från befintliga presentationer eller mallar samt identifiera diagram där datatabellen är aktiverad.

## **Ställ in teckensnittsegenskaper för en diagramdatatabell**
Aspose.Slides for Java erbjuder stöd för att ändra färg på kategorier i en seriefärg.  

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) klassobjekt.  
1. Lägg till ett diagram på bilden.  
1. Ställ in diagrammets tabell.  
1. Ange teckenhöjd.  
1. Spara den modifierade presentationen.  

Nedan ges ett exempel.  

```java
// Skapar tom presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [förklaringsnycklar](https://reference.aspose.com/slides/sv/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/java/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/java/convert-powerpoint-to-html/)/[image](/slides/sv/java/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För alla diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [visas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#hasDataTable--) med diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagram egenskap som indikerar om datatabellen [visas](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#hasDataTable--) och iterera genom bilderna för att identifiera de diagram där den är aktiverad.