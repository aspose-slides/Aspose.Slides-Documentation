---
title: Python でプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/python-net/import-presentation/
keywords:
- PowerPoint のインポート
- プレゼンテーションのインポート
- スライドのインポート
- PDF からプレゼンテーションへ
- PDF から PPT へ
- PDF から PPTX へ
- PDF から ODP へ
- HTML からプレゼンテーションへ
- HTML から PPT へ
- HTML から PPTX へ
- HTML から ODP へ
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PDF および HTML 文書を PowerPoint や OpenDocument のプレゼンテーションにシームレスかつ高性能にインポートし、スライド処理を手軽に行えます。"
---

## **概要**

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、他のファイル形式からプレゼンテーションにコンテンツをインポートできます。 [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスは、PDF、HTML、その他のソースからスライドをインポートするメソッドを提供します。

## **PDF をプレゼンテーションに変換**

このセクションでは、Aspose.Slides を使用して PDF をプレゼンテーションに変換する方法を示します。PDF をインポートし、ページをスライドに変換し、結果を PPTX ファイルとして保存する手順を説明します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) メソッドを呼び出し、PDF ファイルを指定します。  
3. [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを使用して、PowerPoint 形式でプレゼンテーションを保存します。

以下の Python サンプルは、PDF をプレゼンテーションに変換する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert  title="Tip" color="primary" %}}
Aspose が提供する無料の [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリを試してみてください。ここで説明したプロセスのライブ実装です。
{{% /alert %}}

## **HTML をプレゼンテーションに変換**

このセクションでは、Aspose.Slides を使用して HTML コンテンツをプレゼンテーションにインポートする方法を示します。HTML を読み込み、テキスト、画像、基本的な書式を保持したままスライドに変換し、PPTX ファイルとして保存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) メソッドを呼び出し、HTML ファイルを指定します。  
3. [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを使用して、PowerPoint 形式でプレゼンテーションを保存します。

以下の Python サンプルは、HTML をプレゼンテーションに変換する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**PDF をインポートする際にテーブルは保持されますか？また、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) の [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) パラメータを有効にするとテーブル認識が行われます。効果は PDF の構造に依存します。

{{% alert title="Note" color="info" %}}
Aspose.Slides は、HTML を他の一般的なファイル形式に変換することもできます：

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}