---
title: Ulepszanie prezentacji PowerPoint za pomocą animacji w Javie
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
## **Wstęp**

Ponieważ prezentacje mają na celu przedstawienie czegoś, ich wygląd wizualny i zachowanie interaktywne są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w sprawianiu, że prezentacja przyciąga uwagę i angażuje widzów. Aspose.Slides oferuje szeroki zakres możliwości dodawania animacji do prezentacji PowerPoint:

- Stosuj różne typy efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.  
- Używaj wielu efektów animacji PowerPoint na jednym kształcie.  
- Wykorzystuj oś czasu animacji do sterowania efektami animacji.  
- Twórz niestandardowe animacje.

W Aspose.Slides można zastosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji mogą być stosowane do dowolnego elementu na slajdzie.

## **Efekty animacji**
Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty, takie jak Bounce, PathFootball i Zoom, oraz specyficzne efekty, takie jak OLEObjectShow i OLEObjectOpen. Pełną listę znajdziesz w klasie [EffectType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effecttype/).

Ponadto te efekty animacji mogą być używane w połączeniu z następującymi zachowaniami:

- [ColorEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ColorEffect)  
- [CommandEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/CommandEffect)  
- [FilterEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FilterEffect)  
- [MotionEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/MotionEffect)  
- [PropertyEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PropertyEffect)  
- [RotationEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/RotationEffect)  
- [ScaleEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ScaleEffect)  
- [SetEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SetEffect)

## **Niestandardowa animacja**

Pełne przykłady w języku Java, które tworzą, analizują i modyfikują zachowania oraz edytowalne ścieżki ruchu, znajdziesz w sekcji [Custom Animation](/slides/pl/java/custom-animation/).

W Aspose.Slides można tworzyć własne **niestandardowe animacje**. Można to osiągnąć, łącząc kilka zachowań w nową niestandardową animację.

[Behavior](https://reference.aspose.com/slides/pl/java/com.aspose.slides/behavior/) jest elementem budulcowym efektu animacji PowerPoint. Łącz zachowania, aby dostosować efekt, lub dodaj zachowanie, aby rozszerzyć istniejący efekt. Powtórzenia konfiguruje się za pomocą ustawień czasowych, a nie osobnego zachowania powtarzania.

[Animation Point](https://reference.aspose.com/slides/pl/java/com.aspose.slides/point/) to punkt, w którym powinno zostać zastosowane zachowanie.

## **Oś czasu animacji**
[Sequence](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sequence/) to kolekcja efektów animacji, które mogą docierać do różnych kształtów.

[Timeline](https://reference.aspose.com/slides/pl/java/com.aspose.slides/animationtimeline/) to zestaw sekwencji używany na konkretnym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. W wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Oś czasu zapewnia przejrzystszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**
[Trigger](https://reference.aspose.com/slides/pl/java/com.aspose.slides/effecttriggertype/) pozwala zdefiniować działania użytkownika, takie jak kliknięcie przycisku, które uruchamiają określoną animację.

## **Animacja kształtów**
Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i wiele innych.

{{% alert color="info" title="Note" %}}
Przeczytaj więcej [**O animacji kształtów**](/slides/pl/java/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**
Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint mogą być stosowane wyłącznie do kategorii wykresu lub serii wykresu. Możesz również zastosować efekty animacji do elementu kategorii lub elementu serii.

{{% alert color="info" title="Note" %}}
Przeczytaj więcej [**O animowanych wykresach**](/slides/pl/java/animated-charts/).
{{% /alert %}}

## **Animowany tekst**
Oprócz animacji tekstu możesz zastosować animację do akapitu.

{{% alert color="info" title="Note" %}}
Przeczytaj więcej [**O animowanym tekście**](/slides/pl/java/animated-text/).
{{% /alert %}}

## **FAQ**

**Czy animacje zostaną zachowane podczas eksportu do PDF?**

Nie. PDF jest formatem statycznym, dlatego animacje i [przejścia slajdów](/slides/pl/java/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/java/export-to-html5/), [animowanego GIF](/slides/pl/java/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/java/convert-powerpoint-to-video/) zamiast tego.

**Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?**

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/java/convert-powerpoint-to-video/) i zakodować je wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

**Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?**

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/java/open-presentation/) i [zapisywaniu](/slides/pl/java/save-presentation/), ale nie gwarantuje to zachowania animacji. Dane niestandardowych animacji mogą zostać utracone przy konwersji do ODP. Zobacz [Custom Animation](/slides/pl/java/custom-animation/) po przykłady i wskazówki dotyczące sprawdzania kompatybilności formatu.