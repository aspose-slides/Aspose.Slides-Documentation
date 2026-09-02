---
title: Gestire le sezioni delle diapositive nelle presentazioni in .NET
linktitle: Sezione diapositiva
type: docs
weight: 100
url: /it/net/slide-section/
keywords:
- creare sezione
- aggiungere sezione
- modificare sezione
- cambiare sezione
- nome sezione
- recuperare diapositive della sezione
- elaborare diapositive della sezione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive con Aspose.Slides per .NET: crea, rinomina, riordina, recupera ed elabora le diapositive delle sezioni in presentazioni PPTX."
---
## **Introduzione**

Le sezioni organizzano le diapositive consecutive in gruppi denominati senza modificare il contenuto della diapositiva. Con Aspose.Slides per .NET, è possibile creare, riordinare, rinominare, ispezionare e rimuovere le sezioni tramite la proprietà [Presentation.Sections](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sections/).

Le sezioni sono particolarmente utili quando:

- una presentazione di grandi dimensioni deve essere suddivisa in argomenti o capitoli logici;
- gruppi diversi di diapositive sono assegnati a collaboratori differenti;
- le diapositive devono essere elaborate, spostate o unite come gruppi.

Scegli nomi di sezione concisi che descrivano lo scopo delle diapositive raggruppate. Poiché le sezioni fanno parte della struttura della presentazione, utilizza le API delle sezioni per determinare l’appartenenza anziché derivarla dalle posizioni delle diapositive.

## **Creare e gestire le sezioni**

Usa [ISectionCollection.AddSection](https://reference.aspose.com/slides/it/net/aspose.slides/sectioncollection/addsection/) per creare una sezione specificando il suo nome e la diapositiva iniziale. Aspose.Slides determina quali diapositive appartengono alla sezione dalla struttura delle sezioni corrente della presentazione.

La stessa [ISectionCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isectioncollection/) consente anche di:

- spostare una sezione insieme alle sue diapositive usando [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/it/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- rimuovere solo la definizione della sezione con [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/it/net/aspose.slides/sectioncollection/removesection/), mantenendo le sue diapositive;
- rimuovere una sezione e le sue diapositive con [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/it/net/aspose.slides/sectioncollection/removesectionwithslides/);
- aggiungere una sezione vuota alla fine con [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/it/net/aspose.slides/sectioncollection/appendemptysection/).

Il seguente esempio crea due sezioni, ne sposta una, la rimuove insieme alle sue diapositive e aggiunge una sezione vuota:

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

Dopo queste operazioni, la presentazione contiene la sezione `Introduction` con le sue diapositive e una sezione vuota `Appendix`. La sezione `Results` e le sue diapositive sono state rimosse.

## **Rinominare le sezioni**

Per rinominare una sezione, imposta la sua proprietà [ISection.Name](https://reference.aspose.com/slides/it/net/aspose.slides/isection/name/). Le diapositive della sezione e la sua posizione rimangono inalterate.

Il seguente esempio crea una sezione e ne cambia il nome:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Recuperare le diapositive dalle sezioni**

La proprietà [Presentation.Sections](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sections/) restituisce una [ISectionCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isectioncollection/) che puoi enumerare. Per ogni [ISection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/), chiama [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/getslideslistofsection/) per ottenere le diapositive che attualmente vi appartengono. Il metodo restituisce una [ISectionSlideCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isectionslidecollection/), che fornisce il conteggio, l'accesso indicizzato e l'enumerazione.

Il seguente esempio crea due sezioni popolate e una sezione vuota, poi stampa per ogni sezione il suo [name](https://reference.aspose.com/slides/it/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/it/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/it/net/aspose.slides/isection/startedfromslide/), il conteggio delle diapositive e i numeri delle diapositive. Usa l'indicizzatore della collezione per leggere la prima diapositiva e `foreach` per elaborare ogni diapositiva. Per la sezione vuota, la collezione restituita ha un conteggio pari a zero, l'indicizzatore non viene accesso e l'enumerazione non esegue iterazioni.

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

L’appartenenza a una sezione è determinata dalla struttura delle sezioni della presentazione. Non calcolare manualmente l’intervallo di una sezione da [ISection.StartedFromSlide](https://reference.aspose.com/slides/it/net/aspose.slides/isection/startedfromslide/), dagli indici delle diapositive e dalla diapositiva iniziale della sezione successiva.

Le modifiche strutturali possono cambiare sia le diapositive restituite per una sezione sia i loro numeri. Ciò include il riordino delle diapositive, la clonazione di una diapositiva in una sezione, lo spostamento di una sezione insieme alle sue diapositive, la rimozione di diapositive e la rimozione di sezioni. Il prossimo esempio chiama [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/getslideslistofsection/) dopo ogni modifica di questo tipo anziché mantenere ipotesi sui confini precedenti della sezione.

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

Chiama nuovamente [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/getslideslistofsection/) ogni volta che diapositive o sezioni vengono riordinate, clonate, spostate o rimosse. In questo modo l’elaborazione successiva rimane allineata alla struttura corrente della presentazione.

Il formato PPT (PowerPoint 97–2003) non conserva i metadati delle sezioni. Usa questo flusso di lavoro con un formato che supporta le sezioni, come PPTX; la conversione in PPT rimuove la struttura delle sezioni necessaria per le successive enumerazioni.

## **FAQ**

**Le sezioni vengono mantenute quando si salva nel formato PPT (PowerPoint 97–2003)?**

No. Il formato PPT non supporta i metadati delle sezioni, quindi il raggruppamento delle sezioni viene perso quando si salva in .ppt.

**È possibile “nascondere” un’intera sezione?**

No. Una sezione non ha uno stato di visibilità. Per nascondere il suo contenuto, imposta la proprietà [ISlide.Hidden](https://reference.aspose.com/slides/it/net/aspose.slides/islide/hidden/) per ogni diapositiva nella sezione.

**Come posso trovare la sezione che contiene una diapositiva?**

Enumera [Presentation.Sections](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sections/), chiama [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/getslideslistofsection/) per ogni sezione e confronta le diapositive restituite con la diapositiva target. Per una sezione non vuota, [ISection.StartedFromSlide](https://reference.aspose.com/slides/it/net/aspose.slides/isection/startedfromslide/) restituisce la sua prima diapositiva; per una sezione vuota, restituisce `null`.