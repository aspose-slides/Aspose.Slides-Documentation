---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
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
description: "Napraw zmianę rozmiaru arkusza Excel OLE w prezentacjach: dwa sposoby utrzymania spójności ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Note" %}}

Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmieniać rozmiar po ich pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby jego rozwiązania.

{{% /alert %}}

## **Tło**

W artykule [Zarządzaj OLE](/slides/pl/androidjava/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/androidjava/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, gdy dwukrotnie klikniesz ramkę obiektu OLE wyświetlającą obraz arkusza, aktywowany zostaje skoroszyt Excel. Użytkownicy mogą wprowadzać dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie powrócić do slajdu, klikając poza aktywowanym skoroszytem Excel. Rozmiar ramki obiektu OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie różny w zależności od rozmiaru ramki obiektu OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować pierwotny rozmiar przy pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić utrzymanie prawidłowych proporcji w ramach procesu osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie działające**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn.
- Zachowaj stały rozmiar ramki OLE i skaluj wybrane wiersze oraz kolumny, aby pasowały do niej.

### **Skalowanie rozmiaru ramki OLE**

To podejście ustawia rozmiar ramki OLE tak, aby dopasować całkowitą wysokość i szerokość wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiuje wyświetlany zakres. Podgląd jest renderowany w 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisany za pomocą [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aby zastąpić tekst zastępczy „EMBEDDED OLE OBJECT” w zapisanej prezentacji.

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

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w programie PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Musimy użyć zmodyfikowanego skoroszytu.
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

Pomocnik podglądu ustawia [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) na wybrany zakres i usuwa marginesy, nagłówki oraz stopki. Po włączeniu [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-), [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) renderuje zakres jako obraz PNG. Pomocnik zwraca nowy strumień wejściowy zawierający obraz PNG, ustawiony na jego początek do użycia w prezentacji.

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

To podejście skaluje wysokości wybranych wierszy i szerokości wybranych kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza, używając indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) definiuje wyświetlany zakres, a poniższy pomocnik skaluje ten zakres, aby dopasować go do ramki o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do strumienia, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) osadza go w określonym rozmiarze. Podgląd renderowany w 96 DPI jest przypisany za pomocą [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego zastępczego obrazu.

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

// Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w programie PowerPoint.
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

Pomocnik skalowania oblicza oddzielne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości kolumn i względne wysokości wierszy. Przed zastosowaniem ich za pomocą [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) i [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-), konwertuje wyliczone wymiary z punktów na cale. Wybrany zakres musi mieć niezerową szerokość i wysokość.

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

Ten pomocnik podglądu renderuje przeskalowany zakres przy użyciu [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Ogranicza [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) do tego zakresu, usuwa marginesy, nagłówki i stopki oraz zwraca strumień PNG ustawiony na jego początek.

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

{{% alert color="info" title="Note" %}}

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru arkusza. Wybierz podejście, które najlepiej odpowiada Twoim wymaganiom i przypadkowi użycia. Oba podejścia działają w ten sam sposób, niezależnie od tego, czy prezentacje są tworzone na podstawie szablonu, czy od zera. Dodatkowo w tym rozwiązaniu nie ma limitu rozmiaru ramki obiektu OLE.

{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować oryginalny rozmiar okna po aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może powodować zmianę rozmiaru.

**Czy możliwe jest całkowite zapobieżenie temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE tak, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do pożądanego rozmiaru ramki OLE, można zapobiec niepożądanej zmianie rozmiaru.

**Którą metodę skalowania powinienem użyć, skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli chcesz mieć stały rozmiar ramki OLE w swojej prezentacji.

**Czy te rozwiązania będą działać, jeśli moja prezentacja opiera się na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych na podstawie szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy użyciu tych metod?**

Nie. Możesz ustawić ramkę obiektu OLE na dowolny rozmiar, pod warunkiem właściwego ustawienia skali.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**

Tak. Pobierając migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, można wyświetlić własny obraz podglądu zamiast domyślnego zastępnika.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatyczna aktualizacja obiektów OLE przy użyciu dodatku MS PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)