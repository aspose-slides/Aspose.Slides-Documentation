---
title: Gestire le tabelle delle presentazioni in PHP
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/php-java/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto d'aspetto
- allinea testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per PHP via Java. Scopri esempi di codice semplici per semplificare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono semplici e facili da comprendere.

Aspose.Slides fornisce la classe [Table], la classe [Cell] e altri tipi per consentirti di creare, aggiornare e gestire le tabelle in tutti i tipi di presentazioni.

## **Creare una tabella da zero**

1. Crea un'istanza della classe [Presentation].
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [Table] alla diapositiva tramite il metodo [addTable].
6. Itera attraverso ogni [Cell] per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella. 
8. Accedi al [TextFrame] di una [Cell].
9. Aggiungi del testo al [TextFrame].
10. Salva la presentazione modificata.

```php
  # Istanzia una classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce colonne con larghezze e righe con altezze
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Aggiunge una forma tabella alla diapositiva
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

In una tabella standard, la numerazione delle celle è semplice e a base zero. La prima cella di una tabella ha indice 0,0 (colonna 0, riga 0). 

Ad esempio, le celle in una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice PHP mostra come specificare la numerazione per le celle in una tabella:

```php
  # Istanzia una classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce colonne con larghezze e righe con altezze
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Aggiunge una forma tabella alla diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Imposta il formato del bordo per ogni cella
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
    # Salva la presentazione su disco
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accedere a una tabella esistente**

1. Crea un'istanza della classe [Presentation].

2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 

3. Crea un oggetto [Table] e impostalo a null.

4. Itera attraverso tutti gli oggetti [Shape] finché la tabella non viene trovata.

    Se sospetti che la diapositiva con cui stai lavorando contenga una sola tabella, puoi semplicemente controllare tutte le forme che contiene. Quando una forma viene identificata come una tabella, puoi effettuare il cast a un oggetto [Table]. Tuttavia, se la diapositiva contiene diverse tabelle, è meglio cercare la tabella di cui hai bisogno tramite il suo metodo [setAlternativeText(String value)].

5. Utilizza l'oggetto [Table] per lavorare con la tabella. Nell'esempio seguente, abbiamo aggiunto una nuova riga alla tabella.

6. Salva la presentazione modificata.

```php
  # Istanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inizializza TableEx a null
    $tbl = null;
    # Itera attraverso le forme e imposta un riferimento alla tabella trovata
    foreach($sld->getShapes() as $shp) {
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


## **Allineare il testo in una tabella**

1. Crea un'istanza della classe [Presentation].
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [Table] alla diapositiva.
4. Accedi a un oggetto [TextFrame] dalla tabella.
5. Accedi al [Paragraph].
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Ottiene la prima diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Definisce colonne con larghezze e righe con altezze
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Aggiunge la forma tabella alla diapositiva
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

1. Crea un'istanza della classe [Presentation].
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Accedi a un oggetto [Table] dalla diapositiva.
4. Imposta il metodo [setFontHeight(float value)] per il testo.
5. Imposta i metodi [setAlignment(int value)] e [setMarginRight(float value)].
6. Imposta il metodo [setTextVerticalType(byte value)].
7. Salva la presentazione modificata. 

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
    # Imposta l'allineamento del testo delle celle della tabella e il margine destro in un'unica chiamata
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

Aspose.Slides ti consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare questi dettagli per un'altra tabella o altrove. Questo codice PHP mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

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

Il rapporto d'aspetto di una forma geometrica è il rapporto delle sue dimensioni in diverse dimensioni. Aspose.Slides fornisce il metodo [setAspectRatioLocked] per consentirti di bloccare l'impostazione del rapporto d'aspetto per le tabelle e altre forme.

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

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone il metodo [setRightToLeft] e i paragrafi hanno [ParagraphFormat::setRightToLeft]. L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza i blocchi di forma per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**L'inserimento di un'immagine all'interno di una cella come sfondo è supportato?**

Sì. È possibile impostare un [picture fill] per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (stretch o tile).