---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides for .NET 15.6.0
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migracja
- kod przestarzały
- nowoczesny kod
- przestarzałe podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klasy, metody, właściwości i tak dalej, a także inne zmiany wprowadzone w API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Public API Changes**
#### **DataLabel Constructor Signature Has Been Changed**
Podpis konstruktora DataLabel został zmieniony:
było: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
jest: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Have Been Marked as Obsolete and Its Substitutions Have Been Introduced Instead.**
Właściwość IDocumentProperties.Count oraz metody IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) zostały oznaczone jako przestarzałe. Zostały dodane zamiast nich właściwość IDocumentProperties.CountOfCustomProperties oraz metody IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Method INotesSlideManager.RemoveNotesSlide() Has Been Added**
Dodano metodę INotesSlideManager.RemoveNotesSlide() umożliwiającą usunięcie notatki ze slajdu.
#### **Method Remove Has Been Added to IComment**
Do interfejsu IComment dodano metodę Remove służącą do usuwania komentarza z kolekcji.
#### **Method Remove Has Been Added to ICommentAuthor**
Do interfejsu ICommentAuthor dodano metodę Remove służącą do usuwania autora komentarzy z kolekcji.
#### **Methods ClearCustomProperties and ClearBuiltInProperties Have Been Added to IDocumentProperties**
Do IDocumentProperties dodano metodę ClearCustomProperties umożliwiającą usunięcie wszystkich własnych właściwości dokumentu.
Do IDocumentProperties dodano metodę ClearBuiltInProperties umożliwiającą usunięcie i przywrócenie domyślnych wartości wszystkich wbudowanych właściwości dokumentu (Company, Subject, Author itp.).
#### **Methods RemoveAt, Remove and Clear Have Been Added to ICommentAuthorCollection**
Do ICommentAuthorCollection dodano metodę RemoveAt umożliwiającą usunięcie autora o podanym indeksie.
Do ICommentAuthorCollection dodano metodę Remove umożliwiającą usunięcie określonego autora z kolekcji.
Do ICommentAuthorCollection dodano metodę Clear umożliwiającą usunięcie wszystkich elementów z kolekcji.
#### **Property AppVersion Has Been Added to IDocumentProperties**
Do IDocumentProperties dodano właściwość AppVersion umożliwiającą pobranie wbudowanej właściwości dokumentu, która reprezentuje wewnętrzne numery wersji używane przez Microsoft podczas rozwoju.
#### **Property BlackWhiteMode Has Been Added to IShape and to Shape**
Do IShape oraz Shape dodano właściwość BlackWhiteMode.

Ta właściwość określa, jak kształt będzie renderowany w trybie czarno‑biały.

|**Value**|**Meaning**|
| :- | :- |
|Color|Render with normal coloring|
|Automatic|Render with automatic coloring|
|Gray|Render with gray coloring|
|LightGray|Render with light gray coloring|
|InverseGray|Render with inverse gray coloring|
|GrayWhite|Render with gray and white coloring|
|BlackGray|Render with black and gray coloring|
|BlackWhite|Render with black and white coloring|
|Black|Render only with black coloring|
|White|Render with white coloring|
|Hidden|Not render|
|NotDefined|means that property isn't set|
#### **Property ISlide.NotesSlideManager Has Been Added. Property ISlide.NotesSlide and Method ISlide.AddNotesSlide() Have Been Marked as Obsolete.**
Członkowie ISlide.NotesSlide oraz ISlide.AddNotesSlide() zostali oznaczeni jako przestarzali. Należy używać nowej właściwości ISlide.NotesSlideManager.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - przestarzałe
    // notes = slide.NotesSlide; - przestarzałe

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```