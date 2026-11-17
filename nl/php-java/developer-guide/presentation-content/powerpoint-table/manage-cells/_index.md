---
title: Beheer tabelcellen in presentaties met PHP
linktitle: Cellen beheren
type: docs
weight: 30
url: /nl/php-java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in PHP: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides stelt je in staat tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe je samengevoegde tabelcellen identificeert, celranden verwijdert, werkt met celnummering na samenvoegen of splitsen van cellen, de achtergrondkleur van een cel wijzigt en een afbeelding toevoegt binnen een tabelcel. De voorbeelden laten zien hoe je een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indices om tabelcellen te benaderen in de volgorde `(kolom, rij)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) om cellen in samengevoegde regio’s te identificeren. Voor elke match worden de celcoördinaten in `rij;kolf`‑volgorde, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), en de startcoördinaten van de regio, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) en [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/), afgedrukt.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tabelcelranden verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Kolombreedtes, rijhoogtes en de tabelpositie worden gespecificeerd in punten. Het voorbeeld stelt alle vier de celranden in op [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Diagonale celranden toevoegen**

Gebruik [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) om een lijn te tekenen van de linkerbovenhoek naar de rechteronderhoek, en [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) om een lijn te tekenen van de linkeronderhoek naar de rechterbovenhoek. Een diagonale kan een hoek‑header markeren; beide diagonalen kunnen een X vormen om een cel als niet‑toepasbaar aan te geven.

Elke diagonale heeft zijn eigen [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). In de [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) gebruik je [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) om [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) te selecteren en kies je een kleur via [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Stel de lijndikte in punten in met [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Het voorbeeld maakt drie cellen in één rij: een rode neerwaartse diagonale, een blauwe opwaartse diagonale, en beide diagonalen. De boven‑, onder‑, linker‑ en rechter‑celranden blijven ongewijzigd.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Een diagonale verandert alleen de celopmaak. Elke cel behoudt één tekstframe, benaderd via [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). De regio’s aan beide kanten van een diagonale kunnen niet onafhankelijk bewerkt worden.

De opgeslagen tabel, weergegeven in Microsoft PowerPoint:

![Drie tabelcellen met een rode diagonale van links‑boven naar rechts‑onder, een blauwe diagonale van links‑onder naar rechts‑boven, en beide diagonalen die een X vormen.](diagonal-cell-borders.png)

*Van links naar rechts: neerwaartse diagonale (rood, 3 pt), opwaartse diagonale (blauw, 5 pt) en beide diagonalen.*

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) om een rechthoekig bereik van tabelcellen tot één cel te combineren. Geef de cellen op die zich in de linkerboven‑ en rechteronderhoek van het bereik bevinden. Het laatste argument bepaalt of het samenvoegen cellen buiten het opgegeven bereik mag omvatten; `false` houdt het samenvoegen binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punt, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot `(2, 2)` samen. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik je de linkerbovenpositie: `$table->get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indices van cellen buiten het bereik niet wijzigen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindices van de cellen rechts ervan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punt en roept [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) aan op cel `(1, 1)`. De helft van de breedte van 70 punt wordt doorgegeven om twee even brede cellen te creëren.

Na deze splitsing worden de twee helften benaderd als `$table->get_Item(1, 1)` en `$table->get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verschuiven respectievelijk naar kolommen 3 en 4. Rijenindices blijven ongewijzigd. Gebruik deze bijgewerkte kolomindices bij het benaderen van cellen na de splitsing.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![Een niet‑samengevoegde cel van 70 punt splitst in twee cellen van 35 punt, waardoor een vijfde rasterkolom ontstaat en de indices rechts ervan verschuiven.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*De breedtesplitsing heeft invloed op cel (1, 1), met nul‑gebaseerde (kolom, rij) indices. Andere rijen behouden een cel die beide nieuwe kolomposities beslaat.* 
<!-- visual-explanation:manage-cells:end -->

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensinvoer voor te bereiden, gebruik je [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) om langs een bestaande rijgrens te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) om langs een kolomgrens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linker‑deel van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Rijsplitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Kolomsplitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Het voorbeeld gaat uit van een presentatie met een tabel als eerste vorm op de eerste dia, waarbij `(1, 2)` en `(1, 3)` verticaal samengevoegd zijn. Vanaf de onderste positie wordt [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) en [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) gebruikt om de oorsprong te vinden en beide spans te controleren. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale tweekoloms‑samenvoeging gebruik je in plaats daarvan `splitByColSpan(1)`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Haal de resulterende cellen op uit de tabel na het splitsen.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Het tabelraster en de omliggende celindices blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; beide hebben een span van 1 en [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) geeft `false` terug. Grotere regio’s kunnen na één splitsing gedeeltelijk samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de bovenste (of linker) cel; de nieuwe cel is leeg maar erft de celopmaak zoals opvulling, randen en marges. Vul de cellen na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat aparte cellen “Product A” en “Product B” met de sjablooncel‑opmaak behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) voor details.

### **Een cel op een specifieke hoogte splitsen**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) neemt de hoogte van het bovenste deel in punten. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) neemt het aantal bestaande rasterrijen in het bovenste deel. Om een cel van 40 punt in de rechterkolom te centreren, trek je 40 af van de werkelijke hoogte van de cel en verdeel je de resterende ruimte gelijk boven en onder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De eerste splitsing voegt een rasterrij toe en laat de onderste 90 punt in cel `(1, 1)` achter. De tweede splitsing verdeelt die cel in een middencel van 40 punt en een onderste cel van 50 punt. De rechterkolom heeft nu drie cellen met hoogtes van 50, 40 en 50 punt van boven naar beneden. De linkercel beslaat alle drie de rijen en behoudt zijn oorspronkelijke hoogte van 140 punt.

![De linkercel beslaat de volledige tabelhoogte naast drie cellen met “Middle” in het centrum.](split-by-height.png)

## **De achtergrondkleur van een tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 punt en rijen van 50 punt. Het gebruikt [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) om een solide opvulling te selecteren en stelt de kleur die door [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) wordt geretourneerd in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoerafbeelding in de werkmap voordat je dit voorbeeld uitvoert. Het laadt de afbeelding met [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Vervolgens kent het de afbeelding toe aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) stretcht de afbeelding zodat ze de cel vult, wat de beeldverhoudingen kan wijzigen. Kolombreedtes en rijhoogtes worden in punten opgegeven. De geladen afbeelding wordt in een `finally`‑blok vrijgegeven nadat hij aan de presentatie is toegevoegd.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/) en [right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) randen hebben aparte eigenschappen, zodat de dikte en stijl van elke kant kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een picture als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Bij stretchen past de afbeelding zich aan de nieuwe cel aan; bij tilen worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/php-java/manage-hyperlinks/) worden op tekst‑(portion)niveau binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm ingesteld. In de praktijk ken je de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel gebruiken?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak – lettertypefamilie, stijl, grootte en kleur.