---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu C++
linktitle: Wykres 3D
type: docs
url: /pl/cpp/3d-chart/
keywords:
- wykres 3D
- rotacja
- głębokość
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla C++, z obsługą plików PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides poprzez konfigurację ustawień `Rotation3D`, takich jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przedstawia proces tworzenia prezentacji, dodawania wykresu 3D z danymi domyślnymi, zastosowania wymaganych ustawień widoku 3D oraz zapisania zmodyfikowanej prezentacji jako pliku PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**
Aspose.Slides for C++ udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak rotacja X i Y oraz **DepthPercents** itp. Przykładowy kod stosuje ustawienia wymienionych właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z danymi domyślnymi.
1. Ustaw właściwości Rotation3D.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, a także powiązane typy 3D udostępniane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub na stronę internetową?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [chart API](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) lub [renderować cały slajd](/slides/pl/cpp/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd pixel-perfect lub chcesz osadzić wykres w dokumentach, dashboardach lub stronach internetowych bez wymogu korzystania z PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od objętości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjściowego (rozdzielczość i wymiary), aby dopasować się do docelowego wyświetlacza lub wymagań drukowania.