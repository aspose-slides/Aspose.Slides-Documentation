---
title: Управление ячейками таблиц в презентациях на .NET
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/net/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разбиение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Легко управлять ячейками таблиц в PowerPoint с помощью Aspose.Slides для .NET. Освойте быстрый доступ, изменение и стилизацию ячеек для беспроблемной автоматизации слайдов."
---

## **Определение объединённых ячеек таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите таблицу с первого слайда.
3. Пройдитесь по строкам и столбцам таблицы, чтобы найти объединённые ячейки.
4. Выведите сообщение, когда найдены объединённые ячейки.

Этот код C# показывает, как определить объединённые ячейки таблицы в презентации:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // предполагая, что Slide#0.Shape#0 является таблицей
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **Удаление границ ячеек таблицы**
1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода `AddTable`.
6. Пройдитесь по каждой ячейке, чтобы очистить верхнюю, нижнюю, правую и левую границы.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код C# показывает, как удалить границы из ячеек таблицы:
```c#
 // Создает объект класса Presentation, представляющий файл PPTX
 using (Presentation pres = new Presentation())
 {
    // Получает первый слайд
     Slide sld = (Slide)pres.Slides[0];
 
    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };
 
    // Добавляет форму таблицы на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);
 
    // Устанавливает формат границы для каждой ячейки
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


## **Нумерация в объединённых ячейках**
Если мы объединим 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), полученная таблица будет пронумерована. Этот код C# демонстрирует процесс:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide sld = presentation.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет форму таблицы на слайд
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
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


Затем мы дополнительно объединяем ячейки, объединяя (1, 1) и (1, 2). В результате получается таблица, содержащая большую объединённую ячейку в центре:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет форму таблицы на слайд
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
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

    // Объединяет ячейки (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Записывает файл PPTX на диск
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **Нумерация в раздельных ячейках**
В предыдущих примерах, когда ячейки таблицы объединялись, нумерация или система нумерации в остальных ячейках не менялась.

В этот раз мы возьмём обычную таблицу (таблицу без объединённых ячеек) и затем попробуем разделить ячейку (1,1), чтобы получить особую таблицу. Обратите внимание на нумерацию этой таблицы, которая может показаться странной. Однако так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides делает то же самое.

Этот код C# демонстрирует описанный процесс:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Добавляет форму таблицы на слайд
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Устанавливает формат границы для каждой ячейки
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

    // Разделяет ячейку (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Записывает файл PPTX на диск
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **Изменение цвета фона ячейки таблицы**

Этот код C# показывает, как изменить цвет фона ячейки таблицы:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // создать новую таблицу
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // установить цвет фона ячейки
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **Добавление изображения в ячейку таблицы**

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд по его индексу.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода `AddTable`.
6. Создайте объект `Bitmap` для хранения файла изображения.
7. Добавьте bitmap‑изображение в объект `IPPImage`.
8. Установите `FillFormat` для ячейки таблицы в значение `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните изменённую презентацию в файл PPTX

Этот код C# показывает, как разместить изображение внутри ячейки таблицы при её создании:
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Определяет столбцы с ширинами и строки с высотами
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Добавляет форму таблицы на слайд
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Загружает изображение из файла и добавляет его в ресурсы презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет изображение в первую ячейку таблицы
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Сохраняет файл PPTX на диск
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Могу ли я задать разную толщину линий и стили для разных сторон одной ячейки?**

Да. У границ [верхней](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[нижней](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[левой](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[правой](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) есть отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться. Это логично следует из управления границами каждой стороны ячейки, продемонстрированного в статье.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [режима заполнения](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (растяжка/замощение). При растяжении изображение адаптируется к новой ячейке; при замощении тайлы пересчитываются. В статье упомянуты режимы отображения изображения в ячейке.

**Могу ли я назначить гиперссылку всему содержимому ячейки?**

[Гиперссылки](/slides/ru/net/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового кадра ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку отдельной части или всему тексту в ячейке.

**Могу ли я задать разные шрифты в одной ячейке?**

Да. Текстовый кадр ячейки поддерживает [части](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) с независимым форматированием — семейство шрифта, стиль, размер и цвет.