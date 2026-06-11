---
title: Ulepsz prezentacje PowerPoint dzięki animacjom w C++
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
## **Wstęp**

Ponieważ prezentacje mają służyć przedstawieniu czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas ich tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę, aby prezentacja była przyciągająca wzrok i atrakcyjna dla odbiorców. Aspose.Slides for C++ oferuje szeroką gamę opcji dodawania animacji do prezentacji PowerPoint:

- zastosować różne rodzaje efektów animacji PowerPoint na kształtach, wykresach, tabelach, obiektach OLE i innych elementach prezentacji.
- użyć wielu efektów animacji PowerPoint na jednym kształcie.
- użyć osi czasu animacji do kontrolowania efektów animacji.
- tworzyć animacje niestandardowe.

W Aspose.Slides for C++ można zastosować różne efekty animacji na kształtach. Ponieważ każdy element slajdu, w tym tekst, obrazy, obiekt OLE, tabela itp., jest traktowany jako kształt, oznacza to, że możemy zastosować efekt animacji na każdym elemencie slajdu.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation) **namespace** udostępnia klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty animacji takie jak Bounce, PathFootball, efekt Zoom oraz specyficzne efekty animacji takie jak OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji można znaleźć w enumeracji [**EffectType**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Dodatkowo, te efekty animacji mogą być używane w połączeniu z nimi:

- [ColorEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.set_effect)

## **Animacja niestandardowa**

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides.  
Można to osiągnąć, łącząc kilka zachowań w jedną nową animację niestandardową.

[**Behavior**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.behavior) jest jednostką budulcową każdego efektu animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zestawem zachowań składającym się w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, stanie się ono kolejną animacją niestandardową. Na przykład, możesz dodać zachowanie powtórzenia do animacji, aby powtarzała się kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.point) jest miejscem, w którym należy zastosować zachowanie.

## **Oś czasu animacji**

[**Sequence**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.sequence) jest kolekcją efektów animacji, zastosowaną na konkretnym kształcie.

[**AnimationTimeLine**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.animation_time_line) jest zestawem Sequences używanym w konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy użyciu różnych obejść. Oś czasu zastępuje dawną klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy animacji PowerPoint. Jeden slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[**EffectTriggerType**](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) pozwala określić akcje użytkownika (np. kliknięcie przycisku), które spowodują rozpoczęcie określonej animacji. Wyzwalacze zostały dodane tylko w najnowszej wersji PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="primary" %}} 
Czytaj więcej [**About Shape Animation**](/slides/pl/cpp/shape-animation/).
{{% /alert %}}

## **Wykresy animowane**

Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak można stosować animację PowerPoint tylko na kategoriach wykresu lub seriach wykresu. Można także zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="primary" %}} 
Czytaj więcej [**About Animated Charts**](/slides/pl/cpp/animated-charts/).
{{% /alert %}}

## **Tekst animowany**

Oprócz animowanego tekstu, możliwe jest również zastosowanie animacji do akapitu.

{{% alert color="primary" %}} 
Czytaj więcej [**About Animated Text**](/slides/pl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/cpp/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/cpp/export-to-html5/), [animowanego GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/cpp/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wykonać renderowanie prezentacji jako klatki](/slides/pl/cpp/convert-powerpoint-to-video/) i zakodować je do wideo (np. za pomocą ffmpeg), wybierając liczbę klatek na sekundę i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

Formaty PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/cpp/open-presentation/) i [zapisu](/slides/pl/cpp/save-presentation/), ale różnice formatów oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych próbek.