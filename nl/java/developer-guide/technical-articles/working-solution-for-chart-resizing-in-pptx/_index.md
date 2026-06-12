---
title: Werkende oplossing voor het schalen van diagrammen in PPTX
type: docs
weight: 40
url: /nl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram schalen
- Excel-diagram
- OLE-object
- diagram insluiten
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Los onverwacht diagram schalen in PPTX op bij het gebruik van ingebedde Excel OLE-objecten met Aspose.Slides voor Java. Leer twee methoden met code om de afmetingen consistent te houden."
---
## **Achtergrond**

Er is geconstateerd dat Excel‑diagrammen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na hun eerste activering worden geschaald naar een onbepaalde schaal. Dit gedrag veroorzaakt een duidelijk zichtbaar verschil in de presentatie tussen de vóór‑ en na‑activeringsstatus van het diagram. Het Aspose‑team heeft het probleem grondig onderzocht en een oplossing gevonden. Dit artikel beschrijft de oorzaken van het probleem en de bijbehorende fix.

In het [vorige artikel](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) legden we uit hoe je met Aspose.Cells voor Java een Excel‑diagram maakt en dit in een PowerPoint‑presentatie embed met Aspose.Slides voor Java. Om het [object‑preview‑probleem](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de diagram‑afbeelding toegewezen aan het OLE‑objectframe van het diagram. In de resulterende presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de diagram‑afbeelding toont, wordt het Excel‑diagram geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de onderliggende Excel‑werkmap en vervolgens terugkeren naar de bijbehorende dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van het Schalen**

Omdat de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen afmeting. Volgens Microsoft, wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte en handhaven ze de juiste verhoudingen als onderdeel van het embed‑proces. Afhankelijk van de verschillen tussen de Excel‑venstergrootte en de grootte of positie van het OLE‑objectframe, treedt het schalen op.

## **Werkende Oplossing**

Er zijn twee mogelijke scenario’s voor het maken van PowerPoint‑presentaties met Aspose.Slides voor Java.

**Scenario 1:** Een presentatie maken op basis van een bestaand sjabloon.

**Scenario 2:** Een presentatie vanaf nul maken.

De oplossing die we hier bieden, is van toepassing op beide scenario’s. De basis van alle oplossingsbenaderingen is dezelfde: **de venstergrootte van het embedded OLE‑object moet overeenkomen met het OLE‑objectframe in de PowerPoint‑dia**. We bespreken nu de twee benaderingen voor deze oplossing.

## **Eerste Benadering**

In deze benadering leren we hoe we de venstergrootte van de embedded Excel‑werkmap kunnen instellen zodat deze overeenkomt met de afmeting van het OLE‑objectframe in de PowerPoint‑dia.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Er is een vorm op index 2 in het sjabloon waar we een OLE‑frame met een embedded Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑objectframe vooraf gedefinieerd — deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de venstergrootte van de werkmap gelijk te maken aan die vormgrootte. Het volgende codefragment dient dit doel:

```java
// Stel de vensterbreedte van de werkmap in inches in (gedeeld door 576 omdat PowerPoint 576 pixels per inch gebruikt).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Stel de vensterhoogte van de werkmap in inches in.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Sla de werkmap op naar een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe met de ingebedde Excel‑gegevens.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte willen toevoegen met een embedded Excel‑werkmap. In het onderstaande codefragment maken we een OLE‑objectframe van 4 inch hoog en 9,5 inch breed op x = 0,5 inch en y = 1 inch op de dia. Vervolgens stellen we het Excel‑werkmapvenster in op dezelfde grootte — 4 inch hoog en 9,5 inch breed.

```java
// Onze gewenste hoogte.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Onze gewenste breedte.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Definieer de diagramgrootte met een venster.
chart.setSizeWithWindow(true);
 
// Stel de vensterbreedte van de werkmap in inches in (gedeeld door 576 omdat PowerPoint 576 pixels per inch gebruikt).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Stel de vensterhoogte van de werkmap in inches in.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Sla de werkmap op naar een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe met de ingebedde Excel‑gegevens.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Tweede Benadering**

In deze benadering leren we hoe we de grootte van het diagram in de embedded Excel‑werkmap kunnen instellen zodat deze overeenkomt met de afmeting van het OLE‑objectframe in de PowerPoint‑dia. Deze benadering is nuttig wanneer de diagramgrootte van tevoren bekend is en nooit zal veranderen.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Er is een vorm op index 2 in het sjabloon waar we een OLE‑frame met een embedded Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑frame vooraf gedefinieerd — deze komt overeen met de grootte van de vorm op index 2 in het sjabloon. Het enige wat we hoeven te doen is de diagramgrootte in de werkmap gelijk te maken aan die vormgrootte. Het volgende codefragment dient dit doel:

```java
// Definieer de diagramgrootte zonder venster.
chart.setSizeWithWindow(false);
 
// Stel de diagrambreedte in pixels in (vermenigvuldig met 96 omdat Excel 96 pixels per inch gebruikt).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Stel de diagramhoogte in pixels in.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definieer de afdrukgrootte van het diagram.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Sla de werkmap op naar een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe met de ingebedde Excel‑gegevens.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**:

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige grootte willen toevoegen met een embedded Excel‑werkmap. In het onderstaande codefragment maken we een OLE‑objectframe met een hoogte van 4 inch en een breedte van 9,5 inch op x = 0,5 inch en y = 1 inch op de dia. We stellen tevens de bijbehorende diagramgrootte in op dezelfde afmetingen: een hoogte van 4 inch en een breedte van 9,5 inch.

```java
// Onze gewenste hoogte.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Onze gewenste breedte.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Definieer de diagramgrootte zonder venster.
chart.setSizeWithWindow(false);
 
// Stel de diagrambreedte in pixels in (vermenigvuldig met 96 omdat Excel 96 pixels per inch gebruikt).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Stel de diagramhoogte in pixels in.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Sla de werkmap op naar een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe met de ingebedde Excel‑gegevens.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Conclusie**

Er zijn twee benaderingen om het probleem met het schalen van diagrammen op te lossen. De keuze van benadering hangt af van de eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties vanuit een sjabloon of vanaf nul worden gemaakt. Daarnaast is er geen beperking op de grootte van het OLE‑objectframe in deze oplossing.

## **FAQ**

**Waarom verandert de grootte van mijn embedded Excel‑diagram na activatie in PowerPoint?**

Dit gebeurt omdat Excel bij de eerste activatie probeert de originele venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot schalen.

**Is het mogelijk om dit schaalprobleem volledig te voorkomen?**

Ja. Door de venstergrootte van de Excel‑werkmap of de diagramgrootte af te stemmen op de grootte van het OLE‑objectframe vóór het embedden, kun je de diagramgroottes consistent houden.

**Welke benadering moet ik kiezen, venstergrootte instellen of diagramgrootte?**

Gebruik **Benadering 1 (venstergrootte)** als je de beeldverhouding van de werkmap wilt behouden en eventueel later wilt kunnen schalen.  
Gebruik **Benadering 2 (diagramgrootte)** als de diagramafmetingen vast zijn en niet meer veranderen na het embedden.

**Werken deze methoden zowel voor sjabloongebaseerde presentaties als voor nieuwe presentaties?**

Ja. Beide benaderingen werken op dezelfde manier voor presentaties die vanuit sjablonen of vanaf nul worden gemaakt.

**Is er een limiet aan de grootte van het OLE‑objectframe?**

Nee. Je kunt het OLE‑frame naar elke gewenste grootte instellen, zolang het passend schaalt naar de werkmap of diagramgrootte.

**Kan ik deze methoden gebruiken met diagrammen die in andere spreadsheet‑programma's zijn gemaakt?**

De voorbeelden zijn bedoeld voor Excel‑diagrammen gemaakt met Aspose.Cells, maar de principes zijn toepasbaar op andere OLE‑compatibele spreadsheet‑programma's zolang ze vergelijkbare grootte‑opties bieden.

## **Gerelateerde Secties**

- [Excel‑diagrammen maken en embedden als OLE‑objecten in presentaties](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑objecten automatisch bijwerken met een PowerPoint‑add‑in](/slides/nl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)