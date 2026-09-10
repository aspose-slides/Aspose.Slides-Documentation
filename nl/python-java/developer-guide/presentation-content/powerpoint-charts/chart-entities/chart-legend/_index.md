---
title: Grafieklegenda's aanpassen in presentaties met Python
linktitle: Grafieklegenda
type: docs
url: /nl/python-java/chart-legend/
keywords:
- grafieklegenda
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides voor Python via Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legendapresentatie."
---
## **Overzicht**

Aspose.Slides biedt opties om de legenda van grafieken in PowerPoint‑presentaties aan te passen. Deze artikel laat zien hoe u een legenda kunt positioneren en van grootte kunt wijzigen, de lettergrootte voor de hele legenda kunt instellen en opmaak kunt toepassen op een enkel legendaveld.

Het behandelt ook verschillende gerelateerde zaken in de FAQ, waaronder het gebruik van de non‑overlay‑modus zodat het plotgebied ruimte maakt voor de legenda, het toestaan dat lange legendalabels worden afgebroken of regels bevatten, en het laten overerven van de legenda‑opmaak van het presentatie‑thema wanneer er geen expliciete tekst‑ en opvullingsinstellingen zijn toegepast.

## **Positie van de legenda**

Om de eigenschappen van de legenda in te stellen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Verkrijg een referentie naar de dia.  
3. Voeg een grafiek toe aan de dia.  
4. Stel de legenda‑eigenschappen in.  
5. Sla de presentatie op als een PPTX‑bestand.

Het volgende voorbeeld stelt de positie en grootte van een grafieklegenda in.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Maak een lege presentatie aan.
presentation = Presentation()
try:
    # Verkrijg een referentie naar de dia.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een gegroepeerde kolomgrafiek toe aan de dia.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Stel de legendaparameters in.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Sla de presentatie op naar schijf.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lettergrootte van een legenda instellen**

Aspose.Slides voor Python via Java maakt het mogelijk om de lettergrootte van een legenda in te stellen. Volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Maak de standaardgrafiek.  
3. Stel de lettergrootte in.  
4. Stel de minimale aswaarde in.  
5. Stel de maximale aswaarde in.  
6. Sla de presentatie op naar schijf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Maak een lege presentatie.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lettergrootte van een individueel legendaveld instellen**

Aspose.Slides voor Python via Java maakt het mogelijk om de lettergrootte van individuele legendavelden in te stellen. Volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
2. Maak de standaardgrafiek.  
3. Verkrijg toegang tot een legendaveld.  
4. Stel de lettergrootte in.  
5. Sla de presentatie op naar schijf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Maak een lege presentatie.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik de legenda inschakelen zodat de grafiek automatisch ruimte vrijmaakt in plaats van deze te overlappen?**

Ja. Gebruik [setOverlay](https://reference.aspose.com/slides/nl/python-java/aspose.slides/legend/#setOverlay) met `False` om de non‑overlay‑modus in te schakelen; in dit geval krimpt het plotgebied om de legenda te bevatten.

**Kan ik legendalabels op meerdere regels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via nieuweregel‑tekens in de serienaam.

**Hoe kan ik de legenda het kleurschema van het presentatie‑thema laten volgen?**

Stel geen expliciete kleuren, opvullingen of lettertypen in voor de legenda of de bijbehorende tekst. Ze zullen dan overerven van het thema en correct worden bijgewerkt wanneer het ontwerp verandert.