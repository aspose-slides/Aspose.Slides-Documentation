---
title: Bildövergång
type: docs
weight: 110
url: /sv/cpp/examples/elements/slide-transition/
keywords:
- kodexempel
- bildövergång
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska bildövergångar i Aspose.Slides for C++: lägg till, anpassa och ordna effekter och varaktigheter med C++-exempel för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel visar hur man använder bildövergångseffekter och tidsinställningar med **Aspose.Slides for C++**.

## **Add a Slide Transition**
Lägg till en bildövergång

Apply a fade transition effect to the first slide.
Applicera en toningsövergång på den första bilden.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Applicera en toningsövergång.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Access a Slide Transition**
Åtkomst till en bildövergång

Read the transition type currently assigned to a slide.
Läs den övergångstyp som för närvarande är tilldelad till en bild.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Åtkomst till övergångstypen.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Remove a Slide Transition**
Ta bort en bildövergång

Clear any transition effect by setting the type to `None`.
Rensa alla övergångseffekter genom att sätta typen till `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Ta bort övergången genom att sätta None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Set Transition Duration**
Ställ in övergångens varaktighet

Specify how long the slide is displayed before advancing automatically.
Ange hur länge bilden visas innan den automatiskt går vidare.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // I millisekunder.

    presentation->Dispose();
}
```