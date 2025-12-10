---
title: 在 .NET 中管理演示文稿的 SmartArt 形状节点
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
description: "使用 Aspose.Slides for .NET 在 PPT 和 PPTX 中管理 SmartArt 形状节点。获取清晰的代码示例和技巧以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for .NET 提供了最简单的 API，以最简便的方式管理 SmartArt 形状。以下示例代码演示如何在 SmartArt 形状中添加节点和子节点。

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加新的节点，并在 TextFrame 中设置文本。
- 然后，在新添加的 SmartArt 节点中添加子节点，并在 TextFrame 中设置文本。
- 保存演示文稿。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AddNodes.pptx");

// 遍历第一张幻灯片中的所有形状
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
以下示例代码说明了如何在特定位置向 SmartArt 形状的相应节点添加子节点。

- 创建 `Presentation` 类的实例。
- 使用索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加一种 StackedList 类型的 SmartArt 形状。
- 访问已添加 SmartArt 形状的第一个节点。
- 然后，在位置 2 为选定的节点添加子节点并设置其文本。
- 保存演示文稿。
```c#
// 创建演示文稿实例
Presentation pres = new Presentation();

// 访问演示文稿的幻灯片
ISlide slide = pres.Slides[0];

// 添加 SmartArt IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 访问索引 0 处的 SmartArt 节点
ISmartArtNode node = smart.AllNodes[0];

// 在父节点的位置 2 添加新的子节点
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// 添加文本
chNode.TextFrame.Text = "Sample Text Added";

// 保存演示文稿
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **访问 SmartArt 节点**
以下示例代码帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 是只读的，且仅在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 遍历 SmartArt 形状中的所有节点。
- 访问并显示信息，如 SmartArt 节点的位置、层级和文本。
```c#
  // 加载所需的演示文稿
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 遍历第一张幻灯片中的所有形状
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
以下示例代码帮助访问 SmartArt 形状中各节点对应的子节点。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点。
- 对于每个选定的 SmartArt 形状节点，遍历该节点内部的所有子节点。
- 访问并显示信息，如子节点的位置、层级和文本。
```c#
// 加载所需的演示文稿
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 遍历第一张幻灯片中的所有形状
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
- 添加一种 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状。
- 访问已访问 SmartArt 形状中索引为 0 的节点。
- 然后，使用 GetNodeByPosition() 方法访问该 SmartArt 节点位置 1 的子节点。
- 访问并显示信息，如子节点的位置、层级和文本。
```c#
 // 实例化演示文稿
 Presentation pres = new Presentation();

 // 访问第一张幻灯片
 ISlide slide = pres.Slides[0];

 // 在第一张幻灯片中添加 SmartArt 形状
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // 访问索引 0 处的 SmartArt 节点
 ISmartArtNode node = smart.AllNodes[0];

 // 访问父节点中位置 1 的子节点
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // 打印 SmartArt 子节点参数
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```


## **删除 SmartArt 节点**
本示例演示如何删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 检查该 SmartArt 是否拥有超过 0 个节点。
- 选择要删除的 SmartArt 节点。
- 然后，使用 RemoveNode() 方法删除选定的节点并保存演示文稿。
```c#
// 加载所需的演示文稿
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 遍历第一张幻灯片中的所有形状
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

                // 删除选中的节点
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // 保存演示文稿
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **在特定位置删除 SmartArt 节点**
本示例演示如何在特定位置删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 形状节点。
- 然后，检查选定的 SmartArt 节点是否拥有超过 2 个子节点。
- 然后，使用 RemoveNodeByPosition() 方法删除位置 1 的节点。
- 保存演示文稿。
```c#
// 加载所需的演示文稿             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 遍历第一张幻灯片中的所有形状
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


## **为 SmartArt 对象中的子节点设置自定义位置**
现在 Aspose.Slides for .NET 支持设置 SmartArtShape 的 X 和 Y 属性。下面的代码片段演示如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意，添加新节点会重新计算所有节点的位置和大小。
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
以下示例代码将探讨如何识别 SmartArt 节点集合中的助理节点并对其进行更改。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点，并检查它们是否为助理节点。
- 将助理节点的状态更改为普通节点。
- 保存演示文稿。
```c#
 // 创建演示文稿实例
 using (Presentation pres = new Presentation("AssistantNode.pptx"))
 {
     // 遍历第一张幻灯片中的所有形状
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
Aspose.Slides for .NET 可以添加自定义 SmartArt 形状并设置其填充格式。本文说明如何使用 Aspose.Slides for .NET 创建和访问 SmartArt 形状以及设置其填充格式。

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
3. 使用索引获取节点的引用。
4. 获取缩略图图像。
5. 以任意所需的图像格式保存缩略图。

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
是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/net/shape-animation/)（进入、退出、强调、运动路径）并调整时间。必要时也可以为 SmartArt 节点内部的形状添加动画。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**
通过[替代文本](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)进行分配和搜索。为 SmartArt 设置独特的 AltText，可在不依赖内部标识符的情况下通过编程方式找到它。

**将演示文稿转换为 PDF 时，SmartArt 的外观是否会保留？**
是的。Aspose.Slides 在[PDF 导出](/slides/zh/net/convert-powerpoint-to-pdf/)过程中以高视觉保真度渲染 SmartArt，保留布局、颜色和效果。

**我可以提取整个 SmartArt 的图像（用于预览或报告）吗？**
是的。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)或[SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)，以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。