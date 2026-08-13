---
title: Nyilvános API és visszafelé inkompatibilis változások az Aspose.Slides for .NET 15.6.0-ban
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafogó változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes hozzáadott vagy eltávolított osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.6.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
#### **A DataLabel konstruktor aláírása megváltozott**
A DataLabel konstruktor aláírása megváltozott:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Az IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) tagok elavultként lettek megjelölve, és helyettük helyettesítők kerültek bevezetésre.**
Az IDocumentProperties.Count tulajdonság és az IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) metódusok elavultként lettek megjelölve. Az IDocumentProperties.CountOfCustomProperties tulajdonság és az IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) metódusok lettek hozzáadva helyettük.
#### **Az INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva**
Az INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva egy diára vonatkozó jegyzet dia eltávolításához.
#### **Az IComment-hez hozzá lett adva a Remove metódus**
Az IComment.Remove metódus hozzá lett adva a megjegyzés a gyűjteményből való eltávolításához.
#### **Az ICommentAuthor-hez hozzá lett adva a Remove metódus**
Az ICommentAuthor.Remove metódus hozzá lett adva a megjegyzések szerzőjének a gyűjteményből való eltávolításához.
#### **Az IDocumentProperties-hez hozzá lettek adva a ClearCustomProperties és a ClearBuiltInProperties metódusok**
Az IDocumentProperties.ClearCustomProperties metódus hozzá lett adva az összes egyéni dokumentumtulajdonság eltávolításához.
Az IDocumentProperties.ClearBuiltInProperties metódus hozzá lett adva az összes beépített dokumentumtulajdonság (Company, Subject, Author stb.) eltávolításához és alapértelmezett értékek beállításához.
#### **Az ICommentAuthorCollection-hez hozzá lettek adva a RemoveAt, Remove és Clear metódusok**
Az ICommentAuthorCollection.RemoveAt metódus hozzá lett adva a szerző a megadott index alapján történő eltávolításához.
Az ICommentAuthorCollection.Remove metódus hozzá lett adva a megadott szerző eltávolításához a gyűjteményből.
Az ICommentAuthorCollection.Clear metódus hozzá lett adva a gyűjtemény összes elemének eltávolításához.
#### **Az IDocumentProperties-hez hozzá lett adva az AppVersion tulajdonság**
Az IDocumentProperties.AppVersion tulajdonság hozzá lett adva a beépített dokumentumtulajdonság lekéréséhez, amely a Microsoft fejlesztés során használt belső verziószámokat képviseli.
#### **A BlackWhiteMode tulajdonság hozzá lett adva az IShape-hez és a Shape-hez**
A BlackWhiteMode tulajdonság hozzá lett adva az IShape-hez és a Shape-hez.

Ez a tulajdonság meghatározza, hogyan jelenik meg egy alakzat fekete-fehér megjelenítési módban.

|**Érték** |**Jelentés** |
| :- | :- |
|Color |Normál színezéssel megjelenít |
|Automatic |Automatikus színezéssel megjelenít |
|Gray |Szürke színezéssel megjelenít |
|LightGray |Világosszürke színezéssel megjelenít |
|InverseGray |Inverz szürke színezéssel megjelenít |
|GrayWhite |Szürke és fehér színezéssel megjelenít |
|BlackGray |Fekete és szürke színezéssel megjelenít |
|BlackWhite |Fekete-fehér színezéssel megjelenít |
|Black |Csak fekete színnel jelenik meg |
|White |Fehér színnel jelenik meg |
|Hidden |Nem jelenik meg |
|NotDefined|jelenti, hogy a tulajdonság nincs beállítva|
#### **Az ISlide.NotesSlideManager tulajdonság hozzá lett adva. Az ISlide.NotesSlide és az ISlide.AddNotesSlide() metódusok elavultként lettek megjelölve.**
Az ISlide.NotesSlide és az ISlide.AddNotesSlide() tagok elavultként lettek megjelölve. Használja helyettük az új ISlide.NotesSlideManager tulajdonságot.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - elavult
    // notes = slide.NotesSlide; - elavult

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```