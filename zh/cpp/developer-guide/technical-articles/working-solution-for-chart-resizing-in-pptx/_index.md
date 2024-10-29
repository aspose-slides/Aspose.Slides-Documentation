---
title: PPTX 中图表大小调整的有效解决方案
type: docs
weight: 60
url: /zh/cpp/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

已观察到，通过 Aspose 组件在 PowerPoint 演示文稿中作为 OLE 嵌入的 Excel 图表在第一次激活后被调整为未知比例。此行为在图表激活状态之前和之后之间造成了演示文稿的显著视觉差异。Aspose 团队在 Microsoft 团队的帮助下详细调查了此问题并找到了解决方案。本文涵盖了此问题的原因和解决方案。 

{{% /alert %}} 
## **背景**
在 [上一篇文章](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) 中，我们解释了如何使用 Aspose.Cells for C++ 创建 Excel 图表，并进一步使用 Aspose.Slides for C++ 将该图表嵌入到 PowerPoint 演示文稿中。为了适应对象变化的问题，我们将图表图像分配给图表 OLE 对象框。在输出演示文稿中，当我们双击显示图表图像的 OLE 对象框时，Excel 图表被激活。最终用户可以在实际的 Excel 工作簿中进行任何所需的更改，然后通过单击激活的 Excel 工作簿外部返回到相关幻灯片。当用户返回到幻灯片时，OLE 对象框的大小将会改变。OLE 对象框的不同大小和嵌入的 Excel 工作簿的大小将导致不同的调整比例。

## **调整原因**
由于 Excel 工作簿具有自己的窗口大小，它尝试在第一次激活时保留其原始大小。另一方面，OLE 对象框将具有其自己的大小。根据 Microsoft 的说法，在激活 Excel 工作簿时，Excel 和 PowerPoint 会协商大小并确保其在嵌入操作中处于正确的比例。根据 Excel 窗口大小和 OLE 对象框的大小/位置之间的差异，发生调整。

## **有效解决方案**
使用 Aspose.Slides for C++ 创建 PowerPoint 演示文稿有两种可能的方案。

**方案 1：** 基于现有模板创建演示文稿。

**方案 2：** 从头开始创建演示文稿。

我们将在这里提供的解决方案适用于这两种方案。所有解决方案方法的基础将是相同的。即：**嵌入的 OLE 对象窗口大小应与 PowerPoint 幻灯片中的 OLE 对象框大小相同**。现在，我们将讨论解决方案的两种方法。

## **第一种方法**
在此方法中，我们将学习如何将嵌入式 Excel 工作簿的窗口大小设置为与 PowerPoint 幻灯片中的 OLE 对象框大小相同。

**方案 1** 

假设我们定义了一个模板并希望基于此模板创建演示文稿。假设模板中索引为 2 的位置有一个形状，我们希望在该位置放置一个 OLE 框以容纳嵌入的 Excel 工作簿。在此方案中，OLE 对象框的大小将被视为预定义（即模板中索引为 2 的形状的大小）。我们需要做的就是：将工作簿的窗口大小设置为形状的大小。以下代码片段将达到此目的： 

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
// 定义带有窗口的图表大小 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shapes()->idx_get(2);

// 将工作簿的窗口宽度设置为英寸（除以 72，因为 PowerPoint 使用 
// 72 像素/英寸）
wb->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// 将工作簿的窗口高度设置为英寸
wb->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// 实例化 MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream3(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 创建带有嵌入 Excel 的 OLE 对象框
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(), 
	shape->get_Height(),
	dataInfo);
```

**方案 2** 

假设我们希望从头创建演示文稿，并希望任何大小的 OLE 对象框中嵌入 Excel 工作簿。在以下代码片段中，我们在 x 轴=0.5 英寸和 y 轴=1 英寸的幻灯片中创建了一个高度为 4 英寸、宽度为 9.5 英寸的 OLE 对象框。此外，我们设置了相应的 Excel 工作簿窗口大小，即：高度 4 英寸和宽度 9.5 英寸。 

``` cpp
// 我们期望的高度
int32_t desiredHeight = 288; // 4 英寸 (4 * 72)

// 我们期望的宽度
int32_t desiredWidth = 684; // 9.5 英寸 (9.5 * 72)

// 定义带有窗口的图表大小 
chart->SetSizeWithWindow(true);

// 将工作簿的窗口宽度设置为英寸
wb->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// 将工作簿的窗口高度设置为英寸
wb->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// 实例化 MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 创建带有嵌入 Excel 的 OLE 对象框
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f,
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```


## **第二种方法**
在此方法中，我们将学习如何将嵌入式 Excel 工作簿中图表的大小设置为与 PowerPoint 幻灯片中的 OLE 对象框大小相同。当图表的大小事先已知并且永远不会改变时，此方法非常有用。

**方案 1** 

假设我们定义了一个模板并希望基于此模板创建演示文稿。假设模板中索引为 2 的位置有一个形状，我们希望在该位置放置一个 OLE 框以容纳嵌入的 Excel 工作簿。在此方案中，OLE 框的大小将被视为预定义（即模板中索引为 2 的形状的大小）。我们需要做的就是：将工作簿中图表的大小设置为形状的大小。以下代码片段将达到此目的： 

``` cpp
// 定义不带窗口的图表大小 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shapes()->idx_get(2);

// 以像素为单位设置图表宽度（乘以 96，因为 Excel 使用 96 像素每英寸）    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// 以像素为单位设置图表高度
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// 定义图表打印大小
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// 实例化 MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 创建带有嵌入 Excel 的 OLE 对象框
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	shape->get_X(), 
	shape->get_Y(), 
	shape->get_Width(),
	shape->get_Height(),
	dataInfo);
```

**方案 2** 

假设我们希望从头创建演示文稿，并希望任何大小的 OLE 对象框中嵌入 Excel 工作簿。在以下代码片段中，我们在 x 轴=0.5 英寸和 y 轴=1 英寸的幻灯片中创建了一个高度为 4 英寸、宽度为 9.5 英寸的 OLE 对象框。此外，我们设置了相应的图表大小，即：高度 4 英寸和宽度 9.5 英寸。 

``` cpp
// 我们期望的高度
int32_t desiredHeight = 288; // 4 英寸 (4 * 576)

// 我们期望的宽度
int32_t desiredWidth = 684; // 9.5 英寸(9.5 * 576)

// 定义不带窗口的图表大小 
chart->SetSizeWithWindow(false);

// 以像素为单位设置图表宽度    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// 以像素为单位设置图表高度    
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// 实例化 MemoryStream
System::SharedPtr<System::IO::MemoryStream> ms = ToSlidesMemoryStream(wb->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(ms->ToArray(), u"xls");

// 创建带有嵌入 Excel 的 OLE 对象框
System::SharedPtr<IOleObjectFrame> objFrame = slide->get_Shapes()->AddOleObjectFrame(
	36.0f, 
	72.0f, 
	desiredWidth, 
	desiredHeight,
	dataInfo);
```

## **结论**
{{% alert color="primary" %}} 

有两种方法可以解决图表调整大小的问题。选择适当的方法取决于需求和用例。无论是从模板创建演示文稿还是从头创建演示文稿，两种方法的工作方式都是相同的。此外，解决方案中没有 OLE 对象框大小的限制。 

{{% /alert %}} 
## **相关部分**
[创建并将 Excel 图表嵌入演示文稿中的 OLE 对象](https://docs.aspose.com/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)