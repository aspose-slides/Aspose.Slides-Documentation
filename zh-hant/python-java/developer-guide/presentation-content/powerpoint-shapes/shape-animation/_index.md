---
title: 使用 Python 透過 Java 在簡報中套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/python-java/shape-animation/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 添加、檢查與自訂形狀動畫、時序、音效、後動畫行為以及動畫文字。"
---
## **概觀**

若要處理效果內的個別行為或編輯運動路徑段落，請參閱[自訂動畫](/slides/zh-hant/python-java/custom-animation/)。

Aspose.Slides for Python via Java 以幻燈片時間軸中的效果來表示幻燈片動畫。一個效果包含目標形狀、動畫類型與子類型、觸發條件、時序設定，以及可選的屬性，例如音效或後動畫行為。

時間軸包含兩種序列：

- **主要序列** 於投影片前進時播放。  
- **互動序列** 會在其觸發形狀被點擊時開始。

因為文字方塊、圖片、圖表、表格與其他投影片物件皆繼承自[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)，您可對大多數投影片內容使用相同的[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 方法。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttype/) 類別。

## **新增形狀動畫**

若要新增動畫，取得投影片的主要序列，並以目標形狀、效果類型、子類型與觸發條件呼叫[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect)。若要在另一個形狀被點擊時開始效果，請建立觸發該形狀的互動序列。

以下範例同時建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

觸發條件決定效果何時開始：

- [EffectTriggerType.OnClick] 等待在主要序列中的點擊，或在互動序列中對觸發形狀的點擊。  
- [EffectTriggerType.WithPrevious] 與前一個效果同時開始。  
- [EffectTriggerType.AfterPrevious] 在前一個效果結束時開始。

