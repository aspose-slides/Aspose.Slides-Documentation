---
title: Porównaj slajdy prezentacji w C++
linktitle: Porównaj slajdy
type: docs
weight: 50
url: /pl/cpp/compare-slides/
keywords:
- porównywanie slajdów
- porównanie slajdów
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Programowo porównuj prezentacje PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Szybko identyfikuj różnice slajdów w kodzie."
---
## **Przegląd**

Aspose.Slides umożliwia porównywanie slajdów, slajdów układu i slajdów wzorcowych przy użyciu metody `Equals` udostępnionej przez interfejs `IBaseSlide` oraz klasę `BaseSlide`. Metoda ta zwraca `true`, gdy porównywane slajdy są identyczne pod względem struktury i statycznej zawartości.

## **Porównaj dwa slajdy**
Metoda Equals została dodana do interfejsu IBaseSlide oraz klasy BaseSlide. Zwraca ona true dla slajdów / slajdów układu / slajdów wzorcowych, które są identyczne pod względem struktury i statycznej zawartości.

Dwa slajdy są równe, jeśli wszystkie kształty, style, teksty, animacje i inne ustawienia są identyczne itd. Porównanie nie uwzględnia unikalnych wartości identyfikatorów, np. SlideId, ani treści dynamicznej, np. bieżącej wartości daty w miejscu przeznaczonym na datę.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Czy fakt, że slajd jest ukryty, wpływa na porównanie samych slajdów?**

[Hidden status](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/get_hidden/) jest własnością na poziomie prezentacji/odtwarzania, a nie treścią wizualną. Równość dwóch konkretnych slajdów jest określana przez ich strukturę i statyczną zawartość; sam fakt, że slajd jest ukryty, nie sprawia, że slajdy są różne.

**Czy hiperłącza i ich parametry są brane pod uwagę?**

Tak. Hiperłącza są częścią statycznej zawartości slajdu. Jeśli adres URL lub akcja hiperłącza różnią się, jest to zazwyczaj traktowane jako różnica w zawartości statycznej.

**Jeśli wykres odwołuje się do zewnętrznego pliku Excel, czy zawartość tego pliku zostanie uwzględniona?**

Nie. Porównanie odbywa się na podstawie samych slajdów. Zewnętrzne źródła danych zazwyczaj nie są odczytywane w czasie porównywania; uwzględniane jest tylko to, co znajduje się w strukturze i statycznym stanie slajdu.