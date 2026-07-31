---
title: Pythonでハンドアウトモードにプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Pythonでプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slidesを使用してPDFまたは画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換できる機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定できるため、会議やセミナー、その他のイベントで便利です。`slides_layout_options` プロパティを [PdfOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/) クラスで設定することでこのモードを有効にできます。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```py
# プレゼンテーションを読み込みます。
with slides.Presentation("sample.pptx") as presentation:

    # エクスポート オプションを設定します。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 1ページに横方向で4枚のスライド
    slides_layout_options.print_slide_numbers = True                                 # スライド番号を印刷
    slides_layout_options.print_frame_slide = True                                   # スライドの枠を印刷
    slides_layout_options.print_comments = False                                     # コメントはなし

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
`slides_layout_options` プロパティは、PDF、HTML、TIFF などの特定の出力形式、および画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **FAQ**

**ハンドアウトモードで1ページあたり表示できるスライドサムネイルの最大数はどれくらいですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handouttype/) をサポートしており、横または縦方向の配置で最大 9 枚のサムネイルを1ページに表示できます。利用可能な設定は、1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定（例: [PdfOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/)）で `show_hidden_slides` オプションを有効にしてください。