若要為圖片、圖表或其他形狀類型加上動畫，將該物件傳遞給[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 取代 `target_shape`。有關圖表特定的分組選項，請參閱[Animated Charts](/slides/zh-hant/python-java/animated-charts/)。

## **讀取形狀動畫**

當已知目標形狀時，可使用[Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#getEffectsByShape)。若要檢查每個效果，請遍歷主要序列與所有互動序列。遍歷可避免假設序列在索引 `0` 處一定有效果。

以下範例建立具有主要序列與互動序列效果的形狀，取得針對該形狀的效果，然後遍歷投影片上的每個序列。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

如果只需要單一形狀的效果，請先以名稱、佔位符型別或其他穩定屬性識別該形狀；然後呼叫[Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#getEffectsByShape)。切勿假設[ShapeCollection.get_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#get_Item) 在索引 `0` 處必定是目標物件。

## **處理繼承佔位符效果**

普通投影片上的佔位符可以繼承其版面投影片與母片投影片上對應佔位符的動畫行為。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 會傳回該父佔位符，若無父佔位符則傳回 `None`。

在以下示範簡報中，頁腳在普通投影片上使用 **Random Bars**，在版面投影片上使用 **Split**，在母片投影片上使用 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳佔位符動畫效果](layout-shape-animation.png)

![母片投影片上的頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報的佔位符層級。它為母片佔位符、版面佔位符以及普通投影片上的對應佔位符加入效果。每次呼叫[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 前都會檢查回傳的形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **變更動畫時序**

PowerPoint **Timing** 對話框對應到[Timing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/) 的屬性。

![PowerPoint 動畫效果的時序對話框](shape-animation.png)

- **Start** 對應到[Timing.getTriggerType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getTriggerType)。  
- **Duration** 對應到[Timing.getDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getDuration)，單位為秒。  
- **Delay** 對應到[Timing.getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getTriggerDelayTime)，單位為秒。  
- **Repeat** 對應到[Timing.getRepeatCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatUntilNextClick) 或 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)。  
- **Rewind when done playing** 對應到[Timing.getRewind](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRewind)。

此獨立範例加入一個效果，透過[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 回傳的物件變更其時序，並儲存結果。保留回傳的[Effect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/) 參考，以免產生不必要的集合索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

請僅使用一種重複模式。將重複次數與「直到」旗標同時使用可能在不同檢視器中產生混淆結果。變更重複模式時，請先呼叫[Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#setRepeatUntilNextClick) 與[Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#setRepeatUntilEndSlide)，再呼叫[Timing.setRepeatCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#setRepeatCount)，因為設定任一旗標亦會變更目前的重複模式。

## **新增與提取動畫聲音**

動畫效果可以透過[Effect.getSound](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/#getSound) 參照內嵌音訊。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/#setStopPreviousSound) 可指示效果停止先前效果所啟動的音訊。

### **為效果新增聲音**

以下範例假設本機有名為 `animation-sound.wav` 的音訊檔。它建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止該聲音。它使用[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 回傳的物件，因此不需要序列索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **提取內嵌效果聲音**

以下範例假設本機有名為 `presentation-with-animation-sounds.pptx` 的簡報。它掃描主要與互動序列，將每個內嵌效果聲音寫入 `extracted-animation-sounds` 目錄。副檔名依據[Audio.getContentType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audio/#getContentType) 所回傳的音訊 MIME 類型決定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

對於大型音訊物件，請使用[Audio.getStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audio/#getStream) 並將串流複製到檔案，而非將整個物件載入至位元組陣列。

## **設定後動畫行為**

**After animation** 選項控制形狀在效果結束後的處理方式。

![PowerPoint 效果選項對話框，顯示「後動畫」設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/afteranimationtype/) 類別支援保留形狀不變、變更其顏色、在動畫後隱藏形狀，或在下一次點擊時隱藏。當類型為[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/afteranimationtype/#Color) 時，亦須設定[Effect.getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/#getAfterAnimationColor)。

此獨立範例建立一個效果，透過回傳的 effect 物件設定其後動畫行為，並儲存結果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

將類型從[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/afteranimationtype/#Color) 變更為其他類型時，會清除後動畫顏色設定。

## **動畫文字**

文字動畫有兩個相關控制項：

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textanimation/#getBuildType) 控制段落是一起出現還是逐段落顯示。  
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/#getAnimateTextType) 控制文字是一次性全部出現、逐字或逐字元顯示。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effect/#getDelayBetweenTextParts) 設定字詞或字元之間的延遲。正值為效果持續時間的百分比；負值為秒數延遲。

以下獨立範例對文字方塊中的單字進行動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/buildtype/#AsOneObject) 會停用段落逐段建立，使字詞設定套用於整個文字框。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要以段落為單位建立文字方塊，請設定[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落層級）。若要針對單一段落使用獨立效果，請使用接受[Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 的[Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 覆載版本。請參閱[Animated Text](/slides/zh-hant/python-java/animated-text/) 取得段落層級範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。  
- PDF 與靜態影像不會播放動畫。若輸出必須顯示動作，請使用[HTML5 匯出](/slides/zh-hant/python-java/export-to-html5/)、動畫 GIF 或[影片轉換](/slides/zh-hant/python-java/convert-powerpoint-to-video/)。  
- 對於 HTML5，請啟用[Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateShapes)，必要時再啟用[Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/html5options/#setAnimateTransitions)。  
- 影片轉換支援許多常見的進入、強調、退出與運動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[支援動畫與效果](/slides/zh-hant/python-java/convert-powerpoint-to-video/#supported-animations-and-effects)，並以目標 Aspose.Slides 版本測試關鍵簡報。  
- 進階自訂效果與從其他簡報格式匯入的效果可能會保留於檔案中，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問答**

**為何動畫在 PowerPoint 中會顯示，但在 PDF 中不會？**

PDF 為靜態格式，故不會播放動畫與投影片過場。若必須保留動作，請匯出為 HTML5、動畫 GIF 或影片。

**為何效果在影片中播放的方式不同？**

影片匯出會將動畫渲染成影片，而非儲存原始的 PowerPoint 行為。部分進階效果不受支援或會被近似處理。請參閱支援效果表，並於正式使用前測試實際簡報。

**將形狀前移或後移會改變其動畫順序嗎？**

不會。形狀的 Z 順序僅控制重疊關係，動畫的播放順序由序列順序與觸發條件決定。如需改變播放順序，請調整時間軸。