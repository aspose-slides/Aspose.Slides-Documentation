---
title: PowerPointをSWF Flashに変換する
type: docs
weight: 80
url: /ja/cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Aspose.Slides APIを使用してPowerPoint PPT、PPTXをSWF Flash形式に変換します。"
---

[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドは、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスによって公開されており、プレゼンテーション全体をSWFドキュメントに変換するために使用できます。また、[SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options)クラスと[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)インターフェイスを使用して、生成されたSWFにコメントを含めることもできます。以下の例は、SWFOptionsクラスで提供されているオプションを使用してプレゼンテーションをSWFドキュメントに変換する方法を示しています。

``` cpp
// ドキュメントディレクトリへのパス
    System::String dataDir = GetDataPath();

    // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // プレゼンテーションとノートページを保存
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```