---
title: Plotgebieden van presentatiediagrammen aanpassen op Android
linktitle: Plotgebied
type: docs
url: /nl/androidjava/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint‑presentaties kunt aanpassen met Aspose.Slides voor Android via Java. Verbeter moeiteloos de weergave van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u met het plotgebied van een grafiek in Aspose.Slides werkt. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied kunt verkrijgen door de lay‑out van de grafiek te valideren en vervolgens de X-, Y‑, breedte‑ en hoogte‑waarden te lezen.

Het laat ook zien hoe u de lay‑outmodus van het plotgebied kunt configureren wanneer de lay‑out handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plotgebied wordt berekend op basis van de binnenste regio of van de buitenste regio samen met assen en aslabels.

## **Breedte en hoogte van een grafiek‑plotgebied ophalen**
Aspose.Slides for Android via Java biedt een eenvoudige API.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse aan.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Roep de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#validateChartLayout--) aan om de werkelijke waarden te verkrijgen.
1. Haal de werkelijke X‑positie (links) van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haal de werkelijke boven‑positie van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haal de werkelijke breedte van het grafiekelement op.
1. Haal de werkelijke hoogte van het grafiekelement op.

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

## **Lay‑outmodus van een grafiek‑plotgebied instellen**
Aspose.Slides for Android via Java biedt een eenvoudige API om de lay‑outmodus van het plotgebied van een grafiek in te stellen. De methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) en [**getLayoutTargetType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) zijn toegevoegd aan de klasse [**ChartPlotArea**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartPlotArea) en de interface [**IChartPlotArea**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartPlotArea). Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, bepaalt deze eigenschap of het plotgebied wordt ingedeeld op basis van de binnenkant (exclusief assen en aslabels) of van de buitenkant (inclusief assen en aslabels). Er zijn twee mogelijke waarden die gedefinieerd zijn in de enumeratie [**LayoutTargetType**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LayoutTargetType#Inner) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied bepaalt, exclusief de tick‑marks en aslabels.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/LayoutTargetType#Outer) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied, de tick‑marks en de aslabels bepaalt.

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

In punten; 1 inch = 72 punten. Dit zijn de coördineerne eenheden van Aspose.Slides.

**Hoe verschilt het plotgebied van het grafiekgebied qua inhoud?**

Het plotgebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enz.); het grafiekgebied omvat de omliggende elementen (titel, legenda, enz.). Bij 3D‑grafieken omvat het plotgebied ook de wanden/vloer en de assen.

**Hoe worden de x, y, breedte en hoogte van het plotgebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Ze worden weergegeven als fracties (0-1) van de totale grootte van de grafiek; in deze modus is auto‑positionering uitgeschakeld en worden de door u opgegeven fracties gebruikt.

**Waarom veranderde de positie van het plotgebied nadat de legenda was toegevoegd/verplaatst?**

De legenda bevindt zich in het grafiekgebied buiten het plotgebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het plotgebied kan verschuiven wanneer auto‑positionering actief is. (Dit is standaardgedrag voor PowerPoint‑grafieken.)