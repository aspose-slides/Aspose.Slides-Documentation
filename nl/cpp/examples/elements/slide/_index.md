---
title: Dia
type: docs
weight: 10
url: /nl/cpp/examples/elements/slide/
keywords:
- codevoorbeeld
- dia
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer dia's in Aspose.Slides for C++: maak, kloon, herschik, wijzig de grootte, stel achtergronden in en pas overgangen toe met C++ voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel biedt een reeks voorbeelden die laten zien hoe u met dia's kunt werken met **Aspose.Slides for C++**. U leert hoe u dia's kunt toevoegen, benaderen, klonen, opnieuw ordenen en verwijderen met behulp van de `Presentation`‑klasse.

Elk voorbeeld hieronder bevat een korte uitleg, gevolgd door een code‑fragment in C++.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank` lay-out en voegen we een lege dia toe aan de presentatie.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Opmerking:** Elke dia‑lay-out is afgeleid van een masterslide, die het algemene ontwerp en de placeholder‑structuur bepaalt. De afbeelding hieronder laat zien hoe masterslides en hun bijbehorende lay-outs zijn georganiseerd in PowerPoint.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Dia's benaderen op index**

U kunt dia's benaderen via hun index, of de index van een dia vinden op basis van een referentie. Dit is handig voor het itereren door of het wijzigen van specifieke dia's.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Voeg nog een lege dia toe.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Benader dia's op index.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Haal de dia-index op vanuit een referentie, en benader deze vervolgens op index.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Dia klonen**

Dit voorbeeld laat zien hoe u een bestaande dia kunt klonen. De gekloonde dia wordt automatisch aan het einde van de dia‑collectie toegevoegd.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Dia's opnieuw ordenen**

U kunt de volgorde van dia's wijzigen door er één naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een gekloonde dia naar de eerste positie.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Dia verwijderen**

Om een dia te verwijderen, verwijst u er simpelweg naar en roept u `Remove` aan. Dit voorbeeld voegt een tweede dia toe en verwijdert vervolgens de originele, zodat alleen de nieuwe overblijft.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```