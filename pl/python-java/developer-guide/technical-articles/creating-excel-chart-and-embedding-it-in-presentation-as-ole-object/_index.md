---
title: Utworzenie wykresów Excel i osadzenie ich w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells for Python via Java i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides, w tym podgląd wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres kolumnowy Excel przy użyciu Aspose.Cells for Python via Java i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for Python via Java. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu przez OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz zgodnej instalacji Excel.

## **Wymagania wstępne**

Zainstaluj pakiety Pythona `aspose-cells` i `aspose-slides-java` oraz kompatybilne środowisko uruchomieniowe Java. Zaimportuj oba pakiety przed uruchomieniem JVM, aby ich biblioteki Java były dostępne dla JPype. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Pliki wejściowe nie są wymagane: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje dla obu produktów podczas uruchamiania poza trybem ewaluacji.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.  
1. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.  
1. Ustaw zakres wyświetlania OLE skoroszytu i renderuj wykres do PNG.  
1. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty na slajdzie.  
1. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie pełnią różne role. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) przyjmuje indeksy wierszy i kolumn rozpoczynające się od zera. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) przyjmuje natomiast górny wiersz, lewą kolumnę, dolny wiersz i prawą kolumnę. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako granic prawego dolnego rogu; wartości te są wyborem układu, a nie liczbą wierszy lub kolumn danych.

Rama slajdu używa punktów. Przykład dopasowuje ją do slajdu i centruje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utwórz i osadź wykres**

Poniższy pełny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako aktywny arkusz przed zapisaniem skoroszytu.

Skoroszyt jest wyraźnie zapisywany jako XLSX, zgodnie z rozszerzeniem `xlsx` przekazywanym do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Strumienie tablic bajtów Java przechowują skoroszyt i obraz w pamięci oraz dostarczają tablice bajtów wymagane przez API Java. PNG jest ładowany bezpośrednio z bajtów, bez pośredniej konwersji bitmapy. Przypisanie go przez [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zastępuje domyślny placeholder OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Wygeneruj podgląd wykresu i osobno zserializuj edytowalny skoroszyt.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Dopasuj podgląd do slajdu bez zmiany jego proporcji.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel i podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres kolumnowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje proporcje.

![Wykres kolumnowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W zgodnym środowisku PowerPoint na pulpicie, z dostępnym Excelem, dwukliknij obiekt, aby aktywować i edytować osadzony skoroszyt. Aktywacja i edycja zależą od obsługi OLE oraz ustawień zabezpieczeń aplikacji hosta.

## **FAQ**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie to oddzielne treści. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego placeholdera „EMBEDDED OLE OBJECT”. Zobacz [Object Preview Issue when Adding OleObjectFrame](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Przy programowej aktualizacji danych skoroszytu, wygeneruj ponownie obraz wykresu i zastąp podgląd oraz dane osadzonego skoroszytu.

**Czy mogę użyć XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować prezentację obiektu OLE przy aktywacji skoroszytu. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Working Solution for Chart Resizing in PPTX](/slides/pl/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Working Solution for Chart Resizing in PPTX](/slides/pl/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/)