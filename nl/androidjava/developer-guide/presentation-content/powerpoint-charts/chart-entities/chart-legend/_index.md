---
title: Grafieklegenden aanpassen in presentaties op Android
linktitle: Grafieklegende
type: docs
url: /nl/androidjava/chart-legend/
keywords:
- grafieklegende
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas grafieklegenden aan met Aspose.Slides voor Android via Java om PowerPoint‑presentaties te optimaliseren met op maat gemaakte legende‑opmaak."
---
## **Overzicht**

Aspose.Slides for Android via Java biedt mogelijkheden om legenden van grafieken in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe je een legende positioneert en de grootte ervan instelt, de lettergrootte voor de hele legende bepaalt, een individuele legende‑item formatteert, en geselecteerde items verbergt of herstelt.

De FAQ behandelt gerelateerde gedragspatronen, waaronder het reserveren van ruimte voor de legende, het weergeven van meerregelige labels en het overnemen van opmaak van het presentatiethema.

## **Legendepositionering**

Gebruik de [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), en [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) methoden om de positie en grootte ervan op te geven als een fractie van de afmetingen van de grafiek.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste offset- en afmetingswaarden van de legende te delen door de breedte en hoogte van de grafiek, worden ze omgezet naar relatieve waarden: de legende wordt 50 punten vanaf de linkerbovenhoek van de grafiek verplaatst en heeft een grootte van 100 bij 100 punten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Druk de positie en grootte van de legende uit relatief ten opzichte van de grafiek.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de lettergrootte van een legende in**

Gebruik de [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) van de legende om de tekstopmaak te benaderen en gebruik [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) om de lettergrootte in punten in te stellen.

Dit voorbeeld maakt een grafiek met standaardgegevens en stelt de legendetekst in op 20 punten. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de lettergrootte van een individueel legende‑item in**

Gebruik de collectie die wordt geretourneerd door de [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) methode van de legende om de opmaak van een specifiek item te benaderen. Item‑indices beginnen bij nul, dus index `1` verwijst naar het tweede item.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarvan de standaardgegevens minstens twee reeksen bevatten. Het formatteert het tweede legende‑item met vet, cursief en blauwe tekst van 20 punten.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verberg individuele legende‑items**

Om een aanvullende reeks uit de legende te verwijderen terwijl de gegevens zichtbaar blijven, roep je [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) aan met `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Dit verbergt alleen het geselecteerde legende‑item; het verwijdert de reeks of de gegevenspunten niet. Het aanroepen van [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) met `false` daarentegen verbergt de volledige legende.

Het onderstaande voorbeeld maakt een gegroepeerde kolomgrafiek met meerdere reeksen met standaardgegevens. Het verbergt het legende‑item van de tweede reeks (index `1`) en slaat de presentatie op. Vervolgens wordt het item hersteld door [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) aan te roepen met `false` en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Herstel hetzelfde item zonder de grafiekgegevens te wijzigen.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vergelijking hieronder toont dezelfde grafiek met alle items zichtbaar en met het tweede item verborgen. De kolommen van de tweede reeks blijven ongewijzigd.

![Vergelijking van een grafiek met alle legende‑items zichtbaar en met Serie 2 verborgen in de legende; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom-, staaf- en lijngrafieken geven legende‑items de reeksen aan. Voor cirkeldiagrammen geven ze individuele gegevenspunten (segmenten) aan, dus gebruik je in plaats daarvan [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) op het geselecteerde segment. De API documenteert deze methode voor gegevenspunten voor de grafiektype `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Ga er niet van uit dat deze ook van toepassing is op donuts‑grafieken, die niet in die lijst staan.

## **FAQ**

**Kan ik de grafiek ruimte reserveren voor de legende in plaats van deze eroverheen te leggen?**

Ja. Roep [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) aan met `false` om ruimte voor de legende te reserveren in plaats van toe te staan dat deze het tekengebied overlapt.

**Kan ik meerregelige legende‑labels maken?**

Ja. Lange labels kunnen afbreken wanneer de beschikbare breedte onvoldoende is. Je kunt ook reeksnamen voorzien van regeleinde‑tekens om een regeleinde af te dwingen.

**Hoe zorg ik ervoor dat de legende het kleurenschema van het presentatiethema volgt?**

Laat de kleuren, opvullingen en lettertypen van de legende ongedefinieerd, zodat deze de thematische opmaak kan overnemen. Expliciete opmaak overschrijft de bijbehorende themainstellingen.