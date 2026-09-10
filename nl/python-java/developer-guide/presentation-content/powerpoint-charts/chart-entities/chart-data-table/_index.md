---
title: Grafiekdatatabellen aanpassen in presentaties met Python
linktitle: Datatabel
type: docs
url: /nl/python-java/chart-data-table/
keywords:
- grafiekgegevens
- datatabel
- fonteigenschappen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas grafiekdatatabellen aan in Python voor PPT en PPTX met Aspose.Slides for Python via Java om de efficiëntie en aantrekkelijkheid van presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met grafiektabellen in Aspose.Slides. Het laat zien hoe u een datatabel voor een grafiek kunt weergeven en de tekstopmaak kunt aanpassen door fonteigenschappen zoals vette stijl en lettergrootte in te stellen. Het voorbeeld toont het maken van een presentatie, het toevoegen van een grafiek, het inschakelen van de grafiekdatatabel, het toepassen van fontinstellingen en het opslaan van de bijgewerkte presentatie.

Het bevat ook korte antwoorden op veelgestelde vragen over het weergeven van legende‑sleutels in een grafiekdatatabel, het behouden van de datatabel bij export, het werken met grafieken geladen uit bestaande presentaties of sjablonen, en het identificeren van grafieken waarbij de datatabel is ingeschakeld.

## **Stel fonteigenschappen in voor een grafiekdatatabel**

Aspose.Slides for Python via Java stelt u in staat de datatabel van een grafiek weer te geven en de fonteigenschappen van de tekst te wijzigen.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
2. Voeg een grafiek toe aan de dia.
3. Toon de grafiekdatatabel.
4. Stel de vette stijl en de lettergrootte van de datatabeltekst in.
5. Sla de gewijzigde presentatie op.

Het volgende voorbeeld demonstreert deze stappen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Maak een lege presentatie.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik kleine legende‑sleutels weergeven naast de waarden in de datatabel van de grafiek?**

Ja. De datatabel ondersteunt [legende‑sleutels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datatable/#setShowLegendKey), en u kunt ze in- of uitschakelen.

**Wordt de datatabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, dus de geëxporteerde [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/python-java/convert-powerpoint-to-html/)/[afbeelding](/slides/nl/python-java/convert-powerpoint-to-png/) bevat de grafiek met zijn datatabel.

**Worden datatabellen ondersteund voor grafieken die afkomstig zijn uit een sjabloonbestand?**

Ja. Voor elke grafiek die is geladen uit een bestaande presentatie of sjabloon, kunt u controleren en wijzigen of een datatabel [wordt weergegeven](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#hasDataTable) met behulp van de grafiekeigenschappen.

**Hoe kan ik snel vinden welke grafieken in een bestand de datatabel hebben ingeschakeld?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de datatabel [wordt weergegeven](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#hasDataTable) en doorloop de dia's om de grafieken te identificeren waarbij deze is ingeschakeld.