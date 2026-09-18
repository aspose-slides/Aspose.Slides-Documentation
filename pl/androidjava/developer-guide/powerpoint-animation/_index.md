---
title: Ulepsz prezentacje PowerPoint animacjami na Androidzie
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
- Android
- Java
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides dla Androida za pomocą Javy w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**PowerPoint animation** odgrywa ważną rolę w sprawianiu, że prezentacja przyciąga uwagę i angażuje widzów. Aspose.Slides oferuje szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Użyj wielu efektów animacji PowerPoint na pojedynczym kształcie.
- Wykorzystaj oś czasu animacji do sterowania efektami animacji.
- Twórz własne animacje.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom oraz specyficzne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w klasie [EffectType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttype/).

Ponadto, te efekty animacji można łączyć z następującymi zachowaniami:

- [ColorEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SetEffect)

## **Animacja niestandardowa**
Pełne przykłady w języku Java, które tworzą, przeglądają i modyfikują zachowania oraz edytowalne ścieżki ruchu, znajdziesz w [Animacja niestandardowa](/slides/pl/java/custom-animation/).

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behavior](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/behavior/) jest elementem budującym efekt animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć zdefiniowany efekt. Powtarzanie jest konfigurowane poprzez ustawienia czasu, a nie oddzielne zachowanie powtarzania.

[Animation Point](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/point/) jest punktem, w którym należy zastosować zachowanie.

## **Oś czasu animacji**
[Sequence](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/sequence/) jest zbiorem efektów animacji, które mogą dotyczyć różnych kształtów.

[Timeline](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/animationtimeline/) jest zestawem sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy użyciu różnych obejść. Oś czasu zapewnia przejrzystszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[Trigger](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttriggertype/) pozwala zdefiniować akcje użytkownika, takie jak kliknięcie przycisku, które uruchamiają konkretną animację.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" title="Note" %}}
Czytaj dalej [**O animacji kształtów**](/slides/pl/androidjava/shape-animation/).
{{% /alert %}}

## **Wykresy animowane**
Do tworzenia animowanych wykresów należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint można stosować jedynie do kategorii wykresu lub serii wykresu. Można także zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Note" %}}
Czytaj dalej [**O wykresach animowanych**](/slides/pl/androidjava/animated-charts/).
{{% /alert %}}

## **Tekst animowany**
Oprócz animacji tekstu, możesz zastosować animację do akapitu.

{{% alert color="info" title="Note" %}}
Czytaj dalej [**O tekście animowanym**](/slides/pl/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje będą zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/androidjava/slide-transition/) nie są odtwarzane. Jeśli potrzebny jest ruch, wyeksportuj do [HTML5](/slides/pl/androidjava/export-to-html5/), [animowanego GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/androidjava/convert-powerpoint-to-video/).

**Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wykonać renderowanie prezentacji jako klatki](/slides/pl/androidjava/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając liczbę klatek na sekundę i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

Formaty PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/androidjava/open-presentation/) i [zapisu](/slides/pl/androidjava/save-presentation/), ale nie gwarantuje to zachowania animacji. Dane animacji niestandardowych mogą zostać utracone podczas konwersji do ODP. Zobacz [Custom Animation for Java](/slides/pl/java/custom-animation/) po przykłady i wskazówki dotyczące sprawdzania zgodności formatu.