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
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js，將您的 PPT 與 PPTX 檔案轉換為先進的形狀效果——在數秒內打造引人注目、專業的投影片。"
---
## **Introduction**

在 PowerPoint 中，效果可用於使形狀突出，但它們不同於 [fills](/slides/zh-hant/nodejs-java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射，擴散形狀的發光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。 

* 某些效果組合看起來比其他的更好。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項本質上是兩個或多個效果的已知好看組合。透過選擇預設，您就不必花時間測試或組合不同的效果來找出合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/EffectFormat) 類別中提供屬性與方法，讓您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

以下 JavaScript 程式碼示範如何將外部陰影效果（[getOuterShadowEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)）套用於矩形：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **套用反射效果**

以下 JavaScript 程式碼示範如何將反射效果套用於形狀：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **套用發光效果**

以下 JavaScript 程式碼示範如何將發光效果套用於形狀：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **套用柔化邊緣效果**

以下 JavaScript 程式碼示範如何將柔化邊緣套用於形狀：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在同一個形狀上結合不同的效果，如陰影、反射和發光，以打造更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。效果將套用於整個群組。