---
title: "Рабочее решение проблемы изменения размера листа"
type: docs
weight: 20
url: /ru/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Исправьте изменение размера OLE‑листов Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — в форматах PPT и PPTX."
---
{{% alert color="info" %}}

Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, после первой активации изменяют размер до неопределённого масштаба. Это создает заметную визуальную разницу в презентации между состоянием OLE‑объекта до и после активации. Мы детально исследовали эту проблему и предложили решение, которое описано в этой статье.

{{% /alert %}}

## **Предыстория**

В статье [Manage OLE](/slides/ru/androidjava/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint, используя Aspose.Slides for Android через Java. Чтобы решить проблему [object preview issue](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа Excel кадру OLE‑объекта. В полученной презентации, когда вы дважды щёлкните кадр OLE‑объекта, показывающий изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированного окна Excel. Размер кадра OLE‑объекта изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров кадра OLE‑объекта и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, кадр OLE‑объекта имеет свои размеры. Согласно Microsoft, когда активируется рабочая книга Excel, Excel и PowerPoint согласовывают размер, чтобы обеспечить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и позицией кадра OLE‑объекта.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать размер кадра OLE в презентации PowerPoint так, чтобы он соответствовал высоте и ширине нужного количества строк и столбцов в кадре OLE.  
- Оставить размер кадра OLE постоянным и масштабировать размеры участвующих строк и столбцов, чтобы они помещались в выбранный размер кадра OLE.

### **Scale the OLE Frame Size**

В этом подходе мы узнаем, как установить размер кадра OLE встроенной рабочей книги Excel так, чтобы он соответствовал совокупному размеру участвующих строк и столбцов в листе Excel. Предположим, у нас есть шаблон листа Excel, который необходимо добавить в презентацию в виде кадра OLE. В этом случае сначала будет вычислен размер кадра OLE‑объекта на основе совокупных высот строк и ширин столбцов, участвующих в рабочей книге. Затем мы зададим размер кадра OLE равным вычисленному значению. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для кадра OLE в PowerPoint, мы также снимем изображение нужных участков строк и столбцов в рабочей книге и установим его в качестве изображения кадра OLE.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Получите ширину и высоту OLE‑изображения в пунктах.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Нужно использовать изменённую рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE‑изображение в ресурсы презентации.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создайте кадр OLE‑объекта.
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

### **Scale the Cell Range Size**

В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширину участвующих столбцов, чтобы они соответствовали пользовательскому размеру кадра OLE. Предположим, у нас есть шаблон листа Excel, который необходимо добавить в презентацию в виде кадра OLE. В этом случае мы зададим размер кадра OLE и масштабируем размеры строк и столбцов, участвующих в области кадра OLE. Затем мы сохраним рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в кадр OLE. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для кадра OLE в PowerPoint, мы также снимем изображение нужных участков строк и столбцов в рабочей книге и установим его в качестве изображения кадра OLE.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Необходимо использовать изменённую рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавьте OLE‑изображение в ресурсы презентации.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создайте кадр OLE‑объекта.
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

Существует два подхода для исправления проблемы изменения размера листа. Выбор подходящего метода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении отсутствует ограничение на размер кадра OLE‑объекта.

{{% /alert %}}

## **FAQ**

### Почему встроенный лист Excel изменяет размер при первой активации в PowerPoint?

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как кадр OLE‑объекта в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что приводит к изменению размера.

### Можно ли полностью предотвратить эту проблему изменения размера?

Да. Масштабируя кадр OLE под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер кадра OLE, можно полностью избежать нежелательного изменения размера.

### Какой метод масштабирования выбрать: масштабирование кадра OLE или масштабирование диапазона ячеек?

Выберите **масштабирование кадра OLE**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если требуется фиксированный размер кадра OLE в презентации.

### Будут ли эти решения работать, если моя презентация основана на шаблоне?

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для презентаций, создаваемых с нуля.

### Есть ли ограничение на размер кадра OLE при использовании этих методов?

Нет. Вы можете задать любой размер кадра OLE, при условии правильного выбора масштаба.

### Как избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя кадра OLE, можно отобразить пользовательское превью вместо стандартного заполнителя.