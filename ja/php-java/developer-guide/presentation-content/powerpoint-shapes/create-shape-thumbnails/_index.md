---
title: 形のサムネイルを作成する
type: docs
weight: 70
url: /php-java/create-shape-thumbnails/
---


## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaを使用すると、各ページがスライドに対応するプレゼンテーションファイルを作成できます。スライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし、開発者は時々、画像ビューアでそれぞれの形の画像を別々に表示する必要があります。その場合、Aspose.Slides for PHP via Javaがスライドの形のサムネイル画像を生成する手助けをします。

{{% /alert %}} 

このトピックでは、異なる状況でスライドのサムネイルを生成する方法を示します：

- スライド内に形のサムネイルを生成する。
- ユーザー定義の寸法を持つスライド形のサムネイルを生成する。
- 形の外観の境界内に形のサムネイルを生成する。

## **スライドからの形のサムネイルの生成**
Aspose.Slides for PHP via Javaを使用して任意のスライドから形のサムネイルを生成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのIDまたはインデックスを使用して任意のスライドの参照を取得します。
1. デフォルトスケールで参照されたスライドの[形のサムネイル画像](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--)を取得します。
1. 希望の画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドから形のサムネイルを生成する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationクラスをインスタンス化する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケール画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 画像をPNG形式でディスクに保存する
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

## **ユーザー定義のスケーリングファクターを使用した形のサムネイルの生成**
Aspose.Slides for PHP via Javaを使用してスライドの形のサムネイルを生成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのIDまたはインデックスを使用して任意のスライドの参照を取得します。
1. ユーザー定義の寸法で参照されたスライドの[形のサムネイル画像](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-)を取得します。
1. 希望の画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリングファクターに基づいて形のサムネイルを生成する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationクラスをインスタンス化する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケール画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 画像をPNG形式でディスクに保存する
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

## **外観の境界の形のサムネイルの生成**
この形のサムネイルを作成する方法は、開発者が形の外観の境界内にサムネイルを生成できるようにします。形の効果をすべて考慮します。生成された形のサムネイルはスライドの境界によって制限されます。形の外観の境界内にスライド形のサムネイルを生成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのIDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 外観として形の境界で参照されたスライドのサムネイル画像を取得します。
1. 希望の画像形式でサムネイル画像を保存します。

このサンプルコードは、上記の手順に基づいています：

```php
  # プレゼンテーションファイルを表すPresentationクラスをインスタンス化する
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # フルスケール画像を作成する
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 画像をPNG形式でディスクに保存する
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