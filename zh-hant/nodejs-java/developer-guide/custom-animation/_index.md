---
title: 在 JavaScript 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/nodejs-java/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 簡報中建立、檢查並修改自訂動畫行為與可編輯的移動路徑。"
---
## **概觀**

自訂動畫行為讓您能控制動畫效果內的個別操作，例如變更顏色、旋轉形狀或遵循可編輯的移動路徑。本指南說明如何建立與組合行為、設定其時間、檢查與修改現有動畫，並驗證其屬性在儲存與重新開啟簡報後仍能保留。

對於預定義效果與點擊觸發，請參考[形狀動畫](/slides/zh-hant/nodejs-java/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **Timeline → Sequence → Effect → Behaviors**：

- [getTimeline](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getTimeline) 方法會傳回投影片的時間軸，該時間軸包含主要序列與互動序列。
- [Sequence](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/) 包含效果，可能針對不同的形狀。
- [Effect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/) 識別目標形狀、預設、子類型與效果時間。
- 由[Effect.getBehaviors](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effect/#getBehaviors)返回的集合包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立單一行為**

呼叫[Sequence.addEffect]以建立效果並存取[getBehaviors]集合。預設可以自動填入此集合。擴充預設時保留其操作，或在有意取代時使用[clear]。

[BehaviorFactory]建立下列說明的八種行為類型。移動路徑請參考[建立移動路徑](#build-a-motion-path)。每個程式碼片段包含其模組匯入，且可在已安裝 `aspose.slides.via.java` 與 `java` 套件的 Node.js 環境中執行。請先執行產生檔案的範例，再執行讀取其輸出的範例。稍後的編輯範例會說明使用哪個輸出檔案。

### **旋轉**

使用[createRotationEffect]建立旋轉。[getBy]指定相對角度（度），[getFrom]與[getTo]指定端點。

此範例以 Spin 效果開始，將其預設操作取代為一個旋轉行為，並將該操作設為兩秒持續時間。90 度的相對角度表示形狀起始方向的四分之一旋轉，因而不需要明確的起始角度。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` 包含一個形狀與一個旋轉行為。以下的集合、時間與旋轉編輯範例皆使用此檔案。

### **縮放**

使用[createScaleEffect]搭配 X/Y 百分比： [getFrom] 與 [getTo] 描述起始與結束大小，而 [getBy] 描述相對變化。此處的 100 代表原始大小。

此範例在兩秒內將兩個維度由 100% 成長至 125%。使用相同的水平與垂直百分比可維持形狀比例；若使用不同百分比則會使某一維度較另一維度拉伸。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **顏色**

使用[createColorEffect]將填色從藍色變為橙色。[getFrom] 與 [getTo] 為顏色；[getBy] 為顏色偏移。[Behavior.getProperties] 識別被動畫化的屬性。

形狀的實心填色預設為藍色，與動畫起始顏色相符。選取填色屬性告訴行為要變更形狀的哪一部份；僅有顏色端點並不會識別該屬性。已儲存的效果描述了兩秒的過渡至橙色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **濾鏡**

使用[createFilterEffect]選取抹除。[getType]、[getSubtype]與[getReveal]指示濾鏡、方向以及是顯示或隱藏形狀。

此範例設定一個兩秒的抹除，以右方向子類別顯示形狀。濾鏡設定屬於效果內的行為，因此在移除預設的原始操作後再進行設定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **屬性**

使用[createPropertyEffect]讓不透明度產生動畫。[getFrom]、[getTo]與[getBy]為字串，會透過[getValueType]與[getCalcMode]解析。請選擇端點或相對偏移，而不是隨意同時設定三者。

此處選取的屬性是 opacity（不透明度），數值字串表示從 25% 不透明度變為完整不透明度。線性插值描述了這些值之間的漸變。若將此範例套用至其他屬性，請選擇該屬性相應的值類型與端點值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **設定**

使用[createSetEffect]透過[getTo]指定可見性。設定行為不會在端點之間插值。

此範例選取可見性屬性，並在行為執行時指派字串 `visible`。在此簡易簡報中，矩形已經是可見的，因此單獨指派可能不會產生明顯的視覺變化。此類操作在結合其他控制形狀隱藏或顯示的較大效果時相當有用。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **指令**

使用[createCommandEffect]並設定[getType]、[getCommandString]與[getShapeTarget]。請將名為 `sample.wav` 的 WAV 錄音放置於工作目錄。本範例使用[addAudioFrameEmbedded]將其嵌入，並將播放指令附加至音訊框。

音訊框同時是效果的目標與指令的目標。這樣會將播放請求連結至嵌入的錄音檔；僅有指令字串無法識別要控制的媒體物件。此效果被設定為在簡報播放時點擊後開始。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

儲存會把指令存入 `command.pptx`；不會自動播放錄音。播放需要支援此指令與其媒體目標的簡報播放器。

## **管理行為集合**

[BehaviorCollection] 支援[add]、[insert]、[remove]與[removeAt]。此範例開啟 `rotation.pptx`，加入縮放，將其移至旋轉之前，然後移除旋轉。移除後重新插入相同物件會變更其儲存位置，而不會產生副本。

編輯順序會將集合從 rotation–scale 變為 scale–rotation，最終變為僅 scale。索引指向當前集合，因此移除時使用旋轉在重新排序後的新索引。最後的列舉確認了將被儲存的行為。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

輸出為 `ScaleEffect`：僅保留縮放。僅憑集合順序不會使行為依次排程。僅在全部取代其操作時才清除集合。

## **設定行為時間**

[Behavior.getTiming] 會揭露[Timing]，且獨立於[Effect.getTiming]。效果時間排程外層效果；行為時間則描述其中的操作。

### **設定持續時間、延遲、重複與加速**

開啟 `rotation.pptx`，以秒為單位設定持續時間（[getDuration]）與觸發延遲（[getTriggerDelayTime]），接著透過[setRepeatCount]設定重複次數。[getAccelerate]與[getDecelerate]為持續時間的比例；兩者總和請勿超過 1。

輸入檔為旋轉範例所產生的檔案，第一個行為已知為旋轉。本範例僅變更該行為的時間；其 90 度角度保持不變。將角度與時間分開設定，可更方便地調整節奏而無需重建動畫。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此行為使用兩秒持續時間、半秒延遲，並設定重複次數為 3。持續時間的前 20% 與後 20% 用於加速與減速。

其他重複策略包含[getRepeatDuration]、[getRepeatUntilEndSlide]與[getRepeatUntilNextClick]；請選擇其中一種策略，而非同時啟用全部。[getAutoReverse] 會在正向播放後倒轉動畫。加速與減速適用於連續變化，而非離散的指派或指令。

## **建立移動路徑**

使用[createMotionEffect]建立移動。[getFrom]、[getTo]與[getBy]描述基於百分比的座標或偏移。若要建立可編輯的路徑，請建立[MotionPath]並以[MotionEffect.setPath]指派。[MotionPath]會儲存路徑指令。

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至其端點。 |
| CurveTo | Three | 依由兩個控制點與端點定義的三次曲線移動。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 完成路徑。 |

[MotionPathPointsType] 描述點編輯的特性，例如角點或平滑點。它不會取代指令類型。對於下面的曲線範例使用曲線點類型，對於直線段使用角點類型。

路徑座標以投影片尺寸正規化：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。絕對指令在路徑座標系統中指定位置；相對指令則指定相對於目前位置的偏移。這與[getOrigin]（選取路徑的參考框架）以及[getPathEditMode]（控制形狀移動時路徑的移動方式）是分開的。

### **建立直線路徑**

建立具有起始點、一條直線段與結束指令的移動行為。[MotionPath.add]接受指令類型、其點、點的類型與相對座標旗標。

起始指令設定 (0, 0)，直線在 (0.25, 0) 結束，為路徑提供投影片寬度四分之一的水平位移。結束指令沒有座標點。路徑指派後，將移動行為加入效果即會把此路徑連結至矩形。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 包含一個具有三個路徑指令的移動行為。以下的檔案編輯範例均使用此已知結構。

### **比較絕對座標與相對座標**

這兩個路徑物件描述相同的路徑。絕對指令的終點為 (0.3, 0.1)；相對指令則在目前位置 (0.2, 0) 上加上 (0.1, 0.1)。

兩條路徑皆從相同位置開始。對於相對直線，將其 X、Y 偏移加至目前位置即得終點；對於絕對直線，直接讀取終點。若未轉換座標就切換旗標，會產生不同的路徑。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

將任一路徑指派給移動行為，即可在簡報中使用。最後的布林參數會為該指令選擇相對座標。

### **以曲線取代直線**

開啟 `motion.pptx`，將其直線指令取代為三次曲線。先提供兩個控制點，然後再提供端點。

起始位置由前一指令提供。前兩個點構成曲線形狀，第三個點為目的地；它們不是三個連續的目的地。同步更新指令類型、點編輯類型與點陣列，可確保片段與新幾何保持一致。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 中的路徑仍有三個指令；其中間的指令現在定義為曲線。

## **檢查與編輯已儲存的路徑**

每個[MotionCmdPath]會公開[getPoints]、[getCommandType]、[getPointsType]與[isRelative]。以下範例使用`motion.pptx`中已知的三指令路徑。對於任意輸入，先定位目標效果，並在依索引編輯前檢查指令類型與點數量。

### **讀取指令與座標**

在不變更路徑的情況下讀取。結束與閉合迴路指令不需要點，因此要允許點陣列為 null。

輸出會先將每個數值指令類型與其相對座標旗標配對，然後列出其點。這讓您在修改路徑前能分辨端點與偏移。曲線會列出三個點，而此檔案中的直線僅列出一個點。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

此清單包含起始點、一條結束於 (0.25, 0) 的絕對直線，以及結束指令。

### **變更端點**

開啟 `motion.pptx`，並取代直線的點陣列以移動其端點。

在輸入檔中，索引 0 為起始指令，索引 1 為直線。取代直線的單一點會更改其目的地，而不會改變指令類型、時間或在集合中的位置。因為此指令使用絕對座標，新點對表示位置而非新增偏移。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 中的直線結束於 (0.4, 0.1)；原始檔未變更。

### **取代線段**

使用[insert]與[removeAt]取代 `motion.pptx` 中的直線。插入會將舊的直線移至索引 2。

這示範了取代指令物件而非編輯其現有座標。插入後，集合暫時包含起始指令、新直線、舊直線與結束指令。移除索引 2 後，舊直線被捨棄，新的路徑保留。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的路徑仍有三個指令，新的直線結束於 (0.2, 0.1)，結束指令位於最後。

## **修改與驗證現有行為**

當行為的索引未知時，請依類型選取。本範例開啟 `rotation.pptx`，尋找其[RotationEffect]，變更角度，並在重新開啟後檢查儲存的值。

類型檢查讓迴圈跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，因此比較的是持久化資料而非仍在記憶體中的值。本範例仍假設已知效果位於主要序列的第一個；依類型選取行為無法在任意簡報中定位正確的效果。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

輸出為 `Rotation preserved: true`。對其他行為亦可套用相同的類型檢查模式。要進行完整的保存檢查，請比較目標形狀、效果、行為類型與順序、時間與路徑指令。對浮點數使用數值容差。若簡報的動畫布局未知，請參考[讀取形狀動畫](/slides/zh-hant/nodejs-java/shape-animation/#read-shape-animations)以遍歷主要與互動序列。

## **行為順序、預設與播放**

[BehaviorCollection] 中的順序是效果操作的儲存順序。它不是每個行為自動等待前一個的播放清單。時間與外層效果決定排程。行為可以重疊，同一屬性的操作可能透過[getAdditive]與[getAccumulate]互相影響。不要僅靠重新排序集合來排程「移動，然後旋轉」；請使用明確的時間設定或如[形狀動畫]中所述的分離效果。

效果的[getType]與[getSubtype]描述其預設。它們並非編輯後行為樹的完整說明。請在自訂行為之前先選擇預設與子類型：變更預設可能會重新建立集合，並捨棄您的自訂操作。例如，將已自訂的 Spin 效果變更為 Fade，會以 set 與 filter 行為取代其旋轉行為。變更預設或子類型後請再次檢查集合。清除預設行為也可能移除預設所需的可見性或初始化操作。範例故意使用可見形狀並取代行為；未重新建構每個預設的實作。

## **格式相容性**

即使行為樹已保存，也無法保證在所有檢視器或匯出渲染器中播放完全相同。請分別檢查已儲存的資料與渲染輸出。

| 格式或輸出 | 需驗證項目 |
| --- | --- |
| PPTX | PPTX：作為這些範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放情況。 |
| PPT | PPT：舊版的二進位表示可能與 PPTX 不同。測試單獨的儲存與重新開啟循環以及播放；不要僅根據 PPTX 成功輸出就推斷支援所有自訂組合。 |
| PDF、PNG、JPEG 以及其他靜態投影片影像 | 僅包含靜態投影片表示，並非可播放的行為時間軸或保證的最終動畫框格。 |
| [HTML5](/slides/zh-hant/nodejs-java/export-to-html5/) | 可在匯出選項中啟用形狀動畫時播放支援的動畫。於瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/) | 儲存已渲染的影格，而非可編輯的行為或點擊觸發的互動。檢查實際渲染的動作。 |
| [Video](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) | 將動畫影格渲染並編碼為影片。支援僅限於渲染器的[支援動畫與效果](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects)；指令與互動事件不會變成可編輯的時間軸。 |

## **常見問題**

**為什麼我的效果在我加入任何行為之前就已包含行為？**

建立預定義效果時可能會產生其底層操作。請先檢查它們，再決定是擴充預設還是取代其行為。

**將行為移至開頭會使它先播放嗎？**

未必。集合順序並非時間的替代品。請檢查延遲、持續時間，以及同屬性操作之間的交互。

**為什麼結束指令沒有點？**

它標示路徑結束，無需座標。檢查從檔案讀取的路徑時，要留意點陣列是否為 null。

**成功的往返是否足以確認播放？**

不會。重新開啟僅驗證屬性的保存。須另行測試簡報播放程式或動畫匯出，以確認其視覺行為。