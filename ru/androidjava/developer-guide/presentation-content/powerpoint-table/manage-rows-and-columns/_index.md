---
title: Управление строками и столбцами
type: docs
weight: 20
url: /ru/androidjava/manage-rows-and-columns/
keywords: "Таблица, строки и столбцы таблицы, презентация PowerPoint, Java, Aspose.Slides для Android на Java"
description: "Управление строками и столбцами таблицы в презентациях PowerPoint с помощью Java"
---

Чтобы управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) и многие другие типы.

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Создайте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) и установите его в null.
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), чтобы найти соответствующую таблицу.
5. Установите первую строку таблицы в качестве заголовка.

Этот код на Java показывает, как установить первую строку таблицы в качестве заголовка:

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Инициализация null TableEx
    ITable tbl = null;

    // Перебор фигур и установка ссылки на таблицу
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // Установка первой строки таблицы в качестве заголовка
            tbl.setFirstRow(true);
        }
    }
    
    // Сохранение презентации на диск
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Клонируйте строку таблицы.
7. Клонируйте столбец таблицы.
8. Сохраните измененную презентацию.

Этот код на Java показывает, как клонировать строку или столбец таблицы PowerPoint:

```java
 // Создание экземпляра класса Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Определение столбцов с шириной и строк с высотой
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавление формы таблицы на слайд
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Добавление текста в ячейку 1 строки 1
    table.get_Item(0, 0).getTextFrame().setText("Ячейка 1 Строка 1");

    // Добавление текста в ячейку 1 строки 2
    table.get_Item(1, 0).getTextFrame().setText("Ячейка 2 Строка 1");

    // Клонирование строки 1 в конец таблицы
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Добавление текста в ячейку 1 строки 2
    table.get_Item(0, 1).getTextFrame().setText("Ячейка 1 Строка 2");

    // Добавление текста в ячейку 2 строки 2
    table.get_Item(1, 1).getTextFrame().setText("Ячейка 2 Строка 2");

    // Клонирование строки 2 как 4-й строки таблицы
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Клонирование первого столбца в конец
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Клонирование 2-го столбца на 4-й индекс столбца
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    
    // Сохранение презентации на диск
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Удалите строку таблицы.
7. Удалите столбец таблицы.
8. Сохраните измененную презентацию.

Этот код на Java показывает, как удалить строку или столбец из таблицы:

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

## **Установить форматирование текста на уровне строки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) слайда.
4. Установите высоту шрифта для ячеек первой строки с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Установите выравнивание текста и правый отступ для ячеек первой строки с помощью [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Установите вертикальный тип текста для ячеек второй строки с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Предположим, что первая фигура на первом слайде — это таблица
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Установка высоты шрифта ячеек первой строки
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Установка выравнивания текста и правого отступа для ячеек первой строки
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Установка вертикального типа текста для ячеек второй строки
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

    // Сохранение презентации на диск
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить форматирование текста на уровне столбца таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите соответствующий объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) слайда.
4. Установите высоту шрифта для ячеек первого столбца с помощью [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Установите выравнивание текста и правый отступ для ячеек первого столбца в одном вызове с помощью [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Установите вертикальный тип текста для ячеек второго столбца с помощью [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию:

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Предположим, что первая фигура на первом слайде — это таблица
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Установка высоты шрифта ячеек первого столбца
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Установка выравнивания текста и правого отступа для ячеек первого столбца в одном вызове
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Установка вертикального типа текста для ячеек второго столбца
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет вам извлекать свойства стиля для таблицы, чтобы вы могли использовать эти данные для другой таблицы или в другом месте. Этот код на Java показывает, как получить свойства стиля из предустановленного стиля таблицы:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // изменение предустановленного стиля по умолчанию
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```