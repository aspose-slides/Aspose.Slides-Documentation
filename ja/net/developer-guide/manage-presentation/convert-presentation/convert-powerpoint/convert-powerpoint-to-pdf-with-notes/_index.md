---
title: C#でノート付きのPowerPointをPDFに変換
linktitle: ノート付きのPowerPointをPDFに変換
type: docs
weight: 50
url: /net/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPoint変換, プレゼンテーション, PowerPointをPDFに, ノート, c#, csharp, .NET, Aspose.Slides"
description: "C#または.NETを使用してノート付きのPowerPointをPDFに変換"
---

## **概要**

[PowerPointをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)する際に、エクスポートされたドキュメント内にノートやコメントがどのように配置されるかを制御することもできます。以下のトピックが含まれています。

- [C# PPTをPDFにノート付きで変換](#convert-powerpoint-to-pdf-with-notes)
- [C# PPTXをPDFにノート付きで変換](#convert-powerpoint-to-pdf-with-notes)
- [C# ODPをPDFにノート付きで変換](#convert-powerpoint-to-pdf-with-notes)
- [C# ノート付きのPowerPointをPDFに変換](#convert-powerpoint-to-pdf-with-notes)

## **ノート付きのPowerPointをPDFに変換**

Presentationクラスが公開している[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドを使用して、PowerPoint PPTまたはPPTXプレゼンテーションをノート付きでPDFに変換できます。Aspose.Slides for .NETを使用してMicrosoft PowerPointプレゼンテーションをPDFノートとして保存するのは、2行のプロセスです。プレゼンテーションを開いてPDFノートとして保存するだけです。以下のC#コードスニペットは、サンプルプレゼンテーションをノートスライドビューのPDFに更新します：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// スライドのタイプとサイズを設定 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Asposeの[PowerPointをPDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)または[PPTをPDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)コンバーターをチェックすることをお勧めします。

{{% /alert %}}