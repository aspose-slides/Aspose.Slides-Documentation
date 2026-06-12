---
title: Transizione diapositiva
type: docs
weight: 110
url: /it/cpp/examples/elements/slide-transition/
keywords:
- esempio di codice
- transizione diapositiva
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le transizioni delle diapositive in Aspose.Slides per C++: aggiungi, personalizza e sequenzia effetti e durate con esempi C++ per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come applicare effetti di transizione delle diapositive e tempi con **Aspose.Slides for C++**.

## **Add a Slide Transition**
Applica un effetto di transizione dissolvenza alla prima diapositiva.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Applica una transizione di dissolvenza.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Access a Slide Transition**
Leggi il tipo di transizione attualmente assegnato a una diapositiva.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Accedi al tipo di transizione.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Remove a Slide Transition**
Rimuovi qualsiasi effetto di transizione impostando il tipo su `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Rimuovi la transizione impostando None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Set Transition Duration**
Specifica per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // In millisecondi.

    presentation->Dispose();
}
```