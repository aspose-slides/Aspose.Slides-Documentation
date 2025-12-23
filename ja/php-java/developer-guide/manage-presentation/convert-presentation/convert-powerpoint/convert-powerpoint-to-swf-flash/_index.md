---
title: PHPでPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPointからSWFへ
type: docs
weight: 80
url: /ja/php-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからSWFへ
- プレゼンテーションからSWFへ
- スライドからSWFへ
- PPTからSWFへ
- PPTXからSWFへ
- PowerPointからFlashへ
- プレゼンテーションからFlashへ
- スライドからFlashへ
- PPTからFlashへ
- PPTXからFlashへ
- PPTをSWFとして保存
- PPTXをSWFとして保存
- PPTをSWFにエクスポート
- PPTXをSWFにエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプル、迅速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**
Presentation クラスで提供される [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用すると、プレゼンテーション全体を **SWF** ドキュメントに変換できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions) クラスが提供するオプションを使用してプレゼンテーションを **SWF** ドキュメントに変換する方法を示しています。生成された SWF にコメントを含めるには、[**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) クラスおよび [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) インターフェイスを使用できます。
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # プレゼンテーションを保存
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**SWF に非表示スライドを含めることはできますか？**

はい。[SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) の [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) メソッドを使用して非表示スライドを有効にします。既定では、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF のサイズをどのように制御できますか？**

[setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) メソッドと [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) を使用して、ファイルサイズと画像品質のバランスを取ります。

**'setViewerIncluded' は何のためですか、またいつ無効にすべきですか？**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンにソースフォントがない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) で指定したフォントに置き換えて、意図しないフォールバックを防ぎます。