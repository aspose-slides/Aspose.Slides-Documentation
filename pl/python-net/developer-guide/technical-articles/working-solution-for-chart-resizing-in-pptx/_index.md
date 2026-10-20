---
title: Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 60
url: /pl/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadź wykres
- PowerPoint
- prezentacja
- Python poprzez .NET
- Python
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w pliku PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides dla Pythona poprzez .NET. Ustaw stałe wymiary wykresu, aby utrzymać spójność rozmiarów wykresu i ramki OLE."
---
## **Przegląd**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego dochodzi do zmiany rozmiaru i pokazuje, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Tworzenie wykresów Excel i osadzanie ich jako obiektów OLE w prezentacjach](/slides/pl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak stworzyć wykres Excel przy użyciu Aspose.Cells dla Pythona poprzez .NET i osadzić go w prezentacji PowerPoint za pomocą Aspose.Slides dla Pythona poprzez .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wyjściowej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel jest aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie powrócić do slajdu, klikając poza aktywnym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie określone wymiary. Gdy skoroszyt Excel zostaje aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Działające rozwiązanie**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno z nową prezentacją, jak i istniejącym szablonem.

Przykład wymaga Aspose.Cells dla Pythona poprzez .NET oraz Aspose.Slides dla Pythona poprzez .NET. Tworzy prosty wykres kolumnowy na aktywnym arkuszu wykresu i osadza skoroszyt w formacie XLS. Nie przypisano obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9.5 × 4‑inch umieszczoną 0.5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu podawane są w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Użyj szablonu](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) na false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) za pomocą [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) i [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 piksele. Ustaw [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) na wartość CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). Przykład osadza skoroszyt przy użyciu [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) i zapisuje prezentację z ramką OLE o wymiarach 9.5 × 4‑inch.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Współrzędne i wymiary slajdu podawane są w punktach (72 punkty na cal).
    width = 684.0  # 9,5 cala.
    height = 288.0  # 4 cale.

    chart.size_with_window = False
    # Konwertuj punkty na piksele wykresu przy użyciu 96 pikseli na cal.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Użyj szablonu**

Logika określania rozmiaru jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Załaduj prezentację szablonu zamiast tworzyć pustą prezentację.
1. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako symbolu zastępczego.
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Zachowaj niezmienione obliczenia rozmiaru.
1. Dodaj ramkę OLE w pozycji symbolu zastępczego zamiast stałych współrzędnych 36 i 72.
1. Usuń symbol zastępczy przed zapisem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić oryginalny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak mogę utrzymać spójność rozmiarów wykresu i ramki OLE?**

Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj niestandardowego rozmiaru druku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i konwersje jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu wystarcza?**

Dopasowanie samego rozmiaru okna skoroszytu nie zapobiega w sposób niezawodny zmianie rozmiaru ramki OLE po aktywacji. Użyj stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno z prezentacjami opartymi na szablonie, jak i z nowymi prezentacjami?**

Tak. Dla szablonu użyj wymiarów i pozycji symbolu zastępczego. Dla nowej prezentacji określ bezpośrednio wymiary i pozycję ramki.

**Czy mogę używać tego przykładu z wykresami utworzonymi w innych programach arkuszy kalkulacyjnych?**

Przykład używa skoroszytu Excel utworzonego przy pomocy Aspose.Cells. Nie demonstruje zachowania aktywacji w innych programach arkuszy kalkulacyjnych.

## **Powiązane sekcje**

- [Tworzenie wykresów Excel i osadzanie ich jako obiektów OLE w prezentacjach](/slides/pl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)