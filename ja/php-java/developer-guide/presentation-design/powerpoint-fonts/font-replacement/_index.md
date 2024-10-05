---
title: フォント置き換え - PowerPoint Java API
linktitle: フォント置き換え
type: docs
weight: 60
url: /php-java/font-replacement/
description: Java APIを使用してPowerPointで明示的置き換え方法によるフォントの置き換え方法を学びます。
---

フォントを使用することについて考え直した場合、そのフォントを別のフォントに置き換えることができます。古いフォントのすべてのインスタンスは新しいフォントに置き換えられます。

Aspose.Slidesを使用すると、この方法でフォントを置き換えることができます：

1. 関連するプレゼンテーションをロードします。
2. 置き換えられるフォントをロードします。
3. 新しいフォントをロードします。
4. フォントを置き換えます。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPHPコードはフォント置き換えを示しています：

```php
  # プレゼンテーションをロードする
  $pres = new Presentation("Fonts.pptx");
  try {
    # 置き換えられるソースフォントをロードする
    $sourceFont = new FontData("Arial");
    # 新しいフォントをロードする
    $destFont = new FontData("Times New Roman");
    # フォントを置き換える
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # プレゼンテーションを保存する
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

特定の条件で何が起こるかを決定するルールを設定するには（フォントにアクセスできない場合など）、[**フォント代替**](/slides/php-java/font-substitution/)を参照してください。

{{% /alert %}}