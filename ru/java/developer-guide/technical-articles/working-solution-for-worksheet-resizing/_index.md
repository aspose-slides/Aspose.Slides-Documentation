---
title: Рабочее решение для изменения размера листов
type: docs
weight: 20
url: /ru/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- рабочий лист
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Исправление изменения размера OLE листа Excel в презентациях: два способа сохранить согласованность кадров объектов — масштабировать кадр или лист — для форматов PPT и PPTX."
---
{{% alert color="info" %}}

Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint с помощью компонентов Aspose, изменяются до неопределённого масштаба после первой активации. Это приводит к заметной визуальной разнице между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предложили решение, описанное в статье.

{{% /alert %}}

## **Контекст**

В статье [Управление OLE](/slides/ru/java/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Java. Чтобы решить проблему [предпросмотра объекта](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили OLE‑кадру изображение выбранной области листа. В полученной презентации при двойном щелчке по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную книгу Excel, а затем возвращаться к слайду, щелкнув вне активированной книги. При возврате к слайду размер OLE‑кадра изменяется. Коэффициент изменения зависит от размеров OLE‑кадра и встроенной книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel своё окно, она пытается сохранить исходный размер при первой активации. С другой стороны, у OLE‑кадра есть свои размеры. По данным Microsoft, при активации книги Excel Excel и PowerPoint согласовывают размер, чтобы сохранить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и позицией OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размеров.

- Масштабировать размер OLE‑кадра в презентации PowerPoint так, чтобы он соответствовал высоте и ширине требуемого количества строк и столбцов в OLE‑кадре.
- Оставить размер OLE‑кадра постоянным и масштабировать размеры участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы узнаем, как задать размер OLE‑кадра встроенной книги Excel, соответствующий совокупному размеру участвующих строк и столбцов листа Excel.

Допустим, у нас есть шаблонный лист Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае размер OLE‑объекта сначала рассчитывается на основе суммарных высот строк и ширин столбцов, участвующих в книге. Затем мы задаём размер OLE‑кадра этим рассчитанным значением. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» в PowerPoint, мы также сделаем снимок нужных областей строк и столбцов книги и установим его как изображение OLE‑кадра.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Установите отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Нам нужно использовать модифицированную рабочую книгу.
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

### **Масштабировать размер диапазона ячеек**

В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширины участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Допустим, у нас есть шаблонный лист Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае мы задаём размер OLE‑кадра и масштабируем размеры строк и столбцов, участвующих в области OLE‑кадра. Затем сохраняем книгу в поток, чтобы применить изменения, и конвертируем её в массив байтов для добавления в OLE‑кадр. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» в PowerPoint, мы также сделаем снимок нужных областей строк и столбцов книги и установим его как изображение OLE‑кадра.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Нам нужно использовать модифицированную рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE изображение в ресурсы презентации.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создайте OLE объектный кадр.
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
 * @param width     Ожидаемая ширина диапазона ячеек в пунктах.
 * @param height    Ожидаемая высота диапазона ячеек в пунктах.
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

## **Заключение**

{{% alert color="info" %}} 

Существует два подхода для исправления проблемы изменения размеров листа. Выбор подхода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаётся ли презентация из шаблона или с нуля. Кроме того, в этом решении нет ограничения на размер OLE‑кадра.

{{% /alert %}}

## **FAQ**

### Почему встроенный лист Excel изменяет размер при первой активации в PowerPoint?

Это происходит because Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размеров.

### Можно ли полностью предотвратить эту проблему изменения размеров?

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, можно избежать нежелательного изменения размеров.

### Какой метод масштабирования следует использовать: масштабирование OLE‑кадра или диапазона ячеек?

Выберите **масштабирование OLE‑кадра**, если хотите сохранить исходные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑кадра в презентации.

### Работают ли эти решения, если моя презентация основана на шаблоне?

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

### Есть ли ограничение по размеру OLE‑кадра при использовании этих методов?

Нет. Вы можете задать OLE‑кадру любой размер, при условии правильного выбора масштаба.

### Как избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, можно отобразить собственное изображение предпросмотра вместо стандартного заполнителя.

## **Сопутствующие статьи**

[Создание диаграммы Excel и её встраивание в презентацию как OLE‑объект](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)