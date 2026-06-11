---
title: Hantera tabellceller i presentationer med PHP
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/php-java/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Hantera enkelt tabellceller i PowerPoint med Aspose.Slides för PHP. Lär dig snabbt få åtkomst till, ändra och formatera celler för sömlös bildautomation."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller uppdelning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX-fil.

## **Identifiera en sammanslagen tabellcell**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta tabellen från den första bilden. 
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

Denna PHP‑kod visar hur du identifierar sammanslagna tabellceller i en presentation:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// antar att Slide#0.Shape#0 är en tabell

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort tabellcellramar**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addTable).
6. Iterera genom varje cell för att rensa de övre, nedre, högra och vänstra ramarna.
7. Spara den ändrade presentationen som en PPTX-fil.

Denna PHP‑kod visar hur du tar bort ramarna från tabellceller:

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Åtkommer den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Lägger till tabellform på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in ramformatet för varje cell
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Skriver PPTX-filen till disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numrering i sammanslagna celler**
Om vi slår ihop två cellpar (1, 1) × (2, 1) och (1, 2) × (2, 2) blir den resulterande tabellen numrerad. Denna PHP‑kod demonstrerar processen:

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Åtkommer den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Lägger till en tabellform på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in ramformatet för varje cell
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
    # Slår ihop celler (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Slår ihop celler (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Vi slår sedan ihop cellerna ytterligare genom att slå samman (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten: 

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Åtkommer den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Lägger till en tabellform på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in ramformatet för varje cell
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
    # Slår ihop celler (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Slår ihop celler (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Slår ihop celler (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Skriver PPTX-filen till disk
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numrering i en uppdelad cell**
I tidigare exempel, när tabellceller slog ihop, förändrades inte numreringen eller talssystemet i de andra cellerna. 

Denna gång tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1,1) för att få en speciell tabell. Du kan vilja uppmärksamma tabellens numrering, som kan uppfattas som märklig. Detta är dock så Microsoft PowerPoint numrerar tabellceller och Aspose.Slides gör samma sak. 

Denna PHP‑kod demonstrerar den process vi beskrev:

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Åtkommer den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Lägger till en tabellform på bilden
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ställer in ramformatet för varje cell
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
    # Slår ihop celler (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Slår ihop celler (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Delar cell (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Skriver PPTX-filen till disk
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra tabellcellens bakgrundsfärg**

Denna PHP‑kod visar hur du ändrar en cells bakgrundsfärg:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # skapa en ny tabell
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # ange bakgrundsfärgen för en cell
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Lägg till en bild i en tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden [AddTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addTable).
6. Skapa ett `Images`‑objekt för att hålla bildfilen.
7. Lägg till `IImage`‑bilden till `IPPImage`‑objektet.
8. Ställ in `FillFormat` för tabellcellen till `Picture`.
9. Lägg till bilden i tabellens första cell.
10. Spara den ändrade presentationen som en PPTX-fil

Denna PHP‑kod visar hur du placerar en bild i en tabellcell när du skapar en tabell:

```php
  # Instansierar Presentation-klassen som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Åtkommer den första bilden
    $islide = $pres->getSlides()->get_Item(0);
    # Definierar kolumner med bredder och rader med höjder
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Lägger till en tabellform på bilden
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Skapa ett IPPImage-objekt med bildfilen
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Lägger till bilden i den första tabellcellen
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Sparar PPTX-filen till disk
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cellformat/getborderright/) ramar har separata egenskaper, så tjockleken och stilen för varje sida kan variera. Detta följer logiskt från per-sida ramkontroll för en cell som demonstreras i artikeln.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillmode/) (stretch/tile). Vid stretch anpassas bilden till den nya cellen; vid tile beräknas rutorna om. Artikeln nämner bildvisningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/php-java/manage-hyperlinks/) sätts på textraden (portion) nivå inom cellens textram eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textram stöder [portions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) (körningar) med oberoende formatering—teckensnittsfamilj, stil, storlek och färg.