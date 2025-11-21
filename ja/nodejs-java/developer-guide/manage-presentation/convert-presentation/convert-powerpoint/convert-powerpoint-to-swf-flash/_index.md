---
title: PowerPoint を SWF フラッシュに変換
type: docs
weight: 80
url: /ja/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT、PPTX を SWF に変換"
description: "JavaScript で PowerPoint PPT、PPTX を SWF に変換"
---

## **PPT(X) を SWF に変換**
The [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) メソッドは [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスで公開されており、プレゼンテーション全体を **SWF** ドキュメントに変換するために使用できます。以下の例では、[**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) クラスが提供するオプションを使用してプレゼンテーションを **SWF** ドキュメントに変換する方法を示します。生成された SWF にコメントを含めるには、[**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) クラスと [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) クラスを使用することもできます。
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // プレゼンテーションを保存
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。[setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) メソッドを[SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/)で使用します。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

ファイルサイズと画像品質のバランスを取るために、[setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) メソッドと [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) を使用します。

**'setViewerIncluded' の目的は何ですか、またいつ使用すべきですか？**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する予定がある場合や、UI のないシンプルな SWF フレームが必要な場合に使用してください。

**エクスポート先のマシンでソースフォントが見つからない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) の [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) で指定したフォントに置き換えて、意図しないフォールバックを回避します。