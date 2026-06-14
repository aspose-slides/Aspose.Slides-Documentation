---
title: 在 Android 上的簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/androidjava/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java，將您的 PPT 與 PPTX 檔案轉換為具備進階形狀效果的檔案——在數秒內打造醒目且專業的簡報投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用來讓形狀脫穎而出，但它們不同於[填色](/slides/zh-hant/androidjava/shape-formatting/#gradient-fill)或輪廓。使用 PowerPoint 效果，您可以在形狀上製作逼真的反射、擴散形狀的發光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六種可套用於形狀的效果。您可以對同一個形狀套用一個或多個效果。  
* 某些效果組合比其他組合更好看。為此，PowerPoint 在 **Preset** 下提供了預設選項。Preset 選項實際上是一組已知外觀良好的兩種或以上效果的組合。這樣，只要選取預設，您就不必花時間測試或自行組合不同效果以找出不錯的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/EffectFormat) 類別中提供屬性與方法，讓您能在 PowerPoint 簡報的形狀上套用相同的效果。

## **套用陰影效果**

以下 Java 程式碼示範如何將外部陰影效果（[OuterShadowEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) 套用至矩形：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **套用反射效果**

以下 Java 程式碼示範如何將反射效果套用至形狀：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **套用發光效果**

以下 Java 程式碼示範如何將發光效果套用至形狀：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **套用柔和邊緣效果**

以下 Java 程式碼示範如何將柔和邊緣效果套用至形狀：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以將陰影、反射、發光等不同效果組合在同一個形狀上，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包含自動圖形、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，您可以對群組形狀套用效果。該效果將套用至整個群組。