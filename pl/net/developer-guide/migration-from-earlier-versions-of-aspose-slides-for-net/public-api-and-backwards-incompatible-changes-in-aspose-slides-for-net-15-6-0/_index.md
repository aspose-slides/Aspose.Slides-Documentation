---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.6.0
linktitle: Aspose.Slides dla .NET 15.6.0
type: docs
weight: 170
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i łamiących zmian w Aspose.Slides dla .NET, umożliwiający płynne migrowanie rozwiązań prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Zmieniono sygnaturę konstruktora DataLabel**
Sygnatura konstruktora DataLabel została zmieniona: poprzednio: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); teraz: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Członkowie IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) zostali oznaczeni jako przestarzali, a zamiast nich wprowadzono ich zamienniki.**
Właściwość IDocumentProperties.Count oraz metody IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) zostały oznaczone jako przestarzałe. Dodano właściwość IDocumentProperties.CountOfCustomProperties oraz metody IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Dodano metodę INotesSlideManager.RemoveNotesSlide()**
Dodano metodę INotesSlideManager.RemoveNotesSlide() służącą do usuwania slajdu notatek wybranego slajdu.
#### **Do IComment dodano metodę Remove**
Dodano metodę IComment.Remove służącą do usuwania komentarza z kolekcji.
#### **Do ICommentAuthor dodano metodę Remove**
Dodano metodę ICommentAuthor.Remove służącą do usuwania autora komentarzy z kolekcji.
#### **Do IDocumentProperties dodano metody ClearCustomProperties i ClearBuiltInProperties**
Dodano metodę IDocumentProperties.ClearCustomProperties służącą do usuwania wszystkich własnych właściwości dokumentu.
Dodano metodę IDocumentProperties.ClearBuiltInProperties służącą do usuwania i przywracania domyślnych wartości wszystkich wbudowanych właściwości dokumentu (Company, Subject, Author itd.).
#### **Do ICommentAuthorCollection dodano metody RemoveAt, Remove i Clear**
Dodano metodę ICommentAuthorCollection.RemoveAt służącą do usuwania autora według podanego indeksu.
Dodano metodę ICommentAuthorCollection.Remove służącą do usuwania określonego autora z kolekcji.
Dodano metodę ICommentAuthorCollection.Clear służącą do usuwania wszystkich elementów z kolekcji.
#### **Do IDocumentProperties dodano właściwość AppVersion**
Dodano właściwość IDocumentProperties.AppVersion, umożliwiającą odczyt wbudowanej właściwości dokumentu reprezentującej wewnętrzne numery wersji używane przez firmę Microsoft podczas rozwoju.
#### **Do IShape i Shape dodano właściwość BlackWhiteMode**
Właściwość BlackWhiteMode została dodana do IShape oraz Shape.

Ta właściwość określa, jak kształt będzie renderowany w trybie wyświetlania czarno‑białego.

|**Wartość** |**Znaczenie** |
| :- | :- |
|Color |Renderowanie z normalnym kolorowaniem |
|Automatic |Renderowanie z automatycznym kolorowaniem |
|Gray |Renderowanie ze szarym kolorowaniem |
|LightGray |Renderowanie z jasnoszarym kolorowaniem |
|InverseGray |Renderowanie z odwróconym szarym kolorowaniem |
|GrayWhite |Renderowanie ze szarym i białym kolorowaniem |
|BlackGray |Renderowanie z czarnym i szarym kolorowaniem |
|BlackWhite |Renderowanie z czarnym i białym kolorowaniem |
|Black |Renderowanie wyłącznie czarnym kolorem |
|White |Renderowanie białym kolorem |
|Hidden |Brak renderowania |
|NotDefined |oznacza, że właściwość nie jest ustawiona |
#### **Dodano właściwość ISlide.NotesSlideManager. Właściwość ISlide.NotesSlide i metoda ISlide.AddNotesSlide() zostały oznaczone jako przestarzałe.**
Członkowie ISlide.NotesSlide oraz ISlide.AddNotesSlide() zostali oznaczeni jako przestarzali. Użyj nowej właściwości ISlide.NotesSlideManager zamiast nich.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - przestarzałe

// notes = slide.NotesSlide; - przestarzałe

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```