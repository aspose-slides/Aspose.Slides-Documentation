---
title: 使用 Python 在簡報中管理墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/python-net/manage-ink/
keywords:
- ink
- ink object
- ink trace
- manage ink
- draw ink
- drawing
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理 PowerPoint 墨跡物件—建立、編輯與樣式化數位墨跡。取得追蹤、筆刷顏色與大小的程式範例。"
---
## **簡介**

PowerPoint 提供了墨跡功能，允許您繪製非標準圖形，可用於突顯其他物件、顯示連接與流程，並將注意力引導至投影片上的特定項目。

Aspose.Slides 提供了 [aspose.slides.ink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ink/) 名稱空間，其中包含建立和管理墨跡物件所需的類型。

## **常規物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件 (shape) 來表示。形狀物件在最簡單的形式下是定義物件本身區域（其框架）及其屬性的容器。後者包括容器區域大小、容器形狀、容器背景等。相關資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/python-net/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，它會忽略除尺寸之外的所有框架（容器）屬性。容器區域的尺寸由標準的 `width` 和 `height` 值決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡形狀追蹤**

追蹤是用於記錄使用者書寫數位墨跡時筆的軌跡的基本元素或標準。追蹤是描述連接點序列的錄製。

最簡單的編碼形式指定每個樣本點的 X 與 Y 坐標。當所有連接點渲染完畢時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖的筆刷屬性**

您可以使用筆刷來繪製連接追蹤元素點的線條。筆刷具有自己的顏色與大小，分別對應於 `Brush.color` 和 `Brush.size` 屬性。

### **設定墨跡筆刷顏色**

此 Python 程式碼示範如何為筆刷設定顏色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **設定墨跡筆刷大小**

此 Python 程式碼示範如何為筆刷設定大小：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

一般而言，筆刷的寬度與高度不相同，PowerPoint 不會顯示筆刷大小（資料區段為灰色）。但當筆刷寬度與高度相同時，PowerPoint 會以此方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚說明，讓我們增加墨跡物件的高度，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的尺寸——它永遠假設線條的粗細為零（見最後的圖像）。

因此，要確定整個墨跡物件的可見範圍，必須考慮追蹤物件的筆刷尺寸。此處，目標物件（手寫文字追蹤物件）已按容器（框架）尺寸縮放。當容器（框架）尺寸變更時，筆刷尺寸保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在處理文字時也會呈現相同的行為：

![ink_powerpoint6](ink_powerpoint6.png)

**進一步閱讀**

* 若要了解一般形狀的資訊，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/python-net/powerpoint-shapes/)。
* 若需更深入了解有效值，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/python-net/shape-effective-properties/#get-effective-font-height-value)。