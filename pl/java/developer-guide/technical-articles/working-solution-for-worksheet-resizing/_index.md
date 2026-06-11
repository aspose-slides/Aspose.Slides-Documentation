---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
type: docs
weight: 20
url: /pl/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Napraw zmianę rozmiaru arkusza Excel OLE w prezentacjach: dwa sposoby, aby utrzymać spójność ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="primary" %}}

Zaobserwowano, że arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną w prezentacji między stanem przed i po aktywacji obiektu OLE. Dokonaliśmy szczegółowej analizy tego problemu i przygotowaliśmy rozwiązanie, które opisano w tym artykule.

{{% /alert %}}

## **Tło**

W artykule [Zarządzaj OLE](/slides/pl/java/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzać dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki OLE zmieni się po powrocie użytkownika do slajdu. Współczynnik skalowania będzie zależał od rozmiaru ramki OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, przy pierwszej aktywacji próbuje zachować swój pierwotny rozmiar. Z kolei ramka obiektu OLE posiada własne wymiary. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić zachowanie prawidłowych proporcji w ramach procesu osadzania. Zmiana rozmiaru zachodzi w zależności od różnic pomiędzy rozmiarem okna Excel a rozmiarem i pozycją ramki OLE.

## **Rozwiązanie**

Istnieją dwa możliwe sposoby uniknięcia efektu zmiany rozmiaru.

- Skalowanie rozmiaru ramki OLE w prezentacji PowerPoint tak, aby odpowiadało wysokości i szerokości żądanej liczby wierszy i kolumn w ramce OLE.
- Zachowanie stałego rozmiaru ramki OLE i skalowanie rozmiaru uczestniczących wierszy i kolumn, aby zmieściły się w wybranym rozmiarze ramki OLE.

### **Skalowanie rozmiaru ramki OLE**

W tym podejściu dowiemy się, jak ustawić rozmiar ramki OLE osadzonego skoroszytu Excel tak, aby odpowiadał łącznemu rozmiarowi uczestniczących wierszy i kolumn w arkuszu Excel.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu rozmiar ramki OLE zostanie najpierw obliczony na podstawie łącznych wysokości wierszy i szerokości kolumn uczestniczących w skoroszycie. Następnie ustawimy rozmiar ramki OLE na tę obliczoną wartość. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” w PowerPoint, przechwycimy również obraz żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Skalowanie rozmiaru zakresu komórek**

W tym podejściu dowiemy się, jak skalować wysokości uczestniczących wierszy i szerokości uczestniczących kolumn, aby pasowały do niestandardowego rozmiaru ramki OLE.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu ustawimy rozmiar ramki OLE oraz przeskalujemy rozmiary wierszy i kolumn, które tworzą obszar ramki OLE. Następnie zapisujemy skoroszyt do strumienia, aby zastosować zmiany, i konwertujemy go na tablicę bajtów w celu dodania do ramki OLE. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” w PowerPoint, przechwycimy również obraz żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaluj zakres komórek, aby dopasować go do rozmiaru ramki.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Musimy użyć zmodyfikowanego skoroszytu.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Dodaj obraz OLE do zasobów prezentacji.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Utwórz ramkę obiektu OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Oczekiwana szerokość zakresu komórek w punktach.
 * @param height    Oczekiwana wysokość zakresu komórek w punktach.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Wniosek**

{{% alert color="primary" %}} 

Istnieją dwa podejścia, które pozwalają naprawić problem zmiany rozmiaru arkusza. Wybór odpowiedniego podejścia zależy od konkretnych wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki OLE.

{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować pierwotny rozmiar okna przy aktywacji, podczas gdy ramka OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może skutkować zmianą rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE tak, aby pasowała do rozmiaru zakresu komórek Excel lub skalując zakres komórek, aby pasował do pożądanego rozmiaru ramki OLE, można uniknąć niechcianej zmiany rozmiaru.

**Którą metodę skalowania wybrać – skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn Excela. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania działają, jeśli moja prezentacja oparta jest na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy stosowaniu tych metod?**

Nie. Możesz ustawić dowolny rozmiar ramki OLE, o ile odpowiednio skalujesz.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**

Tak. Tworząc zrzut docelowego zakresu komórek Excel i ustawiając go jako obraz zastępczy ramki OLE, możesz wyświetlić własny podgląd zamiast domyślnego tekstu.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatyczna aktualizacja obiektów OLE przy użyciu dodatku MS PowerPoint](/slides/pl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)