---
title: PowerPointをSWF Flashに変換
type: docs
weight: 80
url: /ja/net/convert-powerpoint-to-swf-flash/
keywords: "PowerPointを変換, プレゼンテーション, PowerPointをSWFに, SWFフラッシュ PPTをSWFに, PPTXをSWFに, C#, Csharp, .NET"
description: "C#または.NETでPowerPointプレゼンテーションをSWF Flashに変換"
---

## **プレゼンテーションをFlashに変換**

[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスによって提供され、プレゼンテーション全体を SWF ドキュメントに変換するために使用できます。[SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) クラスと[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) インターフェイスを使用すると、生成された SWF にコメントを含めることもできます。以下の例は、SWFOptions クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
```c#
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
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

はい。[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/) の[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) オプションを有効にしてください。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

[Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) フラグ（デフォルトで有効）を使用し、[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'ViewerIncluded' は何のためにあり、いつ無効にすべきですか？**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンに元のフォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) の[DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/)で指定したフォントで置き換えを行い、意図しないフォント置換を防ぎます。