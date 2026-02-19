---
title: Folienübergang
type: docs
weight: 110
url: /de/cpp/examples/elements/slide-transition/
keywords:
- Codebeispiel
- Folienübergang
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Master-Übergänge in Folien in Aspose.Slides for C++: Hinzufügen, Anpassen und Sequenzieren von Effekten und Dauern mit C++-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Anwendung von Folienübergangseffekten und Zeitsteuerungen mit **Aspose.Slides for C++**.

## **Folienübergang hinzufügen**

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Fade-Übergang anwenden.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den derzeit einer Folie zugewiesenen Übergangstyp.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Zugriff auf den Übergangstyp.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Entfernen eines Folienübergangs**

Entfernen Sie jeden Übergangseffekt, indem Sie den Typ auf `None` setzen.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Übergang entfernen, indem None gesetzt wird.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeschaltet wird.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // In Millisekunden.

    presentation->Dispose();
}
```