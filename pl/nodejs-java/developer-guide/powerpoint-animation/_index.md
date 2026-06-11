---
title: Ulepsz prezentacje PowerPoint animacjami w JavaScript
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/nodejs-java/powerpoint-animation/
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
- interaktywna animacja
- niestandardowa animacja
- animacja kształtów
- animowany wykres
- animowany tekst
- animowany kształt
- animowany obiekt OLE
- animowany obraz
- animowana tabela
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj Aspose.Slides for Node.js via Java do obsługi animacji PowerPoint. Ten przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje służą do przedstawiania czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę przy ich tworzeniu.

**Animacja PowerPoint** odgrywa ważną rolę, aby uczynić prezentację przyciągającą uwagę i atrakcyjną dla odbiorców. Aspose.Slides for Node.js via Java oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- zastosować różne typy efektów animacji PowerPoint na kształtach, wykresach, tabelach, obiektach OLE i innych elementach prezentacji.
- używać wielu efektów animacji PowerPoint na jednym kształcie.
- używać linii czasu animacji do kontrolowania efektów animacji.
- tworzyć niestandardowe animacje.

W Aspose.Slides for Node.js via Java, różne efekty animacji mogą być stosowane na kształtach. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekt OLE, tabela itp., jest traktowany jako kształt, oznacza to, że możemy zastosować efekt animacji na każdym elemencie slajdu.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty animacji takie jak Bounce, PathFootball, efekt Zoom oraz specyficzne efekty animacji jak OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [**EffectType**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttype/).

Dodatkowo, te efekty animacji mogą być używane w połączeniu z:

- [ColorEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SetEffect)

## **Niestandardowa animacja**
Możliwe jest tworzenie własnych **niestandardowych animacji** w Aspose.Slides.  
Można to osiągnąć, łącząc kilka zachowań w nową niestandardową animację.

[**Behavior**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Behavior) jest jednostką budulcową każdego efektu animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zestawem zachowań składającym się w jedną strategię. Możesz połączyć zachowania w niestandardową animację raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, powstanie kolejna niestandardowa animacja. Na przykład, możesz dodać zachowanie powtarzania do animacji, aby powtórzyła się kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Point) jest punktem, w którym powinno być zastosowane zachowanie.

## **Linia czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Sequence) jest zbiorcą efektów animacji zastosowanych do konkretnego kształtu.

[**Timeline**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AnimationTimeLine) jest zbiorem Sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy różnych obejściach. Linia czasu zastępuje starą klasę AnimationSettings i zapewnia jaśniejszy model obiektowy animacji PowerPoint. Jeden slajd może mieć tylko jedną linię czasu animacji.

## **Animacja interaktywna**
[**Trigger**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/EffectTriggerType) umożliwia definiowanie działań użytkownika (np. kliknięcie przycisku), które uruchomią określoną animację. Wyzwalacze zostały dodane dopiero w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="primary" %}} 
Przeczytaj więcej [**O animacji kształtów**](/slides/pl/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animację PowerPoint można zastosować tylko do kategorii wykresu lub serii wykresu. Można również zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="primary" %}} 
Przeczytaj więcej [**O animowanych wykresach**](/slides/pl/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowanego tekstu, możliwe jest także zastosowanie animacji do akapitu.

{{% alert color="primary" %}} 
Przeczytaj więcej [**O animowanym tekście**](/slides/pl/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane podczas eksportu do PDF?**

No. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/nodejs-java/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/nodejs-java/export-to-html5/), [animowanego GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/).

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wykonywać renderowanie prezentacji jako klatki](/slides/pl/nodejs-java/convert-powerpoint-to-video/) i kodować je do wideo (np. za pomocą ffmpeg), wybierając liczbę klatek na sekundę (FPS) i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane dla [odczytu](/slides/pl/nodejs-java/open-presentation/) i [zapisu](/slides/pl/nodejs-java/save-presentation/), ale różnice formatów oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych próbek.