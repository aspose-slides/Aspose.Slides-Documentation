---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w JavaScript
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
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj Aspose.Slides for Node.js via Java do obsługi animacji PowerPoint. Ten przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje mają za zadanie coś przedstawić, ich wygląd wizualny i interaktywne zachowanie są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w uczynieniu prezentacji przyciągającą uwagę i angażującą dla odbiorców. Aspose.Slides for Node.js via Java oferuje szeroką gamę opcji dodawania animacji do prezentacji PowerPoint:

- Stosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Używaj wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystuj oś czasu animacji do sterowania efektami animacji.
- Twórz animacje niestandardowe.

W Aspose.Slides for Node.js via Java można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji można zastosować do dowolnego elementu na slajdzie.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty, takie jak Bounce, PathFootball i Zoom, oraz specyficzne efekty, takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttype/).

Ponadto te efekty animacji mogą być używane w połączeniu z następującymi zachowaniami:

- [ColorEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SetEffect)

## **Animacja niestandardowa**

Pełne przykłady JavaScript, które tworzą, analizują i modyfikują zachowania oraz edytowalne ścieżki ruchu, znajdziesz w sekcji [Custom Animation](/slides/pl/nodejs-java/custom-animation/).

Możliwe jest stworzenie własnych **animacji niestandardowych** w Aspose.Slides. Osiąga się to poprzez połączenie kilku zachowań w nową animację niestandardową.

[Behavior](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/behavior/) jest elementem budulcowym efektu animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć predefiniowany efekt. Powtarzanie jest konfigurowane poprzez ustawienia czasowe, a nie oddzielne zachowanie powtórzenia.

[Animation Point](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/point/) to punkt, w którym ma zostać zastosowane zachowanie.

## **Oś czasu animacji**
[Sequence](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/) to zbiór efektów animacji, które mogą docierać do różnych kształtów.

[Timeline](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/animationtimeline/) to zestaw sekwencji używany na konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i możliwe tylko przy użyciu różnych obejść. Oś czasu zapewnia przejrzystszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[Trigger](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttriggertype/) pozwala zdefiniować akcje użytkownika, takie jak kliknięcie przycisku, które uruchamiają konkretną animację.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/pl/nodejs-java/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint mogą być stosowane wyłącznie do kategorii wykresu lub serii wykresu. Można również zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/pl/nodejs-java/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animacji tekstu, możesz zastosować animację do akapitu.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/pl/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane przy eksporcie do PDF?**

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/nodejs-java/slide-transition/) nie odtwarzają się. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/nodejs-java/export-to-html5/), [animowanego GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę zamienić animowaną prezentację na wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/nodejs-java/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane do [odczytu](/slides/pl/nodejs-java/open-presentation/) i [zapisu](/slides/pl/nodejs-java/save-presentation/), ale nie gwarantuje to zachowania animacji. Dane animacji niestandardowych mogą zostać utracone podczas konwersji do ODP. Zobacz [Custom Animation](/slides/pl/nodejs-java/custom-animation/) po przykłady i wskazówki dotyczące sprawdzania kompatybilności formatów.