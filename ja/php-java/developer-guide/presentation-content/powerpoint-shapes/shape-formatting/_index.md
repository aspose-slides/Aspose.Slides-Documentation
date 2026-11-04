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
- スケッチ図形線
- ジョインスタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint の図形をフォーマットする方法を学びます。PPT および PPTX ファイルの塗りつぶし、線、効果スタイルを正確かつ完全にコントロールできます。"
---
## **はじめに**

PowerPointで図形のアウトライン、塗りつぶし、効果を調整して書式設定します。Aspose.Slides for PHP via Java を使用すると、透明度、回転、3D 書式設定などをプログラムで制御できます。

![PowerPoint の図形書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットできるクラスとメソッドを提供します。

## **線の書式設定**

[Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) を使用して図形のアウトラインを制御します。この例は、塗りつぶしなしの長方形を青い破線アウトラインで作成します。[LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) は太さが異なる複合線を選択し、[LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) は幅を 7 ポイントに、[LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) は破線パターンを選択します。

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

### **カスタム破線パターンの設定**

事前定義の線スタイルで必要な破線の長さや間隔が得られない場合は、[LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) を使用します。たとえばブランドのアウトラインや技術図で使用します。パターンを割り当てると、線の破線スタイルは自動的に[LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)に変更されます。

配列のエントリは破線と間隔の長さを交互に並べ、破線から開始します。各値は線幅の倍数です。幅 3 ポイントで`[4, 2]`は 12 ポイントの破線と 6 ポイントの間隔を生成します。有限かつ非負の値のペアを使用して、完全な破線‑間隔セグメントを定義します。この例は、正の値のみを使用してすべての破線と間隔が表示されるようにしています。

この例は、同じ長さでフラットキャップの青い線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は最初のパターンを幅を 2 倍にして繰り返し、破線と間隔の長さも 2 倍にします。5 本目はカスタムパターンから実線に切り替えます。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // 最後の線を実線スタイルに戻す。
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

事前定義の破線スタイルに戻すには、[LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) に [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) を渡します。選択されたスタイルが線の外観を制御します。

PowerPoint での結果（上から下へ）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；および **Solid, 3 pt**。

![3 つのカスタム破線パターン、最初のパターンを使用した太い線、PowerPoint の実線](custom-dash-patterns.png)

### **線端（キャップ）の設定**

[LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) を使用して開いた線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) クラスは 3 つの明示的なキャップスタイルを提供します。

- `Flat`: ストロークは端点で停止します。
- `Round`: 半円形のキャップが端点を線幅の半分だけ超えて伸びます。
- `Square`: 四角形のキャップが端点を線幅の半分だけ超えて伸びます。

クラスには `NotDefined` も含まれ、これはキャップスタイルが明示的に割り当てられていないことを意味します。

キャップは、線端に記号を追加する矢印ヘッドや、線セグメント間の角を制御するジョインとは異なります。この例では、[LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) と [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) で矢印ヘッドを無効にし、キャップ形状のみを比較します。

以下の例は、幅 20 ポイントの水平線を 3 本作成します。上から順にフラット、ラウンド、スクエアキャップを使用します。端点は同じ水平座標ですが、ラウンドとスクエアキャップは各端点から 10 ポイント伸びます。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint での結果（上から下へ）：**Flat**、**Round**、**Square**。

![PowerPoint の同一太線に対するフラット、ラウンド、スクエアキャップ](line-caps.png)

## **図形線へのスケッチ効果の適用**

スケッチ効果は、図形の線を手書き風にします。[Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) で線設定にアクセスし、[LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) でスケッチ設定にアクセスし、[SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) で [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) クラスから値を選択します。

以下の PHP コードは、[LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) で効果を削除する方法を示します。

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、レイアウトスライドから継承される可能性がある場合は、[LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) を使用し、返されたオブジェクトの `getSketchFormat` メソッドにアクセスして `getSketchType` の値を読み取ります。実効値は、継承が解決された後に実際に適用される書式設定を反映します。この例は、最初のスライドに少なくとも 1 つの図形がある既存のプレゼンテーションを必要とし、両方の値を出力します。

