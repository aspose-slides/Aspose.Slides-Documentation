---
title: 使用 Python 管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/python-net/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 色彩
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 於 .NET 透過 Python 自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指引。"
---
## **概觀**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立和管理 SmartArt 圖形。本篇說明如何將 SmartArt 形狀加入投影片、存取現有的 SmartArt 形狀、依特定佈局類型搜尋 SmartArt，並透過變更 SmartArt 樣式或色彩樣式來更新其外觀。範例示範如何透過簡報投影片的形狀集合操作 SmartArt 形狀、檢查形狀是否為 SmartArt，然後修改或檢視其屬性。

## **建立 SmartArt 形狀**

Aspose.Slides for Python via .NET 允許您從頭開始在投影片上加入自訂 SmartArt 形狀。API 使此工作變得簡單。若要將 SmartArt 形狀加入投影片：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得目標投影片。
1. 加入 SmartArt 形狀，指定其佈局類型。
1. 將修改後的簡報儲存為 PPTX 檔。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:
    # 取得簡報投影片。
    slide = presentation.slides[0]
    # 新增 SmartArt 形狀。
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在投影片上存取 SmartArt 形狀**

以下程式碼示範如何在投影片上存取 SmartArt 形狀。範例會遍歷投影片上的每個形狀，並檢查它是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/) 物件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# 載入簡報檔案。
with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 形狀。
        if isinstance(shape, smartart.SmartArt):
            # 輸出形狀名稱。
            print("Shape name:", shape.name)
```

## **以指定佈局類型存取 SmartArt 形狀**

以下範例說明如何存取具有指定佈局類型的 SmartArt 形狀。請注意，SmartArt 的佈局類型無法變更——它是唯讀的，且於形狀建立時即設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 遍歷第一張投影片上的所有形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/) 物件。
1. 如果 SmartArt 形狀的佈局類型符合需求，執行所需的操作。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 形狀。
        if isinstance(shape, smartart.SmartArt):
            # 檢查 SmartArt 版面配置類型。
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **變更 SmartArt 形狀樣式**

以下範例說明如何定位 SmartArt 形狀並變更其樣式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 並載入包含 SmartArt 形狀的檔案。
1. 依索引取得第一張投影片的參照。
1. 遍歷第一張投影片上的每個形狀。
1. 尋找具有指定樣式的 SmartArt 形狀。
1. 將新樣式指派給 SmartArt 形狀。
1. 儲存簡報。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 形狀。
        if isinstance(shape, smartart.SmartArt):
            # 檢查 SmartArt 樣式。
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # 變更 SmartArt 樣式。
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **變更 SmartArt 形狀的色彩樣式**

此範例說明如何變更 SmartArt 形狀的色彩樣式。範例程式碼會定位具有指定色彩樣式的 SmartArt 形狀並更新它。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例並載入包含 SmartArt 形狀的簡報。
1. 依索引取得第一張投影片的參照。
1. 遍歷第一張投影片上的每個形狀。
1. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.smartart/smartart/) 物件。
1. 定位具有指定色彩樣式的 SmartArt 形狀。
1. 為該 SmartArt 形狀設定新的色彩樣式。
1. 儲存簡報。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # 遍歷第一張投影片上的每個形狀。
    for shape in presentation.slides[0].shapes:
        # 檢查形狀是否為 SmartArt 形狀。
        if isinstance(shape, smartart.SmartArt):
            # 檢查顏色類型。
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # 變更顏色類型。
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫效果嗎？**

是的。SmartArt 是形狀，因此您可以像對其他形狀一樣，透過動畫 API 套用 [standard animations](/slides/zh-hant/python-net/powerpoint-animation/)（進入、退出、強調、動作路徑）等動畫效果。

**如果我不知道 SmartArt 的內部 ID，該如何在投影片上找到特定的 SmartArt？**

設定並使用替代文字（AltText），並以該值搜尋形狀——這是定位目標形狀的建議做法。

**我可以將 SmartArt 與其他形狀群組嗎？**

是的。您可以將 SmartArt 與其他形狀（圖片、表格等）群組，然後 [manipulate the group](/slides/zh-hant/python-net/group/)。

**我該如何取得特定 SmartArt 的影像（例如，用於預覽或報告）？**

匯出該形狀的縮圖/影像；此函式庫可以將 [render individual shapes](/slides/zh-hant/python-net/create-shape-thumbnails/) 轉換為點陣檔（PNG/JPG/TIFF）。

**將整份簡報轉換為 PDF 時，SmartArt 外觀會被保留嗎？**

是的。渲染引擎針對 [PDF export](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) 追求高保真度，並提供多種品質與相容性選項。