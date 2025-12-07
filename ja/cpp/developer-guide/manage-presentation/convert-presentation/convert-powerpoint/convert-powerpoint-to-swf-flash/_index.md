---
title: C++でPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPointをSWFへ
type: docs
weight: 80
url: /ja/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "C++のAspose.SlidesでPowerPoint（PPT/PPTX）をSWF Flashに変換します。ステップバイステップのコードサンプル、迅速な高品質出力、PowerPointの自動化は不要です。"
---

## **プレゼンテーションを Flash に変換**

Presentation クラスで提供される [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用すると、プレゼンテーション全体を SWF ドキュメントに変換できます。また、[SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) クラスと [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) インターフェイスを使用して、生成された SWF にコメントを含めることもできます。以下の例は、SWFOptions クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
``` cpp
// ドキュメント ディレクトリへのパス。
    System::String dataDir = GetDataPath();

    // プレゼンテーション ファイルを表す Presentation オブジェクトを作成
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // プレゼンテーション と ノート ページを保存
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。[set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) メソッドを [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) で使用します。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズはどのように制御できますか？**

[set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) メソッドを使用し、[JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'set_ViewerIncluded' は何のためにあり、いつ使用すべきですか？**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンにソースフォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) で指定したフォントに置き換えて、意図しないフォントフォールバックを防ぎます。