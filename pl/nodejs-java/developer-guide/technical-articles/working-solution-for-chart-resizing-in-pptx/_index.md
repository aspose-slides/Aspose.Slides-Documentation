---
title: Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w pliku PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides for Node.js via Java. Ustaw stałe wymiary wykresu, aby zachować spójność rozmiarów wykresu i ramki OLE."
---
## **Przegląd**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmieniać rozmiar po pierwszej aktywacji. Może to powodować zauważalną różnicę w wyglądzie wykresu przed i po aktywacji. Ten artykuł wyjaśnia, dlaczego zachodzi zmiana rozmiaru i pokazuje, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for Node.js via Java i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides for Node.js via Java. Aby rozwiązać [problem z podglądem obiektu](/slides/pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wynikowej prezentacji, gdy dwukrotnie klikniesz ramkę obiektu OLE wyświetlającą obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel stara się zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie określone wymiary. Gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje jako część procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Działające rozwiązanie**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. To rozwiązanie działa zarówno z nową prezentacją, jak i istniejącym szablonem.

Przykład wymaga Aspose.Cells for Node.js via Java i Aspose.Slides for Node.js via Java. Zainstaluj pakiety Node.js `aspose.cells`, `aspose.slides.via.java` i `java`. Uruchom dwa skrypty CommonJS poniżej w osobnych procesach Node.js, używając tego samego katalogu roboczego, ponieważ oba pakiety Aspose inicjalizują most Java podczas ładowania. Tworzy on prosty wykres kolumnowy na aktywnym arkuszu wykresu i osadza skoroszyt w formacie XLS. Nie przypisano obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu są podane w punktach (72 punkty na cal). W przypadku istniejącej prezentacji zobacz [Użyj szablonu](#use-a-template).

## **Ustaw stały rozmiar wykresu**

Ustaw [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) na false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) za pomocą [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) i [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 piksele. Ustaw [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) na wartość CUSTOM typu `PrintSizeType`. Przykład osadza skoroszyt przy użyciu [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

Zapisz ten pierwszy skrypt jako `create-fixed-chart.js`. Tworzy on `chart-fixed-size.xls` z wykresem o wymiarach 912 × 384 piksele, pasującym do ramki 684 × 288 punktów użytej w drugim skrypcie. Nie jest wymagany żaden skoroszyt wejściowy.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Dopasuj wymiary ramki OLE w punktach (72 punkty na cal).
    const width = 684; // 9,5 cala.
    const height = 288; // 4 cale.

    chart.setSizeWithWindow(false);
    // Konwertuj punkty na piksele wykresu przy użyciu 96 pikseli na cal.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Wszystkie synchroniczne operacje zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

Zapisz drugi skrypt jako `embed-fixed-chart.js` i uruchom go po `create-fixed-chart.js`. Odczytuje on wygenerowany skoroszyt XLS i zapisuje `chart-fixed-size.pptx`. Most Java wymaga explicite tablicy bajtów Java dla danych skoroszytu oraz wartości typu float Java dla współrzędnych i wymiarów ramki. Rozszerzenie `xls` odpowiada formatowi zapisanego skoroszytu.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Współrzędne i wymiary slajdu są w punktach (72 punkty na cal).
    const width = 684; // 9,5 cala.
    const height = 288; // 4 cale.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Wszystkie synchroniczne operacje zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

## **Użyj szablonu**

Logika określania rozmiaru jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Wczytaj prezentację szablonu zamiast tworzyć pustą prezentację.  
1. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako symbolu zastępczego.  
1. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Użyj tych samych wymiarów w skrypcie tworzącym skoroszyt, zachowując niezmienione obliczenia rozmiaru, i wygeneruj ponownie skoroszyt XLS przed jego osadzeniem.  
1. Dodaj ramkę OLE w pozycji symbolu zastępczego zamiast stałych współrzędnych 36 i 72.  
1. Usuń symbol zastępczy przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywowaniu go w PowerPoint?**  
Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak mogę utrzymać spójność rozmiarów wykresu i ramki OLE?**  
Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj własnego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i konwersje jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu jest wystarczające?**  
Dopasowanie samego rozmiaru okna skoroszytu nie zapewnia niezawodnego zapobieżenia zmianie rozmiaru ramki OLE po aktywacji. Użyj stałych wymiarów wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno z prezentacjami opartymi na szablonie, jak i z nowymi prezentacjami?**  
Tak. Dla szablonu użyj wymiarów i pozycji symbolu zastępczego. Dla nowej prezentacji podaj wymiary i pozycję ramki bezpośrednio.

**Czy mogę używać tego przykładu z wykresami tworzonymi w innych programach arkuszy kalkulacyjnych?**  
Przykład używa skoroszytu Excel utworzonego przy pomocy Aspose.Cells. Nie demonstruje zachowania aktywacji dla innych programów arkuszy kalkulacyjnych.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)