---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/cpp/examples/elements/slide-transition/
keywords:
- przykład kodu
- przejście slajdu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Mistrzowskie przejścia slajdów w Aspose.Slides dla C++: dodawaj, dostosowuj i kolejkuj efekty oraz czasy trwania przy użyciu przykładów C++ dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje stosowanie efektów przejścia slajdu i czasu trwania z **Aspose.Slides for C++**.

## **Dodaj przejście slajdu**

Zastosuj efekt przejścia zanikania do pierwszego slajdu.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Zastosuj przejście zanikania.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Uzyskaj dostęp do typu przejścia.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Usuń przejście slajdu**

Wyczyść wszelkie efekty przejścia, ustawiając typ na `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Usuń przejście, ustawiając brak.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // W milisekundach.

    presentation->Dispose();
}
```