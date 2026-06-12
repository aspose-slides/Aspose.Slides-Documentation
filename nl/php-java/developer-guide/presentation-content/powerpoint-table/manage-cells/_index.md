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
description: "Beheer tabelcellen in PowerPoint moeiteloos met Aspose.Slides voor PHP. Beheers het snel benaderen, wijzigen en opmaken van cellen voor naadloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding kunt toevoegen binnen een tabelcel. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Identificeer een samengevoegde tabelcel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal de tabel op van de eerste dia.  
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.  
4. Geef een bericht weer wanneer samengevoegde cellen zijn gevonden.

Deze PHP‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// ervan uitgaande dat Slide#0.Shape#0 een tabel is

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

## **Tabelcelranden verwijderen**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via zijn index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addTable)‑methode.  
6. Itereer door elke cel om de boven-, onder-, rechter- en linkergrens te wissen.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze PHP‑code laat zien hoe u de randen van tabelcellen kunt verwijderen:

```php
  # Maakt een Presentation‑klasse‑instantie die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Toegang tot de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Stelt het randformaat in voor elke cel
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Schrijft het PPTX‑bestand naar de schijf
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nummering in samengevoegde cellen**
Als we 2 paren cellen samenvoegen (1, 1) x (2, 1) en (1, 2) x (2, 2), zal de resulterende tabel genummerd zijn. Deze PHP‑code demonstreert het proces:

```php
  # Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Stelt het randformaat in voor elke cel
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
    # Voegt cellen (1, 1) x (2, 1) samen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Voegt cellen (1, 2) x (2, 2) samen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```php
  # Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Stelt het randformaat in voor elke cel
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
    # Voegt cellen (1, 1) x (2, 1) samen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Voegt cellen (1, 2) x (2, 2) samen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Voegt cellen (1, 1) x (1, 2) samen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Schrijft het PPTX‑bestand naar de schijf
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nummering in een gesplitste cel**
In eerdere voorbeelden, toen tabelcellen werden samengevoegd, veranderde het nummeringssysteem in de andere cellen niet.

Dit keer nemen we een reguliere tabel (een tabel zonder samengevoegde cellen) en proberen we cel (1,1) te splitsen om een bijzondere tabel te krijgen. Let op de nummering van deze tabel, die wellicht vreemd lijkt. Dit is echter de manier waarop Microsoft PowerPoint tabelcellen nummeriseert en Aspose.Slides doet hetzelfde.

Deze PHP‑code demonstreert het beschreven proces:

```php
  # Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Stelt het randformaat in voor elke cel
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
    # Voegt cellen (1, 1) x (2, 1) samen
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Voegt cellen (1, 2) x (2, 2) samen
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Splitst cel (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Schrijft het PPTX‑bestand naar de schijf
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Achtergrondkleur van de tabelcel wijzigen**

Deze PHP‑code laat zien hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # maak een nieuwe tabel
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # stel de achtergrondkleur in voor een cel
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

## **Afbeelding toevoegen binnen een tabelcel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via zijn index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addTable)‑methode.  
6. Maak een `Images`‑object aan om het afbeeldingsbestand te bewaren.  
7. Voeg de `IImage`‑afbeelding toe aan het `IPPImage`‑object.  
8. Stel het `FillFormat` voor de tabelcel in op `Picture`.  
9. Voeg de afbeelding toe aan de eerste cel van de tabel.  
10. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze PHP‑code laat zien hoe u een afbeelding binnen een tabelcel kunt plaatsen bij het creëren van een tabel:

```php
  # Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert de eerste dia
    $islide = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Maak een IPPImage-object aan met behulp van het afbeeldingsbestand
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Voegt de afbeelding toe aan de eerste tabelcel
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Slaat het PPTX-bestand op naar de schijf
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [boven](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellformat/getbordertop/)/[onder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellformat/getborderbottom/)/[links](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellformat/getborderleft/)/[rechts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cellformat/getborderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen. Dit volgt logisch uit de per‑zijde randcontrole voor een cel die in het artikel wordt gedemonstreerd.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [vullingsmodus](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillmode/) (stretch/tile). Bij uitrekken past de afbeelding zich aan de nieuwe cel aan; bij tegelherhaling worden de tegels opnieuw berekend. Het artikel vermeldt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/php-java/manage-hyperlinks/) worden ingesteld op het tekst‑ (deel)niveau binnen het tekstframe van de cel of op het niveau van de gehele tabel/vorm. In de praktijk wijst u de link toe aan een deel of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [porties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.