---
title: 在 C++ 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/cpp/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿转 PNG
- 幻灯片转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精确且自动化的结果。"
---

## **关于 PowerPoint 到 PNG 转换**

PNG（可移植网络图形）格式虽然没有 JPEG（联合图像专家组）那么流行，但它依然非常流行。 

**使用场景：** 当您拥有复杂的图像且对尺寸没有要求时，PNG 是比 JPEG 更好的图像格式。 

{{% alert title="Tip" color="primary" %}} 您可能想了解 Aspose 免费的 **PowerPoint 到 PNG 转换器**： [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页面所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类。  
2. 从 [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合中获取 [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) 接口下的幻灯片对象。  
3. 使用 [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) 方法获取每张幻灯片的缩略图。  
4. 使用 [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) 方法将幻灯片缩略图保存为 PNG 格式。  

以下 C++ 代码演示了如何将 PowerPoint 演示文稿转换为 PNG：
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

如果您希望获得特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定生成的缩略图尺寸。 

下面的 C++ 代码演示了上述操作：
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

如果您希望获取特定尺寸的 PNG 文件，可以为 `ImageSize` 传入您偏好的 `width` 和 `height` 参数。 

以下代码展示了在指定图像尺寸的情况下，将 PowerPoint 转换为 PNG 的方法： 
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


## **常见问题**

**如何仅导出特定形状（例如图表或图片）而不是整张幻灯片？**  
Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/cpp/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**  
是的，但请 [不要共享](/slides/zh/cpp/multithreading/) 单个演示文稿实例于多个线程。每个线程或进程应使用单独的实例。

**导出为 PNG 时试用版有哪些限制？**  
评估模式会在输出图像上添加水印，并在应用许可证前强制执行 [其他限制](/slides/zh/cpp/licensing/)。