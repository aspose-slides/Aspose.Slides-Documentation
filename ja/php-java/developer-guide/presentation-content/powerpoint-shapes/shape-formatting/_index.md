---
title: 形状の書式設定
type: docs
weight: 20
url: /ja/php-java/shape-formatting/
keywords: "形状の書式設定, ラインの書式設定, ジョインスタイルの書式設定, グラデーション塗りつぶし, パターン塗りつぶし, 画像塗りつぶし, 単色塗りつぶし, 形状の回転, 3D ベベル効果, 3D 回転効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint プレゼンテーション内の形状を整形します"
---

PowerPoint では、スライドに形状を追加できます。形状は線で構成されているため、構成する線に特定の効果を変更または適用することで形状をフォーマットできます。さらに、形状がどのように充填されるかを決定する設定を指定することで、形状を整形することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for PHP via Java** は、PowerPoint の既知のオプションに基づいて形状を整形するためのインターフェースとプロパティを提供します。

## **ラインの書式設定**

Aspose.Slides を使用すると、形状のラインスタイルを指定できます。この手順に沿った手続きは以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) を追加します。
4. 形状のラインに色を設定します。
5. 形状のラインの幅を設定します。
6. 形状のラインの [ラインスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) を設定します。
7. 形状のラインの [ダッシュスタイル](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) を設定します。
8. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、長方形の `AutoShape` を整形した操作を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形タイプのオートシェイプを追加します
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # 長方形形状の塗りつぶし色を設定します
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # 長方形のラインにいくつかの書式設定を適用します
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # 長方形のラインの色を設定します
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ジョインスタイルの書式設定**
ジョインタイプのオプションは次の3種類です：

* ラウンド
* ミッター
* ベベル

デフォルトでは、PowerPoint は二つのラインを角度で結合する場合（または形状の角で）、**ラウンド** セッティングを使用します。しかし、非常に鋭い角を持つ形状を描く場合は、**ミッター** を選択すると良いでしょう。

![join-style-powerpoint](join-style-powerpoint.png)

この Java コードは、ミッター、ベベル、ラウンドのジョインタイプを持つ3つの長方形（上の画像）を作成した操作を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 3つの長方形オートシェイプを追加します
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # 長方形形状の塗りつぶし色を設定します
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ラインの幅を設定します
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # 長方形のラインの色を設定します
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # ジョインスタイルを設定します
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # 各長方形にテキストを追加します
    $shp1->getTextFrame()->setText("ミッター ジョインスタイル");
    $shp2->getTextFrame()->setText("ベベル ジョインスタイル");
    $shp3->getTextFrame()->setText("ラウンド ジョインスタイル");
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **グラデーション塗りつぶし**
PowerPoint では、グラデーション塗りつぶしは、形状に対して色の連続的なブレンドを適用できる書式設定オプションです。たとえば、1つの色が徐々に別の色に変わるように、2色以上を設定することができます。

以下は、Aspose.Slides を使用して形状にグラデーション塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) を `Gradient` に設定します。
5. `GradientFormat` クラスに関連する `GradientStops` コレクションによって公開された `Add` メソッドを使用して、位置を定義した2つの好みの色を追加します。
6. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、楕円体にグラデーション塗りつぶし効果を使用した操作を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 楕円オートシェイプを追加します
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # 楕円にグラデーション書式設定を適用します
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # グラデーションの方向を設定します
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # 2つのグラデーションストップを追加します
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # PPTX ファイルをディスクに保存します
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **パターン塗りつぶし**
PowerPoint では、パターン塗りつぶしは、形状にドット、ストライプ、クロスハッチ、またはチェックで構成された2色のデザインを適用できる書式設定オプションです。さらに、パターンの前景と背景の好みの色を選択できます。

Aspose.Slides は、形状を整形しプレゼンテーションを豊かにするために使用できる45以上の定義済みスタイルを提供します。定義済みのパターンを選択した後でも、そのパターンに含める色を指定できます。

