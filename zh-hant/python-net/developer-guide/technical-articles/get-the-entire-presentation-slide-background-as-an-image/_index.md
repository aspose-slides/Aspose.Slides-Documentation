---
title: 以影像方式取得簡報中整個投影片背景
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片
- 背景
- 投影片背景
- 最終背景
- 背景轉為影像
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，從 PowerPoint 與 OpenDocument 簡報中提取完整投影片背景為影像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景圖片、簡報主題、色彩配置以及放置於母片或版面投影片上的物件。

本篇文章說明如何使用 Aspose.Slides 將整個投影片背景提取為影像。由於此任務沒有單一方法可用，做法是將選取的投影片複製到暫存簡報中，移除投影片上的形狀，然後將產生的投影片背景轉換為影像。

## **取得整個投影片背景**

Aspose.Slides for Python 未提供直接提取整個簡報投影片背景為影像的簡易方法，但您可以遵循以下步驟完成此操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入簡報。
1. 從簡報取得投影片尺寸。
1. 選取投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片尺寸。
1. 將選取的投影片複製到暫存簡報中。
1. 刪除複製投影片上的形狀。
1. 將複製的投影片轉換為影像。

以下程式碼範例會將整個簡報投影片背景提取為影像。
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **常見問題**

**從母片的複雜漸層、紋理或圖片填充會在產生的背景影像中保留嗎？**

是。Aspose.Slides 會套用在投影片、版面或母片上定義的漸層、圖片與紋理填充進行渲染。若需將外觀從繼承的母片中分離，請在匯出前於目前投影片[設定自訂背景](/slides/zh-hant/python-net/presentation-background/)。

**我可以在儲存之前為產生的背景影像加入浮水印嗎？**

是。您可以在可編輯的[投影片副本](/slides/zh-hant/python-net/clone-slides/)上加入[加入浮水印](/slides/zh-hant/python-net/watermark/)形狀或圖片（放在其他內容之後），然後再匯出。這樣即可產生已內嵌浮水印的背景影像。

**我能否在不與現有投影片綁定的情況下取得特定版面或母片的背景？**

是。取得目標母片或版面，將其套用到具有所需尺寸的[暫存投影片](/slides/zh-hant/python-net/clone-slides/)上，然後匯出該投影片，即可取得該版面或母片衍生的背景。

**是否有授權限制會影響影像匯出？**

只要使用[有效授權](/slides/zh-hant/python-net/licensing/)，即可完整使用渲染功能。於評估模式下，輸出可能會有例如浮水印等限制。請在執行批次匯出前於每個程序啟用授權。