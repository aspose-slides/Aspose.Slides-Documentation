---
title: ".NET で PDF や HTML からプレゼンテーションをインポート"
linktitle: "プレゼンテーションのインポート"
type: docs
weight: 60
url: /ja/net/import-presentation/
keywords:
  - "プレゼンテーションのインポート"
  - "スライドのインポート"
  - "PDF のインポート"
  - "HTML のインポート"
  - "PDF からプレゼンテーションへ"
  - "PDF から PPT へ"
  - "PDF から PPTX へ"
  - "PDF から ODP へ"
  - "HTML からプレゼンテーションへ"
  - "HTML から PPT へ"
  - "HTML から PPTX へ"
  - "HTML から ODP へ"
  - "PowerPoint"
  - "OpenDocument"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "PDF と HTML ドキュメントを .NET の Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションにシームレスかつ高パフォーマンスでインポートできます。"
---

Aspose.Slides for .NET を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、PDF ドキュメントからプレゼンテーションをインポートできるようにする [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) クラスを提供しています。

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) メソッドを呼び出し、PDF ファイルを渡します。 
3. [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この C# コードは PDF から PowerPoint への変換操作を示しています:
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
ここで説明したプロセスのライブ実装である **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリをチェックすると良いでしょう。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) メソッドを呼び出し、HTML ファイルを渡します。 
3. [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint ドキュメントとして保存します。

この C# コードは HTML から PowerPoint への変換操作を示しています: 
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

**PDF をインポートする際にテーブルは保持されますか、検出を改善できますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) にはテーブル認識を有効にする [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) パラメータが含まれています。有効性は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 

Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます: 

* [HTML to image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}