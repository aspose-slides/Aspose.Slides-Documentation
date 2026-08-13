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
- 显示效果
- 发光效果
- WordArt 变换
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中创建并自定义 WordArt 效果。本分步指南帮助开发者在 C++ 中使用专业文字提升演示文稿。"
---
## **概述**

WordArt 效果允许您在 PowerPoint 演示文稿中添加视觉上吸引人、样式化的文字。使用 Aspose.Slides，开发人员可以像在 Microsoft PowerPoint 中一样以编程方式创建、定制和管理 WordArt——无需安装 Office。本文概述了使用 WordArt 的方法，包括如何应用文本变换、填充样式、轮廓、阴影以及其他格式选项，使您的演示内容更具表现力和吸引力。WordArt 允许您把文字视为图形对象。它由对文字应用的效果或特殊修改组成，使文字更加醒目或突出。

## **创建简单的 WordArt 模板并将其应用到文本**

**使用 Aspose.Slides** 

首先，我们使用以下 C++ 代码创建一段简单的文本：

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

现在，通过以下代码将文本的字体高度设置为更大的值，以使效果更明显：

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**使用 Microsoft PowerPoint**

转到 Microsoft PowerPoint 中的 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果；在左侧菜单中，您可以为新的 WordArt 指定设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我们使用以下代码将 SmallGrid 图案颜色应用于文本，并添加宽度为 1 的黑色文本边框：

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

生成的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序界面中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，阴影、反射和发光效果可以应用于文本；3D 格式和 3D 旋转效果可以应用于文本块；软边缘属性可以应用于形状对象（即使未设置 3D 格式属性仍会产生效果）。

### **将阴影效果应用于文本**

此处我们仅针对文本本身设置属性。使用以下 C++ 代码将阴影效果应用于文本：

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以为文本应用预设值阴影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一种阴影类型。示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您一次同时应用两种阴影：InnerShadow 和 PresetShadow。

**备注：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。  
- 如果同时使用 OuterShadow 和 InnerShadow，最终效果取决于 PowerPoint 的版本。例如，在 PowerPoint 2013 中，效果会叠加；但在 PowerPoint 2007 中只会应用 OuterShadow 效果。

### **将反射效果应用于文本**

我们通过下面的 C++ 示例代码为文本添加反射：

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

### **将发光效果应用于文本**

我们使用以下代码将发光效果应用于文本，使其更加闪亮或突出：

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

您可以更改阴影、显示和发光的参数。效果属性会分别设置到文本的每个部分。 

{{% /alert %}} 

### **在 WordArt 中使用变换**

我们通过以下代码使用 set_Transform 方法（作用于整段文本）：

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Microsoft PowerPoint 和 Aspose.Slides for C++ 都提供一定数量的预定义变换类型。 

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义变换类型，请依次点击：**Format** → **TextEffect** → **Transform**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。

### **将 3D 效果应用于文本和形状**

我们使用以下示例代码为文本形状设置 3D 效果：

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

生成的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 C++ 代码为文本应用 3D 效果：

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

将 3D 效果应用于文本或其形状以及效果之间的交互遵循特定规则。

考虑文本及其所在形状的场景。3D 效果包含 3D 对象表示以及对象所在的场景。

- 当形状和文本都设置了场景时，形状的场景优先——文本的场景被忽略。  
- 当形状没有自己的场景但具有 3D 表示时，使用文本的场景。  
- 否则——如果形状本身没有 3D 效果，则形状保持平面，3D 效果仅应用于文本。  

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}} 

## **将外部阴影效果应用于形状**
Aspose.Slides for C++ 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.effects.i_outer_shadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.effects.i_inner_shadow) 类，允许您对 TextFrame 中的文本应用阴影效果。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加 Rectangle 类型的 AutoShape。  
4. 访问与该 AutoShape 关联的 TextFrame。  
5. 将 AutoShape 的 FillType 设置为 NoFill。  
6. 实例化 OuterShadow 类。  
7. 设置阴影的 BlurRadius。  
8. 设置阴影的 Direction。  
9. 设置阴影的 Distance。  
10. 将 RectanglelAlign 设置为 TopLeft。  
11. 将阴影的 PresetColor 设置为 Black。  
12. 将演示文稿保存为 PPTX 文件。

以下 C++ 示例代码演示了上述步骤，展示如何将外部阴影效果应用于文本：

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 为矩形添加 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");

// 禁用形状填充，以便获取文本的阴影
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 添加外部阴影并设置所有必要参数
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// 将演示文稿保存到磁盘
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **将内部阴影效果应用于形状**
请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 获取幻灯片的引用。  
3. 添加 Rectangle 类型的 AutoShape。  
4. 启用 InnerShadowEffect。  
5. 设置所有必要的参数。  
6. 将 ColorType 设置为 Scheme。  
7. 设置 Scheme Color。  
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例代码（基于上述步骤）展示了如何在 C++ 中向两个形状之间添加连接器：

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto slide = presentation->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 为矩形添加 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 启用 InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 设置所有必要的参数
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// 将 ColorType 设置为 Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// 设置 Scheme 颜色
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// 保存演示文稿
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **常见问题解答**

### 我可以在不同的字体或文字系统（例如阿拉伯语、中文）中使用 WordArt 效果吗？

可以，Aspose.Slides 支持 Unicode，并兼容所有主流字体和文字系统。阴影、填充、轮廓等 WordArt 效果均可在任意语言下使用，尽管具体的字体可用性和渲染取决于系统字体。

### 我可以将 WordArt 效果应用于母版幻灯片元素吗？

可以，您可以在母版幻灯片上的形状（包括标题占位符、页脚或背景文字）上应用 WordArt 效果。对母版布局所做的更改会同步到所有使用该母版的幻灯片。

### WordArt 效果会影响演示文稿的文件大小吗？

会有轻微影响。阴影、发光和渐变填充等效果会略微增加文件大小，因为会添加额外的格式元数据，但一般来说影响可以忽略不计。

### 我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？

可以，您可以使用 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) 接口的 `GetImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需保存完整的演示文稿。