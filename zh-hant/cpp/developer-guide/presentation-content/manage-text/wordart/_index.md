---
title: 在 C++ 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/cpp/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 反射效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中建立與自訂 WordArt 效果。此步驟指南協助開發人員在 C++ 中以專業文字強化簡報。"
---
## **概述**

WordArt 效果讓您可以使用填充、輪廓、陰影、反射、發光、變形以及 3D 格式來美化文字。本文說明如何在未安裝 Microsoft Office 的情況下，使用 Aspose.Slides for C++ 在 PowerPoint 簡報中建立和自訂這些效果。

## **建立簡易 WordArt 範本並套用至文字**

以下範例透過設定文字、字型、圖案填色與輪廓，建立簡易的 WordArt 風格。

每個範例都會建立新的簡報，並在第一張投影片上新增一個矩形；不需要輸入檔案。第一個範例將文字設定為「Aspose.Slides」。形狀的位置與尺寸以點 (point) 為單位：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

將字型設定為 36 點的 Arial Black，以使格式更明顯：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

套用具有深橘色前景與白色背景的 [SmallGrid](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/patternstyle/) 圖案，然後加入寬度為 1 點的黑色文字輪廓：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

產生的文字：

![簡易 WordArt 範本](WordArt_template.png)

## **套用其他 WordArt 效果**

以下範例示範如何將陰影、反射、發光、變形與 3D 效果套用至文字。

### **套用外部陰影效果**

外部陰影透過在文字背後放置陰影來增添深度。您可以自訂其顏色、方向、距離、模糊半徑、比例與斜切。

此範例呼叫 [EnableOuterShadowEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) 並設定黑色陰影，模糊半徑為 4 點、方向為 230 度、距離為 30 點。比例值 100 保持陰影大小，水平斜切則將其傾斜 20 度。Alpha 變換將不透明度設為 32%：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

產生的文字：

![外部陰影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 當同時使用外部陰影與預設陰影時，僅套用外部陰影。
- 若同時使用外部陰影與內部陰影，最終效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍，而在 PowerPoint 2007 中則僅套用外部陰影。
{{% /alert %}}

### **套用反射效果**

反射會產生文字的鏡像副本。調整其位置、比例、模糊與不透明度即可控制外觀。

此範例呼叫 [EnableReflectionEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) 並以 -100% 的比例垂直翻轉反射。它使用 0.5 點的模糊半徑與 4.72 點的距離。沿反射的 0% 到 60% 位置，不透明度由 60% 下降至 0.9%：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

產生的文字：

![反射效果](reflection_effect.png)

### **套用發光效果**

發光會在文字周圍加入柔和的彩色輪廓。調整其顏色、不透明度與半徑即可控制效果。

此範例呼叫 [EnableGlowEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ieffectformat/enablegloweffect/) 並套用紅色發光，透明度為 54%，半徑為 7 點：

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

產生的文字：

![發光效果](glow_effect.png)

### **套用 WordArt 變形**

WordArt 變形會彎曲、伸展或扭曲文字區塊。

將 [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/set_transform/) 設為 [ArchUpPour](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textshapetype/)，即可將整個文字框向上彎曲：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

產生的文字：

![WordArt 變形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ 提供一組預先定義的 [變形類型](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textshapetype/)。
{{% /alert %}}

### **套用 3D 效果至圖形與文字**

您可以將 3D 效果套用至圖形或其文字。斜角、擠出、光照與相機設定會影響最終外觀。

以下範例使用 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 為矩形新增圓形斜角、橙色擠出以及深紅色輪廓。斜角尺寸、擠出高度、輪廓寬度與深度皆以點為單位。塑膠材質、繞 Z 軸旋轉 40 度的均衡光照，以及透視相機共同決定其外觀：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

產生的圖形：

![圖形 3D 效果](shape_3D_effect.png)

此範例透過 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/get_threedformat/) 為文字套用類似的 3D 格式。較小的斜角塑造字母邊緣，而擠出與光照則賦予文字深度：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

產生的文字：

![文字 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
將 3D 效果套用至文字或其圖形——以及這些效果之間的交互——受到特定規則的約束。請考慮同時包含文字與其所在圖形的場景。3D 效果包括物件的 3D 表示以及其所處的場景。

- 若同時為圖形和文字設定了場景，則圖形的場景具有優先權，文字的場景將被忽略。
- 若圖形沒有自己的場景但具有 3D 表示，則使用文字的場景。
- 若圖形根本沒有 3D 效果，則視為平面，且 3D 效果僅套用於文字。

這些行為與 [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_lightrig/) 與 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_camera/) 方法相關。
{{% /alert %}}

若要在保留圖形 3D 格式的同時保持文字平面且易讀，請參閱 [在 3D 圖形上保持文字平面](/slides/zh-hant/cpp/3d-presentation/) 以比較兩種設定並取得完整的 C++ 範例。

## **常見問題**

**我可以在不同字型或文字系統（例如阿拉伯文、中文）上使用 WordArt 效果嗎？**

是的，Aspose.Slides for C++ 支援 Unicode，能與所有主要字型與文字系統一起使用。無論語言為何，都可以套用陰影、填色與輪廓等 WordArt 效果，但字型是否可用以及渲染效果可能取決於系統字型。

**我可以將 WordArt 效果套用至投影片母片元素嗎？**

是的，您可以將 WordArt 效果套用至母片投影片上的圖形，包括標題佔位元、頁尾或背景文字。對母版版面的變更將會套用至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會有輕微影響。陰影、發光與漸層填色等 WordArt 效果會因為額外的格式化資訊而稍微增加檔案大小，但差異通常可忽略不計。

**我可以在未儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

是的，您可以使用 [ISlide::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 將包含 WordArt 的投影片渲染為圖像（例如 PNG、JPEG），或使用 [IShape::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getimage/) 渲染個別圖形。這樣即可在記憶體或螢幕上預覽結果，無需先儲存或匯出完整簡報。