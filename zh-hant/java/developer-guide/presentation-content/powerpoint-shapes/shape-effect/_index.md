---
title: 使用 Java 在簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 的進階形狀效果轉換您的 PPT 和 PPTX 檔案——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們與 [填充](/slides/zh-hant/java/shape-formatting/#gradient-fill) 或外框不同。使用 PowerPoint 效果，您可以在形狀上建立真實的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對同一個形狀套用一或多種效果。

某些效果組合看起來比其他組合更佳。為此，PowerPoint 在 **Preset** 下提供了選項。Preset 選項是已知外觀良好的兩種或以上效果的組合。這樣，透過選取預設，您不必花時間測試或組合不同效果來找到理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 類別下提供屬性與方法，允許您在 PowerPoint 簡報中的形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影讓卡片或面板在投影片背景之上脫穎而出。陰影會延伸至形狀邊緣之外，營造形狀被提升於投影片之上的感覺。調整其顏色、方向、距離與模糊半徑，以配合範本的光線與樣式。

此 Java 程式碼示範如何對矩形套用 [外部陰影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![陰影效果](shadow_effect.png)

### **套用內部陰影**

當重現範本的視覺樣式時，使用內部陰影讓卡片或面板呈現凹陷的外觀。外部陰影延伸至形狀之外，使其看起來被提升；而內部陰影則在其邊緣內側投射陰影。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然後使用 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 取得的陰影進行設定。較大的模糊半徑會產生較柔和的邊緣。

此 Java 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後保存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請對形狀的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

### **套用、變更與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--)，並使用 [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) 來選取 [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/)。若要切換樣式，只要在同一形狀上變更 preset 即可。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) 可在保留填色與外框的同時移除陰影。

此範例在同一投影片上並排顯示四個階段。兩個陰影皆偏移 10 點。225° 的方向使第一個陰影位於矩形的左上方，45° 的方向則使第二個陰影位於右下方。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 原始 | 第一個預設 | 第二個預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上方陰影](preset_shadow_top_left.png) | ![右下方陰影](preset_shadow_bottom_right.png) | ![移除陰影後的無陰影](preset_shadow_removed.png) |

## **套用反射效果**

要在 Aspose.Slides for Java 中套用反射效果，您可以為形狀新增類似鏡面的反射，並調整距離、透明度與大小等參數。此效果可提升簡報的美感，使形狀看起來更精緻且有層次感。透過簡單程式碼即可快速在多個元素間套用，確保設計的一致性。

此 Java 程式碼示範如何對形狀套用 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射效果](reflection_effect.png)

## **套用發光效果**

要在 Aspose.Slides for Java 中為形狀套用發光效果，您可以在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀更突出，並為您的簡報增添吸引人的視覺元素。只需少量程式碼即可實作，提升投影片的整體觀感。

此 Java 程式碼示範如何對形狀套用 [發光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![發光效果](glow_effect.png)

## **套用柔化邊緣效果**

要在 Aspose.Slides for Java 中套用柔化邊緣效果，您可以在形狀的邊緣周圍建立平滑、模糊的過渡。此效果能為設計增添更細膩、精緻的外觀，特別適合需要柔和外觀的版面設計。您可以輕鬆調整半徑等參數，以在簡報的各種形狀上達成理想效果。

此 Java 程式碼示範如何對形狀套用 [柔化邊緣效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![柔化邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可在保持形狀可編輯的前提下，柔化其填色與外框。對形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 即可。半徑以點為單位 (1/72 吋)：使用非負值，值越大模糊程度越強。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定控制效果的可視範圍。`false` 時，模糊會被裁切至原始繪製範圍（包括外框）；`true` 時，模糊可超出該範圍。兩種設定皆不會改變形狀的位置或尺寸。

下方比較使用相同的填色、外框與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 與 15 點的比較（grow 停用與啟用）](shape_blur_comparison.png)

此 Java 範例建立一個橙色矩形，搭配深藍色外框，先套用 5 點模糊，然後再呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 以 15 點模糊更新，並分別保存兩個模糊狀態；最後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--)，保存未模糊的形狀。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形狀模糊同時影響填色與外框。柔化邊緣效果只淡化形狀的邊緣，而陰影模糊則僅柔化陰影。影像轉換效果作用於圖像內容；此範例直接在形狀的 effect format 上套用模糊，未將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以將陰影、反射、發光等不同效果組合在同一個形狀上，以創造更動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動形狀、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用到整個群組。