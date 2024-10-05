---
title: PowerPointをSWF Flashに変換
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "PowerPointを変換, プレゼンテーション, PowerPointをSWFへ, SWF Flash PPTをSWFへ, PPTXをSWFへ, Python"
description: "PythonでPowerPointプレゼンテーションをSWF Flashに変換"
---

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスによって公開された[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用すると、プレゼンテーション全体をSWFドキュメントに変換できます。また、[SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/)クラスと[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)インターフェースを使用することで、生成されたSWFにコメントを含めることもできます。以下の例は、SWFOptionsクラスが提供するオプションを使用してプレゼンテーションをSWFドキュメントに変換する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションとノートページの保存
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```