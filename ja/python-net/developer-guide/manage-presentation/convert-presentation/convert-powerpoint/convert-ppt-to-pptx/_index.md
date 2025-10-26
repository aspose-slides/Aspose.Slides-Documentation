---
title: PythonでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-ppt-to-pptx/
keywords:
- сonvert PPT
- PPT to PPTX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でレガシーな PPT プレゼンテーションを最新の PPTX に高速変換 — 明快なチュートリアル、無料コードサンプル、Microsoft Office 不要。"
---

## **概要**

このガイドでは、Python とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックを取り上げます:

- PythonでPPTをPPTXに変換

## **PythonでPPTをPPTXに変換**

Python のサンプルコードは以下のセクションをご覧ください、すなわち[Convert PPT to PPTX](#convert-ppt-to-pptx)。それは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更することで、PDF、XPS、ODP、HTML など多くの形式にも変換できます。これらの記事で詳しく解説しています:

- [PythonでPPTをPDFに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [PythonでPPTをXPSに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [PythonでPPTをHTMLに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [PythonでPPTをODPに変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [PythonでPPTを画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
古い PPT 形式を Aspose.Slides API で PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで行うのが最適な解決策です。Aspose.Slides API なら数行のコードで実現可能です。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、以下が可能です:

- マスター、レイアウト、スライドの複雑な構造を変換。
- チャートを含むプレゼンテーションを変換。
- グループシェイプ、オートシェイプ（矩形や楕円など）やカスタムジオメトリを持つシェイプを変換。
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプを変換。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換。

{{% alert color="primary" %}}

次の [**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** に基づいて構築されており、PPT から PPTX への基本的な変換機能のライブ例をご確認いただけます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップして PPTX に変換してダウンロードできる Web アプリです。

他のライブ [**Aspose.Slides 変換**](https://products.aspose.app/slides/conversion/) の例をご覧ください。
{{% /alert %}}

## **PPT を PPTX に変換**
PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドに渡すだけです。[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用します。以下の Python コードサンプルは、デフォルトオプションで PPT から PPTX にプレゼンテーションを変換します。

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPT file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Save the presentation in PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[**PPT と PPTX の比較**](/slides/ja/python-net/ppt-vs-pptx/) プレゼンテーション形式や、[**Aspose.Slides が PPT から PPTX への変換をサポートする方法**](/slides/ja/python-net/convert-ppt-to-pptx/) について詳しく読むことができます。

## よくある質問

### **PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリ形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復元が改善されています。

### **Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### **PPT から PPTX への変換に Aspose.Slides for Python via .NET は必須ですか？**

はい、Aspose.Slides API は PowerPoint プレゼンテーションをプログラムで変換、操作、保存するために必要なメソッドとクラスを提供しており、Microsoft PowerPoint に依存しません。

### **複数の PPT ファイルを一括で PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで順次変換でき、バッチ変換シナリオに適しています。

### **変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

### **PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式へも変換できます。

### **Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティのソフトウェアは不要です。

### **オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT から PPTX 変換ツール](https://products.aspose.app/slides/conversion/ppt-to-pptx) を使用すれば、コードを書くことなくブラウザ上で直接変換できます。