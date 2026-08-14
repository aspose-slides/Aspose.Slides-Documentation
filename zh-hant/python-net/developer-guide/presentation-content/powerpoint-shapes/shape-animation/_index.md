---
title: 在簡報中使用 Python 套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/python-net/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 新增、檢查和自訂形狀動畫、時間設定、聲音、動畫結束後行為以及動畫文字。"
---
## **概述**

Aspose.Slides for Python via .NET 將投影片動畫表示為投影片時間軸上的效果。每個效果都有目標形狀、動畫類型與子類型、觸發方式、時間設定，以及諸如聲音或動畫結束後行為等可選屬性。

時間軸包含兩種序列：

- **主序列** 於投影片前進時播放。
- **互動序列** 在其觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格以及其他投影片物件實作了[IShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishape/)，您可以對大多數投影片內容使用相同的[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/)方法。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttype/)列舉中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主序列，並以目標形狀、效果類型、子類型與觸發方式呼叫[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/)。若要在另一個形狀被點擊時開始的效果，請建立觸發該其他形狀的互動序列。

以下範例會建立兩種動畫並將結果儲存為`shape-animations.pptx`。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

觸發器控制效果何時開始：

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 在主序列中等待點擊，或在互動序列中等待觸發形狀的點擊。
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 與前一個效果同時開始。
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 在前一個效果完成後開始。

若要為圖片、圖表或其他形狀類型加入動畫，請將該物件傳遞給[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/)而不是`target_shape`。有關圖表特定的分組選項，請參閱[Animated Charts](/slides/zh-hant/python-net/animated-charts/)。

## **讀取形狀動畫**

當您知道目標形狀時，使用[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) 。若要檢查每個效果，請遍歷主序列以及所有互動序列。遍歷可避免假設序列在索引`0`處一定有效果。

以下範例建立一個具有主序列與互動效果的形狀，取得針對該形狀的效果，然後遍歷投影片上的每個序列。

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

如果只需要單一形狀的效果，請先以名稱、佔位符類型或其他穩定屬性識別該形狀，然後呼叫[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/get_effects_by_shape/)。不要假設索引`0`處的形狀永遠是目標物件。

## **使用繼承的佔位符效果**

普通投影片上的佔位符可以繼承其版面配置投影片與母版投影片上相對應佔位符的動畫行為。[Shape.get_base_placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_base_placeholder/) 會回傳該父佔位符，若不存在父佔位符則回傳`None`。

在以下範例簡報中，頁腳在普通投影片上具有**Random Bars**，在版面配置投影片上具有**Split**，在母版投影片上具有**Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面配置投影片上頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例自行建立佔位符階層。它將效果加入母版佔位符、版面配置佔位符，以及普通投影片上相對應的佔位符。每次呼叫[Shape.get_base_placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_base_placeholder/) 前，都會先檢查回傳的形狀是否為`None`。

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **變更動畫時間設定**

PowerPoint **Timing** 對話框對應至[Timing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/)的屬性。

![PowerPoint 動畫效果的時間對話框](shape-animation.png)

- **開始** 對應至[Timing.trigger_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/trigger_type/)。
- **持續時間** 對應至[Timing.duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/duration/)，單位為秒。
- **延遲** 對應至[Timing.trigger_delay_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/trigger_delay_time/)，單位為秒。
- **重複** 對應至[Timing.repeat_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_count/)、[Timing.repeat_until_next_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_next_click/)或[Timing.repeat_until_end_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)。
- **播放完成後倒退** 對應至[Timing.rewind](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/rewind/)。

此獨立範例加入一個效果，透過[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/) 回傳的物件變更其時間設定，並儲存結果。保留回傳的[Effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/) 參考可避免不必要的集合索引。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

請有意地僅使用一種重複模式。將重複計數與「until」旗標結合可能在不同的檢視器中產生混淆結果。變更重複模式時，先設定[Timing.repeat_until_next_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_next_click/)與[Timing.repeat_until_end_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)，再設定[Timing.repeat_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_count/)，因為設定任一旗標也會改變目前的重複模式。

