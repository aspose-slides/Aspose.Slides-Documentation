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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Przejścia slajdów kontrolują, w jaki sposób slajdy pojawiają się podczas pokazu slajdów. Dzięki Aspose.Slides dla .NET możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerem oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł używa przykładów w C#, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać czasem slajdu i utworzyć przejście Morph między dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i uzyskaj dostęp do właściwości [SlideShowTransition](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Ustaw jej [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/type/) na wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitiontype/) i następnie zapisz prezentację.

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

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące właściwości kontrolują to zachowanie:

- [AdvanceOnClick](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceonclick/) umożliwia widzowi przejście po kliknięciu myszy.
- [AdvanceAfter](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceafter/) włącza automatyczne przechodzenie.
- [AdvanceAfterTime](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceaftertime/) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno przejście po kliknięciu, jak i oparte na czasie, aby widz mógł przejść po kliknięciu lub poczekać na timer. Aby używać tylko timera, ustaw [AdvanceOnClick](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach, odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przechodzenie jest włączone, odczytaj [AdvanceAfter](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceafter/). Sam zapisany czas opóźnienia nie wskazuje, że timer jest aktywny.

Kolejny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

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

## **Precyzyjna kontrola czasu przejścia**

Użyj [Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/duration/) , aby określić dokładną długość efektu przejścia w milisekundach. Właściwość [SlideShowTransition](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu udostępnia te ustawienia poprzez [ISlideShowTransition](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/):

| Właściwość | Cel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/duration/) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Włącz [AdvanceAfter](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/advanceafter/), aby aktywować ten timer. |
| [Speed](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/speed/) | Wybiera predefiniowaną kategorię szybkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[Duration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przechodzenia konfiguruje się oddzielnie. Gdy nie ustawiono wyraźnego czasu trwania, Aspose.Slides wyznacza czas trwania efektu na podstawie typu przejścia i wartości [Speed].

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby zachować jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitiontype/) i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przechodzenie po 5 000 milisekundach i wyłącza przechodzenie po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

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

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą korzystać z różnych czasów trwania efektów. Na przykład użyj krótkiego przejścia dla slajdu tytułowego i dłuższego przejścia dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1 200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

### **Koordynuj przejścia z animowanym wyjściem**

Podczas przygotowywania [animated GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/net/export-to-html5/), lub [video](/slides/pl/net/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑milisekundowego zaniku (fade) między scenami i osobno dostosuj opóźnienie przechodzenia każdego slajdu, aby umożliwić czas na narrację lub treść.

Dla GIF i wideo skoordynuj częstotliwość klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, jakie efekty i opcje czasowe obsługuje wybrany format eksportu oraz podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Odczytaj [Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/duration/) przed modyfikacją przejścia, aby ustalić, czy przechowywana jest wyraźna wartość. Wartość `-1` oznacza, że nie ustawiono jawnego czasu trwania; wartość nieujemna określa przechowywany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i [Speed](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/slideshowtransition/speed/) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź oryginalne ustawienia.

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

## **Przejście Morph**

Przejście Morph animuje zmiany pomiędzy obiektami na kolejnych slajdach. Aby utworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie, a następnie zastosuj przejście Morph do drugiego slajdu. Dzięki temu przejście animuje odpowiadające obiekty między ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

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

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionmorphtype/) kontroluje, w jaki sposób Morph dopasowuje i animuje treść:

- [ByObject](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionmorphtype/) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując słowa, gdy to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując znaki, gdy to możliwe.

Ustaw właściwość przejścia [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/type/) na Morph przed dostępem do jej [Value](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/value/). Wartość następnie udostępnia interfejs [IMorphTransition](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/imorphtransition/), którego [MorphType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/imorphtransition/morphtype/) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd, aby używał animacji Morph opartej na słowach.

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

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt rozpoczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/type/) przejścia. Najpierw ustaw typ, a następnie użyj odpowiedniego interfejsu z jego [Value](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/value/).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Ustawia [FromBlack](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) za pomocą [IOptionalBlackTransition](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/ioptionalblacktransition/) , aby przejście rozpoczynało się od czarnego ekranu.

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

Tak. Preferuj [Duration], gdy potrzebujesz dokładnego czasu trwania efektu w milisekundach. Użyj [Speed], gdy wystarczy predefiniowana kategoria [TransitionSpeed] — Slow, Medium lub Fast — i nie ustawiono wyraźnego czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzać?**

Tak. Przypisz osadzony dźwięk do [Sound](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/sound/), ustaw [SoundMode](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitionsoundmode/) i włącz [SoundLoop](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/soundloop/). Dźwięk będzie się powtarzał aż do kolejnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Iteruj po kolekcji [Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) prezentacji i ustaw właściwość [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/type/) przejścia każdego slajdu na tę samą wartość. Ustaw wszystkie opcje czasu i efektów w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest obecnie ustawione na slajdzie?**

Odczytaj właściwość [Type](https://reference.aspose.com/slides/pl/net/aspose.slides/islideshowtransition/type/) z [SlideShowTransition](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Zwraca ona wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/net/aspose.slides.slideshow/transitiontype/); None oznacza, że nie zastosowano żadnego efektu przejścia.