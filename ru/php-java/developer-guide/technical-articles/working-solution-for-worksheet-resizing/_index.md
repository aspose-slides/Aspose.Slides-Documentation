---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 20
url: /ru/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- рабочий лист
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Устранение изменения размера OLE‑рабочего листа Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — в форматах PPT и PPTX."
---
{{% alert color="info" title="Примечание" %}}

Рабочие листы Excel, внедренные как OLE‑объекты в презентацию PowerPoint с использованием компонентов Aspose, могут неожиданно менять размер после первой активации. Такое поведение создает заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье объясняется проблема и описываются два способа её решения.

{{% /alert %}}

## **Предыстория**

В статье [Manage OLE](/slides/ru/php-java/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for PHP via Java. Чтобы решить [object preview issue](/slides/ru/php-java/object-preview-issue-when-adding-oleobjectframe/), мы присвоили OLE‑кадру изображение выбранной области листа. В результирующей презентации, когда вы дважды щелкаете OLE‑кадр, отображающий изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную книгу Excel, а затем возвращаться к слайду, щелкнув за пределами активированной книги. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и внедрённой рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel своё окно, при первой активации она пытается сохранить исходный размер. С другой стороны, у OLE‑кадра есть свои размеры. По данным Microsoft, когда активируется рабочая книга Excel, Excel и PowerPoint согласуют размер, чтобы сохранить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размерами и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать OLE‑кадр в презентации PowerPoint так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов.
- Оставить размер OLE‑кадра постоянным и масштабировать выбранные строки и столбцы, чтобы они помещались в него.

### **Масштабировать размер OLE‑кадра**

Этот подход устанавливает размер OLE‑кадра так, чтобы он соответствовал общей высоте и ширине выбранных строк и столбцов во внедрённом листе Excel.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) определяет отображаемый диапазон. Предварительный просмотр рендерится с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты с учётом 72 пунктов на дюйм. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) встраивает модифицированную книгу в кадр с этими размерами. Предпросмотр назначается через [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), заменяя заполнитель «EMBEDDED OLE OBJECT» в сохранённой презентации.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Внедрить изменённую рабочую книгу и сохранить двоичные данные в массиве байтов Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Помощник предварительного просмотра задаёт [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) на выбранный диапазон и удаляет поля, верхние и нижние колонтитулы. При включённом [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) рендерит диапазон в PNG‑изображение. Помощник возвращает новый входной поток, содержащий PNG‑изображение, позиционированный в начале для использования в презентации.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Масштабировать размер диапазона ячеек**

Этот подход масштабирует высоту выбранных строк и ширину выбранных столбцов до пользовательского размера OLE‑кадра.

Пример загружает существующую рабочую книгу Excel и выбирает первые 10 строк и 13 столбцов первого листа, используя индексы, начинающиеся с нуля. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) определяет отображаемый диапазон, а приведённый ниже помощник масштабирует этот диапазон до кадра шириной 400 пунктов и высотой 100 пунктов. После сохранения модифицированной книги в поток, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) встраивает её с указанными размерами. Предпросмотр, рендеренный с 96 DPI, назначается через [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Внедрить изменённую рабочую книгу и сохранить двоичные данные в массиве байтов Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Помощник масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняя относительные ширины его столбцов и относительные высоты его строк. Он преобразует рассчитанные размеры из пунктов в дюймы перед применением их через [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) и [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). Выбранный диапазон должен иметь ненулевые ширину и высоту.

```php
use aspose\cells\CellsUnitType;

// Ширина и высота — ожидаемые размеры диапазона ячеек в пунктах.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Этот помощник предварительного просмотра рендерит изменённый диапазон с помощью [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Он ограничивает [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) этим диапазоном, удаляет поля, верхние и нижние колонтитулы и возвращает PNG‑поток, позиционированный в начале.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Вывод**

{{% alert color="info" title="Примечание" %}}

Существует два подхода к устранению проблемы изменения размера листа. Выберите тот, который лучше подходит вашим требованиям и сценарию использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения на размер OLE‑кадра.

{{% /alert %}}

## **FAQ**

**Почему внедрённый лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Можно ли полностью предотвратить эту проблему изменения размера?**

Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, вы можете предотвратить нежелательное изменение размера.

**Какой метод масштабирования использовать: масштабирование OLE‑кадра или диапазона ячеек?**

Выберите **масштабирование OLE‑кадра**, если хотите сохранить исходные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если вам нужен фиксированный размер OLE‑кадра в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для создаваемых с нуля.

**Существует ли ограничение размера OLE‑кадра при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑кадра, при условии корректной настройки масштабирования.

**Есть ли способ избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, вы можете отобразить пользовательское изображение‑предпросмотр вместо стандартного заполнителя.

## **Похожие статьи**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ru/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)