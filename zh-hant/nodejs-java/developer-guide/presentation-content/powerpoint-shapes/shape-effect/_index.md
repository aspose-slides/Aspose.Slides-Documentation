---
title: 在簡報中使用 JavaScript 套用形狀特效
linktitle: 形狀特效
type: docs
weight: 30
url: /zh-hant/nodejs-java/shape-effect/
keywords:
- 形狀特效
- 陰影特效
- 反射特效
- 發光特效
- 柔和邊緣特效
- 特效格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js，透過進階的形狀特效轉換您的 PPT 與 PPTX 檔案——在數秒內打造醒目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的特效可用於讓形狀突出，但它們與 [填色](/slides/zh-hant/nodejs-java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 特效，您可以為形狀建立逼真的倒影、擴散形狀的發光等效果。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的特效。您可以對同一個形狀套用一個或多個特效。

某些特效組合看起來比其他組合更好。因此，PowerPoint 在 **Preset** 下提供了選項。Preset 選項是兩種或以上已知能產生良好視覺效果的特效組合。透過選取預設，您不必浪費時間測試或組合不同的特效來尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您在 PowerPoint 簡報的形狀上套用相同的特效。

## **套用陰影特效**

Aspose.Slides for Node.js via Java 支援形狀的外部陰影與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計需求。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上脫穎而出。陰影延伸至形狀邊緣之外，營造形狀浮於投影片之上的感覺。調整顏色、方向、距離與模糊半徑，以符合範本的光源與樣式。

以下 JavaScript 程式碼示範如何將 [外部陰影特效](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用到矩形：

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

![陰影特效](shadow_effect.png)

### **套用內部陰影**

在重現範本的視覺樣式時，使用內部陰影可令卡片或面板呈現凹陷的外觀。外部陰影延伸至形狀外部，使其看起來被抬起；而內部陰影則在其邊緣內部產生陰影。

先呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)，再設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) 回傳的陰影。較大的模糊半徑值會產生較柔和的邊緣。

以下 JavaScript 範例建立一個淡藍色卡片，並套用深灰色內部陰影，最後將檔案儲存為 PPTX。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![淡藍色矩形的內部陰影](inner_shadow_effect.png)

若要移除內部陰影，請對形狀的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **套用、變更與移除預設陰影**

呼叫 [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) 並使用 [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) 來選取 [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/)。如需切換樣式，可在同一形狀上變更預設。呼叫 [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) 可在保留填色與輪廓的情況下移除陰影。

此範例在同一投影片上並排顯示四個階段。兩個陰影的偏移皆為 10 點。225° 的方向將第一個陰影放置在矩形的左上方，45° 的方向則將第二個陰影放置在右下方。

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

| 原始 | 第一個預設 | 第二個預設 | 移除後 |
| :---: | :---: | :---: | :---: |
| ![無陰影](preset_shadow_original.png) | ![左上方陰影](preset_shadow_top_left.png) | ![右下方陰影](preset_shadow_bottom_right.png) | ![移除陰影後的無陰影](preset_shadow_removed.png) |

## **套用反射特效**

在 Aspose.Slides for Node.js via Java 中套用反射特效，只需為形狀新增鏡像般的反射，並調整距離、透明度與大小等參數。此特效可提升簡報的美觀度，使形狀呈現更精緻、專業的外觀。透過簡單程式碼即可快速在多個元素上套用，保持設計一致性。

以下 JavaScript 程式碼示範如何將 [反射特效](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) 套用到形狀：

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

![反射特效](reflection_effect.png)

## **套用發光特效**

在 Aspose.Slides for Node.js via Java 中套用發光特效，只需在形狀周圍加入柔和的光暈，並調整顏色與大小等屬性。此特效有助於使形狀更突出，為簡報增添吸睛的視覺元素。實作簡易，僅需少量程式碼即可提升投影片整體外觀。

以下 JavaScript 程式碼示範如何將 [發光特效](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) 套用到形狀：

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

![發光特效](glow_effect.png)

## **套用柔和邊緣特效**

在 Aspose.Slides for Node.js via Java 中套用柔和邊緣特效，可在形狀的邊緣產生平滑、模糊的過渡效果。此特效為設計增添更細緻、柔和的外觀，適用於需要柔軟外觀的版面。您可以輕鬆調整半徑等參數，以在簡報中的各種形狀上取得理想效果。

以下 JavaScript 程式碼示範如何將 [柔和邊緣特效](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用到形狀：

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

![柔和邊緣特效](soft_edges_effect.png)

## **套用模糊特效**

使用形狀模糊可在保持形狀可編輯的同時，柔化其填色與輪廓。對形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 英吋) 為單位：使用非負值，值越大模糊程度越強。半徑為零時外觀保持不變。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定控制特效的可見邊界。設定為 `false` 時，模糊會被限制在原始繪製的邊界內，包括輪廓；設定為 `true` 時，模糊可延伸超出該邊界。無論哪種設定，都不會改變形狀的位置或尺寸。

下方比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 點與 15 點的比較，分別在關閉與啟用 grow 時的效果](shape_blur_comparison.png)

此 JavaScript 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) 將模糊調整為 15 點，並分別儲存兩個模糊狀態；最後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣特效會淡化形狀邊緣，而陰影模糊僅會柔化陰影本身。圖像轉換特效作用於圖像內容；本範例直接在形狀的 effect format 上套用模糊，而不需將形狀轉換為圖像。

## **常見問題**

**我可以對同一個形狀套用多個特效嗎？**

可以，您可以將陰影、反射、發光等不同特效組合在單一形狀上，以產生更具動感的外觀。

**哪些形狀可以套用特效？**

您可以對各種形狀套用特效，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用特效嗎？**

可以，特效會套用到整個群組。