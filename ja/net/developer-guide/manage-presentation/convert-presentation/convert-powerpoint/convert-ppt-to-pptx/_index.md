---
title: C#でPPTをPPTXに変換
linktitle: C#でPPTをPPTXに変換
type: docs
weight: 20
url: /net/convert-ppt-to-pptx/
keywords: "C# PPTをPPTXに変換, PowerPointプレゼンテーションを変換, PPTからPPTX, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPoint PPTをPPTXに変換"
---

## **概要**

この記事では、C#を使用してPPT形式のPowerPointプレゼンテーションをPPTX形式に変換する方法を説明します。また、オンラインのPPTからPPTXへの変換アプリについても触れます。以下のトピックがカバーされています。

- [C#でPPTをPPTXに変換](#convert-ppt-to-pptx)

## **C#でPPTをPPTXに変換**

PPTをPPTXに変換するためのC#のサンプルコードについては、以下のセクションを参照してください。すなわち、[C#でPPTをPPTXに変換](#convert-ppt-to-pptx)です。これはPPTファイルを読み込み、PPTX形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTMLなどの他の多くの形式にPPTファイルを保存することも可能です。これらの記事で説明されています。

- [C#でPPTをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C#でPPTをXPSに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C#でPPTをHTMLに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C#でPPTをODPに変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C#でPPTを画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
古いPPT形式をAspose.Slides APIを使用してPPTXに変換します。数千のPPTプレゼンテーションをPPTX形式に変換する必要がある場合、最良の解決策はプログラム的に行うことです。Aspose.Slides APIを使用すれば、数行のコードで行うことができます。このAPIは、PPTプレゼンテーションをPPTXに変換するための完全な互換性をサポートしており、次のことが可能です：

- マスター、レイアウト、およびスライドの複雑な構造を変換。
- チャートを含むプレゼンテーションを変換。
- グループ形状、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つ形状を含むプレゼンテーションを変換。
- オートシェイプのテクスチャとピクチャフィルスタイルを持つプレゼンテーションを変換。
- プレースホルダー、テキストフレーム、およびテキストホルダーを持つプレゼンテーションを変換。

{{% alert color="primary" %}} 

[**Aspose.Slides PPTからPPTXへの変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは**Aspose.Slides API**に基づいて構築されているため、基本的なPPTからPPTXへの変換機能の生きた例を見ることができます。Aspose.Slides ConversionはWebアプリで、PPT形式のプレゼンテーションファイルをドロップしてPPTXに変換してダウンロードすることができます。

他の生きた[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)の例を見つけてください。
{{% /alert %}} 


## **PPTをPPTXに変換**
PPTをPPTXに変換するには、ファイル名と保存形式を[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスの[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドに渡します。以下のC#コードサンプルは、デフォルトのオプションを使用してPPTからPPTXにプレゼンテーションを変換します。

```c#
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX形式でPPTXプレゼンテーションを保存
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


[**PPTとPPTX**](/slides/net/ppt-vs-pptx/)プレゼンテーション形式の詳細および[**Aspose.SlidesがPPTからPPTXへの変換をサポートする方法**](/slides/net/convert-ppt-to-pptx/)についてもっと読む。