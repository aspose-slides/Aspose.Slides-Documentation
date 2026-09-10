---
title: Pas plotgebieden van presentatiediagrammen aan in Python
linktitle: Plotgebied
type: docs
url: /nl/python-java/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint‑presentaties kunt aanpassen met Aspose.Slides for Python via Java. Verbeter moeiteloos de visuele weergave van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u werkt met het plotgebied van een grafiek in Aspose.Slides. Het legt uit hoe u de werkelijke positie en grootte van het plotgebied krijgt door de grafieklay-out te valideren en vervolgens de X-, Y-, breedte- en hoogte‑waarden te lezen.

Het toont ook hoe u de lay‑outmodus van het plotgebied configureert wanneer de lay-out handmatig wordt ingesteld, met behulp van LayoutTargetType om te bepalen of het plotgebied wordt berekend op basis van de binnenregion of van de buitenregion, samen met assen en as‑labels.

## **Breedte en Hoogte van een Grafiek‑Plotgebied Opvragen**

Aspose.Slides for Python via Java biedt een eenvoudige API om de werkelijke positie en grootte van het plotgebied van een grafiek uit te lezen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse aan.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Roep de methode [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#validateChartLayout) aan voordat u de werkelijke waarden opvraagt.
5. Haal de werkelijke X‑positie (links) van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
6. Haal de werkelijke Y‑positie (boven) van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
7. Haal de werkelijke breedte van het grafiekelement op.
8. Haal de werkelijke hoogte van het grafiekelement op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Lay-outmodus van een Grafiek‑Plotgebied Instellen**

Aspose.Slides for Python via Java biedt een eenvoudige API om de lay‑outmodus van het plotgebied van een grafiek in te stellen. De methoden [setLayoutTargetType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) en [getLayoutTargetType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) zijn beschikbaar in de [ChartPlotArea](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartplotarea/) klasse. Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, bepaalt deze instelling of het plotgebied wordt gelegd op basis van de binnenkant (exclusief assen en as‑labels) of van de buitenkant (inclusief assen en as‑labels). Er zijn twee mogelijke waarden gedefinieerd in de enumeratie [LayoutTargetType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layouttargettype/#Inner) specificeert dat de grootte van het plotgebied de teekens en as‑labels uitsluit.
- [Outer](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layouttargettype/#Outer) specificeert dat de grootte van het plotgebied de teekens en as‑labels omvat.

Voorbeeldcode staat hieronder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In welke eenheden worden werkelijke X, werkelijke Y, werkelijke breedte en werkelijke hoogte geretourneerd?**

In points; 1 inch = 72 points. Dit zijn de coördinate‑eenheden van Aspose.Slides.

**Hoe verschilt het Plotgebied van het Grafiekgebied qua inhoud?**

Het Plotgebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enz.); het Grafiekgebied omvat de omringende elementen (titel, legenda, enz.). In 3D‑grafieken omvat het Plotgebied ook de wanden/vloer en de assen.

**Hoe worden de X, Y, breedte en hoogte van het Plotgebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Het zijn fracties (0–1) van de totale grootte van de grafiek; in deze modus is automatische positionering uitgeschakeld en worden de door u ingestelde fracties gebruikt.

**Waarom veranderde de positie van het Plotgebied na het toevoegen of verplaatsen van de legenda?**

De legenda bevindt zich in het grafiekgebied buiten het Plotgebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het Plotgebied kan verschuiven wanneer automatische positionering actief is. (Dit is standaardgedrag voor PowerPoint‑grafieken.)