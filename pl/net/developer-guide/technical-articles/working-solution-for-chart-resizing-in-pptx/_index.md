---
title: Rozwiązanie działające dla zmiany rozmiaru wykresu w PPTX
type: docs
weight: 60
url: /pl/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w plikach PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides dla .NET. Ustaw stałe wymiary wykresu, aby utrzymać spójność rozmiarów wykresu i ramki OLE."
---
## **Tło**

Wykresy Excel osadzone jako obiekty OLE w prezentacjach PowerPoint przy użyciu komponentów Aspose mogą zmienić rozmiar po pierwszej aktywacji. Może to prowadzić do widocznej różnicy w wyglądzie wykresu przed i po aktywacji. W tym artykule wyjaśniamy, dlaczego zachodzi zmiana rozmiaru i pokazujemy, jak jej zapobiec, dopasowując stałe wymiary wykresu do ramki OLE.

W [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel za pomocą Aspose.Cells dla .NET i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides dla .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W prezentacji wyjściowej, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą edytować osadzony skoroszyt Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Osadzony skoroszyt Excel ma własne wymiary okna, które Excel próbuje zachować przy pierwszej aktywacji obiektu. Ramka OLE na slajdzie ma niezależnie określone wymiary. Gdy skoroszyt Excel zostaje aktywowany, Excel i PowerPoint negocjują rozmiar obiektu, aby utrzymać jego proporcje w ramach procesu osadzania. Różnice między oknem skoroszytu a ramką OLE mogą więc powodować zmianę rozmiaru obiektu.

## **Działające rozwiązanie**

Dopasuj rozmiar wykresu do ramki OLE na slajdzie i utrzymaj wymiary wykresu niezależne od okna skoroszytu. Rozwiązanie działa zarówno z nową prezentacją, jak i z istniejącym szablonem.

Przykład wymaga Aspose.Cells dla .NET oraz Aspose.Slides dla .NET. Tworzy prosty wykres kolumnowy na aktywnym arkuszu wykresów i osadza skoroszyt w formacie XLS. Nie przypisuje się obrazu podglądu wykresu; wykres staje się widoczny po aktywacji obiektu OLE w PowerPoint.

Przykład tworzy nową prezentację z ramką OLE o wymiarach 9,5 × 4 cala, umieszczoną 0,5 cala od lewej krawędzi i 1 cala od góry. Współrzędne i wymiary slajdu podane są w punktach (72 punkty na cal). Dla istniejącej prezentacji zobacz [Użyj szablonu](#use-a-template).

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Współrzędne i wymiary slajdu są podane w punktach (72 punkty na cal).
var width = 684f; // 9,5 cala.
var height = 288f; // 4 cale.

chart.SizeWithWindow = false;
// Konwertuj punkty na piksele wykresu używając 96 pikseli na cal.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ustaw stały rozmiar wykresu**

Ustaw [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) na wartość false, aby wymiary wykresu były niezależne od okna skoroszytu. Ustaw wymiary [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) za pomocą [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) i [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), konwertując punkty na piksele przy użyciu 96 pikseli na cal: ramka o wymiarach 684 × 288 punktów odpowiada wykresowi o wymiarach 912 × 384 piksele. Ustaw [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) na wartość Custom typu [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Przykład osadza skoroszyt za pomocą [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) i zapisuje prezentację z ramką OLE o wymiarach 9,5 × 4 cala.

## **Użyj szablonu**

Logika ustalania rozmiaru jest taka sama dla istniejącej prezentacji. Aby dostosować przykład:

1. Wczytaj prezentację‑szablon zamiast tworzyć pustą prezentację.  
2. Sprawdź, czy pierwszy slajd zawiera co najmniej trzy kształty, a następnie użyj kształtu o indeksie 2 jako miejsca zastępczego.  
3. Pobierz szerokość i wysokość ramki z tego kształtu zamiast używać stałych wartości 684 i 288. Pozostałe obliczenia wymiarów pozostaw bez zmian.  
4. Dodaj ramkę OLE w pozycji miejsca zastępczego zamiast stałych współrzędnych 36 i 72.  
5. Usuń miejsce zastępcze przed zapisaniem prezentacji.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Jak utrzymać spójność rozmiarów wykresu i ramki OLE?**

Ustaw stałe wymiary wykresu, które odpowiadają ramce OLE, i użyj niestandardowego rozmiaru wydruku wykresu przed osadzeniem skoroszytu. Powyższy przykład pokazuje wymagane ustawienia i przeliczenia jednostek.

**Czy dopasowanie rozmiaru okna skoroszytu wystarczy?**

Samo dopasowanie rozmiaru okna skoroszytu nie zapewnia pewnej ochrony przed zmianą rozmiaru ramki OLE po aktywacji. Należy stosować stałe wymiary wykresu, jak pokazano w przykładzie.

**Czy to rozwiązanie działa zarówno w prezentacjach opartych na szablonie, jak i w nowych prezentacjach?**

Tak. Dla szablonu użyj wymiarów i pozycji miejsca zastępczego. Dla nowej prezentacji podaj wymiary i pozycję ramki bezpośrednio.

**Czy mogę użyć tego przykładu z wykresami utworzonymi w innych programach arkuszy kalkulacyjnych?**

Przykład korzysta ze skoroszytu Excel utworzonego za pomocą Aspose.Cells. Nie demonstruje zachowania aktywacji dla innych programów arkuszy kalkulacyjnych.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)