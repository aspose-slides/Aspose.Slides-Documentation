---
title: 在 Android 上建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/androidjava/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android (Java) 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為及可編輯的移動路徑。"
---
## **概觀**

自訂動畫行為讓您能控制動畫效果內的單一操作，例如變更顏色、旋轉圖形或沿可編輯的移動路徑前進。本指南說明如何建立與結合行為、設定它們的時間、檢查與修改現有動畫，並驗證其屬性在儲存與重新開啟簡報後仍能保留。

如需預設效果與點擊觸發器，請參閱[形狀動畫](/slides/zh-hant/androidjava/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **時間軸 → 序列 → 效果 → 行為**：

- [getTimeline](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) 方法會傳回投影片的時間軸，其中包含主要序列與互動序列。
- [ISequence](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/) 包含效果，可能針對不同圖形。
- [IEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/) 定義目標圖形、預設、子類型與效果時間。
- 由 [IEffect.getBehaviors](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 回傳的集合包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立單一行為**

呼叫 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 以建立效果並存取 [getBehaviors](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 集合。預設可以自動填滿此集合。延伸預設時保留其操作，或在有意取代時使用 [clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/#clear--)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/) 會建立下列八種行為類型。移動路徑請參考[建立移動路徑](#build-a-motion-path)。每個程式碼片段皆包含其 import；請將可執行語句放入方法內。稍後的編輯範例會說明使用哪個輸出檔案。於 Android 上，請以可由應用程式存取的完整路徑取代範例檔名，例如應用程式的檔案目錄。

### **旋轉**

使用 [createRotationEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) 建立旋轉。[getBy](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irotationeffect/#getBy--) 指定相對角度（度）；[getFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irotationeffect/#getFrom--) 與 [getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irotationeffect/#getTo--) 指定端點。

範例從 Spin 效果開始，將其預設操作以單一旋轉行為取代，並將該操作的持續時間設定為兩秒。90 度的相對角度表示圖形起始方向的四分之一旋轉，故不需要明確的起始角度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` 包含一個圖形與一個旋轉行為。以下的集合、時間與旋轉編輯範例皆使用此檔案。

### **縮放**

使用 [createScaleEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) 搭配 X/Y 百分比：[getFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) 與 [getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iscaleeffect/#getTo--) 描述起始與結束尺寸，而 [getBy](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iscaleeffect/#getBy--) 描述相對變化。此處 100 代表原始大小。

範例在兩秒內將兩個維度從 100% 增長至 125%。使用相同的水平與垂直百分比可保持圖形比例；使用不同的百分比則會拉伸某一維度。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **顏色**

使用 [createColorEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) 將填色從藍色變為橙色。[getFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icoloreffect/#getFrom--) 與 [getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icoloreffect/#getTo--) 為顏色；[getBy](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icoloreffect/#getBy--) 為顏色偏移。[IBehavior.getProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehavior/#getProperties--) 會指出被動畫化的屬性。

圖形的實心填色初始化為藍色，與動畫的起始顏色相符。選取填色屬性告訴行為要變更圖形的哪一部份；僅有顏色端點並不會指明該屬性。儲存的效果描述兩秒內過渡至橙色。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **濾鏡**

使用 [createFilterEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) 選擇抹除效果。[getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifiltereffect/#getType--)、[getSubtype](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--) 與 [getReveal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) 分別指定濾鏡、方向以及是顯示或隱藏圖形。

此範例設定兩秒的抹除效果，以右方向子類別顯示圖形。濾鏡設定屬於效果內的行為，因此在移除預設的原始操作後再進行設定。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **屬性**

使用 [createPropertyEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) 動畫化不透明度。[getFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--)、[getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipropertyeffect/#getTo--) 與 [getBy](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) 為字串，會透過 [getValueType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) 與 [getCalcMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) 進行解釋。請選擇端點或相對偏移，而非同時設定三者。

此處選取的屬性為不透明度，字串數值表示從 25% 不透明度變為完全不透明。線性插值描述在這兩個值之間的漸變。若將此範例套用至其他屬性，請為該屬性選擇合適的值類型與端點值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **設定**

使用 [createSetEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) 透過 [getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iseteffect/#getTo--) 指定可見性。設定行為不會在端點之間插值。

範例選取可見性屬性，並在行為執行時指派字串 `visible`。在此最小簡報中矩形已預設為可見，因此僅此指派不會產生明顯的視覺變化。此類操作在同時控制圖形何時隱藏或顯示的較大效果中會很有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **指令**

使用 [createCommandEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) 並設定 [getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommandeffect/#getType--)、[getCommandString](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommandeffect/#getCommandString--) 與 [getShapeTarget](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--)。將名為 `sample.wav` 的 WAV 錄音檔放在工作目錄中。此範例使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) 將其嵌入，並將播放指令附加至音訊框架。

音訊框架同時是效果的目標與指令的目標。這樣即把播放請求連結到嵌入的錄音檔；單純的指令字串本身不會指明要控制哪個媒體物件。效果設定為在投影片放映期間點擊時啟動。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

儲存會將指令存入 `command.pptx`；不會自動播放錄音。播放必須使用支援該指令與媒體目標的投影片播放器。

## **管理行為集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/) 支援 [add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)、[insert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)、[remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-)、以及 [removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-)。此範例開啟 `rotation.pptx`，加入縮放，將其插入至旋轉之前，並移除旋轉。移除後再重新插入同一物件會改變其儲存位置而不會產生副本。

編輯順序會將集合從「旋轉→縮放」變為「縮放→旋轉」，最後僅剩縮放。索引指向當前集合，所以在重新排序後的旋轉新索引被用於移除。最終列舉確認哪個行為會被儲存。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

輸出為 `ScaleEffect`：僅保留縮放。僅因集合順序本身不會排程行為依序執行。若要取代所有操作才清除集合。

## **設定行為時間**

[IBehavior.getTiming](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehavior/#getTiming--) 會公開 [ITiming](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/)，與 [IEffect.getTiming](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getTiming--) 獨立。效果時間排程整個效果；行為時間則描述其內部的單一操作。

### **設定持續時間、延遲、重複與加速**

開啟 `rotation.pptx`，以秒為單位設定持續時間 ([getDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getDuration--)) 與觸發延遲 ([getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--))，再透過 [setRepeatCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) 設定重複次數。[getAccelerate](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getAccelerate--) 與 [getDecelerate](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getDecelerate--) 為持續時間的比例；其總和請勿超過 1。

輸入檔案為旋轉範例中所建立的檔案，第一個行為已知為旋轉。本範例僅變更該行為的時間設定；其 90 度角度保持不變。將角度與時間分開，可在不重新建立動畫的情況下調整節奏。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此行為使用兩秒持續時間、半秒延遲，且重複次數為 3。前後各 20% 的持續時間用於加速與減速。

其他重複政策包括 [getRepeatDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatDuration--)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) 以及 [getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)；請只選擇其中一種，而非同時啟用。 [getAutoReverse](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getAutoReverse--) 會在正向播放後倒回播放。加速與減速僅適用於連續變化，不適用於離散的賦值或指令。

## **建立移動路徑**

使用 [createMotionEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) 建立移動。其 [getFrom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#getFrom--)、[getTo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#getTo--) 與 [getBy](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#getBy--) 說明以百分比為基礎的座標或偏移量。若要建立可編輯的路徑，請建立 [MotionPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/motionpath/) 並以 [IMotionEffect.setPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) 指派。 [IMotionPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotionpath/) 會儲存路徑指令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/motioncommandpathtype/) 用於選擇操作：

| 指令 | 點數 | 含義 |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至端點。 |
| CurveTo | Three | 依兩個控制點與端點形成的三次曲線前進。 |
| CloseLoop | None | 回到起始位置。 |
| End | None | 結束路徑。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/motionpathpointstype/) 說明點的編輯特性，如拐角點或平滑點。它不會取代指令類型。曲線範例請使用曲線點類型，直線段請使用拐角點類型。

路徑座標會正規化為投影片尺寸：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正向 Y 向下。絕對指令以路徑座標系統的絕對位置指定；相對指令則以相對於目前位置的偏移量指定。這與 [getOrigin](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#getOrigin--)（選擇路徑參照框）以及 [getPathEditMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--)（控制圖形移動時路徑如何移動）分開。

### **建立直線路徑**

建立一個包含起始點、一段直線與結束指令的移動行為。[IMotionPath.add](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) 需要指令類型、點陣列、點類型與相對座標旗標。

起始指令設定 (0, 0)，線段終點為 (0.25, 0)，使路徑在水平方向位移投影片寬度的四分之一。結束指令不帶座標點。將路徑指派後，將移動行為加入效果即會將此路徑套用至矩形。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 包含一個具有三個路徑指令的移動行為。以下的檔案編輯範例皆以此已知結構為基礎。

### **比較絕對與相對座標**

以下兩個路徑物件描述相同的路徑。絕對指令的終點為 (0.3, 0.1)；相對指令則在目前位置 (0.2, 0) 上加上 (0.1, 0.1)。

兩條路徑皆從相同位置開始。對於相對線，將其 X 與 Y 偏移量加至目前位置即可得到端點；對於絕對線，直接讀取端點。若未轉換座標而僅切換旗標，會產生不同的路徑。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

將任一路徑指派給移動行為即可在簡報中使用。最後的布林值參數決定該指令使用相對座標。

### **將直線取代為曲線**

開啟 `motion.pptx`，將其線段指令取代為三次曲線。先提供兩個控制點，最後提供端點。

起始位置由前一指令提供。前兩個點決定曲線形狀，第三個點為目的地；它們並非三個連續的目的地。同步更新指令類型、點編輯類型與點陣列，可確保段落與新幾何形狀一致。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 中的路徑仍有三個指令；其中間的指令現在定義為曲線。

## **檢查與編輯已儲存的路徑**

每個 [IMotionCmdPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioncmdpath/) 會公開 [getPoints](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--)、[getCommandType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--)、[getPointsType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--) 與 [isRelative](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--)。以下範例使用 `motion.pptx` 中已知的三指令路徑。若處理任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數量。

### **讀取指令與座標**

在不變更路徑的情況下讀取。結束與閉合指令不需要點，因此需允許 null 點陣列。

輸出會先列出每個數值指令類型與其相對座標旗標，然後列出其點。這讓您在修改路徑前能區分端點與偏移量。曲線會列出三個點，而此檔案中的直線僅列出一個點。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

列舉內容包含起始點、絕對線段終點 (0.25, 0) 與結束指令。

### **變更端點**

開啟 `motion.pptx`，取代線段的點陣列以移動其端點。

在輸入檔案中，索引 0 為起始指令，索引 1 為線段。取代線段的單一點會改變其目的地，而不會改變指令類型、時間或在集合中的位置。因為指令使用絕對座標，新點會指定位置而非加上偏移量。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 中的線段終點為 (0.4, 0.1)；原始檔案未變更。

### **取代段落**

使用 [insert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) 與 [removeAt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) 取代 `motion.pptx` 中的線段。插入會將舊線段往後移至索引 2。

此示範說明取代指令物件，而非編輯其現有座標。插入後，集合暫時包含起始指令、新線段、舊線段與結束指令。移除索引 2 後，即捨棄舊線段，留下新路徑。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的路徑仍有三個指令，新的線段終點為 (0.2, 0.1)，結束指令仍在最後。

## **修改並驗證現有行為**

當行為的索引未知時，可依類型選取。本範例開啟 `rotation.pptx`，找到其 [IRotationEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irotationeffect/)，變更角度，並在重新開啟後檢查儲存的值。

類型檢查允許迴圈跳過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，以確保比較的是持久化資料，而非仍留在記憶體中的值。本範例仍假設已知效果位於主要序列的第一個位置；以類型選取行為無法在任意簡報中定位正確的效果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

輸出為 `Rotation preserved: true`。對其他行為也可套用相同的類型檢查模式。若要完整驗證保留情況，請比較目標圖形、效果、行為類型與順序、時間與路徑指令。對於不明動畫布局的簡報，請參閱[讀取圖形動畫](/slides/zh-hant/androidjava/shape-animation/#read-shape-animations)以遍歷主要與互動序列。

## **行為順序、預設與播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehaviorcollection/) 中的順序即為效果操作的儲存順序。它不是播放清單，並不會自動讓每個行為等候前一個完成。時間與其所屬效果決定排程。行為可以重疊，同一屬性的操作可能透過 [getAdditive](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehavior/#getAdditive--) 與 [getAccumulate](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) 互動。請勿僅靠重新排序集合來安排「先移動再旋轉」；請使用明確的時間設定或如[形狀動畫](/slides/zh-hant/androidjava/shape-animation/)所述的分開效果。

效果的 [getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getType--) 與 [getSubtype](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getSubtype--) 描述其預設。它們不是已編輯行為樹的完整描述。請先選定預設與子類型，再自訂行為：變更預設可能會重建集合並捨棄您的自訂操作。例如，將自訂的 Spin 效果改為 Fade 可能會以 set 與 filter 行為取代其旋轉行為。變更預設或子類型後，請再次檢查集合。清除預設行為也可能移除預設所需的可見性或初始化操作。範例故意使用可見圖形並取代行為，未重新建構每個預設的實作。

## **格式相容性**

即使行為樹被保留，也不保證在所有檢視器或匯出渲染器中有相同的播放效果。請分別檢查已儲存的資料與渲染輸出。

| 格式或輸出 | 驗證項目 |
| --- | --- |
| PPTX | 使用此格式作為本範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放效果。 |
| PPT | 舊版二進位表示法可能與 PPTX 不同。請另行執行保存——重新開啟循環與播放測試；不要僅以 PPTX 成功輸出推斷支援所有自訂組合。 |
| PDF、PNG、JPEG 以及其他靜態投影片影像 | 只包含靜態投影片表示，並非可播放的行為時間軸或保證的最終動畫幀。 |
| [HTML5](/slides/zh-hant/androidjava/export-to-html5/) | 在匯出選項中啟用形狀動畫時，可播放支援的動畫。請在瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/) | 儲存的是渲染的幀，而非可編輯的行為或點擊觸發的互動。請檢查實際渲染的移動。 |
| [Video](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) | 渲染動畫幀並編碼為影片。支援範圍受渲染器的[支援動畫與效果](/slides/zh-hant/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects)限制；指令與互動事件不會成為可編輯的時間軸。 |

## **常見問題集**

**為什麼我的效果在我加入任何行為之前就已包含行為？**

建立預設效果時可能會同時建立其底層操作。請先檢查它們，再決定是要延伸預設還是取代其行為。

**將行為移至開頭會使它先播放嗎？**

未必。集合順序並非時間的替代品。請檢查延遲、持續時間以及同屬性操作之間的互動。

**為什麼結束指令沒有點？**

結束指令標示路徑的結尾，不需要座標。檢查從檔案讀取的路徑時，請留意點陣列可能為 null。

**僅成功的往返儲存即足以確認播放嗎？**

不夠。重新開啟只確認您檢查的屬性是否被保留。仍需在投影片放映播放器或動畫匯出中另行測試，以確認實際的視覺行為。