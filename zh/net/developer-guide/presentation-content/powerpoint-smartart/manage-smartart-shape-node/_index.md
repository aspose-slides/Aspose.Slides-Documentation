---
title: 在 .NET 中管理演示文稿中的 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/net/manage-smartart-shape-node/
keywords:
- SmartArt 节点
- 子节点
- 添加节点
- 节点位置
- 访问节点
- 删除节点
- 自定义位置
- 助理节点
- 填充格式
- 渲染节点
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理 PPT 和 PPTX 中的 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for .NET 提供了最简便的 API 来管理 SmartArt 形状。以下示例代码将帮助在 SmartArt 形状中添加节点和子节点。

- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加新节点，并在 TextFrame 中设置文本。
- 随后，在新添加的 SmartArt 节点中添加子节点，并在 TextFrame 中设置文本。
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
以下示例代码说明如何在特定位置向 SmartArt 形状的相应节点添加子节点。

- 创建 `Presentation` 类的实例。
- 通过索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状中的第一个节点。
- 随后，在选定节点的第 2 位置添加子节点并设置其文本。
- 保存演示文稿。
```c#
// 创建演示文稿实例
Presentation pres = new Presentation();

// 访问演示文稿的幻灯片
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
以下示例代码将帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且只能在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 遍历 SmartArt 形状中的所有节点。
- 访问并显示信息，例如 SmartArt 节点的位置、层级和文本。
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
以下示例代码将帮助访问 SmartArt 形状中各节点的子节点。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点。
- 对于每个选定的 SmartArt 形状节点，遍历该节点内的所有子节点。
- 访问并显示子节点的位置、层级和文本等信息。
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
以下示例将演示如何在特定位置访问 SmartArt 形状中各节点的子节点。

- 创建 `Presentation` 类的实例。
- 通过索引获取第一张幻灯片的引用。
- 添加 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状。
- 获取访问的 SmartArt 形状中索引为 0 的节点。
- 随后，使用 GetNodeByPosition() 方法访问该 SmartArt 节点中位置为 1 的子节点。
- 访问并显示子节点的位置、层级和文本等信息。
```c#
 // 实例化演示文稿
 Presentation pres = new Presentation();

 // 访问第一张幻灯片
 ISlide slide = pres.Slides[0];

 // 在第一张幻灯片中添加 SmartArt 形状
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // 访问索引 0 处的 SmartArt 节点
 ISmartArtNode node = smart.AllNodes[0];

 // 在父节点中访问位置为 1 的子节点
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // 打印 SmartArt 子节点参数
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```




## **删除 SmartArt 节点**
以下示例将演示如何删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 检查 SmartArt 是否拥有超过 0 个节点。
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

                // 删除选定的节点
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // 保存演示文稿
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **在特定位置删除 SmartArt 节点**
以下示例将演示如何在特定位置删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 形状节点。
- 检查所选 SmartArt 节点是否拥有超过 2 个子节点。
- 随后，使用 RemoveNodeByPosition() 方法删除位置为 1 的节点。
- 保存演示文稿。
```c#
// 加载所需的演示文稿             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 遍历第一张幻灯片中的每个形状
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
现在 Aspose.Slides for .NET 支持设置 SmartArtShape 的 X 和 Y 属性。下面的代码片段展示了如何自定义 SmartArtShape 的位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// 将 SmartArt 形状移动到新位置
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
以下示例代码说明如何在 SmartArt 节点集合中识别助理节点并对其进行更改。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
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
Aspose.Slides for .NET 可以添加自定义 SmartArt 形状并设置其填充格式。本文档阐述了如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for .NET 设置其填充格式的步骤。

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
2. 添加 SmartArt。
3. 通过索引获取节点的引用
4. 获取缩略图。
5. 将缩略图以任意所需的图像格式保存。

下面的示例生成 SmartArt 子节点的缩略图
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


## **FAQ**

**是否支持 SmartArt 动画？**

是的。SmartArt 被视为普通形状，因此您可以[应用标准动画](/slides/zh/net/shape-animation/)（进入、退出、强调、运动路径）并调整时间。如果需要，还可以对 SmartArt 节点内的形状进行动画设置。

**如果未知内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**

通过[alternative text](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)进行分配并搜索。为 SmartArt 设置唯一的 AltText，可在程序中无需依赖内部标识符即可找到它。

**将演示文稿转换为 PDF 时，SmartArt 的外观是否会保留？**

是的。Aspose.Slides 在[PDF 导出](/slides/zh/net/convert-powerpoint-to-pdf/)期间以高视觉保真度渲染 SmartArt，保留布局、颜色和效果。

**我能提取整个 SmartArt 的图像吗（用于预览或报告）？**

是的。您可以将 SmartArt 形状渲染为[raster formats](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)或[SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)，以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。