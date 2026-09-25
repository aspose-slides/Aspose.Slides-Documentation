---
title: 在 Java 中建立與套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/java/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 反射效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中建立與自訂 WordArt 效果。本步驟指南協助開發人員在 Java 中以專業文字提升簡報。"
---
## **概覽**

WordArt 效果讓您可以使用填充、輪廓、陰影、反射、發光、變形和 3D 格式化來樣式化文字。本文說明如何在未安裝 Microsoft Office 的情況下，使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立與自訂這些效果。

## **建立簡易 WordArt 範本並套用至文字**

以下範例透過設定文字、字型、圖案填滿與輪廓來建立簡易的 WordArt 風格。

每個範例都會建立一個新簡報，並在第一張投影片上新增一個矩形；不需要任何輸入檔案。第一個範例將文字設定為「Aspose.Slides」。形狀的位置與尺寸以點 (points) 為單位：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

將字型設定為 36 點的 Arial Black，以更明顯地呈現格式設定：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

套用 [SmallGrid](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/patternstyle/#SmallGrid) 圖案，前景為深橙色、背景為白色，然後加入寬度為 1 點的黑色文字輪廓：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![簡易 WordArt 範本](WordArt_template.png)

## **套用其他 WordArt 效果**

以下範例示範如何將陰影、反射、發光、變形和 3D 效果套用至文字。

### **套用外部陰影效果**

外部陰影透過在文字後方放置陰影來增加深度。您可以自訂其顏色、方向、距離、模糊半徑、比例與斜切。

此範例呼叫 [enableOuterShadowEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--)，並設定一個模糊半徑為 4 點、方向為 230 度、距離為 30 點的黑色陰影。比例值為 100 會保留陰影大小，而水平斜切會將其傾斜 20 度。Alpha 變換將不透明度設為 32%：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![外部陰影效果](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 當同時使用外部陰影和預設陰影時，僅會套用外部陰影。
- 若同時使用外部與內部陰影，最終效果取決於 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果會加倍；而在 PowerPoint 2007 中，僅套用外部陰影。
{{% /alert %}}

### **套用反射效果**

反射會產生文字的鏡像副本。調整其位置、比例、模糊與不透明度以控制外觀。

此範例呼叫 [enableReflectionEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effectformat/#enableReflectionEffect--)，將反射垂直翻轉，比例為 -100%。使用 0.5 點的模糊半徑與 4.72 點的距離。沿反射的 0% 到 60% 位置，不透明度從 60% 下降至 0.9%：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![反射效果](reflection_effect.png)

### **套用發光效果**

發光會在文字周圍添加柔和的彩色輪廓。調整其顏色、不透明度與半徑以控制效果。

此範例呼叫 [enableGlowEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effectformat/#enableGlowEffect--)，套用一個不透明度為 54%、半徑為 7 點的紅色發光：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![發光效果](glow_effect.png)

### **套用 WordArt 變形**

WordArt 變形會彎曲、拉伸或扭曲文字區塊。

將 [setTransform](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframeformat/#setTransform-int-) 設為 [ArchUpPour](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textshapetype/#ArchUpPour) 以將整個文字框向上彎曲：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![WordArt 變形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java 提供一組預先定義的 [transformation types](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textshapetype/)。
{{% /alert %}}

### **套用 3D 效果至形狀和文字**

您可以對形狀或其文字套用 3D 效果。斜角、擠出、光照與相機設定會控制最終外觀。

以下範例使用 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 為矩形加入圓形斜角、橙色擠出以及深紅色輪廓。斜角尺寸、擠出高度、輪廓寬度與深度皆以點為單位。塑膠材質、繞 Z 軸旋轉 40 度的均衡光照，以及透視相機共同定義其外觀：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

產生的形狀如下：

![形狀 3D 效果](shape_3D_effect.png)

此範例透過 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframeformat/#getThreeDFormat--) 為文字套用類似的 3D 格式。較小的斜角塑造字母邊緣，而擠出與光照則為文字提供深度：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

產生的文字如下：

![文字 3D 效果](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
將 3D 效果套用於文字或其形狀——以及這些效果之間的交互——受到特定規則的管轄。請考慮同時包含文字與其容納形狀的場景。3D 效果包括對象的 3D 表示以及其所在的場景。

- 如果同時為形狀與文字設定了場景，則以形狀的場景為優先，文字的場景會被忽略。
- 如果形狀本身沒有場景，但有 3D 表示，則使用文字的場景。
- 如果形狀根本沒有 3D 效果，則視為平面，且僅對文字套用 3D 效果。

這些行為與 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/#getLightRig--) 與 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/#getCamera--) 方法有關。
{{% /alert %}}

若要在保持文字平面且易讀的同時保留形狀的 3D 格式，請參閱 [Keep Text Flat on a 3D Shape](/slides/zh-hant/java/3d-presentation/) 以比較兩種設定並取得完整的 Java 範例。

## **常見問題**

**我可以在不同字體或文字系統（例如阿拉伯文、中文）中使用 WordArt 效果嗎？**

是的，Aspose.Slides for Java 支援 Unicode，且可與所有主要字體與文字系統一起使用。無論語言為何，都可套用如陰影、填充與輪廓等 WordArt 效果，但字體的可用性與呈現可能取決於系統字體。

**我可以將 WordArt 效果套用至投影片母片元素嗎？**

是的，您可以將 WordArt 效果套用到母片投影片上的形狀，包括標題佔位符、頁腳或背景文字。對母片版面所做的變更會套用至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會有少量影響。陰影、發光、漸層填充等 WordArt 效果會因為額外的格式設定資料而略微增加檔案大小，但差異通常可以忽略不計。

**我可以在不儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

是的，您可以使用 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage--) 將包含 WordArt 的投影片渲染成圖像（例如 PNG、JPEG），或使用 [IShape.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage--) 渲染單一形狀。這樣可以在記憶體或螢幕上預覽結果，無需先儲存或匯出完整簡報。