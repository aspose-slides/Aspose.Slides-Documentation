---
title: 在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象
type: docs
weight: 40
url: /zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Cells for C++ 创建 Excel 图表，并将工作簿嵌入到 PowerPoint 演示文稿中（使用 Aspose.Slides），包括图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for C++ 创建 Excel 柱状图，并使用 Aspose.Slides for C++ 将其工作簿嵌入到 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。单独的 PNG 预览在 OLE 对象激活之前显示在幻灯片上。

结果是一个嵌入的 Excel 对象，而不是原生的 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

在 C++ 项目中配置 Aspose.Cells for C++ 和 Aspose.Slides for C++ 的头文件和库。将示例代码放在应用程序入口点处，include 声明位于文件作用域。生成演示文稿时不需要 Microsoft Office。

不需要输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。运行时请为两个产品应用许可证，以脱离评估模式。

## **嵌入工作原理**

1. 创建一个包含数据工作表和图表工作表的工作簿。  
2. 将图表工作表设为活动工作表，使工作簿在打开时显示图表。  
3. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。  
4. 将工作簿以 XLSX 格式保存在内存中，并将这些字节嵌入到幻灯片。  
5. 将 PNG 设为 OLE 对象的预览图像并将演示文稿保存为 PPTX。

工作簿显示范围和幻灯片框架具有不同的角色。 [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 使用零基的起始/结束行列索引。 [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) 则使用顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界；这些值是布局选择，而非数据行列的数量。

幻灯片框架使用点（points）。示例将其放置在幻灯片内部并居中，同时保持 PNG 的宽高比，而不是将预览拉伸填满幻灯片。

## **创建并嵌入图表**

以下完整示例向 `DataSheet` 填充四行五列的值。每一行成为图表的一个系列。`ChartSheet` 在保存工作簿之前被选为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 从内存流加载，无需中间位图转换。Aspose.Cells 返回字节向量，示例将其复制到 Aspose.Slides 接受的数组类型。使用对象前先初始化 Aspose.Cells，并在对象销毁后释放其资源。通过 [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) 赋值可替换默认的 OLE 占位符。

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // 渲染图表预览并单独序列化可编辑的工作簿。
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // 将 Cells 缓冲区复制到 Slides 使用的数组类型中。
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // 将预览适配到幻灯片内，保持宽高比不变。
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// 在所有 Cells 对象销毁后释放 Cells 资源。
Aspose::Cells::Cleanup();
```

## **预期结果**

`OutputChart.pptx` 包含一张幻灯片，内嵌 Excel 工作簿并显示图表预览。工作簿包含原始数据和一个四系列的柱状图。预览居中显示并保留比例。

![Excel 柱状图显示为嵌入工作簿的预览](excel-chart-ole-preview.png)

在兼容的桌面 PowerPoint 环境并且安装了 Excel 时，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和幻灯片预览是分离的内容。提供图表图像可让幻灯片显示图表，而不是默认的 “EMBEDDED OLE OBJECT” 占位符。参见[添加 OleObjectFrame 时的对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)。

**在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。程序化更新工作簿数据后，需要重新生成图表图像并同时替换预览以及嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际的工作簿格式匹配，仅更改扩展名并不能转换数据。

**为什么对象在激活后可能会改变大小？**

宿主应用在激活工作簿时可能会更新 OLE 对象的呈现。工作簿的 OLE 显示范围和幻灯片框架尺寸都会影响结果。参见[工作解决方案：PPTX 中图表大小调整](/slides/zh/cpp/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [工作解决方案：PPTX 中图表大小调整](/slides/zh/cpp/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)