---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 15.6.0
linktitle: Aspose.Slides per Java 15.6.0
type: docs
weight: 140
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) eventuali nuove restrizioni e altre [changes](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introdotte con l'Aspose.Slides for Java 15.6.0 API.
{{% /alert %}} 
## **Modifiche dell'API pubblica**
#### **La firma del costruttore com.aspose.slides.DataLabel è stata modificata**
La firma del costruttore è stata modificata da DataLabel(com.aspose.slides.IChartSeries) a DataLabel(com.aspose.slides.IChartDataPoint).
#### **I membri com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) sono stati contrassegnati come Obsoleti; sono state introdotte delle sostituzioni**
I metodi IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) sono stati contrassegnati come Obsoleti. Sono stati introdotti invece i metodi IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **È stato aggiunto il metodo com.aspose.slides.INotesSlideManager.removeNotesSlide()**
È stato aggiunto il metodo com.aspose.slides.INotesSlideManager.RemoveNotesSlide() per rimuovere la diapositiva delle note di una determinata diapositiva.
#### **È stato aggiunto il metodo com.aspose.slides.ISlide.getNotesSlideManager(). I metodi ISlide.getNotesSlide() e ISlide.addNotesSlide() sono stati contrassegnati come Obsoleti**
I metodi ISlide.getNotesSlide() e ISlide.addNotesSlide() sono stati contrassegnati come Obsoleti. Utilizzare il nuovo metodo ISlide.getNotesSlideManager() al suo posto.
``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - deprecato

// notes = slide.getNotesSlide(); - deprecato

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **È stato aggiunto il metodo getAppVersion() a com.aspose.slides.IDocumentProperties**
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.getAppVersion() per ottenere la proprietà di documento incorporata, che rappresenta i numeri di versione interni utilizzati da Microsoft PowerPoint.
#### **È stato aggiunto il metodo remove() a com.aspose.slides.IComment**
È stato aggiunto il metodo com.aspose.slides.IComment.remove() per rimuovere un commento dalla raccolta.
#### **È stato aggiunto il metodo remove() a com.aspose.slides.ICommentAuthor**
È stato aggiunto il metodo ICommentAuthor.Remove per rimuovere l'autore dei commenti dalla raccolta.
#### **Sono stati aggiunti i metodi clearCustomProperties() e clearBuiltInProperties() a com.aspose.slides.IDocumentProperties**
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.clearCustomProperties() per rimuovere tutte le proprietà di documento personalizzate.
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.clearBuiltInProperties() per rimuovere e impostare i valori predefiniti per tutte le proprietà di documento incorporate (Company, Subject, Author ecc.).
#### **Sono stati aggiunti i metodi getBlackWhiteMode() e setBlackWhiteMode(byte) a com.aspose.slides.IShape**
Sono stati aggiunti i metodi getBlackWhiteMode() e setBlackWhiteMode(byte) a com.aspose.slides.IShape. I metodi specificano come una forma verrà visualizzata in modalità bianco‑nero. I valori possibili sono specificati nella classe com.aspose.slides.BlackWhiteMode.

|**Valore** |**Significato** |
| :- | :- |
|Color |Restituisce con colorazione normale |
|Automatic |Restituisce con colorazione automatica |
|Gray |Restituisce con colorazione grigia |
|LightGray |Restituisce con colorazione grigio chiaro |
|InverseGray |Restituisce con colorazione grigio inverso |
|GrayWhite |Restituisce con colorazione grigio e bianco |
|BlackGray |Restituisce con colorazione nero e grigio |
|BlackWhite |Restituisce con colorazione nero e bianco |
|Black |Restituisce solo con colorazione nera |
|White |Restituisce con colorazione bianca |
|Hidden |L'oggetto non viene renderizzato |
#### **Sono stati aggiunti i metodi removeAt(int), remove(ICommentAuthor) e clear() a com.aspose.slides.ICommentAuthorCollection**
È stato aggiunto il metodo ICommentAuthorCollection.removeAt(int) per rimuovere l'autore all'indice specificato. È stato aggiunto il metodo ICommentAuthorCollection.remove(ICommentAuthor) per rimuovere l'autore specificato dalla raccolta. È stato aggiunto il metodo ICommentAuthorCollection.clear() per rimuovere tutti gli elementi dalla raccolta.