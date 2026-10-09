---
title: Применение эффектов фигур в презентациях с помощью C++
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/cpp/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для C++ — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заполнения](/slides/ru/cpp/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, распространять светящееся свечение формы и т.д.

![Эффект фигуры](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры под **Предустановки**. Параметры Предустановки представляют собой комбинацию двух и более эффектов, известную как хорошую. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или сочетание разных эффектов в поиске удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), которые позволяют применять такие же эффекты к фигурам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for C++ поддерживает внешние и внутренние тени для фигур. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы карточка или панель выделялась на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещённости и стилю вашего шаблона.

Этот код C++ показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) к прямоугольнику:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Эффект тени](shadow_effect.png)

### **Применение внутренней тени**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное изображение. Внешняя тень выходит за пределы формы и делает её выглядящей поднятой, тогда как внутренняя тень затемняет внутренние края.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Большие значения радиуса размытия дают более мягкие края.

Этот пример C++ создаёт светло‑голубую карточку с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффектов фигуры.

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for C++, вы можете добавить зеркальное отражение к фигурам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает визуальный стиль презентаций, придавая фигурам более отполированный и изысканный вид. Его легко реализовать при помощи простого кода, позволяющего быстро применять его к нескольким элементам для согласованного дизайна.

Этот код C++ показывает, как применить [эффект отражения](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) к фигуре:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Эффект отражения](reflection_effect.png)

## **Применение эффекта свечения**

Чтобы применить эффект свечения к фигуре в Aspose.Slides for C++, вы можете добавить мягкое светящееся сияние вокруг фигур, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий вид ваших слайдов.

Этот код C++ показывает, как применить [эффект свечения](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) к фигуре:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Эффект свечения](glow_effect.png)

## **Применение эффекта мягких краёв**

Чтобы применить эффект мягких краёв в Aspose.Slides for C++, вы можете создать плавный, размытый переход вокруг краёв фигуры. Этот эффект придаёт более нежный и изысканный вид, идеально подходящий для дизайнов, которым требуется мягкое, приглушённое оформление. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта на различных фигурах вашей презентации.

Этот код C++ показывает, как применить [мягкие края](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) к фигуре:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Эффект мягких краёв](soft_edges_effect.png)

## **FAQ**

**Могу ли я применить несколько эффектов к одной и той же фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный внешний вид.

**К каким фигурам можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, объекты OLE и многое другое.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, вы можете применять эффекты к сгруппированным фигурам. Эффект будет применён ко всей группе.