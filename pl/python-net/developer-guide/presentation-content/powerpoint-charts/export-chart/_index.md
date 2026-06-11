---
title: Eksportowanie wykresów z prezentacji przy użyciu Pythona
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/python-net/export-chart/
keywords:
- wykres
- wykres do obrazu
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji przy użyciu Aspose.Slides dla Pythona poprzez .NET, obsługując formaty PPT, PPTX i ODP, oraz usprawnić raportowanie w dowolnym procesie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia eksport wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizację wykresu poza prezentacją PowerPoint.

## **Pobieranie obrazu wykresu**
Aspose.Slides for Python via .NET zapewnia wsparcie przy wyodrębnianiu obrazu konkretnego wykresu. Poniżej znajduje się przykładowy kod.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu metody [metoda zapisu do SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/write_as_svg/).

**Jak mogę ustawić dokładny rozmiar eksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które umożliwiają określenie rozmiaru lub skali — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, gdy czcionki w etykietach i legendzie wyglądają niepoprawnie po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/python-net/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport uwzględnia motyw, style i efekty PowerPoint?**

Tak. Renderowanie Aspose.Slides respektuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), dzięki czemu wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz sekcję eksportu w [API](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/)/[dokumentacji](/slides/pl/python-net/convert-powerpoint/) dotyczącą formatów wyjściowych ([PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), itp.) oraz powiązanych opcji renderowania.