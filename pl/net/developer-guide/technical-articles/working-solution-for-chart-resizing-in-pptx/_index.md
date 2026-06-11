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
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w pliku PPTX przy użyciu osadzonych obiektów OLE Excel w Aspose.Slides dla .NET. Poznaj dwie metody z kodem, aby zachować spójne rozmiary."
---
## **Tło**

Zaobserwowano, że wykresy Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po ich pierwszej aktywacji. Zachowanie to powoduje wyraźną różnicę wizualną w prezentacji między stanem wykresu przed i po aktywacji. Zespół Aspose dokładnie zbadał problem i znalazł rozwiązanie. Ten artykuł opisuje przyczyny problemu oraz odpowiednią poprawkę.

W [poprzednim artykule](/slides/pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel przy użyciu Aspose.Cells for .NET i osadzić go w prezentacji PowerPoint za pomocą Aspose.Slides for .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki OLE obiektu wykresu. W wynikowej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz wykresu, wykres Excel jest aktywowany. Użytkownicy mogą wprowadzić dowolne zmiany w podstawowym skoroszycie Excel, a następnie powrócić do odpowiedniego slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować swój pierwotny rozmiar przy pierwszej aktywacji. Ramka obiektu OLE ma jednak własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar i utrzymują prawidłowe proporcje w ramach procesu osadzania. W zależności od różnic między rozmiarem okna Excel a rozmiarem lub pozycją ramki OLE, zachodzi zmiana rozmiaru.

## **Rozwiązanie**

Istnieją dwa możliwe scenariusze tworzenia prezentacji PowerPoint przy użyciu Aspose.Slides for .NET.

**Scenariusz 1:** Utwórz prezentację na podstawie istniejącego szablonu.

**Scenariusz 2:** Utwórz prezentację od podstaw.

Rozwiązanie, które tutaj przedstawiamy, ma zastosowanie do obu scenariuszy. Podstawą wszystkich podejść jest to samo: **rozmiar okna osadzonego obiektu OLE powinien odpowiadać ramce obiektu OLE na slajdzie PowerPoint**. Omówimy teraz dwa podejścia do tego rozwiązania.

## **Pierwsze podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar okna osadzonego skoroszytu Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE na slajdzie PowerPoint.

**Scenariusz 1**

Załóżmy, że mamy zdefiniowany szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym chcemy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest z góry określony – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar okna skoroszytu równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```cs
// Określ rozmiar wykresu z oknem. 
chart.SizeWithWindow = true;

// Ustaw szerokość okna skoroszytu w calach (dzielone przez 72, ponieważ PowerPoint używa 72 pikseli na cal).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Ustaw wysokość okna skoroszytu w calach.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Zapisz skoroszyt do strumienia pamięci.
MemoryStream workbookStream = workbook.SaveToStream();

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenariusz 2**

Powiedzmy, że chcemy utworzyć prezentację od podstaw i dodać ramkę OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę OLE o wysokości 4 cali i szerokości 9,5 cala w położeniu x = 0,5 cala oraz y = 1 cal na slajdzie. Następnie ustawiamy okno skoroszytu Excel na ten sam rozmiar – 4 cale wysokości i 9,5 cala szerokości.

```cs
// Nasza żądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 72)

// Nasza żądana szerokość.
int desiredWidth = 684;//9.5 cala (9.5 * 72)

// Określ rozmiar wykresu z oknem.
chart.SizeWithWindow = true;

// Ustaw szerokość okna skoroszytu w calach.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Ustaw wysokość okna skoroszytu w calach.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Zapisz skoroszyt do strumienia pamięci.
MemoryStream workbookStream = workbook.SaveToStream();

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Drugie podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar wykresu w osadzonym skoroszycie Excel tak, aby odpowiadał rozmiarowi ramki OLE na slajdzie PowerPoint. To podejście jest użyteczne, gdy rozmiar wykresu jest znany z góry i nie będzie się zmieniał.

**Scenariusz 1**

Załóżmy, że mamy zdefiniowany szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym zamierzamy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest z góry określony – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar wykresu w skoroszycie równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```cs
// Zdefiniuj rozmiar wykresu bez okna. 
chart.SizeWithWindow = false;

// Ustaw szerokość wykresu w pikselach (pomnóż przez 96, ponieważ Excel używa 96 pikseli na cal).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Ustaw wysokość wykresu w pikselach.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Zdefiniuj rozmiar wydruku wykresu.
chart.PrintSize = PrintSizeType.Custom;

// Zapisz skoroszyt do strumienia pamięci.
MemoryStream workbookStream = workbook.SaveToStream();

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenariusz 2**

Załóżmy, że chcemy utworzyć prezentację od podstaw i dodać ramkę OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę OLE o wysokości 4 cali i szerokości 9,5 cala na slajdzie w położeniu x = 0,5 cala oraz y = 1 cal. Ustawiamy również rozmiar wykresu na te same wymiary: wysokość 4 cale i szerokość 9,5 cala.

```cs
 // Nasza żądana wysokość.
int desiredHeight = 288; // 4 cale (4 * 576)

// Nasza żądana szerokość.
int desiredWidth = 684; // 9.5 cala (9.5 * 576)

// Zdefiniuj rozmiar wykresu bez okna. 
chart.SizeWithWindow = false;

// Ustaw szerokość wykresu w pikselach.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Ustaw wysokość wykresu w pikselach.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Zapisz skoroszyt do strumienia pamięci.
MemoryStream workbookStream = workbook.SaveToStream();

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Wnioski**

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru wykresu. Wybór podejścia zależy od wymagań i konkretnego scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od podstaw. Nie ma również ograniczeń co do rozmiaru ramki OLE w tym rozwiązaniu.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**  
Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może prowadzić do zmiany rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**  
Tak. Dopasowując rozmiar okna skoroszytu Excel lub rozmiar wykresu do rozmiaru ramki OLE przed osadzeniem, można utrzymać stały rozmiar wykresu.

**Które podejście powinienem wybrać: ustawianie rozmiaru okna skoroszytu czy rozmiaru wykresu?**  
Użyj **podejścia 1 (rozmiar okna)**, jeśli chcesz zachować proporcje skoroszytu i ewentualnie umożliwić późniejsze zmiany rozmiaru.  
Użyj **podejścia 2 (rozmiar wykresu)**, jeśli wymiary wykresu są stałe i nie będą się zmieniać po osadzeniu.

**Czy te metody działają zarówno w prezentacjach opartych na szablonie, jak i w nowych prezentacjach?**  
Tak. Oba podejścia działają identycznie w prezentacjach tworzonych z szablonów i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE?**  
Nie. Ramkę OLE można ustawić na dowolny rozmiar, o ile proporcjonalnie skaluje się do rozmiaru skoroszytu lub wykresu.

**Czy mogę używać tych metod z wykresami utworzonymi w innych programach arkuszowych?**  
Przykłady są przeznaczone dla wykresów Excel tworzonych przy użyciu Aspose.Cells, ale zasady mają zastosowanie do innych programów arkuszowych kompatybilnych z OLE, o ile obsługują podobne opcje rozmiaru.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Aktualizuj obiekty OLE automatycznie przy użyciu dodatku PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)