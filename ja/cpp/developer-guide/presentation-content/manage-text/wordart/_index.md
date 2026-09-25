---
title: C++ で WordArt エフェクトを作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/cpp/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt エフェクト
- 影エフェクト
- 反射エフェクト
- 光彩エフェクト
- WordArt 変形
- 3D エフェクト
- 外側の影エフェクト
- 内側の影エフェクト
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で WordArt エフェクトを作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が C++ でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、テキストに塗りつぶし、輪郭、影、反射、光彩、変形、3D 書式設定を適用して装飾できます。本記事では、Microsoft Office をインストールせずに Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションでこれらのエフェクトを作成およびカスタマイズする方法を説明します。

## **シンプルな WordArt テンプレートを作成し、テキストに適用する**

以下の例は、テキスト、フォント、パターン塗りつぶし、輪郭を設定してシンプルな WordArt スタイルを構築します。

各例は新しいプレゼンテーションを作成し、最初のスライドに矩形を追加します。入力ファイルは不要です。最初の例ではテキストを「Aspose.Slides」に設定します。シェイプの位置とサイズはポイントで測定されます。

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

フォントを Arial Black、サイズ 36pt に設定して書式を目立たせます。

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

前景色に濃いオレンジ、背景色に白の [SmallGrid](https://reference.aspose.com/slides/ja/cpp/aspose.slides/patternstyle/) パターンを適用し、幅 1 ポイントの黒いテキスト輪郭を追加します。

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

結果のテキスト:

![シンプルな WordArt テンプレート](WordArt_template.png)

## **その他の WordArt エフェクトを適用する**

以下の例では、影、反射、光彩、変形、3D エフェクトをテキストに適用する方法を示します。

### **外側の影エフェクトを適用する**

外側の影はテキストの背後に影を配置して奥行きを付加します。色、方向、距離、ぼかし半径、スケール、傾斜をカスタマイズできます。

この例は [EnableOuterShadowEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) を呼び出し、黒色の影をぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントで設定します。スケール 100 は影のサイズを維持し、水平傾斜で 20 度傾けます。アルファ変換で不透明度を 32% に設定します。

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

結果のテキスト:

![外側の影エフェクト](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側の影とプリセットの影を同時に使用すると、外側の影のみが適用されます。
- 外側の影と内側の影を同時に使用した場合、効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が倍になり、PowerPoint 2007 では外側の影のみが適用されます。
{{% /alert %}}

### **反射エフェクトを適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、不透明度を調整して外観を制御できます。

この例は [EnableReflectionEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) を呼び出し、スケール -100% で垂直に反転させます。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用し、不透明度は位置 0% から 60% の間で 60% から 0.9% に減少します。

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

結果のテキスト:

![反射エフェクト](reflection_effect.png)

### **光彩エフェクトを適用する**

光彩はテキストの周囲に柔らかい色付き輪郭を追加します。色、不透明度、半径を調整して効果を制御できます。

この例は [EnableGlowEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ieffectformat/enablegloweffect/) を呼び出し、54% の不透明度と半径 7 ポイントの赤い光彩を適用します。

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

結果のテキスト:

![光彩エフェクト](glow_effect.png)

### **WordArt 変形を適用する**

WordArt の変形により、テキストブロックを曲げ、伸ばす、または歪めることができます。

[ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_transform/) を [ArchUpPour](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textshapetype/) に設定して、テキストフレーム全体を上向きに曲げます。

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

結果のテキスト:

![WordArt 変形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ は、事前定義された [変形タイプ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textshapetype/) のセットを提供します。
{{% /alert %}}

### **シェイプとテキストに 3D エフェクトを適用する**

シェイプまたはテキストに 3D エフェクトを適用できます。ベベル、押し出し、照明、カメラ設定が外観を制御します。

以下の例は [IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) を使用して、矩形に円形ベベル、オレンジ色の押し出し、濃い赤の輪郭を追加します。ベベルサイズ、押し出し高さ、輪郭幅、深さはポイントで測定されます。プラスチック素材、Z 軸周りに 40 度回転したバランス照明、遠近カメラが外観を定義します。

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

結果のシェイプ:

![シェイプの 3D エフェクト](shape_3D_effect.png)

この例は [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/get_threedformat/) を通じて、テキストにも同様の 3D 書式設定を適用します。小さなベベルが文字のエッジを形成し、押し出しと照明がテキストに奥行きを与えます。

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

結果のテキスト:

![テキストの 3D エフェクト](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストまたはシェイプへの 3D エフェクト適用と、これらのエフェクト間の相互作用は特定の規則で管理されます。テキストとそれを含むシェイプの両方がシーンを持つ場合、シェイプのシーンが優先され、テキストのシーンは無視されます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先されます。
- シェイプにシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- シェイプに 3D エフェクトがまったくない場合、平面として扱われ、3D エフェクトはテキストにのみ適用されます。

これらの動作は [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_lightrig/) および [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_camera/) メソッドに関連しています。
{{% /alert %}}

テキストを平面に保ちつつシェイプの 3D 書式設定を維持する方法については、[Keep Text Flat on a 3D Shape](/slides/ja/cpp/3d-presentation/) を参照し、設定比較と完全な C++ サンプルをご確認ください。

## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中国語）でも WordArt エフェクトは使用できますか？**

はい、Aspose.Slides for C++ は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、輪郭などの WordArt エフェクトは言語に関係なく適用できますが、フォントの可用性と描画はシステムにインストールされているフォントに依存する場合があります。

**スライドマスタの要素にも WordArt エフェクトを適用できますか？**

はい、マスタースライド上のタイトルプレースホルダー、フッター、背景テキストなどのシェイプにも WordArt エフェクトを適用できます。マスターレイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

**WordArt エフェクトはプレゼンテーションファイルのサイズに影響しますか？**

若干影響します。影、光彩、グラデーション塗りつぶしなどのエフェクトは、追加の書式設定メタデータによりファイルサイズをわずかに増加させますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？**

はい、[ISlide::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/getimage/) を使用して WordArt を含むスライドを画像 (PNG、JPEG など) にレンダリングしたり、[IShape::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getimage/) で個々のシェイプを画像化したりできます。これにより、保存やエクスポート前にメモリ上または画面上で結果をプレビューできます。