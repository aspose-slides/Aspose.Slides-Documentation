---
title: Maak Excel-diagrammen en voeg ze in presentaties in als OLE-objecten
type: docs
weight: 30
url: /nl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram insluiten
- OLE-object
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak een Excel-diagram met Aspose.Cells for Node.js via Java en voeg de werkmap in in een PowerPoint-presentatie met Aspose.Slides, inclusief een voorbeeld van het diagram."
---
## **Overzicht**

Dit artikel laat zien hoe u een Excel‑kolomdiagram maakt met Aspose.Cells for Node.js via Java en de werkmap ervan insluit in een PowerPoint‑presentatie met Aspose.Slides for Node.js via Java. De ingesloten werkmap bevat zowel de brongegevens als het diagram. Een aparte PNG‑voorbeeldweergave toont het diagram op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingesloten Excel‑object, geen native PowerPoint‑diagram. Het bewerken van de werkmap via OLE vereist een desktop‑applicatie die OLE‑activering ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Installeer de Node.js‑pakketten `aspose.cells`, `aspose.slides.via.java` en `java`. Voer de voorbeelden uit als twee CommonJS‑scripts in afzonderlijke Node.js‑processen: eerst `create-chart.js`, daarna `embed-chart.js`, waarbij dezelfde werkmap wordt gebruikt. Beide Aspose‑pakketten initialiseren de Java‑bridge tijdens het laden, dus deze voorbeelden houden ze in afzonderlijke processen. Microsoft Office is niet vereist om de presentatie met deze bibliotheken te genereren.

Er is geen bestaande werkmap of afbeelding nodig. Het eerste script maakt `ChartWorkbook.xlsx` en `ChartPreview.png`; het tweede leest die bestanden en schrijft `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer u buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkmap met een gegevenswerkblad en een diagramblad.  
2. Maak het diagramblad actief zodat de werkmap opent op het diagram.  
3. Stel het OLE‑weergavebereik van de werkmap in en render het diagram naar PNG.  
4. Sla de werkmap op als XLSX en voeg de bytes ervan in op een dia in een afzonderlijk Node.js‑proces.  
5. Wijs de PNG toe als voorbeeld van het OLE‑object en sla de presentatie op als PPTX.

Het weergavebereik van de werkmap en het frame op de dia hebben verschillende rollen. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) neemt nulgebaseerde start‑/eind‑rij‑ en kolomindexen. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) neemt daarentegen de bovenste rij, de linkerkolom, de onderste rij en de rechterkolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als de rechter‑onder‑grenzen; deze waarden zijn lay‑outkeuzes, geen aantallen gegevensrijen of -kolommen.

Het dia‑frame gebruikt punten. Het voorbeeld past het binnen de dia en centreert het, terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de voorbeeldweergave uit te rekken om de dia te vullen.

## **Maak en insluit het diagram**

Bewaar het eerste voorbeeld als `create-chart.js`. Het vult `DataSheet` met vier rijen en vijf kolommen waarden. Elke rij wordt een diagramreeks. `ChartSheet` wordt geselecteerd als het actieve blad voordat de werkmap wordt opgeslagen.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render de diagramvoorbeeldweergave en serialiseer de bewerkbare werkmap apart.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Alle synchronische taken zijn voltooid; stop het Java-bridge-proces.
process.exit(0);
```

Bewaar het volgende voorbeeld als `embed-chart.js`. Voer het uit nadat `create-chart.js` beide invoerbestanden heeft aangemaakt. Het centreert het OLE‑frame en behoudt de beeldverhouding van de voorbeeldafbeelding.

Het tweede script voegt de opgeslagen werkmap in en gebruikt de PNG als voorbeeld. De werkmap wordt expliciet opgeslagen als XLSX, overeenkomstig de extensie `xlsx` die wordt doorgegeven aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). De PNG wordt rechtstreeks uit de bytes geladen zonder een tussenliggende bitmap‑conversie. De Java‑bridge vereist expliciete Java‑byte‑arrays voor de afbeelding en werkmapgegevens, en Java‑floatwaarden voor de coördinaten van het dia‑frame. Toewijzing via [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) vervangt de standaard OLE‑plaatsvervanger.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Pas de voorbeeldweergave aan binnen de dia zonder de beeldverhouding te veranderen.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Alle synchronische taken zijn voltooid; stop het Java-bridge-proces.
process.exit(0);
```

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingesloten Excel‑werkmap en een diagramvoorbeeld. De werkmap bevat de oorspronkelijke gegevens en een kolomdiagram met vier reeksen. Het voorbeeld is gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel kolomdiagram weergegeven als voorbeeld van een ingesloten werkmap](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, dubbelklik op het object om het ingesloten werkmap te activeren en bewerken. Activering en bewerking hangen af van de OLE‑ondersteuning en de beveiligingsinstellingen van de host‑applicatie.

## **FAQ**

**Waarom is een voorbeeldafbeelding nodig?**

De ingesloten werkmap en de dia‑voorbeeldweergave zijn afzonderlijke inhoud. Lever een diagramafbeelding zodat de dia het diagram toont in plaats van de standaard “EMBEDDED OLE OBJECT”‑plaatsvervanger. Zie [Probleem met voorbeeldweergave bij toevoegen van OleObjectFrame](/slides/nl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Wordt de voorbeeldweergave automatisch bijgewerkt wanneer ik de werkmap in code wijzig?**

Beschouw de voorbeeldweergave als een momentopname. Wanneer u de werkmapgegevens programmatisch bijwerkt, genereer u de diagramafbeelding opnieuw en vervangt u zowel de voorbeeldweergave als de ingesloten werkmapgegevens.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla de werkmap op in XLS‑indeling en gebruik `xls` als de extensie voor de ingesloten gegevens. De extensie moet overeenkomen met het werkelijke werkmapformaat; alleen de extensie wijzigen converteert de gegevens niet.

**Waarom kan het object van grootte veranderen na activering?**

De host‑applicatie kan de weergave van het OLE‑object bijwerken wanneer het de werkmap activeert. Het OLE‑weergavebereik van de werkmap en de afmetingen van het dia‑frame zijn beide van belang. Zie [Werkende oplossing voor diagramschaling in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/).

## **Gerelateerde secties**

- [Werkende oplossing voor diagramschaling in PPTX](/slides/nl/java/working-solution-for-chart-resizing-in-pptx/)
- [Probleem met voorbeeldweergave bij toevoegen van OleObjectFrame](/slides/nl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)