---
title: C++ を使用したプレゼンテーションでの形状エフェクトの適用
linktitle: 形状エフェクト
type: docs
weight: 30
url: /ja/cpp/shape-effect/
keywords:
- 形状エフェクト
- 影エフェクト
- 反射エフェクト
- グローエフェクト
- ソフトエッジエフェクト
- エフェクト形式
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して高度な形状エフェクトで PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint のエフェクトは形状を際立たせるために使用できますが、[塗りつぶし](/slides/ja/cpp/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint のエフェクトを使用すると、形状に実感のある反射を作成したり、形状のグローを広げたりできます。

![形状エフェクト](shape-effect.png)

PowerPoint には形状に適用できる 6 つのエフェクトが用意されています。形状に 1 つまたは複数のエフェクトを適用できます。

エフェクトの組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint では **プリセット** のオプションが用意されています。プリセットオプションは、組み合わせると見栄えが良いと知られている 2 つ以上のエフェクトの組み合わせです。このように、プリセットを選択すれば、さまざまなエフェクトを試したり組み合わせたりして最適な組み合わせを見つける手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーション内の形状に同じエフェクトを適用できるようにする、[EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影エフェクトの適用**

Aspose.Slides for C++ は形状の外側および内側のシャドウをサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側シャドウの適用**

外側シャドウを使用して、カードやパネルをスライド背景から際立たせます。シャドウは形状のエッジの外側まで広がり、形状がスライド上に浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この C++ コードは、矩形に[外側シャドウ エフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) を適用する方法を示しています:
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

![シャドウ エフェクト](shadow_effect.png)

#### **形状が回転したときのシャドウ方向の制御**

デフォルトでは、外側シャドウは形状と共に回転します。回転が異なる形状でも同じ方向から光が当たっているように見せるには、`false` を指定して [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) を呼び出し、[set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) でシャドウに同じ角度を設定します。

この例では、右方向にオフセットされた (0°) グレーのシャドウを持つ 2 本の矢印を作成します。その後、スライドを複製し、両方の矢印を時計回りに 90° 回転させます。
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

2 枚目のスライドでは、左矢印のシャドウは下向きに投影され、右矢印のシャドウは依然として右向きです。両方のシャドウの設定された方向は 0° のままです。

![90° 回転前後の PowerPoint レンダリング。両方のシャドウは右側から開始し、回転後、左矢印の下にシャドウが移動し、右矢印の右側に残ります。](arrow-shadow-rotation.png)

### **内側シャドウの適用**

テンプレートのビジュアルスタイルを再現する際は、内側シャドウを使用してカードやパネルに凹んだ外観を付けます。外側シャドウは形状の外側に広がり浮き上がって見せますが、内側シャドウはエッジの内部を陰影付けします。

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) を設定します。ぼかし半径の値を大きくすると、エッジが柔らかくなります。

この C++ の例は、淡い青色のカードに濃い灰色の内側シャドウを付け、PPTX ファイルとして保存します:
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

![内側シャドウ付きの淡い青色の矩形](inner_shadow_effect.png)

内側シャドウを削除するには、形状の EffectFormat で [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

### **プリセットシャドウの適用、変更、削除**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) を呼び出し、[set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) で [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) を選択します。同じ形状でスタイルを切り替えるには、プリセットを変更します。[DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) を呼び出すと、塗りつぶしと輪郭は保持したままシャドウを削除できます。

この例では、各段階で矩形のコピーを保持します。両方のシャドウは 10 ポイントオフセットされています。方向が 225° の場合、最初のシャドウは矩形の左上に配置され、45° の場合、2 番目のシャドウは右下に配置されます。
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

| 元の状態 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射エフェクトの適用**

Aspose.Slides for C++ で反射エフェクトを適用するには、形状に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは、形状に洗練された外観を与え、プレゼンテーションの美しさを向上させます。簡単なコードで実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この C++ コードは、形状に[反射エフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) を適用する方法を示しています:
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

![反射エフェクト](reflection_effect.png)

## **グローエフェクトの適用**

Aspose.Slides for C++ で形状にグローエフェクトを適用するには、形状の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。このエフェクトは形状を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで実装でき、スライド全体の外観を向上させます。

この C++ コードは、形状に[グローエフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) を適用する方法を示しています:
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

![グローエフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for C++ でソフトエッジエフェクトを適用すると、形状のエッジ周囲に滑らかでぼかされた移行を作成できます。このエフェクトは、より控えめで洗練された外観を付加し、柔らかな印象が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に目的の効果を実現できます。

この C++ コードは、形状に[ソフトエッジ](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) を適用する方法を示しています:
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

![ソフトエッジエフェクト](soft_edges_effect.png)

## **ぼかしエフェクトの適用**

形状ぼかしを使用すると、形状の塗りつぶしと輪郭を柔らかくしながら、形状自体は編集可能なままにできます。形状の EffectFormat で [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) を呼び出します。半径はポイント (1/72 インチ) で測定され、非負の値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変更されません。

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) 設定はエフェクトの可視範囲を制御します。`false` の場合、ぼかしは元の描画範囲（輪郭を含む）にクリップされます。`true` の場合、ぼかしはその範囲を超えて広がることができます。どちらの設定も形状の位置やサイズは変更しません。

以下の比較では、全体を通して同じ塗りつぶし、輪郭、形状サイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 ポイントと 15 ポイント、grow 無効・有効の状態で比較した元の矩形](shape_blur_comparison.png)

この C++ の例は、オレンジの矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、その後 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、次に [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) を呼び出してぼかしなしの形状を保存します。
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

形状ぼかしは塗りつぶしと輪郭の両方に影響します。ソフトエッジエフェクトは形状のエッジをフェードさせ、シャドウぼかしはシャドウのみを柔らかくします。画像変換エフェクトは画像内容に対して作用しますが、この例では形状を画像に変換せず、直接形状の EffectFormat にぼかしを適用しています。

## **FAQ**

**同じ形状に複数のエフェクトを適用できますか？**

はい、影、反射、グローなどの異なるエフェクトを組み合わせて、単一の形状に適用し、より動的な外観を作成できます。

**どのような形状にエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな形状にエフェクトを適用できます。

**グループ化された形状にエフェクトを適用できますか？**

はい、グループ化された形状にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。