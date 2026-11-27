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
description: "使用 Aspose.Slides for Java 以進階的形狀效果轉換您的 PPT 與 PPTX 檔案——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用於強調形狀，但它們不同於 [填色](/slides/zh-hant/java/shape-formatting/#gradient-fill) 或外框。使用 PowerPoint 效果，您可以在形狀上創建逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合比其他組合更好看。為此，PowerPoint 在 **Preset** 下提供選項。預設選項是兩個或以上已知好看的效果組合。透過選取預設，您不必浪費時間測試或組合不同效果以找出漂亮的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 類別下提供屬性與方法，讓您能將相同的效果套用於 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影使卡片或面板在投影片背景上突出。陰影延伸超出形狀邊緣，營造出形狀浮於投影片之上的感覺。調整顏色、方向、距離與模糊半徑，以配合範本的光源與樣式。

此 Java 程式碼說明如何將 [外部陰影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) 套用至矩形：

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

#### **在形狀旋轉時控制陰影方向**

預設情況下，外部陰影會隨形狀旋轉。若要讓不同旋轉角度的形狀看起來受到相同方向的光照，請以 `false` 呼叫 [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-)，並使用 [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) 設定相同的陰影方向。

範例建立兩個藍色箭頭，灰色陰影向右偏移 42 點 (0°)。接著複製投影片並將兩個箭頭順時針旋轉 90°。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在第二張投影片中，左側箭頭的陰影向下投射，而右側箭頭的陰影仍向右。兩個陰影的方向皆保持 0°。

![PowerPoint 在 90° 旋轉前後的渲染。兩個陰影最初位於右側，旋轉後左側箭頭的陰影移至下方，右側箭頭的陰影仍在右側。](arrow-shadow-rotation.png)

### **套用內部陰影**

在重現範本的視覺樣式時，使用內部陰影讓卡片或面板呈現凹陷感。外部陰影延伸於形狀外側，使其顯得凸起；內部陰影則在邊緣內側著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 取得的陰影。較大的模糊半徑會產生較柔和的邊緣。

此 Java 範例建立一個淡藍色卡片，帶深灰色內部陰影，並儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

若要移除內部陰影，請於形狀的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

### **套用、變更與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) 並使用 [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) 選取 [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/)。若要切換樣式，可在同一形狀上變更預設。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) 可移除陰影，同時保留填色與外框。

此範例在同一投影片上並排顯示四個階段。兩個陰影皆偏移 10 點。225° 方向將第一個陰影放在矩形的左上方，45° 方向則將第二個陰影放在右下方。

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

| 原始 | 第一預設 | 第二預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上投影](preset_shadow_top_left.png) | ![右下投影](preset_shadow_bottom_right.png) | ![移除後無陰影](preset_shadow_removed.png) |

## **套用反射效果**

在 Aspose.Slides for Java 中套用反射效果，您可以為形狀新增鏡面般的反射，調整距離、透明度與大小等參數。此效果能提升簡報的美感，使形狀更顯精緻與專業。只需簡單程式碼即可快速套用於多個元素，以保持設計一致性。

此 Java 程式碼說明如何將 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) 套用至形狀：

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

在 Aspose.Slides for Java 中套用發光效果，您可以在形狀周圍加上柔和的光環，調整顏色與大小等屬性。此效果有助於讓形狀更突出，為簡報增添吸引人的視覺元素。只需少量程式碼即可實作，提升投影片的整體觀感。

此 Java 程式碼說明如何將 [發光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) 套用至形狀：

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

在 Aspose.Slides for Java 中套用柔化邊緣效果，您可以在形狀的邊緣創建平滑、模糊的過渡。此效果讓外觀更為細緻、柔和，適合需要柔軟外觀的設計。您可輕鬆調整半徑等參數，以在簡報中的各種形狀上實現理想的效果。

此 Java 程式碼說明如何將 [柔化邊緣效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) 套用至形狀：

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

使用形狀模糊可在保持形狀可編輯的前提下，使填色與外框變得柔和。於形狀的 effect format 上呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)。半徑以點 (1/72 吋) 為單位：使用非負值，值越大模糊程度越高。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定控制效果的可見範圍。設定為 `false` 時，模糊會被限制在原始繪製範圍內（包括外框）；設定為 `true` 時，模糊可延伸超出該範圍。無論哪種設定，都不會改變形狀的位置或尺寸。

以下比較使用相同的填色、外框與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與 5 點與 15 點模糊半徑的比較，分別在停用與啟用 grow 時的效果](shape_blur_comparison.png)

此 Java 範例建立一個橘色矩形，帶深藍外框，先套用 5 點模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 改為 15 點模糊，並分別儲存兩個模糊狀態；最後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) 並儲存未模糊的形狀。

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

形狀模糊同時影響填色與外框。柔化邊緣效果只淡化形狀邊緣，而陰影模糊僅柔化陰影本身。影像轉換效果作用於影像內容；本範例直接於形狀的 effect format 套用模糊，未將形狀轉為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以將不同的效果（例如陰影、反射、發光）組合在同一形狀上，以打造更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，效果會套用於整個群組。