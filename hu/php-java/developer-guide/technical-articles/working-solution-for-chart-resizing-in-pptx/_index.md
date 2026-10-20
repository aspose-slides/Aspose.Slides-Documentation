---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 40
url: /hu/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Javítsa a PPTX-ben a beágyazott Excel OLE objektumok használata során előforduló váratlan diagram átméretezést az Aspose.Slides for PHP via Java segítségével. Állítson be rögzített diagramméreteket, hogy a diagram és az OLE keret méretei következetesek maradjanak."
---
## **Áttekintés**

Az Aspose komponensekkel PowerPoint‑prezentációkba OLE objektumként ágyazott Excel‑diagramok az első aktiválás után méretet változtathatnak. Ez észrevehető különbséget eredményez a diagram megjelenésében aktiválás előtt és után. Ez a cikk elmagyarázza, miért következik be az átméretezés, és bemutatja, hogyan lehet megelőzni azt a diagram rögzített méreteinek az OLE‑kerethez igazításával.

Az [Excel‑diagramok létrehozása és OLE‑objektumként való beágyazása a prezentációkba](/slides/hu/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) cikkben bemutattuk, hogyan lehet Excel‑diagramot létrehozni az Aspose.Cells for PHP via Java segítségével, és beágyazni azt PowerPoint‑prezentációba az Aspose.Slides for PHP via Java használatával. Az [objektum előnézeti probléma](/slides/hu/php-java/object-preview-issue-when-adding-oleobjectframe/) kezelésére a diagram képet a diagram OLE objektumkeretéhez rendeltük. A kimeneti prezentációban, ha duplán kattintunk a diagramképet megjelenítő OLE objektumkeretre, az Excel‑diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel‑munkafüzetet, majd a aktivált munkafüzeten kívülre kattintva visszatérhetnek a diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési tényező a OLE objektumkeret és a beágyazott Excel‑munkafüzet eredeti méreteitől függ.

## **Átméretezés oka**

A beágyazott Excel‑munkafüzetnek saját ablakméretei vannak, amelyeket az Excel megpróbál megőrizni az objektum első aktiválásakor. A dián lévő OLE keret önállóan definiált méretekkel rendelkezik. Amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy a beágyazás folyamata során megmaradjon az arányosság. A munkafüzetablak és az OLE keret közötti különbségek ezért okozhatják az objektum átméretezését.

## **Működő megoldás**

Igazítsuk a diagram méretét a dián lévő OLE kerethez, és tartsuk a diagram méreteit függetlenül a munkafüzetablaktól. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példa az Aspose.Cells for PHP via Java és az Aspose.Slides for PHP via Java termékeket igényli. Állítsuk be mindkét terméket ugyanazzal a PHP/Java Bridge példánnyal, töltsük be mindkét PHP wrapper‑t, és tegyük a Java‑könyvtárakat elérhetővé a bridge számára. Bemeneti fájlokra nincs szükség. Egy egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és XLS formátumban ágyazza be a munkafüzetet. Nem rendelünk diagram előnézeti képet; a diagram akkor válik láthatóvá, amikor az OLE objektum aktiválódik a PowerPoint‑ban.

A példa egy új prezentációt hoz létre 9,5 × 4 hüvelykes OLE kerettel, amely 0,5 hüvelykre van pozicionálva a bal szélről és 1 hüvelykre felülről. A dia koordinátái és méretei pontban vannak megadva (72 pont per hüvelyk). Létező prezentáció esetén lásd a [Sablon használata](#use-a-template) szekciót.

## **Rögzített diagramméret beállítása**

Állítsuk a [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) értékét **false**‑ra, hogy a diagram méretei függetlenek legyenek a munkafüzetablaktól. A [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) méreteit a [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) és a [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) segítségével állítsuk be, a pontokat 96 pixel per hüvelyk alapján pixelre konvertálva: egy 684 × 288 pont méretű keret 912 × 384 pixel méretű diagramnak felel meg. A [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) értékét állítsuk a [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/) **CUSTOM** értékére. A példa a [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) segítségével ágyazza be a munkafüzetet, és egy 9,5 × 4 hüvelykes OLE kerettel menti a prezentációt.

A Java numerikus eredményeket a `java_values` függvénnyel konvertáljuk, mielőtt PHP indexként használnánk őket. A munkafüzet bájtjai Java byte array‑ként maradnak, amikor a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/)‑nek adjuk át.

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

        // Dia koordinátái és méretei pontban vannak megadva (72 pont per hüvelyk).
        $width = 684; // 9,5 hüvelyk.
        $height = 288; // 4 hüvelyk.

        $chart->setSizeWithWindow(false);
        // Konvertálja a pontokat diagram pixelre 96 pixel per hüvelyk használatával.
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

## **Sablon használata**

A méretezési logika ugyanaz egy meglévő prezentáció esetén is. A példa adaptálásához:

1. Töltsük be a sablonprezentációt egy üres prezentáció létrehozása helyett.
1. Ellenőrizzük, hogy az első dián legalább három alakzat van-e, majd a 2. indexű alakzatot használjuk helyőrzőként.
1. A keret szélességét és magasságát vegyük az adott alakzatról a 684 és 288 rögzített értékek helyett. A méretezési számításokat tartsuk változatlanul.
1. Adjuk hozzá az OLE keretet a helyőrző pozíciójához a 36 és 72 rögzített koordináták helyett.
1. Távolítsuk el a helyőrzőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik méretben a beágyazott Excel‑diagram, miután aktiválom PowerPoint‑ban?**

Ez azért történik, mert az Excel megpróbálja visszaállítani az eredeti ablakméretet az első aktiváláskor, míg a PowerPoint‑ban az OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami az átméretezéshez vezethet.

**Hogyan tarthatom konzisztensnek a diagram és az OLE‑keret méreteit?**

Állítsunk be rögzített diagramméreteket, amelyek megegyeznek az OLE keret méreteivel, és a beágyazás előtt használjunk egyedi diagramnyomtatási méretet. A fenti példa mutatja a szükséges beállításokat és egységkonverziókat.

**Elégséges-e a munkafüzet ablakméretének egyeztetése?**

A munkafüzet ablakméretének csak önmagában történő egyeztetése nem biztosítja megbízhatóan, hogy az OLE keret ne változzon méretben aktiválás után. Használjunk rögzített diagramméreteket, ahogy a példában látható.

**Működik ez a megoldás sablon‑alapú és új prezentációk esetén is?**

Igen. Sablon esetén a helyőrző méreteit és pozícióját használjuk. Új prezentáció esetén a keret méreteit és pozícióját közvetlenül adjuk meg.

**Használhatom ezt a példát más táblázatkezelő programokban létrehozott diagramokkal?**

A példa egy Aspose.Cells‑szel létrehozott Excel‑munkafüzetet használ. Nem mutatja be más táblázatkezelő programok aktiválási viselkedését.

## **Kapcsolódó szakaszok**

- [Excel‑diagramok létrehozása és OLE‑objektumként való beágyazása a prezentációkba](/slides/hu/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)