---
title: .NET で PDF または HTML からプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/net/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDF のインポート
- HTML のインポート
- PDF からプレゼンテーションへの変換
- PDF から PPT への変換
- PDF から PPTX への変換
- PDF から ODP への変換
- HTML からプレゼンテーションへの変換
- HTML から PPT への変換
- HTML から PPTX への変換
- HTML から ODP への変換
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して、.NET で PDF および HTML ドキュメントを PowerPoint および OpenDocument のプレゼンテーションにシームレスかつ高パフォーマンスでインポートし、スライド処理を容易に行います。"
---
## **イントロダクション**

Aspose.Slides を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF および HTML ドキュメントからプレゼンテーションをインポートできる [SlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/slidecollection/) クラスを提供します。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. [AddFromPdf](https://reference.aspose.com/slides/ja/net/aspose.slides.slidecollection/addfrompdf/methods/1) メソッドを呼び出し、PDF ファイルを渡します。 
3. [Save](https://reference.aspose.com/slides/ja/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この C# コードは PDF から PowerPoint への変換を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
**Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) ウェブアプリをチェックするとよいでしょう。このアプリは、ここで説明したプロセスの実際の実装です。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. [AddFromHtml](https://reference.aspose.com/slides/ja/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) メソッドを呼び出し、HTML ファイルを渡します。 
3. [Save](https://apireference.aspose.com/slides/ja/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint ドキュメントとして保存します。

この C# コードは HTML から PowerPoint への変換を示しています： 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### PDF をインポートする際にテーブルは保持されますか？また、その検出を改善できますか？

インポート時にテーブルを検出できます。PdfImportOptions にはテーブル認識を有効にする [DetectTables](https://reference.aspose.com/slides/ja/net/aspose.slides.import/pdfimportoptions/detecttables/) パラメーターが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 
また、Aspose.Slides を使用して HTML を他の一般的なファイル形式に変換することもできます。 

* [HTML を画像に変換](https://products.aspose.com/slides/ja/net/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/ja/net/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/ja/net/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/ja/net/conversion/html-to-tiff/)

{{% /alert %}}