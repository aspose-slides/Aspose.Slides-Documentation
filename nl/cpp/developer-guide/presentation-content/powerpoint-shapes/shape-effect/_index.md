---
title: Toepassen van Vormeffecten in Presentaties met C++
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/cpp/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloei‑effect
- zachtrand‑effect
- effectformaat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Transformeer uw PPT‑ en PPTX‑bestanden met geavanceerde vormeffecten met Aspose.Slides voor C++ — maak verbluffende, professionele dia's in enkele seconden."
---
## **Introductie**

Hoewel effecten in PowerPoint gebruikt kunnen worden om een vorm te laten opvallen, verschillen ze van [fills](/slides/nl/cpp/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kunt u overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. U kunt één of meerdere effecten op een vorm toepassen. 

* Sommige combinaties van effecten zien er beter uit dan andere. Om die reden staan de PowerPoint‑opties onder **Preset**. De preset‑opties zijn in wezen een bekende, goed uitziende combinatie van twee of meer effecten. Op deze manier hoeft u bij het kiezen van een preset geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.effect_format/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Schaduweffect toepassen**

Deze C++‑code laat zien hoe u het buitenschaduw‑effect ([OuterShadowEffect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) op een rechthoek toepast:

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

## **Reflectie‑effect toepassen**

Deze C++‑code laat zien hoe u het reflectie‑effect op een vorm toepast:

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

## **Gloei‑effect toepassen**

Deze C++‑code laat zien hoe u het gloei‑effect op een vorm toepast:

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

## **Zachte randen‑effect toepassen**

Deze C++‑code laat zien hoe u het zachte randen‑effect op een vorm toepast:

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

## **FAQ**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, u kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

U kunt effecten toepassen op verschillende vormen, waaronder auto‑vormen, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, u kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.