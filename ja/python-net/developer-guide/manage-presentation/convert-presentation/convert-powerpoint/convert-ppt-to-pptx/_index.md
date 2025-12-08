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
description: "Aspose.Slides を使用して、Python でレガシー PPT プレゼンテーションを最新の PPTX に高速に変換します — 明瞭なチュートリアル、無料のコードサンプル、Microsoft Office 不要。"
---

## **概要**

この記事では、Python とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックがカバーされています:

- Python で PPT を PPTX に変換

## **Python で PPT を PPTX に変換**

Python で PPT を PPTX に変換するサンプルコードについては、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更することで、PDF、XPS、ODP、HTML など多数の形式に PPT ファイルを保存できます。これらの記事で詳しく説明しています:

- [Python で PPT を PDF に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python で PPT を XPS に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python で PPT を HTML に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python で PPT を ODP に変換](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python で PPT を画像に変換](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
古い PPT 形式を Aspose.Slides API で PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで行うことです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、以下が可能です:

- マスター、レイアウト、スライドなどの複雑な構造を変換します。
- チャートを含むプレゼンテーションを変換します。
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリのシェイプを含むプレゼンテーションを変換します。
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプのプレゼンテーションを変換します。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換します。

{{% alert color="primary" %}}

次の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** をベースに構築されているため、基本的な PPT から PPTX への変換機能のライブ例を見ることができます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップして PPTX に変換された状態でダウンロードできるウェブアプリです。

他のライブ例は [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) をご覧ください。
{{% /alert %}}

## **PPT を PPTX に変換**
PPT を PPTX に変換するには、[**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドにファイル名と保存形式を渡すだけです。以下の Python コードサンプルは、デフォルトオプションで PPT から PPTX にプレゼンテーションを変換します。
```python
import aspose.slides as slides

# PPT ファイルを表す Presentation オブジェクトをインスタンス化します
pres = slides.Presentation("PPTtoPPTX.ppt")

# プレゼンテーションを PPTX 形式で保存します
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


[**PPT と PPTX の違い**](/slides/ja/python-net/ppt-vs-pptx/) のプレゼンテーション形式と、[**Aspose.Slides が PPT から PPTX への変換をサポート**](/slides/ja/python-net/convert-ppt-to-pptx/) について、さらに詳しくご覧ください。

## **よくある質問**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さくなり、データ復元が改善されます。

**Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**Aspose.Slides は複数の PPT ファイルをまとめて PPTX に変換するバッチ変換をサポートしていますか？**

はい、ループ内で Aspose.Slides を使用して、複数の PPT ファイルをプログラムで PPTX に変換できるため、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides はプレゼンテーションの高忠実度変換を維持します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML などの他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアを必要とせずに変換を実行できます。

**PPT から PPTX への変換に利用できるオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリケーションを使用すれば、コードを書かずにブラウザ上で直接変換を実行できます。
