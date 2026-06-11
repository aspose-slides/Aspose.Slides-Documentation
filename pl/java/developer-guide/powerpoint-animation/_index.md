---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w Javie
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/java/powerpoint-animation/
keywords:
- dodaj animację
- zaktualizuj animację
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
- Java
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides for Java w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, aby ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w sprawieniu, że prezentacja przyciąga uwagę i angażuje odbiorców. Aspose.Slides oferuje szeroki zakres możliwości dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE oraz innych elementów prezentacji.
- Użyj wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystaj oś czasu animacji do kontrolowania efektów animacji.
- Twórz własne animacje.

W Aspose.Slides można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji mogą być stosowane do dowolnego elementu na slajdzie.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty animacji takie jak Bounce, PathFootball, efekt Zoom oraz specyficzne efekty animacji jak OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [**EffectType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effecttype/)enumeration.

Ponadto, te efekty animacji mogą być używane w połączeniu z nimi:

- [ColorEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SetEffect)

## **Animacja własna**
Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[**Behavior**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Behavior) jest jednostką budującą każdy efekt animacji PowerPoint. Wszystkie efekty animacji są w rzeczywistości zbiorem zachowań składających się w jedną strategię. Możesz połączyć zachowania w animację niestandardową jednorazowo i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint – stanie się to kolejną animacją niestandardową. Na przykład, możesz dodać zachowanie powtarzania do animacji, aby była ona odtwarzana kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Point) jest punktem, w którym należy zastosować zachowanie.

## **Oś czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Sequence) jest kolekcją efektów animacji, zastosowaną na konkretnym kształcie.

[**Timeline**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AnimationTimeLine) jest zbiorem Sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W poprzednich wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy użyciu różnych obejść. Oś czasu ma zastąpić starą klasę AnimationSettings i zapewnić bardziej przejrzysty model obiektowy dla animacji PowerPoint. Jeden slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[**Trigger**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectTriggerType) pozwala definiować akcje użytkownika (np. kliknięcie przycisku), które spowodują rozpoczęcie określonej animacji. Wyzwalacze zostały dodane tylko w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides umożliwia zastosowanie animacji do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="primary" %}} 
Czytaj więcej [**O animacji kształtów**](/slides/pl/java/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animację PowerPoint można zastosować tylko do kategorii wykresu lub serii wykresu. Można także zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="primary" %}} 
Czytaj więcej [**O animowanych wykresach**](/slides/pl/java/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowanego tekstu możliwe jest także zastosowanie animacji do akapitu.

{{% alert color="primary" %}} 
Czytaj więcej [**O animowanym tekście**](/slides/pl/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane podczas eksportu do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/java/slide-transition/) nie odtwarzają się. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/java/export-to-html5/), [animowanego GIF‑a](/slides/pl/java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/java/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wyświetlić prezentację jako klatki](/slides/pl/java/convert-powerpoint-to-video/) i zakodować je do wideo (np. przy użyciu ffmpeg), wybierając liczbę FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/java/open-presentation/) i [zapisu](/slides/pl/java/save-presentation/), ale różnice formatów mogą powodować, że niektóre efekty wyglądają lub zachowują się nieco inaczej. Zweryfikuj krytyczne przypadki na rzeczywistych próbkach.