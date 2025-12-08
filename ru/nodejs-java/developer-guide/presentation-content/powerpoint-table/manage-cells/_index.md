---
title: Управление ячейками
type: docs
weight: 30
url: /ru/nodejs-java/manage-cells/
keywords: "Таблица, объединённые ячейки, разделённые ячейки, изображение в ячейке таблицы, Java, Aspose.Slides for Node.js via Java"
description: "Ячейки таблиц в презентациях PowerPoint на JavaScript"
---

## **Определить объединённые ячейки таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите таблицу с первого слайда. 
3. Пройдите по строкам и столбцам таблицы, чтобы найти объединённые ячейки.
4. Выведите сообщение, когда найдены объединённые ячейки.

Этот JavaScript‑код показывает, как определить объединённые ячейки таблицы в презентации:
```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// предполагая, что Slide#0.Shape#0 является таблицей
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удалить границы ячеек таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Пройдите по каждой ячейке, чтобы очистить верхнюю, нижнюю, правую и левую границы.
7. Сохраните изменённую презентацию как файл PPTX.

Этот JavaScript‑код показывает, как удалить границы у ячеек таблицы:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Определяет столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Добавляет форму таблицы на слайд
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Устанавливает формат границы для каждой ячейки
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Сохраняет PPTX на диск
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Нумерация в объединённых ячейках**
Если мы объединим 2 пары ячеек (1, 1) × (2, 1) и (1, 2) × (2, 2), получившаяся таблица будет пронумерована. Этот JavaScript‑код демонстрирует процесс:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Задает столбцы с ширинами и строки с высотами
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
    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Затем мы продолжаем объединять ячейки, объединив (1, 1) и (1, 2). В результате получится таблица с большой объединённой ячейкой в центре: 
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
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
    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Объединяет ячейки (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Записывает файл PPTX на диск
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Нумерация в разделённой ячейке**
В предыдущих примерах, когда ячейки таблицы объединялись, нумерация или система счёта в других ячейках не менялась. 

На этот раз мы берём обычную таблицу (таблица без объединённых ячеек) и пытаемся разделить ячейку (1, 1), получая особую таблицу. Обратите внимание на нумерацию этой таблицы — она может показаться странной. Однако именно так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides делает то же самое. 

Этот JavaScript‑код демонстрирует описанный процесс:
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
    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Разделяет ячейку (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Записывает файл PPTX на диск
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить цвет фона ячейки таблицы**

Этот JavaScript‑код показывает, как изменить цвет фона ячейки таблицы:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // создаём новую таблицу
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // задаёт цвет фона для ячейки
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Добавить изображение внутрь ячейки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Создайте объект `Images` для хранения файла изображения.
7. Добавьте изображение `IImage` в объект `PPImage`.
8. Установите `FillFormat` для ячейки таблицы в значение `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните изменённую презентацию как файл PPTX.

Этот JavaScript‑код показывает, как разместить изображение внутри ячейки таблицы при её создании:
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var islide = pres.getSlides().get_Item(0);
    // Задаёт столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Добавляет форму таблицы на слайд
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Создаёт объект PPImage, используя файл изображения
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет изображение в первую ячейку таблицы
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Сохраняет файл PPTX на диск
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли задать различную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [верхняя](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[нижняя](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[левая](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[правая](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут отличаться. Это логично вытекает из управления границами каждой стороны ячейки, продемонстрированного в статье.

**Что происходит с изображением, если изменить размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [режима заполнения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при плитке плитки пересчитываются. В статье упоминаются режимы отображения изображения в ячейке.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Гиперссылки](/slides/ru/nodejs-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/формы. На практике вы присваиваете ссылку части текста или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [части](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) с независимым форматированием — семейство шрифта, стиль, размер и цвет.