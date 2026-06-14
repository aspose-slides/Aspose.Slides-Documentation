---
title: 使用 Python 在簡報中套用形狀動畫
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
- 提取動畫
- 新增效果
- 取得效果
- 提取效果
- 效果聲音
- 套用動畫
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中建立與自訂形狀動畫。脫穎而出！"
---
## **簡介**

動畫是可套用於文字、影像、圖形或[圖表](/slides/zh-hant/python-net/animated-charts/)的視覺效果。它們為簡報或其組成部分賦予活力。 

## **為何在簡報中使用動畫？**

使用動畫，您可以 

* 控制資訊的流程
* 強調重要要點
* 提升觀眾的興趣或參與度
* 讓內容更易於閱讀、理解或處理
* 吸引讀者或觀眾注意簡報中的重要部分

PowerPoint 提供眾多動畫與動畫效果的選項與工具，涵蓋 **入口**、**退出**、**強調** 和 **移動路徑** 類別。 

## **Aspose.Slides 中的動畫**

* Aspose.Slides 提供您在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/) 命名空間下使用動畫所需的類別與型別，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttype/) 列舉中提供超過 **150 種動畫效果**。這些效果本質上與 PowerPoint 中使用的效果相同（或等價）。

## **將動畫套用至文字方塊**

Aspose.Slides for Python via .NET 允許您將動畫套用至形狀中的文字。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iautoshape/)。  
4. 將文字新增至 `IAutoShape.TextFrame`。  
5. 取得主要的效果序列。  
6. 為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iautoshape/) 新增動畫效果。  
7. 將 `TextAnimation.BuildType` 屬性設定為 `BuildType` 列舉中的值。  
8. 將簡報寫入磁碟，儲存為 PPTX 檔案。  

以下 Python 程式碼示範如何將 `Fade` 效果套用至 AutoShape，並將文字動畫設定為 *By 1st Level Paragraphs* 值：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 類別。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # 新增帶文字的 AutoShape
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # 取得投影片的主要序列。
    sequence = sld.timeline.main_sequence

    # 為形狀新增 Fade 動畫效果
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # 依第一層段落動畫化形狀文字
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # 將 PPTX 檔案儲存至磁碟
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

除了將動畫套用至文字之外，您也可以將動畫套用至單一[段落](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iparagraph/)。請參閱[**動畫文字**](/slides/zh-hant/python-net/animated-text/)。 

{{% /alert %}} 

## **將動畫套用至圖片框**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 在投影片上新增或取得 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。  
4. 取得主要的效果序列。  
5. 為 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 新增動畫效果。  
6. 將簡報寫入磁碟，儲存為 PPTX 檔案。  

以下 Python 程式碼示範如何將 `Fly` 效果套用至圖片框：

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# 實例化一個代表簡報檔案的 Presentation 類別。
with slides.Presentation() as pres:
    # 載入要加入簡報影像集合的圖像
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # 在投影片上新增圖片框
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # 取得投影片的主要序列。
    sequence = pres.slides[0].timeline.main_sequence

    # 為圖片框新增從左側飛入的動畫效果
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # 將 PPTX 檔案儲存至磁碟
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **將動畫套用至形狀**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 新增一個 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iautoshape/)。  
4. 新增一個 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iautoshape/)（點擊此物件時即播放動畫）。  
5. 為斜角形狀建立效果序列。  
6. 建立自訂 `UserPath`。  
7. 加入移動至 `UserPath` 的指令。  
8. 将简报写入磁碟，儲存為 PPTX 檔案。  

以下 Python 程式碼示範如何將 `PathFootball`（路徑足球）效果套用至形狀：

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# 實例化一個代表 PPTX 檔案的 Presentation 類別。
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 從頭開始為現有形狀建立 PathFootball 效果。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # 新增 PathFootBall 動畫效果。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 建立某種「按鈕」。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # 為按鈕建立效果序列。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # 建立自訂使用者路徑。只有在按下按鈕後，我們的物件才會移動。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 加入移動指令，因為建立的路徑目前為空。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **取得套用於形狀的動畫效果**

