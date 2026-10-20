---
title: Создание диаграмм Excel и их внедрение в презентации как OLE‑объекты
type: docs
weight: 30
url: /ru/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Диаграмма Excel
- внедрение диаграммы
- OLE‑объект
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создайте диаграмму Excel с помощью Aspose.Cells для Node.js через Java и внедрите рабочую книгу в презентацию PowerPoint с Aspose.Slides, включая предварительный просмотр диаграммы."
---
## **Обзор**

Эта статья показывает, как создать столбчатую диаграмму Excel с помощью Aspose.Cells для Node.js через Java и внедрить её рабочую книгу в презентацию PowerPoint с помощью Aspose.Slides для Node.js через Java. Встроенная рабочая книга содержит как исходные данные, так и диаграмму. Отдельное PNG‑предпросмотр отображает диаграмму на слайде до активации OLE‑объекта.

В результате получается встроенный объект Excel, а не нативная диаграмма PowerPoint. Редактирование рабочей книги через OLE требует настольного приложения, поддерживающего активацию OLE, и совместимой установки Excel.

## **Требования**

Установите пакеты Node.js `aspose.cells`, `aspose.slides.via.java` и `java`. Запускайте примеры как два скрипта CommonJS в отдельных процессах Node.js: сначала `create-chart.js`, затем `embed-chart.js`, используя один и тот же рабочий каталог. Оба пакета Aspose инициализируют Java‑мост при загрузке, поэтому эти примеры держат их в отдельных процессах. Для создания презентации с помощью этих библиотек Microsoft Office не требуется.

Не требуется существующая рабочая книга или изображение. Первый скрипт создает `ChartWorkbook.xlsx` и `ChartPreview.png`; второй считывает эти файлы и записывает `OutputChart.pptx` в текущий рабочий каталог. Применяйте лицензии для обоих продуктов при запуске вне режима оценки.

## **Как работает внедрение**

1. Создайте рабочую книгу с листом данных и листом диаграммы.  
2. Сделайте лист диаграммы активным, чтобы рабочая книга открывалась на диаграмме.  
3. Установите диапазон отображения OLE рабочей книги и отрендерите диаграмму в PNG.  
4. Сохраните рабочую книгу в формате XLSX и внедрите её байты в слайд в отдельном процессе Node.js.  
5. Назначьте PNG в качестве предварительного просмотра OLE‑объекта и сохраните презентацию в формате PPTX.  

Диапазон отображения рабочей книги и рамка на слайде имеют разные роли. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) принимает нулевые индексы начала/конца строки и столбца. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) вместо этого принимает верхнюю строку, левый столбец, нижнюю строку и правый столбец. В примере используются индекс строки 55 и индекс столбца 25 как границы нижнего правого угла; эти значения являются выборами разметки, а не количеством строк или столбцов данных.

Рамка слайда использует пункты. Пример вписывает её в слайд и центрирует, сохраняя соотношение сторон PNG, а не растягивая предварительный просмотр, чтобы заполнить слайд.

## **Создание и внедрение диаграммы**

Сохраните первый пример как `create-chart.js`. Он заполняет `DataSheet` четырьмя строками и пятью столбцами значений. Каждая строка становится серией диаграммы. `ChartSheet` выбирается как активный лист перед сохранением рабочей книги.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Отрендерить предварительный просмотр диаграммы и отдельно сериализовать редактируемую рабочую книгу.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Вся синхронная работа завершена; остановите процесс Java‑моста.
process.exit(0);
```

Сохраните следующий пример как `embed-chart.js`. Запустите его после того, как `create-chart.js` создал оба входных файла. Он центрирует OLE‑рамку и сохраняет соотношение сторон изображения предварительного просмотра.

Второй скрипт внедряет сохранённую рабочую книгу и использует PNG в качестве её предварительного просмотра. Рабочая книга явно сохраняется как XLSX, соответствуя расширению `xlsx`, передаваемому в [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG загружается напрямую из её байтов без промежуточного преобразования в bitmap. Java‑мост требует явных массивов байтов Java для изображения и данных рабочей книги, а также значений float Java для координат рамки слайда. Присвоение через [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) заменяет стандартный заполнитель OLE.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Поместить предварительный просмотр в слайд, не изменяя его соотношение сторон.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Вся синхронная работа завершена; остановите процесс Java‑моста.
process.exit(0);
```

## **Ожидаемый результат**

`OutputChart.pptx` содержит один слайд с встроенной рабочей книгой Excel и предварительным просмотром диаграммы. Рабочая книга содержит исходные данные и столбчатую диаграмму с четырьмя сериями. Предпросмотр центрирован на слайде и сохраняет свои пропорции.

![Столбчатая диаграмма Excel, отображаемая как предварительный просмотр встроенной рабочей книги](excel-chart-ole-preview.png)

В совместимой настольной среде PowerPoint с установленным Excel дважды щелкните объект, чтобы активировать и отредактировать встроенную рабочую книгу. Активация и редактирование зависят от поддержки OLE в приложении‑хосте и настроек безопасности.

## **FAQ**

**Зачем нужен изображение предварительного просмотра?**

Встроенная рабочая книга и её предварительный просмотр на слайде являются отдельным содержимым. Предоставьте изображение диаграммы, чтобы слайд показывал диаграмму вместо стандартного заполнителя "EMBEDDED OLE OBJECT". См. [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Обновляется ли предварительный просмотр автоматически при изменении рабочей книги в коде?**

Считайте предварительный просмотр снимком. При программном обновлении данных рабочей книги повторно генерируйте изображение диаграммы и заменяйте как предварительный просмотр, так и данные встроенной рабочей книги.

**Могу ли я использовать XLS вместо XLSX?**

Да. Сохраните рабочую книгу в формате XLS и используйте `xls` в качестве расширения встроенных данных. Расширение должно соответствовать фактическому формату рабочей книги; изменение лишь расширения не преобразует данные.

**Почему объект может менять размер после активации?**

Приложение‑хост может обновлять отображение OLE‑объекта при активации рабочей книги. И диапазон отображения OLE рабочей книги, и размеры рамки слайда имеют значение. См. [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/).

## **Связанные разделы**

- [Рабочее решение для изменения размера диаграммы в PPTX](/slides/ru/java/working-solution-for-chart-resizing-in-pptx/)
- [Проблема предварительного просмотра объекта при добавлении OleObjectFrame](/slides/ru/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)