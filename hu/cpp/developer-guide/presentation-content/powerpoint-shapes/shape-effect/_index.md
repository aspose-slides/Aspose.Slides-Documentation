---
title: Alakzat effektusok alkalmazása prezentációkban C++-szal
linktitle: Alakzat effektus
type: docs
weight: 30
url: /hu/cpp/shape-effect/
keywords:
- alakzat effektus
- árnyék effektus
- reflexió effektus
- ragyogás effektus
- lágy szegélyek effektus
- effektus formátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat effektusokkal az Aspose.Slides for C++ segítségével — hozzon létre lenyűgöző, professzionális diát néhány másodperc alatt."
---
## **Bevezetés**

Miközben a PowerPoint‑ben az effektusok egy alakzat kiemelésére szolgálnak, különböznek a [kitöltésektől](/slides/hu/cpp/shape-formatting/#gradient-fill) vagy a körvonalaktól. PowerPoint‑effektusokkal meggyőző tükröződéseket hozhat létre egy alakzaton, sugározhatja az alakzat ragyogását stb.

<img src="shape-effect.png" alt="alakhatás" style="zoom:50%;" />

* A PowerPoint hat hatást kínál, amelyeket alakzatokra lehet alkalmazni. Egy alakzatra egy vagy több effektust is alkalmazhat. 

* Egyes effektus kombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint opciói a **Preset** alatt. Az előre beállított (Preset) opciók lényegében egy ismert, jól kinéző két vagy több effektusból álló kombinációt jelentenek. Így egy előre beállítást választva nem kell időt vesztegetni különböző effektusok tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.effect_format/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat az effektusokat alkalmazza a PowerPoint‑prezentációk alakzataira.

## **Árnyék effektus alkalmazása**

Ez a C++ kód megmutatja, hogyan alkalmazhatja a külső árnyék effektust ([OuterShadowEffect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) egy téglalapra:

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

## **Reflexió effektus alkalmazása**

Ez a C++ kód megmutatja, hogyan alkalmazhatja a reflexió effektust egy alakzatra:

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

## **Ragyogás effektus alkalmazása**

Ez a C++ kód megmutatja, hogyan alkalmazhatja a ragyogás effektust egy alakzatra:

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

## **Lágy szegélyek effektus alkalmazása**

Ez a C++ kód megmutatja, hogyan alkalmazhatja a lágy szegélyeket egy alakzatra:

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

## **GYIK**

**Alkalmazhatok több effektust ugyanarra az alakzatra?**

Igen, különböző effektusokat, például árnyékot, reflexiót és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok effektusokat?**

Effektusokat különféle alakzatokra alkalmazhat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok effektusokat csoportosított alakzatokra?**

Igen, csoportosított alakzatokra is alkalmazhat effektusokat. Az effektus az egész csoportra lesz alkalmazva.