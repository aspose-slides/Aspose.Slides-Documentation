---
title: Управление Ячейками
type: docs
weight: 30
url: /ru/net/manage-cells/
keywords: "Таблица, объединенные ячейки, разделенные ячейки, изображение в ячейке таблицы, C#, Csharp, Aspose.Slides для .NET"
description: "Ячейки таблицы в презентациях PowerPoint на C# или .NET"
---

## **Определение Объединенной Ячейки Таблицы**

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите таблицу с первого слайда. 
3. Переберите строки и столбцы таблицы, чтобы найти объединенные ячейки.
4. Выведите сообщение, когда объединенные ячейки найдены.

Этот код C# демонстрирует, как определить объединенные ячейки таблицы в презентации:

```c#
using (Presentation pres = new Presentation("НекотораяПрезентацияСТаблицей.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // предполагаем, что Slide#0.Shape#0 — это таблица
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Ячейка {0};{1} является частью объединенной ячейки с RowSpan={2} и ColSpan={3}, начиная с ячейки {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));
            }
        }
    }
}
```

## **Удаление Границ Ячеек Таблицы**
1. Создайте экземпляр класса `Презентация`.
2. Получите ссылку на слайд по его индексу. 
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд через метод `AddTable`.
6. Переберите каждую ячейку, чтобы очистить верхнюю, нижнюю, правую и левую границы.
7. Сохраните измененную презентацию в формате PPTX.

Этот код C# демонстрирует, как удалить границы из ячеек таблицы:

```c#
// Создает экземпляр класса Презентация, который представляет файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    Slide sld = (Slide)pres.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Добавляет таблицу на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границ для каждой ячейки
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Записывает файл PPTX на диск
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Нумерация в Объединенных Ячейках**
Если объединить 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), результирующая таблица будет пронумерована. Этот код C# демонстрирует процесс:

```c#
// Создает экземпляр класса Презентация, который представляет файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide sld = presentation.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет таблицу на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границ для каждой ячейки
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Объединяет ячейки (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Объединяет ячейки (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Затем мы дополнительно объединим ячейки, объединив (1, 1) и (1, 2). Результатом будет таблица с крупной объединенной ячейкой в центре: 

```c#
// Создает экземпляр класса Презентация, который представляет файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет таблицу на слайд
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границ для каждой ячейки
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Объединяет ячейки (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Объединяет ячейки (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Объединяет ячейки (1, 1) и (1, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Записывает файл PPTX на диск
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Нумерация в Разделенной Ячейке**
В предыдущих примерах, когда ячейки таблицы были объединены, нумерация или система чисел в других ячейках не изменилась. 

На этот раз мы берем обычную таблицу (таблицу без объединенных ячеек) и затем пытаемся разделить ячейку (1,1), чтобы получить специальную таблицу. Вы можете обратить внимание на нумерацию этой таблицы, которая может показаться странной. Однако именно так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides делает то же самое. 

Этот код C# демонстрирует описанный нами процесс:

```c#
// Создает экземпляр класса Презентация, который представляет файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет таблицу на слайд
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границ для каждой ячейки
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Объединяет ячейки (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Объединяет ячейки (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Делит ячейку (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Записывает файл PPTX на диск
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Изменение Фона Ячейки Таблицы**

Этот код C# демонстрирует, как изменить цвет фона ячейки таблицы:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // Создает новую таблицу
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Устанавливает цвет фона для ячейки 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Добавление Изображения Внутри Ячейки Таблицы**

1. Создайте экземпляр класса `Презентация`.
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд через метод `AddTable`. 
6. Создайте объект `Bitmap`, чтобы сохранить файловое изображение.
7. Добавьте растровое изображение в объект `IPPImage`.
8. Установите `FillFormat` для Ячейки Таблицы на `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните измененную презентацию в формате PPTX

Этот код C# демонстрирует, как поместить изображение внутри ячейки таблицы при создании таблицы:

```c#
// Создает экземпляр класса Презентация, который представляет файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide islide = presentation.Slides[0];

    // Определяет столбцы с шириной и строки с высотой
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Добавляет таблицу на слайд
    ITable tbl = islide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Создает объект Bitmap для хранения файлового изображения
    Bitmap image = new Bitmap("aspose-logo.jpg");

    // Создает объект IPPImage, используя объект bitmap
    IPPImage imgx1 = presentation.Images.AddImage(image);

    // Добавляет изображение в первую ячейку таблицы
    tbl[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = imgx1;

    // Сохраняет файл PPTX на диск
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```