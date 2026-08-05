---
title: API pubblica e modifiche incompatibili retroattive in Aspose.Slides per Java 15.6.0
linktitle: Aspose.Slides per Java 15.6.0
type: docs
weight: 140
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), i metodi, le proprietà e così via, eventuali nuove restrizioni e le altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introdotte con l'API Aspose.Slides per Java 15.6.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
La firma del costruttore di com.aspose.slides.DataLabel è stata modificata.
The signature of the constructor has been changed from DataLabel(com.aspose.slides.IChartSeries) to DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
I membri com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) sono stati contrassegnati come Obsoleti; sono state introdotte delle sostituzioni.
Methods IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) have been marked as Deprecated. Methods IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) have been introduced instead.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
È stato aggiunto il metodo com.aspose.slides.INotesSlideManager.removeNotesSlide().
Method com.aspose.slides.INotesSlideManager.RemoveNotesSlide() has been added for removing notes slide of some slide.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
È stato aggiunto il metodo com.aspose.slides.ISlide.getNotesSlideManager(). I metodi ISlide.getNotesSlide() e ISlide.addNotesSlide() sono stati contrassegnati come Obsoleti.
ISlide.getNotesSlide(), ISlide.addNotesSlide() methods have been marked as Deprecated. Use new method ISlide.getNotesSlideManager() instead.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - deprecato

// notes = slide.getNotesSlide(); - deprecato

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
È stato aggiunto il metodo getAppVersion() a com.aspose.slides.IDocumentProperties.
Method com.aspose.slides.IDocumentProperties.getAppVersion() has been added in order to get builtin document property, which represents internal version numbers used by Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
È stato aggiunto il metodo remove() a com.aspose.slides.IComment.
Method com.aspose.slides.IComment.remove() has been added for removing comment from the collection.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
È stato aggiunto il metodo ICommentAuthor.Remove per rimuovere l'autore dei commenti dalla collezione.
Method ICommentAuthor.Remove has been added for removing author of comments from the collection.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Sono stati aggiunti i metodi clearCustomProperties() e clearBuiltInProperties() a com.aspose.slides.IDocumentProperties.
Method com.aspose.slides.IDocumentProperties.clearCustomProperties() has been added for removing all custom document properties.
Method com.aspose.slides.IDocumentProperties.clearBuiltInProperties() has been added for removing and setting default values for all builtin document properties (Company, Subject, Author etc).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Sono stati aggiunti i metodi getBlackWhiteMode() e setBlackWhiteMode(byte) a com.aspose.slides.IShape.
The methods specify how a shape will render in black-and-white display mode. The possible values are specified in com.aspose.slides.BlackWhiteMode class.

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
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Sono stati aggiunti i metodi removeAt(int), remove(ICommentAuthor) e clear() a com.aspose.slides.ICommentAuthorCollection.
Method ICommentAuthorCollection.removeAt(int) has added for removing author by specified index. Method ICommentAuthorCollection.remove(ICommentAuthor) has added for removing specified author from collection. Method ICommentAuthorCollection.clear() has been added for removing all items from collection.