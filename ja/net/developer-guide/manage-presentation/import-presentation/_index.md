---
title: PDF または HTML から PowerPoint をインポート
linktitle: プレゼンテーションをインポート
type: docs
weight: 60
url: /ja/net/import-presentation/
keywords: "PowerPoint のインポート, PDF から PowerPoint, HTML から PowerPoint, PDF から PPT, HTML から PPT, C#, Csharp, Aspose.Slides for .NET"
description: "PDF または HTML から PowerPoint をインポートします。PDF を PowerPoint に変換します。HTML を PowerPoint に変換します"
---

Using [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) class to allow you to import presentations from PDF documents.

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
このプロセスの実装例として、**Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリを確認すると便利です。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) メソッドを呼び出し、HTML ファイルを渡します。 
3. [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) メソッドを使用して、ファイルを PowerPoint ドキュメントとして保存します。

この C#コードは HTML から PowerPoint への変換操作を示しています: 
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

**PDF をインポートする際にテーブルは保持されますか、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) にはテーブル認識を有効にする [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) パラメータが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます：

* [HTML から画像](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML から JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML から XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML から TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}