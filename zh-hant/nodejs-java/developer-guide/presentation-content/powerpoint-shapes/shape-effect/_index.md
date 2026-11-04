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
description: "使用 JavaScript 與 Aspose.Slides for Node.js 轉換您的 PPT 與 PPTX 檔案，套用進階形狀效果 - 在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用於讓形狀脫穎而出，但它們與 [填充](/slides/zh-hant/nodejs-java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在形狀上創建逼真的倒影、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對一個形狀套用一個或多個效果。

某些效果的組合比其他組合更好看。基於此原因，PowerPoint 在 **Preset** 下提供選項。Preset 選項是已知外觀良好的兩種或以上效果的組合。這樣，透過選取預設，您就不必浪費時間測試或組合不同的效果以尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 類別下提供屬性與方法，讓您能將相同的效果套用於 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for Node.js via Java 支援形狀的外部和內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中凸顯。陰影超出形狀邊緣，營造形狀從投影片上方升起的效果。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

以下 JavaScript 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) 套用到矩形：

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

在重現範本的視覺樣式時，使用內部陰影可讓卡片或面板呈現凹陷外觀。外部陰影延伸至形狀外部，使其看起來抬升；而內部陰影則在其邊緣內部著色。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) 取得的陰影。較大的模糊半徑值會產生較柔和的邊緣。

以下 JavaScript 範例建立一個淺藍色卡片，帶有深灰色內部陰影，並將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![帶內部陰影的淺藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請於形狀的 effect format 呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **套用反射效果**

在 Aspose.Slides for Node.js via Java 中套用反射效果時，您可以為形狀新增類似鏡面的反射，並調整距離、透明度與大小等參數。此效果透過為形狀賦予更光滑、精緻的外觀，提升簡報的美感。只需簡單程式碼即可輕鬆實作，快速套用於多個元素以維持一致的設計。

以下 JavaScript 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) 套用到形狀：

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

在 Aspose.Slides for Node.js via Java 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀突顯，並為簡報增添吸引目光的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體觀感。

以下 JavaScript 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) 套用到形狀：

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

在 Aspose.Slides for Node.js via Java 中套用柔和邊緣效果時，您可以在形狀的邊緣產生平滑、模糊的過渡。此效果提供更細膩、精緻的外觀，適用於需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種形狀上達成理想的效果。

以下 JavaScript 程式碼示範如何將 [柔和邊緣效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) 套用到形狀：

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

使用形狀模糊可使形狀的填色與輪廓變得柔和，同時保持形狀仍可編輯。於形狀的 effect format 呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)。半徑以點 (1/72 英寸) 為單位：使用非負值，較大的值會產生更強的模糊。半徑為零則保持外觀不變。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定控制效果的可見範圍。設定為 `false` 時，模糊會被裁剪至原始繪製範圍，包括輪廓；設定為 `true` 時，模糊可延伸超出該範圍。兩種設定皆不會改變形狀的位置或尺寸。

以下比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形比較，模糊半徑為 5 與 15 點，grow 停用與啟用](shape_blur_comparison.png)

以下 JavaScript 範例建立一個橙色矩形，搭配深藍色輪廓，先套用 5 點的模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) 將其更新為 15 點的模糊。它會儲存兩個模糊狀態，接著呼叫 [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) 並儲存未模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊僅會柔化陰影。影像轉換效果作用於影像內容；此範例直接對形狀的 effect format 套用模糊，而不將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果會套用至整個群組。