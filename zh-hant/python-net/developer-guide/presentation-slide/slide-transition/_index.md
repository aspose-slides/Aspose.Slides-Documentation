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
- Morph 過渡
- 過渡類型
- 過渡效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 套用投影片過渡、設定自動投影片前進，並自訂 Morph 及其他過渡效果。"
---
## **概述**

投影片過渡控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Python via .NET，您可以為每張投影片選擇過渡效果、設定以滑鼠點擊或計時方式前進，並調整特定效果的選項。本文以 Python 範例說明如何套用過渡、設定精確的過渡持續時間、管理投影片計時，以及在兩張投影片之間建立 Morph 過渡。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片過渡**

若要套用過渡，使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 屬性。將其 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉中的某個值，然後儲存簡報。

以下範例將 Circle 過渡套用於第一張投影片，將 Comb 過渡套用於第二張投影片。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **輪形過渡**

[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) 的 [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) 屬性控制顯示目標投影片的徑向區段數量。先將投影片的過渡 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 的 WHEEL，然後再以 [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) 取得 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)。

此範例建立兩組相同的投影片：一張黑色投影片後接一張帶有金色矩形的投影片。目標投影片使用 1 與 8 兩種輻條數，且具有相同的 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 與明確的 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 8,000 毫秒，以便輕易觀察差異。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從第 1 張投影片前進到第 2 張，然後從第 3 張前進到第 4 張。於 PowerPoint 播放時，驗證過的 1 條輻條會以一次順時針掃描顯示投影片；驗證過的 8 條則同時以八個徑向區段顯示。目的內容與過渡計時相同，唯一差異在於顯示區段的數量。

## **進階投影片過渡設定**

您可以設定投影片在畫面上保留的時間以及是否以滑鼠點擊前進投影片放映。以下屬性負責此行為：

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 允許觀眾點擊滑鼠前進。
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 允許自動前進。
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，可讓觀眾點擊前進或等待計時器。若只使用計時器，請將 [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 設為 `False`。延遲時間僅控制投影片放映何時前進；它不會設定視覺過渡效果的持續時間。

此範例為前三張投影片指派不同的效果，並分別在 3、5、7 秒後自動前進。滑鼠點擊亦可前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

若要檢查是否已啟用計時前進，請讀取 [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/)。僅有儲存的延遲並不代表計時器已啟動。

下一個範例開啟上述儲存的檔案，回報每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，最後儲存更新後的設定。

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **精確控制過渡計時**

使用 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 以毫秒為單位指定過渡效果的精確長度。投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 屬性透過 [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) 公開這些設定：

| 屬性 | 用途 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 設定過渡效果本身的持續時間（毫秒）。 |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | 設定投影片自動前進前的延遲時間（毫秒）。請啟用 [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 以啟動此計時器。 |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 中選取預設速度類別：SLOW、MEDIUM 或 FAST。當未指定精確持續時間時會使用此值。 |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 僅控制過渡效果本身；它不決定投影片保持可見的時間。自動前進延遲需另外設定。若未設定明確的 duration，Aspose.Slides 會根據過渡類型與 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 來決定效果持續時間。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用於每張投影片**

為了保持節奏一致，請對每張投影片套用相同的效果與精確持續時間。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並為每個過渡設定 750 毫秒的持續時間。同時啟用 5,000 毫秒後的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # 獨立於效果持續時間配置自動前進。
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **為個別投影片設定不同持續時間**

不同投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的過渡，為章節介紹使用較長的過渡。此範例為第一張投影片設定 500 毫秒，為第二張投影片設定 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **與動畫輸出協調過渡**

在製作 [animated GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/python-net/export-to-html5/) 或 [video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 時，請在匯出前設定精確的過渡持續時間，以符合預期節奏。例如，在場景間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出影格率與效果持續時間協調：600 毫秒相當於 30 fps 時的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫過渡。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的過渡持續時間**

在修改過渡之前，先讀取 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 以判斷是否已存儲明確的值。值為 `-1` 表示未設定明確的持續時間；非負值表示以毫秒為單位的已存儲持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據過渡類型與 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 來決定。設定過渡類型可能會初始化持續時間，故請先檢查原始設定。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph 過渡**

Morph 過渡在連續的投影片之間為物件變化製作動畫。若要建立簡易的 Morph 效果，只需複製投影片、在複製的投影片上移動或調整物件大小，並將 Morph 過渡套用至第二張投影片。這會讓相對應的物件在原始與變更狀態之間進行動畫。

以下範例建立一張包含文字矩形的投影片，複製該投影片，然後在複製品上變更矩形的位置與大小。接著於第二張投影片的 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉中選取 Morph。請在支援 Morph 的簡報檢視器中開啟儲存的檔案，以在投影片放映時看到效果。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 過渡類型**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 將每個形狀視為整體物件。
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以單字為單位動畫化文字。
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 盡可能以字元為單位動畫化文字。

在存取其 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) 之前，先將過渡 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為 Morph。取得的值會提供 [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) 物件，其 [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) 屬性可選擇匹配模式。

此範例開啟前節建立的簡報，並將第二張投影片設定為以單字為基礎的 Morph 動畫。

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **設定過渡效果**

某些過渡會公開額外選項，例如方向或是否從黑畫面開始。可用選項取決於所選過渡的 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)。請先設定類型，然後使用其 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) 取得相應的過渡物件。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 過渡，並透過 [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) 的 [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) 讓過渡從黑畫面開始。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **常見問題**

**我可以控制投影片過渡的播放速度嗎？**

可以。當需要以毫秒為單位的精確效果持續時間時，請首選 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/)。若預設的 [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)（SLOW、MEDIUM 或 FAST）已足夠且未設定明確的持續時間，請使用 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)。這些設定會獨立於自動前進延遲，控制過渡效果。

**我可以將音訊附加到過渡並讓它循環播放嗎？**

可以。將嵌入式音訊指派給 [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)，將 [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) 設為來自 [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) 列舉的 START_SOUND，並啟用 [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)。音訊將持續循環，直至投影片放映中的下一個音效事件。

**將相同過渡套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合，將每張投影片的過渡 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為相同的值。於同一迴圈中設定任何計時與效果選項，以確保所有投影片的行為保持一致。

**我要如何檢查投影片目前設定的過渡是什麼？**

讀取投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 中的 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 屬性。它會回傳 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉中的值；NONE 代表未套用任何過渡效果。