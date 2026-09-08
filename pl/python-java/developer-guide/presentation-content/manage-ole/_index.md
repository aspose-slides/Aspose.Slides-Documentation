---
title: Zarządzanie OLE w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/python-java/manage-ole/
keywords:
- Obiekt OLE
- Łączenie i osadzanie obiektów
- dodaj OLE
- osadź OLE
- dodaj obiekt
- osadź obiekt
- dodaj plik
- osadź plik
- powiązany obiekt
- powiązany plik
- zmień OLE
- ikona OLE
- tytuł OLE
- wyodrębnij OLE
- wyodrębnij obiekt
- wyodrębnij plik
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona poprzez Java. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) jest technologią Microsoft, która umożliwia umieszczanie danych i obiektów utworzonych w jednej aplikacji w innej aplikacji poprzez łączenie lub osadzanie.

{{% /alert %}}

Rozważmy wykres utworzony w MS Excel. Wykres jest następnie umieszczany na slajdzie PowerPoint. Ten wykres Excel jest uważany za obiekt OLE.

- Obiekt OLE może pojawić się jako ikona. W takim przypadku, po dwukrotnym kliknięciu ikony, wykres otwiera się w powiązanej aplikacji (Excel) lub jest wyświetlane zapytanie o wybór aplikacji do otwarcia lub edycji obiektu.
- Obiekt OLE może wyświetlać swoją rzeczywistą zawartość, taką jak zawartość wykresu. W tym przypadku wykres jest aktywowany w PowerPoint, interfejs wykresu ładuje się i można modyfikować dane wykresu w obrębie PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/pl/python-java/) pozwala wstawiać OLE Objects do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/)).

## **Dodaj ramki obiektów OLE do slajdów**

Zakładając, że już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Python via Java, możesz zrobić to w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Odczytaj plik Excel jako tablicę bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) do slajdu, zawierając tablicę bajtów oraz inne informacje o obiekcie OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy wykres z pliku Excel do slajdu jako ramkę obiektu OLE przy użyciu Aspose.Slides for Python via Java. **Uwaga**, że konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleembeddeddatainfo/) przyjmuje rozszerzenie obiektu, które ma być osadzone, jako drugi parametr. To rozszerzenie pozwala PowerPoint prawidłowo zinterpretować typ pliku i wybrać odpowiednią aplikację do otwarcia tego obiektu OLE.

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

### **Dodaj ramki powiązanych obiektów OLE**

Aspose.Slides for Python via Java umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) bez osadzania danych, a jedynie z linkiem do pliku.

Ten kod w Pythonie pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) z powiązanym plikiem Excel do slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do ramek obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz łatwo go znaleźć lub uzyskać do niego dostęp w następujący sposób:

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.
3. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/).
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma tylko jeden kształt na pierwszym slajdzie. Następnie sprawdziliśmy, że obiekt jest [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/). To była pożądana ramka obiektu OLE, do której chcemy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego w slajdzie obiektu wykresu Excel) oraz jej danych plikowych.

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

### **Uzyskaj dostęp do właściwości powiązanej ramki obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości powiązanej ramki obiektu OLE.

Ten kod w Pythonie pokazuje, jak sprawdzić, czy obiekt OLE jest powiązany, a następnie uzyskać ścieżkę do powiązanego pliku:

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

        # Sprawdź, czy obiekt OLE jest powiązany.
        if ole_frame.isObjectLink():
            # Wypisz pełną ścieżkę do powiązanego pliku.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Wypisz względną ścieżkę do powiązanego pliku, jeśli istnieje.
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

1. Wczytaj prezentację z osadzonym obiektem OLE, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu ramki obiektu OLE.
   W naszym przykładzie użyliśmy wcześniej utworzonego pliku PPTX, który ma jeden kształt na pierwszym slajdzie. Następnie sprawdziliśmy, że obiekt jest [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/). To była pożądana ramka obiektu OLE, do której chcemy uzyskać dostęp.
4. Po uzyskaniu dostępu do ramki obiektu OLE możesz wykonać na niej dowolną operację.
5. Utwórz obiekt [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) i uzyskaj dostęp do danych OLE.
6. Uzyskaj dostęp do żądanego [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) i zmień dane.
7. Zapisz zaktualizowany [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) w strumieniu.
8. Zmień dane obiektu OLE ze strumienia.

W poniższym przykładzie uzyskuje się dostęp do ramki obiektu OLE (osadzonego w slajdzie obiektu wykresu Excel) i modyfikuje jej dane plikowe w celu zaktualizowania danych wykresu.

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

        # Odczytaj dane obiektu OLE jako obiekt Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modyfikuj dane skoroszytu.
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

## **Osadzanie innych typów plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for Python via Java umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawiać pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w odpowiednim programie lub wyświetlane jest zapytanie o wybór odpowiedniego programu do otwarcia.

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

## **Ustaw typy plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może być konieczna wymiana starych obiektów OLE na nowe lub zastąpienie nieobsługiwanego obiektu OLE obsługiwanym. Aspose.Slides for Python via Java umożliwia ustawienie typu pliku dla osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie.

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

## **Ustaw obrazy ikon i tytuły dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawane jest podgląd składający się z obrazu ikony. Ten podgląd jest tym, co użytkownicy widzą przed uzyskaniem dostępu lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu jako elementów podglądu, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for Python via Java.

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

## **Zapobiegaj zmianie rozmiaru i przemieszczeniu ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu prezentacji, po otwarciu prezentacji w PowerPoint może pojawić się komunikat z prośbą o zaktualizowanie linków. Kliknięcie przycisku „Update Links” może zmienić rozmiar i pozycję ramki obiektu OLE, ponieważ PowerPoint aktualizuje dane z powiązanego obiektu OLE i odświeża podgląd obiektu. Aby zapobiec wyświetlaniu tego pytania, ustaw metodę [setUpdateAutomatic](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) klasy [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) na `False`:

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

Aspose.Slides for Python via Java umożliwia wyodrębnianie plików osadzonych w slajdach jako obiekty OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej obiekty OLE, które zamierzasz wyodrębnić.
2. Iteruj po wszystkich kształtach w prezentacji i uzyskaj dostęp do kształtów [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/).
3. Uzyskaj dostęp do danych osadzonych plików z ramek obiektów OLE i zapisz je na dysk.

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

Renderowana jest to, co jest widoczne na slajdzie — ikona/obraz podmienny (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przenosić/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/python-java/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd powiązanego OLE. Aby uzyskać stabilny wygląd, stosuj praktyki opisane w [Working Solution for Worksheet Resizing](/slides/pl/python-java/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz podmiany.

**Czy względne ścieżki do powiązanych obiektów OLE będą zachowane w formacie PPTX?**

W PPTX informacje o „względnych ścieżkach” nie są dostępne — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać pewnych ścieżek bezwzględnych/dostępnych URI lub osadzania.