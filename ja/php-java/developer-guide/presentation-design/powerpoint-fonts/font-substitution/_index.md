---
title: フォントの置き換え - PowerPoint Java API
linktitle: フォントの置き換え
type: docs
weight: 70
url: /ja/php-java/font-substitution/
keywords: "フォント, 置き換えフォント, PowerPoint プレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint でのフォントの置き換え"
---

Aspose.Slides は、特定の条件下で何をすべきかを決定するフォントのルールを設定できるようにします（たとえば、フォントにアクセスできない場合など）：

1. 関連するプレゼンテーションを読み込む。
2. 置き換えられるフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置き換えのためのルールを追加する。
5. プレゼンテーションのフォント置き換えルールコレクションにそのルールを追加する。
6. 効果を観察するためにスライド画像を生成する。

この PHP コードはフォントの置き換えプロセスを示しています：

```php
  # プレゼンテーションを読み込む
  $pres = new Presentation("Fonts.pptx");
  try {
    # 置き換えられるソースフォントを読み込む
    $sourceFont = new FontData("SomeRareFont");
    # 新しいフォントを読み込む
    $destFont = new FontData("Arial");
    # フォント置き換えのためのルールを追加する
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # フォント置き換えルールコレクションにルールを追加する
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # ルールリストにフォントルールコレクションを追加する
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # SomeRareFont がアクセス不可能な場合、Arial フォントが代わりに使用される
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 画像を JPEG 形式でディスクに保存する
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
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

{{%  alert title="注意"  color="warning"   %}} 

[**フォント置き換え**](/slides/ja/php-java/font-replacement/) を参照したいかもしれません。

{{% /alert %}}