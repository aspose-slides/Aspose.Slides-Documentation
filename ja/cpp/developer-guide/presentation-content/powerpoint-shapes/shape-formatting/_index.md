---
title: C++でPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/cpp/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形描画
- グレースケール図形描画
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式のリセット
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、およびエフェクトのスタイルを正確かつ完全に制御して設定できます。"
---
## **イントロダクション**

PowerPointでは、スライドに図形を追加できます。図形はラインで構成されているため、輪郭を変更したりエフェクトを適用したりして書式設定できます。また、内部の塗りつぶし方法を指定する設定で図形をフォーマットできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ は、PowerPointで利用できる同じオプションを使用して図形をフォーマットできるインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下のコードは、矩形の `AutoShape` の書式設定方法を示しています。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

![プレゼンテーションの書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果は、図形の線を手書き風に見せます。`IShape::get_LineFormat` で線設定にアクセスし、`ILineFormat::get_SketchFormat` でスケッチ設定にアクセスし、`ISketchFormat::set_SketchType` で [LineSketchType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) 列挙体から値を選択します。

以下の C++ コードは、[LineSketchType::Curved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てた値を取得し、[LineSketchType::None](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

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

`ISketchFormat::get_SketchType` が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、レイアウトスライドから継承できる場合は、`ILineFormat::GetEffective` を使用し、`ILineFormatEffectiveData::get_SketchFormat` にアクセスして、`ISketchFormatEffectiveData::get_SketchType` を取得します。継承が解決された後に実際に適用される書式が有効値として返されます。

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

結合タイプのオプションは次の 3 つです。

* ラウンド
* マイター
* ベベル

PowerPoint では、2 本の線を角度で結合するとき（図形の角など）、デフォルトで **ラウンド** が使用されます。ただし、鋭角の図形を描く場合は **マイター** を選択した方が適しています。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

以下の C++ コードは、上図のように Miter、Bevel、Round 結合タイプ設定で 3 つの矩形を作成した例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

// 線幅を設定します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を段階的にフェードさせて適用できます。

Aspose.Slides で図形にグラデーション塗りつぶしを適用する方法は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igradientformat/) インターフェイスが公開するグラデーションストップコレクションの `Add` メソッドを使用して、位置を指定した 2 つ以上の色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで指定できます。

Aspose.Slides には、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 以上の定義済みパターンスタイルが用意されています。定義済みパターンを選択した後でも、正確な使用色を指定できます。

パターン塗りつぶしを図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Pattern` に設定します。
1. 定義済みオプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipatternformat/get_backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipatternformat/get_forecolor/) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、矩形にパターン塗りつぶしを適用する例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// FillType を Pattern に設定します。
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

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して画像塗りつぶしを図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Picture` に設定します。
5. 画像塗りつぶしモードを `Tile`（または別の希望モード）に設定します。
6. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトを作成します。
7. 画像を `ISlidesPicture.set_Image` メソッドに渡します。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下は「lotus.png」という画像を使用した例です。

![The lotus picture](lotus.png)

以下の C++ コードは、画像で図形を塗りつぶす方法を示しています。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// FillType を Picture に設定します。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 画像塗りつぶしモードを設定します。
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 画像を読み込み、プレゼンテーションのリソースに追加します。
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

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定**

タイル画像をテクスチャとして設定し、タイル処理の動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [set_PictureFillMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): 画像の塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [set_TileAlignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): 図形内のタイルの配置を指定します。
- [set_TileFlip](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileflip/): タイルを水平、垂直、または両方に反転させるかを制御します。
- [set_TileOffsetX](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [set_TileOffsetY](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [set_TileScaleX](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): タイルの水平スケールをパーセンテージで定義します。
- [set_TileScaleY](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): タイルの垂直スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶしを持つ矩形を追加し、タイルオプションを構成する方法を示しています。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto firstSlide = presentation->get_Slide(0);

// 矩形のオートシェイプを追加します。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 図形の FillType を Picture に設定します。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 画像を読み込み、プレゼンテーションのリソースに追加します。
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

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用されません。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C++ コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// FillType を Solid に設定します。
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 塗りつぶしの色を設定します。
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX ファイルをディスクに保存します。
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャ塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形は透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を含む色を定義します（`alpha` 成分が透明度を制御）。
1. プレゼンテーションを保存します。

以下の C++ コードは、矩形に透明塗りつぶし色を適用する例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// 単色の矩形オートシェイプを追加します。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 単色シェイプの上に透明な矩形オートシェイプを追加します。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX ファイルをディスクに保存します。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides では、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を調整したい場合に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形を 5 度回転させる例です。

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

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

Aspose.Slides では、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/threedformat/) プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形に 3D ベベル効果を適用する例です。

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

// スライドに図形を追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// 図形の ThreeDFormat プロパティを設定します。
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

Aspose.Slides では、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/threedformat/) プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転効果を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. `set_CameraType` と `set_LightType` を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の C++ コードは、図形に 3D 回転効果を適用する例です。

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

## **図形の白黒表示の制御**

`IShape::set_BlackWhiteMode` メソッドは、プレゼンテーションが白黒モードで表示または処理される際に、個々の図形がどのように描画されるかを指定します。白黒表示自体を有効にするものではなく、通常のカラー表示モードでの図形の塗り、線、その他書式設定を変更しません。

[BlackWhiteMode] 列挙体の値を使用して目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` は灰色で表示し、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常の色を保持し、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルのモードが設定されていないことを意味します。

以下の C++ コードは、カラー図形を作成し、白黒表示モードで灰色に表示させる例です。

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

// カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形を灰色で描画します。
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

通常のカラー表示では矩形はオレンジの塗りつぶしが保持されますが、白黒表示のワークフローでは `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど白黒表示設定を尊重するワークフローで別の外観を定義できます。

## **書式のリセット**

以下の C++ コードは、スライドの書式をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式をデフォルト設定に戻す方法を示しています。

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
    // レイアウト上にプレースホルダーがあるスライドの各シェイプをリセットします。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

影響はごくわずかです。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色やエフェクト、グラデーションなどの図形パラメータはメタデータとして保存されるため、実質的なサイズ増加はほとんどありません。

**同一の書式設定を持つ図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、エフェクト設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより後のスタイル管理が容易になります。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。希望のスタイルが設定されたサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式を再適用します。