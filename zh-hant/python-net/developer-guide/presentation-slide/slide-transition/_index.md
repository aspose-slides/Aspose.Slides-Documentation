---
title: 使用 Python 管理簡報中的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 90
url: /zh-hant/python-net/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 轉場
- 過渡類型
- 過渡效果
- Python
- Aspose.Slides
description: "探索如何在 Aspose.Slides for Python（透過 .NET）中自訂投影片過渡，並提供 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概述**

Aspose.Slides for Python 提供對投影片過渡的完整控制，從選擇過渡類型到配置時間和觸發條件，皆可作為自動化簡報工作流程的一部分。您可以設定投影片在點擊時或在指定延遲後前進，並透過例如從黑色切入或方向性進入等效果細緻調整視覺行為。此函式庫亦支援在 PowerPoint 2019 中引入的 Morph 過渡，包含依物件、文字或字元的變形模式，以在投影片之間創造平滑且一致的運動。

## **新增投影片過渡**

為了讓概念更易於理解，此範例示範如何使用 Aspose.Slides for Python 來管理簡單的投影片過渡。開發人員可以將不同的投影片過渡效果套用至投影片並自訂其行為。若要建立簡單的投影片過渡，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 使用 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 列舉中的其中一個效果套用投影片過渡。
3. 將修改後的簡報檔案儲存。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以載入簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 對第 1 張投影片套用圓形過渡。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 對第 2 張投影片套用梳狀過渡。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **新增進階投影片過渡**

在本節中，我們對投影片套用了簡單的過渡效果。若要使此效果更受控且更精緻，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 使用 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 列舉中的其中一個效果套用投影片過渡。
3. 設定過渡為 Advance On Click、在特定時間後前進，或同時兩者皆啟用。
4. 將修改後的簡報檔案儲存。

如果啟用了 **Advance On Click**，投影片僅會在使用者點擊時前進。若設定了 **Advance After Time** 屬性，投影片將在指定的間隔時間後自動前進。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # 對第 1 張投影片套用圓形過渡。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 啟用點擊前進並設定 3 秒自動前進。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # 對第 2 張投影片套用梳狀過渡。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 啟用點擊前進並設定 5 秒自動前進。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # 對第 3 張投影片套用縮放過渡。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # 啟用點擊前進並設定 7 秒自動前進。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 轉場**

Aspose.Slides for Python 支援 [Morph transition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/morphtransition/)，此過渡會將從一張投影片到下一張投影片的平滑移動動畫化。本節說明如何使用 Morph 轉場。若要有效使用，您需要兩張投影片且至少有一個共享的物件。最簡單的方法是複製投影片，然後將該物件移動至第二張投影片的不同位置。

以下程式碼片段示範如何複製包含文字的投影片，並將 Morph 轉場套用至第二張投影片。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # 複製第一張投影片以建立第二張擁有相同形狀的投影片，以維持 Morph 連續性。
    slide1 = presentation.slides.add_clone(slide0)

    # 在第二張投影片選取相同的矩形，並變更其位置與大小。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 在第二張投影片啟用 Morph 轉場，以平滑地動畫化形狀變更。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionmorphtype/) 列舉表示不同類型的 Morph 投影片過渡。

以下程式碼片段示範如何將 Morph 轉場套用至投影片並變更 morph 類型：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **設定過渡效果**

Aspose.Slides for Python 讓您設定過渡效果，例如 **From Black**、**From Left**、**From Right** 等。若要配置過渡效果，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得投影片的參考。
3. 設定所需的過渡效果。
4. 將簡報儲存為 PPTX 檔案。

以下範例中，我們設定了多種過渡效果。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 套用 Cut 轉場並啟用 From Black。
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我可以控制投影片過渡的播放速度嗎？**

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionspeed/) 設定調整過渡的 [speed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/speed/)，例如 slow、medium、fast。

**我可以為過渡附加音訊並使其循環播放嗎？**

可以。您可以為過渡嵌入音效，並透過如 sound mode 與循環等設定來控制其行為（例如 [sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound/)、[sound_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)、[sound_loop](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)，以及如 [sound_is_built_in](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) 和 [sound_name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) 等中繼資料）。

**將相同的過渡快速套用到每張投影片的最佳方法是什麼？**

在每張投影片的過渡設定中配置所需的過渡類型；過渡是依投影片儲存的，因此對所有投影片套用相同的類型即可獲得一致的結果。

**我該如何檢查投影片目前設定的過渡是什麼？**

檢查投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_show_transition/) 並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/type/)；該值會精確告訴您套用了哪種效果。