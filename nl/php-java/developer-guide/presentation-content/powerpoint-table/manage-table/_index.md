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
- aspectverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor PHP via Java. Ontdek eenvoudige code-voorbeelden om uw tabelworkflows te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is overzichtelijk en gemakkelijk te begrijpen.

Aspose.Slides levert de [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) klasse, de [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) klasse en andere types die u in staat stellen tabellen te maken, bij te werken en te beheren in allerlei presentaties.

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.
2. Haal een referentie naar een dia op via de index. 
3. Definieer een array van `columnWidth`.
4. Definieer een array van `rowHeight`.
5. Voeg een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addtable/) methode.
6. Iterate door elke [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechter- en linkerranden.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen. 
8. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van een [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/).
9. Voeg tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).
10. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u een tabel in een presentatie maakt:

```php
  # Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
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
    # Voegt cellen 1 en 2 van rij 1 samen
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

In een standaardtabel is de nummering van cellen eenvoudig en nul‑gebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze PHP‑code laat zien hoe u de nummering voor cellen in een tabel opgeeft:

```php
  # Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
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
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.

2. Haal een referentie naar de dia die de tabel bevat op via de index. 

3. Maak een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object aan en stel het in op null.

4. Iterate door alle [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) objecten totdat de tabel gevonden is.
   
   Als u vermoedt dat de dia waarmee u werkt slechts één tabel bevat, kunt u eenvoudig alle shapes die erin zitten controleren. Wanneer een shape wordt aangemerkt als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object. Maar als de dia meerdere tabellen bevat, zoekt u beter de gewenste tabel via de [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/setalternativetext/).

5. Gebruik het [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object om met de tabel te werken. In het onderstaande voorbeeld hebben we een nieuwe rij aan de tabel toegevoegd.

6. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u toegang krijgt tot en werkt met een bestaande tabel:

```php
  # Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Benadert de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Initialiseert een null‑TableEx
    $tbl = null;
    # Doorloopt de shapes en zet een referentie naar de gevonden tabel
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Stelt de tekst in voor de eerste kolom van de tweede rij
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

## **Vind de cel die een TextFrame bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van een tabel ontvangt, gebruik dan de [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) methode om de eigenaar‑[Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) op te halen. Voor een tekstkader van een tabelcel retourneert [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) de eigenaar en retourneert [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape) `null`, hoewel de tabel zelf een shape is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/#getFirstColumnIndex) en [Cell::getFirstRowIndex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/#getFirstRowIndex) methoden. [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt de eigendom niet. Controleer altijd de geretourneerde cel met `java_is_null` voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel‑ en shape‑eigenaren identificeert, inclusief shapes gekoppeld aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/php-java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.
2. Haal een referentie naar een dia op via de index. 
3. Voeg een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object toe aan de dia.
4. Toegang tot een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) object van de tabel.
5. Toegang tot de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/).
6. Lijn de tekst verticaal uit.
7. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u de tekst in een tabel uitlijnt:

```php
  # Maakt een instantie van de Presentation‑klasse
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
    # Benadert het tekstkader
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Creëert het Paragraph‑object voor het tekstkader
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Creëert het Portion‑object voor de alinea
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

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.
2. Haal een referentie naar een dia op via de index. 
3. Toegang tot een [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table) object vanaf de dia.
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight) in voor de tekst.
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setalignment/) en de [setMarginRight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginright/) in.
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/settextverticaltype/) in.
7. Sla de gewijzigde presentatie op. 

Deze PHP‑code laat zien hoe u uw gewenste opmaakopties op de tekst in een tabel toepast:

```php
  # Maakt een instantie van de Presentation‑klasse
  $pres = new Presentation("simpletable.pptx");
  try {
    # Laten we aannemen dat de eerste shape op de eerste dia een tabel is
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Stelt de letterhoogte van de tabelcellen in
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Stelt de tekstuitlijning en de rechter marge van de tabelcellen in één oproep in
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Stelt het verticale type van de tabelceltekst in
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

## **Tabel‑stijleigenschappen opvragen**

Aspose.Slides maakt het mogelijk om de stileigenschappen van een tabel op te halen, zodat u die details kunt gebruiken voor een andere tabel of elders. Deze PHP‑code laat zien hoe u de stileigenschappen van een vooraf ingesteld tabel‑style krijgt:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// wijzig het standaard stijl‑preset thema

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aspectverhouding van een tabel vergrendelen**

De aspectverhouding van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) methode om de instelling voor het vergrendelen van de aspectverhouding voor tabellen en andere shapes mogelijk te maken.

Deze PHP‑code laat zien hoe u de aspectverhouding voor een tabel vergrendelt:

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

**Kan ik de leesrichting van rechts naar links (RTL) inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/setrighttoleft/) methode, en alinea's hebben [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setrighttoleft/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen de cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte wijzigen?**

Gebruik shape‑vergrendelingen om verplaatsen, grootte wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen zijn ook van toepassing op tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of tegel).