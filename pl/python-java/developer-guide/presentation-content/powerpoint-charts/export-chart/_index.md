---
title: Eksport wykresów z prezentacji w Pythonie za pośrednictwem Java
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/python-java/export-chart/
keywords:
- wykres
- wykres na obraz
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji przy użyciu Aspose.Slides dla Pythona za pośrednictwem Java, obsługując formaty PPT i PPTX oraz usprawniając raportowanie w dowolnym procesie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia wyeksportowanie wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizację wykresu poza prezentacją PowerPoint.

Oprócz podstawowego przepływu pracy z eksportem obrazu, artykuł odnosi się również do typowych pytań związanych z eksportem, w tym zapisywania zawartości wykresu jako SVG, kontrolowania rozmiaru wyjścia za pomocą opcji renderowania, ładowania czcionek w celu zachowania wyglądu etykiet i legendy oraz utrzymania pierwotnego formatowania prezentacji, takiego jak motywy, style, wypełnienia i efekty podczas renderowania.

## **Uzyskaj obraz wykresu**
Aspose.Slides for Python via Java obsługuje wyodrębnianie obrazu konkretnego wykresu. Poniższy przykład demonstruje, jak to zrobić.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisu kształtu do SVG](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Jak mogę ustawić dokładny rozmiar eksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które pozwalają określić rozmiar lub skalę — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, gdy czcionki w etykietach i legendzie wyglądają niepoprawnie po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/python-java/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport uwzględnia motyw, style i efekty PowerPointa?**

Tak. Renderer Aspose.Slides stosuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), dzięki czemu wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne funkcje renderowania/eksportu poza obrazami wykresów?**

Zobacz [API](https://reference.aspose.com/slides/pl/python-java/aspose.slides/)/[dokumentację](/slides/pl/python-java/convert-powerpoint/) dotyczącą docelowych formatów wyjściowych ([PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), itp.) oraz powiązane opcje renderowania.