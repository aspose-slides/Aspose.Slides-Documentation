---
title: "Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.6.0-ban"
linktitle: "Aspose.Slides for Java 15.6.0"
type: docs
weight: 140
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
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
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és töréspontokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) osztályt, metódust, tulajdonságot stb., az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) az Aspose.Slides for Java 15.6.0 API-val.
{{% /alert %}} 
## **Nyilvános API változások**
#### **A com.aspose.slides.DataLabel konstruktor aláírása megváltozott**
A konstruktor aláírása megváltozott a DataLabel(com.aspose.slides.IChartSeries)-ról a DataLabel(com.aspose.slides.IChartDataPoint)-ra.
#### **A com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) tagok elavulttá lettek nyilvánítva; helyettesítőket vezettek be helyettük**
Az IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index), .remove(string name) és .contains(string name) metódusok elavulttá lettek nyilvánítva. Helyettük bevezetésre kerültek az IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index), .removeCustomProperty(String name) és .containsCustomProperty(string name) metódusok.
#### **A com.aspose.slides.INotesSlideManager.removeNotesSlide() metódus hozzá lett adva**
A com.aspose.slides.INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva egy dia jegyzetdiájának eltávolításához.
#### **A com.aspose.slides.ISlide.getNotesSlideManager() metódus hozzá lett adva. Az ISlide.getNotesSlide() és ISlide.addNotesSlide() metódusok elavulttá lettek nyilvánítva**
Az ISlide.getNotesSlide() és ISlide.addNotesSlide() metódusok elavulttá lettek nyilvánítva. Helyette használja az új ISSlide.getNotesSlideManager() metódust.
``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - elavult

// notes = slide.getNotesSlide(); - elavult

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **A getAppVersion() metódus hozzá lett adva a com.aspose.slides.IDocumentProperties-hez**
A com.aspose.slides.IDocumentProperties.getAppVersion() metódus hozzá lett adva a beépített dokumentumtulajdonság lekéréséhez, amely a Microsoft PowerPoint által használt belső verziószámokat reprezentálja.
#### **A remove() metódus hozzá lett adva a com.aspose.slides.IComment-hoz**
A com.aspose.slides.IComment.remove() metódus hozzá lett adva a megjegyzés a gyűjteményből történő eltávolításához.
#### **A remove() metódus hozzá lett adva a com.aspose.slides.ICommentAuthor-hoz**
Az ICommentAuthor.Remove metódus hozzá lett adva a megjegyzések szerzőjének a gyűjteményből történő eltávolításához.
#### **A clearCustomProperties() és a clearBuiltInProperties() metódusok hozzá lettek adva a com.aspose.slides.IDocumentProperties-hez**
A com.aspose.slides.IDocumentProperties.clearCustomProperties() metódus hozzá lett adva az összes egyéni dokumentumtulajdonság eltávolításához.
A com.aspose.slides.IDocumentProperties.clearBuiltInProperties() metódus hozzá lett adva az összes beépített dokumentumtulajdonság (Company, Subject, Author stb.) eltávolításához és alapértelmezett értékek beállításához.
#### **A getBlackWhiteMode() és a setBlackWhiteMode(byte) metódusok hozzá lettek adva a com.aspose.slides.IShape-hoz**
A getBlackWhiteMode(), a setBlackWhiteMode(byte) metódusok hozzá lettek adva a com.aspose.slides.IShape-hoz. A metódusok meghatározzák, hogy egy alakzat hogyan jelenik meg fekete-fehér megjelenítési módban. A lehetséges értékek a com.aspose.slides.BlackWhiteMode osztályban vannak definiálva.

|**Érték**|**Jelentés**|
| :- | :- |
|Color|Visszaadja a normál színezést|
|Automatic|Visszaadja az automatikus színezést|
|Gray|Visszaadja a szürke színezést|
|LightGray|Visszaadja a világosszürke színezést|
|InverseGray|Visszaadja az inverz szürke színezést|
|GrayWhite|Visszaadja a szürke és fehér színezést|
|BlackGray|Visszaadja a fekete és szürke színezést|
|BlackWhite|Visszaadja a fekete és fehér színezést|
|Black|Csak fekete színezést ad vissza|
|White|Fehér színezést ad vissza|
|Hidden|Az objektum nem jelenik meg|
#### **A removeAt(int), a remove(ICommentAuthor) és a clear() metódusok hozzá lettek adva a com.aspose.slides.ICommentAuthorCollection-hoz**
A ICommentAuthorCollection.removeAt(int) metódus hozzá lett adva a megadott indexű szerző eltávolításához. A ICommentAuthorCollection.remove(ICommentAuthor) metódus hozzá lett adva a megadott szerző a gyűjteményből történő eltávolításához. A ICommentAuthorCollection.clear() metódus hozzá lett adva a gyűjtemény összes elemének eltávolításához.