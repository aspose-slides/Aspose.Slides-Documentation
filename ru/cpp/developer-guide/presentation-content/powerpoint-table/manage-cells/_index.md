---
title: Управление ячейками таблиц в презентациях с использованием C++
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/cpp/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разделение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в C++: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячеек и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую форму на первом слайде как таблицу. Предполагается, что слайд и форма существуют и что форма является таблицей. Затем он перебирает все строки и столбцы и использует [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) для определения ячеек в объединённых областях. Для каждой найденной ячейки выводятся её координаты в порядке `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), а также начальные координаты области: [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) и [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Удалить границы ячейки таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и добавьте таблицу на её первый слайд с помощью [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Ширины столбцов, высоты строк и положение таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в значение [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), делая их невидимыми.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Объединить ячейки таблицы**

Используйте [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент определяет, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри диапазона.

Пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся четырёхколоночной и четырёхстрочной. Чтобы получить содержимое или форматирование объединённой ячейки, используйте её позицию в левом верхнем угле: `table->idx_get(1, 1)` в этом примере. Остальные позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за её пределами не меняются.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4 × 4 с колонками и строками по 70 пунктов и вызывается [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) для ячейки `(1, 1)`. Поскольку передаётся половина ширины 70 пунктов, получаются две ячейки одинаковой ширины.

После разделения две половины доступны как `table->idx_get(1, 1)` и `table->idx_get(2, 1)`. Сетка таблицы теперь содержит пять столбцов: ячейки, ранее находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые ячейки шаблона к заполнению данными, используйте [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) для разделения по существующей границе строки или [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) для разделения по границе столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относителен к объединённой области:

- Разделение по строке: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Разделение по столбцу: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Пример предполагает, что в первой форме первого слайда присутствует таблица, в которой ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начинаем с нижней позиции, используя [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) и [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) для определения начала, и проверяем обе области. Затем `SplitByRowSpan(1)` разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `SplitByColSpan(1)`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Получить получившиеся ячейки из таблицы после разделения.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите получившиеся ячейки по их координатам; в данном случае обе имеют span = 1, и [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) выводит `False`. Более крупные области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пустая, но наследует форматирование ячейки, включая заливку, границы и отступы. Заполните ячейки после разделения и при необходимости явно задайте форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием ячеек шаблона. Смотрите [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) для подробностей.

## **Изменить цвет фона ячейки таблицы**

В этом примере создаётся таблица со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Используется [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) для выбора сплошной заливки и [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) для доступа к цвету заливки, который устанавливается в красный для ячейки `(2, 3)` (третий столбец, четвёртая строка).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Добавить изображение в ячейку таблицы**

Поместите входное изображение в рабочий каталог перед запуском примера. Оно загружается с помощью [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) и добавляется в коллекцию изображений презентации через [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Затем изображение назначается в качестве заливки картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить её соотношение сторон. Ширины столбцов и высоты строк задаются в пунктах. Загруженное изображение освобождается после того, как оно было добавлено в презентацию.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **Часто задаваемые вопросы**

**Можно ли установить разную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при замощении плитки пересчитываются.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/cpp/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/формы. На практике ссылка назначается отдельной части или всему тексту в ячейке.

**Можно ли установить разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (фрагменты) с независимым форматированием — семейство шрифта, стиль, размер и цвет.