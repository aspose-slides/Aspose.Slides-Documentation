---
title: PHP を使用したプレゼンテーションへのフォント埋め込み
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/php-java/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint と OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確なレンダリングを実現します。"
---

**PowerPoint の埋め込みフォント** は、プレゼンテーションを任意のシステムやデバイスで開いたときに正しく表示させたい場合に便利です。作業で創造的になり、サードパーティ製や非標準フォントを使用した場合、埋め込みフォントにする理由はさらに増えます。埋め込みフォントがない場合、スライド上のテキストや数値、レイアウト、スタイリング等が変わってしまい、意味不明な矩形になることがあります。

The [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class、[FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) class、and [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) class are contain most of the methods you need to work with embedded fonts in PowerPoint presentations.

## **埋め込みフォントの取得と削除**

Aspose.Slides は、プレゼンテーションに埋め込まれたフォントを取得（または確認）できる [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) メソッド（[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスで公開）を提供します。フォントを削除するには、同じクラスの [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) メソッドを使用します。

```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 埋め込み "FunSized" を使用したテキストフレームを含むスライドをレンダリングします
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像を JPEG 形式でディスクに保存します
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # すべての埋め込みフォントを取得します
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # "Calibri" フォントを検索します
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # "Calibri" フォントを削除します
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # プレゼンテーションをレンダリングします。 "Calibri" フォントは既存のフォントに置き換えられます
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像を JPEG 形式でディスクに保存します
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 埋め込まれた "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) クラスと [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。この PHP コードは、フォントを埋め込んでプレゼンテーションに追加する方法を示しています:
```php
  # プレゼンテーションを読み込みます
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # プレゼンテーションをディスクに保存します
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **埋め込みフォントの圧縮**

プレゼンテーションに埋め込まれたフォントを圧縮し、ファイルサイズを削減できるように、Aspose.Slides は [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) クラスで公開されている [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts) メソッドを提供します。

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**プレゼンテーション内の特定のフォントが埋め込みされていても、レンダリング時に置き換えられるかどうかを確認するにはどうすればよいですか？**

フォントマネージャーの [置換情報](/slides/ja/php-java/font-substitution/) と [フォールバック/置換ルール](/slides/ja/php-java/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合は、フォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常は必要ありません—ほとんどの環境で利用可能です。ただし、Docker やフォントが事前にインストールされていない Linux サーバーなどの「薄い」環境で完全な移植性が求められる場合、システムフォントを埋め込むことで予期しない置換のリスクを排除できます。