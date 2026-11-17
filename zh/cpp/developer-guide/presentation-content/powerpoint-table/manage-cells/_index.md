---
title: 在演示文稿中使用 C++ 管理表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/cpp/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 C++ 管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格，并使用 Aspose.Slides for C++ 设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文阐述了如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、修改单元格背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引，以 `(column, row)` 顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一张幻灯片上的第一个形状作为表格访问。它假设该幻灯片和形状存在且该形状是表格。随后遍历所有行和列，并使用[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 来识别合并区域中的单元格。对于每个匹配项，打印单元格坐标（`row;column` 顺序）、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)，以及区域的起始坐标，[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 和 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)。

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

## **删除表格单元格边框**

创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，并使用[AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 在其第一张幻灯片上添加表格。列宽、行高以及表格位置均以点为单位指定。示例将所有四条单元格边框设置为[FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，使其不可见。

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

## **添加对角线单元格边框**

使用[get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) 绘制从左上角到右下角的线，使用[get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) 绘制从左下角到右上角的线。对角线可用于标记角标题；两条对角线可形成 X，以标记单元格不适用。

每条对角线都是一个[ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/)。使用[get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) 访问其填充，调用[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) 并传入[FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，随后通过[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) 选择颜色。使用[set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) 以点为单位设置线宽。

示例在一行中创建了三个单元格：一个带有红色向下对角线的单元格、一个带有蓝色向上对角线的单元格，以及同时带有两条对角线的单元格。它保持上下左右单元格边框不变。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

对角线是一种格式属性，而非单元格拆分。每个单元格保留一个通过[get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 访问的文本框；对角线两侧的区域不能独立编辑。

保存的表格，在 Microsoft PowerPoint 中呈现如下：

![三个位于表格的单元格，显示左上到右下的红色对角线、左下到右上的蓝色对角线，以及形成 X 的两条对角线。](diagonal-cell-borders.png)

*从左到右：向下对角线（红色，3 pt），向上对角线（蓝色，5 pt），以及两条对角线。*

## **合并表格单元格**

使用[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可包括范围外的单元格；`false` 将合并限制在该范围内。

示例创建了一个 4×4 的表格，列宽和行高均为 70 点，然后合并位于 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格底层网格仍保持四列四行。要访问合并单元格的内容或格式，在本例中使用其左上位置：`table->idx_get(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引保持不变。

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

## **拆分表格单元格**

在前面的示例中合并单元格保留了表格的网格。拆分单元格可能会引入新的网格列并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建了一个 4×4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用[SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两半可通过 `table->idx_get(1, 1)` 和 `table->idx_get(2, 1)` 访问。表格网格现在有五列：原本位于第 2、3 列的单元格分别移动到第 3、4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

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

<!-- visual-explanation:manage-cells:start -->
[![未合并的 70 点单元格拆分为两个 35 点单元格，添加第五列网格并将右侧索引向右移动。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*宽度拆分影响单元格 (1, 1)，使用从零开始的 (column, row) 索引。其他行保持单元格跨越两个新列位置。*
<!-- visual-explanation:manage-cells:end -->

### **按行或列跨度拆分合并的单元格**

为了准备合并的模板单元格进行数据填充，可使用[SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 按现有行边界拆分，或使用[SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) 按列边界拆分。

`index` 参数统计拆分上部的行数或左部的列数；它相对于合并区域：

- 行拆分：`0 < index <`[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)。
- 列拆分：`0 < index <`[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)。

示例假设演示文稿在第一张幻灯片的第一个形状中有一个表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。从下部位置开始，使用[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 和[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 定位起点并检查两个跨度。随后 `SplitByRowSpan(1)` 将第 2、3 行分离用于产品名称。对于水平的两列合并，请改用 `SplitByColSpan(1)`。

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

    // 检索拆分后表格中得到的单元格。
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

表格网格及其周围单元格索引保持不变。可通过坐标检索得到的单元格；此处两者的跨度均为 1，且 [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) 输出 `False`。更大的区域在一次拆分后仍可能部分保留合并状态。

原始文本及其格式保留在上（或左）单元格；新单元格为空，但继承单元格的格式，如填充、边框和边距。拆分后填充单元格并显式设置所需的文本格式。

已保存的演示文稿包含独立的 "Product A" 和 "Product B" 单元格，保留了模板的单元格格式。详见[单元格 API 参考](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)。

### **按特定高度拆分单元格**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) 以点为单位接受上半部分的高度。[SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) 以上半部分的现有网格行数为参数。要将 40 点的单元格居中到右侧列，需要从单元格实际高度中减去 40，并将剩余空间在上下等分。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

第一次拆分会添加一行网格，使下部在 `(1, 1)` 处保留 90 点。第二次拆分针对该单元格，再在其下方添加一行。右侧列现在包含 `(1, 0)`（50 点，`margin`）、 `(1, 1)`（40 点）和 `(1, 2)`（50 点，`margin`）。左侧单元格跨越所有三行，原始高度为 140 点。

![左侧单元格跨越整个表格高度，旁边有三个单元格，中间为 Middle。](split-by-height.png)

## **更改表格单元格背景颜色**

本示例创建了一个列宽 150 点、行高 50 点的表格。它使用[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) 选择实心填充，并通过[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) 访问填充颜色，将单元格 `(2, 3)`（第 3 列第 4 行）的颜色设置为红色。

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

## **在表格单元格中添加图像**

在运行本示例前，请将输入图像放置于工作目录。它使用[Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) 加载图像，并通过[AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) 将其添加到演示文稿的图像集合中。随后将图像分配给单元格 `(0, 0)`（表格中的第一个单元格）的图片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) 将图像拉伸以填充单元格，可能会改变其宽高比。列宽和行高以点为单位。加载的图像在添加到演示文稿后即被释放。

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

## **常见问题**

**我可以为单个单元格的不同边设置不同的线条粗细和样式吗？**

是的。单元格的[上](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[下](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[左](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[右](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) 边框拥有各自的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行尺寸，图像会怎样？**

行为取决于[填充模式](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)。使用拉伸时，图像会适应新的单元格；使用平铺时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/cpp/manage-hyperlinks/) 可以在单元格文本框内部的文本（段落）级别或整个表格/形状级别设置。实践中，您可以将链接分配给某个段落或单元格中的全部文本。

**我可以在单个单元格中设置不同的字体吗？**

是的。单元格的文本框支持具有独立格式的[段落](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（运行），包括字体系列、样式、大小和颜色。