---
title: Anpassa diagramdatatabeller i presentationer med JavaScript
linktitle: Datatabell
type: docs
url: /sv/nodejs-java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa diagramdatatabeller i JavaScript för PPT och PPTX med Aspose.Slides för Node.js via Java för att öka effektiviteten och attraktionskraften i presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att sätta teckensnittsegenskaper såsom fet stil och teckenhöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

Den innehåller även korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram laddade från befintliga presentationer eller mallar, samt identifiera diagram där datatabellen är aktiverad.

## **Ange teckensnittsegenskaper för diagramdatatabell**

Aspose.Slides for Node.js via Java erbjuder stöd för att ändra färg på kategorier i en serie. 

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klassobjekt.
1. Lägg till ett diagram på bilden.
1. ange diagramtabell.
1. Sätt teckenhöjd.
1. Spara den modifierade presentationen.

 Nedan ges ett exempel. 

```javascript
// Skapar tom presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [legend keys](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setshowlegendkey/), och du kan slå på eller av dem.

**Behålls datatabellen när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/sv/nodejs-java/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För alla diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [is shown](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/hasdatatable/) med hjälp av diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagramegenskap som indikerar om datatabellen [is shown](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/hasdatatable/) och gå igenom bilderna för att identifiera diagrammen där den är aktiverad.