---
title: 在簡報中使用 JavaScript 套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/nodejs-java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js 以先進的形狀效果轉換您的 PPT 與 PPTX 檔案——在數秒內打造引人注目且專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓圖形突出，但它們與 [填色](/slides/zh-hant/nodejs-java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在圖形上建立逼真的反射、擴散圖形的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於圖形的效果。您可以對圖形套用一種或多種效果。

某些效果組合看起來比其他組合更佳。因此，PowerPoint 在 **預設** 下提供選項。預設選項是兩種或以上已知效果良好組合的搭配。透過選取預設，您就不必浪費時間測試或組合不同效果以找出理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您能將相同的效果套用至 PowerPoint 簡報中的圖形。

## **套用陰影效果**

Aspose.Slides for Node.js via Java 支援圖形的外部與內部陰影。您可以自訂顏色、方向、距離與模糊半徑，以符合簡報的設計需求。

### **套用外部陰影**

使用外部陰影可使卡片或面板在投影片背景上突出。陰影延伸至圖形邊緣之外，營造圖形浮起於投影片上的感覺。調整其顏色、方向、距離與模糊半徑，以符合模板的光源與樣式。

以下 JavaScript 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用至矩形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![陰影效果](shadow_effect.png)

#### **在圖形旋轉時控制陰影方向**

預設情況下，外部陰影會隨圖形旋轉。若希望不同旋轉角度的圖形看起來光源方向相同，請以 `false` 呼叫 [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) 並使用 [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) 為它們的陰影設定相同方向。

此範例建立兩個藍色箭頭，灰色陰影向右偏移 42 點 (0°)。接著複製投影片，將兩個箭頭順時針旋轉 90°。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在第二張投影片中，左側箭頭的陰影向下投射，而右側箭頭的陰影仍向右。兩個陰影的設定方向皆保持 0°。

![PowerPoint 在 90° 旋轉前後的呈現。兩個陰影起始於右側。旋轉後，左側箭頭的陰影移至下方，右側箭頭的陰影仍在右側。](arrow-shadow-rotation.png)

### **套用內部陰影**

在還原模板的視覺樣式時，可使用內部陰影讓卡片或面板呈現凹陷的外觀。外部陰影延伸至圖形外部，使其看起來凸起；內部陰影則在邊緣內側投射陰影。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)，接著設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影。較大的模糊半徑會產生較柔和的邊緣。

以下 JavaScript 範例建立一個淡藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![帶內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請對圖形的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **套用、變更與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) 並使用 [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) 以選取 [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/)。若要切換樣式，可在同一圖形上變更預設。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) 以在保留填色與輪廓的情況下移除陰影。

此範例於同一投影片上並排顯示四個階段。兩個陰影均偏移 10 點。225° 的方向將第一個陰影放置於矩形的左上方，45° 則將第二個陰影放置於右下方。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 原始 | 第一預設 | 第二預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上陰影](preset_shadow_top_left.png) | ![右下陰影](preset_shadow_bottom_right.png) | ![移除後無陰影](preset_shadow_removed.png) |

## **套用反射效果**

在 Aspose.Slides for Node.js via Java 中套用反射效果時，您可以為圖形加入鏡像般的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使圖形更顯精緻與高級。透過簡單程式碼即可輕鬆實作，快速在多個元素上套用，保持設計一致性。

以下 JavaScript 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) 套用至圖形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射效果](reflection_effect.png)

## **套用發光效果**

在 Aspose.Slides for Node.js via Java 中為圖形套用發光效果時，您可以在圖形周圍加上柔和、發亮的光環，並調整顏色與大小等屬性。此效果協助圖形突顯，為簡報增添吸引且醒目的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 JavaScript 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) 套用至圖形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![發光效果](glow_effect.png)

## **套用柔和邊緣效果**

在 Aspose.Slides for Node.js via Java 中套用柔和邊緣效果時，您可以在圖形邊緣製造平滑、模糊的過渡。此效果帶來更細膩、精緻的外觀，適合需要柔和外觀的設計。您可輕鬆調整半徑等參數，以在簡報中各種圖形上達成理想效果。

以下 JavaScript 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用至圖形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![柔和邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可柔化圖形的填色與輪廓，同時保持圖形可編輯。對圖形的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 英吋) 為單位：使用非負值，值越大模糊程度越強。半徑為 0 時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定控制效果的可見範圍。設為 `false` 時，模糊會被裁切至原始繪製範圍，包含輪廓。設為 `true` 時，模糊可延伸超出該範圍。兩種設定皆不會改變圖形的位置或尺寸。

下方比較使用相同的填色、輪廓與圖形尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 與 15 點的比較，分別在關閉與啟用 grow 時的狀態](shape_blur_comparison.png)

以下 JavaScript 範例建立一個橙色矩形，配上深藍色輪廓，先套用 5 點的模糊，接著再呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) 將其更新為 15 點的模糊。程式會將兩個模糊狀態皆儲存，然後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未模糊的圖形。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形狀模糊同時影響填色與輪廓。柔和邊緣效果僅淡化圖形的邊緣，而陰影模糊則只柔化陰影。影像轉換效果作用於影像內容；本範例直接對圖形的 effect format 套用模糊，未將圖形轉換為影像。

## **常見問題**

**我可以對同一圖形套用多個效果嗎？**

是的，您可以在單一圖形上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些圖形套用效果？**

您可以對各種圖形套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對組合圖形套用效果嗎？**

是的，您可以對組合圖形套用效果。效果會套用於整個群組。