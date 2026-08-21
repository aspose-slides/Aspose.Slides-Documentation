---
title: PHPでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/php-java/shape-formatting/
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
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルの塗りつぶし、線、効果スタイルを正確かつ完全に制御できます。"
---
## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭線を変更したり効果を適用したりして書式設定できます。また、図形の内部の塗りつぶし方法を指定して書式設定することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットするクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタム線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linestyle/) を設定します。
1. 線幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、矩形の `AutoShape` の書式設定方法を示しています。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 矩形シェイプの塗りつぶしカラーを設定します。
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

![The formatted lines in the presentation](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果は、図形の線を手描き風に見せます。`[Shape.getLineFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/)` で線設定にアクセスし、`[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/lineformat/)` でスケッチ設定にアクセスし、`[SketchFormat.setSketchType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sketchformat/)` で `[LineSketchType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linesketchtype/)` 列挙体から値を選択します。

次の PHP コードは、`[LineSketchType.Curved](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linesketchtype/)` 効果を適用し、明示的に割り当てられた値を取得し、`[LineSketchType.None](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linesketchtype/)` で効果を削除する方法を示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // 図形の線フォーマットとそのスケッチフォーマットにアクセスします。
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // スケッチ効果を適用します。
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // 図形に直接割り当てられたスケッチ効果を読み取ります。
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // スケッチ効果を削除します。
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

`[SketchFormat.getSketchType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sketchformat/)` が返す値は、図形に直接設定されたものを表します。線の書式設定がテーマ、マスタースライド、レイアウトスライドから継承される可能性がある場合は、`[LineFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/lineformat/)` を使用し、返されたオブジェクトの `getSketchFormat` メソッドにアクセスして `getSketchType` の値を読み取ります。Effective 値は、継承が解決された後に実際に適用される書式設定を反映します。

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

結合タイプには次の 3 つのオプションがあります。

* Round
* Miter
* Bevel

既定では、PowerPoint は２本の線を角度で結合するとき（図形のコーナーなど）に **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションが好ましいことがあります。

![The join style in the presentation](join-style-powerpoint.png)

次の PHP コードは、上記画像のように Miter、Bevel、Round の結合スタイル設定で 3 つの矩形を作成した方法を示しています。

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

    // 各矩形シェイプの塗りつぶしカラーを設定します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を段階的に徐々に変化させて適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. `[GradientFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/gradientformat/)` クラスが公開するグラデーションストップコレクションの `add` メソッドを使用して、位置を指定した 2 つの好きな色を追加します。
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

    // 2つのグラデーションストップを追加します。
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![The ellipse with gradient fill](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムカラーで指定できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために、45 種類以上の事前定義パターンスタイルを図形に適用できる機能を提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/php-java/aspose.slides/patternformat/#getBackColor) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/php-java/aspose.slides/patternformat/#getForeColor) を設定します。
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

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または別の好みのモード）に設定します。
1. 使用したい画像から `[PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/)` オブジェクトを作成します。
1. 画像を `SlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![The lotus picture](lotus.png)

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

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイル処理の挙動をカスタマイズしたい場合は、`[PictureFillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/)` クラスの次のメソッドを使用できます。

- `[setPictureFillMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setPictureFillMode)`: `Tile` または `Stretch` のいずれかで画像塗りつぶしモードを設定します。
- `[setTileAlignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileAlignment)`: 図形内のタイルの配置を指定します。
- `[setTileFlip](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileFlip)`: タイルを水平、垂直、または両方に反転させるかを制御します。
- `[setTileOffsetX](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileOffsetX)`: 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- `[setTileOffsetY](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileOffsetY)`: 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- `[setTileScaleX](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileScaleX)`: タイルの水平スケールをパーセンテージで定義します。
- `[setTileScaleY](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/#setTileScaleY)`: タイルの垂直スケールをパーセンテージで定義します。

次のコードサンプルは、タイル画像塗りつぶし付きの矩形図形を追加し、タイルオプションを構成する方法を示しています。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 矩形のオートシェイプを追加します。
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

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどを使用せず、単純な背景色が適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の PHP コードは、PowerPoint スライド内の矩形に単色塗りつぶしを適用する方法を示しています。

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

    // 塗りつぶしカラーを設定します。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX ファイルをディスクに保存します。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![The shape with solid color fill](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りの不透明度を制御できます。透明度の値が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に見えるようになります。

Aspose.Slides では、塗りに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を持つ色を定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

次の PHP コードは、矩形に透明塗りつぶし色を適用する方法を示しています。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    $slide = $presentation->getSlides()->get_Item(0);

    // ソリッド矩形のオートシェイプを追加します。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ソリッド形状の上に透明な矩形オートシェイプを追加します。
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

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素の位置を調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
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

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/)` プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. `[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)` クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに `[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)` を追加します。
1. 図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/)` を構成してベベル設定を定義します。
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/)` プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. `[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)` クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに `[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)` を追加します。
1. `[setCameraType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/camera/#setCameraType)` と `[setLightType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/lightrig/#setLightType)` を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の PHP コードは、図形に 3D 回転効果を適用する方法を示しています。

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

![The 3D rotation effect](3D-rotation-effect.png)

## **図形の白黒表示制御**

`[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#setBlackWhiteMode)` メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに、個々の図形がどのように描画されるかを指定します。このメソッドだけで白黒表示が有効になるわけではなく、通常のカラー表示時の図形の塗り、線、その他の書式設定は変更されません。

`[BlackWhiteMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/blackwhitemode/)` クラスの値を使用して目的の動作を選択します。例として、`Automatic` はレンダリングアプリケーションに変換を任せ、`Gray` と `LightGray` はグレーで表示、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持、`Hidden` は白黒モードで図形を非表示にします。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

次の PHP コードは、色付き図形を作成し、白黒表示モードで灰色に見えるように設定する例です。

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

    // カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形を灰色で描画します。
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

通常のカラー表示では、矩形はオレンジの塗りつぶしを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他白黒表示設定を尊重するワークフローで別の外観を定義できます。

## **書式設定のリセット**

次の Java コードは、`[LayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/)` 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトにリセットする方法を示しています。

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // レイアウト上のプレースホルダーがあるスライド上の各シェイプをリセットします。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーションファイルのサイズに影響しますか？**

影響は最小限です。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同一の書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。目的のスタイルを持つサンプル図形をテンプレートスライドデッキまたは .POTX テンプレートファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。