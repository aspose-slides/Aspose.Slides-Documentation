---
title: フォールバックフォントを使用したプレゼンテーションのレンダリング
type: docs
weight: 30
url: /php-java/render-presentation-with-fallback-font/
---

次の例は、これらの手順を含みます：

1. [フォールバックフォントルールコレクションを作成します](/slides/php-java/create-fallback-fonts-collection/)。
1. フォールバックフォントルールを[削除](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-)し、別のルールに[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加します。
1. ルールコレクションを[getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--)メソッドに設定します。
1. [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用することで、プレゼンテーションを同じフォーマットで保存するか、別のフォーマットで保存できます。フォールバックフォントルールコレクションが[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)に設定されると、これらのルールはプレゼンテーションの保存、レンダリング、変換などの操作中に適用されます。

```php
  # ルールコレクションの新しいインスタンスを作成
  $rulesList = new FontFallBackRulesCollection();
  # いくつかのルールを作成
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとしています
    $fallBackRule->remove("Tahoma");
    # 指定された範囲のルールを更新する
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # 既存のルールをリストから削除することもできます
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # 使用するために準備したルールリストを割り当てる
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # 初期化されたルールコレクションを使用してサムネイルをレンダリングし、JPEGに保存
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 画像をJPEG形式でディスクに保存
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
[プレゼンテーションの保存と変換について詳しく読む](/slides/php-java/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}