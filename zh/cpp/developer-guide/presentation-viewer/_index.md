---
title: 演示文稿查看器
type: docs
weight: 50
url: /cpp/presentation-viewer/
keywords: 
- 查看 PowerPoint 演示文稿
- 查看 ppt
- 查看 PPTX
- C++
- Aspose.Slides for C++
description: "在 C++ 中查看 PowerPoint 演示文稿"
---

## **从幻灯片生成 SVG 图像**
Aspose.Slides for C++ 用于创建演示文稿文件，包含幻灯片。可以通过使用 Microsoft PowerPoint 打开演示文稿来查看这些幻灯片。但有时，开发人员可能还需要在他们喜欢的图像查看器中以 SVG 图像查看幻灯片。在这种情况下，Aspose.Slides for C++ 允许您将单个幻灯片导出为 SVG 图像。本文描述了如何使用此功能。要使用 Aspose.Slides.Pptx for C++ 从任何所需幻灯片生成 SVG 图像，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过使用其 ID 或索引获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存到文件中。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **使用自定义形状 ID 生成 SVG**
现在 Aspose.Slides for C++ 可以用来自定义形状 ID 的幻灯片生成 SVG。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿来看。但有时，开发人员可能还需要在他们喜欢的图像查看器中以 SVG 图像查看幻灯片。在这种情况下，Aspose.Slides for C++ 允许您将单个幻灯片导出为 SVG 图像。为此，已将 ID 属性添加到 ISvgShape 以支持生成 SVG 中形状的自定义 ID。为了实现此功能，介绍了一个 CustomSvgShapeFormattingController，您可以使用它来设置形状 ID。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}

## **创建幻灯片缩略图图像**
Aspose.Slides for C++ 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿文件进行查看。但有时，开发人员可能需要使用他们喜欢的图像查看器以图像的形式查看幻灯片。在这种情况下，Aspose.Slides for C++ 可以帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides for C++ 生成任何所需幻灯片的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在指定比例下获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```cpp
// 实例化 Presentation 类
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlide.pptx");

// 访问第一张幻灯片
auto slide = presentation->get_Slide(0);

// 创建全尺寸图像
auto image = slide->GetImage(1, 1);
image->Save(u"Thumbnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **使用用户定义的尺寸创建缩略图**
1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在指定比例下获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```cpp
// 实例化 Presentation 类
auto presentation = MakeObject<Presentation>(u"ThumbnailWithUserDefinedDimensions.pptx");

// 访问第一张幻灯片
auto slide = presentation->get_Slide(0);

// 用户定义的尺寸
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// 获取 X 和 Y 的缩放值
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// 创建自定义缩放图像
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Thumbnail2_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **在注释幻灯片视图中从幻灯片创建缩略图**
要使用 Aspose.Slides for C++ 生成任何所需幻灯片在注释幻灯片视图中的缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在注释幻灯片视图中，以指定比例获取引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

下面的代码片段生成演示文稿第一张幻灯片在注释幻灯片视图中的缩略图。

```cpp
// 实例化 Presentation 类
auto presentation = MakeObject<Presentation>(u"ThumbnailFromSlideInNotes.pptx");

// 访问第一张幻灯片
auto slide = presentation->get_Slide(0);

// 用户定义的尺寸
auto desiredX = 1200;
auto desiredY = 800;

auto slideSize = presentation->get_SlideSize()->get_Size();

// 获取 X 和 Y 的缩放值
auto scaleX = (float)(1.0 / slideSize.get_Width()) * desiredX;
auto scaleY = (float)(1.0 / slideSize.get_Height()) * desiredY;

// 创建全尺寸图像
auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"Notes_tnail_out.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```