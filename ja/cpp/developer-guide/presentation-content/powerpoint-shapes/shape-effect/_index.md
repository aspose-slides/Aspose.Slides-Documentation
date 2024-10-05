---
title: シェイプ効果
type: docs
weight: 30
url: /cpp/shape-effect
keywords: "シェイプ効果, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointシェイプに効果を適用する"
---

PowerPointのエフェクトはシェイプを際立たせるために使用できますが、[フィル](/slides/cpp/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPointエフェクトを使用すると、シェイプに convincingな反射を作成したり、シェイプの輝きを広げたりすることができます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPointはシェイプに適用できる6つのエフェクトを提供しています。シェイプに1つ以上のエフェクトを適用することができます。

* エフェクトのいくつかの組み合わせは他よりも見栄えが良いです。この理由から、PowerPointには**プリセット**オプションがあります。プリセットオプションは、2つ以上のエフェクトの良好な組み合わせを本質的に示しています。このようにして、プリセットを選択することで、良い組み合わせを見つけるために異なるエフェクトをテストしたり組み合わせたりする時間を無駄にすることはありません。

Aspose.Slidesは、PowerPointプレゼンテーションのシェイプに同じエフェクトを適用するための[EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/)クラスのプロパティとメソッドを提供しています。

## **影の効果を適用する**

このC++コードは、長方形に外部影の効果（[OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)）を適用する方法を示しています：

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

## **反射効果を適用する**

このC++コードは、シェイプに反射効果を適用する方法を示しています：

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

## **グロー効果を適用する**

このC++コードは、シェイプにグロー効果を適用する方法を示しています：

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

## **ソフトエッジ効果を適用する**

このC++コードは、シェイプにソフトエッジを適用する方法を示しています：

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