以下は、Aspose.Slides を使用して形状にパターン塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) を `Pattern` に設定します。
5. 形状のために好みのパターンスタイルを設定します。
6. [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat) の [背景色](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) を設定します。
7. [前景色](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) を [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat) に設定します。
8. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、長方形を美しくするためにパターン塗りつぶしを使用した操作を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形オートシェイプを追加します
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 塗りつぶしタイプをパターンに設定します
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # パターンスタイルを設定します
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # パターンのバックとフォアの色を設定します
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **画像塗りつぶし**
PowerPoint では、画像塗りつぶしは、画像を形状内に配置できる書式設定オプションです。基本的に、形状の背景として画像を使用することができます。

以下は、Aspose.Slides を使用して形状に画像を塗りつぶす方法です：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) を `Picture` に設定します。
5. 画像塗りつぶしモードをタイルに設定します。
6. 形状に塗りつぶす画像を使用して `IPPImage` オブジェクトを作成します。
7. `PictureFillFormat` オブジェクトの `Picture.Image` プロパティを最近作成された `IPPImage` に設定します。
8. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、形状に画像を塗りつぶす方法を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形オートシェイプを追加します
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 塗りつぶしタイプを画像に設定します
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # 画像塗りつぶしモードを設定します
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # 画像を設定します
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **単色塗りつぶし**
PowerPoint では、単色塗りつぶしは、形状を単一の色で塗りつぶすことを可能にする書式設定オプションです。選択された色は通常、単純な色です。色は、特別な効果や変更が加えられた形状の背景に適用されます。

以下は、Aspose.Slides を使用して形状に単色塗りつぶしを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. 形状の [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) を `Solid` に設定します。
5. 形状のために好みの色を設定します。
6. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、PowerPoint のボックスに単色塗りつぶしを適用する方法を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形オートシェイプを追加します
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 塗りつぶしタイプを単色に設定します
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # 長方形の色を設定します
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **透明度を設定する**

PowerPoint では、形状に単色、グラデーション、画像、またはテクスチャで塗りつぶす際に、塗りつぶしの不透明度を決定する透明度レベルを指定できます。これにより、たとえば、透明度レベルを低く設定すると、（形状の後ろの）スライドオブジェクトまたは背景が見えるようになります。

Aspose.Slides は、次のように形状の透明度レベルを設定することを可能にします：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. アルファコンポーネントが設定された `new Color` を使用します。
5. オブジェクトを PowerPoint ファイルとして保存します。

この PHP コードは、そのプロセスを示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # ソリッド形状を追加します
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # ソリッド形状の上に透明な形状を追加します
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # PPTX ファイルをディスクに保存します
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形状を回転する**
Aspose.Slides を使用すると、スライドに追加された形状を次の方法で回転できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
4. 必要な度数で形状を回転します。
5. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

この PHP コードは、形状を90度回転させる方法を示しています：

```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形オートシェイプを追加します
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 形状を90度回転させます
    $shp->setRotation(90);
    # PPTX ファイルをディスクに保存します
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **3D ベベル効果を追加する**
Aspose.Slides を使用すると、次の方法で形状に 3D ベベル効果を追加でき、[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) プロパティを修正します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
3. 形状の [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) プロパティの好みのパラメータを設定します。
4. プレゼンテーションをディスクに書き込みます。

この PHP コードは、形状に 3D ベベル効果を追加する方法を示しています：

```php
  # プレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # スライドに形状を追加します
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # 形状の ThreeDFormat プロパティを設定します
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # プレゼンテーションを PPTX ファイルとして保存します
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **3D 回転効果を追加する**
Aspose.Slides を使用すると、次の方法で形状に 3D 回転効果を適用できます。 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) プロパティを修正します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) をスライドに追加します。
3. [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) と [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--) に対して、好みの数値を指定します。
4. プレゼンテーションをディスクに書き込みます。

この PHP コードは、形状に 3D 回転効果を適用する方法を示しています：

```php
  # プレゼンテーション クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # プレゼンテーションを PPTX ファイルとして保存します
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **書式設定のリセット**

この PHP コードは、スライド内の書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) にプレースホルダーを持つすべての形状の位置、サイズ、および書式をデフォルト値に戻す方法を示しています：

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # レイアウトにプレースホルダーのあるスライドの各形状が元に戻ります
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```