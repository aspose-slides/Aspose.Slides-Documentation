---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w PHP
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/php-java/powerpoint-animation/
keywords:
- dodaj animację
- zaktualizuj animację
- zmień animację
- usuń animację
- zarządzaj animacją
- kontroluj animację
- efekt animacji
- animacja PowerPoint
- linia czasu animacji
- animacja interaktywna
- animacja niestandardowa
- animacja kształtu
- animowany wykres
- animowany tekst
- animowany kształt
- animowany obiekt OLE
- animowany obraz
- animowana tabela
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides for PHP via Java w obsłudze animacji PowerPoint. Kluczowe funkcje i wskazówki, aby ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają za zadanie przedstawić coś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas ich tworzenia.

**PowerPoint animation** odgrywa ważną rolę, aby prezentacja była przyciągająca uwagę i atrakcyjna dla odbiorców. Aspose.Slides for PHP via Java oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- zastosować różne typy efektów animacji PowerPoint na kształtach, wykresach, tabelach, obiektach OLE i innych elementach prezentacji.
- używać wielu efektów animacji PowerPoint na jednym kształcie.
- używać linii czasu animacji do kontrolowania efektów animacji.
- utworzyć niestandardową animację.

W Aspose.Slides for PHP via Java można zastosować różne efekty animacji na kształtach. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekt OLE, tabela itp., jest traktowany jako kształt, oznacza to, że możemy zastosować efekt animacji na każdym elemencie slajdu.

## **Efekty animacji**
Aspose.Slides obsługuje **150+ efektów animacji**, w tym podstawowe efekty animacji takie jak Bounce, PathFootball, efekt Powiększenia oraz specyficzne efekty animacji takie jak OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji można znaleźć w wyliczeniu [**EffectType**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttype/) .

Dodatkowo, te efekty animacji mogą być używane w połączeniu z nimi:
- [ColorEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SetEffect)

## **Animacja niestandardowa**
Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. 
Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[**Behavior**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Behavior) jest jednostką budującą każdy efekt animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zestawem zachowań złożonych w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint – stanie się to kolejną animacją niestandardową. Na przykład możesz dodać zachowanie powtórzenia do animacji, aby powtarzała się kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Point) to punkt, w którym powinno być zastosowane zachowanie.

## **Oś czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Sequence) jest zbiorem efektów animacji, stosowanym na konkretnym kształcie.

[**Timeline**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/AnimationTimeLine) jest zestawem Sekwencji używanych na konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Timeline zastępuje starą klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy animacji PowerPoint. Jeden slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[**Trigger**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/EffectTriggerType) umożliwia definiowanie akcji użytkownika (np. kliknięcie przycisku), które spowodują rozpoczęcie określonej animacji. Wyzwalacze zostały dodane dopiero w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="primary" %}} 
Czytaj więcej [**O animacji kształtów**](/slides/pl/php-java/shape-animation/).
{{% /alert %}}

## **Wykresy animowane**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animację PowerPoint można stosować tylko na kategoriach wykresu lub seriach wykresu. Można także zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="primary" %}} 
Czytaj więcej [**O wykresach animowanych**](/slides/pl/php-java/animated-charts/).
{{% /alert %}}

## **Tekst animowany**
Oprócz animowanego tekstu, możliwe jest również zastosowanie animacji do akapitu.

{{% alert color="primary" %}} 
Czytaj więcej [**O tekście animowanym**](/slides/pl/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/php-java/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/php-java/export-to-html5/), [animowanego GIF](/slides/pl/php-java/convert-powerpoint-to-animated-gif/), lub [wideo](/slides/pl/php-java/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek oraz rozmiar klatki?**

Tak. Możesz [wyświetlić prezentację jako klatki](/slides/pl/php-java/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając liczbę klatek na sekundę (FPS) i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/php-java/open-presentation/) i [zapisywaniu](/slides/pl/php-java/save-presentation/), ale różnice w formatach oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych przykładów.