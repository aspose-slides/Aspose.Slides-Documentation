---
title: Pythonでプレゼンテーションを複数のフォーマットに変換
linktitle: プレゼンテーションの変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
keywords:
- プレゼンテーションの変換
- プレゼンテーションのエクスポート
- PPTからPPTXへ
- PPTからPDFへ
- PPTXからPDFへ
- PPTからXPSへ
- PPTXからXPSへ
- PPTからTIFFへ
- PPTXからTIFFへ
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを PPTX、PDF、XPS、TIFF などへ簡単かつ高品質に変換します。"
---

## **イントロダクション**

このページでは、Aspose.Slides for Python via .NET を使用したプレゼンテーション変換の概要を提供します。サポートされているシナリオをまとめ、PDF、XPS、TIFF へのエクスポートや PPT と PPTX 間の変換など、具体的なコード例を示すガイドへのリンクを紹介します。関連する記事では、ノートのレンダリングや画像品質の調整など、フォーマット固有のオプションや、PPT→PPTX パスでの部分的なサポートといった既知の制限事項にも触れています。このページを使って変換したいターゲットフォーマットを選び、リンク先の手順に従ってください。

## **PPT から PPTX への変換**

### **PPT/PPTX について**

PPT は古いバイナリ形式の PowerPoint（97–2003）で、PPTX は PowerPoint 2007 で導入された ZIP パッケージの Open XML 形式です。PPT と比べて PPTX は通常ファイルサイズが小さく、最新機能をサポートし、ドキュメント自動化にも適しており、長期保存やクロスプラットフォームのワークフローに推奨されます。

### **PPT を PPTX に変換する**

Aspose.Slides は PPT プレゼンテーションを PPTX 形式に変換することをサポートしています。このタスクに Aspose.Slides API を使用する主な利点は、目的の結果を得るためのワークフローが非常にシンプルであることです。実際には、最小限のコードで変換を実行でき、スライド、レイアウト、メディアの高忠実度を保ちます。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/)。
{{% /alert %}}

## **プレゼンテーションの PDF への変換**

### **PDF について**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF)（PDF）は、Adobe Systems が文書の交換のために作成したファイル形式です。文書の内容が、閲覧するプラットフォームに関係なく同一のビジュアルで表示されることを目的としています。

### **プレゼンテーションを PDF に変換する**

Aspose.Slides で読み込めるすべてのプレゼンテーションは、PDF ドキュメントに変換できます。Aspose.Slides コンポーネントだけでプレゼンテーションを直接 PDF にエクスポートでき、サードパーティのライブラリや Aspose.PDF コンポーネントは不要です。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT & PPTX を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/)。
{{% /alert %}}

## **プレゼンテーションの XPS への変換**

### **XPS について**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)（XPS）は、Microsoft が開発したページ記述言語および固定文書形式です。PDF と同様に、XPS は固定レイアウトの文書形式で、文書の忠実性を保ち、デバイスに依存しない外観を提供します。

### **プレゼンテーションを XPS に変換する**

Aspose.Slides が読み込める任意のプレゼンテーションは、XPS 形式に変換できます。Aspose.Slides は高忠実度のページレイアウトおよびレンダリングエンジンを使用して、固定レイアウトの XPS 形式で出力します。特に、Windows Presentation Foundation（WPF）に依存せずに直接 XPS を生成します。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/)。
{{% /alert %}}

## **プレゼンテーションの TIFF への変換**

### **TIFF について**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF)（TIFF）は、単一ファイル内に複数の画像（ページ）を格納できるラスター画像形式です。もともと Aldus が開発し、スキャン、FAX、その他画像処理アプリケーションで広くサポートされています。

### **プレゼンテーションを TIFF に変換する**

Aspose.Slides が読み込める任意のドキュメントは、サードパーティコンポーネントを使用せずに直接 TIFF ファイルに変換できます。さらに、生成される TIFF のページサイズを任意に指定することも可能です。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)。
{{% /alert %}}

## **FAQ**

**PDF/XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。エクスポート時に [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) / [XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 設定の該当オプションで非表示スライドを含めることができます。

**アーカイブ保存用の PDF/A 形式での保存はサポートされていますか？**

はい。エクスポート時に PDF/A 準拠レベル（A-2a/A-2b/A-2u および A-3a/A-3b）が[利用可能](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)です。

**変換時のフォントは埋め込まれますか、それとも置換されますか？**

柔軟なオプションがあります。すべてのグリフを埋め込むか使用されたサブセットのみを埋め込むかを[選択](/slides/ja/python-net/embedded-font/)でき、[代替フォント](/slides/ja/python-net/fallback-font/)を指定し、フォントに必要なスタイルが欠けている場合の[動作を制御](/slides/ja/python-net/font-substitution/)できます。

**生成される PDF の品質とサイズをどのように制御できますか？**

[JPEG 品質](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[テキスト圧縮](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、画像の[十分な解像度](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)しきい値、そして画像の[最適な圧縮率](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/)を選択できるモードがあります。

**スライドの範囲（例: 5–12）だけをエクスポートできますか？**

はい、エクスポート時にスライドのサブセットを選択できます。

**複数ファイルを同時にマルチコアで処理することはサポートされていますか？**

別プロセスでプレゼンテーションを並列に処理することは可能です。重要: 同じ [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトを [複数スレッド](/slides/ja/python-net/multithreading/) から読み込んだり保存したりしてはいけません。

**異なるスレッドからライセンスを設定する際のリスクはありますか？**

はい、[ライセンス設定](/slides/ja/python-net/licensing/) 呼び出しはスレッドセーフではなく、同期が必要です。