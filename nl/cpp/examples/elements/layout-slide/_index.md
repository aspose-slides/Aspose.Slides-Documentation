---
title: Layoutdia
type: docs
weight: 20
url: /nl/cpp/examples/elements/layout-slide/
keywords:
- codevoorbeeld
- layoutdia
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer lay-outdia's in Aspose.Slides voor C++: kies, pas toe en pas aan dia-lay-outs, tijdelijke aanduidingen en masters met C++-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u werkt met **Layout Slides** in Aspose.Slides voor C++. Een layout slide definieert het ontwerp en de opmaak die door normale slides wordt geërfd. U kunt layout slides toevoegen, benaderen, klonen en verwijderen, en ongebruikte opschonen om de presentatiegrootte te verkleinen.

## **Een layout slide toevoegen**

U kunt een aangepaste layout slide maken om herbruikbare opmaak te definiëren. Bijvoorbeeld, u kunt een tekstvak toevoegen dat op alle slides met deze layout wordt weergegeven.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Maak een layoutdia met een lege layouttype en een aangepaste naam.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Voeg een tekstvak toe aan de layoutdia.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Voeg twee dia's toe met deze layout; beide erven de tekst uit de layout.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Opmerking 1:** Layout slides fungeren als sjablonen voor individuele slides. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens in veel slides hergebruiken.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst toevoegt aan een layout slide, tonen alle slides die op die layout zijn gebaseerd automatisch deze gedeelde inhoud.  
> De screenshot hieronder toont twee slides, elk een tekstvak overervend van dezelfde layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Een layout slide benaderen**

Layout slides kunnen worden benaderd via index of via layouttype (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Toegang tot een layoutdia via index.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Toegang tot een layoutdia via type.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Een layout slide verwijderen**

U kunt een specifieke layout slide verwijderen als deze niet meer nodig is.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Haal een layoutdia op via type en verwijder deze.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Ongebruikte layout slides verwijderen**

Om de presentatiegrootte te verkleinen, kunt u layout slides verwijderen die niet door enige normale slide worden gebruikt.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Verwijdert automatisch alle layoutdia's die niet door enige dia worden gebruikt.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Een layout slide klonen**

U kunt een layout slide dupliceren met de `AddClone`‑methode.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Haal een bestaande layoutdia op via type.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Kloon de layoutdia naar het einde van de layoutdia-collectie.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Samenvatting:** Layout slides zijn krachtige hulpmiddelen om consistente opmaak over slides te beheren. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout slides.