## **新增與擷取動畫聲音**

動畫效果可以透過[Effect.sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/sound/) 參照內嵌音訊。[Effect.stop_previous_sound](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/stop_previous_sound/) 可指示效果停止先前效果所啟動的音訊。

### **將聲音加入效果**

以下範例預期本機音訊檔案名稱為`animation-sound.wav`。它建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止該聲音。它使用[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/) 回傳的物件，因此不需要序列索引。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **擷取內嵌效果聲音**

以下範例預期本機簡報名稱為`presentation-with-animation-sounds.pptx`。它掃描主序列與互動序列，將每個內嵌的效果聲音寫入`extracted-animation-sounds` 目錄。副檔名依據[Audio.content_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/audio/content_type/) 所公開的音訊 MIME 類型選取。

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

對於大型音訊物件，請使用[Audio.get_stream](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/audio/get_stream/) 並將串流複製至檔案，而非將整個物件載入至位元組陣列。

## **設定動畫結束後行為**

**After animation** 選項控制形狀在其效果完成後的處理方式。

![PowerPoint 效果選項對話框顯示「動畫結束後」設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 列舉支援保持形狀不變、變更其顏色、動畫結束後隱藏，或在下一次點擊時隱藏。當類型為[AfterAnimationType.COLOR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 時，亦請設定[Effect.after_animation_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/after_animation_color/)。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫結束後行為，並儲存結果。

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

將類型從[AfterAnimationType.COLOR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 變更為其他類型時，會清除動畫結束後的顏色設定。

## **動畫文字**

文字動畫有兩個相關的控制項：

- [TextAnimation.build_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/textanimation/build_type/) 控制段落是一起顯示還是逐段落顯示。
- [Effect.animate_text_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/animate_text_type/) 控制文字是一次全部顯示、逐字或逐字元顯示。[Effect.delay_between_text_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/delay_between_text_parts/) 設定字詞或字元之間的延遲。正值為效果持續時間的百分比，負值為秒數延遲。

以下獨立範例為文字方塊中的單字加入動畫。[BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/buildtype/) 會停用逐段落建構，使字單位設定套用於整個文字框。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

若要逐段落建構文字方塊，請設定[BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/buildtype/)（或其他段落層級）。若要針對單一段落套用自己的效果，請使用接受[IParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iparagraph/) 的[Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/) 重載。請參閱[Animated Text](/slides/zh-hant/python-net/animated-text/) 以取得段落層級範例。

## **匯出與相容性說明**

- 將檔案儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 及靜態影像不會播放動畫。若輸出必須呈現動態，請使用[HTML5 export](/slides/zh-hant/python-net/export-to-html5/)、動畫 GIF，或[video conversion](/slides/zh-hant/python-net/convert-powerpoint-to-video/)。
- 若為 HTML5，請啟用[Html5Options.animate_shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_shapes/)，必要時再啟用[Html5Options.animate_transitions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_transitions/)。
- 影片轉換支援許多常見的進入、強調、退出與路徑動畫，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[supported animations and effects](/slides/zh-hant/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)，並以目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果及從其他簡報格式匯入的效果可能在檔案中保留，但在 PowerPoint、HTML5 或影片中呈現方式不同。請驗證匯出結果，而非僅依據效果名稱。

## **常見問題**

**為何動畫會在 PowerPoint 中顯示，但在 PDF 中不顯示？**

PDF 為靜態格式，無法播放動畫與投影片切換。若需保留動作，請匯出為 HTML5、動畫 GIF 或影片。

**為何效果在影片中播放的方式不同？**

影片匯出會渲染動畫，而非直接儲存原始 PowerPoint 行為。某些進階效果未受支援或僅為近似。請查閱受支援的效果表，並在正式使用前測試實際簡報。

**將形狀向前或向後移動會改變其動畫順序嗎？**

不會。形狀的 Z 軸順序決定疊蓋關係，序列順序與觸發方式決定動畫播放順序。若需要不同的播放順序，請調整時間軸。