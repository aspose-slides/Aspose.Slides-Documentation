---
title: "PHP を使用してプレゼンテーション内の SmartArt グラフィックを管理する"
linktitle: "SmartArt グラフィック"
type: docs
weight: 20
url: /ja/php-java/manage-smartart-shape/
keywords:
- "SmartArt オブジェクト"
- "SmartArt グラフィック"
- "SmartArt スタイル"
- "SmartArt カラー"
- "SmartArt の作成"
- "SmartArt の追加"
- "SmartArt の編集"
- "SmartArt の変更"
- "SmartArt へのアクセス"
- "SmartArt レイアウト タイプ"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides を使用して PHP で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **スマートアートシェイプの作成**
Aspose.Slides for PHP via Java は SmartArt シェイプを作成するための API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation] クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [SmartArtシェイプの追加]（https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-）し、[LayoutType] を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
```php
  # プレゼンテーション クラスのインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt シェイプを追加
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # プレゼンテーションを保存
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **スライド上の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用します。サンプルコードでは、スライド内のすべてのシェイプを走査し、それが [SmartArt] シェイプかどうかを確認します。SmartArt タイプのシェイプであれば、[**SmartArt**] インスタンスに型変換します。
```php
  # 目的のプレゼンテーションを読み込む
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプが SmartArt タイプかどうかを確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャストする
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **特定の LayoutType を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [SmartArt] シェイプにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、[SmartArt] シェイプが追加されたときにのみ設定されるため、変更できないことに注意してください。

1. [Presentation] クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt] タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定の LayoutType を持つ SmartArt シェイプを確認し、必要な処理を実行します。
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査する
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプが SmartArt タイプかどうかを確認する
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャストする
        $smart = $shape;
        # SmartArt のレイアウトを確認する
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **SmartArt シェイプのスタイル変更**
この例では、任意の SmartArt シェイプのクイック スタイルを変更する方法を学びます。

1. [Presentation] クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt] タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定の Style を持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しい Style を設定します。
1. プレゼンテーションを保存します。
```php
  # プレゼンテーション クラスをインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャスト
        $smart = $shape;
        # SmartArt スタイルを確認
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt スタイルを変更
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # プレゼンテーションを保存
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **SmartArt シェイプのカラー スタイル変更**
この例では、任意の SmartArt シェイプのカラー スタイルを変更する方法を学びます。以下のサンプルコードは、特定のカラー スタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation] クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt] タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定の Color Style を持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しい Color Style を設定します。
1. プレゼンテーションを保存します。
```php
  # プレゼンテーション クラスをインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプかどうかを確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャスト
        $smart = $shape;
        # SmartArt のカラータイプを確認
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt のカラータイプを変更
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # プレゼンテーションを保存
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API（開始、終了、強調、モーション パス）を使用して[標準アニメーション](/slides/ja/php-java/powerpoint-animation/)を適用できます。

**内部 ID が分からない場合、スライド上の特定の SmartArt をどうやって見つけますか？**

代替テキスト (AltText) を設定し、その値でシェイプを検索します。これは対象シェイプを特定する推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像やテーブルなどの他のシェイプとグループ化でき、[グループの操作](/slides/ja/php-java/group/)が可能です。

**特定の SmartArt の画像（プレビューやレポート用）を取得する方法は？**

シェイプのサムネイル/画像をエクスポートできます。ライブラリは個々のシェイプを PNG/JPG/TIFF 形式のラスターファイルとして[レンダリング](/slides/ja/php-java/create-shape-thumbnails/)できます。

**プレゼンテーション全体を PDF に変換したとき、SmartArt の外観は保持されますか？**

はい。レンダリング エンジンは[PDF エクスポート](/slides/ja/php-java/convert-powerpoint-to-pdf/)で高忠実度を目指しており、品質や互換性のオプションが用意されています。