---
title: .NET で PDF または HTML からプレゼンテーションをインポート
linktitle: プレゼンテーションをインポート
type: docs
weight: 60
url: /ja/net/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDF のインポート
- HTML のインポート
- PDF からプレゼンテーションへ
- PDF から PPT へ
- PDF から PPTX へ
- PDF から ODP へ
- HTML からプレゼンテーションへ
- HTML から PPT へ
- HTML から PPTX へ
- HTML から ODP へ
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: ".NET で Aspose.Slides を使用し、PDF と HTML ドキュメントを PowerPoint および OpenDocument プレゼンテーションにシームレスかつ高性能にスライド処理できるよう、簡単にインポートします。"
---

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF ドキュメントからプレゼンテーションをインポートできるようにするために、[SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) クラスを提供します。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) メソッドを呼び出し、PDF ファイルを渡します。  
3. [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この C# コードは PDF から PowerPoint への変換を示しています。
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
ここで説明したプロセスのライブ実装である **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリを確認したいかもしれません。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML 文書を PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) メソッドを呼び出し、HTML ファイルを渡します。  
3. [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint ドキュメントとして保存します。

この C# コードは HTML から PowerPoint への変換を示しています。 
```c#
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

**PDF をインポートする際にテーブルは保持されますか？また、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) にはテーブル認識を有効にする [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) パラメータが含まれています。有効性は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 

また、Aspose.Slides を使用して HTML を他の一般的なファイル形式に変換することもできます：

* [HTML を画像に変換](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}