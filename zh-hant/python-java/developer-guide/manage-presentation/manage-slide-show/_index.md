---
title: 在 Python via Java 中管理投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/python-java/manage-slide-show/
keywords:
- 顯示類型
- 由講者呈現
- 個人瀏覽
- 資訊站瀏覽
- 顯示選項
- 持續循環
- 無旁白顯示
- 無動畫顯示
- 筆刷顏色
- 顯示投影片
- 自訂放映
- 前進投影片
- 手動
- 使用時間設定
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理投影片放映。輕鬆控制投影片轉場、時間設定等，支援 PPT、PPTX 與 ODP 格式。"
---
## **簡介**

Microsoft PowerPoint 的 **Set Up Show** 選項讓您可以選擇投影片類型、啟用循環、選取投影片，並控制投影片的前進方式。使用 Aspose.Slides for Python via Java，您可以以程式方式設定這些選項，並將其儲存於簡報檔案中。

透過 [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlideShowSettings) 方法會回傳一個 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/) 物件，用來控制這些選項。以下範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。每個範例會在需要時啟動 JVM，並在完成後釋放簡報。

## **選擇顯示類型**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setSlideShowType) 定義投影片放映的類型，可為以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/browsedatkiosk/)。使用此方法可依不同使用情境（例如自動化資訊站或手動簡報）調整簡報。

下面的程式碼範例建立一個新簡報，並將顯示類型設為「Browsed by an individual」且不顯示捲軸。

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

## **啟用顯示選項**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setLoop) 決定投影片放映是否持續循環直到手動停止，適用於需要不斷運行的自動化簡報。[SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowNarration) 決定是否在放映期間播放語音旁白，適合包含語音導覽的自動簡報。[SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowAnimation) 決定是否播放投影片物件的動畫，以呈現完整的視覺效果。

以下程式碼範例建立新簡報，並讓投影片放映循環。

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

## **選取要顯示的投影片**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setSlides) 方法讓您指定在簡報期間要顯示的投影片範圍。當只需顯示簡報的部份投影片而非全部時，此功能非常實用。下面的程式碼範例建立包含九張投影片的簡報，並選取第 2 張至第 9 張投影片。範圍使用以 1 為起點的投影片編號。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 建立九張投影片，以確保所選範圍存在。
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

## **控制投影片前進方式**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setUseTimings) 方法允許您啟用或停用每張投影片的預設時間設定，方便自動以預先定義的顯示時長播放投影片。以下程式碼範例建立新簡報，並停用時間設定的使用。

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

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) 方法決定在播放多媒體內容（例如影片或音訊）時，投影片放映期間是否顯示媒體控制項（播放、暫停、停止等）。當您希望在簡報過程中讓簡報者掌控媒體播放時，此功能相當實用。

以下程式碼範例建立新簡報，並啟用媒體控制項的顯示。

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

**我能否將簡報儲存為直接以投影片放映模式開啟？**

可以。將檔案儲存為 PPSX 或 PPSM；這兩種格式在 PowerPoint 中開啟時會直接進入投影片放映模式。於 Aspose.Slides 中，於[匯出時](/slides/zh-hant/python-java/save-presentation/)選擇相應的儲存格式。

**我可以在不刪除投影片的情況下，將個別投影片排除於放映之外嗎？**

可以。將投影片標記為 [hidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setHidden)。隱藏的投影片仍保留於簡報中，但不會在投影片放映期間顯示。

**Aspose.Slides 能否播放投影片放映或在螢幕上即時控制簡報？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放由 PowerPoint 等檢視程式負責。