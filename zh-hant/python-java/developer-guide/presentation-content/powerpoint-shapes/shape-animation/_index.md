---
title: 在使用 Python via Java 的簡報中套用形狀動畫
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
- 效果聲音
- 套用動畫
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 新增、檢查及自訂形狀動畫、計時、聲音、動畫後行為，以及動畫文字。"
---
## **概觀**

Aspose.Slides for Python via Java 將投影片動畫表示為投影片時間軸中的效果。每個效果具有目標形狀、動畫類型與子類型、觸發方式、計時設定，以及聲音或動畫後行為等可選屬性。

時間軸包含兩種序列：

- **主要序列** 於投影片前進時播放。
- **互動序列** 於觸發形狀被點擊時開始。

由於文字方塊、圖片、圖表、表格以及其他投影片物件皆繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)，您可對大多數投影片內容使用相同的 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 方法。可用的效果列於 [EffectType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttype/) 類別中。

## **新增形狀動畫**

若要加入動畫，取得投影片的主要序列，並以目標形狀、效果類型、子類型以及觸發方式呼叫 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect)。若效果需要在點擊其他形狀時開始，則建立觸發該其他形狀的互動序列。

下列範例同時建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

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

觸發器控制效果何時開始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/#OnClick) 在主要序列中等待點擊，或在互動序列中等待對觸發形狀的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/#WithPrevious) 與前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/#AfterPrevious) 在前一個效果結束時開始。

若要為圖片、圖表或其他形狀類型設定動畫，請將該物件傳遞給 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect)（而非 `target_shape`）。有關圖表專屬的分組選項，請參閱 [Animated Charts](/slides/zh-hant/python-java/animated-charts/)。

## **讀取形狀動畫**

當您已知目標形狀時，使用 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#getEffectsByShape)。若要檢查每一個效果，請列舉主要序列及所有互動序列。列舉可避免假設序列在索引 `0` 處必有效果。

下列範例建立一個同時具有主要序列與互動效果的形狀，取得針對該形狀的效果，然後列舉投影片上的每個序列。

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

如果只需要單一形狀的效果，請先以名稱、占位符類型或其他穩定屬性識別該形狀；接著呼叫 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#getEffectsByShape)。切勿假設索引 `0` 的 [ShapeCollection.get_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#get_Item) 必定是目標物件。

## **處理繼承的占位符效果**

普通投影片上的占位符可以從其版面投影片與母片投影片上對應的占位符繼承動畫行為。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 會回傳該父占位符，若無父占位符則回傳 `None`。

在下列範例簡報中，頁腳在普通投影片上使用 **Random Bars**，在版面投影片上使用 **Split**，在母片投影片上使用 **Fly In**。

![普通投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳占位符動畫效果](layout-shape-animation.png)

