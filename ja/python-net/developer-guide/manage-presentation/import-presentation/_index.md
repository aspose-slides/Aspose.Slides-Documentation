---
title: Pythonでプレゼンテーションをインポート
linktitle: プレゼンテーションをインポート
type: docs
weight: 60
url: /ja/python-net/import-presentation/
keywords:
- PowerPointをインポート
- プレゼンテーションをインポート
- スライドをインポート
- PDFからプレゼンテーションへ
- PDFからPPTへ
- PDFからPPTXへ
- PDFからODPへ
- HTMLからプレゼンテーションへ
- HTMLからPPTへ
- HTMLからPPTXへ
- HTMLからODPへ
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PDF および HTML ドキュメントを PowerPoint と OpenDocument のプレゼンテーションにシームレスかつ高性能にインポートし、スライド処理を容易にします。"
---

## **概要**

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、他のファイル形式からプレゼンテーションへコンテンツをインポートできます。[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスは、PDF、HTML、その他のソースからスライドをインポートするメソッドを提供します。

## **PDF をプレゼンテーションに変換**

このセクションでは、Aspose.Slides を使用して PDF をプレゼンテーションに変換する方法を示します。PDF のインポート、ページをスライドに変換し、結果を PPTX ファイルとして保存する手順を解説します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) メソッドを呼び出し、PDF ファイルを指定します。
3. [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを使用して、プレゼンテーションを PowerPoint 形式で保存します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}

**Aspose の無料** [PDF を PowerPoint に変換](https://products.aspose.app/slides/import/pdf-to-powerpoint) ウェブアプリを試してみてもよいでしょう。これはここで説明したプロセスのライブ実装です。

{{% /alert %}}

## **HTML をプレゼンテーションに変換**

このセクションでは、Aspose.Slides を使用して HTML コンテンツをプレゼンテーションにインポートする方法を示します。HTML の読み込み、テキスト、画像、基本的な書式を保持したままスライドに変換し、結果を PPTX ファイルとして保存する手順を解説します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) メソッドを呼び出し、HTML ファイルを指定します。
3. [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを使用して、プレゼンテーションを PowerPoint 形式で保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**PDF をインポートする際にテーブルは保持されますか？また、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) にはテーブル認識を有効にする [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) パラメータが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="info" %}}

Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます:
* [HTML を画像に変換](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML を JPG に変換](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML を XML に変換](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML を TIFF に変換](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}