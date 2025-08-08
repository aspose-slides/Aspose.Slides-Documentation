---
title: Python で OpenDocument プレゼンテーションを変換
linktitle: OpenDocument を変換
type: docs
weight: 10
url: /ja/python-net/convert-openoffice-odp/
keywords:
- OpenDocument を変換
- ODP を変換
- ODP を PDF に変換
- ODP を PPT に変換
- ODP を PPTX に変換
- ODP を XPS に変換
- ODP を HTML に変換
- ODP を TIFF に変換
- ODP を SWF に変換
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides を使用して OpenDocument の ODP を PDF、PPT、PPTX、XPS、HTML、TIFF、SWF に変換: コード例、高い忠実度、一括変換、カスタマイズ。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) は、OpenOffice ODPプレゼンテーションを多くの形式に変換することを可能にします。ODPファイルを他のドキュメント形式に変換するために使用されるAPIは、PowerPoint（PPTおよびPPTX）の変換操作に使用されるものと同じです。

以下の例では、ODP文書を他の形式に変換する方法を示します（ソースODPファイルを変更するだけです）：

- [ODPをHTMLに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODPをPDFに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODPをTIFFに変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)
- [ODPをSWF Flashに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODPをXPSに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODPをノート付きPDFに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODPをノート付きTIFFに変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例えば、ODPプレゼンテーションをPDFに変換する必要がある場合、次のように行うことができます：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```