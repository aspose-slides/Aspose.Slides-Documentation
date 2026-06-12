---
title: Gestire gli oggetti Ink della presentazione in Java
linktitle: Gestisci Ink
type: docs
weight: 95
url: /it/java/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci gli oggetti ink di PowerPoint — crea, modifica e stila inchiostro digitale con Aspose.Slides per Java. Ottieni esempi di codice per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint fornisce la funzione penna per consentirti di disegnare figure non standard, che possono essere utilizzate per evidenziare altri oggetti, mostrare connessioni e processi, e attirare l'attenzione su elementi specifici in una diapositiva. 

Aspose.Slides fornisce tutti i tipi Ink (ad esempio la classe [Ink](https://reference.aspose.com/slides/it/java/com.aspose.slides/ink/)) di cui hai bisogno per creare e gestire oggetti penna. 

## **Differenze tra oggetti normali e oggetti Ink**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Un oggetto forma, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme alle sue proprietà. Quest'ultimo include le dimensioni dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint tratta un oggetto Ink, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) tranne le sue dimensioni. Le dimensioni dell'area del contenitore sono determinate dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di Inkshape**

Una traccia è un elemento di base o uno standard utilizzato per registrare la traiettoria di una penna mentre l'utente scrive inky digitale. Le tracce sono registrazioni che descrivono sequenze di punti collegati. 

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Puoi usare un pennello per disegnare linee che collegano i punti degli elementi della traccia. Il pennello ha il proprio colore e dimensione, corrispondenti alle proprietà `Brush.Color` e `Brush.Size`. 

### **Imposta il colore del pennello Ink**

Questo codice Java mostra come impostare il colore per un pennello:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Imposta la dimensione del pennello Ink** 

Questo codice Java mostra come impostare la dimensione per un pennello:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dei dati è grigio). Ma quando la larghezza e l'altezza del pennello corrispondono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto Ink e rivediamo le dimensioni importanti: 

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non considera la dimensione dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l'ultima immagine). 

Pertanto, per determinare l'area visibile dell'intero oggetto Ink, dobbiamo considerare la dimensione del pennello degli oggetti traccia. Qui, l'oggetto di destinazione (l'oggetto traccia del testo scritto a mano) è stato scalato alle dimensioni del contenitore (riquadro). Quando le dimensioni del contenitore (riquadro) cambiano, la dimensione del pennello rimane costante e viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando tratta i testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori approfondimenti**

* Per leggere informazioni sulle forme in generale, consultare la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/java/powerpoint-shapes/). 
* Per ulteriori informazioni sui valori effettivi, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/java/shape-effective-properties/#getting-effective-font-height-value).