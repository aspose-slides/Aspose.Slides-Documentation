---
title: Beheer rijen en kolommen in PowerPoint-tabellen met PHP
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/php-java/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak voor rij
- tekstopmaak voor kolom
- tabelstijl
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor PHP via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Inleiding**

Aspose.Slides for PHP via Java laat u de tabelstructuur en opmaak in PowerPoint‑presentaties beheren via de [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) class. U kunt een koprij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een volledige rij of kolom.

Dit artikel legt deze bewerkingen uit met PHP‑voorbeelden. Het laat ook zien hoe u een stijl‑preset van een tabel kunt ophalen zodat u deze kunt hergebruiken. Rijen‑ en kolom‑indexen van een tabel beginnen bij nul.

## **Rijhoogte regelen**

Gebruik [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) geeft de werkelijke hoogte terug. Toegang tot de rij krijg je via [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), die een tabel bevat als de eerste shape op de eerste dia. De eerste rij begint op 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, met regelterugloop en marges van 6 punten boven‑ en onderaan; de langere tekst in de tweede kolom wordt over meerdere regels verdeeld. Het voorbeeld verhoogt de minimumwaarde naar 100 punten, verlaagt deze vervolgens naar 20 punten, print de werkelijke hoogte na elke wijziging, en slaat beide resultaten op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Met de meegeleverde presentatie voegt het verhogen van de minimumwaarde extra ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de werkelijke hoogte blijft groter dan 20 punten omdat de tekst en celmarges meer ruimte nodig hebben. Alleen de minimumwaarde verlagen kan de rij niet onder de door de inhoud vereiste ruimte dwingen.

Verschillende factoren beïnvloeden de werkelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kunnen meer verticale ruimte vereisen.
- **Regelterugloop en kolombreedte:** wanneer regelterugloop is ingeschakeld, kan het verkleinen van de kolombreedte met [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) meer regels opleveren. Een bredere kolom kan de benodigde verticale ruimte verminderen.
- **Celmarges:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) en [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) voegen verticale ruimte toe. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) en [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) verkleinen de beschikbare breedte voor tekst en kunnen extra regelterugloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de inhouds‑gedreven ondergrens voor de hele rij. Om de rij korter te maken, moet u mogelijk de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In de geïllustreerde resultaten waren de werkelijke hoogtes 70, 100 en 55.2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstafmetingen kunnen variëren afhankelijk van de lettertypen die in uw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijke 70 pt | Verhoogd: minimum 100 pt, werkelijke 100 pt | Verlaagd: minimum 20 pt, werkelijke 55.2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punten; ingepakte tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Eerste rij als koptekst instellen**

Gebruik de [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) methode om de eerste rij te markeren voor koptekst‑opmaak. Het uiterlijk hangt af van de op tafel toegepaste tabelstijl.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Toegang tot de tabel die is opgeslagen als de eerste shape op de dia.
4. Schakel de koptekst‑opmaak in voor de eerste rij.
5. Sla de gewijzigde presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een tabelrij of -kolom klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) methode.
5. Kloon de benodigde rijen.
6. Kloon de benodigde kolommen.
7. Sla de gewijzigde presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een rij of kolom uit een tabel verwijderen**

Verwijder rijen of kolommen die niet langer nodig zijn in een tabel. Het verwijderen van een item verschuift de indexen van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) methode.
5. Verwijder de tweede rij en de tweede kolom.
6. Sla de gewijzigde presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tekstopmaak op rijniveau van de tabel instellen**

Pas tekstopmaak toe op een volledige rij om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) voor de eerste rij.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) voor de eerste rij.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) voor de tweede rij.
6. Sla de gewijzigde presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tekstopmaak op kolomniveau van de tabel instellen**

Pas tekstopmaak toe op een volledige kolom om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) voor de eerste kolom.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) voor de eerste kolom.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) voor de tweede kolom.
6. Sla de gewijzigde presentatie op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tabelstijleigenschappen ophalen**

Gebruik de [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) methode om de op een tabel toegepaste preset op te halen en deze op een andere tabel te hergebruiken. Hiermee wordt de preset geïdentificeerd in plaats van individuele cel‑opmaakoverschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) toe, en leest de preset terug. Het print de gehele getalwaarde die overeenkomt met `DarkStyle1` en slaat de tabel op in `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kan ik PowerPoint‑thema's/stijlen toepassen op een reeds gemaakte tabel?**

Ja. De tabel erft het thema van de dia/lay-out/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik gestreepte (gebandde) kolommen hebben terwijl ik aangepaste kleuren behoud op specifieke cellen?**

Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.