---
title: 在 Python 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/python-net/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為及可編輯的移動路徑。"
---
## **概觀**

自訂動畫行為讓您能控制動畫效果中的個別操作，例如變更顏色、旋轉形狀，或沿可編輯的移動路徑移動。本指南說明如何建立與組合行為、設定它們的時間、檢查與修改現有動畫，並驗證其屬性在儲存與重新開啟簡報後仍能保留。

如需預先定義的效果與點擊觸發，請參閱 [Shape Animation](/slides/zh-hant/python-net/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- 投影片的 [timeline](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/timeline/) 包含主要序列與互動序列。
- [Sequence](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/) 包含效果，可能針對不同的形狀。
- [Effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/) 指定目標形狀、預設、子類別以及效果時間。
- [Effect.behaviors](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/behaviors/) 包含實作效果的操作：變色、移動、旋轉、設定屬性等等。

## **建立單一行為**

呼叫 [Sequence.add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/) 可建立效果並取得其 [behaviors](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/behaviors/) 集合。預設可以自動填充此集合。延伸預設時保留其操作，或在刻意取代時使用 [clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/clear/)。

[BehaviorFactory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/) 建立下列八種行為類型。移動相關內容請參閱 [Build a Motion Path](#build-a-motion-path)。每個建立範例都是完整程式；稍後的編輯範例會說明使用的輸出檔案。

### **Rotation**

使用 [create_rotation_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) 來建立旋轉。[by](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect/by/) 指定相對角度（度）；[from_address](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect/from_address/) 與 [to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect/to/) 指定端點。

此範例先使用 Spin 效果，將其預設操作取代為單一旋轉行為，並將該操作的持續時間設定為兩秒。90 度的相對角度代表形狀起始方向的四分之一次轉，因此不需要明確的起始角度。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` 包含一個形狀與一個旋轉行為。下面的集合、時間與旋轉編輯範例皆以此檔案為基礎。

### **Scale**

使用 [create_scale_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) 並以 X/Y 百分比指定：[from_address](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/scaleeffect/from_address/) 與 [to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/scaleeffect/to/) 描述起始與結束尺寸；[by](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/scaleeffect/by/) 描述相對變化。此處 100 代表原始尺寸。

範例在兩秒內將兩個維度從 100% 成長至 125%。使用相同的水平與垂直百分比可保持形狀比例；若使用不同百分比則會將其中一個維度拉伸得較多。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Color**

使用 [create_color_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) 將填色由藍色變為橙色。[from_address](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/coloreffect/from_address/) 與 [to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/coloreffect/to/) 為顏色；[by](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/coloreffect/by/) 為顏色偏移。[Behavior.properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/properties/) 會指出被動畫化的屬性。

形狀的實心填色預設為藍色，與動畫的起始顏色相符。選取 fill‑color 屬性可告訴行為要變更形狀的哪個部份；僅有顏色端點並不會指定該屬性。已儲存的效果描述一次兩秒的過渡至橙色。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filter**

使用 [create_filter_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) 來選取擦拭效果。[type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/filtereffect/type/)、[subtype](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/filtereffect/subtype/) 與 [reveal](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/filtereffect/reveal/) 分別指定過濾器、方向以及是顯示還是隱藏形狀。

此範例設定兩秒的擦拭，使用右方向子類別顯示形狀。過濾器設定屬於效果內的行為，因此在移除預設的原始操作後再進行設定。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Property**

使用 [create_property_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) 來動畫化不透明度。[from_address](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/from_address/)、[to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/to/) 與 [by](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/by/) 為字串，會依 [value_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/value_type/) 與 [calc_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/calc_mode/) 進行解釋。請選擇端點或相對偏移，而不是同時設定三者。

此例選取的屬性是 opacity，數值字串代表從 25% 不透明度變為完全不透明。線性插值描述在這兩個值之間的漸變。若改為其他屬性，請選擇適合該屬性的值型別與端點值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Set**

使用 [create_set_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) 透過 [to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/seteffect/to/) 指定可見性。Set 行為不會在端點之間插值。

範例選取 visibility 屬性，並在行為執行時指派字串 `visible`。在此最簡簡報中矩形本來就已可見，單獨指派可能看不出明顯的視覺變化。此類操作在結合其他控制形狀隱藏或顯示的效果時才會顯得有用。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Command**

使用 [create_command_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) 並設定 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/commandeffect/type/)、[command_string](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/commandeffect/command_string/)、[shape_target](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/commandeffect/shape_target/)。將名為 `sample.wav` 的 WAV 錄音放在工作目錄中。此範例使用 [add_audio_frame_embedded](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 將其嵌入，並將播放指令附加到音訊框架。

音訊框架同時是效果的目標與指令的目標。這樣即可將播放請求連結至嵌入的錄音；單純的指令字串並不會指明要控制哪個媒體物件。此效果設定為在投影片放映時點擊即可開始。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

儲存後指令會存於 `command.pptx`，但不會自動播放錄音。播放需要支援該指令與其媒體目標的投影片放映程式。

## **管理行為集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/) 支援 [add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/remove/)、[remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/remove_at/)。此範例開啟 `rotation.pptx`，加入縮放、將其移至旋轉之前，最後移除旋轉。移除並重新插入同一物件會改變其儲存位置而不會產生副本。

編輯順序將集合由 rotation–scale 變為 scale–rotation，最後僅剩 scale。索引會依據當前集合計算，因此在重新排序後，移除會使用旋轉的新索引。最後的列舉確認哪個行為會被儲存。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

輸出為 `ScaleEffect`：僅剩縮放。集合順序本身不會安排行為依次執行。只有在全部替換其操作時才需要清除集合。

## **設定行為時間**

[Behavior.timing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/timing/) 會露出 [Timing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/)，此時間獨立於 [Effect.timing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/timing/)。Effect 時間排定封閉的效果；行為時間則描述其中的單一操作。

### **設定持續時間、延遲、重複與加速**

開啟 `rotation.pptx`，以秒為單位設定 [duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/duration/) 與 [trigger_delay_time](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/trigger_delay_time/)，再設定 [repeat_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_count/)。[accelerate](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/accelerate/) 與 [decelerate](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/decelerate/) 為持續時間的分數，總和請勿超過 1。

輸入檔案為旋轉範例所建立的檔案，第一個行為已知為旋轉。此範例僅變更該行為的時間設定，90 度的角度保持不變。將角度與時間分開設定，可在不重新建構動畫的情況下調整速度。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

此行為使用兩秒持續時間、半秒延遲，且 repeat_count 為 3。持續時間的前後 20% 用於加速與減速。

其他重複策略包括 [repeat_duration](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_duration/)、[repeat_until_end_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)、[repeat_until_next_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/repeat_until_next_click/)，請選擇其中一種而非同時啟用。 [auto_reverse](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/timing/auto_reverse/) 會在正向播放後反向播放。加速與減速僅適用於連續變化，不適用於離散的指派或指令。

## **建立移動路徑**

使用 [create_motion_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) 建立移動。其 [from_address](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/from_address/)、[to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/to/)、[by](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/by/) 皆描述以百分比為基礎的座標或偏移。若需可編輯的路徑，請建立 [MotionPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpath/) 並指派給 [MotionEffect.path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/path/)。[MotionPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpath/) 會儲存路徑指令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncommandpathtype/) 用於選擇操作：

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | 設定起始位置。 |
| LINE_TO | One | 沿直線段移動至端點。 |
| CURVE_TO | Three | 依兩個控制點與端點遵循三次曲線。 |
| CLOSE_LOOP | None | 回到起始位置。 |
| END | None | 結束路徑。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpathpointstype/) 描述點的編輯特性，例如拐角點或平滑點。它不會取代指令類型。曲線範例使用曲線點類型，直線段則使用拐角點類型。

路徑座標以投影片尺寸正規化：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。Absolute 指令使用路徑座標系的絕對位置；Relative 指令則使用相對於當前位置的偏移。這與 [origin](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/origin/)（選擇路徑參考框架）以及 [path_edit_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/path_edit_mode/)（控制形狀移動時路徑的行為）是分開的概念。

### **建立直線路徑**

建立一個包含起點、單一直線段與結束指令的移動行為。[MotionPath.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpath/add/) 需要指令類型、點集合、點類型，及相對座標旗標。

起始指令設定 (0, 0)，線段結束於 (0.25, 0)，即水平位移為投影片寬度的四分之一。結束指令不帶座標點。將路徑指派後，將移動行為加入效果，即可將此路徑套用至矩形。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` 包含一個具有三個路徑指令的移動行為。以下的檔案編輯範例皆以此已知結構為基礎。

### **比較絕對與相對座標**

以下兩個路徑物件描述相同的路徑。絕對指令的終點為 (0.3, 0.1)；相對指令則將 (0.1, 0.1) 加到當前位置 (0.2, 0)。

兩條路徑皆從相同位置開始。對於相對線段，將其 X、Y 偏移加到當前位置即可得到端點；對於絕對線段，直接讀取端點。若未轉換座標就切換旗標，會得到不同的路徑。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

將任一路徑指派給移動行為，即可在簡報中使用。最後的布林引數決定該指令是否使用相對座標。

### **將直線取代為曲線**

開啟 `motion.pptx`，將其線段指令換成三次曲線。先提供兩個控制點，最後提供端點。

起始位置由前一個指令提供。前兩個點形塑曲線，第三個點則是曲線的終點；它們並非三個連續的目的地。同時更新指令類型、點編輯類型與點陣列，可確保段落與新幾何形狀保持一致。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx` 中的路徑仍有三個指令，只是其中的中間指令現在改為曲線。

## **檢視與編輯已儲存的路徑**

每個 [MotionCmdPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncmdpath/) 會公開 [points](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncmdpath/points/)、[command_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncmdpath/command_type/)、[points_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncmdpath/points_type/)、[is_relative](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioncmdpath/is_relative/)。以下範例使用 `motion.pptx` 中已知的三指令路徑。對於任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數。

### **讀取指令與座標**

在不修改路徑的情況下讀取。結束與 close‑loop 指令不需要點，因此需允許 `None` 點陣列。

輸出會在列出點之前，先將每個指令與其相對座標旗標配對，讓您在修改路徑前能分辨端點與偏移。曲線會列出三個點，而此檔案中的直線僅列出一個點。

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

列舉內容包含起點、一條絕對線段結束於 (0.25, 0)，以及結束指令。

### **變更端點**

開啟 `motion.pptx`，取代線段的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為線段。取代線段的單一點會改變其目的地，同時不會改變指令類型、時間或在集合中的位置。因為指令使用絕對座標，所以新座標表示一個位置，而非加入的偏移。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx` 中的線段結束於 (0.4, 0.1)；原始檔案保持不變。

### **取代段落**

使用 [insert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpath/insert/) 與 [remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motionpath/remove_at/) 取代 `motion.pptx` 中的線段。插入會將舊的線段移至索引 2。

此示範了取代指令物件而非編輯其現有座標。插入後，集合暫時包含起始指令、新線段、舊線段以及結束指令。移除索引 2 後，舊線段被捨棄，新的路徑保留下來。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

儲存的路徑仍有三個指令，新線段結束於 (0.2, 0.1)，最後的指令仍為結束。

## **修改與驗證既有行為**

當行為索引未知時，可依類型選取。本範例開啟 `rotation.pptx`，找到其 [RotationEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect/)，變更角度，然後重新開啟檔案以檢查儲存值。

類型檢查使迴圈能跳過非旋轉的行為。第二次載入會將儲存的檔案讀入另一個簡報物件，因而比較的是已持久化的資料，而非仍在記憶體中的值。此範例仍假設已知的效果位於主序列的第一個位置；以類型選取行為無法保證在任意簡報中定位正確的效果。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

輸出為 `Rotation preserved: True`。對其他行為使用相同的類型檢查模式。若要進行完整的保存檢查，請比較目標形狀、效果、行為類型與順序、時間以及路徑指令。對浮點數使用數值容差。若簡報的動畫佈局未知，請參閱 [Read Shape Animations](/slides/zh-hant/python-net/shape-animation/#read-shape-animations) 以遍歷主序列與互動序列。

## **行為順序、預設與播放**

[BehaviorCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behaviorcollection/) 中的順序是效果操作的儲存順序。它不是播放清單，行為不會自動等候前一個完成。時間與封閉的效果決定排程。行為可以重疊，且同一屬性的操作可能透過 [additive](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/additive/) 與 [accumulate](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/accumulate/) 互動。僅靠重新排序集合並不能安排「先移動再旋轉」；請使用明確的時間設定或如 [Shape Animation](/slides/zh-hant/python-net/shape-animation/) 中所述的分離效果。

效果的 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/type/) 與 [subtype](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effect/subtype/) 描述其預設。它們無法完整描述已編輯的行為樹。請在自訂行為前先選擇預設與子類別：變更預設可能會重建集合，並捨棄您的自訂操作。例如，將自訂的 Spin 效果改為 Fade，會用 set 與 filter 行為取代旋轉行為。變更預設或子類別後請再次檢查集合。清除預設行為亦可能移除預設所需的可見性或初始化操作。範例故意使用可見的形狀並取代行為，未重新建構每個預設的實作。

## **格式相容性**

即使行為樹得以保留，也不保證在每個檢視器或匯出渲染器上的播放完全相同。請分別檢查儲存的資料與渲染結果。

| Format or output | What to verify |
| --- | --- |
| PPTX | 使用此格式作為本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放效果。 |
| PPT | 舊式二進位表示可能與 PPTX 不同。請執行另一次儲存‑重新開啟與播放測試；不要僅憑 PPTX 成功就推斷所有自訂組合均受支援。 |
| PDF、PNG、JPEG 等靜態投影片影像 | 只包含靜態投影片表示，無法播放行為時間線或保證最終動畫框格。 |
| [HTML5](/slides/zh-hant/python-net/export-to-html5/) | 在匯出選項啟用形狀動畫時，可播放受支援的動畫。請在瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/) | 儲存渲染的影格，而非可編輯的行為或點擊觸發的互動。請檢查實際渲染的移動。 |
| [Video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) | 將動畫影格渲染並編碼為影片。支援程度受渲染器的 [supported animations and effects](/slides/zh-hant/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) 限制；指令與互動事件不會變成可編輯的時間線。 |

## **常見問題**

**為什麼我的效果在未加入任何行為前就已包含行為？**

建立預先定義的效果時，可能會同時建立其底層操作。請先檢查它們，再決定是延伸預設還是取代其行為。

**將行為移至開頭會讓它先播放嗎？**

不一定。集合順序並非時間的替代品。請檢查延遲、持續時間，以及同一屬性上多個操作之間的互動。

**為什麼結束指令沒有點？**

結束指令標示路徑的終點，無需座標。讀取檔案中的路徑時，請留意 `None` 點陣列的情況。

**僅完成往返測試就足以確認播放嗎？**

不是。重新開啟只確認您檢查的屬性是否被保留。仍需在投影片放映播放器或動畫匯出中分別測試，以確認實際視覺行為。