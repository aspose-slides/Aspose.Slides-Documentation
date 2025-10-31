---
title: PythonでPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPointからSWF Flashへ
type: docs
weight: 80
url: /ja/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PowerPointからSWF
- プレゼンテーションからSWF
- スライドからSWF
- PPTからSWF
- PPTXからSWF
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slidesを使用してPythonでPowerPoint（PPT/PPTX）をSWF Flashに変換します。ステップバイステップのコードサンプル、高速で高品質な出力、PowerPointの自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

[保存](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供し、プレゼンテーション全体を SWF ドキュメントに変換するために使用できます。  また、[SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) クラスと [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) インターフェイスを使用して、生成された SWF にコメントを含めることもできます。  以下の例は、SWFOptions クラスが提供するオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションとノートページを保存する
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**SWFに非表示スライドを含めることはできますか？**

はい。SwfOptions の [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) オプションを有効にしてください。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的なSWFサイズをどのように制御できますか？**

[compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) フラグ（デフォルトで有効）を使用し、[jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'viewer_included' は何のためのものですか、またいつ無効にすべきですか？**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポートマシンに元フォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) で指定したフォントに置き換えて、予期しないフォントフォールバックを防ぎます。