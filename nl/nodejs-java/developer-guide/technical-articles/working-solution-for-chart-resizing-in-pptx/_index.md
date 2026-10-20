---
title: Werkende oplossing voor grafiekgrootte aanpassen in PPTX
type: docs
weight: 40
url: /nl/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekgrootte aanpassen
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Los onverwachte grafiekgrootte-aanpassing op in PPTX bij het gebruik van ingebedde Excel OLE-objecten met Aspose.Slides voor Node.js via Java. Stel vaste grafiekafmetingen in om de grafiek- en OLE-framegroottes consistent te houden."
---
## **Overzicht**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties zijn ingebed met behulp van Aspose‑componenten kunnen van grootte veranderen na hun eerste activering. Dit kan een duidelijk verschil in het uiterlijk van de grafiek veroorzaken vóór en na de activering. Dit artikel legt uit waarom het formaat verandert en laat zien hoe u dit kunt voorkomen door vaste grafiekafmetingen af te stemmen op het OLE‑frame.

In [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), legden we uit hoe u een Excel‑grafiek maakt met Aspose.Cells for Node.js via Java en deze in een PowerPoint‑presentatie embedt met Aspose.Slides for Node.js via Java. Om het [probleem met objectvoorvertoning](/slides/nl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de output‑presentatie, wanneer u dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding weergeeft, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingebedde Excel‑werkmap bewerken en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de factor voor het wijzigen van de grootte varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingebedde Excel‑werkmap.

## **Oorzaak van formaatwijziging**

De ingebedde Excel‑werkmap heeft eigen vensterafmetingen, die Excel probeert te behouden wanneer het object voor het eerst wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embed‑proces. Verschillen tussen het werkmap‑venster en het OLE‑frame kunnen daarom zorgen voor een wijziging van de grootte van het object.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmap‑venster. Deze oplossing werkt met een nieuwe presentatie of een bestaand sjabloon.

Het voorbeeld vereist Aspose.Cells for Node.js via Java en Aspose.Slides for Node.js via Java. Installeer de `aspose.cells`, `aspose.slides.via.java` en `java` Node.js‑pakketten. Voer de twee CommonJS‑scripts hieronder uit in aparte Node.js‑processen, met dezelfde werkmap, omdat beide Aspose‑pakketten de Java‑bridge initialiseren tijdens het laden. Het script maakt een eenvoudige kolomgrafiek op een actief grafiekblad en embedt de werkmap in XLS‑formaat. Er wordt geen voorbeeldafbeelding van de grafiek toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object in PowerPoint wordt geactiveerd.

Het voorbeeld maakt een nieuwe presentatie met een OLE‑frame van 9.5 × 4 inch, gepositioneerd 0.5 inch van de linkerkant en 1 inch van de bovenkant. Dia‑coördinaten en afmetingen worden in points gegeven (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

## **Stel een vaste grafiekgrootte in**

Stel [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmap‑venster. Stel de [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject)‑afmetingen in via [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) en [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), waarbij points naar pixels worden geconverteerd met 96 pixels per inch: een frame van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) in op de CUSTOM‑waarde van `PrintSizeType`. Het voorbeeld embedt de werkmap met [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) en slaat een presentatie op met een OLE‑frame van 9.5 × 4 inch.

Sla dit eerste script op als `create-fixed-chart.js`. Het maakt `chart-fixed-size.xls` aan met een grafiek van 912 × 384 pixels, passend bij het frame van 684 × 288 points dat door het tweede script wordt gebruikt. Er is geen invoer‑werkmap nodig.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Stem de OLE-frameafmetingen af op punten (72 punten per inch).
    const width = 684; // 9,5 inch.
    const height = 288; // 4 inch.

    chart.setSizeWithWindow(false);
    // Converteer punten naar grafiekpixels met 96 pixels per inch.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Alle synchroon werk is voltooid; stop het Java-bridge-proces.
process.exit(0);
```

Sla het tweede script op als `embed-fixed-chart.js` en voer het uit na `create-fixed-chart.js`. Het leest de gegenereerde XLS‑werkmap en slaat `chart-fixed-size.pptx` op. De Java‑bridge vereist een expliciete Java‑byte‑array voor de werkmap‑gegevens en Java‑float‑waarden voor de frame‑coördinaten en afmetingen. De extensie `xls` komt overeen met het opgeslagen formaat van de werkmap.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Dia-coördinaten en -afmetingen zijn in punten (72 punten per inch).
    const width = 684; // 9,5 inch.
    const height = 288; // 4 inch.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Alle synchrone bewerkingen zijn voltooid; stop het Java-bridge-proces.
process.exit(0);
```

## **Gebruik een sjabloon**

De logica voor de grootte is hetzelfde voor een bestaande presentatie. Pas het voorbeeld als volgt aan:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.  
2. Controleer of de eerste dia ten minste drie vormen bevat en gebruik vervolgens de vorm op index 2 als tijdelijke aanduiding.  
3. Neem de frame‑breedte en -hoogte van die vorm in plaats van de vaste waarden 684 en 288. Gebruik dezelfde afmetingen in het script voor het maken van de werkmap, houd de berekeningen ongewijzigd, en genereer de XLS‑werkmap opnieuw voordat u deze embedt.  
4. Voeg het OLE‑frame toe op de positie van de tijdelijke aanduiding in plaats van de vaste coördinaten 36 en 72.  
5. Verwijder de tijdelijke aanduiding voordat u de presentatie opslaat.

## **FAQ**

**Waarom verandert mijn ingebedde Excel‑grafiek van grootte na activering in PowerPoint?**  
Dit gebeurt omdat Excel bij de eerste activering probeert het oorspronkelijke vensterformaat te herstellen, terwijl het OLE‑objectframe in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de verhoudingen te behouden, wat kan leiden tot een wijziging van de grootte.

**Hoe kan ik de grafiek‑ en OLE‑frame‑groottes consistent houden?**  
Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste afdrukgrootte voor de grafiek voordat u de werkmap embedt. Het bovenstaande voorbeeld toont de benodigde instellingen en eenheden‑conversies.

**Is het afstemmen van de werkmap‑venstergrootte voldoende?**  
Alleen het afstemmen van de werkmap‑venstergrootte voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals in het voorbeeld.

**Werkt deze oplossing zowel voor sjabloon‑gebaseerde presentaties als voor nieuwe presentaties?**  
Ja. Voor een sjabloon gebruikt u de afmetingen en positie van de tijdelijke aanduiding. Voor een nieuwe presentatie specificeert u de frame‑afmetingen en positie rechtstreeks.

**Kan ik dit voorbeeld gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma's?**  
Het voorbeeld maakt gebruik van een Excel‑werkmap die is gecreëerd met Aspose.Cells. Het laat geen activeringsgedrag zien voor andere spreadsheet‑programma's.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)