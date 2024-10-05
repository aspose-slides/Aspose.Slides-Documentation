---
title: 埋め込みフォント - PowerPoint Java API
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /php-java/embedded-font/
keywords: "フォント, 埋め込みフォント, フォントの追加, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションで埋め込みフォントを使用する"

---

**PowerPointでの埋め込みフォント**は、プレゼンテーションを任意のシステムやデバイスで正しく表示させたい場合に便利です。もし創造的な作業のためにサードパーティ製または非標準のフォントを使用した場合、フォントを埋め込む理由がさらに増えます。さもなければ（埋め込みフォントがない場合）、スライド上のテキストや数字、レイアウト、スタイリングなどが変わったり、混乱を招く長方形に変わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)クラス、[FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/)クラス、[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)クラス、およびそれらのインターフェイスは、PowerPointプレゼンテーションにおける埋め込みフォントを操作するために必要なプロパティやメソッドのほとんどを含んでいます。

## **プレゼンテーションから埋め込みフォントを取得または削除する**

Aspose.Slidesは、プレゼンテーションに埋め込まれているフォントを取得（または確認）するために、[getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--)メソッド（[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)クラスによって公開）を提供します。フォントを削除するには、[removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-)メソッド（同じクラスによって公開）を使用します。

このPHPコードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 埋め込み「FunSized」を使用するテキストフレームを含むスライドをレンダリング
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像をJPEG形式でディスクに保存
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # すべての埋め込みフォントを取得
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # 「Calibri」フォントを見つける
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # 「Calibri」フォントを削除
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # プレゼンテーションをレンダリング; 「Calibri」フォントは既存のものに置き換えられる
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像をJPEG形式でディスクに保存
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 埋め込み「Calibri」フォントなしのプレゼンテーションをディスクに保存
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **埋め込みフォントをプレゼンテーションに追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/)列挙体と、[addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)メソッドの2つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。このPHPコードは、プレゼンテーションにフォントを埋めて追加する方法を示しています：

```php
  # プレゼンテーションを読み込む
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
    # プレゼンテーションをディスクに保存
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **埋め込みフォントを圧縮する**

プレゼンテーション内の埋め込みフォントを圧縮してファイルサイズを削減できるように、Aspose.Slidesは[compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-)メソッド（[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)クラスによって公開）を提供します。

このPHPコードは、埋め込みPowerPointフォントを圧縮する方法を示しています：

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