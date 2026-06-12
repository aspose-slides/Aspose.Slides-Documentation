---
title: Gestisci le celle della tabella nelle presentazioni usando PHP
linktitle: Gestisci Celle
type: docs
weight: 30
url: /it/php-java/manage-cells/
keywords:
- cella della tabella
- unire celle
- rimuovere bordo
- dividere cella
- immagine nella cella
- colore di sfondo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci facilmente le celle delle tabelle in PowerPoint con Aspose.Slides per PHP. Impara ad accedere, modificare e stilizzare le celle rapidamente per un'automazione delle diapositive fluida."
---
## **Panoramica**

Aspose.Slides consente di accedere e modificare le celle delle tabelle nelle presentazioni PowerPoint. Questo articolo spiega come identificare le celle di tabella unite, rimuovere i bordi delle celle, gestire la numerazione delle celle dopo l’unione o la divisione, cambiare il colore di sfondo di una cella e aggiungere un’immagine all’interno di una cella di tabella. Gli esempi mostrano come creare o aprire una presentazione, ottenere una tabella da una diapositiva, aggiornare la formattazione delle celle tramite le proprietà della cella e salvare la presentazione modificata come file PPTX.

## **Identificare una cella di tabella unita**
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere la tabella dalla prima diapositiva. 
3. Scorrere le righe e le colonne della tabella per trovare le celle unite.
4. Stampare un messaggio quando vengono rilevate celle unite.

Questo codice PHP mostra come identificare le celle di tabella unite in una presentazione:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// supponendo che Slide#0.Shape#0 sia una tabella

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

## **Rimuovere i bordi delle celle della tabella**
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice. 
3. Definire un array di colonne con larghezza.
4. Definire un array di righe con altezza.
5. Aggiungere una tabella alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addTable).
6. Scorrere ogni cella per cancellare i bordi superiore, inferiore, destro e sinistro.
7. Salvare la presentazione modificata come file PPTX.

Questo codice PHP mostra come rimuovere i bordi dalle celle della tabella:

```php
  # Instanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Definisce le colonne con larghezze e le righe con altezze
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Aggiunge la forma della tabella alla diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Imposta il formato del bordo per ogni cella
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Scrive il PPTX su disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numerazione nelle celle unite**
Se uniamo 2 coppie di celle (1, 1) × (2, 1) e (1, 2) × (2, 2), la tabella risultante sarà numerata. Questo codice PHP dimostra il processo:

```php
  # Instanzia la classe Presentation che rappresenta un file PPTX
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
    # Unisce le celle (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Unisce le celle (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Successivamente uniamo ulteriormente le celle unendo (1, 1) e (1, 2). Il risultato è una tabella contenente una grande cella unita al centro:

```php
  # Instanzia la classe Presentation che rappresenta un file PPTX
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
    # Unisce le celle (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Unisce le celle (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Unisce le celle (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Scrive il file PPTX su disco
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numerazione in una cella divisa**
Negli esempi precedenti, quando le celle della tabella venivano unite, il sistema di numerazione delle altre celle non cambiava.  

Questa volta prendiamo una tabella regolare (una tabella senza celle unite) e proviamo a dividere la cella (1,1) per ottenere una tabella speciale. Prestate attenzione alla numerazione di questa tabella, che può apparire strana. Tuttavia, è così che Microsoft PowerPoint numerano le celle delle tabelle e Aspose.Slides fa lo stesso.

Questo codice PHP dimostra il processo descritto:

```php
  # Instanzia la classe Presentation che rappresenta un file PPTX
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
    # Unisce le celle (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Unisce le celle (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Divide la cella (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Scrive il file PPTX su disco
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiare il colore di sfondo della cella della tabella**

Questo codice PHP mostra come cambiare il colore di sfondo di una cella della tabella:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # crea una nuova tabella
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # imposta il colore di sfondo per una cella
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

## **Aggiungere un'immagine all'interno di una cella della tabella**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Definire un array di colonne con larghezza.
4. Definire un array di righe con altezza.
5. Aggiungere una tabella alla diapositiva tramite il metodo [AddTable](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addTable).
6. Creare un oggetto `Images` per contenere il file immagine.
7. Aggiungere l'immagine `IImage` all'oggetto `IPPImage`.
8. Impostare il `FillFormat` della cella della tabella su `Picture`.
9. Aggiungere l'immagine alla prima cella della tabella.
10. Salvare la presentazione modificata come file PPTX

Questo codice PHP mostra come inserire un'immagine all'interno di una cella della tabella durante la creazione della tabella:

```php
  # Instanzia la classe Presentation che rappresenta un file PPTX
  $pres = new Presentation();
  try {
    # Accede alla prima diapositiva
    $islide = $pres->getSlides()->get_Item(0);
    # Definisce le colonne con larghezze e le righe con altezze
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Aggiunge una forma di tabella alla diapositiva
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Crea un oggetto IPPImage usando il file immagine
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Aggiunge l'immagine alla prima cella della tabella
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Salva il file PPTX su disco
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso impostare spessori e stili di linea differenti per i vari lati di una singola cella?**

Sì. I bordi [top](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/it/php-java/aspose.slides/cellformat/getborderright/) hanno proprietà separate, quindi lo spessore e lo stile di ciascun lato possono differire. Questo deriva dal controllo dei bordi per lato illustrato nell’articolo.

**Cosa succede all'immagine se modifico la dimensione della colonna/riga dopo aver impostato un’immagine come sfondo della cella?**

Il comportamento dipende dalla [fill mode](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillmode/) (stretch/tile). Con lo stretch, l’immagine si adatta alla nuova cella; con il tile, le tessere vengono ricalcolate. L’articolo descrive le modalità di visualizzazione dell’immagine in una cella.

**Posso assegnare un collegamento ipertestuale all’intero contenuto di una cella?**

I [Hyperlinks](/slides/it/php-java/manage-hyperlinks/) vengono impostati a livello di porzione di testo all’interno del frame di testo della cella o a livello dell’intera tabella/forma. In pratica, si assegna il collegamento a una porzione o a tutto il testo nella cella.

**Posso impostare font diversi all’interno di una singola cella?**

Sì. Il frame di testo di una cella supporta le [portions](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) (run) con formattazione indipendente—famiglia, stile, dimensione e colore del font.