---
title: 使用 Python via Java 管理簡報中的投影片過渡
linktitle: 投影片過渡
type: docs
weight: 80
url: /zh-hant/python-java/slide-transition/
keywords:
- 投影片過渡
- 新增投影片過渡
- 套用投影片過渡
- 進階投影片過渡
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "套用投影片過渡、設定自動投影片前進，並使用 Aspose.Slides for Python via Java 自訂 Morph 及其他過渡效果。"
---
## **概述**

投影片過渡控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Python via Java，您可以為每張投影片選擇過渡效果，設定以滑鼠點擊或計時器前進，並調整特定效果的選項。本文採用 Python 範例說明如何套用過渡、設定精確的過渡持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 過渡。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡**

要套用過渡，使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別載入簡報，然後透過 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 取得投影片的過渡設定。使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 並傳入來自 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列舉的值，最後儲存簡報。

以下範例將 Circle 過渡套用於第一張投影片，將 Comb 過渡套用於第二張投影片。請使用至少有兩張投影片的 `input.pptx` 檔案。

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

## **輪形過渡**

使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 從 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 中選取 Wheel。然後呼叫 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 以存取 [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) 設定。其 [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) 方法控制有多少個徑向區段會顯示目的投影片。

此範例建立兩組相同的投影片。每組以黑色投影片開始，最後以全投影片的金色矩形結束。兩個目的投影片皆使用相同的慢速 (透過 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) 設定) 以及使用 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 明確設定 8,000 毫秒的持續時間。僅改變徑向區段數量。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

開啟 `wheel-transitions.pptx` 於 PowerPoint 並啟動投影片放映。從第 1 張投影片前往第 2 張時，可看到金色矩形以順時針單一掃描方式顯示。再從第 3 張投影片前往第 4 張時，可看到八個徑向區段同時呈現相同矩形。

## **淡出至黑色的 Reveal 過渡**

將目的投影片的過渡類型設為 Reveal，然後對其 [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) 設定呼叫 [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack)。此範例建立一張青綠色來源投影片與一張珊瑚色目的投影片，然後將兩張投影片複製。每組使用相同的兩秒 Reveal 過渡，僅第二組會在過渡時淡出至黑色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

開啟 `reveal-transitions.pptx` 於 PowerPoint 並啟動投影片放映。從第 1 張投影片前往第 2 張時，可看到青綠色直接淡入珊瑚色。再從第 3 張投影片前往第 4 張時，畫面會短暫變暗至接近黑色，然後出現珊瑚色投影片。兩張投影片皆保留原本的背景顏色。

下方的列顯示每半秒的 PowerPoint 畫面。比較每列的中間畫面即可看到效果差異。

![PowerPoint 播放時禁用淡出至黑色（上）與啟用淡出至黑色（下）。僅下排會通過近黑色。](reveal-through-black.png)

## **新增進階投影片過渡**

您可以設定投影片在螢幕上停留的時間，以及是否以滑鼠點擊前進投影片放映。以下方法可控制此行為：

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允許觀看者透過點擊滑鼠前進。
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 啟用自動前進。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 以毫秒指定自動前進前的延遲時間。

