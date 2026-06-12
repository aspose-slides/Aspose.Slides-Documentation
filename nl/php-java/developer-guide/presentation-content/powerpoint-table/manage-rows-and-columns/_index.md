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
- tabelkoptekst
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor PHP via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Om u in staat te stellen de rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/)‑klasse en vele andere types.

## **Stel de eerste rij in als koptekst**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad de presentatie.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table)‑object aan en zet deze op null.  
4. Itereer door alle [Vorm](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑objecten om de relevante tabel te vinden.  
5. Stel de eerste rij van de tabel in als zijn koptekst.  

Deze PHP‑code toont hoe u de eerste rij van een tabel als koptekst instelt:

```php
  # Instantieert de Presentation-klasse
  $pres = new Presentation("table.pptx");
  try {
    # Toegang tot de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Initialiseert de null TableEx
    $tbl = null;
    # Doorloopt de shapes en stelt een referentie naar de tabel in
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Stelt de eerste rij van een tabel in als header
        $tbl->setFirstRow(true);
      }
    }
    # Slaat de presentatie op naar schijf
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kloon een tabelrij of -kolom**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table)‑object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addtable/)‑methode.  
6. Kloon de tabelrij.  
7. Kloon de tabelkolom.  
8. Sla de gewijzigde presentatie op.  

Deze PHP‑code toont hoe u een rij of kolom van een PowerPoint‑tabel kloont:

```php
  # Instantieert de Presentation-klasse
  $pres = new Presentation("Test.pptx");
  try {
    # Toegang tot de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Definieert kolommen met breedtes en rijen met hoogtes
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Voegt een tabelvorm toe aan de dia
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Voegt tekst toe aan rij 1 cel 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Voegt tekst toe aan rij 1 cel 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Kloont rij 1 aan het einde van de tabel
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Voegt tekst toe aan rij 2 cel 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Voegt tekst toe aan rij 2 cel 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Kloont rij 2 als 4e rij van de tabel
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Kloont eerste kolom aan het einde
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Kloont 2e kolom op index 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Slaat de presentatie op naar schijf
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verwijder een rij of kolom uit een tabel**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table)‑object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addtable/)‑methode.  
6. Verwijder de tabelrij.  
7. Verwijder de tabelkolom.  
8. Sla de gewijzigde presentatie op.  

Deze PHP‑code toont hoe u een rij of kolom uit een tabel verwijdert:

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

## **Stel tekstopmaak in op rijniveau van de tabel**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Open toegang tot het relevante [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table)‑object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight) in voor de cellen in de eerste rij.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginright/) in voor de cellen van de eerste rij.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/settextverticaltype/) in voor de cellen van de tweede rij.  
7. Sla de gewijzigde presentatie op.  

Deze PHP‑code demonstreert de bewerking.

```php
  # Maakt een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Stelt de letterhoogte van de cellen in de eerste rij in
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Stelt de tekstuitlijning en rechter marge van de cellen in de eerste rij in
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Stelt het verticale tekstype van de cellen in de tweede rij in
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Slaat de presentatie op naar schijf
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel tekstopmaak in op kolomniveau van de tabel**

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Open toegang tot het relevante [Tabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Table)‑object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight) in voor de cellen van de eerste kolom.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setalignment/) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginright/) in voor de cellen van de eerste kolom.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/settextverticaltype/) in voor de cellen van de tweede kolom.  
7. Sla de gewijzigde presentatie op.  

Deze PHP‑code demonstreert de bewerking:

```php
  # Maakt een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Stelt de letterhoogte van de cellen in de eerste kolom in
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Stelt de tekstuitlijning en rechter marge van de cellen in de eerste kolom in met één oproep
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Stelt het verticale teksttype van de cellen in de tweede kolom in
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

## **Haal tabelstijleigenschappen op**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen, zodat u die details voor een andere tabel of elders kunt gebruiken. Deze PHP‑code laat zien hoe u de stijleigenschappen van een vooraf ingestelde tabelstyle kunt ophalen:

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

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een reeds gemaakte tabel?**

Ja. De tabel erft het thema van de dia/layout/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, tabellen van Aspose.Slides hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen opnieuw in in die volgorde.

**Kan ik afwisselend (gestreept) gekleurde kolommen hebben terwijl ik aangepaste kleuren voor specifieke cellen behoud?**

Ja. Schakel afwisselende kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.