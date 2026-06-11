---
title: Applicera formseffekter i presentationer med C++
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/cpp/shape-effect/
keywords:
- formeffekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- mjuk kantseffekt
- effektformat
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Transformera dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för C++ — skapa slående, professionella bilder på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fills](/slides/sv/cpp/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en forms glöd, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan applicera en eller flera effekter på en form. 

* Vissa kombinationer av effekter ser bättre ut än andra. Därför finns PowerPoint‑alternativ under **Preset**. Preset‑alternativen är i princip en väl beprövad kombination av två eller fler effekter. På så sätt, genom att välja ett förinställt alternativ, slipper du slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.effect_format/) som låter dig applicera samma effekter på former i PowerPoint‑presentationer.

## **Applicera en skuggeffekt**

Denna C++‑kod visar hur du applicerar den yttre skuggeffekten ([OuterShadowEffect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) på en rektangel:

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

## **Applicera en reflektionseffekt**

Denna C++‑kod visar hur du applicerar reflektionseffekten på en form:

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

## **Applicera en glödeffekt**

Denna C++‑kod visar hur du applicerar glödeffekten på en form:

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

## **Applicera en mjuk kant‑effekt**

Denna C++‑kod visar hur du applicerar mjuka kanter på en form:

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

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.