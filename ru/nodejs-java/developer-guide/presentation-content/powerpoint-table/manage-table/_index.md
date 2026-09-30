---
title: Управление таблицами презентаций на JavaScript
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/nodejs-java/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью JavaScript и Aspose.Slides для Node.js. Узнайте простые примеры кода для оптимизации работы с таблицами."
---
## **Введение**

Таблицы в PowerPoint организуют информацию в строки и столбцы, упрощая чтение и сравнение значений.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), класс [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создание таблицы с нуля**

Создайте таблицу, указав её позицию, ширину столбцов и высоту строк. После добавления её на слайд можно форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите массив ширин столбцов в пунктах.
4. Определите массив высот строк в пунктах.
5. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Пройдите по каждому [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/), чтобы применить форматирование верхних, нижних, правых и левых границ.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её метод [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--).
9. Установите текст в объединённую ячейку.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя столбцами и пятью строками в точке (100, 50). Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки первой строки и сохраняет результат как `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Нумерация в стандартной таблице**

В стандартной таблице индексы ячеек начинаются с нуля и задаются в порядке (столбец, строка). Первая ячейка имеет индекс (0, 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт таблицу 4 × 4, изображённую выше, со столбцами и строками шириной 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты иллюстрируют индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Пройдите по фигурам, чтобы найти таблицу, затем используйте класс [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) для чтения или обновления её ячеек.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройдите по объектам [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) и остановитесь, когда найдёте таблицу. Если на слайде несколько таблиц, используйте [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) для идентификации нужной.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он задаёт значение `New` ячейке в столбце 0, строка 1 и сохраняет результат как `table1_out.pptx`. Входной файл должен содержать как минимум один слайд, а первая таблица на этом слайде должна иметь минимум один столбец и две строки.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Для изменения высоты строки в существующей таблице и понимания, почему её фактическая высота может превышать запрошенный минимум, см. [Control Row Height](/slides/ru/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Поиск ячейки, владеющей текстовым фреймом**

Когда общий код обработки текста получает объект [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) для получения владельца‑[Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). Для текстового фрейма ячейки таблицы [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) возвращает владельца, а [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) возвращает `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) и [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) также предоставляет только навигацию: он возвращает владельца, но не меняет владение. Всегда проверяйте возвращаемую ячейку на `null` перед её использованием.

Для полного примера, определяющего владельцев ячейки таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

Можно управлять вертикальной привязкой и направлением текста в отдельных ячейках таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) из таблицы.
5. Получите первый [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) и задайте ему текст и цвет.
6. Установите вертикальную привязку ячейки и направление текста с помощью [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) и [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 со столбцами шириной 120 пунктов и строками высотой 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в остальные ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка форматирования текста на уровне таблицы**

Используйте [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) для применения форматирования текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому можно задавать эти свойства без перебора отдельных ячеек.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) со слайда.
4. Установите размер шрифта с помощью [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Задайте выравнивание абзаца и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Установите направление текста с помощью [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните изменённую презентацию.

Пример ниже открывает `table.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Отформатированная презентация сохраняется как `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получение свойств стиля таблицы**

Используйте [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) для чтения предустановленного стиля таблицы и [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) для его назначения. Этот пример применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) к одной таблице, выводит значение предустановки и назначает тот же стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) для блокировки этого соотношения.

Пример ниже открывает `pres.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включает блокировку соотношения сторон, выводит обновлённое состояние (`true`) и сохраняет результат как `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Использование обоих обеспечивает правильный RTL‑порядок и отображение внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в итоговом файле?**

Используйте [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) для отключения перемещения, изменения размера, выбора и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в выбранном режиме (растягивание или замостка).