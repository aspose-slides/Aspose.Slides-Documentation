---
title: "API pubbliche e modifiche retroattive incompatibili in Aspose.Slides per .NET 15.6.0"
linktitle: "Aspose.Slides per .NET 15.6.0"
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
description: "Esamina gli aggiornamenti delle API pubbliche e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutti i [aggiunti](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) o i [rimossi](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) classi, metodi, proprietà e così via, e le altre modifiche introdotte con l'API Aspose.Slides per .NET 15.6.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **La firma del costruttore DataLabel è stata modificata**
La firma del costruttore DataLabel è stata modificata:
prima: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ora: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **I membri IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) sono stati contrassegnati come obsoleti e le loro sostituzioni sono state introdotte**
La proprietà IDocumentProperties.Count e i metodi IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) sono stati contrassegnati come obsoleti. Sono state aggiunte invece la proprietà IDocumentProperties.CountOfCustomProperties e i metodi IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **È stato aggiunto il metodo INotesSlideManager.RemoveNotesSlide()**
Il metodo INotesSlideManager.RemoveNotesSlide() è stato aggiunto per rimuovere la diapositiva note di una diapositiva.
#### **È stato aggiunto il metodo Remove a IComment**
Il metodo IComment.Remove è stato aggiunto per rimuovere un commento dalla collezione.
#### **È stato aggiunto il metodo Remove a ICommentAuthor**
Il metodo ICommentAuthor.Remove è stato aggiunto per rimuovere l'autore dei commenti dalla collezione.
#### **Sono stati aggiunti i metodi ClearCustomProperties e ClearBuiltInProperties a IDocumentProperties**
Il metodo IDocumentProperties.ClearCustomProperties è stato aggiunto per rimuovere tutte le proprietà documento personalizzate.
Il metodo IDocumentProperties.ClearBuiltInProperties è stato aggiunto per rimuovere e impostare i valori predefiniti per tutte le proprietà documento integrate (Company, Subject, Author ecc.).
#### **Sono stati aggiunti i metodi RemoveAt, Remove e Clear a ICommentAuthorCollection**
Il metodo ICommentAuthorCollection.RemoveAt è stato aggiunto per rimuovere un autore mediante l'indice specificato.
Il metodo ICommentAuthorCollection.Remove è stato aggiunto per rimuovere un autore specificato dalla collezione.
Il metodo ICommentAuthorCollection.Clear è stato aggiunto per rimuovere tutti gli elementi dalla collezione.
#### **È stata aggiunta la proprietà AppVersion a IDocumentProperties**
La proprietà IDocumentProperties.AppVersion è stata aggiunta per ottenere la proprietà documento integrata che rappresenta i numeri di versione interni utilizzati da Microsoft durante lo sviluppo.
#### **È stata aggiunta la proprietà BlackWhiteMode a IShape e a Shape**
La proprietà BlackWhiteMode è stata aggiunta a IShape e a Shape.

Questa proprietà specifica come una forma verrà visualizzata in modalità bianco‑nero.

|**Valore** |**Significato** |
| :- | :- |
|Color |Rende con colorazione normale |
|Automatic |Rende con colorazione automatica |
|Gray |Rende con colorazione grigia |
|LightGray |Rende con colorazione grigio chiaro |
|InverseGray |Rende con colorazione grigio inverso |
|GrayWhite |Rende con colorazione grigia e bianca |
|BlackGray |Rende con colorazione nera e grigia |
|BlackWhite |Rende con colorazione nera e bianca |
|Black |Rende solo con colorazione nera |
|White |Rende con colorazione bianca |
|Hidden |Non viene renderizzata |
|NotDefined|indica che la proprietà non è impostata|
#### **È stata aggiunta la proprietà ISlide.NotesSlideManager. La proprietà ISlide.NotesSlide e il metodo ISlide.AddNotesSlide() sono stati contrassegnati come obsoleti.**
I membri ISlide.NotesSlide e ISlide.AddNotesSlide() sono stati contrassegnati come obsoleti. Usa la nuova proprietà ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsoleto

// notes = slide.NotesSlide; - obsoleto

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```