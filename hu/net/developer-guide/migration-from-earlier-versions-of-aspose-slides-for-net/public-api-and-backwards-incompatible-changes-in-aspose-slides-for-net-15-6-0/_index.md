---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.6.0-ban
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
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) osztályt, metódust, tulajdonságot és hasonlókat, valamint a Aspose.Slides for .NET 15.6.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API változások**
#### **A DataLabel konstruktor aláírása megváltozott**
A DataLabel konstruktor aláírása megváltozott:
régi: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
új: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Az IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) tagok elavulttá lettek jelölve, és helyettük helyettesítők kerültek bevezetésre.**
Az IDocumentProperties.Count tulajdonság és az IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) metódusok elavulttá lettek jelölve. Helyettük hozzá lett adva az IDocumentProperties.CountOfCustomProperties tulajdonság és az IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) metódusok.
#### **Az INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva**
Az INotesSlideManager.RemoveNotesSlide() metódus hozzá lett adva egy dia jegyzetdiájának eltávolításához.
#### **Az Remove metódus hozzá lett adva az IComment-hez**
Az IComment.Remove metódus hozzá lett adva a megjegyzés a gyűjteményből való eltávolításához.
#### **Az Remove metódus hozzá lett adva az ICommentAuthor-hoz**
Az ICommentAuthor.Remove metódus hozzá lett adva a megjegyzés szerzőjének a gyűjteményből való eltávolításához.
#### **A ClearCustomProperties és a ClearBuiltInProperties metódusok hozzá lettek adva az IDocumentProperties-hez**
Az IDocumentProperties.ClearCustomProperties metódus hozzá lett adva az összes egyedi dokumentumtulajdonság eltávolításához.
Az IDocumentProperties.ClearBuiltInProperties metódus hozzá lett adva az összes beépített dokumentumtulajdonság (Company, Subject, Author stb.) eltávolításához és alapértelmezett értékek beállításához.
#### **A RemoveAt, Remove és Clear metódusok hozzá lettek adva az ICommentAuthorCollection-hez**
Az ICommentAuthorCollection.RemoveAt metódus hozzá lett adva a megadott indexű szerző eltávolításához.
Az ICommentAuthorCollection.Remove metódus hozzá lett adva a megadott szerző a gyűjteményből való eltávolításához.
Az ICommentAuthorCollection.Clear metódus hozzá lett adva az összes elem a gyűjteményből való eltávolításához.
#### **Az AppVersion tulajdonság hozzá lett adva az IDocumentProperties-hez**
Az IDocumentProperties.AppVersion tulajdonság hozzá lett adva egy beépített dokumentumtulajdonság lekéréséhez, amely a Microsoft fejlesztés során használt belső verziószámokat képviseli.
#### **A BlackWhiteMode tulajdonság hozzá lett adva az IShape-hez és a Shape-hez**
A BlackWhiteMode tulajdonság hozzá lett adva az IShape-hez és a Shape-hez.
Ez a tulajdonság meghatározza, hogyan jelenik meg a forma fekete-fehér megjelenítési módban.

|**Érték** |**Jelentés** |
| :- | :- |
|Color |Normál színezéssel jelenik meg |
|Automatic |Automatikus színezéssel jelenik meg |
|Gray |Szürke színezéssel jelenik meg |
|LightGray |Világosszürke színezéssel jelenik meg |
|InverseGray |Inverz szürke színezéssel jelenik meg |
|GrayWhite |Szürke és fehér színezéssel jelenik meg |
|BlackGray |Fekete és szürke színezéssel jelenik meg |
|BlackWhite |Fekete és fehér színezéssel jelenik meg |
|Black |Csak fekete színezéssel jelenik meg |
|White |Fehér színezéssel jelenik meg |
|Hidden |Nem jelenik meg |
|NotDefined|azt jelenti, hogy a tulajdonság nincs beállítva |
#### **Az ISlide.NotesSlideManager tulajdonság hozzá lett adva. Az ISlide.NotesSlide és az ISlide.AddNotesSlide() metódus elavulttá lett jelölve.**
Az ISlide.NotesSlide és az ISlide.AddNotesSlide() elemek elavulttá lettek jelölve. Használja helyette az új ISlide.NotesSlideManager tulajdonságot.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - elavult

// notes = slide.NotesSlide; - elavult

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```