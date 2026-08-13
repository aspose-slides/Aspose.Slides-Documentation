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
description: "Poznaj możliwości Aspose.Slides dla Javy w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, które pomogą ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają przedstawiać treść, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w przyciąganiu uwagi i angażowaniu widzów. Aspose.Slides oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.  
- Użyj wielu efektów animacji PowerPoint na jednym kształcie.  
- Wykorzystaj oś czasu animacji do sterowania efektami animacji.  
- Twórz własne animacje.

W Aspose.Slides można stosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji mogą być zastosowane do dowolnego elementu slajdu.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty, takie jak Bounce, PathFootball, Zoom oraz specyficzne efekty, np. OLEObjectShow, OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [**EffectType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effecttype/).

Dodatkowo te efekty animacji można łączyć ze sobą:

- [ColorEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SetEffect)

## **Niestandardowa animacja**
W Aspose.Slides możesz tworzyć własne **niestandardowe animacje**.  
Można to osiągnąć, łącząc kilka zachowań w jedną nową animację.

[**Behavior**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Behavior) jest jednostką budującą każdy efekt animacji PowerPoint. Wszystkie efekty animacji to w rzeczywistości zestaw zachowań połączonych w jedną strategię. Możesz połączyć zachowania w niestandardową animację raz i ponownie używać jej w innych prezentacjach. Dodanie nowego zachowania do standardowego efektu animacji PowerPoint tworzy kolejną niestandardową animację. Na przykład możesz dodać zachowanie powtórzenia, aby animacja powtarzała się kilka razy.

[**Animation Point**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Point) to punkt, w którym powinno zostać zastosowane zachowanie.

## **Oś czasu animacji**
[**Sequence**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Sequence) to zbiór efektów animacji stosowanych do konkretnego kształtu.

[**Timeline**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/AnimationTimeLine) to zestaw sekwencji używanych na konkretnym slajdzie. Jest to silnik animacji dostępny od PowerPoint 2002. W starszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Oś czasu zastępuje starą klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy dla animacji PowerPoint. Jeden slajd może mieć **tylko jedną** oś czasu animacji.

## **Animacja interaktywna**
[**Trigger**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/EffectTriggerType) pozwala określić akcje użytkownika (np. kliknięcie przycisku), które spowodują uruchomienie określonej animacji. Triggery zostały wprowadzone dopiero w najnowszej wersji PowerPoint.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, którymi mogą być tekst, prostokąt, linia, ramka, obiekt OLE itp.

{{% alert color="info" %}} 
Przeczytaj więcej [**O animacji kształtów**](/slides/pl/java/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animację w PowerPoint można stosować wyłącznie do kategorii wykresu lub serii wykresu. Możesz także zastosować efekt animacji do elementu kategorii lub elementu serii.

{{% alert color="info" %}} 
Przeczytaj więcej [**O animowanych wykresach**](/slides/pl/java/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowanego tekstu, możliwe jest także zastosowanie animacji do akapitu.

{{% alert color="info" %}} 
Przeczytaj więcej [**O animowanym tekście**](/slides/pl/java/animated-text/).
{{% /alert %}}

## **FAQ**

### Czy animacje zostaną zachowane przy eksporcie do PDF?

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/java/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/java/export-to-html5/), [animowanego GIF-a](/slides/pl/java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/java/convert-powerpoint-to-video/) zamiast tego.

### Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/java/convert-powerpoint-to-video/) i zakodować je w wideo (np. przy użyciu ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

### Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/java/open-presentation/) i [zapisie](/slides/pl/java/save-presentation/), ale różnice formatów mogą powodować nieco inne wyświetlanie lub zachowanie niektórych efektów. Zweryfikuj krytyczne przypadki na rzeczywistych próbkach.