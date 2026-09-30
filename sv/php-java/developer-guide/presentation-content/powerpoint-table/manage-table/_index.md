---
title: Hantera presentationstabeller i PHP
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/php-java/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för PHP via Java. Upptäck enkla kodexempel för att förenkla ditt tabellarbetsflöde."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), klassen [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) och andra typer för att låta dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från grunden**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att ha lagt till den på en bild kan du formatera cellkanter, slå samman celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Definiera en array med kolumnbredder i punkter.
4. Definiera en array med radhöjder i punkter.
5. Lägg till ett [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Slå samman de två första cellerna i tabellens första rad.
8. Åtkomst till den sammanslagna cellen via dess [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/)-metod.
9. Ange texten i den sammanslagna cellen.
10. Spara den ändrade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader vid (100, 50) punkter. Det applicerar röda kanter med en bredd på 5 punkter, slår ihop de två första cellerna i första raden och sparar resultatet som `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på detta sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar den 4 × 4‑tabell som illustreras ovan, med kolumnbredder och radhöjder på 70 punkter samt röda cellkanter med en bredd på 5 punkter. Koordinaterna visar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds formsamling. Iterera genom formerna för att hitta en tabell och använd sedan klassen [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) för att läsa eller uppdatera dess celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen via dess index.
3. Iterera genom objekten av typen [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) för att identifiera den du behöver.
4. Uppdatera texten i målcell.
5. Spara den ändrade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det sätter cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Indatan måste innehålla minst en bild och den första tabellen på den bilden måste ha minst en kolumn och två rader.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga den begärda minimin, se [Kontroll av radhöjd](/slides/sv/php-java/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en textram**

När generisk textbearbetningskod får en [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) från en tabell, använd metoden [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) för att hämta den ägande [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). För en tabellcell‑textram returnerar [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) ägaren och [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) returnerar `null`, även om tabellen själv är en form.

Cellkoordinaterna är tillgängliga via de skrivskyddade metoderna [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) och [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) ger också skrivskyddad navigation: den returnerar ägaren men ändrar inte ägandeskapet. Kontrollera alltid den returnerade cellen med `java_is_null` innan du använder den.

För ett komplett exempel som identifierar tabellcell‑ och formägare, inklusive former kopplade till SmartArt‑noder, se [Sök och ersätt text](/slides/sv/php-java/search-and-replace-text/).

## **Justera text i en tabell**

Du kan kontrollera vertikal förankring och textriktning för enskilda tabellceller. Exemplet i detta avsnitt centrerar text i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Lägg till ett [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-objekt på bilden.
4. Åtkomst till ett [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)-objekt från tabellen.
5. Åtkomst till det första [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) och ange dess text och färg.
6. Ställ in cellens vertikala förankring och textriktning med [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) och [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Spara den ändrade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ange textformatering på tabellnivå**

Använd [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) för att applicera textformatering på alla celler i en tabell. Dess överlagringar accepterar format för portion, stycke och textram, så du kan ställa in dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Åtkomst till ett [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)-objekt från bilden.
4. Ställ in teckenstorleken med [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) för texten.
5. Ställ in styckejustering och högermarginal med [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Ställ in textriktningen med [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Spara den ändrade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som dess första form. Det ställer in teckenstorleken till 25 punkter, högerjusterar stycken med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hämta tabellstils‑egenskaper**

Använd [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) för att läsa en tabells förinställda stil och [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) för att tilldela den. Detta exempel applicerar [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) på en tabell, skriver ut det förinställda värdet och tilldelar samma förinställning till en andra tabell. Båda tabellerna sparas i `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lås bildförhållandet för en tabell**

En tabells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som dess första form. Det skriver ut det aktuella låstillståndet, aktiverar låsning av bildförhållandet, skriver ut det uppdaterade tillståndet (`true`) och sparar resultatet som `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kan jag aktivera höger‑till‑vänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen exponerar en [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/)-metod, och stycken har [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutliga filen?**

Använd [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) för att inaktivera flytt, storleksändring, val osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt det valda läget (stretch eller tile).