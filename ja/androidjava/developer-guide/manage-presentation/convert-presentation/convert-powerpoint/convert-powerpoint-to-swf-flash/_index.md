---
title: Android で PowerPoint プレゼンテーションを SWF フラッシュに変換
linktitle: PowerPoint から SWF へ
type: docs
weight: 80
url: /ja/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から SWF へ
- プレゼンテーションから SWF へ
- スライドから SWF へ
- PPT から SWF へ
- PPTX から SWF へ
- PowerPoint から Flash へ
- プレゼンテーションから Flash へ
- スライドから Flash へ
- PPT から Flash へ
- PPTX から Flash へ
- PPT を SWF として保存
- PPTX を SWF として保存
- PPT を SWF にエクスポート
- PPTX を SWF にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用した Java で PowerPoint (PPT/PPTX) を SWF フラッシュに変換します。ステップバイステップのコードサンプル、高速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **PPT(X) を SWF に変換**
[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドは、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスで公開されており、プレゼンテーション全体を **SWF** ドキュメントに変換するために使用できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions) クラスが提供するオプションを使用してプレゼンテーションを **SWF** ドキュメントに変換する方法を示しています。また、生成された SWF にコメントを含めるには、[**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) クラスと [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) インターフェイスを使用できます。
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // プレゼンテーションの保存
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。[SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) の [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して非表示スライドを有効にします。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

[setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) メソッドと [adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) を使用して、ファイルサイズと画像品質のバランスを取ります。

**‘setViewerIncluded’ は何のためにあり、いつ無効にすべきですか？**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンに元フォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) で指定したフォントに置き換えて、予期しないフォントフォールバックを防止します。