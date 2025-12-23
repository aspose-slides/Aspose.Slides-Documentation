---
title: PHPでプレゼンテーションのプレースホルダーを管理
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/php-java/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- プロンプトテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でプレースホルダーを簡単に管理します：テキストの置換、プロンプトのカスタマイズ、PowerPoint および OpenDocument の画像透過性の設定が可能です。"
---

## **プレースホルダーのテキストを変更する**
Aspose.Slides for PHP via Java](/slides/ja/php-java/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索して変更できます。Aspose.Slides を使用すると、プレースホルダー内のテキストを変更できます。

**前提条件**: プレースホルダーが含まれるプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

このプレゼンテーションでプレースホルダーのテキストを置換する方法は次のとおりです:

1. [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. プレースホルダーを見つけるためにシェイプをイテレートします。
4. プレースホルダーシェイプを [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この PHP コードはプレースホルダーのテキストを変更する方法を示しています:
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # プレースホルダーを探すためにシェイプを反復処理します
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # 各プレースホルダーのテキストを変更します
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # プレゼンテーションをディスクに保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** といったプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、プレースホルダーレイアウトに好みのプロンプトテキストを挿入できます。

この PHP コードはプレースホルダーにプロンプトテキストを設定する方法を示しています:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # スライドを反復処理します
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint は「Click to add title」を表示します
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // サブタイトルを追加
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **プレースホルダー画像の透過性を設定する**
Aspose.Slides を使用すると、テキストプレースホルダー内の背景画像の透明度を設定できます。このフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色によります）。

この PHP コードは画像背景（シェイプ内）の透過性を設定する方法を示しています:
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**ベースプレースホルダーとは何か、スライド上のローカルシェイプとどう違うのか**  
ベースプレースホルダーは、スライドのシェイプが継承するレイアウトまたはマスタ上の元のシェイプです。タイプ、位置、いくつかの書式設定がそれから引き継がれます。ローカルシェイプは独立しており、ベースプレースホルダーが存在しない場合は継承が適用されません。

**すべてのスライドを個別にイテレートせずに、プレゼンテーション全体のタイトルやキャプションを更新するにはどうすればよいですか？**  
レイアウトまたはマスタ上の該当するプレースホルダーを編集します。そのレイアウトやマスタに基づくスライドは、自動的に変更を継承します。

**標準のヘッダー/フッタープレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御しますか？**  
適切なスコープ（通常のスライド、レイアウト、マスタ、ノート/配布資料）で HeaderFooter マネージャーを使用し、プレースホルダーのオン/オフを切り替え、内容を設定します。