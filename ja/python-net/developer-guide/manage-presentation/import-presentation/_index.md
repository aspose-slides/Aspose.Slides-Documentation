---
title: Python でプレゼンテーションをインポートする
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/python-net/import-presentation/
keywords:
- PowerPoint をインポート
- プレゼンテーションをインポート
- スライドをインポート
- PDF をプレゼンテーションに
- PDF を PPT に
- PDF を PPTX に
- PDF を ODP に
- HTML をプレゼンテーションに
- HTML を PPT に
- HTML を PPTX に
- HTML を ODP に
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PDF および HTML ドキュメントを手間なく PowerPoint および OpenDocument プレゼンテーションにインポートし、高性能なスライド処理を実現する方法をご紹介します。"
---

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slidesは、PDF、HTMLドキュメントなどからプレゼンテーションをインポートするための[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)クラスを提供します。

## **PDFからPowerPointのインポート**

この場合、PDFをPowerPointプレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. プレゼンテーションクラスのオブジェクトをインスタンス化します。 
2. `add_from_pdf`メソッドを呼び出し、PDFファイルを渡します。 
3. `save`メソッドを使用して、ファイルをPowerPoint形式で保存します。

このPythonコードは、PDFからPowerPointへの操作を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="ヒント" color="primary" %}} 

ここで説明されているプロセスのライブ実装である**Aspose無料**[PDFからPowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)ウェブアプリをチェックしてみてください。 

{{% /alert %}} 

## **HTMLからPowerPointのインポート**

この場合、HTMLドキュメントをPowerPointプレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。 
2. `add_from_html`メソッドを呼び出し、HTMLファイルを渡します。 
3. `save`メソッドを使用して、ファイルをPowerPointドキュメントとして保存します。

このPythonコードは、HTMLからPowerPointへの操作を示しています： 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesを使用してHTMLを他の一般的なファイル形式に変換することもできます： 

* [HTMLから画像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}