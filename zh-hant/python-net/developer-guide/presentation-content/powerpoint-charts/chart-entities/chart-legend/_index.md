---
title: 使用 Python 在簡報中自訂圖表圖例
linktitle: 圖例
type: docs
url: /zh-hant/python-net/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET 自訂圖表圖例，以量身打造的圖例格式優化 PowerPoint 與 OpenDocument 簡報。"
---
## **概述**

Aspose.Slides for Python 提供對圖表圖例的完整控制，使您能將資料標籤變得清晰且適合投影片使用。您可以顯示或隱藏圖例、選擇其在投影片上的位置，並調整版面配置以避免與繪圖區重疊。此 API 允許您設定文字與標記的樣式、微調間距與背景，並格式化邊框與填充以符合您的主題。開發人員還可以存取單個圖例項目，以重新命名或過濾它們，確保僅顯示最相關的系列。透過這些功能，您的圖表保持可讀、一致，且符合投影片的設計標準。

## **圖例定位**

使用 Aspose.Slides，您可以快速控制圖表圖例的出現位置以及它如何適應投影片版面。了解如何精確放置圖例。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 取得投影片的參考。
1. 在投影片中加入圖表。
1. 設定圖例屬性。
1. 將簡報儲存為 PPTX 檔案。

以下範例中，我們設定圖表圖例的位置與大小：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立 Presentation 類別的實例。
with slides.Presentation() as presentation:

    # 取得投影片的參考。
    slide = presentation.slides[0]

    # 在投影片中加入叢集柱狀圖。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # 設定圖例屬性。
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # 將簡報儲存至磁碟。
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖例字型大小**

圖表的圖例應該與其說明的資料一樣易讀。本節說明如何調整圖例的字型大小，以配合投影片的排版並提升可及性。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別。
1. 建立圖表。
1. 設定字型大小。
1. 將簡報儲存至磁碟。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖例項目的字型大小**

Aspose.Slides 讓您透過格式化個別項目，微調圖表圖例的外觀。以下範例示範如何針對特定圖例項目設定屬性，而不影響其他圖例。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別。
1. 建立圖表。
1. 存取圖例項目。
1. 設定項目屬性。
1. 將簡報儲存至磁碟。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以啟用圖例，使圖表自動為其分配空間，而不是覆蓋它嗎？**

可以。使用非覆蓋模式（[overlay](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/legend/overlay/) = `false`），此時繪圖區會縮小以容納圖例。

**我可以建立多行圖例標籤嗎？**

可以。當空間不足時，長標籤會自動換行；亦支援在系列名稱中使用換行字元強制換行。

**我要如何讓圖例遵循投影片主題的色彩配置？**

不要為圖例或其文字設定明確的顏色、填充或字型。如此一來，它們會繼承自主題，且在設計變更時會正確更新。