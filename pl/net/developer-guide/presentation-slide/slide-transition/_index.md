---
title: Zarządzanie przejściami slajdów w prezentacjach w .NET
linktitle: Przejście slajdu
type: docs
weight: 90
url: /pl/net/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- zastosuj przejście slajdu
- zaawansowane przejście slajdu
- przejście morph
- typ przejścia
- efekt przejścia
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla .NET, z instrukcjami krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektu przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejścia dla wybranych slajdów oraz zapisać wynik jako plik PPTX. Artykuł odpowiada również na typowe pytania dotyczące szybkości przejścia, dźwięków przejścia, stosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodawanie przejścia slajdu**
Aby ułatwić zrozumienie, przedstawiliśmy użycie Aspose.Slides dla .NET do zarządzania prostymi przejściami slajdów. Programiści mogą nie tylko stosować różne efekty przejścia na slajdach, ale także dostosowywać zachowanie tych efektów. Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z dostępnych w Aspose.Slides dla .NET wartości wyliczenia TransitionType.
3. Zapisz zmodyfikowany plik prezentacji.

```c#
// Utwórz instancję klasy Presentation, aby wczytać plik źródłowej prezentacji
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Zastosuj przejście typu circle na slajdzie 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Zastosuj przejście typu comb na slajdzie 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Zapisz prezentację na dysku
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie zaawansowanego przejścia slajdu**
W poprzedniej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Aby ten efekt uczynić bardziej zaawansowanym i kontrolowanym, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z dostępnych w Aspose.Slides dla .NET wartości wyliczenia.
3. Możesz również ustawić przejście na „Advance On Click”, po określonym czasie lub obie opcje.
4. Jeśli przejście slajdu jest włączone jako „Advance On Click”, przejście nastąpi tylko po kliknięciu myszy. Ponadto, jeśli właściwość Advance After Time jest ustawiona, przejście nastąpi automatycznie po upływie określonego czasu.
5. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Zastosuj przejście typu circle na slajdzie 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Ustaw czas przejścia na 3 sekundy
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Zastosuj przejście typu comb na slajdzie 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Ustaw czas przejścia na 5 sekund
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Zastosuj przejście typu zoom na slajdzie 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Ustaw czas przejścia na 7 sekund
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Zapisz prezentację na dysku
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Dodatkowo, przy użyciu właściwości [AdvanceAfter](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceafter/) możesz sprawdzić, czy przejście slajdu zostało skonfigurowane do przejścia do następnego slajdu, lub wyłączyć to ustawienie.

Poniższy kod C# pokazuje, jak to zrobić:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Pobiera przejście slajdu
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Sprawdza, czy ustawienie Advance After Time jest włączone
        if (slideTransition.AdvanceAfter)
        {
            // Wypisuje wartość Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Wyłącza przejście po określonym czasie, jeśli wartość AdvanceAfterTime jest większa niż 2 sekundy
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Przejście Morph**
Aspose.Slides dla .NET obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/imorphtransition). Representuje ono nowy przejście Morph wprowadzone w PowerPoint 2019. Przejście Morph pozwala animować płynny ruch z jednego slajdu do drugiego. W tym artykule opisano koncepcję oraz sposób użycia przejścia Morph. Aby efektywnie wykorzystać przejście Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najłatwiejszy sposób to skopiowanie slajdu i przesunięcie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać kopię slajdu z tekstem do prezentacji i ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) na drugim slajdzie.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Typy przejścia Morph**
Dodano nową wyliczeniową [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionmorphtype). Reprezentuje ona różne typy przejścia Morph.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: przejście Morph jest wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: przejście Morph jest wykonywane poprzez przenoszenie tekstu słowo po słowie, tam gdzie to możliwe.
- ByChar: przejście Morph jest wykonywane poprzez przenoszenie tekstu znak po znaku, tam gdzie to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście Morph na slajdzie i zmienić typ Morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Ustawianie efektów przejścia**
Aspose.Slides dla .NET obsługuje ustawianie efektów przejścia, takich jak „from black”, „from left”, „from right” itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Pobierz odniesienie do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

W poniższym przykładzie ustawiono efekty przejścia.

```c#
// Utwórz instancję klasy Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Ustaw efekt
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Zapisz prezentację na dysku
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Ustaw właściwość [Speed](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/speed/) przejścia za pomocą ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionspeed/) (np. slow/medium/fast).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować zachowanie za pomocą ustawień takich jak tryb dźwięku i pętla (np. [Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/soundloop/), a także metadane takie jak [SoundIsBuiltIn](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) i [SoundName](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane osobno dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach daje spójny rezultat.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Sprawdź [ustawienia przejścia](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide/slideshowtransition/) slajdu i odczytaj jego [typ przejścia](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/type/); ta wartość dokładnie określa, jaki efekt jest zastosowany.