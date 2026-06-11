---
title: Zarządzanie OLE w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj OLE
type: docs
weight: 40
url: /pl/python-net/manage-ole/
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
- Aspose.Slides
description: "Optymalizuj zarządzanie obiektami OLE w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona przez .NET. Osadzaj, aktualizuj i eksportuj zawartość OLE bezproblemowo."
---
## **Wprowadzenie**

{{% alert title="Informacja" color="info" %}}
**OLE (Object Linking & Embedding)** jest technologią Microsoft, która pozwala na powiązanie lub osadzenie danych i obiektów utworzonych w jednej aplikacji w innej.
{{% /alert %}}

Na przykład wykres utworzony w Microsoft Excel i umieszczony na slajdzie PowerPoint jest obiektem OLE.

- Obiekt OLE może występować jako ikona. Podwójne kliknięcie ikony otwiera obiekt w powiązanej aplikacji (np. Excel) lub wyświetla okno wyboru aplikacji do otwarcia lub edycji.
- Obiekt OLE może wyświetlać swoją zawartość (na przykład wykres). W takim przypadku PowerPoint aktywuje osadzony obiekt, ładuje interfejs wykresu i umożliwia edytowanie danych wykresu bezpośrednio w PowerPoint.

Aspose.Slides for Python umożliwia wstawianie obiektów OLE do slajdów jako ramki obiektów OLE ([OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/)).

## **Dodawanie obiektów OLE do slajdów**

Jeśli już utworzyłeś wykres w Microsoft Excel i chcesz osadzić go w slajdzie jako ramkę obiektu OLE przy użyciu Aspose.Slides for Python, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Odczytaj plik Excel do tablicy bajtów.
1. Dodaj [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) do slajdu, podając tablicę bajtów oraz inne szczegóły obiektu OLE.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie wykres z pliku Excel jest osadzony w slajdzie jako [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/).

**Uwaga:** Konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pl/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) przyjmuje rozszerzenie pliku osadzania jako drugi parametr. PowerPoint wykorzystuje to rozszerzenie do identyfikacji typu pliku i wyboru odpowiedniej aplikacji do otwarcia obiektu OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Przygotuj dane dla obiektu OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Dodaj ramkę obiektu OLE do slajdu.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Dodawanie powiązanych obiektów OLE**

Aspose.Slides for Python umożliwia dodanie [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/), który odwołuje się do pliku zamiast osadzania jego danych.

Poniższy przykład w Pythonie pokazuje, jak dodać [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/), powiązany z plikiem Excel na slajdzie:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj ramkę obiektu OLE z powiązanym plikiem Excel.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do obiektów OLE**

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz uzyskać do niego dostęp w następujący sposób:

1. Wczytaj prezentację zawierającą osadzony obiekt OLE, tworząc instancję klasy Presentation.
1. Uzyskaj odniesienie do slajdu według jego indeksu.
1. Uzyskaj dostęp do kształtu OleObjectFrame.
1. Po uzyskaniu ramki obiektu OLE wykonaj na niej niezbędne operacje.

Poniższy przykład uzyskuje dostęp do ramki obiektu OLE — osadzonego wykresu Excel — i pobiera jego dane pliku. W tym przykładzie używamy pliku PPTX zawierającego pojedynczy kształt na pierwszym slajdzie.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Pobierz dane osadzonego pliku.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Pobierz rozszerzenie osadzonego pliku.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Dostęp do właściwości powiązanego obiektu OLE**

Aspose.Slides umożliwia dostęp do właściwości ramki powiązanego obiektu OLE.

Poniższy przykład w Pythonie sprawdza, czy obiekt OLE jest powiązany i, jeśli tak, pobiera ścieżkę do powiązanego pliku:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Sprawdź, czy obiekt OLE jest powiązany.
        if ole_frame.is_object_link:
            # Wyświetl pełną ścieżkę do powiązanego pliku.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Wyświetl względną ścieżkę do powiązanego pliku, jeśli istnieje.
            # Tylko prezentacje .ppt mogą zawierać ścieżkę względną.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Zmiana danych obiektu OLE**

{{% alert color="primary" %}}
W tej sekcji poniższy przykład kodu wykorzystuje [Aspose.Cells for Python via .NET](/cells/python-net/).
{{% /alert %}}

Jeśli obiekt OLE jest już osadzony w slajdzie, możesz uzyskać do niego dostęp i zmodyfikować jego dane w następujący sposób:

1. Wczytaj prezentację, tworząc instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj docelowy slajd według jego indeksu.
1. Uzyskaj dostęp do kształtu [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/).
1. Po uzyskaniu ramki obiektu OLE wykonaj wymagane operacje.
1. Utwórz obiekt `Workbook` i odczytaj dane OLE.
1. Otwórz żądany `Worksheet` i edytuj dane.
1. Zapisz zaktualizowany `Workbook` do strumienia.
1. Zastąp dane obiektu OLE używając tego strumienia.

