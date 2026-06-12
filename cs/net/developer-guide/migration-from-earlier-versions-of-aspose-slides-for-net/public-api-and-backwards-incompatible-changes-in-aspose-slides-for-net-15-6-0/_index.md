---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.6.0
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
description: "Prohlédněte si aktualizace veřejného API a breaking changes v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) nebo [odebrané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 15.6.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Signatura konstruktoru DataLabel byla změněna**
Signatura konstruktoru DataLabel byla změněna:
byla: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nyní: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Členové IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) byli označeni jako zastaralí a byly zavedeny jejich náhrady.**
Vlastnost IDocumentProperties.Count a metody IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) byly označeny jako zastaralé. Byla přidána vlastnost IDocumentProperties.CountOfCustomProperties a metody IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Metoda INotesSlideManager.RemoveNotesSlide() byla přidána**
Metoda INotesSlideManager.RemoveNotesSlide() byla přidána pro odebrání poznámkové snímky některého snímku.
#### **Metoda Remove byla přidána do IComment**
Metoda IComment.Remove byla přidána pro odebrání komentáře ze sbírky.
#### **Metoda Remove byla přidána do ICommentAuthor**
Metoda ICommentAuthor.Remove byla přidána pro odebrání autora komentářů ze sbírky.
#### **Metody ClearCustomProperties a ClearBuiltInProperties byly přidány do IDocumentProperties**
Metoda IDocumentProperties.ClearCustomProperties byla přidána pro odebrání všech vlastních vlastností dokumentu.
Metoda IDocumentProperties.ClearBuiltInProperties byla přidána pro odebrání a nastavení výchozích hodnot pro všechny vestavěné vlastnosti dokumentu (Company, Subject, Author atd.).
#### **Metody RemoveAt, Remove a Clear byly přidány do ICommentAuthorCollection**
Metoda ICommentAuthorCollection.RemoveAt byla přidána pro odebrání autora podle zadaného indexu.
Metoda ICommentAuthorCollection.Remove byla přidána pro odebrání určeného autora ze sbírky.
Metoda ICommentAuthorCollection.Clear byla přidána pro odebrání všech položek ze sbírky.
#### **Vlastnost AppVersion byla přidána do IDocumentProperties**
Vlastnost IDocumentProperties.AppVersion byla přidána pro získání vestavěné vlastnosti dokumentu, která představuje interní čísla verzí používaná Microsoftem během vývoje.
#### **Vlastnost BlackWhiteMode byla přidána do IShape a do Shape**
Vlastnost BlackWhiteMode byla přidána do IShape a do Shape.

Tato vlastnost určuje, jak bude tvar vykreslen v režimu černobílého zobrazení.

|**Hodnota** |**Význam** |
| :- | :- |
|Color |Vykreslí se normálním zbarvením |
|Automatic |Vykreslí se automatickým zbarvením |
|Gray |Vykreslí se šedým zbarvením |
|LightGray |Vykreslí se světle šedým zbarvením |
|InverseGray |Vykreslí se inverzně šedým zbarvením |
|GrayWhite |Vykreslí se šedobílým zbarvením |
|BlackGray |Vykreslí se černo-šedým zbarvením |
|BlackWhite |Vykreslí se černo-bílým zbarvením |
|Black |Vykreslí se pouze černým zbarvením |
|White |Vykreslí se bílým zbarvením |
|Hidden |Nevykreslí se |
|NotDefined|znamená, že vlastnost není nastavena|
#### **Vlastnost ISlide.NotesSlideManager byla přidána. Vlastnost ISlide.NotesSlide a metoda ISlide.AddNotesSlide() byly označeny jako zastaralé.**
Členové ISlide.NotesSlide, ISlide.AddNotesSlide() byli označeni jako zastaralí. Použijte novou vlastnost ISlide.NotesSlideManager místo nich.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - zastaralé

// notes = slide.NotesSlide; - zastaralé

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```