以下範例示範如何使用 [Sequence](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/) 類別的 `get_effects_by_shape` 方法，取得套用於形狀的所有動畫效果。

**範例 1：取得套用於普通投影片上形狀的動畫效果**

先前您已學習如何在 PowerPoint 簡報中為形狀新增動畫效果。以下範例程式碼示範如何取得簡報 `AnimExample_out.pptx` 中第一張普通投影片上第一個形狀所套用的效果。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # 取得投影片的主要動畫序列。
    sequence = first_slide.timeline.main_sequence

    # 取得第一張投影片上的第一個形狀。
    shape = first_slide.shapes[0]

    # 取得套用於該形狀的動畫效果。
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**範例 2：取得所有動畫效果，包括從佔位區繼承的效果**

如果普通投影片上的形狀具有位於版面投影片和/或母片投影片的佔位區，且已為這些佔位區新增動畫效果，則在投影片放映時，該形狀的所有效果都會被播放，包含從佔位區繼承的效果。

假設我們有一個 PowerPoint 簡報檔案 `sample.pptx`，其中只有一張投影片，包含一個僅有文字「Made with Aspose.Slides」的頁腳形狀，且已套用 **Random Bars** 效果。

![投影片形狀動畫效果](slide-shape-animation.png)

再假設在 **版面** 投影片的頁腳佔位區上套用了 **Split** 效果。

![版面形狀動畫效果](layout-shape-animation.png)

最後，在 **母片** 投影片的頁腳佔位區上套用了 **Fly In** 效果。

![母片形狀動畫效果](master-shape-animation.png)

以下範例程式碼示範如何使用 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 類別的 `get_base_placeholder` 方法，存取形狀佔位區，並取得套用於頁腳形狀的動畫效果，包含來自版面與母片投影片上佔位區的繼承效果。

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 取得普通投影片上形狀的動畫效果。
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # 取得版面投影片上佔位區的動畫效果。
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # 取得母片投影片上佔位區的動畫效果。
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **變更動畫效果的時間屬性**

Aspose.Slides for Python via .NET 允許您變更動畫效果的 Timing（時間）屬性。

以下為 Microsoft PowerPoint 中的動畫時間面板：

![動畫時間面板](shape-animation.png)

以下為 PowerPoint Timing 與 `Effect.Timing` 屬性之對應關係：

- PowerPoint Timing **Start** 下拉選單對應到 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 屬性。 
- PowerPoint Timing **Duration** 對應到 `Effect.Timing.Duration` 屬性。動畫的持續時間（秒）為動畫完成一次循環所需的總時間。 
- PowerPoint Timing **Delay** 對應到 `Effect.Timing.TriggerDelayTime` 屬性。 

以下說明如何變更 Effect Timing（效果時間）屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。  
2. 為所需的 `Effect.Timing` 屬性設定新值。  
3. 儲存修改後的 PPTX 檔案。

以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 類別。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # 取得投影片的主要序列。
    sequence = pres.slides[0].timeline.main_sequence

    # 取得主要序列的第一個效果。
    effect = sequence[0]

    # 將效果的 TriggerType 變更為點擊時開始
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 變更效果的持續時間
    effect.timing.duration = 3

    # 變更效果的 TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # 將 PPTX 檔案儲存至磁碟
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **動畫效果聲音**

Aspose.Slides 提供以下屬性，讓您在動畫效果中使用聲音： 

- `sound`
- `stop_previous_sound`

### **新增動畫效果聲音**

以下 Python 程式碼示範如何新增動畫效果聲音，並在下一個效果開始時停止該聲音：

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # 將音訊新增至簡報的音訊集合
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # 取得投影片的主要序列。
    sequence = first_slide.timeline.main_sequence

    # 取得主要序列的第一個效果
    first_effect = sequence[0]

    # 檢查效果是否為「無聲」
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 為第一個效果新增聲音
        first_effect.sound = effect_sound

    # 取得投影片的第一個互動序列。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 設定效果的「停止前一個聲音」旗標
    interactive_sequence[0].stop_previous_sound = True

    # 將 PPTX 檔案寫入磁碟
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **擷取動畫效果聲音**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 取得主要的效果序列。  
4. 擷取嵌入於每個動畫效果的 `sound`。  

