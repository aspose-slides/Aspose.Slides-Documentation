---
title: .NET で PowerPoint プレゼンテーションを SWF Flash に変換
linktitle: PowerPoint を SWF に変換
type: docs
weight: 80
url: /ja/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を SWF に変換
- プレゼンテーションを SWF に変換
- スライドを SWF に変換
- PPT を SWF に変換
- PPTX を SWF に変換
- PowerPoint を Flash に変換
- プレゼンテーションを Flash に変換
- スライドを Flash に変換
- PPT を Flash に変換
- PPTX を Flash に変換
- PPT を SWF として保存
- PPTX を SWF として保存
- PPT を SWF にエクスポート
- PPTX を SWF にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップの C# コードサンプル、高速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

Presentation クラスが公開する [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドを使用すると、プレゼンテーション全体を SWF ドキュメントに変換できます。 また、[SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) クラスと [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) インターフェイスを使用して、生成された SWF にコメントを含めることもできます。 以下の例は、SWFOptions クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // プレゼンテーションとノートページを保存します
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。 [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/) の [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) オプションを有効にしてください。 デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF のサイズをどのように制御できますか？**

デフォルトで有効になっている [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) フラグを使用し、[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'ViewerIncluded' は何のためにあり、いつ無効にすべきですか？**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。 独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンに元フォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) で指定したフォントを代替フォントとして使用し、意図しないフォールバックを防ぎます。