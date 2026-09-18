---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w .NET
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/net/powerpoint-animation/
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
- prezentacja PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides dla .NET w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak ulepszyć swoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają coś przedstawić, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w sprawianiu, że prezentacja jest przyciągająca uwagę i angażująca dla odbiorców. Aspose.Slides for .NET zapewnia szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Użyj wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystaj oś czasu animacji do sterowania efektami animacji.
- Twórz animacje niestandardowe.

W Aspose.Slides for .NET można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest uznawany za kształt, efekty animacji mogą być stosowane do dowolnego elementu na slajdzie.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/) namespace zapewnia klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom, a także specyficzne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype).

Ponadto, te efekty animacji mogą być używane w połączeniu z następującymi:

- [ColorEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/seteffect)

## **Animacja niestandardowa**

Aby zobaczyć pełne przykłady C# tworzące, sprawdzające i modyfikujące zachowania oraz edytowalne ścieżki ruchu, zobacz [Custom Animation](/slides/pl/net/custom-animation/).

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behavior](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/behavior) jest podstawowym elementem efektu animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć zdefiniowany wcześniej efekt. Powtarzanie jest konfigurowane poprzez ustawienia czasu, a nie oddzielne zachowanie powtórzenia.

[Animation Point](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/point) jest punktem, w którym powinno zostać zastosowane zachowanie.

## **Oś czasu animacji**

[Sequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/sequence) jest kolekcją efektów animacji, które mogą dotyczyć różnych kształtów.

[Timeline](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animationtimeline) jest zestawem sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W starszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i można było to osiągnąć jedynie przy użyciu różnych obejść. Oś czasu zastępuje starą klasę AnimationSettings i zapewnia bardziej przejrzysty model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[Trigger](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype) pozwala zdefiniować akcje użytkownika (np. kliknięcie przycisku), które uruchomią określoną animację. Wyzwalacze zostały wprowadzone w najnowszej wersji PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" title="Note" %}}
Read more [**O animacji kształtów**](/slides/pl/net/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**

Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint można stosować tylko do kategorii wykresu lub serii wykresu. Można także zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Note" %}}
Read more [**O animowanych wykresach**](/slides/pl/net/animated-charts/).
{{% /alert %}}

## **Animowany tekst**

Oprócz animowania tekstu, możesz zastosować animację do akapitu.

{{% alert color="info" title="Note" %}}
Read more [**O animowanym tekście**](/slides/pl/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/net/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/net/export-to-html5/), [animowanego GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/net/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/net/convert-powerpoint-to-video/) i zakodować je do wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/net/open-presentation/) i [zapisu](/slides/pl/net/save-presentation/), ale nie gwarantuje to zachowania animacji. Dane animacji niestandardowych mogą zostać utracone podczas konwersji do ODP. Zobacz [Custom Animation](/slides/pl/net/custom-animation/) po przetestowany przykład i ograniczenia formatu.