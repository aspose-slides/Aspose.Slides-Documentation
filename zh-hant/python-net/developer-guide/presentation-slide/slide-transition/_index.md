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
## **概述**

投影片轉場控制投影片在投影片放映期間的顯示方式。使用 Aspose.Slides for Python via .NET，您可以為每張投影片選擇轉場效果、設定滑鼠點擊或計時器的前進方式，並調整特定效果的選項。本文以 Python 範例說明如何套用轉場、設定精確的轉場持續時間、管理投影片計時，並在兩張投影片之間建立 Morph 轉場。範例亦示範如何將設定儲存為 PPTX 檔案。

## **新增投影片轉場**

若要套用轉場，請使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別載入簡報，並存取投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 屬性。將其 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉的值，然後儲存簡報。

以下範例對第一張投影片套用 Circle 轉場，對第二張投影片套用 Comb 轉場。請使用至少包含兩張投影片的 `input.pptx` 檔案。

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

## **Wheel 轉場**

[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) 的 [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) 屬性控制顯示目標投影片的徑向區段數量。將投影片的轉場 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為來自 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 的 WHEEL，然後再以 [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) 形式取得 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)。

此範例建立兩組相同的投影片：一張黑色投影片，接著是一張帶金色矩形的投影片。目標投影片分別使用 1 與 8 根輻條，兩者的 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 相同，且明確設定 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 為 8,000 毫秒，以便易於觀察差異。

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

在 PowerPoint 中開啟輸出簡報並執行投影片放映。從第 1 張投影片前進至第 2 張，然後從第 3 張前進至第 4 張。於 PowerPoint 播放時，驗證過的 1 根輻條會以順時針掃描一次顯示投影片；驗證過的 8 根輻條則同時以八個徑向區段顯示投影片。目的內容與轉場計時相同，唯一差異在於顯示區段的數量。

## **Fade Through Black 搭配 Reveal 轉場**

將目標投影片的轉場 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為 Reveal，然後在產生的 [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) 物件上設定 [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/)。此範例建立一張青綠色來源投影片與一張珊瑚色目標投影片，然後將此對投影片複製。兩組投影片皆使用相同的兩秒 Reveal 轉場，只有第二組會在轉場期間通過黑色。

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

在 PowerPoint 中開啟 `reveal-transitions.pptx` 並開始投影片放映。從第 1 張投影片前進至第 2 張，可看到青綠色直接淡入珊瑚色。再從第 3 張投影片前進至第 4 張，畫面會短暫變暗至接近黑色，然後顯示珊瑚色投影片。兩張投影片仍保留其原始背景色。

下方的列顯示每半秒的 PowerPoint 影格。比較每列中間的影格，即可看到設定的效果差異。

![PowerPoint 播放時未啟用 through_black（上）與啟用（下）。僅下列會通過近乎黑色。](reveal-through-black.png)

## **新增進階投影片轉場**

您可以設定投影片在螢幕上停留的時間，以及是否以滑鼠點擊前進投影片放映。以下屬性負責此行為：

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 允許觀眾透過點擊滑鼠前進。
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 啟用自動前進。
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 指定自動前進前的延遲時間（毫秒）。

