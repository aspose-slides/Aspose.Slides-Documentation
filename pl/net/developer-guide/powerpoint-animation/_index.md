---
title: Ulepsz prezentacje PowerPoint za pomocą animacji w .NET
linktitle: Animacja PowerPoint
type: docs
weight: 150
url: /pl/net/powerpoint-animation/
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
- prezentacja PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Poznaj możliwości Aspose.Slides dla .NET w obsłudze animacji PowerPoint. Ten ogólny przegląd podkreśla kluczowe funkcje i oferuje wskazówki, jak ulepszyć Twoje prezentacje."
---
## **Wprowadzenie**

Ponieważ prezentacje służą do przedstawiania czegoś, ich wygląd wizualny i interaktywne zachowanie są zawsze brane pod uwagę podczas tworzenia.

**Animacja PowerPoint** odgrywa ważną rolę w uczynieniu prezentacji atrakcyjną i angażującą dla odbiorców. Aspose.Slides for .NET oferuje szeroką gamę opcji dodawania animacji do prezentacji PowerPoint:

- Zastosowanie różnych typów efektów animacji PowerPoint do kształtów, wykresów, tabel, obiektów OLE i innych elementów prezentacji.
- Użycie wielu efektów animacji PowerPoint na jednym kształcie.
- Wykorzystanie linii czasu animacji do kontrolowania efektów animacji.
- Tworzenie animacji niestandardowych.

W Aspose.Slides for .NET można stosować różne efekty animacji do kształtów. Ponieważ każdy element na slajdzie, w tym tekst, obrazy, obiekty OLE i tabele, jest traktowany jako kształt, efekty animacji mogą być stosowane do dowolnego elementu na slajdzie.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/) namespace udostępnia klasy do pracy z animacjami PowerPoint.

## **Efekty animacji**

Aspose.Slides obsługuje **ponad 150 efektów animacji**, w tym podstawowe efekty, takie jak Bounce, PathFootball i Zoom, oraz specyficzne efekty, takie jak OLEObjectShow i OLEObjectOpen. Pełną listę efektów animacji znajdziesz w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype).

Dodatkowo te efekty animacji mogą być używane w połączeniu z następującymi:

- [ColorEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/seteffect)

## **Animacja niestandardowa**

Możliwe jest tworzenie własnych **animacji niestandardowych** w Aspose.Slides. Można to osiągnąć, łącząc kilka zachowań w nową animację niestandardową.

[Behaviour](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/behavior) jest elementem budulcowym dowolnego efektu animacji PowerPoint. Wszystkie efekty animacji to w zasadzie zestaw zachowań składających się w jedną strategię. Możesz połączyć zachowania w animację niestandardową raz i ponownie używać jej w innych prezentacjach. Jeśli dodasz nowe zachowanie do standardowego efektu animacji PowerPoint, stanie się ono kolejną animacją niestandardową. Na przykład możesz dodać zachowanie powtarzania do animacji, aby powtarzała się kilka razy.

[Animation Point](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/point) to punkt, w którym powinno zostać zastosowane zachowanie.

## **Oś czasu animacji**

[Sequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/sequence) to kolekcja efektów animacji zastosowanych do konkretnego kształtu.

[Timeline](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animationtimeline) to zestaw sekwencji używanych w określonym slajdzie. Jest to silnik animacji wprowadzony w PowerPoint 2002. We wcześniejszych wersjach PowerPoint dodawanie efektów animacji do prezentacji było trudne i wymagało różnych obejść. Oś czasu zastępuje starą klasę AnimationSettings i zapewnia przejrzystszy model obiektowy animacji PowerPoint. Slajd może mieć tylko jedną oś czasu animacji.

## **Animacja interaktywna**

[Trigger](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype) pozwala zdefiniować akcje użytkownika (np. kliknięcie przycisku), które uruchomią określoną animację. Triggery zostały wprowadzone w najnowszej wersji PowerPoint.

## **Animacja kształtów**

Aspose.Slides umożliwia stosowanie animacji do kształtów, które mogą obejmować tekst, prostokąty, linie, ramki, obiekty OLE i inne.

{{% alert color="info" %}} 
Read more [**About Shape Animation**](/slides/pl/net/shape-animation/).
{{% /alert %}}

## **Animowane wykresy**

Aby tworzyć animowane wykresy, należy używać tych samych klas co dla kształtów. Jednak animacje PowerPoint można stosować tylko do kategorii wykresu lub serii wykresu. Efekty animacji można także zastosować do elementu kategorii lub elementu serii.

{{% alert color="info" %}} 
Read more [**About Animated Charts**](/slides/pl/net/animated-charts/).
{{% /alert %}}

## **Animowany tekst**

Oprócz animowanego tekstu możliwe jest także zastosowanie animacji do akapitu.

{{% alert color="info" %}} 
Read more [**About Animated Text**](/slides/pl/net/animated-text/).
{{% /alert %}}

## **FAQ**

### Czy animacje zostaną zachowane przy eksporcie do PDF?

Nie. PDF jest formatem statycznym, więc animacje i [przejścia slajdów](/slides/pl/net/slide-transition/) nie są odtwarzane. Jeśli potrzebujesz ruchu, wyeksportuj do [HTML5](/slides/pl/net/export-to-html5/), [animowanego GIF-a](/slides/pl/net/convert-powerpoint-to-animated-gif/) lub [wideo](/slides/pl/net/convert-powerpoint-to-video/) zamiast tego.

### Czy mogę przekształcić animowaną prezentację w wideo i kontrolować liczbę klatek na sekundę oraz rozmiar klatki?

Tak. Możesz [renderować prezentację jako klatki](/slides/pl/net/convert-powerpoint-to-video/) i zakodować je w wideo (np. za pomocą ffmpeg), wybierając FPS i rozdzielczość. Animacje i przejścia slajdów są odtwarzane podczas renderowania.

### Czy animacje pozostaną nienaruszone przy pracy z ODP (nie tylko PPTX)?

PPT, PPTX i ODP są obsługiwane przy [odczycie](/slides/pl/net/open-presentation/) i [zapisie](/slides/pl/net/save-presentation/), ale różnice formatów oznaczają, że niektóre efekty mogą wyglądać lub zachowywać się nieco inaczej. Zweryfikuj krytyczne przypadki na rzeczywistych próbkach.