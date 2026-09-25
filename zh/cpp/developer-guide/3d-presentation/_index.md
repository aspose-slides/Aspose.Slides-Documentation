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

Aspose.Slides for C++ 可以创建、编辑、保留并渲染类似 PowerPoint 的形状和文本的 3D 格式化。本文章覆盖旋转、拉伸、倒角、灯光、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果，而不是插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会把这些 3D 效果渲染到导出的 2D 输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_threedformat/) 方法为形状应用 3D 格式化。该方法返回 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。此方法为文本框而不是形状主体应用 3D 格式化。

最重要的方法如下：

| 方法 | 它控制什么 | 何时使用 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_camera/) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [get_LightRig](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_lightrig/) | 灯光预设、方向和灯光旋转。 | 改变 3D 表面上的高光和阴影效果。 |
| [set_Material](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_material/) | 表面材质，如平面、哑光、塑料或金属。 | 让相同的几何体看起来更平坦、柔和、光亮或金属感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形状从正面向后延伸的距离。 | 将平面形状转换为可见的厚实 3D 对象。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 拉伸侧面的颜色。 | 显示深度或将侧面颜色与正面填充保持一致。 |
| [set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式化使用的附加深度。 | 在形状或文本上微调深度，尤其与倒角和材质设置一起使用时。 |
| [get_BevelTop](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_beveltop/) 和 [get_BevelBottom](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 正面和背面的凸起或圆角边缘。 | 添加柔化或成形的边缘，而不是尖锐的平面。 |
| [get_ContourColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_contourcolor/) 和 [set_ContourWidth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

要让形状看起来逼真地呈现 3D，通常需要四类设置：

- 相机设置，因为默认的正视图可能会隐藏拉伸效果。
- 灯光设置，因为光照让各个面和侧面可读。
- 材质设置，因为表面材质影响光线的渲染方式。
- 拉伸或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。相机旋转值以度为单位，拉伸高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿另存为 PPTX。

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

![渲染的蓝色 3D 矩形，正面带白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转通过 “3‑D 旋转” 面板配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转面板，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_camera/) 访问相机。下面的示例创建一个矩形，选择正交正视图，并将其 X、Y、Z 旋转分别设为 20、30、40 度。它在内存中配置形状，未保存文件：

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

当需要改变观察者看到对象的方式时使用相机。它不会改变幻灯片上 2D 形状的几何形状，只会改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加拉伸和深度**

拉伸通过在正面后方延伸形状，使其看起来更厚。在 PowerPoint 中，深度控制可见厚度，颜色控制侧面颜色。

![PowerPoint 深度控制映射到拉伸颜色和拉伸高度属性](img_02_02.png)

使用 [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 设置厚度，使用 [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) 设置侧面颜色。下面的示例为矩形设置 100 点的紫色侧面拉伸，并旋转相机以展示其厚度。它在内存中配置形状，未保存文件：

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

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_depth/) 方法设置 3D 形状的深度。[set_ExtrusionHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 方法控制拉伸效果的高度，如本例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化与形状填充相互独立。您可以对正面使用纯色、渐变、图案或图片填充，同时使用相同的相机、灯光、材质和拉伸设置。

下面的示例对正面应用蓝到橙的渐变，对 150 点的拉伸侧面使用深橙色。渐变停止点 0 与 100 标记渐变的起止。相机旋转值以度为单位。幻灯片渲染为 PNG（尺寸为默认的两倍）：

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

渲染结果保留了正面的渐变，并单独渲染了拉伸侧面：

![渲染的 3D 矩形，正面为蓝到橙的渐变填充，侧面为橙色拉伸](img_02_03.png)

如果想使用图片填充，只需将图片添加到演示文稿并分配给形状填充。下面的示例要求工作目录中已有名为 “image.jpg” 的文件。它将图片拉伸填满矩形，应用 150 点拉伸，并以度为单位设置相机旋转。形状在内存中配置，未保存或渲染文件：

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

图片渲染在正面，拉伸渲染为 3D 侧面：

![渲染的 3D 矩形，正面为照片填充，侧面为橙色拉伸](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体，文本的 3D 格式化影响文本框。这对类似 WordArt 的效果很有用，需要对文字本身进行拉伸、材质、灯光和相机设置。

下面的示例创建带有橙白网格图案的文字，应用向上弧形，并通过 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/get_threedformat/) 配置 3D 设置。拉伸高度和深度使用点为单位，灯光旋转使用度为单位。形状填充和轮廓被隐藏，仅显示文字。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿另存为 PPTX：

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

文字呈现为弧形、拉伸的 3D 字体：

![渲染的 3D 文本，带拱形 WordArt 变换、橙色图案填充和深色拉伸](img_02_05.png)

## **在 3D 形状上保持文字平面**

要在保持形状 3D 外观的同时让文字易读，需通过 [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/get_textframeformat/) 调用 [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_keeptextflat/)。当值为 `true` 时，文字保持在 3D 场景之外；为 `false` 时，文字参与 3D 场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其相机、灯光、材质和拉伸仍通过 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_threedformat/) 配置。它也不同于普通旋转。`[IShape::set_Rotation]` 在幻灯片平面内旋转形状，而 `[ITextFrameFormat::set_RotationAngle]` 控制文字在其包围盒内的自定义旋转。保持文字平面不会重置这两个角度中的任何一个。

下面的完整示例创建一个带文字的蓝色矩形，并在其旁边克隆一个副本。两个矩形拥有相同的 3D 格式化，唯一差别在文字设置：左侧为 `false`，右侧为 `true`。相机角度以度为单位，拉伸高度为 40 点。示例将演示文稿保存为 PPTX，并将对比幻灯片渲染为 PNG（尺寸为默认的两倍）。

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

左侧文字随 3D 方向倾斜；右侧文字保持平面，更易阅读。两者的可见拉伸和 3D 方向相同。

![并排的 3D 矩形：左侧 KeepTextFlat 为 false，右侧为 true](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。这在以下情形中适用：将幻灯片渲染为 [PNG](/slides/zh/cpp/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/cpp/convert-powerpoint-to-html/)，或为 [视频转换](/slides/zh/cpp/convert-powerpoint-to-video/) 生成帧。

请记住：

- 导出的图像和 PDF 并非交互式。导出后对象无法被观众旋转。
- 最终外观取决于相机、灯光、材质、拉伸、填充以及幻灯片缩放的组合。
- 如需检查继承或主题基础的格式化值，请读取 [effective shape properties](/slides/zh/cpp/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果是渲染后的图像，而不是可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观众可以旋转的交互式 3D 场景。在 PPTX 中，只要格式支持，3D 格式化仍可在 PowerPoint 中编辑。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、拉伸、倒角、灯光和材质。本文仅讨论 3D 效果。

**要呈现可见的 3D 形状需要哪些设置？**

至少需要设置相机旋转和拉伸或深度。实践中，还应设置灯光和材质，以便渲染出的面具有清晰的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状主体使用 [IShape::get_ThreeDFormat]，对文本使用 [ITextFrameFormat::get_ThreeDFormat]。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 以及用于视频转换的帧时渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能读取继承和主题设置后最终的 3D 值吗？**

可以。使用本文档中描述的有效格式化 API（参见 [Shape Effective Properties]）读取最终的相机、灯光、倒角及相关 3D 值。