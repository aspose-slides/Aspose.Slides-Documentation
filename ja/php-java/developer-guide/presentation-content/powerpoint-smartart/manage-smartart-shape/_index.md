---
title: スマートアートシェイプの管理
type: docs
weight: 20
url: /ja/php-java/manage-smartart-shape/
---


## **スマートアートシェイプの作成**
Aspose.Slides for PHP via Java はスマートアートシェイプを作成するための API を提供しています。スライドにスマートアートシェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType) を設定して [スマートアートシェイプを追加](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)します。
1. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

```php
  # Presentation クラスのインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # スマートアートシェイプの追加
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # プレゼンテーションの保存
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図：スライドに追加されたスマートアートシェイプ**|

## **スライド内のスマートアートシェイプにアクセス**
以下のコードを使用して、プレゼンテーションスライドに追加されたスマートアートシェイプにアクセスします。サンプルコードでは、スライド内のすべてのシェイプを巡回し、それが [スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプであるかどうかを確認します。形状がスマートアートタイプである場合、そのインスタンスを [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) に型キャストします。

```php
  # プレゼンテーションを読み込む
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを巡回
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 形状がスマートアートタイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 形状を SmartArtEx に型キャスト
        $smart = $shape;
        echo("シェイプ名:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **特定のレイアウトタイプを持つスマートアートシェイプにアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。スマートアートの LayoutType は読み取り専用で、[スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプが追加されたときにのみ設定されるため、変更することはできません。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、スマートアートシェイプを持つプレゼンテーションを読み込みます。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを巡回します。
1. 形状が [スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプであるかどうかを確認し、スマートアートである場合は選択された形状をスマートアートに型キャストします。
1. 特定の LayoutType を持つスマートアートシェイプを確認し、その後必要な処理を実行します。

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを巡回
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 形状がスマートアートタイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 形状を SmartArtEx に型キャスト
        $smart = $shape;
        # スマートアートのレイアウトを確認
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("ここで何かを行います....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スマートアートシェイプのスタイルを変更**
この例では、任意のスマートアートシェイプのクイックスタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、スマートアートシェイプを含むプレゼンテーションを読み込みます。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを巡回します。
1. 形状が [スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプであるかどうかを確認し、スマートアートである場合は選択された形状をスマートアートに型キャストします。
1. 特定のスタイルを持つスマートアートシェイプを見つけます。
1. スマートアートシェイプに新しいスタイルを設定します。
1. プレゼンテーションを保存します。

```php
  # Presentation クラスのインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを巡回
    foreach($slide->getShapes() as $shape) {
      # 形状がスマートアートタイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 形状を SmartArtEx に型キャスト
        $smart = $shape;
        # スマートアートスタイルの確認
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # スマートアートスタイルの変更
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # プレゼンテーションの保存
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図：スタイルが変更されたスマートアートシェイプ**|

## **スマートアートシェイプのカラー スタイルを変更**
この例では、任意のスマートアートシェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つスマートアートシェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、スマートアートシェイプを含むプレゼンテーションを読み込みます。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを巡回します。
1. 形状が [スマートアート](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプであるかどうかを確認し、スマートアートである場合は選択された形状をスマートアートに型キャストします。
1. 特定のカラースタイルを持つスマートアートシェイプを見つけます。
1. スマートアートシェイプに新しいカラースタイルを設定します。
1. プレゼンテーションを保存します。

```php
  # Presentation クラスのインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを巡回
    foreach($slide->getShapes() as $shape) {
      # 形状がスマートアートタイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 形状を SmartArtEx に型キャスト
        $smart = $shape;
        # スマートアートのカラースタイルを確認
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # スマートアートのカラースタイルを変更
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # プレゼンテーションの保存
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**図：カラー スタイルが変更されたスマートアートシェイプ**|