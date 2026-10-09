---
title: 在簡報中使用 Java 套用圖形效果
linktitle: 圖形效果
type: docs
weight: 30
url: /zh-hant/java/shape-effect/
keywords:
- 圖形效果
- 陰影效果
- 反射效果
- 發光效果
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 以先進的圖形效果轉換您的 PPT 與 PPTX 檔案—在幾秒鐘內建立引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用來讓圖形突顯，但它們與 [填色](/slides/zh-hant/java/shape-formatting/#gradient-fill) 或輪廓不同。使用 PowerPoint 效果，您可以在圖形上創建逼真的反射、擴散圖形的發光等。

![圖形效果](shape-effect.png)

PowerPoint 提供六種可套用於圖形的效果。您可以對圖形套用一個或多個效果。

某些效果組合看起來比其他的更好。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項是已知外觀良好的兩種或以上效果的組合。透過選取預設，您就不必浪費時間測試或組合不同效果以找出好的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 類別下提供屬性和方法，讓您能在 PowerPoint 簡報中對圖形套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Java 支援圖形的外部陰影與內部陰影。您可以自訂其顏色、方向、距離和模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中突顯。陰影延伸至圖形邊緣之外，營造圖形從投影片上方凸起的感覺。調整其顏色、方向、距離和模糊半徑，以匹配範本的光線與樣式。

以下 Java 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) 套用到矩形：

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

在重製範本的視覺樣式時，使用內部陰影可讓卡片或面板呈現凹陷外觀。外部陰影延伸至圖形之外，使其看起來凸起，而內部陰影則在其邊緣內側加暗。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 回傳的陰影。較大的模糊半徑值會產生較柔和的邊緣。

以下 Java 範例建立一個淡藍色卡片，並加入深灰色內部陰影，然後將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![淡藍色矩形的內部陰影](inner_shadow_effect.png)

若要移除內部陰影，請在圖形的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **套用反射效果**

在 Aspose.Slides for Java 中套用反射效果時，您可以為圖形新增鏡面般的反射，並調整距離、透明度與大小等參數。此效果可提升簡報的美感，讓圖形看起來更精緻且具專業感。只需簡單程式碼即可輕鬆實作，讓多個元素快速套用，保持一致的設計。

以下 Java 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) 套用到圖形：

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

在 Aspose.Slides for Java 中為圖形套用發光效果時，您可以在圖形周圍添加柔和的光環，並調整顏色與大小等屬性。此效果有助於讓圖形突顯，為簡報增添吸引人且醒目的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 Java 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) 套用到圖形：

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

在 Aspose.Slides for Java 中套用柔化邊緣效果時，您可以在圖形的邊緣創造平滑、模糊的過渡。此效果增添更細膩、精緻的外觀，非常適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中對各種圖形達成理想的效果。

以下 Java 程式碼示範如何將 [柔化邊緣效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) 套用到圖形：

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

## **常見問題**

**我可以在同一個圖形上套用多個效果嗎？**

是的，您可以在單一圖形上結合不同的效果，如陰影、反射與發光，以創造更具動態的外觀。

**我可以對哪些圖形套用效果？**

您可以對各種圖形套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組圖形套用效果嗎？**

是的，您可以對群組圖形套用效果。該效果會套用到整個群組。