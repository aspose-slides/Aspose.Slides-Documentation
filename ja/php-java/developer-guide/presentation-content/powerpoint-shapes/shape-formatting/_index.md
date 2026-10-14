---
title: PHPでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/php-java/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルの書式設定
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
- PHP
- Aspose.Slides
description: "Aspose.Slidesを使用してPHPでPowerPointの図形をフォーマットする方法を学びます。PPT、PPTX、ODPファイルに対して、塗りつぶし、線、エフェクトのスタイルを正確かつ完全に制御して設定できます。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したりエフェクトを適用したりして書式設定できます。さらに、内部の塗りつぶし方法を指定して図形を書式設定することもできます。

![PowerPoint のシェイプ書式設定](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java は、PowerPoint で利用できる同じオプションを使用して図形を書式設定できるクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、長方形の `AutoShape` の線を書式設定する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプの AutoShape を追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 長方形シェイプの塗りつぶしカラーを設定します。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 長方形の線に書式設定を適用します。
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // 長方形の線の色を設定します。
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

## **シェイプ線へのスケッチ効果の適用**

スケッチ効果は、シェイプの線を手描きのように見せます。`[Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)` で線の設定にアクセスし、`[LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)` でスケッチ設定にアクセスし、`[SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/)` で `[LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)` 列挙体から値を選択します。

次の PHP コードは、`[LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)` 効果を適用し、明示的に割り当てられた値を読み取り、`[LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)` で効果を削除する例です。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // シェイプのライン書式とそのスケッチ書式にアクセスします。
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // スケッチ効果を適用します。
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // シェイプに直接割り当てられたスケッチ効果を読み取ります。
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // スケッチ効果を削除します。
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

`[SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/)` が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、レイアウトスライドから線の書式設定が継承される場合は、`[LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)` を使用し、返されたオブジェクトの `getSketchFormat` メソッドにアクセスして `getSketchType` の値を読み取ります。Effective 値は、継承が解決された後に実際に適用される書式設定を反映します。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

PowerPoint では、図形のコーナーなどで 2 本の線が角度で結合されると、既定で **Round** 設定が使用されます。ただし、鋭い角度の図形を描く場合は **Miter** オプションが好まれることがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の PHP コードは、上記画像のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの長方形を作成した例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプの AutoShape を 3 つ追加します。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 各長方形シェイプの塗りつぶしカラーを設定します。
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

    // 各長方形の線の色を設定します。
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

    // 各長方形にテキストを追加します。
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. `[GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/)` クラスが公開するグラデーション ストップ コレクションの `add` メソッドを使用して、位置を指定した 2 つ以上の色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse タイプの AutoShape を追加します。
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

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで指定できます。

Aspose.Slides では、45 以上の事前定義パターン スタイルを図形に適用して、プレゼンテーションの視覚的魅力を高めることができます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

次の手順で Aspose.Slides を使用して図形にパターン塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターン スタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、長方形にパターン塗りつぶしを適用する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプの AutoShape を追加します。
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

![パターン塗りつぶしの長方形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、図形の内部に画像を挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像フィルモードを `Tile`（または他の希望モード）に設定します。
1. 使用したい画像から `[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)` オブジェクトを作成します。
1. 画像を `SlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像が「lotus.png」ファイルに含まれています。

![ロータス画像](lotus.png)

次の PHP コードは、図形を画像で塗りつぶす例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプの AutoShape を追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 塗りつぶしタイプを Picture に設定します。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 画像塗りつぶしモードを設定します。
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

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとして画像をタイル表示**

画像をテクスチャとしてタイル表示し、タイルの動作をカスタマイズしたい場合は、`[PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)` クラスの次のメソッドを使用できます。

- `[setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode)`: 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- `[setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment)`: 図形内のタイル配置を指定します。
- `[setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip)`: タイルを水平方向、垂直方向、または両方に反転させるかを制御します。
- `[setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX)`: 図形の基点からタイルの水平方向オフセット（ポイント）を設定します。
- `[setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY)`: 図形の基点からタイルの垂直方向オフセット（ポイント）を設定します。
- `[setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX)`: タイルの水平方向スケールをパーセンテージで定義します。
- `[setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY)`: タイルの垂直方向スケールをパーセンテージで定義します。

次のコード サンプルは、タイル表示の画像塗りつぶしを持つ長方形を追加し、タイルオプションを構成する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 矩形の AutoShape を追加します。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // シェイプの塗りつぶしタイプを Picture に設定します。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 画像をシェイプに割り当てます。
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // 画像塗りつぶしモードとタイル属性を設定します。
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

![タイルオプションの設定](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用せず、単色の背景色が適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、スライド上の長方形に単色塗りつぶしを適用する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプの AutoShape を追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // 塗りつぶしカラーを設定します。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、単色、グラデーション、画像、テクスチャのいずれかで塗りつぶした図形に対し、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を持つ色を定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

次の PHP コードは、長方形に透明塗りつぶし色を適用する例です。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // ソリッド長方形 AutoShape を追加します。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な長方形 AutoShape を追加します。
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

![透明な図形](shape-transparency.png)

## **シェイプの回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を回転させる際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
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

    // Rectangle タイプの AutoShape を追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // シェイプを 5 度回転させます。
    $shape->setRotation(5);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides を使用すると、図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) プロパティを構成して 3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の PHP コードは、図形に 3D ベベル効果を適用する例です。

```php
// Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // スライドにシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // シェイプの ThreeDFormat プロパティを設定します。
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

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides を使用すると、図形の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) プロパティを構成して 3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. `[setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType)` と `[setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType)` を使用して 3D 回転を定義します。
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

![3D 回転効果](3D-rotation-effect.png)

## **シェイプの白黒描画の制御**

`[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode)` メソッドは、プレゼンテーションが白黒モードで表示または処理される際に、個々のシェイプがどのように描画されるかを指定します。白黒表示自体を有効にするわけではなく、通常のカラー モードでのシェイプの塗り、線、その他の書式設定も変更しません。

`[BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/)` クラスの値から目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレーカラーを使用し、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色を強制、`Color` は通常のカラーを保持、`Hidden` は白黒モードでシェイプを省略します。`NotDefined` はシェイプレベルのモードが割り当てられていないことを意味します。

次の PHP コードは、カラーのシェイプを作成し、白黒表示モードでグレーに見えるように設定した例です。

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // カラー モードではオレンジの塗りつぶしを保持し、白黒モードではシェイプをグレーで描画します。
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

通常のカラー モードでは、長方形はオレンジの塗りつぶしのままです。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレー表示になります。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他黒白表示設定を尊重するワークフローで別の外観を定義できます。

## **書式のリセット**

次の Java コードは、[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべてのシェイプの位置、サイズ、書式をデフォルト設定にリセットする方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // レイアウトにプレースホルダーがあるスライド上の各シェイプをリセットします。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**シェイプの書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

ほとんど影響しません。埋め込み画像やメディアがファイル容量の大部分を占め、色やエフェクト、グラデーションなどのシェイプ パラメータはメタデータとして保存され、実質的なサイズ増加はほぼありません。

**同一の書式設定を持つスライド上のシェイプを検出してグループ化するにはどうすればよいですか？**

各シェイプの主要な書式プロパティ（塗りつぶし、線、エフェクト設定）を比較します。すべての対応する値が一致すれば、スタイルは同一とみなし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム シェイプ スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル シェイプをテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイル済みシェイプをクローンして、必要な場所で書式を再適用します。