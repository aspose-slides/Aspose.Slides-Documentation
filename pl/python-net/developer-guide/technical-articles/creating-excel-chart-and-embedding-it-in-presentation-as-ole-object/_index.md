---
title: Tworzenie wykresów Excel i osadzanie ich w prezentacjach jako obiekty OLE
type: docs
weight: 50
url: /pl/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- prezentacja
- Python
- Python via .NET
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells for Python via .NET i osadź skoroszyt w prezentacji PowerPoint z Aspose.Slides, w tym podgląd wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres słupkowy Excel przy użyciu Aspose.Cells for Python via .NET i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for Python via .NET. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu za pośrednictwem OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz kompatybilnej instalacji programu Excel.

## **Wymagania wstępne**

Zainstaluj pakiety `aspose-cells-python` i `aspose-slides` w swoim środowisku Python. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Pliki wejściowe nie są wymagane: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje dla obu produktów, gdy uruchamiasz poza trybem ewaluacyjnym.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.  
1. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.  
1. Ustaw zakres wyświetlania OLE skoroszytu i renderuj wykres do formatu PNG.  
1. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty na slajdzie.  
1. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie mają różne role. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) przyjmuje indeksy wierszy i kolumn rozpoczynające się od zera. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) natomiast przyjmuje wiersz górny, kolumnę lewą, wiersz dolny i kolumnę prawą. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako granic prawy dolny; wartości te są wyborami układu, a nie liczbą wierszy lub kolumn danych.

Ramka slajdu używa jednostki punktów. Przykład dopasowuje ją do slajdu i wyśrodkowuje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utworzenie i osadzenie wykresu**

Poniższy kompletny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako aktywny arkusz przed zapisaniem skoroszytu.

Skoroszyt jest jawnie zapisywany jako XLSX, pasując do rozszerzenia `xlsx` przekazywanego do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG jest wczytywany bezpośrednio ze strumienia, bez pośredniej konwersji bitmapy. Przypisanie go za pomocą [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) zastępuje domyślny znak zastępczy OLE.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Renderuj podgląd wykresu i osobno serializuj edytowalny skoroszyt.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Dopasuj podgląd do slajdu bez zmiany proporcji.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel i podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres słupkowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje swoje proporcje.

![Wykres słupkowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W zgodnym środowisku desktopowym PowerPoint z dostępnym Excelem, dwukrotne kliknięcie obiektu aktywuje i umożliwi edycję osadzonego skoroszytu. Aktywacja i edycja zależą od obsługi OLE przez aplikację hosta oraz ustawień bezpieczeństwa.

## **FAQ**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie to oddzielna zawartość. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego znacznika „EMBEDDED OLE OBJECT”. Zobacz [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Przy programowej aktualizacji danych skoroszytu, wygeneruj ponownie obraz wykresu i zastąp podgląd oraz osadzone dane skoroszytu.

**Czy mogę używać formatu XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja host może zaktualizować prezentację obiektu OLE po aktywacji skoroszytu. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Automatyczna zmiana rozmiaru obiektów OLE w prezentacjach PowerPoint](/slides/pl/python-net/working-solution-for-worksheet-resizing/).

## **Powiązane sekcje**

- [Automatyczna zmiana rozmiaru obiektów OLE w prezentacjach PowerPoint](/slides/pl/python-net/working-solution-for-worksheet-resizing/)
- [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Zarządzanie obiektami OLE](/slides/pl/python-net/manage-ole/)