同時啟用點擊與計時前進，讓觀看者可以點擊或等待計時器前進。若只想使用計時器，請將 `False` 傳入 [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延遲時間僅控制投影片放映何時前進；它不會設定視覺過渡效果的持續時間。

此範例將不同的效果套用於前 3 張投影片，並分別於 3、5、7 秒後啟用自動前進。滑鼠點擊亦可前進這些投影片。請使用至少有三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，呼叫 [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。僅儲存的延遲並不代表計時器已啟動。

下一個範例開啟上述儲存的檔案，回報每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進，同時啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精確控制過渡時間**

使用 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 以毫秒指定過渡效果的精確長度。投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 方法會透過 [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) 暴露這些設定：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | 設定過渡效果本身的持續時間（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 設定投影片自動前進前的延遲時間（毫秒）。將 `True` 傳入 [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以啟用此計時器。 |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | 從 [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) 列舉中選擇預定義的速度類別：Slow、Medium 或 Fast。當未指定精確持續時間時使用此設定。 |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 僅控制過渡效果；它不決定投影片在畫面上停留多久。請分別設定自動前進的延遲時間。若未設定明確的持續時間，Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值推算效果持續時間。

<!-- visual-explanation:slide-transition:start -->
[![分離的條形圖顯示 750 毫秒的過渡持續時間與 5,000 毫秒的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此示範為每張投影片套用 750 毫秒的淡入過渡，並分別在 5,000 毫秒後啟用自動前進。過渡持續時間控制效果；前進時間控制何時離開投影片。這些條形圖僅為示意設定，並非測量的合併時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **將相同的持續時間套用到每張投影片**

為了保持節奏一致，請將相同的效果與精確持續時間套用至每張投影片。本範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 中選取 Fade，並為每個過渡設定 750 毫秒的持續時間。然後分別在 5,000 毫秒後啟用自動前進，且停用滑鼠點擊前進，最後將結果另存為 PPTX。

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

        # 配置自動前進，與效果持續時間無關。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **為個別投影片設定不同的持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的過渡，為章節介紹投影片使用較長的過渡。本範例為第一張投影片設定 500 毫秒，為第二張投影片設定 1,200 毫秒。請使用至少有兩張投影片的 `input.pptx` 檔案。

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

### **協調過渡與動畫輸出**

在製作 [動畫 GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/python-java/export-to-html5/) 或 [影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期的節奏。例如，在場景之間使用 600 毫秒的淡入，並分別調整每張投影片的前進延遲，以提供旁白或內容的時間。

對於 GIF 和影片，請將輸出幀率與效果持續時間協調：600 毫秒相當於 30 fps 時的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的過渡持續時間**

在修改過渡之前，先呼叫 [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) 以判斷是否已儲存明確值。`-1` 代表未設定明確持續時間；非負值則為以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值推算該持續時間。設定過渡類型可能會初始化持續時間，因此請先檢查原始設定。

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

## **Morph 過渡**

Morph 過渡會在連續投影片之間動畫化物件的變化。要建立簡單的 Morph 效果，只需複製投影片、在複製投影片上移動或調整物件大小，然後將 Morph 過渡套用至第二張投影片。這樣會讓對應的物件在原始狀態與變更後的狀態之間動畫化。

以下範例建立一張包含文字矩形的投影片，將其複製，並在複製投影片上更改矩形的位置與大小。然後在第二張投影片的 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列舉中選取 Morph。將儲存的檔案開啟支援 Morph 的簡報檢視器，即可在投影片放映時看到效果。

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

## **Morph 過渡類型**

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) 將每個形狀視為整體物件。
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) 盡可能以單字為單位動畫化文字。
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) 盡可能以字元為單位動畫化文字。

先使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 選取 Morph，然後再存取 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue)。取得的值即為 [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) 類別的實例，透過其 [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) 方法選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以單字為基礎的 Morph 動畫。

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

## **設定過渡效果**

某些過渡會提供額外選項，例如方向或是否從黑屏開始。可用的選項取決於使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 所選的過渡。先設定類型，然後使用 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 取得的相應類別。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 過渡，並透過 [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) 的 [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) 讓過渡從黑屏開始。

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

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

可以。當您需要以毫秒為單位的精確效果持續時間時，請優先使用 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration)。若預設的 [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）已足夠且未設定明確持續時間，則使用 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed)。這些設定會獨立於自動前進的延遲時間，僅控制過渡效果。

**我可以為過渡附加音訊並使其循環嗎？**

可以。使用 [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) 指定嵌入的音訊，將 [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) 列舉中的 `StartSound` 傳入 [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode)，並以 `True` 啟用 [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop)。音訊會在投影片放映中持續循環，直至下一個音效事件發生。

**將相同過渡套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 集合，對每張投影片的過渡呼叫 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 並傳入相同的值。於同一迴圈中設定任何計時或效果選項，即可確保所有投影片的行為一致。

**我要如何檢查投影片目前設定了哪種過渡？**

對投影片的 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 結果呼叫 [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType)。它會回傳來自 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列舉的值；`None_` 表示未套用任何過渡效果。