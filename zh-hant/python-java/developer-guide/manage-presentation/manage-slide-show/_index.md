---
title: 在 Python via Java 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/python-java/manage-slide-show/
keywords:
- 放映類型
- 演講者主持
- 個人瀏覽
- 資訊亭瀏覽
- 放映選項
- 持續循環
- 不含旁白的放映
- 不含動畫的放映
- 筆跡顏色
- 顯示投影片
- 自訂放映
- 前進投影片
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理投影片放映。輕鬆控制投影片過場、計時等功能，支援 PPT、PPTX 與 ODP 格式。"
---
## **簡介**

Microsoft PowerPoint 的 **Set Up Show** 選項讓您可以選擇放映類型、啟用循環、選擇投影片，並控制投影片的前進方式。使用 Aspose.Slides for Python via Java，您可以以程式方式設定這些選項，並將它們儲存在簡報檔案中。

[Presentation.getSlideShowSettings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideShowSettings) 方法會回傳一個控制這些選項的 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/) 物件。以下範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。每個範例會在需要時啟動 JVM，完成後釋放簡報。

## **選取放映類型**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setSlideShowType) 定義放映的類型，可為以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/browsedbyindividual/)、或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/browsedatkiosk/)。使用此方法可讓您針對不同使用情境（例如自動化資訊亭或手動簡報）調整簡報。

以下程式碼範例建立新簡報，並將放映類型設定為「Browsed by an individual」且不顯示捲軸。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **啟用放映選項**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setLoop) 決定放映是否應持續循環，直到手動停止。這對需要持續運行的自動化簡報非常有用。

[SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowNarration) 決定放映期間是否播放語音旁白。對於包含語音指導的自動化簡報很有幫助。

[SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowAnimation) 決定投影片物件上的動畫是否播放。這有助於呈現簡報完整的視覺效果。

以下程式碼範例建立新簡報，並讓放映循環播放。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **選取要放映的投影片**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setSlides) 方法允許您選取在簡報期間要顯示的投影片範圍。當您只需要顯示簡報的一部份而非全部投影片時，此功能十分有用。以下程式碼範例建立包含九張投影片的簡報，並選取第 2 張至第 9 張投影片。範圍使用以 1 為起始的投影片編號。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 建立九張投影片以確保選取的範圍存在。
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制投影片前進**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setUseTimings) 方法允許您啟用或停用每張投影片的預設計時。這對於以預先定義的顯示時間自動播放投影片非常有用。以下程式碼範例建立新簡報，並停用使用計時。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **顯示媒體控制項**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) 方法決定在播放多媒體內容（例如影片或音訊）時，放映期間是否顯示媒體控制項（如播放、暫停和停止）。當您希望讓簡報者能控制媒體播放時，此功能很有用。

以下程式碼範例建立新簡報，並啟用顯示媒體控制項。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**Can I save a presentation so it opens directly in slide show mode?**

是的。將檔案儲存為 PPSX 或 PPSM；這些格式在 PowerPoint 中開啟時會直接以投影片放映模式啟動。在 Aspose.Slides 中，請於[匯出期間](/slides/zh-hant/python-java/save-presentation/)選擇相應的儲存格式。

**Can I exclude individual slides from the show without deleting them from the file?**

是的。將投影片標記為[hidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setHidden)。隱藏的投影片仍保留在簡報中，但在放映時不會顯示。

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放由如 PowerPoint 等檢視應用程式處理。