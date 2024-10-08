---
title: 形状效果
type: docs
weight: 30
url: /cpp/shape-effect
keywords: "形状效果, PowerPoint演示, C++, CPP, Aspose.Slides for C++"
description: "在C++中为PowerPoint形状应用效果"
---

虽然PowerPoint中的效果可以用于使形状更加突出，但它们与[填充](/slides/cpp/shape-formatting/#gradient-fill)或轮廓不同。使用PowerPoint效果，可以在形状上创建逼真的反射、扩散形状的光晕等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint提供六种可以应用于形状的效果。您可以将一种或多种效果应用于形状。

* 一些效果组合看起来比其他组合更好。因此，PowerPoint在**预设**下提供了选项。预设选项本质上是一种已知的好看组合，由两个或多个效果组合而成。通过选择预设，您将不必浪费时间测试或组合不同的效果来寻找好的组合。

Aspose.Slides在[EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/)类下提供属性和方法，允许您在PowerPoint演示文稿中的形状上应用相同的效果。

## **应用阴影效果**

以下C++代码显示如何将外部阴影效果（[OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)）应用于矩形：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **应用反射效果**

以下C++代码显示如何将反射效果应用于形状：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **应用发光效果**

以下C++代码显示如何将发光效果应用于形状：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **应用柔和边缘效果**

以下C++代码显示如何将柔和边缘效果应用于形状：

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```