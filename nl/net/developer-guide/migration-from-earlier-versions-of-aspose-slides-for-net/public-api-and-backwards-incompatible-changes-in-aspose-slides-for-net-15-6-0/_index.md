---
title: Openbare API en terugwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.6.0
linktitle: Aspose.Slides voor .NET 15.6.0
type: docs
weight: 170
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) klassen, methoden, eigenschappen enzovoort weer, evenals andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **DataLabel Constructor Signature Has Been Changed**
De handtekening van de DataLabel‑constructor is gewijzigd:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
nu: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Have Been Marked as Obsolete and Its Substitutions Have Been Introduced Instead.**
De eigenschap IDocumentProperties.Count en de methoden IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) zijn gemarkeerd als verouderd. De eigenschap IDocumentProperties.CountOfCustomProperties en de methoden IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) zijn in de plaats toegevoegd.
#### **Method INotesSlideManager.RemoveNotesSlide() Has Been Added**
De methode INotesSlideManager.RemoveNotesSlide() is toegevoegd om de notitieslide van een slide te verwijderen.
#### **Method Remove Has Been Added to IComment**
De methode IComment.Remove is toegevoegd om een opmerking uit de collectie te verwijderen.
#### **Method Remove Has Been Added to ICommentAuthor**
De methode ICommentAuthor.Remove is toegevoegd om de auteur van opmerkingen uit de collectie te verwijderen.
#### **Methods ClearCustomProperties and ClearBuiltInProperties Have Been Added to IDocumentProperties**
De methode IDocumentProperties.ClearCustomProperties is toegevoegd om alle aangepaste documenteigenschappen te verwijderen.
De methode IDocumentProperties.ClearBuiltInProperties is toegevoegd om alle ingebouwde documenteigenschappen (Company, Subject, Author etc.) te verwijderen en de standaardwaarden in te stellen.
#### **Methods RemoveAt, Remove and Clear Have Been Added to ICommentAuthorCollection**
De methode ICommentAuthorCollection.RemoveAt is toegevoegd om een auteur te verwijderen op basis van een opgegeven index.
De methode ICommentAuthorCollection.Remove is toegevoegd om een opgegeven auteur uit de collectie te verwijderen.
De methode ICommentAuthorCollection.Clear is toegevoegd om alle items uit de collectie te verwijderen.
#### **Property AppVersion Has Been Added to IDocumentProperties**
De eigenschap IDocumentProperties.AppVersion is toegevoegd om de ingebouwde documenteigenschap op te halen die interne versienummers van Microsoft tijdens de ontwikkeling vertegenwoordigt.
#### **Property BlackWhiteMode Has Been Added to IShape and to Shape**
De eigenschap BlackWhiteMode is toegevoegd aan IShape en aan Shape.

Deze eigenschap bepaalt hoe een vorm wordt weergegeven in de zwart‑wit modus.

|**Value** |**Meaning** |
| :- | :- |
|Color |Weergegeven met normale kleuring |
|Automatic |Weergegeven met automatische kleuring |
|Gray |Weergegeven met grauwe kleuring |
|LightGray |Weergegeven met lichtgrijze kleuring |
|InverseGray |Weergegeven met inverse grauwe kleuring |
|GrayWhite |Weergegeven met grijze en witte kleuring |
|BlackGray |Weergegeven met zwarte en grauwe kleuring |
|BlackWhite |Weergegeven met zwarte en witte kleuring |
|Black |Alleen weergegeven met zwarte kleuring |
|White |Weergegeven met witte kleuring |
|Hidden |Niet weergegeven |
|NotDefined |betekent dat de eigenschap niet is ingesteld|
#### **Рroperty ISlide.NotesSlideManager Has Been Added. Property ISlide.NotesSlide and Method ISlide.AddNotesSlide() Have Been Marked as Obsolete.**
De leden ISlide.NotesSlide en ISlide.AddNotesSlide() zijn gemarkeerd als verouderd. Gebruik in plaats daarvan de nieuwe eigenschap ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - verouderd

// notes = slide.NotesSlide; - verouderd

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```