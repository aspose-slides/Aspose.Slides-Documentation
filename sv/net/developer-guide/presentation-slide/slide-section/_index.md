---
title: Hantera bildavsnitt i presentationer i .NET
linktitle: Bildavsnitt
type: docs
weight: 100
url: /sv/net/slide-section/
keywords:
- skapa avsnitt
- lägga till avsnitt
- redigera avsnitt
- ändra avsnitt
- avsnittsnamn
- hämta avsnittsbilder
- bearbeta avsnittsbilder
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera bildavsnitt med Aspose.Slides för .NET: skapa, byta namn, ändra ordning, hämta och bearbeta avsnittsbilder i PPTX-presentationer."
---
## **Introduktion**

Avsnitt organiserar på varandra följande bilder i namngivna grupper utan att ändra bildinnehållet. Med Aspose.Slides för .NET kan du skapa, ändra ordning, byta namn, inspektera och ta bort avsnitt via egenskapen [Presentation.Sections](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sections/).

Avsnitt är särskilt användbara när:

- en stor presentation behöver delas upp i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder måste bearbetas, flyttas eller slås samman som grupper.

Välj korta avsnittsnamn som beskriver syftet med de grupperade bilderna. Eftersom avsnitt är en del av presentationsstrukturen bör du använda avsnitt‑API:erna för att bestämma medlemskap i stället för att härleda det från bildpositioner.

## **Skapa och hantera avsnitt**

Använd [ISectionCollection.AddSection](https://reference.aspose.com/slides/sv/net/aspose.slides/sectioncollection/addsection/) för att skapa ett avsnitt genom att ange dess namn och startbild. Aspose.Slides bestämmer vilka bilder som tillhör avsnittet utifrån presentationens aktuella avsnittsstruktur.

Samma [ISectionCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isectioncollection/) låter dig också:

- flytta ett avsnitt tillsammans med dess bilder genom att använda [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- ta bara bort avsnittdefinitionen med [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/sv/net/aspose.slides/sectioncollection/removesection/), vilket behåller dess bilder;
- ta bort ett avsnitt och dess bilder med [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/sectioncollection/removesectionwithslides/);
- lägga till ett tomt avsnitt i slutet med [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/sv/net/aspose.slides/sectioncollection/appendemptysection/).

Följande exempel skapar två avsnitt, flyttar ett av dem, tar bort det tillsammans med dess bilder och lägger till ett tomt avsnitt:

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

Efter dessa operationer innehåller presentationen `Introduction`‑avsnittet med dess bilder och ett tomt `Appendix`‑avsnitt. `Results`‑avsnittet och dess bilder har tagits bort.

## **Byta namn på avsnitt**

För att byta namn på ett avsnitt, sätt dess egenskap [ISection.Name](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/name/). Avsnittets bilder och position förblir oförändrade.

Följande exempel skapar ett avsnitt och ändrar dess namn:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Hämta bilder från avsnitt**

Egenskapen [Presentation.Sections](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sections/) returnerar en [ISectionCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isectioncollection/) som du kan enumerera. För varje [ISection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/), anropa [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/getslideslistofsection/) för att hämta de bilder som för närvarande tillhör den. Metoden returnerar en [ISectionSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isectionslidecollection/), som tillhandahåller ett antal, indexerad åtkomst och enumeration.

Följande exempel skapar två fyllda avsnitt och ett tomt avsnitt, och skriver sedan ut varje avsnitts [namn](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/name/), [identifierare](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/sectionid/), [startbild](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/startedfromslide/), bildantal och bildnummer. Det använder samlings‑indexeraren för att läsa den första bilden och `foreach` för att bearbeta varje bild. För det tomma avsnittet har den returnerade samlingen ett antal på noll, indexeraren nås inte och enumerationen utför inga iterationer.

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

Avsnittstillhörighet bestäms av presentationens avsnittsstruktur. Beräkna inte ett avsnitts intervall manuellt från [ISection.StartedFromSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/startedfromslide/), bildindex och nästa avsnitts startbild.

Strukturella redigeringar kan ändra både de bilder som returneras för ett avsnitt och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till ett avsnitt, flytt av ett avsnitt tillsammans med dess bilder, borttagning av bilder samt borttagning av avsnitt. Nästa exempel anropar [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/getslideslistofsection/) efter varje sådan förändring i stället för att behålla antaganden om avsnittets tidigare gränser.

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

Anropa [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/getslideslistofsection/) igen när bilder eller avsnitt omordnas, klonas, flyttas eller tas bort. Detta säkerställer att efterföljande bearbetning är i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte avsnittmetadata. Använd detta arbetsflöde med ett format som stödjer avsnitt, till exempel PPTX; konvertering till PPT tar bort den avsnittsstruktur som behövs för senare enumeration.

## **FAQ**

**Behålls avsnitt när de sparas till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT‑formatet stödjer inte avsnittmetadata, så avsnittsgruppning går förlorad när du sparar till .ppt.

**Kan ett helt avsnitt "döljas"?**

Nej. Ett avsnitt har inget synlighetstillstånd. För att dölja dess innehåll, sätt egenskapen [ISlide.Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/hidden/) för varje bild i avsnittet.

**Hur kan jag hitta avsnittet som innehåller en bild?**

Enumerera [Presentation.Sections](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sections/), anropa [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/getslideslistofsection/) för varje avsnitt och jämför de returnerade bilderna med målbilden. För ett icke‑tomt avsnitt returnerar [ISection.StartedFromSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/isection/startedfromslide/) dess första bild; för ett tomt avsnitt returneras `null`.