---
title: 注釈付きでPowerPointをPDFに変換
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPoint変換, プレゼンテーション, PowerPointをPDFに, 注釈, Python, Aspose.Slides"
description: "Pythonを使用して注釈付きでPowerPointをPDFに変換"
---

Presentationクラスによって公開されている[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、PowerPoint PPTまたはPPTXプレゼンテーションを注釈付きPDFに変換できます。Aspose.Slides for Pythonを使用してMicrosoft PowerPointプレゼンテーションを注釈付きPDFに保存するのは、2行のプロセスです。プレゼンテーションを開いて、注釈付きPDFとして保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションを注釈スライドビューのPDFに更新します：

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトのインスタンスを作成
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# スライドのタイプとサイズを設定
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

Asposeの[PowerPointをPDFに](https://products.aspose.app/slides/conversion)や[PPTをPDFに](https://products.aspose.app/slides/conversion/ppt-to-pdf)変換ツールをチェックしてみることをお勧めします。

{{% /alert %}}