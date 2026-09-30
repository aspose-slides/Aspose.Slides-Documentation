---
title: 使用 C++ 管理 PowerPoint 表格中的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/cpp/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 首行
- 表格标题
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文本格式化
- 列文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 中管理表格的行和列，并加快演示文稿的编辑和数据更新。"
---
## **简介**

Aspose.Slides for C++ 让您通过 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 类和 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口在 PowerPoint 演示文稿中管理表格结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文通过 C++ 示例解释这些操作。它还展示了如何检索表格的样式预设以便重复使用。表格行列索引从零开始。

## **控制行高**

使用 [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) 设置行的最小高度（单位为点）。它是下限，而非固定高度。 [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) 返回实际高度；该值不能直接设置。通过 [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，该文件在首张幻灯片的第一个形状中包含一个表格。其首行高度为 70 点。单元格使用 18 点 Arial 文本，自动换行，顶部和底部边距为 6 点；第二列的较长文本会换成多行。示例将最小高度提高到 100 点，然后降低到 20 点，每次更改后打印实际高度，并保存两种结果。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

使用提供的演示文稿时，增大最小值会为行添加空间。减小最小值会去除该额外空间，但实际高度仍大于 20 点，因为文本和单元格边距需要更多空间。仅降低最小值无法将行高度压低到内容所需空间以下。

实际高度受多个因素影响：

- **文本和字体大小**：更长的文本、显式换行或更大的字体会占用更多垂直空间。
- **换行和列宽**：启用换行后，使用 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) 减小列宽会产生更多行。更宽的列可以降低垂直空间需求。
- **单元格边距**：[ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) 和 [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) 控制增加垂直空间的边距。[ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) 和 [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) 控制水平边距，会影响文本可用宽度并可能导致额外换行。

对于此未合并单元格的表格，需要最多垂直空间的单元格决定整行的内容驱动下限。若要使行更短，可能还需缩短文本、减小字体或边距，或加宽列。

下图展示了相同比例下的同一表格。参考 .NET 运行示例中的实际高度分别为 70、100 和 55.2 点：最终行仍高于其 20 点的最小值。具体文本度量可能随您环境中的字体而异。下载保存结果：[增加最小值](row-height-increased.pptx) 和 [减少最小值](row-height-decreased.pptx)。

| 原始：最小值 70 pt，实际 70 pt | 增加：最小值 100 pt，实际 100 pt | 减少：最小值 20 pt，实际 55.2 pt |
| --- | --- | --- |
| ![原始表格，首行 70 点。](row-height-before.png) | ![将首行最小值增加到 100 点后的表格。](row-height-increased.png) | ![将首行最小值减小到 20 点后的表格；换行文本使行高仍高于最小值。](row-height-decreased.png) |

## **将首行设为标题**

使用 [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) 方法将首行标记为标题格式。其外观取决于表格所应用的表格样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 访问存储在幻灯片上第一形状的表格。
4. 为其首行启用标题格式。
5. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中首张幻灯片的第一形状是表格。它为首行启用标题格式并保存为 `First_row_header.pptx`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **克隆表格行或列**

克隆行或列以重用其内容和格式。您可以将副本追加到表格末尾，或插入到指定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法添加表格。
5. 克隆所需的行。
6. 克隆所需的列。
7. 保存修改后的演示文稿。

示例需要 `Test.pptx`，其中至少包含一张幻灯片。它创建一个三列五行的表格，尺寸以点为单位。示例将首行和首列的副本追加，然后在索引 3（第四位置）插入第二行和第二列的副本。生成的表格具有七行五列。`false` 参数禁用对相邻合并行或列的克隆；此表格无合并单元格。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除项会导致后续行或列的索引移动。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类创建演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法添加表格。
5. 删除第二行和第二列。
6. 保存修改后的演示文稿。

此示例创建一个三乘三的表格并删除索引为 1 的行和列，留下一个二乘二的表格，保存为 `TestTable_out.pptx`。尺寸以点为单位。`false` 参数禁用对相邻合并行或列的删除；此表格无合并单元格。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **在表格行级别设置文本格式**

对整行应用文本格式以保持单元格一致。您可以设置字体属性、段落格式和文本方向，而无需对每个单元格单独格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 为首行设置字体高度。
4. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 为首行设置对齐方式和右段落边距。
5. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 为第二行设置文本方向。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中首张幻灯片的第一形状是表格且至少有两行。它为首行应用 25 点文本、右对齐和 20 点右段落边距，然后为第二行设置垂直文本。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRrow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **在表格列级别设置文本格式**

对整列应用文本格式以保持单元格一致。您可以设置字体属性、段落格式和文本方向，而无需对每个单元格单独格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 使用 [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 为首列设置字体高度。
4. 使用 [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) 为首列设置对齐方式和右段落边距。
5. 使用 [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) 为第二列设置文本方向。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中首张幻灯片的第一形状是表格且至少有两列。它为首列应用 25 点文本、右对齐和 20 点右段落边距，然后为第二列设置垂直文本。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **获取表格样式属性**

使用 [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) 方法检索已应用于表格的预设样式，以便在另一表格上重复使用。该方法返回预设标识，而不是单元格的个别格式覆盖。

示例创建一个表格，应用 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) 并读取回预设。它打印 `DarkStyle1` 并将表格保存为 `table.pptx`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **常见问题**

**我可以将 PowerPoint 主题/样式应用于已经创建的表格吗？**

可以。表格会继承幻灯片/版面/母版的主题，您仍然可以在此基础上覆盖填充、边框和文本颜色。

**我可以像在 Excel 中那样对表格行进行排序吗？**

不能，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用带状（条纹）列吗？**

可以。启用带状列后，仍可对特定单元格应用本地格式；单元格级别的格式会优先于表格样式。