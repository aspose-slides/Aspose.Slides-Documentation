---
title: Gestire righe e colonne nelle tabelle PowerPoint usando PHP
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/php-java/manage-rows-and-columns/
keywords:
- riga della tabella
- colonna della tabella
- prima riga
- intestazione della tabella
- clona riga
- clona colonna
- copia riga
- copia colonna
- rimuovi riga
- rimuovi colonna
- formattazione testo riga
- formattazione testo colonna
- stile della tabella
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le righe e le colonne delle tabelle in PowerPoint con Aspose.Slides per PHP via Java e velocizza la modifica delle presentazioni e gli aggiornamenti dei dati."
---
## **Introduzione**

Per consentirti di gestire le righe e le colonne di una tabella in una presentazione PowerPoint, Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/table/) e molti altri tipi.

## **Imposta la Prima Riga come Intestazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione.  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Crea un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) e impostalo a null.  
4. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) per trovare la tabella pertinente.  
5. Imposta la prima riga della tabella come intestazione.  

Questo codice PHP mostra come impostare la prima riga di una tabella come intestazione:

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inizializza la TableEx a null
    $tbl = null;
    # Itera attraverso le forme e imposta un riferimento alla tabella
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Imposta la prima riga di una tabella come intestazione
        $tbl->setFirstRow(true);
      }
    }
    # Salva la presentazione su disco
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Clona una Riga o una Colonna di Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Definisci un array di `columnWidth`.  
4. Definisci un array di `rowHeight`.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addtable/).  
6. Clona la riga della tabella.  
7. Clona la colonna della tabella.  
8. Salva la presentazione modificata.  

Questo codice PHP mostra come clonare una riga o una colonna di una tabella PowerPoint:

```php
  # Istanzia la classe Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce colonne con larghezze e righe con altezze
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Aggiunge una forma tabella alla diapositiva
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Aggiunge del testo alla cella riga 1 colonna 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Aggiunge del testo alla cella riga 1 colonna 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Clona la riga 1 alla fine della tabella
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Aggiunge del testo alla cella riga 2 colonna 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Aggiunge del testo alla cella riga 2 colonna 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Clona la riga 2 come quarta riga della tabella
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clona la prima colonna alla fine
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clona la seconda colonna all'indice della quarta colonna
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Salva la presentazione su disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rimuovi una Riga o una Colonna da una Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Definisci un array di `columnWidth`.  
4. Definisci un array di `rowHeight`.  
5. Aggiungi un oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addtable/).  
6. Rimuovi la riga della tabella.  
7. Rimuovi la colonna della tabella.  
8. Salva la presentazione modificata.  

Questo codice PHP mostra come rimuovere una riga o una colonna da una tabella:

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

## **Imposta la Formattazione del Testo a Livello di Riga della Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) pertinente dalla diapositiva.  
4. Imposta le celle della prima riga con [setFontHeight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Imposta le celle della prima riga con [setAlignment(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Imposta le celle della seconda riga con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Salva la presentazione modificata.  

Questo codice PHP dimostra l'operazione.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Supponiamo che la prima forma nella prima diapositiva sia una tabella
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Imposta l'altezza del font delle celle della prima riga
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Imposta l'allineamento del testo e il margine destro delle celle della prima riga
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Imposta il tipo verticale del testo delle celle della seconda riga
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Salva la presentazione su disco
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Imposta la Formattazione del Testo a Livello di Colonna della Tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e carica la presentazione,  
2. Ottieni un riferimento alla diapositiva tramite il suo indice.  
3. Accedi all'oggetto [Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/Table) pertinente dalla diapositiva.  
4. Imposta le celle della prima colonna con [setFontHeight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Imposta le celle della prima colonna con [setAlignment(int value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setalignment/) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Imposta le celle della seconda colonna con [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Salva la presentazione modificata.  

Questo codice PHP dimostra l'operazione:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation();
  try {
    # Supponiamo che la prima forma nella prima diapositiva sia una tabella
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Imposta l'altezza del font delle celle della prima colonna
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Imposta l'allineamento del testo e il margine destro delle celle della prima colonna in una chiamata
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Imposta il tipo verticale del testo delle celle della seconda colonna
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

## **Ottieni le Proprietà di Stile della Tabella**

Aspose.Slides ti consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare questi dettagli per un'altra tabella o altrove. Questo codice PHP mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambia il tema predefinito dello stile preimpostato

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso applicare temi/stili PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle di Aspose.Slides non dispongono di ordinamento o filtri integrati. Ordina i dati in memoria prima, quindi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a strisce) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, quindi sovrascrivi le celle specifiche con una formattazione locale; la formattazione a livello di cella ha la precedenza sullo stile della tabella.