---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu C++
linktitle: Wykres 3D
type: docs
url: /pl/cpp/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla C++, obsługując pliki PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides, konfigurując ustawienia `Rotation3D`, takie jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przeprowadza przez tworzenie prezentacji, dodawanie wykresu 3D z domyślnymi danymi, zastosowanie wymaganych ustawień widoku 3D oraz zapis zmodyfikowanej prezentacji jako plik PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**

Aspose.Slides for C++ udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci, jak ustawić różne właściwości, takie jak rotacja X, Y, **DepthPercents** itp. Przykładowy kod zastosowuje ustawienia wymienionych wyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, wraz z pokrewnymi typami 3D udostępnionymi poprzez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/). Aby uzyskać dokładną i aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres jako obraz za pomocą [API wykresu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) lub [renderować cały slajd](/slides/pl/cpp/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd piksel po pikselu lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od ilości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, utrzymuj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do wyjścia o odpowiednich rozmiarach (rozdzielczość i wymiary), aby dopasować je do docelowego wyświetlacza lub wymagań druku.