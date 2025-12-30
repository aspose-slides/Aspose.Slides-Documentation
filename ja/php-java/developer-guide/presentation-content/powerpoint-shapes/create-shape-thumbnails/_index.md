---
title: PHPでプレゼンテーション シェイプのサムネイルを作成する
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/php-java/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプ をレンダリング
- シェイプ レンダリング
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint スライドから高品質なシェイプ サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートできます。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java を使用すると、各ページがスライドに対応するプレゼンテーション ファイルを作成できます。スライドは Microsoft PowerPoint で開くことで表示できます。しかし、開発者がシェイプの画像を別の画像ビューアで個別に確認したい場合があります。そのようなケースでは、Aspose.Slides for PHP via Java がスライド シェイプのサムネイル画像の生成を支援します。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライド サムネイルを生成する方法を示します。

- スライド内のシェイプ サムネイルの生成
- ユーザー定義のサイズでシェイプ サムネイルを生成
- シェイプの外観の境界内でシェイプ サムネイルを生成

## **スライドからシェイプ サムネイルを生成する**
Aspose.Slides for PHP via Java を使用して任意のスライドからシェイプ サムネイルを生成するには、次の手順を実行します。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)** クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドのデフォルト スケールで **[シェイプ サムネイル画像を取得](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--)** します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプ サムネイルを生成する方法を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 画像を PNG 形式でディスクに保存する
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


## **ユーザー定義スケーリング係数でサムネイルを生成する**
Aspose.Slides for PHP via Java を使用してスライドのシェイプ サムネイルをユーザー定義のサイズで生成するには、次の手順を実行します。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)** クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドの **[シェイプ サムネイル画像を取得](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-)** し、ユーザー定義の寸法を指定します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリング係数に基づいてシェイプ サムネイルを生成する方法を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 画像を PNG 形式でディスクに保存する
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


## **外観境界ベースのシェイプ サムネイルを作成する**
この方法を使用すると、開発者はシェイプの外観境界内でサムネイルを生成できます。すべてのシェイプ効果が考慮され、生成されたシェイプ サムネイルはスライド境界によって制限されます。外観境界内でスライド シェイプのサムネイルを生成するには、次の手順を実行します。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)** クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 外観としてシェイプ境界を使用して、参照したスライドのサムネイル画像を取得します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、上記の手順に基づいています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケールの画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 画像を PNG 形式でディスクに保存する
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


## **FAQ**

**シェイプ サムネイルを保存するときに使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/)、その他。シェイプはコンテンツを SVG として保存することで、[ベクトル SVG としてエクスポート](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) も可能です。

**サムネイルのレンダリング時に Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用し、`Appearance` は[視覚効果](/slides/ja/php-java/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示シェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショー表示に影響しますが、シェイプの画像生成を妨げません。

**グループシェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) など） はサムネイルまたは SVG として保存できます。

**システムにインストールされているフォントはテキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォント代替やテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/php-java/custom-font/)（または[フォント置換を構成](/slides/ja/php-java/font-substitution/)）する必要があります。