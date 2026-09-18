---
title: 在 Java 中建立與修改自訂動畫行為
linktitle: 自訂動畫
type: docs
weight: 151
url: /zh-hant/java/custom-animation/
keywords:
- 自訂動畫
- 動畫行為
- 移動路徑
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立、檢查與修改自訂動畫行為及可編輯的移動路徑。"
---
## **概觀**

自訂動畫行為讓您能控制動畫效果中的個別操作，例如變更顏色、旋轉圖形或遵循可編輯的移動路徑。本指南說明如何建立與組合行為、設定時間、檢查與修改現有動畫，以及確認其屬性在儲存與重新開啟簡報後仍能保留。

如需預定義效果與點擊觸發，請參考[形狀動畫](/slides/zh-hant/java/shape-animation/)。

## **了解動畫模型**

動畫的組織結構為 **時間軸 → 序列 → 效果 → 行為**：

- [getTimeline](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ibaseslide/#getTimeline--) 方法會回傳投影片的時間軸，其中包含主序列與互動序列。
- [ISequence](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/) 包含效果，可能針對不同的圖形。
- [IEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/) 定義目標圖形、預設、子類型與效果時間。
- [IEffect.getBehaviors](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#getBehaviors--) 回傳的集合包含實作效果的操作：變更顏色、移動、旋轉、設定屬性等。

## **建立個別行為**

呼叫[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 以建立效果並存取[getBehaviors]集合。預設會自動填入此集合。擴充預設時保留其操作，或在明確取代時使用[clear]。

[IBehaviorFactory] 建立下方示範的八種行為類型。移動路徑請參閱[Build a Motion Path](#build-a-motion-path)。每段程式碼都包含其 import；請將可執行語句放入方法中。之後的編輯範例會說明使用哪個輸出檔案。

### **旋轉**

使用[createRotationEffect]建立旋轉。[getBy]指定相對角度（度）；[getFrom]與[getTo]指定起點與終點。

範例從 Spin 效果開始，將其預設操作取代為單一旋轉行為，並為該操作設定兩秒的持續時間。90 度的相對角度代表圖形起始方向的四分之一旋轉，故不需要明確的起始角度。

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

使用[createScaleEffect]並以 X/Y 百分比表示： [getFrom] 與 [getTo] 描述起始與結束尺寸，而 [getBy] 描述相對變化。此處 100 代表原始大小。

範例在兩秒內將兩個維度從 100% 增長至 125%。使用相同的水平與垂直百分比可保持圖形比例；若使用不同的百分比則會使某一維度較另一維度更伸展。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **顏色**

使用[createColorEffect]將填色從藍色變更為橙色。[getFrom]與[getTo]為顏色；[getBy]為顏色偏移。[IBehavior.getProperties]用於辨識被動畫化的屬性。

圖形的實心填色預設為藍色，與動畫的起始顏色相同。選取填色屬性可告訴行為要變更圖形的哪一部分；僅有顏色端點無法辨識該屬性。儲存的效果描述為兩秒的過渡至橙色。

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **濾鏡**

使用[createFilterEffect]以選取擦除效果。[getType]、[getSubtype]與[getReveal]分別指定濾鏡類型、方向，以及是顯示或隱藏圖形。

此範例設定為兩秒的擦除，使用向右方向子類別來顯示圖形。濾鏡設定屬於效果內的行為，故在移除預設的原始操作後再進行設定。

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

使用[createPropertyEffect]以動畫化不透明度。[getFrom]、[getTo]與[getBy]為字串，會透過[getValueType]與[getCalcMode]進行解析。請選擇端點或相對偏移，而不要同時設定三者。

此處，所選屬性為不透明度，數值字串表示從 25% 不透明度變為完全不透明。線性插值描述兩個值之間的漸變。若將此範例改用其他屬性，請選擇相應的值類型與端點值。

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

使用[createSetEffect]並透過[getTo]指定可見性。設定行為不會在端點之間插值。

此範例選取可見性屬性，並在行為執行時指派字串 `visible`。在此簡易簡報中矩形已是可見的，因此此指派本身可能不會產生明顯的視覺變化。此類操作在結合其他控制圖形隱顯的較大效果時相當有用。

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

使用[createCommandEffect]並設定[getType]、[getCommandString]與[getShapeTarget]。將名稱為 `sample.wav` 的 WAV 錄音檔放置於工作目錄。此範例使用[addAudioFrameEmbedded]將其嵌入，並為音訊框架附加播放指令。

音訊框架同時是效果與指令的目標。這將播放請求連結至嵌入的錄音；僅有指令字串無法辨識要控制的媒體對象。此效果設定為在投影片放映期間點擊時啟動。

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

儲存時會將指令存入`command.pptx`；不會直接播放錄音。播放需要支援此指令與媒體目標的投影片放映程式。

## **管理行為集合**

[IBehaviorCollection] 支援 add、insert、remove 與 removeAt。此範例開啟`rotation.pptx`，加入縮放，將其移至旋轉之前，並移除旋轉。移除再重新插入同一物件會變更其儲存位置而不產生副本。

編輯順序會將集合從 rotation–scale 變為 scale–rotation，最後變為僅 scale。索引指向當前集合，因此移除時使用旋轉在重新排序後的新索引。最後的列舉確認了將被儲存的行為。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
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

輸出為`ScaleEffect`：僅剩縮放。僅靠集合順序不會使行為相繼排程。僅在全部取代其操作時才清除集合。

## **設定行為時間**

[IBehavior.getTiming] 會揭露 ITiming，與[IEffect.getTiming] 獨立。效果時間排程封裝的效果；行為時間描述其內部的操作。

### **設定持續時間、延遲、重複與加速**

開啟`rotation.pptx`，以秒為單位設定持續時間([getDuration])與觸發延遲([getTriggerDelayTime])，接著透過[setRepeatCount]設定重複次數。[getAccelerate]與[getDecelerate]為持續時間的比例；其總和請維持在不超過 1。

輸入檔為旋轉範例所建立的檔案，第一個行為已知為旋轉。本範例僅變更該行為的時間，其 90 度角度保持不變。將角度與時間分開，使調整節奏時不必重新建構動畫。

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

該行為使用兩秒的持續時間、半秒的延遲，且重複次數為 3。其持續時間的前後各 20% 用於加速與減速。

其他重複策略包含 getRepeatDuration、getRepeatUntilEndSlide 與 getRepeatUntilNextClick；請選擇單一策略，而非同時啟用。getAutoReverse 會在正向播放後反向播放動畫。加速與減速適用於連續變化，而非離散的指派或指令。

## **建立移動路徑**

使用[createMotionEffect]建立移動。其 getFrom、getTo 與 getBy 描述以百分比為基礎的座標或偏移。若要可編輯的路徑，請建立[MotionPath]並以[IMotionEffect.setPath]指派。[IMotionPath]會儲存路徑指令。

| 指令 | 點數 | 說明 |
| --- | --- | --- |
| MoveTo | One | 設定起始位置。 |
| LineTo | One | 沿直線段移動至其端點。 |
| CurveTo | Three | 依兩個控制點與端點所定義的三次曲線移動。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 結束路徑。 |

[MotionPathPointsType] 描述點編輯特性，例如轉角點或平滑點。它不會取代指令類型。對於下方的曲線範例使用曲線點類型，對直線段使用轉角點類型。

路徑座標依投影片尺寸正規化：X 位移 0.25 代表投影片寬度的四分之一，而非 0.25 點。正的 Y 向下。絕對指令在路徑座標系統中指定位置；相對指令則以目前位置的偏移表示。這與[getOrigin]（選取路徑參考框架）以及[getPathEditMode]（控制圖形移動時路徑的移動方式）分開。

### **建立直線路徑**

建立包含起始點、一條直線段與結束指令的移動行為。[IMotionPath.add] 需要指令類型、其點、點的類型以及相對座標旗標。

起始指令設定為 (0, 0)，而直線結束於 (0.25, 0)，使路徑在水平上位移投影片寬度的四分之一。結束指令沒有座標點。路徑指派完成後，將移動行為加入效果即可將此路徑連結至矩形。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 包含一個具有三個路徑指令的移動行為。以下的檔案編輯範例皆使用此已知結構。

### **比較絕對與相對座標**

這兩個路徑物件描述相同的路徑。絕對指令的終點為 (0.3, 0.1)；相對指令則將 (0.1, 0.1) 加至目前位置 (0.2, 0)。

兩條路徑皆從相同位置開始。對於相對線，將其 X 與 Y 偏移加至目前位置即可得到端點；對於絕對線，直接讀取端點。若切換旗標而不轉換座標，會產生不同的路徑。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

將任一路徑指派給移動行為即可於簡報中使用。最後的布林參數用於選擇該指令的相對座標。

### **將直線替換為曲線**

開啟`motion.pptx`，將其直線指令替換為三次曲線。先提供兩個控制點，然後是端點。

起始位置由前一指令提供。前兩個點形塑曲線，第三個點為終點；它們並非三個連續的目的地。一起更新指令類型、點編輯類型與點陣列，可使段落與新幾何保持一致。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 中的路徑仍有三個指令；其中間指令現在定義為曲線。

## **檢查與編輯已儲存的路徑**

每個[IMotionCmdPath]會揭露 getPoints、getCommandType、getPointsType與 isRelative。以下範例使用`motion.pptx`中已知的三指令路徑。對於任意輸入，請先定位目標效果，並在依索引編輯前檢查指令類型與點數量。

### **讀取指令與座標**

在不變更路徑的前提下讀取。End 與 CloseLoop 指令不需要點，因此需允許點陣列為 null。

輸出會先將每個數值指令類型與其相對座標旗標配對，然後列出其點。這讓您在修改路徑前能區分端點與偏移。曲線會列出三個點，而此檔案中的直線僅列出一個點。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

此清單包含起始點、一條結束於 (0.25, 0) 的絕對直線，以及結束指令。

### **變更端點**

開啟`motion.pptx`，並取代直線的點陣列以移動其端點。

在輸入檔中，索引 0 為起始指令，索引 1 為直線。替換直線的單一點會改變其目的地，但不會改變指令類型、時間或在集合中的位置。因指令使用絕對座標，新的座標對指定的是位置而非添加的偏移。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 中的直線終點為 (0.4, 0.1)；原始檔案未被更改。

### **取代段落**

使用 insert 與 removeAt 取代`motion.pptx`中的直線。插入會將舊的直線移至索引 2。

此示範取代指令物件而非編輯其現有座標。插入後，集合暫時包含起始指令、新直線、舊直線與結束指令。移除索引 2 後，舊直線被丟棄，新的路徑保留下來。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的路徑仍有三個指令，新直線的終點為 (0.2, 0.1)，結束指令位於最後。

## **修改與驗證現有行為**

當行為的索引未知時，請依類型選取。本範例開啟`rotation.pptx`，尋找其 IRotationEffect，變更角度，並在重新開啟後檢查儲存的值。

類型檢查使迴圈可略過非旋轉的行為。第二次載入會將已儲存的檔案讀入另一個簡報物件，因而比較的是持久化資料，而非仍留在記憶體中的值。本範例仍假設已知的效果位於主序列的第一個；依類型選取行為無法在任意簡報中定位正確的效果。

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

輸出為`Rotation preserved: true`。對其他行為套用相同的類型檢查模式。若要完整的保留檢查，請比較目標圖形、效果、行為類型與順序、時間與路徑指令。對浮點值使用數值容差。若簡報的動畫佈局未知，請參閱[Read Shape Animations](/slides/zh-hant/java/shape-animation/#read-shape-animations) 以遍歷主序列與互動序列。

## **行為順序、預設與播放**

[IBehaviorCollection] 中的順序即為效果操作的儲存順序。它並非播放清單，不能保證每個行為自動等待前一個。時間與封裝的效果決定排程。行為可能重疊，同一屬性的操作可能透過 getAdditive 與 getAccumulate 互相影響。不要僅以重新排序集合來排程「先移動再旋轉」；請使用明確的時間設定或如[Shape Animation](/slides/zh-hant/java/shape-animation/)所述的分離效果。

效果的 getType 與 getSubtype 描述其預設。它們無法完整描述編輯過的行為樹。請先選擇預設與子類型，再自訂行為：變更預設可能會重建集合並捨棄您的自訂操作。例如，將自訂的 Spin 效果改為 Fade 會以 set 與 filter 行為取代其旋轉行為。變更預設或子類型後請再次檢查集合。清除預設行為亦可能移除預設所需的可見性或初始化操作。範例故意使用可見圖形並取代其行為；不會重新建構每個預設的實作。

## **格式相容性**

即使保留了行為樹，也不保證在所有檢視器或匯出渲染器中具有相同的播放效果。請分別檢查已儲存的資料與渲染輸出。

| 格式或輸出 | 需要驗證的項目 |
| --- | --- |
| PPTX | 使用此格式作為範例的主要格式。重新開啟以驗證可編輯的行為樹，然後在目標 PowerPoint 版本中檢查播放。 |
| PPT | 舊版二進位表示法可能與 PPTX 不同。測試單獨的儲存與重新開啟循環及播放；不要僅憑 PPTX 成功輸出就推斷支援所有自訂組合。 |
| PDF, PNG, JPEG, and other static slide images | 包含靜態投影片表示，未包含可播放的行為時間軸或保證的最終動畫畫面。 |
| [HTML5](/slides/zh-hant/java/export-to-html5/) | 在匯出選項啟用形狀動畫時，可播放支援的動畫。於瀏覽器中測試自訂組合。 |
| [Animated GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/) | 儲存渲染的影格，而非可編輯的行為或點擊觸發的互動。檢查實際渲染的移動。 |
| [Video](/slides/zh-hant/java/convert-powerpoint-to-video/) | 渲染動畫影格並編碼為影片。支援度受渲染器的[supported animations and effects]限制；指令與互動事件不會變成可編輯的時間軸。 |

## **常見問題**

**為什麼我的效果在我添加任何行為之前就已包含行為？**

建立預設效果時可能會建立其底層操作。請在決定是擴充預設還是取代其行為前先檢查它們。

**將行為移至開頭會讓它先播放嗎？**

不一定。集合順序並不能取代時間設定。請檢查延遲、持續時間，以及同一屬性操作之間的互動。

**為什麼 End 指令沒有點？**

它標示路徑結束，無需座標。檢查從檔案讀取的路徑時，請留意點陣列是否為 null。

**成功的往返儲存與開啟是否足以確認播放？**

不是。重新開啟僅確認您檢查的屬性得以保留。請另行測試投影片播放程式或動畫匯出，以確認其視覺行為。