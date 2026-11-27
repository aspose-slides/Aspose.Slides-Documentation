---
title: Apply Shape Effects in Presentations Using C++
linktitle: Shape Effect
type: docs
weight: 30
url: /cpp/shape-effect/
keywords:
- shape effect
- shadow effect
- reflection effect
- glow effect
- soft edges effect
- effect format
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Transform your PPT and PPTX files with advanced shape effects using Aspose.Slides for C++ — create striking, professional slides in seconds."
---

## **Introduction**

While effects in PowerPoint can be used to make a shape stand out, they differ from [fills](/slides/cpp/shape-formatting/#gradient-fill) or outlines. Using PowerPoint effects, you can create convincing reflections on a shape, spread a shape's glow, etc.

![Shape effect](shape-effect.png)

PowerPoint provides six effects that can be applied to shapes. You can apply one or more effects to a shape.

Some combinations of effects look better than others. For this reason, PowerPoint has options under **Preset**. The Preset options are essentially a combination of two or more effects known to look good together. This way, by selecting a preset, you won't have to waste time testing or combining different effects to find a nice combination.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Apply a Shadow Effect**

Aspose.Slides for C++ supports outer and inner shadows for shapes. You can customize their color, direction, distance, and blur radius to match your presentation's design.

### **Apply an Outer Shadow**

Use an outer shadow to make a card or panel stand out against the slide background. The shadow extends beyond the shape's edges, creating the impression that the shape is raised above the slide. Adjust its color, direction, distance, and blur radius to match the lighting and styling of your template.

This C++ code shows how to apply the [outer shadow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) to a rectangle:

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

![Shadow effect](shadow_effect.png)

#### **Control the Shadow Direction When a Shape Rotates**

By default, an outer shadow rotates with its shape. To make shapes with different rotations appear lit from the same direction, call [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) with `false` and use [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) to give their shadows the same angle.

The example creates two arrows with gray shadows offset to the right (0°). It then duplicates the slide and rotates both arrows 90° clockwise.

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

On the second slide, the left arrow casts its shadow downward, while the right arrow still casts its shadow to the right. The configured direction remains 0° for both shadows.

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **Apply an Inner Shadow**

When reproducing a template's visual styling, use an inner shadow to give a card or panel a recessed appearance. An outer shadow extends outside the shape and makes it appear raised, while an inner shadow shades the inside of its edges.

Call [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), then configure [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Larger blur radius values produce softer edges.

This C++ example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file:

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

To remove the inner shadow, call [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) on the shape's effect format.

### **Apply, Change, and Remove a Preset Shadow**

Call [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) and use [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) to select a [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). To switch styles, change the preset on the same shape. Call [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) to remove the shadow while preserving the fill and outline.

This example keeps a copy of the rectangle at each stage. Both shadows are offset by 10 points. A direction of 225° places the first shadow above and to the left of the rectangle, and 45° places the second below and to the right.

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

| Original | First preset | Second preset | After removal |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Apply a Reflection Effect**

To apply a reflection effect in Aspose.Slides for C++, you can add a mirror-like reflection to shapes, adjusting parameters such as distance, transparency, and size. This effect enhances the aesthetic of your presentations by giving shapes a more polished and sophisticated look. It’s easy to implement with simple code, enabling quick application across multiple elements for a consistent design.

This C++ code shows how to apply the [reflection effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) to a shape:

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

![Reflection effect](reflection_effect.png)

## **Apply a Glow Effect**

To apply a glow effect to a shape in Aspose.Slides for C++, you can add a soft, luminous aura around shapes, adjusting properties like color and size. This effect helps make shapes stand out and adds an attractive, eye-catching visual element to your presentation. It's easy to implement with minimal code, enhancing the overall look of your slides.

This C++ code shows how to apply the [glow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) to a shape:

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

![Glow effect](glow_effect.png)

## **Apply a Soft Edges Effect**

To apply a soft edges effect in Aspose.Slides for C++, you can create a smooth, blurred transition around the edges of a shape. This effect adds a more subtle and refined look, perfect for designs that need a gentle, softer appearance. You can easily adjust parameters like radius to achieve the desired effect across various shapes in your presentation.

This C++ code shows how to apply the [soft edges](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) to a shape:

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

![Soft edges effect](soft_edges_effect.png)

## **Apply a Blur Effect**

Use shape blur to soften a shape's fill and outline while keeping the shape editable. Call [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) on the shape's effect format. The radius is measured in points (1/72 inch): use a nonnegative value, with larger values producing stronger blur. A radius of zero leaves the appearance unchanged.

The [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) setting controls the visible bounds of the effect. With `false`, the blur is clipped to the original painted bounds, including the outline. With `true`, the blur can extend beyond those bounds. Neither setting changes the shape's position or dimensions.

The comparison below uses the same fill, outline, and shape dimensions throughout. The top row uses `grow = false`; the bottom row uses `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

This C++ example creates an orange rectangle with a dark blue outline, applies a 5-point blur, and then updates it to a 15-point blur by calling [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) again. It saves both blurred states, then calls [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) and saves the shape without blur.

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

Shape blur affects the fill and outline together. A soft edges effect fades the shape's edges, while shadow blur softens only the shadow. Image transformation effects operate on image content; this example applies blur directly to the shape's effect format without converting the shape to an image.

## **FAQ**

**Can I apply multiple effects to the same shape?**

Yes, you can combine different effects, such as shadow, reflection, and glow, on a single shape to create a more dynamic appearance.

**What shapes can I apply effects to?**

You can apply effects to various shapes, including autoshapes, charts, tables, pictures, SmartArt objects, OLE objects, and more.

**Can I apply effects to grouped shapes?**

Yes, you can apply effects to grouped shapes. The effect will apply to the entire group.
