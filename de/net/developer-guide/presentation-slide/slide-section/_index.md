---
title: Verwalten von Folienabschnitten in Präsentationen in .NET
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/net/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- Abschnittsfolien abrufen
- Abschnittsfolien verarbeiten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für .NET: Erstellen, umbenennen, neu anordnen, abrufen und verarbeiten Sie Abschnittsfolien in PPTX‑Präsentationen."
---
## **Einführung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für .NET können Sie Abschnitte über die [Presentation.Sections](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sections/) Eigenschaft erstellen, neu anordnen, umbenennen, prüfen und entfernen.

Abschnitte sind besonders nützlich, wenn:

- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Gruppen von Folien verschiedenen Mitwirkenden zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus Folienpositionen abzuleiten.

## **Abschnitte erstellen und verwalten**

Verwenden Sie [ISectionCollection.AddSection](https://reference.aspose.com/slides/de/net/aspose.slides/sectioncollection/addsection/), um einen Abschnitt zu erstellen, indem Sie dessen Namen und die Startfolie angeben. Aspose.Slides ermittelt, welche Folien zum Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [ISectionCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isectioncollection/) ermöglicht Ihnen außerdem:

- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/de/net/aspose.slides/sectioncollection/reordersectionwithslides/) verwenden;
- nur die Abschnittsdefinition entfernen mit [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/de/net/aspose.slides/sectioncollection/removesection/), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/de/net/aspose.slides/sectioncollection/removesectionwithslides/);
- am Ende einen leeren Abschnitt hinzufügen mit [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/de/net/aspose.slides/sectioncollection/appendemptysection/).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt an:

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

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien und einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, setzen Sie die Eigenschaft [ISection.Name](https://reference.aspose.com/slides/de/net/aspose.slides/isection/name/) des Abschnitts. Die Folien und die Position des Abschnitts bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert dessen Namen:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Folien aus Abschnitten abrufen**

Die Eigenschaft [Presentation.Sections](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sections/) gibt eine [ISectionCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isectioncollection/) zurück, die Sie enumerieren können. Für jedes [ISection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/) rufen Sie [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/getslideslistofsection/) auf, um die Folien zu erhalten, die derzeit zu diesem Abschnitt gehören. Die Methode liefert eine [ISectionSlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isectionslidecollection/), die eine Anzahl, indizierten Zugriff und Enumeration bereitstellt.

Das folgende Beispiel erstellt zwei gefüllte Abschnitte und einen leeren Abschnitt, dann gibt es für jeden Abschnitt den [Name](https://reference.aspose.com/slides/de/net/aspose.slides/isection/name/), die [Kennung](https://reference.aspose.com/slides/de/net/aspose.slides/isection/sectionid/), die [Startfolie](https://reference.aspose.com/slides/de/net/aspose.slides/isection/startedfromslide/), die Folienanzahl und die Foliennummern aus. Es verwendet den Indexer der Sammlung, um die erste Folie zu lesen, und `foreach`, um jede Folie zu verarbeiten. Für den leeren Abschnitt hat die zurückgegebene Sammlung eine Anzahl von Null, der Indexer wird nicht verwendet und die Enumeration führt keine Durchläufe durch.

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

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [ISection.StartedFromSlide](https://reference.aspose.com/slides/de/net/aspose.slides/isection/startedfromslide/), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dazu gehören das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/getslideslistofsection/) nach jeder solchen Änderung auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

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

Rufen Sie [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/getslideslistofsection/) erneut auf, wann immer Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur abgestimmt.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnittsmetadaten. Verwenden Sie diesen Arbeitsablauf mit einem Format, das Abschnitte unterstützt, wie PPTX; das Konvertieren in PPT entfernt die für die spätere Aufzählung erforderliche Abschnittsstruktur.

## **FAQ**

**Bleiben Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnittsmetadaten, daher gehen die Abschnittsgruppen beim Speichern in .ppt verloren.

**Kann ein kompletter Abschnitt „ausgeblendet“ werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitszustand. Um dessen Inhalte auszublenden, setzen Sie die Eigenschaft [ISlide.Hidden](https://reference.aspose.com/slides/de/net/aspose.slides/islide/hidden/) für jede Folie im Abschnitt.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Enumerieren Sie [Presentation.Sections](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sections/), rufen Sie [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/de/net/aspose.slides/isection/getslideslistofsection/) für jeden Abschnitt auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑Folie. Für einen nicht leeren Abschnitt liefert [ISection.StartedFromSlide](https://reference.aspose.com/slides/de/net/aspose.slides/isection/startedfromslide/) seine erste Folie; für einen leeren Abschnitt liefert er `null`.