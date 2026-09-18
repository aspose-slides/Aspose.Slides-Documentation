---
title: 在 .NET 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/net/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 運動路徑
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為與可編輯的運動路徑。"
---
## **概觀**

自訂動畫行為讓您能掌控動畫效果中的單一操作，例如變更顏色、旋轉形狀或沿可編輯的運動路徑移動。本指南說明如何建立與組合行為、設定其時序、檢查與修改現有動畫，以及驗證其屬性在儲存與重新開啟簡報後仍能保留。

有關預先定義的效果與點擊觸發，請參閱[形狀動畫](/slides/zh-hant/net/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- 投影片的[Timeline](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/timeline/)包含主要序列與互動序列。
- [ISequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/)包含效果，可能針對不同的形狀。
- [IEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/)識別目標形狀、預設、子類型與效果時序。
- [IEffect.Behaviors](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/behaviors/)包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立單一行為**

呼叫[ISequence.AddEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence/addeffect/)以建立效果並存取其[Behaviors](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/behaviors/)集合。預設可以自動填充此集合。延伸預設時保留其操作，或在刻意取代時使用[Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/clear/)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/)建立下列八種行為類型。運動相關請參考[建立運動路徑](#build-a-motion-path)。每個建立範例皆為完整程式；後續編輯範例會說明使用哪個輸出檔案。

### **旋轉**

使用[CreateRotationEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)建立旋轉。[By](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/irotationeffect/by/)指定相對角度（度）；[From](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/irotationeffect/from/)與[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/irotationeffect/to/)指定端點。

範例以 Spin 效果開始，將其預設操作取代為單一旋轉行為，且將此操作的持續時間設定為兩秒。90 度的相對角度表示形狀起始方向的四分之一旋轉，故不需要明確的起始角度。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` 含有一個形狀與一個旋轉行為。下列的集合、時序與旋轉編輯範例皆使用此檔案。

### **縮放**

使用[CreateScaleEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)並以 X/Y 百分比表示：[From](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/iscaleeffect/from/)與[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/iscaleeffect/to/)描述起始與結束大小，而[By](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/iscaleeffect/by/)描述相對變化。此處 100 代表原始大小。

範例在兩秒內將兩個維度從 100% 成長至 125%。使用相同的水平與垂直百分比可保持形狀的比例；若使用不同的百分比則會使其中一個維度被拉伸。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **顏色**

使用[CreateColorEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)將填色由藍色變為橙色。[From](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icoloreffect/from/)與[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icoloreffect/to/)是顏色；[By](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icoloreffect/by/)是顏色偏移。[IBehavior.Properties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehavior/properties/)指出被動畫化的屬性。

形狀的實心填色先設為藍色，與動畫的起始顏色相符。選取 fill‑color 屬性告訴行為要變更形狀的哪一部份；僅有顏色端點無法識別該屬性。已儲存的效果描述兩秒的過渡至橙色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **濾鏡**

使用[CreateFilterEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)選擇擦除效果。[Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ifiltereffect/type/)、[Subtype](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ifiltereffect/subtype/)與[Reveal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ifiltereffect/reveal/)分別指定濾鏡、方向以及是顯示或隱藏形狀。

此範例設定兩秒的擦除，以向右方向的子類別顯示形狀。濾鏡設定屬於效果內的行為，因此在移除預設原始操作後再進行設定。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **屬性**

使用[CreatePropertyEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)為不透明度設定動畫。[From](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ipropertyeffect/from/)、[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ipropertyeffect/to/)與[By](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ipropertyeffect/by/)是字串，會根據[ValueType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ipropertyeffect/valuetype/)與[CalcMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ipropertyeffect/calcmode/)進行解譯。請依需求選擇端點或相對偏移，而非同時設定三者。

此處選取的屬性是不透明度，數字字串表示從 25% 不透明度變為完全不透明。線性插值描述在這兩個值之間的逐漸變化。若要將此範例套用至其他屬性，請選擇適合該屬性的值類型與端點值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **設定**

使用[CreateSetEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createseteffect/)透過[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/iseteffect/to/) 指定可見性。設定行為不會在端點之間進行插值。

範例選取可見性屬性，並在行為執行時將字串 `visible` 指派給它。此矩形在此最小簡報中已經可見，因此單純指派可能不會產生明顯的視覺變化。此類操作在同時控制形狀何時隱藏或顯示的較大型效果中非常有用。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **指令**

使用[CreateCommandEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)並設定[Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icommandeffect/type/)、[CommandString](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icommandeffect/commandstring/)與[ShapeTarget](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/icommandeffect/shapetarget/)。將名為 `sample.wav` 的 WAV 錄音放入工作目錄。此範例使用[AddAudioFrameEmbedded](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addaudioframeembedded/)將其嵌入，並將播放指令附加至音訊框架。

音訊框架同時是效果的目標與指令的目標。這樣即可將播放請求連結至嵌入的錄音；僅有指令字串本身無法指示要控制哪個媒體物件。此效果被設定為在投影片放映期間點擊時啟動。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

儲存會將指令寫入 `command.pptx`；不會自動播放錄音。播放必須使用支援此指令與其媒體目標的投影片放映程式。

## **管理行為集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/)支援[Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/add/)、[Insert](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/insert/)、[Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/removeat/)。此範例開啟 `rotation.pptx`，加入縮放，將其插入至旋轉之前，並移除旋轉。移除後再重新插入相同物件會改變其儲存位置而不會產生副本。

編輯順序將集合從 rotation–scale 變為 scale–rotation，最後只剩 scale。索引根據目前的集合計算，因此在重新排序後，移除使用的是旋轉的新索引。最終列舉確認哪個行為會被儲存。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

輸出為 `ScaleEffect`：僅剩縮放。僅靠集合順序不會排程行為依序執行。只有在全部取代時才使用 Clear。

## **設定行為時序**

[IBehavior.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehavior/timing/)公開[ITiming](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/)，獨立於[IEffect.Timing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/timing/)。效果時序排程封閉的效果；行為時序描述其內部的單一操作。

### **設定持續時間、延遲、重複與加速**

開啟 `rotation.pptx`，以秒為單位設定[Duration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/duration/)與[TriggerDelayTime](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/triggerdelaytime/)，接著設定[RepeatCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatcount/)。[Accelerate](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/accelerate/)與[Decelerate](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/decelerate/)是持續時間的比例，總和請勿超過 1。

輸入檔案即為旋轉範例所建立的檔案，第一個行為已知是旋轉。此範例僅變更該行為的時序；其 90 度角度保持不變。將角度與時序分離，可在不重建動畫的情況下調整速度。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

此行為使用兩秒持續時間、半秒延遲，並重複 3 次。前後各 20% 的持續時間用於加速與減速。

其他重複政策包括[RepeatDuration](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatduration/)、[RepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilendslide/)、[RepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/repeatuntilnextclick/)。請選擇單一政策，而非同時啟用多個。[AutoReverse](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/itiming/autoreverse/)會在正向播放後倒轉播放。加速與減速只適用於連續變化，不適用於離散的指派或指令。

## **建立運動路徑**

使用[CreateMotionEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)建立運動。[From](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/from/)、[To](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/to/)與[By](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/by/)描述以百分比為基礎的座標或偏移。若需可編輯路徑，請建立[MotionPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motionpath/)並指派給[IMotionEffect.Path](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/path/)。[IMotionPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotionpath/)儲存路徑指令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motioncommandpathtype/)用於選擇操作：

| 指令 | 點數 | 意義 |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至端點。 |
| CurveTo | Three | 依兩個控制點與端點的三次曲線前進。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 結束路徑。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motionpathpointstype/)描述點的編輯特性，例如拐角點或平滑點。它不會取代指令類型。曲線範例使用曲線點類型，直線段則使用拐角點類型。

路徑座標正規化為投影片尺寸：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。絕對指令以路徑座標系統指定位置；相對指令則以目前位置的偏移表示。這與[Origin](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/origin/)（路徑參考框）以及[PathEditMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioneffect/patheditmode/)（形狀移動時路徑如何變動）是分開的概念。

### **建立直線路徑**

建立包含起始點、一段直線以及結束指令的運動行為。[IMotionPath.Add](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotionpath/add/)接受指令類型、點陣列、點類型與相對座標旗標。

起始指令設定 (0, 0)，線段結束於 (0.25, 0)，使路徑在水平方向上位移投影片寬度的四分之一。結束指令不帶座標點。路徑指派完成後，將運動行為加入效果即可將此路徑套用到矩形。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` 含有一個運動行為與三個路徑指令。以下的檔案編輯範例皆以此已知結構為基礎。

### **比較絕對與相對座標**

以下兩個路徑物件描述相同的路徑。絕對指令以 (0.3, 0.1) 結束；相對指令則將 (0.1, 0.1) 加到目前位置 (0.2, 0) 上。

兩條路徑皆從相同位置開始。對於相對線段，將其 X、Y 偏移加到目前位置即可得到端點；對於絕對線段，直接讀取端點。若不轉換座標而僅切換旗標，將會描述不同的路徑。

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

將任一路徑指派給運動行為，即可在簡報中使用。最後的布林參數選擇此指令使用相對座標。

### **以曲線取代直線**

開啟 `motion.pptx`，將其線段指令換成三次曲線。先提供兩個控制點，最後提供端點。

起始位置由前一個指令提供。前兩個點塑形曲線，第三個點為曲線的終點；它們不是三個連續的目的地。同時更新指令類型、點編輯類型與點陣列，可保持段落與新幾何形狀的一致性。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx` 的路徑仍有三個指令，只是中間指令改為曲線。

## **檢查與編輯已儲存的路徑**

每個[IMotionCmdPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioncmdpath/)公開[Points](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioncmdpath/points/)、[CommandType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioncmdpath/commandtype/)、[PointsType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioncmdpath/pointstype/)、[IsRelative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotioncmdpath/isrelative/)。以下範例使用 `motion.pptx` 中已知的三指令路徑。若處理任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數。

### **讀取指令與座標**

在不變更路徑的情況下讀取。結束與關閉迴路指令不需要點，因此需允許空的點陣列。

輸出會在列出點之前先顯示每個指令的相對座標旗標，讓您在修改路徑前辨別端點與偏移。曲線會列出三個點，而此檔案中的直線僅列出一個點。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

列出內容包含起始點、以絕對座標於 (0.25, 0) 結束的直線，以及結束指令。

### **變更端點**

開啟 `motion.pptx`，取代線段的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為線段。取代線段的單一點會改變其目的地，但不會改變指令類型、時序或在集合中的位置。因為指令使用絕對座標，新點指定的是位置而非偏移。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx` 中的線段結束於 (0.4, 0.1)；原始檔案未受影響。

### **取代段落**

使用[Insert](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotionpath/insert/)與[RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/imotionpath/removeat/)取代 `motion.pptx` 中的線段。插入會將舊的線段移至索引 2。

此示範取代指令物件，而非編輯其現有座標。插入後，集合暫時包含起始指令、新線段、舊線段與結束指令。移除索引 2 後，舊線段被捨棄，新的路徑保留下來。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

儲存的路徑仍有三個指令，新的線段結束於 (0.2, 0.1)，結束指令仍在最後。

## **修改與驗證既有行為**

當行為索引未知時，可依類型選取。本範例開啟 `rotation.pptx`，找到其[IRotationEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/irotationeffect/)，變更角度，並在重新開啟後檢查已儲存的值。

類型檢查讓迴圈跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，因而比較的是持久化資料，而非仍在記憶體中的值。本範例仍假設已知的效果位於主序列的第一個；依類型選取行為並不能在任意簡報中定位正確的效果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

輸出為 `Rotation preserved: True`。將相同的類型檢查模式套用至其他行為。若要完整驗證保存情況，請比較目標形狀、效果、行為類型與順序、時序以及路徑指令。對於浮點數值請使用數值容差。若簡報的動畫版面未知，請參閱[閱讀形狀動畫](/slides/zh-hant/net/shape-animation/#read-shape-animations)以遍歷主序列與互動序列。

## **行為順序、預設與播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehaviorcollection/)中的順序是效果操作的儲存順序。它不是播放清單，行為不會自動等候前一個行為完成。時序與封閉的效果決定排程。行為可以重疊，同一屬性的操作可能透過[Additive](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehavior/additive/)與[Accumulate](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ibehavior/accumulate/)產生交互。不要僅透過重新排序集合來排程「先移動再旋轉」；請使用明確的時序或如[形狀動畫](/slides/zh-hant/net/shape-animation/)所述的分離效果。

效果的[Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/type/)與[Subtype](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/ieffect/subtype/)描述其預設。它們並非已編輯行為樹的完整描述。請先選擇預設與子類型，再自訂行為：更改預設可能會重建集合並捨棄自訂操作。例如，將自訂的 Spin 效果改為 Fade 會以設定與濾鏡行為取代旋轉行為。變更預設或子類型後請再次檢查集合。清除預設行為也可能會移除預設所需的可見性或初始化操作。這些範例刻意使用可見形狀並取代其行為，並未重新建構每個預設的實作。

## **格式相容性**

已保存的行為樹無法保證在所有檢視器或匯出渲染器中呈現相同的播放效果。請分別檢查保存的資料與渲染輸出。

| 格式或輸出 | 需要驗證的項目 |
| --- | --- |
| PPTX | 本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放。 |
| PPT | 老舊二進位格式可能與 PPTX 不同。請執行另一次保存–重新開啟循環與播放測試；不要僅因 PPTX 成功而推斷支援所有自訂組合。 |
| PDF、PNG、JPEG 及其他靜態投影片影像 | 只包含靜態投影片表示，未包含可播放的行為時間軸或保證的最終動畫畫面。 |
| [HTML5](/slides/zh-hant/net/export-to-html5/) | 在匯出選項啟用形狀動畫時可播放受支援的動畫。請在瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/) | 儲存渲染的幀，未包含可編輯的行為或點擊觸發的互動。請檢查實際渲染的運動。 |
| [Video](/slides/zh-hant/net/convert-powerpoint-to-video/) | 將動畫幀渲染並編碼為影片。支援僅限於渲染器的[支援動畫與效果](/slides/zh-hant/net/convert-powerpoint-to-video/#supported-animations-and-effects)；指令與互動事件不會成為可編輯的時間軸。 |

## **常見問題**

**為什麼我的效果在未加入任何行為前就已包含行為？**

建立預先定義的效果時可能會自動建立其底層操作。請先檢查它們，再決定是要延伸預設還是取代其行為。

**將行為移到集合開頭會使它先播放嗎？**

不一定。集合順序不能取代時序。請檢查延遲、持續時間以及同一屬性上操作之間的交互。

**為什麼結束指令沒有點？**

結束指令標示路徑的終點，不需要座標。從檔案讀取路徑時，請留意可能為 null 的點陣列。

**成功的來回測試足以確認播放嗎？**

不能。重新開啟只能確認您檢查的屬性是否被保留。仍需在投影片放映程式或動態匯出中分別測試其視覺行為。