---
title: 在 C++ 中创建 3D 演示文稿
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 挤出
- 3D 渐变
- 3D 文本
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多种用途。"
---

## **概览**
自 Aspose.Slides 20.9 起，可以创建和修改 PowerPoint 3D 模型。通过为 2D 形状添加一系列 3D 效果即可实现。通过在形状上创建相机视图，您可以绕轴旋转它。为形状创建挤出或深度，可将 2D 形状转换为 3D 模型。设置 3D 形状的光照效果或更改材质可以使其更生动。将 3D 模型的颜色更改为 3D 渐变、修改形状轮廓、添加斜角可使 3D 模型更有体积感。所有 3D 效果均可应用于 PowerPoint 3D 模型和文本。

让我们来看第一个创建 3D 模型的示例，它包含了上述所有功能：
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
presentation->Dispose();
```


生成的 PowerPoint 3D 模型：

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**
PowerPoint 中可通过以下方式进行形状旋转：

![todo:image_alt_text](img_02_01.png)

要旋转 PowerPoint 3D 模型，需要在形状上创建相机视图。可以使用[IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4) 方法完成。旋转方法从相机类调用，就像您在旋转相机一样。实际上，当您相对于形状旋转相机时，实际是旋转 3D 平面上的形状。
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... 设置其他 3D 场景参数

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **3D 深度和挤出**
要为 PowerPoint 3D 模型添加深度和挤出，可使用[IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295) 方法。要修改挤出颜色，请使用[IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e) 方法：
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... 设置其他 3D 场景参数

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


PowerPoint 中的深度菜单：

![todo:image_alt_text](img_02_02.png)

## **3D 渐变**
在 PowerPoint 3D 模型上绘制 3D 渐变可通过[Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58) 方法实现：
``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


带有 3D 渐变的模型：

![todo:image_alt_text](img_02_03.png)
  
要创建图片渐变，请使用[Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb) 方法：
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. 设置 3D: Camera, LightRig, Extrusion

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


带有图片渐变的 3D 模型：

![todo:image_alt_text](img_02_04.png)

## **3D 文本（WordArt）**
要在文本上应用旋转、挤出、光照、渐变并将其制作成 3D 文本（WordArt），需要访问[IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30) 方法：
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// setup "Arch Up" WordArt transform effect
textFrameFormat->set_Transform(TextShapeType::ArchUp);

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text3d.png");
thumbnail->Dispose();

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


3D 文本（WordArt）的示例：

![todo:image_alt_text](img_02_05.png)

## **常见问题**

**将演示文稿导出为图像/PDF/HTML 时，3D 效果会被保留吗？**

是的。Slides 3D 引擎在导出为受支持的格式时会渲染 3D 效果（[图像](/slides/zh/cpp/convert-powerpoint-to-png/)、[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/) 等）。

**我能检索考虑主题、继承等因素的“有效”（最终）3D 参数值吗？**

是的。Slides 提供了用于[读取有效值](/slides/zh/cpp/shape-effective-properties/) 的 API（包括 3D 的光照、斜角等），因此您可以查看最终的实际设置。

**将演示文稿转换为视频时，3D 效果会生效吗？**

是的。在[为视频生成帧](/slides/zh/cpp/convert-powerpoint-to-video/)时，3D 效果会像[导出图像](/slides/zh/cpp/convert-powerpoint-to-png/)一样被渲染。