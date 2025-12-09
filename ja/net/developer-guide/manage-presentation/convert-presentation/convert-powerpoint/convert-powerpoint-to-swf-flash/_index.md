---
title: PowerPoint プレゼンテーションを .NET で SWF Flash に変換
linktitle: PowerPoint から SWF
type: docs
weight: 80
url: /ja/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint の変換
- プレゼンテーションの変換
- スライドの変換
- PPT の変換
- PPTX の変換
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
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップの C# コードサンプル、迅速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換する**

Presentation クラスで公開されている [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドを使用すると、プレゼンテーション全体を SWF ドキュメントに変換できます。 [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) クラスと [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) インターフェイスを使用して、生成された SWF にコメントを含めることも可能です。 以下の例は、[SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // プレゼンテーションとノートページを保存
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **FAQ**

**SWF に非表示スライドを含めることはできますか？**

はい。 [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) の [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) オプションを有効にします。 デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF のサイズをどのように制御できますか？**

デフォルトで有効になっている [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) フラグを使用し、[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'ViewerIncluded' は何のためのもので、いつ無効にすべきですか？**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) は埋め込みプレーヤーの UI（ナビゲーションコントロール、パネル、検索）を追加します。 独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンにソースフォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) で指定したフォントに置き換えて、意図しないフォントフォールバックを防ぎます。