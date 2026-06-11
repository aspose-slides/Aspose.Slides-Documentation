---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/net/examples/elements/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- dostęp do przejścia slajdu
- usuń przejście slajdu
- czas trwania przejścia
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj przejścia slajdów w Aspose.Slides for .NET: dodawaj, dostosowuj i kolejkuj efekty oraz czasy trwania z przykładami C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje zastosowanie efektów przejścia slajdów i ich czasów z **Aspose.Slides for .NET**.

## **Dodaj przejście slajdu**

Zastosuj efekt płynnego przejścia do pierwszego slajdu.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Zastosuj przejście płynne.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Uzyskaj dostęp do typu przejścia.
    var type = slide.SlideShowTransition.Type;
}
```

## **Usuń przejście slajdu**

Wyczyść dowolny efekt przejścia, ustawiając typ na `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Usuń przejście, ustawiając brak.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem dalej.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // w milisekundach
}
```