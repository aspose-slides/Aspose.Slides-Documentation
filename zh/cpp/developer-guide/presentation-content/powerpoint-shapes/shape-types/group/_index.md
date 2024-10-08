---
title: 组
type: docs
weight: 40
url: /zh/cpp/group/
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上使用组形状。该功能帮助开发者支持更丰富的演示文稿。Aspose.Slides for C++ 支持添加或访问组形状。可以向已添加的组形状中添加形状以填充它，或访问组形状的任何属性。使用 Aspose.Slides for C++ 向幻灯片添加组形状的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 向幻灯片添加一个组形状。
1. 向已添加的组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组形状。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **访问 AltText 属性**
本主题展示了简单的步骤，配有代码示例，用于添加组形状和访问幻灯片上组形状的 AltText 属性。使用 Aspose.Slides for C++ 访问幻灯片中组形状的 AltText 的步骤如下：

1. 实例化 `Presentation` 类，该类表示一个 PPTX 文件。
1. 通过使用其索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问 AltText 属性。

下面的示例访问组形状的替代文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}