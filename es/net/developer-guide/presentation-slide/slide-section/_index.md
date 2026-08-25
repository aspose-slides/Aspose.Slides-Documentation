---
title: Administrar secciones de diapositivas en presentaciones en .NET
linktitle: Sección de diapositiva
type: docs
weight: 100
url: /es/net/slide-section/
keywords:
- crear sección
- añadir sección
- editar sección
- cambiar sección
- nombre de sección
- recuperar diapositivas de sección
- procesar diapositivas de sección
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administrar secciones de diapositivas con Aspose.Slides para .NET: crear, renombrar, reordenar, recuperar y procesar diapositivas de sección en presentaciones PPTX."
---
## **Introducción**

Las secciones organizan diapositivas consecutivas en grupos con nombre sin cambiar el contenido de la diapositiva. Con Aspose.Slides para .NET, puedes crear, reordenar, renombrar, inspeccionar y eliminar secciones mediante la propiedad [Presentation.Sections](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sections/) .

Las secciones son especialmente útiles cuando:

- una presentación grande necesita dividirse en temas o capítulos lógicos;
- diferentes grupos de diapositivas se asignan a distintos colaboradores;
- las diapositivas necesitan ser procesadas, movidas o combinadas como grupos.

Elige nombres de sección concisos que describan el propósito de las diapositivas agrupadas. Dado que las secciones forman parte de la estructura de la presentación, utiliza las API de sección para determinar la pertenencia en lugar de derivarla de la posición de las diapositivas.

## **Crear y administrar secciones**

Utiliza [ISectionCollection.AddSection](https://reference.aspose.com/slides/es/net/aspose.slides/sectioncollection/addsection/) para crear una sección especificando su nombre y diapositiva inicial. Aspose.Slides determina qué diapositivas pertenecen a la sección a partir de la estructura de secciones actual de la presentación.

El mismo [ISectionCollection](https://reference.aspose.com/slides/es/net/aspose.slides/isectioncollection/) también permite:

- mover una sección junto con sus diapositivas utilizando [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/es/net/aspose.slides/sectioncollection/reordersectionwithslides/);
- eliminar solo la definición de la sección con [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/es/net/aspose.slides/sectioncollection/removesection/), lo que conserva sus diapositivas;
- eliminar una sección y sus diapositivas con [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/es/net/aspose.slides/sectioncollection/removesectionwithslides/);
- agregar una sección vacía al final con [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/es/net/aspose.slides/sectioncollection/appendemptysection/).

El siguiente ejemplo crea dos secciones, mueve una de ellas, la elimina junto con sus diapositivas y agrega una sección vacía:

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

Después de estas operaciones, la presentación contiene la sección `Introduction` con sus diapositivas y una sección vacía `Appendix`. La sección `Results` y sus diapositivas han sido eliminadas.

## **Renombrar secciones**

Para renombrar una sección, establece su propiedad [ISection.Name](https://reference.aspose.com/slides/es/net/aspose.slides/isection/name/). Las diapositivas y la posición de la sección permanecen sin cambios.

El siguiente ejemplo crea una sección y cambia su nombre:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Obtener diapositivas de las secciones**

La propiedad [Presentation.Sections](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sections/) devuelve una [ISectionCollection](https://reference.aspose.com/slides/es/net/aspose.slides/isectioncollection/) que puedes enumerar. Para cada [ISection](https://reference.aspose.com/slides/es/net/aspose.slides/isection/), llama a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/es/net/aspose.slides/isection/getslideslistofsection/) para obtener las diapositivas que actualmente le pertenecen. El método devuelve una [ISectionSlideCollection](https://reference.aspose.com/slides/es/net/aspose.slides/isectionslidecollection/), que proporciona un recuento, acceso indexado y enumeración.

El siguiente ejemplo crea dos secciones pobladas y una sección vacía, luego muestra el [nombre](https://reference.aspose.com/slides/es/net/aspose.slides/isection/name/), el [identificador](https://reference.aspose.com/slides/es/net/aspose.slides/isection/sectionid/), la [diapositiva inicial](https://reference.aspose.com/slides/es/net/aspose.slides/isection/startedfromslide/), el recuento de diapositivas y los números de diapositiva de cada sección. Utiliza el indexador de la colección para leer la primera diapositiva y `foreach` para procesar cada diapositiva. Para la sección vacía, la colección devuelta tiene un recuento de cero, no se accede al indexador y la enumeración no realiza iteraciones.

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

La pertenencia a una sección se determina por la estructura de secciones de la presentación. No calcules el rango de una sección manualmente a partir de [ISection.StartedFromSlide](https://reference.aspose.com/slides/es/net/aspose.slides/isection/startedfromslide/), índices de diapositivas y la diapositiva inicial de la siguiente sección.

Las ediciones estructurales pueden cambiar tanto las diapositivas devueltas para una sección como sus números de diapositiva. Esto incluye reordenar diapositivas, clonar una diapositiva en una sección, mover una sección junto con sus diapositivas, eliminar diapositivas y eliminar secciones. El siguiente ejemplo llama a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/es/net/aspose.slides/isection/getslideslistofsection/) después de cada uno de estos cambios en lugar de mantener suposiciones sobre los límites anteriores de la sección.

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

Llama a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/es/net/aspose.slides/isection/getslideslistofsection/) nuevamente siempre que se reordenan, clonan, mueven o eliminan diapositivas o secciones. Esto mantiene el procesamiento posterior alineado con la estructura actual de la presentación.

El formato PPT (PowerPoint 97–2003) no conserva los metadatos de sección. Utiliza este flujo de trabajo con un formato que soporte secciones, como PPTX; la conversión a PPT elimina la estructura de secciones necesaria para la enumeración posterior.

## **Preguntas frecuentes**

**¿Se conservan las secciones al guardar en el formato PPT (PowerPoint 97–2003)?**

No. El formato PPT no admite metadatos de sección, por lo que la agrupación de secciones se pierde al guardar en .ppt.

**¿Se puede "ocultar" una sección completa?**

No. Una sección no tiene un estado de visibilidad. Para ocultar su contenido, establece la propiedad [ISlide.Hidden](https://reference.aspose.com/slides/es/net/aspose.slides/islide/hidden/) para cada diapositiva de la sección.

**¿Cómo puedo encontrar la sección que contiene una diapositiva?**

Enumera [Presentation.Sections](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sections/), llama a [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/es/net/aspose.slides/isection/getslideslistofsection/) para cada sección y compara las diapositivas devueltas con la diapositiva objetivo. Para una sección no vacía, [ISection.StartedFromSlide](https://reference.aspose.com/slides/es/net/aspose.slides/isection/startedfromslide/) devuelve su primera diapositiva; para una sección vacía, devuelve `null`.