---
title: Pythonでハンドアウトモードのプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/python-net/convert-powerpoint-in-Handout-mode/
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
description: "Pythonでプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.SlidesでPDFまたは画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---

## **ハンドアウトモード エクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントに便利です。`slides_layout_options` プロパティを設定することで、このモードを有効にできます。対象のクラスは [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)、および [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) です。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメーターを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```py
# プレゼンテーションを読み込みます。
with slides.Presentation("sample.pptx") as presentation:

    # エクスポート オプションを設定します。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 1ページにスライドを横方向に4枚配置
    slides_layout_options.print_slide_numbers = True                                 # スライド番号を印刷
    slides_layout_options.print_frame_slide = True                                   # スライドの周囲にフレームを印刷
    slides_layout_options.print_comments = False                                     # コメントなし

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 
`slides_layout_options` プロパティは、PDF、HTML、TIFF などの特定の出力形式や、画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードで 1 ページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) に対応しており、横方向または縦方向の並びで、1ページあたり最大 9 枚のサムネイルを配置できます。利用できるオプションは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。対象の形式のエクスポート設定で `show_hidden_slides` オプションを有効にします。たとえば [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) です。