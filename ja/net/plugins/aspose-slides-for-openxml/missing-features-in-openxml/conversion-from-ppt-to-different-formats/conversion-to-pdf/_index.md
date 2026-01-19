---
title: PDF への変換
type: docs
weight: 30
url: /ja/net/conversion-to-pdf/
---

PDF ドキュメントは、組織、政府部門、個人間で文書を交換する標準フォーマットとして広く使用されています。人気のあるフォーマットであるため、開発者は Microsoft PowerPoint のプレゼンテーション ファイルを PDF ドキュメントに変換するよう依頼されることがよくあります。このような要件を想定し、Aspose.Slides for .NET は他のコンポーネントを使用せずにプレゼンテーションを PDF ドキュメントに変換することをサポートしています。

**Aspose.Slides for .NET** は、プレゼンテーション ファイルを表す Presentation クラスを提供します。**Presentation** クラスは、プレゼンテーション全体を **PDF** ドキュメントに変換できる Save メソッドを公開しています。**PdfOptions** クラスは、JpegQuality、TextCompression、Compliance など、**PDF** 作成のためのオプションを提供します。これらのオプションを使用して、目的とする PDF の標準を実現できます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Save the presentation to PDF with default options

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)