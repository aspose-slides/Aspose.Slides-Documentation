---
title: Ulepsz prezentacje PowerPoint o animacje w PHP
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
description: "Poznaj możliwości Aspose.Slides for PHP via Java w obsłudze animacji PowerPoint. Kluczowe funkcje i wskazówki, które pomogą ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**PowerPoint animation** odgrywa ważną rolę w sprawianiu, że prezentacja przyciąga uwagę i angażuje widzów. Aspose.Slides for PHP via Java oferuje szeroką gamę opcji dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Użyj wielu efektów animacji PowerPoint na pojedynczym kształcie.
- Wykorzystaj oś czasu animacji do kontrolowania efektów animacji.
- Twórz animacje niestandardowe.

W Aspose.Slides for PHP via Java można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji mogą być stosowane do dowolnego elementu na slajdzie.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom oraz konkretne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w klasie [EffectType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttype/).

Dodatkowo, te efekty animacji mogą być używane w połączeniu z następującymi zachowaniami:
- [ColorEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SetEffect)

## **Animacja niestandardowa**

Pełne przykłady PHP, które tworzą, przeglądają i modyfikują zachowania oraz edytowalne ścieżki ruchu, znajdziesz w [Custom Animation](/slides/pl/php-java/custom-animation/).

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behavior](https://reference.aspose.com/slides/pl/php-java/aspose.slides/behavior/) jest elementem budulcowym efektu animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć zdefiniowany efekt. Powtórzenia konfiguruje się poprzez ustawienia czasowe, a nie poprzez osobne zachowanie powtarzania.

[Animation Point](https://reference.aspose.com/slides/pl/php-java/aspose.slides/point/) jest punktem, w którym powinno zostać zastosowane zachowanie.

## **Linia czasu animacji**
[Sequence](https://reference.aspose.com/slides/pl/php-java/aspose.slides/sequence/) jest kolekcją efektów animacji, które mogą być skierowane do różnych kształtów.

[Timeline](https://reference.aspose.com/slides/pl/php-java/aspose.slides/animationtimeline/) jest zestawem sekwencji używanych w konkretnym slajdzie. To silnik animacji wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy użyciu różnych obejść. Oś czasu zapewnia przejrzystszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[Trigger](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effecttriggertype/) pozwala zdefiniować działania użytkownika, takie jak kliknięcie przycisku, które uruchamiają określoną animację.

## **Animacja kształtu**
Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" title="Note" %}}
Czytaj więcej [**O animacji kształtów**](/slides/pl/php-java/shape-animation/).
{{% /alert %}}

## **Wykresy animowane**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint mogą być stosowane tylko do kategorii wykresu lub serii wykresu. Można również zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Note" %}}
Czytaj więcej [**O animowanych wykresach**](/slides/pl/php-java/animated-charts/).
{{% /alert %}}

## **Tekst animowany**
Oprócz animowania tekstu, możesz zastosować animację do akapitu.

{{% alert color="info" title="Note" %}}
Czytaj więcej [**O animowanym tekście**](/slides/pl/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje będą zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [slide transitions](/slides/pl/php-java/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, zamiast tego wyeksportuj do [HTML5](/slides/pl/php-java/export-to-html5/), [animowanego GIF](/slides/pl/php-java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/php-java/convert-powerpoint-to-video/).

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatek?**

Tak. Możesz [renderuj prezentację jako klatki](/slides/pl/php-java/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając liczbę klatek na sekundę i rozdzielczość. Animacje oraz przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

Formaty PPT, PPTX oraz ODP są obsługiwane do [odczytu](/slides/pl/php-java/open-presentation/) i [zapisu](/slides/pl/php-java/save-presentation/), ale nie gwarantuje to zachowania animacji. Dane animacji niestandardowych mogą zostać utracone przy konwersji do ODP. Zobacz [Custom Animation](/slides/pl/php-java/custom-animation/) po przykłady i wskazówki dotyczące sprawdzania kompatybilności formatu.