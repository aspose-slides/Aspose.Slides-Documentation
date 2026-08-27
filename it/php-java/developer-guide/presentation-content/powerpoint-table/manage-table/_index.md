---
title: Gestire le tabelle delle presentazioni in PHP
linktitle: Gestire tabella
type: docs
weight: 10
url: /it/php-java/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi alla tabella
- rapporto d'aspetto
- allinea testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per PHP via Java. Scopri esempi di codice semplici per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficace per visualizzare e rappresentare le informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono chiare e facili da comprendere.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table), la classe [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/) e altri tipi per consentire di creare, aggiornare e gestire le tabelle in tutti i tipi di presentazioni.

## **Creare una tabella da zero**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice. 
3. Definire un array di `columnWidth`.
4. Definire un array di `rowHeight`.
5. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addtable/).
6. Iterare su ciascuna [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unire le prime due celle della prima riga della tabella. 
8. Accedere al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) di una [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/).
9. Aggiungere del testo al [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/).
10. Salvare la presentazione modificata.

Questo codice PHP mostra come creare una tabella in una presentazione:

```php
  # Istanzia una classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce le colonne con larghezze e le righe con altezze
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Aggiunge una forma di tabella alla diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Imposta il formato del bordo per ogni cella
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
    # Unisce le celle 1 e 2 della riga 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Aggiunge del testo alla cella unita
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Salva la presentazione su disco
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numerazione in una tabella standard**

In una tabella standard, la numerazione delle celle è semplice e parte da zero. La prima cella di una tabella ha indice 0,0 (colonna 0, riga 0). 

Ad esempio, le celle di una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice PHP mostra come specificare la numerazione per le celle di una tabella:

```php
  # Istanzia una classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce le colonne con larghezze e le righe con altezze
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Aggiunge una forma di tabella alla diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Imposta il formato del bordo per ogni cella
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
    # Salva la presentazione su disco
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedere a una tabella esistente**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).

2. Ottenere un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 

3. Creare un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) e impostarlo a null.

4. Iterare su tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) fino a trovare la tabella.

   Se si sospetta che la diapositiva contenga una sola tabella, è possibile controllare semplicemente tutte le forme che contiene. Quando una forma viene identificata come tabella, è possibile effettuare il cast a oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table). Se, invece, la diapositiva contiene più tabelle, è preferibile cercare la tabella necessaria tramite il suo [setAlternativeText(String value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/setalternativetext/).

5. Utilizzare l'oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) per lavorare con la tabella. Nell'esempio seguente, abbiamo aggiunto una nuova riga alla tabella.

6. Salvare la presentazione modificata.

Questo codice PHP mostra come accedere e lavorare con una tabella esistente:

```php
  # Istanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inizializza TableEx a null
    $tbl = null;
    # Itera attraverso le forme e imposta un riferimento alla tabella trovata
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Imposta il testo per la prima colonna della seconda riga
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Salva la presentazione modificata su disco
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Trovare la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) da una tabella, utilizzare il metodo [TextFrame::getParentCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentCell) per recuperare la [Cell](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/) proprietaria. Per un TextFrame di una cella della tabella, [TextFrame::getParentCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentCell) restituisce il proprietario e [TextFrame::getParentShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentShape) restituisce `null`, sebbene la tabella stessa sia una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell::getFirstRowIndex](https://reference.aspose.com/slides/it/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/#getParentCell) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne cambia la proprietà. Verificare sempre la cella restituita con `java_is_null` prima di utilizzarla.

Per un esempio completo che identifica i proprietari di cella della tabella e di forma, inclusi gli oggetti associati a nodi SmartArt, vedere [Search and Replace Text](/slides/it/php-java/search-and-replace-text/).

## **Allineare il testo in una tabella**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice. 
3. Aggiungere un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) alla diapositiva.
4. Accedere a un oggetto [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) dalla tabella.
5. Accedere al [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/).
6. Allineare il testo verticalmente.
7. Salvare la presentazione modificata.

Questo codice PHP mostra come allineare il testo in una tabella:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Definisce le colonne con larghezze e le righe con altezze
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Aggiunge la forma della tabella alla diapositiva
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Accede al TextFrame
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Crea l'oggetto Paragraph per il TextFrame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Crea l'oggetto Portion per il paragrafo
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Allinea il testo verticalmente
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Salva la presentazione su disco
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare la formattazione del testo a livello di tabella**

1. Creare un'istanza della [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) class.
2. Ottenere un riferimento a una diapositiva tramite il suo indice. 
3. Accedere a un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) dalla diapositiva.
4. Impostare il [setFontHeight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setFontHeight) per il testo.
5. Impostare il [setAlignment(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setalignment/) e il [setMarginRight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Impostare il [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Salvare la presentazione modificata. 

Questo codice PHP mostra come applicare le opzioni di formattazione preferite al testo di una tabella:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Supponiamo che la prima forma sulla prima diapositiva sia una tabella
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Imposta l'altezza del carattere delle celle della tabella
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Imposta l'allineamento del testo e il margine destro delle celle della tabella in una sola chiamata
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Imposta il tipo di orientamento verticale del testo delle celle della tabella
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

## **Ottenere le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poterle utilizzare per un'altra tabella o altrove. Questo codice PHP mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambia il tema predefinito del preset di stile

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bloccare il rapporto d'aspetto di una tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto delle sue dimensioni in diverse direzioni. Aspose.Slides fornisce il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme.

Questo codice PHP mostra come bloccare il rapporto d'aspetto per una tabella:

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

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e per il testo nelle sue celle?**

Sì. La tabella espone il metodo [setRightToLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/setrighttoleft/), e i paragrafi hanno [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setrighttoleft/). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizzare i blocchi di forma per disabilitare spostamento, ridimensionamento, selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportata l'inserzione di un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).