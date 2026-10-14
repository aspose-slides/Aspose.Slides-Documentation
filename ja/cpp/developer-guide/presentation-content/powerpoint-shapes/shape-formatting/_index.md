---
title: "C++ で PowerPoint の図形を書式設定"
linktitle: "図形の書式設定"
type: docs
weight: 20
url: /ja/cpp/shape-formatting/
keywords:
- "図形の書式設定"
- "線の書式設定"
- "スケッチ効果"
- "図形線のスケッチ"
- "結合スタイルの書式設定"
- "グラデーション塗りつぶし"
- "パターン塗りつぶし"
- "画像塗りつぶし"
- "テクスチャ塗りつぶし"
- "単色塗りつぶし"
- "形状の透明度"
- "白黒形状レンダリング"
- "グレースケール形状レンダリング"
- "形状の回転"
- "3D ベベル効果"
- "3D 回転効果"
- "書式設定のリセット"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides を使用して C++ で PowerPoint の図形を書式設定する方法を学びましょう—PPT、PPTX、ODP ファイルに対して、塗り、線、エフェクトのスタイルを正確かつ完全に制御できます。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形はラインで構成されているため、アウトラインを変更したりエフェクトを適用したりして書式設定できます。また、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットすることもできます。

![PowerPoint の図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for C++ は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットできるインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下のコードは、矩形の `AutoShape` をフォーマットする方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 矩形シェイプの塗りつぶし色を設定します。
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 矩形の線に書式設定を適用します。
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 矩形の線の色を設定します。
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX ファイルをディスクに保存します。
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果は、図形の線を手描きのように見せます。[IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) を使用して線の設定にアクセスし、[ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) でスケッチ設定にアクセスし、[ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) を使用して [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) 列挙体から値を選択します。

以下の C++ コードは、[LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) で効果を削除する方法を示します：

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、またはレイアウトスライドから線の書式設定が継承される場合は、[ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) を使用し、[ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) にアクセスし、[ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) を読み取ります。効果的な値は、継承が解決された後に実際に適用される書式設定を反映します：

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **結合スタイルの書式設定**

結合タイプのオプションは3つあります。

* ラウンド
* ミーテル
* ベベル

デフォルトでは、PowerPoint が角度で 2 本の線を結合するとき（たとえば図形のコーナー）**ラウンド**設定が使用されます。ただし、鋭角な形状を描く場合は**ミーテル**オプションを好むかもしれません。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

以下の C++ コードは、上の画像に示された 3 つの矩形がミーテル、ベベル、ラウンドの結合タイプ設定を使用して作成された方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを 3 つ追加します。
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// 各矩形シェイプの塗りつぶし色を設定します。
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 線の幅を設定します。
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 各矩形の線の色を設定します。
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 結合スタイルを設定します。
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 各矩形にテキストを追加します。
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX ファイルをディスクに保存します。
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **グラデーション塗りつぶし**

PowerPoint では、グラデーション塗りつぶしは図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々に別の色へフェードさせるように適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する方法は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) インターフェイスが公開するグラデーションストップコレクションの `Add` メソッドを使用して、位置を指定した 2 つの好みの色を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Ellipse タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 楕円にグラデーション書式を適用します。
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// グラデーションの方向を設定します。
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 2 つのグラデーションストップを追加します。
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートされた画像でグラデーションの見え方が PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されているグラデーション塗りつぶしを変更せずに、レンダリングスタイルを選択できます。

## **パターン塗りつぶし**

PowerPoint では、パターン塗りつぶしは 2 色のデザイン（点、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 以上の事前定義されたパターンスタイルを提供します。事前定義されたパターンを選択した後でも、使用する正確な色を指定できます。

