---
title: Działające rozwiązanie problemu zmiany rozmiaru arkusza
type: docs
weight: 20
url: /pl/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Napraw zmianę rozmiaru arkusza Excel OLE w prezentacjach: dwa sposoby utrzymania spójności ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Note" %}}
Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmieniać rozmiar po pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby jego rozwiązania.
{{% /alert %}}

## **Tło**

W artykule [Zarządzaj OLE](/slides/pl/nodejs-java/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides dla Node.js poprzez Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy końcowi mogą wprowadzać dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem Excel. Rozmiar ramki OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie zależał od rozmiaru ramki OLE oraz osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować swój pierwotny rozmiar po pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własny rozmiar. Według Microsoft, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić zachowanie właściwych proporcji w ramach procesu osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie działające**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn.
- Utrzymaj stały rozmiar ramki OLE i skaluj wybrane wiersze oraz kolumny, aby pasowały do niej.

### **Skaluj rozmiar ramki OLE**

To podejście ustawia rozmiar ramki OLE tak, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) określa wyświetlany zakres. Podgląd jest renderowany w 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisany za pomocą [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) w celu zastąpienia tekstu zastępczego "EMBEDDED OLE OBJECT" w zapisanej prezentacji.

Zainstaluj pakiety `aspose.cells`, `aspose.slides.via.java` oraz `java` i umieść `sample.xlsx` w katalogu roboczym. Dla każdego podejścia najpierw uruchom skrypt przygotowawczy, a następnie skrypt osadzający w osobnym procesie Node.js w tym samym katalogu. Dwa pakiety Aspose inicjalizują most Java oddzielnie.

Zapisz ten skrypt przygotowawczy jako `prepare-frame-scaled.js` i uruchom go poleceniem `node prepare-frame-scaled.js`. Zapisuje on pliki `frame-scaled.xlsx` i `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Wszystkie operacje synchroniczne zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

Zapisz ten skrypt osadzający jako `embed-frame-scaled.js` i uruchom go poleceniem `node embed-frame-scaled.js`. Odczytuje on te pliki i zapisuje `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Wszystkie operacje synchroniczne zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

Pomocniczy podgląd ustawia [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) na wybrany zakres i usuwa marginesy, nagłówki oraz stopki. Po włączeniu [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea), [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) renderuje zakres jako obraz PNG. Pomocnik zapisuje obraz PNG do pliku do użycia w prezentacji.

### **Skaluj rozmiar zakresu komórek**

To podejście skaluje wysokości wybranych wierszy i szerokości wybranych kolumn, aby dopasować do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) definiuje wyświetlany zakres, a pomocnik skaluje ten zakres, aby pasował do ramki o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do pliku, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) osadza go w określonym rozmiarze. Podgląd renderowany w 96 DPI jest przypisany za pomocą [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego zastępczego obrazu.

Zapisz ten skrypt przygotowawczy jako `prepare-cells-scaled.js` i uruchom go poleceniem `node prepare-cells-scaled.js`. Zapisuje on pliki `cells-scaled.xlsx` i `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Wszystkie operacje synchroniczne zostały zakończone; zatrzymaj proces mostu Java.
process.exit(cellsPrepared ? 0 : 1);
```

Zapisz ten skrypt osadzający jako `embed-cells-scaled.js` i uruchom go poleceniem `node embed-cells-scaled.js`. Odczytuje on te pliki i zapisuje `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Wszystkie operacje synchroniczne zostały zakończone; zatrzymaj proces mostu Java.
process.exit(0);
```

Pomocnik skalowania oblicza osobne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości kolumn oraz względne wysokości wierszy. Przed zastosowaniem ich przy użyciu [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) i [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) konwertuje obliczone wymiary z punktów na cale. Wybrany zakres musi mieć niezerową szerokość i wysokość.

Ten pomocniczy podgląd renderuje zmieniony zakres przy użyciu [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Ogranicza [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) do tego zakresu, usuwa marginesy, nagłówki i stopki oraz zapisuje obraz PNG do pliku.

## **Wnioski**
{{% alert color="info" title="Note" %}}
Istnieją dwa podejścia do naprawy problemu zmiany rozmiaru arkusza. Wybierz podejście, które najlepiej spełnia Twoje wymagania i przypadek użycia. Oba podejścia działają w ten sam sposób, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od zera. Dodatkowo w tym rozwiązaniu nie ma ograniczenia rozmiaru ramki obiektu OLE.
{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar przy pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może powodować zmianę rozmiaru.

**Czy istnieje możliwość całkowitego zapobieżenia temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE, aby dopasować rozmiar do zakresu komórek Excel, lub skalując zakres komórek, aby dopasować do wymaganego rozmiaru ramki OLE, można zapobiec niechcianej zmianie rozmiaru.

**Którą metodę skalowania powinienem użyć: skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować pierwotne rozmiary wierszy i kolumn Excel. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania będą działać, jeśli moja prezentacja oparta jest na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje ograniczenie rozmiaru ramki OLE przy użyciu tych metod?**

Nie. Możesz ustawić ramkę obiektu OLE na dowolny rozmiar, pod warunkiem odpowiedniego ustawienia skali.

**Czy istnieje sposób na uniknięcie tekstu zastępczego "EMBEDDED OLE OBJECT" w PowerPoint?**

Tak. Pobierając migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, można wyświetlić własny obraz podglądu zamiast domyślnego zastępczego obrazu.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatyczna aktualizacja obiektów OLE przy użyciu dodatku MS PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)