---
title: Hantera rader och kolumner i PowerPoint‑tabeller med PHP
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/php-java/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första raden
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- textformatering för rad
- textformatering för kolumn
- tabellstil
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för PHP via Java och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

Aspose.Slides för PHP via Java låter dig hantera tabellstruktur och formatering i PowerPoint-presentationer via klassen [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner samt tillämpa textformatering på en hel rad eller kolumn.

Den här artikeln förklarar dessa operationer med PHP‑exempel. Den visar också hur du hämtar en tabells stilförinställning så att du kan återanvända den. Tabellrader och kolumnindex är nollbaserade.

## **Kontrollera radens höjd**

Använd [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) för att ange en rads minsta höjd i punkter. Det är en undre gräns, inte en fast höjd. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) returnerar den faktiska höjden. Få åtkomst till raden via [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar på 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts marginaler ovanför och nedanför; den längre texten i den andra kolumnen radbryts till flera rader. Exemplet ökar minimum till 100 punkter, sedan minskar det till 20 punkter, skriver ut den faktiska höjden efter varje förändring och sparar båda resultaten.

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

Med den medföljande presentationen lägger ökning av minimum till extra utrymme i raden. Minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna kräver mer plats. Att bara minska minimum kan inte tvinga raden under det utrymme som innehållet kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och typsnittsstorlek:** längre text, explicita radbrytningar eller ett större typsnitt kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan minskning av kolumnbredd med [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) producera fler rader. En bredare kolumn kan minska det vertikala utrymmet som behövs.
- **Cellmarginaler:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) och [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) lägger till vertikalt utrymme. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) och [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) minskar bredden som är tillgänglig för text och kan orsaka extra radbrytning.

För den här tabellen utan sammanslagna celler bestämmer den cell som behöver mest vertikalt utrymme den innehållsdrivna lägre gränsen för hela raden. För att göra raden kortare kan du även behöva förkorta texten, minska typsnittsstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I de illustrerade resultaten var de faktiska höjderna 70, 100 och 55,2 punkter: den sista raden förblev högre än sitt 20‑punkts minimum. Exakta textmått kan variera beroende på vilka typsnitt som finns i din miljö. Ladda ner de sparade resultaten: [increased minimum](row-height-increased.pptx) och [decreased minimum](row-height-decreased.pptx).

| Original: min 70 pt, faktisk 70 pt | Ökad: min 100 pt, faktisk 100 pt | Minskad: min 20 pt, faktisk 55,2 pt |
| --- | --- | --- |
| ![Originaltabell med en 70‑punkts första rad.](row-height-before.png) | ![Tabell efter att ha ökat den första radens minimum till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat den första radens minimum till 20 punkter; radbrytning håller raden högre än minimum.](row-height-decreased.png) |

## **Ange den första raden som rubrik**

Använd metoden [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Gå till den första bilden.
3. Hämta tabellen som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

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

## **Klona en tabellrad eller -kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Gå till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Klona de behövda raderna.
6. Klona de behövda kolumnerna.
7. Spara den modifierade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `false` inaktiverar kloning i intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

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

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort förskjuts indexen för de rader eller kolumner som följer det.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Gå till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den modifierade presentationen.

Detta exempel skapar en tre‑gång‑tre tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑gång‑två tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `false` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

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

## **Ange textformatering på radnivå i tabellen**

Tillämpa textformatering på en hel rad för att hålla cellerna enhetliga. Du kan ange teckensnittsegenskaper, styckeformatering och textorientering utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) för den första raden.
4. Använd [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) för den första raden.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) för den andra raden.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det applicerar 25‑punkts text, högermarginaljustering och en 20‑punkts högermarginal för stycket på den första raden, och sätter sedan vertikal text i den andra raden.

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

## **Ange textformatering på kolumnnivå i tabellen**

Tillämpa textformatering på en hel kolumn för att hålla cellerna enhetliga. Du kan ange teckensnittsegenskaper, styckeformatering och textorientering utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Hämta tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) för den första kolumnen.
4. Använd [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) för den första kolumnen.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) för den andra kolumnen.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det applicerar 25‑punkts text, högermarginaljustering och en 20‑punkts högermarginal för stycket på den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

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

## **Hämta tabellstilens egenskaper**

Använd metoden [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) för att hämta den förinställning som har tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än enskilda cellers formateringsöverskridanden.

Exemplet skapar en tabell, applicerar [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) och läser tillbaka förinställningen. Det skriver ut det heltalsvärde som motsvarar `DarkStyle1` och sparar tabellen i `table.pptx`.

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

**Kan jag applicera PowerPoint‑teman/stilar på en tabell som redan är skapad?**

Ja. Tabellen ärver slide/layout/master‑temat, och du kan fortfarande åsidosätta fyllningar, ramar och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först, och återpopulate sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller egna färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cell‑nivå‑formatering har företräde framför tabellstilen.