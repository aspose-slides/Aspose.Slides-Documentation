---
title: Применение эффектов формы в презентациях с использованием C++
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/cpp/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте файлы PPT и PPTX с помощью продвинутых эффектов формы в Aspose.Slides для C++ — создавайте яркие профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint могут использоваться для того, чтобы форма выделялась, однако они отличаются от [заливки](/slides/ru/cpp/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, распространять свечение формы и т. д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применить к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset по сути представляют собой комбинацию двух или более эффектов, которые известны тем, что хорошо сочетаются. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов для поиска удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), позволяющие применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides for C++ поддерживает внешние и внутренние тени для форм. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы карточка или панель выделялась на фоне слайда. Тень выходит за границы формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии со светом и стилем вашего шаблона.

Этот пример на C++ показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) к прямоугольнику:
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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное отображение. Внешняя тень располагается за пределами формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутреннюю часть её границ.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Большие значения радиуса размытия дают более мягкие края.

Этот пример на C++ создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX:
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

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффектов формы.

## **Применение эффекта отражения**

Чтобы применить эффект отражения в Aspose.Slides for C++, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более отполированный и изысканный вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот пример на C++ показывает, как применить [эффект отражения](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) к форме:
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

Чтобы применить эффект свечения к форме в Aspose.Slides for C++, вы можете добавить мягкую светящуюся ауру вокруг форм, настроив такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, привлекающий внимание визуальный элемент в вашей презентации. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот пример на C++ показывает, как применить [эффект свечения](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) к форме:
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

Чтобы применить эффект мягких краёв в Aspose.Slides for C++, вы можете создать плавный размытой переход вокруг краев формы. Этот эффект придаёт более деликатный и изысканный вид, идеально подходящий для дизайнов, требующих нежного, более мягкого отображения. Вы можете легко регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта для разных форм в презентации.

Этот пример на C++ показывает, как применить [мягкие края](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) к форме:
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

## **Применение эффекта размытия**

Используйте размытие формы, чтобы смягчить заливку и контур формы, сохраняя её редактируемой. Вызовите [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, оставляет внешний вид без изменений.

Параметр [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) управляет видимыми границами эффекта. При `false` размытие ограничивается исходными нарисованными границами, включая контур. При `true` размытие может выходить за эти границы. Ни один из параметров не меняет позицию или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы. В верхней строке используется `grow = false`; в нижней — `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов при отключённом и включённом Grow](shape_blur_comparison.png)

Этот пример на C++ создаёт оранжевый прямоугольник с тёмно‑синий контуром, применяет размытие радиуса 5 пунктов, а затем обновляет его до 15 пунктов, вызвав [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) ещё раз. Он сохраняет оба состояния размытия, затем вызывает [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) и сохраняет форму без размытия.
```cpp
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Размытие формы воздействует одновременно на заливку и контур. Эффект мягких краёв размывает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображений работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффектов формы без преобразования её в изображение.

## **FAQ**

**Могу ли я применить несколько эффектов к одной и той же форме?**  
Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный вид.

**Каким формам можно применять эффекты?**  
Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и другие.

**Можно ли применять эффекты к сгруппированным формам?**  
Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.