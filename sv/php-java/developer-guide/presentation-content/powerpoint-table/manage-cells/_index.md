---
title: Hantera tabellceller i presentationer med PHP
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/php-java/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i PHP: identifiera sammanslagna celler, ta bort ramar, dela celler och sätt bakgrundsfärger samt bilder med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides gör att du kan komma åt och ändra tabellceller i PowerPoint‑presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cell‑egenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(kolumn, rad)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itereras alla rader och kolumner och [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) används för att identifiera celler i sammanslagna områden. För varje träff skrivs cellens koordinater i `rad;kolumn`‑ordning, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) och områdets startkoordinater, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) och [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Ta bort tabellcellramar**

Skapa en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellramar till [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), så de blir osynliga.

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

## **Slå ihop tabellceller**

Använd [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra respektive nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får omfatta celler utanför det angivna området; `false` håller sammanslagningen inom området.

Exemplet skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader och slår sedan ihop de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre‑vänstra position: `$table->get_Item(1, 1)` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

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

## **Dela tabellceller**

Sammanslagna celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan introducera en ny rutnätskolumn och ändra kolumnindex för celler till höger. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader och anropar [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) på cell `(1, 1)`. Halva cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter delningen nås de två halvorna som `$table->get_Item(1, 1)` och `$table->get_Item(2, 1)`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen låg i kolumnerna 2 och 3 flyttas till kolumnerna 3 respektive 4. Radräknare förblir oförändrade. Använd dessa uppdaterade kolumnindex när du får åtkomst till celler efter delningen.

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

### **Dela sammanslagna celler efter rad‑ eller kolumnspann**

För att förbereda sammanslagna mallceller för datafyllning, använd [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) för att dela längs en befintlig radgräns, eller [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Kolumndelning: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Utgående från den nedre positionen används [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) och [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) för att lokalisera ursprunget och kontrollerar båda spannen. `splitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell två‑kolumns‑sammanslagning, använd `splitByColSpan(1)` istället.

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

        // Hämta de resulterande cellerna från tabellen efter delning.
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

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda spännvidderna 1 och [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) returnerar `false`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering kvarstår i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering som fyllning, ramar och marginaler. Fyll i cellerna efter delning och sätt eventuell textformatering explicit.

Den sparade presentationen innehåller separata "Product A"‑ och "Product B"‑celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) för detaljer.

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det använder [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) för att välja en solid fyllning och sätter färgen som returneras av [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

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

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) och lägger till den i presentationens bildsamling med [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Därefter tilldelas bilden till bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) sträcker bilden så att den fyller cellen, vilket kan ändra dess bildförhållande. Kolumnbredder och radhöjder anges i punkter. Den laddade bilden avyttras i ett `finally`‑block efter att den lagts till i presentationen.

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

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enda cell?**

Ja. De [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn‑/radstorlek efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching anpassas bilden till den nya cellen; vid tiling räknas rutorna om.

**Kan jag tilldela en hyperlänk till hela cellens innehåll?**

[Hyperlinks](/slides/sv/php-java/manage-hyperlinks/) sätts på text‑ (portion)‑nivå inom cellens textram eller på hela tabell‑/form‑nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) med oberoende formatering – teckensnittsfamilj, stil, storlek och färg.