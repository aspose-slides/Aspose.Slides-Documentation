---
title: Gestire gli oggetti inchiostro nelle presentazioni con Python
linktitle: Gestisci inchiostro
type: docs
weight: 95
url: /it/python-net/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci gli oggetti inchiostro di PowerPoint—crea, modifica e stilizza l'inchiostro digitale con Aspose.Slides per Python via .NET. Ottieni esempi di codice per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint fornisce la funzione penna per permetterti di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici in una diapositiva.  

Aspose.Slides fornisce lo spazio dei nomi [aspose.slides.ink](https://reference.aspose.com/slides/it/python-net/aspose.slides.ink/) che contiene i tipi necessari per creare e gestire gli oggetti penna.  

## **Differenze tra Oggetto Regolare e Oggetti Penna**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Un oggetto forma, nella sua forma più semplice, è un contenitore che definisce l’area dell’oggetto stesso (il suo riquadro) insieme alle sue proprietà. Quest’ultimo include le dimensioni dell’area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per ulteriori informazioni, vedi [Formato Layout Forma](https://docs.aspose.com/slides/it/python-net/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint tratta un oggetto penna, ignora tutte le proprietà del riquadro dell’oggetto (contenitore) tranne la sua dimensione. La dimensione dell’area del contenitore è determinata dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce Inkshape**

Una traccia è un elemento di base o uno standard usato per registrare la traiettoria di una penna mentre un utente scrive in digitale. Le tracce sono registrazioni che descrivono sequenze di punti collegati.  

La forma più semplice di codifica specifica le coordinate X e Y di ciascun punto di campionamento. Quando tutti i punti collegati vengono renderizzati, producono un’immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## Proprietà del Pennello per il Disegno

Puoi usare un pennello per disegnare linee che collegano i punti degli elementi traccia. Il pennello ha il proprio colore e la propria dimensione, corrispondenti alle proprietà `Brush.color` e `Brush.size`.  

### **Imposta il Colore del Pennello Ink**

Questo codice Python mostra come impostare il colore per un pennello:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Imposta la Dimensione del Pennello Ink**

Questo codice Python mostra come impostare la dimensione per un pennello:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

In genere, la larghezza e l’altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati è grigio). Quando larghezza e altezza del pennello corrispondono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per Chiarezza, aumentiamo l’altezza dell’oggetto penna e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non considera la dimensione dei pennelli: assume sempre che lo spessore della linea sia zero (vedi l’immagine finale).  

Pertanto, per determinare l’area visibile dell’intero oggetto penna, dobbiamo considerare la dimensione del pennello degli oggetti traccia. Qui, l’oggetto target (l’oggetto traccia del testo scritto a mano) è stato scalato alle dimensioni del contenitore (riquadro). Quando le dimensioni del contenitore (riquadro) cambiano, la dimensione del pennello rimane costante e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Approfondimenti**

* Per informazioni generali sulle forme, consulta la sezione [Forme PowerPoint](https://docs.aspose.com/slides/it/python-net/powerpoint-shapes/).  
* Per ulteriori dettagli sui valori effettivi, vedi [Proprietà Effettive Forma](https://docs.aspose.com/slides/it/python-net/shape-effective-properties/#get-effective-font-height-value).