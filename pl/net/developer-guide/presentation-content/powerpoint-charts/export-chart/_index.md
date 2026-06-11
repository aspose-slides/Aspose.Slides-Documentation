---
title: Eksport wykresów z prezentacji w .NET
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/net/export-chart/
keywords:
- wykres
- wykres na obraz
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji przy użyciu Aspose.Slides dla .NET, obsługującego formaty PPT i PPTX, oraz usprawnij raportowanie w dowolnym przepływie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia eksport wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz z wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizacje wykresu poza prezentacją PowerPoint.

Oprócz podstawowego przepływu eksportu obrazu, artykuł porusza również typowe pytania związane z eksportem, w tym zapisywanie zawartości wykresu jako SVG, kontrolowanie rozmiaru wyjścia za pomocą opcji renderowania, ładowanie czcionek w celu zachowania wyglądu etykiet i legendy oraz zachowanie oryginalnego formatowania prezentacji, takiego jak motywy, style, wypełnienia i efekty podczas renderowania.

## **Pobierz obraz wykresu**
Aspose.Slides dla .NET zapewnia wsparcie w wyodrębnianiu obrazu konkretnego wykresu. Poniżej podano przykładowy kod.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisu shape-to‑SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/).

**Jak mogę ustawić dokładny rozmiar wyeksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które pozwalają określić rozmiar lub skalę – biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, jeśli czcionki w etykietach i legendzie wyglądają niepoprawnie po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/net/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało métriki i wygląd tekstu.

**Czy eksport zachowuje motyw, style i efekty PowerPointa?**

Tak. Renderowanie w Aspose.Slides przestrzega formatowania prezentacji (motywy, style, wypełnienia, efekty), dzięki czemu wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz sekcję eksportu w [API](https://reference.aspose.com/slides/pl/net/aspose.slides.export/)/[dokumentacji](/slides/pl/net/convert-powerpoint/) dotyczącą formatów wyjściowych ([PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [SVG](/slides/pl/net/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/net/convert-powerpoint-to-xps/), [HTML](/slides/pl/net/convert-powerpoint-to-html/) i inne) oraz powiązane opcje renderowania.