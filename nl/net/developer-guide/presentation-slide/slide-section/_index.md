---
title: Beheer dia‑secties in presentaties in .NET
linktitle: Dia‑sectie
type: docs
weight: 100
url: /nl/net/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- sectiedia’s ophalen
- sectiedia’s verwerken
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer dia‑secties met Aspose.Slides voor .NET: maak, hernoem, herschik, haal op en verwerk sectiedia’s in PPTX‑presentaties."
---
## **Inleiding**

Secties organiseren opeenvolgende dia’s in benoemde groepen zonder de dia‑inhoud te wijzigen. Met Aspose.Slides voor .NET kun je secties maken, herschikken, hernoemen, inspecteren en verwijderen via de [Presentation.Sections](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sections/) eigenschap.

Secties zijn vooral handig wanneer:

- een grote presentatie moet worden opgesplitst in logische onderwerpen of hoofdstukken;
- verschillende groepen dia’s worden toegewezen aan verschillende medewerkers;
- dia’s moeten worden verwerkt, verplaatst of samengevoegd als groepen.

Kies beknopte sectienamen die het doel van de gegroepeerde dia’s beschrijven. Omdat secties deel uitmaken van de presentatiestructuur, gebruik de sectie‑API’s om lidmaatschap te bepalen in plaats van dit af te leiden van de positie van dia’s.

## **Secties maken en beheren**

Gebruik [ISectionCollection.AddSection](https://reference.aspose.com/slides/nl/net/aspose.slides/sectioncollection/addsection/) om een sectie te maken door de naam en de begindia op te geven. Aspose.Slides bepaalt welke dia’s tot de sectie behoren op basis van de huidige sectiestructuur van de presentatie.

Dezelfde [ISectionCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isectioncollection/) laat je ook:

- een sectie samen met de bijbehorende dia’s verplaatsen met [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- alleen de sectiedefinitie verwijderen met [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/nl/net/aspose.slides/sectioncollection/removesection/), waardoor de dia’s behouden blijven;
- een sectie en de bijbehorende dia’s verwijderen met [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/sectioncollection/removesectionwithslides/);
- een lege sectie aan het einde toevoegen met [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/nl/net/aspose.slides/sectioncollection/appendemptysection/).

Het volgende voorbeeld maakt twee secties, verplaatst er één, verwijdert die samen met de dia’s, en voegt een lege sectie toe:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Na deze bewerkingen bevat de presentatie de `Introduction`‑sectie met de bijbehorende dia’s en een lege `Appendix`‑sectie. De `Results`‑sectie en de bijbehorende dia’s zijn verwijderd.

## **Secties hernoemen**

Om een sectie te hernoemen, stel je de [ISection.Name](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/name/) eigenschap in. De dia’s en de positie van de sectie blijven ongewijzigd.

Het volgende voorbeeld maakt een sectie en verandert de naam:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Dia’s ophalen uit secties**

De [Presentation.Sections](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sections/) eigenschap geeft een [ISectionCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isectioncollection/) terug die je kunt enumereren. Voor elke [ISection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/) roep je [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/getslideslistofsection/) aan om de dia’s te verkrijgen die momenteel tot die sectie behoren. De methode retourneert een [ISectionSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isectionslidecollection/), die een telling, index‑toegang en enumeratie biedt.

Het volgende voorbeeld maakt twee gevulde secties en één lege sectie, en drukt vervolgens voor elke sectie de [name](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/startedfromslide/), het aantal dia’s en de dianummers af. Het gebruikt de collectie‑indexer om de eerste dia te lezen en `foreach` om elke dia te verwerken. Voor de lege sectie heeft de geretourneerde collectie een telling van nul, wordt de indexer niet benaderd en voert de enumeratie geen iteraties uit.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Sectielidmaatschap wordt bepaald door de sectiestructuur van de presentatie. Bereken de bereik‑waarde van een sectie niet handmatig op basis van [ISection.StartedFromSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/startedfromslide/), dia‑indexen en de begindia van de volgende sectie.

Structurele bewerkingen kunnen zowel de teruggegeven dia’s voor een sectie als hun dianummers wijzigen. Dit omvat het herschikken van dia’s, een dia klonen naar een sectie, een sectie samen met de dia’s verplaatsen, dia’s verwijderen en secties verwijderen. Het volgende voorbeeld roept [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/getslideslistofsection/) aan na elke dergelijke wijziging in plaats van veronderstellingen over de eerdere grenzen van de sectie te behouden.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Roep [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/getslideslistofsection/) opnieuw aan wanneer dia’s of secties worden herschikt, gekloond, verplaatst of verwijderd. Dit houdt latere verwerking in overeenstemming met de huidige presentatiestructuur.

Het PPT‑formaat (PowerPoint 97–2003) behoudt geen sectiemetadata. Gebruik deze workflow met een formaat dat secties ondersteunt, zoals PPTX; bij conversie naar PPT gaat de sectiestructuur verloren die nodig is voor latere enumeratie.

## **FAQ**

**Worden secties behouden bij opslaan naar het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een volledige sectie “verborgen” worden?**

Nee. Een sectie heeft geen zichtbaarheidstoestand. Om de inhoud te verbergen, stel je de [ISlide.Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/hidden/) eigenschap in voor elke dia in de sectie.

**Hoe kan ik de sectie vinden die een bepaalde dia bevat?**

Enumereer [Presentation.Sections](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sections/), roep voor elke sectie [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/getslideslistofsection/) aan en vergelijk de geretourneerde dia’s met de doel‑dia. Voor een niet‑lege sectie geeft [ISection.StartedFromSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/isection/startedfromslide/) de eerste dia terug; voor een lege sectie wordt `null` geretourneerd.