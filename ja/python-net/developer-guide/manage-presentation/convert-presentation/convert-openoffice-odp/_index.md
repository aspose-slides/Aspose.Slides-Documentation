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
description: "Aspose.Slides を使用して Python で OpenDocument ODP を PDF、PPT、PPTX、XPS、HTML、TIFF、または SWF に変換します。コード例、高忠実度、バッチ変換、カスタマイズが可能です。"
---

## **ODP ファイルの変換**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) は OpenOffice ODP プレゼンテーションを多数の形式に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用する API は、PowerPoint (PPT および PPTX) 変換操作で使用するものと同じです。

以下の例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソース ODP ファイルを変更してください）：

- [ODP を HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/)
- [ODP を PDF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)
- [ODP を SWF Flash に変換](/slides/ja/python-net/convert-powerpoint-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/)
- [ODP をノート付き PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf-with-notes/)
- [ODP をノート付き TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff-with-notes/)

例えば、ODP プレゼンテーションを PDF に変換する必要がある場合は、次のように実行できます：
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **FAQ**

**LibreOffice や OpenOffice をインストールせずに ODP を PPTX に変換できますか？**

はい。Aspose.Slides は完全にスタンドアロンのライブラリで、外部アプリケーションを必要とせずに PowerPoint と OpenOffice の形式の両方を処理できます。

**Aspose.Slides はパスワードで保護された ODP/OTP ファイルを開いたり保存したりできますか？**

はい。パスワードを提供すれば[暗号化されたプレゼンテーションを読み込む](/slides/ja/python-net/password-protected-presentation/)ことができ、暗号化や保護設定付きでプレゼンテーションを保存することも可能です。

**変換前に ODP から埋め込みメディアファイル（音声/動画）を抽出できますか？**

はい。Aspose.Slides を使用すると、プレゼンテーションから埋め込み[audio](/slides/ja/python-net/audio-frame/)と[video](/slides/ja/python-net/video-frame/)をアクセスおよび抽出でき、変換前の処理や別途再利用に役立ちます。

**変換された ODP を Strict Office Open XML として保存できますか？**

はい。PPTX に保存する際、[保存オプション](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)を使用して Strict OOXML を有効にし、より厳格なコンプライアンス要件に対応できます。