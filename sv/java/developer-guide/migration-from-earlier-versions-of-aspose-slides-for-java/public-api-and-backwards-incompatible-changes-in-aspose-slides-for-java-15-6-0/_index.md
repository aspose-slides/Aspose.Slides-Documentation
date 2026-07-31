---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 15.6.0
linktitle: Aspose.Slides för Java 15.6.0
type: docs
weight: 140
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migrering
- äldre kod
- modern kod
- äldre strategi
- modern strategi
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 
Den här sidan listar alla [tillägg](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) som införts med Aspose.Slides for Java 15.6.0 API.
{{% /alert %}} 
## **Ändringar i offentligt API**
#### **signaturen för com.aspose.slides.DataLabel‑konstruktorn har ändrats**
Signaturen för konstruktorn har ändrats från DataLabel(com.aspose.slides.IChartSeries) till DataLabel(com.aspose.slides.IChartDataPoint).
#### **Medlemmarna com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) har markerats som föråldrade; ersättningar har införts istället**
Metoderna IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) har markerats som föråldrade. Metoderna IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) har införts istället.
#### **Metoden com.aspose.slides.INotesSlideManager.removeNotesSlide() har lagts till**
Metoden com.aspose.slides.INotesSlideManager.RemoveNotesSlide() har lagts till för att ta bort notes‑slide från en slide.
#### **Metoden com.aspose.slides.ISlide.getNotesSlideManager() har lagts till. Metoderna ISlide.getNotesSlide() och ISlide.addNotesSlide() har markerats som föråldrade**
Metoderna ISlide.getNotesSlide() och ISlide.addNotesSlide() har markerats som föråldrade. Använd den nya metoden ISlide.getNotesSlideManager() istället.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - föråldrad

// notes = slide.getNotesSlide(); - föråldrad

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Metoden getAppVersion() har lagts till i com.aspose.slides.IDocumentProperties**
Metoden com.aspose.slides.IDocumentProperties.getAppVersion() har lagts till för att hämta den inbyggda dokumentegenskapen som representerar interna versionsnummer som används av Microsoft PowerPoint.
#### **Metoden remove() har lagts till i com.aspose.slides.IComment**
Metoden com.aspose.slides.IComment.remove() har lagts till för att ta bort en kommentar från samlingen.
#### **Metoden remove() har lagts till i com.aspose.slides.ICommentAuthor**
Metoden ICommentAuthor.Remove har lagts till för att ta bort författaren till kommentarer från samlingen.
#### **Metoderna clearCustomProperties() och clearBuiltInProperties() har lagts till i com.aspose.slides.IDocumentProperties**
Metoden com.aspose.slides.IDocumentProperties.clearCustomProperties() har lagts till för att ta bort alla anpassade dokumentegenskaper.
Metoden com.aspose.slides.IDocumentProperties.clearBuiltInProperties() har lagts till för att ta bort och återställa standardvärden för alla inbyggda dokumentegenskaper (Company, Subject, Author osv).
#### **Metoderna getBlackWhiteMode() och setBlackWhiteMode(byte) har lagts till i com.aspose.slides.IShape**
Metoderna getBlackWhiteMode() och setBlackWhiteMode(byte) har lagts till i com.aspose.slides.IShape.
Metoderna specificerar hur en shape ska renderas i svart‑vit visningsläge. De möjliga värdena anges i klassen com.aspose.slides.BlackWhiteMode.

|**Värde** |**Betydelse** |
| :- | :- |
|Color |Returnerar med normal färgsättning |
|Automatic |Returnerar med automatisk färgsättning |
|Gray |Returnerar med grå färgsättning |
|LightGray |Returnerar med ljusgrå färgsättning |
|InverseGray |Returnerar med inverterad grå färgsättning |
|GrayWhite |Returnerar med grå och vit färgsättning |
|BlackGray |Returnerar med svart och grå färgsättning |
|BlackWhite |Returnerar med svart och vit färgsättning |
|Black |Returnerar endast med svart färgsättning |
|White |Returnerar med vit färgsättning |
|Hidden |Objektet renderas inte |
#### **Metoderna removeAt(int), remove(ICommentAuthor) och clear() har lagts till i com.aspose.slides.ICommentAuthorCollection**
Metoden ICommentAuthorCollection.removeAt(int) har lagts till för att ta bort en författare enligt angivet index. Metoden ICommentAuthorCollection.remove(ICommentAuthor) har lagts till för att ta bort en angiven författare från samlingen. Metoden ICommentAuthorCollection.clear() har lagts till för att ta bort alla objekt från samlingen.