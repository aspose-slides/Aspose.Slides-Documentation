---
title: C++ で PowerPoint の図形をフォーマット
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/cpp/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ効果
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果のスタイルを正確かつ完全にコントロールできます。"
---
## **概要**

PowerPointでは、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したり効果を適用したりして書式設定できます。また、内部の塗りつぶし方法を指定する設定で図形をフォーマットできます。

![PowerPointでの図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for C++ は、PowerPointで利用できる同じオプションを使用して図形をフォーマットできるインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linestyle/) を設定します。
1. 線幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形 AutoShape の書式設定方法を示しています。

```cpp
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

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果は、図形の線を手描きのように見せます。[IShape::get_LineFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_lineformat/) を使用して線設定にアクセスし、[ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilineformat/get_sketchformat/) でスケッチ設定にアクセスし、[ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isketchformat/set_sketchtype/) を使用して [LineSketchType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の C++ コードは、[LineSketchType::Curved](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType::None](https://reference.aspose.com/slides/ja/cpp/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

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

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isketchformat/get_sketchtype/) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される場合は、[ILineFormat::GetEffective](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilineformat/geteffective/) を使用し、[ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) にアクセスし、[ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) を読み取ります。実効値は継承が解決された後に実際に適用される書式設定を示します：

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

結合タイプのオプションは次の3つです。

* Round
* Miter
* Bevel

既定では、PowerPoint は角度で2本の線（例えば図形の角）を結合する際に **Round** 設定を使用します。ただし、鋭い角度の図形を描く場合は **Miter** オプションを選択した方が良い場合があります。

![プレゼンテーションの結合スタイル](join-style-powerpoint.png)

次の C++ コードは、上の画像に示されている3つの矩形が Miter、Bevel、Round の結合タイプ設定を使用して作成された方法を示しています。

```cpp
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

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2色以上の色を徐々に別の色へフェードさせるように適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igradientformat/) インターフェイスが提供するグラデーション ストップ コレクションの `Add` メソッドを使用して、位置を定義した 2 つの好みの色を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Ellipse タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 楕円にグラデーション書式設定を適用します。
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// グラデーションの方向を設定します。
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 2 つのグラデーション ストップを追加します。
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、交差ハッチ、チェックなどの 2 色のデザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は 45 種類以上の事前定義されたパターン スタイルを提供し、図形に適用してプレゼンテーションの視覚的魅力を高めることができます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義されたオプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipatternformat/get_backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipatternformat/get_forecolor/) を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望のモード）に設定します。
1. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.set_Image` メソッドに渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

例えば、次の画像 "lotus.png" があるとします：

![蓮の画像](lotus.png)

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 塗りつぶしタイプを Picture に設定します。
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

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat] インターフェイスおよび [PictureFillFormat] クラスの次のメソッドを使用できます：

- [set_PictureFillMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)：画像塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [set_TileAlignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilealignment/)：図形内のタイルの配置を指定します。
- [set_TileFlip](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileflip/)：タイルを水平、垂直、または両方に反転させるかどうかを制御します。
- [set_TileOffsetX](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/)：タイルの水平方向オフセット（ポイント単位）を図形の原点から設定します。
- [set_TileOffsetY](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/)：タイルの垂直方向オフセット（ポイント単位）を図形の原点から設定します。
- [set_TileScaleX](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilescalex/)：タイルの水平方向スケールをパーセンテージで定義します。
- [set_TileScaleY](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipicturefillformat/set_tilescaley/)：タイルの垂直方向スケールをパーセンテージで定義します。

次のコードサンプルは、タイル画像塗りつぶしを持つ矩形形状を追加し、タイルオプションを構成する方法を示しています：

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto firstSlide = presentation->get_Slide(0);

// 矩形のオートシェイプを追加します。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 図形の塗りつぶしタイプを Picture に設定します。
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

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. 図形に希望の塗りつぶし色を割り当てます。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、またはテクスチャ塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど、図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用するカラーのアルファ値を調整することで透明度レベルを設定できます。手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を持つカラーを定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// ソリッド矩形のオートシェイプを追加します。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX ファイルをディスクに保存します。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせてビジュアル要素の位置決めを行う際に便利です。

スライド上の図形を回転させる手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティを目的の角度に設定します。
1. プレゼンテーションを保存します。

```cpp
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

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat] プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/threedformat/) を設定し、ベベル設定を定義します。
1. プレゼンテーションを保存します。

```cpp
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

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat] プロパティを構成して 3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
1. [set_CameraType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icamera/set_cameratype/) と [set_LightType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilightrig/set_lighttype/) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

```cpp
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

![3D 回転効果](3D-rotation-effect.png)

## **書式設定のリセット**

次の C++ コードは、スライドの書式設定をリセットし、[LayoutSlide] 上のプレースホルダーを持つすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // レイアウト上にプレースホルダーがあるスライド上の各シェイプをリセットします。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

ほとんど影響はありません。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの形状パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を共有しているスライド上の図形を検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなして論理的にグループ化できます。これにより、後のスタイル管理が簡素化されます。

**カスタム形状スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル付き図形をクローンして、必要な場所で書式設定を再適用します。