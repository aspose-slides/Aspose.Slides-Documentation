---
title: Použití efektů tvarů v prezentacích pomocí C++
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/cpp/shape-effect/
keywords:
- efekt tvaru
- stínový efekt
- odrazový efekt
- zářivý efekt
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX s pokročilými efekty tvarů pomocí Aspose.Slides pro C++ — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k tomu, aby tvar vynikl, liší se od [vyplnění](/slides/cs/cpp/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint poskytuje šest efektů, které lze aplikovat na tvary. Na tvar lze použít jeden nebo více efektů.  

* Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu jsou v PowerPointu možnosti pod **Preset**. Volby Preset jsou v podstatě osvědčené kombinace dvou nebo více efektů, které vypadají dobře. Tímto způsobem při výběru předvolby nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.effect_format/) umožňující použít stejné efekty na tvary v prezentacích PowerPointu.

## **Použít stínový efekt**

Tento C++ kód ukazuje, jak aplikovat vnější stínový efekt ([OuterShadowEffect](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) na obdélník:

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

## **Použít odrazový efekt**

Tento C++ kód ukazuje, jak aplikovat odrazový efekt na tvar:

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

## **Použít zářivý efekt**

Tento C++ kód ukazuje, jak aplikovat zářivý efekt na tvar:

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

## **Použít efekt měkkých hran**

Tento C++ kód ukazuje, jak aplikovat měkké hrany na tvar:

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

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jediném tvaru a vytvořit tak dynamický vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty lze použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, efekty lze použít na seskupené tvary. Efekt bude aplikován na celou skupinu.