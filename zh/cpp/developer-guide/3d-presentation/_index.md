---
title: 使用 C++ 在演示文稿中创建 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、灯光、材质、拉伸、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for C++ 能够创建、编辑、保留并呈现 PowerPoint 样式的形状和文本的 3D 格式化。本文章涵盖了诸如旋转、拉伸、倒角、光照、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，并非插入或编辑独立的 3D 模型文件。将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 接口的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_threedformat/) 方法对形状应用 3D 格式化。该方法返回 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/) 接口的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。这会对文本框而非形状本体应用 3D 格式化。

最重要的方法如下：

| 方法 | 控制内容 | 何时使用 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_camera/) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [get_LightRig](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_lightrig/) | 灯光预设、方向和灯光旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [set_Material](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_material/) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何形状看起来更平坦、柔软、有光泽或金属感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形状从前表面向后延伸的距离。 | 将平面形状变为可见厚度的 3D 对象。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 拉伸侧面的颜色。 | 显示深度或将侧面颜色与前填充颜色协调。 |
| [set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式化使用的额外深度。 | 对形状或文本进行细微深度调节，尤其与倒角和材质设置一起使用时。 |
| [get_BevelTop](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_beveltop/) 和 [get_BevelBottom](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前后表面的凸起或圆角边缘。 | 为平面表面添加柔和或模具化的边缘，而不是锐利的平面。 |
| [get_ContourColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_contourcolor/) 和 [set_ContourWidth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四种设置才能看起来逼真 3D：

- 相机设置，因为默认的正面视图可能会隐藏拉伸效果。  
- 灯光设置，因为光照使各面和侧面可辨。  
- 材质设置，因为表面影响光线的渲染方式。  
- 拉伸或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其前表面添加文本，应用 3D 格式化，将演示文稿保存为 PPTX，并将幻灯片渲染为 PNG 图像。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

渲染的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，前面有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过 “3‑D 旋转” 面板配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 设置相机类型和旋转：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

当需要改变观看者看到对象的角度时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过将形状向后延伸，使其看起来更厚。PowerPoint 中的深度控制设置可见厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用 [set_ExtrusionHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 设置厚度，使用 [get_ExtrusionColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) 设置侧面颜色：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

当需要直接使用 PowerPoint 的深度值或将深度与倒角、材质、文本效果结合时，使用 [set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_depth/)。在许多形状场景下，`set_ExtrusionHeight` 更直观，因为它直接表达可见的拉伸高度。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。可以对前表面使用纯色、渐变、图案或图片填充，并仍然使用相同的相机、灯光、材质和拉伸设置。

下面示例对形状应用渐变填充，并将侧面颜色设为更深的拉伸颜色：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

渲染的输出保留前表面的渐变，并单独渲染拉伸：

![渲染的 3D 矩形，蓝到橙的渐变填充，橙色拉伸](img_02_03.png)

若改用图片填充，先将图像添加到演示文稿，再将其分配给形状填充：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

图片渲染在前表面，拉伸则渲染为 3D 侧面：

![渲染的 3D 矩形，前面为照片填充，橙色拉伸](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状本体，文本的 3D 格式化影响文本框。这对需要字母本身进行拉伸、材质、光照和相机设置的 WordArt 类效果非常有用。

下面示例创建带图案填充的文本，应用 WordArt 变换，并在 [ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/) 上配置 3D 设置：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

文本渲染为弧形、拉伸的 3D 字体：

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色拉伸](img_02_05.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。这适用于将幻灯片渲染为 [PNG](/slides/zh/cpp/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/cpp/convert-powerpoint-to-html/)，或为 [video conversion](/slides/zh/cpp/convert-powerpoint-to-video/) 生成帧。

请注意以下要点：

- 导出的图像和 PDF 不具交互性。导出后，观看者无法旋转对象。  
- 最终外观取决于相机、灯光、材质、拉伸、填充和幻灯片缩放的组合。  
- 如需检查继承或主题基础的格式值，请阅读 [effective shape properties](/slides/zh/cpp/shape-effective-properties/)。  
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的图像，而非可编辑的 3D 设置。

## **常见问题**

### Aspose.Slides 能创建交互式 3D 演示文稿吗？

Aspose.Slides 创建并渲染形状和文本的 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可旋转的交互式 3D 场景。在 PPTX 中，3D 格式化仍保持可编辑（前提是格式本身支持）。  

### 3D 模型和 3D 效果有什么区别？

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、倒角、光照和材质。本文讨论的正是 3D 效果。  

### 需要哪些设置才能看到可见的 3D 形状？

至少需要设置相机旋转并启用拉伸或深度。实践中，还应设置灯光和材质，以便渲染出的面具有清晰的高光和阴影。  

### 能同时对形状和文本应用 3D 效果吗？

可以。对形状本体使用 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/)，对文本使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/)。  

### 导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。  

### 能读取继承和主题设置后最终的 3D 值吗？

能。使用在 [effective shape properties](/slides/zh/cpp/shape-effective-properties/) 中描述的有效格式化 API，可读取最终的相机、灯光、倒角及相关 3D 值。