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
- przejście Morph
- typ przejścia
- efekt przejścia
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Dzięki Aspose.Slides for .NET możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerem oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł używa przykładów w C#, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać timingiem slajdów i utworzyć przejście Morph między dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Add Slide Transition**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i uzyskaj dostęp do właściwości [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Ustaw jej [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle na pierwszym slajdzie i przejście Comb na drugim. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Przejście kołowe**

Właściwość [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) interfejsu [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) kontroluje liczbę promieniowych sektorów odsłaniających docelowy slajd. Ustaw przejście slajdu [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na Wheel z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) przed odczytaniem [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) jako [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, po którym następuje slajd z złotym prostokątem. Slajdy docelowe używają liczby sektorów 1 i 8, przy tej samej [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) oraz wyraźnie określonym [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) równym 8000 milisekund, aby różnica była łatwa do zauważenia.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Otwórz wygenerowaną prezentację w programie PowerPoint i uruchom pokaz slajdów. Przejdź z slajdu 1 do slajdu 2, a następnie ze slajdu 3 do slajdu 4. W odtwarzaniu PowerPoint potwierdzona liczba sektorów 1 odsłania slajd jednym, ruchomym w kierunku zgodnym z ruchem wskazówek zegara; potwierdzona liczba 8 odsłania go przez osiem promieniowych sektorów jednocześnie. Zawartość docelowa i czas przejścia są identyczne, więc różnica polega na liczbie sektorów odsłaniania.

## **Add Advanced Slide Transition**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi dalej w pokazie slajdów. Następujące właściwości kontrolują to zachowanie:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) umożliwia widzowi przejście po kliknięciu myszy.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) włącza automatyczne przechodzenie.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz jednocześnie przechodzenie po kliknięciu i po upływie czasu, aby widz mógł kontynuować kliknięciem lub poczekać na timer. Aby używać tylko timera, ustaw [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Opóźnienie określa, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Aby sprawdzić, czy automatyczne przechodzenie jest włączone, odczytaj [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Sam zapisany odstęp nie oznacza, że timer jest aktywny.

Następny przykład otwiera wcześniej zapisaną plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Control Transition Timing Precisely**

Użyj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) aby określić dokładną długość efektu przejścia w milisekundach. Właściwość [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu udostępnia te ustawienia poprzez [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Property | Cel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Włącz [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) aby uruchomić ten timer. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Konfiguruj oddzielnie opóźnienie automatycznego przechodzenia. Gdy nie ustawiono wyraźnego czasu trwania, Aspose.Slides określa czas trwania efektu na podstawie typu przejścia i wartości [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Apply the Same Duration to Every Slide**

Aby zapewnić spójne tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przechodzenie po 5 000 milisekund i wyłącza przechodzenie po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Set Different Durations for Individual Slides**

Różne slajdy mogą używać różnych czasów trwania efektu. Na przykład można zastosować krótkie przejście dla slajdu tytułowego i dłuższe dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1 200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordinate Transitions with Animated Output**

Przy przygotowywaniu [animowanego GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/net/export-to-html5/) lub [wideo](/slides/pl/net/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj zanikania Fade trwającego 600 milisekund między scenami i osobno dostosuj opóźnienie przejścia każdego slajdu, aby zapewnić czas na narrację lub treść.

Dla GIF i wideo skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasu są obsługiwane przez wybrany format eksportu i podglądaj wynik, aby potwierdzić synchronizację.

### **Read an Existing Transition Duration**

Odczytaj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) przed modyfikacją przejścia, aby ustalić, czy zapisano wyraźną wartość. Wartość `-1` oznacza, że nie ustawiono wyraźnego czasu trwania; nieujemna wartość określa zapisany czas trwania w milisekundach. Nieustawiona wartość nie jest wyliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, dlatego najpierw sprawdź pierwotne ustawienia.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph Transition**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby utworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. Daje to przejściu odpowiednie obiekty do animacji między stanem pierwotnym a zmodyfikowanym.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia położenie oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph Transition Types**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) kontroluje, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) traktuje każdy kształt jako jeden obiekt.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując słowa, gdy to możliwe.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując znaki, gdy to możliwe.

Ustaw [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) przejścia na Morph przed odczytaniem jego [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Wartość dostarcza interfejs [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), którego właściwość [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) wybiera tryb dopasowania.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```


<!-- visual-explanation:slide-transition:start -->
[![Jednostki dopasowania Morph przedstawione jako cały kształt, pojedyncze słowa i pojedyncze znaki.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph może dopasowywać całe kształty, słowa lub znaki tam, gdzie to możliwe. Te pola identyfikują jednostki dopasowania, a nie obserwowany ruch. Przykład wybiera ByWord na drugim slajdzie.*
<!-- visual-explanation:slide-transition:end -->

## **Set Transition Effects**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Najpierw ustaw typ, a potem użyj odpowiedniego interfejsu z jego [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu `input.pptx`. Ustawia [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) poprzez [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Preferuj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), gdy wystarcza predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium lub Fast, i nie jest ustawiony wyraźny czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i zrobić go w pętli?**

Tak. Przypisz osadzony dźwięk do [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), ustaw [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) i włącz [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Dźwięk będzie powtarzany, dopóki nie nastąpi kolejny zdarzenie dźwiękowe w pokazie slajdów.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Iteruj kolekcję [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) prezentacji i ustaw każdej slajdowi przejście [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na tę samą wartość. Ustaw wszelkie opcje czasu i efektu w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Odczytaj właściwość [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) z [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Zwraca ona wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None oznacza, że żaden efekt przejścia nie jest zastosowany.