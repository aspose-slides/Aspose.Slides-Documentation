---
title: Hantera presentationstabeller i PHP
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/php-java/manage-table/
keywords:
- lägga till tabell
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
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för PHP via Java. Upptäck enkla kodexempel för att effektivisera ditt tabell-arbetsflöde."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa och framställa information. Informationen i ett rutnät av celler (arrangerade i rader och kolumner) är enkel och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table), klassen [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/) och andra typer för att låta dig skapa, uppdatera och hantera tabeller i alla typer av presentationer.

## **Skapa en tabell från grunden**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en slides referens via dess index. 
3. Definiera en array av `columnWidth`.
4. Definiera en array av `rowHeight`.
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/)‑objekt på bilden genom metoden [addTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addtable/) .
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Slå samman de två första cellerna i tabellens första rad. 
8. Kom åt en [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) .
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) .
10. Spara den modifierade presentationen.

```php
  # Instansierar en Presentation-klass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Kommer åt den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Lägger till ett tabellobjekt på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in kantformat för varje cell
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Slår ihop cellerna 1 och 2 i rad 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Lägger till text i den sammanslagna cellen
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Sparar presentationen till disk
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numrering i en standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell indexeras som 0,0 (kolumn 0, rad 0). 

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Denna PHP‑kod visar hur du anger numreringen för celler i en tabell:

```php
  # Instansierar en Presentation-klass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Kommer åt den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Lägger till ett tabellobjekt på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in kantformat för varje cell
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Sparar presentationen till disk
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Åtkomst till en befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en referens till bilden som innehåller tabellen via dess index. 
3. Skapa ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt och sätt det till null.
4. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/)‑objekt tills tabellen hittas.

   Om du misstänker att bilden du arbetar med innehåller en enda tabell kan du helt enkelt kontrollera alla former den innehåller. När en form identifieras som en tabell kan du typkonvertera den till ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt. Men om bilden du arbetar med innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [setAlternativeText(String value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/setalternativetext/) .
5. Använd [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objektet för att arbeta med tabellen. I exemplet nedan lade vi till en ny rad i tabellen.
6. Spara den modifierade presentationen.

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Kommer åt den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Initierar null TableEx
    $tbl = null;
    # Itererar genom formerna och sätter en referens till den hittade tabellen
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Sätter texten för den första kolumnen i den andra raden
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Sparar den modifierade presentationen till disk
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Justera text i en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en slides referens via dess index. 
3. Lägg till ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt på bilden.
4. Kom åt ett [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/)‑objekt från tabellen.
5. Kom åt [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) .
6. Justera texten vertikalt.
7. Spara den modifierade presentationen.

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Lägger till tabellformen på bilden
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Kommer åt textramen
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Skapar Paragraph-objektet för textramen
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Skapar Portion-objektet för stycket
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Justerar texten vertikalt
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Sparar presentationen till disk
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange textformatering på tabellnivå**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en slides referens via dess index. 
3. Kom åt ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt från bilden.
4. Ställ in [setFontHeight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontHeight) för texten.
5. Ställ in [setAlignment(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Ställ in [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Spara den modifierade presentationen. 

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("simpletable.pptx");
  try {
    # Låt oss anta att den första formen på den första bilden är en tabell
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ställer in tabellcellernas fonthöjd
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Ställer in tabellcellernas textjustering och högermarginal i ett anrop
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Ställer in tabellcellernas vertikala texttyp
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hämta tabellstilsattribut**

Aspose.Slides låter dig hämta stilattribut för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna PHP‑kod visar hur du får stilattributen från en förinställd tabellstil:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ändra standardstilens förinställda tema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lås bildförhållandet för en tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess storlekar i olika dimensioner. Aspose.Slides tillhandahåller metoden [setAspectRatioLocked](https://reference.aspose.com/slides/sv/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) för att låta dig låsa bildförhållandet för tabeller och andra former.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen exponerar en [setRightToLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/setrighttoleft/)‑metod, och stycken har [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setrighttoleft/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd lås på former för att inaktivera flytt, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/) för en cell; bilden kommer att täcka cellens område enligt det valda läget (sträckning eller mosaik).