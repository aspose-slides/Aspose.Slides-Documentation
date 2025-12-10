---
title: Применение эффектов фигур в презентациях с использованием C++
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/cpp/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для C++ — создавайте яркие, профессиональные слайды за считанные секунды."
---

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заливок](/slides/ru/cpp/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создать убедительные отражения на форме, распространить светящийся ореол формы и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.  
* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры **Preset**. Параметры Preset представляют собой известные хорошо выглядящие комбинации двух и более эффектов. Таким образом, выбирая готовый набор, вам не придётся тратить время на тестирование или комбинирование различных эффектов в поисках хорошей комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format/) , которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот C++ код показывает, как применить внешний эффект тени ([OuterShadowEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) к прямоугольнику:
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


## **Применить эффект отражения**

Этот C++ код показывает, как применить эффект отражения к форме:
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


## **Применить эффект светящегося ореола**

Этот C++ код показывает, как применить эффект светящегося ореола к форме:
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


## **Применить эффект мягких краёв**

Этот C++ код показывает, как применить мягкие края к форме:
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

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и светящийся ореол, на одной форме, чтобы создать более динамичный вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автоформы, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.