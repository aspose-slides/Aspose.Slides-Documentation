---
title: Werkende oplossing voor grafiek‑schaalverandering in PPTX
type: docs
weight: 40
url: /nl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiek schalen
- Excel‑grafiek
- OLE‑object
- grafiek insluiten
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Los onverwacht schalen van grafieken in PPTX op bij het gebruik van ingebedde Excel OLE‑objecten met Aspose.Slides voor Java. Leer twee methoden met code om de afmetingen consistent te houden."
---
## **Achtergrond**

Er is geconstateerd dat Excel‑grafieken die als OLE‑objecten in een PowerPoint‑presentatie zijn ingevoegd via Aspose‑componenten, na hun eerste activering worden geschaald naar een onbepaalde schaal. Dit gedrag veroorzaakt een duidelijk zichtbaar verschil in de presentatie tussen de voor‑ en na‑activeringsstatus van de grafiek. Het Aspose‑team heeft het probleem grondig onderzocht en een oplossing gevonden. Dit artikel beschrijft de oorzaken van het probleem en de bijbehorende oplossing.

In het [vorige artikel](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) hebben we uitgelegd hoe je met Aspose.Cells voor Java een Excel‑grafiek maakt en deze in een PowerPoint‑presentatie embed met Aspose.Slides voor Java. Om het [object‑preview‑probleem](/slides/nl/java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de resulterende presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding weergeeft, wordt de Excel‑grafiek geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de onderliggende Excel‑werkmap en vervolgens terugkeren naar de betreffende dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de schaalfactor varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingevoegde Excel‑werkmap.

## **Oorzaak van schalen**

Omdat de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activering zijn oorspronkelijke afmeting te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd en handhaven ze de juiste verhoudingen als onderdeel van het insluitingsproces. Afhankelijk van de verschillen tussen de grootte van het Excel‑venster en de grootte of positie van het OLE‑objectframe treedt er een schaalverandering op.

## **Werkende oplossing**

Er zijn twee mogelijke scenario’s voor het maken van PowerPoint‑presentaties met Aspose.Slides voor Java.

**Scenario 1:** Maak een presentatie op basis van een bestaand sjabloon.

**Scenario 2:** Maak een presentatie vanaf nul.

De oplossing die we hier bieden, is van toepassing op beide scenario’s. De basis van alle oplossingsbenaderingen is hetzelfde: **de venstergrootte van het ingebedde OLE‑object moet overeenkomen met het OLE‑objectframe in de PowerPoint‑dia**. We bespreken nu de twee benaderingen van deze oplossing.

## **Eerste benadering**

In deze benadering leren we hoe we de venstergrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de afmeting van het OLE‑objectframe in de PowerPoint‑dia.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Er is een shape op index 2 in het sjabloon waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑objectframe vooraf bepaald – hij komt overeen met de grootte van de shape op index 2 in het sjabloon. Alles wat we hoeven te doen is de venstergrootte van de werkmap gelijk te stellen aan die shape‑grootte. De volgende code‑fragment dient dit doel:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Stel de breedte van het werkmapvenster in inches in (gedeeld door 72 omdat PowerPoint 72 punten per inch gebruikt).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Stel de hoogte van het werkmapvenster in inches in.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Sla de werkmap op in een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe aan met de ingebedde Excel‑gegevens.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige afmeting met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande code‑fragment maken we een OLE‑objectframe van 4 inch hoog en 9,5 inch breed op x = 0,5 inch en y = 1 inch op de dia. Vervolgens stellen we het Excel‑werkmapvenster in op dezelfde afmeting – 4 inch hoog en 9,5 inch breed.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Onze gewenste hoogte.
int desiredHeight = 288; // 4 duim (4 * 72)
 
// Onze gewenste breedte.
int desiredWidth = 684; // 9.5 duim (9.5 * 72)
 
// Definieer de grafiekgrootte met een venster.
chart.setSizeWithWindow(true);
 
// Stel de breedte van het werkmapvenster in inches in (gedeeld door 72 omdat PowerPoint 72 punten per inch gebruikt).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Stel de hoogte van het werkmapvenster in inches in.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Sla de werkmap op in een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe aan met de ingebedde Excel‑gegevens.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 duim (0.5 * 72)
    72,  // y = 1 duim (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Tweede benadering**

In deze benadering leren we hoe we de grootte van de grafiek in de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de grootte van het OLE‑objectframe in de PowerPoint‑dia. Deze benadering is nuttig wanneer de grafiekgrootte van tevoren bekend is en nooit zal veranderen.

**Scenario 1**

Stel dat we een sjabloon hebben gedefinieerd en presentaties op basis daarvan willen maken. Er is een shape op index 2 in het sjabloon waar we een OLE‑frame met een ingebedde Excel‑werkmap willen plaatsen. In dit scenario is de grootte van het OLE‑frame vooraf bepaald – hij komt overeen met de grootte van de shape op index 2 in het sjabloon. Alles wat we hoeven te doen is de grafiekgrootte in de werkmap gelijk te stellen aan die shape‑grootte. De volgende code‑fragment dient dit doel:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Definieer de grafiekgrootte zonder venster.
chart.setSizeWithWindow(false);
 
// Stel de breedte van de grafiek in pixels in (vermenigvuldig met 96 omdat Excel 96 pixels per duim gebruikt).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Stel de hoogte van de grafiek in pixels in.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definieer de afdrukgrootte van de grafiek.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Sla de werkmap op in een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe aan met de ingebedde Excel‑gegevens.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

Stel dat we een presentatie vanaf nul willen maken en een OLE‑objectframe van willekeurige afmeting met een ingebedde Excel‑werkmap willen opnemen. In het onderstaande code‑fragment maken we een OLE‑objectframe met een hoogte van 4 inch en een breedte van 9,5 inch op de dia op x = 0,5 inch en y = 1 inch. We stellen ook de bijbehorende grafiekgrootte in op dezelfde afmetingen: een hoogte van 4 inch en een breedte van 9,5 inch.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Onze gewenste hoogte.
int desiredHeight = 288; // 4 duim (4 * 72)
 
// Onze gewenste breedte.
int desiredWidth = 684; // 9.5 duim (9.5 * 72)
 
// Definieer de grafiekgrootte zonder venster.
chart.setSizeWithWindow(false);
 
// Stel de breedte van de grafiek in pixels in (gedeeld door 72 om duimen te krijgen, vermenigvuldigd met 96 omdat Excel 96 pixels per duim gebruikt).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Stel de hoogte van de grafiek in pixels in.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Sla de werkmap op in een geheugenstroom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Maak een OLE‑objectframe met de ingebedde Excel‑gegevens.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 duim (0.5 * 72)
    72,  // y = 1 duim (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Conclusie**

Er zijn twee benaderingen om het probleem met het schalen van de grafiek op te lossen. De keuze van de benadering hangt af van de vereisten en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, ongeacht of de presentaties worden gemaakt vanuit een sjabloon of vanaf nul. Daarnaast is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

## **FAQ**

### Waarom verandert mijn ingebedde Excel‑grafiek van grootte nadat deze in PowerPoint is geactiveerd?

Dit gebeurt omdat Excel bij de eerste activering probeert de oorspronkelijke venstergrootte te herstellen, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een schaalverandering.

### Is het mogelijk om dit schaalprobleem volledig te voorkomen?

Ja. Door de venstergrootte of de grafiekgrootte van de Excel‑werkmap overeen te laten komen met de grootte van het OLE‑objectframe vóór het insluiten, kun je de grafiekgroottes consistent houden.

### Welke benadering moet ik kiezen, de venstergrootte van de werkmap instellen of de grafiekgrootte instellen?

Gebruik **benadering 1 (venstergrootte)** als je de beeldverhouding van de werkmap wilt behouden en eventueel later wilt kunnen schalen.  
Gebruik **benadering 2 (grafiekgrootte)** als de grafiekafmetingen vaststaan en niet zullen veranderen na het insluiten.

### Werken deze methoden zowel met sjabloongebaseerde presentaties als met nieuwe presentaties?

Ja. Beide benaderingen werken hetzelfde voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn gemaakt.

### Is er een limiet aan de grootte van het OLE‑objectframe?

Nee. Je kunt het OLE‑frame op elke gewenste grootte instellen, zolang het passend schaalt naar de werkmap‑ of grafiekgrootte.

### Kan ik deze methoden gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma’s?

De voorbeelden zijn ontworpen voor Excel‑grafieken gemaakt met Aspose.Cells, maar de principes gelden ook voor andere OLE‑compatibele spreadsheet‑programma’s zolang ze vergelijkbare grootte‑opties bieden.

## **Gerelateerde secties**

- [Excel‑grafieken maken en insluiten als OLE‑objecten in presentaties](/slides/nl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)