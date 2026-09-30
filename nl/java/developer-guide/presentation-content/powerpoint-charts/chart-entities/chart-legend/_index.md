---
title: Grafieklegenda aanpassen in presentaties met Java
linktitle: Grafieklegenda
type: docs
url: /nl/java/chart-legend/
keywords:
- grafieklegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides for Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides for Java biedt opties om de legenda van diagrammen in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe je een legenda positioneert en de grootte ervan bepaalt, de lettergrootte voor de hele legenda instelt, een individueel legende‑item opmaakt en geselecteerde items verbergt of herstelt.

De FAQ behandelt gerelateerde gedrag, waaronder het reserveren van ruimte voor de legende, het weergeven van labels over meerdere regels en het overnemen van opmaak uit het thema van de presentatie.

## **Legende positionering**

Gebruik de methoden van de legende [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), en [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) om de positie en grootte ervan op te geven als fracties van de afmetingen van het diagram.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste legende‑offsets en afmetingen te delen door de breedte en hoogte van het diagram, worden ze omgezet naar relatieve waarden: de legende wordt 50 punten verplaatst vanaf de linkerbovenhoek van het diagram en krijgt een grootte van 100 bij 100 punten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Geef de positie en grootte van de legende weer ten opzichte van het diagram.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lettergrootte van de legende instellen**

Gebruik de [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) van de legende om de tekstopmaak te benaderen en gebruik [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) om de lettergrootte in punten in te stellen.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legendetekst in op 20 punten. Het schakelt ook automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot 10.

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

## **Lettergrootte van een individueel legende‑item instellen**

Gebruik de collectie die wordt geretourneerd door de [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) methode van de legende om de opmaak van een specifiek item te benaderen. Item‑indexen beginnen bij nul, dus index `1` verwijst naar het tweede item.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarvan de standaardgegevens ten minste twee reeksen bevatten. Het formatteert het tweede legende‑item met vet, cursief en blauwe tekst van 20 punten.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Individuele legende‑items verbergen**

Om een hulpreeks uit de legende te verwijderen terwijl de gegevens zichtbaar blijven, roep je [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) aan met `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Dit verbergt alleen het geselecteerde legende‑item; het verwijdert de reeks of de gegevenspunten niet. In tegenstelling hiermee verbergt het aanroepen van [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) met `false` de volledige legende.

Het onderstaande voorbeeld maakt een gegroepeerde kolomgrafiek met meerdere reeksen met standaardgegevens. Het verbergt het legende‑item van de tweede reeks (index `1`) en slaat de presentatie op. Vervolgens wordt het item hersteld door [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) aan te roepen met `false` en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

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

![Vergelijking van een diagram met alle legende‑items zichtbaar en met Serie 2 verborgen in de legende; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijndiagrammen identificeren legende‑items reeksen. Voor cirkeldiagrammen identificeren ze individuele datapunten (segmenten), dus gebruik je [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) op het geselecteerde segment. De API documenteert deze datapunten‑methode voor de diagramtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Ga er niet van uit dat dit geldt voor donutsdiagrammen, die niet in die lijst zijn opgenomen.

## **FAQ**

**Kan ik het diagram ruimte laten reserveren voor de legende in plaats van deze te overlappen?**

Ja. Roep [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) aan met `false` om ruimte voor de legende te reserveren in plaats van deze het plotgebied te laten overlappen.

**Kan ik legende‑labels over meerdere regels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. Je kunt ook reeksnamen van een regeleinde scheiden om een regelafbreking af te dwingen.

**Hoe laat ik de legende het kleurschema van het presentatie‑thema volgen?**

Laat de kleuren, opvullingen en lettertypen van de legende leeg, zodat deze de themavormgeving kan overnemen. Expliciete opmaak overschrijft de bijbehorende themainstellingen.