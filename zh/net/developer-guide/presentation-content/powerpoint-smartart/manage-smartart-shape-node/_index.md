---
title: 管理 SmartArt 形状节点
type: docs
weight: 30
url: /zh/net/manage-smartart-shape-node/
keywords:
- SmartArt
- SmartArt 节点
- SmartArt 子节点
- PowerPoint
- 演示文稿
- C#
- C#
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的 SmartArt 节点和子节点"
---

## **添加 SmartArt 节点**
Aspose.Slides for .NET 提供了最简洁的 API，以最容易的方式管理 SmartArt 形状。以下示例代码演示了如何在 SmartArt 形状中添加节点和子节点。

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加新节点并在 TextFrame 中设置文本。
- 现在，在新添加的 SmartArt 节点中添加子节点并在 TextFrame 中设置文本。
- 保存演示文稿。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AddNodes.pptx");

// 遍历第一张幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 添加新的 SmartArt 节点
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // 添加文本
        TemNode.TextFrame.Text = "Test";

        // 在父节点中添加新的子节点。它将被添加到集合的末尾
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // 添加文本
        newNode.TextFrame.Text = "New Node Added";

    }
}

// 保存演示文稿
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **在特定位置添加 SmartArt 节点**
以下示例代码演示了如何在特定位置向 SmartArt 形状的相应节点添加子节点。

- 创建 `Presentation` 类的实例。
- 使用索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状中的第一个节点。
- 在位置 2 处为选定的节点添加子节点并设置其文本。
- 保存演示文稿。
```c#
// 创建演示文稿实例
Presentation pres = new Presentation();

// 访问演示文稿幻灯片
ISlide slide = pres.Slides[0];

// 添加 Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 访问索引 0 处的 SmartArt 节点
ISmartArtNode node = smart.AllNodes[0];

// 在父节点的第 2 位置添加新的子节点
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// 添加文本
chNode.TextFrame.Text = "Sample Text Added";

// 保存演示文稿
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **访问 SmartArt 节点**
以下示例代码帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。

- 使用索引获取第一张幻灯片的引用。

- 遍历第一张幻灯片中的所有形状。

- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArt。

- 遍历 SmartArt 形状中的所有节点。

- 访问并显示信息，如 SmartArt 节点的位置、层级和文本。
```c#
  // 加载所需的演示文稿
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 遍历第一张幻灯片中的每个形状
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // 检查形状是否为 SmartArt 类型
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // 将形状强制转换为 SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // 遍历 SmartArt 中的所有节点
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // 访问索引 i 处的 SmartArt 节点
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // 打印 SmartArt 节点参数
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```


  


## **访问 SmartArt 子节点**
以下示例代码帮助访问 SmartArt 形状中相应节点的子节点。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点。
- 对于每个选定的 SmartArt 节点，遍历该节点内部的所有子节点。
- 访问并显示信息，如子节点的位置、层级和文本。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 遍历第一张幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 遍历 SmartArt 中的所有节点
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // 访问索引 i 处的 SmartArt 节点
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // 遍历索引 i 处 SmartArt 节点的子节点
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // 访问 SmartArt 节点中的子节点
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // 打印 SmartArt 子节点参数
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```




## **在特定位置访问 SmartArt 子节点**
本示例演示如何在特定位置访问 SmartArt 形状中相应节点的子节点。

- 创建 `Presentation` 类的实例。
- 使用索引获取第一张幻灯片的引用。
- 添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状。
- 访问该 SmartArt 形状中索引为 0 的节点。
- 现在，使用 GetNodeByPosition() 方法在该节点的第 1 位置访问子节点。
- 访问并显示信息，如子节点的位置、层级和文本。
```c#
 // 实例化演示文稿
 Presentation pres = new Presentation();

 // 访问第一张幻灯片
 ISlide slide = pres.Slides[0];

 // 在第一张幻灯片中添加 SmartArt 形状
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // 访问索引 0 处的 SmartArt  节点
 ISmartArtNode node = smart.AllNodes[0];

 // 在父节点中访问位置 1 的子节点
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // 打印 SmartArt 子节点参数
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```




