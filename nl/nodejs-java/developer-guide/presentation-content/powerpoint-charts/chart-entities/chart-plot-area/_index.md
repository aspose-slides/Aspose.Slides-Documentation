---
title: Pas plotgebieden van presentatiediagrammen aan in JavaScript
linktitle: Plotgebied
type: docs
url: /nl/nodejs-java/chart-plot-area/
keywords:
- grafiek
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van grafieken in PowerPoint‑presentaties kunt aanpassen met JavaScript en Aspose.Slides voor Node.js. Verbeter moeiteloos de visuele weergave van uw dia's."
---
## **Overzicht**

Dit artikel toont hoe u met het plotgebied van een grafiek in Aspose.Slides kunt werken. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied kunt verkrijgen door de grafieklay-out te valideren en vervolgens de X‑, Y‑, breedte‑ en hoogte‑waarden uit te lezen.

Het laat bovendien zien hoe u de lay‑outmodus van het plotgebied kunt configureren wanneer de lay‑out handmatig wordt ingesteld, gebruikmakend van `LayoutTargetType` om te definiëren of het plotgebied wordt berekend op basis van zijn binnenste gebied of van zijn buitenste gebied, samen met assen en aslabels.

## **Breedte en hoogte van het plotgebied van een grafiek ophalen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor . 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Roep de methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#validateChartLayout--) aan vóór het verkrijgen van de werkelijke waarden.
5. Krijgt de werkelijke X‑locatie (links) van het grafiekelement ten opzichte van de linkerbovenhoek van de grafiek.
6. Krijgt de werkelijke bovenkant van het grafiekelement ten opzichte van de linkerbovenhoek van de grafiek.
7. Krijgt de werkelijke breedte van het grafiekelement.
8. Krijgt de werkelijke hoogte van het grafiekelement.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lay‑outmodus van het plotgebied van een grafiek instellen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API om de lay‑outmodus van het plotgebied van een grafiek in te stellen. De methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) en [**getLayoutTargetType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) zijn toegevoegd aan de klasse [**ChartPlotArea**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartPlotArea). Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, bepaalt deze eigenschap of het plotgebied wordt gelayout door de binnenkant (exclusief assen en aslabels) of door de buitenkant (inclusief assen en aslabels). Er zijn twee mogelijke waarden die zijn gedefinieerd in de enumeratie [**LayoutTargetType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LayoutTargetType#Inner) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied bepaalt, zonder de tickmarks en aslabels.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/LayoutTargetType#Outer) - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied, de tickmarks en de aslabels bepaalt.

Voorbeeldcode wordt hieronder gegeven.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**In welke eenheden worden werkelijke X, werkelijke Y, werkelijke breedte en werkelijke hoogte geretourneerd?**

In points; 1 inch = 72 points. Dit zijn de coördinaateenheden van Aspose.Slides.

**Hoe verschilt het plotgebied van het grafiekgebied qua inhoud?**

Het plotgebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enz.); het grafiekgebied omvat de omringende elementen (titel, legenda, enz.). In 3D‑grafieken omvat het plotgebied ook de wanden/vloer en de assen.

**Hoe worden de X, Y, breedte en hoogte van het plotgebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Ze worden weergegeven als breuken (0–1) van de totale grootte van de grafiek; in deze modus is automatische positionering uitgeschakeld en worden de door u ingestelde breuken gebruikt.

**Waarom veranderde de positie van het plotgebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het grafiekgebied buiten het plotgebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het plotgebied kan verschuiven wanneer automatische positionering actief is. (Dit is standaardgedrag voor PowerPoint‑grafieken.)