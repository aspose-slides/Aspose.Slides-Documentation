---
title: Beheer presentatietabellen in PHP
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/php-java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- toegang tot tabel
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint‑dia’s met Aspose.Slides voor PHP via Java. Ontdek eenvoudige code‑voorbeelden om je tabelwerkstromen te stroomlijnen."
---
## **Introductie**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het makkelijker is om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Tabel](https://reference.aspose.com/slides/php-java/aspose.slides/table/) klasse, [Cel](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) klasse en andere typen om tabellen in presentaties te maken, bij te werken en te beheren.

## **Een tabel van nul af maken**

Maak een tabel door de positie, kolombreedtes en rijhoogtes op te geven. Na toevoegen aan een dia kun je celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse.
2. Verkrijg een verwijzing naar de dia via de index.
3. Definieer een array met kolombreedtes in punten.
4. Definieer een array met rijhoogtes in punten.
5. Voeg een [Tabel](https://reference.aspose.com/slides/php-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) methode.
6. Itereer door elke [Cel](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker‑randen.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Toegang tot de samengevoegde cel via de [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) methode.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de gewijzigde presentatie op.

Het onderstaande voorbeeld maakt een tabel met drie kolommen en vijf rijen op (100, 50) punten. Het past rode randen toe met een breedte van 5 punten, voegt de eerste twee cellen in de eerste rij samen en slaat het resultaat op als `table.pptx`.

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

## **Nummering in een standaardtabel**

In een standaardtabel zijn cel‑indices nul‑gebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft de index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de bovenstaande 4 × 4‑tabel, met kolombreedtes en rijhoogtes van 70 punten en rode celranden met een breedte van 5 punten. De coördinaten illustreren cel‑indices; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

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

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormcollectie van een dia. Itereer door de vormen om een tabel te vinden, en gebruik vervolgens de [Tabel](https://reference.aspose.com/slides/php-java/aspose.slides/table/) klasse om de cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse.
2. Verkrijg een verwijzing naar de dia die de tabel bevat via de index.
3. Itereer door de [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) objecten en stop wanneer een tabel gevonden is. Bevat de dia meerdere tabellen, gebruik dan [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) om de gewenste tabel te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de gewijzigde presentatie op.

Het onderstaande voorbeeld opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel in kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet ten minste één kolom en twee rijen hebben.

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

Om een rij in een bestaande tabel te wijzigen en te begrijpen waarom de werkelijke hoogte de gevraagde minimumhoogte kan overschrijden, zie [Rijhoogte regelen](/slides/nl/php-java/manage-rows-and-columns/#control-row-height).

## **Vind de cel die een tekstframe bezit**

Wanneer algemene tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ontvangt van een tabel, gebruik dan de [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) methode om de eigenaar‑[Cel](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) op te halen. Voor een tabel‑cel tekstframe geeft [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) de eigenaar terug en geeft [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) `null` terug, zelfs hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) en [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) methoden. [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt het eigendom niet. Controleer altijd de geretourneerde cel met `java_is_null` voordat je deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel‑ en vorm‑eigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Zoeken en vervangen van tekst](/slides/nl/php-java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

Je kunt de verticale verankering en tekstoriëntatie van individuele tabelcellen besturen. Het voorbeeld in deze sectie centreert de tekst in de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse.
2. Verkrijg een verwijzing naar de dia via de index.
3. Voeg een [Tabel](https://reference.aspose.com/slides/php-java/aspose.slides/table/) object toe aan de dia.
4. Toegang tot een [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) object vanuit de tabel.
5. Toegang tot de eerste [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstoriëntatie van de cel in met behulp van [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) en [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een 4 × 4‑tabel met kolombreedtes van 120 punten en rijhoogtes van 100 punten. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de overige cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

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

## **Tekstopmaak instellen op tabelniveau**

Gebruik [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren gedeelte‑, alinea‑ en tekstframe‑opmaak, zodat je deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met behulp van de [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse.
2. Verkrijg een verwijzing naar de dia via de index.
3. Toegang tot een [Tabel](https://reference.aspose.com/slides/php-java/aspose.slides/table/) object vanuit de dia.
4. Stel de lettergrootte in met behulp van [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) voor de tekst.
5. Stel alinea‑uitlijning en de rechter marge in met [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Stel de tekstoriëntatie in met [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Sla de gewijzigde presentatie op.

Het onderstaande voorbeeld opent `table.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 punten, uitlijnt alinea's rechts met een rechter marge van 20 punten, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

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

## **Tabelstijl‑eigenschappen ophalen**

Gebruik [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) om de vooraf ingestelde stijl van een tabel te lezen en [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) toe op één tabel, toont de preset‑waarde en kent dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

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

## **Verhoudingsvergrendeling van een tabel**

De beeldverhouding van een tabel is de verhouding tussen de breedte en de hoogte. Gebruik [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) om deze verhouding voor een tabel te vergrendelen.

Het onderstaande voorbeeld opent `pres.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het toont de huidige vergrendelingsstatus, schakelt de verhoudingsvergrendeling in, toont de bijgewerkte status (`true`), en slaat het resultaat op als `pres-out.pptx`.

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

**Kan ik de leesrichting van rechts‑naar‑links (RTL) activeren voor een hele tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) methode, en alinea's hebben [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Het gebruiken van beide zorgt voor de juiste RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of van grootte wijzigen?**

Gebruik [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) om verplaatsen, van grootte wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt het celgebied volgens de gekozen modus (strekken of tegel).