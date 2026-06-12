---
title: Gestire gli oggetti Ink della presentazione in PHP
linktitle: Gestisci Ink
type: docs
weight: 95
url: /it/php-java/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci gli oggetti Ink di PowerPoint — crea, modifica e stile l'inchiostro digitale con Aspose.Slides per PHP via Java. Ottieni esempi di codice per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint offre la funzione di inchiostro per consentire di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici di una diapositiva. 

Aspose.Slides fornisce tutti i tipi di Ink (ad esempio la classe [Ink](https://reference.aspose.com/slides/it/php-java/aspose.slides/ink/)) di cui hai bisogno per creare e gestire oggetti inchiostro.

## **Differenze tra oggetti regolari e oggetti Ink**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti shape. Un oggetto shape, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo frame) insieme alle sue proprietà. Quest'ultimo comprende la dimensione dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per informazioni, vedi [Formato layout shape](https://docs.aspose.com/slides/it/php-java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto ink, ignora tutte le proprietà del frame dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Inkshape**

Una trace è un elemento di base o uno standard utilizzato per registrare la traiettoria di una penna mentre l'utente scrive inchiostro digitale. Le trace sono registrazioni che descrivono sequenze di punti connessi. 

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti connessi sono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Puoi usare un pennello per disegnare linee che collegano i punti degli elementi trace. Il pennello ha il proprio colore e dimensione, corrispondenti alle proprietà `Brush.Color` e `Brush.Size`. 

### **Impostare il colore del pennello Ink**

Questo codice PHP mostra come impostare il colore per un pennello:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Impostare la dimensione del pennello Ink** 

Questo codice PHP mostra come impostare la dimensione per un pennello:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati è grigiata). Ma quando la larghezza e l'altezza del pennello corrispondono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per maggiore chiarezza, aumentiamo l'altezza dell'oggetto ink e rivediamo le dimensioni importanti: 

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (frame) non considera la dimensione dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l'ultima immagine). 

Pertanto, per determinare l'area visibile dell'intero oggetto ink, dobbiamo considerare la dimensione del pennello degli oggetti trace. Qui, l'oggetto di destinazione (l'oggetto trace del testo scritto a mano) è stato scalato alla dimensione del contenitore (frame). Quando la dimensione del contenitore (frame) cambia, la dimensione del pennello rimane costante e viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori letture**

* Per informazioni generali sulle forme, vedi la sezione [Forme PowerPoint](https://docs.aspose.com/slides/it/php-java/powerpoint-shapes/).
* Per maggiori dettagli sui valori effettivi, vedi [Proprietà effettive shape](https://docs.aspose.com/slides/it/php-java/shape-effective-properties/#getting-effective-font-height-value).