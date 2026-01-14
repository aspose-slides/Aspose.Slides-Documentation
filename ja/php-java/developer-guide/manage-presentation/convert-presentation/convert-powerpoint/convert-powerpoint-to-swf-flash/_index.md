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
description: "Aspose.Slides を使用して、PHPで PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプルで、迅速かつ高品質な出力を実現し、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

[save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) メソッドは [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスで公開されており、プレゼンテーション全体を **SWF** ドキュメントに変換するために使用できます。以下の例は、[SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) クラスが提供するオプションを使用してプレゼンテーションを **SWF** ドキュメントに変換する方法を示しています。また、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用して生成された SWF にコメントを含めることもできます。
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # プレゼンテーションの保存
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**SWFに非表示スライドを含めることはできますか？**

はい。非表示スライドは [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) の [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) メソッドを使用して有効にできます。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

[setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) メソッドと [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) を使用して、ファイルサイズと画像の忠実度のバランスを取ります。

**'setViewerIncluded' の目的は何ですか？また、いつ無効にすべきですか？**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や、UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンに元フォントが存在しない場合、どうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) で指定したフォントに置き換えて、意図しないフォントフォールバックを防ぎます。