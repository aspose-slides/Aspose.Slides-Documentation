---
title: PHPでプレゼンテーションシェイプのサムネイルを作成する
linktitle: シェイプサムネイル
type: docs
weight: 70
url: /ja/php-java/create-shape-thumbnails/
keywords:
- シェイプサムネイル
- シェイプ画像
- シェイプのレンダリング
- シェイプレンダリング
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaを使用してPowerPointスライドから高品質なシェイプサムネイルを生成します – プレゼンテーションのサムネイルを簡単に作成・エクスポートできます。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、各ページがスライドに対応するプレゼンテーションファイルを作成するために使用できます。スライドは Microsoft PowerPoint でプレゼンテーションファイルを開くことで表示できます。ただし、開発者は時々シェイプの画像を画像ビューアで個別に表示する必要があります。そのような場合、Aspose.Slides for PHP via Java はスライドシェイプのサムネイル画像を生成するのに役立ちます。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライドのサムネイルを生成する方法を示します。

- スライド内のシェイプサムネイルを生成する。
- ユーザー定義のサイズでスライドシェイプのシェイプサムネイルを生成する。
- シェイプの外観境界内でシェイプサムネイルを生成する。

## **スライドからシェイプサムネイルを生成する**
Aspose.Slides for PHP via Java を使用して任意のスライドからシェイプサムネイルを生成するには、次の手順を実行します。

1. [Presentation] クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのデフォルトスケールで[シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプサムネイルを生成する方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルサイズの画像を作成
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


## **ユーザー定義スケーリング係数のサムネイルを生成する**
Aspose.Slides for PHP via Java を使用してスライドのシェイプサムネイルを生成するには、次の手順を実行します。

1. [Presentation] クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. ユーザー定義のサイズで参照されたスライドの[シェイプのサムネイル画像を取得](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリング係数に基づいてシェイプサムネイルを生成する方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケール画像を作成
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


## **境界ベースのシェイプ外観サムネイルを作成する**
このシェイプサムネイル作成方法により、開発者はシェイプの外観境界内でサムネイルを生成できます。すべてのシェイプ効果が考慮されます。生成されたシェイプサムネイルはスライドの境界で制限されます。シェイプの外観境界内でスライドシェイプのサムネイルを生成するには、次の手順を実行します。

1. [Presentation] クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプ境界を外観として使用し、参照されたスライドのサムネイル画像を取得します。
1. 好みの画像形式でサムネイル画像を保存します。

このサンプルコードは上記の手順に基づいています。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケール画像を作成
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


## **FAQ**

**シェイプサムネイルの保存に使用できる画像形式は何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/) およびその他があります。シェイプは、シェイプの内容を SVG として保存することで、[ベクター SVG としてエクスポート](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) することもできます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用し、`Appearance` は[視覚効果](/slides/ja/php-java/shape-effect/)（影、ぼかしなど）を考慮します。

**シェイプが非表示としてマークされた場合はどうなりますか？サムネイルとしてレンダリングされますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げません。

**グループシェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape] として表現されるすべてのオブジェクト（[GroupShape]、[Chart]、[SmartArt] を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントはテキストシェイプのサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/php-java/custom-font/)（または[フォント置換を構成](/slides/ja/php-java/font-substitution/)）する必要があります。