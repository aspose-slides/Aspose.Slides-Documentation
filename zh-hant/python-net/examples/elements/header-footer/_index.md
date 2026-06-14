---
title: "頁眉與頁腳"
type: docs
weight: 220
url: /zh-hant/python-net/examples/elements/header-footer/
keywords:
- "頁眉與頁腳"
- "新增頁眉與頁腳"
- "更新頁眉與頁腳"
- "設定日期與時間"
- "程式碼範例"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Aspose.Slides"
description: "在 Python 中使用 Aspose.Slides 控制頁眉與頁腳：新增或編輯日期/時間、投影片編號與頁腳文字，並在 PPT、PPTX 與 ODP 中顯示或隱藏佔位符。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 添加頁腳並更新日期與時間佔位符。

## **Add a Footer**
新增頁腳

在投影片的頁腳區域加入文字並使其可見。

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Date and Time**
更新日期與時間

修改投影片上的日期與時間佔位符。

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```