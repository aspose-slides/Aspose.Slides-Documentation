---
title: Python でプレゼンテーションを複数形式に変換
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
keywords:
- プレゼンテーションを変換
- プレゼンテーションをエクスポート
- PPT から PPTX へ
- PPT から PDF へ
- PPTX から PDF へ
- PPT から XPS へ
- PPTX から XPS へ
- PPT から TIFF へ
- PPTX から TIFF へ
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、XPS、TIFF などに変換します。シンプルで高品質な変換です。"
---

## **はじめに**

このページでは、Aspose.Slides for Python via .NET を使用したプレゼンテーション変換の概要を提供します。サポートされているシナリオをまとめ、PDF、XPS、TIFF などの形式へのプレゼンテーションやスライドのエクスポート、PPT から PPTX への変換の正確なコードを示すガイドへリンクしています。関連する記事では、ノートのレンダリングや画像品質の調整といった形式固有のオプションや、PPT→PPTX パスでの部分的なサポートなど既知の制限事項がハイライトされています。このページを使って対象形式を選択し、リンクされたレシピに従ってください。

## **PPT から PPTX への変換**

### **PPT/PPTX について**

PPT は古いバイナリ形式の PowerPoint（97–2003）で、PPTX は PowerPoint 2007 で導入された ZIP パッケージ化された Open XML 形式です。PPT に比べて PPTX は通常、ファイルサイズが小さく、最新機能をサポートし、ドキュメント自動化に適しており、長期保存やクロスプラットフォーム ワークフローに推奨されます。

### **PPT を PPTX に変換する**

Aspose.Slides は PPT プレゼンテーションを PPTX 形式に変換することをサポートしています。このタスクに Aspose.Slides API を使用する主な利点は、目的の結果を得るためのワークフローが非常にシンプルなことです。実際には、スライド、レイアウト、メディアの高忠実度を保ちながら、最小限のコードで変換を実行できます。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **プレゼンテーションを PDF に変換する**

### **PDF について**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) は、Adobe Systems が組織間で文書を交換するために作成したファイル形式です。その目的は、閲覧プラットフォームに関係なく文書の内容が同じ視覚的外観で表示されることを保証することです。

### **プレゼンテーションを PDF に変換する**

Aspose.Slides で読み込めるプレゼンテーションはすべて PDF 文書に変換できます。Aspose.Slides コンポーネントだけでプレゼンテーションを直接 PDF にエクスポートでき、サードパーティのライブラリや Aspose.PDF コンポーネントは必要ありません。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT と PPTX を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **プレゼンテーションを XPS に変換する**

### **XPS について**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) は、Microsoft が元々開発したページ記述言語および固定文書形式です。PDF と同様に、XPS は固定レイアウトの文書形式で、文書の忠実度を保持し、デバイスに依存しない外観を提供します。

### **プレゼンテーションを XPS に変換する**

Aspose.Slides で読み込めるプレゼンテーションはすべて XPS 形式に変換できます。Aspose.Slides は高忠実度のページレイアウトとレンダリングエンジンを使用して、固定レイアウトの XPS 形式で出力します。特筆すべきは、Windows Presentation Foundation (WPF) に依存せずに直接 XPS を生成する点です。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **プレゼンテーションを TIFF に変換する**

### **TIFF について**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) は、単一ファイル内に複数の画像（ページ）を保存できるラスター画像形式です。もともとは Aldus によって開発され、スキャン、FAX、その他の画像処理アプリケーションで広くサポートされています。

### **プレゼンテーションを TIFF に変換する**

Aspose.Slides で読み込めるドキュメントは、サードパーティ コンポーネントを使用せずに直接 TIFF ファイルに変換できます。さらに、生成される TIFF のページサイズをオプションで指定することも可能です。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**PDF/XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。エクスポート時に[PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) / [XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 設定の対応オプションで非表示スライドを含めることができます。

**アーカイブ保存用の PDF/A 形式での保存はサポートされていますか？**

はい、エクスポート時に[PDF/A 準拠レベル](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)（A-2a/A-2b/A-2u および A-3a/A-3b を含む）を選択できます。

**変換時のフォントは埋め込まれますか、置き換えられますか？**

柔軟なオプションがあります。すべての字形を埋め込むか使用されたサブセットのみを埋め込むかを[設定](/slides/ja/python-net/embedded-font/)でき、[代替フォント](/slides/ja/python-net/fallback-font/)を指定し、フォントに特定のスタイルがない場合の[動作](/slides/ja/python-net/font-substitution/)を制御できます。

**生成される PDF の品質とサイズはどのように制御できますか？**

[JPEG 品質](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[テキスト圧縮](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、画像の[十分な解像度](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)閾値、さらに[画像の最適圧縮率](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/)を選択するモードが利用可能です。

**スライドの範囲（例: 5–12）だけをエクスポートできますか？**

はい、エクスポート時にスライドのサブセットを選択できます。

**複数ファイルを同時にマルチコアで処理することはサポートされていますか？**

別々のプロセスで異なるプレゼンテーションを並列に処理することは可能です。重要なのは、同じ[プレゼンテーション]([https://reference.aspose.com/slides/python-net/aspose.slides/presentation/])オブジェクトを[複数スレッド](/slides/ja/python-net/multithreading/)からロードまたは保存しないことです。

**異なるスレッドからライセンスを適用する際のリスクはありますか？**

はい、[ライセンス設定](/slides/ja/python-net/licensing/)の呼び出しはスレッドセーフではなく、同期が必要です。