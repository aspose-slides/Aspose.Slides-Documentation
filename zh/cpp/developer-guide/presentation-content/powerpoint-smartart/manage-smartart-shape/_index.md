---
title: 使用 C++ 管理演示文稿中的 SmartArt 图形
linktitle: SmartArt 图形
type: docs
weight: 20
url: /zh/cpp/manage-smartart-shape/
keywords:
- SmartArt 对象
- SmartArt 图形
- SmartArt 样式
- SmartArt 颜色
- 创建 SmartArt
- 添加 SmartArt
- 编辑 SmartArt
- 更改 SmartArt
- 访问 SmartArt
- SmartArt 布局类型
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中自动化 PowerPoint SmartArt 的创建、编辑和样式设置，提供简洁的代码示例和以性能为中心的指南。"
---

## **创建 SmartArt 形状**
Aspose.Slides for C++ 现在可以从头在幻灯片中添加自定义 SmartArt 形状。Aspose.Slides for C++ 提供了最简易的 API，以最方便的方式创建 SmartArt 形状。要在幻灯片中创建 SmartArt 形状，请按以下步骤操作：

- 创建 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 通过设置 LayoutType 添加 SmartArt 形状。
- 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **访问幻灯片上的 SmartArt 形状**
以下代码用于访问演示文稿幻灯片中添加的 SmartArt 形状。在示例代码中，我们将遍历幻灯片中的每个形状，并检查它是否为 SmartArt 形状。如果是 SmartArt 类型，则将其转换为 SmartArt 实例。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **访问具有特定布局类型的 SmartArt 形状**
以下示例代码帮助访问具有特定 LayoutType 的 SmartArt 形状。请注意，SmartArt 的 LayoutType 只能在添加 SmartArt 形状时设置，之后不可更改。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定形状强制转换为 SmartArt。
- 检查具有特定 LayoutType 的 SmartArt 形状，并在随后执行所需操作。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **更改 SmartArt 形状样式**
以下示例代码帮助访问具有特定布局类型的 SmartArt 形状。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定形状强制转换为 SmartArt。
- 查找具有特定 Style 的 SmartArt 形状。
- 为 SmartArt 形状设置新的 Style。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **更改 SmartArt 形状颜色样式**
本示例演示如何更改任意 SmartArt 形状的颜色样式。以下示例代码将访问具有特定颜色样式的 SmartArt 形状并更改其样式。

- 创建 `Presentation` 类的实例并加载包含 SmartArt 形状的演示文稿。
- 使用索引获取第一张幻灯片的引用。
- 遍历第一张幻灯片中的每个形状。
- 检查形状是否为 SmartArt 类型，并在是 SmartArt 时将选定形状强制转换为 SmartArt。
- 查找具有特定 Color Style 的 SmartArt 形状。
- 为 SmartArt 形状设置新的 Color Style。
- 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**我可以将 SmartArt 作为单个对象进行动画处理吗？**

可以。SmartArt 是一种形状，因此您可以通过动画 API（入口、退出、强调、运动路径）像对其他形状一样应用[标准动画](/slides/zh/cpp/powerpoint-animation/)。

**如果不知道内部 ID，如何在幻灯片上找到特定的 SmartArt？**

设置并使用替代文本（AltText），然后按该值搜索形状——这是定位目标形状的推荐方式。

**我可以将 SmartArt 与其他形状分组吗？**

可以。您可以将 SmartArt 与其他形状（图片、表格等）分组，然后[操作该组](/slides/zh/cpp/group/)。

**如何获取特定 SmartArt 的图像（例如用于预览或报告）？**

导出该形状的缩略图/图像；库可以将[单个形状渲染](/slides/zh/cpp/create-shape-thumbnails/)为栅格文件（PNG/JPG/TIFF）。

**将整个演示文稿转换为 PDF 时，SmartArt 的外观会被保留吗？**

会。渲染引擎针对[PDF 导出](/slides/zh/cpp/convert-powerpoint-to-pdf/)实现高保真度，并提供多种质量和兼容性选项。