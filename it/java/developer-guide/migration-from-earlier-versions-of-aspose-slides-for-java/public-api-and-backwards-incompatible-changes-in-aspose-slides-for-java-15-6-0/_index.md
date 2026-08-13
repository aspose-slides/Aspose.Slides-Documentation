---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 15.6.0
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per Java per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [aggiunte](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), eventuali nuove restrizioni e altre [modifiche](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) introdotte con l'API Aspose.Slides per Java 15.6.0.

{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
La firma del costruttore è stata modificata da DataLabel(com.aspose.slides.IChartSeries) a DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
I metodi IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) sono stati contrassegnati come Obsoleti. Sono stati introdotti al loro posto i metodi IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
È stato aggiunto il metodo com.aspose.slides.INotesSlideManager.RemoveNotesSlide() per rimuovere la diapositiva delle note di una diapositiva.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
I metodi ISlide.getNotesSlide() e ISlide.addNotesSlide() sono stati contrassegnati come Obsoleti. Utilizzare il nuovo metodo ISlide.getNotesSlideManager().

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - deprecato

    // notes = slide.getNotesSlide(); - deprecato

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.getAppVersion() per ottenere la proprietà di documento incorporata che rappresenta i numeri di versione interni utilizzati da Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
È stato aggiunto il metodo com.aspose.slides.IComment.remove() per rimuovere il commento dalla collezione.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
È stato aggiunto il metodo ICommentAuthor.Remove per rimuovere l'autore dei commenti dalla collezione.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.clearCustomProperties() per rimuovere tutte le proprietà personalizzate del documento.
È stato aggiunto il metodo com.aspose.slides.IDocumentProperties.clearBuiltInProperties() per rimuovere e impostare i valori predefiniti per tutte le proprietà di documento incorporate (Company, Subject, Author ecc.).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Sono stati aggiunti i metodi getBlackWhiteMode() e setBlackWhiteMode(byte) a com.aspose.slides.IShape.
I metodi specificano come una forma verrà visualizzata in modalità bianco‑nero. I valori possibili sono specificati nella classe com.aspose.slides.BlackWhiteMode.

|**Valore** |**Significato** |
| :- | :- |
|Color |Restituisce con colorazione normale |
|Automatic |Restituisce con colorazione automatica |
|Gray |Restituisce con colorazione grigia |
|LightGray |Restituisce con colorazione grigio chiaro |
|InverseGray |Restituisce con colorazione grigio inversa |
|GrayWhite |Restituisce con colorazione grigio e bianco |
|BlackGray |Restituisce con colorazione nero e grigio |
|BlackWhite |Restituisce con colorazione nero e bianco |
|Black |Restituisce solo con colorazione nera |
|White |Restituisce con colorazione bianca |
|Hidden |L'oggetto non viene renderizzato |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Il metodo ICommentAuthorCollection.removeAt(int) è stato aggiunto per rimuovere l'autore all'indice specificato. Il metodo ICommentAuthorCollection.remove(ICommentAuthor) è stato aggiunto per rimuovere l'autore specificato dalla collezione. Il metodo ICommentAuthorCollection.clear() è stato aggiunto per rimuovere tutti gli elementi dalla collezione.