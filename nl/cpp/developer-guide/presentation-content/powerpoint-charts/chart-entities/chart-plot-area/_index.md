---
title: Aangepaste plotgebieden van presentatiegrafieken in C++
linktitle: Plotgebied
type: docs
url: /nl/cpp/chart-plot-area/
keywords:
- grafiek
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van grafieken in PowerPoint‑presentaties kunt aanpassen met Aspose.Slides voor C++. Verbeter moeiteloos de visuele weergave van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u werkt met het plotgebied van een grafiek in Aspose.Slides. Het legt uit hoe u de werkelijke positie en afmeting van het plotgebied kunt verkrijgen door de grafieklay-out te valideren en vervolgens de X-, Y-, breedte- en hoogtewaarden uit te lezen.

Het toont ook hoe u de lay-outmodus van het plotgebied kunt configureren wanneer de lay-out handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plotgebied wordt berekend op basis van zijn binnenste regio of op basis van de buitenste regio samen met assen en aslabels.

## **Breedte en hoogte van een grafiek‑plotgebied opvragen**
Aspose.Slides for C++ biedt een eenvoudige API voor .

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse aan.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Roep de methode IChart::ValidateChartLayout() aan vóór het verkrijgen van de werkelijke waarden.
5. Haalt de werkelijke X‑locatie (links) van het grafiekelement op, relatief ten opzichte van de linkerbovenhoek van de grafiek.
6. Haalt de werkelijke bovenkant van het grafiekelement op, relatief ten opzichte van de linkerbovenhoek van de grafiek.
7. Haalt de werkelijke breedte van het grafiekelement op.
8. Haalt de werkelijke hoogte van het grafiekelement op.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Sla presentatie op met grafiek
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **De lay-outmodus van een grafiek‑plotgebied instellen**
Aspose.Slides for C++ biedt een eenvoudige API om de lay-outmodus van het grafiek‑plotgebied in te stellen. Eigenschap **LayoutTargetType** is toegevoegd aan de klassen **ChartPlotArea** en **IChartPlotArea**. Als de lay-out van het plotgebied handmatig wordt gedefinieerd, geeft deze eigenschap aan of het plotgebied moet worden gelay‑out op basis van de binnenkant (exclusief assen en aslabels) of de buitenkant (inclusief assen en aslabels). Er zijn twee mogelijke waarden die gedefinieerd zijn in de enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied moet bepalen, exclusief de markeringen en aslabels.
- **LayoutTargetType.Outer** - geeft aan dat de grootte van het plotgebied de grootte van het plotgebied, de markeringen en de aslabels moet bepalen.

Voorbeeldcode staat hieronder.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In welke eenheden worden ActualX, ActualY, ActualWidth en ActualHeight geretourneerd?**

In points; 1 inch = 72 points. Dit zijn de coördinaateenheden van Aspose.Slides.

**Hoe verschilt het plotgebied van het grafiekgebied qua inhoud?**

Het plotgebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enzovoort); het grafiekgebied omvat de omliggende elementen (titel, legenda, enzovoort). Bij 3D‑grafieken omvat het plotgebied ook de wanden/vloer en de assen.

**Hoe worden de X, Y, Breedte en Hoogte van het plotgebied geïnterpreteerd wanneer de lay-out handmatig is?**

Ze zijn fracties (0–1) van de totale grootte van de grafiek; in deze modus is automatische positionering uitgeschakeld en worden de door u ingestelde fracties gebruikt.

**Waarom veranderde de positie van het plotgebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het grafiekgebied buiten het plotgebied, maar beïnvloedt de lay-out en de beschikbare ruimte, waardoor het plotgebied kan verschuiven wanneer automatische positionering actief is. (Dit is standaardgedrag voor PowerPoint‑grafieken.)