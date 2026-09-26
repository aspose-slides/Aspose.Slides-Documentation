---
title: 使用 Python 在講義模式下轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/python-java/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Python 透過 Java 將 PowerPoint 簡報轉換為講義。將多張投影片排列在每頁上，並使用 Aspose.Slides 匯出為 PDF。"
---
## **介紹**

Aspose.Slides for Python via Java 允許您以講義模式匯出簡報，將多張投影片排佈在單一頁面上。此功能對於列印會議、研討會及類似活動的簡報材料非常有用。

可透過 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 方法設定版面配置。講義佈局受到 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/) 與 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 的支援。使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/handoutlayoutingoptions/) 物件來指定版面與顯示設定。

若要在匯出前設定講義頁面的尺寸與方向，請參閱 [Notes Page Size](/slides/zh-hant/python-java/notes-size/)。

## **講義模式匯出**

若要以講義模式匯出簡報，請建立 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/handoutlayoutingoptions/) 實例，並使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 將其指派給目標匯出選項。

以下範例載入 `sample.pptx`，並以每頁四張投影片的水平排列方式匯出為 PDF。範例會包含投影片編號與投影片框線，且不會匯出註解。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("sample.pptx")
try:
    # 設定講義版面配置。
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # 使用選擇的版面將簡報匯出為 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="警告" %}}
講義版面設定適用於支援的輸出格式，例如 PDF、HTML、TIFF 與已渲染的影像。它們不會重新排列來源簡報中的投影片順序。
{{% /alert %}}

## **常見問題**

**在講義模式下，每頁最大可顯示多少張投影片縮圖？**

Aspose.Slides 在每頁最多支援九張縮圖。[HandoutType] 預設提供每頁顯示一、二、三、四、六或九張投影片的配置。四、六、九張投影片的預設同時提供水平與垂直排序方式。

**我可以自訂格線，例如每頁五張或八張投影片嗎？**

不行。縮圖的數量與排列方式由預先定義的 [HandoutType] 值決定。這些講義版面設定不支援任意的格線配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中啟用隱藏投影片。對於 PDF，於儲存簡報前呼叫 [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 並傳入 `True`。