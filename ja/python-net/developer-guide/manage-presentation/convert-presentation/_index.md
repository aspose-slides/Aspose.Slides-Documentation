---
title: Pythonでプレゼンテーションを複数フォーマットに変換
linktitle: プレゼンテーションの変換
type: docs
weight: 70
url: /ja/python-net/developer-guide/manage-presentation/convert-presentation/
keywords:
- プレゼンテーションの変換
- プレゼンテーションのエクスポート
- PPTからPPTX
- PPTからPDF
- PPTXからPDF
- PPTからXPS
- PPTXからXPS
- PPTからTIFF
- PPTXからTIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、XPS、TIFF などに変換します。シンプルで高品質な変換です。"
---

## **はじめに**

このページでは、Aspose.Slides for Python via .NET を使用したプレゼンテーション変換の概要を提供します。サポートされているシナリオをまとめ、PDF、XPS、TIFF などのフォーマットへのエクスポートや PPT と PPTX の相互変換の具体的なコードを示すガイドへリンクしています。関連する記事では、ノートのレンダリングや画像品質の調整といったフォーマット固有のオプションや、PPT→PPTX の部分的なサポートなどの既知の制限事項をハイライトしています。このページを使って対象フォーマットを選択し、リンクされた手順に従ってください。

## **PPT から PPTX への変換**

### **PPT/PPTX について**

PPT は古いバイナリ形式の PowerPoint (97–2003) で、PPTX は PowerPoint 2007 で導入された ZIP 圧縮の Open XML 形式です。PPT と比較して、PPTX は通常ファイルサイズが小さく、最新機能をサポートし、ドキュメント自動化にも適しており、長期保存やクロスプラットフォームワークフローに推奨されます。

### **PPT を PPTX に変換**

Aspose.Slides は PPT プレゼンテーションを PPTX 形式に変換できます。このタスクに Aspose.Slides API を使用する主な利点は、目的の結果を得るためのワークフローがシンプルな点です。実際には、最小限のコードで変換を実行でき、スライド、レイアウト、メディアの高い忠実度を保ちます。

{{% alert color="primary" %}}
詳しくは: [Convert PPT to PPTX in Python](/slides/ja/python-net/convert-ppt-to-pptx/)。
{{% /alert %}}

## **プレゼンテーションの PDF 変換**

### **PDF について**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) は、Adobe Systems が文書のやり取りのために作成したファイル形式です。その目的は、閲覧プラットフォームに関係なく文書の視覚的外観を同一に保つことです。

### **プレゼンテーションを PDF に変換**

Aspose.Slides で読み込めるすべてのプレゼンテーションは PDF ドキュメントに変換できます。Aspose.Slides コンポーネントだけでプレゼンテーションを PDF に直接エクスポートでき、サードパーティのライブラリや Aspose.PDF コンポーネントは不要です。

{{% alert color="primary" %}}
詳しくは: [Convert PPT & PPTX to PDF in Python](/slides/ja/python-net/convert-powerpoint-to-pdf/)。
{{% /alert %}}

## **プレゼンテーションの XPS 変換**

### **XPS について**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) は、Microsoft が開発したページ記述言語および固定文書フォーマットです。PDF と同様に、XPS は固定レイアウトの文書形式で、文書の忠実度を保持し、デバイスに依存しない外観を提供します。

### **プレゼンテーションを XPS に変換**

Aspose.Slides が読み込める任意のプレゼンテーションは XPS 形式に変換できます。Aspose.Slides は高忠実度のページレイアウト・レンダリングエンジンを使用して、固定レイアウトの XPS 形式で出力します。特筆すべきは、Aspose.Slides が Windows Presentation Foundation (WPF) に依存せずに直接 XPS を生成する点です。

{{% alert color="primary" %}}
詳しくは: [Convert PowerPoint Presentations to XPS in Python](/slides/ja/python-net/convert-powerpoint-to-xps/)。
{{% /alert %}}

## **プレゼンテーションの TIFF 変換**

### **TIFF について**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) は、単一ファイルに複数の画像（ページ）を保存できるラスタ画像形式です。もともと Aldus が開発し、スキャン、FAX、その他画像処理アプリケーションで広くサポートされています。

### **プレゼンテーションを TIFF に変換**

Aspose.Slides が読み込める任意のドキュメントは、サードパーティのコンポーネント無しで直接 TIFF ファイルに変換できます。結果の TIFF のページサイズを任意で指定することも可能です。

{{% alert color="primary" %}}
詳しくは: [Convert PowerPoint Presentations to TIFF in Python](/slides/ja/python-net/convert-powerpoint-to-tiff/)。
{{% /alert %}}

## **FAQ**

**PDF/XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。エクスポートは、[PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 設定の該当オプションで非表示スライドの包含をサポートします。

**アーカイブ保存用の PDF/A 形式での保存はサポートされていますか？**

はい、エクスポート時に PDF/A 準拠レベル（A-2a/A-2b/A-2u および A-3a/A-3b）[が利用可能](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)です。

**変換時のフォントは埋め込まれますか、置き換えられますか？**

柔軟なオプションがあります。すべてのグリフまたは使用されたサブセットのみを[埋め込む](/slides/ja/python-net/embedded-font/)、[代替フォント](/slides/ja/python-net/fallback-font/) を指定し、フォントに特定のスタイルがない場合の[動作を制御](/slides/ja/python-net/font-substitution/) ことができます。

**生成された PDF の品質とサイズをどのように制御できますか？**

[JPEG 品質](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[テキスト圧縮](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、画像の[十分な解像度](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) のしきい値、そして画像の[最適な圧縮率](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) を選択するモードがあります。

**スライドの範囲（例: 5–12）だけをエクスポートすることはできますか？**

はい、エクスポートはスライドのサブセット選択をサポートします。

**複数のファイルを同時にマルチコアで処理することは可能ですか？**

別プロセスで複数のプレゼンテーションを並行して処理することは許容されます。重要: 同じ[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトを[複数スレッド](/slides/ja/python-net/multithreading/)からロードまたは保存してはいけません。

**異なるスレッドからライセンスを設定する際のリスクはありますか？**

はい、[ライセンス設定](/slides/ja/python-net/licensing/) 呼び出しはスレッドセーフではなく、同期が必要です。