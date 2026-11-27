---
title: Применение эффектов фигур в презентациях с использованием C++
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/cpp/shape-effect/
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT и PPTX с помощью продвинутых эффектов фигур, используя Aspose.Slides для C++ — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Хотя эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заливок](/slides/ru/cpp/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать правдоподобные отражения на форме, распространять её свечение и т. д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset по сути представляют собой комбинацию двух и более эффектов, которые известны тем, что хорошо сочетаются. Таким образом, выбирая предустановку, вам не придется тратить время на тестирование или комбинирование разных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), позволяющие применять те же эффекты к формам в презентациях PowerPoint.

## **Применение эффекта тени**

Aspose.Slides для C++ поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применение внешней тени**

Используйте внешнюю тень, чтобы карта или панель выделялась на фоне слайда. Тень выходит за пределы краёв формы, создавая впечатление, что форма приподнята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код на C++ показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) к прямоугольнику:

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

#### **Управление направлением тени при вращении формы**

По умолчанию внешняя тень вращается вместе с формой. Чтобы формы с разными вращениями выглядели освещёнными из одного направления, вызовите [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) с `false` и используйте [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) чтобы задать их теням одинаковый угол.

В примере создаются две стрелки со серая тенями, смещёнными вправо (0°). Затем слайд дублируется и обе стрелки вращаются на 90° по часовой стрелке.

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto before = presentation->get_Slide(0);

auto left = before->get_Shapes()->AddAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
left->get_FillFormat()->set_FillType(FillType::Solid);
left->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
left->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

left->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = left->get_EffectFormat()->get_OuterShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_Gray());
shadow->set_Direction(0);
shadow->set_Distance(42);
shadow->set_BlurRadius(0);
shadow->set_RotateShadowWithShape(true);

auto right = before->get_Shapes()->AddClone(left);
right->set_X(395);
right->get_EffectFormat()->get_OuterShadowEffect()->set_RotateShadowWithShape(false);

auto after = presentation->get_Slides()->AddClone(before);
for (auto i = 0; i < after->get_Shapes()->get_Count(); ++i)
{
    after->get_Shape(i)->set_Rotation(90);
}

presentation->Save(u"arrow_shadows.pptx", SaveFormat::Pptx);
```

На втором слайде левая стрелка отбрасывает тень вниз, тогда как правая стрелка всё ещё отбрасывает тень вправо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после вращения на 90°. Оба теневых эффекта исходно находятся справа. После вращения тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применение внутренней тени**

При воссоздании визуального стиля шаблона используйте внутреннюю тень, чтобы придать карте или панели вдавленный вид. Внешняя тень выходит за пределы формы и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутреннюю часть её краёв.

Вызовите [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), затем настройте [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Большие значения радиуса размытия дают более мягкие края.

Этот пример на C++ создаёт светло‑голубую карту с тёмно‑серой внутренней тенью и сохраняет её как файл PPTX:

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

Чтобы удалить внутреннюю тень, вызовите [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) у формата эффекта формы.

### **Применение, изменение и удаление предустановленной тени**

Вызовите [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) и используйте [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) для выбора [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). Чтобы переключить стили, измените предустановку у той же формы. Вызовите [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) для удаления тени при сохранении заливки и контура.

Этот пример сохраняет копию прямоугольника на каждом этапе. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень над и слева от прямоугольника, а 45° размещает вторую тень ниже и справа.

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![Тень сверху слева](preset_shadow_top_left.png) | ![Тень снизу справа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применение эффекта отражения**

Для применения эффекта отражения в Aspose.Slides для C++ можно добавить зеркальное отражение к формам, настроив такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая формам более полированный и изысканный вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к нескольким элементам для согласованного дизайна.

Этот код на C++ показывает, как применить [reflection effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) к форме:

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

Для применения эффекта свечения к форме в Aspose.Slides для C++ можно добавить мягкое светящееся сияние вокруг формы, настроив такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный визуальный элемент к вашей презентации. Его легко реализовать с минимальным объёмом кода, улучшая общий вид ваших слайдов.

Этот код на C++ показывает, как применить [glow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) к форме:

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

Для применения эффекта мягких краёв в Aspose.Slides для C++ можно создать плавный размытой переход вокруг краёв формы. Этот эффект добавляет более утончённый и изысканный вид, идеально подходящий для дизайнов, требующих мягкого, менее резкого отображения. Вы легко можете настраивать такие параметры, как радиус, чтобы достичь желаемого эффекта на различных формах в вашей презентации.

Этот код на C++ показывает, как применить [soft edges](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) к форме:

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

Используйте размытие формы, чтобы смягчить заливку и контур формы, сохраняя её редактируемой. Вызовите [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) у формата эффекта формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус 0 оставляет внешний вид без изменений.

Параметр [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) управляет видимыми границами эффекта. При `false` размытие обрезается по оригинальным нарисованным границам, включая контур. При `true` размытие может выходить за эти границы. Ни одна из настроек не меняет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы во всех случаях. Верхняя строка использует `grow = false`; нижняя строка — `grow = true`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, с отключённым и включённым увеличением](shape_blur_comparison.png)

Этот пример на C++ создаёт оранжевый прямоугольник с тёмно‑синей окантовкой, применяет размытие 5 пунктов, а затем обновляет его до 15 пунктов, снова вызывая [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Он сохраняет оба размышлённых состояния, затем вызывает [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) и сохраняет форму без размытия.

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

Размытие формы влияет одновременно на заливку и контур. Эффект мягких краёв смягчает края формы, тогда как размытие тени смягчает только тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффекта формы без преобразования её в изображение.

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной форме, чтобы создать более динамичный внешний вид.

**К каким формам можно применять эффекты?**

Вы можете применять эффекты к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, объекты OLE и другие.

**Можно ли применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.