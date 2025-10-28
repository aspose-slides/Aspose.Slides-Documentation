---
title: Python でプレゼンテーションを複数形式に変換する
linktitle: プレゼンテーションを変換
type: docs
weight: 70
url: /ja/python-net/convert-presentation/
keywords:
- プレゼンテーションの変換
- プレゼンテーションのエクスポート
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

## **イントロダクション**

このページでは、Aspose.Slides for Python via .NET を使用したプレゼンテーション変換の概要を紹介します。サポートされているシナリオをまとめ、PDF、XPS、TIFF へのエクスポートや PPT と PPTX 間の変換など、具体的なコード例を示すガイドへのリンクを提供します。関連する記事では、ノートのレンダリングや画像品質の調整といった形式固有のオプションや、PPT→PPTX パスにおける部分的なサポート制限なども取り上げています。このページを利用して対象形式を選択し、リンク先のレシピに従ってください。

## **PPT から PPTX への変換**

### **PPT/PPTX について**

PPT は PowerPoint の旧バイナリ形式（97〜2003）であり、PPTX は PowerPoint 2007 で導入された ZIP 圧縮の Open XML 形式です。PPT に比べて PPTX は通常、ファイルサイズが小さく、最新機能をサポートし、文書自動化との相性が良く、長期保存やクロスプラットフォーム ワークフローに推奨されます。

### **PPT を PPTX に変換**

Aspose.Slides は PPT プレゼンテーションを PPTX 形式に変換することをサポートしています。このタスクに Aspose.Slides API を使用する主な利点は、目的の結果を得るためのワークフローが非常にシンプルであることです。実際には、最小限のコードでスライド、レイアウト、メディアの高忠実度を保ったまま変換を実行できます。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT を PPTX に変換](/slides/ja/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **プレゼンテーションを PDF に変換**

### **PDF について**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF)（PDF）は、Adobe Systems が文書のやり取りのために作成したファイル形式です。目的は、閲覧プラットフォームに関係なく、文書の内容が同一の視覚的外観で表示されることを保証することです。

### **プレゼンテーションを PDF に変換**

Aspose.Slides で読み込めるすべてのプレゼンテーションは、PDF ドキュメントに変換できます。Aspose.Slides コンポーネントだけでプレゼンテーションを直接 PDF にエクスポートでき、サードパーティ ライブラリや Aspose.PDF コンポーネントは必要ありません。

{{% alert color="primary" %}}
詳しく読む: [Python で PPT と PPTX を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **プレゼンテーションを XPS に変換**

### **XPS について**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)（XPS）は、Microsoft が最初に開発したページ記述言語および固定文書形式です。PDF と同様に、XPS は固定レイアウトの文書形式で、文書の忠実性を保持し、デバイスに依存しない外観を提供します。

### **プレゼンテーションを XPS に変換**

Aspose.Slides が読み込めるすべてのプレゼンテーションは、XPS 形式に変換できます。Aspose.Slides は高忠実度のページレイアウトおよびレンダリング エンジンを使用して、固定レイアウトの XPS 形式で出力します。特筆すべきは、Aspose.Slides が Windows Presentation Foundation（WPF）に依存せずに直接 XPS を生成する点です。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを XPS に変換](/slides/ja/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **プレゼンテーションを TIFF に変換**

### **TIFF について**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF)（TIFF）は、単一ファイル内に複数の画像（ページ）を格納できるラスタ画像形式です。もともとは Aldus が開発し、スキャン、FAX、その他画像処理アプリケーションで広くサポートされています。

### **プレゼンテーションを TIFF に変換**

Aspose.Slides が読み込めるすべてのドキュメントは、サードパーティ コンポーネントを使用せずに直接 TIFF ファイルに変換できます。さらに、生成される TIFF の各ページの画像サイズを任意で指定することも可能です。

{{% alert color="primary" %}}
詳しく読む: [Python で PowerPoint プレゼンテーションを TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**PDF/XPS にエクスポートする際に非表示スライドを含めることはできますか？**

はい。エクスポート時に、[PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) および [XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 設定の対応オプションで非表示スライドを含めることができます。

**PDF/A 形式（アーカイブ保存用）への保存はサポートされていますか？**

はい。エクスポート時に [PDF/A 準拠レベル](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)（A-2a/A-2b/A-2u および A-3a/A-3b を含む）を指定できます。

**変換時のフォントは埋め込まれますか、それとも置き換えられますか？**

柔軟なオプションがあります。すべての字形を埋め込むか使用されたサブセットだけを埋め込むかを選択でき、[代替フォント](/slides/ja/python-net/fallback-font/) を指定したり、フォントに特定のスタイルが欠けている場合の動作を [制御](/slides/ja/python-net/font-substitution/) できます。

**生成される PDF の品質とサイズはどのように制御できますか？**

[JPEG 品質](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[テキスト圧縮](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、画像の [十分な解像度](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) のしきい値、さらには [画像に最適な圧縮モード](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) を選択できます。

**スライドの範囲（例: 5–12）のみをエクスポートすることは可能ですか？**

はい。エクスポート時にスライドのサブセットを選択できます。

**複数ファイルを同時にマルチコアで処理することはサポートされていますか？**

別プロセスでプレゼンテーションを並列に処理することは許容されます。ただし、同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトを [複数スレッド](/slides/ja/python-net/multithreading/) から同時にロードまたは保存しないでください。

**異なるスレッドからライセンスを設定する際のリスクはありますか？**

はい、[ライセンス設定](/slides/ja/python-net/licensing/) の呼び出しはスレッドセーフではなく、同期が必要です。