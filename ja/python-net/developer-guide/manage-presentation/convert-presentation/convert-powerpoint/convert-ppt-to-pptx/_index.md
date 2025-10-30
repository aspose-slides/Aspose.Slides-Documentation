---
title: "PythonでPPTをPPTXに変換"
linktitle: "PPTからPPTXへ"
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords:
- "PPTを変換"
- "PPTからPPTXへ"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slidesを使用して、レガシーなPPTプレゼンテーションをPythonで高速に最新のPPTXに変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office不要。"
---

## **概要**

この記事では、Python とオンラインの PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックがカバーされています：

- PythonでPPTをPPTXに変換

## **PythonでPPTをPPTXに変換**

Python のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、すなわち[PPTをPPTXに変換](#convert-ppt-to-pptx)をご覧ください。コードは単に PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など多くの形式にも変換でき、これらの記事で詳しく説明しています：

- [PythonでPPTをPDFに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [PythonでPPTをXPSに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [PythonでPPTをHTMLに変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [PythonでPPTをODPに変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [PythonでPPTを画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
Aspose.Slides API を使用して古い PPT フォーマットを PPTX に変換します。数千件の PPT プレゼンテーションを PPTX に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートし、次のことが可能です：

- マスタ、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}}
以下の[**Aspose.Slides PPTからPPTXへの変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは**Aspose.Slides API**をベースに構築されているため、基本的な PPT から PPTX への変換機能のライブ例を確認できます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換された状態でダウンロードできるウェブアプリです。

他のライブ[**Aspose.Slides変換**](https://products.aspose.app/slides/conversion/)例をご覧ください。
{{% /alert %}}

## **PPTをPPTXに変換**
PPT を PPTX に変換するには、[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドにファイル名と保存形式を渡すだけです。以下の Python コードサンプルは、デフォルトオプションで PPT から PPTX にプレゼンテーションを変換します。

```python
import aspose.slides as slides

# PPTファイルを表すPresentationオブジェクトをインスタンス化
pres = slides.Presentation("PPTtoPPTX.ppt")

# プレゼンテーションをPPTX形式で保存
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[PPTとPPTX](/slides/ja/python-net/ppt-vs-pptx/) の違いと、[**Aspose.Slides が PPT から PPTX への変換をサポート**](/slides/ja/python-net/convert-ppt-to-pptx/) についての詳細をご覧ください。

## **よくある質問**

### **PPT と PPTX フォーマットの違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が改善されています。

### **Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### **PPT から PPTX への変換には Aspose.Slides for Python via .NET が必要ですか？**

はい、Aspose.Slides API が必要です。この API は、Microsoft PowerPoint に依存せずに PowerPoint プレゼンテーションをプログラムで変換、操作、保存するためのメソッドとクラスを提供します。

### **複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用して多数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

### **変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

### **PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式に変換することをサポートしています。

### **Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

### **オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の[Aspose.Slides PPTからPPTXへのコンバータ](https://products.aspose.app/slides/conversion/ppt-to-pptx)ウェブアプリを使用すれば、コードを書かずにブラウザ上で直接変換できます。