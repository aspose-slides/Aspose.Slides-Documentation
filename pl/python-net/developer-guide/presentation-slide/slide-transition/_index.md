---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu Pythona
linktitle: Przejście slajdu
type: docs
weight: 90
url: /pl/python-net/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- zastosuj przejście slajdu
- zaawansowane przejście slajdu
- przejście morph
- typ przejścia
- efekt przejścia
- Python
- Aspose.Slides
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides for Python poprzez .NET, z instrukcją krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides for Python zapewnia pełną kontrolę nad przejściami slajdów, począwszy od wyboru typu przejścia, po konfigurowanie czasu i wyzwalaczy w ramach zautomatyzowanych przepływów pracy prezentacji. Możesz ustawić, aby slajdy przechodziły po kliknięciu i/lub po określonym opóźnieniu oraz dopracować zachowanie wizualne za pomocą efektów, takich jak przejścia z czerni lub wejścia w określonym kierunku. Biblioteka obsługuje również przejście Morph wprowadzone w PowerPoint 2019, w tym tryby morphingu według obiektu, słowa lub znaku, aby uzyskać płynny, spójny ruch między slajdami.

## **Dodaj przejścia slajdów**

Aby ułatwić zrozumienie, ten przykład pokazuje, jak używać Aspose.Slides for Python do zarządzania prostymi przejściami slajdów. Programiści mogą stosować różne efekty przejść slajdów i dostosowywać ich zachowanie. Aby stworzyć proste przejście slajdu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Zastosuj przejście slajdu używając jednego z efektów z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/transitiontype/) .
1. Zapisz zmodyfikowany plik prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby wczytać plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    # Zastosuj przejście koła do slajdu 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Zastosuj przejście grzebieniowe do slajdu 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Zapisz prezentację na dysku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj zaawansowane przejścia slajdów**

W tej sekcji zastosowaliśmy prosty efekt przejścia do slajdu. Aby uczynić ten efekt bardziej kontrolowanym i dopracowanym, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Zastosuj przejście slajdu używając jednego z efektów z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/transitiontype/) .
1. Skonfiguruj przejście, aby przechodziło po kliknięciu, po określonym czasie lub oba.
1. Zapisz zmodyfikowany plik prezentacji.

Jeśli **Advance On Click** jest włączona, slajd przechodzi tylko po kliknięciu użytkownika. Jeśli ustawiono właściwość **Advance After Time**, slajd przechodzi automatycznie po określonym przedziale czasu.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Zastosuj przejście koła do slajdu 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Włącz przejście po kliknięciu i ustaw automatyczne przejście po 3 sekundach.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Zastosuj przejście grzebieniowe do slajdu 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Włącz przejście po kliknięciu i ustaw automatyczne przejście po 5 sekundach.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Zastosuj przejście przybliżenia do slajdu 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Włącz przejście po kliknięciu i ustaw automatyczne przejście po 7 sekundach.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Zapisz prezentację na dysku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Przejście Morph**

Aspose.Slides for Python obsługuje [przejście Morph](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/morphtransition/), które animuje płynny ruch z jednego slajdu do drugiego. Ta sekcja wyjaśnia, jak używać przejścia Morph. Aby używać go efektywnie, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najprostsze rozwiązanie to zduplikowanie slajdu, a następnie przeniesienie obiektu na inną pozycję na drugim slajdzie.

Poniższy fragment kodu pokazuje, jak sklonować slajd zawierający tekst i zastosować przejście Morph do drugiego slajdu.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Sklonuj pierwszy slajd, aby utworzyć drugi slajd z tymi samymi kształtami dla ciągłości Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Wybierz ten sam prostokąt na drugim slajdzie i zmień jego pozycję oraz rozmiar.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Włącz przejście Morph na drugim slajdzie, aby płynnie animować zmiany kształtu.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Typy przejść Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/transitionmorphtype/) reprezentuje różne typy przejść Morph dla slajdów.

Poniższy fragment kodu pokazuje, jak zastosować przejście Morph do slajdu i zmienić typ morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw efekty przejść**

Aspose.Slides for Python pozwala ustawiać efekty przejść, takie jak **From Black**, **From Left**, **From Right** itp. Aby skonfigurować efekt przejścia, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Uzyskaj referencję do slajdu.
1. Ustaw żądany efekt przejścia.
1. Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiamy kilka efektów przejść.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Zastosuj przejście Cut i włącz From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Zapisz prezentację na dysku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**  

Tak. Ustaw prędkość przejścia za pomocą [speed](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/speed/) , używając ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/transitionspeed/) , (np. wolna/średnia/szybka).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**  

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować jego zachowanie za pomocą ustawień, takich jak tryb dźwięku i pętla (np. [sound](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), oraz metadane, takie jak [sound_is_built_in](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) i [sound_name](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**  

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane per slajd, więc zastosowanie tego samego typu we wszystkich slajdach zapewnia spójny rezultat.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**  

Sprawdź ustawienia przejścia slajdu ([transition settings](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/slide_show_transition/)) i odczytaj jego [transition type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/type/) ; ta wartość dokładnie określa, który efekt jest zastosowany.