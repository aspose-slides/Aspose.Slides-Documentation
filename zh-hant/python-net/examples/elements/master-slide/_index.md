---
title: 母片
type: docs
weight: 30
url: /zh-hant/python-net/examples/elements/master-slide/
keywords:
- 母片
- 新增母片
- 存取母片
- 移除母片
- 未使用的母片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理母片：建立、編輯、複製及格式化主題、背景、占位符，以統一 PowerPoint 與 OpenDocument 的投影片。"
---
母片位於 PowerPoint 投影片繼承階層的最高層級。**母片** 定義背景、標誌以及文字格式等共用設計元素。**版面母片** 繼承自母片，而 **普通投影片** 繼承自版面母片。

本文說明如何使用 Aspose.Slides for Python via .NET 建立、修改與管理母片。

## **新增母片**

此範例示範如何透過複製預設母片來建立新的母片。

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # 複製預設母片。
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** 母片提供在所有投影片上套用一致品牌或共用設計元素的方式。對母片所做的任何變更都會自動套用到相依的版面母片與普通投影片上。

> 💡 **Tip 2:** 任何加入母片的圖形或格式皆會被版面母片繼承，進而被使用該版面的所有普通投影片繼承。  
> 下圖說明在母片上加入文字方塊會如何自動在最終投影片上顯示。

![母片繼承範例](master-slide-banner.png)

## **存取母片**

您可以使用 `Presentation.masters` 集合來存取母片。以下說明如何取得並操作它們：

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # 存取第一個母片。
        first_master_slide = presentation.masters[0]
```

## **移除母片**

母片可以依索引或依參考方式移除。

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 依索引移除。
        presentation.masters.remove_at(0)

        # 或依參考移除。
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的母片**

某些簡報包含未使用的母片。移除這些母片可協助減少檔案大小。

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 移除所有未使用的母片（即使已標記為 Preserve）。
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** 使用 `remove_unused(True)` 來清除未使用的母片，並最小化簡報大小。