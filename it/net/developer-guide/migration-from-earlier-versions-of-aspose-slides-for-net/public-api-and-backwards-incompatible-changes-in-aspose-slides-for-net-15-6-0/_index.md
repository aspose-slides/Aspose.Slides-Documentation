---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per .NET 15.6.0
linktitle: Aspose.Slides per .NET 15.6.0
type: docs
weight: 170
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), e le altre modifiche introdotte con l'API di Aspose.Slides per .NET 15.6.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **La firma del costruttore DataLabel è stata modificata**
La firma del costruttore DataLabel è stata modificata:
prima: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **I membri IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) sono stati contrassegnati come obsoleti e sono state introdotte le loro sostituzioni.**
La proprietà IDocumentProperties.Count e i metodi IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) sono stati contrassegnati come obsoleti. La proprietà IDocumentProperties.CountOfCustomProperties e i metodi IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) sono stati aggiunti al loro posto.
#### **È stato aggiunto il metodo INotesSlideManager.RemoveNotesSlide()**
Il metodo INotesSlideManager.RemoveNotesSlide() è stato aggiunto per rimuovere la diapositiva delle note di una diapositiva.
#### **È stato aggiunto il metodo Remove a IComment**
Il metodo IComment.Remove è stato aggiunto per rimuovere un commento dalla raccolta.
#### **È stato aggiunto il metodo Remove a ICommentAuthor**
Il metodo ICommentAuthor.Remove è stato aggiunto per rimuovere l'autore dei commenti dalla raccolta.
#### **I metodi ClearCustomProperties e ClearBuiltInProperties sono stati aggiunti a IDocumentProperties**
Il metodo IDocumentProperties.ClearCustomProperties è stato aggiunto per rimuovere tutte le proprietà personalizzate del documento.
Il metodo IDocumentProperties.ClearBuiltInProperties è stato aggiunto per rimuovere e impostare i valori predefiniti per tutte le proprietà builtIn del documento (Company, Subject, Author etc).
#### **I metodi RemoveAt, Remove e Clear sono stati aggiunti a ICommentAuthorCollection**
Il metodo ICommentAuthorCollection.RemoveAt è stato aggiunto per rimuovere l'autore mediante l'indice specificato.
Il metodo ICommentAuthorCollection.Remove è stato aggiunto per rimuovere l'autore specificato dalla raccolta.
Il metodo ICommentAuthorCollection.Clear è stato aggiunto per rimuovere tutti gli elementi dalla raccolta.
#### **È stata aggiunta la proprietà AppVersion a IDocumentProperties**
La proprietà IDocumentProperties.AppVersion è stata aggiunta per ottenere la proprietà builtIn del documento che rappresenta i numeri di versione interni utilizzati da Microsoft durante lo sviluppo.
#### **È stata aggiunta la proprietà BlackWhiteMode a IShape e a Shape**
La proprietà BlackWhiteMode è stata aggiunta a IShape e a Shape.

Questa proprietà specifica come una forma verrà renderizzata in modalità bianco‑nero.

|**Valore** |**Significato** |
| :- | :- |
|Color |Renderizza con colori normali |
|Automatic |Renderizza con colorazione automatica |
|Gray |Renderizza con colorazione grigia |
|LightGray |Renderizza con colorazione grigio chiaro |
|InverseGray |Renderizza con colorazione grigio inverso |
|GrayWhite |Renderizza con colorazione grigio e bianco |
|BlackGray |Renderizza con colorazione nera e grigia |
|BlackWhite |Renderizza con colorazione nera e bianca |
|Black |Renderizza solo con colorazione nera |
|White |Renderizza con colorazione bianca |
|Hidden |Non renderizza |
|NotDefined |significa che la proprietà non è impostata |
#### **È stata aggiunta la proprietà ISlide.NotesSlideManager. Le proprietà ISlide.NotesSlide e il metodo ISlide.AddNotesSlide() sono stati contrassegnati come obsoleti.**
I membri ISlide.NotesSlide e ISlide.AddNotesSlide() sono stati contrassegnati come obsoleti. Usa la nuova proprietà ISlide.NotesSlideManager al loro posto.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - obsoleto
    // notes = slide.NotesSlide; - obsoleto

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```