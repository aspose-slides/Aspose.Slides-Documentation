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
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、灯光、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for C++ 可以创建、编辑、保留并渲染类似 PowerPoint 的形状和文本的 3D 格式。本篇文章覆盖旋转、挤压、倒角、灯光、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}

本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，而不是插入或编辑独立的 3D 模型文件。将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染为导出的 2D 输出。

{{% /alert %}}

## **3D 格式化概念**

使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) 方法对形状应用 3D 格式化。该方法返回 [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。该方法对文本框而不是形状本体应用 3D 格式化。

最重要的方法包括：

| 方法 | 控制内容 | 使用时机 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | 灯光预设、方向和灯光旋转。 | 改变 3D 表面上高光和阴影的显示方式。 |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | 表面材质，如平面、哑光、塑料或金属。 | 使相同几何形状看起来更平坦、柔和、光亮或金属感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形状从前表面向后延伸的距离。 | 将平面形状转换为可见厚度的 3D 对象。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 挤压侧面的颜色。 | 显示深度或将侧面颜色与前填充协调。 |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式化使用的额外深度。 | 对形状或文本进行细微的深度调节，尤其配合倒角和材质设置使用。 |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) 和 [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前后表面的凸起或圆角边缘。 | 为平面表面添加柔化或模塑的边缘。 |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) 和 [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

一个形状在看起来具有说服力的 3D 效果前，通常需要四类设置：

- 相机设置，因为默认的正视图可能会隐藏挤压效果。
- 灯光设置，因为光照使各面和侧面可辨识。
- 材质设置，因为表面影响光线的渲染方式。
- 挤压或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其前表面添加文字，并应用 3D 格式化。相机旋转值以度为单位，挤压高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿保存为 PPTX。

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过“3‑D 旋转”窗格配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) 访问相机。以下示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设为 20、30、40 度。示例在内存中配置形状，未保存文件：

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

presentation->Dispose();
```

当需要改变观看者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 与 Aspose.Slides 渲染时使用的 3D 视点。

### **从模板形状复制相机方向**

要匹配模板形状的相机方向，可通过 [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) 读取其预设并使用 [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) 应用。示例打开 `template.pptx`，将第一张幻灯片中第一个形状的相机方向复制到第二个形状。两个形状均已拥有 3D 灯光，第二个形状没有显式的相机旋转。

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) 返回度数。索引 `0` 为纬度，`1` 为经度，`2` 为旋转。按该顺序将角度传递给 [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/)。如果源没有显式旋转，`GetRotation` 返回空指针，此时保持第二个形状的角度未设置。显式的 `(0, 0, 0)` 旋转会返回三个零的数组，应当复制。

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在 PowerPoint 中重新打开 `camera-copy.pptx`，右侧的箭头与左侧的矩形拥有相同的相机预设和旋转。两者使用相同的灯光和挤压深度。

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **添加挤压和深度**

挤压通过在前表面后方延伸形状，使其看起来更厚。PowerPoint 中的深度控制决定可见的厚度，颜色控制决定侧面的颜色。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

使用 [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 设置厚度，使用 [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) 设置侧面颜色。以下示例为矩形设置 100 点的挤压高度，侧面为紫色，并旋转相机以显示其厚度。示例在内存中配置形状，未保存文件：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) 方法设置 3D 形状的深度。[set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 方法控制挤压效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充独立。可以对前表面使用纯色、渐变、图案或图片填充，同时保持相同的相机、灯光、材质和挤压设置。

本示例对前表面应用蓝到橙的渐变，对 150 点的挤压侧面使用深橙色。渐变在 0% 和 100% 处分别为开始和结束颜色。相机旋转值以度为单位。幻灯片渲染为 PNG 图像（尺寸为默认的两倍）：

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

渲染输出保留前表面的渐变，并单独渲染挤压侧面：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

若要使用图片填充，先将图像添加到演示文稿并分配给形状填充。此示例需要工作目录中已有名为 “image.jpg” 的文件。它将图片拉伸填充矩形，应用 150 点的挤压，并以度为单位设置相机旋转。示例在内存中配置形状，未保存或渲染文件：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

图片在前表面渲染，挤压作为 3D 侧面渲染：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状本体，文本的 3D 格式化影响文本框。这对于需要对文字本身进行挤压、材质、灯光和相机设置的 WordArt 类效果非常有用。

以下示例创建带有橙白网格图案的文本，应用向上拱形，并通过 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) 配置 3D 设置。挤压高度和深度以点为单位，灯光旋转以度为单位。形状填充和轮廓被隐藏，仅保留文字可见。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并保存演示文稿为 PPTX：

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

文本被渲染为弧形、挤压的 3D 字体：

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **在 3D 形状上保持文字平面**

要在保持形状 3D 外观的同时让文字保持可读，请通过 [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) 调用 [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/)。当该值为 `true` 时，文字不参与 3D 场景；为 `false` 时，文字会随 3D 场景一起倾斜。

此设置不会移除形状的 3D 格式化：相机、灯光、材质和挤压仍通过 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) 配置。它也不同于普通旋转。[IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) 旋转的是幻灯片平面的形状，而 [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) 控制文本在其边框内的自定义旋转。将文字排除在 3D 场景外不会重置这两个角度。

以下独立示例创建一个带文字的蓝色矩形，并在原始矩形旁边克隆一份。两个形状拥有相同的 3D 格式化，仅文字设置不同：左侧为 `false`，右侧为 `true`。相机角度以度为单位，挤压高度为 40 点。示例保存演示文稿为 PPTX，并将对比幻灯片渲染为 PNG（尺寸为默认的两倍）。

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

左侧文字随 3D 方向倾斜，右侧文字保持平面且更易阅读。两个矩形保留相同的可见挤压和 3D 方向。

![Side-by-side 3D rectangles: KeepTextFlat is false on the left and true on the right](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。此行为在以下场景均适用：将幻灯片渲染为 [PNG](/slides/zh/cpp/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/cpp/convert-powerpoint-to-html/)，或为 [视频转换](/slides/zh/cpp/convert-powerpoint-to-video/) 生成帧。

请注意以下要点：

- 导出的图像和 PDF 不是交互式的，导出后对象无法被观看者旋转。
- 最终外观取决于相机、灯光装置、材质、挤压、填充以及幻灯片缩放的组合。
- 若需检查继承或基于主题的格式化值，请读取 [effective shape properties](/slides/zh/cpp/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是以可编辑的 3D 设置保存。

## **常见问题解答**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景供观看者旋转。 在 PPTX 中，只要格式支持，3D 格式化仍保持可编辑。

**3D 模型与 3D 效果有什么区别？**

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、倒角、灯光和材质。本文只讨论 3D 效果。

**要让 3D 形状可见，必须设置哪些参数？**

至少需要设置相机旋转以及挤压或深度。实际使用中，还应设置灯光装置和材质，以便渲染出的面拥有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状本体使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/)，对文本使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/)。

**导出为图像、PDF、HTML 或视频帧时，3D 效果会出现吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 和用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能读取在继承和主题设置之后的最终 3D 值吗？**

可以。使用在 [Shape Effective Properties](/slides/zh/cpp/shape-effective-properties/) 中描述的有效格式化 API，读取最终的相机、灯光装置、倒角及相关 3D 值。