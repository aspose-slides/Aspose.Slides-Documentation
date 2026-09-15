---
title: Działające rozwiązanie problemu zmiany rozmiaru wykresu w PPTX
type: docs
weight: 40
url: /pl/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- zmiana rozmiaru wykresu
- wykres Excel
- obiekt OLE
- osadzanie wykresu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Napraw nieoczekiwaną zmianę rozmiaru wykresu w plikach PPTX przy użyciu osadzonych obiektów Excel OLE z Aspose.Slides for Python via Java. Poznaj dwie metody z kodem, aby zachować spójne rozmiary."
---
## **Tło**

Zaobserwowano, że wykresy Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po ich pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną w prezentacji między stanem wykresu przed i po aktywacji. Zespół Aspose dokładnie zbadał problem i znalazł rozwiązanie. Ten artykuł opisuje przyczyny problemu oraz odpowiadające im rozwiązanie.

W [poprzednim artykule](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) wyjaśniliśmy, jak stworzyć wykres Excel przy użyciu Aspose.Cells for Python via Java i osadzić go w prezentacji PowerPoint przy użyciu Aspose.Slides for Python via Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wykresu do ramki obiektu OLE wykresu. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz wykresu, wykres Excel zostaje aktywowany. Użytkownicy mogą wprowadzać dowolne zmiany w podstawowym skoroszycie Excel, a następnie powrócić do odpowiedniego slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmienia się po powrocie użytkownika do slajdu, a współczynnik skalowania zależy od oryginalnych rozmiarów zarówno ramki obiektu OLE, jak i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, przy pierwszej aktywacji próbuje zachować swój pierwotny rozmiar. Rama obiektu OLE ma natomiast własny rozmiar. Zgodnie z informacjami od Microsoft, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar i utrzymują poprawne proporcje w ramach procesu osadzania. W zależności od różnic między rozmiarem okna Excel a rozmiarem lub pozycją ramki obiektu OLE, zachodzi zmiana rozmiaru.

## **Rozwiązanie**

Istnieją dwa możliwe scenariusze tworzenia prezentacji PowerPoint przy użyciu Aspose.Slides for Python via Java.

**Scenariusz 1:** Utworzenie prezentacji na podstawie istniejącego szablonu.

**Scenariusz 2:** Utworzenie prezentacji od zera.

Podane tutaj rozwiązanie ma zastosowanie do obu scenariuszy. Podstawą wszystkich podejść jest to samo: **rozmiar okna osadzonego obiektu OLE powinien odpowiadać ramce obiektu OLE w slajdzie PowerPoint**. Omówimy teraz dwa podejścia do tego rozwiązania.

## **Pierwsze podejście**

W tym podejściu nauczymy się, jak ustawić rozmiar okna osadzonego skoroszytu Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE w slajdzie PowerPoint.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przypuśćmy, że w szablonie znajduje się kształt o indeksie 2, w którym chcemy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki obiektu OLE jest z góry określony – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar okna skoroszytu równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Załaduj skoroszyt Excel zawierający wykres.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Ustaw rozmiar okna skoroszytu w calach (PowerPoint używa 72 punktów na cal).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Zapisz skoroszyt do strumienia pamięci.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenariusz 2**

Powiedzmy, że chcemy utworzyć prezentację od zera i dodać ramkę OLE dowolnego rozmiaru z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę OLE o wysokości 4 cali i szerokości 9,5 cala w pozycji x = 0,5 cala oraz y = 1 cal na slajdzie. Następnie ustawiamy okno skoroszytu Excel na ten sam rozmiar – 4 cale wysokości i 9,5 cala szerokości.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Załaduj skoroszyt Excel zawierający wykres.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 cale (4 * 72).
    desired_width = 684  # 9,5 cala (9.5 * 72).

    # Zdefiniuj rozmiar wykresu z oknem.
    chart.setSizeWithWindow(True)

    # Ustaw rozmiar okna skoroszytu w calach (PowerPoint używa 72 punktów na cal).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Zapisz skoroszyt do strumienia pamięci.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Drugie podejście**

