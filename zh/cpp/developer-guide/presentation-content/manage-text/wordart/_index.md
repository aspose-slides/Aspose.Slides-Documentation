---
title: 在 C++ 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/cpp/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 反射效果
- 发光效果
- WordArt 变换
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中创建和自定义 WordArt 效果。本分步指南帮助开发者在 C++ 中使用专业文本提升演示文稿。"
---
## **概览**

WordArt 效果允许您使用填充、轮廓、阴影、反射、发光、变换和 3D 格式来美化文本。本文介绍如何在 PowerPoint 演示文稿中使用 Aspose.Slides for C++（无需安装 Microsoft Office）创建和自定义这些效果。

## **创建简单的 WordArt 模板并应用于文本**

以下示例通过设置文本、字体、图案填充和轮廓来构建一个简单的 WordArt 样式。

每个示例都会创建一个新演示文稿，并在其第一张幻灯片上添加一个矩形；无需输入文件。第一个示例将文本设置为 "Aspose.Slides"。形状的位置和尺寸以点为单位：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

将字体设置为 36 磅的 Arial Black，以使格式更明显：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

应用一个具有深橙色前景和白色背景的 [SmallGrid](https://reference.aspose.com/slides/zh/cpp/aspose.slides/patternstyle/) 图案，然后添加宽度为 1 磅的黑色文本轮廓：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

生成的文本：

![简单的 WordArt 模板](WordArt_template.png)

## **应用其他 WordArt 效果**

以下示例演示如何对文本应用阴影、反射、发光、变换和 3D 效果。

### **应用外部阴影效果**

外部阴影通过在文本后方放置阴影来增加深度。您可以自定义其颜色、方向、距离、模糊半径、比例和倾斜度。

此示例调用 [EnableOuterShadowEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) 并设置一个模糊半径为 4 磅、方向为 230 度、距离为 30 磅的黑色阴影。比例值为 100 可保持阴影大小，而水平倾斜将其倾斜 20 度。Alpha 变换将不透明度设置为 32%：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

生成的文本：

![外部阴影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 当外部阴影和预设阴影同时使用时，仅应用外部阴影。
- 如果外部阴影和内部阴影同时使用，产生的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍，而在 PowerPoint 2007 中，仅应用外部阴影。
{{% /alert %}}

### **应用反射效果**

反射会创建文本的镜像副本。通过调整其位置、比例、模糊和不透明度来控制外观。

此示例调用 [EnableReflectionEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) 并将反射垂直翻转，比例为 -100%。使用 0.5 磅的模糊半径和 4.72 磅的距离。沿反射的 0% 到 60% 位置，不透明度从 60% 下降到 0.9%：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

生成的文本：

![反射效果](reflection_effect.png)

### **应用发光效果**

发光在文本周围添加柔和的彩色轮廓。通过调整颜色、不透明度和半径来控制效果。

此示例调用 [EnableGlowEffect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ieffectformat/enablegloweffect/) 并应用一个不透明度为 54%、半径为 7 磅的红色发光：

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

生成的文本：

![发光效果](glow_effect.png)

### **应用 WordArt 变换**

WordArt 变换可以弯曲、拉伸或扭曲文本块。

将 [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_transform/) 设置为 [ArchUpPour](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textshapetype/)，使整个文本框向上弯曲：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

生成的文本：

![WordArt 变换](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ 提供一组预定义的 [transformation types](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textshapetype/)。
{{% /alert %}}

### **对形状和文本应用 3D 效果**

您可以对形状或其文本应用 3D 效果。斜面、拉伸、光照和摄像机设置决定最终外观。

以下示例使用 [IThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 为矩形添加圆形斜面、橙色拉伸和深红色轮廓。斜面尺寸、拉伸高度、轮廓宽度和深度均以点为单位。塑料材质、绕 Z 轴旋转 40 度的均衡光照以及透视摄像机决定其外观：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![形状 3D 效果](shape_3D_effect.png)

此示例通过 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/get_threedformat/) 对文本应用类似的 3D 格式。较小的斜面塑造字母边缘，而拉伸和光照为文本提供深度：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

![文本 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
对文本或其形状应用 3D 效果——以及这些效果之间的交互——受特定规则约束。考虑一个同时包含文本和其所在形状的场景。3D 效果包括对象的 3D 表现以及其所在的场景。

- 如果形状和文本都设置了场景，则以形状的场景为优先，文本的场景被忽略。
- 如果形状没有自己的场景但具有 3D 表现，则使用文本的场景。
- 如果形状根本没有 3D 效果，则视为平面，仅对文本应用 3D 效果。

这些行为与 [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_lightrig/) 和 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/get_camera/) 方法相关。
{{% /alert %}}

若要在保持形状 3D 格式的同时使文本保持平面且易读，请参阅 [Keep Text Flat on a 3D Shape](/slides/zh/cpp/3d-presentation/) 了解两种设置的比较以及完整的 C++ 示例。

## **常见问题**

**我可以在不同字体或脚本（例如阿拉伯文、中文）中使用 WordArt 效果吗？**

是的，Aspose.Slides for C++ 支持 Unicode，并可与所有主流字体和脚本一起使用。无论语言为何，都可以应用阴影、填充和轮廓等 WordArt 效果，但字体的可用性和渲染可能取决于系统字体。

**我可以将 WordArt 效果应用于幻灯片母版元素吗？**

是的，您可以将 WordArt 效果应用于母版幻灯片上的形状，包括标题占位符、页脚或背景文本。对母版布局所做的更改将会反映在所有相关幻灯片中。

**WordArt 效果会影响演示文稿文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等 WordArt 效果可能会因添加的格式元数据略微增大文件大小，但差异通常可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

是的，您可以使用 [ISlide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/getimage/) 将包含 WordArt 的幻灯片渲染为图像（例如 PNG、JPEG），或使用 [IShape::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getimage/) 渲染单独的形状。这使您能够在内存中或屏幕上预览结果，而无需保存或导出完整的演示文稿。