---
title: 管理智能艺术形状节点
type: docs
weight: 30
url: /cpp/manage-smartart-shape-node/
keywords:
- 智能艺术
- 智能艺术节点
- 智能艺术子节点
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for C++
description: "在C++中管理PowerPoint演示文稿中的智能艺术节点和子节点"
---



## **添加智能艺术节点**
Aspose.Slides for C++ 提供了最简单的API，用于以最简单的方式管理智能艺术形状。以下示例代码将帮助您在智能艺术形状中添加节点和子节点。

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，则将所选形状强制转换为智能艺术。
- 在智能艺术形状的 NodeCollection 中添加一个新节点，并在 TextFrame 中设置文本。
- 现在，在新添加的智能艺术节点中添加一个子节点，并在 TextFrame 中设置文本。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **在特定位置添加智能艺术节点**
在以下示例代码中，我们解释了如何在特定位置添加与智能艺术形状相应节点的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用索引获取第一张幻灯片的引用。
- 在访问的幻灯片中添加一个 StackedList 类型的智能艺术形状。
- 访问添加的智能艺术形状中的第一个节点。
- 现在，在所选节点的第2个位置添加子节点并设置其文本。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **访问智能艺术节点**
以下示例代码将帮助您访问智能艺术形状中的节点。请注意，您无法更改智能艺术的 LayoutType，因为它是只读的，并且仅在添加智能艺术形状时设置。

- 创建一个 `Presentation` 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，则将所选形状强制转换为智能艺术。
- 遍历智能艺术形状中的所有节点。
- 访问并显示信息，如智能艺术节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **访问智能艺术子节点**
以下示例代码将帮助您访问属于智能艺术形状相应节点的子节点。

- 创建一个 PresentationEx 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，请将所选形状强制转换为 SmartArtEx。
- 遍历智能艺术形状中的所有节点。
- 对于每个选定的智能艺术形状节点，遍历特定节点中的所有子节点。
- 访问并显示信息，如子节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **在特定位置访问智能艺术子节点**
在这个例子中，我们将学习如何在特定位置访问属于智能艺术形状相应节点的子节点。

- 创建一个 `Presentation` 类的实例。
- 通过使用索引获取第一张幻灯片的引用。
- 添加一个 StackedList 类型的智能艺术形状。
- 访问添加的智能艺术形状。
- 访问访问的智能艺术形状的索引0处的节点。
- 现在，使用 GetNodeByPosition() 方法访问访问的智能艺术节点的第1个位置的子节点。
- 访问并显示信息，如子节点的位置、级别和文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **删除智能艺术节点**
在这个例子中，我们将学习如何删除智能艺术形状中的节点。

- 创建一个 `Presentation` 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，则将所选形状强制转换为智能艺术。
- 检查智能艺术是否有超过0个节点。
- 选择要删除的智能艺术节点。
- 现在，使用 RemoveNode() 方法删除所选节点* 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **在特定位置删除智能艺术节点**
在这个例子中，我们将学习如何在特定位置删除智能艺术形状中的节点。

- 创建一个 `Presentation` 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，则将所选形状强制转换为智能艺术。
- 选择索引0处的智能艺术形状节点。
- 现在，检查所选的智能艺术节点是否有超过2个子节点。
- 现在，使用 RemoveNodeByPosition() 方法删除位置1处的节点。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **为智能艺术子节点设置自定义位置**
现在Aspose.Slides for .NET支持设置智能艺术形状的X和Y属性。下面的代码片段展示了如何设置自定义智能艺术形状的位置、大小和旋转，请注意，添加新节点会导致所有节点的位置和大小重新计算。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **检查助手节点**
在以下示例代码中，我们将研究如何识别智能艺术节点集合中的助手节点并进行更改。

- 创建一个 PresentationEx 类的实例，并加载包含智能艺术形状的演示文稿。
- 通过使用索引获取第二张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为智能艺术类型，如果是智能艺术，则将所选形状强制转换为 SmartArtEx。
- 遍历智能艺术形状中的所有节点，检查它们是否为助手节点。
- 将助手节点的状态更改为正常节点。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **设置节点的填充格式**
Aspose.Slides for C++ 使添加自定义智能艺术形状并设置其填充格式成为可能。本文解释了如何创建和访问智能艺术形状，并使用 Aspose.Slides for C++ 设置其填充格式。

请按照以下步骤操作：

- 创建一个 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 通过设置其 LayoutType 添加智能艺术形状。
- 为智能艺术形状节点设置 FillFormat。
- 将修改后的演示文稿写入PPTX文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **生成智能艺术子节点的缩略图**
开发人员可以通过以下步骤生成智能艺术子节点的缩略图：

1. 实例化一个 `Presentation` 类，该类表示PPTX文件。
2. 添加智能艺术。
3. 通过使用索引获取节点的引用。
4. 获取缩略图图像。
5. 以任何所需的图像格式保存缩略图图像。

以下示例生成智能艺术子节点的缩略图

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