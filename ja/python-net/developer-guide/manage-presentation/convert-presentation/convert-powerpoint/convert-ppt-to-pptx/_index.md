---
title: Convert PPT to PPTX in Python
linktitle: PPT to PPTX
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords:
- сonvert PPT
- PPT to PPTX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Convert legacy PPT presentations to modern PPTX fast in Python with Aspose.Slides — clear tutorial, free code samples, no Microsoft Office dependency."
---

## **概要**

この記事では、Python とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。取り上げるトピックは次のとおりです。

- Python で PPT を PPTX に変換

## **PythonでPPTをPPTXに変換**

PPT を PPTX に変換する Python のサンプルコードについては、以下のセクション、すなわち [PPT を PPTX に変換](#convert-ppt-to-pptx) を参照してください。PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式にも変換できます。詳しくは以下の記事をご覧ください。

- [Python で PPT を PDF に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python で PPT を XPS に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python で PPT を HTML に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python で PPT を ODP に変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python で PPT を画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式から PPTX に変換します。数千件の PPT プレゼンテーションを PPTX に変換する必要がある場合、プログラムで行うのが最適です。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、以下が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- チャートを含むプレゼンテーションを変換
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタム ジオメトリを持つシェイプを変換
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプを変換
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}}

以下の [**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** をベースに構築されているため、PPT から PPTX への基本的な変換機能のライブ例をご確認いただけます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーション ファイルをドロップすると、PPTX に変換してダウンロードできる Web アプリです。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 例もご覧ください。
{{% /alert %}}

## **PPT を PPTX に変換**
PPT を PPTX に変換するには、[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドにファイル名と保存形式を渡すだけです。以下の Python コード サンプルは、デフォルト オプションで PPT を PPTX に変換します。

```python
import aspose.slides as slides

# PPT ファイルを表す Presentation オブジェクトを作成
pres = slides.Presentation("PPTtoPPTX.ppt")

# プレゼンテーションを PPTX 形式で保存
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[**PPT と PPTX の違い**](/slides/ja/python-net/ppt-vs-pptx/) と、[**Aspose.Slides が PPT から PPTX への変換をサポートしているか**](/slides/ja/python-net/convert-ppt-to-pptx/) について詳しく読むことができます。

## Frequently Asked Questions

### **PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する旧式のバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さく、データ復元が容易です。

### **Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### **PPT から PPTX への変換に Aspose.Slides for Python via .NET は必須ですか？**

はい。Aspose.Slides API は、Microsoft PowerPoint に依存せずに PowerPoint プレゼンテーションをプログラムで変換、操作、保存するために必要なメソッドとクラスを提供します。

### **複数の PPT ファイルを一括で PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで順次 PPTX に変換でき、バッチ変換シナリオに適しています。

### **変換後にコンテンツと書式は保持されますか？**

Aspose.Slides は高精度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換過程で保持されます。

### **PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式に変換することをサポートしています。

### **Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ ソフトウェアを必要とせずに変換を実行できます。

### **オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT から PPTX へのコンバータ](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザ上で直接変換できます。