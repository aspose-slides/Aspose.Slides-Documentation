---
title: Anpassa datapunkter i Treemap och Sunburst diagram med JavaScript
linktitle: Datapunkter i Treemap och Sunburst diagram
type: docs
url: /sv/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- datapunkt
- etikettfärg
- grenfärg
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar datapunkter i treemap- och sunburst-diagram med JavaScript och Aspose.Slides för Node.js via Java, kompatibel med PowerPoint-format."
---
## **Introduktion**

Bland andra typer av PowerPoint-diagram finns två ”hierarkiska” typer – **Treemap** och **Sunburst**‑diagram (även känt som Sunburst‑graf, Sunburst‑diagram, Radial‑diagram, Radial‑graf eller Multi Level Pie Chart). Dessa diagram visar hierarkiska data organiserade som ett träd – från blad till grenens topp. Bladen definieras av serie‑datapunkterna, och varje efterföljande inbäddad gruppering definieras av motsvarande kategori. Aspose.Slides for Node.js via Java möjliggör formatering av datapunkter i Sunburst‑diagram och Treemap i JavaScript.

Här är ett Sunburst‑diagram, där data i kolumnen Series1 definierar bladnoderna, medan andra kolumner definierar hierarkiska datapunkter:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Låt oss börja med att lägga till ett nytt Sunburst‑diagram i presentationen:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Se även" %}} 
- [**Skapa eller uppdatera PowerPoint‑presentationsdiagram i JavaScript**](/slides/sv/nodejs-java/create-chart/)
{{% /alert %}}

Om det finns ett behov av att formatera datapunkter i diagrammet bör vi använda följande:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevel) klasser 
och [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metod 
ger tillgång till att formatera datapunkter i Treemap‑ och Sunburst‑diagram. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
används för att komma åt flernivå‑kategorier – den representerar behållaren för 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevel)‑objekt. I princip är den ett omslag för 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartCategoryLevelsManager) med de egenskaper som lagts till specifikt för datapunkter. 
Klassen [**ChartDataPointLevel**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevel) har två metoder: [**getFormat**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) och 
[**getDataLabel**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) som ger tillgång till motsvarande inställningar.

## **Visa datapunktvärde**

Visa värdet för datapunkten "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ställ in datapunktetikett och färg**

Ställ in datapunktetiketten för "Branch 1" så att den visar serienamnet ("Series1") istället för kategorinamnet. Sätt sedan textfärgen till gult:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ställ in grenfärg för datapunkt**

Ändra färg på grenen "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kan jag ändra ordningen (sorteringen) av segment i Sunburst/Treemap?**

Nej. PowerPoint sorterar segment automatiskt (vanligtvis efter fallande värden, medurs). Aspose.Slides speglar detta beteende: du kan inte ändra ordningen direkt; du uppnår det genom att förbehandla data.

**Hur påverkar presentationstemat färgerna på segment och etiketter?**

Diagramfärger ärver presentationens [tema/palette](/slides/sv/nodejs-java/presentation-theme/) om du inte explicit sätter fyllningar/typsnitt. För konsekventa resultat, lås in solida fyllningar och textformatering på de önskade nivåerna.

**Kommer export till PDF/PNG att behålla anpassade grenfärger och etikettinställningar?**

Ja. Vid export av presentationen bevaras diagraminställningarna (fyllningar, etiketter) i de resulterande filformaten eftersom Aspose.Slides renderar med diagrammets formatering tillämpad.

**Kan jag beräkna de faktiska koordinaterna för en etikett/element för anpassad överlagring ovanpå diagrammet?**

Ja. Efter att diagramlayouten har validerats är faktiska X‑ och Y‑värden tillgängliga för element (t.ex. en [DataLabel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/)), vilket underlättar exakt placering av överlagringar.