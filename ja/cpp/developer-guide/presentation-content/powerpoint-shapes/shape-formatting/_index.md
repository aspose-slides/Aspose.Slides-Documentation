---
title: C++ で PowerPoint の図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/cpp/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- 結合スタイルのフォーマット
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
description: "Aspose.Slides を使用して C++ で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果スタイルを正確に、完全にコントロールしながら設定できます。"
---

## **概要**

PowerPointでは、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したりエフェクトを適用したりして書式設定できます。また、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ は、PowerPointで利用できるのと同じオプションを使用して図形の書式設定を行えるインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [線のスタイル](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [破線スタイル](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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


結果：

![The formatted lines in the presentation](formatted-lines.png)

## **結合スタイルの書式設定**

結合タイプのオプションは次の3つです：

* ラウンド
* ミタ
* ベベル

既定では、PowerPoint は図形の角などで2本の線を結合するときに **ラウンド** 設定を使用します。ただし、鋭角の形状を描く場合は **ミタ** オプションを選択した方がよいことがあります。

![The join style in the presentation](join-style-powerpoint.png)

以下の C++ コードは、上図のようにミタ、ベベル、ラウンドの結合タイプ設定を使用して 3 つの矩形を作成した例です。
```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを3つ追加します。
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

PowerPoint では、グラデーション塗りつぶしは連続した色の混合を図形に適用できる書式設定オプションです。たとえば、複数の色を徐々に変化させながら塗りつぶすことができます。

以下の手順で Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) インターフェイスが公開するグラデーションストップ コレクションの `Add` メソッドを使用して、位置を指定した 2 つ以上の好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Ellipse タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 楕円にグラデーションの書式設定を適用します。
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// グラデーションの方向を設定します。
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// グラデーション ストップを2つ追加します。
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX ファイルをディスクに保存します。
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


結果：

![The ellipse with gradient fill](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点・ストライプ・クロスハッチ・チェックなどの二色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色はカスタムで指定できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 種類以上の事前定義パターン スタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

以下の手順で Aspose.Slides を使用して図形にパターン塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義されたオプションからパターン スタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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


結果：

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

以下の手順で Aspose.Slides を使用して図形に画像塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用する画像から [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.set_Image` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下は「lotus.png」というファイルを使用した例です。

![The lotus picture](lotus.png)

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// Rectangle タイプのオートシェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 塗りつぶしタイプを Picture に設定します。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// ピクチャー塗りつぶしモードを設定します。
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


結果：

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) クラスの以下のメソッドを使用できます。

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): 画像塗りつぶしモードを設定します—`Tile` または `Stretch`。
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): 図形内でタイルの配置を指定します。
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): タイルを水平、垂直、またはその両方で反転させるかを制御します。
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): タイルの水平スケールをパーセンテージで定義します。
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): タイルの垂直スケールをパーセンテージで定義します。

以下のコード例は、矩形図形にタイル画像塗りつぶしを追加し、タイル オプションを構成する方法を示しています。
```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

// ピクチャー塗りつぶしモードとタイル設定を構成します。
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


結果：

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなどを使用せずに適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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


結果：

![The shape with solid color fill](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の数値が大きいほど、図形は背景や下にあるオブジェクトが透過的に見えるようになります。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を含む色を定義します（`alpha` 成分が透明度を制御します）。
1. プレゼンテーションを保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// 最初のスライドを取得します。
auto slide = presentation->get_Slide(0);

// 実体の矩形オートシェイプを追加します。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 実体の形状の上に透明な矩形オートシェイプを追加します。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX ファイルをディスクに保存します。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


結果：

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形の回転をサポートします。特定の配置やデザイン要件に合わせて視覚要素を回転させる際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

```cpp
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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


結果：

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

```cpp
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

// Set the shape's ThreeDFormat properties.
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


結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) を追加します。
1. [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) と [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) を使用して 3D 回転を定義します。
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


結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **書式設定のリセット**

以下の C++ コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定を既定に戻す方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // レイアウト上のプレースホルダーを持つスライド上の各形状をリセットします。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**形状の書式設定は最終的なプレゼンテーションのファイル サイズに影響しますか？**

ほとんど影響しません。埋め込み画像やメディアがファイル容量の大部分を占め、色やエフェクト、グラデーションなどの形状パラメータはメタデータとして保存され、実質的なサイズ増加はありません。

**同じ書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、エフェクト設定）を比較します。すべての該当値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより後続のスタイル管理が簡素化されます。

**カスタムの図形スタイルセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイル済み図形をクローンして、必要な場所に書式設定を再適用します。