---
title: 在 Python（透過 Java）中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/python-java/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 運動路徑
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中建立、檢視與修改自訂動畫行為和可編輯的運動路徑。"
---
## **概述**

自訂動畫行為讓您能控制動畫效果中的個別操作，如變更顏色、旋轉形狀或遵循可編輯的運動路徑。本指南說明如何建立與組合行為、設定它們的時間、檢查與修改既有動畫，並驗證其屬性在儲存與重新開啟簡報後仍能保留。

如需預先定義的效果與點擊觸發，請參閱 [形狀動畫](/slides/zh-hant/python-java/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- [getTimeline] 方法返回幻燈片時間線，該時間線包含其主序列和互動序列。
- [Sequence] 包含效果，可能針對不同的形狀。
- [Effect] 用於辨識目標形狀、預設、子類型以及效果時間。
- 由 [Effect.getBehaviors] 回傳的集合包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立個別行為**

呼叫 [Sequence.addEffect] 以建立效果，並存取 [Effect.getBehaviors] 集合。預設可以自動填入此集合。延伸預設時保留其操作，或在有意取代時使用 [clear]。

[BehaviorFactory] 建立下面示範的八種行為類型。運動相關請參閱 [建立運動路徑](#build-a-motion-path)。每個程式碼片段皆包含其匯入，且在必要時會啟動 JVM。Java 物件與陣列透過 JPype 建立。後續編輯範例會說明使用的輸出檔案。

### **旋轉**

使用 [createRotationEffect] 建立旋轉。[getBy] 指定相對角度（度數）；[getFrom] 與 [getTo] 指定起點與終點。

此範例以 Spin 效果為起點，將其預設操作取代為單一旋轉行為，並將該操作的持續時間設為兩秒。90 度的相對角度代表形狀起始方向的四分之一旋轉，無需明確設定起始角度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` 包含一個形狀與一個旋轉行為。下列的集合、時間與旋轉編輯範例均使用此檔案。

### **縮放**

使用 [createScaleEffect] 搭配 X/Y 百分比：[getFrom] 與 [getTo] 說明起始與結束大小，而 [getBy] 說明相對變化。此處 100 代表原始大小。

範例將兩個維度從 100% 成長至 125%，持續兩秒。使用相同的水平與垂直百分比可保持形狀比例，不同的百分比則會拉伸某一維度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **顏色**

使用 [createColorEffect] 將填色從藍色變為橙色。[getFrom] 與 [getTo] 為顏色；[getBy] 為顏色偏移。[Behavior.getProperties] 用於辨識被動畫化的屬性。

形狀的實心填色在初始化時設定為藍色，與動畫的起始顏色相符。選取填色屬性告訴行為要變更形狀的哪個部位；僅有顏色端點無法指明屬性。儲存的效果描述為兩秒過渡至橙色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **過濾**

使用 [createFilterEffect] 以選取抹除方式。[getType]、[getSubtype] 與 [getReveal] 分別指定過濾器、方向以及是顯示還是隱藏形狀。

此範例設定兩秒的抹除，使用向右方向的子類型來顯示形狀。過濾設定屬於效果內的行為，因此在移除預設的原始操作後再進行設定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **屬性**

使用 [createPropertyEffect] 為不透明度建立動畫。[getFrom]、[getTo]、[getBy] 為字串，會透過 [getValueType] 與 [getCalcMode] 進行解析。建議只設定端點或相對偏移，而非同時設定三者。

此處選取的屬性為不透明度，字串數值代表從 25% 不透明度變為完全不透明。線性插值描述了兩個值之間的逐漸變化。若改用其他屬性，請為該屬性選擇適當的值類型與端點值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **設定**

使用 [createSetEffect] 透過 [getTo] 指派可見性。設定行為不會在端點之間插值。

範例選取可見性屬性，並在行為執行時將字串 `visible` 指派給它。此最小簡報中矩形已經可見，所以僅此指派不會產生明顯的視覺變化。此類操作通常是更大效果的一部份，用於同時控制形狀何時隱藏或顯示。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **指令**

使用 [createCommandEffect] 並設定 [getType]、[getCommandString] 與 [getShapeTarget]。將名為 `sample.wav` 的 WAV 錄音檔放置於工作目錄。此範例使用 [addAudioFrameEmbedded] 將其嵌入，並將播放指令附加到音訊框架。

音訊框架同時是效果的目標與指令的目標。這樣即可將播放請求與嵌入的錄音檔連結；僅有指令字串本身不足以辨識要控制的媒體物件。效果設定為在投影片放映期間點擊時啟動。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

儲存後會在 `command.pptx` 中留下指令；不會自動播放錄音。播放需使用支援此指令與媒體目標的投影片播放器。

## **管理行為集合**

[BehaviorCollection] 支援 [add]、[insert]、[remove] 與 [removeAt]。此範例開啟 `rotation.pptx`，新增縮放，將其插入到旋轉之前，最後移除旋轉。移除後再重新插入同一物件會改變其在集合中的位置，而不會產生副本。

編輯順序會使集合從「旋轉→縮放」變為「縮放→旋轉」，最後只剩縮放。索引指向當前集合，因此移除時使用的是旋轉在重新排序後的新索引。最終列舉會確認哪個行為會被儲存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

輸出為 `ScaleEffect`：僅剩縮放。集合順序本身不會使行為依序排程。只有在全部取代時才需要清除集合。

## **設定行為時間**

[Behavior.getTiming] 會公開 [Timing]，與 [Effect.getTiming] 獨立。Effect 時間排程整個效果；行為時間則描述其內部的操作。

### **設定持續時間、延遲、重複次數與加速**

開啟 `rotation.pptx`，以秒為單位設定持續時間 ([getDuration]) 與觸發延遲 ([getTriggerDelayTime])，然後透過 [setRepeatCount] 設定重複次數。[getAccelerate] 與 [getDecelerate] 為持續時間的比例，請保持兩者總和最多為 1。

輸入檔案是旋轉範例所產生的檔案，第一個行為已知是旋轉。此範例僅變更該行為的時間；其 90 度角度保持不變。將角度與時間分開設定，可在不重新建立動畫的情況下調整節奏。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此行為使用兩秒持續時間、半秒延遲，且重複次數為 3。前後各 20% 的時間用於加速與減速。

其他重複策略包括 [getRepeatDuration]、[getRepeatUntilEndSlide]、[getRepeatUntilNextClick]；請選擇其中一種，而非同時啟用。[getAutoReverse] 會在正向播放後反向播放。加速與減速僅適用於連續變化，不適用於離散的賦值或指令。

## **建立運動路徑**

使用 [createMotionEffect] 建立運動。其 [getFrom]、[getTo]、[getBy] 描述以百分比為基礎的座標或偏移。若要建立可編輯的路徑，請建立 [MotionPath] 並透過 [MotionEffect.setPath] 指派。[MotionPath] 會儲存路徑指令。

[MotionCommandPathType] 用於選擇指令：

| 指令 | 點數 | 說明 |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至端點。 |
| CurveTo | Three | 依兩個控制點與端點形成三次曲線。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 結束路徑。 |

[MotionPathPointsType] 描述點的編輯特性，例如拐角或平滑點。它不會取代指令類型。曲線範例使用曲線點類型，直線段則使用拐角點類型。

路徑座標以投影片尺寸正規化：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。絕對指令在路徑座標系統中指定位置；相對指令則以當前位置為偏移。這與 [getOrigin]（選擇路徑參考框架）以及 [getPathEditMode]（控制形狀移動時路徑的行為）是分開的概念。

### **建立直線路徑**

建立一個運動行為，包含起始點、一段直線以及結束指令。[MotionPath.add] 需要指令類型、點陣列、點類型以及相對座標旗標。

起始指令設定 (0, 0)，直線結束於 (0.25, 0)，因此路徑水平位移為投影片寬度的四分之一。結束指令不帶座標點。指派路徑後，將運動行為加入效果即可將該路徑連結到矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` 包含一個運動行為與三個路徑指令。以下的檔案編輯範例皆使用此已知結構。

### **比較絕對與相對座標**

這兩個路徑物件描述相同的路徑。絕對指令的終點為 (0.3, 0.1)；相對指令則在當前位置 (0.2, 0) 上加上 (0.1, 0.1)。

兩條路徑的起點相同。對於相對線，需將其 X 與 Y 偏移加到當前位置才能得到端點；對於絕對線，直接讀取端點即可。未轉換座標而僅切換旗標會產生不同的路徑。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

將任一路徑指派給運動行為即可在簡報中使用。最後的布林參數用於選擇該指令是否使用相對座標。

### **以曲線取代直線**

開啟 `motion.pptx`，將其直線指令替換為三次曲線。先提供兩個控制點，最後提供端點。

起始位置由前一個指令提供。前兩個點塑造曲線，第三個點為曲線的終點；它們並非三個連續的目的地。同時更新指令類型、點編輯類型與點陣列，可確保段落與新幾何保持一致。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` 的路徑仍有三個指令，只是其中的中間指令改為曲線。

## **檢查與編輯已儲存的路徑**

每個 [MotionCmdPath] 皆提供 [getPoints]、[getCommandType]、[getPointsType] 與 [isRelative]。以下範例使用 `motion.pptx` 中已知的三指令路徑。對於任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數。

### **讀取指令與座標**

在不變更路徑的情況下讀取。結束與關閉迴路指令不需點，因此要允許空的點陣列。

輸出會先列出每個數值指令類型與其相對座標旗標，接著列出點。這讓您在修改路徑前就能區分端點與偏移。曲線會列出三個點，而本檔案中的直線僅有一個點。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

此清單包含起始點、絕對線段 (結束於 (0.25, 0))，以及結束指令。

### **變更端點**

開啟 `motion.pptx`，取代直線的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為直線。取代直線的唯一點會改變其目的地，而不會改變指令類型、時間或在集合中的位置。因為指令使用絕對座標，新的座標對直接指定位置，而非添加偏移。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` 中的直線結束於 (0.4, 0.1)；原始檔案保持不變。

### **取代段落**

使用 [insert] 與 [removeAt] 於 `motion.pptx` 中取代直線。插入會將舊的直線移至索引 2。

此示範的是取代整個指令物件，而非編輯其座標。插入後，集合暫時包含起始指令、新的直線、舊的直線，以及結束指令。移除索引 2 後，舊的直線被刪除，新的路徑保留。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

儲存後的路徑仍有三個指令，新的直線結束於 (0.2, 0.1)，結束指令仍在最後。

## **修改與驗證既有行為**

當行為索引未知時，可依類型選取。本範例開啟 `rotation.pptx`，找到其 [RotationEffect]，變更角度，並在重新開啟後檢查儲存值。

類型檢查允許迴圈跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，以確保比較的是永久保存的資料，而非仍在記憶體中的值。此範例仍假設已知的效果位於主序列的第一個位置；依類型選取行為並不保證能在任意簡報中定位正確的效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

輸出為 `Rotation preserved: True`。對其他行為套用相同的類型檢查模式。完整的保存檢查應比較目標形狀、效果、行為類型與順序、時間與路徑指令。對浮點值使用數值容差。若簡報的動畫布局未知，請參閱 [閱讀形狀動畫](/slides/zh-hant/python-java/shape-animation/#read-shape-animations) 以遍歷主序列與互動序列。

## **行為順序、預設與播放**

[BehaviorCollection] 中的順序是效果操作的儲存順序。它不是播放清單，並不會自動使每個行為等待前一個。時間與封閉的效果才決定排程。行為可以重疊，且同屬性上的操作可能透過 [getAdditive] 與 [getAccumulate] 互動。不要僅靠重新排序集合來實現「先移動，再旋轉」；請使用明確的時間設定或將它們分成不同的效果，如同 [形狀動畫] 中所說。

效果的 [getType] 與 [getSubtype] 描述其預設，並非已編輯行為樹的完整說明。先選擇預設與子類型，再自訂行為：變更預設會重建集合，可能會捨棄您自訂的操作。例如，將自訂的 Spin 效果改為 Fade 會用設定與過濾行為取代旋轉行為。變更預設或子類型後，請再次檢查集合。清除預設行為也可能移除預設所需的可見性或初始化操作。範例故意使用可見形狀並取代行為，而不重新建構每個預設的實作。

## **格式相容性**

保留的行為樹並不保證在每個檢視器或匯出渲染器中都有相同的播放效果。請分別檢查儲存的資料與呈現的輸出。

| 格式或輸出 | 需要驗證的項目 |
| --- | --- |
| PPTX | 作為本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放情形。 |
| PPT | 舊版二進位表示可能與 PPTX 不同。請執行另一次儲存‑重新開啟循環並測試播放；不要僅憑 PPTX 成功即推斷所有自訂組合皆受支援。 |
| PDF、PNG、JPEG 及其他靜態投影片影像 | 只包含靜態投影片表示，未包含可播放的時間軸或保證的最終動畫畫面。 |
| [HTML5](/slides/zh-hant/python-java/export-to-html5/) | 在匯出選項啟用形狀動畫時，可播放支援的動畫。請在瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/) | 儲存的是渲染的影格，未包含可編輯的行為或點擊觸發的互動。請檢查實際渲染的運動。 |
| [Video](/slides/zh-hant/python-java/convert-powerpoint-to-video/) | 會將動畫影格渲染並編碼成影片。支援度受渲染器的 [支援動畫與效果](/slides/zh-hant/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) 限制；指令與互動事件不會變成可編輯的時間軸。 |

## **常見問題**

**為什麼在我還沒加入任何行為之前，效果已經包含行為了？**

建立預先定義的效果時，可能會同時建立其底層操作。請先檢查它們，再決定是延伸預設還是取代其行為。

**把行為移到開頭就會先播放嗎？**

未必。集合順序不能取代時間設定。請檢查延遲、持續時間以及同屬性操作之間的互動。

**為什麼結束指令沒有點？**

結束指令標示路徑的終點，不需要座標。閱讀自檔案載入的路徑時，請留意可能為 null 的點陣列。

**一次完整的往返測試就足以確認播放嗎？**

不足。重新開啟只確認您檢查的屬性是否被保存。仍需在投影片播放程式或動畫匯出工具中分別測試，以確認實際視覺行為。