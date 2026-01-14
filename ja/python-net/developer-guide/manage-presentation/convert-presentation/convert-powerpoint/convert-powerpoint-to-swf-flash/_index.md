---
title: PythonでPowerPointプレゼンテーションをSWF Flashに変換
linktitle: PowerPoint を SWF Flash に変換
type: docs
weight: 80
url: /ja/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PowerPoint to SWF
- プレゼンテーション to SWF
- スライド to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して PowerPoint (PPT/PPTX) を SWF Flash に変換します。ステップバイステップのコードサンプル、迅速かつ高品質な出力、PowerPoint の自動化は不要です。"
---

## **プレゼンテーションをFlashに変換**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスによって提供され、プレゼンテーション全体を SWF ドキュメントに変換するために使用できます。 [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) クラスと [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用すると、生成された SWF にコメントを含めることもできます。以下の例は、SWFOptions クラスで提供されるオプションを使用してプレゼンテーションを SWF ドキュメントに変換する方法を示しています。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saving presentation and notes pages
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```


## **よくある質問**

**SWFに非表示スライドを含められますか？**

はい。[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) の [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) オプションを有効にします。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズをどのように制御できますか？**

デフォルトで有効になっている [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) フラグを使用し、[jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) を調整してファイルサイズと画像品質のバランスを取ります。

**'viewer_included' は何のためにあり、いつ無効にすべきですか？**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) は埋め込みプレーヤー UI（ナビゲーションコントロール、パネル、検索）を追加します。独自のプレーヤーを使用する場合や UI のないシンプルな SWF フレームが必要な場合は無効にしてください。

**エクスポート環境にソースフォントが存在しない場合はどうなりますか？**

Aspose.Slides は、[SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) の [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) で指定したフォントを代替として使用し、予期しないフォールバックを回避します。