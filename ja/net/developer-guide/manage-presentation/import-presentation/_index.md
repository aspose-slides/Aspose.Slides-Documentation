---
title: PDFまたはHTMLからPowerPointをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /net/import-presentation/
keywords: "PowerPointのインポート, PDFからPowerPoint, HTMLからPowerPoint, PDFからPPT, HTMLからPPT, C#, Csharp, Aspose.Slides for .NET"
description: "PDFまたはHTMLからPowerPointをインポートします。PDFをPowerPointに変換します。HTMLをPowerPointに変換します。"
---

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slidesは、PDFドキュメントからプレゼンテーションをインポートするために[SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/)クラスを提供します。

## **PDFからPowerPointをインポート**

この場合、PDFをPowerPointプレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1)メソッドを呼び出し、PDFファイルを渡します。
3. [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5)メソッドを使用してファイルをPowerPoint形式で保存します。

このC#コードは、PDFからPowerPointへの操作を示しています：

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="ヒント" color="primary" %}} 

ここで説明したプロセスのライブ実装である**Aspose無料** [PDFからPowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)ウェブアプリをチェックすることをお勧めします。 

{{% /alert %}} 

## **HTMLからPowerPointをインポート**

この場合、HTMLドキュメントをPowerPointプレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml)メソッドを呼び出し、HTMLファイルを渡します。
3. [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5)メソッドを使用してファイルをPowerPointドキュメントとして保存します。

このC#コードは、HTMLからPowerPointへの操作を示しています： 

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

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesを使用して、HTMLを他の人気のファイル形式に変換することもできます： 

* [HTMLから画像](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}