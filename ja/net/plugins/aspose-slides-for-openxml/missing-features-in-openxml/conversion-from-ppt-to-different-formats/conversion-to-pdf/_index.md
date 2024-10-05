---
title: PDF への変換
type: docs
weight: 30
url: /net/conversion-to-pdf/
---

PDF 文書は、組織、政府部門、個人間で文書を交換するための標準形式として広く使用されています。これは人気のある形式であり、開発者はしばしば Microsoft PowerPoint プレゼンテーションファイルを PDF 文書に変換するよう求められます。このような要件を実現するために、Aspose.Slides for .NET は、他のコンポーネントを使用することなくプレゼンテーションを PDF 文書に変換することをサポートしています。

**Aspose.Slides for .NET** は、プレゼンテーションファイルを表す Presentation クラスを提供しています。**Presentation** クラスは、全体のプレゼンテーションを **PDF** 文書に変換するために呼び出すことができる Save メソッドを公開しています。**PdfOptions** クラスは、JpegQuality、TextCompression、Compliance など、**PDF** を作成するためのオプションを提供します。これらのオプションを使用することで、所望の PDF 基準を得ることができます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "PDF への変換.pdf";

//プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化

Presentation pres = new Presentation(srcFileName);

//デフォルトオプションでプレゼンテーションを PDF に保存

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)