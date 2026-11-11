---
title: Pythonでハンドアウトモードにプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Pythonでプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF や画像にエクスポートできます。サンプルコード付きです。無料でお試しください。"
---
## **概要**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換でき、Handout モードで印刷用の配布資料を作成する機能も提供します。このモードでは、1 ページに複数のスライドをどのように配置するかを設定できるため、会議やセミナーなどのイベントで便利です。`slides_layout_options` プロパティを設定することで、このモードを有効にできます。対象クラスは [PdfOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/) です。

エクスポート前に配布ページのサイズや向きを設定するには、[Notes Page Size](/slides/ja/python-net/notes-size/) を参照してください。

## **配布モードのエクスポート**

配布モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、配布モードでプレゼンテーションを PDF に変換するコード例です。

```py
import aspose.slides as slides

# プレゼンテーションを読み込みます。
with slides.Presentation("sample.pptx") as presentation:

    # エクスポート オプションを設定します。
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 1ページに横方向に4枚のスライド
    slides_layout_options.print_slide_numbers = True                                 # スライド番号を印刷
    slides_layout_options.print_frame_slide = True                                   # スライドの周囲にフレームを印刷
    slides_layout_options.print_comments = False                                     # コメントなし

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
`slides_layout_options` プロパティは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **よくある質問**

**配布モードでページあたりに表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handouttype/) により、ページあたり最大 9 枚のサムネイルを横方向または縦方向の順序でサポートします。対応するレイアウトは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドを設定できますか？**

できません。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/handouttype/) 列挙体で厳密に制御されており、任意のレイアウトはサポートされていません。

**隠しスライドを配布出力に含めることはできますか？**

できます。対象フォーマットのエクスポート設定で `show_hidden_slides` オプションを有効にしてください。例: [PdfOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/tiffoptions/)。