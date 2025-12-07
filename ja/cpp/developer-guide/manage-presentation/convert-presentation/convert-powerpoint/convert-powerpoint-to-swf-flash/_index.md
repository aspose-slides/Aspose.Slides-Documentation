---
title: C++でPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPoint を SWF に変換
type: docs
weight: 80
url: /ja/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプル、高速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスで提供される [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用すると、プレゼンテーション全体を SWF ドキュメントに変換できます。 [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) クラスと [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) インターフェイスを使用すると、生成された SWF にコメントを含めることもできます。 以下の例は、[SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
``` cpp
// ドキュメントディレクトリへのパスです。
    System::String dataDir = GetDataPath();

    // プレゼンテーションファイルを表す Presentation オブジェクトを作成します
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // プレゼンテーションとノートページを保存します
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。[SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) の [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) メソッドを使用します。既定では非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

[set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) メソッドを使用し、[JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'set_ViewerIncluded' の用途は何ですか？また、いつ使用すべきですか？**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート先のマシンで元フォントが見つからない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) で指定したフォントに置き換えて、意図しないフォントフォールバックを回避します。