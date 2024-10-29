---
title: デフォルトフォント - PowerPoint Java API
linktitle: デフォルトフォント
type: docs
weight: 30
url: /ja/php-java/default-font/
description: PowerPoint Java APIを使用すると、プレゼンテーションをPDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontを定義する方法を示します。
---


## **プレゼンテーションのレンダリングにデフォルトフォントを使用する**
Aspose.Slidesを使用すると、プレゼンテーションをPDF、XPS、またはサムネイルにレンダリングするためのデフォルトフォントを設定できます。この記事では、デフォルトフォントとして使用するためのDefaultRegular FontとDefaultAsian Fontを定義する方法を示します。以下の手順に従って、Aspose.Slides for PHPをJava API経由で使用して外部ディレクトリからフォントを読み込んでください：

1. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions)のインスタンスを作成します。
1. [DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)を希望するフォントに設定します。以下の例では、Wingdingsを使用しています。
1. [DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)を希望するフォントに設定します。次のサンプルでもWingdingsを使用しています。
1. プレゼンテーションをPresentationを使用してロードし、ロードオプションを設定します。
1. 以上の結果を確認するために、スライドサムネイル、PDF、およびXPSを生成します。

上記の実装は以下の通りです。

```php
  # デフォルトのレギュラーフォントとアジアフォントを定義するためにロードオプションを使用
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # プレゼンテーションをロード
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # スライドサムネイルを生成
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # ディスクに画像を保存。
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDFを生成
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPSを生成
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```