---
title: 形状格式化
type: docs
weight: 20
url: /zh/cpp/shape-formatting/
keywords: "格式化形状, 格式化线条, 格式化连接样式, 渐变填充, 图案填充, 图片填充, 实心颜色填充, 旋转形状, 3d 倾斜效果, 3d 旋转效果, PowerPoint 演示文稿, C++, Aspose.Slides for С++"
description: "在 C++ 中格式化 PowerPoint 演示文稿中的形状"
---

在 PowerPoint 中，可以向幻灯片添加形状。由于形状由线条构成，因此可以通过修改或应用某些效果来格式化形状。此外，可以通过指定设置来格式化形状，以决定它们（形状内部的区域）如何填充。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for C++** 提供接口和属性，使您能够根据 PowerPoint 中已知的选项格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定首选的线条样式。以下步骤概述了这样的过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 为形状线条设置颜色。
5. 为形状线条设置宽度。
6. 为形状线条设置 [线条样式](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4)。
7. 为形状线条设置 [虚线样式](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了格式化矩形 `AutoShape` 的操作：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加矩形类型的自动形状
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 设置矩形形状的填充颜色
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// 对矩形的线条应用一些格式
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 设置矩形线条的颜色
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **格式化连接样式**
以下是三种连接类型选项：

* 圆角
* 斜切
* 倒角

默认情况下，当 PowerPoint 以角度连接两条线（或形状的角）时，它使用 **圆角** 设置。然而，如果您希望绘制一个具有非常尖锐角度的形状，您可能想选择 **斜切**。

![join-style-powerpoint](join-style-powerpoint.png)

以下 C++ 代码演示了使用斜切、倒角和圆角连接类型设置创建 3 个矩形（如上图）：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加 3 个矩形自动形状
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// 设置矩形形状的填充颜色
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 设置线条的宽度
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 设置矩形线条的颜色
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 设置连接样式
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 为每个矩形添加文本
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **渐变填充**
在 PowerPoint 中，渐变填充是一种格式选项，允许您将颜色连续混合应用于形状。例如，您可以应用两种或更多颜色，使一种颜色逐渐消失并转变为另一种颜色。

以下是如何使用 Aspose.Slides 将渐变填充应用于形状的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 设置为 `Gradient`。
5. 使用与 `GradientFormat` 类关联的 `GradientStops` 集合的 `Add` 方法添加您首选的 2 种颜色及其位置。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示在椭圆上使用渐变填充效果的操作：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);
    
// 添加一个椭圆自动形状
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// 将渐变格式应用于椭圆
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// 设置渐变的方向
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 添加 2 个渐变停止
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// 将 PPTX 文件写入磁盘
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **图案填充**
在 PowerPoint 中，图案填充是一种格式选项，允许您将由点、条纹、交叉阴影或格子组成的双色设计应用于形状。此外，您可以选择首选的图案前景和背景颜色。

Aspose.Slides 提供 45 种以上的预定义样式，可用于格式化形状并丰富演示文稿。即使在选择了预定义图案后，您仍然可以指定图案必须包含的颜色。

以下是如何使用 Aspose.Slides 将图案填充应用于形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 设置为 `Pattern`。
5. 为形状设置首选图案样式。
6. 为 [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format) 设置 [背景颜色](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e)。
7. 为 [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format) 设置 [前景颜色](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了如何使用图案填充美化一个矩形：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加一个矩形自动形状
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 设置填充类型为图案
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// 设置图案样式
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// 设置图案的背景色和前景色
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **图片填充**
在 PowerPoint 中，图片填充是一种格式选项，允许您在形状内部放置图片。本质上，您可以将图像用作形状的背景。

以下是如何使用 Aspose.Slides 用图片填充形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 设置为 `Picture`。
5. 将图片填充模式设置为 Tile。
6. 使用将用于填充形状的图像创建 `IPPImage` 对象。
7. 将 `PictureFillFormat` 对象的 `Picture.Image` 属性设置为最近创建的 `IPPImage`。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了如何用图片填充形状：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加一个矩形自动形状
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 将填充类型设置为图片
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// 设置图片填充模式
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 设置图片
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **实心颜色填充**
在 PowerPoint 中，实心颜色填充是一种格式选项，允许您使用单一颜色填充形状。所选颜色通常是纯色。该颜色应用于形状背景，没有特殊效果或修改。

以下是如何使用 Aspose.Slides 将实心颜色填充应用于形状的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) 设置为 `Solid`。
5. 为形状设置首选颜色。
6. 将修改后的演示文稿写入 PPTX 文件。

上述步骤在下面的示例中实现。

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加一个矩形自动形状
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 将填充类型设置为实心
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// 设置矩形的颜色
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **设置透明度**

在 PowerPoint 中，当您用实心颜色、渐变、图片或纹理填充形状时，可以指定透明度级别，该级别决定了填充的透明度。例如，如果您设置低透明度级别，则幻灯片对象或背景（在形状后面）会透过。

Aspose.Slides 允许您以这种方式为形状设置透明度级别：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 使用 `Color.FromArgb` 设置 alpha 组件。
5. 将对象保存为 PowerPoint 文件。

以下 C++ 代码演示了该过程：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加一个实心形状
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// 在实心形状上添加一个透明形状
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// 将 PPTX 文件写入磁盘
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **旋转形状**
Aspose.Slides 允许您以这种方式旋转添加到幻灯片的形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
4. 按照需要的度数旋转形状。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了如何将形状旋转 90 度：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 添加一个矩形自动形状
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// 将形状旋转 90 度
autoShape->set_Rotation(90.f);

// 将 PPTX 文件写入磁盘
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **添加 3D 倾斜效果**
Aspose.Slides 允许您通过修改形状的 [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) 属性以这种方式为形状添加 3D 倾斜效果：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
3. 设置您首选的形状 [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) 属性参数。
4. 将演示文稿写入磁盘。

以下 C++ 代码演示了如何向形状添加 3D 倾斜效果：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);

// 向幻灯片添加一个形状
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// 设置形状的 ThreeDFormat 属性
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// 将演示文稿保存为 PPTX 文件
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **添加 3D 旋转效果**
Aspose.Slides 允许您通过修改形状的 [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) 属性以这种方式为形状应用 3D 旋转效果：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape)。
3. 指定您首选的 [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) 和 [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f) 的属性。
4. 将演示文稿写入磁盘。

以下 C++ 代码演示了如何为形状应用 3D 旋转效果：

```cpp
// 实例化一个表示演示文稿文件的演示文稿类
auto pres = MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);
    
// 向幻灯片添加一个形状
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// 设置形状的 ThreeDFormat 属性
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// 向幻灯片添加一个形状
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 30, 300, 200, 200);

// 设置形状的 ThreeDFormat 属性
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// 将演示文稿保存为 PPTX 文件
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **重置格式**

以下 C++ 代码演示了如何在幻灯片中重置格式，并将每个在 [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide) 上有占位符的形状的位置、大小和格式还原到其默认值：

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // 每个在幻灯片上有占位符的形状将被还原
    slide->Reset();
}
```