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
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的 SmartArt 节点和子节点"
---


## **添加 SmartArt 节点**
Aspose.Slides for .NET 提供了管理 SmartArt 形状的最简单 API。以下示例代码将帮助您在 SmartArt 形状中添加节点和子节点。

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加一个新节点，并在 TextFrame 中设置文本。
- 现在，在新添加的 SmartArt 节点中添加一个子节点，并在 TextFrame 中设置文本。
- 保存演示文稿。

```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AddNodes.pptx");

// 遍历第一个幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 添加一个新的 SmartArt 节点
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // 添加文本
        TemNode.TextFrame.Text = "测试";

        // 在父节点中添加新子节点。它将被添加到集合的末尾
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // 添加文本
        newNode.TextFrame.Text = "新节点已添加";

    }
}

// 保存演示文稿
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **在特定位置添加 SmartArt 节点**
在以下示例代码中，我们解释了如何在特定位置添加属于相应 SmartArt 形状的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用索引获取第一个幻灯片的引用。
- 在访问的幻灯片中添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状中的第一个节点。
- 现在，为所选节点在位置 2 添加子节点并设置其文本。
- 保存演示文稿。

```c#
// 创建演示文稿实例
Presentation pres = new Presentation();

// 访问演示文稿幻灯片
ISlide slide = pres.Slides[0];

// 添加 Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 访问添加的 SmartArt 节点，索引为 0
ISmartArtNode node = smart.AllNodes[0];

// 在父节点中位置 2 添加新子节点
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// 添加文本
chNode.TextFrame.Text = "示例文本已添加";

// 保存演示文稿
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **访问 SmartArt 节点**
以下示例代码将帮助您访问 SmartArt 形状内部的节点。请注意，您无法更改 SmartArt 的 LayoutType，因为它是只读的，仅在添加 SmartArt 形状时设置。

- 创建一个 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArt。
- 遍历 SmartArt 形状内部的所有节点。
- 访问并显示如 SmartArt 节点的位置、级别和文本等信息。

```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessSmartArt.pptx");

// 遍历第一个幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
  
        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
        // 遍历 SmartArt 内部的所有节点
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // 访问索引为 i 的 SmartArt 节点
            Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
            // 打印 SmartArt 节点参数
            string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
            Console.WriteLine(outString);
        }
    }
}
```



## **访问 SmartArt 子节点**
以下示例代码将帮助您访问属于相应 SmartArt 形状节点的子节点。

- 创建一个 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状内部的所有节点。
- 对于每个选定的 SmartArt 形状节点，遍历特定节点内部的所有子节点。
- 访问并显示子节点的位置、级别和文本等信息。

```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 遍历第一个幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 遍历 SmartArt 内部的所有节点
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // 访问索引为 i 的 SmartArt 节点
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // 在 SmartArt 节点中遍历子节点
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
在此示例中，我们将学习如何访问属于相应 SmartArt 形状的特定位置的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用索引获取第一个幻灯片的引用。
- 添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状。
- 获取访问的 SmartArt 形状的索引为 0 的节点。
- 现在，使用 GetNodeByPosition() 方法访问索引为 1 的访问 SmartArt 节点的子节点。
- 访问并显示子节点的位置、级别和文本等信息。

```c#
// 实例化演示文稿
Presentation pres = new Presentation();

// 访问第一个幻灯片
ISlide slide = pres.Slides[0];

// 在第一个幻灯片中添加 SmartArt 形状
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 访问添加的 SmartArt 节点，索引为 0
ISmartArtNode node = smart.AllNodes[0];

// 在父节点中访问位置为 1 的子节点
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// 打印 SmartArt 子节点参数
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **删除 SmartArt 节点**
在此示例中，我们将学习如何删除 SmartArt 形状内部的节点。

- 创建一个 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArt。
- 检查 SmartArt 是否有超过 0 个节点。
- 选择要删除的 SmartArt 节点。
- 现在，使用 RemoveNode() 方法删除所选节点并保存演示文稿。

```c#
// 加载所需的演示文稿
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 遍历第一个幻灯片中的每个形状
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // 检查形状是否为 SmartArt 类型
        if (shape is ISmartArt)
        {
            // 将形状强制转换为 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // 访问索引为 0 的 SmartArt 节点
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



## **在特定位置删除 SmartArt 节点**
在此示例中，我们将学习如何在特定位置删除 SmartArt 形状内部的节点。

- 创建一个 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 形状节点。
- 现在，检查选定的 SmartArt 节点是否有超过 2 个子节点。
- 现在，使用 RemoveNodeByPosition() 方法删除位置 1 的节点。
- 保存演示文稿。

```c#
// 加载所需的演示文稿             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 遍历第一个幻灯片中的每个形状
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // 检查形状是否为 SmartArt 类型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // 将形状强制转换为 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // 访问索引为 0 的 SmartArt 节点
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 删除位置为 1 的子节点
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// 保存演示文稿
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **为 SmartArt 中的子节点设置自定义位置**
现在 Aspose.Slides for .NET 支持设置 SmartArtShape 的 X 和 Y 属性。下面的代码片段演示了如何设置自定义 SmartArtShape 的位置、大小和旋转。请注意，添加新节点会导致所有节点的位置和大小重新计算。

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
在以下示例代码中，我们将研究如何识别 SmartArt 节点集合中的助理节点并进行更改。

- 创建一个 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第二个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是 SmartArt，则将所选形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状内部的所有节点并检查它们是否为助理节点。
- 将助理节点的状态更改为普通节点。
- 保存演示文稿。

```c#
// 创建演示文稿实例
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 遍历第一个幻灯片中的每个形状
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
                    // 将助理节点设置为 false，并使其成为普通节点
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
Aspose.Slides for .NET 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文解释了如何使用 Aspose.Slides for .NET 创建和访问 SmartArt 形状并设置其填充格式。

请按照以下步骤操作：

- 创建一个 `Presentation` 类的实例。
- 通过索引获取幻灯片的引用。
- 通过设置其 LayoutType 添加一个 SmartArt 形状。
- 为 SmartArt 形状节点设置 FillFormat。
- 以 PPTX 文件格式写入修改后的演示文稿。

```c#
using (Presentation presentation = new Presentation())
{
    // 访问幻灯片
    ISlide slide = presentation.Slides[0];

    // 添加 SmartArt 形状和节点
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "一些文本";

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
开发人员可以通过以下步骤生成 SmartArt 子节点的缩略图：

1. 实例化代表 PPTX 文件的 `Presentation` 类。
2. 添加 SmartArt。
3. 通过使用索引获得节点的引用。
4. 获取缩略图图像。
5. 将缩略图图像保存为任何所需的图像格式。

以下示例生成 SmartArt 子节点的缩略图。

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