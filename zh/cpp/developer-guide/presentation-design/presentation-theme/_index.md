---
title: 管理 C++ 中的演示主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/cpp/presentation-theme/
keywords:
- PowerPoint 主题
- 演示主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理演示主题，以创建、定制并转换具有一致品牌形象的 PowerPoint 文件。"
---
演示主题定义了设计元素的属性。当您选择演示主题时，本质上是选择了一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/cpp/powerpoint-fonts/)、[背景样式](/slides/zh/cpp/presentation-background/) 和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用特定的颜色组合。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为方便您选择新主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 枚举中提供了相应的值。

以下 C++ 代码示例演示如何更改主题的强调颜色：

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

您可以通过以下方式确定结果颜色的实际值：

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (颜色 [A=255, R=128, G=100, B=162])
```

为了进一步演示颜色更改操作，我们创建另一个元素并将（来自首次操作的）强调颜色分配给它。随后在主题中更改该颜色：

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

新颜色会自动应用到这两个元素上。

### **从附加调色板设置主题颜色**

当您对主主题颜色（1）进行亮度变换时，会生成来自附加调色板（2）的颜色。随后您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1**- 主主题颜色  
**2**- 来自附加调色板的颜色。

以下 C++ 代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// 强调色 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// 强调色 4，更亮 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// 强调色 4，更亮 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// 强调色 4，更亮 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// 强调色 4，更暗 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// 强调色 4，更暗 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **将 `SchemeColor` 映射到 `IColorScheme` 颜色**

使用 [SchemeColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.schemecolor/) 时，您可能会注意到它包含以下主题颜色值：

`Background1`, `Background2`, `Text1`, 和 `Text2`.

然而，`Presentation::get_MasterTheme()::get_ColorScheme()` 返回 [IColorScheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/icolorscheme/) ，其对应的颜色为：

`Dark1`, `Dark2`, `Light1`, 和 `Light2`.

这只是命名上的差异。这些值指向相同的主题颜色槽，映射固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 与 `Dark`/`Light` 之间没有动态转换。它们仅是同一主题颜色的不同名称。

此命名差异来源于 Microsoft Office 的术语。较早的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而较新的 UI 版本将同一槽显示为 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **更改主题字体**

为方便您为主题以及其他用途选择字体，Aspose.Slides 使用以下特殊标识符（类似于 PowerPoint 中使用的）：

* **+mn-lt** - 正文字体 Latin（Minor Latin Font）
* **+mj-lt** - 标题字体 Latin（Major Latin Font）
* **+mn-ea** - 正文字体 East Asian（Minor East Asian Font）
* **+mj-ea** - 正文字体 East Asian（Major East Asian Font）

以下 C++ 代码示例演示如何将 Latin 字体分配给主题元素：

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

以下 C++ 代码示例演示如何更改演示文稿的主题字体：

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

所有文本框中的字体将被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 字体](/slides/zh/cpp/powerpoint-fonts/)。 
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在典型的演示文稿中仅保存其中的 3 种。

![todo:image_alt_text](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 C++ 代码以获取演示文稿中预定义背景的数量：

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.i_format_scheme/) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) 属性，您可以在 PowerPoint 主题中添加或访问背景样式。 
{{% /alert %}}

以下 C++ 代码示例演示如何为演示文稿设置背景：

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看 [PowerPoint 背景](/slides/zh/cpp/presentation-background/)。 
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合为 3 种效果：细微、适中和强烈。例如，将效果应用于特定形状时的结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用来自 [FormatScheme](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.i_format_scheme/) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)、[LineStyles](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd) 和 [EffectStyles](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)），您可以比 PowerPoint 中的选项更灵活地更改主题中的元素。

以下 C++ 代码示例演示如何通过更改元素的部分属性来修改主题效果：

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

生成的填充颜色、填充类型、阴影效果等的变化如下：

![todo:image_alt_text](presentation-design_11.png)

## **常见问题**

**是否可以在不更改母版的情况下仅对单张幻灯片应用主题？**

是的。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅对该幻灯片应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/slidethememanager/)）。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

将幻灯片连同它们的母版一起 [克隆幻灯片](/slides/zh/cpp/clone-slides/) 到目标演示文稿。这样可以保留原始的母版、布局以及关联的主题，从而保持外观一致。

**如何查看所有继承和覆盖之后的“实际”值？**

使用 API 的 [“实际”视图](/slides/zh/cpp/shape-effective-properties/) 来获取主题/颜色/字体/效果的最终解析属性。这些视图返回应用母版以及任何本地覆盖后的最终值。