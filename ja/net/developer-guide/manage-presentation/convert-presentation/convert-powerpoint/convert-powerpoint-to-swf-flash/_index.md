---
title: PowerPointをSWFフラッシュに変換する
type: docs
weight: 80
url: /ja/net/convert-powerpoint-to-swf-flash/
keywords: "PowerPointの変換, プレゼンテーション, PowerPointからSWF, SWFフラッシュPPTからSWF, PPTXからSWF, C#, Csharp, .NET"
description: "C#または.NETでPowerPointプレゼンテーションをSWFフラッシュに変換する"
---

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスが公開する[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドを使用して、全体のプレゼンテーションをSWFドキュメントに変換できます。生成されたSWFにコメントを含めるには、[SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions)クラスと[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)インターフェースを使用できます。以下の例は、SWFOptionsクラスによって提供されるオプションを使用してプレゼンテーションをSWFドキュメントに変換する方法を示しています。

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // プレゼンテーションとノートページを保存する
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```