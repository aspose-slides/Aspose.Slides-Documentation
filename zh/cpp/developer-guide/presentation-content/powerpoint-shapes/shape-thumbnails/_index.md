---
title: 在 C++ 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/cpp/shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 从 PowerPoint 幻灯片生成高质量的形状缩略图 – 轻松创建和导出演示文稿缩略图。"
---
## **介绍**

Aspose.Slides 用于创建每页为幻灯片的演示文稿文件。可以通过 Microsoft PowerPoint 打开这些演示文稿文件进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides 可以帮助您生成幻灯片形状的缩略图。本文将介绍如何使用此功能。

本文说明了以不同方式生成幻灯片缩略图的方法：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状生成具有用户自定义尺寸的形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
使用 Aspose.Slides for C++ 从任意幻灯片生成形状缩略图的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 以默认比例获取引用幻灯片的形状缩略图图像。
4. 将缩略图图像保存为任意所需的图像格式。

下面的示例生成形状缩略图。

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **生成用户自定义缩放因子缩略图**
使用 Aspose.Slides for C++ 为任意幻灯片形状生成形状缩略图的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 获取带有形状边界的引用幻灯片的缩略图图像。
4. 将缩略图图像保存为任意所需的图像格式。

下面的示例使用用户自定义缩放因子生成缩略图。

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // 在 X 和 Y 轴上缩放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **创建基于边界的形状外观缩略图**
此方法用于创建形状缩略图，允许开发人员在形状外观的边界内生成缩略图，并考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在外观边界内生成任意幻灯片形状的缩略图，请使用以下示例代码：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 获取引用幻灯片的缩略图图像，使用形状边界作为外观。
4. 将缩略图图像保存为任意所需的图像格式。

下面的示例创建基于外观边界的缩略图。

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // 在 X 和 Y 轴上缩放。

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **获取形状的实际可视边界**

[IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 的框架属性——`IShape::get_X()`、`IShape::get_Y()`、`IShape::get_Width()` 和 `IShape::get_Height()`——描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占据不同的轴对齐矩形。旋转、轮廓、箭头、文本布局和溢出、生成的 SmartArt 几何形状以及其他渲染效果都可能改变占用区域。

使用 [Shape::GetVisualBounds](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getvisualbounds/) 可在不创建图像的情况下计算该占用区域。此方法返回以幻灯片坐标表示的 [RectangleF](https://reference.aspose.com/slides/zh/cpp/system.drawing/rectanglef/)。返回的矩形不受幻灯片裁剪，因此当内容超出幻灯片原点时，其坐标可能为负。

[Shape::GetVisualBounds](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getvisualbounds/) 目前未在 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 接口中声明。因此，请将从幻灯片形状集合中获取的形状保持为接口类型的值，仅在调用该方法时进行强制转换。

以下示例获取并比较框架和可视边界：

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

相同的 [RectangleF](https://reference.aspose.com/slides/zh/cpp/system.drawing/rectanglef/) 可用于将相邻形状对齐到其 `RectangleF::get_Left()`、`RectangleF::get_Right()`、`RectangleF::get_Top()` 或 `RectangleF::get_Bottom()` 边缘；在生成的布局中预留足够空间；或检测内容是否超出允许的区域。可视边界在 SmartArt、文本框、箭头、图片、旋转形状和组形状等场景尤为有用，因为存储的框架可能并未完整表示渲染结果。

在需要布局或验证坐标且不需要位图时，请使用 [Shape::GetVisualBounds]。在需要渲染形状时，请使用 [IShape::GetImage]。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds::Shape` 根据形状边界（包括轮廓设置）确定图像大小，而 `ShapeThumbnailBounds::Appearance` 根据形状的外观确定大小并限制结果在幻灯片边界内。相比之下，[Shape::GetVisualBounds] 仅返回计算出的矩形，不会裁剪到幻灯片。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**  
[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将其内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**  
`Shape` 使用形状的几何结构；`Appearance` 会考虑[可视效果](/slides/zh/cpp/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏会怎样？它仍会生成缩略图吗？**  
隐藏的形状仍然是模型的一部分，可以渲染；隐藏标记仅影响放映时的显示，不会阻止生成形状图像。

**是否支持组形状、图表、SmartArt 和其他复杂对象？**  
支持。任何以 [Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/) 表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**  
会。应[提供所需字体](/slides/zh/cpp/custom-font/)（或[配置字体替换](/slides/zh/cpp/font-substitution/)），以避免不期望的回退和文本重排。