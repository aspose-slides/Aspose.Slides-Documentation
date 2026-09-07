---
title: Python を使用したハンドアウトモードでの PowerPoint プレゼンテーション変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java 経由）で PowerPoint プレゼンテーションをハンドアウトに変換します。1 ページに複数のスライドを配置し、Aspose.Slides を使用して PDF にエクスポートできます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、ハンドアウトモードでプレゼンテーションをエクスポートでき、1 ページに複数のスライドを配置できます。これは、会議やセミナー、その他のイベント用にプレゼンテーション資料を印刷する際に便利です。

レイアウトは [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) メソッドで構成します。ハンドアウトレイアウトは [PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/) でサポートされています。[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用して、レイアウトと表示設定を指定します。

## **ハンドアウトモードでのエクスポート**

ハンドアウトモードでプレゼンテーションをエクスポートするには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handoutlayoutingoptions/) インスタンスを作成し、[setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) を使用して対象のエクスポートオプションに割り当てます。

以下の例は `sample.pptx` を読み込み、横方向に 1 ページあたり 4 スライドで PDF にエクスポートします。スライド番号とスライドの枠が含まれ、コメントは除外されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# プレゼンテーションをロードします。
presentation = Presentation("sample.pptx")
try:
    # ハンドアウトレイアウトを設定します。
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
ハンドアウトレイアウト設定は PDF、HTML、TIFF、レンダリング画像などのサポートされている出力形式に適用されます。元のプレゼンテーションのスライド順序は変更されません。
{{% /alert %}}

## **FAQ**

**ハンドアウトモードで 1 ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は最大でページあたり 9 枚のサムネイルをサポートしています。[HandoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handouttype/) のプリセットは、1、2、3、4、6、または 9 スライドを 1 ページに配置できます。4、6、9 スライドのプリセットは横方向および縦方向の順序を提供します。

**5 枚または 8 枚などのカスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は事前定義された [HandoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/handouttype/) の値で制御されます。任意のグリッドはこれらのハンドアウトレイアウト設定ではサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で非表示スライドを有効にします。PDF の場合は、プレゼンテーションを保存する前に `True` を指定して [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) を呼び出します。