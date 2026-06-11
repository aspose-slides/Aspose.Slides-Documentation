---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram på Android
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-diagram
- sunburst-diagram
- datapunkt
- etikettfärg
- grenfärg
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar datapunkter i treemap- och sunburst-diagram med Aspose.Slides för Android via Java, kompatibel med PowerPoint-format."
---
## **Introduktion**

Bland andra typer av PowerPoint‑diagram finns två ”hierarkiska” typer – **Treemap** och **Sunburst**‑diagram (även känt som Sunburst‑graf, Sunburst‑diagram, Radial‑diagram, Radial‑graf eller Multi Level Pie Chart). Dessa diagram visar hierarkiska data organiserade som ett träd – från blad till grenens topp. Bladen definieras av seriedatapunkterna, och varje efterföljande inbäddad gruppering definieras av motsvarande kategori. Aspose.Slides för Android via Java möjliggör formatering av datapunkter i Sunburst‑diagram och Treemap i Java.

Här är ett Sunburst‑diagram, där data i kolumnen Series1 definierar bladtavlorna, medan andra kolumner definierar hierarkiska datapunkter:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Låt oss börja med att lägga till ett nytt Sunburst‑diagram i presentationen:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Se även" %}} 
- [**Skapa eller uppdatera PowerPoint‑presentationdiagram på Android**](/slides/sv/androidjava/create-chart/)
{{% /alert %}}

Om det finns behov av att formatera diagrammets datapunkter bör vi använda följande:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevel) klasser och [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metod ger åtkomst till att formatera datapunkter i Treemap och Sunburst‑diagram. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevelsManager) används för att komma åt flernivåkategorier – den representerar behållaren för [**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevel)‑objekt. I princip är den ett omslag för [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartCategoryLevelsManager) med egenskaper som lagts till specifikt för datapunkter. Klassen [**IChartDataPointLevel**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevel) har två metoder: [**getFormat**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) och [**getDataLabel**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) som ger åtkomst till motsvarande inställningar.

## **Visa ett datapunktsvärde**
Visa värdet för datapunkten "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Ställ in datapunktetikett och färg**
Ställ in datapunktetiketten för "Branch 1" så att den visar seriens namn ("Series1") istället för kategorinamnet. Ställ sedan in textfärgen till gul:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Ställ in grenfärg för datapunkt**
Ändra färg på grenen "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Vanliga frågor**

**Kan jag ändra ordningen (sorteringen) av segment i Sunburst/Treemap?**

Nej. PowerPoint sorterar segment automatiskt (vanligtvis efter fallande värden, medurs). Aspose.Slides speglar detta beteende: du kan inte ändra ordningen direkt; du uppnår det genom att förbehandla data.

**Hur påverkar presentationens tema färgerna på segment och etiketter?**

Diagrammens färger ärver presentationens [tema/palett](/slides/sv/androidjava/presentation-theme/) om du inte uttryckligen anger fyllningar/typsnitt. För konsekventa resultat, lås fast solida fyllningar och textformatering på de nivåer som krävs.

**Kommer export till PDF/PNG att bevara anpassade grenfärger och etiketinställningar?**

Ja. Vid export av presentationen bevaras diagraminställningarna (fyllningar, etiketter) i de exporterade formaten eftersom Aspose.Slides renderar med diagrammets formatering tillämpad.

**Kan jag beräkna de faktiska koordinaterna för en etikett/element för anpassad överlagring ovanpå diagrammet?**

Ja. Efter att diagramlayouten har validerats är de faktiska *x*- och *y*-koordinaterna tillgängliga för element (t.ex. en [DataLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/datalabel/)), vilket underlättar exakt placering av överlagringar.