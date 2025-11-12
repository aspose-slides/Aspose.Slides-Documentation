---
title: Pythonでプレゼンテーションをインポート
linktitle: プレゼンテーションインポート
type: docs
weight: 60
url: /ja/python-net/import-presentation/
keywords:
- PowerPoint をインポート
- プレゼンテーションをインポート
- スライドをインポート
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
description: "Aspose.Slides を使用して、Python で PDF および HTML ドキュメントを PowerPoint および OpenDocument のプレゼンテーションにシームレスかつ高速にインポートします。"
---

## **概要**

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) を使用すると、他のファイル形式からプレゼンテーションにコンテンツをインポートできます。[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスは、PDF、HTML などのソースからスライドをインポートするメソッドを提供します。

## **PDF をプレゼンテーションに変換する**

このセクションでは、Aspose.Slides を使用して PDF をプレゼンテーションに変換する方法を示します。PDF をインポートし、ページをスライドに変換し、結果を PPTX ファイルとして保存する手順を解説します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. `add_from_pdf` メソッドを呼び出し、PDF ファイルを指定します。  
3. `save` メソッドを使用して、プレゼンテーションを PowerPoint 形式で保存します。

以下の Python サンプルは、PDF をプレゼンテーションに変換する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ヒント" color="primary" %}}
**Aspose の無料** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリを試してみてください。ここで説明したプロセスのライブ実装です。
{{% /alert %}}

## **HTML をプレゼンテーションに変換する**

このセクションでは、Aspose.Slides を使用して HTML コンテンツをプレゼンテーションにインポートする方法を示します。HTML を読み込み、テキスト・画像・基本的な書式を保持したままスライドに変換し、PPTX ファイルとして保存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. `add_from_html` メソッドを呼び出し、HTML ファイルを指定します。  
3. `save` メソッドを使用して、プレゼンテーションを PowerPoint 形式で保存します。

以下の Python サンプルは、HTML をプレゼンテーションに変換する例です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**PDF をインポートする際にテーブルは保持されますか？また、テーブル検出を改善できますか？**

インポート時にテーブルを検出できます。`PdfImportOptions` の `detect_tables` パラメータを有効にするとテーブル認識が行われます。効果は PDF の構造に依存します。

{{% alert title="注" color="info" %}}
Aspose.Slides を使用して HTML を以下の他の一般的なファイル形式に変換することもできます：

* [HTML から画像へ](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}