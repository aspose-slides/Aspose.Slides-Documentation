---
title: Python で PPT を PPTX に変換する
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords:
- PPT を変換
- PPT から PPTX へ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、レガシーな PPT プレゼンテーションを Python で高速に最新の PPTX に変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office 不要です。"
---

## **概要**

この記事では、Python とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが扱われます：

- Python で PPT を PPTX に変換

## **PythonでPPTをPPTXに変換**

PPT を PPTX に変換する Python のサンプルコードについては、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。これは単に PPT ファイルを読み込み、PPTX 形式で保存するだけのものです。保存形式を変更すれば、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事でも説明しています：

- [PythonでPPTをPDFに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [PythonでPPTをXPSに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [PythonでPPTをHTMLに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [PythonでPPTをODPに変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [PythonでPPTを画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPTからPPTX変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な解決策はプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、次のことが可能です：

- マスター、レイアウト、スライドの複雑な構造を変換します。
- チャートを含むプレゼンテーションを変換します。
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換します。
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換します。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換します。

{{% alert color="primary" %}}

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** に基づいて構築されており、基本的な PPT から PPTX への変換機能のライブ例を確認できます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップし、PPTX に変換された状態でダウンロードできるWebアプリです。

他のライブ例は [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) をご参照ください。

{{% /alert %}}

## **PPTをPPTXに変換**

PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドに渡すだけです。このメソッドは [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスに属します。以下の Python コードサンプルは、デフォルトオプションを使用して PPT から PPTX にプレゼンテーションを変換します。
```python
import aspose.slides as slides

# PPT ファイルを表す Presentation オブジェクトを作成します
pres = slides.Presentation("PPTtoPPTX.ppt")

# プレゼンテーションを PPTX 形式で保存します
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


[PPT と PPTX の違い](/slides/ja/python-net/ppt-vs-pptx/) や、[Aspose.Slides が PPT から PPTX への変換をサポートしている方法](/slides/ja/python-net/convert-ppt-to-pptx/) について詳しく読むことができます。

## よくある質問

### **PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する旧式のバイナリ形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が改善されています。

### **Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### **PPT から PPTX への変換に Aspose.Slides for Python via .NET は必須ですか？**

はい、Aspose.Slides API はプログラムから PowerPoint プレゼンテーションを変換、操作、保存するために必要なメソッドとクラスを提供しており、Microsoft PowerPoint が不要です。

### **複数の PPT ファイルを一括で PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで順次 PPTX に変換でき、一括変換シナリオに適しています。

### **変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

### **PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式に変換することをサポートしています。

### **Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロンの API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

### **オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザ上で直接変換できます。