```php
use aspose\slides\Presentation;

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

## **ジョインスタイルの書式設定**

ジョインタイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

ジョインスタイルは、2 つのアウトラインセグメントが角でどのように接続されるかを制御します。丸い角には **Round**、鋭い角には **Miter**、平坦な角には **Bevel** を使用します。

![プレゼンテーション内のジョインスタイル](join-style-powerpoint.png)

この例は、青いアウトライン（幅 15 ポイント）の黒い長方形を 3 つ作成します。[LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) をそれぞれ [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) のミーター、ベベル、ラウンド値に設定し、角の描画方法を比較します。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **鋭角でのミータージョインの制限**

[LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) を [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) に設定した状態で、[LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) を使用して鋭角がどれだけ伸びるかを制限します。

リミットは、ジョインの内側と外側の角間の距離を線幅で割った比率です。たとえば、値 `8` は線幅の最大 8 倍までミーター長さを許可します（ポイント単位ではありません）。角がリミットを超えると、PowerPoint はその角でベベルジョインを使用します。リミットを大きくすると、より鋭いポイントになります。この設定はミータージョインにのみ影響し、角が両方のリミット内に収まる場合は見た目に変化はありません。

この例は、幅 20 ポイントのアウトラインを持つ同一の塗りつぶしなし三角形を 2 つ作成します。左側の三角形はリミット `2`、右側は `8` を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角のミーター長さと線幅の比率は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベルし、右側の頂点は保持します。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint の結果：左側は **Miter limit 2**、右側は **miter limit 8**。

![PowerPoint のベベル頂点（ミーターリミット 2）と尖った頂点（ミーターリミット 8）](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしは、図形全体に色をブレンドします。この例は、[FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) を使用して、赤から紫への 45 度の線形グラデーションで楕円を塗りつぶします。[GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) メソッドは、グラデーションの開始（0）と終了（1）にカラー ストップを配置します。既存のストップをクリアすると、これら 2 色のみが使用されます。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートされた画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

### **線形グラデーション角度の設定**

[GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) を使用して、[GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度で測定され、時計回りに増加します：`0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数角度もサポートされます。[0, 360) の範囲外の有限角度は 1 回転に正規化されます。たとえば、`-45` は `315` に、`360` は `0` になります。

この例は、位置 `0`、`0.5`、`1` に同一の赤、緑、青ストップを持つ 6 つの長方形を作成します。スケーリングを無効にして、角度を長方形の比率に依存せずに比較できるようにします。左から右への角度は、1 行目が `0`、`45`、`90`、2 行目が `135`、`180`、`270` です。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint の結果:

![上段の 0、45、90 度、下段の 135、180、270 度の線形グラデーション](linear-gradient-angles.png)

### **図形とともに線形グラデーションをスケーリング**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) は [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 値を受け取ります。`False` に設定すると、図形のサイズが変わっても幾何学的なグラデーション角度を保持し、`True` に設定すると図形の幅と高さに合わせてグラデーションをスケーリングします。スケーリングが有効な場合、非正方形の図形では見た目の角度が割り当てた角度と異なることがあります。

以下の例は、`45` 度の角度と同じカラー ストップを使用します。左列は `False`、右列は `True` です。各列は、上に横長の長方形、下に縦長の長方形を配置します。両方とも同じ横幅で開始し、2 番目の長方形の幅と高さを変更して、塗りつぶしがリサイズにどのように応答するかを示します。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint の結果（左はスケーリングなし、右は有り）:

![45 度グラデーションの横長・縦長長方形、左は LinearGradientScaled False、右は True](linear-gradient-scaling.png)

スケーリングを無効にすると、対角のカラーバンドは両方の長方形で同じ向きを保ちます。スケーリングを有効にすると、バンドは図形の比率に合わせて伸びます。これにより、テンプレートのグラデーションを別のサイズの図形に適用する際に再現しやすくなります。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの外観は変わりません。

角度とスケーリングの設定は線形グラデーションにのみ適用され、[GradientShape::Radial または GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) の塗りつぶしは制御しません。

### **角度とグラデーション方向の組み合わせ**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) は [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) クラスからグラデーションスタイルを選択します。数値角度の代替ではありません。線形グラデーションの場合、コーナースタイルは[setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle)で設定された角度を変更せずに、色が分布する領域を変更できます。角度やスケーリングを比較するときは、方向は変更しないでください。

以下の例は、同じ設定を逆の順序で適用します。2 つの長方形は同じ外観になります：方向を先に設定しても、後に設定しても結果は変わりません。

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **パターン塗りつぶし**

パターン塗りつぶしは、ドット、ストライプ、チェックなどの 2 色デザインを適用します。この例は、[PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) を使用してトレリスパターンを選択します。[PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) で薄い灰色の背景を、[PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) で黄色のパターン色を設定します。

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![パターン塗りつぶしの長方形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしは、図形内に画像を使用します。この例はローカル画像を必要とし、[Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) を使用してプレゼンテーションの画像コレクションにロードします。[PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) をタイルモードに設定すると、画像が長方形内で繰り返されます。使用したソース画像は以下です。

![ロータスの画像](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとして画像をタイル表示**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): `Tile` または `Stretch` の画像塗りつぶしモードを設定します。
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平方向、垂直方向、または両方に反転するか制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): タイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): タイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を必要とし、元のサイズの 50% で繰り返すように [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) を構成します。`-32` ポイントのオフセットでタイルを水平・垂直にシフトし、右下揃えと両方向のフリップで繰り返しテクスチャの配置を決定します。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

