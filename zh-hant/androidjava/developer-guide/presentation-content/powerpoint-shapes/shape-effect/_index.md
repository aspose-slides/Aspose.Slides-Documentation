---
title: 在 Android 簡報中套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/androidjava/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，將您的 PPT 與 PPTX 檔案轉換為高級形狀效果——在幾秒鐘內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可用於突出顯示形狀，但它們不同於 [填色](/slides/zh-hant/androidjava/shape-formatting/#gradient-fill) 或輪廓線。使用 PowerPoint 效果，您可以在形狀上創建逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果的組合比其他組合更好看。鑑於此，PowerPoint 在 **預設** 下提供選項。預設選項是兩個以上效果的組合，已知能產生良好效果。如此一來，選擇預設後，您就不必花時間測試或組合不同的效果以找到理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 類別中提供屬性與方法，使您能將相同的效果套用於 PowerPoint 簡報中的形狀。

## **套用陰影效果**

Aspose.Slides for Android via Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中突顯。陰影延伸至形狀邊緣之外，產生形狀凸起於投影片之上的印象。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

以下 Java 程式碼示範如何將 [外部陰影效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) 套用於矩形：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![陰影效果](shadow_effect.png)

### **套用內部陰影**

在重現範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來凸起，而內部陰影則在邊緣內側加暗。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) 取得的陰影。較大的模糊半徑值會產生較柔和的邊緣。

以下 Java 範例建立一個淡藍色卡片，並套用深灰色內部陰影，將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![淡藍色矩形帶內部陰影](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的效果格式上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **套用反射效果**

在 Aspose.Slides for Android via Java 中套用反射效果時，您可以為形狀加入鏡像般的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀呈現更精緻、專業的外觀。只需簡單程式碼即可輕鬆實作，讓多個元素快速套用，以達成一致的設計。

以下 Java 程式碼示範如何將 [反射效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) 套用於形狀：

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

在 Aspose.Slides for Android via Java 中為形狀套用發光效果時，您可以在形狀周圍加入柔和、發光的光暈，並調整顏色與大小等屬性。此效果有助於讓形狀突出，為簡報增添吸引人、引人注目的視覺元素。只需少量程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 Java 程式碼示範如何將 [發光效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) 套用於形狀：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

在 Aspose.Slides for Android via Java 中套用柔化邊緣效果時，您可以在形狀的邊緣建立平滑、模糊的過渡。此效果提供更細緻、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種形狀上達成理想的效果。

以下 Java 程式碼示範如何將 [柔化邊緣效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) 套用於形狀：

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

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，例如陰影、反射與發光，以產生更具動態的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。效果會套用到整個群組。