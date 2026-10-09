---
title: C++ を使用したプレゼンテーションでの図形効果の適用
linktitle: 図形効果
type: docs
weight: 30
url: /ja/cpp/shape-effect/
keywords:
- 図形効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して高度な図形効果で PPT および PPTX ファイルを変換し、数秒で際立ったプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/cpp/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形の光彩を広げたりすることができます。

![形状効果](shape-effect.png)

PowerPoint には図形に適用できる 6 種類の効果が用意されています。図形に 1 つまたは複数の効果を適用できます。

効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint では **Preset** のオプションが用意されています。Preset オプションは、見栄えが良いとされる 2 つ以上の効果の組み合わせです。これにより、プリセットを選択するだけで、さまざまな効果を試したり組み合わせたりして最適な組み合わせを探す手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影効果の適用**

Aspose.Slides for C++ は、図形に対して外側と内側の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影の適用**

外側の影を使用すると、カードやパネルをスライドの背景に対して際立たせることができます。影は図形のエッジの外側に広がり、図形がスライド上で浮き上がっているように見えます。テンプレートの照明やスタイルに合わせて、影の色、方向、距離、およびぼかし半径を調整してください。

この C++ コードは、矩形に[外側の影効果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/)を適用する方法を示しています:

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

![影効果](shadow_effect.png)

### **内側の影の適用**

テンプレートのビジュアルスタイルを再現する際には、カードやパネルに凹んだ外観を与えるために内側の影を使用します。外側の影は図形の外側に広がり、浮き上がって見えるのに対し、内側の影はエッジの内側を陰影付けします。

まず[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) を呼び出し、次に[InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) を設定します。ぼかし半径の値が大きいほど、エッジは柔らかくなります。

この C++ の例は、薄い青色のカードに濃い灰色の内側の影を付け、PPTX ファイルとして保存します:

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

![内側の影がある薄い青色の矩形](inner_shadow_effect.png)

内側の影を削除するには、図形の EffectFormat で[DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) を呼び出します。

## **反射効果の適用**

Aspose.Slides for C++ で反射効果を適用するには、形状に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は、形状に洗練された外観を与えることでプレゼンテーションの美感を向上させます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この C++ コードは、形状に[反射効果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/)を適用する方法を示しています:

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

![反射効果](reflection_effect.png)

## **光彩効果の適用**

Aspose.Slides for C++ で形状に光彩効果を適用するには、形状の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。この効果は形状を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見た目を向上させます。

この C++ コードは、形状に[光彩効果](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/)を適用する方法を示しています:

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

![光彩効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for C++ でソフトエッジ効果を適用するには、形状のエッジ周辺に滑らかでぼかされたトランジションを作成します。この効果は、より繊細で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に希望の効果を適用できます。

この C++ コードは、形状に[ソフトエッジ](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/)を適用する方法を示しています:

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

![ソフトエッジ効果](soft_edges_effect.png)

## **よくある質問**

**同じ形状に複数の効果を適用できますか？**

はい、影、反射、光彩など、さまざまな効果を単一の形状に組み合わせて、より動的な外観を作り出すことができます。

**どのような形状に効果を適用できますか？**

自動図形、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな形状に効果を適用できます。

**グループ化された形状に効果を適用できますか？**

はい、グループ化された形状にも効果を適用できます。効果はグループ全体に適用されます。