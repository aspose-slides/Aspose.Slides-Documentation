---
title: "Python を使用したハンドアウト モードでの PowerPoint プレゼンテーションの変換"
linktitle: "ハンドアウト モード"
type: docs
weight: 150
url: /ja/python-java/convert-powerpoint-in-handout-mode/
keywords:
- "PowerPoint の変換"
- "プレゼンテーションの変換"
- "ハンドアウト モード"
- "ハンドアウト"
- "PPT"
- "PPTX"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python via Java で PowerPoint プレゼンテーションをハンドアウトに変換します。複数のスライドをページに配置し、Aspose.Slides を使用して PDF にエクスポートします。"
---
## **はじめに**

Aspose.Slides for Python via Java は、ハンドアウト モードでプレゼンテーションをエクスポートし、1 ページに複数のスライドを配置できます。これは、会議、セミナー、その他のイベント向けにプレゼンテーション資料を印刷する際に便利です。

レイアウトは [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) メソッドで構成します。ハンドアウト レイアウトは [PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/)、および [TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) でサポートされます。レイアウトと表示設定を指定するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。

エクスポート前にハンドアウトページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/python-java/notes-size/) を参照してください。

## **ハンドアウト モードのエクスポート**

ハンドアウト モードでプレゼンテーションをエクスポートするには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handoutlayoutingoptions/) のインスタンスを作成し、[setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) を使用して対象のエクスポート オプションに割り当てます。

以下の例は `sample.pptx` を読み込み、横方向に 1 ページあたり 4 スライドで PDF にエクスポートします。スライド番号とスライド枠が含まれ、コメントは除外されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# プレゼンテーションを読み込む。
presentation = Presentation("sample.pptx")
try:
    # ハンドアウト レイアウトを設定する。
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # 選択したレイアウトでプレゼンテーションを PDF にエクスポートする。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
ハンドアウト レイアウト設定は、PDF、HTML、TIFF、レンダリング画像などのサポートされた出力形式に適用されます。これらは元のプレゼンテーションのスライド順序を変更しません。
{{% /alert %}}

## **よくある質問**

**ハンドアウト モードでページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、ページあたり最大 9 つのサムネイルをサポートします。[HandoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handouttype/) のプリセットは、1、2、3、4、6、または 9 スライドをページあたりで提供します。4、6、9 スライドのプリセットは、横方向と縦方向の順序付けをサポートします。

**5 枚や 8 枚など、カスタム グリッドを定義できますか？**

いいえ。サムネイルの数と順序は、事前定義された [HandoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handouttype/) の値で制御されます。任意のグリッドはこれらのハンドアウト レイアウト設定ではサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で非表示スライドを有効にします。PDF の場合は、プレゼンテーションを保存する前に `True` を指定して [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) を呼び出します。