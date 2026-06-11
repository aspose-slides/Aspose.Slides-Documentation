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
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla C++, z instrukcjami krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przejście po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawić opcje efektu przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejścia dla wybranych slajdów i zapisać wynik jako plik PPTX. Artykuł odpowiada również na typowe pytania dotyczące prędkości przejścia, dźwięków przejścia, stosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodawanie przejścia slajdu**
Aby ułatwić zrozumienie, przedstawiliśmy użycie Aspose.Slides for C++ do zarządzania prostymi przejściami slajdów. Programiści mogą nie tylko stosować różne efekty przejścia slajdów, ale także dostosowywać zachowanie tych efektów. Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Zastosuj typ przejścia slajdu na wybranym slajdzie, korzystając z jednej z dostępnych w Aspose.Slides for C++ wartości wyliczenia TransitionType.
1. Zapisz zmodyfikowany plik prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Dodawanie zaawansowanego przejścia slajdu**
W poprzedniej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Aby uczynić ten efekt lepszym i bardziej kontrolowanym, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
1. Zastosuj typ przejścia slajdu na wybranym slajdzie, korzystając z jednej z dostępnych w Aspose.Slides for C++ wartości wyliczenia TransitionType.
1. Możesz także ustawić przejście na „Advance On Click”, po określonym czasie lub oba te tryby.
1. Jeśli przejście slajdu jest włączone jako „Advance On Click”, przejście nastąpi tylko po kliknięciu myszy. Ponadto, jeśli ustawiona jest właściwość „Advance After Time”, przejście zostanie wykonane automatycznie po upływie określonego czasu.
1. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Przejście Morph**
Aspose.Slides for C++ obsługuje teraz przejście Morph. Reprezentuje ono nowy rodzaj przejścia wprowadzonego w PowerPoint 2019. Przejście Morph umożliwia płynną animację ruchu z jednego slajdu na kolejny. W tym artykule opisano koncepcję i sposób użycia przejścia Morph. Aby efektywnie korzystać z przejścia Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najprostszy sposób to skopiowanie slajdu i przemieszczenie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z tekstem do prezentacji i ustawić przejście typu Morph na drugim slajdzie.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Typy przejścia Morph**
Dodano nowy wyliczeniowy typ Aspose.Slides.SlideShow.TransitionMorphType. Reprezentuje on różne typy przejścia Morph.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: przejście Morph jest wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: przejście Morph jest wykonywane poprzez przenoszenie tekstu słowo po słowie, o ile to możliwe.
- ByChar: przejście Morph jest wykonywane poprzez przenoszenie tekstu znak po znaku, o ile to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście Morph na slajdzie i zmienić jego typ:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Ustawianie efektów przejścia**
Aspose.Slides for C++ umożliwia ustawianie efektów przejścia, takich jak z czarnego, z lewej, z prawej itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation.
- Pobierz referencję do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy efekty przejścia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Ustaw prędkość przejścia za pomocą właściwości [speed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) oraz ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/transitionspeed/) (np. slow/medium/fast).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować zachowanie za pomocą ustawień, takich jak [set_Sound](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), a także metadane, takie jak [set_SoundIsBuiltIn](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) i [set_SoundName](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/).

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane osobno dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach daje jednolity rezultat.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Sprawdź ustawienia przejścia slajdu za pomocą [get_SlideshowTransition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.baseslide/get_slideshowtransition/) i odczytaj jego [type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); ta wartość dokładnie informuje, który efekt jest zastosowany.