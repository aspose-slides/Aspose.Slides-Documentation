---
title: PHP を使用してプレゼンテーションの SmartArt グラフィックスを管理する
linktitle: SmartArt グラフィックス
type: docs
weight: 20
url: /ja/php-java/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウト タイプ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt シェイプの作成する**
Aspose.Slides for PHP via Java は SmartArt シェイプを作成するための API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [SmartArt シェイプを追加](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) を、[LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType) を設定して実行します。
4. 変更されたプレゼンテーションを PPTX ファイルとして保存します。
```php
  # Presentation クラスのインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art シェイプを追加
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
|**Figure: スライドに追加された SmartArt シェイプ**|

## **スライド上の SmartArt シェイプにアクセスする**
次のコードは、プレゼンテーションスライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、それが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプかどうかを確認します。シェイプが SmartArt タイプの場合、[**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) インスタンスに型キャストします。
```php
  # 指定したプレゼンテーションをロード
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャスト
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


## **特定の LayoutType を持つ SmartArt シェイプにアクセスする**
次のサンプルコードは、特定の LayoutType を持つ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用であり、[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) シェイプが追加されたときにのみ設定されるため、変更できないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
5. 特定の LayoutType を持つ SmartArt シェイプを確認し、その後に必要な処理を実行します。
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 最初のスライド内のすべてのシェイプを走査
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャスト
        $smart = $shape;
        # SmartArt レイアウトを確認
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


## **SmartArt シェイプのスタイルを変更する**
この例では、任意の SmartArt シェイプのクイック スタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
5. 特定の Style を持つ SmartArt シェイプを検索します。
6. SmartArt シェイプに新しい Style を設定します。
7. プレゼンテーションを保存します。
```php
  # Presentation クラスをインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # シェイプを SmartArtEx に型キャスト
        $smart = $shape;
        # SmartArt のスタイルを確認
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt のスタイルを変更
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
|**Figure: スタイルが変更された SmartArt シェイプ**|

## **SmartArt シェイプのカラースタイルを変更する**
この例では、任意の SmartArt シェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 最初のスライド内のすべてのシェイプを走査します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
5. 特定の Color Style を持つ SmartArt シェイプを検索します。
6. SmartArt シェイプに新しい Color Style を設定します。
7. プレゼンテーションを保存します。
```php
  # Presentation クラスをインスタンス化
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 最初のスライド内のすべてのシェイプを走査
    foreach($slide->getShapes() as $shape) {
      # シェイプが SmartArt タイプか確認
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
|**Figure: カラースタイルが変更された SmartArt シェイプ**|

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API を使用して [standard animations](/slides/ja/php-java/powerpoint-animation/)（開始、終了、強調、動きのパス）を適用できます。

**スライド上の特定の SmartArt を内部 ID が分からない場合、どうやって見つけられますか？**

代替テキスト（AltText）を設定して使用し、その値でシェイプを検索します。これは対象シェイプを見つける推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を他のシェイプ（画像、テーブルなど）とグループ化し、[manipulate the group](/slides/ja/php-java/group/) を使用して操作できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するには？**

シェイプのサムネイル/画像をエクスポートします。ライブラリは個々のシェイプを [render individual shapes](/slides/ja/php-java/create-shape-thumbnails/) してラスターファイル（PNG/JPG/TIFF）に出力できます。

**プレゼンテーション全体を PDF に変換したとき、SmartArt の外観は保持されますか？**

はい。レンダリングエンジンは [PDF export](/slides/ja/php-java/convert-powerpoint-to-pdf/) において高忠実度を目指しており、さまざまな品質と互換性オプションが用意されています。