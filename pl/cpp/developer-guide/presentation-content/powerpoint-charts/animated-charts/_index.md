---
title: Animuj wykresy PowerPoint w C++
linktitle: Animowane wykresy
type: docs
weight: 80
url: /pl/cpp/animated-charts/
keywords:
- wykres
- animowany wykres
- animacja wykresu
- seria wykresu
- kategoria wykresu
- element serii
- element kategorii
- dodaj efekt
- typ efektu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz oszałamiające animowane wykresy w C++ za pomocą Aspose.Slides. Zwiększ atrakcyjność prezentacji dzięki dynamicznym wizualizacjom w plikach PPT i PPTX — rozpocznij teraz."
---
## **Wprowadzenie**

Aspose.Slides obsługuje animowanie elementów wykresu. **Series**, **Categories**, **Series Elements**, **Categories Elements** można animować za pomocą metody [ISequence::AddEffect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/isequence/addeffect/) i dwóch wyliczeń [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) oraz [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animacja serii wykresu**
Jeśli chcesz animować serię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj serię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy serię wykresu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animacja elementu serii**
Jeśli chcesz animować elementy serii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj elementy serii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy serii.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animacja kategorii wykresu**
Jeśli chcesz animować kategorię wykresu, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj kategorię.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy kategorię wykresu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animacja elementu kategorii**
Jeśli chcesz animować elementy kategorii, napisz kod zgodnie z poniższymi krokami:

1. Wczytaj prezentację.
1. Uzyskaj odwołanie do obiektu wykresu.
1. Animuj elementy kategorii.
1. Zapisz plik prezentacji na dysku.

W poniższym przykładzie animowaliśmy elementy kategorii.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Czy różne typy efektów (np. wejścia, podkreślenia, wyjścia) są obsługiwane dla wykresów tak jak dla zwykłych kształtów?**

Tak. Wykres jest traktowany jako kształt, więc obsługuje standardowe typy efektów animacji, w tym wejście, podkreślenie i wyjście, z pełną kontrolą poprzez oś czasu slajdu i sekwencje animacji.

**Czy mogę łączyć animację wykresu z przejściami slajdów?**

Tak. [Transitions](/slides/pl/cpp/slide-transition/) stosuje się do slajdu, natomiast efekty animacji dotyczą obiektów na slajdzie. Możesz używać obu jednocześnie w tej samej prezentacji i kontrolować je niezależnie.

**Czy animacje wykresu są zachowywane przy zapisywaniu do formatu PPTX?**

Tak. Kiedy [zapisz jako PPTX](/slides/pl/cpp/save-presentation/), wszystkie efekty animacji i ich kolejność są zachowywane, ponieważ są częścią natywnego modelu animacji prezentacji.

**Czy mogę odczytać istniejące animacje wykresu z prezentacji i je zmodyfikować?**

Tak. [API](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/) zapewnia dostęp do osi czasu slajdu, sekwencji i efektów, umożliwiając przeglądanie istniejących animacji wykresu i ich modyfikację bez konieczności odtworzenia wszystkiego od podstaw.

**Czy mogę wyprodukować wideo zawierające animacje wykresu przy użyciu Aspose.Slides?**

Tak. Możesz [wyeksportować prezentację do wideo](/slides/pl/cpp/convert-powerpoint-to-video/) zachowując animacje, konfigurując czasy i inne ustawienia eksportu, aby powstały klip odzwierciedlał animowane odtwarzanie.