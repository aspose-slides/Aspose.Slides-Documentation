---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 20
url: /ru/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — для форматов PPT и PPTX."
---

{{% alert color="primary" %}}

Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint с помощью компонентов Aspose, масштабируются до неопределённого размера после первой активации. Такое поведение создаёт заметную визуальную разницу в презентации между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предоставили решение, которое описано в этой статье.

{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/androidjava/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for Android через Java. Чтобы решить [проблема предварительного просмотра объекта](/slides/ru/androidjava/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа в OLE‑кадр. В полученной презентации, когда вы дважды щёлкаете по OLE‑кадру, отображающему изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые желаемые изменения в реальную рабочую книгу Excel, а затем возвращаться к слайду, щёлкнув вне активированной рабочей книги Excel. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, она пытается сохранить свой исходный размер при первой активации. С другой стороны, OLE‑кадр имеет свой собственный размер. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить сохранение правильных пропорций в процессе встраивания. Изменение размера происходит на основе различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Изменить масштаб размера OLE‑кадра в презентации PowerPoint, чтобы он соответствовал высоте и ширине нужного количества строк и столбцов в OLE‑кадре.
- Сохранить постоянный размер OLE‑кадра и масштабировать размер участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы научимся устанавливать размер OLE‑кадра встроенной рабочей книги Excel так, чтобы он соответствовал совокупному размеру участвующих строк и столбцов в листе Excel.

Предположим, у нас есть шаблон листа Excel, который мы хотим добавить в презентацию как OLE‑кадр. В этом случае размер OLE‑объекта сначала будет рассчитан на основе совокупных высот строк и ширин столбцов участвующих в рабочей книге. Затем мы установим размер OLE‑кадра в полученное значение. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в рабочей книге и установим его как изображение OLE‑кадра.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Установить отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Получить ширину и высоту OLE-изображения в пунктах.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Нужно использовать изменённую рабочую книгу.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Добавить OLE-изображение в ресурсы презентации.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создать кадр OLE-объекта.
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


### **Масштабировать размер диапазона ячеек**

В этом подходе мы научимся масштабировать высоты участвующих строк и ширину участвующих столбцов так, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Предположим, у нас есть шаблон листа Excel, который мы хотим добавить в презентацию как OLE‑кадр. В этом случае мы задаём размер OLE‑кадра и масштабируем размеры строк и столбцов, участвующих в области OLE‑кадра. Затем сохраняем рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑кадр. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в рабочей книге и установим его как изображение OLE‑кадра.
```java
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

// Добавить OLE‑изображение в ресурсы презентации.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Создать кадр OLE‑объекта.
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

{{% alert color="primary" %}} 

Существует два подхода к исправлению проблемы изменения размера листа. Выбор подходящего метода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений на размер OLE‑объекта.

{{% /alert %}}

## **FAQ**

**Почему встроенный лист Excel изменяет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, в то время как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить пропорции, что может вызвать изменение масштаба.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, можно предотвратить нежелательное изменение масштаба.

**Какой метод масштабирования следует использовать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?**

Выбирайте **масштабирование OLE‑кадра**, если необходимо сохранить оригинальные размеры строк и столбцов Excel. Выбирайте **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и с нуля.

**Есть ли ограничение на размер OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑объекта, если правильно установите масштаб.

**Можно ли избавиться от текста‑заменителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заменителя OLE‑кадра, можно отобразить собственное изображение‑предпросмотр вместо стандартного заменителя.