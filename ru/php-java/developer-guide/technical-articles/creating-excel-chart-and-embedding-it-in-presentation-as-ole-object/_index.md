---
title: Создание диаграмм Excel и внедрение их в презентации как OLE‑объекты
type: docs
weight: 30
url: /ru/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- диаграмма Excel
- встраивание диаграммы
- OLE‑объект
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells for PHP via Java и внедрите рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides for PHP via Java, включая предварительный просмотр диаграммы."
---
## **Обзор**

В этой статье показано, как создать столбчатую диаграмму Excel с помощью Aspose.Cells for PHP via Java и встроить её рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides for PHP via Java. Встроенная рабочая книга содержит как исходные данные, так и диаграмму. Отдельное PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

Результатом является встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование рабочей книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Настройте Aspose.Cells for PHP via Java и Aspose.Slides for PHP via Java с использованием одного экземпляра PHP/Java Bridge. Загрузите оба PHP‑обёртки и сделайте Java‑библиотеки обоих продуктов доступными мосту. Для создания презентации с помощью этих библиотек Microsoft Office не требуется.

Входные файлы не требуются: пример создает данные и диаграмму в памяти, затем записывает `OutputChart.pptx` в текущий рабочий каталог. Применяйте лицензии для обоих продуктов при работе вне режима оценки.

## **Как работает внедрение**

1. Создайте рабочую книгу с листом данных и листом диаграммы.
2. Сделайте лист диаграммы активным, чтобы рабочая книга открывалась непосредственно на диаграмме.
3. Установите диапазон отображения OLE для рабочей книги и отрендерите диаграмму в PNG.
4. Сохраните рабочую книгу в формате XLSX в памяти и внедрите эти байты в слайд.
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию в формате PPTX.

Диапазон отображения рабочей книги и рамка на слайде имеют разные назначения. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) принимает нулевой базовый начальный и конечный индексы строк и столбцов. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) вместо этого принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере в качестве правой нижней границы используются индекс строки 55 и индекс столбца 25; эти значения являются вариантами верстки, а не количеством строк или столбцов данных.

Рамка слайда использует единицы измерения points. Пример помещает её в пределах слайда и центрирует, сохраняя пропорции PNG, вместо растягивания предварительного просмотра на весь слайд.

## **Создание и встраивание диаграммы**

Следующий полный пример заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбран в качестве активного листа перед сохранением рабочей книги.

Рабочая книга явно сохраняется в формате XLSX, соответствуя расширению `xlsx`, переданному в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Числовые результаты Java преобразуются с помощью `java_values` до выполнения арифметики в PHP, в то время как бинарные данные остаются в массиве байтов Java. PNG загружается напрямую из своих байтов без промежуточного преобразования в bitmap. Назначение его через [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) заменяет стандартный заполнитель OLE.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Сохраните PNG и XLSX в виде массивов байтов Java при передаче их в Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Подгоните и центрируйте предварительный просмотр, сохраняя его пропорции.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд со встроенной рабочей книгой Excel и предварительным просмотром диаграммы. Рабочая книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной рабочей книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel двойной щелчок по объекту активирует и позволяет редактировать встроенную рабочую книгу. Активация и редактирование зависят от поддержки OLE и настроек безопасности в хост‑приложении.

## **FAQ**

**Зачем нужен образ предварительного просмотра?**

Встроенная рабочая книга и её предварительный просмотр на слайде — это отдельный контент. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполнителя «EMBEDDED OLE OBJECT». См. [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении рабочей книги в коде?**

Считайте предварительный просмотр снимком. При программном обновлении данных рабочей книги необходимо заново сгенерировать изображение диаграммы и заменить как предварительный просмотр, так и данные встроенной рабочей книги.

**Могу ли я использовать XLS вместо XLSX?**

Да. Сохраните рабочую книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать фактическому формату рабочей книги; изменение расширения без конвертации данных не приводит к их преобразованию.

**Почему объект может изменить размер после активации?**

Хост‑приложение может обновлять презентацию OLE‑объекта при активации рабочей книги. На размер влияют как диапазон отображения OLE рабочей книги, так и размеры рамки на слайде. См. [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/).

## **Связанные разделы**

- [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Управление OLE‑объектами](/slides/ru/php-java/manage-ole/)