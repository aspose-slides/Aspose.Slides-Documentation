---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.6.0
linktitle: Aspose.Slides för .NET 15.6.0
type: docs
weight: 170
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som införts med Aspose.Slides för .NET 15.6.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
#### **DataLabel‑konstruktorsignatur har ändrats**
DataLabel‑konstruktorsignaturen har ändrats:
var: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nu: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Medlemmarna IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) har markerats som föråldrade och deras ersättningar har införts istället.**
Egenskapen IDocumentProperties.Count och metoderna IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) har markerats som föråldrade. Egenskapen IDocumentProperties.CountOfCustomProperties och metoderna IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) har lagts till istället.
#### **Metod INotesSlideManager.RemoveNotesSlide() har lagts till**
Metoden INotesSlideManager.RemoveNotesSlide() har lagts till för att ta bort anteckningsbilden för en viss bild.
#### **Metod Remove har lagts till i IComment**
Metoden IComment.Remove har lagts till för att ta bort en kommentar från samlingen.
#### **Metod Remove har lagts till i ICommentAuthor**
Metoden ICommentAuthor.Remove har lagts till för att ta bort en författare av kommentarer från samlingen.
#### **Metoderna ClearCustomProperties och ClearBuiltInProperties har lagts till i IDocumentProperties**
Metoden IDocumentProperties.ClearCustomProperties har lagts till för att ta bort alla anpassade dokumentegenskaper.
Metoden IDocumentProperties.ClearBuiltInProperties har lagts till för att ta bort och återställa standardvärden för alla inbyggda dokumentegenskaper (Company, Subject, Author etc).
#### **Metoderna RemoveAt, Remove och Clear har lagts till i ICommentAuthorCollection**
Metoden ICommentAuthorCollection.RemoveAt har lagts till för att ta bort en författare på angivet index.
Metoden ICommentAuthorCollection.Remove har lagts till för att ta bort en specificerad författare från samlingen.
Metoden ICommentAuthorCollection.Clear har lagts till för att ta bort alla objekt från samlingen.
#### **Egenskapen AppVersion har lagts till i IDocumentProperties**
Egenskapen IDocumentProperties.AppVersion har lagts till för att hämta den inbyggda dokumentegenskapen som representerar interna versionsnummer som Microsoft använder under utveckling.
#### **Egenskapen BlackWhiteMode har lagts till i IShape och i Shape**
Egenskapen BlackWhiteMode har lagts till i IShape och i Shape.

Denna egenskap specificerar hur en form ska renderas i svart‑vita visningsläge.

|**Värde** |**Betydelse** |
| :- | :- |
|Color |Rendera med normal färgning |
|Automatic |Rendera med automatisk färgning |
|Gray |Rendera med grå färgning |
|LightGray |Rendera med ljusgrå färgning |
|InverseGray |Rendera med inverterad grå färgning |
|GrayWhite |Rendera med grå och vit färgning |
|BlackGray |Rendera med svart och grå färgning |
|BlackWhite |Rendera med svart och vit färgning |
|Black |Rendera endast med svart färgning |
|White |Rendera med vit färgning |
|Hidden |Inte renderad |
|NotDefined |betyder att egenskapen inte är satt |
#### **Egenskapen ISlide.NotesSlideManager har lagts till. Egenskapen ISlide.NotesSlide och metod ISlide.AddNotesSlide() har markerats som föråldrade.**
ISlide.NotesSlide och ISlide.AddNotesSlide() har markerats som föråldrade. Använd den nya egenskapen ISlide.NotesSlideManager istället.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - föråldrad
    // notes = slide.NotesSlide; - föråldrad

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```