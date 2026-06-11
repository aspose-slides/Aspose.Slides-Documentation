---
title: Hantera rader och kolumner i PowerPoint-tabeller med PHP
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

För att låta dig hantera en tabells rader och kolumner i en PowerPoint-presentation, tillhandahåller Aspose.Slides klassen [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/) och många andra typer.

## **Ange den första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en bilds referens via dess index.  
3. Skapa ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt och sätt det till null.  
4. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/)‑objekt för att hitta den relevanta tabellen.  
5. Ange tabellens första rad som dess rubrik.  

```php
  # Instansierar Presentation-klassen
  $pres = new Presentation("table.pptx");
  try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Initierar den null TableEx
    $tbl = null;
    # Itererar genom formerna och sätter en referens till tabellen
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Sätter den första raden i tabellen som rubrik
        $tbl->setFirstRow(true);
      }
    }
    # Sparar presentationen till disk
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Klona en tabellrad eller -kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addtable/).  
6. Klona tabellraden.  
7. Klona tabellkolumnen.  
8. Spara den modifierade presentationen.  

```php
  # Instansierar Presentation-klassen
  $pres = new Presentation("Test.pptx");
  try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Lägger till en tabellform på bilden
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Lägger till text i rad 1 cell 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Lägger till text i rad 1 cell 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Klonar rad 1 i slutet av tabellen
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Lägger till text i rad 2 cell 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Lägger till text i rad 2 cell 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Klonar rad 2 som den 4:e raden i tabellen
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Klonar den första kolumnen i slutet
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Klonar den andra kolumnen vid index 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Sparar presentationen till disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addtable/).  
6. Ta bort tabellraden.  
7. Ta bort tabellkolumnen.  
8. Spara den modifierade presentationen.  

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange textformatering på radnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Kom åt det relevanta [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objektet från bilden.  
4. Ställ in den första radens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ställ in den första radens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Ställ in den andra radens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Spara den modifierade presentationen.  

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Anta att den första formen på den första bilden är en tabell
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ställer in den första radens cellers teckenhöjd
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Ställer in den första radens cellers textjustering och högermarginal
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ställer in den andra radens cellers vertikala texttyp
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Sparar presentationen till disk
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange textformatering på kolumnnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Kom åt det relevanta [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Table)‑objektet från bilden.  
4. Ställ in den första kolumnens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ställ in den första kolumnens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setalignment/) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Ställ in den andra kolumnens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Spara den modifierade presentationen.  

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Anta att den första formen på den första bilden är en tabell
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ställer in den första kolumnens cellers teckenhöjd
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Ställer in den första kolumnens cellers textjustering och högermarginal i ett anrop
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ställer in den andra kolumnens cellers vertikala texttyp
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Hämta tabellstilens egenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna PHP‑kod visar hur du hämtar stilegenskaperna från en förinställd tabellstil:

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

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en tabell som redan är skapad?**  
Ja. Tabellen ärver bild‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**  
Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först och fyll sedan på tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**  
Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokal formatering; formatering på cellnivå har företräde framför tabellstilen.