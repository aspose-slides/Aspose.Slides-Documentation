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
- WordArt 变形
- 3D 效果
- 外阴影效果
- 内阴影效果
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中创建和自定义 WordArt 效果。此分步指南帮助开发人员在 C++ 中使用专业文本提升演示文稿。"
---

## **关于 WordArt？**
WordArt 或 Word Art 是一种功能，允许你对文本应用特效，使其脱颖而出。使用 WordArt，例如，你可以为文本描边或填充颜色（或渐变），为其添加 3D 效果等。你还可以倾斜、弯曲和拉伸文本的形状。 

{{% alert color="primary" %}} 

WordArt 让你可以像处理图形对象一样处理文本。总体而言，WordArt 包含对文本进行的各种特效或特殊修改，以使其更具吸引力或更显眼。 

{{% /alert %}} 

**Microsoft PowerPoint 中的 WordArt**

在 Microsoft PowerPoint 中使用 WordArt，需要先选择一个预定义的 WordArt 模板。WordArt 模板是一组将应用于文本或其形状的特效。 

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for C++ 20.10 中，我们实现了对 WordArt 的支持，并在后续的 Aspose.Slides for C++ 发行版中对该功能进行了改进。 

使用 Aspose.Slides for C++，你可以轻松在 C++ 中创建自己的 WordArt 模板（单个特效或特效组合），并将其应用于文本。 

## **创建简单的 WordArt 模板并将其应用于文本**

**使用 Aspose.Slides** 

首先，使用以下 C++ 代码创建一段简单的文本： 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```


现在，通过下面的代码将文本的字体高度设置为更大的值，以使特效更明显： 
``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```


**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中转到 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，你可以选择预定义的 WordArt 效果；在左侧菜单中，你可以为新的 WordArt 指定设置。 

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

此处，我们通过以下代码将 SmallGrid 图案颜色应用于文本，并使用宽度为 1 的黑色文本边框： 
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


生成的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序界面中，你可以将这些效果应用于文本、文本框、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，阴影、反射和发光效果可应用于文本；3D 格式和 3D 旋转效果可应用于文本框；柔和边缘属性可应用于形状对象（即使未设置 3D 格式属性，也仍会产生效果）。 

### **将阴影效果应用于文本**

此处，我们仅针对文本设置属性。使用以下 C++ 代码将阴影效果应用于文本： 
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


Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。 

使用 PresetShadow，你可以对文本应用预设值的阴影。 

**使用 Microsoft PowerPoint**

在 PowerPoint 中只能使用一种阴影类型。例如：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许一次应用两种阴影：InnerShadow 和 PresetShadow。

**注意：**

- 同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。 
- 如果同时使用 OuterShadow 和 InnerShadow，实际应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中效果会叠加两次，而在 PowerPoint 2007 中仅应用 OuterShadow。 

### **将反射效果应用于文本**

通过以下 C++ 示例代码为文本添加反射： 
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


### **将发光效果应用于文本**

使用以下代码将发光效果应用于文本，使其闪亮或突出： 
``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```


操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

你可以更改阴影、显示和发光的参数。特效属性会分别设置在文本的每个部分。 

{{% /alert %}} 

### **在 WordArt 中使用变形**

通过以下代码使用 set_Transform 方法（针对整段文本）：

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```


结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for C++ 都提供若干预定义的变形类型。 

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义的变形类型，请依次选择：**Format** → **TextEffect** → **Transform**

**使用 Aspose.Slides**

要选择变形类型，请使用 TextShapeType 枚举。 

### **将 3D 效果应用于文本和形状**

我们通过以下示例代码为文本形状设置 3D 效果：

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


生成的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 C++ 代码将 3D 效果应用于文本：

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


操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及特效之间的交互遵循一定规则。 

可以将文本及其所在形状视为一个场景。3D 效果包括 3D 对象的表示以及对象所在的场景。 

- 当形状和文本都设置了场景时，形状的场景优先级更高——文本的场景被忽略。 
- 当形状没有自己的场景但具有 3D 表示时，使用文本的场景。 
- 否则——当形状本身没有 3D 效果时，形状保持平面，仅在文本上应用 3D 效果。 

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。 

{{% /alert %}} 

## **将外阴影效果应用于形状**
Aspose.Slides for C++ 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) 类，允许你对 TextFrame 中的文本应用阴影效果。按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加一个矩形类型的 AutoShape。  
4. 访问该 AutoShape 关联的 TextFrame。  
5. 将 AutoShape 的 FillType 设置为 NoFill。  
6. 实例化 OuterShadow 类。  
7. 设置阴影的 BlurRadius。  
8. 设置阴影的 Direction。  
9. 设置阴影的 Distance。  
10. 将 RectanglelAlign 设置为 TopLeft。  
11. 将阴影的 PresetColor 设置为 Black。  
12. 将演示文稿保存为 PPTX 文件。  

下面的 C++ 示例代码展示了如何将外阴影效果应用于文本：

``` cpp
auto pres = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto sld = pres->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u"Aspose TextBox");

// 禁用形状填充，以便获取文本阴影
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 添加外部阴影并设置所有必要参数
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
按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。  
2. 获取幻灯片的引用。  
3. 添加一个矩形类型的 AutoShape。  
4. 启用 InnerShadowEffect。  
5. 设置所有必要的参数。  
6. 将 ColorType 设置为 Scheme。  
7. 设置 Scheme Color。  
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。  

下面的示例代码（基于上述步骤）展示了如何在 C++ 中为两个形状之间添加连接器：

``` cpp
auto presentation = System::MakeObject<Presentation>();
// 获取幻灯片的引用
auto slide = presentation->get_Slides()->idx_get(0);

// 添加矩形类型的 AutoShape
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 向矩形添加 TextFrame
ashp->AddTextFrame(u"Aspuse TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 启用内部阴影效果    
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

// 设置方案颜色
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// 保存演示文稿
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**我可以在不同的字体或文字脚本（例如阿拉伯文、中文）上使用 WordArt 效果吗？**

可以，Aspose.Slides 支持 Unicode 并兼容所有主流字体和文字脚本。阴影、填充、描边等 WordArt 效果均可应用于任何语言，尽管具体字体的可用性和渲染效果取决于系统字体。  

**我可以将 WordArt 效果应用于母版幻灯片元素吗？**

可以，你可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文本）应用 WordArt 效果。对母版布局所做的更改会在所有关联的幻灯片中体现。  

**WordArt 效果会影响演示文稿文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等效果会稍微增加文件大小，因为会添加格式元数据，但通常差异可以忽略不计。  

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，你可以使用 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 接口的 `GetImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需保存或导出完整的演示文稿。