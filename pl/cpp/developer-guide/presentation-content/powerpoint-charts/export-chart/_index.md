---
title: Eksport wykresów prezentacji w C++
linktitle: Eksportuj wykres
type: docs
weight: 90
url: /pl/cpp/export-chart/
keywords:
- wykres
- wykres do obrazu
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji przy użyciu Aspose.Slides dla C++, obsługując formaty PPT i PPTX, oraz usprawnić raportowanie w każdym przepływie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia wyeksportowanie wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie użyć wizualizacji wykresu poza prezentacją PowerPoint.

## **Uzyskaj obraz wykresu**
Aspose.Slides for C++ zapewnia obsługę wyodrębniania obrazu określonego wykresu. Poniżej podano przykładowy kod.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisu shape-to-SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/).

**Jak mogę ustawić dokładny rozmiar exportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które pozwalają określić rozmiar lub skalę — biblioteka obsługuje renderowanie obiektów o zadanych wymiarach/skali.

**Co zrobić, jeśli czcionki w etykietach i legendzie wyglądają niepoprawnie po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/cpp/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport respektuje motyw, style i efekty PowerPointa?**

Tak. Renderowanie w Aspose.Slides stosuje się do formatowania prezentacji (motywy, style, wypełnienia, efekty), dzięki czemu wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz sekcję eksportu w [API](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/)/[dokumentacji](/slides/pl/cpp/convert-powerpoint/) aby poznać dostępne cele wyjściowe ([PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), itp.) oraz powiązane opcje renderowania.