以下 Python 程式碼示範如何擷取嵌入於動畫效果中的聲音：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 類別。
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # 取得投影片的主要序列。
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # 以位元組陣列提取效果聲音
        audio = effect.sound.binary_data
```

## **動畫結束後**

Aspose.Slides for .NET 允許您變更動畫效果的 After animation（動畫結束後）屬性。

![動畫結束後面板](shape-after-animation.png)

PowerPoint 效果 **After animation** 下拉選單對應以下屬性：

- `after_animation_type` 屬性描述動畫結束後的類型：
  * PowerPoint **More Colors** 對應 [COLOR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 類型；
  * PowerPoint **Don't Dim** 項目對應 [DO_NOT_DIM](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 類型（預設的動畫結束後類型）；
  * PowerPoint **Hide After Animation** 項目對應 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 類型；
  * PowerPoint **Hide on Next Mouse Click** 項目對應 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 類型；
- `after_animation_color` 屬性定義動畫結束後的顏色格式。此屬性與 [COLOR](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/afteranimationtype/) 類型共同使用。若將類型更改為其他，動畫結束後的顏色將被清除。

以下 Python 程式碼示範如何變更動畫結束後的效果：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 類別
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 取得主要序列的第一個效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 將動畫結束後類型變更為顏色
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # 設定動畫結束後的暗淡顏色
    first_effect.after_animation_color.color = Color.alice_blue

    # 將 PPTX 檔案寫入磁碟
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **動畫文字**

Aspose.Slides 提供以下屬性，讓您操作動畫效果的 *Animate text*（動畫文字）區塊：

- `animate_text_type` 描述效果的動畫文字類型。形狀文字可依以下方式動畫化：
  - 同時全部 ([ALL_AT_ONCE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/animatetexttype/) 類型)
  - 逐字（[BY_WORD](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/animatetexttype/) 類型）
  - 逐字元（[BY_LETTER](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/animatetexttype/) 類型）
- `delay_between_text_parts` 設定動畫文字部件（詞或字元）之間的延遲。正值表示效果持續時間的百分比，負值表示以秒為單位的延遲。

以下說明如何變更 Effect Animate text（效果動畫文字）屬性：

1. [套用](#apply-animation-to-shape)或取得動畫效果。  
2. 將 `build_type` 屬性設定為 [AS_ONE_OBJECT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/buildtype/) 值，以關閉 *By Paragraphs*（逐段落）動畫模式。  
3. 為 `animate_text_type` 與 `delay_between_text_parts` 屬性設定新值。  
4. 儲存修改後的 PPTX 檔案。  

以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 取得主要序列的第一個效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 將效果的文字動畫類型變更為「As One Object」
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # 將效果的動畫文字類型變更為「By word」
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 將單字之間的延遲設為效果持續時間的 20%
    first_effect.delay_between_text_parts = 20

    # 將 PPTX 檔案寫入磁碟
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **常見問題**

**如何確保在將簡報發佈至網路時保留動畫？**

[Export to HTML5](/slides/zh-hant/python-net/export-to-html5/) 並啟用負責[形狀](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_shapes/)與[轉場](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/animate_transitions/)動畫的[選項](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/html5options/)。純 HTML 不會播放投影片動畫，而 HTML5 則會。

**變更形狀的 Z 序（圖層順序）會如何影響動畫？**

動畫順序與繪製順序是獨立的：效果控制出現/消失的時間與類型，而 [z-order](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/z_order_position/) 決定哪個覆蓋哪個。最終的可見結果取決於兩者的組合。（這是一般 PowerPoint 的行為；Aspose.Slides 的效果與形狀模型亦遵循相同邏輯。）

**將某些動畫效果轉換為影片時是否有限制？**

一般而言，[動畫受支援](/slides/zh-hant/python-net/convert-powerpoint-to-video/)，但在少數情況或特定效果下可能會以不同方式呈現。建議使用您所使用的效果以及相應的函式庫版本進行測試。