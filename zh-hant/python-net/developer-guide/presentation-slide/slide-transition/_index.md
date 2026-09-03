---
title: 使用 Python 管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 90
url: /zh-hant/python-net/slide-transition/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 套用投影片轉場、設定自動投影片前進，並自訂 Morph 及其他轉場效果。"
---
## **概觀**

投影片轉場控制投影片在簡報播放期間的顯示方式。使用 Aspose.Slides for Python via .NET，您可以為每張投影片選擇轉場效果、設定以滑鼠點擊或計時器方式前進，並調整特定效果的選項。本文使用 Python 範例套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例也示範如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

若要套用轉場，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [slide_show_transition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_show_transition/) 屬性。將其 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 列舉的值，然後儲存簡報。

下列範例將 Circle 轉場套用於第一張投影片，將 Comb 轉場套用於第二張。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間以及是否透過滑鼠點擊前進投影片放映。以下屬性會控制此行為：

- [advance_on_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 允許觀眾透過滑鼠點擊前進。
- [advance_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 啟用自動前進。
- [advance_after_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，可讓觀眾點擊前進或等待計時器。若僅使用計時器，請將 [advance_on_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 設為 `False`。此延遲決定投影片何時前進；它不會設定視覺轉場效果的持續時間。

此範例為前三張投影片指派不同的效果，並分別在 3、5、7 秒後啟用自動前進。滑鼠點擊亦可前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否啟用了計時前進，請讀取 [advance_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/)。僅有儲存的延遲並不表示計時器已啟動。

下一個範例開啟上述儲存的檔案，報告每個已啟用的計時器，並對延遲超過兩秒的投影片停用自動前進。對這些投影片啟用滑鼠點擊，並儲存更新後的設定。

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

## **精確控制轉場時間**

使用 [duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 可指定轉場效果的精確長度（毫秒）。投影片的 [slide_show_transition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_show_transition/) 屬性透過 [SlideShowTransition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/) 透露這些設定：

| 屬性 | 用途 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 設定轉場效果本身的持續時間（毫秒）。 |
| [advance_after_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | 設定投影片自動前進前的延遲（毫秒）。啟用 [advance_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 以啟動此計時器。 |
| [speed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionspeed/) 中選取預定義的速度類別：SLOW、MEDIUM 或 FAST。當未指定精確持續時間時使用此設定。 |

[duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 只控制轉場效果；它不決定投影片的可見時間。請分別設定自動前進的延遲。若未設定明確的持續時間，Aspose.Slides 會根據轉場類型和 [speed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 的值決定效果持續時間。

### **將相同持續時間套用至每張投影片**

為了保持一致的節奏，將相同的效果與精確持續時間套用到每張投影片。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並為每個轉場設定 750 毫秒的持續時間。它另外在 5,000 毫秒後啟用自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # 獨立於效果持續時間設定自動前進。
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **為各投影片設定不同的持續時間**

不同的投影片可以使用不同的效果持續時間。例如，為標題投影片使用較短的轉場，為章節介紹使用較長的轉場。此範例為第一張投影片設定 500 毫秒，為第二張設定 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

### **將轉場與動畫輸出同步**

在製作 [animated GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh-hant/python-net/export-to-html5/)、或 [video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期的節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以留出旁白或內容的時間。

對於 GIF 與影片，請將輸出影格率與效果持續時間協調：600 毫秒相當於 30 fps 下的 18 幀。於 HTML5 中，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與時間選項，並預覽輸出以確認同步。

### **讀取現有的轉場持續時間**

在修改轉場之前先讀取 [duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 以判斷是否已儲存明確的值。`-1` 代表未設定明確的持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [speed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 來決定該持續時間。設定轉場類型可能會初始化持續時間，所以請先檢查原始設定。

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

## **Morph 轉場**

Morph 轉場會在連續投影片之間動畫化物件的變化。若要建立簡單的 Morph 效果，請複製一張投影片，於複製品上移動或調整物件尺寸，然後將 Morph 轉場套用到第二張投影片。這樣會讓相對應的物件在原始狀態與修改後狀態之間進行動畫。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製品上變更矩形的位置與大小。接著為第二張投影片從 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 列舉中選取 Morph。使用支援 Morph 的簡報檢視器開啟已儲存的檔案，即可在投影片播放時看到效果。

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

## **Morph 轉場類型**

[TransitionMorphType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionmorphtype/) 列舉控制 Morph 如何匹配與動畫化內容：

- [BY_OBJECT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionmorphtype/) 將每個圖形視為整體物件。
- [BY_WORD](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情況下，依詞彙匹配動畫化文字。
- [BY_CHAR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情況下，依字元匹配動畫化文字。

在存取其 [value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/value/) 之前，先將轉場 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為 Morph。此值會提供 [MorphTransition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/morphtransition/) 物件，其 [morph_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/morphtransition/morph_type/) 屬性可選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為基於詞彙的 Morph 動畫。

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

## **設定轉場效果**

某些轉場會顯示額外選項，例如方向或是否從黑屏開始。可用的選項取決於所選的轉場 [type]。先設定類型，然後從其 [value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/value/) 取得相應的轉場物件使用。

以下範例將 Cut 轉場套用到 `input.pptx` 的第一張投影片。它透過 [OptionalBlackTransition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/optionalblacktransition/) 設定 [from_black](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/)，使轉場從黑屏開始。

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

**我可以控制投影片轉場的播放速度嗎？**

可以。若需要以毫秒為單位的精確效果持續時間，請使用 [duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/duration/)。若使用預定義的 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionspeed/) 類別（SLOW、MEDIUM 或 FAST）已足夠且未設定明確的持續時間，則使用 [speed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/speed/)。這些設定會獨立於自動前進的延遲，控制轉場效果。

**我可以將音訊附加到轉場並使其循環播放嗎？**

可以。將嵌入的音訊指派給 [sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound/)，將 [sound_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) 設為來自 [TransitionSoundMode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitionsoundmode/) 列舉的 START_SOUND，並啟用 [sound_loop](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)。音訊會循環播放，直至投影片放映中的下一個音效事件。

**將相同轉場套用至每張投影片的最快方法是什麼？**

遍歷簡報的 [slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 集合，將每張投影片的轉場 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為相同的值。在同一迴圈中設定任何計時與效果選項，以確保所有投影片的行為一致。

**我要如何檢查投影片目前設定的轉場為何？**

從投影片的 [slide_show_transition](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/slide_show_transition/) 讀取 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/slideshowtransition/type/) 屬性。它會回傳 [TransitionType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.slideshow/transitiontype/) 列舉中的值；NONE 表示未套用任何轉場效果。