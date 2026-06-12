---
title: Gestisci oggetti inchiostro della presentazione in C++
linktitle: Gestisci Inchiostro
type: docs
weight: 95
url: /it/cpp/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci gli oggetti inchiostro di PowerPoint—crea, modifica e stile l'inchiostro digitale con Aspose.Slides per C++. Ottieni esempi di codice per tracce, colore e dimensione del pennello."
---
## **Introduzione**

PowerPoint fornisce la funzione inchiostro per consentire di disegnare figure non standard, che possono essere usate per evidenziare altri oggetti, mostrare connessioni e processi, e richiamare l'attenzione su elementi specifici in una diapositiva. 

Aspose.Slides fornisce l'interfaccia [Aspose.Slides.Ink](https://reference.aspose.com/slides/it/cpp/aspose.slides.ink/) che contiene i tipi necessari per creare e gestire gli oggetti inchiostro. 

## **Differenze tra oggetti normali e oggetti inchiostro**

Gli oggetti in una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Un oggetto forma, nella sua forma più semplice, è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme alle sue proprietà. Quest'ultimo comprende la dimensione dell'area del contenitore, la forma del contenitore, lo sfondo del contenitore, ecc. Per ulteriori informazioni, vedere [Shape Layout Format](https://docs.aspose.com/slides/it/cpp/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto inchiostro, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai valori standard `width` e `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di Inkshape**

Una traccia è un elemento base o uno standard usato per registrare la traiettoria di una penna mentre l'utente scrive in inchiostro digitale. Le tracce sono registrazioni che descrivono sequenze di punti collegati. 

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto campione. Quando tutti i punti collegati vengono renderizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

È possibile utilizzare un pennello per disegnare linee che collegano i punti degli elementi traccia. Il pennello ha il proprio colore e dimensione, corrispondenti alle proprietà `Brush.Color` e `Brush.Size`. 

### **Imposta il colore del pennello inchiostro**

Questo codice C++ mostra come impostare il colore per un pennello:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Imposta la dimensione del pennello inchiostro** 

Questo codice C++ mostra come impostare la dimensione per un pennello:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

In genere, la larghezza e l'altezza di un pennello non coincidono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dei dati è grigiastra). Ma quando la larghezza e l'altezza del pennello coincidono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto inchiostro e rivediamo le dimensioni importanti: 

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non considera la dimensione dei pennelli—presume sempre che lo spessore della linea sia zero (vedi l'ultima immagine). 

Pertanto, per determinare l'area visibile dell'intero oggetto inchiostro, dobbiamo considerare la dimensione del pennello delle tracce. Qui, l'oggetto target (la traccia di testo scritto a mano) è stato scalato alla dimensione del contenitore (riquadro). Quando la dimensione del contenitore (riquadro) cambia, la dimensione del pennello rimane costante e viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint mostra lo stesso comportamento quando gestisce i testi:

![ink_powerpoint6](ink_powerpoint6.png)

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](https://docs.aspose.com/slides/it/cpp/powerpoint-shapes/). 
* Per ulteriori dettagli sui valori effettivi, consultare [Shape Effective Properties](https://docs.aspose.com/slides/it/cpp/shape-effective-properties/#get-effective-font-height-value).