以下の手順で Aspose.Slides を使用して図形にパターン塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義されたオプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、矩形にパターン塗りつぶしを適用する方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 塗りつぶしタイプを Pattern に設定します。
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// パターンスタイルを設定します。
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// パターンの背景色と前景色を設定します。
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX ファイルをディスクに保存します。
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint では、画像塗りつぶしは画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する方法は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または別の好みのモード）に設定します。
1. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.set_Image` メソッドに渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下は「lotus.png」ファイルを使用した例です。

![蓮の画像](lotus.png)

以下の C++ コードは、画像で図形を塗りつぶす方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 塗りつぶしタイプを Picture に設定します。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 画像塗りつぶしモードを設定します。
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 画像をロードし、プレゼンテーションのリソースに追加します。
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// 画像を設定します。
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![画像塗りつぶしの形状](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイル処理の動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): 図形内のタイルの配置を指定します。
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): タイルを水平、垂直、または両方に反転させるかを制御します。
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): 図形の原点からタイルの水平オフセット（ポイント単位）を設定します。
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): 図形の原点からタイルの垂直オフセット（ポイント単位）を設定します。
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): タイルの水平スケールをパーセンテージで定義します。
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): タイルの垂直スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの矩形形状を追加し、タイルオプションを構成する方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto firstSlide = presentation->get_Slide(0);

// 矩形のオートシェイプを追加します。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 図形の塗りつぶしタイプを Picture に設定します。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 画像をロードし、プレゼンテーションのリソースに追加します。
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 画像を図形に割り当てます。
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 画像塗りつぶしモードとタイル設定を構成します。
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint では、単色塗りつぶしは図形を単一の均一な色で塗りつぶす書式設定オプションです。この単色の背景色は、グラデーション、テクスチャ、パターンなどを使用せずに適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 塗りつぶしタイプを Solid に設定します。
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 塗りつぶし色を設定します。
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX ファイルをディスクに保存します。
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![単色塗りつぶしの形状](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど、図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を持つ色を定義します（`alpha` 成分が透明度を制御します）。
1. プレゼンテーションを保存します。

以下の C++ コードは、矩形に透明な塗りつぶし色を適用する方法を示します：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// 実体矩形のオートシェイプを追加します。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 実体形状の上に透明な矩形オートシェイプを追加します。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX ファイルをディスクに保存します。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![透明な形状](shape-transparency.png)

## **図形の回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転させることができます。これは、特定の配置やデザイン要件がある視覚要素の位置決めに便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティを目的の角度に設定します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形を 5 度回転させる方法を示します：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 図形を 5 度回転させます。
shape->set_Rotation(5);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形に 3D ベベル効果を適用する方法を示します：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// スライドにシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// シェイプの ThreeDFormat プロパティを設定します。
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// プレゼンテーションを PPTX ファイルとして保存します。
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転効果を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) と [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形に 3D 回転効果を適用する方法を示します：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// プレゼンテーションを PPTX ファイルとして保存します。
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) メソッドは、プレゼンテーションが白黒モードで表示または処理される場合に、個々の図形がどのようにレンダリングされるかを指定します。このメソッド自体で白黒表示を有効にするわけではなく、通常のカラー表示モードでの図形の塗り、線、その他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` は灰色で表示し、`BlackWhite` は黒と白のみ、`Black` と `White` は単色を強制、`Color` は通常のカラーを保持、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

以下の C++ コードは、カラー図形を作成し、白黒表示モードで灰色に見えるように設定します：

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは形状をグレーで表示します。
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

通常のカラー モードでは、矩形はオレンジ色の塗りつぶしが保持されます。白黒表示のワークフローでは、モードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷、プレビュー、またはプレゼンテーションの白黒表示設定を尊重するその他のワークフローで別個の外観を定義できます。

## **書式設定のリセット**

以下の C++ コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示します：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // レイアウト上にプレースホルダーがあるスライド上の各シェイプをリセットします。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **よくある質問**

**図形の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

影響は最小限です。埋め込み画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同一の書式設定を共有しているスライド上の図形を検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一であるとみなし、論理的にそれらの図形をグループ化します。これにより、後続のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル済み図形をクローンして、必要な場所で書式設定を再適用します。