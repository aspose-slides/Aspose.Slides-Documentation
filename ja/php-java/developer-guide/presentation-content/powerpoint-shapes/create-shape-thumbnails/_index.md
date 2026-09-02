---
title: PHPでプレゼンテーション形状のサムネイルを作成する
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/php-java/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状のレンダリング
- 形状レンダリング
- ビジュアル境界
- 形状境界
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint スライドから高品質な形状サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートします。"
---
## **はじめに**

Aspose.Slides は、各ページがスライドであるプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者が形状の画像を別々の画像ビューアで確認する必要がある場合があります。そのようなケースでは、Aspose.Slides がスライド形状のサムネイル画像の生成を支援します。この機能の使用方法は本記事で説明します。

本記事では、スライドのサムネイルを生成するさまざまな方法について説明します。

- スライド内の形状サムネイルを生成する。
- ユーザー定義のサイズでスライド形状のサムネイルを生成する。
- 形状の外観の境界内でサムネイルを生成する。

## **スライドから形状サムネイルを生成する**

Aspose.Slides for PHP via Java を使用して任意のスライドから形状サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照されたスライドのデフォルトスケールで[形状サムネイル画像を取得](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage)します。
4. 好みの画像形式でサムネイル画像を保存します。

```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 画像を PNG 形式でディスクに保存
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ユーザー定義のスケーリング ファクターでサムネイルを生成する**

Aspose.Slides for PHP via Java を使用してスライドの形状サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. ユーザー定義のサイズで参照されたスライドの[形状サムネイル画像を取得](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage)します。
4. 好みの画像形式でサムネイル画像を保存します。

```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 画像を PNG 形式でディスクに保存
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **境界ベースの形状外観サムネイルを作成する**

この形状サムネイル作成方法により、開発者は形状の外観の境界内でサムネイルを生成できます。すべての形状効果が考慮されます。生成された形状サムネイルはスライドの境界で制限されます。外観の境界内でスライド形状のサムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドの参照を取得します。
3. 参照されたスライドの形状境界を外観としてサムネイル画像を取得します。
4. 好みの画像形式でサムネイル画像を保存します。

```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 画像を PNG 形式でディスクに保存
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形状の実際のビジュアル境界を取得する**

[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) のフレームプロパティ—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, `Shape::getHeight()`—は、プレゼンテーション モデルに格納されている矩形を表します。実際に描画されるコンテンツはフレームを超えて拡張したり、別の軸整列矩形を占有したりすることがあります。回転、アウトライン、矢じり、テキストのレイアウトとオーバーフロー、生成された SmartArt のジオメトリ、その他の描画効果が占有領域を変える可能性があります。

画像を生成せずに占有領域を計算するには、[Shape::getVisualBounds](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getVisualBounds) を使用します。このメソッドはスライド座標系の[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を返します。返された矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

次の例はフレーム境界とビジュアル境界を取得して比較します。

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

同じ[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) を使用して、近接する形状を左、右、上、下のエッジに揃える、生成されたレイアウトで十分なスペースを確保する、または許可された領域外のコンテンツを検出することができます。ビジュアル境界は、格納されたフレームが完全な描画結果を表さない可能性がある SmartArt、テキスト ボックス、矢印、画像、回転形状、グループ形状などで特に有用です。

レイアウトや検証のために座標が必要でビットマップが不要な場合は、[Shape::getVisualBounds](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getVisualBounds) を使用します。形状を描画する必要がある場合は、[Shape::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage) を使用します。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapethumbnailbounds/) を使用すると、`ShapeThumbnailBounds::Shape` はアウトライン設定を含む形状境界から画像のサイズを決定し、`ShapeThumbnailBounds::Appearance` は形状の外観からサイズを決定し、結果をスライド境界に制限します。対照的に、`Shape::getVisualBounds` は計算された矩形のみを返し、スライドにクリップしません。

## **FAQ**

**形状サムネイルを保存する際に使用できる画像フォーマットは何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imageformat/) などが使用できます。形状は、形状のコンテンツを SVG として保存することで[ベクター SVG としてエクスポート](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/writeassvg/) も可能です。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` は形状のジオメトリを使用し、`Appearance` は[ビジュアル効果](/slides/ja/php-java/shape-effect/)（影、光彩など）を考慮します。

**形状が非表示としてマークされた場合はどうなりますか？サムネイルとして描画されますか？**

非表示の形状はモデルの一部として残り、描画可能です。非表示フラグはスライドショーの表示に影響しますが、形状の画像生成を妨げることはありません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) として表現されるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされているフォントはテキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/php-java/custom-font/)（または[フォント置換を構成](/slides/ja/php-java/font-substitution/)）する必要があります。