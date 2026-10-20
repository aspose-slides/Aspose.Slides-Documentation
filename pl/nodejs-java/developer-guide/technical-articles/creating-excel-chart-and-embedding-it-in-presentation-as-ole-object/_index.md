---
title: Utwórz wykresy Excel i osadź je w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Wykres Excel
- osadź wykres
- obiekt OLE
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Utwórz wykres Excel przy użyciu Aspose.Cells for Node.js via Java i osadź skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides, w tym podgląd wykresu."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć wykres słupkowy Excel przy użyciu Aspose.Cells for Node.js via Java i osadzić jego skoroszyt w prezentacji PowerPoint przy użyciu Aspose.Slides for Node.js via Java. Osadzony skoroszyt zawiera zarówno dane źródłowe, jak i wykres. Oddzielny podgląd PNG wyświetla wykres na slajdzie przed aktywacją obiektu OLE.

Wynikiem jest osadzony obiekt Excel, a nie natywny wykres PowerPoint. Edycja skoroszytu poprzez OLE wymaga aplikacji desktopowej obsługującej aktywację OLE oraz kompatybilnej instalacji Excel.

## **Wymagania wstępne**

Zainstaluj pakiety Node.js `aspose.cells`, `aspose.slides.via.java` oraz `java`. Uruchom przykłady jako dwa skrypty CommonJS w osobnych procesach Node.js: najpierw `create-chart.js`, potem `embed-chart.js`, używając tego samego katalogu roboczego. Oba pakiety Aspose inicjalizują most Java podczas ładowania, dlatego przykłady muszą działać w oddzielnych procesach. Microsoft Office nie jest wymagany do wygenerowania prezentacji przy użyciu tych bibliotek.

Nie jest wymagany żaden istniejący skoroszyt ani obraz. Pierwszy skrypt tworzy `ChartWorkbook.xlsx` i `ChartPreview.png`; drugi odczytuje te pliki i zapisuje `OutputChart.pptx` w bieżącym katalogu roboczym. Zastosuj licencje obu produktów, gdy uruchamiasz poza trybem ewaluacyjnym.

## **Jak działa osadzanie**

1. Utwórz skoroszyt z arkuszem danych i arkuszem wykresu.  
1. Ustaw arkusz wykresu jako aktywny, aby skoroszyt otwierał się na wykresie.  
1. Określ zakres wyświetlania OLE skoroszytu i wyrenderuj wykres do PNG.  
1. Zapisz skoroszyt jako XLSX i osadź jego bajty w slajdzie w osobnym procesie Node.js.  
1. Przypisz PNG jako podgląd obiektu OLE i zapisz prezentację jako PPTX.

Zakres wyświetlania skoroszytu i ramka na slajdzie pełnią różne role. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) przyjmuje indeksy wierszy i kolumn rozpoczynające się od zera. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) przyjmuje natomiast wiersz górny, kolumnę lewą, wiersz dolny i kolumnę prawą. Przykład używa indeksu wiersza 55 i indeksu kolumny 25 jako granic prawidłowo‑dolnych; wartości te są wyborem układu, a nie liczbą wierszy czy kolumn danych.

Rama slajdu używa punktów. Przykład dopasowuje ją do slajdu i centruje, zachowując proporcje PNG, zamiast rozciągać podgląd, aby wypełnić slajd.

## **Utworzenie i osadzenie wykresu**

Zapisz pierwszy przykład jako `create-chart.js`. Wypełnia on `DataSheet` czterema wierszami i pięcioma kolumnami wartości. Każdy wiersz staje się serią wykresu. `ChartSheet` jest wybierany jako aktywny arkusz przed zapisaniem skoroszytu.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderuj podgląd wykresu i osobno serializuj edytowalny skoroszyt.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Wszystkie synchroniczne prace zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

Zapisz poniższy przykład jako `embed-chart.js`. Uruchom go po tym, jak `create-chart.js` utworzy oba pliki wejściowe. Centruje on ramkę OLE i zachowuje proporcje obrazu podglądu.

Drugi skrypt osadza zapisany skoroszyt i używa PNG jako jego podglądu. Skoroszyt jest wyraźnie zapisywany jako XLSX, pasując do rozszerzenia `xlsx` przekazanego do [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG jest ładowany bezpośrednio z bajtów, bez pośredniej konwersji bitmapy. Most Java wymaga jawnych tablic bajtów Java dla obrazu i danych skoroszytu oraz wartości zmiennoprzecinkowych Java dla współrzędnych ramki slajdu. Przypisanie go przez [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) zastępuje domyślny placeholder OLE.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Dopasuj podgląd do slajdu bez zmiany jego proporcji.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Wszystkie synchroniczne prace zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

## **Oczekiwany wynik**

`OutputChart.pptx` zawiera jeden slajd z osadzonym skoroszytem Excel i podglądem wykresu. Skoroszyt zawiera oryginalne dane oraz wykres słupkowy z czterema seriami. Podgląd jest wyśrodkowany na slajdzie i zachowuje proporcje.

![Wykres słupkowy Excel wyświetlany jako podgląd osadzonego skoroszytu](excel-chart-ole-preview.png)

W kompatybilnym środowisku PowerPoint na komputerze, z zainstalowanym Excelem, podwójne kliknięcie obiektu aktywuje i umożliwi edycję osadzonego skoroszytu. Aktywacja i edycja zależą od wsparcia OLE w aplikacji hosta oraz od ustawień zabezpieczeń.

## **FAQ**

**Dlaczego potrzebny jest obraz podglądu?**

Osadzony skoroszyt i jego podgląd na slajdzie to oddzielne elementy. Dostarcz obraz wykresu, aby slajd wyświetlał wykres zamiast domyślnego symbolu „EMBEDDED OLE OBJECT”. Zobacz [Object Preview Issue when Adding OleObjectFrame](/slides/pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Czy podgląd aktualizuje się automatycznie po zmianie skoroszytu w kodzie?**

Traktuj podgląd jako migawkę. Po aktualizacji danych skoroszytu programowo, wygeneruj ponownie obraz wykresu i zastąp podgląd oraz dane osadzonego skoroszytu.

**Czy mogę użyć formatu XLS zamiast XLSX?**

Tak. Zapisz skoroszyt w formacie XLS i użyj `xls` jako rozszerzenia danych osadzonych. Rozszerzenie musi odpowiadać rzeczywistemu formatowi skoroszytu; samo zmienienie rozszerzenia nie konwertuje danych.

**Dlaczego obiekt może zmienić rozmiar po aktywacji?**

Aplikacja hosta może zaktualizować prezentację obiektu OLE po jego aktywacji. Zarówno zakres wyświetlania OLE skoroszytu, jak i wymiary ramki slajdu mają znaczenie. Zobacz [Working Solution for Chart Resizing in PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/).

## **Powiązane sekcje**

- [Working Solution for Chart Resizing in PPTX](/slides/pl/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)