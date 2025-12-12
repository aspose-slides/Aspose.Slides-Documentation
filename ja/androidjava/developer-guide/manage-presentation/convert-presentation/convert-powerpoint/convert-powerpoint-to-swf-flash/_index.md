---
title: Android で PowerPoint プレゼンテーションを SWF Flash に変換
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
- PowerPoint から SWF
- プレゼンテーションから SWF
- スライドから SWF
- PPT から SWF
- PPTX から SWF
- PowerPoint から Flash
- プレゼンテーションから Flash
- スライドから Flash
- PPT から Flash
- PPTX から Flash
- PPT を SWF として保存
- PPTX を SWF として保存
- PPT を SWF にエクスポート
- PPTX を SWF にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用して、Java で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプル、高速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **PPT(X) を SWF に変換**
[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドは [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスが提供し、プレゼンテーション全体を **SWF** ドキュメントに変換できます。以下の例は、[**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions) クラスで提供されるオプションを使用してプレゼンテーションを **SWF** ドキュメントに変換する方法を示しています。生成された SWF にコメントを含めるには、[**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) クラスと [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) インターフェイスを使用できます。
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // プレゼンテーションを保存
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**SWF に非表示スライドを含めることはできますか？**

はい。[SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) の [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) メソッドで非表示スライドを有効にできます。既定では、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF のサイズをどのように制御できますか？**

[setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) メソッドと [adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) を使用して、ファイルサイズと画像品質のバランスを調整できます。

**'setViewerIncluded' は何のためにあり、いつ無効にすべきですか？**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) は埋め込みプレイヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレイヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンにソースフォントがない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) で指定したフォントに置き換えて、予期しないフォントフォールバックを回避します。