---
title: PPTX 中图表调整大小的可行解决方案
type: docs
weight: 60
url: /zh/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表调整大小
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表调整大小。学习两种代码方法以保持尺寸一致。"
---

## **背景**

已观察到，通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 幻灯片后，在首次激活后会被调整为未指定的比例。这种行为导致图表在激活前后在演示文稿中出现明显的视觉差异。Aspose 团队对该问题进行了详细调查并找到了解决方案。本文描述了问题的原因及相应的修复方法。

在[上一篇文章](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们介绍了如何使用 Aspose.Cells for C++ 创建 Excel 图表并使用 Aspose.Slides for C++ 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/cpp/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象帧。在输出的演示文稿中，当双击显示图表图像的 OLE 对象帧时，Excel 图表会被激活。最终用户可以在底层 Excel 工作簿中进行任意更改，然后通过单击激活的工作簿之外的区域返回相应幻灯片。用户返回幻灯片时，OLE 对象帧的大小会发生变化，且调整比例取决于 OLE 对象帧和嵌入的 Excel 工作簿原始大小的差异。

## **调整大小的原因**

由于 Excel 工作簿拥有自己的窗口大小，它会尝试在首次激活时保留原始大小。而 OLE 对象帧也有其自身的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸并在嵌入过程中保持正确的比例。由于 Excel 窗口大小与 OLE 对象帧的大小或位置存在差异，便会产生调整大小的现象。

## **可行的解决方案**

使用 Aspose.Slides for C++ 创建 PowerPoint 演示文稿有两种可能的场景。

**场景 1：** 基于现有模板创建演示文稿。

**场景 2：** 从零开始创建演示文稿。

我们在此提供的解决方案适用于两种场景。所有解决方案的核心都是相同的：**嵌入的 OLE 对象窗口大小应匹配 PowerPoint 幻灯片中的 OLE 对象帧**。下面将讨论此解决方案的两种实现方式。

## **第一种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿窗口大小，使其与 PowerPoint 幻灯片中 OLE 对象帧的大小相匹配。

**场景 1**

假设我们已定义模板，想基于该模板创建演示文稿。设模板中索引为 2 的形状用于放置包含嵌入 Excel 工作簿的 OLE 帧。在此场景下，OLE 对象帧的大小是预定义的——与模板中索引为 2 的形状大小相同。我们只需将工作簿的窗口大小设为该形状的大小。以下代码片段实现此目的：
```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// 使用窗口定义图表大小。 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// 设置工作簿的窗口宽度（单位为英寸），除以 72，因为 PowerPoint 使用每英寸 72 像素。
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// 设置工作簿的窗口高度（单位为英寸）。
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// 将工作簿保存到内存流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 数据创建 OLE 对象框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```


**场景 2**

假设我们想从零开始创建演示文稿，并在其中加入任意大小的 OLE 对象帧以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象帧。随后将 Excel 工作簿窗口设置为相同的大小——高 4 英寸、宽 9.5 英寸。
```cpp
// 我们期望的高度。
int32_t desiredHeight = 288; // 4 英寸 (4 * 72)

// 我们期望的宽度。
int32_t desiredWidth = 684; // 9.5 英寸 (9.5 * 72)

// 使用窗口定义图表大小。 
chart->SetSizeWithWindow(true);

// 设置工作簿的窗口宽度（单位为英寸）。
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// 设置工作簿的窗口高度（单位为英寸）。
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// 将工作簿保存到内存流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 数据创建 OLE 对象框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **第二种方法**

在此方法中，我们将学习如何将嵌入 Excel 工作簿中图表的大小设置为与 PowerPoint 幻灯片中 OLE 对象帧的大小相匹配。当图表大小事先已知且不会变化时，此方法尤为适用。

**场景 1**

同样假设我们已定义模板，想基于该模板创建演示文稿。设模板中索引为 2 的形状用于放置包含嵌入 Excel 工作簿的 OLE 帧。此时 OLE 帧大小已预定义——与该形状大小相同。我们只需将工作簿中图表的大小设为该形状的大小。以下代码片段实现此目的：
```cpp
// 在没有窗口的情况下定义图表大小。 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// 以像素设置图表宽度（乘以 96，因为 Excel 每英寸使用 96 像素）。    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// 以像素设置图表高度。
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// 定义图表打印尺寸。
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// 将工作簿保存到内存流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 数据创建 OLE 对象框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```


**场景 2**

假设我们从零开始创建演示文稿，并在其中加入任意大小的 OLE 对象帧以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象帧，并将相应图表的大小设置为相同的尺寸：高 4 英寸、宽 9.5 英寸。
```cpp
// 我们期望的高度。
int32_t desiredHeight = 288; // 4 英寸 (4 * 576)

// 我们期望的宽度。
int32_t desiredWidth = 684; // 9.5 英寸 (9.5 * 576)

// 在没有窗口的情况下定义图表大小。 
chart->SetSizeWithWindow(false);

// 以像素设置图表宽度。    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// 以像素设置图表高度。
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// 将工作簿保存到内存流。
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// 使用嵌入的 Excel 数据创建 OLE 对象框架。
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```


## **结论**

解决图表调整大小问题有两种方法。选择哪种方法取决于需求和使用场景。无论是基于模板创建演示文稿还是从头创建，两种方法的工作方式相同，并且对 OLE 对象帧的大小没有限制。

## **常见问答**

**为什么嵌入的 Excel 图表在 PowerPoint 中激活后会改变大小？**

这是因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象帧拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持宽高比，从而导致调整大小。

**是否可以彻底防止此调整大小问题？**

可以。通过在嵌入前将 Excel 工作簿窗口大小或图表大小匹配到 OLE 对象帧的尺寸，即可保持图表尺寸一致。

**应该采用哪种方法：设置工作簿窗口大小还是设置图表大小？**

如果希望保持工作簿的宽高比并可能以后进行调整，请使用**方法 1（窗口大小）**。  
如果图表尺寸固定且在嵌入后不会改变，请使用**方法 2（图表大小）**。

**这些方法是否适用于基于模板的演示文稿和全新创建的演示文稿？**

是的。两种方法在基于模板创建和全新创建的演示文稿中均表现相同。

**OLE 对象帧的大小是否有限制？**

没有限制。只要 OLE 帧的尺寸能够适当地映射到工作簿或图表尺寸，即可设置为任意大小。

**这些方法能否用于其他电子表格程序创建的图表？**

示例针对使用 Aspose.Cells 创建的 Excel 图表，但原理同样适用于其他支持 OLE 的电子表格程序，只要它们提供类似的尺寸设置选项。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其作为 OLE 对象嵌入](/slides/zh/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)