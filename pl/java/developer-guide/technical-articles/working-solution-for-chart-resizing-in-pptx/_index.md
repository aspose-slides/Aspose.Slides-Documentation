---
title: Działające rozwiązanie skalowania wykresu w PPTX
type: docs
weight: 40
url: /pl/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- skalowanie wykresu
- wykres Excel
- obiekt OLE
- osadź wykres
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Napraw nieoczekiwane skalowanie wykresu w plikach PPTX przy użyciu osadzonych obiektów Excel OLE w Aspose.Slides dla Javy. Poznaj dwie metody z kodem, aby zachować spójne rozmiary."
---
## **Tło**

Zaobserwowano, że wykresy Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonej wartości po ich pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną w prezentacji między stanem wykresu przed i po aktywacji. Zespół Aspose szczegółowo zbadał problem i znalazł rozwiązanie. W tym artykule opisano przyczyny problemu oraz odpowiednią poprawkę.

W [previous article](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for Java i osadzić go w prezentacji PowerPoint przy pomocy Aspose.Slides for Java. Aby rozwiązać [object preview issue](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wyniku prezentacji, gdy dwukrotnie klikniesz ramkę obiektu OLE wyświetlającą obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą wprowadzić dowolne zmiany w leżącym pod spodem skoroszycie Excel, a następnie wrócić do odpowiedniego slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się po powrocie użytkownika do slajdu, a współczynnik skalowania zależy od pierwotnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna skalowania**

Ponieważ skoroszyt Excel ma własny rozmiar okna, przy pierwszej aktywacji próbuje zachować swój oryginalny rozmiar. Ramka obiektu OLE ma jednak swój własny rozmiar. Według Microsoft, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar i utrzymują prawidłowe proporcje w ramach procesu osadzania. W zależności od różnic między rozmiarem okna Excel a rozmiarem lub pozycją ramki obiektu OLE zachodzi skalowanie.

## **Działające rozwiązanie**

Istnieją dwa możliwe scenariusze tworzenia prezentacji PowerPoint przy użyciu Aspose.Slides for Java.

**Scenariusz 1:** Tworzenie prezentacji na podstawie istniejącego szablonu.

**Scenariusz 2:** Tworzenie prezentacji od podstaw.

Rozwiązanie, które tutaj przedstawiamy, obowiązuje w obu scenariuszach. Podstawą wszystkich podejść jest to samo: **rozmiar okna osadzonego obiektu OLE powinien odpowiadać ramce obiektu OLE w slajdzie PowerPoint**. Omówimy teraz dwa podejścia do tego rozwiązania.

## **Pierwsze podejście**

W tym podejściu nauczymy się ustawiać rozmiar okna osadzonego skoroszytu Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE w slajdzie PowerPoint.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym chcemy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki obiektu OLE jest z góry określony – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar okna skoroszytu równy rozmiarowi tego kształtu. Poniższy fragment kodu pełni tę funkcję:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Ustaw szerokość okna skoroszytu w calach (dzielone przez 72, ponieważ PowerPoint używa 72 punktów na cal).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Ustaw wysokość okna skoroszytu w calach.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Zapisz skoroszyt do strumienia pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenariusz 2**

Załóżmy, że chcemy stworzyć prezentację od podstaw i dodać ramkę obiektu OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę OLE o wysokości 4 cala i szerokości 9,5 cala w pozycji x = 0,5 cala oraz y = 1 cala na slajdzie. Następnie ustawiamy okno skoroszytu Excel na taki sam rozmiar – 4 cala wysokości i 9,5 cala szerokości.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Pożądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 72)
 
// Pożądana szerokość.
int desiredWidth = 684; // 9,5 cala (9.5 * 72)
 
// Zdefiniuj rozmiar wykresu z oknem.
chart.setSizeWithWindow(true);
 
// Ustaw szerokość okna skoroszytu w calach (dzielone przez 72, ponieważ PowerPoint używa 72 punktów na cal).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Ustaw wysokość okna skoroszytu w calach.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Zapisz skoroszyt do strumienia pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 cala (0.5 * 72)
    72,  // y = 1 cal (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Drugie podejście**

W tym podejściu nauczymy się ustawiać rozmiar wykresu w osadzonym skoroszycie Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE w slajdzie PowerPoint. Podejście to jest przydatne, gdy rozmiar wykresu jest znany z góry i nie ulegnie zmianie.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym zamierzamy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest określony z góry – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar wykresu w skoroszycie na równy rozmiarowi kształtu. Poniższy fragment kodu spełnia to zadanie:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Określ rozmiar wykresu bez okna.
chart.setSizeWithWindow(false);
 
// Ustaw szerokość wykresu w pikselach (pomnóż przez 96, ponieważ Excel używa 96 pikseli na cal).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Ustaw wysokość wykresu w pikselach.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Określ rozmiar wydruku wykresu.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Zapisz skoroszyt do strumienia pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenariusz 2**:

Załóżmy, że chcemy stworzyć prezentację od podstaw i dodać ramkę OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę obiektu OLE o wysokości 4 cala i szerokości 9,5 cala na slajdzie w pozycji x = 0,5 cala oraz y = 1 cala. Jednocześnie ustawiamy odpowiadający rozmiar wykresu na te same wymiary: wysokość 4 cala i szerokość 9,5 cala.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Nasza pożądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 72)
 
