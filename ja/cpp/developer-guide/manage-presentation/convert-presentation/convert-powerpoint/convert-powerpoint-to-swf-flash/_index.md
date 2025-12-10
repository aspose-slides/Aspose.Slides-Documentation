---
title: C++ で PowerPoint プレゼンテーションを SWF Flash に変換
linktitle: PowerPoint から SWF へ
type: docs
weight: 80
url: /ja/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプル、高速で高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

The [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) class and [INotesCommentsLayoutingOptions ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)interface.  The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.
``` cpp
// ドキュメントディレクトリへのパスです。
    System::String dataDir = GetDataPath();

    // プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // プレゼンテーションとノート ページを保存します
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **よくある質問**

**SWFに非表示スライドを含めることはできますか？**

はい。 Use the [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) method in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). By default, hidden slides are not exported.

**圧縮や最終的なSWFサイズをどのように制御できますか？**

Use the [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) method and adjust [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) to balance file size and image fidelity.

**'set_ViewerIncluded' は何のためのもので、いつ使用すべきですか？**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) adds an embedded player UI (navigation controls, panels, search). Disable it if you plan to use your own player or need a bare SWF frame without UI.

**エクスポート先のマシンに元フォントが存在しない場合はどうなりますか？**

Aspose.Slides will substitute the font you specify via [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) to avoid an unintended fallback.