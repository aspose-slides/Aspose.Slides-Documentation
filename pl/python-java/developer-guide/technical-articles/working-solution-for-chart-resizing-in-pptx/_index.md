---
title: Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadź wykres
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w pliku PPTX przy użyciu osadzonych obiektów OLE Excel z Aspose.Slides for Python via Java. Ustaw stałe wymiary wykresu, aby utrzymać spójność rozmiarów wykresu i ramki OLE."
---
## **Tło**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego zachodzi zmiana rozmiaru i pokazuje, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for Python via Java i osadzić go w prezentacji PowerPoint przy pomocy Aspose.Slides for Python via Java. Aby rozwiązać [object preview issue](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wyjściowej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie określone wymiary. Gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Rozwiązanie działające**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno z nową prezentacją, jak i istniejącym szablonem.

Przykład wymaga Aspose.Cells for Python via Java oraz Aspose.Slides for Python via Java. Tworzy prosty wykres kolumnowy na aktywnym arkuszu wykresu i osadza skoroszyt w formacie XLS. Nie jest przypisany żaden obraz podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu podawane są w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Use a Template](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) na false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) przez [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) i [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 pikseli. Ustaw [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) na wartość CUSTOM typu [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Przykład osadza skoroszyt za pomocą [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Współrzędne i wymiary slajdu podane są w punktach (72 punkty na cal).
        width = 684.0  # 9,5 cala.
        height = 288.0  # 4 cale.

        chart.setSizeWithWindow(False)
        # Konwertuj punkty na piksele wykresu używając 96 pikseli na cal.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Użyj szablonu**

Logika określania rozmiaru jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Załaduj prezentację szablonową zamiast tworzyć pustą prezentację.  
1. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako miejsca wstawienia.  
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Zachowaj niezmienione obliczenia rozmiaru.  
1. Dodaj ramkę OLE w miejscu placeholdera zamiast stałych współrzędnych 36 i 72.  
1. Usuń placeholder przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po jego aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak mogę utrzymać spójność rozmiarów wykresu i ramki OLE?**

Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj niestandardowego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i przeliczenia jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu wystarczy?**

Samo dopasowanie rozmiaru okna skoroszytu nie zapewnia niezawodnej ochrony przed zmianą rozmiaru ramki OLE po aktywacji. Należy używać stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno z prezentacjami opartymi na szablonie, jak i z nowymi prezentacjami?**

Tak. W przypadku szablonu użyj wymiarów i pozycji placeholdera. W nowej prezentacji podaj wymiary i pozycję ramki bezpośrednio.

**Czy mogę używać tego przykładu z wykresami utworzonymi w innych programach arkuszowych?**

Przykład używa skoroszytu Excel utworzonego za pomocą Aspose.Cells. Nie demonstruje zachowania aktywacji dla innych programów arkuszowych.

## **Powiązane sekcje**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)