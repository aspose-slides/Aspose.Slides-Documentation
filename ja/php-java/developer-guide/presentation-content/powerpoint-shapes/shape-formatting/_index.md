---
title: PHPでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/php-java/shape-formatting/
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
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対し、塗りつぶし、線、効果スタイルを正確かつ完全にコントロールして設定できます。"
---

## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、アウトラインに対して効果を変更または適用して書式設定できます。さらに、内部の塗りつぶし方法を指定して図形を書式設定することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットするクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [線スタイル](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [破線スタイル](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、矩形の `AutoShape` の線を書式設定する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 矩形シェイプの塗りつぶし色を設定します。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 矩形の線に書式設定を適用します。
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // 矩形の線の色を設定します。
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round（丸め）
* Miter（斜め切り）
* Bevel（ベベル）

既定では、PowerPoint は図形の角などで 2 本の線を結合するときに **Round** 設定を使用します。ただし、鋭い角を持つ図形を描く場合は **Miter** オプションを選択した方が適しています。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の PHP コードは、上の画像に示された 3 つの矩形が Miter、Bevel、Round 結合タイプ設定で作成されたことを示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを 3 つ追加します。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶし色を設定します。
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // 線幅を設定します。
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // 各矩形の線の色を設定します。
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 結合スタイルを設定します。
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // 各矩形にテキストを追加します。
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // PPTX ファイルをディスクに保存します。
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 色以上を徐々に変化させながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) クラスが提供する gradient stop コレクションの `add` メソッドを使用し、位置を指定した 2 つの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式設定を適用します。
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // グラデーションの方向を設定します。
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // 2 つのグラデーション ストップを追加します。
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![グラデーション塗りつぶしが適用された楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点・ストライプ・クロスハッチ・チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで指定できます。

Aspose.Slides は、プレゼンテーションの視覚効果を高めるために 45 種類以上の事前定義パターンスタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

パターン塗りつぶしを図形に適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、矩形にパターン塗りつぶしを適用する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Pattern に設定します。
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // パターンスタイルを設定します。
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // パターンの背景色と前景色を設定します。
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![パターン塗りつぶしが適用された矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して画像塗りつぶしを図形に適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像の塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用したい画像から [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `SlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![ロータス画像](lotus.png)

次の PHP コードは、画像で図形を塗りつぶす方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 塗りつぶしタイプを Picture に設定します。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 画像の塗りつぶしモードを設定します。
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // 画像を設定します。
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![画像塗りつぶしが適用された図形](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：`Tile` または `Stretch` のいずれかで画像塗りつぶしモードを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment)：図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip)：タイルを水平方向、垂直方向、または両方で反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：図形の基準点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：図形の基準点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX)：タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY)：タイルの垂直スケールをパーセンテージで定義します。

次のサンプルは、タイル画像塗りつぶしを持つ矩形を追加し、タイルオプションを構成する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 四角形のオートシェイプを追加します。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // 図形の塗りつぶしタイプを Picture に設定します。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 画像を図形に割り当てます。
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // 画像塗りつぶしモードとタイル設定を構成します。
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用されません。

Aspose.Slides で単色塗りつぶしを図形に適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // 塗りつぶし色を設定します。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![単色塗りつぶしが適用された図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャの塗りつぶしを適用する際に、透明度レベルを設定して塗りの不透明度を調整できます。透明度が高いほど、背景や下にあるオブジェクトが透けて見えるようになります。

Aspose.Slides では、塗りに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度（アルファ成分で制御）を持つ色を定義します。
1. プレゼンテーションを保存します。

次の PHP コードは、矩形に透明な塗りつぶし色を適用する方法を示しています。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // ソリッドな矩形オートシェイプを追加します。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // PPTX ファイルをディスクに保存します。
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![透明な図形のプレビュー](shape-transparency.png)

## **図形の回転**

Aspose.Slides では、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素の向きを調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の PHP コードは、図形を 5 度回転させる例です。
```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 図形を 5 度回転させます。
    $shape->setRotation(5);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![図形の回転プレビュー](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) を設定してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の PHP コードは、図形に 3D ベベル効果を適用する方法を示しています。
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // スライドに図形を追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // 図形の ThreeDFormat プロパティを設定します。
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // プレゼンテーションを PPTX ファイルとして保存します。
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![3D ベベル効果のプレビュー](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) と [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の PHP コードは、図形に 3D 回転効果を適用する例です。
```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // プレゼンテーションを PPTX ファイルとして保存します。
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![3D 回転効果のプレビュー](3D-rotation-effect.png)

## **書式設定のリセット**

次の Java コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。
```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // レイアウト上にプレースホルダーがあるスライド上のすべてのシェイプをリセットします。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

ほとんど影響はありません。埋め込み画像やメディアがファイル容量の大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を持つ図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一と見なして論理的にグループ化できます。これにより、後々のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイル付き図形をクローンして、必要な場所で書式設定を再適用します。