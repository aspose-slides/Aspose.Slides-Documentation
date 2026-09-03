---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu C++
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/cpp/slide-transition/
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
- C++
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides for C++."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu. Dzięki Aspose.Slides for C++ możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przejście po kliknięciu myszy lub po upływie czasu oraz dostosować opcje specyficzne dla efektu. Ten artykuł używa przykładów w C++, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać czasem wyświetlania slajdów i stworzyć przejście Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [get_SlideShowTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Wywołaj [set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_type/) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu oraz przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) umożliwia widzowi przejście po kliknięciu myszy.
- [set_AdvanceAfter](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceafter/) włącza automatyczne przejście.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz oba tryby – kliknięcie i odliczanie – aby widz mógł przejść po kliknięciu lub poczekać na timer. Aby używać tylko timera, wywołaj [set_AdvanceOnClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) z wartością `false`. Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie określa czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy także mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Aby sprawdzić, czy automatyczne przejście jest włączone, wywołaj [get_AdvanceAfter](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Sama zapisana wartość opóźnienia nie oznacza, że timer jest aktywny.

Kolejny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [set_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_duration/) aby określić dokładną długość efektu przejścia w milisekundach. Metoda [get_SlideShowTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) slajdu udostępnia te ustawienia za pośrednictwem [ISlideShowTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_duration/) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Wywołaj [set_AdvanceAfter](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_advanceafter/) z `true`, aby aktywować timer. |
| [set_Speed](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_speed/) | Wybiera jedną z predefiniowanych kategorii prędkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium lub Fast. Używana, gdy nie określono dokładnego czasu trwania. |

[set_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_duration/) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia konfiguruje się oddzielnie. Gdy nie zostanie ustawiony explicite czas trwania, Aspose.Slides wylicza go na podstawie typu przejścia oraz wartości zwracanej przez [get_Speed](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby uzyskać równomierne tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitiontype/) i nadaje każdemu przejściu czas trwania 750 ms. Oddzielnie włącza automatyczne przejście po 5 000 ms i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Ustaw różne czasy trwania dla pojedynczych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektu. Na przykład krótkie przejście dla slajdu tytułowego i dłuższe dla wprowadzenia sekcji. Przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Koordynuj przejścia z animowanym wyjściem**

Podczas przygotowywania [animated GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/cpp/export-to-html5/), lub [video](/slides/pl/cpp/convert-powerpoint-to-video/), ustaw dokładne czasy przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj przejścia fade trwającego 600 ms między scenami i oddzielnie dostosuj opóźnienie przejścia każdego slajdu, aby zapewnić czas na narrację lub treść.

Dla GIF i wideo koordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 ms to 18 klatek przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasu są obsługiwane przez wybrany format i podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [get_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_duration/) przed modyfikacją przejścia, aby sprawdzić, czy zapisano explicite wartość. Wartość `-1` oznacza brak ustawionego czasu trwania; nieujemna wartość określa zapisany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia oraz wartości zwracanej przez [get_Speed](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_speed/), aby określić ten czas. Ustawienie typu przejścia może zainicjować czas trwania, dlatego najpierw sprawdź oryginalne ustawienia.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Przejście Morph**

Przejście Morph animuje zmiany pomiędzy obiektami na kolejnych slajdach. Aby utworzyć proste przejście Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na kopii i zastosuj przejście Morph do drugiego slajdu. Dzięki temu odpowiednie obiekty będą animowane między swoim pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Typy przejść Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionmorphtype/) określa, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionmorphtype/) traktuje każdy kształt jako pojedynczy obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując słowa tam, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Wywołaj [set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_type/) z wartością Morph przed uzyskaniem [get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_value/). Uzyskana wartość zapewnia interfejs [IMorphTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/imorphtransition/), którego metoda [set_MorphType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd do użycia animacji Morph opartej na słowach.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego typu przejścia. Najpierw ustaw typ, a następnie użyj odpowiedniego interfejsu zwróconego przez [get_Value](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_value/).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [set_FromBlack](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) z wartością `true` poprzez [IOptionalBlackTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/ioptionalblacktransition/), aby przejście zaczynało się od czarnego ekranu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**Czy mogę kontrolować szybkość odtwarzania przejścia slajdu?**

Tak. Preferuj [set_Duration](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_duration/), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [set_Speed](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_speed/), gdy wystarcza kategoria [TransitionSpeed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionspeed/) – Slow, Medium lub Fast – i nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Przypisz wbudowany dźwięk przy pomocy [set_Sound](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_sound/), wywołaj [set_SoundMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_soundmode/) z wartością StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionsoundmode/), oraz włącz pętlę przy pomocy [set_SoundLoop](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_soundloop/). Dźwięk będzie powtarzany aż do następnego zdarzenia dźwiękowego w pokazie.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Iteruj po kolekcji zwróconej przez metodę [get_Slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slides/) prezentacji i wywołaj [set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/set_type/) z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie czasy i opcje efektów w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideshowtransition/get_type/) na przejściu zwróconym przez metodę [get_SlideShowTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) slajdu. Zwróci wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitiontype/); None oznacza, że żadne przejście nie jest zastosowane.