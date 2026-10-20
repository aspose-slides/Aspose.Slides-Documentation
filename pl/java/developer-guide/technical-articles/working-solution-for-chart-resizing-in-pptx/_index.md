---
title: Działające rozwiązanie zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w PPTX przy użyciu osadzonych obiektów OLE Excel z Aspose.Slides for Java. Ustaw stałe wymiary wykresu, aby zachować spójność rozmiarów wykresu i ramki OLE."
---
## **Tło**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego zachodzi zmiana rozmiaru i pokazuje, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Tworzenie wykresów Excel i osadzanie ich jako obiekty OLE w prezentacjach](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for Java i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides for Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki OLE wykresu. W wynikowej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz wykresu, wykres Excel jest aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie zdefiniowane wymiary. Gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby zachować proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Rozwiązanie działające**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno w nowej prezentacji, jak i w istniejącym szablonie.

Przykład wymaga Aspose.Cells for Java i Aspose.Slides for Java. Tworzy prosty wykres kolumnowy na aktywnej kartce wykresu i osadza skoroszyt w formacie XLS. Nie przypisuje obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu podane są w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Użyj szablonu](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) na false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary zwracane przez [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) za pomocą [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) i [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 piksele. Ustaw [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) na wartość CUSTOM typy [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Przykład osadza skoroszyt przy użyciu [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Współrzędne i wymiary slajdu są podane w punktach (72 punkty na cal).
        float width = 684f; // 9,5 cala.
        float height = 288f; // 4 cale.

        chart.setSizeWithWindow(false);
        // Konwertuj punkty na piksele wykresu używając 96 pikseli na cal.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Użyj szablonu**

Logika wymiarowania jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Załaduj prezentację szablonu zamiast tworzyć pustą prezentację.  
1. Sprawdź, czy pierwsza slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako symbolu zastępczego.  
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Zachowaj niezmienione obliczenia wymiarów.  
1. Dodaj ramkę OLE w miejscu symbolu zastępczego zamiast stałych współrzędnych 36 i 72.  
1. Usuń symbol zastępczy przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak mogę utrzymać stałe rozmiary wykresu i ramki OLE?**

Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj niestandardowego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i konwersje jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu jest wystarczające?**

Samodzielne dopasowanie rozmiaru okna skoroszytu nie zapewnia niezawodnej ochrony przed zmianą rozmiaru ramki OLE po aktywacji. Należy używać stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno w prezentacjach opartych na szablonie, jak i w nowych prezentacjach?**

Tak. W przypadku szablonu użyj wymiarów i pozycji symbolu zastępczego. W nowej prezentacji określ wymiary i pozycję ramki bezpośrednio.

**Czy mogę używać tego przykładu z wykresami utworzonymi w innych programach arkuszy kalkulacyjnych?**

Przykład używa skoroszytu Excel utworzonego przy pomocy Aspose.Cells. Nie demonstruje zachowania aktywacji dla innych programów arkuszy kalkulacyjnych.

## **Powiązane sekcje**

- [Tworzenie wykresów Excel i osadzanie ich jako obiekty OLE w prezentacjach](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)