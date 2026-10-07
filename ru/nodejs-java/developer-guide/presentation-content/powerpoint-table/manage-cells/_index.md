---
title: Управление ячейками таблиц в презентациях с помощью JavaScript
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/nodejs-java/manage-cells/
keywords:
- ячейка таблицы
- объединить ячейки
- удалить границу
- разделить ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в JavaScript: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц и изменять их в презентациях PowerPoint. Эта статья объясняет, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разбиения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. В примерах показывается, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячейки через свойства ячейки и сохранить изменённую презентацию в формате PPTX.

Aspose.Slides использует нулевые индексы для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую форму на первом слайде как таблицу. Предполагается, что слайд и форма существуют и что форма является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/) и начальные координаты области, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) и [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Удалить границы ячеек таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), делая их невидимыми.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Объединить ячейки таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) для объединения прямоугольного диапазона ячеек в одну. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент управляет тем, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4×4 со столбцами и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, при этом базовая сетка таблицы сохраняет четыре столбца и четыре строки. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем угле: `table.get_Item(1, 1)` в этом примере. Остальные позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек вне диапазона не меняются.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4×4 со столбцами и строками по 70 пунктов и вызывается [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) для ячейки `(1, 1)`. Поскольку передаётся половина ширины ячейки 70 пунктов, создаются две ячейки одинаковой ширины.

После разделения две половины доступны как `table.get_Item(1, 1)` и `table.get_Item(2, 1)`. Сетка таблицы теперь содержит пять столбцов: ячейки, первоначально находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменения. Используйте эти обновлённые индексы столбцов при доступе к ячейкам после разделения.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) для разбиения по существующей строковой границе или [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) для разбиения по столбцовой границе.

Аргумент `index` считает строки в верхней части или столбцы в левой части разбиения; он относителен объединённой области:

- Разбиение по строке: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Разбиение по столбцу: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Пример предполагает, что презентация содержит таблицу в первой форме первого слайда, при этом ячейки `(1, 2)` и `(1, 3)` объединены по вертикали. Начиная с нижней позиции, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) и [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) для поиска начала и проверяет оба охвата. `splitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `splitByColSpan(1)`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Получить результирующие ячейки из таблицы после разделения.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; в данном случае обе имеют охваты 1 и [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) выводит `false`. Более крупные области могут оставаться частично объединёнными после одного разбиения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и отступы. Заполняйте ячейки после разбиения и явно задавайте требуемое форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблонных ячеек. См. [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) для подробностей.

## **Изменить цвет фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами по 150 пунктов и строками по 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) для выбора сплошной заливки и задаёт цвет, возвращаемый [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/), как красный для ячейки `(2, 3)`, то есть третьего столбца и четвёртой строки.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить изображение внутрь ячейки таблицы**

Поместите исходное изображение в рабочий каталог перед запуском этого примера. Он загружает изображение с помощью [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) и добавляет его в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Затем изображение назначается заполнению картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить её соотношение сторон. Ширины столбцов и высоты строк указаны в пунктах. Загруженное изображение освобождается в блоке `finally` после того, как оно добавлено в презентацию.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Могу ли я задать разную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). При растяжении изображение адаптируется к новой ячейке; при замостке плитки пересчитываются.

**Могу ли я назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/nodejs-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/формы. На практике ссылка назначается части текста или всему тексту в ячейке.

**Могу ли я задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (фрагменты) с независимым форматированием — семейство шрифта, стиль, размер и цвет.