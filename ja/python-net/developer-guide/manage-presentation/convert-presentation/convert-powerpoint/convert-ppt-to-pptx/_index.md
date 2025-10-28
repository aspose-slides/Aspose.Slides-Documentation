---
title: PythonでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords:
- PPTを変換
- PPTからPPTXへ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でレガシーな PPT プレゼンテーションを最新の PPTX に高速変換する方法を解説。チュートリアル、無料サンプルコード、Microsoft Office 不要。"
---

## **概要**

この記事では、Python とオンラインの PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。取り上げるテーマは以下の通りです。

- Python で PPT を PPTX に変換する

## **Python で PPT を PPTX に変換する**

Python のサンプルコードで PPT を PPTX に変換する方法は、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) をご覧ください。コードは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他形式にも変換可能です。詳細は次の記事をご参照ください。

- [Python で PPT を PDF に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python で PPT を XPS に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python で PPT を HTML に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python で PPT を ODP に変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python で PPT を画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して旧形式の PPT を PPTX に変換します。数千件の PPT を PPTX に変換する必要がある場合、最適な解決策はプログラムで実行することです。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT から PPTX への完全な互換性をサポートし、次の操作が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換  
- チャートを含むプレゼンテーションを変換  
- グループ形状、オートシェイプ（矩形や楕円など）やカスタムジオメトリを持つ形状を変換  
- オートシェイプのテクスチャや画像塗りつぶしスタイルを変換  
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換  

{{% alert color="primary" %}}

以下の **Aspose.Slides PPT から PPTX 変換** アプリをご覧ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** を基に構築されており、基本的な PPT から PPTX への変換機能をライブで体験できます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップし、PPTX に変換してダウンロードできる Web アプリです。

他のライブ **Aspose.Slides Conversion** 例は [こちら](https://products.aspose.app/slides/conversion/) です。  
{{% /alert %}}

## **PPT を PPTX に変換する**
PPT を PPTX に変換するには、[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドにファイル名と保存形式を渡すだけです。以下の Python サンプルは、既定オプションで PPT を PPTX に変換します。

```python
import aspose.slides as slides

# PPT ファイルを表す Presentation オブジェクトを作成
pres = slides.Presentation("PPTtoPPTX.ppt")

# PPTX 形式でプレゼンテーションを保存
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[**PPT と PPTX の違い**](/slides/ja/python-net/ppt-vs-pptx/) についての詳細と、[**Aspose.Slides が PPT から PPTX への変換をサポートしているか**](/slides/ja/python-net/convert-ppt-to-pptx/) をご覧ください。

## よくある質問

### **PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する従来のバイナリ形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新形式です。PPTX はパフォーマンス向上、ファイルサイズ削減、データ復元性向上を実現します。

### **Python で PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### **PPT から PPTX への変換に Aspose.Slides for Python via .NET は必須ですか？**

はい。Aspose.Slides API が、Microsoft PowerPoint に依存せずに PowerPoint プレゼンテーションをプログラムで変換、操作、保存するために必要なメソッドとクラスを提供します。

### **複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい。ループ処理で Aspose.Slides を呼び出すことで、複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

### **変換後も内容と書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、形状、チャートなどのデザイン要素は PPT から PPTX への変換時に保持されます。

### **PPT ファイルから PDF や HTML など他の形式にも変換できますか？**

はい。Aspose.Slides は PPT を PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式へも変換できます。

### **Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via .NET は単体で動作し、Microsoft PowerPoint やサードパーティ製ソフトウェアを必要とせずに変換を実行できます。

### **オンラインで PPT を PPTX に変換できるツールはありますか？**

はい。コードを書かずにブラウザ上で直接変換できる無料の [Aspose.Slides PPT から PPTX 変換ツール](https://products.aspose.app/slides/conversion/ppt-to-pptx) をご利用ください。