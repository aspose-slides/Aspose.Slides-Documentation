---
title: 在 Python 中向簡報新增矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/python-net/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 Aspose.Slides for Python via .NET 在您的 PowerPoint 與 OpenDocument 簡報中新增矩形，輕鬆以程式方式設計與修改形狀，提升簡報效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 向 PowerPoint 投影片新增矩形形狀。內容涵蓋建立簡單矩形、建立格式化矩形，以及將更新後的簡報另存為 PPTX 檔案。您也將看到如何套用基本的矩形格式設定，如純色填滿、線條顏色與線寬。此外，本文的 FAQ 亦指出相關的矩形作業，包括圓角、圖片填滿、視覺效果、超連結、形狀鎖定、匯出選項與有效屬性。

## **建立簡單矩形**
與前面的主題類似，這個主題也是關於新增形狀，而此次要討論的形狀是矩形。在本主題中，我們說明開發人員如何使用 Aspose.Slides for Python via .NET 在投影片中加入簡單或有格式的矩形。若要在簡報的選定投影片上新增簡單矩形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別的執行個體。
1. 使用索引取得投影片的參考。
1. 使用 IShapes 物件提供的 AddAutoShape 方法，新增類型為 Rectangle 的 IAutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們在簡報的第一張投影片新增了一個簡單矩形。

```py
import aspose.slides as slides

# 實例化代表 PPTX 的 Prseetation 類別
with slides.Presentation() as pres:
    # 取得第一張投影片
    sld = pres.slides[0]

    # 新增矩形類型的自動圖形
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #寫入 PPTX 檔案至磁碟
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **建立格式化矩形**
若要在投影片上加入格式化矩形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別的執行個體。
1. 使用索引取得投影片的參考。
1. 使用 IShapes 物件提供的 AddAutoShape 方法，新增類型為 Rectangle 的 IAutoShape。
1. 將矩形的填滿類型設定為實心 (Solid)。
1. 使用與 IShape 物件關聯的 FillFormat 物件所提供的 SolidFillColor.Color 屬性，設定矩形的顏色。
1. 設定矩形線條的顏色。
1. 設定矩形線條的寬度。
1. 將修改後的簡報寫入為 PPTX 檔案。  
上述步驟已在以下範例中實作。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation() as pres:
    # 取得第一張投影片
    sld = pres.slides[0]

    # 新增矩形類型的自動圖形
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 對矩形形狀套用一些格式設定
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 對矩形的線條套用一些格式設定
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #寫入 PPTX 檔案至磁碟
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**如何新增具有圓角的矩形？**

使用圓角 [shape type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapetype/) 並在形狀屬性中調整角半徑；也可透過幾何調整為每個角套用圓角。

**如何使用圖片（紋理）填滿矩形？**

選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)，提供圖片來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**

可以。[Outer/inner shadow, glow, and soft edges](/slides/zh-hant/python-net/shape-effect/) 皆可使用，且具備可調整的參數。

**我可以將矩形變成帶有超連結的按鈕嗎？**

可以。可在形狀點擊時 [Assign a hyperlink](/slides/zh-hant/python-net/manage-hyperlinks/)（跳轉至投影片、檔案、網址或電子郵件）。

**如何防止矩形被移動或變更？**

使用 [shape locks](/slides/zh-hant/python-net/applying-protection-to-presentation/)：可禁止移動、調整大小、選取或文字編輯，以保護版面配置。

**我可以將矩形轉換為點陣圖或 SVG 嗎？**

可以。您可以將 [render the shape](http://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/) 轉為指定尺寸/比例的影像，或 [export it as SVG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/) 以向量形式使用。

**如何快速取得考慮佈景主題與繼承後的矩形實際（有效）屬性？**

使用 [shape’s effective properties](/slides/zh-hant/python-net/shape-effective-properties/)：API 會回傳已考慮佈景主題樣式、版面配置與本地設定的計算值，簡化格式分析。