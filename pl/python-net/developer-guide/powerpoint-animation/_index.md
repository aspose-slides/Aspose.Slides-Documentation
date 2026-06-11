---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w Pythonie
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/python-net/powerpoint-animation/
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
- animacja kształtu
- animowany wykres
- animowany tekst
- animowany kształt
- animowany obiekt OLE
- animowany obraz
- animowana tabela
- prezentacja PowerPoint
- Python
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides for Python via .NET w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak wzbogacić swoje prezentacje."
---
## **Wprowadzenie**

Prezentacje są projektowane w celu przekazywania informacji, dlatego ich wygląd wizualny i zachowanie interaktywne są kluczowymi kwestiami podczas tworzenia.

**Animacja PowerPoint** odgrywa istotną rolę w sprawianiu, że prezentacja przyciąga uwagę i angażuje widzów. Aspose.Slides for Python via .NET oferuje szeroki wachlarz możliwości dodawania animacji do prezentacji PowerPoint. Możesz:

- Zastosować różne efekty animacji do kształtów, wykresów, tabel, obiektów OLE i innych elementów.
- Użyć wielu efektów animacji na jednym kształcie.
- Sterować efektami za pomocą osi czasu animacji.
- Tworzyć niestandardowe animacje.

Przestrzeń nazw [aspose.slides.animation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/) dostarcza klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe, takie jak Bounce, PathFootball i Zoom, a także specjalistyczne, jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttype/).

Dodatkowo, te efekty animacji mogą być łączone z następującymi efektami:

- [ColorEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/seteffect/)

## **Niestandardowa animacja**

Możesz tworzyć własne **niestandardowe animacje** w Aspose.Slides, łącząc wiele zachowań w jeden efekt.

[Behavior](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/) jest podstawowym elementem budulcowym każdego efektu animacji PowerPoint. Każdy efekt animacji to w istocie zestaw zachowań ułożonych w jedną strategię lub oś czasu. Możesz złożyć zachowania w niestandardową animację raz i ponownie używać jej w innych prezentacjach. Dodanie nowego zachowania do standardowego efektu animacji PowerPoint sprawia, że staje się ona niestandardową animacją — na przykład dodanie zachowania powtórzenia, aby animacja odtwarzała się wielokrotnie.

[Animation Point](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/point/) oznacza moment lub pozycję, w której zastosowane jest zachowanie (klatka kluczowa).

## **Oś czasu animacji**

[Sequence](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/) jest zbiorem efektów animacji zastosowanych do konkretnego kształtu.

[Timeline](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/animationtimeline/) to zestaw sekwencji używanych na konkretnej slajdzie. Został wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji było trudne i często wymagało obejść. Timeline zastępuje starą klasę `AnimationSettings` i zapewnia przejrzystszy model obiektowy animacji PowerPoint. Każdy slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[Trigger](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/) pozwala zdefiniować akcje użytkownika (np. kliknięcie przycisku), które uruchamiają określoną animację. Wyzwalacze zostały dodane dopiero w najnowszych wersjach PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów — takich jak tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="primary" %}}
Czytaj dalej [**O animacji kształtów**](/slides/pl/python-net/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**

Aby tworzyć animowane wykresy, używaj tych samych klas co dla kształtów. Jednak animacje PowerPoint mogą być stosowane tylko do kategorii wykresu lub serii wykresu. Możesz także zastosować efekt animacji do pojedynczego elementu kategorii lub serii.

{{% alert color="primary" %}}
Czytaj dalej [**O animowanych wykresach**](/slides/pl/python-net/animated-charts/).
{{% /alert %}}

## **Animowany tekst**

Oprócz animacji tekstu, możesz zastosować animację do akapitu.

{{% alert color="primary" %}}
Czytaj dalej [**O animowanym tekście**](/slides/pl/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/python-net/slide-transition/) nie odtwarzają się. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/python-net/export-to-html5/), [animowanego GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/python-net/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wyświetlić prezentację jako klatki](/slides/pl/python-net/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane w zakresie [odczytu](/slides/pl/python-net/open-presentation/) i [zapisu](/slides/pl/python-net/save-presentation/), ale różnice formatów mogą powodować, że niektóre efekty wyglądają lub zachowują się nieco inaczej. Zweryfikuj krytyczne przypadki przy użyciu rzeczywistych próbek.