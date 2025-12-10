---
title: 在 C++ 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/cpp/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 实色填充
- 形状透明度
- 旋转形状
- 3D 倾角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中格式化 PowerPoint 形状——为 PPT、PPTX 和 ODP 文件精准且完全控制地设置填充、线条和效果样式。"
---

## **概述**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或应用效果到其轮廓来格式化它们。此外，您还可以通过指定设置来控制形状内部的填充方式，从而格式化形状。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ 提供接口和方法，允许您使用 PowerPoint 中可用的相同选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线条的 [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的代码演示如何格式化矩形 `AutoShape`：
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个矩形类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 设置矩形形状的填充颜色。
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 对矩形的线条应用格式设置。
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 设置矩形线条的颜色。
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![演示文稿中的格式化线条](formatted-lines.png)

## **格式化连接样式**

以下是三种连接类型选项：

* 圆角
* 斜角
* 斜切

默认情况下，PowerPoint 在以角度连接两条线（例如在形状的角落）时使用 **Round** 设置。然而，如果您绘制的是具有尖角的形状，您可能更喜欢 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 C++ 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建图中所示的三个矩形：
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加三个矩形类型的自动形状。
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// 为每个矩形形状设置填充颜色。
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 设置线宽。
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 为每个矩形的线条设置颜色。
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 设置连接样式。
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 向每个矩形添加文本。
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色渐变。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) 接口公开的渐变停止集合的 `Add` 方法，添加您首选的两种颜色并定义位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个椭圆类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 对椭圆应用渐变格式。
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// 设置渐变的方向。
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 添加两个渐变停靠点。
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![椭圆的渐变填充](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用双颜色设计，例如点、条纹、交叉线或棋盘格。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供超过 45 种预定义的图案样式，您可以将其应用于形状，以增强演示文稿的视觉效果。即使选择了预定义图案，仍可指定其使用的确切颜色。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/)。
1. 将修改后的演示文稿保存为 PPTX 文件。

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个矩形类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 将填充类型设置为 Pattern。
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// 设置图案样式。
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// 设置图案的背景色和前景色。
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实质上将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 从您想使用的图像创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 对象。
1. 将图像传递给 `ISlidesPicture.set_Image` 方法。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 "lotus.png" 的文件，其图片如下：

![莲花图片](lotus.png)

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个矩形类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 将填充类型设置为 Picture。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 设置图片填充模式。
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 加载图像并将其添加到演示文稿资源中。
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// 设置图片。
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![带图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果想将平铺的图片设为纹理并自定义平铺行为，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) 类的方法：

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)：设置图片填充模式——`Tile` 或 `Stretch`。
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/)：指定平铺在形状内部的对齐方式。
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/)：控制平铺是水平翻转、垂直翻转还是同时翻转。
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/)：设置平铺相对于形状原点的水平偏移（以点为单位）。
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/)：设置平铺相对于形状原点的垂直偏移（以点为单位）。
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/)：定义平铺的水平缩放比例（百分比）。
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/)：定义平铺的垂直缩放比例（百分比）。

以下代码示例展示如何添加带平铺图片填充的矩形形状并配置平铺选项：
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto firstSlide = presentation->get_Slide(0);

// 添加一个矩形自动形状。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 将形状的填充类型设置为 Picture。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 加载图像并将其添加到演示文稿资源中。
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 将图像分配给形状。
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 配置图片填充模式和平铺属性。
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![平铺选项](tile-options.png)

## **实色填充**

在 PowerPoint 中，实色填充是一种格式化选项，用单一均匀的颜色填充形状。这种纯色背景不包含任何渐变、纹理或图案。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状分配您首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个矩形类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 将填充类型设置为 Solid。
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 设置填充颜色。
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![带实色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当对形状应用实色、渐变、图片或纹理填充时，您还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更透，使背景或底层对象部分可见。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度级别。以下是操作方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 `Color` 定义带透明度的颜色（alpha 分量控制透明度）。
1. 保存演示文稿。

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个实心矩形自动形状。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 在实心形状上添加一个透明矩形自动形状。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 使您能够在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计的视觉元素定位时非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 将形状的 rotation 属性设置为所需角度。
1. 保存演示文稿。

```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 获取第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 添加一个矩形类型的自动形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 将形状旋转 5 度。
shape->set_Rotation(5);

// 将 PPTX 文件保存到磁盘。
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾角效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) 属性来应用 3D 倾角效果。

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) 以定义倾角设置。
1. 保存演示文稿。

```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 向幻灯片添加形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// 设置形状的 ThreeDFormat 属性。
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// 将演示文稿保存为 PPTX 文件。
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![3D 倾角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) 属性来应用 3D 旋转效果。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。
1. 使用 [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) 和 [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) 定义 3D 旋转。
1. 保存演示文稿。

```cpp
// 创建 Presentation 类的实例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// 将演示文稿保存为 PPTX 文件。
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![3D 旋转效果](3D-rotation-effect.png)

## **重置格式**

以下 C++ 代码展示如何重置幻灯片的格式，并将位于 [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) 上的所有带占位符的形状的位置信息、大小和格式恢复为默认设置：
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 重置幻灯片上所有在布局占位符上的形状。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **常见问题**

**形状格式化会影响最终的演示文稿文件大小吗？**

影响很小。嵌入的图像和媒体占据了大部分文件空间，而形状参数（如颜色、效果和渐变）以元数据形式存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应的值匹配，则视为相同样式，并在逻辑上对这些形状进行分组，这有助于后续的样式管理。

**我可以将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。