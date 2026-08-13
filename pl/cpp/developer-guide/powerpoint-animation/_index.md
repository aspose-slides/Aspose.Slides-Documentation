---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w C++
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/cpp/powerpoint-animation/
keywords:
- dodaj animację
- aktualizuj animację
- zmień animację
- usuń animację
- zarządzaj animacją
- kontroluj animację
- efekt animacji
- animacja PowerPoint
- oś czasu animacji
- animacja interaktywna
- animacja niestandardowa
- animacja kształtów
- animowany wykres
- animowany tekst
- animowany kształt
- animowany obiekt OLE
- animowany obraz
- animowana tabela
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać i kontrolować zaawansowane efekty animacji w Aspose.Slides dla C++, aby tworzyć dynamiczne prezentacje PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i interaktywne zachowanie są zawsze brane pod uwagę podczas ich tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę, aby uczynić prezentację przyciągającą uwagę i atrakcyjną dla widzów. Aspose.Slides for C++ oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- stosowanie różnych typów efektów animacji PowerPoint na kształtach, wykresach, tabelach, obiektach OLE i innych elementach prezentacji.
- użycie wielu efektów animacji PowerPoint na jednym kształcie.
- użycie osi czasu animacji do kontrolowania efektów.
- tworzenie własnych animacji.

W Aspose.Slides for C++ można zastosować różne efekty animacji na kształtach. Ponieważ każdy element slajdu, w tym tekst, obrazy, obiekt OLE, tabela itp., jest traktowany jako kształt, oznacza to, że możemy zastosować efekt animacji do każdego elementu slajdu.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation) **namespace** zapewnia klasy do pracy z animacjami PowerPoint.
## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty, takie jak Bounce, PathFootball, Zoom oraz specyficzne efekty, np. OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [**EffectType**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Dodatkowo te efekty animacji mogą być używane w połączeniu z:

- [ColorEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.set_effect)

## **Własna animacja**
Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. 
Można to osiągnąć, łącząc kilka zachowań w jedną nową animację niestandardową.

[**Behavior**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.behavior) jest jednostką budującą dowolny efekt animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zestawem zachowań składającym się w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, stanie się on kolejną animacją niestandardową. Na przykład możesz dodać zachowanie powtarzania do animacji, aby została odtworzona kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.point) to punkt, w którym powinno zostać zastosowane zachowanie.

## **Oś czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.sequence) to kolekcja efektów animacji zastosowanych do konkretnego kształtu.

[**AnimationTimeLine**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.animation_time_line) to zestaw sekwencji używany na konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Oś czasu zastępuje starą klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy dla animacji PowerPoint. Jeden slajd może mieć **tylko jedną** oś czasu animacji.
## **Animacja interaktywna**
[**EffectTriggerType**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) umożliwia definiowanie działań użytkownika (np. kliknięcie przycisku), które spowodują uruchomienie określonej animacji. Triggery zostały dodane dopiero w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides pozwala stosować animacje do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="info" %}} 
Czytaj więcej [**About Shape Animation**](/slides/pl/cpp/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co do kształtów. Jednak animację PowerPoint można zastosować wyłącznie do kategorii wykresu lub serii wykresu. Można także zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="info" %}} 
Czytaj więcej [**About Animated Charts**](/slides/pl/cpp/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowanego tekstu możliwe jest również zastosowanie animacji do akapitu.

{{% alert color="info" %}} 
Czytaj więcej [**About Animated Text**](/slides/pl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### Czy animacje zostaną zachowane przy eksportowaniu do PDF?

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/cpp/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/cpp/export-to-html5/), [animowanego GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/cpp/convert-powerpoint-to-video/) zamiast tego.

### Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/cpp/convert-powerpoint-to-video/) i zakodować je do wideo (np. przy użyciu ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

### Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/cpp/open-presentation/) i [zapisywaniu](/slides/pl/cpp/save-presentation/), ale różnice w formatach oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych próbek.