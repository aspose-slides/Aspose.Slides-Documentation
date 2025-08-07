---
title: 使用 Python 管理演示文稿中的 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/python-net/manage-smartart-shape-node/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PPT、PPTX 和 ODP 中管理 SmartArt 形状节点。获取清晰的代码示例和技巧，简化您的演示文稿."
---

## **添加 SmartArt 节点**
Aspose.Slides for Python via .NET 提供了最简单的 API，以最简单的方式管理 SmartArt 形状。以下示例代码将帮助在 SmartArt 形状中添加节点和子节点。

- 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并加载带有 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加一个新节点，并在 TextFrame 中设置文本。
- 现在，在新添加的 SmartArt 节点中添加一个子节点，并在 TextFrame 中设置文本。
- 保存演示文稿。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:

        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 添加一个新的 SmartArt 节点
            node1 = shape.all_nodes.add_node()
            # 添加文本
            node1.text_frame.text = "测试"

            # 在父节点中添加新子节点。它将在集合的末尾添加
            new_node = node1.child_nodes.add_node()

            # 添加文本
            new_node.text_frame.text = "新节点已添加"

    # 保存演示文稿
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **在特定位置添加 SmartArt 节点**
在以下示例代码中，我们解释了如何在特定位置添加属于 SmartArt 形状的相应节点的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用其索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状中的第一个节点。
- 现在，在位置 2 为所选节点添加子节点，并设置其文本。
- 保存演示文稿。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 创建演示文稿实例
with slides.Presentation() as pres:
    # 访问演示文稿幻灯片
    slide = pres.slides[0]

    # 添加 Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # 访问添加的 SmartArt 形状中的节点
    node = smart.all_nodes[0]

    # 在父节点中的位置 2 添加新子节点
    chNode = node.child_nodes.add_node_by_position(2)

    # 添加文本
    chNode.text_frame.text = "示例文本已添加"

    # 保存演示文稿
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **访问 SmartArt 节点**
以下示例代码将帮助访问 SmartArt 形状内部的节点。请注意，您不能更改 SmartArt 的 LayoutType，因为它是只读的，并且仅在添加 SmartArt 形状时设置。

- 创建一个 `Presentation` 类的实例，并加载带有 SmartArt 形状的演示文稿。

- 通过使用其索引获取第一张幻灯片的引用。

- 遍历第一张幻灯片中的每个形状。

- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArt。

- 遍历 SmartArt 形状内部的所有节点。

- 访问并显示诸如 SmartArt 节点位置、级别和文本等信息。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 内部的所有节点
            for i in range(len(shape.all_nodes)):
                # 访问索引为 i 的 SmartArt 节点
                node = shape.all_nodes[i]

                # 打印 SmartArt 节点参数
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **访问 SmartArt 子节点**
以下示例代码将帮助访问属于 SmartArt 形状相应节点的子节点。

- 创建一个 PresentationEx 类的实例，并加载带有 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArtEx。
- 遍历 SmartArt 形状内部的所有节点。
- 对于每个选定的 SmartArt 形状节点，遍历特定节点内部的所有子节点。
- 访问并显示诸如子节点位置、级别和文本等信息。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 内部的所有节点
            for node0 in shape.all_nodes:
                # 遍历子节点
                for j in range(len(node0.child_nodes)):
                    # 访问 SmartArt 节点中的子节点
                    node = node0.child_nodes[j]

                    # 打印 SmartArt 子节点参数
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **在特定位置访问 SmartArt 子节点**
在此示例中，我们将学习如何访问特定位置属于 SmartArt 形状相应节点的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用其索引获取第一张幻灯片的引用。
- 添加一个 StackedList 类型的 SmartArt 形状。
- 访问添加的 SmartArt 形状。
- 访问所访问 SmartArt 形状中索引为 0 的节点。
- 现在，使用 GetNodeByPosition() 方法访问所访问 SmartArt 节点的子节点位置 1。
- 访问并显示诸如子节点位置、级别和文本等信息。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 实例化演示文稿
with slides.Presentation() as pres:
    # 访问第一张幻灯片
    slide = pres.slides[0]
    # 在第一张幻灯片中添加 SmartArt 形状
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # 访问 SmartArt 中索引为 0 的节点
    node = smart.all_nodes[0]
    # 访问父节点中位置为 1 的子节点
    position = 1
    chNode = node.child_nodes[position] 
    # 打印 SmartArt 子节点参数
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **删除 SmartArt 节点**
在此示例中，我们将学习如何删除 SmartArt 形状内部的节点。

