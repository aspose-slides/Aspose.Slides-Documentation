---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 20
url: /ru/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Исправьте изменение размера OLE‑листов Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — для форматов PPT и PPTX."
---
{{% alert color="info" title="Note" %}}

Встраивание листов Excel в виде OLE‑объектов в презентацию PowerPoint с использованием компонентов Aspose может привести к неожиданному изменению размера после первой активации. Такое поведение создает заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье объясняется проблема и описываются два способа её решения.

{{% /alert %}}

## **Предыстория**

В статье [Manage OLE](/slides/ru/java/manage-ole/) мы объяснили, как добавить OLE‑рамку в презентацию PowerPoint с использованием Aspose.Slides for Java. Чтобы решить проблему [object preview issue](/slides/ru/java/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑рамке. В полученной презентации, когда вы дважды щёлкаете по OLE‑рамке, отображающей изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной рабочей книги. Размер OLE‑рамки изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑рамки и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel собственный размер окна, она пытается сохранить свой исходный размер при первой активации. С другой стороны, OLE‑рамка имеет свой размер. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы сохранить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и позицией OLE‑рамки.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Изменить масштаб OLE‑рамки в презентации PowerPoint, чтобы она соответствовала общей высоте и ширине выбранных строк и столбцов.
- Сохранить постоянный размер OLE‑рамки и масштабировать выбранные строки и столбцы под её размеры.

### **Масштабировать размер OLE‑рамки**

Этот подход задаёт размер OLE‑рамки, соответствующий общей высоте и ширине выбранных строк и столбцов во встраиваемом листе Excel.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевого индекса. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) определяет отображаемый диапазон. Предпросмотр рендерится с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты с использованием 72 пункта на дюйм. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) встраивает изменённую рабочую книгу в рамку с этими размерами. Предпросмотр назначается через [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) для замены заполнителя «EMBEDDED OLE OBJECT» в сохранённой презентации.

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

// Установить отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Получить ширину и высоту OLE‑изображения в пунктах.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Нам нужно использовать изменённую рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить OLE‑изображение в ресурсы презентации.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создать рамку OLE‑объекта.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Помощник предпросмотра устанавливает [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) в выбранный диапазон и удаляет поля, верхние и нижние колонтитулы. При включённом [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) рендерит диапазон в PNG‑изображение. Помощник возвращает новый поток ввода, содержащий PNG‑изображение, позиционированный в начале для использования в презентации.

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

Этот подход масштабирует высоту выбранных строк и ширину выбранных столбцов, чтобы они соответствовали пользовательскому размеру OLE‑рамки.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевого индекса. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) определяет отображаемый диапазон, а приведённый ниже помощник масштабирует этот диапазон, чтобы он поместился в рамку шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой рабочей книги в поток, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) встраивает её с указанными размерами. Предпросмотр, отрендеренный при 96 DPI, назначается через [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), поэтому сохранённая презентация показывает выбранные ячейки вместо заполнителя по умолчанию.

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

// Установить отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру рамки.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Нам нужно использовать изменённую рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить OLE‑изображение в ресурсы презентации.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создать рамку OLE‑объекта.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

Помощник масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняет относительные ширины его столбцов и относительные высоты его строк. Он преобразует вычисленные размеры из пунктов в дюймы перед применением их с помощью [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) и [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Выбранный диапазон должен иметь ненулевую ширину и высоту.

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

Этот помощник предпросмотра рендерит изменённый диапазон с использованием [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Он ограничивает [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) этим диапазоном, удаляет поля, верхние и нижние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

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

Существует два подхода к устранению проблемы изменения размеров листа. Выберите тот, который лучше всего соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений по размеру OLE‑рамки.

{{% /alert %}}

## **Вопросы и ответы**

**Почему встраиваемый лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑рамка в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑рамку под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑рамки, можно полностью избежать нежелательного изменения размера.

**Какой метод масштабирования следует использовать: масштабирование OLE‑рамки или масштабирование диапазона ячеек?**

Выбирайте **масштабирование OLE‑рамки**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выбирайте **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑рамки в презентации.

**Работают ли эти решения, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**Есть ли ограничение по размеру OLE‑рамки при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑объекта, если правильно зададите масштаб.

**Можно ли избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона Excel и задав его в качестве изображения‑заполнителя OLE‑рамки, вы можете отобразить собственное изображение‑предпросмотр вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и внедрение её в презентацию в виде OLE‑объекта](/slides/ru/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)