![母片投影片上的頁腳占位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報中的占位符階層。它會將效果加入母片占位符、版面占位符以及普通投影片上的對應占位符。每次呼叫 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 前，都會檢查回傳的形狀是否為空。

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

## **變更動畫計時**

PowerPoint **Timing** 對話方塊對應至 [Timing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/) 的屬性。

![PowerPoint 動畫效果的 Timing 對話方塊](shape-animation.png)

- **開始** 對應至 [Timing.getTriggerType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getTriggerType)。
- **持續時間** 對應至 [Timing.getDuration](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getDuration)，單位為秒。
- **延遲** 對應至 [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getTriggerDelayTime)，單位為秒。
- **重複** 對應至 [Timing.getRepeatCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatCount)，[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatUntilNextClick) 或 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)。
- **播放完成後倒帶** 對應至 [Timing.getRewind](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/timing/#getRewind)。

此獨立範例加入一個效果，透過 [Sequence.addEffect] 回傳的物件變更其計時，並儲存結果。保留回傳的 [Effect] 參考可避免不必要的集合索引。

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

請明確使用單一的重複模式。將重複次數與「直到」旗標同時使用，可能在不同的檢視器中產生混亂的結果。變更重複模式時，請先設定 [Timing.setRepeatUntilNextClick] 與 [Timing.setRepeatUntilEndSlide]，再設定 [Timing.setRepeatCount]，因為設定任一旗標會同時變更目前的重複模式。

## **新增與擷取動畫聲音**

動畫效果可以透過 [Effect.getSound] 參照嵌入的音訊。[Effect.setStopPreviousSound] 可指示效果停止先前效果所啟動的音訊。

### **為效果新增聲音**

下列範例假設本機有名為 `animation-sound.wav` 的音訊檔案。它會建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止該聲音。它使用由 [Sequence.addEffect] 回傳的物件，無需指定序列索引。

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

### **擷取嵌入的效果聲音**

下列範例假設本機有名為 `presentation-with-animation-sounds.pptx` 的簡報。它會掃描主要與互動序列，將所有嵌入的效果聲音寫入 `extracted-animation-sounds` 目錄。副檔名依據由 [Audio.getContentType] 顯示的音訊 MIME 類型選取。

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

對於大型音訊物件，請使用 [Audio.getStream] 並將串流複製至檔案，而非將整個物件載入至位元組陣列。

## **設定動畫結束後的行為**

**After animation** 選項決定形狀在效果結束後的處理方式。

![PowerPoint 效果選項對話方塊（顯示動畫結束後設定）](shape-after-animation.png)

[AfterAnimationType] 類別支援保持形狀不變、更改其顏色、於動畫結束後隱藏，或在下一次點擊時隱藏。當類型為 [AfterAnimationType.Color] 時，亦需設定 [Effect.getAfterAnimationColor]。

此獨立範例建立一個效果，透過回傳的 effect 物件設定其動畫結束後的行為，並儲存結果。

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

將類型從 [AfterAnimationType.Color] 改變後，會清除動畫結束後的顏色設定。

## **文字動畫**

文字動畫包含兩個相關控制項：

- [TextAnimation.getBuildType] 控制段落是一次顯示全部，還是逐段顯示。
- [Effect.getAnimateTextType] 控制文字是一次顯示全部、逐字或逐字母顯示。[Effect.getDelayBetweenTextParts] 設定字詞或字母之間的延遲。正值表示效果持續時間的百分比；負值表示以秒為單位的延遲。

下列獨立範例為文字方塊中的單詞加入動畫。[BuildType.AsOneObject] 會停用逐段建構，使字詞設定套用於整個文字框。

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

若要以段落為單位建構文字方塊，請設定 [BuildType.ByLevelParagraphs1]（或其他段落層級）。若要為單一段落指定獨立效果，請使用接受 [Paragraph] 的 [Sequence.addEffect] 重載。請參閱 [Animated Text](/slides/zh-hant/python-java/animated-text/) 取得段落層級的範例。

## **匯出與相容性說明**

- 將檔案儲存為 PPT 或 PPTX 可保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 與靜態影像不會播放動畫。若輸出必須顯示動態，請使用 [HTML5 export](/slides/zh-hant/python-java/export-to-html5/)、動畫 GIF，或 [video conversion](/slides/zh-hant/python-java/convert-powerpoint-to-video/)。
- 對於 HTML5，請啟用 [Html5Options.setAnimateShapes]，必要時再啟用 [Html5Options.setAnimateTransitions]。
- 影片轉換支援許多常見的進入、強調、退出及移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的 [supported animations and effects](/slides/zh-hant/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) 並以目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果與從其他簡報格式匯入的效果雖可能保留於檔案中，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問題**

**為何動畫在 PowerPoint 中出現，卻在 PDF 中沒有？**

PDF 為靜態格式，故不會播放動畫與投影片過渡。若必須保留動態，請匯出為 HTML5、動畫 GIF，或影片。

**為何效果在影片中播放不同？**

影片匯出會將動畫渲染為影片，而非保留原始 PowerPoint 行為。某些進階效果不受支援或僅被近似。請查閱支援的效果表，並在正式使用前測試實際簡報。

**將形狀前移或後移會改變其動畫順序嗎？**

不會。形狀的 Z 軸順序僅影響重疊層次，動畫的播放順序由序列順序與觸發方式決定。如需不同的播放順序，請調整時間軸。