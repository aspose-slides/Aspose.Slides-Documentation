---
title: Gestire gli oggetti Ink della presentazione su Android
linktitle: Gestisci Ink
type: docs
weight: 95
url: /it/androidjava/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci gli oggetti Ink di PowerPoint—crea, modifica e stila l'inchiostro digitale con Aspose.Slides per Android. Ottieni esempi di codice Java per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint fornisce la funzione inchiostro per consentire di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici di una diapositiva. 

Aspose.Slides fornisce tutti i tipi Ink (ad es. [Inchiostro](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ink/) classe) di cui hai bisogno per creare e gestire oggetti inchiostro.

## **Differenze tra oggetti standard e oggetti inchiostro**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Un oggetto forma, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme alle sue proprietà. Quest'ultime includono le dimensioni dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per ulteriori informazioni, consulta [Formato layout forma](https://docs.aspose.com/slides/it/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto inchiostro, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) tranne le sue dimensioni. Le dimensioni dell'area del contenitore sono determinate dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Inkshape**

Una traccia è un elemento di base o uno standard usato per registrare la traiettoria di una penna mentre l'utente scrive in inchiostro digitale. Le tracce sono registrazioni che descrivono sequenze di punti connessi. 

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto di campionamento. Quando tutti i punti connessi vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Puoi usare un pennello per disegnare linee che collegano i punti degli elementi della traccia. Il pennello ha il proprio colore e dimensione, corrispondenti alle proprietà `Brush.Color` e `Brush.Size`.

### **Imposta il colore del pennello inchiostro**

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

### **Imposta la dimensione del pennello inchiostro** 

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

In generale, la larghezza e l'altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dei dati è grigia). Tuttavia, quando larghezza e altezza del pennello coincidono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto inchiostro e rivediamo le dimensioni importanti: 

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non considera la dimensione dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l'ultima immagine). 

Pertanto, per determinare l'area visibile dell'intero oggetto inchiostro, dobbiamo considerare la dimensione del pennello delle tracce. Qui, l'oggetto target (l'oggetto traccia del testo scritto a mano) è stato ridimensionato alla dimensione del contenitore (riquadro). Quando le dimensioni del contenitore (riquadro) cambiano, la dimensione del pennello rimane costante e viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce i testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori letture**

* Per informazioni generali sulle forme, consulta la sezione [Forme PowerPoint](https://docs.aspose.com/slides/it/androidjava/powerpoint-shapes/).
* Per ulteriori informazioni sui valori effettivi, consulta [Proprietà effettive della forma](https://docs.aspose.com/slides/it/androidjava/shape-effective-properties/#getting-effective-font-height-value).