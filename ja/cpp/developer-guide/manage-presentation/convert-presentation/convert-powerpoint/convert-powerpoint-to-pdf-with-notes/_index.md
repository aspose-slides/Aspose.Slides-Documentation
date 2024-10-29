---
title: PowerPointをノート付きでPDFに変換する
type: docs
weight: 50
url: /ja/cpp/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPointをノート付きでPDFに変換する"
description: "PowerPointをノート付きでPDFに変換します。Aspose.SlidesでPPTとPPTXをノート付きでPDFに変換します。"
---

Presentationクラスによって公開されている[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドは、PowerPoint PPTまたはPPTXプレゼンテーションをノート付きでPDFに変換するために使用できます。Aspose.Slides for C++を使用して、Microsoft PowerPointプレゼンテーションをノート付きのPDFに保存するのは2行のプロセスです。プレゼンテーションを開いて、それをノート付きのPDFとして保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューのPDFに更新します：

``` cpp
// ドキュメントディレクトリへのパス。
String dataDir = GetDataPath();

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// スライドのタイプとサイズを設定 
//auxPresentation->get_SlideSize()->SetSize(presentation->get_SlideSize()->get_Size().get_Width(), presentation->get_SlideSize()->get_Size().get_Height(), SlideSizeScaleType::EnsureFit);
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
pdfOptions->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```



{{% alert color="primary" %}} 

Asposeの[PowerPointをPDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)や[PPTをPDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)コンバータをチェックしてみてください。 

{{% /alert %}} 