W tym podejściu nauczymy się, jak ustawić rozmiar wykresu w osadzonym skoroszycie Excel tak, aby odpowiadał rozmiarowi ramki obiektu OLE w slajdzie PowerPoint. To podejście jest przydatne, gdy rozmiar wykresu jest znany z góry i nie będzie się zmieniał.

**Scenariusz 1**

Załóżmy, że zdefiniowaliśmy szablon i chcemy tworzyć prezentacje na jego podstawie. Przypuśćmy, że w szablonie znajduje się kształt o indeksie 2, w którym zamierzamy umieścić ramkę OLE zawierającą osadzony skoroszyt Excel. W tym scenariuszu rozmiar ramki OLE jest z góry określony – odpowiada rozmiarowi kształtu o indeksie 2 w szablonie. Wszystko, co musimy zrobić, to ustawić rozmiar wykresu w skoroszycie równy rozmiarowi tego kształtu. Poniższy fragment kodu spełnia to zadanie:

```python
import jpage
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

    # Załaduj skoroszyt Excel zawierający wykres.
    workbook = Workbook("chart.xls")
    chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Zdefiniuj rozmiar wykresu bez okna.
    chart.setSizeWithWindow(False)

    # Ustaw rozmiar wykresu w pikselach (Excel używa 96 pikseli na cal).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Zdefiniuj rozmiar wydruku wykresu.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Zapisz skoroszyt do strumienia pamięci.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenariusz 2**:

Załóżmy, że chcemy utworzyć prezentację od zera i dodać ramkę OLE dowolnego rozmiaru z osadzonym skoroszytem Excel. W poniższym fragmencie kodu tworzymy ramkę OLE o wysokości 4 cali i szerokości 9,5 cala na slajdzie w pozycji x = 0,5 cala oraz y = 1 cal. Jednocześnie ustawiamy rozmiar wykresu na te same wymiary: wysokość 4 cale i szerokość 9,5 cala.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Załaduj skoroszyt Excel zawierający wykres.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 cale (4 * 72).
    desired_width = 684  # 9,5 cala (9.5 * 72).

    # Zdefiniuj rozmiar wykresu bez okna.
    chart.setSizeWithWindow(False)

    # Ustaw rozmiar wykresu w pikselach (Excel używa 96 pikseli na cal).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Zapisz skoroszyt do strumienia pamięci.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Utwórz ramkę obiektu OLE z osadzonymi danymi Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Wniosek**

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru wykresu. Wybór podejścia zależy od wymagań i konkretnego przypadku użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone na podstawie szablonu, czy od zera. Dodatkowo nie ma ograniczeń co do rozmiaru ramki obiektu OLE w tym rozwiązaniu.

## **FAQ**

**Dlaczego mój osadzony wykres Excel zmienia rozmiar po jego aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje przywrócić pierwotny rozmiar okna przy pierwszej aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Dopasowując rozmiar okna skoroszytu Excel lub rozmiar wykresu do rozmiaru ramki obiektu OLE przed osadzeniem, można utrzymać spójny rozmiar wykresu.

**Które podejście wybrać – ustawić rozmiar okna skoroszytu czy rozmiar wykresu?**

Użyj **podejścia 1 (rozmiar okna)**, jeśli chcesz zachować proporcje skoroszytu i ewentualnie umożliwić późniejsze skalowanie.  
Użyj **podejścia 2 (rozmiar wykresu)**, jeśli wymiary wykresu są stałe i nie będą się zmieniały po osadzeniu.

**Czy te metody działają zarówno w prezentacjach opartych na szablonie, jak i w nowych prezentacjach?**

Tak. Oba podejścia działają identycznie zarówno dla prezentacji tworzonych na podstawie szablonów, jak i od zera.

**Czy istnieje limit rozmiaru ramki obiektu OLE?**

Nie. Możesz ustawić ramkę OLE na dowolny rozmiar, pod warunkiem że odpowiednio skalujesz ją względem rozmiaru skoroszytu lub wykresu.

**Czy mogę używać tych metod z wykresami utworzonymi w innych programach arkuszy?**

Przykłady są przeznaczone dla wykresów Excel tworzonych przy użyciu Aspose.Cells, ale zasady mają zastosowanie również do innych programów arkuszy zgodnych z OLE, o ile obsługują podobne opcje rozmiaru.

## **Powiązane sekcje**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)