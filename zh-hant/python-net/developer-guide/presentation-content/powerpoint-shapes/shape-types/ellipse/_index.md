---
title: 在 Python 中為簡報新增橢圓
linktitle: 橢圓
type: docs
weight: 30
url: /zh-hant/python-net/ellipse/
keywords:
- 橢圓
- 形狀
- 新增橢圓
- 建立橢圓
- 繪製橢圓
- 格式化橢圓
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中建立、格式化與操作橢圓形狀，適用於 PPT、PPTX 與 ODP 簡報——附帶程式碼範例。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中加入橢圓形狀。內容涵蓋建立簡單橢圓、建立格式化橢圓，以及將更新後的簡報儲存為 PPTX 檔案。也會提及相關問題，例如處理橢圓的位置與大小、控制堆疊順序，以及套用動畫效果。

## **建立橢圓**
在本主題中，我們將向開發人員介紹如何使用 Aspose.Slides for Python via .NET 在投影片中加入橢圓形狀。Aspose.Slides for Python via .NET 提供更簡易的 API，只需幾行程式碼即可繪製各種形狀。若要在簡報的特定投影片中加入簡單橢圓，請遵循以下步驟：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例
2. 使用索引取得投影片的參考
3. 使用 IShapes 物件提供的 AddAutoShape 方法，新增類型為 Ellipse 的 AutoShape
4. 将修改后的简报写入 PPTX 文件

在下方示例中，我們已在第一張投影片加入橢圓。

```py
import aspose.slides as slides

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation() as pres:
    # 取得第一張投影片
    sld = pres.slides[0]

    # 新增橢圓類型的自動形狀
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **建立格式化橢圓**
若要在投影片中加入格式更佳的橢圓，請遵循以下步驟：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 使用索引取得投影片的參考。
3. 使用 IShapes 物件提供的 AddAutoShape 方法，新增類型為 Ellipse 的 AutoShape。
4. 將橢圓的填充類型設定為實心。
5. 使用與 IShape 物件相關聯的 FillFormat 物件所公開的 SolidFillColor.Color 屬性，設定橢圓的顏色。
6. 設定橢圓線條的顏色。
7. 設定橢圓線條的寬度。
8. 将修改后的简报写入 PPTX 文件。

在下方示例中，我們已在簡報的第一張投影片加入格式化的橢圓。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation() as pres:
    # 取得第一張投影片
    sld = pres.slides[0]

    # 新增橢圓類型的自動形狀
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # 為橢圓形狀套用一些格式設定
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 為橢圓的線條套用一些格式設定
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問答**

**如何依照投影片單位設定橢圓的精確位置與大小？**

座標和尺寸通常以 **點 (points)** 為單位指定。為了取得可預測的結果，請以投影片尺寸為基礎，並在指定數值前將所需的公釐或英吋轉換為點。

**如何將橢圓放置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移至最前或最底，調整其繪圖順序。這可讓橢圓覆蓋其他物件或顯示其下方的物件。

**如何為橢圓加入出現或強調的動畫效果？**

[套用](/slides/zh-hant/python-net/shape-animation/) 進入、強調或退出效果於形狀，並設定觸發條件與時間，以協調動畫的播放時機與方式。