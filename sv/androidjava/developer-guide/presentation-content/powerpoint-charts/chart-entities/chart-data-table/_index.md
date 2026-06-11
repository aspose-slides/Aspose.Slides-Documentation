---
title: Anpassa diagramdatatabeller i presentationer på Android
linktitle: Datatabell
type: docs
url: /sv/androidjava/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa diagramdatatabeller i Java för PPT och PPTX med Aspose.Slides för Android för att öka effektiviteten och attraktiviteten i presentationer."
---
## **Overview**

Den här artikeln förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ange teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man läser in en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittsinställningar och sparar den uppdaterade presentationen.

## **Set Font Properties for a Chart Data Table**
Aspose.Slides för Android via Java erbjuder stöd för att ändra färg på kategorier i en serie.  

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassobjekt.
1. Lägg till diagram på bilden.
1. Ställ in diagramtabell.
1. Ange teckensnittshöjd.
1. Spara den ändrade presentationen.

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

**Can I show small legend keys next to the values in the chart’s data table?**

Ja. Datatabellen stöder [legend keys](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), och du kan slå på eller av dem.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/androidjava/convert-powerpoint-to-html/)/[image](/slides/sv/androidjava/convert-powerpoint-to-png/) inkluderar diagrammet med dess datatabell.

**Are data tables supported for charts that come from a template file?**

Ja. För alla diagram som läses in från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [is shown](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#hasDataTable--) med diagrammets egenskaper.

**How can I quickly find which charts in a file have the data table enabled?**

Inspektera varje diagramegenskap som visar om datatabellen [is shown](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#hasDataTable--) och gå igenom bilderna för att identifiera diagrammen där den är aktiverad.