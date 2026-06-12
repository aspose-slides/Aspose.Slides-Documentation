---
title: Aanpassen van plotgebieden van presentatiediagrammen in Java
linktitle: Plotgebied
type: docs
url: /nl/java/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- layoutmodus
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint-presentaties kunt aanpassen met Aspose.Slides voor Java. Verbeter moeiteloos de weergave van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u met het plotgebied van een grafiek in Aspose.Slides kunt werken. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied kunt verkrijgen door de grafieklay-out te valideren en vervolgens de X‑, Y‑, breedte‑ en hoogte‑waarden te lezen.

Het toont ook hoe u de lay‑outmodus van het plotgebied kunt configureren wanneer de lay‑out handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plotgebied wordt berekend op basis van het binnenste gebied of van het buitenste gebied, inclusief assen en aslabels.

## **Krijg breedte en hoogte van een grafiek‑plotgebied**
Aspose.Slides for Java biedt een eenvoudige API voor .

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Roep de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart#validateChartLayout--) aan om de werkelijke waarden te verkrijgen.
5. Haalt de werkelijke X‑locatie (links) van het grafiekelement op, relatief ten opzichte van de linkerbovenhoek van de grafiek.
6. Haalt de werkelijke bovenkant van het grafiekelement op, relatief ten opzichte van de linkerbovenhoek van de grafiek.
7. Haalt de werkelijke breedte van het grafiekelement op.
8. Haalt de werkelijke hoogte van het grafiekelement op.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Stel de lay‑outmodus van een grafiek‑plotgebied in**
Aspose.Slides for Java biedt een eenvoudige API om de lay‑outmodus van het plotgebied van een grafiek in te stellen. De methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) en [**getLayoutTargetType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) zijn toegevoegd aan de klasse [**ChartPlotArea**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartPlotArea) en de interface [**IChartPlotArea**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartPlotArea). Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, geeft deze eigenschap aan of het plotgebied moet worden opgemaakt op basis van de binnenkant (exclusief assen en aslabels) of op basis van de buitenkant (inclusief assen en aslabels). Er zijn twee mogelijke waarden die gedefinieerd zijn in de enum [**LayoutTargetType**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LayoutTargetType#Inner) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied bepaalt, zonder de markeringen en aslabels.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/LayoutTargetType#Outer) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied, de markeringen en de aslabels bepaalt.

Voorbeeldcode staat hieronder.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**In welke eenheden worden de werkelijke x, werkelijke y, werkelijke breedte en werkelijke hoogte geretourneerd?**

In punten; 1 inch = 72 punten. Dit zijn de coördinaten‑eenheden van Aspose.Slides.

**Hoe verschilt het Plot‑gebied van het Grafiek‑gebied wat betreft inhoud?**

Het Plot‑gebied is de regio waar de data worden getekend (reeksen, rasterlijnen, trendlijnen, enz.). Het Grafiek‑gebied bevat de omringende elementen (titel, legenda, enz.). In 3D‑grafieken omvat het Plot‑gebied ook de wanden/vloer en de assen.

**Hoe worden de x, y, breedte en hoogte van het Plot‑gebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Ze zijn fracties (0‑1) van de totale grootte van de grafiek; in deze modus is automatisch positioneren uitgeschakeld en worden de door u ingestelde fracties gebruikt.

**Waarom veranderde de positie van het Plot‑gebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het grafiekgebied buiten het Plot‑gebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het Plot‑gebied kan verschuiven wanneer automatisch positioneren actief is. (Dit is standaardgedrag voor PowerPoint‑grafieken.)