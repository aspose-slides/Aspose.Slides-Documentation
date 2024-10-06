---
title: C#でPPTXをPPTに変換
linktitle: PPTXをPPTに変換
type: docs
weight: 21
url: /ja/net/convert-pptx-to-ppt/
keywords: "C# PPTXをPPTに変換, PowerPointプレゼンテーションを変換, PPTXをPPT, C#, Aspose.Slides"
description: "C#でPowerPoint PPTXをPPTに変換"
---

## **概要**

この記事では、C#を使用してPPTX形式のPowerPointプレゼンテーションをPPT形式に変換する方法について説明します。以下のトピックが扱われます。

- C#でPPTXをPPTに変換

## **C#でPPTXをPPTに変換**

PPTXをPPTに変換するためのC#サンプルコードについては、以下の[Convert PPTX to PPT](#convert-pptx-to-ppt)のセクションを参照してください。これは、PPTXファイルを読み込み、PPT形式で保存するだけです。異なる保存形式を指定することで、PPTXファイルをPDF、XPS、ODP、HTMLなど多くの他の形式に保存することもできます。これらの記事で議論されています。

- [C#でPPTXをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C#でPPTXをXPSに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C#でPPTXをHTMLに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C#でPPTXをODPに変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C#でPPTXを画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTXをPPTに変換するには、[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスの[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドにファイル名と保存形式を渡すだけです。以下のC#コードサンプルは、デフォルトオプションを使用してPPTXからPPTにプレゼンテーションを変換します。

```c#
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presentation.pptx");

// PPTXプレゼンテーションをPPT形式で保存
pres.Save("presentation.ppt", SaveFormat.Ppt);
```