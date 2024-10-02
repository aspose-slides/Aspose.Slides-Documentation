---
title: Управление ячейками
type: docs
weight: 30
url: /ru/java/manage-cells/
keywords: "Таблица, объединенные ячейки, разделенные ячейки, изображение в ячейке таблицы, Java, Aspose.Slides для Java"
description: "Ячейки таблицы в презентациях PowerPoint на Java"
---


## **Определить объединенную ячейку таблицы**
1. Создайте экземпляр класса  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите таблицу с первого слайда. 
3. Переберите строки и столбцы таблицы, чтобы найти объединенные ячейки.
4. Выведите сообщение, когда объединенные ячейки будут найдены.

Этот код на Java показывает, как определить объединенные ячейки таблицы в презентации:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // предполагается, что Slide#0.Shape#0 - это таблица
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Ячейка %d;%d является частью объединенной ячейки с RowSpan=%d и ColSpan=%d, начиная с ячейки %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удалить границы ячеек таблицы**
1. Создайте экземпляр класса  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Переберите каждую ячейку, чтобы очистить верхние, нижние, правые и левые границы.
7. Сохраните измененную презентацию в виде файла PPTX.

Этот код на Java показывает, как удалить границы у ячеек таблицы:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавляет фигуру таблицы на слайд
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Записывает PPTX на диск
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Нумерация в объединенных ячейках**
Если мы объединим 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), результирующая таблица будет пронумерована. Этот код на Java демонстрирует процесс:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
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

    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Затем мы объединяем ячейки дальше, объединив (1, 1) и (1, 2). Результат – это таблица, содержащая большую объединенную ячейку в центре: 

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
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

    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Объединяет ячейки (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Записывает файл PPTX на диск
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Нумерация в разделенной ячейке**
В предыдущих примерах, когда ячейки таблицы объединялись, нумерация или система номеров в других ячейках не менялась. 

На этот раз мы берем обычную таблицу (таблицу без объединенных ячеек) и затем пытаемся разделить ячейку (1,1), чтобы получить специальную таблицу. Вы можете обратить внимание на нумерацию этой таблицы, которая может показаться странной. Тем не менее, именно так Microsoft PowerPoint нумерует ячейки таблиц, и Aspose.Slides делает то же самое. 

Этот код на Java демонстрирует описанный процесс:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
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

    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Разделяет ячейку (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Записывает файл PPTX на диск
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменить цвет фона ячейки таблицы**

Этот код на Java показывает, как изменить цвет фона ячейки таблицы:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // создаем новую таблицу
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // устанавливаем цвет фона для ячейки 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Добавить изображение в ячейку таблицы**

1. Создайте экземпляр класса  [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Создайте объект `Images`, чтобы хранить файл изображения.
7. Добавьте изображение `IImage` в объект `IPPImage`.
8. Установите `FillFormat` для ячейки таблицы на `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните измененную презентацию в виде файла PPTX.

Этот код на Java показывает, как поместить изображение внутри ячейки таблицы при создании таблицы:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX
Presentation pres = new Presentation();
try {
    // Получает первый слайд
    ISlide islide = pres.getSlides().get_Item(0);

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Добавляет фигуру таблицы на слайд
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Создает объект IPPImage, используя файл изображения
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет изображение в первую ячейку таблицы
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Сохраняет файл PPTX на диск
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```