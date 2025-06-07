---
title: Python で PPTX を PPT に変換する
linktitle: PPTX を PPT に
type: docs
weight: 21
url: /ja/python-net/convert-pptx-to-ppt/
keywords:
- PPTX を PPT に
- PPTX を PPT に変換
- PowerPoint を変換
- プレゼンテーションを変換
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して PPTX を簡単に PPT に変換し、プレゼンテーションのレイアウトと品質を維持しながら PowerPoint 形式との互換性を確保します。"
---

## **概要**

この記事では、Pythonを使用してPPTX形式のPowerPointプレゼンテーションをPPT形式に変換する方法を説明します。以下のトピックが含まれます。

- PythonでPPTXをPPTに変換

## **PythonでPPTXをPPTに変換**

PPTXをPPTに変換するためのPythonサンプルコードについては、以下のセクション[**PPTXをPPTに変換**](#convert-pptx-to-ppt)を参照してください。これはPPTXファイルを読み込み、PPT形式で保存するだけです。異なる保存形式を指定することで、PPTXファイルをPDF、XPS、ODP、HTMLなど、他の多くの形式に保存することも可能です。これらの関連記事で説明されています。

- [PythonでPPTXをPDFに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [PythonでPPTXをXPSに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [PythonでPPTXをHTMLに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [PythonでPPTXをODPに変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [PythonでPPTXを画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTXをPPTに変換するには、ファイル名と保存形式を[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスの[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドに渡してください。以下のPythonコードサンプルでは、デフォルトのオプションを使用してPPTXからPPTへのプレゼンテーションを変換します。

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("presentation.pptx")

# PPTXプレゼンテーションをPPT形式で保存
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```