## **移除 SmartArt 节点**
本示例演示如何移除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 检查 SmartArt 是否拥有大于 0 的节点。
- 选择要删除的 SmartArt 节点。
- 现在，使用 RemoveNode() 方法删除选定的节点并保存演示文稿。
```c#
// 加载所需的演示文稿
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // 访问索引 0 处的 SmartArt 节点
                ISmartArtNode node = smart.AllNodes[0];

                // 删除所选节点
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // 保存演示文稿
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **在特定位置移除 SmartArt 节点**
本示例演示如何在特定位置移除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 形状节点。
- 现在，检查选定的 SmartArt 节点是否拥有超过 2 个子节点。
- 使用 RemoveNodeByPosition() 方法删除位置 1 的节点。
- 保存演示文稿。
```c#
// 加载所需的演示文稿             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // 访问索引 0 处的 SmartArt 节点
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 删除位置 1 的子节点
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// 保存演示文稿
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **为 SmartArt 子节点设置自定义位置**
现在 Aspose.Slides for .NET 支持设置 SmartArtShape 的 X 和 Y 属性。下面的代码片段展示了如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意，添加新节点会重新计算所有节点的位置和大小。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// 移动 SmartArt 形状到新位置
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// 更改 SmartArt 形状的宽度
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// 更改 SmartArt 形状的高度
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// 更改 SmartArt 形状的旋转
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```




## **检查助理节点**
以下示例代码将演示如何识别 SmartArt 节点集合中的助理节点并对其进行更改。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点并检查它们是否为助理节点。
- 将助理节点的状态更改为普通节点。
- 保存演示文稿。
```c#
// 创建演示文稿实例
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 遍历第一张幻灯片中的每个形状
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 检查形状是否为 SmartArt 类型
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // 遍历 SmartArt 形状的所有节点

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // 检查节点是否为助理节点
                if (node.IsAssistant)
                {
                    // 将助理节点设置为 false 并将其改为普通节点
                    node.IsAssistant = false;
                }
            }
        }
    }
    // 保存演示文稿
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **设置节点的填充格式**
Aspose.Slides for .NET 允许添加自定义 SmartArt 形状并设置其填充格式。本文介绍如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for .NET 设置其填充格式。

请按以下步骤操作：

- 创建 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 通过设置 LayoutType 添加 SmartArt 形状。
- 为 SmartArt 形状节点设置 FillFormat。
- 将修改后的演示文稿写入为 PPTX 文件。
```c#
using (Presentation presentation = new Presentation())
{
    // 访问幻灯片
    ISlide slide = presentation.Slides[0];

    // 添加 SmartArt 形状和节点
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // 设置节点填充颜色
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // 保存演示文稿
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```




## **生成 SmartArt 子节点的缩略图**
开发者可以按照以下步骤生成 SmartArt 子节点的缩略图：

1. 实例化表示 PPTX 文件的 `Presentation` 类。
1. 添加 SmartArt。
1. 使用索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例演示了生成 SmartArt 子节点缩略图的过程
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```


## **常见问题**

**是否支持 SmartArt 动画？**

是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/net/shape-animation/)(进入、退出、强调、运动路径)并调整时间。必要时也可以为 SmartArt 节点内的形状设置动画。

**如果不知道内部 ID，如何可靠定位幻灯片上的特定 SmartArt？**

通过[替代文本](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)进行标记并搜索。为 SmartArt 设置唯一的 AltText，即可在代码中无需依赖内部标识符进行定位。

**将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会的。Aspose.Slides 在[PDF 导出](/slides/zh/net/convert-powerpoint-to-pdf/)过程中以高视觉保真度渲染 SmartArt，保持布局、颜色和效果。

**我能提取整个 SmartArt 的图像用于预览或报告吗？**

可以。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)或[SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。