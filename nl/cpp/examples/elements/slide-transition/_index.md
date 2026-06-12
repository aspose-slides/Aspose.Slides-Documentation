---
title: Dia-overgang
type: docs
weight: 110
url: /nl/cpp/examples/elements/slide-transition/
keywords:
- codevoorbeeld
- dia-overgang
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheers dia‑overgangen in Aspose.Slides voor C++: voeg toe, pas aan en orden effecten en duur met C++‑voorbeelden voor PPT-, PPTX‑ en ODP‑presentaties."
---
Dit artikel toont het toepassen van dia‑overgangseffecten en -tijden met **Aspose.Slides for C++**.

## **Een dia‑overgang toevoegen**

Pas een vervagings‑overgangseffect toe op de eerste dia.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Pas een vervagings‑overgang toe.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Toegang tot een dia‑overgang**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Toegang tot het overgangstype.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Een dia‑overgang verwijderen**

Verwijder elk overgangseffect door het type in te stellen op `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Verwijder de overgang door None in te stellen.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Overgangsduur instellen**

Geef op hoe lang de dia wordt getoond voordat deze automatisch wordt voortgezet.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // In milliseconden.

    presentation->Dispose();
}
```