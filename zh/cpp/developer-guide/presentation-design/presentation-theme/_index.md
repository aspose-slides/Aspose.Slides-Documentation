---
title: 演示主题
type: docs
weight: 10
url: /zh/cpp/presentation-theme/
keywords: "主题, PowerPoint主题, PowerPoint演示, CPP, C++, Aspose.Slides for C++"
description: "C++中的PowerPoint演示主题"
---

演示主题定义了设计元素的属性。当您选择一个演示主题时，您实际上是在选择一组特定的视觉元素及其属性。

在PowerPoint中，主题由颜色、[字体](/slides/zh/cpp/powerpoint-fonts/)、[背景样式](/slides/zh/cpp/presentation-background/)和效果组成。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint主题为幻灯片上的不同元素使用一组特定的颜色。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides提供了[SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28)枚举下的值。

以下C++代码展示了如何更改主题的强调颜色：

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

您可以通过以下方式确定结果颜色的有效值：

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

为进一步演示颜色更改操作，我们创建另一个元素并将强调颜色（来自初始操作）分配给它。然后我们在主题中更改颜色：

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

新颜色会自动应用于两个元素。

### **从附加调色板设置主题颜色**

当您对主主题颜色(1)应用亮度变换时，会形成附加调色板(2)中的颜色。然后，您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主主题颜色

**2** - 附加调色板中的颜色。

以下C++代码演示了从主主题颜色获取附加调色板颜色并在形状中使用的操作：

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// 强调 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// 强调 4，亮度 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// 强调 4，亮度 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// 强调 4，亮度 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// 强调 4，亮度 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// 强调 4，亮度 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **更改主题字体**

为了让您选择主题及其他目的的字体，Aspose.Slides使用这些特殊标识符（类似于PowerPoint中使用的）：

* **+mn-lt** - 正文字体拉丁（小型拉丁字体）
* **+mj-lt** - 标题字体拉丁（主要拉丁字体）
* **+mn-ea** - 正文字体东亚（小型东亚字体）
* **+mj-ea** - 正文字体东亚（主要东亚字体）

以下C++代码展示了如何将拉丁字体分配给主题元素：

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"主题文本格式");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

以下C++代码展示了如何更改演示主题字体：

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

所有文本框中的字体将会更新。

{{% alert color="primary" title="提示" %}} 

您可以查看[PowerPoint字体](/slides/zh/cpp/powerpoint-fonts/)。

{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint应用提供12个预定义的背景，但在典型演示中仅保存其中3个背景。 

![todo:image_alt_text](presentation-design_8.png)

例如，在您在PowerPoint应用中保存演示后，您可以运行以下C++代码找出演示中预定义背景的数量：

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"主题的背景填充样式数量为 {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

使用[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/)类的[BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d)属性，您可以在PowerPoint主题中添加或访问背景样式。 

{{% /alert %}}

以下C++代码展示了如何设置演示的背景：

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**索引指南**： 0表示无填充。索引从1开始。

{{% alert color="primary" title="提示" %}} 

您可以查看[PowerPoint背景](/slides/zh/cpp/presentation-background/)。

{{% /alert %}}

## **更改主题效果**

PowerPoint主题通常为每个样式数组包含3个值。这些数组结合成这3种效果：微妙的、适中的和强烈的。例如，以下是在特定形状上应用效果后的结果：

![todo:image_alt_text](presentation-design_10.png)

使用来自[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/)类的3个属性（[FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)、[LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd)、[EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)），您可以更灵活地更改主题中的元素（甚至比PowerPoint中的选项更灵活）。

以下C++代码展示了如何通过更改元素的部分来改变主题效果：

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

填充颜色、填充类型、阴影效果等的结果变化：

![todo:image_alt_text](presentation-design_11.png)