---
title: Управление ячейками таблиц в презентациях на Android
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/androidjava/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разделение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint на Android: определяйте объединенные ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц и изменять их в презентациях PowerPoint. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через их свойства и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определение объединенной ячейки таблицы**

Пример открывает существующую презентацию и получает первую фигуру на первом слайде как таблицу. Предполагается, что слайд и фигура существуют и что фигура является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) для определения ячеек в объединённых регионах. Для каждого совпадения он выводит координаты ячейки в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), а также координаты начала региона, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) и [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Удаление границ ячеек таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в значение [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), делая их невидимыми.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Объединение ячеек таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) для комбинирования прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом‑верхнем и правом‑нижнем углах диапазона. Последний аргумент контролирует, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4×4 со столбцами и строками шириной 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, тогда как базовая сетка таблицы остаётся четырёхстолбцовой и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом‑верхнем углу: `table.get_Item(1, 1)` в этом примере. Остальные позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Разделение ячеек таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4×4 со столбцами и строками шириной 70 пунктов и вызывается [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) для ячейки `(1, 1)`. Поскольку половина ширины 70 пунктов передаётся для создания двух равных ячеек, получаются две ячейки одинаковой ширины.

После разделения две половины доступны как `table.get_Item(1, 1)` и `table.get_Item(2, 1)`. Сетка таблицы теперь содержит пять столбцов: ячейки, первоначально находившиеся в столбцах 2 и 3, переходят в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте эти обновлённые индексы столбцов при обращении к ячейкам после разделения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Разделение объединённых ячеек по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) для разделения вдоль существующей границы строки, либо [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) для разделения вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относителен объединённого региона:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Пример ожидает, что в презентации первая фигура на первом слайде будет таблицей, где ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) и [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) для поиска начала и проверяет оба охвата. `splitByRowSpan(1)` затем отделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Получить результирующие ячейки из таблицы после разделения.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Сетка таблицы и индексы окружающих ячеек остаются без изменений. Получите результирующие ячейки по их координатам; в данном случае обе имеют охват 1 и [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) возвращает `false`. Более крупные регионы могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пустая, но наследует форматирование ячейки, такое как заливка, границы и отступы. После разделения заполните ячейки и явно задайте требуемое форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблонных ячеек. Смотрите [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) для подробностей.

## **Изменение цвета фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) для выбора сплошной заливки и задаёт цвет, возвращаемый [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), в красный для ячейки `(2, 3)`, находящейся в третьем столбце и четвёртой строке.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление изображения внутри ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском этого примера. Оно загружается с помощью [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) и добавляется в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Затем изображение назначается в качестве заливки картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить его соотношение сторон. Ширины столбцов и высоты строк указаны в пунктах. Загруженное изображение освобождается в блоке `finally` после его добавления в презентацию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Часто задаваемые вопросы**

**Могу ли я задать разную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут отличаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). При растяжении изображение адаптируется к новой ячейке, при тайлинге – плитки пересчитываются.

**Могу ли я назначить гиперссылку на всё содержимое ячейки?**

[Hyperlinks](/slides/ru/androidjava/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку части текста или всему тексту в ячейке.

**Могу ли я задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (фрагменты) с независимым форматированием — семейством шрифта, стилем, размером и цветом.