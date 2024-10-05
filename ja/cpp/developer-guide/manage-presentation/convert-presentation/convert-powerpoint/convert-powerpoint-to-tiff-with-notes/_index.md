---
title: メモ付きPowerPointをTIFFに変換
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "メモ付きPowerPointをTIFFに変換"
description: "Aspose.Slidesを使用してメモ付きPowerPointをTIFFに変換します。"
---

TIFFは、Aspose.Slides for C++がメモ付きPowerPoint PPTおよびPPTXプレゼンテーションを画像に変換するためにサポートする広く使用されているいくつかの画像形式の1つです。また、ノートスライドビューでスライドのサムネイルを生成することもできます。[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドは、プレゼンテーションクラスによって公開されており、ノートスライドビューの全プレゼンテーションをTIFFに変換するために使用できます。Aspose.Slides for C++を使用してMicrosoft PowerPointプレゼンテーションをTIFFメモに保存するのは、2行のプロセスです。プレゼンテーションを開いて、TIFFメモとして保存するだけです。また、個々のスライドに対してノートスライドビューでスライドのサムネイルを生成することもできます。以下のコードスニペットは、ノートスライドビューでTIFF画像にサンプルプレゼンテーションを更新する方法を示しています：

``` cpp
// ドキュメントディレクトリへのパス。
System::String dataDir = GetDataPath();

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// プレゼンテーションをTIFFメモに保存
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスター変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)もぜひチェックしてみてください。

{{% /alert %}}