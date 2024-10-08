---
title: WordArt
type: docs
weight: 110
url: /zh/cpp/wordart/
---

## **关于 WordArt?**
WordArt 或 Word Art 是一个功能，允许您对文本应用效果，使其脱颖而出。例如，使用 WordArt，您可以为文本添加轮廓或填充颜色（或渐变），添加 3D 效果等。您还可以倾斜、弯曲和拉伸文本的形状。

{{% alert color="primary" %}} 

WordArt 允许您像处理图形对象一样处理文本。一般来说，WordArt 包含特效或对文本的特殊修改，以使其更具吸引力或更显眼。

{{% /alert %}} 

**Microsoft PowerPoint 中的 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，您必须选择一个预定义的 WordArt 模板。WordArt 模板是一组应用于文本或其形状的效果。

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for C++ 20.10 中，我们实现了对 WordArt 的支持，并在随后的 Aspose.Slides for C++ 版本中对该功能进行了改进。

使用 Aspose.Slides for C++，您可以轻松创建自己的 WordArt 模板（一个效果或效果组合）并将其应用于文本。

## 创建简单的 WordArt 模板并将其应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 C++ 代码创建简单文本：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

现在，我们通过以下代码将文本的字体高度设置为更大的值，以使效果更明显：

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中，转到 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择一个预定义的 WordArt 效果。在左侧菜单中，您可以指定新 WordArt 的设置。

以下是可用的一些参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在这里，我们将 SmallGrid 模式颜色应用于文本，并使用以下代码添加 1 像素宽的黑色文本边框：

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

结果文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他 WordArt 效果

**使用 Microsoft PowerPoint**

通过程序界面，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，阴影、反射和发光效果可以应用于文本；3D 格式和 3D 旋转效果可以应用于文本块；柔和边缘属性可以应用于形状对象（即使未设置 3D 格式属性，它仍然会有影响）。

### 应用阴影效果

这里，我们打算仅设置与文本相关的属性。我们在 C++ 中使用以下代码将阴影效果应用于文本：

``` cpp 
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

Aspose.Slides API 支持三种类型的阴影：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以为文本应用阴影（使用预设值）。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您同时应用两种类型的阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅应用 OuterShadow 效果。
- 如果同时使用 OuterShadow 和 InnerShadow，最终或应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会翻倍。但在 PowerPoint 2007 中，仅应用 OuterShadow 效果。

### 为文本添加显示效果

我们通过以下 C++ 代码为文本添加显示效果：

``` cpp 
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

### 为文本添加发光效果

我们通过以下代码将发光效果应用于文本，使其闪耀或突出：

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

操作的结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。特效的属性会在文本的每个部分上单独设置。

{{% /alert %}} 

### 在 WordArt 中使用变换

我们通过以下代码使用 set_Transform 方法（整个文本块固有）：

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for C++ 提供了一定数量的预定义变换类型。

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义变换类型，请访问：**格式** -> **文本效果** -> **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。

### 为文本和形状应用 3D 效果

我们使用以下示例代码为文本形状设置 3D 效果：

``` cpp 
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

结果文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 C++ 代码为文本应用 3D 效果：

``` cpp 
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

操作的结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的交互是基于某些规则的。

考虑一种用于文本和包含该文本的形状的场景。3D 效果包含 3D 对象表示和对象放置的场景。

- 当为形状和文本设置场景时，形状场景具有更高的优先级——文本场景被忽略。
- 当形状没有自己的场景但有 3D 表示时，使用文本场景。
- 否则——当形状最初没有 3D 效果时——形状是平坦的，3D 效果仅适用于文本。

与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关的描述。

{{% /alert %}} 

## **将外阴影效果应用于文本**
Aspose.Slides for C++ 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) 类，允许您将阴影效果应用于由 TextFrame 托管的文本。请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类。
7. 设置阴影的 BlurRadius。
8. 设置阴影的方向。
9. 设置阴影的距离。
10. 将 RectangleAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿写入 PPTX 文件。

以下是基于上述步骤的 C++ 示例代码，向文本应用外阴影效果：

``` cpp
auto pres = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto sld = pres->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");

// 禁用形状填充，以便我们可以获取文本的阴影
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 添加外阴影并设置所有必要参数
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// 将演示文稿写入磁盘
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **将内阴影效果应用于形状**
请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要的参数。
6. 将 ColorType 设置为 Scheme。
7. 设置方案颜色。
8. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下是基于上述步骤的示例代码，展示了如何在 C++ 中为两个形状之间添加连接器：

``` cpp
auto presentation = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto slide = presentation->get_Slides()->idx_get(0);

// 添加一个矩形类型的 AutoShape
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 启用 InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 设置所有必要参数
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// 将 ColorType 设置为 Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// 设置方案颜色
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// 保存演示文稿
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```