// Nasza pożądana szerokość.
int desiredWidth = 684; // 9.5 cala (9.5 * 72)
 
// Określ rozmiar wykresu bez okna.
chart.setSizeWithWindow(false);
 
// Ustaw szerokość wykresu w pikselach (podzielona przez 72, aby uzyskać cale, pomnożona przez 96, ponieważ Excel używa 96 pikseli na cal).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Ustaw wysokość wykresu w pikselach.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Zapisz skoroszyt do strumienia pamięci.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 cala (0.5 * 72)
    72,  // y = 1 cal (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Podsumowanie**

Istnieją dwa podejścia do rozwiązania problemu skalowania wykresu. Wybór podejścia zależy od wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone na bazie szablonu, czy od podstaw. Ponadto nie ma ograniczeń co do rozmiaru ramki obiektu OLE w tym rozwiązaniu.

## **FAQ**

### Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować skalowanie.

### Czy można całkowicie zapobiec temu problemowi skalowania?

Tak. Dopasowując rozmiar okna skoroszytu Excel lub rozmiar wykresu do rozmiaru ramki obiektu OLE przed osadzeniem, można utrzymać stałe rozmiary wykresu.

### Które podejście wybrać – ustawianie rozmiaru okna skoroszytu czy rozmiaru wykresu?

Użyj **Approach 1 (window size)**, jeśli chcesz zachować proporcje skoroszytu i ewentualnie umożliwić późniejsze skalowanie.  
Użyj **Approach 2 (chart size)**, jeśli wymiary wykresu są stałe i nie zmienią się po osadzeniu.

### Czy te metody działają zarówno w prezentacjach opartych na szablonie, jak i w nowych prezentacjach?

Tak. Oba podejścia działają identycznie w prezentacjach tworzonych z szablonów i od podstaw.

### Czy istnieje limit rozmiaru ramki obiektu OLE?

Nie. Możesz ustawić ramkę OLE na dowolny rozmiar, o ile proporcjonalnie pasuje do rozmiaru skoroszytu lub wykresu.

### Czy mogę używać tych metod z wykresami tworzonymi w innych programach arkuszy kalkulacyjnych?

Przykłady są przeznaczone dla wykresów Excel tworzonych przy pomocy Aspose.Cells, ale zasady mają zastosowanie również do innych programów arkuszy kalkulacyjnych obsługujących OLE, pod warunkiem że oferują podobne opcje rozmiarowania.

## **Powiązane sekcje**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)