---
title: 在簡報中使用 C++ 套用圖形效果
linktitle: 圖形效果
type: docs
weight: 30
url: /zh-hant/cpp/shape-effect/
keywords:
- 圖形效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 的進階圖形效果，轉換您的 PPT 與 PPTX 檔案 —— 只需數秒即可製作引人注目、專業的投影片。"
---
## **介紹**

雖然 PowerPoint 中的效果可用於讓圖形突顯，但它們與[填色](/slides/zh-hant/cpp/shape-formatting/#gradient-fill)或輪廓不同。使用 PowerPoint 效果，您可以在圖形上建立逼真的反射、擴散圖形的發光等。

![Shape effect](shape-effect.png)

PowerPoint 提供六種可套用於圖形的效果。您可以對圖形套用一種或多種效果。

某些效果組合看起來比其他組合更佳。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是已知能相互搭配的兩種或多種效果的組合。如此一來，選擇預設後，就不必花時間測試或組合不同效果以找出合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您在 PowerPoint 簡報的圖形上套用相同的效果。

## **套用陰影效果**

Aspose.Slides for C++ 支援圖形的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板相較於投影片背景更為突出。陰影延伸至圖形邊緣之外，產生圖形浮起於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

此 C++ 程式碼示範如何將[外部陰影效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/)套用至矩形：

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

### **套用內部陰影**

在重製範本的視覺樣式時，使用內部陰影可讓卡片或面板呈現凹陷的外觀。外部陰影會延伸至圖形外部，使其看起來提升，而內部陰影則為其邊緣內部著色。

呼叫[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/)，然後設定[InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/)。較大的模糊半徑值會產生較柔和的邊緣。

此 C++ 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後儲存為 PPTX 檔案：

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

若要移除內部陰影，請對圖形的 effect format 呼叫[DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/)。

## **套用反射效果**

在 Aspose.Slides for C++ 中套用反射效果時，您可以為圖形加入鏡面般的倒影，並調整距離、透明度與尺寸等參數。此效果透過簡單程式碼即可提升簡報的美感，使圖形更具精緻與專業的外觀，且可快速在多個元素間一致套用。

此 C++ 程式碼示範如何將[反射效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/)套用至圖形：

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

## **套用發光效果**

在 Aspose.Slides for C++ 中套用發光效果時，您可以在圖形周圍添加柔和的光暈，並調整顏色與大小等屬性。此效果有助於讓圖形更加突出，為簡報增添吸睛的視覺元素，且僅需少量程式碼即可完成。

此 C++ 程式碼示範如何將[發光效果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/)套用至圖形：

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

## **套用柔和邊緣效果**

在 Aspose.Slides for C++ 中套用柔和邊緣效果時，您可以在圖形的邊緣創建平滑、模糊的過渡。此效果為設計增添更為細膩與精緻的外觀，適合需要柔和外觀的版面配置。您可以輕鬆調整半徑等參數，以在簡報中各種圖形上實現理想的效果。

此 C++ 程式碼示範如何將[柔和邊緣](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/)套用至圖形：

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

## **套用模糊效果**

使用圖形模糊可在保持圖形可編輯的前提下，使其填色與輪廓變得柔和。對圖形的 effect format 呼叫[SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/)。半徑以點 (1/72 英吋) 為單位：使用非負值，較大的值會產生較強的模糊。半徑為零則不改變外觀。

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) 設定控制效果的可視範圍。`false` 時，模糊會被裁切至原始繪製範圍（包含輪廓）。`true` 時，模糊可延伸至該範圍之外。兩者皆不會改變圖形的位置或尺寸。

以下比較在相同填色、輪廓與圖形尺寸下的效果。上排使用 `grow = false`；下排使用 `grow = true`。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

此 C++ 範例建立一個橙色矩形並套用深藍色輪廓，先使用 5 點模糊，然後再次呼叫[SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/)將模糊半徑改為 15 點，並分別儲存兩個模糊狀態。之後呼叫[DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/)以儲存未加模糊的圖形。

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

圖形模糊同時影響填色與輪廓。柔和邊緣效果會淡化圖形的邊緣，而陰影模糊僅軟化陰影。影像變換效果作用於影像內容；本例直接對圖形的 effect format 套用模糊，未將圖形轉換為影像。

## **常見問題**

**我可以對同一個圖形套用多個效果嗎？**

可以，您可以將陰影、反射、發光等不同效果組合在同一圖形上，以建立更具動態的外觀。

**哪些圖形可以套用效果？**

您可以對各種圖形套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組圖形套用效果嗎？**

可以，效果會套用至整個群組。