- 创建一个 `Presentation` 类的实例，并加载带有 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArt。
- 检查 SmartArt 是否有超过 0 个节点。
- 选择要删除的 SmartArt 节点。
- 现在，使用 RemoveNode() 方法删除所选节点并保存演示文稿。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 将形状转换为 SmartArtEx
            if len(shape.all_nodes) > 0:
                # 访问 SmartArt 节点
                node = shape.all_nodes[0]

                # 移除所选节点
                shape.all_nodes.remove_node(node)

    # 保存演示文稿
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **在特定位置删除 SmartArt 节点**
在此示例中，我们将学习如何在特定位置删除 SmartArt 形状内部的节点。

- 创建一个 `Presentation` 类的实例，并加载带有 SmartArt 形状的演示文稿。
- 通过使用其索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArt。
- 选择 SmartArt 形状中的索引 0 的节点。
- 现在，检查所选 SmartArt 节点是否有超过 2 个子节点。
- 现在，使用 RemoveNodeByPosition() 方法删除位置 1 的节点。
- 保存演示文稿。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 将形状转换为 SmartArt
            if len(shape.all_nodes) > 0:
                # 访问 SmartArt 节点
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 删除位置 1 的子节点
                    node.child_nodes.remove_node(1)

    # 保存演示文稿
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **为 SmartArt 中的子节点设置自定义位置**
现在，Aspose.Slides for Python via .NET 支持设置 SmartArtShape 的 X 和 Y 属性。以下代码示例展示了如何设置自定义 SmartArtShape 位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# 移动 SmartArt 形状到新位置
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# 更改 SmartArt 形状的宽度
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# 更改 SmartArt 形状的高度
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# 更改 SmartArt 形状的旋转
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **检查助手节点**
在以下示例代码中，我们将研究如何识别 SmartArt 节点集合中的助手节点并进行更改。

- 创建一个 PresentationEx 类的实例并加载带有 SmartArt 形状的演示文稿。
- 通过使用其索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在它是 SmartArt 时将所选形状转换为 SmartArtEx。
- 遍历 SmartArt 形状内部的所有节点，并检查它们是否为助手节点。
- 将助手节点的状态更改为普通节点。
- 保存演示文稿。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 创建演示文稿实例
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 遍历第一张幻灯片中的每个形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 形状内部的所有节点
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # 检查节点是否为助手节点
                if node.is_assistant:
                    # 将助手节点设置为 false 并将其变为普通节点
                    node.is_assistant = False
    # 保存演示文稿
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **设置节点的填充格式**
Aspose.Slides for Python via .NET 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文解释了如何创建和访问 SmartArt 形状并使用 Aspose.Slides for Python via .NET 设置其填充格式。

请遵循以下步骤：

- 创建一个 `Presentation` 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 通过设置其 LayoutType 添加 SmartArt 形状。
- 为 SmartArt 形状节点设置 FillFormat。
- 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # 访问幻灯片
    slide = presentation.slides[0]

    # 添加 SmartArt 形状和节点
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "一些文本"

    # 设置节点填充颜色
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # 保存演示文稿
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **生成 SmartArt 子节点的缩略图**
开发人员可以通过以下步骤生成 SmartArt 子节点的缩略图：

1. 实例化表示 PPTX 文件的 `Presentation` 类。
1. 添加 SmartArt。
1. 通过使用其索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像以任何所需的图像格式保存。

以下示例生成 SmartArt 子节点的缩略图

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 实例化表示 PPTX 文件的 Presentation 类 
with slides.Presentation() as presentation: 
    # 添加 SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # 通过使用其索引获取节点的引用  
    node = smart.nodes[1]

    # 获取缩略图
    with node.shapes[0].get_image() as bmp:
        # 保存缩略图
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```