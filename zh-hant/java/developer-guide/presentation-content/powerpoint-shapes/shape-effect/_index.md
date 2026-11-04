---
title: 在簡報中使用 Java 套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔和邊緣效果
- 效果格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 轉換您的 PPT 與 PPTX 檔案，透過進階形狀效果在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

雖然 PowerPoint 中的效果可用於讓形狀突出，但它們不同於 [填色](/slides/zh-hant/java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

![形狀效果](shape-effect.png)

PowerPoint 提供六種可套用於形狀的效果。您可以對形狀套用一個或多個效果。

某些效果組合比其他的更好看。基於此原因，PowerPoint 在 **Preset** 下提供選項。Preset 選項是已知看起來不錯的兩種或更多效果的組合。這樣，透過選取預設，您就不必浪費時間測試或組合不同的效果以找出理想的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 類別中提供屬性與方法，使您能在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

Aspose.Slides for Java 支援形狀的外部與內部陰影。您可以自訂其顏色、方向、距離與模糊半徑，以符合簡報的設計。

### **套用外部陰影**

使用外部陰影可讓卡片或面板在投影片背景中脫穎而出。陰影延伸至形狀邊緣之外，產生形狀在投影片上方抬升的感覺。調整其顏色、方向、距離與模糊半徑，以符合範本的光線與樣式。

以下 Java 程式碼示範如何對矩形套用 [外部陰影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)：

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

在重製範本的視覺樣式時，使用內部陰影可為卡片或面板營造凹陷的外觀。外部陰影延伸至形狀外部，使其看起來抬升，而內部陰影則在其邊緣內側產生陰影。

呼叫 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然後設定由 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 取得的陰影。較大的模糊半徑值會產生較柔和的邊緣。

以下 Java 範例建立一個淡藍色卡片，並加上深灰色內部陰影，將其儲存為 PPTX 檔案。陰影方向為 225 度，距離為 7 點，模糊半徑為 6 點：

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

![內部陰影的淡藍色矩形](inner_shadow_effect.png)

若要移除內部陰影，請在形狀的 effect format 上呼叫 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **套用反射效果**

要在 Aspose.Slides for Java 中套用反射效果，您可以為形狀加入鏡面般的反射，並調整距離、透明度與大小等參數。此效果提升簡報的美感，使形狀更具光澤與精緻感。透過簡單程式碼即可輕鬆實作，快速套用於多個元素以維持一致的設計。

以下 Java 程式碼示範如何對形狀套用 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)：

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

要在 Aspose.Slides for Java 中為形狀套用發光效果，您可以在形狀周圍加入柔和、發光的光環，並調整顏色與大小等屬性。此效果有助於讓形狀更突出，為簡報增添吸睛的視覺元素。只需極少程式碼即可輕鬆實作，提升投影片的整體外觀。

以下 Java 程式碼示範如何對形狀套用 [發光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)：

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

## **套用柔和邊緣效果**

要在 Aspose.Slides for Java 中套用柔和邊緣效果，您可以在形狀的邊緣製造平滑、模糊的過渡。此效果帶來更細緻、精緻的外觀，適合需要柔和外觀的設計。您可以輕鬆調整半徑等參數，以在簡報中各種形狀上實現期望的效果。

以下 Java 程式碼示範如何對形狀套用 [柔和邊緣效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)：

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

![柔和邊緣效果](soft_edges_effect.png)

## **套用模糊效果**

使用形狀模糊可在保持形狀可編輯的情況下柔化其填色與輪廓。請在形狀的 effect format 上呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)。半徑以點為單位（1/72 英吋）：使用非負值，較大的值會產生更強的模糊。半徑為零則不會改變外觀。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 設定控制效果的可見範圍。設定為 `false` 時，模糊會被裁剪至原始繪製的範圍，包括輪廓。設定為 `true` 時，模糊可延伸超出該範圍。此設定皆不會改變形狀的位置或尺寸。

以下比較使用相同的填色、輪廓與形狀尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形與模糊半徑 5 點與 15 點的比較（grow 關閉與開啟）](shape_blur_comparison.png)

以下 Java 範例建立一個橙色矩形，並使用深藍色輪廓，先套用 5 點的模糊，然後再次呼叫 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 變更為 15 點的模糊。它會儲存兩個模糊狀態，之後呼叫 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) 並儲存未套用模糊的形狀。

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

形狀模糊同時影響填色與輪廓。柔和邊緣效果會淡化形狀的邊緣，而陰影模糊則僅柔化陰影。影像變換效果作用於影像內容；此範例直接對形狀的 effect format 套用模糊，而不將形狀轉換為影像。

## **常見問題**

**我可以對同一個形狀套用多個效果嗎？**

是的，您可以在單一形狀上結合不同的效果，如陰影、反射與發光，以產生更具動態性的外觀。

**我可以對哪些形狀套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

是的，您可以對群組形狀套用效果。該效果會套用於整個群組。