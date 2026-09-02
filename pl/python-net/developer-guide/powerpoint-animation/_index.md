---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w Pythonie
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/python-net/powerpoint-animation/
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
- prezentacja PowerPoint
- Python
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides for Python via .NET w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak ulepszyć swoje prezentacje."
---
## **Wprowadzenie**

Prezentacje są projektowane w celu przekazywania informacji, dlatego ich wygląd wizualny i zachowanie interaktywne są kluczowymi kwestiami podczas tworzenia.

**PowerPoint animation** odgrywa ważną rolę w sprawianiu, że prezentacja przyciąga uwagę i angażuje widzów. Aspose.Slides for Python via .NET udostępnia szeroki wachlarz opcji dodawania animacji do prezentacji PowerPoint. Możesz:
- Zastosować różne efekty animacji do kształtów, wykresów, tabel, obiektów OLE i innych elementów.
- Używać wielu efektów animacji na jednym kształcie.
- Kontrolować efekty za pomocą osi czasu animacji.
- Tworzyć niestandardowe animacje.

W Aspose.Slides for Python via .NET efekty animacji mogą być stosowane do kształtów. Ponieważ każdy element na slajdzie — w tym tekst, obrazy, obiekty OLE i tabele — jest traktowany jako kształt, możesz zastosować efekty animacji do dowolnego elementu na slajdzie.

Przestrzeń nazw [aspose.slides.animation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/) udostępnia klasy do pracy z animacjami PowerPoint.

## **Instalacja**

```bash
pip install aspose.slides
```

## **Dodanie efektu animacji do kształtu w Pythonie**

Efekty animacji znajdują się w głównej sekwencji slajdu. Dodaj kształt, a następnie wywołaj `add_effect` na `slide.timeline.main_sequence`, podając typ efektu, jego podtyp oraz wyzwalacz, który go uruchamia.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Zapisany plik zawiera jeden efekt na pierwszym slajdzie: prostokąt wylatuje z lewej strony w ciągu dwóch sekund po kliknięciu prezentera. Ponowne otwarcie go i odczytanie `slide.timeline.main_sequence` zwraca ten efekt, więc animacja przetrwała cały proces, a nie istnieje tylko w pamięci.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom, a także specjalistyczne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttype/).

Ponadto, te efekty animacji można łączyć z następującymi efektami:
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

[Behavior](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/behavior/) jest podstawowym elementem budulcowym każdego efektu animacji PowerPoint. Każdy efekt animacji to zasadniczo zestaw zachowań ułożonych w jedną strategię lub oś czasu. Możesz złożyć zachowania w niestandardową animację raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, stanie się ono niestandardową animacją — na przykład dodanie zachowania powtarzania, aby animacja odtwarzała się kilka razy.

[Animation Point](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/point/) oznacza moment lub pozycję, w której zastosowane jest zachowanie (klatka kluczowa).

## **Oś czasu animacji**

[Sequence](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/) jest kolekcją efektów animacji zastosowanych do konkretnego kształtu.

[Timeline](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/animationtimeline/) jest zbiorem sekwencji używanych na konkretnym slajdzie. Została wprowadzona w PowerPoint 2002. W starszych wersjach PowerPoint dodawanie efektów animacji było trudne i często wymagało obejść. Timeline zastępuje starą klasę `AnimationSettings` i zapewnia klarowniejszy model obiektowy animacji PowerPoint. Każdy slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[Trigger](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/) pozwala zdefiniować akcje użytkownika (np. kliknięcie przycisku), które uruchamiają określoną animację. Wyzwalacze zostały dodane dopiero w najnowszych wersjach PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów — takich jak tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="primary" %}}
Czytaj więcej [**O animacji kształtów**](/slides/pl/python-net/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**

Aby tworzyć animowane wykresy, użyj tych samych klas co dla kształtów. Jednak animacje PowerPoint można stosować tylko do kategorii wykresu lub serii wykresu. Możesz także zastosować efekt animacji do pojedynczego elementu kategorii lub elementu serii.

{{% alert color="primary" %}}
Czytaj więcej [**O animowanych wykresach**](/slides/pl/python-net/animated-charts/).
{{% /alert %}}

## **Animowany tekst**

Oprócz animowania tekstu, możesz zastosować animację do akapitu.

{{% alert color="primary" %}}
Czytaj więcej [**O animowanym tekście**](/slides/pl/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

### Czy animacje zostaną zachowane przy eksporcie do PDF?

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/python-net/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/python-net/export-to-html5/), [animated GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/) lub [video](/slides/pl/python-net/convert-powerpoint-to-video/) zamiast tego.

### Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?

Tak. Możesz [wykonać renderowanie prezentacji jako klatki](/slides/pl/python-net/convert-powerpoint-to-video/) i zakodować je do wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

### Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?

PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/python-net/open-presentation/) i [zapisu](/slides/pl/python-net/save-presentation/), ale różnice formatów oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki na rzeczywistych przykładach.