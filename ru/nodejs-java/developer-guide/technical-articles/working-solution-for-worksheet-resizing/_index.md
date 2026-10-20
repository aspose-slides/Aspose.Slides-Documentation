---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 20
url: /ru/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа сохранить согласованность кадров объектов — масштабировать кадр или лист — в форматах PPT и PPTX."
---
{{% alert color="info" title="Note" %}}
Листы Excel, внедренные в презентацию PowerPoint в виде OLE‑объектов с использованием компонентов Aspose, могут неожиданно изменить размер после первой активации. Такое поведение создает заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье объясняется проблема и описываются два способа её решения.
{{% /alert %}}

## **Предыстория**

В статье [Управление OLE](/slides/ru/nodejs-java/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides для Node.js через Java. Чтобы решить [проблему предварительного просмотра объекта](/slides/ru/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑кадру. В полученной презентации, когда вы дважды щёлкните OLE‑кадр, отображающий изображение листа, активируется книга Excel. Пользователи могут внести любые необходимые изменения в реальную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги Excel. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и внедрённой книги Excel.

## **Причина изменения размера**

Поскольку у книги Excel есть собственный размер окна, она пытается сохранить первоначальный размер при первой активации. С другой стороны, OLE‑кадр имеет собственный размер. По данным Microsoft, когда книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить правильные пропорции в процессе внедрения. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.
- Сохранить постоянный размер OLE‑кадра и масштабировать выбранные строки и столбцы, чтобы они помещались в него.

### **Масштабировать размер OLE‑кадра**

Этот подход устанавливает размер OLE‑кадра, соответствующий общей высоте и ширине выбранных строк и столбцов в внедрённом листе Excel.

В примере загружается существующая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием индексов, начинающихся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) определяет отображаемый диапазон. Предпросмотр отображается с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты с учётом 72 пункта на дюйм. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) внедряет изменённую книгу в кадр с этими размерами. Предпросмотр назначается через [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) для замены заполняющего текста "EMBEDDED OLE OBJECT" в сохранённой презентации.

Установите пакеты `aspose.cells`, `aspose.slides.via.java` и `java` и поместите `sample.xlsx` в рабочий каталог. Для каждого подхода сначала запустите скрипт подготовки, а затем скрипт внедрения в отдельном процессе Node.js в том же каталоге. Два пакета Aspose инициализируют мост Java отдельно.

Сохраните этот скрипт подготовки как `prepare-frame-scaled.js` и запустите его командой `node prepare-frame-scaled.js`. Он создаст файлы `frame-scaled.xlsx` и `frame-scaled.png`.

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

// Вся синхронная работа завершена; остановите процесс Java‑моста.
process.exit(0);
```

Сохраните этот скрипт внедрения как `embed-frame-scaled.js` и запустите его командой `node embed-frame-scaled.js`. Он прочитает эти файлы и создаст `frame-scaled.pptx`.

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

// Вся синхронная работа завершена; остановите процесс Java-моста.
process.exit(0);
```

Помощник предварительного просмотра задаёт [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) для выбранного диапазона и удаляет поля, верхние и нижние колонтитулы. При включённом [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) рендерит диапазон в виде PNG‑изображения. Помощник сохраняет PNG‑изображение в файл для использования в презентации.

### **Масштабировать размер диапазона ячеек**

Этот подход масштабирует высоты выбранных строк и ширины выбранных столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

В примере загружается существующая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием индексов, начинающихся с нуля. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) определяет отображаемый диапазон, а вспомогательная функция масштабирует этот диапазон под кадр шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой книги в файл, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) внедряет её с указанным размером. Предпросмотр, отрисованный с разрешением 96 DPI, назначается через [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

Сохраните этот скрипт подготовки как `prepare-cells-scaled.js` и запустите его командой `node prepare-cells-scaled.js`. Он создаст файлы `cells-scaled.xlsx` и `cells-scaled.png`.

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

// Вся синхронная работа завершена; остановите процесс Java-моста.
process.exit(cellsPrepared ? 0 : 1);
```

Сохраните этот скрипт внедрения как `embed-cells-scaled.js` и запустите его командой `node embed-cells-scaled.js`. Он прочитает эти файлы и создаст `cells-scaled.pptx`.

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

// Вся синхронная работа завершена; остановите процесс Java-моста.
process.exit(0);
```

Вспомогательная функция масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины его столбцов и относительные высоты его строк. Она преобразует вычисленные размеры из пунктов в дюймы перед применением их с помощью [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) и [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Выбранный диапазон должен иметь ненулевую ширину и высоту.

Этот помощник предварительного просмотра рендерит изменённый диапазон с использованием [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Он ограничивает [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) этим диапазоном, удаляет поля, верхние и нижние колонтитулы и сохраняет PNG‑изображение в файл.

## **Заключение**
{{% alert color="info" title="Note" %}}
Существует два подхода к исправлению проблемы изменения размера листа. Выберите подход, который лучше всего соответствует вашим требованиям и случаю использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения на размер OLE‑кадра.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, можно предотвратить нежелательное изменение размера.

**Какой метод масштабирования следует использовать: масштабирование OLE‑кадра или масштабирование диапазона ячеек?**

Выберите **масштабирование OLE‑кадра**, если требуется сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и с нуля.

**Есть ли ограничение размера OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑кадра, при условии правильной настройки масштаба.

**Можно ли избавиться от текста‑заполнителя "EMBEDDED OLE OBJECT" в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, можно отобразить пользовательское изображение предварительного просмотра вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и внедрение её в презентацию в виде OLE‑объекта](/slides/ru/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)