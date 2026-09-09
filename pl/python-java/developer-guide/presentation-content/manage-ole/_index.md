---
title: "Zarządzanie OLE w prezentacjach przy użyciu Pythona"
linktitle: "Zarządzanie OLE"
type: docs
weight: 40
url: /pl/python-java/manage-ole/
keywords:
- "obiekt OLE"
- "Łączenie i osadzanie obiektów"
- "dodaj OLE"
- "osadź OLE"
- "dodaj obiekt"
- "osadź obiekt"
- "dodaj plik"
- "osadź plik"
- "połączony obiekt"
- "połączony plik"
- "zmień OLE"
- "ikona OLE"
- "tytuł OLE"
- "wyodrębnij OLE"
- "wyodrębnij obiekt"
- "wyodrębnij plik"
- "PowerPoint"
- "prezentacja"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument za pomocą Aspose.Slides for Python via Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) to technologia firmy Microsoft, która pozwala na umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie.
{{% /alert %}}

Rozważmy wykres utworzony w MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uznawany za obiekt OLE.

- Obiekt OLE może pojawić się jako ikona. W takim przypadku, po podwójnym kliknięciu ikony, wykres zostaje otwarty w powiązanej aplikacji (Excel) lub zostaniesz poproszony o wybranie aplikacji do otwarcia lub edycji obiektu.
- Obiekt OLE może wyświetlać swoje rzeczywiste treści, takie jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, interfejs wykresu jest ładowany i możesz modyfikować dane wykresu w PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/pl/python-java/) umożliwia wstawianie obiektów OLE na slajdy jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/)).

## **Dodawanie ramek obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Python via Java, możesz zrobić to w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz referencję do slajdu według jego indeksu.
3. Odczytaj plik Excel jako tablicę bajtów.
4. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) do slajdu zawierający tablicę bajtów i inne informacje o obiekcie OLE.
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Python via Java. **Uwaga**, że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu możliwego do osadzenia jako drugi parametr. To rozszerzenie pozwala PowerPoint poprawnie zinterpretować typ pliku i wybrać właściwą aplikację do otwarcia tego obiektu OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Przygotuj dane dla obiektu OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Dodaj ramkę obiektu OLE do slajdu.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dodawanie połączonych ramek obiektów OLE**

Aspose.Slides for Python via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) z odnośnikiem do pliku zamiast osadzonych danych.

Ten kod w Pythonie pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) z połączonym plikiem Excel do slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj ramkę obiektu OLE z połączonym plikiem Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz go łatwo znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz referencję do slajdu według jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/). W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie sprawdziliśmy, że obiekt jest [OleObjectFrame]. To była pożądana ramka obiektu OLE, do której mieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.

W poniższym przykładzie dostęp uzyskano do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) oraz do danych pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Pobierz dane osadzonego pliku.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Pobierz rozszerzenie osadzonego pliku.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Dostęp do właściwości połączonej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości połączonej ramki obiektu OLE.

Ten kod w Pythonie pokazuje, jak sprawdzić, czy obiekt OLE jest połączony, a następnie uzyskać ścieżkę do połączonego pliku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Sprawdź, czy obiekt OLE jest połączony.
        if ole_frame.isObjectLink():
            # Wypisz pełną ścieżkę do połączonego pliku.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Wypisz względną ścieżkę do połączonego pliku, jeśli istnieje.
            # Tylko prezentacje PPT mogą zawierać względną ścieżkę.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Zmienianie danych obiektu OLE**

{{% alert color="info" title="Note" %}}
W tej sekcji poniższy przykład kodu używa [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo uzyskać dostęp do tego obiektu i zmodyfikować jego dane w następujący sposób:

1. Załaduj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) .
2. Pobierz referencję do slajdu według jego indeksu.
3. Uzyskaj dostęp do kształtu ramki obiektu OLE. W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie sprawdziliśmy, że obiekt jest [OleObjectFrame]. To była pożądana ramka obiektu OLE, do której mieliśmy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać dowolną operację na niej.
5. Utwórz obiekt [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanej [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) i zmień dane.
7. Zapisz zaktualizowany [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie uzyskano dostęp do ramki obiektu OLE (obiekt wykresu Excel osadzony w slajdzie) i zmodyfikowano dane pliku, aby zaktualizować dane wykresu.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Wczytaj dane obiektu OLE jako obiekt Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Zmodyfikuj dane skoroszytu.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Zmień dane obiektu ramki OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Osadzanie innych typów plików na slajdach**

Oprócz wykresów Excel, Aspose.Slides for Python via Java umożliwia osadzanie innych typów plików na slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik kliknie dwukrotnie wstawiony obiekt, otwiera się on automatycznie w odpowiednim programie lub użytkownik zostaje poproszony o wybranie odpowiedniego programu do jego otwarcia.

Ten kod w Pythonie pokazuje, jak osadzić HTML i ZIP w slajdzie:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami możesz potrzebować zastąpić stare obiekty OLE nowymi lub zamienić nieobsługiwany obiekt OLE na obsługiwany. Aspose.Slides for Python via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

Ten kod w Pythonie pokazuje, jak ustawić typ pliku dla osadzonego obiektu OLE na `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Zmień typ pliku na ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed uzyskaniem dostępu lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for Python via Java.

Ten kod w Pythonie pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Dodaj obraz do zasobów prezentacji.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Ustaw tytuł i obraz dla podglądu OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu połączonego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie odnośników. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z połączonego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw metodę [setUpdateAutomatic](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) klasy [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) na `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for Python via Java umożliwia wyodrębnianie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej obiekty OLE, które chcesz wyodrębnić.
2. Przejdź przez wszystkie kształty w prezentacji i uzyskaj dostęp do kształtów [OleObjectFrame].
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysku.

Ten kod w Pythonie pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?**

To, co jest widoczne na slajdzie, jest renderowane – ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym pliku PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przemieszczać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [shape-level locks](/slides/pl/python-java/applying-protection-to-presentation/). To nie jest szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego połączony obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd połączonego obiektu OLE. Aby zapewnić stabilny wygląd, postępuj zgodnie z praktykami opisanymi w [Working Solution for Worksheet Resizing](/slides/pl/python-java/working-solution-for-worksheet-resizing/) – dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy ścieżki względne połączonych obiektów OLE będą zachowane w formacie PPTX?**

W formacie PPTX informacje o „ścieżkach względnych” nie są dostępne – jedynie pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności zaleca się używanie niezawodnych ścieżek bezwzględnych/URI dostępnych lub osadzanie.