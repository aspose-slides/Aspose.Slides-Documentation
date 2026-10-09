---
title: 使用 JavaScript 在簡報中套用形狀效果
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
description: "使用 JavaScript 以及 Aspose.Slides for Node.js，將您的 PPT 和 PPTX 檔案轉換為進階的形狀效果——在幾秒鐘內打造引人注目且專業的投影片。"
---
## **簡介**

PowerPoint 中的效果可用於讓形狀突出，但它們不同於 [填色](/slides/zh-hant/nodejs-java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上建立逼真的倒影、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一種或多種效果。

某些效果的組合看起來比其他組合更佳。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項是兩種或以上效果的組合，已知能產生良好效果。透過選取預設組合，您无需耗费時間測試或組合不同的效果以找到合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 類別中提供屬性與方法，讓您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Node.js via Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景上突出。陰影延伸至形狀邊緣之外，營造形狀仿佛懸浮於投影片之上的效果。調整其顏色、方向、距離與模糊半徑，以配合模板的光線與樣式。

此 JavaScript 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用至矩形：

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

### **套用內部陰影**

在重現模板的視覺樣式時，使用內部陰影可為卡片或面板呈現凹陷外觀。外部陰影延伸至形狀之外，使其看起來凸起；而內部陰影則在其邊緣內側著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影。較大的模糊半徑值會產生較柔和的邊緣。

此 JavaScript 範例建立一個淡藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

若要移除內部陰影，請在形狀的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **套用反射效果**

在 Aspose.Slides for Node.js via Java 中套用反射效果時，您可以為形狀加入鏡面般的反射，並調整距離、透明度與大小等參數。此效果可提升簡報的美感，使形狀看起來更精緻與高級。透過簡單的程式碼即可輕鬆實作，快速在多個元素上套用，達成一致的設計。

此 JavaScript 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) 套用至形狀：

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

在 Aspose.Slides for Node.js via Java 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，並調整顏色與大小等屬性。此效果可讓形狀更突出，為簡報增添吸引目光的視覺元素。透過少量程式碼即可輕鬆實作，提升投影片的整體外觀。

此 JavaScript 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) 套用至形狀：

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

在 Aspose.Slides for Node.js via Java 中套用柔和邊緣效果時，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果增添更細緻與精緻的外觀，適合需要柔和外觀的設計。您可輕鬆調整半徑等參數，以在簡報的各種形狀上達到理想的效果。

此 JavaScript 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用至形狀：

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

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對多種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。效果會套用至整個群組。