---
title: Управление таблицей
type: docs
weight: 10
url: /ru/nodejs-java/manage-table/
keywords: "Таблица, создание таблицы, доступ к таблице, соотношение сторон таблицы, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Создание и управление таблицами в презентациях PowerPoint на JavaScript"
---

Таблица в PowerPoint — эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), класс [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), класс [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/), класс [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/), а также другие типы, позволяющие создавать, обновлять и управлять таблицами в любых типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Пройдитесь по каждой [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) , чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы. 
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) ячейки [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/).
9. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
10. Сохраните изменённую презентацию.

Этот код JavaScript показывает, как создать таблицу в презентации:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Определяет столбцы с шириной и строки с высотой
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Добавляет форму таблицы на слайд
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Устанавливает формат границы для каждой ячейки
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
    // Объединяет ячейки 1 и 2 первой строки
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Добавляет некоторый текст в объединённую ячейку
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

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице имеет индекс 0,0 (столбец 0, строка 0). 

Для примера ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код JavaScript показывает, как задать нумерацию ячеек в таблице:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).

2. Получите ссылку на слайд, содержащий таблицу, по его индексу. 

3. Создайте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) и установите его в null.

4. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) , пока не будет найдена таблица.

   Если вы подозреваете, что обрабатываемый слайд содержит одну таблицу, вы можете просто проверить все его фигуры. Когда фигура идентифицируется как таблица, её можно привести к типу объекта [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table). Однако если на слайде несколько таблиц, лучше искать нужную таблицу по её методу [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Используйте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), чтобы работать с таблицей. В примере ниже мы добавили новую строку в таблицу.

6. Сохраните изменённую презентацию.

Этот код JavaScript показывает, как получить доступ к существующей таблице и работать с ней:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Инициализирует null TableEx
    var tbl = null;
    // Итерирует через формы и устанавливает ссылку на найденную таблицу
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


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) из таблицы.
5. Получите [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Выравняйте текст вертикально.
7. Сохраните изменённую презентацию.

Этот код JavaScript показывает, как выровнять текст в таблице:
```javascript
// Создает экземпляр класса Presentation
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
    // Доступ к текстовому фрейму
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Создаёт объект Paragraph для текстового фрейма
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Создаёт объект Portion для абзаца
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Выравнивает текст по вертикали
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Сохраняет презентацию на диск
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Получите объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) со слайда.
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните изменённую презентацию. 

Этот код JavaScript показывает, как применить параметры форматирования к тексту в таблице:
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Предположим, что первая фигура на первом слайде — это таблица
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
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы вы могли использовать эти данные для другой таблицы или в другом месте. Этот код JavaScript показывает, как получить свойства стиля из предустановленного стиля таблицы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// изменить предустановленную тему стиля по умолчанию
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это отношение её размеров по разным измерениям. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , позволяющее блокировать настройку соотношения сторон для таблиц и других фигур.

Этот код JavaScript показывает, как блокировать соотношение сторон для таблицы:
```javascript
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

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Использование обоих обеспечивает правильный порядок RTL и отображение внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в финальном файле?**

Используйте [shape locks](/slides/ru/nodejs-java/applying-protection-to-presentation/) для отключения перемещения, изменения размера, выбора и т.д. Эти блокировки также применяются к таблицам.

**Поддерживается ли вставка изображения внутри ячейки в качестве фона?**

Да. Вы можете установить [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или мозаика).