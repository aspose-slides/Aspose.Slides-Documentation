---
title: Управление строками и столбцами в таблицах PowerPoint с использованием Java
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/java/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонирование строки
- клонирование столбца
- копирование строки
- копирование столбца
- удаление строки
- удаление столбца
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint с помощью Aspose.Slides для Java и ускоряйте редактирование презентаций и обновление данных."
---

Чтобы позволить вам управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) , интерфейс [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) и многие другие типы. 

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию. 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) и присвойте ему значение null. 
4. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) , чтобы найти нужную таблицу. 
5. Установите первую строку таблицы в качестве её заголовка. 

Следующий код Java показывает, как установить первую строку таблицы в качестве заголовка:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Инициализирует null TableEx
    ITable tbl = null;

    // Итерирует формы и устанавливает ссылку на таблицу
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sets the first row of a table as its header
            // Устанавливает первую строку таблицы как заголовок
            tbl.setFirstRow(true);
        }
    }
    
    // Сохраняет презентацию на диск
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```




## **Клонирование строки или столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Клонируйте строку таблицы. 
7. Клонируйте столбец таблицы. 
8. Сохраните изменённую презентацию. 

Следующий код Java показывает, как клонировать строку или столбец таблицы PowerPoint:
```java
 // Создает экземпляр класса Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавляет форму таблицы на слайд
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Добавляет текст в ячейку 1 строки 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Добавляет текст в ячейку 2 строки 1
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Клонирует строку 1 в конец таблицы
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Добавляет текст в ячейку 1 строки 2
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Добавляет текст в ячейку 2 строки 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Клонирует строку 2 как 4‑ю строку таблицы
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Клонирует первый столбец в конец
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Клонирует второй столбец на позицию 4‑го столбца
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Сохраняет презентацию на диск
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удаление строки или столбца из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Определите массив `columnWidth`. 
4. Определите массив `rowHeight`. 
5. Добавьте объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Удалите строку таблицы. 
7. Удалите столбец таблицы. 
8. Сохраните изменённую презентацию. 

Следующий код Java показывает, как удалить строку или столбец из таблицы:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка форматирования текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) со слайда. 
4. Установите для ячеек первой строки [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Установите для ячеек первой строки [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Установите для ячеек второй строки [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Сохраните изменённую презентацию. 

Следующий код Java демонстрирует эту операцию.
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Предположим, что первая фигура на первом слайде — таблица
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Устанавливает высоту шрифта ячеек первой строки
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Устанавливает выравнивание текста ячеек первой строки и правый отступ
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Устанавливает вертикальный тип текста ячеек второй строки
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Сохраняет презентацию на диск
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка форматирования текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, 
2. Получите ссылку на слайд по его индексу. 
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) со слайда. 
4. Установите для ячеек первого столбца [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Установите для ячеек первого столбца [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Установите для ячеек второго столбца [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Сохраните изменённую презентацию. 

Следующий код Java демонстрирует эту операцию:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Предположим, что первая фигура на первом слайде — таблица
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Устанавливает высоту шрифта ячеек первого столбца
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Устанавливает выравнивание текста ячеек первого столбца и правый отступ одним вызовом
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Устанавливает вертикальный тип текста ячеек второго столбца
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы использовать эти данные для другой таблицы или в другом месте. Следующий код Java показывает, как получить свойства стиля из предустановленного стиля таблицы:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // изменить предустановленную тему стиля по умолчанию
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/образца, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в этом порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, одновременно сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередующиеся столбцы, а затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.