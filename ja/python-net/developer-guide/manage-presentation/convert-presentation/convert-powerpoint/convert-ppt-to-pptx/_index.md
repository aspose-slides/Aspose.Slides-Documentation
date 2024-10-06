---
title: PPTをPythonでPPTXに変換
linktitle: PPTをPPTXに変換
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords: "Python PPTをPPTXに変換, PowerPointプレゼンテーションを変換, PPTをPPTX, Python, Aspose.Slides"
description: "PythonでPowerPoint PPTをPPTXに変換"
---

## **概要**

この記事では、PPT形式のPowerPointプレゼンテーションをPythonを用いてPPTX形式に変換する方法と、オンラインのPPTからPPTXへの変換アプリについて説明します。以下のトピックが含まれます。

- PythonでPPTをPPTXに変換

## **PythonでPPTをPPTXに変換**

PPTをPPTXに変換するためのPythonサンプルコードについては、以下のセクションを参照してください。[PPTをPPTXに変換](#convert-ppt-to-pptx)。これはPPTファイルを読み込み、PPTX形式で保存するだけです。異なる保存形式を指定することにより、PPTファイルをPDF、XPS、ODP、HTMLなどの他の多くの形式に保存することもできます。これについては、以下の記事で説明しています。

- [PythonでPPTをPDFに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [PythonでPPTをXPSに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [PythonでPPTをHTMLに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [PythonでPPTをODPに変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [PythonでPPTを画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
Aspose.Slides APIを使用して古いPPT形式をPPTXに変換します。数千のPPTプレゼンテーションをPPTX形式に変換する必要がある場合、最良の解決策はプログラムで行うことです。Aspose.Slides APIを使用すれば、わずか数行のコードで実現できます。APIはPPTプレゼンテーションをPPTXに変換するための完全な互換性をサポートしており、以下のことが可能です。

- マスター、レイアウト、スライドの複雑な構造を変換する。
- グラフを含むプレゼンテーションを変換する。
- グループシェイプ、オートシェイプ（長方形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- オートシェイプのテクスチャや画像塗りつぶしスタイルを持つプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを持つプレゼンテーションを変換する。

{{% alert color="primary" %}} 

[**Aspose.Slides PPTからPPTXへの変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは**Aspose.Slides API**に基づいて構築されており、基本的なPPTからPPTXへの変換機能の実例を見ることができます。Aspose.Slides ConversionはWebアプリで、PPT形式のプレゼンテーションファイルをドロップして、PPTXに変換してダウンロードすることができます。

他のライブ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)の例を見つけてください。
{{% /alert %}} 


## **PPTをPPTXに変換**
PPTをPPTXに変換するには、ファイル名と保存形式を[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドの[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスに渡します。以下のPythonコードサンプルは、デフォルトオプションを使用してPPTからPPTXへのプレゼンテーションの変換を行います。

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("PPTtoPPTX.ppt")

# PPTX形式でPPTXプレゼンテーションを保存
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[**PPTとPPTX**](/slides/ja/python-net/ppt-vs-pptx/)プレゼンテーション形式および[**Aspose.SlidesがPPTからPPTXへの変換をサポートする方法**](/slides/ja/python-net/convert-ppt-to-pptx/)についてさらに読む。