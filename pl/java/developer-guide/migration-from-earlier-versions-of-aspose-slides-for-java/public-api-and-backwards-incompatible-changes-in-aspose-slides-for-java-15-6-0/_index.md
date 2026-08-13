---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
  - migracja
  - kod legacy
  - nowoczesny kod
  - przestarzałe podejście
  - nowoczesne podejście
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Java
  - Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany niekompatybilne wstecz w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) wprowadzone w API Aspose.Slides for Java 15.6.0.
{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Zmieniono sygnaturę konstruktora com.aspose.slides.DataLabel**
Sygnatura konstruktora została zmieniona z DataLabel(com.aspose.slides.IChartSeries) na DataLabel(com.aspose.slides.IChartDataPoint).
#### **Członkowie com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) zostali oznaczeni jako przestarzałe; wprowadzono zamienniki**
Metody IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) zostały oznaczone jako przestarzałe. Zamiast nich wprowadzono metody IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name).
#### **Dodano metodę com.aspose.slides.INotesSlideManager.removeNotesSlide()**
Metoda com.aspose.slides.INotesSlideManager.RemoveNotesSlide() została dodana w celu usunięcia slajdu notatek z określonego slajdu.
#### **Dodano metodę com.aspose.slides.ISlide.getNotesSlideManager(). Metody ISlide.getNotesSlide() i ISlide.addNotesSlide() zostały oznaczone jako przestarzałe**
Metody ISlide.getNotesSlide() i ISlide.addNotesSlide() zostały oznaczone jako przestarzałe. Zamiast nich użyj nowej metody ISlide.getNotesSlideManager().
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - przestarzałe

    // notes = slide.getNotesSlide(); - przestarzałe

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Dodano metodę getAppVersion() do com.aspose.slides.IDocumentProperties**
Metoda com.aspose.slides.IDocumentProperties.getAppVersion() została dodana w celu pobrania wbudowanej własności dokumentu, reprezentującej wewnętrzne numery wersji używane przez Microsoft PowerPoint.
#### **Dodano metodę remove() do com.aspose.slides.IComment**
Metoda com.aspose.slides.IComment.remove() została dodana w celu usunięcia komentarza z kolekcji.
#### **Dodano metodę remove() do com.aspose.slides.ICommentAuthor**
Metoda ICommentAuthor.Remove została dodana w celu usunięcia autora komentarzy z kolekcji.
#### **Dodano metody clearCustomProperties() i clearBuiltInProperties() do com.aspose.slides.IDocumentProperties**
Metoda com.aspose.slides.IDocumentProperties.clearCustomProperties() została dodana w celu usunięcia wszystkich niestandardowych własności dokumentu.
Metoda com.aspose.slides.IDocumentProperties.clearBuiltInProperties() została dodana w celu usunięcia i ustawienia wartości domyślnych dla wszystkich wbudowanych własności dokumentu (Company, Subject, Author itp.).
#### **Dodano metody getBlackWhiteMode() i setBlackWhiteMode(byte) do com.aspose.slides.IShape**
Metody getBlackWhiteMode() i setBlackWhiteMode(byte) zostały dodane do com.aspose.slides.IShape. Metody określają, jak kształt będzie renderowany w trybie wyświetlania czarno-białego. Możliwe wartości są określone w klasie com.aspose.slides.BlackWhiteMode.

|**Wartość**|**Znaczenie**|
| :- | :- |
|Color|Zwraca z normalnym kolorowaniem|
|Automatic|Zwraca z automatycznym kolorowaniem|
|Gray|Zwraca z szarym kolorowaniem|
|LightGray|Zwraca z jasnoszarym kolorowaniem|
|InverseGray|Zwraca z odwróconym szarym kolorowaniem|
|GrayWhite|Zwraca z szarym i białym kolorowaniem|
|BlackGray|Zwraca z czarnym i szarym kolorowaniem|
|BlackWhite|Zwraca z czarnym i białym kolorowaniem|
|Black|Zwraca wyłącznie z czarnym kolorowaniem|
|White|Zwraca z białym kolorowaniem|
|Hidden|Obiekt nie jest renderowany|
#### **Dodano metody removeAt(int), remove(ICommentAuthor) i clear() do com.aspose.slides.ICommentAuthorCollection**
Metoda ICommentAuthorCollection.removeAt(int) została dodana w celu usunięcia autora o określonym indeksie. Metoda ICommentAuthorCollection.remove(ICommentAuthor) została dodana w celu usunięcia wskazanego autora z kolekcji. Metoda ICommentAuthorCollection.clear() została dodana w celu usunięcia wszystkich elementów z kolekcji.