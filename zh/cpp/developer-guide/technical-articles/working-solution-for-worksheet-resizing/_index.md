---
title: 工作表尺寸调整的可行方案
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
description: "在 PowerPoint 演示文稿中使用 C++ 的工作表尺寸调整可行方案"
---

{{% alert color="primary" %}}

已观察到，通过 Aspose 组件在 PowerPoint 演示文稿中嵌入的 Excel 工作表作为 OLE 对象，在首次激活后会被调整为未知的比例。此行为导致演示文稿中 OLE 对象的激活前后状态出现明显的视觉差异。我们已对该问题进行了详细调查并提供了解决方案，详见本文。

{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh/cpp/manage-ole/)中，我们解释了如何使用 Aspose.Slides for C++向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在生成的演示文稿中，当双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任意更改，然后通过点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整因子会根据 OLE 对象框的大小和嵌入的 Excel 工作簿的大小而有所不同。

## **调整原因**

由于 Excel 工作簿拥有自己的窗口大小，它在首次激活时会尝试保留原始尺寸。另一方面，OLE 对象框也有其自身的大小。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。调整是基于 Excel 窗口大小与 OLE 对象框的大小和位置之间的差异而发生的。

## **可行方案**

有两种可能的解决方案可以避免此调整效果。

- 在 PowerPoint 演示文稿中缩放 OLE 框的大小，使其匹配 OLE 框中所需行数和列数的高度和宽度。
- 保持 OLE 框大小不变，缩放参与的行和列的大小，以适应所选 OLE 框的尺寸。

### **缩放 OLE 框大小**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿的 OLE 框大小，使其匹配 Excel 工作表中参与行和列的累计大小。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在这种情况下，OLE 对象框的大小将首先根据工作簿中参与的行的累计行高和列的累计列宽进行计算。然后，我们将把 OLE 框的大小设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色的“EMBEDDED OLE OBJECT”提示，我们还将捕获工作簿中所需行列的图像，并将其设为 OLE 框的图片。

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 设置工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示尺寸。
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

// 创建 OLE 对象框架。
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

在此方法中，我们将学习如何缩放参与行的高度和参与列的宽度，以匹配自定义的 OLE 框大小。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在此情形下，我们将设置 OLE 框的大小，并缩放参与 OLE 框区域的行和列的尺寸。随后，我们将工作簿保存到流中以应用更改，并转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框出现红色的“EMBEDDED OLE OBJECT”提示，我们还将捕获工作簿中所需行列的图像，并将其设为 OLE 框的图片。

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 当工作簿文件在 PowerPoint 中用作 OLE 对象时，设置显示尺寸。
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 按框架尺寸缩放单元格范围。
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

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

```cpp
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

{{% alert color="primary" %}}

有两种方法可以解决工作表调整问题。选择合适的方法取决于具体需求和使用场景。两种方法的工作方式相同，无论演示文稿是基于模板还是从头创建。此外，此方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

出现此情况是因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框有其自身的尺寸。PowerPoint 与 Excel 会协商尺寸以保持长宽比，这可能导致调整。

**是否可以完全防止此调整问题？**

可以。通过将 OLE 框缩放以适配 Excel 单元格范围的大小，或将单元格范围缩放以适配所需的 OLE 框大小，可防止不必要的调整。

**我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果希望保持原始 Excel 行列的尺寸，请选择**OLE 框缩放**。如果希望在演示文稿中获得固定大小的 OLE 框，请选择**单元格范围缩放**。

**这些解决方案在基于模板的演示文稿中也适用吗？**

是的。两种方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的大小是否有限制？**

没有限制。只要适当设置比例，OLE 对象框可以任意大小。

**有没有办法避免 PowerPoint 中的“EMBEDDED OLE OBJECT”占位文本？**

可以。通过对目标 Excel 单元格范围进行快照并将其设为 OLE 框的占位图像，您可以用自定义预览图像替代默认的占位文本。

## **相关文章**

[创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)