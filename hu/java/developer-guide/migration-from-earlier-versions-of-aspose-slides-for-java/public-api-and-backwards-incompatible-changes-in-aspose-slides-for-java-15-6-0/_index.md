---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.6.0-ban
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) az Aspose.Slides for Java 15.6.0 API‑val.

{{% /alert %}} 
## **Nyilvános API változások**
#### **com.aspose.slides.DataLabel constructor signature has been changed**
A com.aspose.slides.DataLabel konstruktor aláírása megváltozott a DataLabel(com.aspose.slides.IChartSeries) helyett a DataLabel(com.aspose.slides.IChartDataPoint) értékre.
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
A com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) elemeket elavultnak jelölték; helyette helyettesítőket vezettek be. Az IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) metódusokat elavultnak jelölték. Helyette bevezették az IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) metódusokat.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
A com.aspose.slides.INotesSlideManager.removeNotesSlide() metódus hozzá lett adva.
A com.aspose.slides.INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva egy dia jegyzetdiájának eltávolításához.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
Metódus com.aspose.slides.ISlide.getNotesSlideManager() hozzá lett adva. Az ISlide.getNotesSlide() és ISlide.addNotesSlide() metódusokat elavultnak jelölték.
Az ISlide.getNotesSlide(), ISlide.addNotesSlide() metódusokat elavultnak jelölték. Használja az új ISlide.getNotesSlideManager() metódust helyette.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - elavult

    // notes = slide.getNotesSlide(); - elavult

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
Metódus getAppVersion() lett hozzáadva a com.aspose.slides.IDocumentProperties-hez.
A com.aspose.slides.IDocumentProperties.getAppVersion() metódus hozzá lett adva a beépített dokumentum tulajdonság lekéréséhez, amely a Microsoft PowerPoint által használt belső verziószámokat képviseli.
#### **Method remove() has been added to com.aspose.slides.IComment**
Metódus remove() lett hozzáadva a com.aspose.slides.IComment-hez.
A com.aspose.slides.IComment.remove() metódus hozzá lett adva a megjegyzés a gyűjteményből történő eltávolításához.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
Metódus remove() lett hozzáadva a com.aspose.slides.ICommentAuthor-hez.
Az ICommentAuthor.Remove metódus lett hozzáadva a megjegyzés szerzőjének a gyűjteményből történő eltávolításához.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
Metódusok clearCustomProperties() és clearBuiltInProperties() lettek hozzáadva a com.aspose.slides.IDocumentProperties-hez.
A com.aspose.slides.IDocumentProperties.clearCustomProperties() metódus lett hozzáadva az összes egyedi dokumentumtulajdonság eltávolításához.
A com.aspose.slides.IDocumentProperties.clearBuiltInProperties() metódus lett hozzáadva az összes beépített dokumentumtulajdonság (Company, Subject, Author stb.) eltávolításához és alapértelmezett értékek beállításához.
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
Metódusok getBlackWhiteMode() és setBlackWhiteMode(byte) lettek hozzáadva a com.aspose.slides.IShape-hez.
A metódusok meghatározzák, hogy a forma hogyan jelenik meg fekete-fehér megjelenítési módban. A lehetséges értékeket a com.aspose.slides.BlackWhiteMode osztályban határozzák meg.

|**Érték**|**Jelentés**|
| :- | :- |
|Color|Szín|
|Automatic|Automatikus|
|Gray|Szürke|
|LightGray|Világosszürke|
|InverseGray|Inverz szürke|
|GrayWhite|Szürke-fehér|
|BlackGray|Fekete-szürke|
|BlackWhite|Fekete-fehér|
|Black|Fekete|
|White|Fehér|
|Hidden|Rejtett|
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
Metódusok removeAt(int), remove(ICommentAuthor) és clear() lettek hozzáadva a com.aspose.slides.ICommentAuthorCollection-hoz.
Az ICommentAuthorCollection.removeAt(int) metódus hozzá lett adva a megadott indexű szerző eltávolításához. Az ICommentAuthorCollection.remove(ICommentAuthor) metódus hozzá lett adva a megadott szerző a gyűjteményből történő eltávolításához. Az ICommentAuthorCollection.clear() metódus hozzá lett adva az összes elem a gyűjteményből történő eltávolításához.