---
title: Rozwiązanie problemu zmiany rozmiaru arkusza
type: docs
weight: 20
url: /pl/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Napraw zmianę rozmiaru arkusza Excel OLE w prezentacjach: dwa sposoby, aby utrzymać ramki obiektów spójne—skalowanie ramki lub arkusza—w formatach PPT i PPTX."
---
{{% alert color="info" %}}

Zaobserwowano, że arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonej wielkości po pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną w prezentacji między stanem przed i po aktywacji obiektu OLE. Zbadaliśmy ten problem szczegółowo i przedstawiliśmy rozwiązanie, które opisano w tym artykule.

{{% /alert %}}

## **Tło**

W artykule [Manage OLE](/slides/pl/androidjava/manage-ole/), wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides dla Androida w Javie. Aby rozwiązać [problem podglądu obiektu](/slides/pl/androidjava/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki OLE zmieni się po powrocie użytkownika do slajdu. Współczynnik zmiany rozmiaru będzie zależał od rozmiaru ramki OLE oraz osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel posiada własny rozmiar okna, próbuje zachować swój pierwotny rozmiar przy pierwszej aktywacji. Z kolei ramka obiektu OLE ma własny rozmiar. Według Microsoft, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić prawidłowe proporcje w ramach procesu osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Działające rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj rozmiar ramki OLE w prezentacji PowerPoint, aby dopasować wysokość i szerokość do żądanej liczby wierszy i kolumn w ramce OLE.
- Utrzymaj stały rozmiar ramki OLE i skaluj rozmiar uczestniczących wierszy i kolumn, aby mieściły się w wybranym rozmiarze ramki OLE.

### **Skalowanie rozmiaru ramki OLE**

W tym podejściu nauczymy się, jak ustawić rozmiar ramki OLE osadzonego skoroszytu Excel, aby odpowiadał łącznemu rozmiarowi uczestniczących wierszy i kolumn w arkuszu Excel.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu rozmiar ramki obiektu OLE zostanie najpierw obliczony na podstawie łącznych wysokości wierszy i szerokości kolumn uczestniczących w skoroszycie. Następnie ustawimy rozmiar ramki OLE na tę obliczoną wartość. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, zrobimy także zrzut obrazu żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Pobierz szerokość i wysokość obrazu OLE w punktach.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Potrzebujemy użyć zmodyfikowanego skoroszytu.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Dodaj obraz OLE do zasobów prezentacji.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Utwórz ramkę obiektu OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

W tym podejściu nauczymy się, jak skalować wysokości uczestniczących wierszy i szerokość uczestniczących kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu ustawimy rozmiar ramki OLE i skalujemy rozmiar wierszy oraz kolumn uczestniczących w obszarze ramki OLE. Następnie zapisujemy skoroszyt do strumienia, aby zastosować zmiany, i konwertujemy go na tablicę bajtów w celu dodania do ramki OLE. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, zrobimy także zrzut obrazu żądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

// Skaluj zakres komórek, aby dopasować do rozmiaru ramki.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

## **Wnioski**

{{% alert color="info" %}} 

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru arkusza. Wybór odpowiedniego podejścia zależy od konkretnych wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone od szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki obiektu OLE.

{{% /alert %}}

## **FAQ**

### Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?

Dzieje się tak, ponieważ Excel stara się zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby zachować proporcje, co może prowadzić do zmiany rozmiaru.

### Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?

Tak. Skalując ramkę OLE tak, aby dopasowała się do rozmiaru zakresu komórek Excela lub skalując zakres komórek tak, aby dopasował się do żądanego rozmiaru ramki OLE, można zapobiec niepożądanej zmianie rozmiaru.

### Którą metodę skalowania wybrać: skalowanie ramki OLE czy skalowanie zakresu komórek?

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn Excela. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w swojej prezentacji.

### Czy te rozwiązania będą działać, jeśli moja prezentacja opiera się na szablonie?

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych na bazie szablonów, jak i od podstaw.

### Czy istnieje limit rozmiaru ramki OLE przy użyciu tych metod?

Nie. Możesz ustawić ramkę obiektu OLE na dowolny rozmiar, pod warunkiem odpowiedniego skalowania.

### Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?

Tak. Tworząc zrzut docelowego zakresu komórek Excel i ustawiając go jako obraz zastępczy ramki OLE, możesz wyświetlić własny obraz podglądu zamiast domyślnego tekstu zastępczego.