---
title: Dia
type: docs
weight: 10
url: /nl/net/examples/elements/slide/
keywords:
- dia
- dia toevoegen
- dia benaderen
- dia index
- dia klonen
- slides herschikken
- dia verwijderen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer dia's in Aspose.Slides voor .NET: maak, kloon, herschik, formaat wijzigen, stel achtergronden in en pas overgangen toe met C# voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel biedt een reeks voorbeelden die laten zien hoe u met slides kunt werken met **Aspose.Slides for .NET**. U leert hoe u slides kunt toevoegen, benaderen, klonen, herschikken en verwijderen met de `Presentation`‑klasse.

Elke voorbeeld hieronder bevat een korte uitleg gevolgd door een codefragment in C#.

## **Slide toevoegen**

Om een nieuwe slide toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank`‑lay-out en voegen een lege slide toe aan de presentatie.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Elke dia is gebaseerd op een lay-out, die zelf gebaseerd is op een masterdia.
    // Gebruik de Blank lay-out om een nieuwe dia te maken.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Voeg een nieuwe lege dia toe met de geselecteerde lay-out.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Opmerking:** Elke slide‑lay-out is afgeleid van een master‑slide, die het algemene ontwerp en de placeholder‑structuur bepaalt. De afbeelding hieronder illustreert hoe master‑slides en hun bijbehorende lay-outs zijn georganiseerd in PowerPoint.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Slides benaderen op index**

U kunt slides benaderen via hun index, of de index van een slide vinden op basis van een referentie. Dit is handig om door slides te itereren of specifieke slides te wijzigen.

```csharp
static void AccessSlide()
{
    // Standaard wordt een presentatie aangemaakt met één lege dia.
    using var presentation = new Presentation();

    // Voeg nog een lege dia toe.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Benader dia's op index.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Haal de dia-index op uit een referentie en benader deze vervolgens op index.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Slide klonen**

Dit voorbeeld laat zien hoe u een bestaande slide kunt klonen. De gekloonde slide wordt automatisch aan het einde van de slide‑collectie toegevoegd.

```csharp
static void CloneSlide()
{
    // Standaard bevat de presentatie één lege dia.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Kloon de eerste dia; deze wordt aan het einde van de presentatie toegevoegd.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // De index van de gekloonde dia is 1 (tweede dia in de presentatie).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Slides herschikken**

U kunt de volgorde van slides wijzigen door er één naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een gekloonde slide naar de eerste positie.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Voeg een kloon van de eerste dia toe (standaard aangemaakt).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Verplaats de gekloonde dia naar de eerste positie (de rest schuift omlaag).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Slide verwijderen**

Om een slide te verwijderen, verwijst u er simpelweg naar en roept u `Remove` aan. Dit voorbeeld voegt een tweede slide toe en verwijdert vervolgens de oorspronkelijke, zodat alleen de nieuwe overblijft.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Voeg een nieuwe lege dia toe naast de standaard eerste dia.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Verwijder de eerste dia; alleen de nieuw toegevoegde dia blijft over.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```