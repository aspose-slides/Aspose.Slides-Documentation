---
title: Zwiększ prezentacje PowerPoint dzięki animacjom na Androidzie
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/androidjava/powerpoint-animation/
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
- animacja kształtów
- animowany wykres
- animowany tekst
- animowany kształt
- animowany obiekt OLE
- animowany obraz
- animowana tabela
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides dla Androida przy użyciu Java w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas ich tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę, aby prezentacja była atrakcyjna i przyciągająca uwagę widzów. Aspose.Slides for Android via Java oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- zastosować różne typy efektów animacji PowerPoint na kształtach, wykresach, tabelach, obiektach OLE i innych elementach prezentacji.
- używać wielu efektów animacji PowerPoint na jednym kształcie.
- używać linii czasu animacji do sterowania efektami animacji.
- tworzyć animacje niestandardowe.

W Aspose.Slides for Android via Java można zastosować różne efekty animacji na kształtach. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekt OLE, tabela itp., jest traktowany jako kształt, oznacza to, że możemy zastosować efekt animacji na każdym elemencie slajdu.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty animacji, takie jak Bounce, PathFootball, efekt Zoom oraz specyficzne efekty animacji, takie jak OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji znajdziesz w [**EffectType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttype/) enumeracji.

Ponadto te efekty animacji mogą być używane w połączeniu z:

- [ColorEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SetEffect)

## **Animacja niestandardowa**
Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. 
Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[**Behavior**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Behavior) jest jednostką budującą każdego efektu animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zestawem zachowań składających się w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint – stanie się to kolejną animacją niestandardową. Na przykład możesz dodać zachowanie powtarzania do animacji, aby powtarzała się kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Point) jest punktem, w którym powinno być zastosowane zachowanie.

## **Linia czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Sequence) jest kolekcją efektów animacji zastosowanych na konkretnym kształcie.

[**Timeline**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/AnimationTimeLine) jest zestawem Sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Timeline zastępuje starą klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy animacji PowerPoint. Jeden slajd może mieć tylko jedną linię czasu animacji.

## **Animacja interaktywna**
[**Trigger**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/EffectTriggerType) umożliwia określenie akcji użytkownika (np. kliknięcie przycisku), które spowodują rozpoczęcie określonej animacji. Wyzwalacze zostały dodane tylko w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą być rzeczywiście tekstem, prostokątem, linią, ramką, obiektem OLE itp.

{{% alert color="info" %}} 
Dowiedz się więcej [**O animacji kształtów**](/slides/pl/androidjava/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Do tworzenia animowanych wykresów należy używać tych samych klas co dla kształtów. Jednak animację PowerPoint można zastosować tylko do kategorii wykresu lub serii wykresu. Można również zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="info" %}} 
Dowiedz się więcej [**O animowanych wykresach**](/slides/pl/androidjava/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowanego tekstu możliwe jest również zastosowanie animacji do akapitu.

{{% alert color="info" %}} 
Dowiedz się więcej [**O animowanym tekście**](/slides/pl/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### Czy animacje zostaną zachowane przy eksportowaniu do PDF?

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/androidjava/slide-transition/) nie odtwarzają się. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/androidjava/export-to-html5/), [animowanego GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/androidjava/convert-powerpoint-to-video/) zamiast tego.

### Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?

Tak. Możesz [wykonać rendering prezentacji jako klatki](/slides/pl/androidjava/convert-powerpoint-to-video/) i zakodować je w wideo (np. przy użyciu ffmpeg), wybierając liczbę klatek na sekundę i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

### Czy animacje pozostaną nienaruszone podczas pracy z ODP (nie tylko PPTX)?

Formaty PPT, PPTX i ODP są obsługiwane zarówno przy [odczycie](/slides/pl/androidjava/open-presentation/) i [zapisie](/slides/pl/androidjava/save-presentation/), jednak różnice w formatach mogą powodować, że niektóre efekty będą wyglądały lub zachowywały się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych przykładów.