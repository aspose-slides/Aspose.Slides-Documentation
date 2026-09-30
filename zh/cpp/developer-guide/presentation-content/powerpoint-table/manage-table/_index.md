---
title: 在 C++ 中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/cpp/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流。"
---
## **介绍**

PowerPoint 中的表格将信息组织为行和列，便于阅读和比较数值。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 接口以及其他类型，帮助您在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格并插入文本。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义以磅为单位的列宽数组。
4. 定义以磅为单位的行高数组。
5. 通过 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 以对上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 方法访问合并后的单元格。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 磅处创建一个包含三列五行的表格，使用宽度为 5 磅的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **标准表格中的编号规则**

在标准表格中，单元格索引从零开始，顺序为 (列, 行)。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上图所示的 4 × 4 表格，列宽和行高均为 70 磅，使用宽度为 5 磅的红色单元格边框。坐标仅用于说明单元格索引；示例保持单元格为空，并将表格保存为 `StandardTables_out.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **访问已有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含表格的幻灯片引用。
3. 遍历 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象，找到表格后停止。如果幻灯片包含多个表格，可使用 [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) 来识别所需表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx`，并在第一张幻灯片上找到第一个表格。它将第 0 列第 1 行的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入文件必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列和两行。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

要在已有表格中调整行高并了解实际高度为何可能超过请求的最小值，请参阅 [Control Row Height](/slides/zh/cpp/manage-rows-and-columns/#control-row-height)。

## **查找拥有文本框的单元格**

当通用文本处理代码从表格中获得一个 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 时，使用 [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 获取拥有它的 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)。对于表格单元格的文本框，[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 返回所有者，而 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) 返回 `nullptr`，即使表格本身是形状。

单元格坐标可通过只读的 [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) 和 [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) 方法获取。[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) 还提供只读导航：它返回所有者但不更改所有权。在使用之前始终检查返回的单元格是否为 `nullptr`。

有关完整示例（识别表格单元格和形状所有者，包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/cpp/search-and-replace-text/)。

## **在表格中对齐文本**

您可以控制单个表格单元格的垂直锚定和文本方向。本节示例将第一单元格的文本居中，并将其旋转 270 度。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
4. 从表格中获取一个 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 对象。
5. 获取第一个 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)，并设置其文本和颜色。
6. 使用 [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) 和 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) 设置单元格的垂直锚定和文本方向。
7. 保存修改后的演示文稿。

此示例创建一个 4 × 4 表格，列宽为 120 磅，行高为 100 磅。它对单元格 (0, 0) 中的文本进行格式化，在第一行的其余单元格中添加数值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **在表格级别设置文本格式**

使用 [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) 可对表格中所有单元格应用文本格式。其重载接受段落、文本框和部分的格式设置，无需遍历各个单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 从幻灯片获取一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
4. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 为文本设置字体大小。
5. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 设置段落对齐方式和右边距。
6. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 设置文本方向。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张幻灯片，且其第一形状为表格），将字体大小设置为 25 磅，将段落右对齐并设置右边距为 20 磅，同时使文本垂直显示。格式化后的演示文稿保存为 `result.pptx`。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **获取表格样式属性**

使用 [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) 读取表格的预设样式，使用 [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) 分配样式。本例将 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) 应用于一个表格，打印预设名称，并将相同的预设分配给第二个表格。两个表格均保存在 `table-style.pptx` 中。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比值。使用 [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) 可锁定表格的宽高比。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张幻灯片，且其第一形状为表格），打印当前锁定状态，启用宽高比锁定，打印更新后的状态 (`True`)，并将结果保存为 `pres-out.pptx`。

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **常见问题**

**是否可以为整个表格及其单元格文本启用从右到左 (RTL) 阅读方向？**

可以。表格提供 [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) 方法，段落提供 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/)。同时使用两者可确保单元格内部的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/cpp/applying-protection-to-presentation/) 可禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部将图片作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)，图片将根据所选模式（拉伸或平铺）覆盖单元格区域。