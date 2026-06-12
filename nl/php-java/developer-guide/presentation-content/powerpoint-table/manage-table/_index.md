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
- tekst opmaak
- tabelstijl
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint‑dia's met Aspose.Slides voor PHP via Java. Ontdek eenvoudige code‑voorbeelden om uw tabel‑werkstromen te stroomlijnen."
---
## **Introductie**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (georganiseerd in rijen en kolommen) is eenvoudig en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) klasse, [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) klasse en andere types waarmee u tabellen kunt maken, bijwerken en beheren in allerlei presentaties.

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addtable/) methode.  
6. Itereer door elke [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechts- en linkerranden.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van een [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/).  
9. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Deze PHP‑code toont hoe u een tabel in een presentatie maakt:

```php
  # Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Voegt een tabelvorm toe aan de dia
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Stelt het randformaat in voor elke cel
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
    # Voegt cellen 1 & 2 van rij 1 samen
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Voegt wat tekst toe aan de samengevoegde cel
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Slaat de presentatie op naar schijf
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft index 0,0 (kolom 0, rij 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze PHP‑code toont hoe u de nummering voor cellen in een tabel specificeert:

```php
  # Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Benadert eerste dia
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
    # Slaat de presentatie op naar schijf
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar de dia die de tabel bevat op via de index.  
3. Maak een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object aan en zet het op null.  
4. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) objecten totdat de tabel gevonden is.  

   Als u vermoedt dat de dia waar u mee werkt één tabel bevat, kunt u eenvoudig alle vormen die het bevat controleren. Wanneer een vorm wordt herkend als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object. Maar als de dia waar u mee werkt meerdere tabellen bevat, zoekt u beter naar de gewenste tabel via de [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/setalternativetext/).  

5. Gebruik het [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object om met de tabel te werken. In het onderstaande voorbeeld hebben we een nieuwe rij aan de tabel toegevoegd.  
6. Sla de gewijzigde presentatie op.

Deze PHP‑code toont hoe u toegang krijgt tot en werkt met een bestaande tabel:

```php
  # Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Initialiseert null TableEx
    $tbl = null;
    # Itereert door de shapes en zet een referentie naar de gevonden tabel
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Zet de tekst voor de eerste kolom van de tweede rij
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Slaat de gewijzigde presentatie op naar schijf
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Voeg een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object toe aan de dia.  
4. Toegang tot een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) object van de tabel.  
5. Toegang tot de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

Deze PHP‑code toont hoe u de tekst in een tabel uitlijnt:

```php
  # Creëert een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Voegt de tabelvorm toe aan de dia
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Benadert het tekstframe
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Creëert het Paragraph-object voor het tekstframe
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Creëert het Portion-object voor de alinea
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Lijnt de tekst verticaal uit
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Slaat de presentatie op naar schijf
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tekstopmaak instellen op tabliveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar de dia op via de index.  
3. Toegang tot een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object van de Dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight) in voor de tekst.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginright/) in.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/settextverticaltype/) in.  
7. Sla de gewijzigde presentatie op.

Deze PHP‑code toont hoe u uw gewenste opmaakopties toepast op de tekst in een tabel:

```php
  # Creëert een instantie van de Presentation-klasse
  $pres = new Presentation("simpletable.pptx");
  try {
    # Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Stelt de letterhoogte van de tabelcellen in
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Stelt de tekstuitlijning en de rechtermarge van de tabelcellen in in één oproep
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Stelt het verticale type van de tekst in de tabelcellen in
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

## **Tabelstijleigenschappen ophalen**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen zodat u die details kunt gebruiken voor een andere tabel of elders. Deze PHP‑code toont hoe u de stijleigenschappen van een vooringestelde tabelstijl krijgt:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// wijzig het standaard stijlpreset-thema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aspectratio van een tabel vergrendelen**

De beeldverhouding van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) methode om de instelling voor de beeldverhouding van tabellen en andere vormen te vergrendelen.

Deze PHP‑code toont hoe u de beeldverhouding van een tabel vergrendelt:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// omkeren

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik de leesrichting van rechts‑naar‑links (RTL) voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/setrighttoleft/) methode, en alinea's hebben [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setrighttoleft/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen de cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel kunnen verplaatsen of van formaat wijzigen in het uiteindelijke bestand?**

Gebruik vormvergrendelingen om verplaatsen, van formaat wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt het celgebied volgens de gekozen modus (strekken of tegelen).