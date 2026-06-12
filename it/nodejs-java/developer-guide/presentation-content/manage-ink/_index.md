---
title: Gestire gli oggetti Ink della presentazione in JavaScript
linktitle: Gestire Ink
type: docs
weight: 95
url: /it/nodejs-java/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci gli oggetti ink di PowerPoint—crea, modifica e stila inchiostro digitale con Aspose.Slides per Node.js. Ottieni esempi di codice JavaScript per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint fornisce la funzione ink per consentire di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare collegamenti e processi, e attirare l'attenzione su elementi specifici in una diapositiva. 

Aspose.Slides fornisce tutti i tipi Ink (ad es. [Ink](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ink/) class) di cui hai bisogno per creare e gestire oggetti ink.

## **Differenze tra Oggetti Regolari e Oggetti Ink**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Un oggetto forma, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo frame) assieme alle sue proprietà. Quest'ultimo include la dimensione dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per informazioni, vedi [Shape Layout Format](https://docs.aspose.com/slides/it/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto ink, ignora tutte le proprietà del frame dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Inkshape**

Una traccia è un elemento di base o uno standard utilizzato per registrare la traiettoria di una penna mentre l'utente scrive in ink digitale. Le tracce sono registrazioni che descrivono sequenze di punti collegati. 

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del Pennello per il Disegno**

Puoi usare un pennello per disegnare linee che collegano i punti degli elementi traccia. Il pennello ha il proprio colore e dimensione, corrispondenti ai metodi `Brush.setColor` e `Brush.setSize`. 

### **Imposta il Colore del Pennello Ink**

Questo codice JavaScript mostra come impostare il colore per un pennello:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Imposta la Dimensione del Pennello Ink**

Questo codice JavaScript mostra come impostare la dimensione per un pennello:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

In genere, la larghezza e l'altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati è grigia). Ma quando larghezza e altezza del pennello coincidono, PowerPoint mostra la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto ink e rivediamo le dimensioni importanti: 

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (frame) non considera la dimensione dei pennelli—assume sempre che lo spessore della linea sia zero (vedi l'ultima immagine). 

Pertanto, per determinare l'area visibile dell'intero oggetto ink, dobbiamo considerare la dimensione del pennello degli oggetti traccia. Qui, l'oggetto target (l'oggetto traccia del testo scritto a mano) è stato scalato alla dimensione del contenitore (frame). Quando la dimensione del contenitore (frame) cambia, la dimensione del pennello rimane costante e viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce i testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori letture**

* Per leggere informazioni generali sulle forme, vedi la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/nodejs-java/powerpoint-shapes/).
* Per ulteriori informazioni sui valori effettivi, vedi [Shape Effective Properties](https://docs.aspose.com/slides/it/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).