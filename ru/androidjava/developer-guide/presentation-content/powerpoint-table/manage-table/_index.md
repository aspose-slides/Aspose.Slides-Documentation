---
title: Управление таблицей
type: docs
weight: 10
url: /androidjava/manage-table/
keywords: "Таблица, создать таблицу, доступ к таблице, соотношение сторон таблицы, презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Создайте и управляйте таблицами в презентациях PowerPoint на Java"
---

Таблица в PowerPoint — это эффективный способ представления и отображения информации. Информация в сетке ячеек (расположенных по строкам и столбцам) проста и легка для понимания.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table), интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable), класс [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) и интерфейс [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) для создания, обновления и управления таблицами во всех видах презентаций.

## **Создать таблицу с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс. 
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд через метод [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Примените форматирование к верхним, нижним, правым и левым границам каждой [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/).
7. Объедините первые две ячейки первой строки таблицы. 
8. Получите [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) для [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/).
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
10. Сохраните измененную презентацию.

Этот код Java показывает, как создать таблицу в презентации:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Добавляет фигуру таблицы на слайд
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Объединяет ячейки 1 и 2 строки 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Добавляет текст в объединенную ячейку
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Объединенные ячейки");

    // Сохраняет презентацию на диск
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице индексируется как 0,0 (столбец 0, строка 0). 

Например, ячейки в таблице с 4 столбцами и 4 строками пронумерованы следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код Java показывает, как задать нумерацию для ячеек в таблице:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет фигуру таблицы на слайд
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Сохраняет презентацию на диск
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).

2. Получите ссылку на слайд, содержащий таблицу, через его индекс. 

3. Создайте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) и установите его в null.

4. Переберите все объекты [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) до тех пор, пока таблица не будет найдена.

   Если вы подозреваете, что слайд, с которым вы работаете, содержит единственную таблицу, вы можете просто проверить все фигуры, которые он содержит. Когда фигура идентифицирована как таблица, вы можете привести ее к объекту [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table). Но если слайд, с которым вы работаете, содержит несколько таблиц, то лучше искать нужную таблицу через [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Используйте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) для работы с таблицей. В приведенном ниже примере мы добавили новую строку в таблицу.

6. Сохраните измененную презентацию.

Этот код Java показывает, как получить доступ и работать с существующей таблицей:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Инициализирует null TableEx
    ITable tbl = null;

    // Перебирает фигуры и устанавливает ссылку на найденную таблицу
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Устанавливает текст для первого столбца второй строки
            tbl.get_Item(0, 1).getTextFrame().setText("Новый");
        }
    }
    
    // Сохраняет измененную презентацию на диск
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс. 
3. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд.
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) из таблицы.
5. Получите [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/).
6. Выравнивайте текст вертикально.
7. Сохраните измененную презентацию.

Этот код Java показывает, как выровнять текст в таблице:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получает первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Добавляет фигуру таблицы на слайд
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Получает текстовый фрейм
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Создает объект Paragraph для текстового фрейма
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Создает объект Portion для абзаца
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Текст здесь");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Выравнивает текст вертикально
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Сохраняет презентацию на диск
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить форматирование текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд через его индекс. 
3. Получите объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) из слайда.
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для текста.
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Сохраните измененную презентацию. 

Этот код Java показывает, как применить желаемые параметры форматирования к тексту в таблице:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Предположим, что первая фигура на первом слайде - это таблица
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Устанавливает высоту шрифта ячеек таблицы
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Устанавливает выравнивание текста ячеек таблицы и правый отступ за один вызов
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Устанавливает вертикальный тип текста ячеек таблицы
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет извлекать свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или где-либо еще. Этот код Java показывает, как получить свойства стиля из предустановленного стиля таблицы:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // изменяет заданный стиль предустановленной темы 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Заблокировать соотношение сторон таблицы**

Соотношение сторон геометрической формы — это отношение ее размеров в различных измерениях. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) для блокировки настройки соотношения сторон для таблиц и других фигур.

Этот код Java показывает, как заблокировать соотношение сторон таблицы:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Блокировка соотношения сторон установлена: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // инвертировать

    System.out.println("Блокировка соотношения сторон установлена: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```