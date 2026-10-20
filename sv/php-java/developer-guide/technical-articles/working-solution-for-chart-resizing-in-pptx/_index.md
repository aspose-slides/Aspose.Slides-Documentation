---
title: Fungerande lösning för diagramstorleksändring i PPTX
type: docs
weight: 40
url: /sv/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Åtgärda oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för PHP via Java. Ställ in fasta diagramdimensioner för att hålla diagrammets och OLE-ramens storlekar konsekventa."
---
## **Översikt**

Excel-diagram som bäddas in som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan orsaka en märkbar skillnad i diagrammets utseende före och efter aktivering. Den här artikeln förklarar varför storleksändringen sker och visar hur du förhindrar den genom att matcha fasta diagramdimensioner med OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells för PHP via Java och bäddar in det i en PowerPoint-presentation med Aspose.Slides för PHP via Java. För att lösa [objektförhandsgranskningsproblem](/slides/sv/php-java/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi diagrammets bild till diagrammets OLE-objektram. I den genererade presentationen, när du dubbelklickar på OLE-objektramen som visar diagrammets bild, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återgår till bilden, och förändringsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel-arbetsboken har egna fönsterdimensioner, som Excel försöker behålla när objektet aktiveras för första gången. OLE-ramen på bilden har självständigt definierade dimensioner. När Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att bevara dess proportioner som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför orsaka att objektet ändrar storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE-ramen på bilden och håll diagrammets dimensioner oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells för PHP via Java och Aspose.Slides för PHP via Java. Konfigurera båda produkterna med samma PHP/Java Bridge-instans, ladda båda PHP-wrapperna och gör båda Java-biblioteken tillgängliga för bryggan. Inga indatafiler krävs. Det skapar ett enkelt stapeldiagram på ett aktivt diagramblad och bäddar in arbetsboken i XLS-format. Ingen förhandsgranskningsbild för diagrammet tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en 9,5 × 4 tum OLE-ram placerad 0,5 tum från vänsterkant och 1 tum från toppen. Bildens koordinater och dimensioner är i punkter (72 punkter per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ställ in en fast diagramstorlek**

Ställ in [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) till false så att diagrammets dimensioner är oberoende av arbetsbokens fönster. Ställ in dimensionerna för [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) via [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) och [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), konvertera punkter till pixlar med 96 pixlar per tum: en ram som mäter 684 × 288 punkter motsvarar ett diagram som mäter 912 × 384 pixlar. Ställ in [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) till CUSTOM-värdet för [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). Exemplet bäddar in arbetsboken med [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) och sparar en presentation med en 9,5 × 4 tum OLE-ram.

Java-numeriska resultat konverteras med `java_values` innan de används som PHP-index. Arbetsbokens bytes förblir i en Java-bytearray när de skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Bildens koordinater och dimensioner är i punkter (72 punkter per tum).
        $width = 684; // 9,5 tum.
        $height = 288; // 4 tum.

        $chart->setSizeWithWindow(false);
        // Konvertera punkter till diagrampixlar med 96 pixlar per tum.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.
1. Kontrollera att den första bilden innehåller minst tre former och använd sedan formen med index 2 som platshållare.
1. Ta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll storleksberäkningarna oförändrade.
1. Lägg till OLE-ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.
1. Ta bort platshållaren innan presentationen sparas.

## **Vanliga frågor**

**Varför ändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta händer eftersom Excel försöker återställa det ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan leda till storleksändringen.

**Hur kan jag hålla diagram- och OLE-ramstorlekarna konsekventa?**

Ställ in fasta diagramdimensioner som matchar OLE-ramen och använd en anpassad diagramutskriftstorlek innan arbetsboken bäddas in. Exemplet ovan visar de erforderliga inställningarna och enhetsomvandlingarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**

Att enbart matcha arbetsbokens fönsterstorlek förhindrar inte på ett pålitligt sätt att OLE-ramen förändras i storlek efter aktivering. Använd fasta diagramdimensioner som visas i exemplet.

**Fungerar denna lösning både för mallbaserade presentationer och nya presentationer?**

Ja. För en mall, använd platshållarens dimensioner och position. För en ny presentation, ange ramens dimensioner och position direkt.

**Kan jag använda detta exempel med diagram skapade i andra kalkylprogram?**

Exemplet använder en Excel-arbetsbok skapad med Aspose.Cells. Det visar inte aktiveringsbeteende för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)