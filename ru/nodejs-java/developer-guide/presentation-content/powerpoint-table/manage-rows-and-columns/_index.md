---
title: "Управление строками и столбцами"
type: docs
weight: 20
url: /ru/nodejs-java/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Управление строками и столбцами таблицы в презентациях PowerPoint на JavaScript"
---

Чтобы дать вам возможность управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) class, [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) class, а также многие другие типы.

## **Установить первую строку как заголовок**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию.  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) и присвойте ему null.  
4. Пройдите по всем объектам [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) , чтобы найти нужную таблицу.  
5. Установите первую строку таблицы в качестве заголовка.  

Этот JavaScript‑код показывает, как установить первую строку таблицы в качестве заголовка:
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Инициализирует null TableEx
    var tbl = null;
    // Проходит по формам и задает ссылку на таблицу
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Устанавливает первую строку таблицы как заголовок
            tbl.setFirstRow(true);
        }
    }
    // Сохраняет презентацию на диск
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Определите массив `columnWidth`.  
4. Определите массив `rowHeight`.  
5. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Клонируйте строку таблицы.  
7. Клонируйте столбец таблицы.  
8. Сохраните изменённую презентацию.  

Этот JavaScript‑код показывает, как клонировать строку или столбец таблицы PowerPoint:
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Определяет столбцы с ширинами и строки с высотами
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Добавляет форму таблицы на слайд
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Добавляет текст в ячейку строки 1 столбца 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Добавляет текст в ячейку строки 1 столбца 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Клонирует строку 1 в конец таблицы
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Добавляет текст в ячейку строки 2 столбца 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Добавляет текст в ячейку строки 2 столбца 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Клонирует строку 2 как 4‑ю строку таблицы
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Клонирует первый столбец в конец
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Клонирует второй столбец в позицию 4‑го столбца
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Сохраняет презентацию на диск
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Определите массив `columnWidth`.  
4. Определите массив `rowHeight`.  
5. Добавьте объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Удалите строку таблицы.  
7. Удалите столбец таблицы.  
8. Сохраните изменённую презентацию.  

Этот JavaScript‑код показывает, как удалить строку или столбец из таблицы:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить форматирование текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Получите нужный объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) со слайда.  
4. Установите для ячеек первой строки [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Установите для ячеек первой строки [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Установите для ячеек второй строки [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.  

Этот JavaScript‑код демонстрирует операцию.
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Предположим, что первая фигура на первом слайде — это таблица
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Устанавливает высоту шрифта ячеек первой строки
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Устанавливает выравнивание текста ячеек первой строки и правый отступ
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Устанавливает вертикальный тип текста ячеек второй строки
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Сохраняет презентацию на диск
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить форматирование текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию,  
2. Получите ссылку на слайд по его индексу.  
3. Получите нужный объект [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) со слайда.  
4. Установите для ячеек первого столбца [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Установите для ячеек первого столбца [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Установите для ячеек второго столбца [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.  

Этот JavaScript‑код демонстрирует операцию:
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Предположим, что первая фигура на первом слайде - это таблица
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Устанавливает высоту шрифта ячеек первого столбца
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Устанавливает выравнивание текста и правый отступ ячеек первого столбца одной командой
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Устанавливает вертикальный тип текста ячеек второго столбца
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы использовать эти данные для другой таблицы или в другом месте. Этот JavaScript‑код показывает, как получить свойства стиля из предустановленного стиля таблицы:
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


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/раскладки/мастера, но вы всё равно можете переопределить заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, затем заполните строки таблицы в полученном порядке.

**Можно ли иметь полосатые (заштрихованные) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите полосатые столбцы, а затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.