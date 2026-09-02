---
title: Gerenciar Seções de Slides em Apresentações no .NET
linktitle: Seção de Slide
type: docs
weight: 100
url: /pt/net/slide-section/
keywords:
- criar seção
- adicionar seção
- editar seção
- alterar seção
- nome da seção
- recuperar slides da seção
- processar slides da seção
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie seções de slides com Aspose.Slides para .NET: crie, renomeie, reorganize, recupere e processe slides de seção em apresentações PPTX."
---
## **Introdução**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for .NET, you can create, reorder, rename, inspect, and remove sections through the [Presentation.Sections](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sections/) property.

Sections are especially useful when:

- a large presentation needs to be divided into logical topics or chapters;
- different groups of slides are assigned to different collaborators;
- slides need to be processed, moved, or merged as groups.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **Criar e Gerenciar Seções**

Use [ISectionCollection.AddSection](https://reference.aspose.com/slides/pt/net/aspose.slides/sectioncollection/addsection/) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [ISectionCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isectioncollection/) also lets you:

- move a section together with its slides by using [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- remove only the section definition with [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/pt/net/aspose.slides/sectioncollection/removesection/), which retains its slides;
- remove a section and its slides with [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/sectioncollection/removesectionwithslides/);
- add an empty section at the end with [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/pt/net/aspose.slides/sectioncollection/appendemptysection/).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

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

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Renomear Seções**

To rename a section, set its [ISection.Name](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/name/) property. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Recuperar Slides de Seções**

The [Presentation.Sections](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sections/) property returns an [ISectionCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isectioncollection/) that you can enumerate. For each [ISection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/), call [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/getslideslistofsection/) to obtain the slides that currently belong to it. The method returns an [ISectionSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isectionslidecollection/), which provides a count, indexed access, and enumeration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/startedfromslide/), slide count, and slide numbers. It uses the collection indexer to read the first slide and `foreach` to process every slide. For the empty section, the returned collection has a count of zero, the indexer is not accessed, and enumeration performs no iterations.

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

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [ISection.StartedFromSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/startedfromslide/), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/getslideslistofsection/) after every such change instead of retaining assumptions about the section's former boundaries.

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

Call [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/getslideslistofsection/) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later enumeration.

## **Perguntas Frequentes**

**As seções são preservadas ao salvar no formato PPT (PowerPoint 97–2003)?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**É possível “ocultar” uma seção inteira?**

No. A section has no visibility state. To hide its contents, set the [ISlide.Hidden](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/hidden/) property for each slide in the section.

**Como posso encontrar a seção que contém um slide?**

Enumerate [Presentation.Sections](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sections/), call [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/getslideslistofsection/) for each section, and compare the returned slides with the target slide. For a non-empty section, [ISection.StartedFromSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/isection/startedfromslide/) returns its first slide; for an empty section, it returns `null`.