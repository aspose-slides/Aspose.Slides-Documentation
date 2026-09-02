---
title: Управление таблицами презентации в JavaScript
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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью JavaScript и Aspose.Slides для Node.js. Откройте простые примеры кода, упрощающие работу с таблицами."
---
## **Введение**

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) представлена просто и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table), класс [Cell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами во всех типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Пройдитесь по каждой [Cell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/) и задайте форматирование верхних, нижних, правых и левых границ.
7. Объедините четыре ячейки в левом верхнем углу таблицы (первые два столбца первых двух строк) в одну ячейку. 
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) ячейки [Cell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/).
9. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).
10. Сохраните изменённую презентацию.

Этот JavaScript‑код демонстрирует, как создать таблицу в презентации:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает доступ к первому слайду
    var sld = pres.getSlides().get_Item(0);
    // Определяет столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Добавляет форму таблицы на слайд
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Устанавливает формат рамки для каждой ячейки
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Объединяет блок ячеек 2x2 в левом верхнем углу в одну ячейку
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Добавляет текст в объединённую ячейку
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Сохраняет презентацию на диск
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице имеет индексы 0,0 (столбец 0, строка 0). 

Например, ячейки в таблице из 4 столбцов и 4 строк нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот JavaScript‑код показывает, как задать нумерацию ячеек в таблице:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает доступ к первому слайду
    var sld = pres.getSlides().get_Item(0);
    // Определяет столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Добавляет форму таблицы на слайд
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Устанавливает формат границы для каждой ячейки
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Сохраняет презентацию на диск
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).

2. Получите ссылку на слайд, содержащий таблицу, по его индексу. 

3. Создайте объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table) и присвойте ему значение `null`.

4. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) до тех пор, пока не найдёте таблицу.

   Если вы подозреваете, что обрабатываемый слайд содержит одну единственную таблицу, просто проверьте все его фигуры. Когда фигура определяется как таблица, её можно привести к типу [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table). Если же на слайде несколько таблиц, лучше искать нужную таблицу по её [setAlternativeText(String value)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Используйте объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table) для работы с таблицей. В примере ниже мы задаём текст ячейки таблицы.

6. Сохраните изменённую презентацию.

Этот JavaScript‑код демонстрирует, как получить доступ к существующей таблице и работать с ней:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Получает доступ к первому слайду
    var sld = pres.getSlides().get_Item(0);
    // Инициализирует TableEx как null
    var tbl = null;
    // Проходит по всем фигурам и сохраняет ссылку на найденную таблицу
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Устанавливает текст для первого столбца второй строки
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Сохраняет изменённую презентацию на диск
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Поиск ячейки, владеющей текстовым фреймом**

Когда общий код обработки текста получает объект [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentCell--) для получения владеющей [Cell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/). Для текстового фрейма ячейки таблицы [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentCell--) возвращает владельца, а [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentShape--) возвращает `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) и [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getParentCell--) также обеспечивает только чтение: он возвращает владельца, но не меняет владения. Всегда проверяйте возвращаемую ячейку на `null` перед использованием.

Полный пример, определяющий владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. в разделе [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) из таблицы.
5. Получите [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/).
6. Выведите текст вертикально.
7. Сохраните изменённую презентацию.

Этот JavaScript‑код показывает, как выровнять текст в таблице:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создаёт экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Определяет столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Добавляет форму таблицы на слайд
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Получает доступ к текстовому фрейму
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Создаёт объект Paragraph для текстового фрейма
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Создаёт объект Portion для абзаца
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Выравнивает текст вертикально
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Сохраняет презентацию на диск
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Получите объект [Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Table) со слайда.
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните изменённую презентацию. 

Этот JavaScript‑код демонстрирует, как применить предпочтительные параметры форматирования к тексту в таблице:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Создаёт экземпляр класса Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Предположим, что первая фигура на первом слайде — таблица
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Устанавливает высоту шрифта ячеек таблицы
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Устанавливает вертикальный тип текста ячеек таблицы
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Установка предустановки стиля таблицы**

Aspose.Slides поставляется со встроенными стилями таблиц PowerPoint в виде перечисления [TableStylePreset](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tablestylepreset/), так что вы можете применить одинаковый вид к любой таблице. Этот JavaScript‑код показывает, как заменить стиль таблицы по умолчанию на предустановленный стиль:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// изменить тему предустановленного стиля по умолчанию
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это отношение её размеров по различным измерениям. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) для блокировки настройки соотношения сторон у таблиц и других фигур.

Этот JavaScript‑код демонстрирует, как заблокировать соотношение сторон для таблицы:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/setrighttoleft/), а абзацы имеют [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Использование обоих гарантирует правильный порядок RTL и корректный рендеринг внутри ячеек.

**Как я могу запретить пользователям перемещать или изменять размер таблицы в финальном файле?**

Используйте блокировки фигур, чтобы отключить перемещение, изменение размера, выделение и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фоновой заливки?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в соответствии с выбранным режимом (растягивание или мозаика).