---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.6.0‑ban
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Nézze át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) a Aspose.Slides for Java 15.6.0 API-val együtt.

{{% /alert %}} 
## **Nyilvános API változások**
#### **A com.aspose.slides.DataLabel konstruktor aláírása megváltozott**
A konstruktor aláírása megváltozott a DataLabel(com.aspose.slides.IChartSeries) és a DataLabel(com.aspose.slides.IChartDataPoint) között.
#### **A com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) tagok elavulttá lettek jelölve; helyettesítők lettek bevezetve helyette**
Az IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name) és .contains(string name) metódusok elavulttá lettek jelölve. Helyette be lettek vezetve az IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name) és .containsCustomProperty(string name) metódusok.
#### **A com.aspose.slides.INotesSlideManager.removeNotesSlide() metódus hozzá lett adva**
A com.aspose.slides.INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva egy dia jegyzetdia eltávolításához.
#### **A com.aspose.slides.ISlide.getNotesSlideManager() metódus hozzá lett adva. Az ISlide.getNotesSlide() és ISlide.addNotesSlide() metódusok elavulttá lettek jelölve**
Az ISlide.getNotesSlide() és ISlide.addNotesSlide() metódusok elavulttá lettek jelölve. Helyette használja az új ISlide.getNotesSlideManager() metódust.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - elavult

// notes = slide.getNotesSlide(); - elavult

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **A getAppVersion() metódus hozzá lett adva a com.aspose.slides.IDocumentProperties osztályhoz**
A com.aspose.slides.IDocumentProperties.getAppVersion() metódus hozzá lett adva a beépített dokumentum tulajdonság lekéréséhez, amely a Microsoft PowerPoint által használt belső verziószámokat képviseli.
#### **A remove() metódus hozzá lett adva a com.aspose.slides.IComment osztályhoz**
A com.aspose.slides.IComment.remove() metódus hozzá lett adva a megjegyzés a gyűjteményből való eltávolításához.
#### **A remove() metódus hozzá lett adva a com.aspose.slides.ICommentAuthor osztályhoz**
Az ICommentAuthor.Remove metódus hozzá lett adva a megjegyzések szerzőjének a gyűjteményből való eltávolításához.
#### **A clearCustomProperties() és a clearBuiltInProperties() metódusok hozzá lettek adva a com.aspose.slides.IDocumentProperties osztályhoz**
A com.aspose.slides.IDocumentProperties.clearCustomProperties() metódus hozzá lett adva az összes egyéni dokumentumtulajdonság eltávolításához.
A com.aspose.slides.IDocumentProperties.clearBuiltInProperties() metódus hozzá lett adva az összes beépített dokumentumtulajdonság (Company, Subject, Author stb.) eltávolításához és alapértelmezett értékek beállításához.
#### **A getBlackWhiteMode() és a setBlackWhiteMode(byte) metódusok hozzá lettek adva a com.aspose.slides.IShape osztályhoz**
A getBlackWhiteMode() és a setBlackWhiteMode(byte) metódusok hozzá lettek adva a com.aspose.slides.IShape osztályhoz.
A metódusok meghatározzák, hogyan jelenik meg egy alakzat fekete-fehér megjelenítési módban. A lehetséges értékek a com.aspose.slides.BlackWhiteMode osztályban vannak meghatározva.

|**Érték** |**Jelentés** |
| :- | :- |
|Color |Visszatér normál színezéssel |
|Automatic |Visszatér automatikus színezéssel |
|Gray |Visszatér szürke színezéssel |
|LightGray |Visszatér világosszürke színezéssel |
|InverseGray |Visszatér invertált szürke színezéssel |
|GrayWhite |Visszatér szürke és fehér színezéssel |
|BlackGray |Visszatér fekete és szürke színezéssel |
|BlackWhite |Visszatér fekete és fehér színezéssel |
|Black |Visszatér csak fekete színezéssel |
|White |Visszatér fehér színezéssel |
|Hidden |Az objektum nem kerül renderelésre |
#### **A removeAt(int), remove(ICommentAuthor) és a clear() metódusok hozzá lettek adva a com.aspose.slides.ICommentAuthorCollection osztályhoz**
Az ICommentAuthorCollection.removeAt(int) metódus hozzá lett adva a szerző adott index alapján történő eltávolításához. Az ICommentAuthorCollection.remove(ICommentAuthor) metódus hozzá lett adva a megadott szerző a gyűjteményből való eltávolításához. Az ICommentAuthorCollection.clear() metódus hozzá lett adva az összes elem a gyűjteményből való eltávolításához.