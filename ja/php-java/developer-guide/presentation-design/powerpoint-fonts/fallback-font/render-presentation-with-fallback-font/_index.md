---
title: PHPでフォールバック フォントを使用してプレゼンテーションをレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/php-java/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPointのレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を Java 経由で使用してフォールバック フォントでプレゼンテーションをレンダリングします – PPT、PPTX、ODP でテキストの一貫性を保つステップバイステップのコードサンプルをご提供します。"
---

以下の例では、これらの手順が含まれます:

1. フォールバック フォント ルール コレクションを[フォールバック フォント ルール コレクションを作成](/slides/ja/php-java/create-fallback-fonts-collection/)します。
2. フォールバック フォント ルールを[削除](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-)し、別のルールに[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加します。
3. ルール コレクションを[getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)メソッドに設定します。
4. [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)に設定された後、これらのルールはプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）で適用されます。
```php
  # ルール コレクションの新しいインスタンスを作成
  $rulesList = new FontFallBackRulesCollection();
  # 複数のルールを作成
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 読み込まれたルールからフォールバック フォント "Tahoma" を削除しようとしています
    $fallBackRule->remove("Tahoma");
    # 指定された範囲のルールを更新します
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # また、リストから既存のルールをすべて削除できます
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 使用するために準備したルール リストを割り当て
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 初期化されたルール コレクションを使用してサムネイルをレンダリングし、JPEG に保存
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 画像を JPEG 形式でディスクに保存
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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


{{% alert color="primary" %}} 
PHPでPPTおよびPPTXをJPGに変換する方法の詳細をご覧ください。[PHPでPPTおよびPPTXをJPGに変換](/slides/ja/php-java/convert-powerpoint-to-jpg/)。 
{{% /alert %}}