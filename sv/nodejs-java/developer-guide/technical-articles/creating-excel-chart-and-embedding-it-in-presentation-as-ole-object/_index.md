---
title: Skapa Excel‑diagram och bädda in dem i presentationer som OLE‑objekt
type: docs
weight: 30
url: /sv/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel‑diagram
- bädda in diagram
- OLE‑objekt
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa ett Excel‑diagram med Aspose.Cells för Node.js via Java och bädda in arbetsboken i en PowerPoint‑presentation med Aspose.Slides, inklusive en diagramförhandsgranskning."
---
## **Översikt**

Den här artikeln visar hur du skapar ett kolumndiagram i Excel med Aspose.Cells för Node.js via Java och bäddar in dess arbetsbok i en PowerPoint‑presentation med Aspose.Slides för Node.js via Java. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG‑förhandsgranskning visar diagrammet på bilden innan OLE‑objektet aktiveras.

Resultatet blir ett inbäddat Excel‑objekt, inte ett inbyggt PowerPoint‑diagram. Att redigera arbetsboken via OLE kräver ett skrivbordsprogram som stöder OLE‑aktivering och en kompatibel Excel‑installation.

## **Förutsättningar**

Installera Node.js‑paketen `aspose.cells`, `aspose.slides.via.java` och `java`. Kör exemplen som två CommonJS‑skript i separata Node.js‑processer: först `create-chart.js`, sedan `embed-chart.js`, med samma arbetskatalog. Båda Aspose‑paketen initierar Java‑bron under laddning, så dessa exempel kör dem i separata processer. Microsoft Office krävs inte för att generera presentationen med dessa bibliotek.

Ingen befintlig arbetsbok eller bild krävs. Det första skriptet skapar `ChartWorkbook.xlsx` och `ChartPreview.png`; det andra läser dessa filer och skriver `OutputChart.pptx` till den aktuella arbetskatalogen. Använd licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddningen fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX och bädda in dess bytes i en bild i en separat Node.js‑process.  
5. Tilldela PNG‑filen som OLE‑objektets förhandsgranskning och spara presentationen som PPTX.

Arbetsbokens visningsområde och ramen på bilden har olika roller. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) tar nollbaserade start-/slutrad‑ och kolumnindex. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) tar istället översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som nedre‑högra gränser; dessa värden är layoutval, inte antalet datarader eller -kolumner.

Bilderamen använder punkter. Exemplet anpassar den inom bilden och centrerar den samtidigt som PNG‑filens bildförhållande bevaras, i stället för att sträcka förhandsgranskningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Spara det första exemplet som `create-chart.js`. Det fyller `DataSheet` med fyra rader och fem kolumner med värden. Varje rad blir en diagramserie. `ChartSheet` väljs som aktivt blad innan arbetsboken sparas.

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

    // Rendera diagramförhandsgranskningen och serialisera den redigerbara arbetsboken separat.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Allt synkront arbete är slutfört; stoppa Java‑bryggprocessen.
process.exit(0);
```

Spara följande exempel som `embed-chart.js`. Kör det efter att `create-chart.js` har skapat båda inmatningsfilerna. Det centrerar OLE‑ramen och bevarar förhandsgranskningsbildens bildförhållande.

Det andra skriptet bäddar in den sparade arbetsboken och använder PNG‑filen som dess förhandsgranskning. Arbetsboken sparas explicit som XLSX, vilket matchar `xlsx`‑extensionen som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG‑filen laddas direkt från dess bytes utan en mellanliggande bitmapkonvertering. Java‑bron kräver explicita Java‑byte‑arrayer för bilden och arbetsboksdata, samt Java‑float‑värden för bildramens koordinater. Att tilldela det via [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersätter standard‑OLE‑platshållaren.

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

        // Anpassa förhandsgranskningen inom bilden utan att ändra bildförhållandet.
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

// Allt synkront arbete är slutfört; stoppa Java-bryggprocessen.
process.exit(0);
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsgranskning. Arbetsboken innehåller de ursprungliga data och ett kolumndiagram med fyra serier. Förhandsgranskningen är centrerad på bilden och behåller sina proportioner.

![Excel‑kolumndiagram som visas som förhandsgranskning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbords‑PowerPoint‑miljö med Excel tillgängligt, dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdprogrammets OLE‑stöd och säkerhetsinställningar.

## **FAQ**

**Varför behövs en förhandsbild?**

Den inbäddade arbetsboken och dess bildförhandsgranskning är separat innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet i stället för standard‑“EMBEDDED OLE OBJECT”-platshållaren. Se [Object Preview Issue when Adding OleObjectFrame](/slides/sv/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsgranskningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsgranskningen som ett ögonblicksbild. När du uppdaterar arbetsboksdata programvarumässigt, återskapa diagrambilden och ersätt förhandsgranskningen samt den inbäddade arbetsboksdata.

**Kan jag använda XLS i stället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data‑extensionen. Extensionen måste matcha det faktiska arbetsboksformatet; att enbart ändra extensionen konverterar inte data.

**Varför kan objektet förändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Working Solution for Chart Resizing in PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Arbetslösning för diagramstorleksändring i PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsgranskning av objekt vid tillägg av OleObjectFrame](/slides/sv/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)