同時啟用點擊與計時前進，讓觀眾可點擊前進或等待計時器。若僅使用計時器，將 [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 設為 `False`。延遲時間控制投影片何時前進；它不會設定視覺轉場效果的持續時間。

此範例為前三張投影片分別指定不同的效果，並分別在 3、5、7 秒後自動前進。滑鼠點擊同樣可以前進這些投影片。請使用至少包含三張投影片的 `input.pptx` 檔案。

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

若要檢查是否已啟用計時前進，請讀取 [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/)。僅有延遲值並不表示計時器已啟動。

下一個範例開啟上述儲存的檔案，報告每個已啟用的計時器，並將延遲大於兩秒的投影片關閉自動前進，改為啟用滑鼠點擊，最後儲存更新後的設定。

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

## **精確控制轉場計時**

使用 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 可在毫秒級別指定轉場效果的精確長度。投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 屬性透過 [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) 透露這些設定：

| 屬性 | 目的 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 設定轉場效果本身的持續時間（毫秒）。 |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | 設定投影片自動前進前的延遲時間（毫秒）。必須啟用 [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 才會生效。 |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | 從 [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)（SLOW、MEDIUM、FAST）中選擇預先定義的速度類別。當未指定精確持續時間時會使用此設定。 |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 只控制轉場效果本身，並不決定投影片的可見時間。請分別設定自動前進的延遲。若未設定明確的 duration，Aspose.Slides 會根據轉場類型與 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 來推算效果長度。

<!-- visual-explanation:slide-transition:start -->
[![分別的長條顯示 750 ms 的轉場持續時間與 5,000 ms 的自動前進設定。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*此共用範例為每張投影片設定 750 ms 的 Fade 轉場，並另行啟用 5,000 ms 的自動前進。轉場持續時間控制效果；前進時間控制何時離開投影片。這些長條僅是示意設定，非量測得到的完整時間軸。*
<!-- visual-explanation:slide-transition:end -->

### **將相同持續時間套用到每張投影片**

為了保持節奏一致，請對每張投影片套用相同的效果與精確持續時間。此範例載入 `input.pptx`，從 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 中選取 Fade，並將每個轉場的持續時間設為 750 毫秒。接著分別啟用 5,000 毫秒的自動前進，並停用滑鼠點擊前進，最後將結果儲存為 PPTX。

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

不同投影片可以使用不同的效果持續時間。例如，對標題投影片使用較短的轉場，對章節介紹投影片使用較長的轉場。此範例將第一張投影片的持續時間設為 500 毫秒，第二張投影片設為 1,200 毫秒。請使用至少包含兩張投影片的 `input.pptx`。

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

在製作 [animated GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 簡報](/slides/zh-hant/python-net/export-to-html5/) 或 [影片](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 時，請在匯出前設定精確的轉場持續時間，以符合預期節奏。例如，在場景之間使用 600 毫秒的淡入淡出，並分別調整每張投影片的前進延遲，以容許旁白或內容的播放時間。

對於 GIF 與影片，請將輸出幀率與效果持續時間對齊：600 毫秒相當於 30 fps 時的 18 幀。對於 HTML5，請在匯出設定中啟用動畫轉場。檢查所選匯出格式支援的效果與計時選項，並預覽輸出以確認同步。

### **讀取現有的轉場持續時間**

在修改轉場之前，先讀取 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 以判斷是否已儲存明確值。`-1` 代表未設定明確持續時間；非負值則表示以毫秒為單位的已儲存持續時間。未設定的值並非計算出的播放持續時間：Aspose.Slides 會根據轉場類型與 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 推算此時間。設定轉場類型時可能會初始化 duration，故先檢查原始設定是必要的。

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

Morph 轉場會在連續投影片之間動畫化物件變化。若要建立簡易的 Morph 效果，只需複製投影片、在複製品上移動或調整物件大小，然後對第二張投影片套用 Morph 轉場。這會讓對應的物件在原始與修改後的狀態之間動畫化。

以下範例建立一張包含文字矩形的投影片，複製該投影片，並在複製品上改變矩形的位置與大小。接著從 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉中選取 Morph 作為第二張投影片的轉場。將儲存的檔案在支援 Morph 的簡報檢視器中開啟，即可於投影片放映時看到效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列舉決定 Morph 如何匹配與動畫化內容：

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 將每個圖形視為完整物件。
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情況下，以詞為單位動畫化文字。
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情況下，以字元為單位動畫化文字。

在取得其 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) 之前，先將轉場 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為 Morph。取得的值會回傳 [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) 物件，其 [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) 屬性選擇匹配模式。

此範例開啟前一節建立的簡報，並將第二張投影片設定為以詞為單位的 Morph 動畫。

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

某些轉場會暴露額外選項，例如方向或是否從黑屏開始。可用的選項取決於所選轉場的 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)。請先設定類型，然後從其 [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) 取得相應的轉場物件。

以下範例對 `input.pptx` 的第一張投影片套用 Cut 轉場，並透過 [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) 的 [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) 屬性，使轉場從黑色畫面開始。

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

## **常見問題集**

**我可以控制投影片轉場的播放速度嗎？**

可以。當需要以毫秒為單位的精確效果持續時間時，請使用 [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/)。若預設的 [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/)（SLOW、MEDIUM、FAST）已足夠且未設定明確的 duration，請使用 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)。這些設定會獨立於自動前進的延遲，僅控制轉場效果。

**我可以為轉場附加音訊並讓它循環播放嗎？**

可以。將內嵌音訊指派給 [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)，將 [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) 設為 [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) 中的 START_SOUND，並啟用 [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)。音訊會持續循環，直至投影片放映中的下一個音效事件。

**將相同轉場套用到每張投影片的最快方法是什麼？**

遍歷簡報的 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合，將每張投影片的轉場 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) 設為相同的值。在同一迴圈中設定任何計時或效果選項，即可確保所有投影片的行為保持一致。

**我該如何檢查投影片目前設定了哪種轉場？**

從投影片的 [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) 讀取 [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)。此屬性會回傳來自 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列舉的值；若為 NONE，表示未套用任何轉場效果。