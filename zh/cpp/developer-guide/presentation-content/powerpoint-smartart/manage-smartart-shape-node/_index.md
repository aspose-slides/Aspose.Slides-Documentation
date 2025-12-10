---
title: 使用 C++ 管理演示文稿中的 SmartArt 形状节点
linktitle: SmartArt 形状节点
type: docs
weight: 30
url: /zh/cpp/manage-smartart-shape-node/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PPT 和 PPTX 中管理 SmartArt 形状节点。获取清晰的代码示例和技巧，以简化您的演示文稿。"
---

## **添加 SmartArt 节点**
Aspose.Slides for C++ 提供了最简洁的 API，以最简便的方式管理 SmartArt 形状。以下示例代码将帮助在 SmartArt 形状中添加节点和子节点。

- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 在 SmartArt 形状的 NodeCollection 中添加一个新节点，并在 TextFrame 中设置文本。
- 现在，在新添加的 SmartArt 节点中添加子节点，并在 TextFrame 中设置文本。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **在特定位置添加 SmartArt 节点**
以下示例代码说明了如何在特定位置向 SmartArt 形状的相应节点添加子节点。

- 创建 `Presentation` 类的实例。
- 通过使用索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加一种 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状中的第一个节点。
- 现在，在位置 2 为选定的节点添加子节点并设置其文本。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **访问 SmartArt 节点**
以下示例代码将帮助访问 SmartArt 形状中的节点。请注意，SmartArt 的 LayoutType 是只读的，仅在添加 SmartArt 形状时设置，无法更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 遍历 SmartArt 形状中的所有节点。
- 访问并显示信息，例如 SmartArt 节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **访问 SmartArt 子节点**
以下示例代码将帮助访问属于 SmartArt 形状相应节点的子节点。

- 创建 `PresentationEx` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点。
- 对于每个选定的 SmartArt 形状节点，遍历该节点内部的所有子节点。
- 访问并显示信息，例如子节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **在特定位置访问 SmartArt 子节点**
在本示例中，我们将学习如何在特定位置访问属于 SmartArt 形状相应节点的子节点。

- 创建 `Presentation` 类的实例。
- 通过使用索引获取第一张幻灯片的引用。
- 添加一种 StackedList 类型的 SmartArt 形状。
- 访问已添加的 SmartArt 形状。
- 访问已访问的 SmartArt 形状中索引为 0 的节点。
- 现在，使用 GetNodeByPosition() 方法访问已访问的 SmartArt 节点中位置为 1 的子节点。
- 访问并显示信息，例如子节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **删除 SmartArt 节点**
在本示例中，我们将学习如何删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 检查 SmartArt 是否有超过 0 个节点。
- 选择要删除的 SmartArt 节点。
- 现在，使用 RemoveNode() 方法删除所选节点并保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **在特定位置删除 SmartArt 节点**
在本示例中，我们将学习如何在特定位置删除 SmartArt 形状中的节点。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArt。
- 选择索引为 0 的 SmartArt 形状节点。
- 现在，检查所选 SmartArt 节点是否有超过 2 个子节点。
- 现在，使用 RemoveNodeByPosition() 方法删除位置为 1 的节点。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **为 SmartArt 子节点设置自定义位置**
现在 Aspose.Slides 支持设置 SmartArtShape 的 X 和 Y 属性。以下代码片段展示了如何设置自定义的 SmartArtShape 位置、大小和旋转，请注意添加新节点会导致所有节点的位置和大小重新计算。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **检查助理节点**
以下示例代码将研究如何在 SmartArt 节点集合中识别助理节点并对其进行更改。

- 创建 `PresentationEx` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 通过使用索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，如果是，则将选定的形状强制转换为 SmartArtEx。
- 遍历 SmartArt 形状中的所有节点并检查它们是否为助理节点。
- 将助理节点的状态更改为普通节点。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **设置节点的填充格式**
Aspose.Slides for C++ 使得添加自定义 SmartArt 形状并设置其填充格式成为可能。本文解释了如何使用 Aspose.Slides for C++ 创建和访问 SmartArt 形状以及设置其填充格式。

- 创建 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 通过设置 LayoutType 添加 SmartArt 形状。
- 为 SmartArt 形状节点设置 FillFormat。
- 将修改后的演示文稿写入为 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **生成 SmartArt 子节点的缩略图**
开发者可以通过以下步骤生成 SmartArt 子节点的缩略图：

1. 实例化表示 PPTX 文件的 `Presentation` 类。
1. 添加 SmartArt。
1. 使用索引获取节点的引用。
1. 获取缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例生成 SmartArt 子节点的缩略图
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**是否支持 SmartArt 动画？**
是的。SmartArt 被视为普通形状，因此您可以[应用标准动画](/slides/zh/cpp/shape-animation/)（进入、退出、强调、移动路径）并调整时间。如果需要，还可以为 SmartArt 节点内部的形状添加动画。

**如果不知道内部 ID，如何可靠地定位幻灯片上的特定 SmartArt？**
通过[alternative text](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/)进行分配和搜索。在 SmartArt 上设置独特的 AltText，可让您在程序中定位它，而无需依赖内部标识符。

**将演示文稿转换为 PDF 时，SmartArt 外观会被保留吗？**
是的。Aspose.Slides 在[PDF 导出](/slides/zh/cpp/convert-powerpoint-to-pdf/)期间以高视觉保真度呈现 SmartArt，保留布局、颜色和效果。

**是否可以提取整个 SmartArt 的图像（用于预览或报告）？**
是的。您可以将 SmartArt 形状渲染为[raster formats](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)或[SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)，以获得可缩放的矢量输出，适用于缩略图、报告或网页使用。