---
title: Dostosuj wykresy kołowe w prezentacjach przy użyciu Pythona
linktitle: Wykres kołowy
type: docs
url: /pl/python-net/pie-chart/
keywords:
- wykres kołowy
- zarządzaj wykresem
- dostosuj wykres
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor segmentu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w Pythonie przy użyciu Aspose.Slides, które można eksportować do PowerPoint i OpenDocument, przyspieszając opowiadanie historii danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie segmentów dla standardowego wykresu kołowego.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresu Pie of Pie i Bar of Pie**

Aspose.Slides for Python via .NET obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie, przy pomocy przykładu, pokażemy, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, postępuj zgodnie z poniższymi krokami:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Dodaj wykres na slajdzie.
3. Określ opcje drugiego wykresu wykresu.
4. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy różne właściwości wykresu Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:
    # Dodaj wykres na slajdzie
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Ustaw różne własności
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Zapisz prezentację na dysku
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw automatyczne kolory segmentów wykresu kołowego**

Aspose.Slides for Python via .NET udostępnia prosty interfejs API do ustawiania automatycznych kolorów segmentów wykresu kołowego. Przykładowy kod stosuje ustawienie wymienionych wyżej właściwości.

1. Utwórz instancję klasy Presentation.
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw tytuł wykresu.
5. Ustaw pierwszą serię, aby wyświetlała wartości.
6. Ustaw indeks arkusza danych wykresu.
7. Pobierz arkusz danych wykresu.
8. Usuń domyślnie wygenerowane serie i kategorie.
9. Dodaj nowe kategorie.
10. Dodaj nowe serie.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as presentation:
	# Uzyskaj dostęp do pierwszego slajdu
	slide = presentation.slides[0]

	# Dodaj wykres z domyślnymi danymi
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Ustawianie tytułu wykresu
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Ustaw pierwszą serię, aby wyświetlała wartości
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Ustawianie indeksu arkusza danych wykresu
	defaultWorksheetIndex = 0

	# Pobieranie arkusza danych wykresu
	fact = chart.chart_data.chart_data_workbook

	# Usuń domyślnie wygenerowane serie i kategorie
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Dodawanie nowych kategorii
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Dodawanie nowej serii
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Teraz wypełnianie danych serii
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy warianty „Pie of Pie” i „Bar of Pie” są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/) drugi wykres dla wykresów kołowych, w tym typy „Pie of Pie” i „Bar of Pie”.

**Czy mogę wyeksportować tylko wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/chart/get_image/) (np. PNG) bez całej prezentacji.