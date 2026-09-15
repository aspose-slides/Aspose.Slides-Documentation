---
title: 使用 Python via Java 在簡報中管理投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/python-java/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 套用投影片轉場
- 進階投影片轉場
- Morph 轉場
- 轉場類型
- 轉場效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 套用投影片轉場、設定自動投影片前進，並自訂 Morph 及其他轉場效果。"
---
## **概觀**

投影片轉場控制投影片在投影片放映過程中的顯示方式。使用 Aspose.Slides for Python via Java，您可以為每張投影片選擇轉場效果、設定以滑鼠點擊或計時器方式前進，並調整針對特定效果的選項。本文使用 Python 範例說明如何套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。這些範例也展示如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

若要套用轉場，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入簡報，並透過 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的轉場設定。使用來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitiontype/) 列舉的值呼叫 [setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setType)，最後儲存簡報。

以下範例對第一張投影片套用 Circle 轉場，對第二張投影片套用 Comb 轉場。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間以及是否透過滑鼠點擊推進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許觀眾點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，讓觀眾可點擊繼續或等待計時器。若僅使用計時器，請將 `False` 傳遞給 [setAdvanceOnClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延遲時間決定投影片放映何時前進；它不會設定視覺轉場效果的持續時間。

此範例將不同效果指派給前三張投影片，並分別在 3、5、7 秒後啟用自動前進。也可透過滑鼠點擊前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

若要檢查是否已啟用計時前進，請呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅有儲存的延遲並不表示計時器已啟動。

下一個範例開啟上述已儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，並儲存更新後的設定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **精確控制轉場計時**

使用 [setDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setDuration) 可在毫秒級指定轉場效果的精確長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getSlideShowTransition) 方法透過 [SlideShowTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/) 透露這些設定：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setDuration) | 設定轉場效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定投影片自動前進前的延遲時間（毫秒）。將 `True` 傳給 [setAdvanceAfter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以啟用此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionspeed/) 中選取預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時使用此設定。 |

[setDuration] 僅控制轉場效果；它不決定投影片的可見時間。請分別設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值計算效果持續時間。

### **將相同持續時間套用至每張投影片**

為了保持一致的節奏，請將相同的效果與精確持續時間套用至每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。再分別啟用 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # 獨立於效果持續時間配置自動前進。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **為個別投影片設定不同持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的轉場，為章節介紹使用較長的轉場。此範例將第一張投影片設定為 500 毫秒，第二張設定為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **協調轉場與動畫輸出**

在準備 [animated GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/python-java/export-to-html5/) 或 [video](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期的節奏。例如，在畫面之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 和 video，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 時的 18 幀。在 HTML5 中，於匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有轉場持續時間**

在修改轉場之前呼叫 [getDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確的值。`-1` 表示未設定 explicit 持續時間；非負值則指定以毫秒為單位的儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [getSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值來決定該持續時間。設定轉場類型時可能會初始化持續時間，因此請先檢查原始設定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph 轉場**

Morph 轉場會在連續投影片之間對物件的變化進行動畫。若要建立簡單的 Morph 效果，請複製一張投影片、在複製品上移動或調整物件大小，並對第二張投影片套用 Morph 轉場。這樣可讓相對應的物件在原始與修改後的狀態之間進行動畫。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製品上變更矩形的位置與大小。接著為第二張投影片從 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitiontype/) 列舉中選取 Morph。於支援 Morph 的簡報檢視器中開啟儲存的檔案，即可在投影片放映時看到效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為整體物件。
- [ByWord](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以匹配單詞的方式動畫化文字。
- [ByChar](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以匹配字元的方式動畫化文字。

在存取 [getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getValue) 之前，使用 [setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setType) 來選取 Morph。此時返回的值是一個 [MorphTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/morphtransition/) 類別的實例，其 [setMorphType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/morphtransition/#setMorphType) 方法用於選擇匹配模式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **設定轉場效果**

某些轉場提供額外選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setType) 所選的轉場。請先設定類型，然後使用 [getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getValue) 回傳的相應類別。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 轉場。它透過 [OptionalBlackTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/optionalblacktransition/) 呼叫 [setFromBlack](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/optionalblacktransition/#setFromBlack)，使轉場從黑屏開始。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**我可以控制投影片轉場的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請使用 [setDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setDuration)。若預先定義的 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionspeed/) 類別（Slow、Medium 或 Fast）已足夠且未設定具體持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定會獨立於自動前進延遲，僅控制轉場效果。

**我可以為轉場加入音訊並讓它循環播放嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setSound) 指定內嵌音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitionsoundmode/) 列舉中的 StartSound 傳給 [setSoundMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setSoundMode)，並以 `True` 啟用 [setSoundLoop](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setSoundLoop)。音訊會持續循環，直至投影片放映中的下一個音效事件。

**將相同轉場套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 集合，對每張投影片的轉場呼叫相同值的 [setType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#setType)。在同一迴圈中設定所有計時與效果選項，以保持各投影片行為一致。

**我如何檢查投影片上目前設定的轉場是什麼？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideshowtransition/#getType)。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/transitiontype/) 列舉的值；None_ 表示未套用任何轉場效果。