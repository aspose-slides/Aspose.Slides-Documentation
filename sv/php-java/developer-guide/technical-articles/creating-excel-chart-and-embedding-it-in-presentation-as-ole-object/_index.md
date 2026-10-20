---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells för PHP via Java och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides för PHP via Java, inklusive en diagramförhandsvy."
---
## **Översikt**

Den här artikeln visar hur man skapar ett Excel-stapeldiagram med Aspose.Cells för PHP via Java och bäddar in dess arbetsbok i en PowerPoint-presentation med Aspose.Slides för PHP via Java. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG-förhandsvy visar diagrammet på bilden innan OLE-objektet aktiveras.

Resultatet är ett inbäddat Excel-objekt, inte ett native PowerPoint-diagram. Redigering av arbetsboken via OLE kräver ett skrivbordsprogram som stöder OLE-aktivering och en kompatibel Excel-installation.

## **Förutsättningar**

Konfigurera Aspose.Cells för PHP via Java och Aspose.Slides för PHP via Java med samma PHP/Java Bridge‑instans. Ladda båda PHP‑omslagen och gör båda produkternas Java‑bibliotek tillgängliga för bryggan. Microsoft Office krävs inte för att generera presentationen med dessa bibliotek.

Inga inmatningsfiler behövs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Tilldela licenser för båda produkterna när du kör utanför utvärderingsläget.

## **Hur inbäddningen fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX i minnet och bädda in dessa bytes i en bild.  
5. Tilldela PNG‑filen som OLE‑objektets förhandsvy och spara presentationen som PPTX.

Arbetsbokens visningsområde och ramen på bilden har olika roller. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) tar nollbaserade start‑/slutrad‑ och kolumnindex. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) tar i stället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som nedre‑högra gränser; dessa värden är layoutval, inte antalet datarader eller kolumner.

Bildramen använder punkter. Exemplet anpassar den inom bilden och centrerar den samtidigt som PNG‑filens bildförhållande bevaras, snarare än att sträcka förhandsvyn för att fylla bilden.

## **Skapa och bädda in diagrammet**

Följande kompletta exempel fyller `DataSheet` med fyra rader och fem kolumner med värden. Varje rad blir en diagramserie. `ChartSheet` väljs som det aktiva bladet innan arbetsboken sparas.

Arbetsboken sparas explicit som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Java‑numeriska resultat konverteras med `java_values` innan PHP utför aritmetik, medan binär data förblir i Java‑byte‑arrayer. PNG‑filen laddas direkt från sina bytes utan en mellanliggande bitmap‑konvertering. Genom att tilldela den via [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersätts standard‑OLE‑platshållaren.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Behåll PNG- och XLSX-filerna som Java-bytearrayer när de skickas till Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Anpassa och centrera förhandsvyn samtidigt som bildförhållandet bevaras.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsvy. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsvyn är centrerad på bilden och behåller sina proportioner.

![Excel-stapeldiagram visas som förhandsvy för en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbordsmiljö för PowerPoint med Excel tillgängligt kan du dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdapplikationens OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsbild?**

Den inbäddade arbetsboken och dess bildförhandsvy är separata innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"‑platshållaren. Se [Problem med förhandsvy för objekt när OleObjectFrame läggs till](/slides/sv/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsvyn automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsvyn som en ögonblicksbild. När du uppdaterar arbetsbokens data programmässigt, generera om diagrambilden och ersätt förhandsvyn samt den inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data‑tillägget. Tillägget måste matcha det faktiska arbetsboksformatet; att enbart ändra tillägget konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdprogrammet kan uppdatera OLE‑objektets presentation när det aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Fungerande lösning för diagramändring i PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Fungerande lösning för diagramändring i PPTX](/slides/sv/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsvy för objekt när OleObjectFrame läggs till](/slides/sv/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Hantera OLE‑objekt](/slides/sv/php-java/manage-ole/)