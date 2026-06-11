---
title: Anpassa bubbeldiagram i presentationer med JavaScript
linktitle: Bubbeldiagram
type: docs
url: /sv/nodejs-java/bubble-chart/
keywords:
- bubbeldiagram
- bubbelförstorlek
- storleksskalning
- storleksrepresentation
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med JavaScript och Aspose.Slides för Node.js via Java för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Den här artikeln visar hur du arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: att skala bubbelförstorlekar via metoden `setBubbleSizeScale` och att kontrollera hur bubbelförstorelsevärden representeras via metoden `setBubbleSizeRepresentation`.

Exemplen visar hur man skapar ett bubbeldiagram, justerar dess storleksskala och byter bubbelförstorelserepresentation till bredd. Artikeln innehåller också ett kort FAQ‑avsnitt som klargör stöd för diagramtypen “Bubble with 3-D”, påpekar att praktiska diagramgränser beror på prestanda och mål‑PowerPoint‑version samt förklarar att export bevarar diagrammets utseende via Aspose.Slides renderingsmotor.

## **Skalning av bubbeldiagramsstorlek**
Aspose.Slides för Node.js via Java erbjuder stöd för skalning av bubbeldiagramsstorlek. I Aspose.Slides för Node.js via Java har metoderna [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--) , [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) och [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) lagts till. Nedan ges ett exempel.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Representera data som bubbeldiagramstorlekar**
Metoderna [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) och [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) har lagts till i klasserna [ChartSeries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeries) , [ChartSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesGroup) och relaterade klasser. **BubbleSizeRepresentation** specificerar hur bubbelförstorelsevärden representeras i bubbeldiagrammet. Möjliga värden är: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) och [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Enligt detta har enum‑typen [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/BubbleSizeRepresentationType) lagts till för att ange de möjliga sätten att representera data som bubbeldiagramstorlekar. Exempelkod ges nedan.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Stöds ett “bubbeldiagram med 3‑D‑effekt”, och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, “Bubble with 3-D”. Den tillämpar 3‑D‑stil på bubblorna men lägger inte till någon extra axel; data förblir X‑Y‑S (storlek). Typen finns i uppräkningen [chart type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/).

**Finns det någon gräns för antalet serier och punkter i ett bubbeldiagram?**

Det finns ingen hård gräns på API‑nivå; begränsningar bestäms av prestanda och mål‑PowerPoint‑version. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödjade format bevarar diagrammets utseende; rendering utförs av Aspose.Slides‑motorn. För raster‑/vektormat—format gäller generella regler för diagramgrafik (upplösning, antialiasing), så välj tillräcklig DPI för utskrift.