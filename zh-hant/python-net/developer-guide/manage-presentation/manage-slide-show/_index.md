---
title: 在 Python 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/python-net/manage-slide-show/
keywords:
- 顯示類型
- 由講者主持
- 個人瀏覽
- 在 kiosk 瀏覽
- 放映選項
- 持續循環
- 無旁白放映
- 無動畫放映
- 筆色
- 顯示投影片
- 自訂放映
- 自動換頁
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python（透過 .NET）中管理投影片放映。輕鬆控制投影片過場、計時及其他功能，支援 PPT、PPTX 與 ODP 格式。"
---
## **簡介**

在 Microsoft PowerPoint 中，**Slide Show** 設定是準備與呈現專業簡報的關鍵工具。此區段中最重要的功能之一是 **Set Up Show**，它讓您能依特定條件與觀眾調整簡報，確保彈性與便利。透過此功能，您可以選擇放映類型（例如，由講者主持、由個人瀏覽或在 kiosk 瀏覽），啟用或停用循環、選取要顯示的特定投影片，並使用計時。此步驟對於提升簡報的效能與專業度至關重要。

`slide_show_settings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的屬性，類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slideshowsettings/)，可讓您管理 PowerPoint 簡報中的投影片放映設定。本文將說明如何使用此屬性來配置與控制投影片放映設定的各項功能。

## **選擇放映類型**

`SlideShowSettings.slide_show_type` 定義投影片放映的類型，可為以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/browsedatkiosk/)。使用此屬性可讓簡報因應不同使用情境，例如自動 kiosk 或手動簡報。

以下程式碼範例建立新簡報，並將放映類型設定為「Browsed by an individual」且不顯示捲軸。

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **啟用放映選項**

`SlideShowSettings.loop` 決定投影片放映是否會持續循環直到手動停止，這對需要不間斷執行的自動化簡報非常有用。`SlideShowSettings.show_narration` 決定放映時是否播放語音旁白，適用於含有語音指示的自動簡報。`SlideShowSettings.show_animation` 決定是否播放投影片中物件的動畫，以完整呈現視覺效果。

以下程式碼範例建立新簡報，並讓放映循環。

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **選擇要放映的投影片**

`SlideShowSettings.slides` 屬性允許您指定在簡報期間顯示的投影片範圍，當只需展示部份投影片而非全部時相當實用。以下程式碼範例建立新簡報，並將投影片範圍設定為顯示第 `2` 張至第 `9` 張投影片。

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **使用自動換頁**

`SlideShowSettings.use_timings` 屬性可讓您啟用或停用每張投影片的預設計時，適用於需要依預先設定的顯示時長自動換頁的情況。以下程式碼範例建立新簡報，並停用計時功能。

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **顯示媒體控制項**

`SlideShowSettings.show_media_controls` 屬性決定在播放多媒體內容（例如影片或音訊）時，投影片放映期間是否顯示播放、暫停與停止等媒體控制項。當您希望在簡報中讓演示者自行控制媒體播放時，這個功能非常實用。

以下程式碼範例建立新簡報，並啟用媒體控制項的顯示。

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以將簡報儲存成直接在投影片放映模式開啟嗎？**

可以。將檔案另存為 PPSX 或 PPSM；這些格式在 PowerPoint 中開啟時會直接進入投影片放映模式。在 Aspose.Slides 中，請於[匯出期間](/slides/zh-hant/python-net/save-presentation/)選取相應的儲存格式。

**我可以在不刪除檔案中投影片的情況下，將個別投影片排除於放映之外嗎？**

可以。將投影片標記為 [hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/)。隱藏的投影片仍保留在簡報中，但在投影片放映時不會顯示。

**Aspose.Slides 能夠播放投影片放映或在螢幕上控制即時簡報嗎？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案；實際的播放由像 PowerPoint 這樣的檢視應用程式負責。