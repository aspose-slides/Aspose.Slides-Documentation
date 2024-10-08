---
title: PPTX中图表调整大小的解决方案
type: docs
weight: 60
url: /zh/net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

观察到通过Aspose组件嵌入到PowerPoint演示文稿中的Excel图表在首次激活后会被调整到不明确的比例。这种行为在图表激活前后的演示文稿之间造成了显著的视觉差异。Aspose团队在Microsoft团队的帮助下对此问题进行了详细调查，并找到了问题的解决方案。本文涵盖了此问题的原因和解决方案。

{{% /alert %}} 
## **背景**
在[上一篇文章](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用Aspose.Cells for .NET创建Excel图表，并进一步使用Aspose.Slides for .NET将该图表嵌入PowerPoint演示文稿。为了处理[对象变化问题](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)，我们将图表图像分配给图表OLE对象框。在输出的演示文稿中，当我们双击显示图表图像的OLE对象框时，Excel图表被激活。最终用户可以在实际的Excel工作簿中进行任何所需的更改，然后通过点击激活的Excel工作簿外部返回到相关幻灯片。当用户返回到幻灯片时，OLE对象框的大小会发生变化。不同大小的OLE对象框和嵌入式Excel工作簿的调整大小因素会有所不同。
## **调整大小的原因**
由于Excel工作簿有其自己的窗口大小，它尝试在首次激活时保持其原始大小。另一方面，OLE对象框将有其自己的大小。根据Microsoft的说法，在激活Excel工作簿时，Excel和PowerPoint会协商大小，并确保其在嵌入操作中保持正确的比例。根据Excel窗口大小与OLE对象框大小/位置的不同，发生调整大小。
## **有效解决方案**
使用Aspose.Slides for .NET创建PowerPoint演示文稿有两种可能的场景。

**场景1：** 基于现有模板创建演示文稿

**场景2：** 从头开始创建演示文稿。

我们将在这里提供的解决方案适用于这两种场景。所有解决方案方法的基础将是相同的。也就是说：**嵌入的OLE对象窗口大小应与PowerPoint幻灯片中的OLE对象框相同**。现在，我们将讨论解决方案的两种方法。
## **第一种方法**
在此方法中，我们将学习如何将嵌入的Excel工作簿的窗口大小设置为与PowerPoint幻灯片中的OLE对象框相等。

**场景1**

假设我们已定义一个模板，并希望基于该模板创建演示文稿。假设模板中索引为2的位置有某个形状，我们希望在该位置放置一个承载嵌入式Excel工作簿的OLE框。在此场景中，OLE对象框的大小将被认为是预定义的（即模板中索引为2的形状的大小）。我们要做的就是将工作簿的窗口大小设置为与形状的大小相等。以下代码片段将实现此目的：

```c#
//定义图表大小与窗口 
chart.SizeWithWindow = true;

//将工作簿的窗口宽度设置为英寸（除以72，因为PowerPoint使用
//每英寸72像素）
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//将工作簿的窗口高度设置为英寸
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//实例化MemoryStream
MemoryStream ms = wb.SaveToStream();

//创建一个带有嵌入Excel的OLE对象框
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**场景2**

假设我们希望从头开始创建一个演示文稿，并希望OLE对象框具有任何大小，并嵌入Excel工作簿。在以下代码片段中，我们在幻灯片的x轴=0.5英寸和y轴=1英寸的位置创建了一个高度为4英寸和宽度为9.5英寸的OLE对象框。此外，我们设置了相应的Excel工作簿窗口大小，即：高度为4英寸，宽度为9.5英寸。

```c#
 //我们期望的高度
int desiredHeight = 288;//4英寸（4 * 72）

//我们期望的宽度
int desiredWidth = 684;//9.5英寸（9.5 * 72）

//定义图表大小与窗口
chart.SizeWithWindow = true;

//将工作簿的窗口宽度设置为英寸
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//将工作簿的窗口高度设置为英寸
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//实例化MemoryStream
MemoryStream ms = wb.SaveToStream();

//创建一个带有嵌入Excel的OLE对象框
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```

## **第二种方法**
在此方法中，我们将学习如何将嵌入Excel工作簿中的图表大小设置为与PowerPoint幻灯片中的OLE对象框相等。当图表的大小在前期已知且不会改变时，此方法非常有用。

**场景1**

假设我们已定义一个模板，并希望基于该模板创建演示文稿。假设模板中索引为2的位置有某个形状，我们希望在该位置放置一个承载嵌入式Excel工作簿的OLE框。在此场景中，OLE框的大小将被认为是预定义的（即模板中索引为2的形状的大小）。我们要做的就是将工作簿中的图表大小设置为与形状的大小相等。以下代码片段将实现此目的：

```c#
//定义图表大小不与窗口 
chart.SizeWithWindow = false;

//以像素为单位设置图表宽度（乘以96，因为Excel使用96每英寸像素）    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//以像素为单位设置图表高度
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//定义图表打印大小
chart.PrintSize = PrintSizeType.Custom;

//实例化MemoryStream
MemoryStream ms = wb.SaveToStream();

//创建一个带有嵌入Excel的OLE对象框
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());

```

**场景2**

假设我们希望从头开始创建一个演示文稿，并希望OLE对象框具有任何大小，并嵌入Excel工作簿。在以下代码片段中，我们在幻灯片的x轴=0.5英寸和y轴=1英寸的位置创建了一个高度为4英寸和宽度为9.5英寸的OLE对象框。此外，我们设置了相应的图表大小，即：高度为4英寸，宽度为9.5英寸。

```c#
 //我们期望的高度
int desiredHeight = 288;//4英寸（4 * 576）

//我们期望的宽度
int desiredWidth = 684;//9.5英寸（9.5 * 576）

//定义图表大小不与窗口 
chart.SizeWithWindow = false;

//以像素为单位设置图表宽度    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//以像素为单位设置图表高度    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//实例化MemoryStream
MemoryStream ms = wb.SaveToStream();

//创建一个带有嵌入Excel的OLE对象框
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```

## **结论**
{{% alert color="primary" %}} 

有两种方法可以解决图表调整大小的问题。选择合适的方法取决于需求和用例。无论演示文稿是从模板创建还是从头创建，这两种方法都以相同的方式工作。而且，解决方案中没有OLE对象框大小的限制。

{{% /alert %}} 
## **相关部分**
[在演示文稿中创建并嵌入Excel图表作为OLE对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[自动更新OLE对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)