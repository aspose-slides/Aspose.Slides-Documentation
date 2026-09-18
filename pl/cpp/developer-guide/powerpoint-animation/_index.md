---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w C++
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/cpp/powerpoint-animation/
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
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać i kontrolować zaawansowane efekty animacji w Aspose.Slides dla C++, aby tworzyć dynamiczne prezentacje PowerPoint i OpenDocument."
---
## **Wstęp**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**PowerPoint animation** odgrywa ważną rolę w sprawianiu, że prezentacja jest przyciągająca uwagę i angażująca dla odbiorców. Aspose.Slides udostępnia szeroki zakres opcji dodawania animacji do prezentacji PowerPoint:

- Zastosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE oraz innych elementów prezentacji.
- Użyj wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystaj oś czasu animacji do kontrolowania efektów animacji.
- Twórz niestandardowe animacje.

W Aspose.Slides można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji można zastosować do dowolnego elementu na slajdzie.

Przestrzeń nazw [Aspose::Slides::Animation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/) udostępnia klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty takie jak Bounce, PathFootball i Zoom oraz konkretne efekty takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effecttype/).

Dodatkowo, te efekty animacji mogą być używane w połączeniu z następującymi zachowaniami:

- [ColorEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/seteffect/)

## **Animacja niestandardowa**
Kompletne przykłady C++, które tworzą, inspekcjonują i modyfikują zachowania oraz edytowalne ścieżki ruchu, znajdziesz w [Niestandardowa animacja](/slides/pl/cpp/custom-animation/).

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behavior](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/behavior/) jest elementem budulcowym efektu animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć gotowy efekt. Powtórzenia konfiguruje się poprzez ustawienia czasu, a nie poprzez osobne zachowanie powtarzania.

[Animation Point](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/point/) jest punktem, w którym należy zastosować zachowanie.

## **Linia czasu animacji**
[Sequence](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/sequence/) jest kolekcją efektów animacji, które mogą działać na różne kształty.

[IAnimationTimeLine](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ianimationtimeline/) jest zestawem sekwencji używanych w konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W starszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe jedynie przy różnych obejściach. Linia czasu zapewnia klarowniejszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną linię czasu animacji.

## **Animacja interaktywna**
[Trigger](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effecttriggertype/) umożliwia zdefiniowanie działań użytkownika, takich jak kliknięcie przycisku, które rozpoczynają określoną animację.

## **Animacja kształtów**
Aspose.Slides pozwala na zastosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" title="Uwaga" %}}
Czytaj więcej [**O animacji kształtów**](/slides/pl/cpp/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint można stosować tylko do kategorii wykresu lub serii wykresu. Można także zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Uwaga" %}}
Czytaj więcej [**O animowanych wykresach**](/slides/pl/cpp/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animowania tekstu, możesz zastosować animację do akapitu.

{{% alert color="info" title="Uwaga" %}}
Czytaj więcej [**O animowanym tekście**](/slides/pl/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/cpp/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/cpp/export-to-html5/), [animowanego GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/cpp/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [wykonać renderowanie prezentacji jako klatki](/slides/pl/cpp/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/cpp/open-presentation/) i [zapisywaniu](/slides/pl/cpp/save-presentation/), ale nie gwarantuje to zachowania animacji. Niestandardowe dane animacji mogą zostać utracone przy konwersji do ODP. Zobacz [Niestandardowa animacja](/slides/pl/cpp/custom-animation/) po przykłady i wskazówki dotyczące sprawdzania zgodności formatów.