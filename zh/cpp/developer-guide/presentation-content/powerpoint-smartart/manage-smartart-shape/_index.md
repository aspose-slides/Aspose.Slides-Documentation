---
title: 管理SmartArt形状
type: docs
weight: 20
url: /cpp/manage-smartart-shape/
---


## **创建SmartArt形状**
Aspose.Slides for C++ 现在支持从头开始在幻灯片中添加自定义SmartArt形状。Aspose.Slides for C++提供了最简单的API，以最简便的方式创建SmartArt形状。要在幻灯片中创建SmartArt形状，请按照以下步骤进行操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 通过设置布局类型添加SmartArt形状。
- 将修改后的演示文稿写入PPTX文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **在幻灯片中访问SmartArt形状**
以下代码将用于访问演示文稿幻灯片中添加的SmartArt形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否为SmartArt形状。如果形状是SmartArt类型，则将其强制转换为SmartArt实例。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **访问具有特定布局类型的SmartArt形状**
以下示例代码将帮助访问具有特定布局类型的SmartArt形状。请注意，您不能更改SmartArt的布局类型，因为它是只读的，并且仅在添加SmartArt形状时设置。

- 创建一个 `Presentation` 类的实例，并加载具有SmartArt形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为SmartArt类型，并在它是SmartArt时将所选形状强制转换为SmartArt。
- 检查具有特定布局类型的SmartArt形状，并执行所需的操作。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **更改SmartArt形状样式**
以下示例代码将帮助访问具有特定布局类型的SmartArt形状。

- 创建一个 `Presentation` 类的实例，并加载具有SmartArt形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为SmartArt类型，并在它是SmartArt时将所选形状强制转换为SmartArt。
- 查找具有特定样式的SmartArt形状。
- 为SmartArt形状设置新样式。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **更改SmartArt形状颜色样式**
在此示例中，我们将学习如何更改任何SmartArt形状的颜色样式。在以下示例代码中，将访问具有特定颜色样式的SmartArt形状并更改其样式。

- 创建一个 `Presentation` 类的实例，并加载具有SmartArt形状的演示文稿。
- 通过使用其索引获取第一个幻灯片的引用。
- 遍历第一个幻灯片中的每个形状。
- 检查形状是否为SmartArt类型，并在它是SmartArt时将所选形状强制转换为SmartArt。
- 查找具有特定颜色样式的SmartArt形状。
- 为SmartArt形状设置新颜色样式。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}