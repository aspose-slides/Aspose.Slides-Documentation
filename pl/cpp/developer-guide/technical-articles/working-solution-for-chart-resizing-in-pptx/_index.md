---
title: Rozwiązanie Działające dla Zmiany Rozmiaru Wykresu w PPTX
type: docs
weight: 60
url: /pl/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides dla C++. Poznaj dwie metody z kodem, aby zachować spójne rozmiary."
---
## **Tło**

Zaobserwowano, że wykresy Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po ich pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną w prezentacji pomiędzy stanem wykresu przed i po aktywacji. Zespół Aspose szczegółowo zbadał problem i znalazł rozwiązanie. Ten artykuł opisuje przyczyny problemu oraz odpowiadające im rozwiązanie.

W [poprzednim artykule](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak utworzyć wykres Excel za pomocą Aspose.Cells dla C++ i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides dla C++. Aby rozwiązać [problem podglądu obiektu](/slides/pl/cpp/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy końcowi mogą wprowadzać dowolne zmiany w podstawowym skoroszycie Excel, a następnie wrócić do odpowiedniego slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się, gdy użytkownik wraca do slajdu, a współczynnik zmiany rozmiaru zależy od pierwotnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel posiada własny rozmiar okna, próbuje zachować swój pierwotny rozmiar przy pierwszej aktywacji. Ramka obiektu OLE ma natomiast własny rozmiar. Według Microsoftu, gdy skoroszyt Excel zostaje aktywowany, Excel i PowerPoint negocjują rozmiar i utrzymują właściwe proporcje jako część procesu osadzania. W zależności od różnic pomiędzy rozmiarem okna Excel a rozmiarem lub położeniem ramki obiektu OLE, zachodzi zmiana rozmiaru.

## **Rozwiązanie**

Istnieją dwa możliwe scenariusze tworzenia prezentacji PowerPoint przy użyciu Aspose.Slides dla C++.

**Scenariusz 1:** Utworzyć prezentację na podstawie istniejącego szablonu.

**Scenariusz 2:** Utworzyć prezentację od podstaw.

Rozwiązanie, które przedstawiamy, ma zastosowanie do obu scenariuszy. Podstawą wszystkich podejść jest to samo: **rozmiar okna wbudowanego obiektu OLE powinien odpowiadać ramce obiektu OLE na slajdzie PowerPoint**. Poniżej omówimy dwa podejścia do tego rozwiązania.

## **Pierwsze podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar okna osadzonego skoroszytu Excel, aby odpowiadał rozmiarowi ramki obiektu OLE na slajdzie PowerPoint.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym chcemy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki obiektu OLE jest zdefiniowany z góry — odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Musimy jedynie ustawić rozmiar okna skoroszytu na taki sam jak rozmiar tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Zdefiniuj rozmiar wykresu z oknem. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Ustaw szerokość okna skoroszytu w calach (podzielone przez 72, ponieważ PowerPoint używa 72 pikseli na cal).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Ustaw wysokość okna skoroszytu w calach.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Zapisz skoroszyt do strumienia pamięci.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Create an OLE object frame with the embedded Excel data.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenariusz 2**

Załóżmy, że chcemy stworzyć prezentację od podstaw i umieścić ramkę obiektu OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę obiektu OLE o wysokości 4 cali i szerokości 9,5 cala w pozycji x = 0,5 cala oraz y = 1 cal na slajdzie. Następnie ustawiamy okno skoroszytu Excel na ten sam rozmiar — 4 cale wysokości i 9,5 cala szerokości.

```cpp
// Nasza żądana wysokość.
int32_t desiredHeight = 288; // 4 cale (4 * 72)

// Nasza żądana szerokość.
int32_t desiredWidth = 684; // 9,5 cala (9.5 * 72)

// Zdefiniuj rozmiar wykresu z oknem. 
chart->SetSizeWithWindow(true);

// Ustaw szerokość okna skoroszytu w calach.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Ustaw wysokość okna skoroszytu w calach.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Zapisz skoroszyt do strumienia pamięci.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Drugie podejście**

W tym podejściu dowiemy się, jak ustawić rozmiar wykresu w osadzonym skoroszycie Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE na slajdzie PowerPoint. Podejście to jest przydatne, gdy rozmiar wykresu jest znany z góry i nie ulegnie zmianie.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przyjmijmy, że w szablonie znajduje się kształt o indeksie 2, w którym zamierzamy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest zdefiniowany z góry — odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Musimy jedynie ustawić rozmiar wykresu w skoroszycie na taki sam jak rozmiar tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```cpp
// Zdefiniuj rozmiar wykresu bez okna. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Ustaw szerokość wykresu w pikselach (pomnóż przez 96, ponieważ Excel używa 96 pikseli na cal).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Ustaw wysokość wykresu w pikselach.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Zdefiniuj rozmiar wydruku wykresu.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Zapisz skoroszyt do strumienia pamięci.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenariusz 2**

Załóżmy, że chcemy stworzyć prezentację od podstaw i umieścić ramkę obiektu OLE o dowolnym rozmiarze z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę obiektu OLE o wysokości 4 cali i szerokości 9,5 cala na slajdzie w pozycji x = 0,5 cala oraz y = 1 cal. Ustawiamy także odpowiedni rozmiar wykresu na te same wymiary: wysokość 4 cale i szerokość 9,5 cala.

```cpp
// Nasza żądana wysokość.
int32_t desiredHeight = 288; // 4 cale (4 * 576)

// Nasza żądana szerokość.
int32_t desiredWidth = 684; // 9,5 cala(9.5 * 576)

// Zdefiniuj rozmiar wykresu bez okna. 
chart->SetSizeWithWindow(false);

// Ustaw szerokość wykresu w pikselach.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Ustaw wysokość wykresu w pikselach.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Zapisz skoroszyt do strumienia pamięci.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Wniosek**

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru wykresu. Wybór podejścia zależy od wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone na podstawie szablonu, czy od podstaw. Ponadto w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki obiektu OLE.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po aktywacji w PowerPoint?**  
Odpowiedź: Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**  
Tak. Dopasowując rozmiar okna skoroszytu Excel lub rozmiar wykresu do rozmiaru ramki obiektu OLE przed osadzeniem, można utrzymać stały rozmiar wykresu.

**Które podejście wybrać, ustawienie rozmiaru okna skoroszytu czy rozmiaru wykresu?**  
Użyj **Podejścia 1 (rozmiar okna)**, jeśli chcesz zachować proporcje skoroszytu i ewentualnie umożliwić późniejsze skalowanie.  
Użyj **Podejścia 2 (rozmiar wykresu)**, jeśli wymiary wykresu są stałe i nie będą się zmieniać po osadzeniu.

**Czy te metody będą działały zarówno w prezentacjach opartych na szablonach, jak i w nowych prezentacjach?**  
Tak. Oba podejścia działają identycznie dla prezentacji tworzonych na podstawie szablonów i od podstaw.

**Czy istnieje limit rozmiaru ramki obiektu OLE?**  
Nie. Można ustawić ramkę OLE na dowolny rozmiar, pod warunkiem że odpowiednio skaluje się do rozmiaru skoroszytu lub wykresu.

**Czy mogę używać tych metod z wykresami tworzonymi w innych programach arkuszy kalkulacyjnych?**  
Przykłady są przeznaczone dla wykresów Excel tworzonych przy użyciu Aspose.Cells, ale zasady mają zastosowanie również do innych programów obsługujących OLE, pod warunkiem że oferują podobne opcje rozmiarowania.

## **Powiązane sekcje**

- [Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach](/slides/pl/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)