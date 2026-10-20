---
title: Utwórz wykresy Excel i osadź je w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadź wykres
- obiekt OLE
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Utwórz wykres Excel za pomocą Aspose.Cells for Java i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides, wraz z podglądem wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres kolumnowy Excel za pomocą Aspose.Cells for Java i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for Java. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu za pomocą OLE wymaga aplikacji komputerowej, która obsługuje aktywację OLE i kompatybilnej instalacji Excel.

## **Wymagania wstępne**

Dodaj Aspose.Cells for Java oraz Aspose.Slides for Java do zależności projektu. Uruchom przykład wewnątrz metody Java. Microsoft Office nie jest wymagany do generowania prezentacji przy użyciu tych bibliotek.

Żadne pliki wejściowe nie są wymagane: przykład tworzy dane i wykres w pamięci, a następnie zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje dla obu produktów, gdy uruchamiasz poza trybem oceny.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.
1. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.
1. Ustaw zakres wyświetlania OLE skoroszytu i wygeneruj wykres jako PNG.
1. Zapisz skoroszyt jako XLSX w pamięci i osadź te bajty na slajdzie.
1. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie mają różne role. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) przyjmuje indeksy wierszy i kolumn początkowych/końcowych zaczynające się od zera. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) natomiast przyjmuje górny wiersz, lewą kolumnę, dolny wiersz i prawą kolumnę. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako prawych dolnych granic; te wartości są wyborami układu, a nie liczbą wierszy lub kolumn danych.

Ramka slajdu używa jednostki punktów. Przykład dopasowuje ją do slajdu i centruje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utwórz i osadź wykres**

Poniższy kompletny przykład wypełnia `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako aktywny arkusz przed zapisaniem skoroszytu.

Skoroszyt jest wyraźnie zapisywany jako XLSX, co odpowiada rozszerzeniu `xlsx` przekazywanemu do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG jest ładowany bezpośrednio z bajtów bez pośredniej konwersji bitmapy. Przypisanie go poprzez [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) zastępuje domyślny znak zastępczy OLE.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Wygeneruj podgląd wykresu i osobno zserializuj edytowalny skoroszyt.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Dopasuj podgląd do slajdu bez zmiany jego proporcji.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel oraz podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres kolumnowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje swoje proporcje.

![Wykres kolumnowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W kompatybilnym środowisku PowerPoint na komputerze, z zainstalowanym Excelem, dwukrotne kliknięcie obiektu aktywuje i umożliwi edycję osadzonego skoroszytu. Aktywacja i edycja zależą od obsługi OLE oraz ustawień zabezpieczeń aplikacji hosta.

## **Najczęściej zadawane pytania**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie to oddzielne treści. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego znacznika „EMBEDDED OLE OBJECT”. Zobacz [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Przy programatycznej aktualizacji danych skoroszytu, wygeneruj ponownie obraz wykresu i zastąp podgląd oraz dane osadzonego skoroszytu.

**Czy mogę używać XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować prezentację obiektu OLE podczas aktywacji skoroszytu. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem z podglądem obiektu przy dodawaniu OleObjectFrame](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/)
- [Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint](/slides/pl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)