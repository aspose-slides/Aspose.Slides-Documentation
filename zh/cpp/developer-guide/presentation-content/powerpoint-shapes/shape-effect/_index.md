---
title: 使用 C++ 在演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/cpp/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 对 PPT 和 PPTX 文件进行高级形状效果转换——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

在 PowerPoint 中，效果可用于使形状突出，但它们不同于 [填充](/slides/zh/cpp/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一种或多种效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **预设** 下提供选项。预设选项本质上是两个或多个已知搭配良好的效果的组合。这样，选择预设后，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for C++ 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上突出。阴影超出形状的边缘，营造形状悬浮在幻灯片上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

下面的 C++ 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/):
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

![阴影效果](shadow_effect.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板营造凹陷外观。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则在其边缘内部进行阴影处理。

调用 [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/)，然后配置 [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/)。较大的模糊半径值会产生更柔和的边缘。

下面的 C++ 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件：
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

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请对形状的 EffectFormat 调用 [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/)。

## **应用反射效果**

在 Aspose.Slides for C++ 中应用反射效果时，您可以为形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状赋予更精致、成熟的外观来提升演示文稿的美感。使用简易代码即可轻松实现，可快速在多个元素上应用以实现一致的设计。

下面的 C++ 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/):
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

![反射效果](reflection_effect.png)

## **应用发光效果**

在 Aspose.Slides for C++ 中对形状应用发光效果时，您可以在形状周围添加柔和、发光的光环，调节颜色和大小等属性。此效果有助于突出形状，并为演示文稿增添吸引人、抢眼的视觉元素。只需少量代码即可轻松实现，提升整体幻灯片外观。

下面的 C++ 代码演示如何对形状应用 [发光效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/):
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

![发光效果](glow_effect.png)

## **应用柔和边缘效果**

在 Aspose.Slides for C++ 中应用柔和边缘效果时，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，非常适合需要柔和外形的设计。您可以轻松调节半径等参数，以在演示文稿中的各种形状上实现所需效果。

下面的 C++ 代码演示如何对形状应用 [柔和边缘](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/):
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

![柔和边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可柔化形状的填充和轮廓，同时保持形状可编辑。对形状的 EffectFormat 调用 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/)。半径以点为单位（1/72 英寸）：使用非负值，较大的值会产生更强的模糊。半径为零时外观保持不变。

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) 设置控制效果的可见范围。设置为 `false` 时，模糊被裁剪到原始绘制范围，包括轮廓。设置为 `true` 时，模糊可超出该范围。两种设置都不会改变形状的位置或尺寸。

下面的比较使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形与 5 点和 15 点模糊半径的比较，grow 分别禁用和启用](shape_blur_comparison.png)

下面的 C++ 示例创建一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) 将其更新为 15 点模糊。它保存两个模糊状态，然后调用 [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) 并保存未模糊的形状。
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

形状模糊同时影响填充和轮廓。柔和边缘效果会淡化形状的边缘，而阴影模糊仅柔化阴影。图像变换效果作用于图像内容；本例直接对形状的 EffectFormat 应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动态性的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将作用于整个组合。