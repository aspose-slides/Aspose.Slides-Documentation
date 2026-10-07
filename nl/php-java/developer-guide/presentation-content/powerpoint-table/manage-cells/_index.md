---
title: Beheer tabelcellen in presentaties met PHP
linktitle: Beheer cellen
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
description: "Beheer PowerPoint-tabelcellen in PHP: identificeer samengevoegde cellen, verwijder randen, splits cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummers na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding binnen een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) om cellen in samengevoegde gebieden te identificeren. Voor elke overeenkomst print het de celcoördinaten in de volgorde `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), en de begencoördinaten van het gebied, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) en [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). De kolombreedtes, rijhoogtes en de tabelpositie worden opgegeven in punten. Het voorbeeld stelt alle vier de celranden in op [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Specificeer de cellen op de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `false` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten, en voegt vervolgens de vier centrale cellen samen van `(1, 1)` tot en met `(2, 2)`. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik de linkerbovenpositie: `$table->get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

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

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van de cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten en roept [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) aan op cel `(1, 1)`. De helft van de 70‑punt breedte van de cel wordt doorgegeven om twee cellen van gelijke breedte te creëren.

Na deze splitsing worden de twee helften benaderd als `$table->get_Item(1, 1)` en `$table->get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen zich naar kolommen 3 en 4, respectievelijk. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensinvulling klaar te maken, gebruik [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) om te splitsen langs een bestaande rijgrens, of [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) om te splitsen langs een kolomgrens.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Rij‑splitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Kolom‑splitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Het voorbeeld gaat ervan uit dat een presentatie een tabel bevat als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Beginnend vanaf de lagere positie, gebruikt het [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) en [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) om de oorsprong te vinden en controleert beide spans. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale samenvoeging van twee kolommen, gebruik je `splitByColSpan(1)`.

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

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) geeft `false` terug. Grotere gebieden kunnen na één splitsing deels samengevoegd blijven.

De originele tekst en opmaak blijven in de boven‑ (of linker‑) cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen in en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke “Product A”‑ en “Product B”‑cellen waarbij de celopmaak van het sjabloon behouden blijft. Zie de [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) voor details.

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

## **De achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 punten en rijen van 50 punten. Het gebruikt [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) om een effen vulling te selecteren en stelt de kleur die wordt geretourneerd door [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

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

## **Een afbeelding toevoegen binnen een tabelcel**

Plaats de invoerafbeelding in de werkmap voordat u dit voorbeeld uitvoert. Het laadt de afbeelding met [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Vervolgens kent het de afbeelding toe aan de afbeeldingvulling van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes staan in punten. De geladen afbeelding wordt beëindigd in een `finally`‑blok nadat deze aan de presentatie is toegevoegd.

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende kanten van één cel?**

Ja. De [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke kant kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/php-java/manage-hyperlinks/) worden ingesteld op tekst‑ (portie‑)niveau binnen het tekstvak van de cel of op het niveau van de hele tabel/vorm. In de praktijk ken je de link toe aan een portie of aan alle tekst in de cel.

**Kan ik verschillende lettertypes binnen één cel instellen?**

Ja. Het tekstvak van een cel ondersteunt [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak – lettertypefamilie, stijl, grootte en kleur.