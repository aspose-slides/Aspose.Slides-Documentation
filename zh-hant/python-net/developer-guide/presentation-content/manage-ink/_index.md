---
title: 在 Python 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/python-net/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡呈現
- 隱藏墨跡
- InkOptions
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件，編輯軌跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 及影像匯出過程中，使用 Aspose.Slides for Python via .NET 控制墨跡外觀。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您可以繪製自由形式的筆劃。墨跡可用於標示其他物件、顯示連接與流程，並將注意力集中在投影片中的特定項目上。

[aspose.slides.ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/) 命名空間包含處理墨跡物件所需的類別。例如，[Ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/ink/) 類別代表投影片上的墨跡物件。

## **一般物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件表示。以最簡單的形式，形狀是一個容器，用於定義物件本身的區域（其框架），以及容器大小、形狀和背景等屬性。更多資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/python-net/shape-manipulations/#access-layout-formats-for-shape)。

但是，當 PowerPoint 處理墨跡物件時，會忽略除大小之外的所有框架（容器）屬性。容器區域的大小由標準的 [Ink.width](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/ink/width/) 與 [Ink.height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/ink/height/) 屬性決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡軌跡**

墨跡軌跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。軌跡會儲存一系列相連的點。

最簡單的編碼形式會指定每個取樣點的 X 與 Y 座標。當所有相連的點被繪製時，會產生如下圖所示的影像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡軌跡點的線條。[InkBrush.color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/inkbrush/color/) 與 [InkBrush.size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/inkbrush/size/) 屬性分別控制其顏色與大小。

### **設定墨跡筆刷顏色**

以下 Python 程式碼示範如何設定墨跡筆刷的顏色：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **設定墨跡筆刷大小**

以下 Python 程式碼示範如何設定墨跡筆刷的大小：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

一般而言，筆刷的寬度與高度不相同，PowerPoint 因此不會顯示筆刷大小（對應的資料區段為灰色）。當筆刷的寬度與高度相同時，PowerPoint 會如以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明更加清楚，我們將增加墨跡物件的高度，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的尺寸——它總是假設線條粗細為零（請參考前圖）。

因此，要確定整個墨跡物件的可見區域，必須將其軌跡的筆刷尺寸納入考量。此處，目標物件（手寫文字軌跡）已被縮放至容器（框架）的大小。當容器尺寸變更時，筆刷尺寸保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似的行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **在匯出與呈現期間控制墨跡外觀**

Aspose.Slides 提供 [InkOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/) 類別，用於控制墨跡物件在匯出或呈現輸出時的顯示方式。您可以利用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的解讀方式。

多種輸出類型的匯出或呈現選項中皆提供墨跡選項：

| 輸出 | Ink 選項屬性 |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/ink_options/) |

這些屬性提供以下兩個設定：

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/hide_ink/) 決定是否將墨跡物件納入輸出。預設值為 `False`。
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 決定在渲染墨跡筆刷時，遮罩操作是否被解讀為不透明度。預設值為 `True`；若設為 `False`，則改為使用 ROP 操作。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，墨跡物件在匯出時仍會顯示。若需要沒有手寫批註或其他墨跡內容的純淨輸出，請將 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/hide_ink/) 設為 `True`。

以下 Python 範例會將簡報匯出為 PDF，並隱藏所有墨跡物件：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **在將投影片呈現為影像時隱藏墨跡物件**

若要在將投影片渲染為點陣圖影像時隱藏墨跡物件，請設定 [RenderingOptions.ink_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/renderingoptions/ink_options/)，並將渲染選項傳遞給 [Slide.get_image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/) 方法。

以下 Python 範例會將第一張投影片渲染為 PNG 影像，且不含墨跡物件：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **控制墨跡遮罩呈現**

[InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 屬性控制在渲染墨跡筆刷時，遮罩操作的解讀方式。預設值為 `True`，使用不透明度。將此屬性設為 `False` 則改為使用 ROP 操作。

以下 Python 範例會將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩呈現方式：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

在匯出簡報或將投影片渲染為 TIFF 時，也可透過 [TiffOptions.ink_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/ink_options/) 套用相同設定。

### **選擇隱藏或保留墨跡**

若匯出檔案應為已註釋簡報的純淨版本（例如，供發行且不含審閱標記的最終稿），請將 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/hide_ink/) 設為 `True`。

若墨跡註釋屬於預期內容（如審閱意見、手寫筆記、標記或應保留於匯出結果中的繪圖），則保留 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/hide_ink/) 的預設值 `False`。這讓應用程式能在同一簡報上產生分別的審閱與最終輸出，而無需修改來源墨跡物件。

## **常見問題**

**我可以變更現有墨跡筆劃的顏色或大小嗎？**

可以。從 [Ink.traces](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/ink/traces/) 取得軌跡，然後變更其 [InkTrace.brush](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/inktrace/brush/) 。您可以設定筆刷的 [InkBrush.color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/inkbrush/color/) 與 [InkBrush.size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/inkbrush/size/) 屬性。

**隱藏墨跡會改變來源簡報嗎？**

不會。[InkOptions.hide_ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/inkoptions/hide_ink/) 僅影響渲染或匯出的結果，並不會移除或修改來源簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可透過上述相對應的匯出或呈現選項，為 PDF、HTML、SVG、TIFF 與點陣圖投影片影像設定墨跡選項。

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/python-net/powerpoint-shapes/) 章節。
* 如需取得有效值的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/python-net/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細資訊，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細資訊，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/python-net/convert-powerpoint-to-tiff/)。
* 有關投影片轉影像的渲染資訊，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/python-net/convert-slide/).