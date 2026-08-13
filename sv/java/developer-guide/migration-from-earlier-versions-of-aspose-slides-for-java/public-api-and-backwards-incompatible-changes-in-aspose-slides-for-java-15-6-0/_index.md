---
title: Offentlig API och bakåtinkompatibla ändringar i Aspose.Slides för Java 15.6.0
linktitle: Aspose.Slides för Java 15.6.0
type: docs
weight: 140
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 
Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) klasser, metoder, egenskaper med mera, eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) som introduceras med Aspose.Slides för Java 15.6.0 API.
{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
Signaturen för konstruktorn i com.aspose.slides.DataLabel har ändrats. Signaturen för konstruktorn har ändrats från DataLabel(com.aspose.slides.IChartSeries) till DataLabel(com.aspose.slides.IChartDataPoint).
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Medlemmarna com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) har markerats som föråldrade; ersättningar har införts istället. Metoderna IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) har markerats som föråldrade. Metoderna IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) har införts istället.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
Metoden com.aspose.slides.INotesSlideManager.removeNotesSlide() har lagts till för att ta bort notes slide från en bild.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Metoden com.aspose.slides.ISlide.getNotesSlideManager() har lagts till. Metoderna ISlide.getNotesSlide() och ISlide.addNotesSlide() har markerats som föråldrade. Metoderna ISlide.getNotesSlide() och ISlide.addNotesSlide() har markerats som föråldrade. Använd den nya metoden ISlide.getNotesSlideManager() istället.
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - föråldrad

    // notes = slide.getNotesSlide(); - föråldrad

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Metoden getAppVersion() har lagts till i com.aspose.slides.IDocumentProperties. Metoden com.aspose.slides.IDocumentProperties.getAppVersion() har lagts till för att hämta den inbyggda dokumentegenskapen som representerar interna versionsnummer som används av Microsoft PowerPoint.
#### **Method remove() has been added to com.aspose.slides.IComment**
Metoden remove() har lagts till i com.aspose.slides.IComment. Metoden com.aspose.slides.IComment.remove() har lagts till för att ta bort en kommentar från samlingen.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Metoden remove() har lagts till i com.aspose.slides.ICommentAuthor. Metoden ICommentAuthor.Remove har lagts till för att ta bort författaren till kommentarer från samlingen.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Metoderna clearCustomProperties() och clearBuiltInProperties() har lagts till i com.aspose.slides.IDocumentProperties. Metoden com.aspose.slides.IDocumentProperties.clearCustomProperties() har lagts till för att ta bort alla anpassade dokumentegenskaper. Metoden com.aspose.slides.IDocumentProperties.clearBuiltInProperties() har lagts till för att ta bort och återställa standardvärden för alla inbyggda dokumentegenskaper (Company, Subject, Author etc).
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Metoderna getBlackWhiteMode() och setBlackWhiteMode(byte) har lagts till i com.aspose.slides.IShape. Metoderna getBlackWhiteMode() och setBlackWhiteMode(byte) har lagts till i com.aspose.slides.IShape. Metoderna anger hur en form ska renderas i svart‑vita visningsläge. De möjliga värdena specificeras i klassen com.aspose.slides.BlackWhiteMode.

|**Värde**|**Betydelse**|
| :- | :- |
|Color|Returnerar med normal färgning|
|Automatic|Returnerar med automatisk färgning|
|Gray|Returnerar med grå färgning|
|LightGray|Returnerar med ljusgrå färgning|
|InverseGray|Returnerar med inverterad grå färgning|
|GrayWhite|Returnerar med grå och vit färgning|
|BlackGray|Returnerar med svart och grå färgning|
|BlackWhite|Returnerar med svart och vit färgning|
|Black|Returnerar endast med svart färgning|
|White|Returnerar med vit färgning|
|Hidden|Objektet renderas inte|
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Metoderna removeAt(int), remove(ICommentAuthor) och clear() har lagts till i com.aspose.slides.ICommentAuthorCollection. Metoden ICommentAuthorCollection.removeAt(int) har lagts till för att ta bort en författare med angivet index. Metoden ICommentAuthorCollection.remove(ICommentAuthor) har lagts till för att ta bort en specificerad författare från samlingen. Metoden ICommentAuthorCollection.clear() har lagts till för att ta bort alla objekt från samlingen.