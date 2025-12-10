---
title: C++ 中的组演示形状
linktitle: 形状组
type: docs
weight: 40
url: /zh/cpp/group/
keywords:
- 组形状
- 形状组
- 添加组
- 替代文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 对 PowerPoint 文稿中的形状进行分组和取消分组——快速、一步步的指南，附带免费 C++ 代码。"
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上使用组形状。此功能帮助开发人员创建更丰富的演示文稿。Aspose.Slides for C++ 支持添加或访问组形状。可以向已添加的组形状中添加形状以填充它，或访问组形状的任何属性。要使用 Aspose.Slides for C++ 将组形状添加到幻灯片中，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加组形状。  
4. 向已添加的组形状中添加形状。  
5. 将修改后的演示文稿保存为 PPTX 文件。  

下面的示例向幻灯片添加组形状。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **访问 AltText 属性**
本主题展示了添加组形状并访问幻灯片上组形状的 AltText 属性的简要步骤和代码示例。要使用 Aspose.Slides for C++ 访问幻灯片中组形状的 AltText，请执行以下操作：

1. 实例化表示 PPTX 文件的 `Presentation` 类。  
2. 使用索引获取幻灯片的引用。  
3. 访问幻灯片的形状集合。  
4. 访问组形状。  
5. 访问 AltText 属性。  

下面的示例访问组形状的替代文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **常见问题**

**是否支持嵌套分组（组内包含组）？**  
是的。 [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) 具有 [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) 方法，直接表明层级支持（一个组可以是另一个组的子组）。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**  
使用 [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) 的 [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) 来检查其在显示堆栈中的位置。

**我能阻止移动/编辑/取消组合吗？**  
是的。通过 [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/) 可访问组的锁定部分，从而可以限制对该对象的操作。