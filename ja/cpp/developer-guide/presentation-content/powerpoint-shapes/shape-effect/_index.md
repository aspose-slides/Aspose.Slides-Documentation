---
title: "C++ を使用したプレゼンテーションへの図形エフェクトの適用"
linktitle: "図形エフェクト"
type: docs
weight: 30
url: /ja/cpp/shape-effect/
keywords:
- "図形エフェクト"
- "影エフェクト"
- "反射エフェクト"
- "グローエフェクト"
- "ソフトエッジエフェクト"
- "エフェクト形式"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して高度な図形エフェクトで PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint のエフェクトは図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/cpp/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

![図形エフェクト](shape-effect.png)

PowerPoint は図形に適用できる 6 つのエフェクトを提供しています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせによっては、他よりも見栄えが良くなります。そのため、PowerPoint には **Preset** オプションがあります。Preset オプションは、組み合わせが良いとされる 2 つ以上のエフェクトの組み合わせです。これにより、プリセットを選択するだけで、さまざまなエフェクトをテストしたり組み合わせて最適な組み合わせを探す手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるように、[EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **シャドウ エフェクトを適用する**

Aspose.Slides for C++ は、図形に対して外側と内側のシャドウをサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側のシャドウを適用する**

外側のシャドウを使用すると、カードやパネルがスライドの背景に対して際立ちます。シャドウは図形のエッジの外側に広がり、図形がスライドの上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この C++ コードは、矩形に[外側のシャドウ エフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/)を適用する方法を示しています。

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

### **内側のシャドウを適用する**

テンプレートのビジュアルスタイルを再現する際は、カードやパネルに凹んだ外観を与えるために内側のシャドウを使用します。外側のシャドウは図形の外側に広がり、浮き上がって見えますが、内側のシャドウはエッジの内部を影付けします。

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) を構成します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この C++ のサンプルは、淡い青色のカードに濃い灰色の内側シャドウを付け、PPTX ファイルとして保存します。

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

![内側のシャドウ付きライトブルー矩形](inner_shadow_effect.png)

内側のシャドウを削除するには、図形の EffectFormat で [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

## **反射エフェクトを適用する**

Aspose.Slides for C++ で反射エフェクトを適用するには、図形に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは、図形に洗練された外観を与えることで、プレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用してデザインの一貫性を保つことができます。

この C++ コードは、図形に[反射エフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/)を適用する方法を示しています。

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

## **グロー エフェクトを適用する**

Aspose.Slides for C++ で図形にグロー エフェクトを適用するには、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。このエフェクトは図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この C++ コードは、図形に[グロー エフェクト](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/)を適用する方法を示しています。

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

![グロー エフェクト](glow_effect.png)

## **ソフトエッジ エフェクトを適用する**

Aspose.Slides for C++ でソフトエッジ エフェクトを適用するには、図形のエッジ周辺に滑らかでぼやけたトランジションを作成します。このエフェクトは、より繊細で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に望ましい効果を得ることができます。

この C++ コードは、図形に[ソフトエッジ](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/)を適用する方法を示しています。

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

![ソフトエッジ エフェクト](soft_edges_effect.png)

## **ぼかしエフェクトを適用する**

シェイプのぼかしを使用すると、図形を編集可能なまま、塗りつぶしと輪郭を柔らかくします。図形の EffectFormat で [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) を呼び出します。半径はポイント (1/72 インチ) で測定され、負の値は使用できず、値が大きいほどぼかしが強くなります。半径を 0 にすると外観は変わりません。

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) 設定はエフェクトの表示範囲を制御します。`false` の場合、ぼかしは元の描画範囲（輪郭を含む）にクリップされます。`true` の場合、ぼかしはその範囲を超えて拡張できます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較では、塗りつぶし、輪郭、図形のサイズはすべて同じです。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効・有効の比較（元の矩形）](shape_blur_comparison.png)

この C++ のサンプルは、オレンジ色の矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、再度 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) を呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) を呼び出してぼかしのない図形を保存します。

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

シェイプのぼかしは塗りつぶしと輪郭の両方に影響します。ソフトエッジ エフェクトは図形のエッジをフェードさせ、シャドウのぼかしはシャドウのみを柔らかくします。画像変換エフェクトは画像コンテンツに作用しますが、この例では図形を画像に変換せず、直接図形の EffectFormat にぼかしを適用しています。

## **FAQ**

**同じ図形に複数のエフェクトを適用できますか？**

はい、シャドウ、反射、グローなどの異なるエフェクトを単一の図形に組み合わせて、より動的な外観を作成できます。

**どの図形にエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。