---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu C++
linktitle: Legenda wykresu
type: docs
url: /pl/cpp/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides dla C++, aby zoptymalizować prezentacje PowerPoint dzięki spersonalizowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić położenie i rozmiar legendy, określić rozmiar czcionki dla całej legendy oraz zastosować formatowanie do pojedynczego wpisu legendy. Omówiono również kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zostawił miejsce na legendę, umożliwienie długim etykietom legendy zawijania lub wprowadzania podziałów linii oraz dziedziczenie formatowania legendy z tematu prezentacji, gdy nie ustawiono jawnych ustawień tekstu i wypełnienia.

## **Pozycjonowanie legendy**
Aby ustawić właściwości legendy, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
- Uzyskaj odniesienie do slajdu.
- Dodaj wykres na slajdzie.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy położenie i rozmiar legendy wykresu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Ustaw rozmiar czcionki legendy**
Aspose.Slides dla C++ umożliwia programistom ustawienie rozmiaru czcionki legendy. Wykonaj poniższe kroki: 

- Zainicjalizuj klasę Presentation.
- Utwórz domyślny wykres.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Ustaw rozmiar czcionki poszczególnej legendy**
Aspose.Slides dla C++ umożliwia programistom ustawienie rozmiaru czcionki poszczególnych wpisów legendy. Wykonaj poniższe kroki: 

- Zainicjalizuj klasę Presentation.
- Utwórz domyślny wykres.
- Uzyskaj dostęp do wpisu legendy.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Czy mogę włączyć legendę, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([set_Overlay(false)](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/legend/set_overlay/)); w tym przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć etykiety legendy wielowierszowe?**

Tak. Długie etykiety automatycznie zawijają się, gdy brakuje miejsca; wymuszone podziały linii są obsługiwane poprzez znaki nowej linii w nazwie serii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów tematu prezentacji?**

Nie ustawiaj jawnych kolorów/wypełnień/czcionek dla legendy ani jej tekstu. Wówczas będą one dziedziczone z tematu i będą się poprawnie aktualizować po zmianie projektu.