---
title: Python で PPT を PPTX に変換
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
description: "Aspose.Slides を使用して、Python でレガシー PPT プレゼンテーションをモダンな PPTX に高速変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office 不要です。"
---

## **概要**

この記事では、Python とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。対象トピックは以下の通りです：

- Python で PPT を PPTX に変換

## **Python で PPT を PPTX に変換**

PPT を PPTX に変換する Python のサンプルコードについては、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) をご覧ください。これは単に PPT ファイルを読み込み、PPTX 形式で保存します。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの他の形式にも PPT ファイルを保存できます。これらの記事で詳しく説明しています：

- [Python で PPT を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/)
- [Python で PPT を XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/)
- [Python で PPT を HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/)
- [Python で PPT を ODP に変換](/slides/ja/python-net/save-presentation/)
- [Python で PPT を PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実行可能です。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートし、以下のことが可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループ シェイプ、オート シェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- オート シェイプのテクスチャと画像フィル スタイルを持つプレゼンテーションを変換する。
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}}

以下のアプリをご覧ください：[**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx)：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** に基づいて構築されているため、PPT から PPTX への基本的な変換機能のライブ例をご覧いただけます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーション ファイルをドロップし、PPTX に変換してダウンロードできる Web アプリです。

他のライブ例は [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) をご覧ください。

{{% /alert %}}

## **PPT を PPTX に変換**

PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) メソッドに渡すだけです。このメソッドは [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのものです。以下の Python コードサンプルは、デフォルト オプションで PPT から PPTX へプレゼンテーションを変換します。
```python
import aspose.slides as slides

# PPT ファイルを表す Presentation オブジェクトをインスタンス化します
pres = slides.Presentation("PPTtoPPTX.ppt")

# プレゼンテーションを PPTX 形式で保存します
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


プレゼンテーション形式の [**PPT vs PPTX**](/slides/ja/python-net/ppt-vs-pptx/) について詳しく読み、[**Aspose.Slides は PPT から PPTX への変換をサポートしています**](/slides/ja/python-net/convert-ppt-to-pptx/) の詳細をご確認ください。

## **FAQ**

**PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が改善されています。

**Python で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存することが簡単にできます。

**複数の PPT ファイルを PPTX にバッチ変換することは可能ですか？**

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML などの他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG、JPEG などの複数の形式に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for Python via .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ ソフトウェアを必要とせずに変換を実行できます。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザー上で直接変換を実行できます。