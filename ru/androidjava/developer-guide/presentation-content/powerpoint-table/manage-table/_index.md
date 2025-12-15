---
title: Управление таблицами презентаций на Android
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для Android. Откройте простые примеры кода Java, упрощающие работу с таблицами."
---

Таблица в PowerPoint — это эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) представлена ясно и легко понимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table), интерфейс [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable), класс [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/), интерфейс [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в любых презентациях.

## **Create a Table from Scratch**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Определите массив `columnWidth`.  
4. Определите массив `rowHeight`.  
5. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).  
6. Пройдитесь по каждой [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) и примените форматирование к верхней, нижней, правой и левой границам.  
7. Объедините первые две ячейки первой строки таблицы.  
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) ячейки [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/).  
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).  
10. Сохраните изменённую презентацию.

Этот Java‑код показывает, как создать таблицу в презентации:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Добавляет форму таблицы на слайд
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
    // Объединяет ячейки 1 и 2 первой строки
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Добавляет текст в объединённую ячейку
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Сохраняет презентацию на диск
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numbering in a Standard Table**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка таблицы имеет индексы 0,0 (столбец 0, строка 0).

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот Java‑код показывает, как задать нумерацию ячеек в таблице:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет форму таблицы на слайд
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


## **Access an Existing Table**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  

2. Получите ссылку на слайд, содержащий таблицу, по его индексу.  

3. Создайте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) и присвойте ему значение null.  

4. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), пока не найдёте таблицу.  

   Если вы подозреваете, что на слайде только одна таблица, можно просто проверить все содержащиеся в нём формы. Когда форма идентифицирована как таблица, её можно привести к типу [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table). Если же на слайде несколько таблиц, лучше искать нужную таблицу по её методу [setAlternativeText(String value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).  

5. Используйте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) для работы с таблицей. В примере ниже мы добавляем новую строку в таблицу.  

6. Сохраните изменённую презентацию.

Этот Java‑код показывает, как получить доступ к существующей таблице и работать с ней:
```java
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Инициализирует TableEx как null
    ITable tbl = null;

    // Итерация по фигурам и установка ссылки на найденную таблицу
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Устанавливает текст для первой колонки второй строки
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Сохраняет изменённую презентацию на диск
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Align Text in a Table**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) на слайд.  
4. Получите объект [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) из таблицы.  
5. Получите [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) из [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).  
6. Выравнивайте текст по вертикали.  
7. Сохраните изменённую презентацию.

Этот Java‑код показывает, как выровнять текст в таблице:
```java
// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получает первый слайд 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Добавляет форму таблицы на слайд
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Получает текстовый фрейм
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Создаёт объект Paragraph для текстового фрейма
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Создаёт объект Portion для абзаца
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Выравнивает текст по вертикали
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Сохраняет презентацию на диск
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Set Text Formatting on the Table Level**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Получите объект [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) со слайда.  
4. Установите [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) для текста.  
5. Установите [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) и [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Установите [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Сохраните изменённую презентацию.

Этот Java‑код показывает, как применить желаемые параметры форматирования к тексту в таблице:
```java
// Создаёт экземпляр класса Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Предположим, что первая фигура на первом слайде — это таблица
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Устанавливает высоту шрифта ячеек таблицы
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
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


## **Get Table Style Properties**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы использовать их для другой таблицы или в другом месте. Этот Java‑код показывает, как получить свойства стиля из предустановленного стиля таблицы:
```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // изменить тему предустановленного стиля по умолчанию
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Lock Aspect Ratio of a Table**

Соотношение сторон геометрической фигуры — это отношение её размеров по разным измерениям. Aspose.Slides предоставляет свойство [**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-), позволяющее зафиксировать соотношение сторон для таблиц и других фигур.

Этот Java‑код показывает, как закрепить соотношение сторон для таблицы:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // инвертировать

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Использование обоих методов обеспечивает правильный порядок RTL и корректный рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размеров таблицы конечным пользователем?**

Используйте [защиту форм](/slides/ru/androidjava/applying-protection-to-presentation/), чтобы отключить перемещение, изменение размеров, выделение и т.д. Эти ограничения применяются и к таблицам.

**Поддерживается ли установка изображения в качестве фона ячейки?**

Да. Вы можете задать [заполнение изображением](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать площадь ячейки в выбранном режиме (растягивание или повтор).