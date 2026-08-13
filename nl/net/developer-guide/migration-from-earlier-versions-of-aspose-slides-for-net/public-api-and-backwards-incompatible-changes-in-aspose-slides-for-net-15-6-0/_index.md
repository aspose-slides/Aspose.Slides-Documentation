---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.6.0
linktitle: Aspose.Slides voor .NET 15.6.0
type: docs
weight: 170
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatie‑oplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klassen, methoden, eigenschappen enz., en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Signature van de DataLabel-constructor is gewijzigd**
De signatuur van de DataLabel-constructor is gewijzigd:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nu: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **De leden IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name) en .Contains(string name) zijn gemarkeerd als verouderd en hun vervangingen zijn geïntroduceerd**
De eigenschap IDocumentProperties.Count en de methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name) en .Contains(string name) zijn gemarkeerd als verouderd. De eigenschap IDocumentProperties.CountOfCustomProperties en de methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name) en .ContainsCustomProperty(string name) zijn toegevoegd als vervanging.
#### **Methode INotesSlideManager.RemoveNotesSlide() is toegevoegd**
Methode INotesSlideManager.RemoveNotesSlide() is toegevoegd om een notitie‑dia van een dia te verwijderen.
#### **Methode Remove is toegevoegd aan IComment**
Methode IComment.Remove is toegevoegd om een opmerking uit de verzameling te verwijderen.
#### **Methode Remove is toegevoegd aan ICommentAuthor**
Methode ICommentAuthor.Remove is toegevoegd om de auteur van commentaren uit de verzameling te verwijderen.
#### **Methoden ClearCustomProperties en ClearBuiltInProperties zijn toegevoegd aan IDocumentProperties**
Methode IDocumentProperties.ClearCustomProperties is toegevoegd om alle aangepaste documenteigenschappen te verwijderen.
Methode IDocumentProperties.ClearBuiltInProperties is toegevoegd om alle ingebouwde documenteigenschappen te verwijderen en de standaardwaarden in te stellen (Company, Subject, Author enz.).
#### **Methoden RemoveAt, Remove en Clear zijn toegevoegd aan ICommentAuthorCollection**
Methode ICommentAuthorCollection.RemoveAt is toegevoegd om een auteur te verwijderen op basis van een opgegeven index.
Methode ICommentAuthorCollection.Remove is toegevoegd om een opgegeven auteur uit de verzameling te verwijderen.
Methode ICommentAuthorCollection.Clear is toegevoegd om alle items uit de verzameling te verwijderen.
#### **Eigenschap AppVersion is toegevoegd aan IDocumentProperties**
Eigenschap IDocumentProperties.AppVersion is toegevoegd om de ingebouwde documenteigenschap op te halen die de interne versienummers van Microsoft tijdens de ontwikkeling vertegenwoordigt.
#### **Eigenschap BlackWhiteMode is toegevoegd aan IShape en aan Shape**
Eigenschap BlackWhiteMode is toegevoegd aan IShape en aan Shape.

Deze eigenschap geeft aan hoe een vorm wordt weergegeven in zwart‑wit weergavemodus.

|**Waarde** |**Betekenis** |
| :- | :- |
|Color |Weergeven met normale kleuren |
|Automatic |Weergeven met automatische kleuring |
|Gray |Weergeven met grijze kleuren |
|LightGray |Weergeven met lichtgrijze kleuren |
|InverseGray |Weergeven met omgekeerde grijze kleuren |
|GrayWhite |Weergeven met grijze en witte kleuren |
|BlackGray |Weergeven met zwarte en grijze kleuren |
|BlackWhite |Weergeven met zwarte en witte kleuren |
|Black |Alleen weergeven in zwart |
|White |Weergeven in wit |
|Hidden |Niet weergeven |
|NotDefined|betekent dat de eigenschap niet is ingesteld|
#### **Eigenschap ISlide.NotesSlideManager is toegevoegd. Eigenschap ISlide.NotesSlide en Methode ISlide.AddNotesSlide() zijn gemarkeerd als verouderd.**
De leden ISlide.NotesSlide en ISlide.AddNotesSlide() zijn gemarkeerd als verouderd. Gebruik de nieuwe eigenschap ISlide.NotesSlideManager in plaats daarvan.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - verouderd
    // notes = slide.NotesSlide; - verouderd

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```