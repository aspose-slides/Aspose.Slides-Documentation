---
title: 使用 Python via Java 管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/python-java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡痕跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡轉譯
- 隱藏墨跡
- InkOptions
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件，編輯痕跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 以及影像匯出時控制墨跡外觀，使用 Aspose.Slides for Python via Java。"
---
## **簡介**

PowerPoint 提供了墨跡功能，可讓您繪製自由形式的筆畫。墨跡可用於突出顯示其他物件、說明連接與流程，並將注意力引導至投影片上的特定項目。

Aspose.Slides 提供了操作墨跡物件所需的型別。例如，[Ink](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ink/) 類別代表投影片上的墨跡物件。

## **常規物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀物件表示。最簡單的形式中，形狀是一個容器，定義了物件本身的區域（其框架）以及容器大小、形狀和背景等屬性。更多資訊，請參閱[形狀版面格式](/slides/zh-hant/python-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略框架（容器）的所有屬性，只保留其大小。容器區域的大小由標準的[Shape.getWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getWidth)和[Shape.getHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getHeight) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡痕跡**

墨跡痕跡是用來記錄使用者書寫數位墨跡時筆的軌跡的基本元素。痕跡儲存一系列相連的點。

最簡單的編碼形式指定每個取樣點的 X 與 Y 座標。當所有相連點被呈現時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡痕跡點的線條。筆刷具有自己的顏色與尺寸，由[InkBrush.getColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkbrush/#getColor)和[InkBrush.getSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkbrush/#getSize) 方法表示。

### **設定墨跡筆刷顏色**

以下 Python 程式碼示範如何設定墨跡筆刷的顏色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **設定墨跡筆刷尺寸**

以下 Python 程式碼示範如何設定墨跡筆刷的尺寸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

一般而言，筆刷的寬度與高度不相等，PowerPoint 不會顯示筆刷尺寸（相應的資料區段呈現灰色）。當筆刷寬度與高度相等時，PowerPoint 會以以下方式顯示其尺寸：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，我們將墨跡物件的高度提升，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條粗細為零（見前圖）。

因此，若要確定整個墨跡物件的可見區域，必須將其痕跡的筆刷尺寸納入考慮。此處，目標物件（手寫文字痕跡）已被縮放至容器（框架）的大小。當容器大小變更時，筆刷尺寸保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **在匯出與轉譯期間控制墨跡外觀**

Aspose.Slides 提供[InkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/) 類別，讓您控制墨跡物件在匯出或轉譯輸出中的呈現方式。您可以使用其屬性來完全隱藏墨跡，或變更墨跡筆刷遮罩操作的詮釋方式。

墨跡選項可透過多種輸出類型的匯出或轉譯選項取得：

| 輸出 | Ink 選項屬性 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| 投影片圖像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/#getInkOptions) |

以下[InkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/) 方法提供相同的兩個設定：

- [getHideInk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#getHideInk) 決定是否在輸出中包含墨跡物件。預設值為 `False`。
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 決定在轉譯墨跡筆刷時，遮罩操作是否詮釋為不透明度。預設值為 `True`；如需改為使用 ROP 操作，請以 `False` 呼叫[setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，匯出時會保留墨跡物件。如需產生不含手寫批註或其他墨跡內容的乾淨輸出，請以 `True` 呼叫[InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#setHideInk)。

以下 Python 範例將簡報匯出為 PDF，同時隱藏全部墨跡物件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **在將投影片轉譯為影像時隱藏墨跡物件**

若要在將投影片轉譯為點陣圖影像時隱藏墨跡物件，請設定[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/renderingoptions/#getInkOptions)，並將轉譯選項傳遞給[Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)。

以下 Python 範例將第一張投影片轉譯為 PNG 影像，且不含墨跡物件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **控制墨跡遮罩的轉譯方式**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 設定控制在轉譯墨跡筆刷時遮罩操作的詮釋方式。預設值 `True` 代表使用不透明度。若要改為使用 ROP 操作，請以 `False` 呼叫[InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)。

以下 Python 範例將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩轉譯：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

相同設定也可透過[TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#getInkOptions) 在匯出簡報或將投影片轉譯為 TIFF 時套用。

### **選擇隱藏或保留墨跡**

當您需要為發佈而產生不含批註標記的乾淨版本時，請於匯出期間以 `True` 呼叫[InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#setHideInk)。

當墨跡批註是預期內容（如審閱意見、手寫筆記、重點標記或需保留的圖形）時，請保持[InkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#getHideInk) 的預設值 `False`。這讓應用程式能以同一簡報產生分開的審閱版與最終版，而無需修改來源墨跡物件。

## **常見問題**

**我可以變更既有墨跡筆劃的顏色或大小嗎？**

可以。先從[Ink.getTraces](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ink/#getTraces) 取得痕跡，然後變更其[InkTrace.getBrush](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inktrace/#getBrush)。呼叫[InkBrush.setColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkbrush/#setColor)或[InkBrush.setSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkbrush/#setSize) 即可改變筆刷。

**隱藏墨跡會改變來源簡報嗎？**

不會。呼叫[InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/inkoptions/#setHideInk) 只會影響轉譯或匯出的結果；不會移除或修改來源簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可以透過上述對應的匯出或轉譯選項，為 PDF、HTML、SVG、TIFF 與點陣圖投影片影像設定墨跡選項。

**進一步閱讀**

* 若要了解一般形狀，請參閱[PowerPoint 形狀](/slides/zh-hant/python-java/powerpoint-shapes/)章節。
* 若需了解有效值，請參閱[形狀有效屬性](/slides/zh-hant/python-java/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細資訊，請參閱[將 PPT 與 PPTX 轉換為 PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細資訊，請參閱[將 PowerPoint 簡報轉換為 HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細資訊，請參閱[將簡報投影片轉譯為 SVG 影像](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細資訊，請參閱[將 PowerPoint 簡報轉換為 TIFF](/slides/zh-hant/python-java/convert-powerpoint-to-tiff/)。
* 有關投影片轉譯為影像的詳細資訊，請參閱[將簡報投影片轉換為影像](/slides/zh-hant/python-java/convert-slide/).