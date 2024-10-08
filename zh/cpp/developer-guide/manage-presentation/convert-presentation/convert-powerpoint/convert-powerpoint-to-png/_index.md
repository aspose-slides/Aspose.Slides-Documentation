---
title: 将 PowerPoint 转换为 PNG
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-png/
keywords: PowerPoint 转 PNG, PPT 转 PNG, PPTX 转 PNG, C++, Aspose.Slides for C++
description: 将 PowerPoint 演示文稿转换为 PNG
---

## **关于 PowerPoint 转 PNG 转换**

PNG（可移植网络图形）格式并不像 JPEG（联合图像专家组）那样流行，但仍然相当受欢迎。

**用例：** 当您有复杂图像且大小不是问题时，PNG 是比 JPEG 更好的图像格式。

{{% alert title="提示" color="primary" %}} 您可能想查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**： [PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是此页面描述过程中实时实现的示例。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

请遵循以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类。
2. 从 [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合中获取 [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) 接口的幻灯片对象。
3. 使用 [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) 方法获取每个幻灯片的缩略图。
4. 使用 [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) 方法将幻灯片缩略图保存为 PNG 格式。

以下 C++ 代码演示如何将 PowerPoint 演示文稿转换为 PNG：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果您希望获得特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定了生成缩略图的尺寸。

以下 C++ 代码演示了上述操作：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **使用自定义大小将 PowerPoint 转换为 PNG**

如果您希望获得特定大小的 PNG 文件，可以为 `ImageSize` 传递您首选的 `width` 和 `height` 参数。

以下代码演示如何在指定图像大小的同时将 PowerPoint 转换为 PNG：

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```