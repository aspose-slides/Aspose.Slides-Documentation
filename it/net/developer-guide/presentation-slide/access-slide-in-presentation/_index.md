---
title: Accedi alle diapositive della presentazione in .NET
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/net/access-slide-in-presentation/
keywords:
- accedere alla diapositiva
- indice diapositiva
- ID diapositiva
- posizione diapositiva
- cambia posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET. Incrementa la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione utilizzando Aspose.Slides. Mostra come recuperare le diapositive tramite il loro indice basato su zero dalla raccolta `Slides` e come accedere a una diapositiva mediante il suo ID univoco usando il metodo `GetSlideById`.

Imparerai inoltre come modificare la posizione di una diapositiva impostando la proprietà `SlideNumber` e come definire il numero di diapositiva iniziale per una presentazione con la proprietà `FirstSlideNumber`. Gli esempi mostrano come caricare una presentazione, ottenere riferimenti alle diapositive, aggiornare l'ordine o la numerazione delle diapositive e salvare la presentazione modificata.

## **Accedi a una diapositiva per indice**

Tutte le diapositive in una presentazione sono organizzate numericamente in base alla posizione della diapositiva a partire da 0. La prima diapositiva è accessibile tramite l'indice 0; la seconda diapositiva è accessibile tramite l'indice 1; ecc.

La classe Presentation, che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [ISlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection) (collezione di oggetti [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/)). Questo codice C# mostra come accedere a una diapositiva tramite il suo indice:

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ottiene il riferimento a una diapositiva tramite il suo indice
ISlide slide = presentation.Slides[0];
```

## **Accedi a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. È possibile utilizzare il metodo [GetSlideById](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/getslidebyid) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)) per puntare a quell'ID. Questo codice C# mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [GetSlideById](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ottiene l'ID di una diapositiva
uint id = presentation.Slides[0].SlideId;

// Accede alla diapositiva tramite il suo ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Modifica posizione diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile specificare che la prima diapositiva diventi la seconda diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento alla diapositiva (la cui posizione vuoi modificare) tramite il suo indice
1. Imposta una nuova posizione per la diapositiva tramite la proprietà [SlideNumber](https://reference.aspose.com/slides/it/net/aspose.slides/islide/slidenumber/).
1. Salva la presentazione modificata.

Questo codice C# dimostra un'operazione in cui la diapositiva nella posizione 1 viene spostata nella posizione 2:

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Ottiene la diapositiva la cui posizione verrà modificata
    ISlide sld = pres.Slides[0];

    // Imposta la nuova posizione per la diapositiva
    sld.SlideNumber = 2;

    // Salva la presentazione modificata
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando si modifica la posizione di una diapositiva, le altre diapositive vengono automaticamente regolate.

## **Imposta il numero diapositiva**

Utilizzando la proprietà [FirstSlideNumber](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/firstslidenumber/) (esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri di diapositiva vengano ricalcolati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il numero della diapositiva.
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Questo codice C# dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10:

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Ottiene il numero della diapositiva
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Imposta il numero della diapositiva
    presentation.FirstSlideNumber=10;
    
    // Salva la presentazione modificata
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Se preferisci saltare la prima diapositiva, puoi avviare la numerazione dalla seconda diapositiva (nascostando la numerazione per la prima diapositiva) in questo modo:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Imposta il numero per la prima diapositiva della presentazione
    presentation.FirstSlideNumber = 0;

    // Mostra i numeri delle diapositive per tutte le diapositive
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Nasconde il numero della diapositiva per la prima diapositiva
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Salva la presentazione modificata
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Il numero della diapositiva visualizzato dall'utente corrisponde all'indice basato su zero della collezione?**

Il numero mostrato su una diapositiva può iniziare da un valore arbitrario (ad es., 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione [primo numero di diapositiva](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/firstslidenumber/) della presentazione.

**Le diapositive nascoste influiscono sull'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione e viene conteggiata nell'indicizzazione; "nascosta" si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando vengono aggiunte o rimosse altre diapositive?**

Sì. Gli indici riflettono sempre l'ordine corrente delle diapositive e vengono ricalcolati in caso di operazioni di inserimento, cancellazione o spostamento.