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
description: "使用 Aspose.Slides for Python via .NET 在 PPT、PPTX 和 ODP 中管理 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for Python via .NET 提供了最简洁的 API，以最简便的方式管理 SmartArt 形状。以下示例代码演示如何在 SmartArt 形状中添加节点和子节点。

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加新节点并在 TextFrame 中设置文本。
- 在新添加的 SmartArt 节点中添加子节点并在 TextFrame 中设置文本。
- 保存演示文稿。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:

        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 添加新的 SmartArt 节点
            node1 = shape.all_nodes.add_node()
            # 添加文本
            node1.text_frame.text = "Test"

            # 在父节点中添加新的子节点。它将被添加到集合的末尾
            new_node = node1.child_nodes.add_node()

            # 添加文本
            new_node.text_frame.text = "New Node Added"

    # 保存演示文稿
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在特定位置添加 SmartArt 节点**
以下示例代码说明如何在 SmartArt 形状的相应节点下的特定位置添加子节点。

- 创建 `Presentation` 类的实例。
- 使用索引获取第一张幻灯片的引用。
- 在目标幻灯片中添加 StackedList 类型的 SmartArt 形状。
- 访问已添加 SmartArt 形状的第一个节点。
- 在位置 2 处为选定的节点添加子节点并设置其文本。
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

    # 访问索引为 0 的 SmartArt 节点
    node = smart.all_nodes[0]

    # 在父节点中于位置 2 添加新的子节点
    chNode = node.child_nodes.add_node_by_position(2)

    # 添加文本
    chNode.text_frame.text = "Sample text Added"

    # 保存演示文稿
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **访问 SmartArt 节点**
以下示例代码帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 为只读，且仅在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 遍历 SmartArt 形状中的所有节点。
- 访问并显示节点的位置信息、层级和文本。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 中的所有节点
            for i in range(len(shape.all_nodes)):
                # 访问索引 i 处的 SmartArt 节点
                node = shape.all_nodes[i]

                # 打印 SmartArt 节点参数
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **访问 SmartArt 子节点**
以下示例代码帮助访问 SmartArt 形状中各节点的子节点。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点。
- 对于每个选定的 SmartArt 节点，遍历其内部的所有子节点。
- 访问并显示子节点的位置信息、层级和文本。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 中的所有节点
            for node0 in shape.all_nodes:
                # 遍历子节点
                for j in range(len(node0.child_nodes)):
                    # 访问 SmartArt 节点中的子节点
                    node = node0.child_nodes[j]

                    # 打印 SmartArt 子节点参数
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **在特定位置访问 SmartArt 子节点**
本示例演示如何在特定位置访问 SmartArt 形状各节点的子节点。

- 创建 `Presentation` 类的实例。
- 使用索引获取第一张幻灯片的引用。
- 添加 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状。
- 获取索引为 0 的节点。
- 使用 GetNodeByPosition() 方法在该节点中访问位置 1 的子节点。
- 访问并显示子节点的位置信息、层级和文本。
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
    # 访问索引为 0 的 SmartArt 节点
    node = smart.all_nodes[0]
    # 在父节点中访问位置为 1 的子节点
    position = 1
    chNode = node.child_nodes[position] 
    # 打印 SmartArt 子节点参数
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **删除 SmartArt 节点**
本示例演示如何删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 检查 SmartArt 是否包含超过 0 个节点。
- 选择要删除的 SmartArt 节点。
- 使用 RemoveNode() 方法删除选定的节点并保存演示文稿。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 将形状强制转换为 SmartArtEx
            if len(shape.all_nodes) > 0:
                # 访问索引为 0 的 SmartArt 节点
                node = shape.all_nodes[0]

                # 删除选中的节点
                shape.all_nodes.remove_node(node)

    # 保存演示文稿
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **在特定位置删除 SmartArt 节点**
本示例演示如何在特定位置删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 节点。
- 检查选定的 SmartArt 节点是否拥有超过 2 个子节点。
- 使用 RemoveNodeByPosition() 方法删除位置为 1 的子节点。
- 保存演示文稿。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 将形状强制转换为 SmartArt
            if len(shape.all_nodes) > 0:
                # 访问索引为 0 的 SmartArt 节点
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 删除位置为 1 的子节点
                    node.child_nodes.remove_node(1)

    # 保存演示文稿
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为 SmartArt 子节点设置自定义位置**
现在 Aspose.Slides for Python via .NET 支持设置 SmartArtShape 的 X 和 Y 属性。下面的代码片段展示了如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意添加新节点会重新计算所有节点的位置和大小。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 加载所需的演示文稿
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# 将 SmartArt 形状移动到新位置
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


## **检查助理节点**
以下示例代码将探讨如何识别 SmartArt 节点集合中的助理节点并对其进行修改。

- 创建 PresentationEx 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的所有形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点并检查它们是否为助理节点。
- 将助理节点的状态更改为普通节点。
- 保存演示文稿。
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 创建演示文稿实例
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 遍历第一张幻灯片中的所有形状
    for shape in pres.slides[0].shapes:
        # 检查形状是否为 SmartArt 类型
        if type(shape) is art.SmartArt:
            # 遍历 SmartArt 形状的所有节点
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # 检查节点是否为助理节点
                if node.is_assistant:
                    # 将助理节点设为 false 并使其成为普通节点
                    node.is_assistant = False
    # 保存演示文稿
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置节点的填充格式**
Aspose.Slides for Python via .NET 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文说明如何创建和访问 SmartArt 形状以及使用 Aspose.Slides for Python via .NET 设置其填充格式。

请按以下步骤操作：

- 创建 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 通过设置 LayoutType 添加 SmartArt 形状。
- 为 SmartArt 形状的节点设置 FillFormat。
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
    node.text_frame.text = "Some text"

    # 设置节点填充颜色
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # 保存演示文稿
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **生成 SmartArt 子节点的缩略图**
开发者可以按以下步骤生成 SmartArt 子节点的缩略图：

1. 实例化表示 PPTX 文件的 `Presentation` 类。
2. 添加 SmartArt。
3. 使用索引获取节点的引用。
4. 获取缩略图图像。
5. 将缩略图保存为任意所需的图像格式。

下面的示例演示如何生成 SmartArt 子节点的缩略图
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as presentation: 
    # 添加 SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # 通过索引获取节点的引用
    node = smart.nodes[1]

    # 获取缩略图
    with node.shapes[0].get_image() as bmp:
        # 保存缩略图
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **常见问题**

**是否支持 SmartArt 动画？**

是的。SmartArt 被视为普通形状，您可以[应用标准动画](/slides/zh/python-net/shape-animation/)(进入、退出、强调、运动路径)并调整时间。如果需要，还可以为 SmartArt 节点内部的形状单独设置动画。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**

使用[替代文本](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)进行标识。为 SmartArt 设置唯一的 AltText，即可在代码中通过该文本查找，而无需依赖内部标识符。

**将演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会。Aspose.Slides 在[PDF 导出](/slides/zh/python-net/convert-powerpoint-to-pdf/)过程中高保真渲染 SmartArt，保持布局、颜色和效果。

**我能提取整个 SmartArt 的图像用于预览或报告吗？**

可以。您可以将 SmartArt 形状渲染为[光栅格式](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/)或[SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/)以获得可伸缩的矢量输出，适用于缩略图、报告或 Web 使用。