---
title: Управление строками и столбцами в таблицах PowerPoint с помощью JavaScript
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/nodejs-java/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- копировать строку
- копировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью JavaScript и Aspose.Slides for Node.js via Java, ускоряя редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for Node.js via Java позволяет управлять структурой таблицы и её форматированием в презентациях PowerPoint с помощью класса [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) . Вы можете обозначить строку заголовка, клонировать или удалять строки и столбцы, а также применять форматирование текста к целой строке или столбцу.

Эта статья объясняет эти операции с примерами на JavaScript. Также показано, как получить предустановку стиля таблицы, чтобы её можно было повторно использовать. Индексы строк и столбцов таблицы начинаются с нуля.

## **Управление высотой строки**

Используйте [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) для установки минимальной высоты строки в пунктах. Это нижняя граница, а не фиксированная высота. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) возвращает фактическую высоту. Доступ к строке осуществляется через [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

В примере загружается [row-height-input.pptx](row-height-input.pptx), в котором первая фигура на первом слайде — таблица. Первая строка начинается с 70 пунктов. В ячейках используется текст Arial размером 18 пунктов, перенос строк и верхние и нижние отступы по 6 пунктов; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит фактическую высоту после каждого изменения и сохраняет оба результата.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В предоставленной презентации увеличение минимума добавляет пространство к строке. Уменьшение убирает это дополнительное пространство, но фактическая высота остаётся больше 20 пунктов, потому что текст и отступы ячеек требуют больше места. Снижение только минимума не может заставить строку стать ниже пространства, требуемого её содержимым.

Несколько факторов влияют на фактическую высоту:

- **Текст и размер шрифта:** более длинный текст, явные переносы строк или более крупный шрифт могут требовать больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе уменьшение ширины столбца с помощью [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) может создавать больше строк. Более широкий столбец может уменьшить требуемое вертикальное пространство.
- **Отступы ячеек:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) и [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) добавляют вертикальное пространство. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) и [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) уменьшают доступную ширину для текста и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшего вертикального пространства, определяет нижний предел для всей строки, зависящий от содержимого. Чтобы сделать строку короче, возможно, потребуется сократить текст, уменьшить размер шрифта или отступы, либо увеличить ширину столбца.

Изображения ниже показывают одну и ту же таблицу в одинаковом масштабе. На иллюстрированных результатах фактическая высота была 70, 100 и 55.2 пункта: последняя строка осталась выше своего минимума в 20 пунктов. Точные измерения текста могут варьироваться в зависимости от шрифтов, доступных в вашей среде. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Оригинал: минимум 70 пт, фактическая 70 пт | Увеличено: минимум 100 пт, фактическая 100 пт | Уменьшено: минимум 20 пт, фактическая 55.2 пт |
| --- | --- | --- |
| ![Оригинальная таблица с первой строкой высотой 70 пунктов.](row-height-before.png) | ![Таблица после увеличения минимального значения первой строки до 100 пунктов.](row-height-increased.png) | ![Таблица после уменьшения минимального значения первой строки до 20 пунктов; перенесённый текст удерживает строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку в качестве заголовка**

Используйте метод [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) для пометки первой строки как заголовка. Её внешний вид зависит от применённого к таблице стиля.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Получите доступ к таблице, хранящейся как первая фигура на слайде.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

В примере требуется `table.pptx` с таблицей в качестве первой фигуры на первом слайде. Он включает форматирование заголовка для первой строки и сохраняет `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Клонировать строку или столбец таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) .
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

В примере требуется `Test.pptx` с как минимум одним слайдом. Он создаёт таблицу с тремя столбцами и пятью строками, размеры указаны в пунктах. Он добавляет копии первой строки и первого столбца, затем вставляет копии второй строки и второго столбца в индекс 3 (четвёртая позиция). В результате таблица имеет семь строк и пять столбцов. Параметр `false` отключает клонирование в соседние объединённые строки или столбцы; в этой таблице нет объединённых ячеек.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Удалить строку или столбец из таблицы**

Удалите строки или столбцы, которые больше не нужны в таблице. При удалении элемент сдвигает индексы последующих строк или столбцов.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Определите ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) .
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 3х3 и удаляет строку и столбец с индексом 1, оставляя таблицу 2х2 в `TestTable_out.pptx`. Размеры указаны в пунктах. Параметр `false` отключает удаление соседних объединённых строк или столбцов; в этой таблице нет объединённых ячеек.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить форматирование текста на уровне строки таблицы**

Применяйте форматирование текста к целой строке, чтобы сохранить единообразие её ячеек. Можно задать свойства шрифта, форматирование абзаца и направление текста без форматирования каждой ячейки отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Получите доступ к таблице на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) для первой строки.
4. Используйте [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) для первой строки.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) для второй строки.
6. Сохраните изменённую презентацию.

В примере требуется `table.pptx` с таблицей в качестве первой фигуры на первом слайде и как минимум двумя строками. Он применяет 25‑пунктовый текст, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первой строке, затем задаёт вертикальный текст во второй строке.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить форматирование текста на уровне столбца таблицы**

Применяйте форматирование текста к целому столбцу, чтобы сохранить единообразие его ячеек. Можно задать свойства шрифта, форматирование абзаца и направление текста без форматирования каждой ячейки отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Получите доступ к таблице на первом слайде.
3. Используйте [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) для первого столбца.
4. Используйте [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) для первого столбца.
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) для второго столбца.
6. Сохраните изменённую презентацию.

В примере требуется `table.pptx` с таблицей в качестве первой фигуры на первом слайде и как минимум двумя столбцами. Он применяет 25‑пунктовый текст, выравнивание по правому краю и правый отступ абзаца в 20 пунктов к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить свойства стиля таблицы**

Используйте метод [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) для получения предустановки, применённой к таблице, и повторного её использования в другой таблице. Это идентифицирует предустановку, а не отдельные переопределения форматирования ячеек.

В примере создаётся таблица, применяется [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) и читается предустановка обратно. Выводится целочисленное значение, соответствующее `DarkStyle1`, и сохраняется таблица в `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/основы, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, затем заново заполните строки таблицы в этом порядке.

**Можно ли использовать полосатые столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите полосатые столбцы, затем переопределите конкретные ячейки локальным форматированием; форматирование уровня ячейки имеет приоритет над стилем таблицы.