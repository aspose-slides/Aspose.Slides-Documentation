---
title: Python でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションの変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
keywords:
- プレゼンテーション変換
- プレゼンテーションエクスポート
- PPT から PPTX
- PPT から PDF
- PPTX から PDF
- PPT から XPS
- PPTX から XPS
- PPT から TIFF
- PPTX から TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、XPS、TIFF などに変換します。シンプルで高品質な変換が可能です。"
---

## **概要**

このページでは、Aspose.Slides for Python via .NET を使用したプレゼンテーション変換の概要を示します。サポートされているシナリオをまとめ、PDF、XPS、TIFF へのエクスポートや PPT と PPTX の相互変換など、具体的なコード例を示すガイドへリンクしています。関連する記事では、ノートのレンダリングや画像品質の調整といったフォーマット固有のオプションや、PPT→PPTX 変換の部分的サポートなどの既知の制限事項も紹介しています。このページで対象フォーマットを選択し、リンク先のレシピに従ってください。

## **PPT から PPTX への変換**

### **PPT/PPTX について**

PPT は旧式のバイナリ PowerPoint フォーマット（97–2003）で、PPTX は PowerPoint 2007 で導入された ZIP 圧縮の Open XML フォーマットです。PPT に比べて PPTX はファイルサイズが小さく、最新機能に対応し、ドキュメント自動化にも適しており、長期保存やクロスプラットフォームのワークフローに推奨されます。

### **PPT を PPTX に変換**

Aspose.Slides は PPT プレゼンテーションを PPTX フォーマットに変換できます。このタスクで Aspose.Slides API を使用する主な利点は、目的の結果を得るためのワークフローがシンプルであることです。実際には、最小限のコードでスライド、レイアウト、メディアの高忠実度を保ちながら変換を実行できます。

{{% alert color="primary" %}}
続きを読む： [Python で PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **プレゼンテーションを PDF に変換**

### **PDF について**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF)（PDF）は、Adobe Systems が文書のやり取りのために作成したファイルフォーマットです。プラットフォームに依存せず、文書の内容が同一の視覚的外観で表示されることを目的としています。

### **プレゼンテーションを PDF に変換**

Aspose.Slides が読み込める任意のプレゼンテーションは PDF ドキュメントに変換できます。Aspose.Slides コンポーネントだけでプレゼンテーションを直接 PDF にエクスポートでき、サードパーティのライブラリや Aspose.PDF コンポーネントは不要です。

{{% alert color="primary" %}}
続きを読む： [Python で PPT & PPTX を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **プレゼンテーションを XPS に変換**

### **XPS について**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)（XPS）は、Microsoft が開発したページ記述言語および固定文書フォーマットです。PDF と同様、文書の忠実度を保持し、デバイスに依存しない外観を提供する固定レイアウト形式です。

### **プレゼンテーションを XPS に変換**

Aspose.Slides が読み込める任意のプレゼンテーションは XPS フォーマットに変換できます。Aspose.Slides は高忠実度のページレイアウトとレンダリングエンジンを使用して、固定レイアウトの XPS 形式で出力します。特に、Windows Presentation Foundation（WPF）に依存せずに直接 XPS を生成します。

{{% alert color="primary" %}}
続きを読む： [Python で PowerPoint プレゼンテーションを XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **プレゼンテーションを TIFF に変換**

### **TIFF について**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF)（TIFF）は、1 つのファイルに複数の画像（ページ）を保存できるラスタ画像フォーマットです。元は Aldus によって開発され、スキャン、FAX、その他画像処理アプリケーションで広くサポートされています。

### **プレゼンテーションを TIFF に変換**

Aspose.Slides が読み込める任意のドキュメントは、サードパーティ コンポーネントを使用せずに直接 TIFF ファイルに変換できます。さらに、生成された TIFF のページサイズを任意で指定することも可能です。

{{% alert color="primary" %}}
続きを読む： [Python で PowerPoint プレゼンテーションを TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**PDF/XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。エクスポート時に [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) / [XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) の設定で非表示スライドを含めるオプションがあります。

**アーカイブ保存用の PDF/A 形式での保存はサポートされていますか？**

はい。エクスポート時に PDF/A のコンプライアンスレベル（A-2a/A-2b/A-2u および A-3a/A-3b）を指定できます。[詳細はこちら]（https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/）。

**変換時のフォントは埋め込まれますか、置き換えられますか？**

柔軟なオプションがあります。すべてのグリフまたは使用したサブセットのみを [埋め込む](/slides/ja/python-net/embedded-font/)、[フォールバック フォント](/slides/ja/python-net/fallback-font/) を指定する、フォントが特定のスタイルを欠く場合の [置換動作](/slides/ja/python-net/font-substitution/) を制御できます。

**生成される PDF の品質とサイズはどのように制御できますか？**

[JPEG 品質](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[テキスト圧縮](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、画像用の [十分な解像度](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) のしきい値、画像の [最適な圧縮率](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) を選択できます。

**スライドの範囲（例: 5–12）だけをエクスポートできますか？**

はい。エクスポート時にスライドのサブセットを選択できます。

**複数のファイルを同時にマルチコアで処理することはサポートされていますか？**

別プロセスで異なるプレゼンテーションを並行して処理することは可能です。重要: 同じ [プレゼンテーション]（https://reference.aspose.com/slides/python-net/aspose.slides/presentation/）オブジェクトを [複数スレッド]（/slides/python-net/multithreading/）からロードまたは保存しないでください。

**異なるスレッドからライセンス設定を行う際のリスクはありますか？**

はい。[ライセンス設定]（/slides/python-net/licensing/）呼び出しはスレッドセーフでないため、同期が必要です。