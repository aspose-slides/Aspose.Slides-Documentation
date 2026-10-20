---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Hozzon létre egy Excel diagramot az Aspose.Cells for PHP via Java használatával, és ágyazza be a munkafüzetet egy PowerPoint prezentációba az Aspose.Slides for PHP via Java segítségével, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre Excel oszlopdiagramot az Aspose.Cells for PHP via Java használatával, és ágyazzuk be a munkafüzetét egy PowerPoint-prezentációba az Aspose.Slides for PHP via Java segítségével. A beágyazott munkafüzet tartalmazza a forrás adatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódik.

Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez egy asztali alkalmazás szükséges, amely támogatja az OLE aktiválást, valamint egy kompatibilis Excel telepítés.

## **Előfeltételek**

Konfigurálja az Aspose.Cells for PHP via Java és az Aspose.Slides for PHP via Java termékeket ugyanazzal a PHP/Java Bridge példánnyal. Töltse be mindkét PHP wrappert, és tegye a termékek Java könyvtárait elérhetővé a bridge számára. A Microsoft Office nem szükséges a prezentáció generálásához ezekkel a könyvtárakkal.

Nem szükséges bemeneti fájl: a példa a memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Licencet kell alkalmazni mindkét termékre, ha a próbaverzióon kívül futtatja.

## **A beágyazás működése**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagram munkalappal.
1. Tegye a diagram munkalapot aktívvá, hogy a munkafüzet a diagramon nyíljon meg.
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG-be.
1. Mentse a munkafüzetet XLSX formátumban a memóriában, és ágyazza be ezeket a bájtokat egy diára.
1. Rendelje hozzá a PNG-t OLE objektum előnézeteként, és mentse a prezentációt PPTX formátumban.

A munkafüzet megjelenítési tartománya és a dián lévő keret különböző szerepeket töltenek be. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) nullal indexelt kezdő/​záró sor‑ és oszlopindexeket vár. A [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) ehelyett a felső sort, baloszlopot, alsó sort és jobb oszlopot veszi. A példa a 55‑ös sorindexet és a 25‑ös oszlopindexet használja alsó‑jobb határként; ezek az értékek elrendezési döntések, nem az adat sorok vagy oszlopok száma.

A diakeret pontokban van megadva. A példa úgy illeszti a keretet a diára, hogy középre helyezi, miközben megőrzi a PNG képarányát, ahelyett, hogy nyújtaná az előnézetet a teljes diára.

## **Diagram létrehozása és beágyazása**

Az alábbi teljes példa a `DataSheet` táblát négy sorral és öt oszloppal tölti fel értékekkel. Minden sor egy diagram sorozattá válik. A `ChartSheet` a mentés előtt aktív munkalappá van kiválasztva.

A munkafüzet kifejezetten XLSX formátumban van mentve, amely megfelel a `xlsx` kiterjesztésnek, amelyet az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) kap. A Java numerikus eredményeket a `java_values` konvertálja, mielőtt a PHP aritmetikai műveleteket végezne, míg a bináris adatok Java bájt tömbökben maradnak. A PNG közvetlenül a bájtjaiból van betöltve, köztes bitmap konverzió nélkül. Ennek [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével történő hozzárendelése felváltja az alapértelmezett OLE helykitöltőt.

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

    // Tartsa a PNG-t és az XLSX-et Java bájt tömbökként, amikor azokat a Slides-nek adja át.
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

            // Illessze és középre helyezze az előnézetet, miközben megőrzi a képarányát.
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

## **Várható eredmény**

A `OutputChart.pptx` egy diát tartalmaz, amely egy beágyazott Excel munkafüzetet és egy diagram előnézetet tartalmaz. A munkafüzet a eredeti adatokat és egy négy sorozatú oszlopdiagramot tartalmaz. Az előnézet a dián középre van helyezve és megtartja arányait.

![Excel oszlopdiagram, amely a beágyazott munkafüzet előnézeteként jelenik meg](excel-chart-ole-preview.png)

Kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, duplán kattintson az objektumra a beágyazott munkafüzet aktiválásához és szerkesztéséhez. Az aktiválás és a szerkesztés a host alkalmazás OLE támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges előnézeti kép?**

A beágyazott munkafüzet és a dián megjelenő előnézet különálló tartalom. Adjon meg egy diagram képet, hogy a dia a diagramot mutassa az alapértelmezett "EMBEDDED OLE OBJECT" helykitöltő helyett. Lásd a [Objektum előnézeti probléma az OleObjectFrame hozzáadásakor](/slides/hu/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**

Az előnézetet tekintse egy pillanatképként. Ha programozottan frissíti a munkafüzet adatait, újból generálja a diagram képet, és cserélje le az előnézetet és a beágyazott munkafüzet adatokat is.

**Használhatok XLS-t XLSX helyett?**

Igen. Mentse a munkafüzetet XLS formátumban, és használja a `xls` kiterjesztést a beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; csak a kiterjesztés módosítása önmagában nem konvertálja az adatot.

**Miért változhat meg az objektum mérete az aktiválás után?**

A host alkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diakeret méretei egyaránt számítanak. Lásd a [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézeti probléma az OleObjectFrame hozzáadásakor](/slides/hu/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE objektumok kezelése](/slides/hu/php-java/manage-ole/)