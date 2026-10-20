---
title: Fungerande lösning för diagramomskalning i PPTX
type: docs
weight: 40
url: /sv/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramomskalning
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Åtgärda oväntad diagramomskalning i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för Node.js via Java. Ange fasta diagramdimensioner för att hålla diagrammets och OLE-ramens storlekar konsekventa."
---
## **Översikt**

Excel-diagram som bäddas in som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktiveringen. Denna artikel förklarar varför omstorlek uppstår och visar hur man förhindrar det genom att matcha fasta diagramdimensioner med OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för Node.js via Java och bäddar in det i en PowerPoint-presentation med Aspose.Slides för Node.js via Java. För att åtgärda [problem med förhandsgranskning av objekt](/slides/sv/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrambilden till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återvänder till bilden, och omstorleksfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till omskalning**

Den inbäddade Excel-arbetsboken har sina egna fönsterdimensioner, som Excel försöker behålla när objektet aktiveras för första gången. OLE-ramen på bilden har separat definierade dimensioner. När Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att behålla dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför orsaka att objektet ändrar storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE-ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells för Node.js via Java och Aspose.Slides för Node.js via Java. Installera `aspose.cells`, `aspose.slides.via.java` och `java` Node.js-paketen. Kör de två CommonJS-skripten nedan i separata Node.js-processer, med samma arbetskatalog, eftersom båda Aspose-paketen initierar Java-bryggan under laddning. Det skapar ett enkelt stapeldiagram på ett aktivt diagramark och bäddar in arbetsboken i XLS-format. Ingen förhandsgranskningsbild för diagrammet tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en 9,5 × 4 tum OLE-ram placerad 0,5 tum från vänster kant och 1 tum från toppen. Bildkoordinater och dimensioner är i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ange en fast diagramstorlek**

Ställ in [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) till false så att diagramdimensionerna är oberoende av arbetsbokens fönster. Ställ in [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject)-dimensionerna via [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) och [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), konvertera punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ställ in [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) till CUSTOM‑värdet för `PrintSizeType`. Exemplet bäddar in arbetsboken med [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) och sparar en presentation med en 9,5 × 4 tum OLE-ram.

Spara detta första skript som `create-fixed-chart.js`. Det skapar `chart-fixed-size.xls` med ett diagram som mäter 912 × 384 pixlar, vilket matchar den 684 × 288‑punktsram som används av det andra skriptet. Ingen indataarbetsbok krävs.

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

    // Matcha OLE-ramens dimensioner i punkter (72 punkter per tum).
    const width = 684; // 9,5 tum.
    const height = 288; // 4 tum.

    chart.setSizeWithWindow(false);
    // Konvertera punkter till diagrampixel med 96 pixlar per tum.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Allt synkront arbete är klart; stoppa Java-bryggprocessen.
process.exit(0);
```

Spara det andra skriptet som `embed-fixed-chart.js` och kör det efter `create-fixed-chart.js`. Det läser den genererade XLS‑arbetsboken och sparar `chart-fixed-size.pptx`. Java‑bryggan kräver en explicit Java‑bytearray för arbetsboksdata och Java‑float‑värden för ramens koordinater och dimensioner. `xls`‑ändelsen matchar arbetsbokens sparade format.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Bildkoordinater och dimensioner är i punkter (72 punkter per tum).
    const width = 684; // 9,5 tum.
    const height = 288; // 4 tum.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Allt synkront arbete är klart; stoppa Java-bryggprocessen.
process.exit(0);
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.
1. Kontrollera att den första bilden innehåller minst tre former, och använd sedan formen på index 2 som platshållare.
1. Hämta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Använd samma dimensioner i skriptet som skapar arbetsboken, behåll dimensioneringsberäkningarna oförändrade och återskapa XLS‑arbetsboken innan den bäddas in.
1. Lägg till OLE‑ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.
1. Ta bort platshållaren innan presentationen sparas.

## **Vanliga frågor**

**Varför ändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta händer eftersom Excel försöker återställa den ursprungliga fönsterstorleken vid den första aktiveringen, medan OLE‑objektramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till en omdimensionering.

**Hur kan jag hålla diagrammets och OLE‑ramens storlekar konsekventa?**

Ange fasta diagramdimensioner som matchar OLE‑ramen och använd en anpassad diagramutskriftstorlek innan arbetsboken bäddas in. Exemplet ovan visar de nödvändiga inställningarna och enhetskonverteringarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**

Att endast matcha arbetsbokens fönsterstorlek förhindrar inte på ett pålitligt sätt att OLE‑ramen ändrar storlek efter aktivering. Använd fasta diagramdimensioner som visas i exemplet.

**Fungerar denna lösning med både mallbaserade presentationer och nya presentationer?**

Ja. För en mall, använd platshållarens dimensioner och position. För en ny presentation, ange ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylprogram?**

Exemplet använder en Excel‑arbetsbok skapad med Aspose.Cells. Det visar inte aktiveringsbeteende för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)