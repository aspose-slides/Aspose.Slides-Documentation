---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro .NET 15.6.0
linktitle: Aspose.Slides pro .NET 15.6.0
type: docs
weight: 170
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zkontrolujte aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) nebo [odstraněné](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v API Aspose.Slides pro .NET 15.6.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Signatura konstruktoru DataLabel byla změněna**
Signatura konstruktoru DataLabel byla změněna:
bylo: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nyní: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Členy IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) byly označeny jako zastaralé a místo nich byly zavedeny jejich náhrady.**
Vlastnost IDocumentProperties.Count a metody IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) byly označeny jako zastaralé. Vlastnost IDocumentProperties.CountOfCustomProperties a metody IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) byly místo nich přidány.
#### **Metoda INotesSlideManager.RemoveNotesSlide() byla přidána**
Metoda INotesSlideManager.RemoveNotesSlide() byla přidána pro odebrání poznámkové snímky z některého snímku.
#### **Metoda Remove byla přidána do IComment**
Metoda IComment.Remove byla přidána pro odebrání komentáře ze sbírky.
#### **Metoda Remove byla přidána do ICommentAuthor**
Metoda ICommentAuthor.Remove byla přidána pro odebrání autora komentářů ze sbírky.
#### **Metody ClearCustomProperties a ClearBuiltInProperties byly přidány do IDocumentProperties**
Metoda IDocumentProperties.ClearCustomProperties byla přidána pro odebrání všech vlastních vlastností dokumentu.
Metoda IDocumentProperties.ClearBuiltInProperties byla přidána pro odebrání a nastavení výchozích hodnot všech vestavěných vlastností dokumentu (Company, Subject, Author atd.).
#### **Metody RemoveAt, Remove a Clear byly přidány do ICommentAuthorCollection**
Metoda ICommentAuthorCollection.RemoveAt byla přidána pro odebrání autora podle zadaného indexu.
Metoda ICommentAuthorCollection.Remove byla přidána pro odebrání určeného autora ze sbírky.
Metoda ICommentAuthorCollection.Clear byla přidána pro odebrání všech položek ze sbírky.
#### **Vlastnost AppVersion byla přidána do IDocumentProperties**
Vlastnost IDocumentProperties.AppVersion byla přidána pro získání vestavěné vlastnosti dokumentu, která představuje interní čísla verzí používaná společností Microsoft během vývoje.
#### **Vlastnost BlackWhiteMode byla přidána do IShape i do Shape**
Vlastnost BlackWhiteMode byla přidána do IShape i do Shape.

Tato vlastnost určuje, jak bude tvar vykreslen v režimu černobílého zobrazení.

|**Hodnota** |**Význam** |
| :- | :- |
|Color |Render with normal coloring |
|Automatic |Render with automatic coloring |
|Gray |Render with gray coloring |
|LightGray |Render with light gray coloring |
|InverseGray |Render with inverse gray coloring |
|GrayWhite |Render with gray and white coloring |
|BlackGray |Render with black and gray coloring |
|BlackWhite |Render with black and white coloring |
|Black |Render only with black coloring |
|White |Render with white coloring |
|Hidden |Not render |
|NotDefined|means that property isn't set|
#### **Vlastnost ISlide.NotesSlideManager byla přidána. Vlastnost ISlide.NotesSlide a metoda ISlide.AddNotesSlide() byly označeny jako zastaralé.**
Členové ISlide.NotesSlide, ISlide.AddNotesSlide() byly označeny jako zastaralé. Použijte novou vlastnost ISlide.NotesSlideManager místo nich.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - zastaralé
    // notes = slide.NotesSlide; - zastaralé

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```