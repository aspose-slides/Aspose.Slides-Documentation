---
title: Zarządzaj przejściami slajdów w prezentacjach w .NET
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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów i dostosuj efekty Morph oraz inne efekty przejść za pomocą Aspose.Slides dla .NET."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Z Aspose.Slides dla .NET możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerem oraz dostosować opcje specyficzne dla efektu. Ten artykuł używa przykładów w C#, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać czasem slajdu i utworzyć przejście Morph między dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i uzyskaj dostęp do właściwości [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Ustaw jej [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu i przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

Właściwość [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) interfejsu [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) kontroluje liczbę radialnych sektorów odsłaniających docelowy slajd. Ustaw przejście slajdu [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na Wheel z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) przed dostępem do [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) jako [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, po którym następuje slajd ze złotym prostokątem. Docelowe slajdy używają liczby promieni 1 i 8, z taką samą [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) i wyraźnie ustawionym [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) na 8 000 milisekund, aby różnicę było łatwo zauważyć.

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

Otwórz wyjściową prezentację w PowerPoint i uruchom pokaz slajdów. Przejdź z slajdu 1 do slajdu 2, a następnie z slajdu 3 do slajdu 4. W odtwarzaniu PowerPoint zweryfikowana liczba promieni 1 odsłania slajd jednym, zgodnym z ruchem wskazówek zegara, przesunięciem; zweryfikowana liczba 8 odsłania go jednocześnie ośmioma sektorami. Zawartość docelowa i czas przejścia są identyczne, więc różnica polega wyłącznie na liczbie sektorów odsłaniania.

## **Przejście Reveal z efektem ThroughBlack**

Ustaw typ przejścia docelowego slajdu na Reveal, a następnie użyj [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) aby ustawić [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/). Przykład tworzy niebieskozielony slajd źródłowy i koralowy slajd docelowy, a następnie klonuje oba, aby móc porównać ten sam dwusekundowy efekt przejścia z wyłączonym i włączonym przyciemnieniem.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

W pokazie PowerPoint przejdź z slajdu 1 do slajdu 2. Niebieskozielony slajd płynnie przechodzi w koralowy. Następnie przejdź z slajdu 3 do slajdu 4. ekran krótkotrwale przyciemnia się do prawie czarnego, po czym pojawia się koralowy slajd. Oba slajdy zachowują swoje oryginalne kolory tła.

Poniższe wiersze pokazują klatki z PowerPoint w odstępach pół sekundy. Porównaj środkową klatkę w każdym wierszu, aby zobaczyć efekt ustawienia.

![Odtwarzanie PowerPoint z wyłączonym ThroughBlack (góra) i włączonym (dół). Tylko dolny wiersz przechodzi przez prawie czarny.](reveal-through-black.png)

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Poniższe właściwości kontrolują to zachowanie:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) umożliwia widzowi przejście po kliknięciu myszą.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) włącza automatyczne przechodzenie.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno przejście po kliknięciu, jak i po upłynięciu czasu, aby widz mógł przejść klikając lub poczekać na timer. Aby używać wyłącznie timera, ustaw [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania samego efektu wizualnego.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przejście w czasie jest włączone, odczytaj [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Sam zapisany czas opóźnienia nie oznacza, że timer jest aktywny.

Kolejny przykład otwiera powyżej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

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

Użyj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) aby określić dokładną długość efektu przejścia w milisekundach. Właściwość [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu udostępnia te ustawienia poprzez [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Właściwość | Cel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Włącz [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) aby aktywować ten timer. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, lub Fast. Jest używana, gdy nie podano dokładnego czasu trwania. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia konfiguruje się osobno. Gdy nie ustawiono wyraźnego czasu trwania, Aspose.Slides wyznacza go na podstawie typu przejścia i wartości [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby uzyskać równomierne tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera przejście Fade z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przejście po 5 000 milisekund i wyłącza przejście po kliknięciu myszy, a następnie zapisuje wynik jako PPTX.

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

Różne slajdy mogą używać różnych czasów trwania efektu. Na przykład użyj krótkiego przejścia dla slajdu tytułowego i dłuższego przejścia dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

Przy przygotowywaniu [animated GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/net/export-to-html5/) lub [video](/slides/pl/net/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600 ms zaniku między scenami i dostosuj osobno opóźnienie przejścia każdego slajdu, aby umożliwić czas na narrację lub zawartość.

Dla GIF‑ów i wideo skoordynuj liczbę klatek na sekundę z czasem trwania efektu: 600 ms odpowiada 18 klatkom przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, jakie efekty i opcje czasowe obsługuje wybrany format eksportu i podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Odczytaj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) przed modyfikacją przejścia, aby określić, czy zapisano wyraźną wartość. Wartość `-1` oznacza brak ustawionego czasu trwania; nieujemna wartość określa zapisany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź oryginalne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby utworzyć prosty efekt Morph, sklonuj slajd, przemieść lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. Daje to obiektom przejścia możliwość animacji pomiędzy ich oryginalnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go i zmienia położenie oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt w trakcie pokazu slajdów.

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

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) określa, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując słowa tam, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Ustaw [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) przejścia na Morph przed dostępem do jego [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Wartość zwraca interfejs [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), którego właściwość [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd do animacji Morph opartej na słowach.

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
[![Jednostki dopasowania Morph pokazane jako cały kształt, poszczególne słowa i poszczególne znaki.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph może dopasowywać całe kształty, słowa lub znaki, gdzie to możliwe. Te pola identyfikują jednostki dopasowania, a nie obserwowany ruch. Przykład wybiera ByWord na drugim slajdzie.*
<!-- visual-explanation:slide-transition:end -->

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt rozpoczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Najpierw ustaw typ, a następnie użyj odpowiedniego interfejsu z jego [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

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

Tak. Preferuj [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), gdy wystarczy predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium lub Fast, a nie ustawiono wyraźnego czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzać?**

Tak. Przypisz osadzony dźwięk do [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), ustaw [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), i włącz [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Dźwięk będzie się powtarzał aż do kolejnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Iteruj po kolekcji [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) prezentacji i ustaw każdej slajdowi przejście [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na tę samą wartość. W tym samym pętli ustaw wszystkie opcje czasowe i efektowe, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Odczytaj właściwość [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) z [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) slajdu. Zwraca ona wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None oznacza, że żadne przejście nie jest zastosowane.