---
title: OpenDocument プレゼンテーションを Python で変換
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
description: "Aspose.Slides を使用して Python で OpenDocument ODP を PDF、PPT、PPTX、XPS、HTML、TIFF、または SWF に変換します。コード例、高忠実度、バッチ変換、カスタマイズが可能です。"
---

## **ODP ファイルの変換**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) は、OpenOffice ODP プレゼンテーションを多数の形式に変換できるようにします。ODP ファイルを他のドキュメント形式に変換するために使用される API は、PowerPoint（PPT および PPTX）変換操作で使用されるものと同じです。

これらの例では、ソース ODP ファイルを変更するだけで ODP ドキュメントを他の形式に変換する方法を示します。

- [ODP を HTML に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP を PDF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)
- [ODP を SWF Flash に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP を XPS に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ノート付きで ODP を PDF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ノート付きで ODP を TIFF に変換](/slides/ja/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例えば、ODP プレゼンテーションを PDF に変換したい場合は、次のように実行できます。

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**LibreOffice や OpenOffice をインストールせずに ODP を PPTX に変換できますか？**

はい。Aspose.Slides は、PowerPoint と OpenOffice の両方の形式を外部アプリケーションなしで処理できる完全にスタンドアロンなライブラリです。

**Aspose.Slides はパスワードで保護された ODP/OTP ファイルを開いたり保存したりできますか？**

はい。パスワードを提供すれば[暗号化されたプレゼンテーションを読み込む](/slides/ja/python-net/password-protected-presentation/)ことができ、暗号化や保護設定を付加してプレゼンテーションを保存することもできます。

**変換前に ODP から埋め込みメディアファイル（音声/動画）を抽出できますか？**

はい。Aspose.Slides を使用すると、プレゼンテーションから埋め込み[音声](/slides/ja/python-net/audio-frame/)や[動画](/slides/ja/python-net/video-frame/)をアクセスし抽出でき、変換前の処理や別途再利用に役立ちます。

**変換後の ODP を Strict Office Open XML 形式で保存できますか？**

はい。PPTX に保存する際、[保存オプション](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)で Strict OOXML を有効にでき、より厳格なコンプライアンス要件に対応できます。