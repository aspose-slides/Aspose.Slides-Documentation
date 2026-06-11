---
title: Publikt API och bakåtinkompatibla ändringar i Aspose.Slides för .NET 15.6.0
linktitle: Aspose.Slides för .NET 15.6.0
type: docs
weight: 170
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal strategi
- modern strategi
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Gå igenom offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som introducerats med Aspose.Slides för .NET 15.6.0 API.

{{% /alert %}} 
## **Ändringar i publikt API**
#### **DataLabel-konstruktorsignatur har ändrats**
DataLabel-konstruktorsignatur har ändrats:
var: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nu: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Medlemmarna IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) har markerats som föråldrade och deras ersättningar har införts istället.**
Egenskapen IDocumentProperties.Count och metoderna IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) har markerats som föråldrade. Egenskapen IDocumentProperties.CountOfCustomProperties och metoderna IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) har lagts till istället.
#### **Metod INotesSlideManager.RemoveNotesSlide() har lagts till**
Metod INotesSlideManager.RemoveNotesSlide() har lagts till för att ta bort anteckningsbilden för en viss bild.
#### **Metod Remove har lagts till i IComment**
Metod IComment.Remove har lagts till för att ta bort en kommentar från samlingen.
#### **Metod Remove har lagts till i ICommentAuthor**
Metod ICommentAuthor.Remove har lagts till för att ta bort en författare av kommentarer från samlingen.
#### **Metoderna ClearCustomProperties och ClearBuiltInProperties har lagts till i IDocumentProperties**
Metod IDocumentProperties.ClearCustomProperties har lagts till för att ta bort alla anpassade dokumentegenskaper.
Metod IDocumentProperties.ClearBuiltInProperties har lagts till för att ta bort och återställa standardvärden för alla inbyggda dokumentegenskaper (Company, Subject, Author etc).
#### **Metoderna RemoveAt, Remove och Clear har lagts till i ICommentAuthorCollection**
Metod ICommentAuthorCollection.RemoveAt har lagts till för att ta bort en författare på angivet index.
Metod ICommentAuthorCollection.Remove har lagts till för att ta bort angiven författare från samlingen.
Metod ICommentAuthorCollection.Clear har lagts till för att ta bort alla objekt från samlingen.
#### **Egenskap AppVersion har lagts till i IDocumentProperties**
Egenskap IDocumentProperties.AppVersion har lagts till för att hämta den inbyggda dokumentegenskapen som representerar interna versionsnummer som Microsoft använder under utveckling.
#### **Egenskap BlackWhiteMode har lagts till i IShape och i Shape**
Egenskap BlackWhiteMode har lagts till i IShape och i Shape.

Denna egenskap specificerar hur en form ska renderas i svart‑vitt läge.

|**Värde** |**Betydelse** |
| :- | :- |
|Color |Rendera med normal färgning |
|Automatic |Rendera med automatisk färgning |
|Gray |Rendera med grå färgning |
|LightGray |Rendera med ljusgrå färgning |
|InverseGray |Rendera med omvänd grå färgning |
|GrayWhite |Rendera med grå och vit färgning |
|BlackGray |Rendera med svart och grå färgning |
|BlackWhite |Rendera med svart och vit färgning |
|Black |Rendera endast med svart färgning |
|White |Rendera med vit färgning |
|Hidden |Renderas ej |
|NotDefined|betyder att egenskapen inte är angiven|
#### **Egenskap ISlide.NotesSlideManager har lagts till. Egenskapen ISlide.NotesSlide och metoden ISlide.AddNotesSlide() har markerats som föråldrade.**
Medlemmarna ISlide.NotesSlide, ISlide.AddNotesSlide() har markerats som föråldrade. Använd den nya egenskapen ISlide.NotesSlideManager istället.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - föråldrad

// notes = slide.NotesSlide; - föråldrad

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```