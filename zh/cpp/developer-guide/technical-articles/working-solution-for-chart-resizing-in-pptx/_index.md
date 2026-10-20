---
title: PowerPoint 中图表大小调整的工作方案
type: docs
weight: 60
url: /zh/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表大小调整。设置固定的图表尺寸，以保持图表和 OLE 框尺寸一致。"
---
## **背景**

使用 Aspose 组件在 PowerPoint 演示文稿中嵌入为 OLE 对象的 Excel 图表在首次激活后可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文解释了导致大小调整的原因，并展示了通过将固定的图表尺寸匹配到 OLE 框来防止此问题的方法。

在[创建 Excel 图表并将其嵌入为 OLE 对象的演示文稿](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用 Aspose.Cells for C++ 创建 Excel 图表并使用 Aspose.Slides for C++ 将其嵌入到 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框时，Excel 图表会被激活。用户可以编辑嵌入的 Excel 工作簿，然后通过单击激活的工作簿外部返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且调整因子取决于 OLE 对象框和嵌入的 Excel 工作簿的原始尺寸。

## **大小调整的原因**

嵌入的 Excel 工作簿拥有自己的窗口尺寸，Excel 在对象首次激活时会尝试保留该尺寸。幻灯片上的 OLE 框则有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 协商对象的大小，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异会导致对象调整大小。

## **可行的解决方案**

将图表尺寸匹配到幻灯片上的 OLE 框，并使图表尺寸独立于工作簿窗口。此解决方案适用于新建演示文稿或现有模板。

示例需要 Aspose.Cells for C++ 和 Aspose.Slides for C++。它在活动图表工作表上创建一个简单的柱形图并以 XLS 格式嵌入工作簿。未分配图表预览图像；图表在 PowerPoint 中激活 OLE 对象时可见。

将示例代码放在应用程序入口点，并在文件作用域声明 include。创建对象前先初始化 Aspose.Cells，销毁对象后释放其资源。示例将 Aspose.Cells 返回的工作簿字节向量复制到 Aspose.Slides 接受的数组类型中。

示例创建了一个新的演示文稿，其中 OLE 框大小为 9.5 × 4 英寸，位置距左边缘 0.5 英寸，距顶部 1 英寸。幻灯片坐标和尺寸使用点 (每英寸 72 点) 表示。对于已有演示文稿，请参见[使用模板](#use-a-template)。

## **设置固定的图表尺寸**

将 [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) 设置为 false，以使图表尺寸独立于工作簿窗口。通过 [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) 并使用 [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) 和 [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/) 来设置其尺寸，将点转换为每英寸 96 像素：尺寸为 684 × 288 点的框对应于 912 × 384 像素的图表。将 [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) 设置为 [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/) 的 Custom 值。示例使用 [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) 嵌入工作簿，并保存一个具有 9.5 × 4 英寸 OLE 框的演示文稿。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 幻灯片坐标和尺寸以点为单位（每英寸 72 点）。
    auto width = 684.f; // 9.5 英寸。
    auto height = 288.f; // 4 英寸。

    chart.SetSizeWithWindow(false);
    // 使用每英寸 96 像素将点转换为图表像素。
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // 将 Cells 字节向量复制到 Slides 接受的数组类型中。
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **使用模板**

现有演示文稿的尺寸逻辑相同。要改编示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。
2. 检查第一张幻灯片是否至少包含三个形状，然后使用索引为 2 的形状作为占位符。
3. 从该形状获取框的宽度和高度，而不是使用固定值 684 和 288。保持尺寸计算不变。
4. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。
5. 在保存演示文稿之前删除占位符。

## **常见问题**

**为什么我的嵌入式 Excel 图表在 PowerPoint 中激活后会改变大小？**

因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 协商尺寸以保持宽高比，这可能导致大小调整。

**如何保持图表和 OLE 框的尺寸一致？**

将图表设置为固定尺寸以匹配 OLE 框，并在嵌入工作簿之前使用自定义的图表打印尺寸。上述示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口大小是否足够？**

仅匹配工作簿窗口大小并不能可靠地防止 OLE 框在激活后改变尺寸。请使用示例中所示的固定图表尺寸。

**此解决方案是否适用于基于模板的演示文稿和新建演示文稿？**

是的。对于模板，使用占位符的尺寸和位置。对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**

示例使用 Aspose.Cells 创建的 Excel 工作簿。它未演示其他电子表格程序的激活行为。

## **相关章节**

- [创建 Excel 图表并将其嵌入为 OLE 对象的演示文稿](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)