---
title: Werkende oplossing voor grafiek‑schaling in PPTX
type: docs
weight: 40
url: /nl/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiek schalen
- Excel‑grafiek
- OLE‑object
- grafiek insluiten
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Los onverwachte grafiek‑schaling op in PPTX bij gebruik van ingebedde Excel OLE‑objecten met Aspose.Slides voor Python via Java. Leer twee methoden met code om de afmetingen consistent te houden."
---
## **Achtergrond**

Er is geconstateerd dat Excel‑grafieken die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na hun eerste activering worden geschaald naar een ongedefinieerde grootte. Dit gedrag veroorzaakt een duidelijke visuele afwijking in de presentatie tussen de voor‑ en na‑activeringsstatus van de grafiek. Het Aspose‑team heeft het probleem grondig onderzocht en een oplossing gevonden. Dit artikel beschrijft de oorzaken van het probleem en de bijbehorende oplossing.

In het [vorige artikel](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), legden we uit hoe je een Excel‑grafiek maakt met Aspose.Cells voor Python via Java en deze in een PowerPoint‑presentatie embedden met Aspose.Slides voor Python via Java. Om het [object‑preview‑probleem](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de resulterende presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding toont, de Excel‑grafiek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de onderliggende Excel‑werkmap en vervolgens terugkeren naar de betreffende dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de vergrotingsfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van de grootte‑aanpassing**

Omdat de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd en behouden ze de juiste verhoudingen als onderdeel van het insluitingsproces. Afhankelijk van de verschillen tussen de grootte van het Excel‑venster en die van het OLE‑objectframe (of de positie), treedt de aanpassing op.

## **Werkende oplossing**

Er zijn twee mogelijke scenario’s voor het maken van PowerPoint‑presentaties met Aspose.Slides voor Python via Java.

**Scenario 1:** Een presentatie maken op basis van een bestaand sjabloon.

**Scenario 2:** Een presentatie vanaf nul maken.

De oplossing die we hier bieden, is van toepassing op beide scenario’s. De basis van alle oplossingsbenaderingen is dezelfde: **de venstergrootte van het ingebedde OLE‑object moet overeenkomen met het OLE‑objectframe in de PowerPoint‑dia**. We bespreken nu de twee benaderingen van deze oplossing.

## **Eerste aanpak**

In deze aanpak leren we hoe we de venstergrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de grootte van het OLE‑objectframe in de PowerPoint‑dia.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties willen maken op basis daarvan. Veronderstel dat er een vorm op index 2 in het sjabloon staat waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑objectframe vooraf bepaald ‑ deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de venstergrootte van de werkmap gelijk te stellen aan die vormgrootte. Het volgende codefragment dient dit doel:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laad de Excel-werkmap die de grafiek bevat.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Stel de venstergrootte van de werkmap in inches in (PowerPoint gebruikt 72 punten per inch).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Sla de werkmap op naar een geheugen-stroom.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Maak een OLE-objectframe met de ingebedde Excel-gegevens.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte willen opnemen met een ingebedde Excel‑werkmap. In het onderstaande codefragment maken we een OLE‑objectframe van 4 inch hoog en 9,5 inch breed op x = 0,5 inch en y = 1 inch op de dia. Vervolgens stellen we het Excel‑werkmapvenster in op dezelfde afmetingen ‑ 4 inch hoog en 9,5 inch breed.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laad de Excel-werkmap die de grafiek bevat.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inches (4 * 72).
    desired_width = 684  # 9.5 inches (9.5 * 72).

    # Definieer de grootte van de grafiek met een venster.
    chart.setSizeWithWindow(True)

    # Stel de venstergrootte van de werkmap in inches in (PowerPoint gebruikt 72 punten per inch).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Sla de werkmap op naar een geheugenstroom.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Maak een OLE-objectframe met de ingebedde Excel-gegevens.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Tweede aanpak**

In deze aanpak leren we hoe we de grootte van de grafiek in de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de grootte van het OLE‑objectframe in de PowerPoint‑dia. Deze aanpak is handig wanneer de grafiekgrootte vooraf bekend is en nooit zal veranderen.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties willen maken op basis daarvan. Veronderstel dat er een vorm op index 2 in het sjabloon staat waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑frame vooraf bepaald ‑ deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de grafiekgrootte in de werkmap gelijk te stellen aan de vormgrootte. Het volgende codefragment dient dit doel:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laad de Excel-werkmap die de grafiek bevat.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definieer de grootte van de grafiek zonder venster.
    chart.setSizeWithWindow(False)

    # Stel de grafiekgrootte in pixels in (Excel gebruikt 96 pixels per inch).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definieer de afdrukgrootte van de grafiek.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Sla de werkmap op naar een geheugenstroom.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Maak een OLE-objectframe met de ingebedde Excel-gegevens.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte willen opnemen met een ingebedde Excel‑werkmap. In het onderstaande codefragment maken we een OLE‑objectframe met een hoogte van 4 inch en een breedte van 9,5 inch op de dia op x = 0,5 inch en y = 1 inch. We stellen tevens de overeenkomstige grafiekgrootte in op dezelfde afmetingen: een hoogte van 4 inch en een breedte van 9,5 inch.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Laad de Excel-werkmap die de grafiek bevat.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inches (4 * 72).
    desired_width = 684  # 9,5 inches (9,5 * 72).

    # Definieer de grootte van de grafiek zonder venster.
    chart.setSizeWithWindow(False)

    # Stel de grafiekgrootte in pixels in (Excel gebruikt 96 pixels per inch).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Sla de werkmap op naar een geheugenstroom.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Maak een OLE-objectframe met de ingebedde Excel-gegevens.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusie**

Er zijn twee benaderingen om het probleem met het herschalen van de grafiek op te lossen. De keuze van de benadering hangt af van de vereisten en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties uit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

## **FAQ**

**Waarom verandert de grootte van mijn ingebedde Excel‑grafiek nadat deze in PowerPoint is geactiveerd?**

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een aanpassing.

**Is het mogelijk om dit aanpassingsprobleem volledig te voorkomen?**

Ja. Door de venstergrootte van de Excel‑werkmap of de grafiekgrootte te laten overeenkomen met de grootte van het OLE‑objectframe vóór het insluiten, kun je de grafiekgroottes consistent houden.

**Welke benadering moet ik kiezen, de venstergrootte van de werkmap instellen of de grafiekgrootte?**

Gebruik **aanpak 1 (venstergrootte)** als je de beeldverhouding van de werkmap wilt behouden en eventueel later wil kunnen schalen.  
Gebruik **aanpak 2 (grafiekgrootte)** als de grafiekafmetingen vast staan en niet zullen wijzigen na het insluiten.

**Werken deze methoden zowel voor sjabloon‑gebaseerde presentaties als voor nieuwe presentaties?**

Ja. Beide benaderingen werken op dezelfde manier voor presentaties die uit sjablonen zijn gemaakt en voor presentaties die vanaf nul zijn opgebouwd.

**Is er een limiet aan de grootte van het OLE‑objectframe?**

Nee. Je kunt het OLE‑frame op elke gewenste grootte instellen, zolang het proportioneel blijft ten opzichte van de werkmap‑ of grafiekgrootte.

**Kan ik deze methoden gebruiken met grafieken die in andere spreadsheet‑programma’s zijn gemaakt?**

De voorbeelden zijn bedoeld voor Excel‑grafieken gemaakt met Aspose.Cells, maar de principes zijn ook toepasbaar op andere OLE‑compatibele spreadsheet‑programma’s, zolang ze vergelijkbare grootte‑opties ondersteunen.

## **Gerelateerde secties**

- [Grafieken maken in Excel en insluiten als OLE‑objecten in presentaties](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)