W poniższym przykładzie dostęp do ramki obiektu OLE (osadzonego wykresu Excel) jest uzyskany i jego dane pliku są modyfikowane w celu zaktualizowania wykresu. Przykład używa wcześniej utworzonego pliku PPTX zawierającego pojedynczy kształt na pierwszym slajdzie.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Odczytaj dane obiektu OLE jako obiekt Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Zmodyfikuj dane skoroszytu.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Zmień dane obiektu ramki OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Osadzanie plików w slajdach**

Oprócz wykresów Excel, Aspose.Slides for Python umożliwia osadzanie innych typów plików w slajdach. Na przykład możesz wstawić pliki HTML, PDF i ZIP jako obiekty. Gdy użytkownik dwukrotnie kliknie wstawiony obiekt, otwiera się automatycznie w powiązanej aplikacji lub wyświetlane jest okno wyboru odpowiedniego programu.

Poniższy kod w Pythonie pokazuje, jak osadzić pliki HTML i ZIP w slajdzie:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie typów plików dla osadzonych obiektów**

Podczas pracy z prezentacjami może być konieczne zastąpienie starych obiektów OLE nowymi lub wymiana nieobsługiwanego obiektu OLE na obsługiwany. Aspose.Slides for Python umożliwia ustawienie typu pliku osadzonego obiektu, co pozwala zaktualizować dane ramki OLE lub jej rozszerzenie pliku.

Poniższy kod w Pythonie pokazuje, jak ustawić typ pliku osadzonego obiektu OLE na `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Zmień typ pliku na ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie obrazów ikon i tytułów dla osadzonych obiektów**

Po osadzeniu obiektu OLE automatycznie dodawany jest podgląd w formie ikony. Ten podgląd jest widoczny dla użytkowników przed dostępem lub otwarciem obiektu OLE. Jeśli chcesz użyć konkretnego obrazu i tekstu w podglądzie, możesz ustawić obraz ikony i tytuł przy użyciu Aspose.Slides for Python.

Poniższy kod w Pythonie pokazuje, jak ustawić obraz ikony i tytuł dla osadzonego obiektu:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Dodaj obraz do zasobów prezentacji.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ustaw tytuł i obraz dla podglądu OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zapobieganie zmianie rozmiaru i położenia ramki obiektu OLE**

Po dodaniu powiązanego obiektu OLE do slajdu PowerPoint może wyświetlić monitu o aktualizację linków przy otwieraniu prezentacji. Wybranie Aktualizuj linki może zmienić rozmiar i położenie ramki obiektu OLE, ponieważ PowerPoint odświeża podgląd danymi z powiązanego obiektu. Aby zapobiec wyświetlaniu monitu o aktualizację danych obiektu, ustaw właściwość `update_automatic` klasy [OleObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) na `False`:

```py
ole_frame.update_automatic = False
```

## **Wyodrębnianie osadzonych plików**

Aspose.Slides for Python umożliwia wyodrębnianie plików osadzonych w slajdach jako obiektów OLE w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), która zawiera obiekty OLE, które chcesz wyodrębnić.
1. Iteruj przez wszystkie kształty w prezentacji i znajdź kształty OLEObjectFrame.
1. Pobierz osadzone dane pliku z każdego [OLEObjectFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/oleobjectframe/) i zapisz je na dysk.

Poniższy kod w Pythonie pokazuje, jak wyodrębnić pliki osadzone w slajdzie jako obiekty OLE:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Czy zawartość OLE będzie renderowana przy eksportowaniu slajdów do PDF/obrazów?**

Renderowana jest to, co jest widoczne na slajdzie — ikona/obraz zastępczy (podgląd). „Żywa” zawartość OLE nie jest wykonywana podczas renderowania. W razie potrzeby ustaw własny obraz podglądu, aby zapewnić oczekiwany wygląd w wyeksportowanym PDF.

**Jak mogę zablokować obiekt OLE na slajdzie, aby użytkownicy nie mogli go przemieszczać/edytować w PowerPoint?**

Zablokuj kształt: Aspose.Slides udostępnia [blokady na poziomie kształtu](/slides/pl/python-net/applying-protection-to-presentation/). Nie jest to szyfrowanie, ale skutecznie zapobiega przypadkowym edycjom i przemieszczaniu.

**Dlaczego powiązany obiekt Excel „przeskakuje” lub zmienia rozmiar po otwarciu prezentacji?**

PowerPoint może odświeżać podgląd powiązanego OLE. Aby uzyskać stabilny wygląd, stosuj praktyki opisane w [Working Solution for Worksheet Resizing](/slides/pl/python-net/working-solution-for-worksheet-resizing/) — dopasuj ramkę do zakresu lub skaluj zakres do stałej ramki i ustaw odpowiedni obraz zastępczy.

**Czy względne ścieżki powiązanych obiektów OLE będą zachowane w formacie PPTX?**

W formacie PPTX informacje o „ścieżce względnej” nie są dostępne — tylko pełna ścieżka. Ścieżki względne występują w starszym formacie PPT. Dla przenośności lepiej używać pewnych ścieżek bezwzględnych/ dostępnych URI lub osadzania.