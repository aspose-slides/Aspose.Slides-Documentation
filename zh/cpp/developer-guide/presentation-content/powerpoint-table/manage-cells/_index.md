---
title: 使用 C++ 管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/cpp/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 C++ 管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并使用 Aspose.Slides for C++ 设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您在 PowerPoint 演示文稿中访问和修改表格单元格。本文介绍了如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引，以 `(column, row)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

该示例打开现有演示文稿，并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状是表格。然后遍历所有行和列，并使用[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)来识别合并区域中的单元格。对于每个匹配项，它以`row;column`顺序打印单元格坐标、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)，以及区域的起始坐标，[get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 和 [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)。

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

创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)并使用[AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)在其第一张幻灯片上添加表格。列宽、行高和表格位置均以点为单位指定。示例将所有四条单元格边框设置为[FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，使其不可见。

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

## **合并表格单元格**

使用[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/)将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`false` 将合并限制在该范围内。

该示例创建一个 4×4 的表格，列宽和行高均为 70 点，然后将 `(1, 1)` 到 `(2, 2)` 的四个中心单元格合并。结果单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，在本例中使用其左上位置：`table->idx_get(1, 1)`。合并范围内的其他位置仍然是表格网格的一部分，因此范围之外单元格的索引保持不变。

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

在前面的示例中合并单元格后，表格的网格保持不变。拆分单元格可能会在网格中引入新列，并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

此示例创建一个 4×4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用[SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/)。将单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半单元格分别通过 `table->idx_get(1, 1)` 和 `table->idx_get(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用更新后的列索引。

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

### **按行或列跨度拆分合并的单元格**

要为数据填充准备合并的模板单元格，可使用[SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/)沿现有行边界拆分，或使用[SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/)沿列边界拆分。

`index` 参数计数的是拆分上部的行数或左侧的列数，相对于合并区域：

- 行拆分：`0 < index <`[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)。
- 列拆分：`0 < index <`[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，并且 `(1, 2)` 与 `(1, 3)` 垂直合并。从下部位置开始，使用[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 和 [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 定位起始点并检查两个跨距。`SplitByRowSpan(1)` 将第 2 行和第 3 行分离，用于产品名称。对于水平的两列合并，则使用 `SplitByColSpan(1)`。

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

表格网格及其周围的单元格索引保持不变。通过坐标检索得到的单元格均具有跨距 1，且[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/)返回 `False`。更大的区域在一次拆分后仍可能部分保留合并状态。

原始文本及其格式仍保留在上（或左）单元格中；新单元格为空，但继承填充、边框和边距等单元格格式。拆分后填写单元格内容，并显式设置任何所需的文本格式。

保存后的演示文稿包含独立的 “Product A” 与 “Product B” 单元格，且保留了模板单元格的格式。有关详细信息，请参阅[Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)。

## **更改表格单元格背景颜色**

本示例创建一个列宽 150 点、行高 50 点的表格。它使用[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)选择实色填充，并使用[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)获取填充颜色，将 `(2, 3)`（第 3 列第 4 行）的单元格填充为红色。

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

## **在表格单元格内添加图像**

在运行本示例之前，将输入图像放置在工作目录中。示例使用[Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/)加载图像，并通过[AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/)将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)会将图像拉伸以填满单元格，可能会改变其宽高比。列宽和行高均以点为单位。加载的图像在添加到演示文稿后即被释放。

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

是的。[上边缘](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[下边缘](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[左边缘](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[右边缘](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)边框各自拥有独立的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行大小，图像会怎样？**

行为取决于[填充模式](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)(stretch/tile)。使用拉伸时，图像会根据新的单元格大小进行调整；使用平铺时，会重新计算平铺方式。

**我可以为单元格的全部内容分配超链接吗？**

[超链接](/slides/zh/cpp/manage-hyperlinks/)是在单元格文本框的文字（段落）级别或整个表格/形状级别上设置的。实际上，您可以将链接分配给段落或单元格中的全部文字。

**我可以在单个单元格内设置不同的字体吗？**

可以。单元格的文本框支持[段落](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（run），每个段落可以拥有独立的字体系列、样式、大小和颜色。