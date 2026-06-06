---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 280
url: /zh/cpp/modern-api/
keywords:
- System.Drawing
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- C++
- Aspose.Slides
description: "通过使用 C++ 现代 API 替代已弃用的影像 API，实现幻灯片图像处理的现代化，以实现 PowerPoint 和 OpenDocument 的无缝自动化。"
---
## **介绍**

目前，Aspose.Slides for C++ 库在其公共 API 中依赖以下 System::Drawing 类：
- [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/zh/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/zh/cpp/system.drawing/bitmap/)

自 24.4 版起，这些公共 API 已标记为过时。

为了消除公共 API 对 System::Drawing 的依赖，我们添加了所谓的 “Modern API”。使用 [System::Drawing::Image](https://reference.aspose.com/slides/zh/cpp/system.drawing/image/) 和 [System::Drawing::Bitmap](https://reference.aspose.com/slides/zh/cpp/system.drawing/bitmap/) 的方法已标记为过时，应该改为使用 Modern API 中的对应方法。使用 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/) 的方法已标记为过时，且没有直接的 Modern API 替代。

在当前版本中，请将依赖 System::Drawing 类型的公共 API 视为遗留/过时。新代码和迁移现有图像处理工作流时请使用 Modern API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/) - 表示图像的文件格式。
- [Aspose::Slides::Images](https://reference.aspose.com/slides/zh/cpp/aspose.slides/images/) - 用于实例化和操作 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 接口的方法。

使用 `GetImage` 渲染单个幻灯片或形状。使用 `GetImages` 渲染多个演示文稿幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/cpp/aspose.slides/images/) 方法加载图像，使用 `AddImage` 与 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 将其添加到演示文稿，使用 `ReplaceImage` 与 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 更新已有的演示文稿图像。

使用新 API 的典型场景如下所示：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// 从磁盘上的文件实例化一个一次性使用的 IImage 实例。  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// 通过将 IImage 实例添加到演示文稿的图像集合中来创建 PowerPoint 图像。
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// 在第 1 张幻灯片上添加图片形状。
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// 获取表示第 1 张幻灯片的 IImage 实例。
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// 将图像保存到磁盘上。
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **使用现代 API 替换旧代码**

为简化迁移，新 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 的接口重复了 [System::Drawing::Image](https://reference.aspose.com/slides/zh/cpp/system.drawing/image/) 和 [System::Drawing::Bitmap](https://reference.aspose.com/slides/zh/cpp/system.drawing/bitmap/) 类的独立签名。通常，只需将使用 System::Drawing 的旧方法调用替换为新方法。

### **获取幻灯片缩略图**

遗留/过时 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

现代 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **获取形状缩略图**

遗留/过时 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

现代 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **获取演示文稿缩略图**

遗留/过时 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

现代 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **向演示文稿添加图片**

遗留/过时 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

现代 API：

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **已弃用的方法/属性及其在现代 API 中的替代方案**

### **Presentation 类**
|方法签名|替代方法签名|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide 类**
|方法签名|替代方法签名|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape 类**
|方法签名|替代方法签名|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection 类**
|方法签名|替代方法签名|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage 类**
|方法签名|替代方法签名|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat 类**
|方法签名|替代方法签名|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData 类**
|方法签名|替代方法签名|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **针对 System::Drawing::Graphics 的 API 支持**

使用 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/) 的方法已标记为过时，且没有直接的 Modern API 替代。

请改用 Modern API 的图像渲染方法，而不是渲染到 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/)：
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **常见问题解答**

**为什么移除了 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/)？**

在公共 API 中弃用对 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/) 的支持，以统一渲染和图像的工作方式，消除对平台特定依赖的绑定，并通过 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 转向跨平台方案。请使用 `GetImage` 或 `GetImages` 而不是渲染到 [System::Drawing::Graphics](https://reference.aspose.com/slides/zh/cpp/system.drawing/graphics/)。

**与 [System::Drawing::Image](https://reference.aspose.com/slides/zh/cpp/system.drawing/image/) / [System::Drawing::Bitmap](https://reference.aspose.com/slides/zh/cpp/system.drawing/bitmap/) 相比，使用 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 有什么实际好处？**

[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 统一了对光栅和矢量图像的操作，通过 [ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/) 简化了多种格式的保存，降低了对 `System::Drawing` 的依赖，使代码在不同环境下更具可移植性。

**使用现代 API 会影响生成缩略图的性能吗？**

从 `GetThumbnail` 切换到 `GetImage` 不会导致性能下降：新方法在提供相同的选项和尺寸生成图像的能力的同时，仍然保留对渲染选项的支持。具体的提升或下降取决于使用场景，但功能上两者是等价的。