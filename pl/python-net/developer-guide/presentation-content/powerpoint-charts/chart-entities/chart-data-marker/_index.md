---
title: Zarządzaj znacznikami danych wykresu w prezentacjach przy użyciu Pythona
linktitle: Znacznik danych
type: docs
url: /pl/python-net/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides, zwiększając efektywność prezentacji w formatach PPT, PPTX i ODP dzięki przejrzystym przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienie obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zauważa również, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znaczników wykresu**
Markery można ustawić na punktach danych wykresu w określonych seriach. Aby ustawić opcje znaczników wykresu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Tworzenie domyślnego wykresu
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Pobieranie indeksu domyślnego arkusza danych wykresu
    defaultWorksheetIndex = 0

    # Pobieranie arkusza danych wykresu
    fact = chart.chart_data.chart_data_workbook

    # Usuń przykładową serię
    chart.chart_data.series.clear()

    # Dodaj nową serię
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Ustaw obraz
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Ustaw obraz
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Pobierz pierwszą serię wykresu
    series = chart.chart_data.series[0]

    # Dodaj nowy punkt (1:3) tam.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Zmiana znacznika serii wykresu
    series.marker.size = 15

    # Zapisz prezentację na dysku
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itd.); lista jest zdefiniowana przez wyliczenie [MarkerStyleType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/python-net/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.