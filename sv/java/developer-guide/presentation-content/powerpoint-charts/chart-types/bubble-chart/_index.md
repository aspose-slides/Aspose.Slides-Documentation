---
title: Anpassa bubbeldiagram i presentationer med Java
linktitle: Bubbeldiagram
type: docs
url: /sv/java/bubble-chart/
keywords:
- bubbeldiagram
- bubbelstorlek
- storleksskalning
- storleksrepresentation
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för Java för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Den här artikeln visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbelt storlekar via metoden `setBubbleSizeScale` och styrning av hur bubbelt storleksvärden representeras via metoden `setBubbleSizeRepresentation`.

Exemplen demonstrerar hur man skapar ett bubbeldiagram, justerar dess storleksskalning och byter bubbelt storleksrepresentation till att använda bredd. Artikeln innehåller också ett kort avsnitt med vanliga frågor som förklarar stöd för diagramtypen “Bubble with 3-D”, noterar att praktiska diagramgränser beror på prestanda och mål‑PowerPoint‑version, samt förklarar att export bevarar diagrammets utseende via Aspose.Slides rendering‑motor.

## **Skalning av bubbeldiagramstorlek**
Aspose.Slides for Java tillhandahåller stöd för skalning av bubbeldiagramstorlek. I Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) och [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) har lagts till. Nedan ges ett exempel.  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Representera data som bubbeldiagramstorlekar**
Metoderna [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) och [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) har lagts till på [IChartSeries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesGroup)‑gränssnitten och relaterade klasser. **BubbleSizeRepresentation** anger hur bubbelt storleksvärden representeras i bubbeldiagrammet. Möjliga värden är: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/BubbleSizeRepresentationType#Area) och [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Därmed har enum‑typen [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/BubbleSizeRepresentationType) lagts till för att ange de möjliga sätten att representera data som bubbeldiagramstorlekar. Exempelkod ges nedan.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Stöds ett “bubbeldiagram med 3‑D‑effekt”, och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, “Bubble with 3‑D”. Den applicerar 3‑D‑stil på bubblorna men lägger inte till någon extra axel; data förblir X‑Y‑S (storlek). Typen finns tillgänglig i klassen [chart type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/).

**Finns det någon gräns för antalet serier och datapunkter i ett bubbeldiagram?**

Det finns ingen hård gräns på API‑nivå; begränsningarna bestäms av prestanda och mål‑PowerPoint‑version. Det rekommenderas att hålla antalet datapunkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till de stödda formaten bevarar diagrammets utseende; rendering utförs av Aspose.Slides‑motorn. För raster‑ och vektorformat gäller generella diagramgrafik‑renderingsregler (upplösning, anti‑aliasing), så välj tillräcklig DPI för utskrift.