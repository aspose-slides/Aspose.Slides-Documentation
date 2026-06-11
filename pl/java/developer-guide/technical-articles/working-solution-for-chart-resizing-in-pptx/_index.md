---
title: Działające rozwiązanie problemu zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadź wykres
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w plikach PPTX przy użyciu osadzonych obiektów OLE Excel z Aspose.Slides for Java. Poznaj dwie metody wraz z kodem, które zapewniają spójność rozmiarów."
---
## **Tło**

Zaobserwowano, że wykresy Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną w prezentacji pomiędzy stanem przed i po aktywacji wykresu. Zespół Aspose dokładnie zbadał problem i znalazł rozwiązanie. Ten artykuł opisuje przyczyny problemu oraz odpowiadające mu rozwiązanie.

W [poprzednim artykule](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for Java i osadzić go w prezentacji PowerPoint za pomocą Aspose.Slides for Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki OLE wykresu. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą wprowadzić dowolne zmiany w leżącym pod spodem skoroszycie Excel, a następnie powrócić do odpowiedniego slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować pierwotny rozmiar przy pierwszej aktywacji. Ramka obiektu OLE ma natomiast własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar i utrzymują prawidłowe proporcje jako część procesu osadzania. W zależności od różnic pomiędzy rozmiarem okna Excel a rozmiarem lub pozycją ramki OLE, zachodzi zmiana rozmiaru.

## **Działające rozwiązanie**

Istnieją dwa możliwe scenariusze tworzenia prezentacji PowerPoint przy użyciu Aspose.Slides for Java.

**Scenariusz 1:** Utwórz prezentację na podstawie istniejącego szablonu.

**Scenariusz 2:** Utwórz prezentację od zera.

Rozwiązanie, które tutaj przedstawiamy, dotyczy obu scenariuszy. Podstawą wszystkich podejść jest to samo: **rozmiar okna osadzonego obiektu OLE powinien odpowiadać ramce obiektu OLE na slajdzie PowerPoint**. Omówimy teraz dwa podejścia do tego rozwiązania.

## **Pierwsze podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar okna osadzonego skoroszytu Excel, aby odpowiadał rozmiarowi ramki obiektu OLE na slajdzie PowerPoint.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym chcemy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest określony z góry — odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar okna skoroszytu równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```java
// Ustaw szerokość okna skoroszytu w calach (dzielona przez 576, ponieważ PowerPoint używa 576 pikseli na cal).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Ustaw wysokość okna skoroszytu w calach.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Zapisz skoroszyt do strumienia w pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenariusz 2**

Powiedzmy, że chcemy utworzyć prezentację od zera i dodać ramkę obiektu OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę obiektu OLE o wysokości 4 cale i szerokości 9,5 cala w położeniu x = 0,5 cala i y = 1 cala na slajdzie. Następnie ustawiamy okno skoroszytu Excel na ten sam rozmiar — 4 cale wysokości i 9,5 cala szerokości.

```java
// Żądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 72)
 
// Żądana szerokość.
int desiredWidth = 684; // 9,5 cala (9,5 * 72)
 
// Zdefiniuj rozmiar wykresu z oknem.
chart.setSizeWithWindow(true);
 
// Ustaw szerokość okna skoroszytu w calach (dzielona przez 576, ponieważ PowerPoint używa 576 pikseli na cal).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Ustaw wysokość okna skoroszytu w calach.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Zapisz skoroszyt do strumienia w pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Drugie podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar wykresu w osadzonym skoroszycie Excel, aby odpowiadał rozmiarowi ramki obiektu OLE na slajdzie PowerPoint. To podejście jest przydatne, gdy rozmiar wykresu jest znany z góry i nie zmieni się.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym zamierzamy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest określony z góry — odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar wykresu w skoroszycie równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```java
// Zdefiniuj rozmiar wykresu bez okna.
chart.setSizeWithWindow(false);
 
// Ustaw szerokość wykresu w pikselach (pomnóż przez 96, ponieważ Excel używa 96 pikseli na cal).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Ustaw wysokość wykresu w pikselach.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Zdefiniuj rozmiar wydruku wykresu.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Zapisz skoroszyt do strumienia w pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenariusz 2**:

Załóżmy, że chcemy utworzyć prezentację od zera i dodać ramkę obiektu OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę obiektu OLE o wysokości 4 cale i szerokości 9,5 cala na slajdzie w położeniu x = 0,5 cala i y = 1 cala. Ustawiamy również odpowiedni rozmiar wykresu na te same wymiary: wysokość 4 cale i szerokość 9,5 cala.

```java
// Żądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 72)
 
// Żądana szerokość.
int desiredWidth = 684; // 9,5 cala (9.5 * 72)
 
// Zdefiniuj rozmiar wykresu bez okna.
chart.setSizeWithWindow(false);
 
// Ustaw szerokość wykresu w pikselach (pomnóż przez 96, ponieważ Excel używa 96 pikseli na cal).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Ustaw wysokość wykresu w pikselach.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Zapisz skoroszyt do strumienia w pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Wnioski**

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru wykresu. Wybór podejścia zależy od wymagań i scenariusza użycia. Oba podejścia działają identycznie, niezależnie od tego, czy prezentacje są tworzone na podstawie szablonu, czy od zera. Ponadto w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki obiektu OLE.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Dopasowując rozmiar okna skoroszytu Excel lub rozmiar wykresu do rozmiaru ramki obiektu OLE przed osadzeniem, można utrzymać spójne rozmiary wykresów.

**Które podejście powinienem wybrać, ustawianie rozmiaru okna skoroszytu czy ustawianie rozmiaru wykresu?**

Użyj **Podejście 1 (rozmiar okna)**, jeśli chcesz zachować proporcje skoroszytu i ewentualnie umożliwić zmianę rozmiaru później.  
Użyj **Podejście 2 (rozmiar wykresu)**, jeśli wymiary wykresu są stałe i nie zmienią się po osadzeniu.

**Czy te metody będą działać zarówno dla prezentacji opartych na szablonie, jak i nowych prezentacji?**

Tak. Oba podejścia działają tak samo dla prezentacji tworzonych na podstawie szablonów i od zera.

**Czy istnieje limit rozmiaru ramki obiektu OLE?**

Nie. Można ustawić ramkę OLE na dowolny rozmiar, o ile odpowiednio skaluje się do rozmiaru skoroszytu lub wykresu.

**Czy mogę używać tych metod z wykresami utworzonymi w innych programach arkuszowych?**

Przykłady są przeznaczone dla wykresów Excel tworzonych przy użyciu Aspose.Cells, ale zasady mają zastosowanie do innych programów arkuszowych kompatybilnych z OLE, o ile obsługują podobne opcje rozmiaru.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)