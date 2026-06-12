---
title: Plotgebieden van presentatiediagrammen aanpassen in С++
linktitle: Plotgebied
type: docs
url: /nl/cpp/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte plotgebied
- hoogte plotgebied
- grootte plotgebied
- layoutmodus
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint‑presentaties kunt aanpassen met Aspose.Slides voor С++. Verbeter moeiteloos de uitstraling van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u met het plotgebied van een diagram in Aspose.Slides kunt werken. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied kunt verkrijgen door de diagramlay‑out te valideren en vervolgens de X‑, Y‑, breedte‑ en hoogte‑waarden uit te lezen.

Het demonstreert ook hoe u de layoutmodus van het plotgebied kunt configureren wanneer de layout handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plotgebied wordt berekend op basis van zijn binnenste regio of van zijn buitenste regio samen met assen en as‑labels.

## **Breedte en hoogte van een diagram‑plotgebied opvragen**
Aspose.Slides for C++ biedt een eenvoudige API voor .

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Roep de methode IChart::ValidateChartLayout() aan om de werkelijke waarden te krijgen.
1. Haalt de werkelijke X‑locatie (links) van het diagram‑element op ten opzichte van de linkerbovenhoek van het diagram.
1. Haalt de werkelijke Y‑locatie (boven) van het diagram‑element op ten opzichte van de linkerbovenhoek van het diagram.
1. Haalt de werkelijke breedte van het diagram‑element op.
1. Haalt de werkelijke hoogte van het diagram‑element op.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Presentatie opslaan met diagram
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Layoutmodus van een diagram‑plotgebied instellen**
Aspose.Slides for C++ biedt een eenvoudige API om de layoutmodus van het diagram‑plotgebied in te stellen. Eigenschap **LayoutTargetType** is toegevoegd aan de klassen **ChartPlotArea** en **IChartPlotArea**. Als de layout van het plotgebied handmatig wordt gedefinieerd, geeft deze eigenschap aan of het plotgebied wordt gelayout door zijn binnenkant (exclusief assen en as‑labels) of buitenkant (inclusief assen en as‑labels). Er zijn twee mogelijke waarden die zijn gedefinieerd in de **LayoutTargetType**‑enum.

- **LayoutTargetType.Inner** – geeft aan dat de grootte van het plotgebied wordt bepaald zonder de tick‑marks en as‑labels.
- **LayoutTargetType.Outer** – geeft aan dat de grootte van het plotgebied wordt bepaald inclusief de tick‑marks en as‑labels.

Voorbeeldcode staat hieronder.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In welke eenheden worden ActualX, ActualY, ActualWidth en ActualHeight geretourneerd?**

In punten; 1 inch = 72 punten. Dit zijn de coördinaateenheden van Aspose.Slides.

**Hoe verschilt het plotgebied van het diagramgebied qua inhoud?**

Het plotgebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enz.); het diagramgebied omvat de omliggende elementen (titel, legenda, enz.). In 3D‑diagrammen omvat het plotgebied ook de wanden/vloer en de assen.

**Hoe worden de X‑, Y‑, breedte‑ en hoogte‑waarden van het plotgebied geïnterpreteerd wanneer de layout handmatig is?**

Het zijn fracties (0‑1) van de totale grootte van het diagram; in deze modus is automatische positionering uitgeschakeld en worden de opgegeven fracties gebruikt.

**Waarom veranderde de positie van het plotgebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het diagramgebied buiten het plotgebied, maar beïnvloedt de layout en de beschikbare ruimte, waardoor het plotgebied kan verschuiven wanneer automatische positionering actief is. (Dit is het standaardgedrag voor PowerPoint‑diagrammen.)