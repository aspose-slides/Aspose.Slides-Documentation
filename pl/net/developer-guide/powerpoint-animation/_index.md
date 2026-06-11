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

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny oraz zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w czynieniu prezentacji przyciągającej uwagę i angażującej odbiorców. Aspose.Slides for .NET udostępnia szeroką gamę opcji dodawania animacji do prezentacji PowerPoint:

- Stosuj różne rodzaje efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Używaj wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystuj oś czasu animacji do kontrolowania efektów animacji.
- Twórz niestandardowe animacje.

W Aspose.Slides for .NET można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest uważany za kształt, efekty animacji mogą być zastosowane do dowolnego elementu na slajdzie.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/) namespace zapewnia klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom, a także konkretne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype).

Dodatkowo, te efekty animacji mogą być używane w połączeniu z następującymi:

- [ColorEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/seteffect)

## **Niestandardowa animacja**

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behaviour](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/behavior) jest elementem budulcowym każdego efektu animacji PowerPoint. Wszystkie efekty animacji to w zasadzie zestaw zachowań składających się w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, stanie się ono kolejną animacją niestandardową. Na przykład, możesz dodać zachowanie powtarzania do animacji, aby powtórzyła się kilka razy.

[Animation Point](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/point) jest punktem, w którym należy zastosować zachowanie.

## **Oś czasu animacji**

[Sequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/sequence) jest kolekcją efektów animacji zastosowanych do określonego kształtu.

[Timeline](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animationtimeline) jest zestawem sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i można było to osiągnąć jedynie przy użyciu różnych obejść. Oś czasu zastępuje starą klasę AnimationSettings i zapewnia przejrzystszy model obiektowy dla animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[Trigger](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype) pozwala zdefiniować akcje użytkownika (np. kliknięcie przycisku), które uruchomią określoną animację. Wyzwalacze zostały wprowadzone w najnowszej wersji PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="primary" %}} 
Czytaj więcej [**O animacji kształtów**](/slides/pl/net/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**

Aby utworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint mogą być stosowane wyłącznie do kategorii wykresu lub serii wykresu. Można również zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="primary" %}} 
Czytaj więcej [**O animowanych wykresach**](/slides/pl/net/animated-charts/).
{{% /alert %}}

## **Animowany tekst**

Oprócz animowanego tekstu, można również zastosować animację do akapitu.

{{% alert color="primary" %}} 
Czytaj więcej [**O animowanym tekście**](/slides/pl/net/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/net/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/net/export-to-html5/), [animowanego GIF](/slides/pl/net/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/net/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wykonać renderowanie prezentacji jako klatki](/slides/pl/net/convert-powerpoint-to-video/) i zakodować je w wideo (np. przy użyciu ffmpeg), wybierając liczbę klatek na sekundę i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (a nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/net/open-presentation/) i [zapisu](/slides/pl/net/save-presentation/), ale różnice formatów oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych próbek.