単色塗りつぶしは、図形に単一の均一な色を付けます。この例は、[FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) を単色塗りつぶしモードに設定し、[FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) で黄色を割り当て、長方形をプレゼンテーションに保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **スライドの背景を図形の塗りつぶしとして使用**

スライドの背景と同じ塗りつぶしにする必要がある図形は、[AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) を使用します。たとえばプレゼンテーションテンプレートで使用します。まず [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) を [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) に設定して明示的な塗りつぶしを削除します。この組み合わせにより、図形はスライドの背景をスタイル塗りつぶしではなく背景として使用します。フラグを有効にするだけでは既存の明示的な塗りつぶしは削除されません。

これは [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) とは異なります。背景塗りつぶしは図形の背後にあるオブジェクトをスライド背景の対応領域で隠しますが、塗りつぶしなしはそれらのオブジェクトを可視にします。グラデーションはスライドに合わせて配置され、各図形内で再開されません。

以下の例は、スライドが継承するマスターバックグラウンドを作成し、3 つの長方形の背後にマゼンタバンドを配置します。左の長方形は背景を使用し、中央は塗りつぶしなし、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // マスタからグラデーションを継承する。
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // このオブジェクトを最初に追加して、長方形の背後に表示されるようにする。
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // 明示的な塗りつぶしを適用する前に背景塗りつぶしを無効にする。
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果（左から右へ）：**background fill**、**no fill**、**explicit fill**。マゼンタバンドは左と右の長方形で隠れますが、中央の長方形では可視です。

![背景塗りつぶし、塗り無し、明示的オレンジ塗りつぶし（マゼンタバンド上）](background-fill.png)

同様の動作は、スライド自体またはレイアウトから直接定義された背景にも適用されます。図形はスライドの解決された背景を使用します；例ではスライドとレイアウトの背景を未定義にし、マスターが提供するようにしています。

## **透明度の設定**

単色塗りつぶしの場合、色のアルファ成分が不透明度を制御します：0 が完全に透明、255 が完全に不透明です。この例は、アルファ値 128 の黄色の長方形を使用し、約 50% の透明度にして下の長方形が見えるようにします。色は [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) で割り当てます。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) を使用して、スライド平面上で図形を回転させます。角度は度で測定されます。この例は、長方形を時計回りに 5 度回転させ、プレゼンテーションを保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

[Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) を使用して、図形に奥行きとベベルエッジを付けます。この例は、緑の楕円にオレンジのアウトラインを付け、[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) を 4 ポイントに設定し、[ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) を使用して幅と高さが 6 ポイントの円形トップベベルを適用します。正面の正投影カメラと 3 点照明によりベベルが見えます。

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

図形の 3D 表示はカメラ設定で制御されます。この例は、[Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) に緯度 40 度、経度 35 度、回転 20 度を設定し、[Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) で等角投影カメラを選択し、[LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) で均衡照明を選択して、書式設定された長方形を保存します。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒レンダリングの制御**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに、個々の図形がどのようにレンダリングされるかを指定します。これは白黒表示を有効にするものではなく、通常のカラー モードでの図形の塗りつぶし、線、その他の書式設定を変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) クラスの値を使用して、目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレー、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

この例はオレンジの長方形を作成し、[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) を `Gray` に設定します。保存された図形は通常のカラー表示ではオレンジの塗りつぶしを保持し、白黒表示を尊重するアプリケーションではグレー表示になります。

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

通常のカラー モードでは、長方形はオレンジの塗りつぶしを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレー表示になります。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど白黒表示を尊重するワークフロー向けに別の外観を定義できます。

## **書式設定のリセット**

[Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) を使用して、スライドプレースホルダーの位置、サイズ、書式設定を対応するレイアウトプレースホルダーから復元します。この例は、レイアウトにリンクされたプレースホルダーを持つ既存のプレゼンテーションを必要とし、すべてのスライドをリセットしてから保存します。対応するレイアウトプレースホルダーがない図形はリセットされません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

色、線スタイル、効果設定は、埋め込み画像やメディアに比べて通常はごくわずかなデータしか追加しません。画像塗りつぶしは、画像がプレゼンテーションに保存されるため、ファイルサイズが増加する可能性があります。

**同一の書式設定を共有する図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルを同一とみなし、論理的にそれらの図形をグループ化します。これにより、後続のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライドデッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル済み図形をクローンし、必要な場所ですべての書式設定を再適用します。