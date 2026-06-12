---
title: Gestire gli oggetti Ink della presentazione in .NET
linktitle: Gestisci Ink
type: docs
weight: 95
url: /it/net/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci gli oggetti Ink di PowerPoint—crea, modifica e stila l'inchiostro digitale con Aspose.Slides per .NET. Ottieni esempi di codice per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint offre la funzione ink per consentire di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare connessioni e processi, e attirare l'attenzione su elementi specifici di una diapositiva.

Aspose.Slides fornisce l'interfaccia [Aspose.Slides.Ink](https://reference.aspose.com/slides/it/net/aspose.slides.ink/), che contiene i tipi necessari per creare e gestire oggetti ink.

## **Differenze tra Oggetti Regolari e Oggetti Ink**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti shape. Un oggetto shape, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo frame) insieme alle sue proprietà. Quest'ultima include la dimensione dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/net/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto ink, ignora tutte le proprietà del frame dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Inkshape**

Una traccia è un elemento di base o uno standard utilizzato per registrare la traiettoria di una penna mentre l'utente scrive in digitale. Le tracce sono registrazioni che descrivono sequenze di punti collegati.

La forma più semplice di codifica specifica le coordinate X e Y di ciascun punto di campionamento. Quando tutti i punti collegati sono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del Pennello per il Disegno**

È possibile utilizzare un pennello per disegnare linee che collegano i punti degli elementi di traccia. Il pennello ha il proprio colore e dimensione, corrispondenti alle proprietà `Brush.Color` e `Brush.Size`.

### **Impostare il Colore del Pennello Ink**

Questo codice C# mostra come impostare il colore per un pennello:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Impostare la Dimensione del Pennello Ink**

Questo codice C# mostra come impostare la dimensione per un pennello:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati è grigia). Quando invece la larghezza e l'altezza del pennello coincidono, PowerPoint mostra la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto ink e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (frame) non considera la dimensione dei pennelli—presume sempre che lo spessore della linea sia zero (vedi l'ultima immagine).

Pertanto, per determinare l'area visibile dell'intero oggetto ink, dobbiamo considerare la dimensione del pennello delle tracce. Qui, l'oggetto target (la traccia del testo scritto a mano) è stato scalato alla dimensione del contenitore (frame). Quando la dimensione del contenitore (frame) cambia, la dimensione del pennello rimane costante e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce i testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori letture**

* Per informazioni generali sulle forme, consultare la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/net/powerpoint-shapes/). 
* Per ulteriori dettagli sui valori efficaci, vedere [Shape Effective Properties](https://docs.aspose.com/slides/it/net/shape-effective-properties/#get-effective-font-height-value).