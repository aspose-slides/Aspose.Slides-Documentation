---
title: 工作表大小调整的可行方案
type: docs
weight: 130
url: /zh/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像调整大小
- Excel
- 工作表
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for C++
description: "使用 C++ 在 PowerPoint 演示文稿中进行工作表大小调整的可行方案"
---
{{% alert color="info" title="Note" %}}
使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，首次激活后可能会出现意外的大小调整。此行为导致 OLE 对象在激活前后出现显著的视觉差异。本文解释了此问题并描述了两种解决方法。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh/cpp/manage-ole/)中，我们讲解了如何使用 Aspose.Slides for C++ 将 OLE 框添加到 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，当您双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任何所需的更改，然后通过单击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整大小的因素会根据 OLE 对象框的大小和嵌入的 Excel 工作簿的大小而有所不同。

## **调整大小的原因**

由于 Excel 工作簿拥有自己的窗口大小，它会在首次激活时尝试保持原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。调整大小是基于 Excel 窗口尺寸与 OLE 对象框的尺寸和位置之间的差异而发生的。

## **可行方案**

有两种可能的解决方案可以避免此调整大小效果。

- 在 PowerPoint 演示文稿中缩放 OLE 框，使其匹配所选行列的总高度和宽度。
- 保持 OLE 框尺寸不变，并缩放所选的行和列以适应框内。

### **缩放 OLE 框大小**

此方法将 OLE 框的大小设置为匹配嵌入的 Excel 工作表中所选行列的总高度和宽度。

示例加载现有的 Excel 工作簿，并使用零基索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 定义了要显示的范围。预览以 96 DPI 渲染，并使用每英寸 72 点将像素尺寸转换为点。[ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) 将修改后的工作簿嵌入到具有该尺寸的框中。预览通过[OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) 分配，以替换已保存演示文稿中的 “EMBEDDED OLE OBJECT” 占位符。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 在 PowerPoint 中将工作簿文件用作 OLE 对象时设置显示大小。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// 获取 OLE 图像的宽度和高度（单位：点）。
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// 我们需要使用已修改的工作簿。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 将 OLE 图像添加到演示文稿资源中。
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// 创建 OLE 对象框。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

预览助手使用[PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) 选择范围并移除页边距、页眉和页脚。启用[ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) 后，[SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) 将范围渲染为 PNG 图像。助手将渲染的图像数据复制到一个新的内存流，并将其定位在开头，以供演示文稿使用。

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **缩放单元格范围大小**

此方法将所选行的高度和所选列的宽度进行缩放，以匹配自定义的 OLE 框大小。

示例加载现有的 Excel 工作簿，并使用零基索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) 定义了要显示的范围，以下助手将该范围缩放以适应宽 400 点、高 100 点的框。将修改后的工作簿保存为字节数组后，[ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) 按指定大小嵌入其中。通过[OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) 分配的预览以 96 DPI 渲染，因此已保存的演示文稿显示所选单元格而不是默认占位符。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 在 PowerPoint 中将工作簿文件用作 OLE 对象时设置显示大小。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 将单元格范围缩放以适应框的大小。
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 我们需要使用已修改的工作簿。
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 将 OLE 图像添加到演示文稿资源中。
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// 创建 OLE 对象框。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

缩放助手为所选范围计算单独的宽度和高度比例，保持列的相对宽度和行的相对高度。它在使用[Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/)和[Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) 应用之前，将计算得到的尺寸从点转换为英寸。所选范围的宽度和高度必须非零。

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">单元格范围的预期宽度（单位：点）。</param>
/// <param name="height">单元格范围的预期高度（单位：点）。</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

此预览助手使用[SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) 渲染已调整大小的范围。它使用[PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) 将打印限制在该范围内，移除页边距、页眉和页脚，并返回定位在开头的 PNG 流。

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **结论**

{{% alert color="info" title="Note" %}}
有两种方法可以解决工作表大小调整问题。请选择最符合您需求和使用场景的方法。无论演示文稿是从模板创建还是从头开始，两种方法的工作方式相同。此外，此解决方案对 OLE 对象框的大小没有限制。
{{% /alert %}}

## **常见问题**

**为什么在 PowerPoint 中首次激活嵌入的 Excel 工作表时会改变大小？**

这是因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框有其自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，这可能导致大小调整。

**是否可以完全防止此大小调整问题？**

可以。通过将 OLE 框缩放至适合 Excel 单元格范围的大小，或将单元格范围缩放至所需的 OLE 框大小，您可以防止不必要的大小调整。

**我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果希望保持原始的 Excel 行列大小，请选择 **OLE 框缩放**。如果希望在演示文稿中获得固定的 OLE 框大小，请选择 **单元格范围缩放**。

**如果我的演示文稿基于模板，这些解决方案是否有效？**

是的。这两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的大小是否有限制？**

没有限制。只要适当地设置比例，OLE 对象框可以任意大小。

**是否有办法避免 PowerPoint 中的 “EMBEDDED OLE OBJECT” 占位符文本？**

可以。通过对目标 Excel 单元格范围进行截图并将其设置为 OLE 框的占位图像，您可以在默认占位符位置显示自定义预览图像。

## **相关文章**

[创建 Excel 图表并将其作为 OLE 对象嵌入到演示文稿中](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)