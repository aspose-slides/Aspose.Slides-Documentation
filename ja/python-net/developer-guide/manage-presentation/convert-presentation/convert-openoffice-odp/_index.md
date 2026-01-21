---
title: PythonでOpenDocumentプレゼンテーションを変換
linktitle: OpenDocumentを変換
type: docs
weight: 10
url: /ja/python-net/convert-openoffice-odp/
keywords:
- OpenDocumentを変換
- ODPを変換
- ODPからPDFへ
- ODPからPPTへ
- ODPからPPTXへ
- ODPからXPSへ
- ODPからHTMLへ
- ODPからTIFFへ
- ODPからSWFへ
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PythonとAspose.Slidesを使用してOpenDocument ODPをPDF、PPT、PPTX、XPS、HTML、TIFF、またはSWFに変換します：コード例、高忠実度、バッチ変換、カスタマイズが可能です。"
---

## **ODP ファイルの変換**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) は、OpenDocument (ODP) プレゼンテーションを多数の形式 (HTML、PDF、TIFF、SWF、XPS など) に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint (PPT および PPTX) の変換操作で使用されるものと同じです。

例えば、ODP プレゼンテーションを PDF に変換する必要がある場合、以下のように実行できます。
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **よくある質問**

**LibreOffice や OpenOffice をインストールせずに ODP を PPTX に変換できますか？**

はい。Aspose.Slides は、外部アプリケーションを必要とせず、PowerPoint と OpenOffice の両方の形式を処理できる完全にスタンドアロンのライブラリです。

**Aspose.Slides はパスワードで保護された ODP/OTP ファイルを開いたり保存したりできますか？**

はい。パスワードを指定すれば[暗号化されたプレゼンテーションをロード](/slides/ja/python-net/password-protected-presentation/)でき、暗号化や保護設定を付けてプレゼンテーションを保存することもできます。

**変換前に ODP から埋め込まれたメディアファイル（音声/動画）を抽出できますか？**

はい。Aspose.Slides を使用すると、プレゼンテーションから埋め込まれた[音声](/slides/ja/python-net/audio-frame/)と[動画](/slides/ja/python-net/video-frame/)を取得して抽出でき、変換前の処理や別途再利用に役立ちます。

**変換した ODP を Strict Office Open XML として保存できますか？**

はい。PPTX として保存する際に、[保存オプション](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) を使用して Strict OOXML を有効にすることで、より厳格なコンプライアンス要件に対応できます。