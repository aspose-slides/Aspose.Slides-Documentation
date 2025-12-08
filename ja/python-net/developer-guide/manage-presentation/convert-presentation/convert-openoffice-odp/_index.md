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
description: "PythonでAspose.Slidesを使用してOpenDocument ODPをPDF、PPT、PPTX、XPS、HTML、TIFF、またはSWFに変換します。コード例、高忠実度、バッチ変換、カスタマイズが可能です。"
---

## **ODP ファイルの変換**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) は、OpenOffice ODP プレゼンテーションを多数の形式に変換できます。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint (PPT および PPTX) の変換操作で使用されるものと同じです。

これらの例は、ODP ドキュメントを他の形式に変換する方法を示しています（ソース ODP ファイルを変更するだけです）:

- [ODP を HTML に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP を PDF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)
- [ODP を SWF Flash に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ノート付きで ODP を PDF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ノート付きで ODP を TIFF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例えば、ODP プレゼンテーションを PDF に変換する必要がある場合、次のように実行できます:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **よくある質問**

**LibreOffice または OpenOffice をインストールせずに ODP を PPTX に変換できますか？**

はい。Aspose.Slides は完全にスタンドアロンのライブラリで、外部アプリケーションを必要とせずに PowerPoint と OpenOffice の両形式を処理できます。

**Aspose.Slides はパスワードで保護された ODP/OTP ファイルを開いたり保存したりできますか？**

はい。パスワードを指定すれば、[暗号化されたプレゼンテーションの読み込み](/slides/ja/python-net/password-protected-presentation/) が可能で、暗号化や保護設定付きでプレゼンテーションを保存することもできます。

**変換前に ODP から埋め込まれたメディアファイル（オーディオ/ビデオ）を抽出できますか？**

はい。Aspose.Slides を使用すると、プレゼンテーションから埋め込まれた [オーディオ](/slides/ja/python-net/audio-frame/) と [ビデオ](/slides/ja/python-net/video-frame/) をアクセスして抽出でき、変換前の処理や別途再利用に役立ちます。

**変換された ODP を Strict Office Open XML として保存できますか？**

はい。PPTX に保存する際、[保存オプション](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) を使用して Strict OOXML を有効にでき、より厳格な準拠要件を満たすことができます。