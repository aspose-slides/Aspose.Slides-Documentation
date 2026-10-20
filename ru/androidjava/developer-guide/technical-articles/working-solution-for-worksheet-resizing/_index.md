---
title: "Рабочее решение для изменения размера листа"
type: docs
weight: 20
url: /ru/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- рабочий лист
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа сохранить согласованность кадров объектов — масштабировать кадр или лист — в форматах PPT и PPTX."
---
{{% alert color="info" title="Note" %}}

Листы Excel, встроенные в презентацию PowerPoint в виде OLE‑объектов с использованием компонентов Aspose, могут неожиданно менять размер после первой активации. Такое поведение создает заметную визуальную разницу объекта OLE до и после активации. В этой статье объясняется проблема и описываются два способа её решения.

{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/androidjava/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Android via Java. Чтобы решить [проблему предварительного просмотра объекта](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑кадру. В готовой презентации, когда вы дважды щелкаете OLE‑кадр, отображающий изображение листа, активируется книга Excel. Пользователи могут вносить любые изменения в реальную книгу Excel, а затем возвращаться к слайду, щелкнув вне активированной книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной книги Excel.

## **Причина изменения размера**

Поскольку у книги Excel своё собственное окно, она пытается сохранить исходный размер при первой активации. С другой стороны, OLE‑кадр имеет свои собственные размеры. По данным Microsoft, когда книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы сохранить правильные пропорции в рамках процесса внедрения. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.
- Оставить размер OLE‑кадра постоянным и масштабировать выбранные строки и столбцы так, чтобы они помещались в него.

### **Масштабировать размер OLE‑кадра**

Этот подход устанавливает размер OLE‑кадра так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов во встроенном листе Excel.

Пример загружает существующую книгу Excel и выбирает первые 10 строк и 13 столбцов первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) определяет отображаемый диапазон. Предпросмотр рендерится с разрешением 96 DPI, а его пиксельные размеры конвертируются в пункты при помощи 72 пункта на дюйм. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) внедряет изменённую книгу в кадр с этими размерами. Предпросмотр назначается через [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) для замены заполнителя «EMBEDDED OLE OBJECT» в сохранённой презентации.

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

// Установите отображаемый размер, когда файл книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Получите ширину и высоту OLE‑изображения в пунктах.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Нам необходимо использовать изменённую книгу.
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

Помощник предварительного просмотра устанавливает [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) на выбранный диапазон и удаляет поля, колонтитулы и нижние колонтитулы. При включённом [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) рендерит диапазон как PNG‑изображение. Помощник возвращает новый поток ввода, содержащий PNG‑изображение, позиционированный в начале для использования в презентации.

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

### **Масштабировать диапазон ячеек**

Этот подход масштабирует высоты выбранных строк и ширины выбранных столбцов так, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Пример загружает существующую книгу Excel и выбирает первые 10 строк и 13 столбцов первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) определяет отображаемый диапазон, а приведённый ниже помощник масштабирует этот диапазон до кадра шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой книги в поток, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) внедряет её с указанным размером. Предпросмотр, отрисованный с 96 DPI, назначается через [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

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

// Установите отображаемый размер, когда файл книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Нужно использовать изменённую книгу.
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

Помощник масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины его столбцов и относительные высоты его строк. Он преобразует вычисленные размеры из пунктов в дюймы перед применением их с помощью [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) и [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Выбранный диапазон должен иметь ненулевую ширину и высоту.

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

Этот помощник предварительного просмотра рендерит изменённый диапазон с помощью [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Он ограничивает [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) этим диапазоном, удаляет поля, колонтитулы и нижние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

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

{{% alert color="info" title="Note" %}}

Существует два подхода к исправлению проблемы изменения размера листа. Выберите тот, который лучше соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений по размеру OLE‑кадра.

{{% /alert %}}

## **Вопросы и ответы**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, можно избежать нежелательного изменения размера.

**Какой метод масштабирования следует использовать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?**

Выберите **масштабирование OLE‑кадра**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**Есть ли ограничение на размер OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑кадра, при условии правильной настройки масштаба.

**Можно ли избежать текста заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения заполнителя OLE‑кадра, можно отобразить пользовательское изображение превью вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и встраивание её в презентацию в виде OLE‑объекта](/slides/ru/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)