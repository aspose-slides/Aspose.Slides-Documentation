---
title: 形状缩略图
type: docs
weight: 70
url: /zh/cpp/shape-thumbnails/
keywords: 
- 形状缩略图
- 形状图像
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for С++
description: "从 PowerPoint 演示文稿中提取形状缩略图，使用 C++"
---


## **创建形状缩略图**
Aspose.Slides for C++ 用于创建演示文档文件，每一页都是一张幻灯片。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文档文件来查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for C++ 帮助您生成幻灯片形状的缩略图。如何使用此功能将在本文章中描述。
本文解释了如何以不同方式生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为具有用户定义尺寸的幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。
- 生成 SmartArt 子节点的缩略图。

## **从幻灯片生成形状缩略图**
要从任何幻灯片生成形状缩略图，使用 Aspose.Slides for C++：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的形状缩略图图像，使用默认比例。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成形状缩略图。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **生成用户定义缩放因子的缩略图**
要生成任何幻灯片形状的形状缩略图，使用 Aspose.Slides for C++：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取形状边界的引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成一个具有用户定义缩放因子的缩略图。

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // 在 X 和 Y 轴上的缩放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **创建形状外观的边界缩略图**
此方法用于创建形状的缩略图，使开发人员能够在形状外观的边界内生成缩略图。它考虑了所有的形状效果。生成的形状缩略图受到幻灯片边界的限制。要在任何幻灯片形状的外观边界内生成缩略图，请使用以下示例代码：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取其外观作为形状边界的引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成一个具有用户定义缩放因子的缩略图。

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // 在 X 和 Y 轴上的缩放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```